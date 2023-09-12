'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient

Public Class frmStatusRuleCopy

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.   

        InitializeComponent()

        'AF 02/05/14 - Removed refresh from constructor of statuscombobox - so need to explicitly call it here. 
        cboStatusFrom.Refresh()
        cboStatusTo.Refresh()
    End Sub

#End Region

#Region "Private Methods"

#End Region

#Region "Event Handlers"

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        Cursor = Cursors.WaitCursor

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand("SMS_CopyStatusUpdateRules", conn)

        'send the parameters:
        cmdSQL.Parameters.Add(New SqlParameter("@CopyFromStatus", SqlDbType.Char, 3, ParameterDirection.Input, False, 0,
                                               0, "", DataRowVersion.Proposed,
                                               cboStatusFrom.SelectedStatus.Code.ToString))
        cmdSQL.Parameters.Add(New SqlParameter("@CopyToStatus", SqlDbType.Char, 3, ParameterDirection.Input, False, 10,
                                               0, "", DataRowVersion.Proposed, cboStatusTo.SelectedStatus.Code.ToString))

        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure

            cmdSQL.ExecuteNonQuery()

            MessageBox.Show("Copy completed.", "Copy Status Update Rules", MessageBoxButtons.OK,
                            MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
        Cursor = Cursors.Default

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Sub cboStatusFrom_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboStatusFrom.SelectedIndexChanged

        btnGo.Enabled = cboStatusFrom.SelectedStatus IsNot Nothing AndAlso
                        cboStatusTo.SelectedStatus IsNot Nothing
    End Sub

    Private Sub cboStatusTo_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboStatusTo.SelectedIndexChanged

        btnGo.Enabled = cboStatusFrom.SelectedStatus IsNot Nothing AndAlso
                        cboStatusTo.SelectedStatus IsNot Nothing
    End Sub

#End Region
End Class