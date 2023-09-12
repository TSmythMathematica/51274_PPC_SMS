Imports System.Diagnostics.Eventing.Reader
Imports MPR.SMS.UserControls
Imports MPR.SMS.Data
Imports MPR.SMS.Data.GlobalData
Imports MPR.SMS.Security
Imports MPR.Windows.Forms
Imports System.Windows.Forms
Imports System.Drawing

Public Class frmCaseProperties

#Region "Private Variables"

    Private mobjCase As [Case]
    Private mobjSelPerson As Person     'Selected Person
    Private mblnEditable As Boolean = False
    Private mobjCurrentTab As TabPage

    Private tabSelected(7) as boolean
  
#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ResetTabSelected()

    End Sub

    Public Sub New(ByVal objCase As [Case], ByVal objPerson As Person, ByVal blnReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
      
        mobjCase = objCase
     
        If Not blnReadOnly Then LockCase()

        mobjSelPerson = objPerson

    End Sub

#End Region

#Region "Private Methods"

    'Private Sub DisplayCase(ByVal objCase As [Case], ByVal objPerson As Person)

    '    txtEntityName.Text = GetSafeValue(objCase.EntityName)
    '    txtCaseNotes.Text = GetSafeValue(objCase.CaseNotes)

    '    ViewCaseMembers.SelectedCase = objCase
    '    If objPerson IsNot Nothing Then
    '        ViewCaseMembers.SelectedPerson = objPerson
    '    Else
    '        ViewCaseMembers.SelectedPerson = objCase.PrimarySampleMember
    '    End If
    '    ViewCaseMembers.ShowContacts = False

    '    ViewCaseInstruments.SelectedCase = objCase
    '    ViewCaseDocuments.SelectedCase = objCase
    '    ViewCaseNotes.SelectedCase = objCase
    '    ViewCaseLocatingAttempts.SelectedCase = objCase
    '    ViewCaseLocatingAttempts.SelectedPerson = objPerson
    '    EditValidation.CaseValidation = objCase.CaseValidation

    '    CaseTracking.CurrentSupervisor = New InterviewerSupervisor(CurrentUser.Name)
    '    CaseTracking.InterviewerCaseTrackings = objCase.InterviewerCaseTrackings

    '    'populate the Case Assignment History grid
    '    vwCaseAssignmentHistory.DataSource = "SELECT * FROM vwCaseAssignmentHistory WHERE CaseID = " & GetSafeValue(objCase.CaseID)
    '    vwCaseAssignmentHistory.Columns(0).Visible = False  'CaseID
    '    vwCaseAssignmentHistory.Columns(1).Visible = False  'CaseAssingmentHistoryID
    '    vwCaseAssignmentHistory.SortedColumn = vwCaseAssignmentHistory.Columns("CaseAssignmentHistoryID")
    '    vwCaseAssignmentHistory.SortDirection = System.ComponentModel.ListSortDirection.Descending

    '    If Not objCase Is Nothing AndAlso _
    '       Not objCase.CaseID.IsNull AndAlso _
    '       Not GetSafeValue(objCase.CaseID).Equals(0) Then
    '        tsslCaseID.Text = "CaseID: " & objCase.CaseID.ToString
    '        'tsslStatus.Text = objCase.Status.ToString
    '        If objCase.IsReadOnly Then
    '            tsslLocked.Image = imgImages.Images("lock-unavailable.bmp")
    '            tsslLocked.ToolTipText = "This case is unavailable for editing because it is locked by someone else, or you only have read-only access."
    '        Else
    '            tsslLocked.Image = imgImages.Images("lock-owned.bmp")
    '            tsslLocked.ToolTipText = "This case is locked by you and avaible for editing."
    '        End If
    '        mblnEditable = Not objCase.IsReadOnly And CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)

    '    Else
    '        tsslCaseID.Text = "New case"
    '        tsslStatus.Text = "Untouched"
    '        tsslLocked.Image = imgImages.Images("lock-none.bmp")
    '        tsslLocked.ToolTipText = "This case has not been saved yet."
    '        mblnEditable = True

    '    End If
    '    tsslEntity.Text = GetSafeValue(objCase.EntityType.Description)

    '    'fill in the form title and status bar fields
    '    Me.Text = "SMS - [ " & Project.ShortName & "] - " & tsslCaseID.Text
    '    If Not objCase.EntityName.ToString.Length.Equals(0) Then
    '        Me.Text = Me.Text & " - " & objCase.EntityName.ToString
    '    End If

    '    tsbSave.Enabled = False

    '    '== enable/disable Add/Edit/Delete functions
    '    txtEntityName.ReadOnly = True
    '    txtCaseNotes.ReadOnly = True

    '    ViewCaseMembers.AllowAdd = False
    '    ViewCaseMembers.AllowEdit = False
    '    ViewCaseMembers.AllowDelete = False

    '    ViewCaseAddresses.AllowAdd = ViewCaseMembers.AllowAdd
    '    ViewCaseAddresses.AllowEdit = ViewCaseMembers.AllowEdit
    '    ViewCaseAddresses.AllowDelete = ViewCaseMembers.AllowDelete

    '    ViewCasePhones.AllowAdd = ViewCaseMembers.AllowAdd
    '    ViewCasePhones.AllowEdit = ViewCaseMembers.AllowEdit
    '    ViewCasePhones.AllowDelete = ViewCaseMembers.AllowDelete

    '    ViewCaseEmails.AllowAdd = ViewCaseMembers.AllowAdd
    '    ViewCaseEmails.AllowEdit = ViewCaseMembers.AllowEdit
    '    ViewCaseEmails.AllowDelete = ViewCaseMembers.AllowDelete

    '    'we won't allow add/edit/delete Instrument records at this time.
    '    ViewCaseInstruments.AllowAdd = False    'mblnEditable
    '    ViewCaseInstruments.AllowEdit = False    'mblnEditable
    '    ViewCaseInstruments.AllowDelete = False    'Authorization.IsSupervisor

    '    ViewCaseDocuments.AllowAdd = ViewCaseMembers.AllowAdd
    '    ViewCaseDocuments.AllowEdit = False    'ViewCaseMembers.AllowEdit
    '    ViewCaseDocuments.AllowDelete = ViewCaseMembers.AllowDelete 'IsSupervisor    
    '    ViewCaseDocuments.AllowPreview = False    'ViewCaseMembers.AllowAdd

    '    ViewCaseLocatingAttempts.AllowAdd = False
    '    ViewCaseLocatingAttempts.AllowDelete = False
    '    ViewCaseLocatingAttempts.AllowEdit = False

    '    tabCase.SelectedTab = mobjCurrentTab

    'End Sub


    Private Sub DisplayCaseProperty(ByVal objCase as [Case], ByVal objPerson as Person)
     

        If Not objCase Is Nothing AndAlso _
           Not objCase.CaseID.IsNull AndAlso _
           Not GetSafeValue(objCase.CaseID).Equals(0) Then
            tsslCaseID.Text = "CaseID: " & objCase.CaseID.ToString
            'tsslStatus.Text = objCase.Status.ToString
            If objCase.IsReadOnly Then
                tsslLocked.Image = imgImages.Images("lock-unavailable.bmp")
                tsslLocked.ToolTipText = "This case is unavailable for editing because it is locked by someone else, or you only have read-only access."
            Else
                tsslLocked.Image = imgImages.Images("lock-owned.bmp")
                tsslLocked.ToolTipText = "This case is locked by you and avaible for editing."
            End If
            mblnEditable = Not objCase.IsReadOnly And CurrentUser.HasFullAccess(Security.Enumerations.Permission.FSMCaseAssignment)

        Else
            tsslCaseID.Text = "New case"
            tsslStatus.Text = "Untouched"
            tsslLocked.Image = imgImages.Images("lock-none.bmp")
            tsslLocked.ToolTipText = "This case has not been saved yet."
            mblnEditable = True

        End If
        tsslEntity.Text = GetSafeValue(objCase.EntityType.Description)

        tsslUser.Text = CurrentUser.Name

        txtEntityName.Text = GetSafeValue(mobjCase.EntityName)
      

        'fill in the form title and status bar fields
        Me.Text = "SMS - [ " & Project.ShortName & "] - " & tsslCaseID.Text
        If Not objCase.EntityName.ToString.Length.Equals(0) Then
            Me.Text = Me.Text & " - " & objCase.EntityName.ToString
        End If

        tsbSave.Enabled = False

        '== enable/disable Add/Edit/Delete functions
        txtEntityName.ReadOnly = True
        txtCaseNotes.ReadOnly = True


    end Sub

    Private Sub DisplayTab(ByVal objCase As [Case], ByVal objPerson As Person, ByVal theTab As Integer)
        Me.Cursor = Cursors.WaitCursor
      
        tabSelected(theTab) = True

        Select theTab
            Case CaseTab.ViewCaseMembers
               
                ViewCaseMembers.SelectedCase = objCase
                If objPerson IsNot Nothing Then
                    ViewCaseMembers.SelectedPerson = objPerson
                Else
                    ViewCaseMembers.SelectedPerson = objCase.PrimarySampleMember
                End If
                ViewCaseMembers.ShowContacts = True
                ViewCaseMembers.AllowAdd = False
                ViewCaseMembers.AllowEdit = False
                ViewCaseMembers.AllowDelete = False
                
                ViewCaseAddresses.AllowAdd = ViewCaseMembers.AllowAdd
                ViewCaseAddresses.AllowEdit = ViewCaseMembers.AllowEdit
                ViewCaseAddresses.AllowDelete = ViewCaseMembers.AllowDelete

                ViewCasePhones.AllowAdd = ViewCaseMembers.AllowAdd
                ViewCasePhones.AllowEdit = ViewCaseMembers.AllowEdit
                ViewCasePhones.AllowDelete = ViewCaseMembers.AllowDelete

                ViewCaseEmails.AllowAdd = ViewCaseMembers.AllowAdd
                ViewCaseEmails.AllowEdit = ViewCaseMembers.AllowEdit
                ViewCaseEmails.AllowDelete = ViewCaseMembers.AllowDelete

            Case CaseTab.ViewCaseInstruments
                ViewCaseInstruments.SelectedCase = objCase

                
                'we won't allow add/edit/delete Instrument records at this time.
                ViewCaseInstruments.AllowAdd = False    'mblnEditable
                ViewCaseInstruments.AllowEdit = False    'mblnEditable
                ViewCaseInstruments.AllowDelete = False    'Authorization.IsSupervisor

                ViewCaseDocuments.SelectedCase = objCase
                ViewCaseDocuments.AllowAdd = ViewCaseMembers.AllowAdd
                ViewCaseDocuments.AllowEdit = False    'ViewCaseMembers.AllowEdit
                ViewCaseDocuments.AllowDelete = ViewCaseMembers.AllowDelete 'IsSupervisor    
                ViewCaseDocuments.AllowPreview = False    'ViewCaseMembers.AllowAdd
               

            case CaseTab.ViewCaseNotes
                txtCaseNotes.Text = GetSafeValue(mobjCase.CaseNotes)

                ViewCaseNotes.SelectedCase = objCase
              
            case CaseTab.ViewCaseLocatingAttempts
                ViewCaseLocatingAttempts.SelectedCase = objCase           
                ViewCaseLocatingAttempts.SelectedPerson = objPerson
              
                ViewCaseLocatingAttempts.AllowAdd = False
                ViewCaseLocatingAttempts.AllowDelete = False
                ViewCaseLocatingAttempts.AllowEdit = False
               
            case CaseTab.ViewCaseTracking
                  

                CaseTracking.CurrentSupervisor = New InterviewerSupervisor(CurrentUser.Name)
                CaseTracking.InterviewerCaseTrackings = objCase.InterviewerCaseTrackings
               
            case CaseTab.ViewCaseAssignmentHistory  

                'populate the Case Assignment History grid
                vwCaseAssignmentHistory.DataSource = "SELECT * FROM vwCaseAssignmentHistory WHERE CaseID = " & GetSafeValue(objCase.CaseID)
                vwCaseAssignmentHistory.Columns(0).Visible = False  'CaseID
                vwCaseAssignmentHistory.Columns(1).Visible = False  'CaseAssingmentHistoryID
                vwCaseAssignmentHistory.SortedColumn = vwCaseAssignmentHistory.Columns("CaseAssignmentHistoryID")
                vwCaseAssignmentHistory.SortDirection = System.ComponentModel.ListSortDirection.Descending
                
            Case CaseTab.ViewCaseValidation

                EditValidation.CaseValidation = objCase.CaseValidation
              
        End Select
          
     
        mobjCurrentTab = tabCase.TabPages(theTab)
        tabCase.SelectedTab = mobjCurrentTab

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ResetTabSelected()
        Dim i as integer = 0
        While i < tabCase.TabCount 
            tabSelected(i) = false
            i= i+ 1
        End While
    End Sub

    Private Sub LockCase()

        If GetSafeValue(mobjCase.CaseID) <> 0 Then

            'try to lock case
            Try
                mobjCase.Lock()

                If mobjCase.IsReadOnly Then
                    MessageBox.Show("This case you have selected is read-only because it is currently being updated by another user. If you think the case is locked in error, contact your supervisor to release it.", Project.ShortName & " – Case is locked", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Project.ShortName & " – Case is locked", MessageBoxButtons.OK, MessageBoxIcon.Hand)
            End Try
        End If

    End Sub

    'Returns: Yes    = save changes and continue with chosen action (i.e. exit, search, etc)
    '         No     = don't save changes and continue with chosen action
    '         Cancel = don't save changes and don't continue with chosen action

    Private Function ConfirmSave() As DialogResult

        If mobjCase Is Nothing Then Return System.Windows.Forms.DialogResult.No

        If mobjCase.IsModified Then
            Dim dr As DialogResult = MessageBox.Show("Do you want to save the changes you have made to this case?", Project.ShortName & " – Save changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If dr = System.Windows.Forms.DialogResult.Yes Then
                If Not SaveCase() Then
                    Return System.Windows.Forms.DialogResult.Cancel
                End If
            End If
            Return dr
        Else
            Return System.Windows.Forms.DialogResult.No
        End If

    End Function

    Private Function SaveCase() As Boolean

        If mobjCase.CaseValidation IsNot Nothing AndAlso _
           mobjCase.CaseValidation.IsModified AndAlso _
           Not CaseValidationValidator.IsValid() Then
            CaseValidationValidator.Validate()
            tabCase.SelectedTab = tabValidation
            Return False
        End If
        mobjCurrentTab = tabCase.SelectedTab

        'verify that there's at least one person record
        If mobjCase.Persons.Count = 0 Then
            MessageBox.Show("You must have at least one member in order to save a Case.", "Save error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End If

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

    Private Sub ViewCaseMembers_OnChanged(ByVal sender As Object, ByVal objPerson As Data.Person) Handles ViewCaseMembers.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseMembers.Refresh()
        'ViewCaseAddresses.Refresh()
        'ViewCasePhones.Refresh()

    End Sub

    Private Sub ViewCaseAddresses_OnChanged(ByVal sender As Object, ByVal objAddress As Data.Address) Handles ViewCaseAddresses.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseAddresses.Refresh()
        'ViewCasePhones.Refresh()

    End Sub

    Private Sub ViewCasePhones_OnChanged(ByVal sender As Object, ByVal objPhone As Data.Phone) Handles ViewCasePhones.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCasePhones.Refresh()

    End Sub

    Private Sub ViewCaseEmails_OnChanged(ByVal sender As Object, ByVal objEmail As Data.Email) Handles ViewCaseEmails.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseEmails.Refresh()

    End Sub

    Private Sub ViewCaseInstruments_OnChanged(ByVal sender As Object, ByVal objInstrument As Data.Instrument) Handles ViewCaseInstruments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseInstruments.Refresh()

    End Sub

    Private Sub ViewCaseDocuments_OnChanged(ByVal sender As Object, ByVal objDocument As Data.Document) Handles ViewCaseDocuments.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseDocuments.Refresh()

    End Sub
    Private Sub ViewCaseLocatingAttempts_OnChanged(ByVal sender As Object, ByVal objLocatingAttempt As Data.LocatingAttempt) Handles ViewCaseLocatingAttempts.OnChanged

        tsbSave.Enabled = mobjCase.IsModified
        'ViewCaseLocatingAttempts.Refresh()

    End Sub
    Private Sub CaseTracking_OnChanged(ByVal sender As Object, ByVal objInterviewerCaseTrackings As Data.InterviewerCaseTrackings) Handles CaseTracking.OnChanged

        mobjCase.InterviewerCaseTrackings = objInterviewerCaseTrackings
        tsbSave.Enabled = mobjCase.IsModified

    End Sub

    Private Sub EditValidation_OnChanged(ByVal sender As Object, ByVal objCaseValidation As Data.CaseValidation) Handles EditValidation.OnChanged

        mobjCase.CaseValidation = objCaseValidation
        tsbSave.Enabled = mobjCase.IsModified

    End Sub

    Private Sub ViewCaseMembers_OnClick(ByVal sender As Object, ByVal objPerson As Data.Person) Handles ViewCaseMembers.OnClick

        mobjSelPerson = objPerson

        ViewCaseAddresses.SelectedCase = mobjCase
        ViewCasePhones.SelectedCase = mobjCase
        ViewCaseEmails.SelectedCase = mobjCase

        ViewCaseAddresses.SelectedPerson = objPerson
        ViewCasePhones.SelectedPerson = objPerson
        ViewCaseEmails.SelectedPerson = objPerson

    End Sub


    Private Sub txtEntityName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEntityName.TextChanged

        mobjCase.EntityName = txtEntityName.Text
        tsbSave.Enabled = mobjCase.IsModified

    End Sub

    Private Sub txtCaseNotes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCaseNotes.TextChanged

        mobjCase.CaseNotes = txtCaseNotes.Text
        tsbSave.Enabled = mobjCase.IsModified

    End Sub

    Private Sub tsbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tsbSave.Click

        If SaveCase() Then
            ResetTabSelected()
            DisplayTab(mobjCase, mobjSelPerson, mobjCurrentTab.TabIndex -1 )
        End If

    End Sub

    Private Sub frmDisplayCase_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        '== set-up the generic form properties:

        DisplayCaseProperty(mobjCase, mobjSelPerson)

        DisplayTab(mobjCase, mobjSelPerson, CaseTab.ViewCaseMembers)

    End Sub

    Private Sub frmDisplayCase_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        e.Cancel = (ConfirmSave() = System.Windows.Forms.DialogResult.Cancel)
        If Not e.Cancel AndAlso Not mobjCase Is Nothing Then
            mobjCase.Unlock()
            mobjCase.Dispose()
        End If

    End Sub

    Private Sub tsbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbClose.Click

        Me.Close()

    End Sub

    Private Sub tsbPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPrint.Click

        CaptureScreen()
        PrintPreviewDialog1.Document = Me.PrintDocument1
        Me.PrintPreviewDialog1.ShowDialog()

    End Sub

    Private Sub tsslCaseID_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsslCaseID.MouseDown

        'Case History
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            If Not mobjCase.CaseID.IsNull AndAlso Not mobjCase.CaseID.Value.Equals(0) Then
                Dim frm As New frmDisplayHistory(mobjCase)
                frm.Width = Me.Width
                frm.Location = New Point(Me.Left, System.Windows.Forms.Cursor.Position.Y - 12 - frm.Height)
                frm.Show()
            End If

        End If

    End Sub

    Private Sub tabCase_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabCase.SelectedIndexChanged
        If tabCase.SelectedIndex >= 0 then 

            If not tabSelected(tabcase.SelectedIndex) Then
                DisplayTab(mobjCase, mobjSelPerson, tabCase.SelectedIndex)
            
            end If
        
       end If
    End Sub

#End Region

#Region "Printing"

    Private Declare Function BitBlt Lib "gdi32.dll" Alias "BitBlt" (ByVal hdcDest As IntPtr, ByVal nXDest As Integer, ByVal nYDest As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, ByVal hdcSrc As IntPtr, ByVal nXSrc As Integer, ByVal nYSrc As Integer, ByVal dwRop As System.Int32) As Long
    Dim memoryImage As Bitmap

    Private Sub CaptureScreen()
        Dim mygraphics As Graphics = Me.CreateGraphics()
        Dim s As Size = Me.Size
        memoryImage = New Bitmap(s.Width, s.Height, mygraphics)
        Dim memoryGraphics As Graphics = Graphics.FromImage(memoryImage)
        Dim dc1 As IntPtr = mygraphics.GetHdc
        Dim dc2 As IntPtr = memoryGraphics.GetHdc
        BitBlt(dc2, 0, 0, Me.ClientRectangle.Width, _
           Me.ClientRectangle.Height, dc1, 0, 0, 13369376)
        mygraphics.ReleaseHdc(dc1)
        memoryGraphics.ReleaseHdc(dc2)
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(memoryImage, 0, 0)
    End Sub

#End Region

End Class

Public Enum CaseTab
    ViewCaseMembers = 0
    ViewCaseInstruments
    ViewCaseNotes
    ViewCaseLocatingAttempts   
    ViewCaseTracking
    ViewCaseAssignmentHistory
    ViewCaseValidation
 

End Enum