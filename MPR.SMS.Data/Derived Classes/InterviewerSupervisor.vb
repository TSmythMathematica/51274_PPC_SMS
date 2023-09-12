'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a InterviewerSupervisor object.
''' </summary>

    Public Class InterviewerSupervisor
    Inherits TlkpInterviewerSupervisor

#Region "Private Variables"

    Private mobjTeams As InterviewerTeams
    Private mobjInterviewers As Interviewers
    Private mobjCaseAssignments As CaseAssignments
    Private mobjRegion As InterviewerRegion

#End Region

#Region "Events"

    Event OnInsert(objInterviewerSupervisor As InterviewerSupervisor)

    Event OnUpdate(objInterviewerSupervisor As InterviewerSupervisor)

    Event OnDelete(objInterviewerSupervisor As InterviewerSupervisor)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerSupervisor belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerSupervisor belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Property InterviewerRegion As InterviewerRegion
        Get
            If mobjRegion Is Nothing AndAlso Not InterviewerRegionID.IsNull Then
                mobjRegion = New InterviewerRegion(GetSafeValue(InterviewerRegionID))
            End If
            Return mobjRegion
        End Get
        Set
            mobjRegion = value
            InterviewerRegionID = mobjRegion.InterviewerRegionID
        End Set
    End Property

    Public Property InterviewerTeams As InterviewerTeams
        Get
            If mobjTeams Is Nothing Then
                mobjTeams = New InterviewerTeams(Me)
            End If
            Return (mobjTeams)
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
            Return (mobjInterviewers)
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

    Public ReadOnly Property FullName As String
        Get
            Return GetSafeValue(FirstName) & " " & GetSafeValue(LastName)
        End Get
    End Property

    Public ReadOnly Property NodeText As String
        Get
            Dim str As String = FullName

            'un-comment out the lines below to show the active cases per supervisor. 
            'this was disabled only because it can be SLOOOOW if there's many supervisors
            'Dim cnt As Integer = CaseAssignments(Data.CaseAssignments.CaseAssignmentType.ViewActive).Count
            'If cnt > 0 Then str += " (" + CStr(cnt) + ")"
            Return str
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The InterviewerSupervisor class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a InterviewerSupervisor class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerSupervisor class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the InterviewerSupervisor is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer Supervisor class.
    ''' </summary>
    ''' <param name="intSupervisorID">
    '''     The unique Interviewer Supervisor ID
    ''' </param>
    Public Sub New(intSupervisorID As Integer)

        MyBase.New()

        MyBase.InterviewerSupervisorID = New SqlInt32(intSupervisorID)

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


    ''' <summary>
    '''     Initializes a new instance of the Interviewer Supervisor class.
    ''' </summary>
    ''' <param name="strUserName">
    '''     The unique User Name
    ''' </param>
    Public Sub New(strUserName As String)

        MyBase.New()

        Dim SQL As String = "SELECT * FROM TlkpInterviewerSupervisor WHERE UserName = '" & strUserName & "'"
        Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, SQL)

        While dr.Read()

            MyBase.InterviewerSupervisorID = New SqlInt32(CInt(dr("InterviewerSupervisorID")))

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

        End While

        dr.Close()

        dr = Nothing
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the InterviewerSupervisor into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the InterviewerSupervisor object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the InterviewerSupervisor

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
    '''     Updates a InterviewerSupervisor object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        If InterviewerSupervisorID.IsNull OrElse InterviewerSupervisorID.Value < 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the InterviewerSupervisor

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
    '''     Deletes a InterviewerSupervisor from the database
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

        ' Delete the InterviewerSupervisor

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
