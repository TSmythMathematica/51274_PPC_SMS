'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data
Imports MPR.SMS.Security

Public Class frmSurveySettingsUpdate

#Region "Private Fields"

    Private ReadOnly intSSID As Integer
    Private ReadOnly strAllowedValue As String = String.Empty

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(intVariableID As Integer,
                   strVariable As String,
                   strDescription As String,
                   strValue As String,
                   strValueAllowed As String,
                   strExperimentGroup As String,
                   strIsActive As String,
                   strCreatedBy As String,
                   dtCreatedOn As String,
                   strLastModifiedBy As String,
                   dtLastModifiedOn As String,
                   intRound As Integer,
                   intID As Integer,
                   strInstrumentType As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            Me.txtVariableID.Text = intVariableID.ToString
            Me.txtVariable.Text = strVariable
            Me.txtDescription.Text = strDescription
            Me.txtValue.Text = strValue
            Me.txtExperimentGroup.Text = strExperimentGroup
            Me.txtIsActive.Text = strIsActive
            Me.txtCreatedBy.Text = strCreatedBy
            Me.txtCreatedOn.Text = dtCreatedOn.ToString
            Me.txtLastModifiedBy.Text = strLastModifiedBy
            Me.txtLastModifiedOn.Text = dtLastModifiedOn.ToString

            Me.txtInstrumentType.Text = strInstrumentType
            Me.txtRound.Text = intRound.ToString

            intSSID = intID

            Me.btnOK.Enabled = False


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
                Case "RNG"
                    Dim i As Integer
                    Dim strVal As String = String.Empty
                    Dim strStartVal As String = String.Empty
                    Dim strEndVal As String = String.Empty
                    strVal = Mid(strAllowedValue, 4, Len(strAllowedValue) - 3)
                    For i = 1 To Len(strVal)
                        If Mid(strVal, i, 1) = "-" Then
                            strStartVal = Mid(strVal, 1, i - 1)
                            strEndVal = Mid(strVal, i + 1, Len(strVal))
                            Exit For
                        End If
                    Next

                    Me.txtAllowedValue.Text = "Value between " & CInt(strStartVal) & " and " & CInt(strEndVal)
                Case "DTE"
                    Me.txtAllowedValue.Text = "Date in MM/DD/YYYY format. e.g. 11/30/1012 "
                Case Else
                    Me.txtAllowedValue.Text = strAllowedValue
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error getting data..", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
            Me.Close()
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged
        Me.txtLastModifiedBy.Text = CurrentUser.Name
        Me.txtLastModifiedOn.Text = CStr(Now())
        Me.btnOK.Enabled = True
    End Sub

    Private Sub frmSurveySettingsUpdate_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.btnOK.Enabled = True Then
            e.Cancel = (ConfirmSave() = DialogResult.Cancel)
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        ConfirmSave()

        If Me.btnOK.Enabled = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Me.btnOK.Enabled = True Then
            ConfirmSave()
        Else
            DialogResult = DialogResult.Cancel
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Sub UpdateSurveySettings()
        Cursor = Cursors.WaitCursor

        Dim conn As New SqlConnection(Project.ConnectionString)
        Dim cmdSQL As New SqlCommand("ISMS_SurveySettings_Update", conn)

        cmdSQL.Connection = conn


        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure
            cmdSQL.Parameters.Add(New SqlParameter("@SSID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "",
                                                   DataRowVersion.Proposed, intSSID))
            cmdSQL.Parameters.Add(New SqlParameter("@Value", SqlDbType.VarChar, 200, ParameterDirection.Input, False, 10,
                                                   0, "", DataRowVersion.Proposed, GetSafeValue(Me.txtValue.Text)))
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
                    Me.UpdateSurveySettings()
                    Me.btnOK.Enabled = False
                Else
                    MessageBox.Show(
                        "Please enter a valid Value for this variable. The valid values for this Variable are displayed on the Allowed Value(s) field on the screen.",
                        Project.ShortName & " - Invalid Value!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Me.txtValue.Focus()
                    Me.btnOK.Enabled = True
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


        ' need to check if chr, int or per here 
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

            Case "RNG" ' Range type 
                Dim strVal As String = String.Empty
                Dim strStartVal As String = String.Empty
                Dim strEndVal As String = String.Empty
                strVal = Mid(strAllowedValue, 4, Len(strAllowedValue) - 3)
                For i = 1 To Len(strVal)
                    If Mid(strVal, i, 1) = "-" Then
                        strStartVal = Mid(strVal, 1, i - 1)
                        strEndVal = Mid(strVal, i + 1, Len(strVal))
                        Exit For
                    End If
                Next

                If CInt(Me.txtValue.Text) < CInt(strStartVal) Or CInt(Me.txtValue.Text) > CInt(strEndVal) Then
                    Return False
                Else
                    Return True
                    Exit Select
                End If

            Case "DTE"
                Try
                    strValue = CStr(DateValue(Trim(Me.txtValue.Text)))
                    If _
                        CInt(Mid(Me.txtValue.Text, 1, 2)) >= Month(Now) And
                        CInt(Mid(Me.txtValue.Text, 7, 4)) >= Year(Now) Then
                        Return True
                    Else
                        Return False
                    End If

                Catch ex As Exception
                    Return False
                End Try

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

#End Region
End Class