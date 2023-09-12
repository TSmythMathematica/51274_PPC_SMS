'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Windows.Forms
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Instrument object in the
'''     database.
''' </summary>

    Public Class Instrument
    Inherits TblInstrument

#Region "Events"

    Event OnInsert(objInstrument As Instrument)
    Event OnUpdate(objInstrument As Instrument)
    Event OnDelete(objInstrument As Instrument)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjSampleMember As Person = Nothing
    Private mobjCurrentRespondent As Person = Nothing

    Private mobjInstrumentType As InstrumentType
    Private mobjStatus As Status
    Private ReadOnly mstrStatusOld As SqlString = ""
    Private ReadOnly mstrLogicalStatusOld As SqlString = ""
    Private mobjLogicalStatus As Status

    Private mstrLastError As String
    Private _FieldInterviewer As String
    Private _bilingual As Boolean

#End Region

#Region "Public Properties"

    Public Property CancelUpdate As Boolean = False

    Public Enum StatusUpdateResult
        Override = 0
        NoAction = 1
        [Error] = 2
    End Enum

    public ReadOnly Property CanGetConfirmitCallHistory as Boolean
        Get
            Return GetSafeValue(InstrumentType.IsCATI) AndAlso
                   GetSafeValue(InstrumentType.SurveyID) <> String.Empty
        End Get
    End Property

    Public Property FieldInterviewer As String
        Get
            Return _FieldInterviewer
        End Get
        Set
            _FieldInterviewer = value
        End Set
    End Property

    Public Property Bilingual As Boolean
        Get
            Return _bilingual
        End Get
        Set
            _bilingual = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Instrument object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Instrument object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Instrument object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Instrument object belongs to.
    ''' </value>

        Public Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            MyBase.CaseID = mobjCase.CaseID
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that is the SampleMember of this Instrument.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that is the SampleMember of this Instrument.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Instrument object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this
    '''     property to Nothing (null).
    '''     The Instrument object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property SampleMember As Person
        Get
            If mobjSampleMember Is Nothing Then
                ' Get the index of the associated SampleMemberPerson object initializing the Person
                ' object reference as needed.
                If Not SampleMemberMPRID.IsNull Then

                    Dim i As Integer = mobjCase.Persons.IndexOf(SampleMemberMPRID.ToString)

                    If i >= 0 Then
                        mobjSampleMember = mobjCase.Persons(i)
                    End If
                End If
            End If
            Return mobjSampleMember
        End Get
        Set
            mobjSampleMember = Value
            If Not mobjSampleMember Is Nothing Then
                SampleMemberMPRID = mobjSampleMember.MPRID
            Else
                SampleMemberMPRID = ""
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that is the CurrentRespondent of this
    '''     Instrument.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that is the CurrentRespondent of this Instrument.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Instrument object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this
    '''     property to Nothing (null).
    '''     The Instrument object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property CurrentRespondent As Person
        Get
            If mobjCurrentRespondent Is Nothing Then
                ' Get the index of the associated CurrentRespondentPerson object initializing the Person
                ' object reference as needed.
                If Not CurrentRespondentMPRID.IsNull Then

                    Dim i As Integer = mobjCase.Persons.IndexOf(CurrentRespondentMPRID.ToString)

                    If i >= 0 Then
                        mobjCurrentRespondent = mobjCase.Persons(i)
                    End If
                End If
            End If
            Return mobjCurrentRespondent
        End Get
        Set
            mobjCurrentRespondent = Value
            If Not mobjCurrentRespondent Is Nothing Then
                CurrentRespondentMPRID = mobjCurrentRespondent.MPRID
            Else
                CurrentRespondentMPRID = ""
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the Current (CODE) <see cref="T:MPR.SMS.Data.Status">Status</see> object of this Instrument.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Status">Status</see> object of this Instrument.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Instrument object from a <see cref="T:MPR.SMS.Data.Status">Status</see> object, set this
    '''     property to Nothing (null).
    '''     The Instrument object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Status">Status</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Status As Status
        Get
            mobjStatus = Nothing
            If Not CurrentStatus.IsNull Then
                mobjStatus = New Status(CurrentStatus.ToString)
            End If
            Return mobjStatus
        End Get
        Set
            mobjStatus = value
            CurrentStatus = mobjStatus.Code
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the Logical (CDSP) <see cref="T:MPR.SMS.Data.Status">Status</see> object of this Instrument.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Status">Status</see> object of this Instrument.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Instrument object from a <see cref="T:MPR.SMS.Data.Status">Status</see> object, set this
    '''     property to Nothing (null).
    '''     The Instrument object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Status">Status</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property LogicalStatusObj As Status
        Get
            mobjLogicalStatus = Nothing
            If Not LogicalStatus.IsNull Then
                mobjLogicalStatus = New Status(LogicalStatus.ToString)
            End If
            Return mobjLogicalStatus
        End Get
        Set
            mobjLogicalStatus = value
            LogicalStatus = mobjLogicalStatus.Code
        End Set
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Instrument object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Instrument object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets the InstrumentID of the Instrument object
    ''' </summary>
    ''' <value>
    '''     The InstrumentID of the Instrument object.
    ''' </value>

        Public Shadows ReadOnly Property InstrumentID As SqlInt32
        Get
            Return MyBase.InstrumentID
        End Get
    End Property

    ''' <summary>
    '''     Gets the InstrumentType of the Instrument object.
    ''' </summary>
    ''' <value>
    '''     The InstrumentType of the Instrument object.
    ''' </value>
    Public Property InstrumentType As InstrumentType
        Get
            Dim i As Integer
            If Not InstrumentTypeID.IsNull Then
                i = Project.InstrumentTypes.IndexOf(InstrumentTypeID.Value)
                If i >= 0 Then
                    mobjInstrumentType = Project.InstrumentTypes(i)
                End If
            End If
            Return mobjInstrumentType
        End Get
        Set
            mobjInstrumentType = value
        End Set
    End Property

    Public ReadOnly Property StatusUpdateRuleResult(OldStatus As SqlString, NewStatus As SqlString) _
        As StatusUpdateResult

        Get
            'retreive the new CurrentStatus
            Dim cmdSQL As SqlCommand = New SqlCommand
            cmdSQL.Connection = New SqlConnection
            cmdSQL.Connection.ConnectionString = Project.ConnectionString
            cmdSQL.Connection.Open()

            cmdSQL.CommandText = "dbo.GetStatusUpdateRuleResult"
            cmdSQL.CommandType = CommandType.StoredProcedure

            Try
                cmdSQL.Parameters.Clear()
                cmdSQL.Parameters.Add(New SqlParameter("@ExistingStatus", SqlDbType.Char, 4)).Value = OldStatus
                cmdSQL.Parameters.Add(New SqlParameter("@NewStatus", SqlDbType.Char, 4)).Value = NewStatus

                Dim ReturnValue As SqlParameter = New SqlParameter("@GetStatusUpdateRuleResult", SqlDbType.Int, 4)
                ReturnValue.Direction = ParameterDirection.ReturnValue
                cmdSQL.Parameters.Add(ReturnValue)
                cmdSQL.ExecuteNonQuery()

                Return CType(ReturnValue.Value, StatusUpdateResult)

            Catch ex As Exception
                ' Some error occured. Bubble it to caller and encapsulate Exception object
                Throw _
                    New Exception(
                        "dbo.GetStatusUpdateRuleResult::Error occured." + Environment.NewLine + Environment.NewLine +
                        ex.Message, ex)

                Return StatusUpdateResult.Error

            Finally
                cmdSQL.Dispose()
            End Try
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Instrument class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Instrument class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Instrument object belongs to.
    ''' </param>

        Public Sub New(objCase As [Case])

        mobjCase = objCase

        ConnectionString = Project.ConnectionString

        If Not objCase.CaseID.IsNull Then
            MyBase.CaseID = objCase.CaseID
        End If
        mstrStatusOld = CurrentStatus
        mstrLogicalStatusOld = LogicalStatus


        mobjCase.Instruments.Add(Me)

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Instrument class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Instrument object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Instrument object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)
        mstrStatusOld = CurrentStatus
        mstrLogicalStatusOld = LogicalStatus

        mobjCase = objCase

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Instrument class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Instrument class pertaining
    '''     to a case, without adding it to the case's Instruments collection.
    ''' </remarks>

        Public Sub New(intCaseID As Integer)

        MyBase.New()

        mobjCase = New [Case](intCaseID, False)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If
        mstrStatusOld = CurrentStatus
        mstrLogicalStatusOld = LogicalStatus

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Instrument class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Instrument object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)
        mstrStatusOld = CurrentStatus
        mstrLogicalStatusOld = LogicalStatus

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    Public Sub New(intInstrumentID As Integer, intInstrumentTypeId As Integer)

        MyBase.New()

        MyBase.InstrumentID = intInstrumentID

        ConnectionString = Project.ConnectionString

        MyBase.SelectOne()

        mstrStatusOld = CurrentStatus
        mstrLogicalStatusOld = LogicalStatus

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

#End Region

#Region "Private Methods"

    'Insert a Instrument Status History record, which shows the result
    'of the Status Update Rules
    Private Sub ApplyStatusHistory(strOldStatus As SqlString, strNewStatus As SqlString)

        'insert the Instrument Status History record
        Dim cmdSQL As SqlCommand = New SqlCommand
        cmdSQL.Connection = New SqlConnection
        cmdSQL.Connection.ConnectionString = Project.ConnectionString

        cmdSQL.Connection.Open()
        cmdSQL.CommandText = "SMS_RecordStatusHistory"
        cmdSQL.CommandType = CommandType.StoredProcedure

        Try
            cmdSQL.Parameters.Clear()
            cmdSQL.Parameters.Add(New SqlParameter("@InstrumentID", SqlDbType.Int, 4, ParameterDirection.Input, False, 0,
                                                   0, "", DataRowVersion.Proposed, Me.InstrumentID.Value))
            cmdSQL.Parameters.Add(New SqlParameter("@ExistingStatus", SqlDbType.Char, 4, ParameterDirection.Input, False,
                                                   0, 0, "", DataRowVersion.Proposed, strOldStatus))
            cmdSQL.Parameters.Add(New SqlParameter("@NewStatus", SqlDbType.Char, 4, ParameterDirection.Input, False, 0,
                                                   0, "", DataRowVersion.Proposed, strNewStatus))
            cmdSQL.Parameters.Add(New SqlParameter("@CreatedBy", SqlDbType.NVarChar, 32, ParameterDirection.Input, False,
                                                   0, 0, "", DataRowVersion.Proposed,
                                                   New SqlString(Project.ConnectionProvider.CurrentUser)))

            cmdSQL.ExecuteNonQuery()

        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "tblInstrumentStatusHistory::Insert::Error occured." + Environment.NewLine + Environment.NewLine +
                    ex.Message, ex)

        End Try
        cmdSQL.Dispose()
    End Sub

    'Checks the Status Update Rules, and if the new status code is applied,
    'then update the Date and User as well.
    Private Sub ApplyStatusUpdateRule(strOldStatus As SqlString, strNewStatus As SqlString)

        If StatusUpdateRuleResult(strOldStatus, strNewStatus) = StatusUpdateResult.Override Then
            If strNewStatus = "" Then
                strNewStatus = "0000"
            End If
            CurrentStatus = strNewStatus
            LogicalStatus = strNewStatus
            StatusChangeDate = New SqlDateTime(Now())
            StatusChangedBy = New SqlString(Project.ConnectionProvider.CurrentUser)
        ElseIf StatusUpdateRuleResult(strOldStatus, strNewStatus) = StatusUpdateResult.Error Then
            CurrentStatus = strOldStatus
            LogicalStatus = strOldStatus
            Dim strMsg As String = "Unable to Update Instrument Status to " + strNewStatus.ToString +
                                   ".  Either the update rule is missing or does not allow " + strNewStatus.ToString +
                                   " to overwrite " + strOldStatus.ToString + "." + Environment.NewLine _
                                   + "Please contact your SMS Programmer."
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            CurrentStatus = strOldStatus
            LogicalStatus = strOldStatus
        End If
    End Sub

    'BT: Added on 01/22/2013 to update Blaise in real-time.
    'BT: Commented on 07/01/2013
    'Private Sub RunBlaiseUpdate()

    '    If Project.BlaiseRealTimeProcess And Me.InstrumentTypeID = Project.BlaiseInstrumentTypeID Then
    '        Dim ErrorMessage As String
    '        Dim mobjBlaise As New ISMSBlaiseAPI.BlaiseUtility
    '        Dim BlaiseDatabase As String = Project.BlaiseDatabase '"\\M221\DEVELOPMENT\SISCAI\Projects\Basicblaisell\Basicblaisell.bdb"
    '        Dim BlaiseFields As Dictionary(Of String, String) = New Dictionary(Of String, String)
    '        BlaiseFields("MPRCAIMgt.Mangmnt.Code") = Me.CurrentStatus.Value
    '        BlaiseFields("MPRCAIMgt.Mangmnt.CDSP") = Me.LogicalStatus.Value

    '        If Me.CurrentStatus.Value >= "2001" And Me.CurrentStatus.Value <= "2099" Then
    '            BlaiseFields("CatiMana.CatiCall.RegsCalls[1].DialResult") = "1" 'Final Complete
    '        ElseIf Me.CurrentStatus.Value >= "1890" Then
    '            BlaiseFields("CatiMana.CatiCall.RegsCalls[1].DialResult") = "4" 'Return From Locating
    '            BlaiseFields("MPRCAIMgt.Mangmnt.Phone") = Me.CurrentRespondent.BestPhone.PhoneNum.Value
    '            BlaiseFields("MPRCaiMgt.Mangmnt.IntlPhone") = CStr(Me.CurrentRespondent.BestPhone.IsInternational.Value)
    '            BlaiseFields("MPRCAIMgt.Mangmnt.TimeZone") = Me.CurrentRespondent.BestPhone.TimeZoneCode.Value
    '        ElseIf Me.CurrentStatus.Value >= "1001" And Me.CurrentStatus.Value <= "1999" And Me.CurrentStatus.Value <> "1890" Then
    '            BlaiseFields("CatiMana.CatiCall.RegsCalls[1].DialResult") = "8" 'Interim Other
    '        Else
    '            BlaiseFields("CatiMana.CatiCall.RegsCalls[1].DialResult") = "5" 'Final Non-Response
    '        End If

    '        Try
    '            ErrorMessage = mobjBlaise.UpdateBlaise(Me.SampleMemberMPRID.Value, BlaiseDatabase, BlaiseFields)

    '            If ErrorMessage <> Nothing Then
    '                MessageBox.Show(ErrorMessage)
    '            End If

    '        Catch ex As Exception
    '            Throw New Exception("RunBlaiseUpdate::Error occured." + Environment.NewLine + Environment.NewLine + ex.Message, ex)
    '        End Try


    '    End If


    'End Sub
    'BT: Added on 01/22/2013 to update Blaise in real-time.

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a Instrument object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        'I don 't think this section below is necessary...
        'this is usued when new instrument is inserted for data import. Uncommented out by Angela
        If SampleMember Is Nothing Then
            MyBase.SampleMemberMPRID = New SqlString("")
        Else
            MyBase.SampleMemberMPRID = mobjSampleMember.MPRID
        End If
        If CurrentRespondent Is Nothing Then
            MyBase.CurrentRespondentMPRID = New SqlString("")
        Else
            MyBase.CurrentRespondentMPRID = mobjCurrentRespondent.MPRID
        End If

        If Not IsModified Then
            Return True
        End If

        If GetSafeValue(CurrentStatus).Equals("") Then
            CurrentStatus = New SqlString("0000")
            StatusChangeDate = New SqlDateTime(Now())
            StatusChangedBy = New SqlString(Project.ConnectionProvider.CurrentUser)
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Insert()
            If blnResult Then
                'Create the Status History record
                ApplyStatusHistory(mstrStatusOld, CurrentStatus)
                ApplyStatusHistory(mstrLogicalStatusOld, LogicalStatus)

            End If
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the Instrument object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If CancelUpdate Then
            Return True
        ElseIf InstrumentID.IsNull Then
            Return Insert()
        ElseIf InstrumentID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean

        'I don't think this section below is necessary...
        'If SampleMember Is Nothing Then
        '    MyBase.SampleMemberMPRID = New SqlString("")
        'Else
        '    MyBase.SampleMemberMPRID = mobjSampleMember.MPRID
        'End If
        'If CurrentRespondent Is Nothing Then
        '    MyBase.CurrentRespondentMPRID = New SqlString("")
        'Else
        '    MyBase.CurrentRespondentMPRID = mobjCurrentRespondent.MPRID
        'End If

        'check it against the status update rules
        'If GetSafeValue(CurrentStatus) <> GetSafeValue(mstrStatusOld) Then    'if the status code changed
        ApplyStatusHistory(mstrStatusOld, CurrentStatus)
        ApplyStatusUpdateRule(mstrStatusOld, CurrentStatus)

        'End If


        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If
        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then

            'BT: Added on 01/22/2013 to update Blaise in real-time.
            'BT: Commented on 07/01/2013
            'RunBlaiseUpdate() 
            'BT: Added on 01/22/2013 to update Blaise in real-time.

            '04/16/2021 WJ: send deceased cases to ConfirmIt 
            If Not ReleaseDate.IsNull And mstrStatusOld.ToString <> CurrentStatus.ToString Then
                If (LogicalStatus = "2440" And CurrentStatus = "2440") Then
                    ' send the case to ConfirmIt with related fields 
                    If InstrumentType.SurveyID <> String.Empty AndAlso InstrumentType.SMSToConfirmitRT = True Then
                        ' Send the current status to ConfirmIt
                        ' type id 3 for 2440 status related variables
                        ' If successfully sent, tblInstrument's DateLastSentToCATI field will be updated as well
                        SMSToConfirmIt.SendToConfirmIt(SampleMemberMPRID.ToString, CInt(InstrumentTypeID), 3)
                    End If
                End If
            End If
            '04/16/2021 WJ:

            RaiseEvent OnUpdate(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes the Instrument object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Instrument object has been deleted, otherwise false
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If
        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

    Public Function GetBilingual() As DataTable
        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_tblInstrument_GetBilingual]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("Bilingual")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try
            cmdToExecute.Parameters.Add(New SqlParameter("@InstrumentID", SqlDbType.Int, 4, ParameterDirection.Input,
                                                         False, 10, 0, "", DataRowVersion.Proposed, InstrumentID))
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
                        "Stored Procedure 'SMS_tblInstrument_GetBilingual' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            If toReturn.Rows.Count > 0 Then
                Select Case toReturn.Rows(0).Item("LanguageTypeId").ToString
                    Case "2"
                        _bilingual = True
                    Case Else
                        _bilingual = False
                End Select
            Else
                _Bilingual = False
            End If
            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "TblInstrument::GetBilingual::Error occured." + Environment.NewLine + Environment.NewLine +
                    ex.Message, ex)
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
