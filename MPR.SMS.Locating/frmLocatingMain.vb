'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Windows.Forms
Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls

Public Class frmLocatingMain

#Region "Private Variables"

    Private ReadOnly mobjCase As [Case]
    Private ReadOnly mobjPerson As Person
    Private ReadOnly MPRID As String
    Private mblnEditable As Boolean = False
    Private mobjCurrentTab As TabPage
    Private ReadOnly mblnLocSup As Boolean = False

    Private mblnNewSession As Boolean = True

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objCase As [Case], strMPRID As String)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        MPRID = strMPRID
        mobjPerson = mobjCase.Persons(mobjCase.Persons.IndexOf(strMPRID))
        mobjCurrentTab = tabCase.TabPages(0)

        mblnLocSup = CurrentUser.IsInRole(Security.Enumerations.Role.ProjectAdministrator)

        'automatically lock case if user is a supervisor or if the app.config setting is set.
        'otherwise wait until a locating attempt is made before locking the case.
        If mblnLocSup Or Project.LockLocatingCases Then
            LockCase()
        End If

        DisplayCase(mobjCase)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayCase(objCase As [Case])

        Dim objPerson As Person = objCase.Persons(objCase.Persons.IndexOf(MPRID))

        txtEntityName.Text = GetSafeValue(objCase.EntityName)

        ViewCaseMembers.SelectedCase = objCase
        ViewCaseMembers.ShowContacts = True
        ViewCaseNotes.GroupByName = True

        'EditPerson.Person = objPerson
        With objPerson
            lblMPRID.Text = .MPRID.ToString
            lblName.Text = .FullName
            lblRelType.Text = .RelationshipType.RelationshipType.ToString
            Select Case GetSafeValue(.GenderID)
                Case 1
                    lblGender.Text = "Male"
                Case 2
                    lblGender.Text = "Female"
                Case Else
                    lblGender.Text = ""
            End Select
            lblDOB.Text = GetSafeDate(.DateOfBirth)
            If Not .DateOfBirth.IsNull Then
                lblAge.Text = .Age.ToString
            Else
                lblAge.Text = ""
            End If
            lblSSN.Text = GetSafeSSN(.SSN)
            lblLanguage.Text = .LanguageType.Description.ToString
            If .LanguageType.Description.ToString = "Other" Then
                lblLanguage.Text = lblLanguage.Text & " - " & .LanguageOther.ToString
            End If
            lblStatus.Text = .LocatingStatus.LocatingStatus.ToString & " - " &
                             .LocatingStatus.Status.Description.ToString

            'show original address/phone/email
            lblOrigAddr.Text = ""
            If .OriginalAddress IsNot Nothing Then
                lblOrigAddr.Text = .OriginalAddress.FullStreetAddress & ", " & .OriginalAddress.City.ToString & ", " &
                                   .OriginalAddress.State.ToString & " " & .OriginalAddress.PostalCode.ToString
            End If
            lblOrigPhone.Text = ""
            If .OriginalPhone IsNot Nothing Then
                lblOrigPhone.Text = GetSafePhone(.OriginalPhone.PhoneNum)
            End If
            lblOrigEmail.Text = ""
            If .OriginalEmail IsNot Nothing Then
                lblOrigEmail.Text = .OriginalEmail.EmailAddress.ToString
            End If
            lblUsername.Text = GetSafeValue(.WebUsername)
            lblWebPW.Text = GetSafeValue(.WebPassword)
        End With

        ViewCaseLocatingAttempts.SelectedCase = objCase
        ViewCaseInstruments.SelectedCase = objCase
        ViewCaseDocuments.SelectedCase = objCase
        ViewCaseNotes.SelectedCase = objCase
        ViewConfirmitCallHist.SelectedCase = objCase

        ViewCaseLocatingAttempts.SelectedPerson = objPerson

        'fill in the Locating Status control
        EditLocatingStatusSupervisor.LocatingStatus = objPerson.LocatingStatus

        tsslCaseID.Text = "CaseID: " & objCase.CaseID.ToString
        If objCase.IsReadOnly Then
            tsslLocked.Image = imgImages.Images("lock-unavailable.bmp")
            tsslLocked.ToolTipText =
                "This case is unavailable for editing because it is locked by someone else, or you only have read-only access."
        Else
            tsslLocked.Image = imgImages.Images("lock-owned.bmp")
            tsslLocked.ToolTipText = "This case is locked by you and avaible for editing."
        End If
        mblnEditable = Not objCase.IsReadOnly And
                       CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSLocating)
        tsslEntity.Text = GetSafeValue(objCase.EntityType.Description)
        tsbLock.Visible = False 'Not mblnEditable
        'tsbSave.Visible = mblnEditable
        tsbNew.Enabled = CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSLocating)

        'fill in the form title and status bar fields
        Me.Text = "SMS - [ " & Project.ShortName & "] - Locate Person - MPRID: " & MPRID

        tsbSave.Enabled = False

        '== enable/disable Add/Edit/Delete functions
        txtEntityName.ReadOnly = Not mblnEditable

        'EditPerson.ReadOnly = Not mblnEditable

        ViewCaseLocatingAttempts.AllowAdd = False   'mblnEditable
        ViewCaseLocatingAttempts.AllowEdit = False
        ViewCaseLocatingAttempts.AllowDelete = False   'Authorization.IsSupervisor 'not allowed at this time

        'we won't allow add/edit/delete Instrument records at this time.
        ViewCaseInstruments.AllowAdd = False    'mblnEditable
        ViewCaseInstruments.AllowEdit = False    'mblnEditable
        ViewCaseInstruments.AllowDelete = False    'Authorization.IsSupervisor

        ViewCaseDocuments.AllowAdd = False
        ViewCaseDocuments.AllowEdit = False    'mblnEditable
        ViewCaseDocuments.AllowDelete = False   'Authorization.IsSupervisor 'not allowed at this time 
        ViewCaseDocuments.AllowPreview = True

        'hide "Supervisor" tab from non-supervisors
        If Not tabCase.TabPages("tabCaseSup") Is Nothing Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabCaseSup"))
        End If
        If mblnLocSup Then tabCase.TabPages.Add(tabCaseSup)
        EditLocatingStatusSupervisor.ReadOnly = Not mblnEditable

        'set the Locating Priority Status
        tsbPriority.Enabled = mblnLocSup And mblnEditable
        If GetSafeValue(objPerson.LocatingStatus.PriorityStatus) = 1 Then
            tsbPriority.Image = tsmHighPriority.Image
        Else
            tsbPriority.Image = tsmLowPriority.Image
        End If
        tsmHighPriority.Checked = GetSafeValue(objPerson.LocatingStatus.PriorityStatus) = 1
        tsmLowPriority.Checked = GetSafeValue(objPerson.LocatingStatus.PriorityStatus) <> 1

        tabCase.SelectedTab = mobjCurrentTab
    End Sub

    Private Sub LockCase()

        If GetSafeValue(mobjCase.CaseID) <> 0 Then

            'try to lock case
            Try
                mobjCase.Lock()

                If mobjCase.IsReadOnly Then
                    MessageBox.Show(
                        "This case you have selected is read-only because it is currently being updated by another user. If you think the case is locked in error, contact your supervisor to release it.",
                        Project.ShortName & " – Case is locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " – Case is locked", MessageBoxButtons.OK,
                                MessageBoxIcon.Hand)
            End Try
        End If
    End Sub

    'Returns: Yes    = save changes and continue with chosen action (i.e. exit, search, etc)
    '         No     = don't save changes and continue with chosen action
    '         Cancel = don't save changes and don't continue with chosen action

    Private Function ConfirmSave() As DialogResult

        If mobjCase Is Nothing Then Return DialogResult.No
        If mobjCase.IsReadOnly Then Return DialogResult.No

        If mobjCase.IsModified Then
            Dim dr As DialogResult = MessageBox.Show("Do you want to save the changes you have made to this case?",
                                                     Project.ShortName & " – Save changes?",
                                                     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button1)
            If dr = DialogResult.Yes Then
                If Not SaveCase() Then
                    Return DialogResult.Cancel
                End If
            End If
            Return dr
        Else
            Return DialogResult.No
        End If
    End Function

    Private Function SaveCase() As Boolean

        'verify that there's at least one person record
        If mobjCase.Persons.Count = 0 Then
            MessageBox.Show("You must have at least one member in order to save a Case.", "Save error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

        'if Person is taken out of locating, then reset the Priority to Low.
        If Not mobjPerson.LocatingStatus.Status.IsCaseInLocating AndAlso
           Not mobjPerson.LocatingStatus.Status.IsCaseInLocatingSupervisor Then
            mobjPerson.LocatingStatus.PriorityStatus = 0
        End If

        'add the time spent on the new attempts into the running total.
        'don't re-calculate the running total each time, because a supervisor
        'may have adjusted it.
        For Each objAttempt As LocatingAttempt In mobjPerson.LocatingAttempts
            If objAttempt.LocatingAttemptID.IsNull Then
                mobjPerson.LocatingStatus.TotalTimeSpentInSeconds =
                    GetSafeValue(mobjPerson.LocatingStatus.TotalTimeSpentInSeconds) + objAttempt.TimeSpentInSeconds
            End If
        Next

        'increment the # of time touched, i.e. the number of sessions.
        If mblnNewSession Then
            mobjPerson.LocatingStatus.NoOfTimesTouched = GetSafeValue(mobjPerson.LocatingStatus.NoOfTimesTouched) + 1
        End If
        mblnNewSession = False

        'now save (insert or update) the entire Case object
        Try
            If GetSafeValue(mobjCase.CaseID) = 0 Then
                mobjCase.Insert()
                LockCase()
            Else
                mobjCase.Update()
            End If
            tsbSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error saving this case", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            Return False
        End Try
        Return True
    End Function

#End Region

#Region "Event Handlers"

    Private Sub tabCaseSup_MouseDown(sender As Object, e As MouseEventArgs) Handles tabCaseSup.MouseDown

        'LocatingStatus History
        If e.Button = MouseButtons.Right Then
            EditLocatingStatusSupervisor.ShowHistory()
        End If
    End Sub

    Private Sub EditLocatingStatus_OnChanged(sender As Object, objLocatingStatus As LocatingStatus) _
        Handles EditLocatingStatusSupervisor.OnChanged

        mobjPerson.LocatingStatus = objLocatingStatus
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    'Private Sub EditPerson_OnChanged(ByVal sender As Object, ByVal objPerson As Data.Person) handles edit

    '    'mobjCase.Persons(mobjCase.Persons.IndexOf(MPRID)) = objPerson
    '    tsbSave.Enabled = mobjCase.IsModified

    'End Sub

    Private Sub ViewCaseLocatingAttempts_OnChanged(sender As Object, objLocatingAttempt As LocatingAttempt) _
        Handles ViewCaseLocatingAttempts.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseLocatingAttempts.Refresh()
    End Sub

    Private Sub ViewCaseInstruments_OnChanged(sender As Object, objInstrument As Instrument) _
        Handles ViewCaseInstruments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseInstruments.Refresh()
    End Sub

    Private Sub ViewCaseDocuments_OnChanged(sender As Object, objDocument As Document) _
        Handles ViewCaseDocuments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseDocuments.Refresh()
    End Sub

    Private Sub ViewCaseMembers_OnClick(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnClick

        ViewCaseAddresses.SelectedCase = mobjCase
        ViewCasePhones.SelectedCase = mobjCase
        ViewCaseEmails.SelectedCase = mobjCase
        ViewCaseSocialNetworks.SelectedCase = mobjCase

        ViewCaseAddresses.SelectedPerson = objPerson
        ViewCasePhones.SelectedPerson = objPerson
        ViewCaseEmails.SelectedPerson = objPerson
        ViewCaseSocialNetworks.SelectedPerson = objPerson
    End Sub

    Private Sub txtEntityName_TextChanged(sender As Object, e As EventArgs) Handles txtEntityName.TextChanged

        mobjCase.EntityName = txtEntityName.Text
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub tsbNew_Click(sender As Object, e As EventArgs) Handles tsbNew.Click

        If mobjCase.IsReadOnly Then
            LockCase()
            DisplayCase(mobjCase)
        End If

        If Not mobjCase.IsReadOnly Then
            tsbNew.ShowDropDown()
        End If
    End Sub

    Private Sub tsbNew_DropDownItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) _
        Handles tsbNew.DropDownItemClicked

        If Not mobjCase.IsReadOnly Then
            Dim objLocatingAttemptType As LocatingAttemptType = CType(e.ClickedItem.Tag, LocatingAttemptType)

            Dim objPerson As Person = ViewCaseMembers.SelectedPerson

            Dim frm As Form
            If objLocatingAttemptType.ShowChangeRespondent Then
                frm = New frmLocatingAttemptNewRespondent(mobjCase, mobjPerson, objLocatingAttemptType)
            ElseIf objLocatingAttemptType.ShowAddDocument Then
                frm = New frmLocatingAttemptNewDocument(mobjCase, mobjPerson, objLocatingAttemptType)
            ElseIf objLocatingAttemptType.ShowCaseMembers Then
                frm = New frmLocatingAttemptCaseMembers(mobjCase, mobjPerson, objLocatingAttemptType)
            Else
                If ViewCaseMembers.SelectedPerson Is Nothing Then _
'user must select a person from the members tab before starting an attempt. If only one case member is available, then select it for them.
                    If mobjCase.Persons.Count = 1 Then
                        ViewCaseMembers.SelectedPerson = mobjCase.Persons(0)
                        objPerson = mobjCase.Persons(0)
                    Else ' they must select one
                        MessageBox.Show(
                            "Please click on the Members tab to select a case member for whom this attempt is for.",
                            "Select a case member first", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If
                End If
                frm = New frmLocatingAttempt(mobjPerson, objLocatingAttemptType, objPerson)
            End If
            frm.ShowDialog()

            If frm.DialogResult = DialogResult.OK Then
                'tsbSave.Enabled = mobjCase.IsModified
                'ViewCaseLocatingAttempts.Refresh()
                'ViewCaseInstruments.Refresh()
                'ViewCaseDocuments.Refresh()
                'EditLocatingStatusSupervisor.LocatingStatus = mobjPerson.LocatingStatus

                'automatically save the case if they hit OK from the frmLocatingAttemptXXX dialogs
                If SaveCase() Then
                    DisplayCase(mobjCase)
                End If
            End If

            'C3 6/12/14: caller must call Dipose() method on modal forms.
            'http://stackoverflow.com/questions/3097364/c-sharp-form-close-vs-form-dispose
            frm.Dispose()

        End If
    End Sub

    Private Sub tsbLock_Click(sender As Object, e As EventArgs) Handles tsbLock.Click

        If CurrentUser.HasFullAccess(Security.Enumerations.Permission.SMSLocating) Then
            LockCase()
            DisplayCase(mobjCase)
        End If
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click

        If SaveCase() Then
            DisplayCase(mobjCase)
        End If
    End Sub

    Private Sub frmLocatingMain_Load(sender As Object, e As EventArgs) Handles Me.Load

        '== set-up the generic form properties:

        'fill the Entity Types into the New pull-down button
        tsbNew.DropDownItems.Clear()
        For Each objAttemptType As LocatingAttemptType In Project.LocatingAttemptTypes
            If GetSafeValue(objAttemptType.IsActive) Then
                tsbNew.DropDownItems.Add(objAttemptType.LocatingAttemptType.ToString)

                'select the appropriate image
                If GetSafeValue(objAttemptType.ShowURL) <> "" Then
                    tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Image = imgImages.Images("Internet")
                ElseIf GetSafeValue(objAttemptType.ShowChangeRespondent) Then
                    tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Image = imgImages.Images("ChangeCR")
                ElseIf GetSafeValue(objAttemptType.ShowAddDocument) Then
                    tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Image = imgImages.Images("Document")
                Else
                    tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Image = imgImages.Images("Locating")
                End If

                tsbNew.DropDownItems(tsbNew.DropDownItems.Count - 1).Tag = objAttemptType
            End If
        Next

        tsslUser.Text = CurrentUser.Name
    End Sub

    Private Sub frmLocatingMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmSave() = DialogResult.Cancel)
        If Not e.Cancel AndAlso Not mobjCase Is Nothing Then
            mobjCase.Unlock()
            mobjCase.Dispose()
        End If
    End Sub

    Private Sub tsbClose_Click(sender As Object, e As EventArgs) Handles tsbClose.Click

        Me.Close()
    End Sub

    Private Sub tsslCaseID_MouseDown(sender As Object, e As MouseEventArgs) Handles tsslCaseID.MouseDown

        'Case History
        If e.Button = MouseButtons.Right Then
            If Not mobjCase.CaseID.IsNull AndAlso Not mobjCase.CaseID.Value.Equals(0) Then
                Dim frm As New frmDisplayHistory(mobjCase)
                frm.Width = Me.Width
                frm.Location = New Point(Me.Left, Cursor.Position.Y - 12 - frm.Height)
                frm.Show()
            End If

        End If
    End Sub

    Private Sub tsmLowPriority_Click(sender As Object, e As EventArgs) Handles tsmLowPriority.Click

        mobjPerson.LocatingStatus.PriorityStatus = 0
        tsbPriority.Image = tsmLowPriority.Image
        tsbPriority.ToolTipText = "This case is set to Low priority"
        tsmHighPriority.Checked = False
        tsmLowPriority.Checked = True
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub tsmHighPriority_Click(sender As Object, e As EventArgs) Handles tsmHighPriority.Click

        mobjPerson.LocatingStatus.PriorityStatus = 1
        tsbPriority.Image = tsmHighPriority.Image
        tsbPriority.ToolTipText = "This case is set to High priority"
        tsmHighPriority.Checked = True
        tsmLowPriority.Checked = False
        tsbSave.Enabled = mobjCase.IsModified
    End Sub

    Private Sub tabCase_Click(sender As Object, e As EventArgs) Handles tabCase.Click

        mobjCurrentTab = tabCase.SelectedTab
        ViewCaseMembers.SelectedPerson = mobjPerson
    End Sub
    'Private Sub tsbSelectNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim frm As New frmSelectNewRespondent(mobjCase)
    '    frm.ShowDialog()

    '    If frm.DialogResult = System.Windows.Forms.DialogResult.OK Then
    '        tsbSave.Enabled = mobjCase.IsModified
    '    End If

    'End Sub

#End Region
End Class