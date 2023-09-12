'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Text
Imports MPR.SMS.Data
Imports MPR.SMS.DocumentProcessing

Public Class frmConfirmitReport
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.   

        InitializeComponent()

        Me.CenterToScreen()

        Dim objInst As InstrumentType

        Dim objInstTypes As InstrumentTypes = Project.InstrumentTypes
        lstInstruments.DisplayMember = "Description"

        For Each objInst In objInstTypes
            If GetSafeValue(objInst.SurveyID) <> String.Empty Then
                lstInstruments.Items.Add(objInst)
            End If
        Next

        If lstInstruments.Items.Count > 0 Then
            lstInstruments.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim objInst As InstrumentType = CType(lstInstruments.SelectedItem, InstrumentType)

        If objInst IsNot Nothing Then
            ReadFromConfirmit(GetSafeValue(objInst.SurveyID), GetSafeValue(objInst.InstrumentTypeID))
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub ReadFromConfirmit(SurveyID As String, InstrumentTypeID As Integer)
        Dim strConfirmitVar As String = ""
        Dim strSMSVar As String = ""
        Dim isCompare As String = ""
        Try
            Cursor = Cursors.WaitCursor

            Dim fieldList As List(Of String) = Nothing

            Dim dsConfirmitVariables As DataSet = SqlHelper.ExecuteDataset(Project.ConnectionString,
                                             CommandType.StoredProcedure,
                                             "SMS_ConfirmitDiscrepancyVariables")
            Dim table As DataTable = dsConfirmitVariables.Tables(0)
            Dim CurRows() As DataRow, CurRow As DataRow

            Dim intConfirmitRowCnt As Integer = table.Rows.Count
            fieldList = New List(Of String)(intConfirmitRowCnt)

            CurRows = table.Select
            For Each CurRow In CurRows
                strConfirmitVar = CurRow("ConfirmitVariable").ToString
                fieldList.Add(strConfirmitVar)
            Next
            dsConfirmitVariables.Dispose()

            Dim dt As DataTable
            dt =
                APITest.Data.GetForProject(Project.APIUser, Project.APIPwd, True, SurveyID, fieldList, String.Empty).
                    Tables(0)
            Dim sbXml As New StringBuilder

            For Each row As DataRow In dt.Rows

                For index As Integer = 0 To intConfirmitRowCnt - 1
                    If index = 0 Then
                        sbXml.Append(String.Format("<row>"))
                    End If

                    Dim fieldVar As String = fieldList(index)

                    sbXml.Append(String.Format("<" & fieldVar & ">{0}</" & fieldVar & ">", row(fieldVar).ToString()))

                    If index = intConfirmitRowCnt - 1 Then
                        sbXml.Append(String.Format("</row>"))
                    End If
                Next

            Next

            Dim i As Integer = SqlHelper.ExecuteNonQuery(Project.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SMS_ConfirmitDiscrepancyDelete")

            Dim dsReport As DataSet = New DataSet

            Dim dsSMSVariables As DataSet = SqlHelper.ExecuteDataset(Project.ConnectionString,
                                             CommandType.StoredProcedure,
                                             "SMS_ConfirmitDiscrepancyVariables")
            Dim table2 As DataTable = dsSMSVariables.Tables(0)
            Dim CurRows2() As DataRow, CurRow2 As DataRow

            CurRows2 = table2.Select
            For Each CurRow2 In CurRows2
                strSMSVar = CurRow2("SMSVariable").ToString
                isCompare = CurRow2("IsCompare").ToString()
                If isCompare = "True" Then
                    Dim dsDiscrepancy As DataSet
                    dsDiscrepancy = SqlHelper.ExecuteDataset(Project.ConnectionString,
                                                  CommandType.StoredProcedure,
                                                  "SMS_ConfirmitDiscrepancyCompare",
                                                  New SqlParameter("@InstTypeID", InstrumentTypeID),
                                                  New SqlParameter("@SMSVariable", strSMSVar),
                                                  New SqlParameter("@xml", sbXml.ToString()))
                    Dim tableDiscrepancy As DataTable = dsDiscrepancy.Tables(0).Copy()
                    tableDiscrepancy.TableName = strSMSVar
                    dsReport.Tables.Add(tableDiscrepancy)
                    dsDiscrepancy.Dispose()
                End If
            Next

            dsSMSVariables.Dispose()

            Utility.DataSetToExcel(dsReport, Nothing)

        Catch ex As Exception

            'SetStatusMsg("Error occurred. Please check inputs.")
            'throw;
            MessageBox.Show(ex.Message)
        Finally
            Cursor = Cursors.Arrow
        End Try
    End Sub
End Class