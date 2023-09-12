'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data


Public Class frmDisplayNote

#Region "Constructors"

    '  Private _addressNote As AddressNote

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objNote As AllNote)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtNote.Text = GetSafeValue(objNote.Notes)
        txtNote.ReadOnly = True
        txtNote.Select(0, 0)
    End Sub

    Public Sub New(objNote As Note)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtNote.Text = GetSafeValue(objNote.Notes)
        txtNote.ReadOnly = True
        txtNote.Select(0, 0)
    End Sub

    Public Sub New(objNote As ConfirmitCallHistoryRecord)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        txtNote.Text = GetSafeValue(objNote.CallComment)
        txtNote.ReadOnly = True
        txtNote.Select(0, 0)
    End Sub

#End Region

#Region "Event Handlers"

    'Sub New(addressNote As AddressNote)
    '    ' TODO: Complete member initialization 
    '    _addressNote = addressNote
    'End Sub

    Private Sub txtNote_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles txtNote.KeyPress

        If e.KeyChar = ChrW(Keys.Escape) Then
            Me.Close()
        End If
    End Sub

    Private Sub txtNote_LostFocus(sender As Object, e As EventArgs) Handles txtNote.LostFocus

        Me.Close()
    End Sub

#End Region

#Region "Private Methods"

#End Region
End Class