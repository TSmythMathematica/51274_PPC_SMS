'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.SMS.Security

''' <summary>
'''     Represents a view of all Person records within a case.
''' </summary>
''' <remarks>
'''     ViewCaseMembers provides a reusable ListView/Grid control for
'''     browsing a case's members. When working with the MPR solution, it is
'''     automatically integrated with Visual Studio .NET allowing drag and
'''     drop design from the Toolbox.
''' </remarks>
Public Class ViewCaseMembers

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person

    Private mblnAllowAdd As Boolean = True
    Private mblnAllowEdit As Boolean = True
    Private mblnAllowDelete As Boolean = False
    Private mblnShowContacts As Boolean = True
    Private mblnShowMembers As Boolean = True
    Private mintFilterByRelationshipTypeID As Integer = - 1

    Private mblnObjectWasAdded As Boolean = False

#End Region

#Region "Public Properties"

    <Browsable(False)>
    Public Property SelectedCase As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            SelectedPerson = Nothing
            If mobjCase IsNot Nothing Then
                FillGrid(mobjCase)
            End If
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedPerson As Person
        Get
            If mobjPerson Is Nothing AndAlso grdView.SelectedRows.Count > 0 Then
                mobjPerson = CType(grdView.SelectedRows(0).Tag, Person)
            End If
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
            If mobjPerson Is Nothing Then
                grdView.ClearSelection()
            Else
                For Each objRow As DataGridViewRow In grdView.Rows
                    If objRow.Tag.Equals(mobjPerson) OrElse
                       (Not mobjPerson.MPRID.IsNull AndAlso
                        objRow.Cells("MPRID").FormattedValue.ToString.Equals(mobjPerson.MPRID.ToString)) Then
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

    <DefaultValue(True)> <Category("Behavior")>
    Public Property ShowMembers As Boolean
        Get
            Return mblnShowMembers
        End Get
        Set
            mblnShowMembers = value
            SetGrid()
        End Set
    End Property

    <DefaultValue(True)> <Category("Behavior")>
    Public Property ShowContacts As Boolean
        Get
            Return mblnShowContacts
        End Get
        Set
            mblnShowContacts = value
            SetGrid()
        End Set
    End Property

    'optional Relationship Type filter. -1 = no filter.
    <DefaultValue(- 1)> _
    <Category("Appearance")>
    Public Property FilterByRelationshipTypeID As Integer
        Get
            Return mintFilterByRelationshipTypeID
        End Get
        Set
            mintFilterByRelationshipTypeID = value
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()

        Dim objPerson As Person = mobjPerson

        FillGrid(mobjCase)
        SelectedPerson = objPerson
        MyBase.Refresh()
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnClick(sender As Object, objPerson As Person)
    Public Shadows Event OnDoubleClick(sender As Object, objPerson As Person)
    Public Shadows Event OnChanged(sender As Object, objPerson As Person)
    Public Shadows Event OnAdd(sender As Object, objPerson As Person)

#End Region

#Region "Event Handlers"


    Private Sub grpMembers_Resize(sender As Object, e As EventArgs) Handles grpMembers.Resize

        grpShow.Left = grpMembers.Width - 200
    End Sub

    Private Sub chkShowmembers_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowMembers.CheckedChanged

        ShowMembers = chkShowMembers.Checked
    End Sub

    Private Sub chkShowContacts_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowContacts.CheckedChanged

        ShowContacts = chkShowContacts.Checked
    End Sub

    Private Sub grdView_SelectionChanged(sender As Object, e As EventArgs) Handles grdView.SelectionChanged

        If mobjCase IsNot Nothing AndAlso grdView.SelectedRows.Count > 0 Then
            mobjPerson = CType(grdView.SelectedRows(0).Tag, Person)

            If mobjPerson IsNot Nothing Then
                RaiseEvent OnClick(Me, SelectedPerson)
                btnEdit.Enabled = mblnAllowEdit
                btnDelete.Enabled = EnableDeleteButton()
            End If
        End If
    End Sub

    Private Sub grdView_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) _
        Handles grdView.CellDoubleClick

        If mobjCase IsNot Nothing AndAlso e.RowIndex >= 0 Then
            mobjPerson = CType(grdView.SelectedRows(0).Tag, Person)

            RaiseEvent OnDoubleClick(Me, SelectedPerson)
            If btnEdit.Enabled Then btnEdit.PerformClick()
        End If
    End Sub

    Private Sub grdView_MouseClick(sender As Object, e As MouseEventArgs) Handles grdView.MouseClick

        If e.Button = MouseButtons.Right Then
            If grdView.HitTest(e.X, e.Y).RowIndex >= 0 Then
                grdView.Rows(grdView.HitTest(e.X, e.Y).RowIndex).Selected = True

                If Not SelectedPerson.MPRID.IsNull Then
                    Dim frm As New frmDisplayHistory(SelectedPerson)
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

        'TO-DO: allow adding of multiple Persons even if the case hasn't 
        ' been saved yet. The reason you need to save is so that MPRID #'s 
        ' are assinged to any addresses/phones/emails. We can't have multiple 
        ' sets of addresses/phones/emails without a MPRID, otherwise we wouldn't
        ' know which person they belong to.
        If mblnObjectWasAdded Then
            MessageBox.Show("You cannot add another Case Member until you save the changes already made to the case.",
                            Project.ShortName & " – Add person", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim objPerson As New Person(GetSafeValue(mobjCase.CaseID))
        Dim objAddress As New Address(GetSafeValue(mobjCase.CaseID))
        Dim objPhone As New Phone(GetSafeValue(mobjCase.CaseID))

        'BT: 12/08/2014 Added for Address Notes.
        Dim objNote As New Note(GetSafeValue(mobjCase.CaseID))
        Dim intNoteTypeID As Int16 = 1 'Note Type As Address

        objNote.Case = mobjCase
        objNote.Person = objPerson
        objNote.Address = objAddress
        'BT: 12/08/2014 Added for Address Notes.

        objPerson.Case = mobjCase

        objAddress.Person = objPerson
        objPhone.Person = objPerson

        Dim frm As New frmPersonAdd(mobjCase, objPerson, objAddress, objPhone, objNote, intNoteTypeID) _
        'BT: 12/08/2014 Added for Address Notes.
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjCase)
            SelectedPerson = objPerson
            RaiseEvent OnChanged(Me, objPerson)
            RaiseEvent OnAdd(Me, objPerson)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Dim objPerson As Person = CType(grdView.SelectedRows(0).Tag, Person)

        Dim frm As New frmPersonEdit(mobjCase, objPerson)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            FillGrid(mobjCase)
            SelectedPerson = objPerson
            RaiseEvent OnChanged(Me, objPerson)
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Dim objSelPerson As Person = SelectedPerson

        mobjCase.Persons.Remove(objSelPerson)
        RaiseEvent OnChanged(Me, objSelPerson)
        FillGrid(mobjCase)
        SelectedPerson = Nothing

        If GetSafeValue(objSelPerson.MPRID).Equals(0) Then mblnObjectWasAdded = False
    End Sub

    Private Sub btnShowID_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowID.MouseDown

        Dim blnShow As Boolean = grdView.Columns("MPRID").Visible

        blnShow = Not blnShow
        grdView.Columns("MPRID").Visible = blnShow
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

        Dim objPerson As Person

        grdView.Rows.Clear()
        mblnObjectWasAdded = False

        If Not objCase Is Nothing Then
            For Each objPerson In objCase.Persons
                Dim blnOK As Boolean = (CBool(mintFilterByRelationshipTypeID = - 1) OrElse
                                        CBool(mintFilterByRelationshipTypeID = objPerson.RelationshipTypeID))
                blnOK = blnOK AndAlso
                        ((ShowMembers And GetSafeValue(objPerson.RelationshipType.IsContact) = False) OrElse
                         (ShowContacts And GetSafeValue(objPerson.RelationshipType.IsContact) = True))

                If blnOK Then

                    Dim objRow As Object() = {imgImages.Images("empty.ico"),
                                              GetSafeValue(objPerson.MPRID),
                                              GetSafeValue(objPerson.RelationshipType.RelationshipType),
                                              objPerson.FullName,
                                              GetSafeSSN(objPerson.SSN),
                                              GetSafeDate(objPerson.DateOfBirth),
                                              imgCheckbox.Images("checkbox-unchecked.bmp"),
                                              GetSafeValue(objPerson.ConsentType.Description),
                                              GetSafeValue(objPerson.LanguageType.Description),
                                              GetSafeValue(objPerson.LexID),
                                              GetSafeValue(objPerson.Round)}

                    If GetSafeValue(objPerson.RelationshipType.IsPrimarySampleMember) Then
                        objRow(0) = imgImages.Images("Best SampleMember.bmp")
                    End If
                    If GetSafeValue(objPerson.InSample) Then
                        objRow(6) = imgCheckbox.Images("checkbox-checked.bmp")
                    End If
                    If GetSafeValue(objPerson.MPRID).Equals("") Then
                        mblnObjectWasAdded = True
                    End If
                    grdView.Rows.Add(objRow)
                    grdView.Rows(grdView.Rows.Count - 1).Tag = objPerson
                End If
            Next
            RaiseEvent OnClick(Me, SelectedPerson)

            grdView.Columns("PersonName").DefaultCellStyle.BackColor = Color.LightYellow
            grdView.Columns("Round").Visible = Project IsNot Nothing AndAlso Project.ShowRound
        End If

        grdView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        SetButtons()
    End Sub

    Private Sub SetButtons()

        btnAdd.Enabled = mblnAllowAdd
        btnEdit.Enabled = mblnAllowEdit And (SelectedPerson IsNot Nothing)
        btnDelete.Enabled = EnableDeleteButton()

        'if no buttons are allowed, then expand the grid to cover the buttons
        Dim blnReadOnly As Boolean = (Not (mblnAllowAdd) And Not (mblnAllowEdit) And Not (mblnAllowDelete))
        If blnReadOnly Then
            grdView.Height = grpMembers.Height - 24
        Else
            grdView.Height = grpMembers.Height - btnAdd.Height - 30
        End If

        btnAdd.Visible = Not blnReadOnly
        btnEdit.Visible = Not blnReadOnly
        btnDelete.Visible = Not blnReadOnly And mblnAllowDelete
    End Sub

    Private Function EnableDeleteButton() As Boolean

        If (grdView.Rows.Count > 0) AndAlso (grdView.SelectedRows.Count > 0) Then
            'allow deleting of newly added records
            If SelectedPerson IsNot Nothing AndAlso GetSafeValue(SelectedPerson.MPRID).Equals(0) Then
                Return mblnAllowDelete
            Else 'otherwise, only supervisors can delete existing records
                Return mblnAllowDelete And CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)
            End If
        Else
            Return False
        End If
    End Function

    Private Sub SetGrid()

        If mblnShowMembers And mblnShowContacts Then
            grpMembers.Text = "Case members/contacts"
            imgIcon.Left = 129
        ElseIf mblnShowMembers Then
            imgIcon.Left = 83
            grpMembers.Text = "Case members"
        ElseIf mblnShowContacts Then
            imgIcon.Left = 83
            grpMembers.Text = "Case contacts"
        Else
            imgIcon.Left = 86
            grpMembers.Text = "<no selections>"
        End If
        chkShowMembers.Checked = mblnShowMembers
        chkShowContacts.Checked = mblnShowContacts

        If mobjCase IsNot Nothing Then
            FillGrid(mobjCase)
        End If
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetButtons()
    End Sub

#End Region
End Class
