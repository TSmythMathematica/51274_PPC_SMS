'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a InterviewerCaseTracking object.
''' </summary>

    Public Class InterviewerCaseTracking
    Inherits TblInterviewerCaseTracking

#Region "Private Variables"

    Private mobjInterviewer As Interviewer
    Private mobjCase As [Case]

#End Region

#Region "Events"

    Event OnInsert(objInterviewerCaseTracking As InterviewerCaseTracking)
    Event OnUpdate(objInterviewerCaseTracking As InterviewerCaseTracking)
    Event OnDelete(objInterviewerCaseTracking As InterviewerCaseTracking)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerCaseTracking belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerCaseTracking belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
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
        End Set
    End Property

    Public Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            If mobjCase IsNot Nothing Then
                CaseID = mobjCase.CaseID
            Else
                CaseID = 0
            End If
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The InterviewerCaseTracking class constructor has four overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a InterviewerCaseTracking class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerCaseTracking class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the InterviewerCaseTracking is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer Case Tracking class.
    ''' </summary>
    ''' <param name="intInterviewerCaseTrackingID">
    '''     The unique intInterviewerCaseTrackingID
    ''' </param>
    Public Sub New(intInterviewerCaseTrackingID As Integer)

        MyBase.New()

        MyBase.InterviewerCaseTrackingID = New SqlInt32(intInterviewerCaseTrackingID)

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
    '''     Inserts the InterviewerCaseTracking into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the InterviewerCaseTracking object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the InterviewerCaseTracking

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
    '''     Updates a InterviewerCaseTracking object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        If InterviewerCaseTrackingID.IsNull OrElse InterviewerCaseTrackingID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the InterviewerCaseTracking

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
    '''     Deletes a InterviewerCaseTracking from the database
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

        ' Delete the InterviewerCaseTracking

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
