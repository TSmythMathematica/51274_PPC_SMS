'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data
Imports System.Windows.Forms
Imports MPR.SMS.Data
Imports MPR.SMS.Data.BaseClasses
Imports MPR.SMS.DataQuality.wsMelissaData


Public Class DataQuality
    Implements IDataquality
    'This is a wrapper class for the Melissa Data Corp Data Quality 
    'Web-Service (DQWS). This service will verify and clean Names,
    'Addresses and Phones. 
    '
    'Example applications of this service are:
    '1. Verify & Correct addresses
    '2. GeoCode an address (get latituded/longitude). Find the distance 
    '   between two GeoCoded addresses
    '3. Parse combined names into First, Middle, Last, Suffix, Prefix, etc.
    '4. Determine Gender based on Name.
    '5. Verify Phone #'s based on Area Code and Prefix
    '6. Get recent Area Code changes
    '7. Parse combined Phone # into Area Code, Prefix, Suffix
    '8. Get Time-Zone and TZCode from Phone
    '
    'The above applications can be used in SMS in several ways, including:
    'A. In the UI, add a button to verify/correct a particular address or phone.
    'B. For Respondent Payment Address Verification, add a button to 
    '   Auto-Approve pending addresses.
    'C. For Sample load imports, clean Addresses and Phones, and parse Names.

#Region "Private Declarations"

    Private Const CustomerID As String = "112615433"
    Private Const MaxArraySize As Integer = 100
    Private ReadOnly _GeoCodeEnabled As Boolean
    Private _TransactionStarttime As Date
    Private _TransactionEndtime As Date
    Private _isCancelBatch As Boolean
    Private ReadOnly _resultCodes As DataTable

#End Region

#Region "Public Declarations"

    Public _IsDemo As Boolean = False
    Public _DisplayTransmissionErrors As Boolean = True
    Public _SaveStatusCodes As Boolean = True


#End Region

#Region "Constructors"

    Public Sub New(isDemo As Boolean, SaveStatusCodes As Boolean, GeocodeEnabled As Boolean)
        _SaveStatusCodes = SaveStatusCodes
        If isDemo Then

            _GeoCodeEnabled = True
        Else
            _GeoCodeEnabled = GeocodeEnabled
            'TlkpMelissaResultCode.ConnectionProvider = Project.ConnectionProvider
            ' dtMelissaResultCodes = TlkpMelissaResultCode.SelectAll()
            'CleanCodes = GetCleanCodes()
            _resultCodes = GetResultCodes()
        End If
    End Sub

#End Region

#Region "Events"

    Public Event BatchProgressUpdate As EventHandler(Of BatchProgressArgs) Implements IDataquality.BatchProgressUpdate
    Public Event BatchCancelled() Implements IDataquality.BatchCancelled

#End Region

#Region "Enums"

    Public Enum DataStatusCode As Integer
        NoError = 0
        ParsingError = 1
    End Enum

    Enum DataCleaningTypeEnum As Integer
        Address = 1
        Name = 2
        Phone = 3
        Email = 4
        Geocode = 5
    End Enum

#End Region

#Region "Public Properties"

#End Region

    Public Sub Msg(strMessage As String, strTitle As String)
        MessageBox.Show(strMessage, strTitle)
    End Sub

#Region "AddressFunctions"

    Private Function InitializeAdd(Arraysize As Integer) As RequestArray
        ' Initialize new instance of Request Array

        Dim ReqAddressArray As New RequestArray
        ReDim ReqAddressArray.Record(Arraysize)

        ' Set Customer ID and Transmission Reference (Optional)
        ReqAddressArray.CustomerID = CustomerID
        ReqAddressArray.TransmissionReference = "DQWS SOAP Address Check"
        ReqAddressArray.OptAddressParsed = "True"

        Return ReqAddressArray
    End Function

    Private Function TranslateAddressOutput(ResAddressArrayRecord As ResponseArrayRecord, DirtyAddress As DQAddress) _
        As ProcessedAddress
        'Grab the output
        Dim AddressOutput As New ProcessedAddress
        AddressOutput.Address1 = ResAddressArrayRecord.Address.Address1
        AddressOutput.Address2 = ResAddressArrayRecord.Address.Address2
        If ResAddressArrayRecord.Address.Address2.Length + ResAddressArrayRecord.Address.Suite.Length < 60 Then
            AddressOutput.Address2 = LTrim(AddressOutput.Address2 + " ") + ResAddressArrayRecord.Address.Suite
        Else
            AddressOutput.Address3 = LTrim(AddressOutput.Address3 + " ") + ResAddressArrayRecord.Address.Suite
        End If
        Dim dtMelissaResultCodes As DataTable = GetResultCodes()

        AddressOutput.City = ResAddressArrayRecord.Address.City.Name
        AddressOutput.Company = ResAddressArrayRecord.Address.Company
        AddressOutput.Country = ResAddressArrayRecord.Address.Country.Name
        AddressOutput.Plus4 = ResAddressArrayRecord.Address.Plus4
        AddressOutput.Postalcode = ResAddressArrayRecord.Address.Zip
        AddressOutput.Zip5 = ResAddressArrayRecord.Address.Zip
        AddressOutput.Suite = ResAddressArrayRecord.Address.Suite
        AddressOutput.State = ResAddressArrayRecord.Address.State.Abbreviation
        AddressOutput.Results = ParseResults(ResAddressArrayRecord.Results, dtMelissaResultCodes)
        'AddressOutput.ResultsList = ParseResultsList(ResAddressArrayRecord.Results)
        AddressOutput.isClean = isclean(ResAddressArrayRecord.Results)
        AddressOutput.caseid = DirtyAddress.caseid
        AddressOutput.id = DirtyAddress.id
        AddressOutput.Longitude = "0"
        AddressOutput.Latitude = "0"
        Return AddressOutput
    End Function

    Private Function TranslateAddressOutput(ResAddressArrayRecord As ResponseArrayRecord, Address As DQAddress,
                                            ResGeoCodeArrayRecord As dqwsGeoCodeCheck.ResponseArrayRecord) _
        As ProcessedAddress
        'Grab the output
        Dim GeoCodeAddressOutput As ProcessedAddress
        Dim GeoCodeStatus As DQStatus

        Dim dtMelissaResultCodes As DataTable = GetResultCodes()

        GeoCodeAddressOutput = TranslateAddressOutput(ResAddressArrayRecord, Address)

        GeoCodeAddressOutput.Latitude = ResGeoCodeArrayRecord.Address.Latitude()
        GeoCodeAddressOutput.Longitude = ResGeoCodeArrayRecord.Address.Longitude()
        GeoCodeStatus = ParseResults(ResGeoCodeArrayRecord.Results, dtMelissaResultCodes)

        GeoCodeAddressOutput.Results.Code += GeoCodeStatus.Code
        GeoCodeAddressOutput.Results.Description += GeoCodeStatus.Description

        Return GeoCodeAddressOutput
    End Function

    Private Function FillAddressRequestArrayRecord(Address As DQAddress) As RequestArrayRecord
        Dim objMelissaDataAddress As New RequestArrayRecord

        objMelissaDataAddress.Company = Address.Company
        objMelissaDataAddress.AddressLine1 = Address.Address
        objMelissaDataAddress.AddressLine2 = Address.Address2
        objMelissaDataAddress.City = Address.City
        objMelissaDataAddress.State = Address.State
        objMelissaDataAddress.Zip = Address.Zip5
        objMelissaDataAddress.Plus4 = Address.Plus4
        objMelissaDataAddress.Country = Address.Country

        Return objMelissaDataAddress
    End Function

    Private Function GetNextAddressBatch(BatchNumber As Integer, Addresses As List(Of DQAddress),
                                         NumRecordsThisBatch As Integer, StartIndex As Integer) As RequestArray
        Dim ReqAddressArray As New RequestArray
        ReqAddressArray = InitializeAdd(MaxArraySize - 1)

        For i As Integer = 0 To NumRecordsThisBatch
            Dim CurrentAddressRecord As DQAddress = Addresses.Item(StartIndex + i)
            ReqAddressArray.Record(i) = FillAddressRequestArrayRecord(CurrentAddressRecord)
        Next
        Return ReqAddressArray
    End Function

    Private Function SendAddressBatchToMelissa(ReqAddressArray As RequestArray) As ResponseArray
        Dim ResAddressArray As ResponseArray
        Dim AddressCheckClient As New Service

        _TransactionStarttime = Now
        ResAddressArray = AddressCheckClient.doAddressCheck(ReqAddressArray)
        _TransactionEndtime = Now

        Return ResAddressArray
    End Function

    Private Sub SaveAddressCleaningResults(CleanedAddresses As List(Of ProcessedAddress), TransactionStatus As DQStatus)
        If _SaveStatusCodes Then
            Dim CommunicationID As Integer

            CommunicationID = WriteTransactionResultsToDB(TransactionStatus.Code, CleanedAddresses.Count, "Address")

            For Each Record As ProcessedAddress In CleanedAddresses
                WriteCleaningResultsToDB(DataCleaningTypeEnum.Address, Record.id, Record.Results.Code,
                                         Record.Results.Description, Record.caseid, CommunicationID)
            Next
        End If
    End Sub


    Public Function ProcessAddresses(Addresses As List(Of DQAddress)) As List(Of ProcessedAddress) _
        Implements IDataquality.ProcessAddresses
        _isCancelBatch = False
        Dim ReqAddressArray As RequestArray
        Dim ResAddressArray As ResponseArray
        Dim CleanedAddresses As New List(Of ProcessedAddress)


        'Determine the number of total batches of 100. The last batch will have fewer than 100
        Dim NumBatches As Integer = CInt(Math.Ceiling(Addresses.Count/MaxArraySize)) - 1

        For BatchNumber As Integer = 0 To NumBatches

            If _isCancelBatch = False Then
                Dim NumRecordsThisBatch As Integer
                Dim StartIndex As Integer

                StartIndex = BatchNumber*MaxArraySize

                If BatchNumber = NumBatches Then 'True if this is the last
                    NumRecordsThisBatch = Addresses.Count - StartIndex
                Else
                    NumRecordsThisBatch = MaxArraySize ' Only use the last few records for the last batch. 
                End If

                ReqAddressArray = GetNextAddressBatch(BatchNumber, Addresses, NumRecordsThisBatch - 1, StartIndex)

                ResAddressArray = SendAddressBatchToMelissa(ReqAddressArray)

                If _GeoCodeEnabled Then
                    Dim ResGeoCodeArray As dqwsGeoCodeCheck.ResponseArray
                    ResGeoCodeArray = GeoCodeAddresses(ResAddressArray)

                    For i As Integer = 0 To CInt(ResAddressArray.TotalRecords) - 1
                        CleanedAddresses.Add(TranslateAddressOutput(ResAddressArray.Record(i), Addresses(StartIndex + i),
                                                                    ResGeoCodeArray.Record(i)))
                    Next

                Else
                    For i As Integer = 0 To CInt(ResAddressArray.TotalRecords) - 1
                        CleanedAddresses.Add(TranslateAddressOutput(ResAddressArray.Record(i), Addresses(StartIndex + i)))
                    Next
                End If

                Dim TransactionStatus As DQStatus
                TransactionStatus = GetTransactionResult(ResAddressArray.Results)
                SaveAddressCleaningResults(CleanedAddresses.GetRange(StartIndex, NumRecordsThisBatch), TransactionStatus)
                OnBatchProcessed(BatchNumber, NumBatches)
            Else
                Exit For
            End If
        Next
        Return CleanedAddresses
    End Function

#End Region

#Region "GeoCode"

    Private Function InitializeGeo(ArraySize As Integer) As dqwsGeoCodeCheck.RequestArray
        'GeoCode objects
        Dim ReqGeoCodeCheck As New dqwsGeoCodeCheck.RequestArray

        ReDim ReqGeoCodeCheck.Record(ArraySize)

        ' Set Customer ID and Transmission Reference (Optional)
        ReqGeoCodeCheck.CustomerID = CustomerID
        ReqGeoCodeCheck.TransmissionReference = "DQWS SOAP GeoCode"

        Return ReqGeoCodeCheck
    End Function

    Private Function SendGeoCodeBatchToMelissa(ReqGeoCodeArray As dqwsGeoCodeCheck.RequestArray) _
        As dqwsGeoCodeCheck.ResponseArray
        Dim GeoCodeCheckClient As New dqwsGeoCodeCheck.Service
        Dim ResGeoCodeArray As New dqwsGeoCodeCheck.ResponseArray

        _TransactionStarttime = Now
        ResGeoCodeArray = GeoCodeCheckClient.doGeoCode(ReqGeoCodeArray)
        _TransactionEndtime = Now

        Return ResGeoCodeArray
    End Function

    Private Sub SaveGeocodeCleaningResults(ResGeoCodeArray As dqwsGeoCodeCheck.ResponseArray,
                                           TransactionStatus As DQStatus)
        If _SaveStatusCodes Then
            Dim CommunicationID As Integer

            CommunicationID = WriteTransactionResultsToDB(TransactionStatus.Code, CInt(ResGeoCodeArray.TotalRecords),
                                                          "GeoCode")
        End If
    End Sub

    Public Function GeoCodeAddresses(AddressArray As ResponseArray) As dqwsGeoCodeCheck.ResponseArray
        Dim ReqGeoCodeArray As dqwsGeoCodeCheck.RequestArray
        Dim ResGeoCodeArray As dqwsGeoCodeCheck.ResponseArray

        ReqGeoCodeArray = InitializeGeo(CInt(AddressArray.TotalRecords))

        Dim N As Integer
        For N = 1 To CInt(AddressArray.TotalRecords)

            'Fill in the address values from the address batch that we are already using
            ReqGeoCodeArray.Record(N - 1) = New dqwsGeoCodeCheck.RequestArrayRecord
            ReqGeoCodeArray.Record(N - 1).AddressKey = AddressArray.Record(N - 1).Address.AddressKey.ToString
        Next

        ResGeoCodeArray = SendGeoCodeBatchToMelissa(ReqGeoCodeArray)

        Dim TransactionStatus As DQStatus
        TransactionStatus = GetTransactionResult(ResGeoCodeArray.Results)


        SaveGeocodeCleaningResults(ResGeoCodeArray, TransactionStatus)
        Return ResGeoCodeArray
    End Function

#End Region

#Region "NameFunctions"

    Private Function InitializeName(ArraySize As Integer) As dqwsNameCheck.RequestArray
        ' Initialize new instance of Request Array
        ' Change the MaxArraySize value to the maximum number of records you with to insert
        Dim ReqNameCheck As New dqwsNameCheck.RequestArray

        ReDim ReqNameCheck.Record(ArraySize)

        ReqNameCheck.Record(1) = New dqwsNameCheck.RequestArrayRecord

        ' Set Customer ID and Transmission Reference (Optional)
        ReqNameCheck.CustomerID = CustomerID
        ReqNameCheck.TransmissionReference = "DQWS SOAP Name Check"

        'ReqNameCheck.OptCorrectSpelling = cmbSpelling.Text

        ' First Clear the Original Settings
        ReqNameCheck.OptGenderAggression = ""
        ReqNameCheck.OptGenderPopulation = ""
        ReqNameCheck.OptNameHint = ""

        Return ReqNameCheck
    End Function

    Private Function TranslateNameOutput(ResNameArrayRecord As dqwsNameCheck.ResponseArrayRecord, DirtyName As DQName) _
        As ProcessedName
        Dim CleanedName As New ProcessedName
        Dim dtMelissaResultCodes As DataTable = GetResultCodes()

        CleanedName.First = ResNameArrayRecord.Name.First
        CleanedName.Last = ResNameArrayRecord.Name.Last
        CleanedName.Gender = ResNameArrayRecord.Name.Gender
        CleanedName.Middle = ResNameArrayRecord.Name.Middle
        CleanedName.Prefix = ResNameArrayRecord.Name.Prefix
        CleanedName.Suffix = ResNameArrayRecord.Name.Suffix
        CleanedName.Isclean = isclean(ResNameArrayRecord.Results)


        CleanedName.Results = ParseResults(ResNameArrayRecord.Results, dtMelissaResultCodes)

        CleanedName.caseid = DirtyName.caseid
        CleanedName.id = DirtyName.id
        Return CleanedName
    End Function

    Private Function FillNameRequestArrayRecord(Name As DQName) As dqwsNameCheck.RequestArrayRecord
        Dim objMelissaDataName As New dqwsNameCheck.RequestArrayRecord

        objMelissaDataName.FullName = Name.Fullname

        Return objMelissaDataName
    End Function

    Private Function GetNextNameBatch(BatchNumber As Integer, Names As List(Of DQName), NumRecordsThisBatch As Integer,
                                      StartIndex As Integer) As dqwsNameCheck.RequestArray
        Dim ReqNameArray As New dqwsNameCheck.RequestArray
        ReqNameArray = InitializeName(MaxArraySize - 1)

        For i As Integer = 0 To NumRecordsThisBatch
            Dim CurrentRecord As DQName = Names.Item(StartIndex + i)
            ReqNameArray.Record(i) = FillNameRequestArrayRecord(CurrentRecord)
        Next
        Return ReqNameArray
    End Function

    Private Function SendNameBatchToMelissa(ReqNameCheck As dqwsNameCheck.RequestArray) As dqwsNameCheck.ResponseArray
        Dim ResNameCheck As dqwsNameCheck.ResponseArray
        Dim NameCheckClient As New dqwsNameCheck.Service

        _TransactionStarttime = Now
        ResNameCheck = NameCheckClient.doNameCheck(ReqNameCheck)
        _TransactionEndtime = Now

        Return ResNameCheck
    End Function

    Private Sub SaveNameCleaningResults(CleanedNames As List(Of ProcessedName), TransactionStatus As DQStatus)
        If _SaveStatusCodes Then
            Dim CommunicationID As Integer

            CommunicationID = WriteTransactionResultsToDB(TransactionStatus.Code, CleanedNames.Count, "Name")

            For Each Record As ProcessedName In CleanedNames
                WriteCleaningResultsToDB(DataCleaningTypeEnum.Name, Record.id, Record.Results.Code,
                                         Record.Results.Description, Record.caseid, CommunicationID)
            Next
        End If
    End Sub

    Public Function ProcessNamesVB(ByRef Names As List(Of DQName)) As List(Of ProcessedName) _
        Implements IDataquality.ProcessNamesVB
        Dim cleanedNames As New List(Of ProcessedName)
        _isCancelBatch = False

        For Each row As DQName In Names
            If _isCancelBatch = False Then
                Dim cleanedName As New ProcessedName

                cleanedName.First = StrConv(row.First, VbStrConv.ProperCase)
                cleanedName.Last = StrConv(row.Last, VbStrConv.ProperCase)
                cleanedName.Gender = row.Gender
                cleanedName.Middle = StrConv(row.Middle, VbStrConv.ProperCase)
                cleanedName.Prefix = row.Prefix
                cleanedName.Suffix = row.Suffix
                cleanedName.Isclean = True

                cleanedName.caseid = row.caseid
                cleanedName.id = row.id
                cleanedName.Results = New DQStatus()

                cleanedNames.Add(cleanedName)

            Else
                Exit For
            End If
        Next
        Return cleanedNames
    End Function

    Public Function ProcessNames(Names As List(Of DQName)) As List(Of ProcessedName) _
        Implements IDataquality.ProcessNames
        Dim CleanedNames As New List(Of ProcessedName)
        _isCancelBatch = False
        Dim ReqNameCheck As dqwsNameCheck.RequestArray
        Dim ResNameArray As dqwsNameCheck.ResponseArray

        ReqNameCheck = InitializeName(MaxArraySize)

        'Determine the number of total batches of 100. The last batch will have fewer than 100
        Dim NumBatches As Integer = CInt(Math.Ceiling(Names.Count/MaxArraySize)) - 1


        For BatchNumber As Integer = 0 To NumBatches
            If _isCancelBatch = False Then
                Dim NumRecordsThisBatch As Integer
                Dim StartIndex As Integer

                StartIndex = BatchNumber*MaxArraySize

                If BatchNumber = NumBatches Then 'True if this is the last
                    NumRecordsThisBatch = Names.Count - StartIndex
                Else
                    NumRecordsThisBatch = MaxArraySize ' Only use the last few records for the last batch. 
                End If

                ReqNameCheck = GetNextNameBatch(BatchNumber, Names, NumRecordsThisBatch - 1, StartIndex)
                ResNameArray = SendNameBatchToMelissa(ReqNameCheck)

                For CurrentRecord As Integer = 0 To NumRecordsThisBatch - 1
                    CleanedNames.Add(TranslateNameOutput(ResNameArray.Record(CurrentRecord),
                                                         Names(StartIndex + CurrentRecord)))
                Next

                Dim TransactionStatus As DQStatus
                TransactionStatus = GetTransactionResult(ResNameArray.Results)

                SaveNameCleaningResults(CleanedNames.GetRange(StartIndex, NumRecordsThisBatch), TransactionStatus)
                OnBatchProcessed(BatchNumber, NumBatches)
            Else
                Exit For
            End If
        Next
        Return CleanedNames
    End Function

#End Region

#Region "PhoneFunctions"

    Private Function InitializePhone(ArraySize As Integer) As dqwsPhoneCheck.RequestArray
        'Set Customer ID and Transmission Reference (Optional)
        Dim ReqPhoneArray As New dqwsPhoneCheck.RequestArray

        ReDim ReqPhoneArray.Record(ArraySize)
        ReqPhoneArray.CustomerID = CustomerID
        ReqPhoneArray.TransmissionReference = "DQWS SOAP Phone Check"

        Return ReqPhoneArray
    End Function

    Private Function GetNextPhoneBatch(BatchNumber As Integer, Phones As List(Of DQPhone),
                                       NumRecordsThisBatch As Integer, StartIndex As Integer) _
        As dqwsPhoneCheck.RequestArray
        Dim ReqPhoneArray As New dqwsPhoneCheck.RequestArray
        ReqPhoneArray = InitializePhone(MaxArraySize - 1)

        For i As Integer = 0 To NumRecordsThisBatch
            Dim CurrentRecord As DQPhone = Phones.Item(StartIndex + i)
            ReqPhoneArray.Record(i) = FillPhoneRequestArrayRecord(CurrentRecord)
        Next
        Return ReqPhoneArray
    End Function

    Private Function FillPhoneRequestArrayRecord(Phone As DQPhone) As dqwsPhoneCheck.RequestArrayRecord
        Dim objMelissaDataPhone As New dqwsPhoneCheck.RequestArrayRecord

        objMelissaDataPhone.Phone = Phone.Telephone

        Return objMelissaDataPhone
    End Function

    Private Function SendPhoneBatchToMelissa(ReqPhoneArray As dqwsPhoneCheck.RequestArray) _
        As dqwsPhoneCheck.ResponseArray
        Dim ResPhoneArray As dqwsPhoneCheck.ResponseArray
        Dim PhoneCheckClient As New dqwsPhoneCheck.Service

        _TransactionStarttime = Now
        ResPhoneArray = PhoneCheckClient.doPhoneCheck(ReqPhoneArray)
        _TransactionEndtime = Now


        Return ResPhoneArray
    End Function

    Private Function TranslatePhoneOutput(ResPhoneArrayrecord As dqwsPhoneCheck.ResponseArrayRecord,
                                          DirtyPhone As DQPhone) As ProcessedPhone
        'Grab the output
        Dim CleanedPhone As New ProcessedPhone
        Dim dtMelissaResultCodes As DataTable = GetResultCodes()
        CleanedPhone.AreaCode = ResPhoneArrayrecord.Phone.AreaCode
        CleanedPhone.NewAreaCode = ResPhoneArrayrecord.Phone.NewAreaCode
        CleanedPhone.Timezone = ResPhoneArrayrecord.Phone.TimeZone.Name
        CleanedPhone.TimezoneCode = ResPhoneArrayrecord.Phone.TimeZone.Code
        CleanedPhone.Prefix = ResPhoneArrayrecord.Phone.Prefix
        CleanedPhone.Suffix = ResPhoneArrayrecord.Phone.Suffix
        CleanedPhone.Telephone = ResPhoneArrayrecord.Phone.Prefix + "" + ResPhoneArrayrecord.Phone.Suffix
        CleanedPhone.Results = ParseResults(ResPhoneArrayrecord.Results, dtMelissaResultCodes)
        CleanedPhone.caseid = DirtyPhone.caseid
        CleanedPhone.isClean = isclean(ResPhoneArrayrecord.Results)
        CleanedPhone.id = DirtyPhone.id

        Return CleanedPhone
    End Function

    Private Sub SavePhoneCleaningResults(CleanedPhones As List(Of ProcessedPhone), TransactionStatus As DQStatus)
        If _SaveStatusCodes Then
            Dim CommunicationID As Integer

            CommunicationID = WriteTransactionResultsToDB(TransactionStatus.Code, CleanedPhones.Count, "Phone")

            For Each Record As ProcessedPhone In CleanedPhones
                WriteCleaningResultsToDB(DataCleaningTypeEnum.Phone, Record.id, Record.Results.Code,
                                         Record.Results.Description, Record.caseid, CommunicationID)
            Next
        End If
    End Sub

    Public Function ProcessPhones(Phones As List(Of DQPhone)) As List(Of ProcessedPhone) _
        Implements IDataquality.ProcessPhones
        Dim CleanedPhones As New List(Of ProcessedPhone)
        _isCancelBatch = False
        Dim ReqPhoneCheck As dqwsPhoneCheck.RequestArray
        Dim ResPhoneArray As New dqwsPhoneCheck.ResponseArray

        ReqPhoneCheck = InitializePhone(MaxArraySize)

        'Determine the number of total batches of 100. The last batch will have fewer than 100
        Dim NumBatches As Integer = CInt(Math.Ceiling(Phones.Count/MaxArraySize)) - 1

        For BatchNumber As Integer = 0 To NumBatches
            If _isCancelBatch = False Then
                Dim NumRecordsThisBatch As Integer
                Dim StartIndex As Integer
                StartIndex = BatchNumber*MaxArraySize

                If BatchNumber = NumBatches Then 'True if this is the last
                    NumRecordsThisBatch = Phones.Count - StartIndex
                Else
                    NumRecordsThisBatch = MaxArraySize ' Only use the last few records for the last batch. 
                End If

                ReqPhoneCheck = GetNextPhoneBatch(BatchNumber, Phones, NumRecordsThisBatch - 1, StartIndex)
                ResPhoneArray = SendPhoneBatchToMelissa(ReqPhoneCheck)
                For CurrentRecord As Integer = 0 To NumRecordsThisBatch - 1
                    CleanedPhones.Add(TranslatePhoneOutput(ResPhoneArray.Record(CurrentRecord),
                                                           Phones(StartIndex + CurrentRecord)))
                Next

                Dim TransactionStatus As DQStatus
                TransactionStatus = GetTransactionResult(ResPhoneArray.Results)

                SavePhoneCleaningResults(CleanedPhones.GetRange(StartIndex, NumRecordsThisBatch), TransactionStatus)
                OnBatchProcessed(BatchNumber, NumBatches)
            Else
                Exit For
            End If
        Next
        Return CleanedPhones
    End Function

    Public Function ComputeDistance(Lat1 As Double, Long1 As Double, Lat2 As Double, Long2 As Double) As Double

        Dim x As Double

        x =
            (Math.Sin(DegToRads(Lat1))*Math.Sin(DegToRads(Lat2)) +
             Math.Cos(DegToRads(Lat1))*Math.Cos(DegToRads(Lat2))*
             Math.Cos(Math.Abs((DegToRads(Long2)) - (DegToRads(Long1)))))
        x = Math.Atan((Math.Sqrt(1 - x^2))/x)
        x = 60.0*((x/Math.PI)*180)*1.1507794480235425

        Return x
    End Function

#End Region


#Region "Private Methods"

    Private Function DegToRads(Deg As Double) As Double

        DegToRads = CDbl(Deg*Math.PI/180)
    End Function

    Public Sub OnBatchProcessed(BatchNumber As Integer, TotalBatches As Integer)
        Dim args As New BatchProgressArgs
        args.BatchesProcessed = BatchNumber + 1
        args.TotalBatches = TotalBatches + 1
        RaiseEvent BatchProgressUpdate(Me, args)
    End Sub

    Private Function isclean(errorCodeString As String) As Boolean
        Dim errorCodeList As String() = Nothing
        Dim errorCode As String

        Dim CleanCodes As List(Of String) = GetCleanCodes()

        errorCodeList = errorCodeString.Split(CChar(","))
        For Each errorCode In errorCodeList
            If CleanCodes.Contains(errorCode) Then
                isclean = True
            End If
        Next errorCode

        Return isclean
    End Function

    Private Function ParseResults(Results As String, dtMelissaResultCodes As DataTable) As DQStatus

        Dim status As New DQStatus

        Dim ResultCodeList As String() = Nothing
        Dim ResultCode As String
        ResultCodeList = Results.Split(CChar(","))

        For Each ResultCode In ResultCodeList
            status.Code += ResultCode + "; "
            For Each DataRow As DataRow In dtMelissaResultCodes.Rows
                If ResultCode = DataRow.Item(1).ToString Then
                    status.Description += ResultCode + ": " + DataRow.Item(2).ToString + ";"
                    Exit For
                End If

            Next
        Next ResultCode
        Return status
    End Function

    Private Sub WriteCleaningResultsToDB(DataCleaningType As Integer, DataID As Integer, CodeString As String,
                                         CodeDesc As String, CaseID As Integer, CommunicationID As Integer)

        Dim MelissaResults As New TblMelissa_Results

        MelissaResults.ConnectionString = GlobalData.Project.ConnectionString
        MelissaResults.ConnectionProvider = GlobalData.Project.ConnectionProvider

        Dim openedHere As Boolean = False

        If Not MelissaResults.ConnectionProvider.Connection.State = ConnectionState.Open Then
            openedHere = MelissaResults.ConnectionProvider.OpenConnection()
        End If

        MelissaResults.Caseid = CaseID.ToString
        MelissaResults.DataType = DataCleaningType
        MelissaResults.ReturnCodeString = CodeString
        MelissaResults.ReturnCodeDescription = CodeDesc
        MelissaResults.CommunicationID = CommunicationID

        'Fill in AddressID/PhoneID/EmailID/MPRID(for name cleaning)

        Select Case DataCleaningType
            Case DataCleaningTypeEnum.Address
                MelissaResults.AddressID = DataID
            Case DataCleaningTypeEnum.Phone
                MelissaResults.PhoneID = DataID
            Case DataCleaningTypeEnum.Email
                MelissaResults.EmailID = DataID
        End Select

        MelissaResults.Insert()

        If openedHere Then
            MelissaResults.ConnectionProvider.Connection.Close()
        End If

        MelissaResults.ConnectionProvider = Nothing
    End Sub
    'Private Sub WriteDataCleaningResultstoDBLinq(ByVal addresses As List(Of ProcessedAddress))

    '    'Dim db As DataContext = New DataContext(Project.ConnectionProvider.ConnectionString)
    '    'Dim queryAddress As IEnumerable(Of ProcessedAddress) = From processedaddress In addresses Select processedaddress

    '    'Dim query = From tlkpmelissaresultcode In db.GetTable(Of tlkpMelissaResultCode) Join processedaddress In addresses On processedaddress.Results.code

    'End Sub


    Private Function WriteTransactionResultsToDB(ResultCode As String, NumberOfRecordsInBatch As Integer,
                                                 TransactionType As String) As Integer _
' this is only used when cleaning single records
        Dim MelissaTblCommunication As New TblMelissa_Communication


        MelissaTblCommunication.ConnectionString = GlobalData.Project.ConnectionString
        MelissaTblCommunication.ConnectionProvider = GlobalData.Project.ConnectionProvider

        Dim openedHere As Boolean = False

        If Not MelissaTblCommunication.ConnectionProvider.Connection.State = ConnectionState.Open Then
            openedHere = MelissaTblCommunication.ConnectionProvider.OpenConnection()
        End If

        MelissaTblCommunication.NumberOfRecords = NumberOfRecordsInBatch
        MelissaTblCommunication.StartDateTime = _TransactionStarttime
        MelissaTblCommunication.EndDateTime = _TransactionEndtime
        MelissaTblCommunication.Notes = "Transaction Type: " + TransactionType.ToString

        If ResultCode = " " Then ResultCode = "No Errors"
        MelissaTblCommunication.ResultCode = ResultCode

        MelissaTblCommunication.Insert()

        If openedHere Then
            MelissaTblCommunication.ConnectionProvider.Connection.Close()
        End If

        MelissaTblCommunication.ConnectionProvider = Nothing

        Return MelissaTblCommunication.CommunicationID.Value
    End Function

    Private Function GetCleanCodes() As List(Of String)
        'In the future this function will grab codes from the database
        'For now these are being hard coded
        Dim CleanCodesArray As New List(Of String)


        For Each r As DataRow In _resultCodes.Rows
            If r("isClean").Equals(1) Then
                CleanCodesArray.Add(r.Item("ResultCode").ToString)
            End If
        Next


        Return CleanCodesArray
    End Function


    Public Sub CancelBatchClean() Handles Me.BatchCancelled
        _isCancelBatch = True
    End Sub

    Private Function GetTransactionResult(ErrorCodes As String) As DQStatus
        '***********************************************************************
        ' Block to Handle Different Error Codes in Initialization Results
        Dim errorCodeList As String() = Nothing
        Dim errorCode As String
        Dim TransactionStatus As New DQStatus

        Dim Result As String
        errorCodeList = ErrorCodes.Split(CChar(","))

        Result = ""
        For Each errorCode In errorCodeList

            'DQStatus.StatusCode += errorCode + "; "

            If (errorCode = "SE01") Then
                Result += errorCode + ": Web Service Internal Error;  "
                If _DisplayTransmissionErrors Then MsgBox("Web Service Internal Error;  ")
            ElseIf (errorCode = "GE01") Then
                Result += errorCode + ": Empty XML Request Structure;  "
            ElseIf (errorCode = "GE02") Then
                Result += errorCode + ": Empty XML Request Record Structure;  "
            ElseIf (errorCode = "GE03") Then
                Result += errorCode + ": Counted records send more than number of records allowed per request;  "
            ElseIf (errorCode = "GE04") Then
                Result += errorCode + ": CustomerID empty;  "
                If _DisplayTransmissionErrors Then Msg("Please enter your Customer ID", "Invalid Customer ID")
            ElseIf (errorCode = "GE05") Then
                Result += errorCode + ": CustomerID not valid;  "
                If _DisplayTransmissionErrors Then Msg("The Customer ID your entered is invalid. To retrieve a valid " _
                                                       &
                                                       "Customer ID, please contact a Melissa Data Sales Representative " _
                                                       & "at 800-MELISSA ext. 3 (800-800-6245 ext. 3). ",
                                                       "Invalid Customer ID")
            ElseIf (errorCode = "GE06") Then
                Result += errorCode + ": CustomerID disabled;  "
                If _DisplayTransmissionErrors Then Msg("The Customer ID your entered has been disabled. " _
                                                       & "Please contact a Melissa Data Sales Representative " _
                                                       & "at 800-MELISSA ext. 3 (800-800-6245 ext. 3). ",
                                                       "Disabled Customer ID")
            ElseIf (errorCode = "GE07") Then
                Result += errorCode + ": XML Request invalid;  "
            End If
        Next errorCode

        If Result = "" Then
            Result = "No Errors"
            TransactionStatus.isSuccessfull = True
        End If

        TransactionStatus.Code = ErrorCodes
        TransactionStatus.Description = Result

        Return TransactionStatus
    End Function

    Private Function GetResultCodes() As DataTable
        Dim dtMelissaResultCodes As New DataTable
        Dim TlkpMelissaResultCode As New BaseClasses.TlkpMelissaResultCode
        TlkpMelissaResultCode.ConnectionProvider = GlobalData.Project.ConnectionProvider

        dtMelissaResultCodes = TlkpMelissaResultCode.SelectAll()

        Return dtMelissaResultCodes
    End Function

#End Region

    'Private Function ParseResultsList(Results As String) As List(Of DQStatus)
    '    Dim resultslist As List(Of DQStatus)
    '    Dim ResultCodeList As String() = Nothing
    '    Dim ResultCode As String
    '    ResultCodeList = Results.Split(CChar(","))

    '    For Each ResultCode In ResultCodeList
    '    For
    'End Function
End Class

#Region "Classes"

Public Class DQPhone
    Dim _Telephone As String
    Dim _AreaCode As String
    Dim _NewAreaCode As String
    Dim _Prefix As String
    Dim _Suffix As String
    Dim _TimezoneCode As String
    Dim _TimeZone As String
    Dim _caseid As Integer
    Dim _id As Integer

    Public Property Telephone As String
        Get
            Return _Telephone
        End Get
        Set
            _Telephone = value
        End Set
    End Property

    Public Property AreaCode As String
        Get
            Return _AreaCode
        End Get
        Set
            _AreaCode = value
        End Set
    End Property

    Public Property NewAreaCode As String
        Get
            Return _NewAreaCode
        End Get
        Set
            _NewAreaCode = value
        End Set
    End Property

    Public Property Prefix As String
        Get
            Return _Prefix
        End Get
        Set
            _Prefix = value
        End Set
    End Property

    Public Property Suffix As String
        Get
            Return _Suffix
        End Get
        Set
            _Suffix = value
        End Set
    End Property

    Public Property TimezoneCode As String
        Get
            Select Case _TimezoneCode
                Case "04"
                    Return "08"
                Case "05"
                    Return "07"
                Case "06"
                    Return "06"
                Case "07"
                    Return "05"
                Case "08"
                    Return "04"
                Case "09"
                    Return "03"
                Case "10"
                    Return "02"
                Case Else
                    Return "01"
            End Select
        End Get
        Set
            _TimezoneCode = value
        End Set
    End Property

    Public Property Timezone As String
        Get
            Return _TimeZone
        End Get
        Set
            _TimeZone = value
        End Set
    End Property

    Public Property caseid As Integer
        Get
            Return _caseid
        End Get
        Set
            _caseid = value
        End Set
    End Property

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property
End Class

Public Class ProcessedPhone
    Inherits DQPhone
    Dim _Results As DQStatus
    Dim _isclean As Boolean

    Public Property Results As DQStatus
        Get
            Return _Results
        End Get
        Set
            _Results = value
        End Set
    End Property

    Public Property isClean As Boolean
        Get
            Return _isclean
        End Get
        Set
            _isclean = value
        End Set
    End Property
End Class

Public Class DQAddress
    Dim _Address As String
    Dim _Address1 As String
    Dim _Address2 As String
    Dim _Address3 As String
    Dim _Address4 As String
    Dim _City As String
    Dim _State As String
    Dim _Zip As String
    Dim _Zip5 As String
    Dim _Plus4 As String
    Dim _Company As String
    Dim _Country As String
    Dim _Suite As String
    Dim _PostalCode As String
    Dim _latitude As String ' = ""
    Dim _longitude As String ' = ""
    Dim _deliverypointcode As String
    Dim _caseid As Integer
    Dim _id As Integer

    Public Property Address As String
        Get
            Return _Address
        End Get
        Set
            _Address1 = value
            _Address = value
        End Set
    End Property

    Public Property Address1 As String
        Get
            Return _Address1
        End Get
        Set
            _Address1 = value
            _Address = value
        End Set
    End Property


    Public Property Address2 As String
        Get
            Return _Address2
        End Get
        Set
            _Address2 = value
        End Set
    End Property

    Public Property Address3 As String
        Get
            Return _Address3
        End Get
        Set
            _Address3 = value
        End Set
    End Property

    Public Property Address4 As String
        Get
            Return _Address4
        End Get
        Set
            _Address4 = value
        End Set
    End Property

    Public Property City As String
        Get
            Return _City
        End Get
        Set
            _City = value
        End Set
    End Property

    Public Property State As String
        Get
            Return _State
        End Get
        Set
            _State = value
        End Set
    End Property

    Public Property Zip As String
        Get
            Return _Zip
        End Get
        Set
            _Zip = value
        End Set
    End Property

    Public Property Zip5 As String
        Get
            Return _Zip5
        End Get
        Set
            _Zip5 = value
        End Set
    End Property

    Public Property Plus4 As String
        Get
            Return _Plus4
        End Get
        Set
            _Plus4 = value
        End Set
    End Property

    Public Property Company As String
        Get
            Return _Company
        End Get
        Set
            _Company = value
        End Set
    End Property

    Public Property Country As String
        Get
            Return _Country
        End Get
        Set
            _Country = value
        End Set
    End Property

    Public Property Suite As String
        Get
            Return _Suite
        End Get
        Set
            _Suite = value
        End Set
    End Property


    Public Property Latitude As String
        Get
            Return _latitude
        End Get
        Set
            _latitude = value
        End Set
    End Property


    Public Property Longitude As String
        Get
            Return _longitude
        End Get
        Set
            _longitude = value
        End Set
    End Property


    Public Property Postalcode As String
        Get
            Return _PostalCode
        End Get
        Set
            _PostalCode = value
        End Set
    End Property

    Public Property DeliveryPointCode As String
        Get
            Return _deliverypointcode
        End Get
        Set
            _deliverypointcode = value
        End Set
    End Property

    Public Property caseid As Integer
        Get
            Return _caseid
        End Get
        Set
            _caseid = value
        End Set
    End Property

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property
End Class

Public Class AddressInput
    Inherits DQAddress
End Class

Public Class ProcessedAddress
    Inherits DQAddress
    Dim _Results As DQStatus
    Dim _ResultsList As List(Of DQStatus)
    Dim _isclean As Boolean

    Public Property Results As DQStatus
        Get
            Return _Results
        End Get
        Set
            _Results = value
        End Set
    End Property

    Public Property ResultsList As List(Of DQStatus)
        Get
            Return _ResultsList
        End Get
        Set
            _ResultsList = value
        End Set
    End Property

    Public Property isClean As Boolean
        Get
            Return _isclean
        End Get
        Set
            _isclean = value
        End Set
    End Property
End Class

Public Class DQName
    Dim _Prefix As String
    Dim _First As String
    Dim _Middle As String
    Dim _Last As String
    Dim _Suffix As String
    Dim _Gender As String
    Dim _Fullname As String
    Dim _caseid As Integer
    Dim _id As Integer

    Public Property Prefix As String
        Get
            Return _Prefix
        End Get
        Set
            _Prefix = value
        End Set
    End Property

    Public Property First As String
        Get
            Return _First
        End Get
        Set
            _First = value
        End Set
    End Property

    Public Property Middle As String
        Get
            Return _Middle
        End Get
        Set
            _Middle = value
        End Set
    End Property

    Public Property Last As String
        Get
            Return _Last
        End Get
        Set
            _Last = value
        End Set
    End Property

    Public Property Suffix As String
        Get
            Return _Suffix
        End Get
        Set
            _Suffix = value
        End Set
    End Property

    Public Property Gender As String
        Get
            Return _Gender
        End Get
        Set
            _Gender = value
        End Set
    End Property

    Public Property Fullname As String
        Get
            Return _Fullname
        End Get
        Set
            _Fullname = value
        End Set
    End Property

    Public Property caseid As Integer
        Get
            Return _caseid
        End Get
        Set
            _caseid = value
        End Set
    End Property

    Public Property id As Integer
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property
End Class

Public Class ProcessedName
    Inherits DQName
    Dim _Results As DQStatus
    Dim _isclean As Boolean

    Public Property Results As DQStatus
        Get
            Return _Results
        End Get
        Set
            _Results = value
        End Set
    End Property

    Public Property Isclean As Boolean
        Get
            Return _isclean
        End Get
        Set
            _isclean = value
        End Set
    End Property
End Class

Public Class BatchProgressArgs
    Dim _TotalBatches As Integer
    Dim _BatchesProcessed As Integer

    Public Property TotalBatches As Integer
        Get
            Return _TotalBatches
        End Get
        Set
            _TotalBatches = value
        End Set
    End Property

    Public Property BatchesProcessed As Integer
        Get
            Return _BatchesProcessed
        End Get
        Set
            _BatchesProcessed = value
        End Set
    End Property
End Class

Public Class DQStatus
    Private _Code As String
    Private _Description As String
    Private _isSuccessfull As Boolean
    Private _id As String


    Public Property Code As String
        Get
            Return _Code
        End Get
        Set
            _Code = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return _Description
        End Get
        Set
            _Description = value
        End Set
    End Property

    Public Property isSuccessfull As Boolean
        Get
            Return _isSuccessfull
        End Get
        Set
            _isSuccessfull = value
        End Set
    End Property

    Public Property id As String
        Get
            Return _id
        End Get
        Set
            _id = value
        End Set
    End Property
End Class

#End Region
