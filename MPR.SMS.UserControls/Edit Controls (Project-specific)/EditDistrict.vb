'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class EditDistrict

#Region "Private fields"

    'Private mobjCase As [Case]
    'Private mobjPerson As Person = Nothing
    Private mobjDistrict As District = Nothing

    Private mblnReadOnly As Boolean = False
    Private mblnLastNameRequired As Boolean = False

#End Region

#Region "Public Methods"

    Public Sub ShowHistory()

        If mobjDistrict IsNot Nothing AndAlso
           Not GetSafeValue(mobjDistrict.CaseID).Equals(0) Then
            Dim frm As New frmDisplayHistory(mobjDistrict)
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

#Region "Public Properties"

    Public Property District As District
        Get
            FillProperties()
            Return mobjDistrict
        End Get
        Set
            mobjDistrict = value
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

#Region "Private Methods"

    Private Sub FillProperties()

        If mobjDistrict Is Nothing Then Exit Sub

        With mobjDistrict
            SetSafeValue(.LEAID, txtLEAID.Text)
            SetSafeValue(.Name, txtName.Text)
            .SiteID = cboSite.SelectedSiteID
        End With
    End Sub

    Private Sub FillUserControl()

        If mobjDistrict Is Nothing Then Exit Sub

        With mobjDistrict
            txtLEAID.Text = GetSafeValue(.LEAID)
            txtName.Text = GetSafeValue(.Name)
            cboSite.SelectedSiteID = GetSafeValue(.SiteID)

            vwSchools.DataSource = "SELECT * FROM vwSchoolsByDistrict WHERE DistrictID = " & GetSafeValue(.DistrictID)
            vwSchools.Columns(0).Visible = False

        End With
    End Sub

    Private Sub EnableUserControl(blnReadOnly As Boolean)

        txtName.ReadOnly = blnReadOnly
        txtLEAID.ReadOnly = blnReadOnly
        cboSite.ReadOnly = blnReadOnly

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

    Public Shadows Event OnChanged(sender As Object, objDistrict As District)

#End Region

#Region "Event Handlers"

    Private Sub cboSite_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSite.SelectedIndexChanged

        If cboSite.SelectedSiteID <> GetSafeValue(mobjDistrict.SiteID) Then
            RaiseEvent OnChanged(Me, District)
        End If
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged

        If Not Me.DesignMode Then
            If txtName.Text <> GetSafeValue(mobjDistrict.Name) Then
                RaiseEvent OnChanged(Me, District)
            End If
        End If
    End Sub

    Private Sub txtLEAID_TextChanged(sender As Object, e As EventArgs) Handles txtLEAID.TextChanged

        If Not Me.DesignMode Then
            If txtLEAID.Text <> GetSafeValue(mobjDistrict.LEAID) Then
                RaiseEvent OnChanged(Me, District)
            End If
        End If
    End Sub

    Private Sub EditDistrict_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        'District History
        If e.Button = MouseButtons.Right Then
            ShowHistory()
        End If
    End Sub

#End Region
End Class
