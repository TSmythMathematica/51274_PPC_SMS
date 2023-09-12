'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditSchool

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjSchool As School = Nothing

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
    '        FillUserControl()
    '    End Set
    'End Property

    'Public Property Person() As Person
    '    Get
    '        FillProperties()
    '        Return mobjPerson
    '    End Get
    '    Set(ByVal value As Person)
    '        mobjPerson = value
    '        FillUserControl()
    '    End Set
    'End Property
    Public Property School As School
        Get
            FillProperties()
            Return mobjSchool
        End Get
        Set
            mobjSchool = value
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

    Public Sub ShowHistory()

        If mobjSchool IsNot Nothing AndAlso
           Not GetSafeValue(mobjSchool.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjSchool)
            frm.Width = Me.Parent.Width
            If Cursor.Position.Y + frm.Height + 12 > Screen.GetWorkingArea(Me).Height Then
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y - 12 - frm.Height)
            Else
                frm.Location = New Point(Me.ParentForm.Left + Me.Parent.Left + 4, Cursor.Position.Y + 12)
            End If
            frm.Show()
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjSchool Is Nothing Then Exit Sub

        With mobjSchool
            SetSafeValue(.NCES, txtNCES.Text)
            SetSafeValue(.Name, txtName.Text)
            SetSafeValue(.GradeLevels, txtGradeLevels.Text)
            .DistrictID = cboDistrict.SelectedDistrictID
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjSchool Is Nothing Then Exit Sub

        With mobjSchool
            txtNCES.Text = GetSafeValue(.NCES)
            txtName.Text = GetSafeValue(.Name)
            txtGradeLevels.Text = GetSafeValue(.GradeLevels)
            cboDistrict.SelectedDistrictID = GetSafeValue(.DistrictID)

            vwClassrooms.DataSource = "SELECT * FROM vwClassroomsBySchool WHERE SchoolID = " & GetSafeValue(.SchoolID)
            vwClassrooms.Columns(0).Visible = False

        End With
        EnableUserControl([ReadOnly])
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtName.ReadOnly = blnReadOnly
        txtNCES.ReadOnly = blnReadOnly
        txtGradeLevels.ReadOnly = blnReadOnly
        cboDistrict.ReadOnly = blnReadOnly Or (cboDistrict.SelectedDistrictID <> 0)

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

    Public Shadows Event OnChanged(sender As Object, objSchool As School)

#End Region

#Region "Event Handlers"

    Private Sub cboDistrict_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDistrict.SelectedIndexChanged

        If cboDistrict.SelectedDistrictID <> GetSafeValue(mobjSchool.DistrictID) Then
            RaiseEvent OnChanged(Me, School)
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

        If Not Me.DesignMode Then
            If txtName.Text <> GetSafeValue(mobjSchool.Name) Then
                RaiseEvent OnChanged(Me, School)
            End If
        End If
    End Sub

    Private Sub txtGradeLevels_TextChanged(sender As Object, e As EventArgs) Handles txtGradeLevels.TextChanged

        If Not Me.DesignMode Then
            If txtGradeLevels.Text <> GetSafeValue(mobjSchool.GradeLevels) Then
                RaiseEvent OnChanged(Me, School)
            End If
        End If
    End Sub

    Private Sub txtNCES_TextChanged(sender As Object, e As EventArgs) Handles txtNCES.TextChanged

        If Not Me.DesignMode Then
            If txtNCES.Text <> GetSafeValue(mobjSchool.NCES) Then
                RaiseEvent OnChanged(Me, School)
            End If
        End If
    End Sub

    Private Sub EditSchool_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

#End Region
End Class
