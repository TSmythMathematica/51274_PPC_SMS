'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

Public Class frmManagementSummary
    Private objMsgOfTheDay As Setting

    Private Property MsgOfTheDay As Setting
        Get
            Return objMsgOfTheDay
        End Get
        Set
            objMsgOfTheDay = value
        End Set
    End Property

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.   

        InitializeComponent()

        Me.CenterToScreen()

        Dim objMsgDay As Setting = Project.Settings.MessageOfTheDay
        If objMsgDay IsNot Nothing Then
            txtMessage.Text = objMsgDay.Value.ToString
            MsgOfTheDay = objMsgDay
        End If

        Dim dr As DataSet = Nothing

        Try

            dr = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.StoredProcedure, "SMS_AdminCounts")

            Dim dgv(dr.Tables.Count) As DataGridView
            Dim h As Integer

            For i As Integer = 0 To dr.Tables.Count - 1
                dgv(i) = New DataGridView
                CType(dgv(i), ISupportInitialize).BeginInit()
                Me.MyPanel.Controls.Add(dgv(i))

                dgv(i).ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
                dgv(i).Dock = DockStyle.Top

                If i = 0 Then
                    dgv(i).Location = New Point(0, 0)
                Else
                    dgv(i).Location = New Point(0, dgv(i - 1).Location.Y + dgv(i - 1).Height)
                End If

                dgv(i).AllowUserToAddRows = False
                dgv(i).AllowUserToDeleteRows = False
                AddHandler CType(dgv(i), DataGridView).CellLeave, AddressOf OnBeginEdit


                dgv(i).Height = 100 + CInt(dr.Tables(i).Rows.Count*2)
                dgv(i).TabIndex = i
                CType(dgv(i), ISupportInitialize).EndInit()

                dgv(i).DataSource = dr.Tables(i)

                'If dr.Tables(i).Columns.Count = 1 Then
                '    dgv(i).Columns(0).Width = dgv(i).Columns(0).HeaderText.Length * 7
                '    dgv(i).AutoSize = True
                'End If
                AutoSizeGrid(dgv(i))
                dgv(i).AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                h += dgv(i).Height

            Next

            If h > Screen.PrimaryScreen.Bounds.Height - 180 Then h = Screen.PrimaryScreen.Bounds.Height - 180
            'MyPanel.Height = h
            Me.Height = h + 180
            Me.CenterToScreen()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        Finally
            dr.Dispose()
        End Try
    End Sub

    Private Sub OnBeginEdit(sender As Object, e As DataGridViewCellEventArgs)
        CType(sender, DataGridView).CancelEdit()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub AutoSizeGrid(dgv As DataGridView)

        Dim i As Integer = 0

        Do While (i < dgv.Columns.Count)
            AutoSizeCol(dgv, i)
            i += 1
        Loop
    End Sub

    Private Sub AutoSizeCol(dgv As DataGridView, col As Integer)

        Dim size As SizeF

        Dim width As Single = 0

        Dim g As Graphics = Graphics.FromHwnd(dgv.Handle)

        Dim sf As New StringFormat(StringFormat.GenericTypographic)

        size = g.MeasureString(dgv.Columns(col).HeaderText, dgv.Font, 500, sf)

        width = size.Width

        For i As Integer = 0 To CType(dgv.DataSource, DataTable).Rows.Count - 1

            size = g.MeasureString(dgv(col, i).Value.ToString, dgv.Font, 500, sf)
            If (size.Width > width) Then
                width = size.Width
            End If
        Next

        g.Dispose()

        Dim w As Integer = CType(width, Integer) + 16

        dgv.Columns(col).Width = w
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim blnSuccess As Boolean = False

        Try
            If MsgOfTheDay Is Nothing Then
                MsgOfTheDay = New Setting("MsgOfTheDay", txtMessage.Text, "Appears in the main menu Help window.")
                blnSuccess = MsgOfTheDay.Insert
            Else
                MsgOfTheDay.Value = txtMessage.Text
                blnSuccess = MsgOfTheDay.Update
            End If

            If blnSuccess Then
                Project.Settings.Add(MsgOfTheDay)

                Dim dlgResult As DialogResult = DialogResult.No
                dlgResult = MessageBox.Show("Message of the day has been updated.  Return to main menu?",
                                            Project.ShortName & " – Save changes?", MessageBoxButtons.OKCancel,
                                            MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

                If dlgResult = DialogResult.OK Then
                    Me.Close()
                End If

            Else
                MessageBox.Show("Message of the day failed to update.  Please contact your project administrator.",
                                Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
    End Sub
End Class