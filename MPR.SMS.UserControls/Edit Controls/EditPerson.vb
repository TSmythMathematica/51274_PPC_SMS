'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditPerson

#Region "Private fields"

    Private mobjPerson As Person = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

#End Region

#Region "Public Properties"

    Public Property Person As Person
        Get
            FillProperties()
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
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
    Public Property LastNameRequired As Boolean
        Get
            Return mblnLastNameRequired
        End Get
        Set
            mblnLastNameRequired = value
            If mblnLastNameRequired Then
                LastNameValidator.ControlToValidate = txtLName
            Else
                LastNameValidator.ControlToValidate = Nothing
            End If
        End Set
    End Property

#End Region

#Region "Private Methods"

    'when adding fields/controls to this user control, you need to add it
    'to the following code sections:
    'Sub FillUserControl - fills in the user control when entering
    'Sub FillProperties - fills in the class object when leaving
    'Sub EnableUserControl - tells the user control how to behave when it's set to Read-Only
    Private Sub FillProperties()

        If mobjPerson Is Nothing Then Exit Sub

        With mobjPerson
            SetSafeValue(.FirstName, txtFName.Text)
            SetSafeValue(.LastName, txtLName.Text)
            SetSafeValue(.MiddleName, txtMName.Text)
            SetSafeValue(.Suffix, txtSuffix.Text)
            SetSafeValue(.Title, txtTitle.Text)
            SetSafeValue(.LexID, txtLexID.Text)
            SetSafeValue(.SSN, txtSSN.Text)
            .GenderID = cboGender.SelectedIndex
            SetSafeValue(.DateOfBirth, txtDOB.Text)
            .LanguageTypeID = cboLanguage.SelectedLanguageTypeID
            If cboLanguage.SelectedLanguageType Is Nothing Then
                SetSafeValue(.LanguageOther, "")
            ElseIf cboLanguage.SelectedLanguageType.Description.ToString.Equals("Other") Then
                SetSafeValue(.LanguageOther, txtLangOther.Text)
            Else
                SetSafeValue(.LanguageOther, "")
            End If
            .RelationshipTypeID = cboRelationship.SelectedRelationshipTypeID
            SetSafeValue(.InSample, chkInSample.Checked)
            SetSafeValue(.IsIneligible, chkIsIneligible.Checked)
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjPerson Is Nothing Then Exit Sub

        With mobjPerson
            txtFName.Text = GetSafeValue(.FirstName)
            txtLName.Text = GetSafeValue(.LastName)
            txtMName.Text = GetSafeValue(.MiddleName)
            txtSuffix.Text = GetSafeValue(.Suffix)
            txtTitle.Text = GetSafeValue(.Title)
            txtLexID.Text = GetSafeValue(.LexID)
            txtSSN.Text = GetSafeValue(.SSN)
            cboGender.SelectedIndex = GetSafeValue(.GenderID)
            txtDOB.Text = GetSafeDate(.DateOfBirth)
            cboLanguage.SelectedLanguageTypeID = GetSafeValue(.LanguageTypeID)
            If cboLanguage.SelectedLanguageType Is Nothing Then
                txtLangOther.Text = ""
            ElseIf cboLanguage.SelectedLanguageType.Description.ToString.Equals("Other") Then
                txtLangOther.Text = GetSafeValue(.LanguageOther)
            Else
                txtLangOther.Text = ""
            End If
            cboRelationship.EntityTypeFilter = CType(.Case.EntityTypeID.ToString(), Data.Enumerations.tlkpEntityType)
            cboRelationship.SelectedRelationshipTypeID = GetSafeValue(.RelationshipTypeID)
            chkInSample.Checked = GetSafeValue(.InSample)
            chkIsIneligible.Checked = GetSafeValue(.IsIneligible)
        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtFName.ReadOnly = blnReadOnly
        txtLName.ReadOnly = blnReadOnly
        txtMName.ReadOnly = blnReadOnly
        txtSuffix.ReadOnly = blnReadOnly
        txtTitle.ReadOnly = blnReadOnly
        txtLexID.ReadOnly = blnReadOnly
        txtSSN.ReadOnly = blnReadOnly
        txtDOB.ReadOnly = blnReadOnly
        cboLanguage.ReadOnly = blnReadOnly
        If cboLanguage.SelectedLanguageType Is Nothing Then
            txtLangOther.ReadOnly = True
        ElseIf cboLanguage.SelectedLanguageType.Description.ToString.Equals("Other") Then
            txtLangOther.ReadOnly = blnReadOnly
        Else
            txtLangOther.ReadOnly = True
        End If
        cboRelationship.ReadOnly = blnReadOnly

        cboGender.Enabled = Not blnReadOnly
        If blnReadOnly = True Then
            cboGender.BackColor = Color.Silver
            cboGender.ForeColor = Color.Black
        Else
            cboGender.BackColor = Color.White
            cboGender.ForeColor = Color.Black
        End If
        chkInSample.AutoCheck = False   'Not blnReadOnly
        chkIsIneligible.AutoCheck = False   'Not blnReadOnly
    End Sub

#End Region

#Region "Contructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objPerson As Person)

#End Region

#Region "Event Handlers"

    Private Sub cboLanguage_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLanguage.SelectedIndexChanged

        txtLangOther.ReadOnly = Not (cboLanguage.SelectedLanguageType.Description.ToString.Equals("Other"))

        If mobjPerson IsNot Nothing AndAlso
           cboLanguage.SelectedLanguageTypeID <> GetSafeValue(mobjPerson.LanguageTypeID) Then
            RaiseEvent OnChanged(Me, Person)
        End If
    End Sub

    Private Sub cboRelationship_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboRelationship.SelectedIndexChanged

        If mobjPerson IsNot Nothing AndAlso
           cboRelationship.SelectedRelationshipTypeID <> GetSafeValue(mobjPerson.RelationshipTypeID) Then
            RaiseEvent OnChanged(Me, Person)
        End If
    End Sub

    Private Sub btnRace_Click(sender As Object, e As EventArgs) Handles btnRace.Click

        Dim frm As New frmRace(mobjPerson, mblnReadOnly)
        frm.Location = New Point(CInt(Cursor.Position.X - frm.Width/2), Cursor.Position.Y + 12)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            RaiseEvent OnChanged(Me, Person)
        End If
    End Sub

    Private Sub btnConsent_Click(sender As Object, e As EventArgs) Handles btnConsent.Click

        Dim frm As New frmConsent(mobjPerson, True, True)
        frm.ReadOnly = mblnReadOnly
        frm.Location = New Point(CInt(Cursor.Position.X - frm.Width/2), Cursor.Position.Y + 12)
        frm.ShowDialog()

        If frm.DialogResult = DialogResult.OK Then
            RaiseEvent OnChanged(Me, Person)
        End If
    End Sub

    Private Sub txtFName_TextChanged(sender As Object, e As EventArgs) Handles txtFName.TextChanged

        If Not Me.DesignMode Then
            If txtFName.Text <> GetSafeValue(mobjPerson.FirstName) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtMName_TextChanged(sender As Object, e As EventArgs) Handles txtMName.TextChanged

        If Not Me.DesignMode Then
            If txtMName.Text <> GetSafeValue(mobjPerson.MiddleName) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtLName_TextChanged(sender As Object, e As EventArgs) Handles txtLName.TextChanged

        If Not Me.DesignMode Then
            If txtLName.Text <> GetSafeValue(mobjPerson.LastName) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtSuffix_TextChanged(sender As Object, e As EventArgs) Handles txtSuffix.TextChanged

        If Not Me.DesignMode Then
            If txtSuffix.Text <> GetSafeValue(mobjPerson.Suffix) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtTitle_TextChanged(sender As Object, e As EventArgs) Handles txtTitle.TextChanged

        If Not Me.DesignMode Then
            If txtTitle.Text <> GetSafeValue(mobjPerson.Title) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtLexID_TextChanged(sender As Object, e As EventArgs) Handles txtLexID.TextChanged

        If Not Me.DesignMode Then
            If txtLexID.Text <> GetSafeValue(mobjPerson.LexID) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtDOB_TextChanged(sender As Object, e As EventArgs) Handles txtDOB.TextChanged

        If Not Me.DesignMode Then
            If CDate(txtDOB.Text) <> GetSafeValue(mobjPerson.DateOfBirth) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtSSN_TextChanged(sender As Object, e As EventArgs) Handles txtSSN.TextChanged

        If Not Me.DesignMode Then
            If txtSSN.Text <> GetSafeValue(mobjPerson.SSN) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub cboGender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboGender.SelectedIndexChanged

        If Not Me.DesignMode Then
            If cboGender.SelectedIndex <> GetSafeValue(mobjPerson.GenderID) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub txtLangOther_TextChanged(sender As Object, e As EventArgs) Handles txtLangOther.TextChanged

        If Not Me.DesignMode Then
            If txtLangOther.Text <> GetSafeValue(mobjPerson.LanguageOther) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub chkInSample_CheckedChanged(sender As Object, e As EventArgs) Handles chkInSample.CheckedChanged

        If Not Me.DesignMode AndAlso mobjPerson IsNot Nothing Then
            If chkInSample.Checked <> GetSafeValue(mobjPerson.InSample) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

    Private Sub chkIsIneligible_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsIneligible.CheckedChanged

        If Not Me.DesignMode Then
            If chkIsIneligible.Checked <> GetSafeValue(mobjPerson.IsIneligible) Then
                RaiseEvent OnChanged(Me, Person)
            End If
        End If
    End Sub

#End Region
End Class
