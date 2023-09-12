Imports MPR.SMS.Data

Public Class frmInterviewWeeks

#Region "Private Methods"

    Private Sub RefreshForm()

        Dim objWeeks As New InterviewWeeks

        lstWeeks.Items.Clear()
        lstWeeks.DisplayMember = "DisplayWeek"

        For Each objWeek As InterviewWeek In objWeeks
            lstWeeks.Items.Add(objWeek)
            If txtStartDate.Text.Length = 0 OrElse
               CType(txtStartDate.Text, Date) > CType(objWeek.WeekBeg, Date) Then
                txtStartDate.Text = GetSafeDate(objWeek.WeekBeg)
            End If
        Next
        txtWeeks.Text = CStr(objWeeks.Count)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        FormValidator.Validate()
        If FormValidator.IsValid() Then
            Cursor = Cursors.WaitCursor

            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("SMS_CreateInterviewWeeks", conn)

            'send the parameters:
            cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@WeekBeg", SqlDbType.DateTime, 8, ParameterDirection.Input,
                                                             False, 0, 0, "", DataRowVersion.Proposed,
                                                             GetSafeDate(CType(txtStartDate.Text, Date))))
            cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@NumWeeks", SqlDbType.Int, 4, ParameterDirection.Input,
                                                             False, 10, 0, "", DataRowVersion.Proposed,
                                                             CInt(txtWeeks.Text)))

            Try
                conn.Open()
                cmdSQL.CommandType = CommandType.StoredProcedure

                cmdSQL.ExecuteNonQuery()

                RefreshForm()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()

        End If
    End Sub

    Private Sub frmInterviewWeeks_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        RefreshForm()
    End Sub

    Private Sub ValidatorWeeks_Validating(ByVal sender As Object,
                                          ByVal e As Windows.Forms.Validation.CustomValidator.ValidatingCancelEventArgs) _
        Handles ValidatorWeeks.Validating

        e.Valid = (IsNumeric(txtWeeks.Text) AndAlso CInt(txtWeeks.Text) >= 1 AndAlso CInt(txtWeeks.Text) <= 52)
    End Sub

#End Region
End Class