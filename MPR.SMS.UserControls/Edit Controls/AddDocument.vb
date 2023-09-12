'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms.Validation

Public Class AddDocument

#Region "Private fields"

    Private mobjCase As [Case]
    Private mobjDocument As Document = Nothing

#End Region

#Region "Public Properties"

    <Browsable(False)>
    Public Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
        End Set
    End Property

    <Browsable(False)>
    Public Property Document As Document
        Get
            FillProperties()
            Return mobjDocument
        End Get
        Set
            mobjDocument = value
            FillUserControl()
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjDocument Is Nothing Then Exit Sub

        With mobjDocument
            .DocumentTypeID = cboDocumentType.SelectedDocumentTypeID
            'if no Output type, then status it as "Sent", otherwise it's "Queued"
            If cboDocumentType.SelectedDocumentType IsNot Nothing Then
                If GetSafeValue(cboDocumentType.SelectedDocumentType.DocumentOutputTypeID) = 0 Then
                    .DocumentStatusID = 2   'Sent 
                Else
                    .DocumentStatusID = 1   'Queued (i.e. Created)
                End If
            End If
            If ViewCaseMembers.SelectedPerson IsNot Nothing Then
                .PersonHistory = ViewCaseMembers.SelectedPerson.PersonHistory
            Else
                .PersonHistory = Nothing
            End If
            If ViewCaseAddresses.SelectedAddress IsNot Nothing Then
                .AddressHistory = ViewCaseAddresses.SelectedAddress.AddressHistory
            Else
                .AddressHistory = Nothing
            End If
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjDocument Is Nothing Then Exit Sub

        ViewCaseMembers.SelectedCase = mobjCase
        ViewCaseAddresses.SelectedCase = mobjCase
        'With mobjDocument
        '    DocumentTypeComboBox.SelectedDocumentTypeID = GetSafeValue(.DocumentTypeID)
        '    ViewCaseMembers.SelectedPerson = .PersonHistory.Person
        '    ViewCaseAddresses.SelectedAddress = .AddressHistory.address
        'End With

        If cboDocumentType.ListCount > 0 Then cboDocumentType.SelectedIndex = 0

        If mobjCase.Persons.Count > 0 Then
            If mobjDocument.PersonHistory IsNot Nothing Then
                ViewCaseMembers.SelectedPerson = mobjDocument.PersonHistory.Person
            Else
                ViewCaseMembers.SelectedPerson = mobjCase.Persons(0)
            End If
            ViewCaseAddresses.SelectedPerson = ViewCaseMembers.SelectedPerson
            'If mobjCase.Persons(0).Addresses.Count > 0 Then
            '    If mobjDocument.AddressHistory IsNot Nothing Then
            '        ViewCaseAddresses.SelectedAddress = mobjDocument.AddressHistory.Address
            '    Else
            '        ViewCaseAddresses.SelectedAddress = mobjCase.Persons(0).Addresses(0)
            '    End If
            'End If
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

    Private Sub ViewCaseMembers_OnClick(sender As Object, objPerson As Person) Handles ViewCaseMembers.OnClick

        ViewCaseAddresses.SelectedPerson = objPerson
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Dim objSelDocument As DocumentType = cboDocumentType.SelectedDocumentType
        Dim strFileName As String = GetSafeValue(objSelDocument.SampleFilePathName)

        If strFileName.Equals("") Then
            btnPreview.Enabled = False
            Exit Sub
        End If

        Try
            Cursor.Current = Cursors.WaitCursor
            Process.Start(strFileName)
        Catch ex As Exception
            Dim strMessage As String = "An error was encountered trying to open " + strFileName + ":" + vbCrLf + vbCrLf &
                                       ex.Message
            If Not strMessage.EndsWith(".") Then
                strMessage = strMessage + "."
            End If
            MessageBox.Show(strMessage, Project.ShortName + " - File Preview", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cboDocumentType_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDocumentType.SelectedIndexChanged

        btnPreview.Enabled = (GetSafeValue(cboDocumentType.SelectedDocumentType.SampleFilePathName) <> "")
    End Sub

    Private Sub DocTypeValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles DocTypeValidator.Validating
        e.Valid = cboDocumentType.SelectedDocumentType IsNot Nothing
    End Sub

#End Region
End Class
