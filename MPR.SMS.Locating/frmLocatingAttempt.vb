'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Windows.Forms
Imports MPR.SMS.Data
Imports MPR.SMS.UserControls

Public Class frmLocatingAttempt

#Region "Private Fields"

    Private ReadOnly mobjLocatingAttemptType As LocatingAttemptType
    Private mobjPerson As Person
    Private ReadOnly mobjSelPerson As Person
    Private mobjLocatingAttempt As LocatingAttempt
    Private mobjLocatingStatus As LocatingStatus
    Private mblnExpanded As Boolean = False

    'last to be modified:
    Private mobjLastAddress As Address = Nothing
    Private mobjLastPhone As Phone = Nothing
    Private mobjLastEmail As Email = Nothing
    Private mobjLastSocialNetwork As SocialNetwork = Nothing
    Private ReadOnly mintPhoneCount As Integer = 0

#End Region

#Region "Public Properties"

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objPerson As Person, objLocatingAttemptType As LocatingAttemptType, objSelPerson As Person)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjLocatingAttemptType = objLocatingAttemptType
        mobjPerson = objPerson
        mobjSelPerson = objSelPerson
        mobjLocatingStatus = objPerson.LocatingStatus
        mintPhoneCount = mobjSelPerson.Phones.Count

        mobjLocatingAttempt = New LocatingAttempt()
        mobjLocatingAttempt.Person = objPerson
        mobjLocatingAttempt.LocatingAttemptTypeID = objLocatingAttemptType.LocatingAttemptTypeID
        mobjLocatingAttempt.LocatingAttemptResultID = objLocatingAttemptType.ResultDefault
        mobjLocatingAttempt.PersonLocated = objSelPerson

        EditLocatingStatus.LocatingStatus = mobjLocatingStatus
        EditLocatingAttempt.LocatingAttempt = mobjLocatingAttempt

        EditPerson.Person = objSelPerson
        ViewCaseAddresses.SelectedPerson = objSelPerson
        ViewCasePhones.SelectedPerson = objSelPerson
        ViewCaseEmails.SelectedPerson = objSelPerson
        ViewCaseSocialNetworks.SelectedPerson = objSelPerson
        ViewCaseNotes.SelectedCase = objPerson.Case

        Me.Text = "SMS - [ " & Project.ShortName & "] - Locating Task: " &
                  objLocatingAttemptType.LocatingAttemptType.ToString

        'display the form based on the Attempt Type parameters.
        If Not objLocatingAttemptType.ShowPersonName Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabPerson"))
        End If
        If Not objLocatingAttemptType.ShowAddresses Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabAddress"))
        End If
        If Not objLocatingAttemptType.ShowPhones Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabPhone"))
        End If
        If Not objLocatingAttemptType.ShowEmails Then
            tabCase.TabPages.Remove(tabCase.TabPages("tabEmail"))
            tabCase.TabPages.Remove(tabCase.TabPages("tabSN"))
        End If

        Dim blnShowIE As Boolean = GetSafeValue(objLocatingAttemptType.ShowInSeparateBrowser)
        Dim blnShowURL As Boolean = GetSafeValue(objLocatingAttemptType.ShowURL) <> ""

        'initialize browser to a default URL
        WebBrowser.Navigate(New Uri("about:blank"))

        If blnShowURL And Not blnShowIE Then
            WebBrowser.AllowNavigation = True
            Navigate(GetSafeValue(objLocatingAttemptType.ShowURL))
        Else
            Me.Height = Me.Height - CInt(SplitContainer2.Panel1.Height*0.4)
            SplitContainer2.Panel1.Visible = False
            SplitContainer2.SplitterDistance = 25
            If blnShowURL And blnShowIE Then
                If Project.LastURLProcess <> GetSafeValue(objLocatingAttemptType.ShowURL) Then
                    Process.Start(GetSafeValue(objLocatingAttemptType.ShowURL))
                End If
                Project.LastURLProcess = GetSafeValue(objLocatingAttemptType.ShowURL)
            End If
        End If

        Select Case objLocatingAttemptType.ShowDefault
            Case "N"
                tabCase.SelectedTab = tabCase.TabPages("tabPerson")
            Case "A"
                tabCase.SelectedTab = tabCase.TabPages("tabAddress")
            Case "P"
                tabCase.SelectedTab = tabCase.TabPages("tabPhone")
            Case "E"
                tabCase.SelectedTab = tabCase.TabPages("tabEmail")
            Case "S"
                tabCase.SelectedTab = tabCase.TabPages("tabSN")
        End Select
    End Sub

#End Region

#Region "Private Methods"

    ' Navigates to the given URL if it is valid.
    Private Sub Navigate(address As String)

        If String.IsNullOrEmpty(address) Then Return
        If address.Equals("about:blank") Then Return
        If Not address.StartsWith("http://") And
           Not address.StartsWith("https://") And
           Not address.StartsWith("ftp://") Then
            address = "http://" & address
        End If

        Try
            WebBrowser.Navigate(New Uri(address))
        Catch ex As UriFormatException
            Return
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        FormValidator.Validate()
        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            DialogResult = DialogResult.None
        End If

        If DialogResult = DialogResult.OK Then

            'fill the objects from the edit classes
            mobjLocatingStatus = EditLocatingStatus.LocatingStatus
            mobjLocatingAttempt = EditLocatingAttempt.LocatingAttempt
            mobjPerson = EditPerson.Person

            mobjLocatingAttempt.PersonLocated = mobjLocatingAttempt.PersonLocated
            mobjLocatingAttempt.Address = mobjLastAddress
            mobjLocatingAttempt.Phone = mobjLastPhone
            mobjLocatingAttempt.Email = mobjLastEmail
            mobjLocatingAttempt.SocialNetwork = mobjLastSocialNetwork
            mobjLocatingAttempt.LocatingStatus = mobjLocatingStatus.LocatingStatus

            mobjPerson.LocatingStatus = mobjLocatingStatus
            mobjPerson.LocatingAttempts.Add(0, mobjLocatingAttempt)
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click

        mblnExpanded = Not mblnExpanded
        SplitContainer1.Visible = Not mblnExpanded
        SplitContainer3.Visible = Not mblnExpanded
        If mblnExpanded Then
            btnExpand.Image = imlShowHide.Images("hide.bmp")
            btnExpand.Text = "Collapse"
            SplitContainer2.SplitterDistance = CInt(SplitContainer2.Height)
            SplitContainer3.SplitterDistance = CInt(SplitContainer3.Height)
        Else
            btnExpand.Image = imlShowHide.Images("show.bmp")
            btnExpand.Text = "Expand"
            SplitContainer2.SplitterDistance = CInt(SplitContainer2.Height*0.4)
            SplitContainer3.SplitterDistance = CInt(SplitContainer3.Height*0.55)
        End If
    End Sub

    Private Sub cboURL_KeyDown(sender As Object, e As KeyEventArgs) Handles cboURL.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            Navigate(cboURL.Text)
        End If
    End Sub

    Private Sub WebBrowser_Navigated(sender As Object, e As WebBrowserNavigatedEventArgs) Handles WebBrowser.Navigated

        cboURL.Text = WebBrowser.Url.ToString()
    End Sub

    Private Sub btnFavorites_Click(sender As Object, e As EventArgs) Handles btnFavorites.Click

        Dim frm As New frmWebFavorites
        frm.Location = New Point(CInt(Cursor.Position.X - frm.Width/2), Cursor.Position.Y + 12)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            Navigate(frm.SelectedURL)
        End If
    End Sub

    Private Sub ViewCaseAddresses_OnChanged(sender As Object, objAddress As Address) Handles ViewCaseAddresses.OnChanged

        mobjLastAddress = objAddress

        'if a new phone was added, then note that as well
        If mobjPerson.Phones.Count > mintPhoneCount Then
            mobjLastPhone = mobjPerson.Phones(mobjPerson.Phones.Count - 1)
            ViewCasePhones.Refresh()
        End If
    End Sub

    Private Sub ViewCasePhones_OnChanged(sender As Object, objPhone As Phone) Handles ViewCasePhones.OnChanged

        mobjLastPhone = objPhone
    End Sub

    Private Sub ViewCaseEmails_OnChanged(sender As Object, objEmail As Email) Handles ViewCaseEmails.OnChanged

        mobjLastEmail = objEmail
    End Sub

    Private Sub ViewCaseSocialNetworks_OnChanged(sender As Object, objSocialNetwork As SocialNetwork) _
        Handles ViewCaseSocialNetworks.OnChanged

        mobjLastSocialNetwork = objSocialNetwork
    End Sub

    Private Sub frmLocatingAttempt_Load(sender As Object, e As EventArgs) Handles Me.Load

        'if there is an application associated with this Locating Task, start it now.
        If Not GetSafeValue(mobjLocatingAttemptType.ApplicationLocation).Equals("") Then
            Try
                Process.Start(GetSafeValue(mobjLocatingAttemptType.ApplicationLocation))
            Catch ex As Exception
                Dim strMessage As String = "An error was encountered trying to start: " +
                                           GetSafeValue(mobjLocatingAttemptType.ApplicationLocation) +
                                           Environment.NewLine + Environment.NewLine + ex.Message.ToString
                MessageBox.Show(strMessage, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End If
    End Sub


    Private Sub frmLocatingAttempt_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'C3 6/12/14: dispose of unmanaged objects
        Me.WebBrowser.Dispose()
    End Sub


#End Region
End Class