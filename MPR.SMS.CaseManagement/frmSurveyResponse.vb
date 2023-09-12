'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls


Public Class frmSurveyResponse
    Inherits Form

#Region "Private Fields"

    Private ReadOnly intPreResponseID As Integer
    Private ReadOnly strAllowedValue As String = String.Empty
    Private ReadOnly strSurType As String = String.Empty
    Private ReadOnly intInstrumentTypeID As Integer = 0
    Private ReadOnly strOption As String = String.Empty
    Private ReadOnly strUserName As String = String.Empty
    Private strDocFileName As String = String.Empty

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub


    Public Sub New(strMPRID As String,
                   strQNum As String,
                   strValue As String,
                   strNotes As String,
                   strVariable As String,
                   strMode As String,
                   strVariableID As String,
                   strDesc As String,
                   strCreatedBy As String,
                   dtCreatedOn As String,
                   strLastModifiedBy As String,
                   dtLastModifiedOn As String,
                   intResponseID As Integer,
                   strValueAllowed As String,
                   strSurveyType As String,
                   intTypeID As Integer,
                   strOpt As String,
                   strUser As String,
                   strMessage As String)
        Try
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Me.txtMPRID.Text = strMPRID
            Me.txtNote.Text = ""
            Me.txtQNum.Text = strQNum
            Me.txtValue.Text = strValue
            Me.txtVariableID.Text = strVariableID
            Me.txtVariableName.Text = strVariable
            Me.txtDesc.Text = strDesc
            Me.txtMode.Text = strMode
            Me.txtCreatedBy.Text = strCreatedBy
            Me.txtCreatedOn.Text = dtCreatedOn.ToString
            Me.txtLastModifiedBy.Text = strLastModifiedBy
            Me.txtLastModifiedOn.Text = dtLastModifiedOn.ToString
            intPreResponseID = intResponseID
            strSurType = strSurveyType
            intInstrumentTypeID = intTypeID
            strOption = strOpt
            strUserName = strUser
            Me.txtMessage.Text = strMessage

            If Trim(strMessage) <> "" Then
                Me.txtMessage.BackColor = Color.Yellow
            End If

            Me.CenterToScreen()


            Me.Text = "SMS - [" & Project.ShortName.ToString & "] - " & Me.Text & " - " & strSurType

            strAllowedValue = strValueAllowed
            Select Case UCase(Microsoft.VisualBasic.Left(strAllowedValue, 3))
                Case "CHR"
                    Me.txtAllowedValue.Text = "Maximum length " &
                                              Mid(strAllowedValue, 4, Len(strAllowedValue) - 3).ToString &
                                              " characters."
                Case "INT"
                    If Mid(strAllowedValue, 4, Len(strAllowedValue) - 3).ToString = "10" Then
                        Me.txtAllowedValue.Text = "10 digits Phone Number."
                    Else
                        Me.txtAllowedValue.Text = "Integer value upto " &
                                                  Mid(strAllowedValue, 4, Len(strAllowedValue) - 3).ToString &
                                                  " digits."
                    End If
                Case "PER"
                    Me.txtAllowedValue.Text = "Integer value upto 3 digits"
                Case Else
                    Me.txtAllowedValue.Text = strAllowedValue
            End Select

            If strOption = "By Variable" Then
                Cursor = Cursors.WaitCursor
                AddSRDEELockRecord(txtMPRID.Text, strUserName, intInstrumentTypeID)
                Cursor = Cursors.Default
            End If

            Me.btnOK.Enabled = False

            'If UCase(Me.txtMode.Text) = "MAIL" And Me.GetScannedDocumentFileName = True Then
            '    Me.lnkQuestionnaire.Visible = True
            'End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error getting data..", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmSurveyResponse_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnOK.Enabled = True Then
            e.Cancel = (ConfirmSave() = DialogResult.Cancel)
        End If
        If strOption = "By Variable" Then
            Cursor = Cursors.WaitCursor
            DeleteSRDEELockRecord(txtMPRID.Text, strUserName, intInstrumentTypeID)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        Me.Close()
    End Sub

    Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click

        Dim frm As New frmDisplayHistory("Survey Preliminary Response Data", intPreResponseID, strSurType)
        frm.Width = Me.Width
        frm.Location = New Point((Me.Location).X, Me.PointToScreen(Me.Location).Y)   ' docks at the bottom
        frm.ShowDialog()
    End Sub

    Private Sub txtValue_LostFocus(sender As Object, e As EventArgs) Handles txtValue.LostFocus
        If _
            UCase(Microsoft.VisualBasic.Left(strAllowedValue, 3)) <> "CHR" AndAlso
            UCase(Microsoft.VisualBasic.Left(strAllowedValue, 3)) <> "INT" AndAlso
            UCase(Microsoft.VisualBasic.Left(strAllowedValue, 3)) <> "PER" Then
            Me.txtValue.Text = Me.txtValue.Text.ToUpper()
        End If
    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged
        If Me.txtValue.Modified Then
            Me.txtLastModifiedBy.Text = CurrentUser.Name
            Me.txtLastModifiedOn.Text = CStr(Now())
        End If
    End Sub

    Private Sub txtNote_TextChanged(sender As Object, e As EventArgs) Handles txtNote.TextChanged
        If Trim(Me.txtNote.Text.ToString) <> String.Empty Then
            If Me.txtNote.Modified = True Then
                Me.btnOK.Enabled = True
                Me.txtLastModifiedBy.Text = CurrentUser.Name
                Me.txtLastModifiedOn.Text = CStr(Now())
            End If
        End If
    End Sub

    'Private Sub lnkQuestionnaire_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkQuestionnaire.LinkClicked
    '    Try
    '        Cursor = Cursors.WaitCursor
    '        If strDocFileName <> "" Then
    '            If File.Exists(strDocFileName) = True Then
    '                System.Diagnostics.Process.Start(strDocFileName)
    '            Else
    '                MessageBox.Show("Cannot open Questionnaire file. Please check whether this Questionnaire is scanned or not: " & strDocFileName, Project.ShortName & " - File Missing!", MessageBoxButtons.OK)
    '            End If
    '        Else
    '            MessageBox.Show("Cannot open Questionnaire file.", Project.ShortName & " - File Missing!", MessageBoxButtons.OK)
    '        End If
    '        Cursor = Cursors.Default

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message, Project.ShortName & " - Error retrieving scanned questionnaire image", MessageBoxButtons.OK)
    '        Cursor = Cursors.Default
    '    End Try
    'End Sub


    Private Sub UpdateSurveyResponse()
        Cursor = Cursors.WaitCursor

        Dim conn As New SqlConnection(Project.ConnectionString)

        Dim cmdSQL As SqlCommand = New SqlCommand()

        If intInstrumentTypeID > 0 Then
            cmdSQL.CommandText = "SRDEE_Update"
        Else
            cmdSQL.CommandText = ""
        End If

        cmdSQL.Connection = conn


        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.Parameters.Add(New SqlParameter("@PreResponseID", SqlDbType.Int, 4, ParameterDirection.Input, False,
                                                   10, 0, "", DataRowVersion.Proposed, intPreResponseID))
            cmdSQL.Parameters.Add(New SqlParameter("@Value", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 10,
                                                   0, "", DataRowVersion.Proposed, GetSafeValue(Me.txtValue.Text)))
            cmdSQL.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 2000, ParameterDirection.Input, False,
                                                   10, 0, "", DataRowVersion.Proposed, GetSafeValue(Me.txtNote.Text)))
            cmdSQL.Parameters.Add(New SqlParameter("@User", SqlDbType.VarChar, 32, ParameterDirection.Input, False, 10,
                                                   0, "", DataRowVersion.Proposed, CurrentUser.Name))

            cmdSQL.ExecuteNonQuery()

            MessageBox.Show("Changes saved successfully.", Project.ShortName)

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error Saving...", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try
        Cursor = Cursors.Default
        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Private Function ConfirmSave() As DialogResult

        Dim dr As DialogResult = MessageBox.Show("Do you want to save the changes you have made?",
                                                 Project.ShortName & " – Save changes?", MessageBoxButtons.YesNoCancel,
                                                 MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        Try
            If dr = DialogResult.Yes Then
                If CheckValue() = True Then
                    If Trim(Me.txtNote.Text.ToString) <> String.Empty AndAlso Me.txtNote.Modified = True Then
                        Me.UpdateSurveyResponse()
                        Me.btnOK.Enabled = False
                    Else
                        MessageBox.Show("Cannot save record without a Note. Please enter a note.",
                                        Project.ShortName & " - Add Response Note!", MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation)
                        Me.txtNote.Focus()
                        Me.btnOK.Enabled = True
                    End If
                Else
                    MessageBox.Show(
                        "Please enter a valid Value for this variable. The valid values for this Variable are displayed on the Allowed Value(s) field on the screen.",
                        Project.ShortName & " - Invalid Value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtValue.Focus()
                    Me.btnOK.Enabled = True
                    'Exit Function
                End If
            ElseIf dr = DialogResult.No Then
                Me.btnOK.Enabled = False
            Else
                dr = DialogResult.Cancel
            End If

            Return dr
        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error Saving..", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Return DialogResult.Cancel
        End Try
    End Function

    Private Function CheckValue() As Boolean

        Dim i As Integer
        Dim strValue As String = String.Empty
        Dim strValueFinal As String = String.Empty

        If IsSRDEEOverride(Me.strUserName) = True Then
            Return True
        End If

        Select Case UCase(Microsoft.VisualBasic.Left(strAllowedValue, 3))
            Case "CHR"
                strValue = Mid(strAllowedValue, 4, Len(strAllowedValue) - 3).ToString
                If Len(Trim(Me.txtValue.Text)) <= CInt(strValue) Then
                    Return True
                Else
                    Return False
                End If
            Case "INT"
                If Not IsNumeric(Trim(Me.txtValue.Text)) Then
                    Return False
                Else
                    strValue = Mid(strAllowedValue, 4, Len(strAllowedValue) - 3).ToString
                    If strValue = "10" Then ' Phone number
                        If Len(Trim(Me.txtValue.Text)) = 10 Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        If Len(Trim(Me.txtValue.Text)) <= CInt(strValue) Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If

            Case "PER" ' Percentage upto 3 digits are allowed
                If Not IsNumeric(Trim(Me.txtValue.Text)) Then
                    Return False
                Else
                    If Len(Trim(Me.txtValue.Text)) <= 3 Then
                        Return True
                    Else
                        Return False
                    End If
                End If

            Case Else

                For i = 1 To Len(strAllowedValue)
                    strValue = Mid(strAllowedValue, i, 1)
                    If strValue <> "," Then
                        strValueFinal = Trim(strValueFinal) & strValue
                        If i = Len(strAllowedValue) Then
                            If UCase(Trim(Me.txtValue.Text)) = UCase(Trim(strValueFinal)) Then
                                Return True
                                Exit For
                                Exit Select
                            End If
                        End If
                    Else
                        If UCase(Trim(Me.txtValue.Text)) = UCase(Trim(strValueFinal)) Then
                            Return True
                            Exit For
                            Exit Select
                        Else
                            strValueFinal = ""
                        End If
                    End If
                Next i
                Return False
        End Select
    End Function

    'Private Function GetScannedDocumentFileName() As Boolean

    '    Try
    '        Dim sqldr As SqlClient.SqlDataReader = Nothing
    '        Dim blnFile As Boolean = False
    '        Cursor = Cursors.WaitCursor
    '        sqldr = SqlHelper.ExecuteReader(Project.ConnectionString, _
    '                                        "spDocumentScanGetFile", _
    '                                        New SqlParameter("@MPRID", Me.txtMPRID.Text), _
    '                                        New SqlParameter("InstrumentType", Me.strSurType))

    '        If sqldr.HasRows = True Then
    '            While sqldr.Read
    '                strDocFileName = sqldr("FileName").ToString
    '            End While
    '        End If

    '        If File.Exists(strDocFileName) = True Then
    '            blnFile = True
    '        Else
    '            blnFile = False
    '        End If
    '        If Not sqldr.IsClosed Then
    '            sqldr.Close()
    '        End If
    '        Cursor = Cursors.Default
    '        Return blnFile

    '    Catch ex As Exception
    '        strDocFileName = String.Empty
    '        MessageBox.Show(ex.Message, Project.ShortName & " - Error retrieving scanned questionnaire image", MessageBoxButtons.OK)
    '        Cursor = Cursors.Default
    '        Return False
    '    End Try
    'End Function


#End Region
End Class