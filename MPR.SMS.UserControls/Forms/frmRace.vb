'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Threading
Imports MPR.SMS.Data


Public Class frmRace

#Region "Private Fields"

    Private ReadOnly mobjPerson As Person
    Private ReadOnly mblnReadOnly As Boolean = False
    Private mintOther As Integer = - 1

#End Region

#Region "Private Properties"

    Private Property ItemChecked(intTypeID As Integer) As Boolean
        Get
            For Each objCheckedItem As Object In lstItems.CheckedItems
                If CType(objCheckedItem, DataRowView)("RaceTypeID").Equals(intTypeID) Then
                    Return True
                End If
                Return False
            Next
        End Get
        Set
            For i As Integer = 0 To lstItems.Items.Count - 1
                If CType(lstItems.Items(i), DataRowView)("RaceTypeID").Equals(intTypeID) Then
                    lstItems.SetItemChecked(i, value)
                    Exit Property
                End If
            Next
        End Set
    End Property

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(objPerson As Person, blnReadOnly As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mobjPerson = objPerson

        Dim strDataSource As String = "SELECT * FROM tlkpRaceType"
        InitializeList(strDataSource)
        txtOther.ReadOnly = True

        For Each objRace As PersonRace In mobjPerson.PersonRaces
            ItemChecked(objRace.RaceTypeID.Value) = True
        Next

        txtOther.Text = GetSafeValue(mobjPerson.RaceOther)
        chkHispanic.Checked = GetSafeValue(mobjPerson.IsHispanic)

        mblnReadOnly = blnReadOnly
        chkHispanic.AutoCheck = Not blnReadOnly
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        '1. remove any items which were previously checked
        For i As Integer = 0 To lstItems.Items.Count - 1
            If lstItems.GetItemChecked(i) = False Then
                For Each objRace As PersonRace In mobjPerson.PersonRaces
                    If CType(lstItems.Items(i), DataRowView)("RaceTypeID").Equals(objRace.RaceTypeID.Value) Then
                        mobjPerson.PersonRaces.Remove(objRace)
                        Exit For
                    End If
                Next
            End If
        Next

        '2. add any new items which were previously unchecked
        For Each obj As Object In lstItems.CheckedItems
            Dim blnFound As Boolean = False
            For Each objRace As PersonRace In mobjPerson.PersonRaces
                If CType(obj, DataRowView)("RaceTypeID").Equals(objRace.RaceTypeID.Value) Then
                    blnFound = True
                    Exit For
                End If
            Next
            If Not blnFound Then
                Dim objRace As New PersonRace(mobjPerson)
                SetSafeValue(objRace.RaceTypeID, CType(obj, DataRowView)("RaceTypeID").ToString)

            End If
        Next

        '3. set the "Other" field, if applicable
        If Not txtOther.ReadOnly Then
            SetSafeValue(mobjPerson.RaceOther, txtOther.Text)
        Else
            SetSafeValue(mobjPerson.RaceOther, "")
        End If

        '4. set the Ethnicity (Hispanic) flag
        SetSafeValue(mobjPerson.IsHispanic, chkHispanic.Checked)


        Me.Close()
    End Sub

    Private Sub lstItems_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles lstItems.ItemCheck

        If mblnReadOnly Then
            e.NewValue = e.CurrentValue
        End If

        'enable the "Other" specify field if "Other" is checked
        If e.Index = mintOther Then
            txtOther.ReadOnly = (e.NewValue = CheckState.Unchecked) Or mblnReadOnly
        End If
    End Sub

    Private Sub lstItems_KeyPress(sender As Object, e As KeyPressEventArgs) Handles lstItems.KeyPress

        FixSelections()
    End Sub

    Private Sub lstItems_MouseUp(sender As Object, e As MouseEventArgs) Handles lstItems.MouseUp

        FixSelections()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub InitializeList(strSQL As String)
        Try
            ' Set up the CheckedListBox
            With lstItems

                ' Set up the data source.
                .DataSource = GetDataTable(strSQL)
                .DisplayMember = "Description"
                .ValueMember = "RaceTypeID"

            End With
        Catch ex As SqlException
            MessageBox.Show(ex.Message,
                            "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Thread.CurrentThread.Abort()
        End Try

        'find the index of the "Other" race type
        For i As Integer = 0 To lstItems.Items.Count - 1
            If CType(lstItems.Items(i), DataRowView)("Description").ToString = "Other" Then
                'If lstItems.Items(i).row("Description").ToString = "Other" Then
                mintOther = i
                Exit For
            End If
        Next
    End Sub

    Private Sub FixSelections()

        'once a Race type is known, unselect the "Unknown" option
        If lstItems.CheckedItems.Count > 1 Then
            If lstItems.SelectedIndex = 0 Then
                For i As Integer = 1 To lstItems.Items.Count - 1
                    ItemChecked(i) = False
                Next
            Else
                ItemChecked(0) = False
            End If

            'or, if no Races are selectd, automatically select "Unknown"
        ElseIf lstItems.CheckedItems.Count = 0 Then
            ItemChecked(0) = True
        End If
    End Sub

#End Region
End Class