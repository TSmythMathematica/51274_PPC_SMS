'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Security.Principal
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing

Public Class frmMPRIDSearch

#Region "Private Fields"

    Private ReadOnly mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnReadOnly = False
    End Sub

    Public Sub New(blnReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnReadOnly = blnReadOnly
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmMPRIDSearchV2_Load(sender As Object, e As EventArgs) Handles Me.Load

        tsslStatus.Text = "Initializing, please wait..."
        UserLabel.Text = WindowsIdentity.GetCurrent.Name
        tsslStatus.Text = ""
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Search for Case"
        If mblnReadOnly Then Me.Text = Me.Text & " {Read-only mode}"

        SearchFunction1.DataSource = "SELECT * FROM vwSearch"
        SearchFunction1.Initialize()
        SearchFunction1.DataGridVisible = False
    End Sub

    Private Sub SearchControl1_SearchResultDoubleClick(sender As Object, e As EventArgs, DataRow As DataRow) _
        Handles SearchFunction1.SearchResultDoubleClick

        Dim intCaseID As Integer = CType(DataRow("CaseID"), Integer)
        Dim objCase As New [Case](intCaseID, False)

        Dim strMPRID As String = CType(DataRow("MPRID"), String)
        Dim objPerson As New Person(strMPRID)

        Dim frmDisplayCase As New frmDisplayCase(objCase, objPerson, mblnReadOnly)
        frmDisplayCase.Show()
    End Sub

    Private Sub SearchControl1_BeginSearch(sender As Object, e As EventArgs) Handles SearchFunction1.BeginSearch

        tsslStatus.Text = "Searching, please wait..."
        SearchFunction1.DataGridVisible = True
    End Sub

    Private Sub SearchFunction1_EndSearch(sender As Object, e As EventArgs) Handles SearchFunction1.EndSearch

        tsslError.Visible = False
        tsslStatus.Visible = True
        If SearchFunction1.ResultSetCount > 0 Then
            tsslStatus.Text = ""
        Else
            tsslStatus.Text = ""
        End If
        TotalRecordsLabel.Text = "" 'SearchFunction1.ResultSetCount & " Records"
    End Sub

    Private Sub SearchFunction1_SearchError(sender As Object, e As EventArgs, ErrorMsg As String) _
        Handles SearchFunction1.SearchError

        tsslStatus.Visible = False
        tsslError.Visible = True
        tsslError.Text = ErrorMsg
        'MessageBox.Show(ErrorMsg, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
        TotalRecordsLabel.Text = SearchFunction1.ResultSetCount & " Records"
    End Sub

    Private Sub SearchFunction1_CloseButtonClick(sender As Object, e As EventArgs) _
        Handles SearchFunction1.CloseButtonClick

        Me.Close()
    End Sub

    Private Sub SearchFunction1_ClearButtonClick(sender As Object, e As EventArgs) _
        Handles SearchFunction1.ClearButtonClick
        SearchFunction1.DataGridVisible = False
        tsslStatus.Text = ""
        TotalRecordsLabel.Text = ""
    End Sub



#End Region
End Class