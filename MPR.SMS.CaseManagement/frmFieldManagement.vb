'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Class frmFieldManagement
    Public Sub New(FieldManagmentURL As Uri)

        InitializeComponent()

        WebBrowser.Url = FieldManagmentURL
    End Sub
End Class