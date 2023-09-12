'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Security.Principal
Imports System.Threading
Imports System.Threading.Tasks
Imports MPR.SMS.Data
Imports MPR.SMS.DataQuality
Imports MPR.SMS.Security


Public Class frmBatchClean

#Region "Private Fields"

    Private ReadOnly bs As New BindingSource
    Private sqlda As New SqlDataAdapter
    Private cmdSQL As SqlCommand
    Private blnCancel As Boolean = False
    Private conn As SqlConnection

    Public _Statusdesc As String
    Public _StatusCode As String
    Private isclean As Boolean

    Dim ReadOnly objDQ As New DataQuality.DataQuality(False, True, Project.GeoCode)
    Dim cts As CancellationTokenSource


    Public ReadOnly Property Project As Data.Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property


    Private Enum BatchType
        Address = 0
        Phone
        Name
    End Enum

    Public Enum DataType As Integer
        Address = 1
        Name = 2
        Phone = 3
        Email = 4
        GeoCode = 5
    End Enum

    Private SelectedBatch As BatchType = BatchType.Address

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.UserLabel.Text = WindowsIdentity.GetCurrent.Name
        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - " & Me.Text

        Me.tspProgress.Visible = False
        Me.btnCancel.Visible = False
    End Sub

#End Region

#Region "Event Handlers"

    'Private Sub dgvAddressReview_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    '    If dgvResults.SelectedRows.Count = 0 Then Return

    '    Dim row As DataGridViewRow = dgvResults.SelectedRows(0)

    '    Dim strMPRID As String = row.Cells("MPRID").FormattedValue.ToString()
    '    Dim objPerson As Person = New Person(strMPRID)

    '    Dim intCaseID As Integer = GetSafeValue(objPerson.CaseID)

    '    Dim objCase As New [Case](intCaseID, False)
    '    Dim intAddressID As Integer = 0
    '    If Not row.Cells("AddressID").FormattedValue.ToString() = "" Then
    '        intAddressID = CInt(row.Cells("AddressID").FormattedValue.ToString())
    '    End If

    '    Dim objAddress As Address = Nothing
    '    Dim objAddresses As Addresses = objCase.Addresses
    '    If objAddresses IsNot Nothing Then
    '        For Each objAddress In objAddresses
    '            If objAddress.AddressID = intAddressID Then
    '                Exit For
    '            End If
    '        Next
    '    End If

    'End Sub

    Private Sub optBest_CheckedChanged(sender As Object, e As EventArgs) Handles optBest.CheckedChanged

        chkBestPhysical.Enabled = optBest.Checked
        chkBestMailing.Enabled = optBest.Checked
        chkBestCheck.Enabled = optBest.Checked
    End Sub

    Private Sub optAddressType_CheckedChanged(sender As Object, e As EventArgs) Handles optAddressType.CheckedChanged

        cboAddressType.Enabled = optAddressType.Checked
    End Sub

    Private Sub optPhoneType_CheckedChanged(sender As Object, e As EventArgs) Handles optPhoneType.CheckedChanged

        cboPhoneType.Enabled = optPhoneType.Checked
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tabBatch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tabBatch.SelectedIndexChanged

        btnClean.Text = "Clean " & tabBatch.SelectedTab.Text.ToLower
        SelectedBatch = CType(tabBatch.SelectedIndex, BatchType)
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click

        Select Case tabBatch.SelectedTab.Text
            Case "Addresses"
                DisplayGrid(BuildSQLAddressCases)
            Case "Phones"
                DisplayGrid(BuildSQLPhoneCases)
            Case "Names"
                DisplayGrid(BuildSQLNameCases)
        End Select
    End Sub

    Private Sub btnClean_Click(sender As Object, e As EventArgs) Handles btnClean.Click
        '**Boris Shkolnik - May 25, 2023
        'Fix bug for updating wrong address when click on the grid while cleaning addresses

        'Changes - Boris
        Me.Cursor = Cursors.WaitCursor
        dgvResults.Enabled = False
        'Me.Cursor = Cursors.AppStarting

        conn = New SqlConnection(Project.ConnectionString)
        conn.Open()

        'make sure the grid is populated with the results that match the selected criteria.
        'if you are enterprising enough, you can put in logic to only re-populate the grid 
        'if some criteria changed since the last time it was populated.
        btnPreview.PerformClick()

        tspProgress.Visible = True
        btnCancel.Visible = True
        Me.Refresh()
        blnCancel = False
        cts = New CancellationTokenSource()

        SendBatchesToDQWS()

        tspProgress.Visible = False
        'btnCancel.Visible = False

        tspProgress.Value = 0
        conn.Close()
        If cmdSQL IsNot Nothing Then
            cmdSQL.Dispose()
        End If

        'Change - Boris
        dgvResults.Enabled = False

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        blnCancel = True
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        objDQ.CancelBatchClean()
    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        btnCancel.BorderStyle = Border3DStyle.Sunken
        Application.DoEvents()
    End Sub

    Private Sub btnCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseUp
        btnCancel.BorderStyle = Border3DStyle.RaisedInner
        Application.DoEvents()
    End Sub

    Private Sub btnCaseLocks_Click(sender As Object, e As EventArgs) Handles btnCaseLocks.Click

        Dim frm As frmCaseLockAdmin = New frmCaseLockAdmin
        frm.Show()
    End Sub

    'double click to open a case
    Private Sub dgvResults_DoubleClick(sender As Object, e As EventArgs) Handles dgvResults.DoubleClick

        Dim row As DataGridViewRow = dgvResults.SelectedRows(0)
        Dim intCaseID As Integer = CType(row.Cells("CaseID").Value, Integer)
        Dim objCase As New [Case](intCaseID, False)

        Dim strMPRID As String = row.Cells("MPRID").Value.ToString
        Dim objPerson As Person = Nothing
        If strMPRID.Length > 0 Then
            objPerson = New Person(strMPRID)
        End If

        Dim frmDisplayCase As New frmDisplayCase(objCase, objPerson, False)
        frmDisplayCase.Show()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub DisplayGrid(strSQL As String)

        Try
            With dgvResults
                .Columns.Clear()
                .DataSource = bs
                sqlda = New SqlDataAdapter(strSQL, Project.ConnectionString)

                Dim table As New DataTable
                sqlda.Fill(table)
                bs.DataSource = table

                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
                .MultiSelect = False
                .RowHeadersWidth = 39

                If .Rows.Count > 0 Then
                    .Rows(0).Selected = True
                End If

            End With

            Me.TotalRecordsLabel.Text = "Total Records: " & Me.dgvResults.Rows.Count

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.ShortName & " - Error loading data", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning)
        End Try

        With dgvResults
            .ReadOnly = True

            '.Columns("CaseID").Visible = False

            'try to remove fields that don't exist in all queries
            Try
                .Columns("AddressID").Visible = False
            Catch ex As Exception
            End Try
            Try
                .Columns("Country").Visible = False
            Catch ex As Exception
            End Try
            Try
                .Columns("PhoneID").Visible = False
            Catch ex As Exception
            End Try
            Try
                .Columns("GenderID").Visible = False
            Catch ex As Exception
            End Try
        End With
    End Sub


    Private Async Sub SendBatchesToDQWS()
        If Project.MelissaDataEnabled Then
            Select Case SelectedBatch
                Case BatchType.Address
                    Dim CleanAddresses As List(Of ProcessedAddress)
                    AddHandler objDQ.BatchProgressUpdate, AddressOf UpdateProgress

                    CleanAddresses = Await Task.Run(Function()
                        Return objDQ.ProcessAddresses(GetAddresses())
                    End Function)
                    populateAddressGridView(CleanAddresses)
                Case BatchType.Name
                    If optProperCase.Checked Then
                        Dim cleanNames As List(Of ProcessedName)
                        AddHandler objDQ.BatchProgressUpdate, AddressOf UpdateProgress

                        cleanNames = Await Task.Run(Function()
                            Return objDQ.ProcessNamesVB(GetNames())
                        End Function)
                        populateNameGridView(cleanNames)

                    Else
                        Dim cleanNames As List(Of ProcessedName)
                        AddHandler objDQ.BatchProgressUpdate, AddressOf UpdateProgress

                        cleanNames = Await Task.Run(Function()
                            Return objDQ.ProcessNames(GetNames())
                        End Function)
                        populateNameGridView(cleanNames)

                    End If
                Case BatchType.Phone
                    Dim CleanPhones As List(Of ProcessedPhone)
                    AddHandler objDQ.BatchProgressUpdate, AddressOf UpdateProgress
                    CleanPhones = Await Task.Run(Function()
                        Return objDQ.ProcessPhones(GetPhones())
                    End Function)
                    populatePhoneGridView(CleanPhones)
            End Select
            'Next
        End If
    End Sub

    Public Async Function BatchCleanAddressesAsync(token As CancellationToken) As Task(Of List(Of ProcessedAddress))
        Dim ServProvider As New ServiceProvider
        Dim obj As IDataquality = ServProvider.getDataCleaner
        Dim CleanedAddresses As List(Of ProcessedAddress)

        CleanedAddresses = Await Task.Run(Function()
            Return obj.ProcessAddresses(GetAddresses())
        End Function, token)
        Return CleanedAddresses
    End Function


#Region "Functions to fill cleaning arrays"

    Private Function GetAddresses() As List(Of DQAddress)
        Dim Addresses As New List(Of DQAddress)

        'Dim bs As BindingSource = CType(dgvResults.DataSource, BindingSource)
        Dim DT As DataTable = CType(bs.DataSource, DataTable)

        Dim Address As DQAddress

        For Each Row As DataRow In DT.Rows
            Address = New DQAddress

            Address.Company = Row("Facility1").ToString

            Address.Address1 = Row("Address1").ToString
            Address.Address2 = Row("Address2").ToString
            Address.Suite = Row("Address3").ToString
            Address.City = Row("City").ToString
            Address.State = Row("State").ToString
            Address.Zip = Row("PostalCode").ToString
            If Row("PostalCode").ToString.Length > 5 Then
                Address.Zip = Row("PostalCode").ToString.Substring(0, 5)
            End If
            Address.Country = Row("Country").ToString
            Address.caseid = CInt(Row("Caseid"))
            Address.id = CInt(Row("AddressID"))


            Addresses.Add(Address)
        Next

        Return Addresses
    End Function

    Private Function GetNames() As List(Of DQName)
        Dim Names As New List(Of DQName)
        Dim DT As DataTable = CType(bs.DataSource, DataTable)
        Dim Name As DQName

        For Each Row As DataRow In DT.Rows
            Name = New DQName

            Name.First = Row("FirstName").ToString
            Name.Last = Row("LastName").ToString
            Name.Middle = Row("MiddleName").ToString
            Name.Fullname = Row("Prefix").ToString + " " + Row("FirstName").ToString + " " +
                            LTrim(Row("MiddleName").ToString + " ") + Row("LastName").ToString + Row("Suffix").ToString
            Name.caseid = CInt(Row("CaseID"))
            Name.id = CInt(Row("MPRID"))
            Names.Add(Name)
        Next

        Return Names
    End Function

    Private Function GetPhones() As List(Of DQPhone)
        Dim Phones As New List(Of DQPhone)
        Dim DT As DataTable = CType(bs.DataSource, DataTable)

        Dim Phone As DQPhone

        For Each Row As DataRow In DT.Rows

            Phone = New DQPhone
            'Dim Row As DataGridViewRow = dgvResults.Rows(Currentrecord)
            Phone.Telephone = Row("Phonenum").ToString
            Phone.caseid = CInt(Row("CaseID"))
            Phone.id = CInt(Row("PhoneID"))
            Phones.Add(Phone)

        Next
        Return Phones
    End Function

#End Region

#Region "Functions to populate the grid view"

    Public Sub populateAddressGridView(cleanAddresses As List(Of ProcessedAddress))

        Dim openedHere As Boolean = False

        If conn.State = ConnectionState.Closed Then
            conn.Open()
            openedHere = True
        End If

        Dim cmd As SqlCommand
        cmd = New SqlCommand()
        cmd.Connection = conn

        For currentRecord As Integer = 0 To cleanAddresses.Count - 1
            With cleanAddresses(currentRecord)
                dgvResults.Rows(currentRecord).Cells("Address1").Value = .Address1
                dgvResults.Rows(currentRecord).Cells("Address2").Value = .Address2

                If .Address2.Trim <> .Suite.Trim Then
                    If .Address2.Length + .Suite.Length < 60 Then
                        dgvResults.Rows(currentRecord).Cells("Address2").Value = LTrim(.Address2 + " ") + .Suite
                    Else
                        dgvResults.Rows(currentRecord).Cells("Address3").Value = .Suite
                    End If
                End If

                dgvResults.Rows(currentRecord).Cells("City").Value = .City
                dgvResults.Rows(currentRecord).Cells("Facility1").Value = .Company
                dgvResults.Rows(currentRecord).Cells("Country").Value = .Country

                If .Postalcode.Trim <> "" Then
                    If .Plus4 <> " " Then
                        dgvResults.Rows(currentRecord).Cells("PostalCode").Value = .Postalcode + "-" + .Plus4
                    Else
                        dgvResults.Rows(currentRecord).Cells("PostalCode").Value = .Postalcode
                    End If
                End If

                dgvResults.Rows(currentRecord).Cells("State").Value = .State
                dgvResults.Rows(currentRecord).Cells("IsCleaned").Value = .isClean

                dgvResults.Rows(currentRecord).Cells("Latitude").Value = .Latitude
                dgvResults.Rows(currentRecord).Cells("Longitude").Value = .Longitude
            End With

            'Reset Result Descrption

            If Not chkTestRun.Checked Then
                'TO-DO: convert this to a stored proc, and check for case locks

                Dim isCleaned As New SqlBoolean(cleanAddresses(currentRecord).isClean)

                cmd.CommandText = String.Format("UPDATE tblAddress " &
                                                "SET Address1 = '{1}', Address2 = '{2}', Address3 = '{3}', " &
                                                "City = '{4}', State = '{5}', PostalCode = '{6}', Facility1 = '{7}', " &
                                                "Latitude = '{8}', Longitude = '{9}', " &
                                                "IsCleaned = '{11}', LastModifiedBy = '{10}', LastModifiedOn = GETDATE() " &
                                                "WHERE AddressID = {0}",
                                                dgvResults.Rows(currentRecord).Cells("AddressID").Value.ToString,
                                                Replace(dgvResults.Rows(currentRecord).Cells("Address1").Value.ToString,
                                                        "'", "''"),
                                                Replace(dgvResults.Rows(currentRecord).Cells("Address2").Value.ToString,
                                                        "'", "''"),
                                                Replace(dgvResults.Rows(currentRecord).Cells("Address3").Value.ToString,
                                                        "'", "''"),
                                                Replace(dgvResults.Rows(currentRecord).Cells("City").Value.ToString, "'",
                                                        "''"),
                                                dgvResults.Rows(currentRecord).Cells("State").Value.ToString,
                                                dgvResults.Rows(currentRecord).Cells("PostalCode").Value.ToString().
                                                   Replace("-", ""),
                                                Replace(dgvResults.Rows(currentRecord).Cells("Facility1").Value.ToString,
                                                        "'", "''"),
                                                dgvResults.Rows(currentRecord).Cells("Latitude").Value.ToString,
                                                dgvResults.Rows(currentRecord).Cells("Longitude").Value.ToString,
                                                Replace(CurrentUser.Name, "'", "''"), isCleaned)

                Dim aff As Integer = cmd.ExecuteNonQuery()
                If aff < 1 Then
                    dgvResults.Rows(currentRecord).Cells("Result").Value = "Error saving to db."
                End If
            End If
            dgvResults.Rows(currentRecord).Cells("Result").Value = cleanAddresses(currentRecord).Results.Description
        Next

        If openedHere Then
            conn.Close()
        End If
    End Sub

    Public Sub populatePhoneGridView(CleanedPhones As List(Of ProcessedPhone))

        Dim openedHere As Boolean = False

        If conn.State = ConnectionState.Closed Then
            conn.Open()
            openedHere = True
        End If

        For CurrentRecord As Integer = 0 To CleanedPhones.Count - 1
            'If Not (errorCodeString = " ") Then

            'isclean = ParseErrors(errorCodeString)

            ' If isclean Then
            Dim strPhone As String = CleanedPhones(CurrentRecord).NewAreaCode
            If strPhone = " " Then strPhone = CleanedPhones(CurrentRecord).AreaCode
            strPhone &= CleanedPhones(CurrentRecord).Prefix & CleanedPhones(CurrentRecord).Suffix

            dgvResults.Rows(CurrentRecord).Cells("Phonenum").Value = strPhone
            dgvResults.Rows(CurrentRecord).Cells("TimeZoneCode").Value = (CleanedPhones(CurrentRecord).TimezoneCode)
            dgvResults.Rows(CurrentRecord).Cells("IsCleaned").Value = CleanedPhones(CurrentRecord).isClean

            dgvResults.Rows(CurrentRecord).Cells("Result").Value = "Success"
            'dgv.Rows(dgvRow).Cells("IsCleaned").Value = True

            If Not chkTestRun.Checked Then
                'TO-DO: convert this to a stored proc, and check for case locks
                cmdSQL = New SqlCommand

                Dim isCleaned As New SqlBoolean(CleanedPhones(CurrentRecord).isClean)

                cmdSQL.CommandText = String.Format("UPDATE tblPhone " &
                                                   "SET Phonenum = '{1}', TimeZoneCode = '{2}', IsCleaned = '{4}', " &
                                                   "LastModifiedBy = '{3}', LastModifiedOn = GETDATE() " &
                                                   "WHERE PhoneID = {0}",
                                                   dgvResults.Rows(CurrentRecord).Cells("PhoneID").Value.ToString,
                                                   dgvResults.Rows(CurrentRecord).Cells("Phonenum").Value.ToString,
                                                   dgvResults.Rows(CurrentRecord).Cells("TimeZoneCode").Value.ToString,
                                                   Replace(CurrentUser.Name, "'", "''"), isCleaned)

                cmdSQL = New SqlCommand(cmdSQL.CommandText, conn)

                Dim aff As Integer = cmdSQL.ExecuteNonQuery()
                If aff < 1 Then
                    dgvResults.Rows(CurrentRecord).Cells("Result").Value = "Error saving to db."
                End If
            End If
            dgvResults.Rows(CurrentRecord).Cells("Result").Value = CleanedPhones(CurrentRecord).Results.Description
        Next

        If openedHere Then
            conn.Close()
        End If
    End Sub

    Public Sub populateNameGridView(CleanedNames As List(Of ProcessedName))

        Dim openedHere As Boolean = False

        If conn.State = ConnectionState.Closed Then
            conn.Open()
            openedHere = True
        End If

        For CurrentRecord As Integer = 0 To CleanedNames.Count - 1

            dgvResults.Rows(CurrentRecord).Cells("FirstName").Value = CleanedNames(CurrentRecord).First
            dgvResults.Rows(CurrentRecord).Cells("LastName").Value = CleanedNames(CurrentRecord).Last
            dgvResults.Rows(CurrentRecord).Cells("Gender").Value = CleanedNames(CurrentRecord).Gender
            dgvResults.Rows(CurrentRecord).Cells("MiddleName").Value = CleanedNames(CurrentRecord).Middle
            dgvResults.Rows(CurrentRecord).Cells("Prefix").Value = CleanedNames(CurrentRecord).Prefix
            dgvResults.Rows(CurrentRecord).Cells("Suffix").Value = CleanedNames(CurrentRecord).Suffix
            dgvResults.Rows(CurrentRecord).Cells("Result").Value = CleanedNames(CurrentRecord).Results.Description
            If Not chkTestRun.Checked Then
                'TO-DO: convert this to a stored proc, and check for case locks
                cmdSQL = New SqlCommand
                cmdSQL.CommandText = String.Format("UPDATE tblPerson " &
                                                   "SET Prefix = '{1}', FirstName = '{2}', MiddleName = '{3}', " &
                                                   "LastName = '{4}', Suffix = '{5}', GenderID = '{6}', " &
                                                   "LastModifiedBy = '{7}', LastModifiedOn = GETDATE() " &
                                                   "WHERE MPRID = '{0}'",
                                                   dgvResults.Rows(CurrentRecord).Cells("MPRID").Value.ToString,
                                                   Replace(dgvResults.Rows(CurrentRecord).Cells("Prefix").Value.ToString,
                                                           "'", "''"),
                                                   Replace(
                                                       dgvResults.Rows(CurrentRecord).Cells("FirstName").Value.ToString,
                                                       "'", "''"),
                                                   Replace(
                                                       dgvResults.Rows(CurrentRecord).Cells("Middlename").Value.ToString,
                                                       "'", "''"),
                                                   Replace(
                                                       dgvResults.Rows(CurrentRecord).Cells("LastName").Value.ToString,
                                                       "'", "''"),
                                                   Replace(dgvResults.Rows(CurrentRecord).Cells("Suffix").Value.ToString,
                                                           "'", "''"),
                                                   dgvResults.Rows(CurrentRecord).Cells("GenderID").Value.ToString,
                                                   Replace(CurrentUser.Name, "'", "''"))

                cmdSQL = New SqlCommand(cmdSQL.CommandText, conn)

                Dim aff As Integer = cmdSQL.ExecuteNonQuery()
                If aff < 1 Then
                    dgvResults.Rows(CurrentRecord).Cells("Result").Value = "Error saving to db."
                End If

            End If
        Next

        If openedHere Then
            conn.Close()
        End If
    End Sub

#End Region


    Private Function BuildSQLAddressCases() As String

        '== evenutally, convert this to a stored proc
        Dim sql As String = "SELECT DISTINCT tblPerson.CaseID, tblAddress.MPRID, " _
        'tblPerson.MPRID, tblPerson.FirstName, tblPerson.MiddleName, tblPerson.LastName, "
        sql +=
            "tblAddress.AddressID, tblAddress.Address1, tblAddress.Address2, tblAddress.Address3, tblAddress.Address4, tblAddress.City, "
        sql +=
            "tblAddress.State, tblAddress.Country, tblAddress.PostalCode, tblAddress.Facility1, tblAddress.Latitude, tblAddress.Longitude, ISNULL(tblAddress.IsCleaned, 0) AS IsCleaned, '' AS Result "
        sql += "FROM tblCase INNER JOIN"
        sql += " tblPerson ON tblCase.CaseID = tblPerson.CaseID INNER JOIN"
        sql += " tblAddress ON tblCase.CaseID = tblAddress.CaseID INNER JOIN"
        sql += " tblPersonBest ON tblPerson.MPRID = tblPersonBest.MPRID "
        'sql += "WHERE (tblAddress.MPRID = tblPerson.MPRID OR tblAddress.MPRID IS NULL) "
        sql +=
            "WHERE (IsNull(tblAddress.Address1, '') != '' OR IsNull(tblAddress.Address2, '') != '' OR IsNull(tblAddress.City, '') != ''  OR IsNull(tblAddress.State, '') != ''  OR IsNull(tblAddress.PostalCode, '') != '') "
        sql += BuildSQLCaseCriteria()
        sql += BuildSQLPersonCriteria()

        If chkExcludeCleanedAddresses.Checked Then
            sql += "AND IsNull(tbladdress.IsCleaned, 0) != 1 "
        End If
        If optBest.Checked AndAlso
           (chkBestPhysical.Checked Or chkBestMailing.Checked Or chkBestCheck.Checked) Then
            sql += "AND ("
            If chkBestPhysical.Checked Then
                sql += "tblPersonBest.BestPhysicalAddressID = tblAddress.AddressID"
            End If
            If chkBestMailing.Checked Then
                If chkBestPhysical.Checked Then
                    sql += " OR "
                End If
                sql += "tblPersonBest.BestMailingAddressID = tblAddress.AddressID"
            End If
            If chkBestCheck.Checked Then
                If chkBestPhysical.Checked Or chkBestMailing.Checked Then
                    sql += " OR "
                End If
                sql += "tblPersonBest.BestCheckAddressID = tblAddress.AddressID"
            End If
            sql += ") "
        ElseIf optAddressType.Checked AndAlso cboAddressType.SelectedAddressTypeID >= 0 Then
            sql += "AND tblAddress.AddressTypeID = " & CType(cboAddressType.SelectedAddressTypeID, String)
        End If

        Return sql
    End Function

    Private Function BuildSQLPhoneCases() As String

        '== evenutally, convert this to a stored proc
        Dim sql As String = "SELECT DISTINCT tblPerson.CaseID, tblPhone.MPRID, " _
        'tblPerson.MPRID, tblPerson.FirstName, tblPerson.MiddleName, tblPerson.LastName, "
        sql += "tblPhone.PhoneID, tblPhone.Phonenum, tblPhone.TimeZoneCode, "   'tblPhone.DSTI, "
        sql += "ISNULL(tblPhone.IsCleaned, 0) AS IsCleaned, '' AS Result "
        sql += "FROM tblCase INNER JOIN"
        sql += " tblPerson ON tblCase.CaseID = tblPerson.CaseID INNER JOIN"
        sql += " tblPhone ON tblCase.CaseID = tblPhone.CaseID INNER JOIN"
        sql += " tblPersonBest ON tblPerson.MPRID = tblPersonBest.MPRID "
        'sql += "WHERE (tblPhone.MPRID = tblPerson.MPRID OR tblPhone.MPRID IS NULL) "
        sql += "WHERE IsNull(tblPhone.Phonenum, '') != '' "
        sql += BuildSQLCaseCriteria()
        sql += BuildSQLPersonCriteria()

        If Me.chkExcludeCleanedPhones.Checked Then
            sql += "AND IsNull(tblPhone.IsCleaned, 0) != 1 "
        End If
        If optBestPhone.Checked Then
            sql += "AND tblPersonBest.BestPhoneID = tblPhone.PhoneID"
        ElseIf optPhoneType.Checked AndAlso cboPhoneType.SelectedPhoneTypeID >= 0 Then
            sql += "AND tblPhone.PhoneTypeID = " & CType(cboPhoneType.SelectedPhoneTypeID, String)
        End If

        Return sql
    End Function

    Private Function BuildSQLNameCases() As String

        '== evenutally, convert this to a stored proc
        Dim sql As String =
                "SELECT tblPerson.CaseID, tblPerson.MPRID, tblPerson.Prefix, tblPerson.FirstName, tblPerson.MiddleName, tblPerson.LastName, tblPerson.Suffix, "
        sql += "tblPerson.GenderID, tlkpGender.Gender, '' AS Result "
        sql += "FROM tblCase INNER JOIN tblPerson "
        sql += "ON tblCase.CaseID = tblPerson.CaseID "
        sql += "LEFT OUTER JOIN tlkpGender ON tblPerson.GenderID = tlkpGender.GenderID "
        sql +=
            "WHERE (IsNull(tblPerson.FirstName, '') != '' OR IsNull(tblPerson.MiddleName, '') != '' OR IsNull(tblPerson.LastName, '') != '') "
        sql += BuildSQLCaseCriteria()
        sql += BuildSQLPersonCriteria()

        Return sql
    End Function

    Private Function BuildSQLCaseCriteria() As String

        Dim sql As String = ""
        With CaseCriteria
            If .InSampleOnly Then
                sql += "AND tblCase.InSample = 1 "
            End If
            If .ExcludeIneligibles Then
                sql += "AND IsNull(tblCase.IsIneligible,0) != 1 "
            End If
            If .SelectedCaseType > 0 Then
                sql += "AND tblCase.EntityTypeID = " & CType(.SelectedCaseType, String)
            End If
        End With
        Return sql
    End Function

    Private Function BuildSQLPersonCriteria() As String

        Dim sql As String = ""
        With PersonCriteria
            If .SelectedPersonType >= 0 Then
                sql += "AND tblPerson.RelationshipTypeID = " & CType(.SelectedPersonType, String) & " "
            End If
        End With
        Return sql
    End Function

    Sub UpdateProgress(Sender As Object, Message As BatchProgressArgs)
        If blnCancel Then
            TotalRecordsLabel.Text = "Process cancelled after " + Message.BatchesProcessed.ToString + " of " +
                                     Message.TotalBatches.ToString + " Batches."
        Else
            TotalRecordsLabel.Text = "Processed " + Message.BatchesProcessed.ToString + " of " +
                                     Message.TotalBatches.ToString + " Batches."
        End If
    End Sub


#End Region
End Class