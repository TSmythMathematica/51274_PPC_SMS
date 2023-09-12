Imports MPR.SMS.UserControls
Imports MPR.SMS.Data
Imports MPR.SMS.Data.GlobalData
Imports MPR.SMS.Security
Imports MPR.Windows.Forms
Imports System.Windows.Forms

Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Public Class frmSelectionForForwardingAddress

#Region "Public Variables"
    Public Enum Mode
        Cancel = 0
        AddressExists = 1
        AddressNotExists = 2
    End Enum

    Public ExitMode As Mode

#End Region

#Region "Private Variables"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mintAddressID As Integer
    Private FormLoaded As Boolean = False

#End Region

#Region "Constructors"

    Public Sub New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        FillGrid()

        ' Add any initialization after the InitializeComponent() call.

        StartPosition = FormStartPosition.CenterScreen
    End Sub


    Public Sub New(ByVal objCase As [Case], ByVal objPerson As Person, ByVal AddressID As Integer)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjCase = objCase
        mobjPerson = objPerson
        mintAddressID = AddressID

        FillGrid()

        Text = Text & " for " & mobjPerson.FirstName.ToString() & " " &
            mobjPerson.LastName.ToString() & " (MPRID = " & mobjPerson.MPRID.ToString() & ")"

        StartPosition = FormStartPosition.CenterScreen

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub grdAddresses_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles grdAddresses.CellPainting
        If e.ColumnIndex = 1 Or e.ColumnIndex = 5 Then 'for AddressID and State
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        Dim AddressID As Integer

        If AddressFound() = False Then
            MsgBox("Forwarding Address not selected", MsgBoxStyle.Exclamation, "Validation")
        Else
            AddressID = GetSelectedAddressID()

            For Each objAddress As Address In mobjPerson.Addresses
                If objAddress.AddressID = AddressID Then
                    'Boris*** Changed original source type to Forwarding???
                    objAddress.SourceTypeID = GetSafeValue(MPR.SMS.Data.Enumerations.SourceType.PostOffice)

                    'Boris*** September 11, 2020 - defined new address as Best
                    Dim mystring As String = objAddress.Address1.ToString

                    If mystring.Contains("P.O. ") Or mystring.Contains("PO ") Then
                        mobjPerson.BestMailingAddress = objAddress
                    Else
                        mobjPerson.BestMailingAddress = objAddress
                        mobjPerson.BestPhysicalAddress = objAddress
                    End If

                    Dim objAddressNote As New Note(mobjCase)
                    With objAddressNote
                        .TableID = AddressID
                        .TableTypeID = 1 ' hard coded for now, needs to match to tlkpNoteType
                        .Case = mobjCase
                        .Person = mobjPerson
                        .MPRID = mobjPerson.MPRID
                        .SourceTypeID = GetSafeValue(MPR.SMS.Data.Enumerations.SourceType.PostOffice)
                        .CreatedOn = Now
                    End With
                    mobjCase.Notes.Add(objAddressNote)
                    Exit For  'exit after finding address
                End If
            Next

            ExitMode = Mode.AddressExists
            Close()
        End If
    End Sub


    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        If AddressFound() = True Then
            MsgBox("Forwarding Address selected", MsgBoxStyle.Exclamation, "Validation")
        Else
            ExitMode = Mode.AddressNotExists
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ExitMode = Mode.Cancel
        Close()
    End Sub


    Private Sub grdAddresses_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdAddresses.CellValueChanged
        Dim columnIndex As Integer = 0

        If grdAddresses.RowCount > 0 And FormLoaded = True Then
            If (e.ColumnIndex = columnIndex) Then
                'If the user checked this box, then uncheck all the other rows
                Dim isChecked As Boolean = CBool(grdAddresses.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
                If (isChecked) Then
                    For Each row As DataGridViewRow In grdAddresses.Rows
                        If (row.Index <> e.RowIndex) Then
                            row.Cells(columnIndex).Value = Not isChecked
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub frmSelectionForForwardingAddress_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        FormLoaded = True
    End Sub

    Private Sub grdAddresses_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles grdAddresses.CurrentCellDirtyStateChanged
        If Me.grdAddresses.IsCurrentCellDirty Then
            grdAddresses.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

#End Region

#Region "Private Functions"

    Private Function AddressFound() As Boolean
        For Each row As DataGridViewRow In grdAddresses.Rows
            Dim chk As DataGridViewCheckBoxCell = CType(row.Cells(0), DataGridViewCheckBoxCell)
            If chk.Value IsNot Nothing AndAlso CBool(chk.Value) = True Then
                Return True
            End If
        Next

        Return False
    End Function

    Private Function GetSelectedAddressID() As Integer
        Dim AddressID As Integer = 0

        For Each row As DataGridViewRow In grdAddresses.Rows
            Dim chk As DataGridViewCheckBoxCell = CType(row.Cells(0), DataGridViewCheckBoxCell)
            If chk.Value IsNot Nothing AndAlso CBool(chk.Value) = True Then
                AddressID = CInt(row.Cells(1).Value)
                Exit For
            End If
        Next

        Return AddressID
    End Function

#End Region

#Region "Private Methods"
    Private Sub FillGrid()

        Dim gridRow As Object()

        Dim dt As DataTable
        Dim rows As Integer

        'dt = DataUtility.GetDataTable(procName:="dbo.[SMS_GetUniqueAddressesExceptCurrent]",
        'stringParamName:="@MPRID", stringParamSize:=8,
        ' stringParamValue:=CStr(mobjPerson.MPRID),
        'intParamName:="@CurrentAddressID", intParamValue:=mintAddressID)

        dt = GetDataTable2Par(procName:="dbo.[SMS_GetUniqueAddressesExceptCurrent]",
            stringParamName:="@MPRID", stringParamSize:=8,
            stringParamValue:=CStr(mobjPerson.MPRID),
            intParamName:="@CurrentAddressID", intParamValue:=mintAddressID)

        rows = dt.Rows.Count

        'grdAddresses.DataSource = dt
        'grdAddresses.Refresh()

        With grdAddresses
            .Rows.Clear()
            .AllowUserToAddRows = False

            For counter As Integer = 0 To rows - 1
                'imgList.Images("checkbox-unchecked.bmp")
                gridRow = {False,
                    GetSafeValue(dt.Rows(counter).Item("AddressID").ToString()),
                    GetSafeValue(dt.Rows(counter).Item("Address1").ToString()),
                    GetSafeValue(dt.Rows(counter).Item("Address2").ToString()),
                    GetSafeValue(dt.Rows(counter).Item("City").ToString()),
                    GetSafeValue(dt.Rows(counter).Item("State").ToString()),
                    GetSafeValue(dt.Rows(counter).Item("ZipCode").ToString())}

                grdAddresses.Rows.Add(gridRow)
            Next

            .Columns("DuplicateAddress").Width = 90
            .Columns("AddressID").Width = 64
            .Columns("Address1").Width = 150
            .Columns("Address2").Width = 60
            .Columns("City").Width = 90
            .Columns("State").Width = 40
            .Columns("ZipCode").Width = 70

            ' Set the background color for all rows and for alternating rows. 
            ' The value for alternating rows overrides the value for all rows. 
            .RowsDefaultCellStyle.BackColor = Color.White
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray

            ' Set the row and column header styles.
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Blue
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


            'grdAddresses.Columns("AddressID").DefaultCellStyle.BackColor = Color.LightYellow

            'grdAddresses.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

        End With

    End Sub
#End Region

End Class