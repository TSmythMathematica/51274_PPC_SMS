'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditSite

#Region "Private fields"

    Private mobjSite As Site = Nothing

    Private mblnReadOnly As Boolean = False

#End Region

#Region "Public Properties"

    Public Shadows Property Site As Site
        Get
            FillProperties()
            Return mobjSite
        End Get
        Set
            mobjSite = value
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

#End Region

#Region "Public Methods"

    'Note: un-comment the section below if Site is a sample case and has history
    'Public Sub ShowHistory()

    '    If mobjSite IsNot Nothing AndAlso _
    '       Not GetSafeValue(mobjSite.CaseID).Equals(0) Then
    '        Dim frm As New frmDisplayHistory(mobjSite)
    '        frm.Width = Me.Parent.Width
    '        If System.Windows.Forms.Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
    '           frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, System.Windows.Forms.Cursor.Position.Y - 12 - frm.Height)
    '        Else
    '           frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, System.Windows.Forms.Cursor.Position.Y + 12)
    '        End If
    '        frm.Show()
    '    End If

    'End Sub

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjSite Is Nothing Then Exit Sub

        With mobjSite
            SetSafeValue(.Name, txtName.Text)
            SetSafeValue(.County, txtCounty.Text)
            .StateID = cboState.SelectedStateID
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjSite Is Nothing Then Exit Sub

        With mobjSite
            txtName.Text = GetSafeValue(.Name)
            txtCounty.Text = GetSafeValue(.County)
            cboState.SelectedStateID = GetSafeValue(.StateID)
        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtName.ReadOnly = blnReadOnly
        txtCounty.ReadOnly = blnReadOnly
        cboState.ReadOnly = blnReadOnly

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

#Region "Events"

    Public Shadows Event OnChanged(sender As Object, objSite As Site)

#End Region

#Region "Event Handlers"

    Private Sub cboState_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboState.SelectedIndexChanged

        If mobjSite Is Nothing OrElse cboState.SelectedStateID <> GetSafeValue(mobjSite.StateID) Then
            RaiseEvent OnChanged(Me, Site)
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

        If Not Me.DesignMode Then
            If txtName.Text <> GetSafeValue(mobjSite.Name) Then
                RaiseEvent OnChanged(Me, Site)
            End If
        End If
    End Sub

    Private Sub txtCounty_TextChanged(sender As Object, e As EventArgs) Handles txtCounty.TextChanged

        If Not Me.DesignMode Then
            If txtCounty.Text <> GetSafeValue(mobjSite.County) Then
                RaiseEvent OnChanged(Me, Site)
            End If
        End If
    End Sub

    'Note: un-comment the section below if Site is a sample case and has history
    'Private Sub EditSite_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown

    '    'Site History
    '    If e.Button = System.Windows.Forms.MouseButtons.Right Then
    '        ShowHistory()
    '    End If

    'End Sub

#End Region
End Class
