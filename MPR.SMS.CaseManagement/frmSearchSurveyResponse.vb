'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing

Public Class frmSearchSurveyResponse

#Region "Private Fields"

    Private mblnReadOnly As Boolean = False
    Private ReadOnly mstrSearchOption As String
    Private mstrCaseLockedBy As String = String.Empty
    Private ReadOnly mintInstrumentTypeID As Integer = 0
    Private ReadOnly mstrSearchAction As String
    Private ReadOnly mstrSearchViewName As String

#End Region

#Region "Constructors"

    Public Sub New(strOption As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnReadOnly = False
        mstrSearchOption = strOption
        SearchSurveyResponse1.OptionString = mstrSearchOption
        Me.CenterToScreen()
        Me.SearchSurveyResponse1.CheckBoxIncludeHistory = False
    End Sub

    Public Sub New(intInstTypeID As Integer, strDesc As String, strAction As String, strView As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnReadOnly = False

        mintInstrumentTypeID = intInstTypeID
        mstrSearchOption = strDesc
        mstrSearchAction = strAction
        mstrSearchViewName = strView

        SearchSurveyResponse1.OptionInteger = mintInstrumentTypeID
        SearchSurveyResponse1.OptionString = mstrSearchOption
        SearchSurveyResponse1.OptionActionString = mstrSearchAction
        SearchSurveyResponse1.OptionViewNameString = mstrSearchViewName

        Me.CenterToScreen()
        Me.SearchSurveyResponse1.CheckBoxIncludeHistory = False
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmSearchSurveyResponse_Load(sender As Object, e As EventArgs) Handles Me.Load

        tsslStatus.Text = "Initializing, please wait..."
        UserLabel.Text = WindowsIdentity.GetCurrent.Name
        tsslStatus.Text = ""


        If mintInstrumentTypeID > 0 And mstrSearchAction = "Update" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption
            SearchSurveyResponse1.DataSource = "SELECT Top 10000 * FROM vwSRDEE_Search WHERE InstrumentTypeID = " &
                                               mintInstrumentTypeID
            Me.SearchSurveyResponse1.CheckBoxIncludeHistory = True
        ElseIf mintInstrumentTypeID > 0 And mstrSearchAction = "View" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
            SearchSurveyResponse1.DataSource = "SELECT Top 10000 * FROM vwSRDEE_Search WHERE InstrumentTypeID = " &
                                               mintInstrumentTypeID
            Me.SearchSurveyResponse1.CheckBoxIncludeHistory = True
        ElseIf mintInstrumentTypeID = 0 And mstrSearchAction = "Compare" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Previous Survey Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
            SearchSurveyResponse1.DataSource = "SELECT Top 10000 * FROM " & mstrSearchViewName
        End If

        SearchSurveyResponse1.Initialize()
        SearchSurveyResponse1.DataGridVisible = False
        SearchSurveyResponse1.ExcelButtonVisible = False
        SearchSurveyResponse1.OptionString = mstrSearchOption
    End Sub

    Private Sub SearchSurveyResponse1_ClearButtonClick(sender As Object, e As EventArgs) _
        Handles SearchSurveyResponse1.ClearButtonClick

        SearchSurveyResponse1.DataGridVisible = False
        SearchSurveyResponse1.ExcelButtonVisible = False
        tsslStatus.Text = ""
        tsslError.Text = ""
        TotalRecordsLabel.Text = ""

        If mintInstrumentTypeID > 0 And mstrSearchAction = "Update" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption
        ElseIf mintInstrumentTypeID > 0 And mstrSearchAction = "View" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
        ElseIf mintInstrumentTypeID = 0 And mstrSearchAction = "Compare" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Previous Survey Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
        End If
    End Sub

    Private Sub SearchControl1_SearchResultDoubleClick(sender As Object, e As EventArgs, DataRow As DataRow) _
        Handles SearchSurveyResponse1.SearchResultDoubleClick

        If mstrSearchAction = "View" Or mstrSearchAction = "Compare" Then
            MessageBox.Show("This option is unavailable for editing because it is READ ONLY option.",
                            Project.ShortName & " - READ ONLY", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf mstrSearchAction = "Update" AndAlso IsSRDEELock(mintInstrumentTypeID) = True Then
            MessageBox.Show(
                "Since the Machine Edit process is in progress, Survey response data is unavailable now for editing.",
                Project.ShortName & " - READ ONLY", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        ElseIf mstrSearchAction = "Update" AndAlso Me.SearchSurveyResponse1.IsCheckBoxIncludeHistory Then
            MessageBox.Show(
                "Since you selected include updated variable history box, Survey response data is unavailable now for editing.",
                Project.ShortName & " - READ ONLY", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If


        Try
            Dim strMPRID As String = String.Empty
            Dim strQuestionNum As String = String.Empty
            Dim strValue As String = String.Empty
            Dim strNotes As String = String.Empty
            Dim strDescription As String = String.Empty
            Dim strVariable As String = String.Empty
            Dim strVariableID As String = String.Empty
            Dim strMode As String = String.Empty
            Dim strCreatedBy As String = String.Empty
            Dim dtCreatedOn As String = String.Empty
            Dim strLastModifiedBy As String = String.Empty
            Dim dtLastModifiedOn As String = String.Empty
            Dim strValueAllowed As String = String.Empty
            Dim strMessage As String = String.Empty

            strMPRID = DataRow.Item("MPRID").ToString
            If DataRow.Item("QuestionNumber").ToString Is DBNull.Value Then
                strQuestionNum = ""
            Else
                strQuestionNum = DataRow.Item("QuestionNumber").ToString
            End If
            If DataRow.Item("Value").ToString Is DBNull.Value Then
                strValue = ""
            Else
                strValue = DataRow.Item("Value").ToString
            End If
            If DataRow.Item("Notes").ToString Is DBNull.Value Then
                strNotes = ""
            Else
                strNotes = DataRow.Item("Notes").ToString
            End If
            If DataRow.Item("Description").ToString Is DBNull.Value Then
                strDescription = ""
            Else
                strDescription = DataRow.Item("Description").ToString
            End If
            If DataRow.Item("Variable").ToString Is DBNull.Value Then
                strVariable = ""
            Else
                strVariable = DataRow.Item("Variable").ToString
            End If
            If DataRow.Item("VariableID").ToString Is DBNull.Value Then
                strVariableID = ""
            Else
                strVariableID = DataRow.Item("VariableID").ToString
            End If
            If DataRow.Item("Mode").ToString Is DBNull.Value Then
                strMode = ""
            Else
                strMode = DataRow.Item("Mode").ToString
            End If
            If DataRow.Item("CreatedBy").ToString Is DBNull.Value Then
                strCreatedBy = ""
            Else
                strCreatedBy = DataRow.Item("CreatedBy").ToString
            End If
            If DataRow.Item("CreatedOn").ToString Is DBNull.Value Then
                dtCreatedOn = ""
            Else
                dtCreatedOn = DataRow.Item("CreatedOn").ToString
            End If
            If DataRow.Item("LastModifiedBy").ToString Is DBNull.Value Then
                strLastModifiedBy = ""
            Else
                strLastModifiedBy = DataRow.Item("LastModifiedBy").ToString
            End If

            If DataRow.Item("LastModifiedOn").ToString Is DBNull.Value Then
                dtLastModifiedOn = ""
            Else
                dtLastModifiedOn = DataRow.Item("LastModifiedOn").ToString
            End If
            'Dim intRnd As Integer = CInt(DataRow.Item("Round").ToString)
            Dim intResponseID As Integer = CInt(DataRow.Item("PreResponseID"))

            Dim IsSupervisor As Boolean = GetSRDEESupervisor(UserLabel.Text)

            If IsSupervisor Then
                If DataRow.Item("AllowedValueForSAS").ToString Is DBNull.Value Then
                    strValueAllowed = ""
                Else
                    strValueAllowed = DataRow.Item("AllowedValueForSAS").ToString
                End If
            Else
                If DataRow.Item("AllowedValue").ToString Is DBNull.Value Then
                    strValueAllowed = ""
                Else
                    strValueAllowed = DataRow.Item("AllowedValue").ToString
                End If
            End If

            If DataRow.Item("Message").ToString Is DBNull.Value Then
                strMessage = ""
            Else
                strMessage = DataRow.Item("Message").ToString
            End If


            mblnReadOnly = GetSRDEERecordLock(strMPRID, Me.mintInstrumentTypeID)

            If mblnReadOnly Then
                MessageBox.Show(
                    "This case is unavailable for editing because it is locked by " & Me.mstrCaseLockedBy & ".",
                    Project.ShortName & " - Case Locked in Survey Response!", MessageBoxButtons.OK,
                    MessageBoxIcon.Information)
                Exit Sub
            ElseIf Me.SearchSurveyResponse1.IsGridUpdate Then
                Dim frm As New frmSurveyResponseByMPRID(strMPRID, mstrSearchOption, mintInstrumentTypeID, mblnReadOnly)
                frm.ShowDialog()
            Else

                Dim _
                    frm As _
                        New frmSurveyResponse(strMPRID, strQuestionNum, strValue, strNotes, strVariable, strMode,
                                              strVariableID, strDescription,
                                              strCreatedBy, dtCreatedOn, strLastModifiedBy, dtLastModifiedOn,
                                              intResponseID, strValueAllowed,
                                              mstrSearchOption, mintInstrumentTypeID, "By Variable", UserLabel.Text,
                                              strMessage)
                frm.ShowDialog()
                SearchSurveyResponse1.DoSearch()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error getting data..", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SearchControl1_BeginSearch(sender As Object, e As EventArgs) Handles SearchSurveyResponse1.BeginSearch

        If Me.SearchSurveyResponse1.IsCheckBoxIncludeHistory Then
            Me.Text = "SMS - [" & Project.ShortName.ToString &
                      "] - Search for Survey Preliminary Response Data History - " & mstrSearchOption & " [READ ONLY]"
        ElseIf mintInstrumentTypeID > 0 And mstrSearchAction = "Update" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption
        ElseIf mintInstrumentTypeID > 0 And mstrSearchAction = "View" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Survey Preliminary Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
        ElseIf mintInstrumentTypeID = 0 And mstrSearchAction = "Compare" Then
            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Previous Survey Response Data - " &
                      mstrSearchOption & " [READ ONLY]"
        End If

        tsslStatus.Text = "Searching, please wait..."
        SearchSurveyResponse1.DataGridVisible = True

        tsslStatus.Visible = True
        tsslError.Visible = False
        TotalRecordsLabel.Text = ""
    End Sub

    Private Sub SearchSurveyResponse1_EndSearch(sender As Object, e As EventArgs) _
        Handles SearchSurveyResponse1.EndSearch

        tsslError.Visible = False
        tsslStatus.Visible = True
        If SearchSurveyResponse1.ResultSetCount > 0 Then
            SearchSurveyResponse1.ExcelButtonVisible = True
            If mstrSearchAction = "Update" Then
                tsslStatus.Text = "Double-click on row to Update Survey Preliminary Response Data"
            Else
                tsslStatus.Text = ""
            End If
        Else
            tsslStatus.Text = ""
            SearchSurveyResponse1.ExcelButtonVisible = False
        End If
        TotalRecordsLabel.Text = SearchSurveyResponse1.ResultSetCount & " Records"
    End Sub

    Private Sub SearchSurveyResponse1_SearchError(sender As Object, e As EventArgs, ErrorMsg As String) _
        Handles SearchSurveyResponse1.SearchError

        tsslStatus.Visible = False
        tsslError.Visible = True
        TotalRecordsLabel.Text = ""
        tsslError.Text = ErrorMsg
    End Sub

    Private Sub SearchSurveyResponse1_CloseButtonClick(sender As Object, e As EventArgs) _
        Handles SearchSurveyResponse1.CloseButtonClick

        Me.Close()
    End Sub

    Private Sub SearchSurveyResponse1_ExcelButtonClick(sender As Object, e As EventArgs) _
        Handles SearchSurveyResponse1.ExcelButtonClick

        Cursor = Cursors.WaitCursor
        tsslStatus.Text = "Creating excel file, please wait..."

        Utility.DataTableToExcel(Me.SearchSurveyResponse1.DataTable, Nothing)

        tsslStatus.Text = ""

        Cursor = Cursors.Default
    End Sub

    Private Function GetSRDEERecordLock(strMPRID As String, intInstTypeID As Integer) As Boolean
        Dim blnFlag As Boolean = False
        Dim sqldr As SqlDataReader = Nothing
        Try
            sqldr = SqlHelper.ExecuteReader(Project.GetInstance.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SRDEE_LockRecord_Select",
                                            New SqlParameter("@MPRID", strMPRID),
                                            New SqlParameter("@InstrumentTypeID", intInstTypeID))

            If sqldr.HasRows = True Then
                While sqldr.Read
                    mstrCaseLockedBy = sqldr("LockedBy").ToString
                    If Not mstrCaseLockedBy = "" Then
                        Exit While
                    End If
                End While
                blnFlag = True
            Else
                blnFlag = False
            End If

            If Not sqldr Is Nothing Then
                sqldr.Close()
            End If
            Return blnFlag
        Catch ex As Exception
            If Not sqldr Is Nothing Then
                sqldr.Close()
            End If
            Return True   ' do not allow user to edit, show as locked - in case of any error
        End Try
    End Function


#End Region
End Class