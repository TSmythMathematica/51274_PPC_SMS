'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms.Validation

Public Class EditEmail

#Region "Private fields"

    'Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing
    Private mobjEmail As Email = Nothing

    Private mblnIsShared As Boolean = False
    Private mblnReadOnly As Boolean = False
    Private mblnEmailRequired As Boolean = False

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
            mobjPerson = value
        End Set
    End Property

    'gets/sets whether the Address will be shared or personal
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

    Public Property Email As Email
        Get
            FillProperties()
            Return mobjEmail
        End Get
        Set
            mobjEmail = value
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
    Public Property EmailRequired As Boolean
        Get
            Return mblnEmailRequired
        End Get
        Set
            mblnEmailRequired = value
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjEmail Is Nothing Then Exit Sub

        With mobjEmail
            SetSafeValue(.EmailAddress, txtEmail.Text)
            .EmailTypeID = cboEmailType.SelectedEmailTypeID
            .SourceTypeID = cboSourceType.SelectedSourceTypeID
            .SourceQualityID = cboSourceQuality.SelectedSourceQualityID
        End With

        If chkBestEmail.Checked AndAlso mobjEmail.IsValid Then
            Person.BestEmail = mobjEmail
        ElseIf Person.BestEmail IsNot Nothing AndAlso
               Person.BestEmail.Equals(mobjEmail) Then
            Person.BestEmail = Nothing
        End If
    End Sub

    Private Sub FillUserControl()

        If mobjEmail Is Nothing Then Exit Sub

        With mobjEmail
            txtEmail.Text = GetSafeValue(.EmailAddress)
            cboEmailType.SelectedEmailTypeID = GetSafeValue(.EmailTypeID)
            cboSourceType.SelectedSourceTypeID = GetSafeValue(.SourceTypeID)
            cboSourceQuality.SelectedSourceQualityID = GetSafeValue(.SourceQualityID)
        End With
        SetSharedButton()

        If Person.BestEmail Is Nothing OrElse
           (Person.Emails.Count = 0 And mobjEmail.EmailID.IsNull) OrElse
           (Person.Emails.Count = 1 And Not mobjEmail.EmailID.IsNull) Then
            chkBestEmail.Checked = True
            chkBestEmail.AutoCheck = False
        ElseIf mobjEmail Is Nothing Then
            chkBestEmail.Checked = False
        Else
            chkBestEmail.Checked = (Person.BestEmail.Equals(mobjEmail))
        End If
        If Person.FullName.Length > 0 Then
            chkBestEmail.Text = "This is the 'best' Email for " & GetSafeValue(Person.FirstName) & " " &
                                GetSafeValue(Person.LastName)
        End If
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtEmail.ReadOnly = blnReadOnly

        cboEmailType.ReadOnly = blnReadOnly
        cboSourceType.ReadOnly = blnReadOnly
        cboSourceQuality.ReadOnly = blnReadOnly
    End Sub

    Private Sub SetSharedButton()

        btnShared.Visible = Project.AllowShared
        If IsShared Then
            btnShared.Text = "This email is shared with all case members"
            btnShared.Image = ImageList.Images("users.bmp")
        Else
            btnShared.Text = "This email is specific to this case member"
            btnShared.Image = ImageList.Images("user.bmp")
        End If
    End Sub

    Private Sub SetWarning()

        lblWarning.Visible = IsShared

        If mobjEmail.IsValid Then
            lblWarning.Text =
                "Note: Changing any information on this shared email will also apply those changes to all other members of this case."
        Else
            lblWarning.Text = "Note: Adding a shared email will add this email to all other members of this case."
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
        If Not mblnEmailRequired Then
            e.Valid = True
        Else
            e.Valid = (Not txtEmail.Text.Length.Equals(0))
        End If
    End Sub

#End Region
End Class
