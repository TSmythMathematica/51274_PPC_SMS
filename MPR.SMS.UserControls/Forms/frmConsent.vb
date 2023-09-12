'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class frmConsent

#Region "Private Variables"

    Private ReadOnly mobjPerson As Person = Nothing
    Private ReadOnly mblnShowConsent As Boolean = True
    Private ReadOnly mblnShowAssent As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Public Properties"

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

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objPerson As Person, blnShowConsent As Boolean, blnShowAssent As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mobjPerson = objPerson
        mblnShowConsent = blnShowConsent
        mblnShowAssent = blnShowAssent

        cboConsent.Visible = mblnShowConsent
        cboAssent.Visible = mblnShowAssent

        FillUserControl()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        DialogResult = DialogResult.Cancel
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        DialogResult = DialogResult.OK

        If DialogResult = DialogResult.OK Then
            FillProperties()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillUserControl()

        With mobjPerson
            txtMPRID.Text = GetSafeValue(.MPRID)
            txtName.Text = GetSafeValue(.FirstName) &
                           RTrim(" " & GetSafeValue(.MiddleName)) &
                           RTrim(" " & GetSafeValue(.LastName)) &
                           RTrim(" " & GetSafeValue(.Suffix))

            If Not .ConsentID.IsNull Then
                cboConsent.SelectedConsentID = .ConsentID.Value
            End If
            If Not .AssentID.IsNull Then
                cboAssent.SelectedConsentID = .AssentID.Value
            End If

        End With
    End Sub

    Private Sub FillProperties()

        'only fill the Consent/Assent values if something is specified. 
        'otherwise, we want to leave it as null, which is a valid value.
        ' Null = Not received yet
        '    0 = No/Refused
        '    1 = Yes/Given
        '    2 = Missing/Incomplete/Other Problem
        If cboConsent.SelectedConsentID >= 0 Then
            mobjPerson.ConsentID = cboConsent.SelectedConsentID
        End If
        If cboAssent.SelectedConsentID >= 0 Then
            mobjPerson.AssentID = cboAssent.SelectedConsentID
        End If
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        cboConsent.ReadOnly = blnReadOnly
        cboAssent.ReadOnly = blnReadOnly
    End Sub

#End Region
End Class