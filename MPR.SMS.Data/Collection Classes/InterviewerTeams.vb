'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewerTeam objects for the Project
''' </summary>

    Public Class InterviewerTeams
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewerTeam at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewerTeam to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewerTeam at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As InterviewerTeam

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewerTeam)
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
    '''     Initializes a new instance of the InterviewerTeams collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerTeams from the database.
    ''' </remarks>

        Public Sub New()

        Dim objIntTeam As New TlkpInterviewerTeam

        objIntTeam.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntTeam.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objIntTeams As DataTable = objIntTeam.SelectAll()

        objIntTeam.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objIntTeams.Rows
            Add(New InterviewerTeam(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerTeams collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerTeams for a given Supervisor.
    ''' </remarks>

        Public Sub New(objSupervisor As InterviewerSupervisor)

        Dim objIntTeam As New TlkpInterviewerTeam

        objIntTeam.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntTeam.ConnectionProvider = Project.ConnectionProvider
        End If

        objIntTeam.SupervisorID = objSupervisor.InterviewerSupervisorID
        Dim objIntTeams As DataTable = objIntTeam.SelectAllWSupervisorIDLogic

        objIntTeam.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objIntTeams.Rows
            Add(New InterviewerTeam(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerTeams collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerTeams for a given Region.
    ''' </remarks>

        Public Sub New(objRegion As InterviewerRegion)

        Dim objIntTeam As New TlkpInterviewerTeam

        objIntTeam.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntTeam.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDataRow As DataRow

        For Each objSup As InterviewerSupervisor In objRegion.InterviewerSupervisors
            objIntTeam.SupervisorID = objSup.InterviewerSupervisorID
            Dim objIntTeams As DataTable = objIntTeam.SelectAllWSupervisorIDLogic

            For Each objDataRow In objIntTeams.Rows
                Add(New InterviewerTeam(objDataRow))
            Next
        Next

        objIntTeam.ConnectionProvider = Nothing
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewerTeam to the InterviewerTeams collection.
    ''' </summary>
    ''' <param name="objInterviewerTeam">
    '''     The InterviewerTeam to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewerTeam has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerTeams are maintained in ascending order by TeamID.
    ''' </remarks>

        Public Function Add(objInterviewerTeam As InterviewerTeam) As Integer

        If objInterviewerTeam.TeamID.IsNull Then
            If Not objInterviewerTeam.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInterviewerTeam As InterviewerTeam = CType(List.Item(i), InterviewerTeam)
            If objInterviewerTeam.TeamID.Value < objExistingInterviewerTeam.TeamID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objInterviewerTeam)

        Return i
    End Function

    ''' <summary>
    '''     Updates a InterviewerTeam in the collection.
    ''' </summary>
    ''' <param name="objInterviewerTeam">
    '''     The InterviewerTeam object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerTeams are maintained in ascending order by TeamID.
    ''' </remarks>

        Public Function Update(objInterviewerTeam As InterviewerTeam) As Boolean

        If Not objInterviewerTeam.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewerTeam As InterviewerTeam = CType(List.Item(i), InterviewerTeam)
            If objExistingInterviewerTeam.TeamID.Value = objInterviewerTeam.TeamID.Value Then
                List.RemoveAt(i)
                Add(objInterviewerTeam)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the InterviewerTeam within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the InterviewerTeam whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the InterviewerTeam within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewerTeam As InterviewerTeam = CType(List.Item(i), InterviewerTeam)
                If objInterviewerTeam.TeamID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(intID As Integer) As InterviewerTeam

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInterviewerTeam As InterviewerTeam = CType(List.Item(i), InterviewerTeam)
            If objInterviewerTeam.TeamID.Value = intID Then
                Return objInterviewerTeam
            End If
        Next

        Return Nothing
    End Function

#End Region
End Class
