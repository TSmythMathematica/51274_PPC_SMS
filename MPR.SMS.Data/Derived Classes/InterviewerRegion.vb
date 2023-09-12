'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a InterviewerRegion object.
''' </summary>

    Public Class InterviewerRegion
    Inherits TlkpInterviewerRegion

#Region "Private Variables"

    Private mobjTeams As InterviewerTeams
    Private mobjSupervisors As InterviewerSupervisors
    Private mobjInterviewers As Interviewers
    Private mobjCaseAssignments As CaseAssignments

#End Region

#Region "Events"

    Event OnInsert(objInterviewerRegion As InterviewerRegion)

    Event OnUpdate(objInterviewerRegion As InterviewerRegion)

    Event OnDelete(objInterviewerRegion As InterviewerRegion)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerRegion belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerRegion belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Property InterviewerSupervisors As InterviewerSupervisors
        Get
            If mobjSupervisors Is Nothing Then
                mobjSupervisors = New InterviewerSupervisors(Me)
            End If
            Return mobjSupervisors
        End Get
        Set
            mobjSupervisors = value
        End Set
    End Property

    Public Property InterviewerTeams As InterviewerTeams
        Get
            If mobjTeams Is Nothing Then
                mobjTeams = New InterviewerTeams(Me)
            End If
            Return mobjTeams
        End Get
        Set
            mobjTeams = value
        End Set
    End Property

    Public Property Interviewers As Interviewers
        Get
            If mobjInterviewers Is Nothing Then
                mobjInterviewers = New Interviewers(Me)
            End If
            Return mobjInterviewers
        End Get
        Set
            mobjInterviewers = value
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

    Public ReadOnly Property NodeText As String
        Get
            Dim str As String = GetSafeValue(Name.ToString)

            'un-comment out the lines below to show the active cases per Region. 
            'this was disabled only because it can be SLOOOOW if there's many regions.
            'Dim cnt As Integer = CaseAssignments(Data.CaseAssignments.CaseAssignmentType.ViewActive).Count
            'If cnt > 0 Then str += " (" + CStr(cnt) + ")"
            Return str
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The InterviewerRegion class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a InterviewerRegion class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerRegion class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the InterviewerRegion is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer Region class.
    ''' </summary>
    ''' <param name="intRegionID">
    '''     The unique Interviewer Region ID
    ''' </param>
    Public Sub New(intRegionID As Integer)

        MyBase.New()

        MyBase.InterviewerRegionID = New SqlInt32(intRegionID)

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
    '''     Inserts the InterviewerRegion into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the InterviewerRegion object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the InterviewerRegion

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a InterviewerRegion object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        If InterviewerRegionID.IsNull OrElse InterviewerRegionID.Value < 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If


        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the InterviewerRegion

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a InterviewerRegion from the database
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

        ' Delete the InterviewerRegion

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

#End Region
End Class
