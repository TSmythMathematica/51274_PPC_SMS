'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data


Public Class frmSurveySettings

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmSurveySettings_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsMessageLabel.Text = ""
        LoadInstrumentTypes()
    End Sub

    Private Sub cbInstrumentTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cbInstrumentTypes.SelectedIndexChanged
        tsMessageLabel.Text = ""
        LoadSurveySettings()
    End Sub


    Private Sub dgvSurveySettings_DoubleClick(sender As Object, e As EventArgs) Handles dgvSurveySettings.DoubleClick

        Try
            Dim intVariableID As Integer = CInt(dgvSurveySettings.SelectedRows(0).Cells.Item("VariableID").Value)
            Dim strVariable As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("Variable").Value)
            Dim strDescription As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("Description").Value)
            Dim strValue As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("Value").Value)
            Dim strValueAllowed As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("AllowedValue").Value)
            Dim strExperimentGroup As String =
                    CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("ExperimentGroup").Value)
            Dim strIsActive As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("IsActive").Value)
            Dim strCreatedBy As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("CreatedBy").Value)
            Dim dtCreatedOn As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("CreatedOn").Value)
            Dim strLastModifiedBy As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("LastModifiedBy").Value)
            Dim dtLastModifiedOn As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("LastModifiedOn").Value)
            Dim intRound As Integer = CInt(dgvSurveySettings.SelectedRows(0).Cells.Item("Round").Value)
            Dim intSSID As Integer = CInt(dgvSurveySettings.SelectedRows(0).Cells.Item("SSID").Value)
            Dim strInstrumentType As String = CStr(dgvSurveySettings.SelectedRows(0).Cells.Item("InstrumentType").Value)


            Dim _
                frm As _
                    New frmSurveySettingsUpdate(intVariableID, strVariable, strDescription, strValue, strValueAllowed,
                                                strExperimentGroup, strIsActive, strCreatedBy, dtCreatedOn,
                                                strLastModifiedBy, dtLastModifiedOn, intRound, intSSID,
                                                strInstrumentType)
            frm.ShowDialog()

            LoadSurveySettings()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading Survey Settings data for update",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

#End Region

#Region "Private Methods"

    Private Sub LoadInstrumentTypes()
        Try
            Me.cbInstrumentTypes.DataSource = GetDataTable("ISMS_BlaiseSampleLoad@InstrumentTypeID")
            Me.cbInstrumentTypes.DisplayMember = "Display"
            Me.cbInstrumentTypes.ValueMember = "Value"
            Me.cbInstrumentTypes.SelectedIndex = - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error Loading Instrument Types....",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub LoadSurveySettings()
        Try
            If cbInstrumentTypes.ValueMember <> "" Then
                Dim ds As DataSet = SqlHelper.ExecuteDataset(Project.ConnectionString,
                                                             CommandType.StoredProcedure,
                                                             "ISMS_SurveySettings_Select",
                                                             New SqlParameter("@InstrumentTypeID",
                                                                              cbInstrumentTypes.SelectedValue))
                Dim dt As DataTable = ds.Tables(0)
                Me.dgvSurveySettings.DataSource = dt

                Me.dgvSurveySettings.ReadOnly = True
                Me.dgvSurveySettings.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
                Me.dgvSurveySettings.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Me.dgvSurveySettings.MultiSelect = False

                Me.dgvSurveySettings.Columns("InstrumentType").Visible = False
                Me.dgvSurveySettings.Columns("SSID").Visible = False

                tsRecordsLabel.Text = Me.dgvSurveySettings.RowCount & " Records"
                If Me.dgvSurveySettings.RowCount > 0 Then
                    tsMessageLabel.Text = "Double-click on row to Update Survey Settings Data"
                End If

                dt.Dispose()
                ds.Dispose()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading Survey Settings data...",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


#End Region
End Class