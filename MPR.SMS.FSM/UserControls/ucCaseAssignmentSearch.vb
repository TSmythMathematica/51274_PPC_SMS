Imports MPR.SMS.Data
Imports System.Data.SqlClient

Public Class ucCaseAssignmentSearch

#Region "Private Variables"

    ''' <summary>
    ''' Describes the type of string match that will be performed when searching the SMS
    ''' database.
    ''' </summary>
    ''' <remarks>
    ''' All string matches are currently case insensitive.
    ''' </remarks>
    Public Enum StringMatchType
        ''' <summary>Indicates that an exact match on the specified string will be performed.</summary> 
        Equals
        ''' <summary>Indicates that a search for strings containing the specified string will be performed</summary> 
        Contains
        ''' <summary>Indicates that a search for strings starting with the specified string will be performed</summary> 
        StartsWith
        ''' <summary>Indicates that a search for strins containing the specified string will be performed.</summary> 
        EndsWith
    End Enum

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        optCaseID.Checked = True
        cboMatch.SelectedIndex = 0
    End Sub

#End Region

#Region "Private Methods"

    Private Sub SetForm()

        txtCaseID.Enabled = optCaseID.Checked
        txtMPRID.Enabled = optMPRID.Checked
        cboMatch.Enabled = optLastName.Checked
        txtLastName.Enabled = optLastName.Checked
        cboStatus.Enabled = optStatus.Checked
    End Sub

    Private Sub DoSearch()

        Cursor = Cursors.WaitCursor
        Dim objCaseAssignments As New CaseAssignments(GetWhereClause)
        Cursor = Cursors.Default

        RaiseEvent OnSearch(Me, objCaseAssignments)
    End Sub

    Public ReadOnly Property GetWhereClause() As String
        Get
            ' Build the Select statement using the StringBuilder class
            Dim strSQL As String = "WHERE "

            If optCaseID.Checked Then
                strSQL += "CaseID = " & FormatSqlValue(txtCaseID.Text)

            ElseIf optMPRID.Checked Then
                strSQL += "MPRID = " & FormatSqlValue(txtMPRID.Text)

            ElseIf optLastName.Checked Then

                ' If searching on last name, build its Where clase  
                If txtLastName.Text <> vbNullString Then
                    Select Case CType(cboMatch.SelectedIndex, StringMatchType)
                        Case StringMatchType.Equals
                            strSQL += "LastName = " & FormatSqlValue(txtLastName.Text)
                        Case StringMatchType.StartsWith
                            strSQL += "LastName LIKE " & FormatSqlValue(txtLastName.Text & "%")
                        Case StringMatchType.Contains
                            strSQL += "LastName LIKE " & FormatSqlValue("%" & txtLastName.Text & "%")
                        Case StringMatchType.EndsWith
                            strSQL += "LastName LIKE " & FormatSqlValue("%" & txtLastName.Text)
                    End Select
                Else
                    strSQL += "1 <> 1"
                End If
            ElseIf optStatus.Checked Then
                If cboStatus.SelectedStatus IsNot Nothing Then
                    strSQL += "StatusCode = " & cboStatus.SelectedStatus.Code.ToString
                Else
                    strSQL += "1 <> 1"
                End If
            Else
                strSQL += "1 <> 1"
            End If
            Return strSQL
        End Get
    End Property

    Private Function FormatSqlValue(ByVal objValue As Object) As String

        If objValue Is Nothing Then
            Return "NULL"
        End If

        Dim strType As String = objValue.GetType().ToString()

        Select Case objValue.GetType().ToString()
            Case "System.Int16"
                Return CType(objValue, Int16).ToString()
            Case "System.Int32"
                Return CType(objValue, Int32).ToString()
            Case "System.Int64"
                Return CType(objValue, Int64).ToString()
            Case "System.String"
                Return "'" & Replace(CType(objValue, String), "'", "''") & "'"
        End Select

        Throw New Exception("FormatSqlValue: " & objValue.GetType.ToString() & " is not supported")
    End Function

#End Region

#Region "Events"

    Public Event OnSearch(ByVal sender As Object, ByVal objCaseAssignments As CaseAssignments)

#End Region

#Region "Event Handlers"

    Private Sub optCaseID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles optCaseID.CheckedChanged

        SetForm()
    End Sub

    Private Sub optLastName_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles optLastName.CheckedChanged

        SetForm()
    End Sub

    Private Sub optMPRID_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles optMPRID.CheckedChanged

        SetForm()
    End Sub

    Private Sub optStatus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles optStatus.CheckedChanged

        SetForm()
    End Sub

    Private Sub btnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGo.Click

        DoSearch()
    End Sub

    Private Sub ucCaseAssignmentSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.DesignMode Then
            cboStatus.Filters = "WHERE IsCAPIStatus = 1"
        End If
    End Sub

#End Region
End Class

