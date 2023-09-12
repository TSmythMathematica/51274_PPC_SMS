'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Interviewer objects for the Project
''' </summary>

    Public Class Interviewers
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the Interviewer at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Interviewer to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Interviewer at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Interviewer

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Interviewer)
            End If
            Return Nothing
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the Interviewers collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL Interviewers from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Interviewers

        Dim objInterviewer As New TlkpInterviewer

        objInterviewer.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewer.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInterviewers As DataTable = objInterviewer.SelectAll()

        objInterviewer.ConnectionProvider = Nothing

        ' Add a new Interviewer to the collection for each Interviewer retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewers.Rows
            Add(New Interviewer(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewers collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all Interviewers for a given Region
    ''' </remarks>

        Public Sub New(objRegion As InterviewerRegion)

        ' Retrieve the Project's Interviewers

        Dim objInterviewer As New TlkpInterviewer

        objInterviewer.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewer.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDataRow As DataRow

        For Each objSupervisor As InterviewerSupervisor In objRegion.InterviewerSupervisors
            objInterviewer.InterviewerSupervisorID = objSupervisor.InterviewerSupervisorID
            Dim objInterviewers As DataTable = objInterviewer.SelectAllWInterviewerSupervisorIDLogic

            ' Add a new Interviewer to the collection for each Interviewer retrieved
            For Each objDataRow In objInterviewers.Rows
                Add(New Interviewer(objDataRow))
            Next
        Next

        objInterviewer.ConnectionProvider = Nothing
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewers collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all Interviewers for a given Supervisor
    ''' </remarks>

        Public Sub New(objSupervisor As InterviewerSupervisor)

        ' Retrieve the Project's Interviewers

        Dim objInterviewer As New TlkpInterviewer

        objInterviewer.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewer.ConnectionProvider = Project.ConnectionProvider
        End If

        objInterviewer.InterviewerSupervisorID = objSupervisor.InterviewerSupervisorID
        Dim objInterviewers As DataTable = objInterviewer.SelectAllWInterviewerSupervisorIDLogic

        objInterviewer.ConnectionProvider = Nothing

        ' Add a new Interviewer to the collection for each Interviewer retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewers.Rows
            Add(New Interviewer(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Interviewers collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all Interviewers for a given team
    ''' </remarks>

        Public Sub New(objTeam As InterviewerTeam)

        ' Retrieve the Project's Interviewers

        Dim objInterviewer As New TlkpInterviewer

        objInterviewer.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewer.ConnectionProvider = Project.ConnectionProvider
        End If

        objInterviewer.TeamID = objTeam.TeamID
        Dim objInterviewers As DataTable = objInterviewer.SelectAllWTeamIDLogic

        objInterviewer.ConnectionProvider = Nothing

        ' Add a new Interviewer to the collection for each Interviewer retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewers.Rows
            Add(New Interviewer(objDataRow))
        Next
    End Sub

    Public Sub New (Optional ByVal isInitial As Boolean = True)
        If isInitial Then
            Dim objInterviewer As New TlkpInterviewer

            objInterviewer.ConnectionString = Project.ConnectionString

            ' If the Project's Connection Provider is open, use it

            If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                objInterviewer.ConnectionProvider = Project.ConnectionProvider
            End If

            Dim objInterviewers As DataTable = objInterviewer.SelectAll()

            objInterviewer.ConnectionProvider = Nothing

            ' Add a new Interviewer to the collection for each Interviewer retrieved

            Dim objDataRow As DataRow

            For Each objDataRow In objInterviewers.Rows
                Add(New Interviewer(objDataRow))
            Next
        End If
    End Sub


#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Interviewer to the Interviewers collection.
    ''' </summary>
    ''' <param name="objInterviewer">
    '''     The Interviewer to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Interviewer has been added.
    ''' </returns>
    ''' <remarks>
    '''     Interviewers are maintained in ascending order by InterviewerID.
    ''' </remarks>

        Public Function Add(objInterviewer As Interviewer) As Integer

        If objInterviewer.InterviewerID.IsNull Then
            If Not objInterviewer.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInterviewer As Interviewer = CType(List.Item(i), Interviewer)
            If objInterviewer.InterviewerID.Value < objExistingInterviewer.InterviewerID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objInterviewer)

        Return i
    End Function

    ''' <summary>
    '''     Updates a Interviewer in the collection.
    ''' </summary>
    ''' <param name="objInterviewer">
    '''     The Interviewer object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Interviewers are maintained in ascending order by Interviewer Code.
    ''' </remarks>

        Public Function Update(objInterviewer As Interviewer) As Boolean

        If Not objInterviewer.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewer As Interviewer = CType(List.Item(i), Interviewer)
            If objExistingInterviewer.InterviewerID.Value = objInterviewer.InterviewerID.Value Then
                List.RemoveAt(i)
                Add(objInterviewer)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the Interviewer within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Interviewer whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Interviewer within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewer As Interviewer = CType(List.Item(i), Interviewer)
                If objInterviewer.InterviewerID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(intID As Integer) As Interviewer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInterviewer As Interviewer = CType(List.Item(i), Interviewer)
            If objInterviewer.InterviewerID.Value = intID Then
                Return objInterviewer
            End If
        Next

        Return Nothing
    End Function

    Public Function GetBySupervisor(ByVal supervisorID As SqlInt32) As Interviewers

        Dim i As Integer

        Dim ret As Interviewers = New Interviewers(False)

        For i = 0 To (Count - 1)
            Dim objInterviewer As Interviewer = CType(List.Item(i), Interviewer)
            If objInterviewer.InterviewerSupervisor.InterviewerSupervisorID = supervisorID Then
                ret.Add(objInterviewer)
            End If
        Next

        Return ret

    End Function

#End Region
End Class
