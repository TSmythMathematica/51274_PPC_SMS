'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Option Strict On

Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a CaseAssignment object.
''' </summary>

    Public Class CaseAssignment
    Inherits TblCaseAssignment

#Region "Private Fields"

    Private mstrLastError As String
    Private mblnIsNew As Boolean = False
    Private mobjCase As [Case]
    Private mobjRegion As InterviewerRegion
    Private mobjSupervisor As InterviewerSupervisor
    Private mobjTeam As InterviewerTeam
    Private mobjInterviewer As Interviewer

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

#Region "Events"

    Event OnInsert(objCaseAssignment As CaseAssignment)
    Event OnUpdate(objCaseAssignment As CaseAssignment)
    Event OnDelete(objCaseAssignment As CaseAssignment)
    Event OnBeforeDelete(objCaseAssignment As CaseAssignment, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The CaseAssignment class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a CaseAssignment class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignment class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the CaseAssignment is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignment class.
    ''' </summary>
    ''' <param name="intCaseAssignmentID">
    '''     The primary key ID for which the object will be initialized.
    ''' </param>

        Public Sub New(intCaseAssignmentID As SqlInt32)

        MyBase.New()

        MyBase.CaseAssignmentID = intCaseAssignmentID

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If
            Dim dt As DataTable = SelectOne()

            IsNew = dt.Rows.Count = 0

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

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseAssignment belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseAssignment belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the CaseAssignment.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the CaseAssignment.
    ''' </value>

        Public Property [Case] As [Case]
        Get
            If mobjCase Is Nothing Then
                mobjCase = New [Case](Me.CaseID.Value, False)
            End If
            Return mobjCase
        End Get
        Set
            mobjCase = Value
        End Set
    End Property

    Public Property CaseAssignmentSearch As VwCaseAssignmentSearch

    'Public ReadOnly Property ReleasedToField() As Boolean
    '    Get
    '        If mobjCase IsNot Nothing Then
    '            For Each objInst As Instrument In mobjCase.Instruments
    '                If objInst.StatusCode.ToString >= "880" AndAlso objInst.StatusCode.ToString <= "889" Then
    '                    Return True
    '                End If
    '            Next
    '        End If
    '        Return False
    '    End Get
    'End Property

    Public ReadOnly Property IsActive As Boolean
        Get
            Return [Case].IsFieldActive
        End Get
    End Property

    Public Property Region As InterviewerRegion
        Get
            If mobjRegion Is Nothing Then
                If Not InterviewerRegionID.IsNull Then
                    mobjRegion = New InterviewerRegion(GetSafeValue(InterviewerRegionID))
                ElseIf Not InterviewerSupervisorID.IsNull Then
                    mobjRegion = Supervisor.InterviewerRegion
                ElseIf Not InterviewerTeamID.IsNull Then
                    mobjRegion = InterviewerTeam.InterviewerSupervisor.InterviewerRegion
                ElseIf Not InterviewerID.IsNull Then
                    If Interviewer.InterviewerTeam IsNot Nothing Then
                        mobjRegion = Interviewer.InterviewerTeam.InterviewerSupervisor.InterviewerRegion
                    Else
                        mobjRegion = Interviewer.InterviewerSupervisor.InterviewerRegion
                    End If
                End If
            End If
            Return mobjRegion
        End Get
        Set
            mobjRegion = value
            InterviewerRegionID = mobjRegion.InterviewerRegionID
        End Set
    End Property

    Public Property Supervisor As InterviewerSupervisor
        Get
            If mobjSupervisor Is Nothing Then
                If Not InterviewerSupervisorID.IsNull Then
                    mobjSupervisor = New InterviewerSupervisor(GetSafeValue(InterviewerSupervisorID))
                ElseIf Not InterviewerTeamID.IsNull Then
                    mobjSupervisor = InterviewerTeam.InterviewerSupervisor
                ElseIf Not InterviewerID.IsNull Then
                    If Interviewer.InterviewerTeam IsNot Nothing Then
                        mobjSupervisor = Interviewer.InterviewerTeam.InterviewerSupervisor
                    Else
                        mobjSupervisor = Interviewer.InterviewerSupervisor
                    End If
                End If
            End If
            Return mobjSupervisor
        End Get
        Set
            mobjSupervisor = value
            InterviewerSupervisorID = mobjSupervisor.InterviewerSupervisorID
        End Set
    End Property

    Public Property InterviewerTeam As InterviewerTeam
        Get
            If mobjTeam Is Nothing Then
                If Not InterviewerTeamID.IsNull Then
                    mobjTeam = New InterviewerTeam(GetSafeValue(InterviewerTeamID))
                ElseIf Not InterviewerID.IsNull Then
                    mobjTeam = Interviewer.InterviewerTeam
                End If
            End If
            Return mobjTeam
        End Get
        Set
            mobjTeam = value
            InterviewerTeamID = mobjTeam.TeamID
        End Set
    End Property

    Public Property Interviewer As Interviewer
        Get
            If mobjInterviewer Is Nothing Then
                mobjInterviewer = New Interviewer(GetSafeValue(InterviewerID))
            End If
            Return mobjInterviewer
        End Get
        Set
            mobjInterviewer = value
            InterviewerID = mobjInterviewer.InterviewerID
        End Set
    End Property

    Public ReadOnly Property SchoolName As String
        Get
            If [Case] IsNot Nothing AndAlso
               [Case].PrimarySampleMember IsNot Nothing AndAlso
               [Case].PrimarySampleMember.Student IsNot Nothing AndAlso
               [Case].PrimarySampleMember.Student.School IsNot Nothing Then
                Return GetSafeValue([Case].PrimarySampleMember.Student.School.Name)
            Else
                Return ""
            End If
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the CaseAssignment into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the CaseAssignment object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = True

        MyBase.CaseID = mobjCase.CaseID

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Insert()
            IsNew = False

        Catch ex As Exception

            blnResult = False

            mstrLastError = ex.Message

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a CaseAssignment object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

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

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a CaseAssignment from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCancel As Boolean = False

        ' Let's allow the peanut gallery to have a say in whether this Delete occurs

        RaiseEvent OnBeforeDelete(Me, blnCancel)

        blnResult = Not blnCancel

        ' If no objections from the peanut gallery, delete the Case

        If blnResult Then

            ConnectionString = Project.ConnectionString

            ' If CaseID has not been assigned, skip delete

            If Not CaseID.IsNull Then

                Try

                    blnResult = MyBase.Delete()

                Catch ex As Exception

                    blnResult = False

                    Throw ex

                End Try

            End If

        End If

        ' If successful, raise OnDelete event

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        ' Return result

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates or Inserts a CaseAssignment object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Function Assign() As Boolean

        Dim blnResult As Boolean = False

        Try
            If Project.CaseAssignmentsAllowCopy Then
                blnResult = Me.Insert()
            Else
                blnResult = Me.Update()
            End If
        Catch ex As Exception
            blnResult = False
            If ex.InnerException.Message.Contains("duplicate") Then
                Throw New Exception("Duplicates error: This assignment already exists.")
            Else
                Throw ex
            End If
        End Try

        Return blnResult
    End Function

    Public Function ResetAssignment() As Boolean

        InterviewerRegionID = New SqlInt32
        InterviewerSupervisorID = New SqlInt32
        InterviewerTeamID = New SqlInt32
        InterviewerID = New SqlInt32
        'DateAssigned = New SqlTypes.SqlDateTime(Now)

        Return True
    End Function

#End Region

#Region "Private Methods"

    'convert status from 88x to 87x
    Private Function ChangeStatusToReady(Status As String) As String

        If Status >= "880" And Status <= "889" Then
            Return CStr(CInt(Status) - 10)
        Else
            Return String.Empty
        End If
    End Function

    'convert status from 87x to 88x
    Private Function ChangeStatusToReleased(Status As String) As String

        If Status >= "870" And Status <= "879" Then
            Return CStr(CInt(Status) + 10)
        Else
            Return String.Empty
        End If
    End Function

#End Region
End Class
