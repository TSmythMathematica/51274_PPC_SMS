'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Interviewer object.
''' </summary>

    Public Class Interviewer
    Inherits TlkpInterviewer

#Region "Private Variables"

    Private mobjTeam As InterviewerTeam
    Private mobjSupervisor As InterviewerSupervisor
    Private mobjCaseAssignments As CaseAssignments
    Private mobjInterviewerTrackings As InterviewerTrackings

#End Region

#Region "Events"

    Event OnInsert(objInterviewer As Interviewer)

    Event OnUpdate(objInterviewer As Interviewer)

    Event OnDelete(objInterviewer As Interviewer)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Interviewer belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Interviewer belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property IsActive As Boolean
        Get
            Return CBool(Status = "active")
        End Get
    End Property

    Public ReadOnly Property FullName As String
        Get
            Return GetSafeValue(FirstName) & " " & GetSafeValue(LastName)
        End Get
    End Property

    Public ReadOnly Property NodeText As String
        Get
            Dim str As String = FullName
            If Description.ToString.Length > 0 Then
                str += " - " + Description.ToString
            End If
            If Project.ShowInterviewerCaseCount Then
                Dim cnt As Integer = CaseAssignments(Data.CaseAssignments.CaseAssignmentType.ViewActive).Count
                If cnt > 0 Then str += " (" + CStr(cnt) + ")"
            End If
            Return str
        End Get
    End Property

    Public Property InterviewerTeam As InterviewerTeam
        Get
            If mobjTeam Is Nothing AndAlso Not TeamID.IsNull Then
                mobjTeam = New InterviewerTeam(GetSafeValue(TeamID))
            End If
            Return mobjTeam
        End Get
        Set
            mobjTeam = value
            TeamID = mobjTeam.TeamID
        End Set
    End Property

    Public Property InterviewerSupervisor As InterviewerSupervisor
        Get
            If mobjSupervisor Is Nothing AndAlso Not InterviewerSupervisorID.IsNull Then
                mobjSupervisor = New InterviewerSupervisor(GetSafeValue(InterviewerSupervisorID))
            End If
            Return mobjSupervisor
        End Get
        Set
            mobjSupervisor = value
            InterviewerSupervisorID = mobjSupervisor.InterviewerSupervisorID
        End Set
    End Property

    Public Property CaseAssignments(CaseAssignmentType As CaseAssignments.CaseAssignmentType) As CaseAssignments
        Get
            If mobjCaseAssignments Is Nothing Then
                mobjCaseAssignments = New CaseAssignments(Me, CaseAssignmentType)
            End If
            Return mobjCaseAssignments
        End Get
        Set
            mobjCaseAssignments = value
        End Set
    End Property

    Public Property InterviewerTrackings As InterviewerTrackings
        Get
            If mobjInterviewerTrackings Is Nothing Then
                mobjInterviewerTrackings = New InterviewerTrackings(Me)
            End If
            Return mobjInterviewerTrackings
        End Get
        Set
            mobjInterviewerTrackings = value
        End Set
    End Property

    Public Shadows ReadOnly Property IsModified As Boolean
        Get

            If MyBase.IsModified Then
                Return True
            ElseIf InterviewerTrackings.IsModified Then
                Return True
                'ElseIf CaseAssignments.IsModified Then
                '    Return True
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Interviewer class constructor has four overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Interviewer class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Interviewer is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer class.
    ''' </summary>
    ''' <param name="intInterviewerID">
    '''     The unique Interviewer ID
    ''' </param>
    Public Sub New(intInterviewerID As Integer)

        MyBase.New()

        MyBase.InterviewerID = New SqlInt32(intInterviewerID)

        ConnectionString = Project.ConnectionString
        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            SelectOne()

        Catch ex As Exception

            ' Rethrow the exception
            'Throw ex

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
    '''     Inserts the Interviewer into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Interviewer object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCloseConnection As Boolean = False
        ConnectionProvider = Project.ConnectionProvider

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        'If no Team specified, create a new dummy Team
        'If TeamID = Nothing Then
        '    Dim objTeam As New InterviewerTeam
        '    objTeam.SupervisorID = InterviewerSupervisorID
        '    objTeam.TeamName = "Team_" & UserName.ToString
        '    objTeam.Insert()
        '    TeamID = objTeam.TeamID
        'End If


        ' Insert the Interviewer

        Try
            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Insert()
            If blnResult Then
                blnResult = InterviewerTrackings.Insert
            End If
        Catch ex As Exception
            blnResult = False
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
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a Interviewer object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCloseConnection As Boolean = False
        ConnectionProvider = Project.ConnectionProvider

        If InterviewerID.IsNull OrElse InterviewerID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the Interviewer
        Try
            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Update()
            If blnResult Then
                blnResult = InterviewerTrackings.Update
            End If
        Catch ex As Exception
            blnResult = False
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
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Interviewer from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCloseConnection As Boolean = False
        ConnectionProvider = Project.ConnectionProvider

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the Interviewer

        Try
            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
        Finally
            ' Insure the database is always closed if it was opened here
            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

    Public Sub RefreshAssignment(ByVal caseAssignmentType As CaseAssignments.CaseAssignmentType )       
        If Project.ShowInterviewerCaseCount Then
            mobjCaseAssignments = New CaseAssignments(Me, caseAssignmentType)
        End If
      
    End Sub


#End Region
End Class
