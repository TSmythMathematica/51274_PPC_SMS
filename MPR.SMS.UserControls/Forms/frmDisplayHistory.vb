'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Threading
Imports MPR.SMS.Data


Public Class frmDisplayHistory

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(obj As Object)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Dim strObjType As String = obj.GetType.Name
        Me.Text = strObjType & " History"

        Dim strDataSource As String = ""
        Select Case strObjType
            Case "Case"
                strDataSource = "SELECT * FROM tblCaseHistory WHERE CaseID = '" & CType(obj, [Case]).CaseID.Value & "'"
            Case "Person"
                strDataSource = "SELECT * FROM tblPersonHistory WHERE MPRID = '" & CType(obj, Person).MPRID.ToString &
                                "'"
            Case "Address"
                strDataSource = "SELECT * FROM tblAddressHistory WHERE AddressID = '" &
                                CType(obj, Address).AddressID.Value & "'"
            Case "Phone"
                strDataSource = "SELECT * FROM tblPhoneHistory WHERE PhoneID = '" & CType(obj, Phone).PhoneID.Value &
                                "'"
            Case "Email"
                strDataSource = "SELECT * FROM tblEmailHistory WHERE EmailID = '" & CType(obj, Email).EmailID.Value &
                                "'"
            Case "Note"
                'strDataSource = "SELECT * FROM tblNoteHistory WHERE NoteID = '" & CType(obj, Note).NoteID.Value & "'"
            Case "Instrument"
                strDataSource = "SELECT * FROM tblInstrumentHistory WHERE InstrumentID = '" &
                                CType(obj, Instrument).InstrumentID.Value & "'"
            Case "Document"
                strDataSource = "SELECT * FROM tblDocumentHistory WHERE DocumentID = '" &
                                CType(obj, Document).DocumentID.Value & "'"
            Case "CaseRA"
                strDataSource = "SELECT * FROM tblCaseRAHistory WHERE CaseID = '" & CType(obj, CaseRA).CaseID.Value &
                                "'"
            Case "Student"
                strDataSource = "SELECT * FROM tblStudentHistory WHERE MPRID = '" & CType(obj, Student).MPRID.ToString &
                                "'"
            Case "Teacher"
                strDataSource = "SELECT * FROM tblTeacherHistory WHERE CaseID = '" & CType(obj, Teacher).CaseID.Value &
                                "'"
            Case "Classroom"
                strDataSource = "SELECT * FROM tblClassroomHistory WHERE CaseID = '" &
                                CType(obj, Classroom).CaseID.Value & "'"
            Case "School"
                strDataSource = "SELECT * FROM tblSchoolHistory WHERE CaseID = '" & CType(obj, School).CaseID.Value &
                                "'"
            Case "District"
                strDataSource = "SELECT * FROM tblDistrictHistory WHERE CaseID = '" & CType(obj, District).CaseID.Value &
                                "'"
            Case "LocatingAttempt"
                strDataSource = "SELECT * FROM tblLocatingAttemptHistory WHERE LocatingAttemptID = '" &
                                CType(obj, LocatingAttempt).LocatingAttemptID.Value & "'"
            Case "LocatingStatus"
                strDataSource = "SELECT * FROM tblLocatingStatusHistory WHERE MPRID = '" &
                                CType(obj, LocatingStatus).MPRID.Value & "'"
            Case "SocialNetwork"
                strDataSource = "SELECT * FROM tblSocialNetworkHistory WHERE SocialNetworkID = '" &
                                CType(obj, SocialNetwork).SocialNetworkID.Value & "'"
            Case Else
                Return
        End Select
        InitializeDataGridView(strDataSource)
    End Sub
    'use this constructor for special case tables that might not use an object, 
    'such as InstrumentStatusHistory, or other views
    Public Sub New(strObjType As String, intID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = strObjType & " History"

        Dim strDataSource As String = ""
        Select Case strObjType
            Case "Instrument Status Update Rule"
                strDataSource = "SELECT * FROM vwInstrumentStatusHistory WHERE InstrumentID = " & intID

            Case Else
                Return
        End Select
        InitializeDataGridView(strDataSource)
    End Sub

    'BT: 09/17/2014 Added for SRDEE functionality.
    Public Sub New(strObjType As String, intPreResponseID As Integer, strSurType As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - " & strObjType & " History - " & strSurType

        Me.MinimumSize = New Size(666, 200)

        Dim strDataSource As String = ""
        Select Case strObjType

            Case "Survey Preliminary Response Data"
                strDataSource = "SELECT * FROM vwSRDEE_History WHERE PreResponseID = " & intPreResponseID &
                                " ORDER BY PreResponseHistoryID DESC"
            Case Else
                Return

        End Select
        InitializeDataGridView(strDataSource)
    End Sub
    'BT: 09/17/2014 Added for SRDEE functionality.

#End Region

#Region "Event Handlers"

    Private Sub grdView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) _
        Handles grdView.CellFormatting
        If grdView.Columns(e.ColumnIndex).DataPropertyName = "CreatedOn" Or
           grdView.Columns(e.ColumnIndex).DataPropertyName = "LastModifiedOn" Then
            e.CellStyle.Format = "g"
        End If
    End Sub

    'Private Sub frmDisplayHistory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    '    If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Escape) Then
    '        Me.Close()
    '    End If

    'End Sub

    'Private Sub frmDisplayHistory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus

    '    Me.Close()

    'End Sub
    Private Sub grdView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdView.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub grdView_LostFocus(sender As Object, e As EventArgs) Handles grdView.LostFocus

        Me.Close()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitializeDataGridView(strSQL As String)
        Try
            ' Set up the DataGridView.
            With grdView
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True

                ' Set up the data source.
                .DataSource = GetDataTable(strSQL)

                ' Automatically resize the visible rows.
                '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedHeaders
                .RowTemplate.Height = 18
                '.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                .RowHeadersWidth = 22

                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D

                Dim col As DataGridViewColumn = .Columns(0)
                .Sort(col, ListSortDirection.Descending)

                .ReadOnly = True
                grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

            End With
        Catch ex As SqlException
            MessageBox.Show(ex.Message,
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Thread.CurrentThread.Abort()
        End Try
    End Sub

#End Region
End Class