Imports System.Data.SqlClient
Imports System.Xml
Imports System.Configuration
Imports System.Collections.Generic

'This is NOT auto-Generated, it will not be overwritten by the data access wizard
'These methods are generally used for Silverlight Field Management

Namespace BaseClasses

    Public Class CustomMethods

        Public Sub UpdateInterviewTracking(ByVal EmployeeID As Integer)

            Dim EmplId As String
            EmplId = EmployeeID.ToString()
            Dim ProjectCd As String
            ProjectCd = Project.ProjectCode

            TransferDeltekDataSet("spGetWeeklyTimeSheetInfo", "tmpFMInterviewerHours", EmplId, ProjectCd)

            TransferDeltekDataSet("spGetExpenseInfoByEmplId", "tmpFMInterviewerExpenses", EmplId, ProjectCd)

            Dim MyParamArray As SqlParameter() = { _
            New SqlParameter("@EmplId", SqlDbType.NVarChar, 5, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, EmployeeID)}

            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("FM_UpdateInterviewerTracking", conn)

            'send the parameters:
            cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@EmployeeID", SqlDbType.NVarChar, 10, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, EmployeeID.ToString()))

            Try
                conn.Open()
                cmdSQL.CommandType = CommandType.StoredProcedure

                cmdSQL.ExecuteNonQuery()
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                conn.Close()
                cmdSQL.Dispose()
            End Try

        End Sub

        Public Function getCaseAssignments(ByVal strSQLWhere As String) As DataSet
            Dim mydataset As New DataSet()
            Dim strtreeview As New System.Text.StringBuilder '= New System.Text.StringBuilder();

            Try
                Dim MyParamArray As SqlParameter() = { _
                       New SqlParameter("@WHERE", SqlDbType.VarChar, 2000, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, strSQLWhere)}
                mydataset = SqlHelper.ExecuteDataset(Project.ConnectionString, "SMS_SearchCaseAssignments", MyParamArray)

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try

            Return mydataset
        End Function

        Public Sub TransferDeltekDataSet(Source As String, Destination As String, EmployeeID As String, ProjectCode As String)

            Dim DeltekConn As New SqlConnection(ConfigurationManager.ConnectionStrings("Deltek").ConnectionString)
            Dim cmdSQL As New SqlCommand(Source, DeltekConn)
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.Parameters.Add(New SqlParameter("@EmplId", SqlDbType.NVarChar, 5, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, EmployeeID))
            cmdSQL.Parameters.Add(New SqlParameter("@ProjNum", SqlDbType.NVarChar, 5, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, ProjectCode))
            Dim daDeltekTS As SqlDataAdapter = Nothing
            Dim TransferDT As DataTable = Nothing
            Try
                DeltekConn.Open()
                daDeltekTS = New SqlDataAdapter(cmdSQL)
                daDeltekTS.AcceptChangesDuringFill = False
                TransferDT = New DataTable()
                daDeltekTS.Fill(TransferDT)

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                DeltekConn.Close()
                daDeltekTS.Dispose()
                cmdSQL.Dispose()
            End Try

            Dim SMSConn As New SqlConnection(ConfigurationManager.ConnectionStrings("MPR.SMS").ConnectionString)
            Dim SMSSQLcmdDelete As New SqlClient.SqlCommand("Delete from " & Destination, SMSConn)
            Dim SMSSQlCmd As New SqlCommand("select * from " & Destination, SMSConn)
            Dim daTempIntHours As SqlDataAdapter = Nothing
            Dim cmd As SqlCommandBuilder = Nothing

            Try
                SMSConn.Open()

                SMSSQLcmdDelete.ExecuteNonQuery()

                daTempIntHours = New SqlDataAdapter(SMSSQlCmd)
                cmd = New SqlCommandBuilder(daTempIntHours)
                daTempIntHours.InsertCommand = cmd.GetInsertCommand
                daTempIntHours.Update(TransferDT)

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Finally
                SMSConn.Close()
                daTempIntHours.Dispose()
                cmd.Dispose()
                TransferDT.Dispose()
            End Try
        End Sub

        Public Function TeacherDisplayName(ByVal ConnectionString As String, ByVal CaseID As String) As String

            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "SELECT LastName + ', ' + FirstName FROM tblPerson WHERE CaseID= " & CaseID
            cmdToExecute.CommandType = CommandType.Text

            Dim objSqlConnection As New SqlConnection(ConnectionString)
            objSqlConnection.Open()

            cmdToExecute.Connection = objSqlConnection

            Dim dr As SqlDataReader = cmdToExecute.ExecuteReader

            If dr.Read Then
                TeacherDisplayName = CStr(dr(0))
            Else
                TeacherDisplayName = ""
            End If

            dr.Close()
            objSqlConnection.Close()

        End Function

        Public Sub UpdateweeksbyDate_NoofWeeks(ByVal weekbeg As String, ByVal noofweeks As String)
            'Dim testing As New Project
            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("SMS_CreateInterviewWeeks", conn)

            'send the parameters:
            cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@WeekBeg", SqlDbType.DateTime, 8, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, weekbeg))
            cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@NumWeeks", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, CInt(noofweeks)))

            Try
                conn.Open()
                cmdSQL.CommandType = CommandType.StoredProcedure

                cmdSQL.ExecuteNonQuery()

                'RefreshForm()
            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()
        End Sub

        Public Function getTreeViewXML(ByVal viewstaffby As Integer) As System.Text.StringBuilder
            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("FM_GetTreeView", conn)
            cmdSQL.CommandType = CommandType.StoredProcedure
            'Dim dtTreeXML As DataTable = New DataTable("xmlTreeViewtbl")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdSQL)
            Dim mydataset As New DataSet()
            Dim strtreeview As New System.Text.StringBuilder '= New System.Text.StringBuilder();
            Dim reader As System.Xml.XmlReader
            If viewstaffby = 1 Or viewstaffby = 2 Then
                strtreeview.AppendLine("<TreeView>")
            End If
            Try
                cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, -1))
                cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@viewby", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, viewstaffby))
                conn.Open()


                reader = cmdSQL.ExecuteXmlReader

                While reader.Read
                    strtreeview.Append(reader.ReadOuterXml)
                End While

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()

            If viewstaffby = 1 Or viewstaffby = 2 Then
                getTreeViewOrphans(strtreeview)
                strtreeview.AppendLine("</TreeView>")
            End If
            Return strtreeview

        End Function

        Private Sub getTreeViewOrphans(ByRef strtreeview As System.Text.StringBuilder)
            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("FM_GetTreeOrphans", conn)
            cmdSQL.CommandType = CommandType.StoredProcedure



            Dim reader As System.Xml.XmlReader
            Try
                cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, -1))
                conn.Open()


                reader = cmdSQL.ExecuteXmlReader

                While reader.Read
                    strtreeview.Append(reader.ReadOuterXml)
                End While

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()




        End Sub

        Public Function getHistory(ByVal id As Integer, ByVal tbltype As String) As System.Text.StringBuilder
            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("FM_GetHistory", conn)
            cmdSQL.CommandType = CommandType.StoredProcedure


            Dim strhistoryxml As New System.Text.StringBuilder("")
            Dim reader As System.Xml.XmlReader
            Try
                cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, -1))
                cmdSQL.Parameters.Add(New SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, id))
                cmdSQL.Parameters.Add(New SqlParameter("@tbltype", SqlDbType.VarChar, 400, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, tbltype))
                conn.Open()


                reader = cmdSQL.ExecuteXmlReader

                While reader.Read
                    strhistoryxml.Append(reader.ReadOuterXml)
                End While

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()

            Return strhistoryxml
        End Function

        Public Function getcboValues(ByVal filtertype As String) As Dictionary(Of String, String)
            Dim dictcbovalues As Dictionary(Of String, String) = New Dictionary(Of String, String)
            Dim dsDropdownprefilled As New DataSet

            Dim dsprevvaluetable() As String = {"Prefilltable"}

            Dim paramsforsqlvalue As SqlParameter() = { _
                  New SqlParameter("@filtertype", filtertype)
              }
            MPR.SMS.Data.SqlHelper.FillDataset(Project.ConnectionString, "FM_FillCboValues", dsDropdownprefilled, dsprevvaluetable, paramsforsqlvalue)

            For Each dr As DataRow In dsDropdownprefilled.Tables(0).Rows
                dictcbovalues.Add(dr.Item(0).ToString(), dr.Item(1).ToString())
            Next

            Return dictcbovalues
        End Function

        Public Function getJAWSInterviewers(Optional ByVal interviewerid As Integer = -1) As System.Text.StringBuilder

            Dim conn As New SqlClient.SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlClient.SqlCommand("FM_get_JASS_Interviewers", conn)
            cmdSQL.CommandType = CommandType.StoredProcedure

            Dim strjawsinterviewersxml As New System.Text.StringBuilder("")
            Dim reader As System.Xml.XmlReader
            Try
                If interviewerid <> -1 Then
                    cmdSQL.Parameters.Add(New SqlParameter("@interviewerid", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, interviewerid))
                End If
                'cmdSQL.Parameters.Add(New SqlClient.SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, -1))
                'cmdSQL.Parameters.Add(New SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, id))
                'cmdSQL.Parameters.Add(New SqlParameter("@tbltype", SqlDbType.VarChar, 400, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, tbltype))
                conn.Open()


                reader = cmdSQL.ExecuteXmlReader

                While reader.Read
                    strjawsinterviewersxml.Append(reader.ReadOuterXml)
                End While

            Catch ex As Exception
                'MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
            'Cursor = Cursors.Default

            conn.Close()
            cmdSQL.Dispose()

            Return strjawsinterviewersxml
        End Function

        Public ReadOnly Property Project() As Project
            Get
                Return Data.Project.GetInstance()
            End Get
        End Property



    End Class

End Namespace
