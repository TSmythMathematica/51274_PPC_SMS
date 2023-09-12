'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmDisplayNotes
    Inherits Form

#Region "Private Variables"

    Private ReadOnly mobjaddress As Address

#End Region

#Region "Constructors"

    Public Sub New(objAddress As Address)

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        mobjaddress = objAddress
        ViewNotes.SelectedAddress = mobjaddress
        ViewNotes.SelectedCase = mobjaddress.Case
        'ViewNotes.btnAdd.Enabled = False
        ViewNotes.Refresh()
    End Sub

#End Region
End Class