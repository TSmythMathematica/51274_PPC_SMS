'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Person's Locating Status information.
''' </summary>

    Public Class LocatingStatus
    Inherits TblLocatingStatus

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person

    Private mobjStatus As Status
    Private ReadOnly mstrStatusOld As SqlString = ""

    Private mblnIsNew As Boolean = False
    Private ReadOnly _Notes As String = ""

#End Region

#Region "Events"

    Event OnInsert(objRelationship As LocatingStatus)
    Event OnUpdate(objRelationship As LocatingStatus)
    Event OnDelete(objRelationship As LocatingStatus)

#End Region

#Region "Public Properties"

    Public Enum StatusUpdateResult
        Override = 0
        NoAction = 1
        [Error] = 2
    End Enum

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
    ''' </value>

        Public ReadOnly Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Address object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Address object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingStatus object is associated
    '''     with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingStatus object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an LocatingStatus object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this
    '''     property to Nothing (null).
    '''     The Address object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Person As Person
        Get
            If mobjPerson Is Nothing Then
                ' Get the index of the associated Person object initializing the Person
                ' object reference as needed.
                If Not MPRID.IsNull AndAlso Not MPRID.ToString.Equals("") Then

                    Dim i As Integer = mobjCase.Persons.IndexOf(MPRID.ToString)

                    If i >= 0 Then
                        mobjPerson = mobjCase.Persons(i)
                    End If
                End If
            End If
            Return mobjPerson
        End Get
        Set
            mobjPerson = Value
            MPRID = mobjPerson.MPRID
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingStatus.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingStatus.
    ''' </value>

        Public Property Status As Status
        Get
            mobjStatus = New Status(LocatingStatus.ToString)

            Return mobjStatus
        End Get
        Set
            mobjStatus = Value
            LocatingStatus = mobjStatus.Code
        End Set
    End Property

    'a Person is considered "moved out of locating" if the status changed 
    'from an in-locating status to something other than in-locating
    Public ReadOnly Property IsMovedOutOfLocating As Boolean
        Get
            Dim objOldStatus As New Status(LocatingStatusOld.ToString)
            Dim blnOldStatusInLocating As Boolean =
                    (GetSafeValue(objOldStatus.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(objOldStatus.IsCaseInLocatingSupervisor).Equals(True))
            Dim blnNewStatusInLocating As Boolean =
                    (GetSafeValue(Status.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(Status.IsCaseInLocatingSupervisor).Equals(True))

            Return (blnOldStatusInLocating = True And blnNewStatusInLocating = False)
        End Get
    End Property


    'a Person is considered "moved into locating" if the status changed 
    'from a non-locating status to something in-locating
    Public ReadOnly Property IsMovedIntoLocating As Boolean
        Get
            Dim objOldStatus As New Status(LocatingStatusOld.ToString)
            Dim blnOldStatusInLocating As Boolean =
                    (GetSafeValue(objOldStatus.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(objOldStatus.IsCaseInLocatingSupervisor).Equals(True))
            Dim blnNewStatusInLocating As Boolean =
                    (GetSafeValue(Status.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(Status.IsCaseInLocatingSupervisor).Equals(True))

            Return (blnOldStatusInLocating = False And blnNewStatusInLocating = True)
        End Get
    End Property

    'a LocatingStatus is considered a call-in if the status changed 
    'from a non-locating status to another non-locating status
    Public ReadOnly Property IsCallIn As Boolean
        Get
            Dim objOldStatus As New Status(LocatingStatusOld.ToString)
            Dim blnOldStatusInLocating As Boolean =
                    (GetSafeValue(objOldStatus.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(objOldStatus.IsCaseInLocatingSupervisor).Equals(True))
            Dim blnNewStatusInLocating As Boolean =
                    (GetSafeValue(Status.IsCaseInLocating).Equals(True) Or
                     GetSafeValue(Status.IsCaseInLocatingSupervisor).Equals(True))
            Dim blnStatusChanged As Boolean =
                    Me.IsModified
            'Not GetSafeValue(objOldStatus.Code).Equals(GetSafeValue(Status.Code))

            Return (blnOldStatusInLocating = False And blnNewStatusInLocating = False And blnStatusChanged = True)
        End Get
    End Property

    Public ReadOnly Property StatusUpdateRuleResult(OldStatus As SqlString, NewStatus As SqlString) _
        As StatusUpdateResult

        Get
            'retreive the new LocatingStatus
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

#Region "Private Properties"

    Private Property IsNew As Boolean
        Get
            Return mblnIsNew
        End Get
        Set
            mblnIsNew = value
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The LocatingStatus class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Relationship class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()
        mstrStatusOld = "0000"

        ConnectionString = Project.ConnectionString

        If LocatingStatus.IsNull OrElse LocatingStatus.ToString.Equals("") Then LocatingStatus = New SqlString("0000")
        If NoOfTimesLocating.IsNull Then
            If Status.IsCaseInLocating Or Status.IsCaseInLocatingSupervisor Then
                NoOfTimesLocating = New SqlInt32(1)
            Else
                NoOfTimesLocating = New SqlInt32(0)
            End If
        End If

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the LocatingStatus class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the LocatingStatus is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)
        mstrStatusOld = LocatingStatus

        If Not Notes.IsNull Then _Notes = Notes.ToString
        If LocatingStatus.IsNull OrElse LocatingStatus.ToString.Equals("") Then LocatingStatus = New SqlString("0000")
        If NoOfTimesLocating.IsNull Then
            If Status.IsCaseInLocating Or Status.IsCaseInLocatingSupervisor Then
                NoOfTimesLocating = New SqlInt32(1)
            Else
                NoOfTimesLocating = New SqlInt32(0)
            End If
        End If

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the LocatingStatus class.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingStatus object belongs to.
    ''' </param>

        Public Sub New(objPerson As Person)

        MyBase.New()

        mobjPerson = objPerson
        mobjCase = objPerson.Case

        If objPerson.MPRID.IsNull Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = New SqlString(objPerson.MPRID.ToString)
        End If

        ConnectionString = Project.ConnectionString
        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            Dim dt As DataTable = SelectOneWMPRIDLogic()

            mstrStatusOld = LocatingStatus

            IsNew = dt.Rows.Count = 0

            If Not Notes.IsNull Then _Notes = Notes.ToString
            If LocatingStatus.IsNull OrElse LocatingStatus.ToString.Equals("") Then _
                LocatingStatus = New SqlString("0000")
            If NoOfTimesLocating.IsNull Then
                If Status.IsCaseInLocating Or Status.IsCaseInLocatingSupervisor Then
                    NoOfTimesLocating = New SqlInt32(1)
                Else
                    NoOfTimesLocating = New SqlInt32(0)
                End If
            End If

            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception
            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Relationship into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Relationship object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjPerson.CaseID
        MyBase.MPRID = mobjPerson.MPRID

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        'set the Note Date if the Notes changed.
        If Not Notes.IsNull AndAlso
           Not Notes.ToString.Equals(_Notes) Then
            NoteDate = Now
        End If

        ' Insert the Lacating Status

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
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
    '''     Updates a Relationship object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = False

        'if the status code was changed, check it against the status update rules
        If LocatingStatus <> mstrStatusOld Then
            ApplyStatusUpdateRule(mstrStatusOld, LocatingStatus)
        End If
        If IsMovedIntoLocating Then
            DateSentToLocating = New SqlDateTime(Now)
            NoOfTimesLocating = NoOfTimesLocating + 1
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        'set the Note Date if the Notes changed.
        If Not Notes.IsNull AndAlso
           Not Notes.ToString.Equals(_Notes) Then
            NoteDate = Now
        End If

        ' Update the Locating Status

        Try
            If IsNew Then
                blnResult = Insert()
                IsNew = False
            Else
                blnResult = MyBase.Update()
            End If
        Catch ex As Exception
            blnResult = False
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            ResetModified()
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Relationship from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the Relationship

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

    Public Sub UpdateLastModifiedBy(LocatingStatusID As SqlInt32, PrevLastModifiedBy As SqlString)

        Dim ErrorCode As Integer
        Dim cmdSQL As SqlCommand = New SqlCommand
        cmdSQL.Connection = New SqlConnection
        cmdSQL.Connection.ConnectionString = Project.ConnectionString
        cmdSQL.Connection.Open()

        cmdSQL.CommandText = "SMS_UpdateLocatingStatus_LastModifiedBy"
        cmdSQL.CommandType = CommandType.StoredProcedure

        Try
            cmdSQL.Parameters.Clear()
            cmdSQL.Parameters.Add(New SqlParameter("@LocatingStatusID", SqlDbType.Int, 4)).Value = LocatingStatusID
            cmdSQL.Parameters.Add(New SqlParameter("@LastModifiedBy", SqlDbType.VarChar, 32)).Value = PrevLastModifiedBy
            cmdSQL.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10,
                                                   0, "", DataRowVersion.Proposed, ErrorCode))

            cmdSQL.ExecuteNonQuery()

            ErrorCode = CType(cmdSQL.Parameters.Item("@ErrorCode").Value, Integer)

            If Not ErrorCode.Equals(DataAccessError.OK) Then
                Throw _
                    New Exception(
                        "Stored Procedure 'SMS_UpdateLocatingStatus_LastModifiedBy' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "SMS_UpdateLocatingStatus_LastModifiedBy::Error occured." + Environment.NewLine +
                    Environment.NewLine + ex.Message, ex)

        Finally
            cmdSQL.Dispose()
        End Try
    End Sub

#End Region

#Region "Private Methods"

    'Checks the Status Update Rules, and if the new status code is applied,
    'then update the Date as well.
    Private Sub ApplyStatusUpdateRule(strOldStatus As SqlString, strNewStatus As SqlString)

        If StatusUpdateRuleResult(strOldStatus, strNewStatus) = StatusUpdateResult.Override Then
            LocatingStatus = strNewStatus
            StatusDate = New SqlDateTime(Now())
        Else
            LocatingStatus = strOldStatus
        End If
    End Sub

#End Region
End Class
