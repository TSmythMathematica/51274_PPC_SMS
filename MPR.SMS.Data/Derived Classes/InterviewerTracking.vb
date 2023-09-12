'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a InterviewerTracking object.
''' </summary>

    Public Class InterviewerTracking
    Inherits TblInterviewerTracking

#Region "Private Variables"

    Private mobjInterviewer As Interviewer

#End Region

#Region "Events"

    Event OnInsert(objInterviewerTracking As InterviewerTracking)
    Event OnUpdate(objInterviewerTracking As InterviewerTracking)
    Event OnDelete(objInterviewerTracking As InterviewerTracking)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerTracking belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the InterviewerTracking belongs to.
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

    Public Overloads Property WeekBeg As SqlDateTime
        Get
            If WeekBeg.IsNull Then
                Return CType(DateAdd(DateInterval.Day, - 6, GetSafeValue(WeekEnd)), SqlDateTime)
            Else
                Return WeekBeg
            End If
        End Get
        Set
            MyBase.WeekBeg = Value
        End Set
    End Property

    Public ReadOnly Property TotalExpenses As Double
        Get
            Return _
                GetSafeValue(Expenses) + GetSafeValue(MileageExpense) + GetSafeValue(CarRental) +
                GetSafeValue(AirTravel)
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The InterviewerTracking class constructor has three overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a InterviewerTracking class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerTracking class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the InterviewerTracking is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewer Tracking class.
    ''' </summary>
    ''' <param name="intInterviewerTrackingID">
    '''     The unique Interviewer Tracking ID
    ''' </param>
    Public Sub New(intInterviewerTrackingID As Integer)

        MyBase.New()

        MyBase.InterviewerTrackingID = New SqlInt32(intInterviewerTrackingID)

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
    '''     Inserts the InterviewerTracking into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the InterviewerTracking object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the InterviewerTracking

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
    '''     Updates a InterviewerTracking object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        If InterviewerTrackingID.IsNull OrElse InterviewerTrackingID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the InterviewerTracking

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
    '''     Deletes a InterviewerTracking from the database
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

        ' Delete the InterviewerTracking

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
