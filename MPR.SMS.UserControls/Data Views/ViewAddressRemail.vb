'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class ViewAddressRemail

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjAddress As Address
    Private mobjDocumentType As DocumentType
    Private mobjDocument As Document

    Private mblnObjectWasAdded As Boolean = False

    Const ToLocStatus As String = "1503"

#End Region

#Region "Public Properties"

    <Browsable(False)>
    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedDocumentType As DocumentType
        Get
            Return mobjDocumentType
        End Get
        Set
            mobjDocumentType = value
        End Set
    End Property

    Public Property SelectedDocument As Document
        Get
            Return mobjDocument
        End Get
        Set
            mobjDocument = value
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedPerson As Person
        Get
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
            If SelectedCase Is Nothing AndAlso
               mobjPerson IsNot Nothing Then
                SelectedCase = mobjPerson.Case
            End If
            If mobjPerson IsNot Nothing Then
                If mobjPerson.BestPhysicalAddress IsNot Nothing Then
                    SelectedAddress = mobjPerson.BestPhysicalAddress
                ElseIf mobjPerson.BestMailingAddress IsNot Nothing Then
                    SelectedAddress = mobjPerson.BestMailingAddress
                Else
                    SelectedAddress = mobjPerson.BestCheckAddress
                End If
            Else
                SelectedAddress = Nothing
            End If
            If Not Me.DesignMode Then FillGrid(mobjPerson)
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedAddress As Address
        Get
            If mobjAddress Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)
            ElseIf grdView.Rows.Count.Equals(0) Then
                mobjAddress = Nothing
            End If
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
            If mobjAddress Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjAddress) Then
                        grdView.Rows(objRow.Index).Selected = True
                        Exit For
                    End If
                Next
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objAddress As Address = mobjAddress

        FillGrid(mobjPerson)
        SelectedAddress = objAddress

        If _
            (mobjDocumentType.InstrumentTypeId.IsNull Or mobjDocumentType.InstrumentTypeId = 0) Or
            mobjDocumentType.IsSendToLocating = False Then
            btnLocate.Enabled = False
            btnLocate.Visible = False
            btnClose.Enabled = True
            btnClose.Visible = True
            grpAddress.Text = "Please Select an Address for a Remail"
        Else
            btnLocate.Enabled = True
            btnLocate.Visible = True
            btnClose.Enabled = False
            btnClose.Visible = False
            grpAddress.Text = "Please Select an Address for a Remail or Send to Locating"
        End If
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objAddress As Address)
    Public Shadows Event OnDoubleClick(sender As Object, objAddress As Address)
    Public Shadows Event OnChanged(sender As Object, objAddress As Address)
    Public Event Close(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"


    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjPerson IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)

            RaiseEvent OnClick(Me, SelectedAddress)

        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjPerson IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjAddress = CType(grdView.SelectedRows(0).Tag, Address)

            RaiseEvent OnDoubleClick(Me, SelectedAddress)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedAddress.AddressID.IsNull Then
                    ctxMenu.Show(grdView, e.X, e.Y)
                End If
            End If
        End If
    End Sub

    Private Sub mnuViewAddressHistory_Click(sender As Object, e As EventArgs) Handles mnuViewAddressHistory.Click

        Dim frm As New frmDisplayHistory(SelectedAddress)
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y)
        End If
        frm.Show()
    End Sub

    Private Sub mnuViewBestMailingAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestMailingAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestMailingAddressHistory WHERE MPRID = " &
                               SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Mailing Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 12 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 12)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub mnuViewBestPhysicalAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestPhysicalAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestPhysicalAddressHistory WHERE MPRID = " &
                               SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Physical Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 24 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 24)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub mnuViewBestCheckAddressHistory_Click(sender As Object, e As EventArgs) _
        Handles mnuViewBestCheckAddressHistory.Click

        Dim strSQL As String = "SELECT * FROM vwBestCheckAddressHistory WHERE MPRID = " & SelectedPerson.MPRID.ToString
        Dim frm As New frmDisplayDataView(strSQL, "Best Check Address Selection History")
        frm.Width = grdView.Width
        If Cursor.Position.Y + frm.Height - 36 > Screen.GetWorkingArea(Me).Height Then
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X,
                                     Cursor.Position.Y - 12 - frm.Height)
        Else
            frm.Location = New Point(grdView.Parent.PointToScreen(grdView.Parent.Location).X, Cursor.Position.Y - 36)
        End If
        frm.Columns(0).Visible = False
        frm.Columns(1).Visible = False
        frm.SortedColumn = frm.Columns(2)
        frm.SortDirection = ListSortDirection.Descending
        frm.Show()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = mobjPerson
        Dim objAddress As Address = SelectedAddress

        'BT: 12/08/2014 Added for Address Notes.
        Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))
        Dim intNoteTypeID As Int16 = 1 'Note Type As Address

        objNote.Case = mobjAddress.Case
        objNote.Person = mobjAddress.Person
        objNote.Address = mobjAddress
        'BT: 12/08/2014 Added for Address Notes.

        Dim frm As New frmAddressEdit(mobjCase, objPerson, objAddress, objNote, intNoteTypeID) _
        'BT: 12/08/2014 Added for Address Notes.
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjPerson)
            SelectedAddress = objAddress
            RaiseEvent OnChanged(Me, objAddress)
        End If
    End Sub

    Private Sub BestCheckAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestCheckAddressToolStripMenuItem.Click

        mobjPerson.BestCheckAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub BestMailingAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestMailingAddressToolStripMenuItem.Click

        mobjPerson.BestMailingAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub BestPhysicalAddressToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles BestPhysicalAddressToolStripMenuItem.Click

        mobjPerson.BestPhysicalAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

    Private Sub MarkAsBestForAllToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles MarkAsBestForAllToolStripMenuItem.Click

        mobjPerson.BestCheckAddress = mobjAddress
        mobjPerson.BestMailingAddress = mobjAddress
        mobjPerson.BestPhysicalAddress = mobjAddress
        Refresh()
        RaiseEvent OnChanged(Me, mobjAddress)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillGrid(objPerson As Person)

        If Project Is Nothing Then Exit Sub

        grdView.Rows.Clear()
        Dim objPrevAddress As Address = SelectedAddress

        If Not objPerson Is Nothing Then
            For Each objAddress As Address In objPerson.Addresses

                Dim blnOK As Boolean = (Not GetSafeValue(objAddress.SourceQuality.Description).Equals("Duplicate"))

                If blnOK Then
                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              imgImages.Images("empty.ico"),
                                              imgImages.Images("empty.ico"),
                                              GetSafeValue(objAddress.AddressID),
                                              GetSafeValue(objAddress.SourceQuality.Rank),
                                              imgQuality.Images("Quality-Unknown.bmp"),
                                              imgImages.Images("empty.ico"),
                                              objAddress.FullStreetAddress,
                                              GetSafeValue(objAddress.City),
                                              GetSafeValue(objAddress.State),
                                              GetSafeZip(objAddress.PostalCode),
                                              GetSafeValue(objAddress.AddressType.Description),
                                              GetSafeDate(objAddress.CreatedOn),
                                              GetSafeValue(objAddress.Round)}

                    If _
                        Not mobjPerson.BestPhysicalAddress Is Nothing AndAlso
                        mobjPerson.BestPhysicalAddress.Equals(objAddress) Then
                        objRow(0) = imgImages.Images("Best PhysicalAddress.bmp")
                    End If
                    If _
                        Not mobjPerson.BestMailingAddress Is Nothing AndAlso
                        mobjPerson.BestMailingAddress.Equals(objAddress) Then
                        objRow(1) = imgImages.Images("Best MailingAddress.bmp")
                    End If
                    If Not mobjPerson.BestCheckAddress Is Nothing AndAlso mobjPerson.BestCheckAddress.Equals(objAddress) _
                        Then
                        objRow(2) = imgImages.Images("Best CheckAddress.bmp")
                    End If
                    If GetSafeValue(objAddress.SourceQualityID) = 1 Then
                        objRow(5) = imgQuality.Images("Quality-Bad.bmp")
                    ElseIf GetSafeValue(objAddress.SourceQualityID) = 2 Then
                        objRow(5) = imgQuality.Images("Quality-Good.bmp")
                    ElseIf GetSafeValue(objAddress.SourceQualityID) = 3 Then
                        objRow(5) = imgQuality.Images("Quality-Duplicate.bmp")
                    End If
                    If GetSafeValue(objAddress.IsCleaned) Then
                        objRow(6) = imgImages.Images("SuccessComplete.bmp")
                    End If
                    If GetSafeValue(objAddress.AddressID).Equals(0) Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objAddress
                End If
            Next
            SelectedAddress = objPrevAddress
            RaiseEvent OnClick(Me, SelectedAddress)
        End If
        grdView.Columns("Address").DefaultCellStyle.BackColor = Color.LightYellow
        grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        grdView.Sort(grdView.Columns("Rank"), ListSortDirection.Ascending)

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()


        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region


    Private Sub btnRemail_Click(sender As Object, e As EventArgs) Handles btnRemail.Click
        Dim objdocument As New Document(mobjCase, mobjDocumentType)
        With objdocument
            .PersonHistory = SelectedPerson.PersonHistory
            .AddressHistory = SelectedAddress.AddressHistory
            .DocumentType = mobjDocumentType
            .DocumentStatusID = 1
            .Case = mobjCase
            .InstrumentID = mobjDocument.InstrumentID
        End With

        mobjCase.Documents.Add(objdocument)
        mobjCase.Update()

        RaiseEvent Close(sender, e)
    End Sub

    Private Sub btnLocate_Click(sender As Object, e As EventArgs) Handles btnLocate.Click

        If mobjDocumentType.IsSendToLocating = True Then
            If Not mobjDocumentType.InstrumentTypeId.IsNull AndAlso mobjDocumentType.InstrumentTypeId <> 0 Then
                Dim j As Integer
                For j = 0 To mobjCase.Instruments.Count - 1
                    If _
                        mobjCase.Instruments(j).CurrentRespondentMPRID = SelectedPerson.MPRID And
                        mobjCase.Instruments(j).InstrumentTypeID = mobjDocumentType.InstrumentTypeId Then
                        If _
                            mobjCase.Instruments(j).StatusUpdateRuleResult(mobjCase.Instruments(j).CurrentStatus,
                                                                           ToLocStatus) =
                            Instrument.StatusUpdateResult.Override Then
                            mobjCase.Instruments(j).LogicalStatus = ToLocStatus
                            mobjCase.Instruments(j).CurrentStatus = ToLocStatus
                            Dim objlocatingstatus As New LocatingStatus(mobjCase.Instruments(j).CurrentRespondent)
                            objlocatingstatus.LocatingStatus = ToLocStatus
                            objlocatingstatus.StatusDate = Now
                            objlocatingstatus.DateSentToLocating = Now
                            mobjCase.Instruments(j).CurrentRespondent.LocatingStatus = objlocatingstatus
                            mobjCase.Update()
                        ElseIf _
                            mobjCase.Instruments(j).StatusUpdateRuleResult(mobjCase.Instruments(j).CurrentStatus,
                                                                           ToLocStatus) =
                            Instrument.StatusUpdateResult.Error Then
                            MsgBox(
                                "The status was unable to be updated due to Status Update Rules.  Please contact your SMS programmer to resolve.",
                                MsgBoxStyle.Information, "Status Cannot Be Updated")
                        End If
                    End If
                Next
            Else
                Dim intperson As Integer
                For intperson = 0 To mobjCase.Persons.Count - 1
                    If mobjCase.Persons(intperson).MPRID = mobjPerson.MPRID Then
                        If _
                            mobjCase.Persons(intperson).LocatingStatus.StatusUpdateRuleResult(
                                mobjCase.Persons(intperson).LocatingStatus.Status.Code, ToLocStatus) =
                            Instrument.StatusUpdateResult.Override Then
                            Dim objlocatingstatus As New LocatingStatus(mobjCase.Persons(intperson))
                            objlocatingstatus.LocatingStatus = ToLocStatus
                            objlocatingstatus.StatusDate = Now
                            objlocatingstatus.DateSentToLocating = Now
                            mobjCase.Persons(intperson).LocatingStatus = objlocatingstatus
                            mobjCase.Update()
                        ElseIf _
                            mobjCase.Persons(intperson).LocatingStatus.StatusUpdateRuleResult(
                                mobjCase.Persons(intperson).LocatingStatus.Status.Code, ToLocStatus) =
                            Instrument.StatusUpdateResult.Error Then
                            MsgBox(
                                "The status was unable to be updated due to Status Update Rules.  Please contact your SMS programmer to resolve.",
                                MsgBoxStyle.Information, "Status Cannot Be Updated")
                        End If
                    End If
                Next intperson
            End If
        Else
            MsgBox("This document is not allowed to be sent to locating.", MsgBoxStyle.OkOnly,
                   "Not Allowed to go to Locating")
        End If

        RaiseEvent Close(sender, e)
    End Sub

    Private Sub btnShowAddressNotes_Click(sender As Object, e As EventArgs) Handles btnShowAddressNotes.Click
        'Dim frmDisplayNotes As New frmDisplayNotes(Me.SelectedAddress)
        'frmDisplayNotes.ShowDialog(Me)

        Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))

        objNote.Case = mobjAddress.Case
        objNote.Person = mobjAddress.Person
        objNote.Address = mobjAddress

        Dim frm As New frmNote(mobjCase, objNote, 1)
        frm.ShowDialog()
    End Sub

    Protected Overridable Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        RaiseEvent Close(sender, e)
    End Sub
End Class
