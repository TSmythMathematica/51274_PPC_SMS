'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditPersonName

#Region "Private fields"

    'Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

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

    Private Sub FillProperties()

        If mobjPerson Is Nothing Then Exit Sub

        With mobjPerson
            SetSafeValue(.FirstName, txtFName.Text)
            SetSafeValue(.LastName, txtLName.Text)
            SetSafeValue(.MiddleName, txtMName.Text)
            SetSafeValue(.Suffix, txtSuffix.Text)
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjPerson Is Nothing Then Exit Sub

        With mobjPerson
            txtMPRID.Text = GetSafeValue(.MPRID)
            txtFName.Text = GetSafeValue(.FirstName)
            txtLName.Text = GetSafeValue(.LastName)
            txtMName.Text = GetSafeValue(.MiddleName)
            txtSuffix.Text = GetSafeValue(.Suffix)
        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtFName.ReadOnly = blnReadOnly
        txtLName.ReadOnly = blnReadOnly
        txtMName.ReadOnly = blnReadOnly
        txtSuffix.ReadOnly = blnReadOnly

        Me.TabStop = Not blnReadOnly
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

#End Region
End Class
