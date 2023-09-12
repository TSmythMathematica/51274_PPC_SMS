'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class CaseAssignments
    Inherits CollectionBase

    Public Enum CaseAssignmentType
        ViewAll
        ViewAssigned
        ViewUnassigned
        ViewActive
        ViewCompleted
        ViewValidation
    End Enum

#Region "Constructors"

    Public Sub New()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>

        Public Sub New(blnAll As Boolean)

        ' Retrieve the CaseAssignments

        If blnAll Then
            Dim objCaseAssignment As New TblCaseAssignment

            objCaseAssignment.ConnectionString = Project.ConnectionString

            ' If the Project's Connection Provider is open, use it

            If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
            End If

            Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAll()

            objCaseAssignment.ConnectionProvider = Nothing

            ' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

            Dim objDataRow As DataRow

            For Each objDataRow In objCaseAssignments.Rows
                Add(New CaseAssignment(objDataRow))
            Next
        End If
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>
    ''' <param name="objSupervisor">
    '''     The Supervisor that the CaseAssignments belong to.
    ''' </param>

        Public Sub New(objSupervisor As InterviewerSupervisor, CaseAssignmentType As CaseAssignmentType)

        '' Retrieve the CaseAssignments

        'Dim objCaseAssignment As New TblCaseAssignment

        'objCaseAssignment.ConnectionString = Project.ConnectionString

        '' If the Project's Connection Provider is open, use it

        'If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
        '    objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
        'End If

        'objCaseAssignment.InterviewerSupervisorID = objSupervisor.InterviewerSupervisorID
        'Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAllWInterviewerSupervisorIDLogic()

        'objCaseAssignment.ConnectionProvider = Nothing

        '' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

        'Dim objDataRow As DataRow

        'For Each objDataRow In objCaseAssignments.Rows
        '    Dim objAssignment As New CaseAssignment(objDataRow)
        '    If IsFiltered(objAssignment, CaseAssignmentType) Then
        '        Add(objAssignment)
        '    End If
        'Next

        Dim strSQL As String = "WHERE SupervisorID = " & GetSafeValue(objSupervisor.InterviewerSupervisorID)
        strSQL += GetWhereClause(CaseAssignmentType)
        FillCollection(strSQL)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>
    ''' <param name="objTeam">
    '''     The Team that the CaseAssignments belong to.
    ''' </param>

        Public Sub New(objTeam As InterviewerTeam, CaseAssignmentType As CaseAssignmentType)

        '' Retrieve the CaseAssignments

        'Dim objCaseAssignment As New TblCaseAssignment

        'objCaseAssignment.ConnectionString = Project.ConnectionString

        '' If the Project's Connection Provider is open, use it

        'If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
        '    objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
        'End If

        'objCaseAssignment.InterviewerTeamID = objTeam.TeamID
        'Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAllWInterviewerTeamIDLogic()

        'objCaseAssignment.ConnectionProvider = Nothing

        '' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

        'Dim objDataRow As DataRow

        'For Each objDataRow In objCaseAssignments.Rows
        '    Dim objAssignment As New CaseAssignment(objDataRow)
        '    If IsFiltered(objAssignment, CaseAssignmentType) Then
        '        Add(objAssignment)
        '    End If
        'Next


        Dim strSQL As String = "WHERE TeamID = " & GetSafeValue(objTeam.TeamID)
        strSQL += GetWhereClause(CaseAssignmentType)
        FillCollection(strSQL)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>
    ''' <param name="objRegion">
    '''     The Region that the CaseAssignments belong to.
    ''' </param>

        Public Sub New(objRegion As InterviewerRegion, CaseAssignmentType As CaseAssignmentType)

        '' Retrieve the CaseAssignments

        'Dim objCaseAssignment As New TblCaseAssignment

        'objCaseAssignment.ConnectionString = Project.ConnectionString

        '' If the Project's Connection Provider is open, use it
        'If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
        '    objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
        'End If

        'objCaseAssignment.InterviewerRegionID = objRegion.InterviewerRegionID
        'Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAllWInterviewerRegionIDLogic()

        'objCaseAssignment.ConnectionProvider = Nothing

        '' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

        'Dim objDataRow As DataRow

        'For Each objDataRow In objCaseAssignments.Rows
        '    Dim objAssignment As New CaseAssignment(objDataRow)
        '    If IsFiltered(objAssignment, CaseAssignmentType) Then
        '        Add(objAssignment)
        '    End If
        'Next

        Dim strSQL As String = "WHERE RegionID = " & GetSafeValue(objRegion.InterviewerRegionID)
        strSQL += GetWhereClause(CaseAssignmentType)
        FillCollection(strSQL)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>
    ''' <param name="objInterviewer">
    '''     The interviewer that the CaseAssignments belong to.
    ''' </param>

        Public Sub New(objInterviewer As Interviewer, CaseAssignmentType As CaseAssignmentType)

        '' Retrieve the CaseAssignments

        'Dim objCaseAssignment As New TblCaseAssignment

        'objCaseAssignment.ConnectionString = Project.ConnectionString

        '' If the Project's Connection Provider is open, use it

        'If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
        '    objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
        'End If

        'objCaseAssignment.InterviewerID = objInterviewer.InterviewerID
        'Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAllWInterviewerIDLogic

        'objCaseAssignment.ConnectionProvider = Nothing

        '' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

        'Dim objDataRow As DataRow

        'For Each objDataRow In objCaseAssignments.Rows
        '    Dim objAssignment As New CaseAssignment(objDataRow)
        '    If IsFiltered(objAssignment, CaseAssignmentType) Then
        '        Add(objAssignment)
        '    End If
        'Next

        Dim strSQL As String = "WHERE InterviewerID = " & GetSafeValue(objInterviewer.InterviewerID)
        strSQL += GetWhereClause(CaseAssignmentType)
        FillCollection(strSQL)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseAssignments collection.
    ''' </summary>
    ''' <remarks>
    '''     The CaseAssignments collection is initialized from the database.
    ''' </remarks>
    ''' <param name="objCase">
    '''     The collection of CaseAssignments for a case.
    ''' </param>

        Public Sub New(objCase As [Case])

        ' Retrieve the CaseAssignments

        Dim objCaseAssignment As New TblCaseAssignment

        objCaseAssignment.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
        End If

        objCaseAssignment.CaseID = objCase.CaseID
        Dim objCaseAssignments As DataTable = objCaseAssignment.SelectAllWCaseIDLogic

        objCaseAssignment.ConnectionProvider = Nothing

        ' Add a new CaseAssignment to the collection for each CaseAssignment retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objCaseAssignments.Rows
            Add(New CaseAssignment(objDataRow))
        Next
    End Sub

    'Public Sub New(ByVal strSQL As String)

    '    Dim objCaseAssignment As New TblCaseAssignment

    '    objCaseAssignment.ConnectionString = Project.ConnectionString

    '    ' If the Project's Connection Provider is open, use it
    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        objCaseAssignment.ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Dim objCaseAssignments As DataTable = GlobalData.GetDataTable(strSQL)

    '    objCaseAssignment.ConnectionProvider = Nothing

    '    ' Add a new Person to the collection for each Person retrieved

    '    Dim objDataRow As DataRow

    '    For Each objDataRow In objCaseAssignments.Rows
    '        Add(New CaseAssignment(objDataRow))
    '    Next

    'End Sub

    Public Sub New(strSQLWhere As String)

        FillCollection(strSQLWhere)
    End Sub

#End Region

#Region "Public Properties"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseAssignment at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the CaseAssignment to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The CaseAssignment at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As CaseAssignment

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), CaseAssignment)
            End If
            Return Nothing
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a CaseAssignment to the CaseAssignments collection.
    ''' </summary>
    ''' <param name="objCaseAssignment">
    '''     The CaseAssignment to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the CaseAssignment has been added.
    ''' </returns>
    ''' <remarks>
    '''     CaseAssignments are maintained in ascending order by CaseID.
    ''' </remarks>

        Public Function Add(objCaseAssignment As CaseAssignment) As Integer

        If objCaseAssignment.CaseID.IsNull Then
            If Not objCaseAssignment.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingCaseAssignment As CaseAssignment = CType(List.Item(i), CaseAssignment)
            If objCaseAssignment.CaseID.Value < objExistingCaseAssignment.CaseID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objCaseAssignment)

        Return i
    End Function

    '' <summary>
    ''     Updates a <see cref="T:MPR.SMS.Data.CaseAssignment">CaseAssignment</see> object within the CaseAssignments
    ''     collection.
    '' </summary>
    '' <param name="objCaseAssignment">
    ''     The <see cref="T:MPR.SMS.Data.CaseAssignment">CaseAssignment</see> object to be updated within the collection.
    '' </param>
    '' <returns>
    ''     True if successful, otherwise False
    '' </returns>
    '' <remarks>
    ''     The <see cref="T:MPR.SMS.Data.CaseAssignment">CaseAssignment</see> object is updated within the database and the
    ''     collection. The
    ''     collection is maintained in sorted order by <see cref="T:MPR.SMS.Data.CaseAssignment.CaseID">CaseID</see>.
    '' </remarks>

    Public Function Update(objCaseAssignment As CaseAssignment) As Boolean

        If Not objCaseAssignment.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingCaseAssignment As CaseAssignment = CType(List.Item(i), CaseAssignment)
            If objExistingCaseAssignment.CaseID.Value = objCaseAssignment.CaseID.Value Then
                List.RemoveAt(i)
                Add(objCaseAssignment)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the CaseAssignment within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the CaseAssignment whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the CaseAssignment within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objCaseAssignment As CaseAssignment = CType(List.Item(i), CaseAssignment)
                If objCaseAssignment.CaseID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region

#Region "Private Methods"

    Private Function IsFiltered(objCaseAssignment As CaseAssignment, CaseAssignmentType As CaseAssignmentType) _
        As Boolean

        If CaseAssignmentType = CaseAssignmentType.ViewAll Then
            Return True
        ElseIf CaseAssignmentType = CaseAssignmentType.ViewActive Then
            Return objCaseAssignment.Case.IsFieldActive
        ElseIf CaseAssignmentType = CaseAssignmentType.ViewAssigned Then
            Return Not objCaseAssignment.InterviewerID.IsNull
        ElseIf CaseAssignmentType = CaseAssignmentType.ViewCompleted Then
            Return objCaseAssignment.Case.IsFieldComplete
        ElseIf CaseAssignmentType = CaseAssignmentType.ViewUnassigned Then
            Return objCaseAssignment.InterviewerID.IsNull
        ElseIf CaseAssignmentType = CaseAssignmentType.ViewValidation Then
            Return objCaseAssignment.Case.IsFieldValidation
        Else
            Return False
        End If
    End Function

    Private ReadOnly Property GetWhereClause(CaseAssignmentType As CaseAssignmentType) As String
        Get
            ' Build the Select statement using the StringBuilder class
            Dim strSQL As String = " AND "
            Select Case CaseAssignmentType

                Case CaseAssignmentType.ViewAll
                    strSQL = ""
                Case CaseAssignmentType.ViewActive
                    strSQL += "IsFinalStatus = 0 AND StatusCode <> '000'"
                Case CaseAssignmentType.ViewAssigned
                    strSQL += "(InterviewerID IS NOT NULL OR TeamID IS NOT NULL)"
                Case CaseAssignmentType.ViewCompleted
                    strSQL += "IsComplete = 1"
                Case CaseAssignmentType.ViewUnassigned
                    strSQL += "(InterviewerID IS NULL AND TeamID IS NULL)"
                Case CaseAssignmentType.ViewValidation
                    strSQL += "IsValidate = 1"

            End Select

            Return strSQL
        End Get
    End Property

    Private Sub FillCollection(ByVal strSQLWhere As String)

        Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionString, "SMS_SearchCaseAssignments", strSQLWhere)
        Dim ca As CaseAssignment
        While dr.Read
            'Add(New CaseAssignment(CType(CType(dr("CaseAssignmentID"), Integer), SqlTypes.SqlInt32)))
            ca = New CaseAssignment(CType(CType(dr("CaseAssignmentID"), Integer), SqlTypes.SqlInt32))
            ca.CaseAssignmentSearch = New VwCaseAssignmentSearch(dr)
            Add(ca)
        End While

        dr.Close()
        dr = Nothing

    End Sub

#End Region
End Class
