'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data

Public Class frmRemailDocument
    Inherits Form

#Region "Private Variables"

    Private mobjCase As [Case]
    Private ReadOnly mobjSelPerson As Person     'Selected Person
    Private mobjaddress As Address

#End Region

#Region "Constructors"

    Public Sub New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Public Sub New(objCase As [Case], objPerson As Person, objDocumentType As DocumentType, objDocument As Document)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjSelPerson = objPerson


        lblPersonName.Text = "Sample Member:  " + mobjSelPerson.FullName

        DisplayAddress(objCase, objPerson, objDocumentType, objDocument)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayAddress(objCase As [Case], objPerson As Person, objdocumenttype As DocumentType,
                               objdocument As Document)
        ViewAddressRemail.SelectedPerson = objPerson
        ViewAddressRemail.SelectedCase = objCase
        ViewAddressRemail.SelectedDocumentType = objdocumenttype
        ViewAddressRemail.SelectedDocument = objdocument
        ViewAddressRemail.Refresh()
    End Sub

    Private Sub btnClose_click(sender As Object, e As EventArgs) Handles ViewAddressRemail.Close
        Me.Close()
    End Sub

#End Region
End Class