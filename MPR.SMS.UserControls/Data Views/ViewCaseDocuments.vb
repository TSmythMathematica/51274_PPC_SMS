'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Document records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseDocuments provides a reusable ListView/Grid control for
'''     browsing a case's Documents. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseDocuments

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjDocument As Document

    Private mblnAllowAdd As Boolean = True
    Private mblnAllowEdit As Boolean = True
    Private mblnAllowDelete As Boolean = False
    Private mblnAllowPreview As Boolean = False
    Private ReadOnly mblnAllowAddDocs As Boolean = False

    Private mblnObjectWasAdded As Boolean = False

#End Region

#Region "Public Properties"

    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            If Not Me.DesignMode Then FillGrid(mobjCase)
        End Set
    End Property

    Public Property SelectedDocument As Document
        Get
            If mobjDocument Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjDocument = CType(grdView.SelectedRows(0).Tag, Document)
            End If
            Return mobjDocument
        End Get
        Set
            mobjDocument = value
            If mobjDocument Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjDocument) Then
                        grdView.Rows(objRow.Index).Selected = True
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

    <DefaultValue(True)> <Category("Behavior")>
    Public Property AllowAdd As Boolean
        Get
            Return mblnAllowAdd
        End Get
        Set
            mblnAllowAdd = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(True)> <Category("Behavior")>
    Public Property AllowEdit As Boolean
        Get
            Return mblnAllowEdit
        End Get
        Set
            mblnAllowEdit = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Public Property AllowDelete As Boolean
        Get
            Return mblnAllowDelete
        End Get
        Set
            mblnAllowDelete = value
            SetButtons()
        End Set
    End Property

    <DefaultValue(False)> <Category("Behavior")>
    Public Property AllowPreview As Boolean
        Get
            Return mblnAllowPreview
        End Get
        Set
            mblnAllowPreview = value
            SetButtons()
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objDocument As Document = mobjDocument

        FillGrid(mobjCase)
        SelectedDocument = objDocument
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objDocument As Document)
    Public Shadows Event OnDoubleClick(sender As Object, objDocument As Document)
    Public Shadows Event OnChanged(sender As Object, objDocument As Document)

#End Region

#Region "Event Handlers"

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjDocument = CType(grdView.SelectedRows(0).Tag, Document)

            RaiseEvent OnClick(Me, SelectedDocument)
            SetButtons()
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjDocument = CType(grdView.SelectedRows(0).Tag, Document)

            RaiseEvent OnDoubleClick(Me, SelectedDocument)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedDocument.DocumentID.IsNull Then
                    Dim frm As New frmDisplayHistory(SelectedDocument)
                    frm.Width = grdView.Width
                    If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                        frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                                 Cursor.Position.Y - 12 - frm.Height)
                    Else
                        frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                                 Cursor.Position.Y + 12)
                    End If
                    frm.Show()
                End If
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        'do not allow adding of documents if there are unsaved Addresses or 
        'Persons, because they don't have History records until they're saved.
        Dim sMsg As String = ""
        If mobjCase.Persons.Count = 0 Then
            sMsg = "There must be at least one case member in this Case before you can add documents."
        End If
        If sMsg = "" Then
            For Each objPerson As Person In mobjCase.Persons
                If objPerson.MPRID.ToString.Equals("") Then
                    sMsg = "You must save the changes to this Case before you can add documents."
                    Exit For
                End If
            Next
        End If
        If sMsg = "" Then
            For Each objAddress As Address In mobjCase.Addresses
                If objAddress.AddressID.IsNull Then
                    sMsg = "You must save the changes to this Case before you can add documents."
                    Exit For
                End If
            Next
        End If
        If sMsg <> "" Then
            MessageBox.Show(sMsg, Project.ShortName & " – Add document", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)
            Return
        End If

        Dim objDocument As New Document(GetSafeValue(mobjCase.CaseID))

        Dim frm As New frmDocumentAdd(mobjCase, objDocument)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjCase)
            SelectedDocument = objDocument
            RaiseEvent OnChanged(Me, objDocument)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        'To-do: create frmDocument
        'Dim objDocument As Document = Me.SelectedDocument

        'Dim frm As New frmDocument(mobjCase, objDocument)
        'frm.ShowDialog()

        'If frm.DialogResult = DialogResult.OK Then
        '    FillGrid(mobjCase)
        '    SelectedDocument = objDocument
        '    RaiseEvent OnChanged(Me, objDocument)
        'End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelDocument As Document = Me.SelectedDocument

        mobjCase.Documents.Remove(objSelDocument)
        RaiseEvent OnChanged(Me, objSelDocument)
        FillGrid(mobjCase)
        SelectedDocument = Nothing
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Dim objSelDocument As Document = Me.SelectedDocument
        Dim strFileName As String = GetSafeValue(objSelDocument.DocumentType.SampleFilePathName)

        If strFileName.Equals("") Then
            btnPreview.Enabled = False
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            Process.Start(strFileName)
        Catch ex As Exception
            Dim strMessage As String = "An error was encountered trying to open " + strFileName + ":" + vbCrLf + vbCrLf &
                                       ex.Message
            If Not strMessage.EndsWith(".") Then
                strMessage = strMessage + "."
            End If
            MessageBox.Show(strMessage, Project.ShortName + " - File Preview", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("DocumentID").Visible

        blnShow = Not blnShow
        grdView.Columns("DocumentID").Visible = blnShow
        grdView.Columns("InstrumentID").Visible = blnShow
        grdView.Columns("Instrument").Visible = blnShow
        grdView.Columns("PersonHistoryID").Visible = blnShow
        grdView.Columns("AddressHistoryID").Visible = blnShow
        If blnShow Then
            btnShowID.ImageKey = "hide.bmp"
        Else
            btnShowID.ImageKey = "show.bmp"
        End If
        grdView.Focus()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objCase As [Case])

        grdView.Rows.Clear()

        If Not objCase Is Nothing Then
            For Each objDoc As Document In objCase.Documents

                Dim strInstrument As String = ""
                If Not objDoc.Instrument Is Nothing Then
                    strInstrument = objDoc.Instrument.InstrumentType.Description.ToString
                End If

                Dim strPerson As String = ""
                If Not objDoc.PersonHistory Is Nothing Then
                    strPerson = objDoc.PersonHistory.FullName
                End If

                Dim strAddress As String = ""
                If Not objDoc.AddressHistory Is Nothing Then
                    strAddress = objDoc.AddressHistory.FullAddress
                End If

                Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                          GetSafeValue(objDoc.DocumentID),
                                          GetSafeValue(objDoc.DocumentType.Description),
                                          GetSafeValue(objDoc.DocumentStatus.StatusDesc),
                                          GetSafeDate(objDoc.LastModifiedOn),
                                          GetSafeValue(objDoc.InstrumentID),
                                          strInstrument,
                                          GetSafeValue(objDoc.PersonHistoryID),
                                          strPerson,
                                          GetSafeValue(objDoc.AddressHistoryID),
                                          strAddress,
                                          GetSafeValue(objDoc.DocumentNum),
                                          GetSafeValue(objDoc.Round)}


                grdView.Rows.Add(objRow)
                grdView.Rows(grdView.Rows.Count - 1).Tag = objDoc
            Next
            RaiseEvent OnClick(Me, SelectedDocument)
        End If
        grdView.Columns("Type").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Address").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd
        btnEdit.Enabled = mblnAllowEdit And (SelectedDocument IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()

        Dim objDoc As Document = SelectedDocument()
        If Not objDoc Is Nothing Then
            btnPreview.Enabled = mblnAllowPreview And (GetSafeValue(objDoc.DocumentType.SampleFilePathName) <> "")
        Else
            btnPreview.Enabled = False
        End If

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean =
                (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete) And Not (mblnAllowPreview))
        If blnReadOnly Then
            grdView.Height = grpMembers.Height - 24
        Else
            grdView.Height = grpMembers.Height - btnAdd.Height - 30
        End If

        btnAdd.Visible = mblnAllowAdd And mblnAllowAddDocs   'Not blnReadOnly
        btnEdit.Visible = mblnAllowEdit _
        'Not blnReadOnly '<-- hide Edit button until we have the need for editing documents
        btnDelete.Visible = mblnAllowDelete 'And Not blnReadOnly 
        btnPreview.Visible = mblnAllowPreview    'Not blnReadOnly
    End Sub

    Private Function EnableDeleteButton() As Boolean

        If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
            'allow deleting of newly added (queued) records
            If SelectedDocument IsNot Nothing AndAlso GetSafeValue(SelectedDocument.DocumentStatusID).Equals(1) Then _
'Queued
                Return mblnAllowDelete
            Else 'otherwise, only supervisors can delete existing records
                Return mblnAllowDelete And CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
            End If
        Else
            Return False
        End If
    End Function

    Private Function DocsCanBeAdded() As Boolean

        Dim blnFound As Boolean = False

        If Project IsNot Nothing Then
            For Each objDocType As DocumentType In Project.DocumentTypes
                If GetSafeValue(objDocType.AllowOnTheFlyAdd) = True Then
                    blnFound = True
                    Exit For
                End If
            Next
        End If
        Return blnFound
    End Function

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mblnAllowAddDocs = DocsCanBeAdded
        SetButtons()
    End Sub

#End Region
End Class