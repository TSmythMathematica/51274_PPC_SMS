'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports MPR.SMS.Data

Public Class SearchSurveyResponse

#Region "Private Variables"

    Private mResultsDataSet As DataSet
    Private mstrDataSource As String
    Private mintOptionInstTypeID As Integer
    Private mstrOptionDescription As String
    Private mstrOptionAction As String
    Private mstrOptionViewName As String
    Private sqlparameter As New SqlParameter("@Option", SqlDbType.VarChar)
    Private intNo As Integer
    Private strSQL As String
    Private strWHERE As String

#End Region

#Region "Public Events"

    Public Event BeginSearch(sender As Object, e As EventArgs)
    Public Event EndSearch(sender As Object, e As EventArgs)
    Public Event SearchError(sender As Object, e As EventArgs, ErrorMsg As String)
    Public Event SearchResultClick(sender As Object, e As EventArgs, DataRow As DataRow)
    Public Event SearchResultDoubleClick(sender As Object, e As EventArgs, DataRow As DataRow)
    Public Event CloseButtonClick(sender As Object, e As EventArgs)
    Public Event ClearButtonClick(sender As Object, e As EventArgs)
    Public Event ExcelButtonClick(sender As Object, e As EventArgs)

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

#End Region

#Region "Public Properties"

    <Category("Appearance")>
    Public Property DataGridVisible As Boolean
        Get
            Return Me.dgvSearchResults.Visible
        End Get
        Set
            Me.dgvSearchResults.Visible = Value
        End Set
    End Property

    <Category("Appearance")>
    Public Property ExcelButtonVisible As Boolean
        Get
            Return Me.btnExcel.Visible
        End Get
        Set
            Me.btnExcel.Visible = Value
        End Set
    End Property

    <Browsable(False),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property SearchCriteria As String
        Get
            If Me.tabSearch.SelectedTab Is Me.tabPageAdvanced Then
                Return txtAdvancedSearch.Text.Trim()
            ElseIf Me.tabSearch.SelectedTab Is Me.tabPageQueryBuilder Then
                Return GetCriteriaNewAdvanced()
            Else
                Return GetCriteria(dgvSearchCriteria.Rows)
            End If
        End Get
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public Property DataSource As String
        Get
            Return mstrDataSource
        End Get
        Set
            mstrDataSource = value
        End Set
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public ReadOnly Property DataTable As DataTable
        Get
            Return mResultsDataSet.Tables(0)
        End Get
    End Property

    <DefaultValue(0)> _
    <Category("Data")>
    Public ReadOnly Property ResultSetCount As Integer
        Get
            If mResultsDataSet IsNot Nothing Then
                Return mResultsDataSet.Tables(0).Rows.Count
            Else
                Return 0
            End If
        End Get
    End Property

    <Category("Data")>
    Public Property IsGridUpdate As Boolean
        Get
            Return Me.cbGridUpdate.Checked
        End Get
        Set
            Me.cbGridUpdate.Checked = Value
        End Set
    End Property

    <Category("Data")>
    Public Property IsCheckBoxIncludeHistory As Boolean
        Get
            Return Me.cbIncludeHistory.Checked
        End Get
        Set
            Me.cbIncludeHistory.Checked = Value
        End Set
    End Property

    <Category("Appearance")>
    Public Property CheckBoxIncludeHistory As Boolean
        Get
            Return Me.cbIncludeHistory.Visible
        End Get
        Set
            Me.cbIncludeHistory.Visible = Value
        End Set
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public Property OptionString As String
        Get
            Return mstrOptionDescription
        End Get
        Set
            mstrOptionDescription = value
        End Set
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public Property OptionInteger As Integer
        Get
            Return mintOptionInstTypeID
        End Get
        Set
            mintOptionInstTypeID = value
        End Set
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public Property OptionActionString As String
        Get
            Return mstrOptionAction
        End Get
        Set
            mstrOptionAction = value
        End Set
    End Property

    <Category("Data")> _
    <DefaultValue("")>
    Public Property OptionViewNameString As String
        Get
            Return mstrOptionViewName
        End Get
        Set
            mstrOptionViewName = value
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Initialize()

        If mstrOptionAction = "Compare" Then
            mResultsDataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text,
                                                       DataSource + " WHERE 1 <> 1")
        Else
            mResultsDataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text, DataSource)
        End If

        InitCriteria(mResultsDataSet.Tables(0))
    End Sub

    Public Function DoPreSearch() As Integer

        Dim strNewSQL As String = strSQL.Replace("SELECT Top 10000 *", "SELECT Count(*) AS Records")
        strNewSQL = strNewSQL.Replace("ORDER BY VariableID", "")

        If Not strSQL.Length.Equals(0) Then

            Dim sqldr As SqlDataReader = Nothing
            Dim mRec As Integer = 0

            Try
                sqldr = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, strNewSQL)

                If sqldr.HasRows = True Then
                    While sqldr.Read
                        mRec = CInt(sqldr("Records").ToString)
                        If Not mRec = 0 Then
                            Exit While
                        End If
                    End While
                    Return mRec
                Else
                    mRec = 0
                    Return mRec
                End If

                If Not sqldr Is Nothing Then
                    sqldr.Close()
                End If
            Catch ex As Exception
                If Not sqldr Is Nothing Then
                    sqldr.Close()
                End If
            End Try

        End If
    End Function


    Public Sub DoSearch()

        If Not strSQL.Length.Equals(0) Then

            Try

                mResultsDataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text, strSQL)

                dgvSearchResults.DataSource = mResultsDataSet.Tables(0)

            Catch ex As Exception

            End Try

        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitCriteria(dt As DataTable)

        dgvSearchCriteria.Rows.Clear()
        Dim i As Integer

        For i = 0 To 1
            dgvSearchCriteria.Rows.Add(dt.Columns.Item(i).ToString)
        Next
        Me.dgvSearchCriteria.Columns.Item(0).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dgvSearchCriteria.Columns.Item(1).SortMode = DataGridViewColumnSortMode.NotSortable
        Me.dgvSearchCriteria.Columns.Item(2).SortMode = DataGridViewColumnSortMode.NotSortable

        For i = 2 To Me.dgvSearchCriteria.Rows.Count - 1
            Me.dgvSearchCriteria.Rows(i).ReadOnly = True
            Me.dgvSearchCriteria.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow
        Next

        Me.cbGridUpdate.Visible = False
        Me.cbGridUpdate.Checked = False

        Me.dgvSearchCriteria.Rows(0).Cells(2).ReadOnly = True
        Me.cboVariableList.Height = Me.dgvSearchCriteria.Rows(0).Height
        Me.cboVariableList.Width = Me.dgvSearchCriteria.Columns(2).Width

        Me.cboVariableList.Items.Clear()

        cboVar1.SelectedIndex = - 1
        cboVar2.SelectedIndex = - 1
        cboVar3.SelectedIndex = - 1
        cboComparision1.SelectedIndex = 0
        cboComparision2.SelectedIndex = 0
        cboComparision3.SelectedIndex = 0
        Me.txtVal1.Text = ""
        Me.txtVal2.Text = ""
        Me.txtVal3.Text = ""
        Me.rbOr.Checked = True
        Me.IsCheckBoxIncludeHistory = False
        Me.txtAdvancedSearch.Text = ""

        If mstrOptionAction = "Compare" Then
            Me.tabSearch.TabPages.Remove(Me.tabPageQueryBuilder)
        End If

        Dim sqldr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionString,
                                                             CommandType.StoredProcedure,
                                                             "SRDEE_GetVariableList",
                                                             New SqlParameter("@InstrumentTypeID",
                                                                              Me.mintOptionInstTypeID),
                                                             New SqlParameter("@InstrumentDesc",
                                                                              Me.mstrOptionDescription))
        If sqldr.HasRows = True Then
            While sqldr.Read
                If mstrOptionAction = "Compare" Then
                    Me.cboVariableList.Items.Add(sqldr("Variable").ToString)
                    Me.cboVar1.Items.Add(sqldr("Variable").ToString)
                    Me.cboVar2.Items.Add(sqldr("Variable").ToString)
                    Me.cboVar3.Items.Add(sqldr("Variable").ToString)
                    Me.lblQuestionNumber.Text = "Variable"
                Else
                    Me.cboVariableList.Items.Add(sqldr("QuestionNumber").ToString)
                    Me.cboVar1.Items.Add(sqldr("QuestionNumber").ToString)
                    Me.cboVar2.Items.Add(sqldr("QuestionNumber").ToString)
                    Me.cboVar3.Items.Add(sqldr("QuestionNumber").ToString)
                    Me.lblQuestionNumber.Text = "QuestionNumber"
                End If
            End While
        End If
        sqldr.Close()
    End Sub

    Private Function GetCriteria(rows As DataGridViewRowCollection) As String

        Dim strCriteria As String = ""
        For Each row As DataGridViewRow In rows
            If Not row.Cells(2).FormattedValue.ToString = "" Or
               row.Cells(1).FormattedValue.ToString = "is empty" Or
               row.Cells(1).FormattedValue.ToString = "is not empty" Then
                If Not strCriteria = "" Then
                    strCriteria = strCriteria + " AND "
                End If
                strCriteria = strCriteria + GetFormatedCriteria(row)
            End If
        Next

        If Not strCriteria = "" Then
            strCriteria = strCriteria + " ORDER BY VariableID "
        End If

        Return strCriteria
    End Function

    Private Function GetFormatedCriteria(row As DataGridViewRow) As String

        Dim strFormatedCriteria As String = ""

        If row.Cells(1).FormattedValue.ToString = "is equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] = '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is not equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] <> '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is less than" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] < '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is less than or equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] <= '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is greater than" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] > '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString.ToString = "is greater than or equal to" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString &
                                  "] >= '" + row.Cells(2).FormattedValue.ToString + "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is empty" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] IS NULL OR [" &
                                  row.Cells(0).FormattedValue.ToString & "] = '')"
        ElseIf row.Cells(1).FormattedValue.ToString = "is not empty" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] IS NOT NULL AND [" &
                                  row.Cells(0).FormattedValue.ToString & "] <> '')"
        ElseIf row.Cells(1).FormattedValue.ToString = "begins with" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '" &
                                  row.Cells(2).FormattedValue.ToString & "%')"
        ElseIf row.Cells(1).FormattedValue.ToString = "ends with" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '%" &
                                  row.Cells(2).FormattedValue.ToString & "')"
        ElseIf row.Cells(1).FormattedValue.ToString = "contains" Then
            strFormatedCriteria = " ([" & row.Cells(0).FormattedValue.ToString & "] LIKE '%" &
                                  row.Cells(2).FormattedValue.ToString & "%')"
        End If

        Return strFormatedCriteria
    End Function

    Private Function GetCriteriaNewAdvanced() As String

        Dim strCriteria As String = ""
        Dim strCriteria2 As String = ""
        Dim strCriteria3 As String = ""

        strCriteria2 = GetFormatedCriteriaNewAdvanced2()
        strCriteria3 = GetFormatedCriteriaNewAdvanced3()
        If strCriteria2 = "" Then
            strCriteria = "(" + GetFormatedCriteriaNewAdvanced1() + ")"
        ElseIf strCriteria3 = "" Then
            intNo = 2
            strCriteria = "(" + GetFormatedCriteriaNewAdvanced1() + " OR " + GetFormatedCriteriaNewAdvanced2() + ")"
        Else
            intNo = 3
            strCriteria = "(" + GetFormatedCriteriaNewAdvanced1() + " OR " + GetFormatedCriteriaNewAdvanced2() + " OR " +
                          GetFormatedCriteriaNewAdvanced3() + ")"
        End If

        If Me.rbAnd.Checked = True Then
            If (mstrOptionAction = "Update" Or mstrOptionAction = "View") And Not Me.cbIncludeHistory.Checked Then
                strCriteria = strCriteria &
                              " AND MPRID IN (SELECT MPRID FROM vwSRDEE_Search WHERE InstrumentTypeID = " &
                              mintOptionInstTypeID & " AND " &
                              strCriteria & " GROUP BY MPRID HAVING Count(*) = " &
                              intNo & ") ORDER BY VariableID "
            ElseIf (mstrOptionAction = "Update" Or mstrOptionAction = "View") And Me.cbIncludeHistory.Checked Then
                strCriteria = strCriteria &
                              " AND MPRID IN (SELECT MPRID FROM vwSRDEE_Search_History WHERE InstrumentTypeID = " &
                              mintOptionInstTypeID & " AND " &
                              strCriteria & " GROUP BY MPRID HAVING Count(*) = " &
                              intNo & ") ORDER BY VariableID "
            End If
        Else
            strCriteria = strCriteria & " ORDER BY VariableID "
        End If

        If strCriteria = "() ORDER BY VariableID " Then
            strCriteria = strCriteria.Replace("() ORDER BY VariableID ", "")
        End If

        Return strCriteria
    End Function

    Private Function GetFormatedCriteriaNewAdvanced1() As String

        Dim strFormatedCriteria1 As String = ""

        If cboComparision1.Text.ToString = "is equal to" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] = '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is not equal to" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <> '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is less than" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] < '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is less than or equal to" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <= '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is greater than" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] > '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is greater than or equal to" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] >= '" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "is empty" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NULL OR [" & Me.lblValue.Text & "] = '' ))"
        ElseIf cboComparision1.Text.ToString = "is not empty" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar1.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NOT NULL OR [" & Me.lblValue.Text & "] <> '' ))"
        ElseIf cboComparision1.Text.ToString = "begins with" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar1.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '" + txtVal1.Text + "%'))"
        ElseIf cboComparision1.Text.ToString = "ends with" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar1.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal1.Text + "'))"
        ElseIf cboComparision1.Text.ToString = "contains" Then
            strFormatedCriteria1 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar1.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal1.Text + "%'))"
        End If

        Return strFormatedCriteria1
    End Function

    Private Function GetFormatedCriteriaNewAdvanced2() As String

        Dim strFormatedCriteria2 As String = ""

        If cboComparision2.Text.ToString = "is equal to" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] = '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is not equal to" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <> '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is less than" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] < '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is less than or equal to" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <= '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is greater than" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] > '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is greater than or equal to" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] >= '" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "is empty" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NULL OR [" & Me.lblValue.Text & "] = '' ))"
        ElseIf cboComparision2.Text.ToString = "is not empty" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar2.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NOT NULL OR [" & Me.lblValue.Text & "] <> '' ))"
        ElseIf cboComparision2.Text.ToString = "begins with" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar2.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '" + txtVal2.Text + "%'))"
        ElseIf cboComparision2.Text.ToString = "ends with" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar2.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal2.Text + "'))"
        ElseIf cboComparision2.Text.ToString = "contains" Then
            strFormatedCriteria2 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar2.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal2.Text + "%'))"
        End If

        Return strFormatedCriteria2
    End Function

    Private Function GetFormatedCriteriaNewAdvanced3() As String

        Dim strFormatedCriteria3 As String = ""

        If cboComparision3.Text.ToString = "is equal to" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] = '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is not equal to" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <> '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is less than" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] < '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is less than or equal to" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] <= '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is greater than" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] > '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is greater than or equal to" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] >= '" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "is empty" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NULL OR [" & Me.lblValue.Text & "] = '' ))"
        ElseIf cboComparision3.Text.ToString = "is not empty" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text &
                                   "] = '" + cboVar3.Text.ToString + "')" + " AND ([" & Me.lblValue.Text &
                                   "] IS NOT NULL OR [" & Me.lblValue.Text & "] <> '' ))"
        ElseIf cboComparision3.Text.ToString = "begins with" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar3.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '" + txtVal3.Text + "%'))"
        ElseIf cboComparision3.Text.ToString = "ends with" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar3.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal3.Text + "'))"
        ElseIf cboComparision3.Text.ToString = "contains" Then
            strFormatedCriteria3 = " (([" & Me.lblQuestionNumber.Text & "] = '" & cboVar3.Text.ToString &
                                   "')" + " AND ([" & Me.lblValue.Text & "] LIKE '%" + txtVal3.Text + "%'))"
        End If

        Return strFormatedCriteria3
    End Function

#End Region

#Region "Event Handlers"

    Public Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click

        Cursor = Cursors.WaitCursor
        Dim blnError As Boolean = False
        Dim intRecords As Integer
        Dim intMaxRecords As Integer = 10000

        strSQL = DataSource
        strWHERE = SearchCriteria

        If Me.cbIncludeHistory.Checked Then
            strSQL = strSQL.Replace("vwSRDEE_Search", "vwSRDEE_Search_History")
        End If

        If mstrOptionAction = "Compare" Then
            If strWHERE <> "" Then
                strSQL = strSQL & " WHERE " & strWHERE
            End If
        Else
            If strWHERE <> "" Then
                strSQL = strSQL & " AND " & strWHERE
            End If
        End If

        If ((tabSearch.SelectedTab Is tabPageBasic) And (strWHERE = "")) _
           Or ((tabSearch.SelectedTab Is tabPageQueryBuilder) And (strWHERE = "")) _
           Or ((tabSearch.SelectedTab Is tabPageAdvanced) And (Me.txtAdvancedSearch.Text.ToString.Equals(""))) Then

            Me.dgvSearchResults.Visible = False
            Me.cbGridUpdate.Visible = False
            Me.btnExcel.Visible = False
            RaiseEvent SearchError(sender, e, "You have not specified correct search criteria.")
            blnError = True
        Else

            If mstrOptionAction = "Update" Then
                Me.cbGridUpdate.Visible = True
            End If

            Try

                RaiseEvent BeginSearch(sender, e)

                intRecords = DoPreSearch()

                If intRecords <= intMaxRecords Then

                    DoSearch()

                    If dgvSearchResults.Rows.Count = 0 Then
                        Me.dgvSearchResults.Visible = False
                        Me.cbGridUpdate.Visible = False
                        Me.btnExcel.Visible = False
                        RaiseEvent SearchError(sender, e, "No records found with this search criteria.")
                        blnError = True
                    End If

                Else
                    Me.dgvSearchResults.Visible = False
                    Me.cbGridUpdate.Visible = False
                    Me.btnExcel.Visible = False
                    RaiseEvent _
                        SearchError(sender, e,
                                    "Your search would return " & Format(intRecords, "0,0").ToString & " results (> " &
                                    Format(intMaxRecords, "0,0").ToString & "). Please narrow your search criteria.")
                    blnError = True
                End If

            Catch ex As Exception
                Me.dgvSearchResults.Visible = False
                Me.cbGridUpdate.Visible = False
                Me.btnExcel.Visible = False
                RaiseEvent SearchError(sender, e, "You have entered an invalid expression.")
                blnError = True
            End Try

        End If

        dgvSearchResults.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        Cursor = Cursors.Default
        If Not blnError Then RaiseEvent EndSearch(sender, e)
    End Sub

    Private Sub dgvSearchResults_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvSearchResults.CellDoubleClick

        If e.RowIndex >= 0 AndAlso dgvSearchResults.SelectedRows.Count > 0 Then
            RaiseEvent _
                SearchResultDoubleClick(sender, e,
                                        CType(dgvSearchResults.SelectedRows(0).DataBoundItem, DataRowView).Row)
        End If
    End Sub

    Private Sub dgvSearchResults_Click(sender As Object, e As EventArgs) Handles dgvSearchResults.Click

        If dgvSearchResults.SelectedRows.Count > 0 Then
            RaiseEvent _
                SearchResultClick(sender, e, CType(dgvSearchResults.SelectedRows(0).DataBoundItem, DataRowView).Row)
        End If
    End Sub

    Private Sub dgvSearchCriteria_CellEnter(sender As Object, e As DataGridViewCellEventArgs) _
        Handles dgvSearchCriteria.CellEnter

        If dgvSearchCriteria.CurrentCell.EditType.ToString = "System.Windows.Forms.DataGridViewComboBoxEditingControl" _
            Then
            SendKeys.Send("{F4}")
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        RaiseEvent ClearButtonClick(sender, e)
        InitCriteria(mResultsDataSet.Tables(0))
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        RaiseEvent CloseButtonClick(sender, e)
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click

        If Me.dgvSearchResults.Visible = True Then
            RaiseEvent ExcelButtonClick(sender, e)
        End If
    End Sub

    Private Sub lnkCopyToAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lnkCopyToAdvanced.LinkClicked

        If Me.tabSearch.SelectedTab Is Me.tabPageBasic Then
            Me.txtAdvancedSearch.Text = GetCriteria(dgvSearchCriteria.Rows)
            Me.tabSearch.SelectedTab = Me.tabPageAdvanced
        Else
            Me.txtAdvancedSearch.Text = GetCriteriaNewAdvanced()
            If Me.txtAdvancedSearch.Text = "() ORDER BY VariableID " Then
                Me.txtAdvancedSearch.Text = ""
            End If
            Me.tabSearch.SelectedTab = Me.tabPageAdvanced
        End If
    End Sub

    Private Sub tabSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabSearch.SelectedIndexChanged

        If Me.tabSearch.SelectedTab Is Me.tabPageBasic Or
           Me.tabSearch.SelectedTab Is Me.tabPageQueryBuilder Then
            Me.lnkCopyToAdvanced.Visible = True

        Else
            Me.lnkCopyToAdvanced.Visible = False
        End If
    End Sub

    Private Sub cboVariableList_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboVariableList.SelectedIndexChanged
        Me.dgvSearchCriteria.Rows(0).Cells(2).Value = Me.cboVariableList.Text
    End Sub

    Private Sub cbIncludeHistory_CheckedChanged(sender As Object, e As EventArgs) _
        Handles cbIncludeHistory.CheckedChanged
        btnSearch.PerformClick()
    End Sub

#End Region
End Class
