'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms.Validation

Public Class EditSocialNetwork

#Region "Private fields"

    'Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing
    Private mobjSocialNetwork As SocialNetwork = Nothing

    Private mblnIsShared As Boolean = False
    Private mblnReadOnly As Boolean = False
    Private mblnSocialNetworkRequired As Boolean = False
    Private blnInFillUserControl As Boolean = False

#End Region

#Region "Public Properties"

    'Public Property [Case]() As [Case]
    '    Get
    '        Return mobjCase
    '    End Get
    '    Set(ByVal value As [Case])
    '        mobjCase = value
    '    End Set
    'End Property

    Public Property Person As Person
        Get
            Return mobjPerson
        End Get
        Set
            If value Is Nothing Then Return

            mobjPerson = value
        End Set
    End Property

    'gets/sets whether the SocialNetwork will be shared or personal
    <DefaultValue(False)>
    Public Property IsShared As Boolean
        Get
            Return mblnIsShared
        End Get
        Set
            mblnIsShared = value
            SetSharedButton()
            SetWarning()
        End Set
    End Property

    Public Property SocialNetwork As SocialNetwork
        Get
            FillProperties()
            Return mobjSocialNetwork
        End Get
        Set
            mobjSocialNetwork = value
            FillUserControl()
        End Set
    End Property

    <DefaultValue(False)>
    Public Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = value
            EnableUserControl(mblnReadOnly)
        End Set
    End Property

    <DefaultValue(False)>
    Public Property SocialNetworkRequired As Boolean
        Get
            Return mblnSocialNetworkRequired
        End Get
        Set
            mblnSocialNetworkRequired = value
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjSocialNetwork Is Nothing Then Exit Sub

        With mobjSocialNetwork
            SetSafeValue(.UserName, txtUserName.Text)
            SetSafeValue(.URL, txtURL.Text)
            SetSafeValue(.Notes, txtNotes.Text)
            .SocialNetworkTypeID = cboSocialNetworkType.SelectedSocialNetworkTypeID
            .SourceTypeID = cboSourceType.SelectedSourceTypeID
            .SourceQualityID = cboSourceQuality.SelectedSourceQualityID

            .StatusTypeID = cboSocialNetworkStatus.SelectedSocialNetworkStatusID
            If txtSentRequestOn.Text <> "" AndAlso cboSocialNetworkStatus.SelectedSocialNetworkStatus.IsActiveRequest _
                Then
                SetSafeValue(.SentRequestOn, txtSentRequestOn.Text)
            End If
            SetSafeValue(.LikeUs, chkLikeUs.Checked)

        End With

        If chkBestSocialNetwork.Checked AndAlso mobjSocialNetwork.IsValid Then
            Person.BestSocialNetwork = mobjSocialNetwork
        ElseIf Person.BestSocialNetwork IsNot Nothing AndAlso
               Person.BestSocialNetwork.Equals(mobjSocialNetwork) Then
            Person.BestSocialNetwork = Nothing
        End If
    End Sub

    Private Sub FillUserControl()

        If mobjSocialNetwork Is Nothing Then Exit Sub
        blnInFillUserControl = True

        With mobjSocialNetwork
            txtUserName.Text = GetSafeValue(.UserName)
            txtURL.Text = GetSafeValue(.URL)
            txtNotes.Text = GetSafeValue(.Notes)
            cboSocialNetworkType.SelectedSocialNetworkTypeID = GetSafeValue(.SocialNetworkTypeID)
            cboSourceType.SelectedSourceTypeID = GetSafeValue(.SourceTypeID)
            cboSourceQuality.SelectedSourceQualityID = GetSafeValue(.SourceQualityID)

            cboSocialNetworkStatus.SelectedSocialNetworkStatusID = GetSafeValue(.StatusTypeID)
            If Not .SentRequestOn.IsNull Then
                txtSentRequestOn.Text = GetSafeValue(.SentRequestOn).ToString
            End If
            chkLikeUs.Checked = GetSafeValue(.LikeUs)

        End With

        SetSharedButton()

        If Person.BestSocialNetwork Is Nothing OrElse
           (Person.SocialNetworks.Count = 0 And mobjSocialNetwork.SocialNetworkID.IsNull) OrElse
           (Person.SocialNetworks.Count = 1 And Not mobjSocialNetwork.SocialNetworkID.IsNull) Then
            chkBestSocialNetwork.Checked = True
            chkBestSocialNetwork.AutoCheck = False
        ElseIf mobjSocialNetwork Is Nothing Then
            chkBestSocialNetwork.Checked = False
        Else
            chkBestSocialNetwork.Checked = (Person.BestSocialNetwork.Equals(mobjSocialNetwork))
        End If
        If Person.FullName.Length > 0 Then
            chkBestSocialNetwork.Text = "This is the 'best' Social Network for " & GetSafeValue(Person.FirstName) & " " &
                                        GetSafeValue(Person.LastName)
        End If

        blnInFillUserControl = False
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtUserName.ReadOnly = blnReadOnly
        txtURL.ReadOnly = blnReadOnly
        txtNotes.ReadOnly = blnReadOnly

        cboSocialNetworkType.ReadOnly = blnReadOnly
        cboSourceType.ReadOnly = blnReadOnly
        cboSourceQuality.ReadOnly = blnReadOnly

        cboSocialNetworkStatus.Enabled = Not blnReadOnly
        chkLikeUs.Enabled = Not blnReadOnly
    End Sub

    Private Sub SetSharedButton()

        btnShared.Visible = Project.AllowShared
        If IsShared Then
            btnShared.Text = "This Social Network is shared with all case members"
            btnShared.Image = ImageList.Images("users.bmp")
        Else
            btnShared.Text = "This Social Network is specific to this case member"
            btnShared.Image = ImageList.Images("user.bmp")
        End If
    End Sub

    Private Sub SetWarning()

        lblWarning.Visible = IsShared

        If mobjSocialNetwork.IsValid Then
            lblWarning.Text =
                "Note: Changing any information on this shared Social Network will also apply those changes to all other members of this case."
        Else
            lblWarning.Text =
                "Note: Adding a shared SocialNetwork will add this Social Network to all other members of this case."
        End If
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnShared_Click(sender As Object, e As EventArgs) Handles btnShared.Click

        IsShared = Not IsShared
    End Sub

    Private Sub TextValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles TextValidator.Validating
        If Not mblnSocialNetworkRequired Then
            e.Valid = True
        Else
            e.Valid = (Not txtUserName.Text.Length.Equals(0))
        End If
    End Sub

    Private Sub cboSocialNetworkStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSocialNetworkStatus.SelectedIndexChanged

        'if friending message or friend request are sent, re-set date request sent on
        If not blnInFillUserControl Then
            If cboSocialNetworkStatus.SelectedSocialNetworkStatus.IsActiveRequest Then
                txtSentRequestOn.Text = Now.ToString
                'SetSafeValue(mobjSocialNetwork.SentRequestOn, txtSentRequestOn.Text)
            End If
        End If
    End Sub

#End Region
End Class

Public Class cboItem
    Private mintID As Integer
    Private mstrDescription As String

    Public Property ID As Integer
        Get
            Return mintID
        End Get
        Set
            mintID = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return mstrDescription
        End Get
        Set
            mstrDescription = value
        End Set
    End Property

    Public Sub New(intID As Integer, strDescription As String)
        mintID = intID
        mstrDescription = strDescription
    End Sub
End Class