'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmDocuments

#Region "Private Methods"

    Private Sub FillDocumentStatuses()

        cboDocStatus.Items.Clear()
        cboDocStatus.DisplayMember = "StatusDesc"
        cboDocStatus.ValueMember = "DocumentStatusID"

        For Each objStat As DocumentStatus In Project.DocumentStatuses
            cboDocStatus.Items.Add(objStat)
        Next
    End Sub

    Private Function GetSelectedDocument() As Document

        If grdView.SelectedRows.Count = 0 Then
            Return Nothing
        End If

        Return CType(grdView.SelectedRows(0).Tag, Document)
    End Function

    Private Sub SetSelectedDocument(objDocument As Document)

        If objDocument Is Nothing Then
            grdView.ClearSelection()
            Exit Sub
        End If

        For Each objRow As DataGridViewRow In grdView.Rows
            If objRow.Tag.Equals(objDocument) Then
                grdView.Rows(objRow.Index).Selected = True
            End If
        Next
    End Sub

    Private Function GetSelectedDocumentStatus() As DocumentStatus

        If cboDocStatus.SelectedIndex < 0 Then
            Return Nothing
        End If

        Return CType(cboDocStatus.SelectedItem, DocumentStatus)
    End Function

    Private Sub FillGrid(objDocumentStatus As DocumentStatus)

        grdView.Rows.Clear()

        If objDocumentStatus.DocumentStatusID = Data.Enumerations.DocumentStatus.Sent Then
            If _
                MessageBox.Show(
                    "You have selected to view 'Sent' documents. Your project could contain MANY sent documents, and this operation could take several minutes to load. Are you sure you want to view these?",
                    "View Sent Documents", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) = DialogResult.No Then
                Exit Sub
            End If
        End If

        Cursor = Cursors.WaitCursor

        Dim objDocuments As New Documents(objDocumentStatus)

        For Each objDoc As Document In objDocuments

            Dim strInstrument As String = ""
            If Not objDoc.Instrument Is Nothing Then
                strInstrument = objDoc.Instrument.InstrumentType.Description.ToString
            End If

            Dim strPerson As String = ""
            Dim strMPRID As String = ""
            If Not objDoc.PersonHistory Is Nothing Then
                strPerson = objDoc.PersonHistory.FullName
                strMPRID = objDoc.PersonHistory.MPRID.ToString
            End If

            Dim strAddress As String = ""
            If Not objDoc.AddressHistory Is Nothing Then
                strAddress = objDoc.AddressHistory.FullAddress
            End If

            Dim objRow As Object() = {GetSafeValue(objDoc.DocumentID),
                                      GetSafeValue(objDoc.DocumentType.Description),
                                      GetSafeValue(objDoc.DocumentStatus.StatusDesc),
                                      GetSafeDate(objDoc.LastModifiedOn),
                                      GetSafeValue(objDoc.InstrumentID),
                                      strInstrument,
                                      strMPRID,
                                      GetSafeValue(objDoc.PersonHistoryID),
                                      strPerson,
                                      GetSafeValue(objDoc.AddressHistoryID),
                                      strAddress,
                                      GetSafeValue(objDoc.DocumentNum),
                                      GetSafeValue(objDoc.Round)}


            grdView.Rows.Add(objRow)
            grdView.Rows(grdView.Rows.Count - 1).Tag = objDoc
        Next

        grdView.Columns("Type").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project.ShowRound
        grdView.Columns("Address").DefaultCellStyle.WrapMode = DataGridViewTriState.True

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        lblCount.Text = "Count = " & CStr(grdView.Rows.Count)

        Cursor = Cursors.Default
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmDocuments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FillDocumentStatuses()
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Document Queue"
        btnChange.Enabled = False
    End Sub

    Private Sub cboDocStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDocStatus.SelectedIndexChanged

        Dim objDocStat As DocumentStatus = GetSelectedDocumentStatus()
        If objDocStat IsNot Nothing Then
            FillGrid(objDocStat)

            If GetSafeValue(objDocStat.DocumentStatusID) = Data.Enumerations.DocumentStatus.Queued Then
                btnChange.Enabled = True
                btnChange.Text = "Hold / Cancel"
            ElseIf GetSafeValue(objDocStat.DocumentStatusID) = Data.Enumerations.DocumentStatus.Held Then
                btnChange.Enabled = True
                btnChange.Text = "Return to Queue"
            Else
                btnChange.Enabled = False
            End If

        End If
    End Sub

    Private Sub grdView_SortCompare(sender As Object, e As DataGridViewSortCompareEventArgs) Handles grdView.SortCompare

        e.SortResult = String.Compare(e.CellValue1.ToString(), e.CellValue2.ToString())
        If e.Column.Name = "StatusDate" Then
            e.SortResult = DateTime.Compare(CType(e.CellValue1, DateTime), CType(e.CellValue2, DateTime))
        End If
        'do a secondary sort on MPRID
        If e.SortResult = 0 And e.Column.Name <> "MPRID" Then
            e.SortResult = String.Compare(grdView.Rows(e.RowIndex1).Cells("MPRID").Value.ToString(),
                                          grdView.Rows(e.RowIndex2).Cells("MPRID").Value.ToString())
        End If
        e.Handled = True
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub

    Private Sub btnChange_Click(sender As Object, e As EventArgs) Handles btnChange.Click

        Dim objDoc As Document = GetSelectedDocument()

        If objDoc IsNot Nothing Then
            If GetSafeValue(objDoc.DocumentStatusID) = Data.Enumerations.DocumentStatus.Queued Then
                objDoc.DocumentStatusID = Data.Enumerations.DocumentStatus.Held
                objDoc.Update()
            ElseIf GetSafeValue(objDoc.DocumentStatusID) = Data.Enumerations.DocumentStatus.Held Then
                objDoc.DocumentStatusID = Data.Enumerations.DocumentStatus.Queued
                objDoc.Update()
            End If
            grdView.Rows.Remove(grdView.SelectedRows(0))
            lblCount.Text = "Count = " & CStr(grdView.Rows.Count)
        End If
    End Sub

#End Region
End Class