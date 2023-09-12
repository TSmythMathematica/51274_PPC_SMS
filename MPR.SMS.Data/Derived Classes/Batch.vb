'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class Batch
    Inherits TblBatch

#Region "Events"

    Event OnInsert(objBatch As Batch)
    Event OnUpdate(objBatch As Batch)
    Event OnDelete(objBatch As Batch)

#End Region

#Region "Private Fields"

    Dim mintMaxBatchSize As Integer
    Dim menmBatchType As Enumerations.BatchType
    Dim ReadOnly mobjBatchItems As BatchItems
    Dim mobjInstrumentType As InstrumentType

#End Region

#Region "Public Properties"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property InstrumentType As InstrumentType
        Get
            If (mobjInstrumentType Is Nothing) And (Not Me.InstrumentTypeID.IsNull) Then
                ' instantiate the InstrumentType
                Dim objInstrumentTypes As InstrumentTypes = Project.InstrumentTypes
                mobjInstrumentType = objInstrumentTypes.GetByID(GetSafeValue(Me.InstrumentTypeID))
            End If

            Return mobjInstrumentType
        End Get
    End Property


    Public ReadOnly Property MaxBatchSize As Integer
        Get
            Dim objSqlResult As Object
            Dim strSQL As String

            ' check for Instrument-specific size
            strSQL = "SELECT MaxBatchSize FROM tlkpInstrumentType WHERE InstrumentTypeID = " &
                     Me.InstrumentTypeID.ToString
            objSqlResult = SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.Text, strSQL)
            If objSqlResult IsNot DBNull.Value Then
                mintMaxBatchSize = CInt(objSqlResult)
            Else
                ' get the default size
                strSQL = "SELECT MaxBatchSizeDefault FROM tlkpBatchType WHERE BatchTypeID = " & Me.BatchTypeID.ToString
                objSqlResult = SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.Text, strSQL)
                If objSqlResult IsNot DBNull.Value Then
                    mintMaxBatchSize = CInt(objSqlResult)
                Else
                    ' this should never happen (given Not Null constraint on MaxBatchSizeDefault)
                    mintMaxBatchSize = 0
                End If
            End If

            Return mintMaxBatchSize
        End Get
    End Property

    Public ReadOnly Property BatchItems As BatchItems
        Get
            Return mobjBatchItems
        End Get
    End Property

    Public ReadOnly Property BatchNumber As String
        Get
            Dim strDataEntryProgramID As String = GetSafeValue(Me.InstrumentType.DataEntryProgramID)

            ' determine pseudo-julian date (ie. # of days since Jan 1)
            Dim strDayOfYear As String = CDate(GetSafeDate(Me.CreatedOn)).DayOfYear.ToString
            ' pad it w/ zeros
            strDayOfYear = (New String("0"c, 3 - strDayOfYear.Length)) + strDayOfYear

            Return strDataEntryProgramID + "-" + strDayOfYear + "-" + Me.PublicBatchID.ToString
        End Get
    End Property

    Public ReadOnly Property BatchType As Enumerations.BatchType
        Get
            Return CType(CInt(BatchTypeID), Enumerations.BatchType)
        End Get
    End Property

#End Region

#Region "Constructors"


    ''' <summary>
    '''     Initializes a new instance of the Batch class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Batch class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Batch is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        mobjBatchItems = New BatchItems(Me)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Batch class, and INSERTS it into database.
    ''' </summary>
    ''' <param name="enmBatchType">
    '''     BatchType of the Batch to be created.
    ''' </param>

        Public Sub New(enmBatchType As Enumerations.BatchType, objInstrumentType As InstrumentType)

        MyBase.New()

        ConnectionString = Project.ConnectionString

        menmBatchType = enmBatchType
        Me.BatchTypeID = enmBatchType

        mobjInstrumentType = objInstrumentType
        Me.InstrumentTypeID = objInstrumentType.InstrumentTypeID

        Me.Insert()

        mobjBatchItems = New BatchItems(Me)
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    '''     Prepares ConnectionProvider for database access.
    ''' </summary>
    ''' <returns>
    '''     Returns True if the connection needed to be opened.
    '''     Returns False if connection was already open.
    ''' </returns>
    ''' <remarks>
    '''     It is responsiblity of calling block to [as needed] CloseConnection and
    '''     set ConnectionProvider = Nothing.
    ''' </remarks>

        Private Function PrepareConnectionProvider() As Boolean
        ConnectionProvider = Project.ConnectionProvider

        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider.OpenConnection()
            Return True
        Else
            Return False
        End If
    End Function

    ' Returns the next available PublicBatchID for a new Batch.
    Private Function NextPublicBatchID() As Integer
        Dim strSQL As String
        Dim intNextID As Integer
        Dim objSqlResult As Object

        'AF 03/26/10 - Changed logic to create sequential batch numbers per instrument instead of only per batch type
        strSQL = "SELECT Max(PublicBatchID)" _
                 + "FROM   tblBatch " _
                 + "WHERE  BatchTypeID = " + CStr(Me.BatchTypeID) _
                 + " and InstrumentTypeID = " & CStr(Me.InstrumentTypeID)
        Try
            objSqlResult = SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.Text, strSQL)
        Catch ex As Exception
            Throw ex
        End Try

        If objSqlResult Is DBNull.Value Then

            'AF 3/26/10 - Replaced if statments with construction of starting batchid, added InstrumentTypeID 
            '   to break batches down by Instrument Type
            'AF 5/7/10 Took out InstrumentTypeID, so batch numbers go back to 4 digits, 
            'but will still be sequential within instruments based on WHERE clause above...
            'intNextID = CInt(CStr(Me.BatchTypeID) + CStr(Format(CInt(Me.InstrumentTypeID), "00")) + "001")
            intNextID = CInt(CStr(Me.BatchTypeID) + "001")
        Else
            'increment
            intNextID = CInt(objSqlResult) + 1

            'TODO:?  Improve dealing with possiblity of COLLISION?
            ' e.g. sequence would be:  1998, 1999, 2000, 2001 (resulting in collision w/ DE 2001)
            ' For now, the following hack keeps us pretty safe, and is probably better then
            ' throwing error and/or notifying user that they can't create any more QC batches.
            'If (Me.BatchType = Enumerations.BatchType.QC) And (intNextID = 2000) Then
            '    intNextID = 10000
            'End If

        End If

        Return intNextID
    End Function

#End Region

#Region "Public Methods"


    ''' <summary>
    '''     Returns DataTable of all potential Status codes available project.
    ''' </summary>
    Public Shared Function AllStatusCodes() As DataTable

        Dim strSQL As String = "SELECT * FROM vwBatchStatusCodesAll"
        Dim dsStatusCodes As DataSet = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString, CommandType.Text,
                                                                strSQL)
        Return dsStatusCodes.Tables(0)
    End Function

    ''' <summary>
    '''     Returns DataTable of Status codes available for assigment to instruments.
    ''' </summary>
    Public Shared Function AssignableStatusCodes(batchtype As Enumerations.BatchType) As DataTable
        Dim strSQL As String

        Select Case batchtype
            Case Enumerations.BatchType.QC
                strSQL = "SELECT * FROM vwBatchStatusCodesForQC"
            Case Enumerations.BatchType.DE
                strSQL = "SELECT * FROM vwBatchStatusCodesForDE"
            Case Enumerations.BatchType.Final
                strSQL = "SELECT * FROM vwBatchStatusCodesForFinal"
            Case Enumerations.BatchType.TimeStamp
                strSQL = "SELECT * FROM vwBatchStatusCodesForTimeStamp"
            Case Enumerations.BatchType.QCDVD
                strSQL = "SELECT * FROM vwBatchStatusCodesForQCDVD"
            Case Enumerations.BatchType.CodeDVD
                strSQL = "SELECT * FROM vwBatchStatusCodesForCoding"
            Case Enumerations.BatchType.SupReviewDVD
                strSQL = "SELECT * FROM vwBatchStatusCodesForSupReviewDVD"
            Case Enumerations.BatchType.ReassignDVD
                strSQL = "SELECT * FROM vwBatchStatusCodesForReassignment"
            Case Else
                Return Nothing '>>>>
        End Select

        Dim dsStatusCodes As DataSet = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString, CommandType.Text,
                                                                strSQL)
        Return dsStatusCodes.Tables(0)
    End Function

    ''' <summary>
    '''     Inserts the Batch into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        If Not Me.BatchID.IsNull Then Return False ' because it's already been inserted

        Try
            blnCloseConnection = PrepareConnectionProvider()

            Me.PublicBatchID = NextPublicBatchID()
            blnResult = MyBase.Insert()

        Catch ex As Exception
            Me.PublicBatchID = SqlInt32.Null  ' because the one we assigned is not useful
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a Batch object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        Try
            blnCloseConnection = PrepareConnectionProvider()
            blnResult = MyBase.Update()

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Batch from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        Try
            blnCloseConnection = PrepareConnectionProvider()
            blnResult = MyBase.Delete()

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function


    ''' <summary>
    '''     Returns DataTable of InstrumentTypes available for given BatchType.
    ''' </summary>

        Public Shared Function InstrumentTypesDT(enmBatchType As Enumerations.BatchType) As DataTable

        Dim strSQL As String
        Dim dsInstrumentTypes As DataSet

        If enmBatchType = Enumerations.BatchType.QC Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForQC"
        ElseIf enmBatchType = Enumerations.BatchType.DE Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForDE"
        ElseIf enmBatchType = Enumerations.BatchType.Final Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForFinal"
        ElseIf enmBatchType = Enumerations.BatchType.TimeStamp Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForTimeStamp"
        ElseIf enmBatchType = Enumerations.BatchType.SupReviewDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForSupReviewDVD"
        ElseIf enmBatchType = Enumerations.BatchType.QCDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForQCDVD"
        ElseIf enmBatchType = Enumerations.BatchType.CodeDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForCoding"
        ElseIf enmBatchType = Enumerations.BatchType.ReassignDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentTypeForReassignment"
        Else
            Return Nothing
        End If

        dsInstrumentTypes = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString, CommandType.Text, strSQL)
        If (dsInstrumentTypes IsNot Nothing) AndAlso dsInstrumentTypes.Tables(0).Rows.Count > 0 Then
            Return dsInstrumentTypes.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    '''     Returns DataTable of Instruments available for given BatchType and InstrumentTypeID.
    ''' </summary>

        Public Shared Function InstrumentsAvailable(enmBatchType As Enumerations.BatchType,
                                                    intInstrumentTypeID As Integer) As DataTable
        Dim strSQL As String
        Dim dsInstruments As DataSet

        If enmBatchType = Enumerations.BatchType.QC Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForQC WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.DE Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForDE WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.Final Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForFinal WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.TimeStamp Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForTimeStamp WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.QCDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForQCDVD WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.SupReviewDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForSupReviewDVD WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.CodeDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForCoding WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        ElseIf enmBatchType = Enumerations.BatchType.ReassignDVD Then
            strSQL = "SELECT * FROM vwBatchInstrumentAvailableForReassignment WHERE InstrumentTypeID = " +
                     intInstrumentTypeID.ToString
        Else
            Return Nothing
        End If

        dsInstruments = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString, CommandType.Text, strSQL)
        Return dsInstruments.Tables(0)
    End Function

    ''' <summary>
    '''     Update Batch, and its BatchItems, to indicate batch was received.
    ''' </summary>

        Public Sub UpdateToReceivedStatus()

        ' Update My BatchItems
        Dim objBatchItem As BatchItem
        For Each objBatchItem In Me.BatchItems
            objBatchItem.UpdateInstrumentToBatchReceivedStatus()
        Next

        ' Update Me
        Me.ReceivedBy = Project.ConnectionProvider.CurrentUser
        Me.ReceivedOn = Now()
        Me.Update()
    End Sub

    ''' <summary>
    '''     Selects one or more rows from the database based on the Foreign Key 'BatchTypeID'
    ''' </summary>
    ''' <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
    ''' <remarks>
    '''     Properties needed for this method:
    '''     <UL>
    '''         <LI>BatchTypeID</LI>
    '''     </UL>
    '''     Properties set after a succesful call of this method:
    '''     <UL>
    '''         <LI>ErrorCode</LI>
    '''     </UL>
    ''' </remarks>
    Public Function SelectAllWInstrumentandBatchTypeIDLogic(InstrumentTypeID As Integer, BatchTypeID As Integer) _
        As DataTable
        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_tblBatch_SelectAllWInstrumentandBatchTypeIDLogic]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("tblBatch")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try
            cmdToExecute.Parameters.Add(New SqlParameter("@InstrumentTypeID", SqlDbType.Int, 4, ParameterDirection.Input,
                                                         False, 10, 0, "", DataRowVersion.Proposed, InstrumentTypeID))
            cmdToExecute.Parameters.Add(New SqlParameter("@BatchTypeID", SqlDbType.Int, 4, ParameterDirection.Input,
                                                         False, 10, 0, "", DataRowVersion.Proposed, BatchTypeID))
            cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True,
                                                         10, 0, "", DataRowVersion.Proposed, mErrorCode))

            If mblnConnectionIsLocal Then
                ' Open connection.
                mobjSqlConnection.ConnectionString = Me.ConnectionString
                mobjSqlConnection.Open()
            Else
                If mConnectionProvider.IsTransactionPending Then
                    cmdToExecute.Transaction = mConnectionProvider.CurrentTransaction
                End If
            End If

            ' Execute query.
            adapter.Fill(toReturn)
            mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

            If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
                ' Throw error.
                Throw _
                    New Exception(
                        "Stored Procedure 'SMS_tblBatch_SelectAllWInstrumentandBatchTypeIDLogic' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "TblBatch::SMS_tblBatch_SelectAllWInstrumentandBatchTypeIDLogic::Error occured." +
                    Environment.NewLine + Environment.NewLine + ex.Message, ex)
        Finally
            If mblnConnectionIsLocal Then
                ' Close connection.
                mobjSqlConnection.Close()
            End If
            cmdToExecute.Dispose()
            adapter.Dispose()
        End Try
    End Function

#End Region
End Class
