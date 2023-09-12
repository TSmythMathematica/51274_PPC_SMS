'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms.Validation

Public Class EditNote

#Region "Private fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person = Nothing
    Private mobjAddress As Address = Nothing
    Private mobjNote As Note = Nothing

    Private mblnIsShared As Boolean = False
    Private mblnReadOnly As Boolean = False
    Private mblnNoteRequired As Boolean = False

#End Region

#Region "Public Properties"

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Person As Person
        Get
            Return mobjPerson
        End Get
        Set
            mobjPerson = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Address As Address
        Get
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
        End Set
    End Property

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Note As Note
        Get
            FillProperties()
            Return mobjNote
        End Get
        Set
            mobjNote = value
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
    Public Property NoteRequired As Boolean
        Get
            Return mblnNoteRequired
        End Get
        Set
            mblnNoteRequired = value
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillProperties()


        If LicenseManager.UsageMode = LicenseUsageMode.Designtime Then Return

        If mobjNote Is Nothing Then Exit Sub


        ' EE: logic added 2/11/2015 for Is Field Note?  enhancement
        With mobjNote
            SetSafeValue(.Notes, txtNotes.Text)
            SetSafeValue(.TableTypeID, cboNoteType.SelectedNoteTypeID.ToString())
            .SourceTypeID = cboSourceType.SelectedSourceTypeID
            .CreatedOn = DateTime.Now
            .IsFieldNote = chkShowInField.Checked

        End With
        ViewNotes.SelectedAddress = mobjAddress
    End Sub

    Private Sub FillUserControl()

        Return
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtNotes.ReadOnly = blnReadOnly

        cboNoteType.ReadOnly = blnReadOnly
        cboSourceType.ReadOnly = blnReadOnly
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

    Private Sub TextValidator_Validating(sender As Object, e As CustomValidator.ValidatingCancelEventArgs) _
        Handles TextValidator.Validating
        If Not mblnNoteRequired Then
            e.Valid = True
        Else
            e.Valid = (Not txtNotes.Text.Length.Equals(0))
        End If
    End Sub


    Private Sub chkShowInField_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowInField.CheckedChanged
        ' if checked
        ' then 
    End Sub

#End Region
End Class
