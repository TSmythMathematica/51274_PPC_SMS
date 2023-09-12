'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports MPR.SMS.Data
Imports MPR.SMS.Data.BaseClasses
Imports MPR.Windows.Forms
Imports Microsoft.Office.Interop
Imports System.Text.RegularExpressions

Imports System.Net
Imports Newtonsoft.Json





Public Class frmDataImport
    Inherits Form

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Form object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Form object belongs to.
    ''' </value>
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.   

        InitializeComponent()

        Me.CenterToScreen()

        Dim objImport As DataImport

        Dim objImports As DataImports = Project.DataImports

        For Each objImport In objImports
            lstImports.Items.Add(objImport.Description.Value)
        Next

        If lstImports.Items.Count > 0 Then
            lstImports.SelectedIndex = 0
        End If
    End Sub

#End Region

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lstImports As System.Windows.Forms.ListBox
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lstImports = New System.Windows.Forms.ListBox()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstImports
        '
        Me.lstImports.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.lstImports.Location = New System.Drawing.Point(8, 25)
        Me.lstImports.Name = "lstImports"
        Me.lstImports.Size = New System.Drawing.Size(336, 147)
        Me.lstImports.TabIndex = 2
        '
        'cmdExit
        '
        Me.cmdExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),
                                  System.Windows.Forms.AnchorStyles)
        Me.cmdExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdExit.Location = New System.Drawing.Point(264, 184)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(80, 26)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Cancel"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(225, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Please select the data you would like to import"
        '
        'btnImport
        '
        Me.btnImport.Anchor =
            CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.btnImport.Enabled = False
        Me.btnImport.Location = New System.Drawing.Point(160, 184)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(80, 26)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import"
        '
        'frmDataImport
        '
        Me.AcceptButton = Me.btnImport
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.cmdExit
        Me.ClientSize = New System.Drawing.Size(351, 221)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.lstImports)
        Me.Name = "frmDataImport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Import Cases"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub lstImports_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles lstImports.SelectedIndexChanged

        btnImport.Enabled = lstImports.SelectedItems.Count > 0
    End Sub

    Private Sub lstImports_DoubleClick(sender As Object, e As EventArgs) Handles lstImports.DoubleClick

        btnImport_Click(sender, e)
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click

        Dim objImport As ProgressThread = Nothing
        Dim strCancel As String = "Are you sure you want to cancel the Sample Load?"

        Select Case lstImports.SelectedIndex

            Case 0
                Dim SampleLoad As New SampleLoadImportThread
                SampleLoad.Caption = Me.Text
                SampleLoad.ConfirmCancel = strCancel
                objImport = SampleLoad

            Case 1
                Dim SampleLoad As New AccurintImportThread
                SampleLoad.Caption = Me.Text
                SampleLoad.ConfirmCancel = "Are you sure you want to cancel the Accurint Load?"
                objImport = SampleLoad

            Case 2
                Dim SampleLoad As New BulkLocatingExport
                SampleLoad.Caption = Me.Text
                SampleLoad.ConfirmCancel = "Are you sure you want to cancel?"
                objImport = SampleLoad
                SampleLoad.FileName = ImportUtility.GetImportFileName(Project.BulkLocatingExportFolder, "XLSX") 'N drive location where FileToReload.xlsx is located
                If Not SampleLoad.FileName.ToUpper().EndsWith(".XLSX") Then
                    MessageBox.Show("File Name must be XLSX type.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

            Case 3
                Dim SampleLoad As New UrlImportThread
                SampleLoad.Caption = Me.Text
                SampleLoad.ConfirmCancel = "Are you sure you want to cancel the Accurint Load?"
                objImport = SampleLoad

            Case 4 'Tower data import
                Dim towerData As TowerDataImportThread
                towerData = New TowerDataImportThread
                towerData.Caption = Me.Text
                towerData.ConfirmCancel = strCancel

                towerData.ImportFile = ImportUtility.GetImportFileName(Project.TowerDataImportFolder, "CSV")

                If towerData.ImportFile.Length = 0 Then
                    Return ' cancelled out of open file dialog
                End If
                If Not towerData.ImportFile.ToUpper().EndsWith(".CSV") Then
                    MessageBox.Show("File Name must be CSV type.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                towerData.Start()

            Case 5  'Create ShortURL
                Dim msgText As String = "Do you want to run Confirmit URL / Shorten URL Load process for SMS project?"
                Dim msgTitle As String = " - Confirmit URL / Shorten URL Load!"
                Dim msgCancel As String = "Are you sure you want to cancel SMS Confirmit URL / Shorten URL Load process"

                Dim dr As DialogResult = MessageBox.Show(msgText, Project.ShortName + msgTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                If dr = DialogResult.Yes Then
                    Dim SampleLoad As New ConfirmitUrlLoad
                    SampleLoad.Caption = Me.Text
                    SampleLoad.ConfirmCancel = msgCancel
                    objImport = SampleLoad
                    SampleLoad.FileName = ImportUtility.GetImportFileName("\\mathematica.net\NDrive\Project\SMSBaseV5\", "XLSX")  'Replace SMSBaseV5 with project name 
                    If Not SampleLoad.FileName.ToUpper().EndsWith(".XLSX") Then
                        MessageBox.Show("File Name must be XLSX type.", Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Exit Sub
                    End If
                End If


            Case 6 'Add Other Import Routines Here
        End Select

        If Not objImport Is Nothing Then
            objImport.Start()
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        Me.Close()
    End Sub

#End Region
End Class

#Region "Import Thread Classes"

Public Class SampleLoadImportThread
    Inherits ProgressThread 'Create SMS Load Test Cases

    Public Name As String

    Public Overrides Sub Run()

        Dim blnCanceled As Boolean = False

        Dim objExtSampleLoad As New VwExtTestSample
        objExtSampleLoad.ConnectionString = Project.ConnectionString

        'RaiseOnUpdate("Importing " + Name + "... Please Wait", 0)
        Dim objDataTable As DataTable = objExtSampleLoad.SelectAll()

        Project.OpenConnection()

        Dim count As Integer = 0

        For Each objDataRow As DataRow In objDataTable.Rows

            '  This statement creates a SampleLoad object from one row 
            '  in the input file.  Because the Wizard has been used to generate a 
            '  base class for the SampleLoad table each column in that table
            '  is a property of the SampleLoad object

            Dim objSampleLoad As New ExtTestSample(objDataRow)

            '  Create a new Case object and a Person object within that case for the SampleMember
            Dim objCase As New [Case](Data.Enumerations.tlkpEntityType.SampleMember)
            SetSafeValue(objCase.EntityName, GetSafeValue(objSampleLoad.LastName) & " Case")

            Dim objPerson As New Person(objCase) ' = objStudentCase.PrimarySampleMember
            objPerson.RelationshipTypeID = New SqlInt32(1)
            SetSafeValue(objPerson.FirstName, GetSafeValue(objSampleLoad.FirstName))
            SetSafeValue(objPerson.MiddleName, GetSafeValue(objSampleLoad.MiddleName))
            SetSafeValue(objPerson.LastName, GetSafeValue(objSampleLoad.LastName))
            objPerson.LanguageTypeID = GetSafeValue(objSampleLoad.LanguageTypeID)
            objPerson.GenderID = GetSafeValue(objSampleLoad.GenderID)
            If Not objSampleLoad.DateOfBirth.IsNull Then
                SetSafeValue(objPerson.DateOfBirth, CType(GetSafeValue(objSampleLoad.DateOfBirth), String))
            End If
            SetSafeValue(objPerson.Prefix, GetSafeValue(objSampleLoad.Prefix))
            SetSafeValue(objPerson.Suffix, GetSafeValue(objSampleLoad.Suffix))
            SetSafeValue(objPerson.Title, GetSafeValue(objSampleLoad.Title))
            SetSafeValue(objPerson.SSN, GetSafeValue(objSampleLoad.SSN))

            Dim objAddress As New Address(objCase)
            objAddress.Person = objPerson
            objAddress.Facility1 = objSampleLoad.Facility1
            objAddress.Facility2 = objSampleLoad.Facility2
            objAddress.Address1 = objSampleLoad.Address1
            objAddress.Address2 = objSampleLoad.Address2
            objAddress.Address3 = objSampleLoad.Address3
            objAddress.Address4 = objSampleLoad.Address4
            objAddress.City = objSampleLoad.City
            objAddress.State = objSampleLoad.State
            objAddress.County = objSampleLoad.County
            objAddress.Country = objSampleLoad.Country
            objAddress.PostalCode = objSampleLoad.PostalCode
            objAddress.AddressTypeID = objSampleLoad.AddressTypeID

            Dim objPhone As New Phone(objCase)
            objPhone.Person = objPerson
            objPhone.PhoneNum = objSampleLoad.PhoneNum
            objPhone.Extension = objSampleLoad.Extension
            If Not objSampleLoad.PhoneTimeID.IsNull Then objPhone.PhoneTimeID = objSampleLoad.PhoneTimeID
            If Not objSampleLoad.PhoneTypeID.IsNull Then objPhone.PhoneTypeID = objSampleLoad.PhoneTypeID
            objPhone.TimeZoneCode = objSampleLoad.TimeZoneCode
            If objSampleLoad.DSTI.IsNull Then
                objPhone.DSTI = "0"
            ElseIf String.IsNullOrEmpty(objSampleLoad.DSTI.ToString.Trim) Then
                objPhone.DSTI = "0"
            Else
                objPhone.DSTI = objSampleLoad.DSTI
            End If
            If Not objSampleLoad.OKToText.IsNull Then objPhone.OKToText = objSampleLoad.OKToText

            Dim objEmail As New Email(objCase)
            objEmail.Person = objPerson
            objEmail.EmailAddress = objSampleLoad.EmailAddress
            If Not objSampleLoad.EmailTypeID.IsNull Then objEmail.EmailTypeID = objSampleLoad.EmailTypeID

            objPerson.BestPhone = objPhone
            objPerson.BestPhysicalAddress = objAddress
            objPerson.BestMailingAddress = objAddress
            objPerson.BestCheckAddress = objAddress
            objPerson.BestEmail = objEmail

            Dim objInstrument As New Instrument(objCase)
            objInstrument.SampleMember = objPerson
            objInstrument.CurrentRespondent = objPerson
            objInstrument.InstrumentTypeID = 9 'parent interview
            objInstrument.StatusChangeDate = DateTime.Now
            objInstrument.StatusChangedBy = "Test Sample Load"
            objInstrument.LogicalStatus = "0000"
            objInstrument.CurrentStatus = "0000"
            objInstrument.Round = 1

            'this is where you could put code to add Entity-specific data, such as Student or Teacher field
            'Dim objStudent As New Student(objPerson)
            'objStudent.Grade = objSampleLoad.Grade

            'this is where you could do some cleaning/verification via Melissa Data before saving


            'save the case into the databaes
            objCase.Insert()

            objCase.Dispose()

            objSampleLoad.Update()

            count += 1

            RaiseOnUpdate("Importing Sample... Please Wait", CInt((count * 100) / objDataTable.Rows.Count))

            If blnCanceled Then
                Exit For
            End If

        Next objDataRow
        objDataTable.Dispose()

        Project.CloseConnection()

        If blnCanceled Then
            RaiseOnComplete("Sample Load has been canceled.", MessageBoxIcon.Exclamation)
        Else
            RaiseOnComplete("Sample has been successfully imported.", MessageBoxIcon.Information)
        End If
    End Sub
End Class

Public Class AccurintImportThread
    Inherits ProgressThread 'Accurint Result Load

    Public Name As String

    Public Overrides Sub Run()
        Try
            'Added 10/9/2013 by April Villone 
            'This is a template for loading Accurint files with processing types  A (best 3 addresses) and P (best 3 phones)  
            'There are other process types that Accurint can run such as D (Deceased), E (best 3 emails), etc.  
            'See AccurintBatch.xlsx for more details under MPR.SMS in the Docs folder
            'These other options have not been programmed here and you will need to fill them in yourself.  
            'Commented locations are placed below so you know where to add those pieces if necessary
            'This code assumes that the best accurint address and phone should be set to best for the sample member, overriding what may already be set
            'Should the project not want this behaviour search for "Sets Best" and comment out or modify these pieces of code

            Dim blnCanceled As Boolean = False

            Dim objExtSampleLoad As New VwExtAccurintResult
            objExtSampleLoad.ConnectionString = Project.ConnectionString

            RaiseOnUpdate("Importing " + Name + "... Please Wait", 0)
            Dim objDataTable As DataTable = objExtSampleLoad.SelectAll()

            Dim objDataRow As DataRow
            Project.OpenConnection()

            Dim count As Integer = 0

            For Each objDataRow In objDataTable.Rows
                count += 1
                RaiseOnUpdate("Importing Sample... Please Wait", CInt((count * 100) / objDataTable.Rows.Count))

                Dim objSampleLoad As New VwExtAccurintResult(objDataRow)


                ''''''''''''''''''''''''''''
                '           Person         '
                ''''''''''''''''''''''''''''
                If objSampleLoad.Percaseid.IsNull Then
                    Continue For
                End If

                Dim objSampleMember As Person = New Person(objSampleLoad.Percaseid.ToString)
                Dim objCase As [Case] = New [Case](GetSafeValue(objSampleMember.CaseID), True)
                objSampleMember.Case = objCase
                If objCase.Persons.Count > 0 Then
                    Dim i As Integer = 0
                    For i = 0 To objCase.Persons.Count - 1
                        If objCase.Persons(i).MPRID.ToString = objSampleLoad.Percaseid.ToString Then
                            objSampleMember = objCase.Persons(i)
                            Exit For
                        End If
                    Next i
                End If


                ''''''''''''''''''''''''''''''''''
                'Insert Deceased Processing Here!'
                ''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''
                '         Address          '
                ''''''''''''''''''''''''''''

                If Not objSampleLoad.Address_Match.IsNull Then
                    Select Case GetSafeValue(objSampleLoad.Address_Match)
                        Case "New"
                            If _
                                Not objSampleLoad.Best_Street1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street1)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street1))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City1))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State1))
                                If Not objSampleLoad.Best_Zip1.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip1.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)

                                'Begin Sets Best Address code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestMailingAddress = objAddress
                                'End sets Best Address code
                            End If

                            If _
                                Not objSampleLoad.Best_Street2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street2)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street2))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City2))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State2))
                                If Not objSampleLoad.Best_Zip2.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip2.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)
                            End If

                            If _
                                Not objSampleLoad.Best_Street3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street3)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street3))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City3))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State3))
                                If Not objSampleLoad.Best_Zip3.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip3.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)
                            End If

                        Case "1"
                            If _
                                Not objSampleLoad.Best_Street2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street2)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street2))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City2))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State2))
                                If Not objSampleLoad.Best_Zip2.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip2.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)

                                'Begin Sets Best Address code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestMailingAddress = objAddress
                                'End Sets Best Address code

                            End If

                            If _
                                Not objSampleLoad.Best_Street3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street3)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street3))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City3))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State3))
                                If Not objSampleLoad.Best_Zip3.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip3.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)
                            End If
                        Case "2"
                            If _
                                Not objSampleLoad.Best_Street1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street1)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street1))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City1))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State1))
                                If Not objSampleLoad.Best_Zip1.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip1.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)

                                'Begin Sets Best Address code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestMailingAddress = objAddress
                                'End Sets Best Address code
                            End If

                            If _
                                Not objSampleLoad.Best_Street3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street3)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street3))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City3))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State3))
                                If Not objSampleLoad.Best_Zip3.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip3.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)
                            End If
                        Case "3"
                            If _
                                Not objSampleLoad.Best_Street1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street1)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street1))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City1))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State1))
                                If Not objSampleLoad.Best_Zip1.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip1.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)

                                'Begin Sets Best Address code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestMailingAddress = objAddress
                                'End Sets Best Address code
                            End If

                            If _
                                Not objSampleLoad.Best_Street2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Best_Street2)) Then
                                Dim objAddress As New Address(objCase)
                                objAddress.Person = objSampleMember
                                SetSafeValue(objAddress.Address1, GetSafeValue(objSampleLoad.Best_Street2))
                                SetSafeValue(objAddress.City, GetSafeValue(objSampleLoad.Best_City2))
                                SetSafeValue(objAddress.State, GetSafeValue(objSampleLoad.Best_State2))
                                If Not objSampleLoad.Best_Zip2.IsNull Then
                                    objAddress.PostalCode = GetSafeValue(objSampleLoad.Best_Zip2.ToString)
                                End If

                                objAddress.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objAddress.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch
                                objAddress.AddressTypeID = Data.Enumerations.AddressType.HomeAddress

                                objSampleMember.Addresses.Add(objAddress)
                            End If
                    End Select
                End If

                ''''''''''''''''''''''''''''
                '         Phone            '
                ''''''''''''''''''''''''''''
                If Not objSampleLoad.Phone_Match.IsNull Then
                    Select Case GetSafeValue(objSampleLoad.Phone_Match)
                        Case "New"
                            If _
                                Not objSampleLoad.Phone1_1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone1_1.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone1_1.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType1).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select

                                'Begin Sets Best Phone code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestPhone = objPhone
                                'End Sets Best Phone code
                            End If

                            If _
                                Not objSampleLoad.Phone2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone2.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone2.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType2).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select

                            End If

                            If _
                                Not objSampleLoad.Phone3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone3.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone3.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType3).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select
                            End If

                        Case "1"
                            If _
                                Not objSampleLoad.Phone2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone2.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone2.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType2).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select

                                'Begin Sets Best Phone code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestPhone = objPhone
                                'End Sets Best Phone code
                            End If

                            If _
                                Not objSampleLoad.Phone3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone3.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone3.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType3).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select
                            End If

                        Case "2"
                            If _
                                Not objSampleLoad.Phone1_1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone1_1.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone1_1.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType1).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select

                                'Begin Sets Best Phone code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestPhone = objPhone
                                'End Sets Best Phone code
                            End If

                            If _
                                Not objSampleLoad.Phone3.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone3.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone3.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType3).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select
                            End If
                        Case "3"
                            If _
                                Not objSampleLoad.Phone2.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone2.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone2.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType2).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select

                                'Begin Sets Best Phone code - comment out or modify if project wants different behaviour from the default
                                objSampleMember.BestPhone = objPhone
                                'End Sets Best Phone code

                            End If

                            If _
                                Not objSampleLoad.Phone1_1.IsNull AndAlso
                                Not String.IsNullOrEmpty(GetSafeValue(objSampleLoad.Phone1_1.ToString)) Then
                                Dim objPhone As New Phone(objCase)
                                objPhone.Person = objSampleMember
                                SetSafeValue(objPhone.PhoneNum, GetSafeValue(objSampleLoad.Phone1_1.ToString))
                                objSampleMember.Phones.Add(objPhone)

                                objPhone.SourceQualityID = Data.Enumerations.SourceQuality.Unknown
                                objPhone.SourceTypeID = Data.Enumerations.SourceType.AccurintBatch

                                objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Unknown

                                Select Case GetSafeValue(objSampleLoad.SwitchType1).ToLower
                                    Case "p"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "c"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Cell
                                    Case "v"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Home
                                    Case "g"
                                        objPhone.PhoneTypeID = Data.Enumerations.PhoneType.Pager
                                End Select
                            End If

                    End Select

                    ''''''''''''''''''''''''''''''''''
                    ' Insert Email Processing Here!  '
                    ''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''
                    'Insert Relative Processing Here!'
                    ''''''''''''''''''''''''''''''''''

                    '''''''''''''''''''''''''''''''''''
                    'Insert Associate Processing Here!'
                    '''''''''''''''''''''''''''''''''''
                End If

                objCase.Update()
                objCase.Dispose()

            Next objDataRow
            objDataTable.Dispose()

            'cnx.Close()
            'cnx = Nothing
            Project.CloseConnection()

            If blnCanceled Then
                RaiseOnComplete("Sample Load has been canceled.", MessageBoxIcon.Exclamation)
            Else
                RaiseOnComplete("Sample has been successfully imported.", MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        'Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub
End Class

Public Class BulkLocatingExport : Inherits ProgressThread 'Bulk Locating push to Confirmit

    Public Name As String
    Public FileName As String
    Private sqlda As New SqlDataAdapter
    Private conn As SqlClient.SqlConnection

    Public Overrides Sub Run()

        If FileName = String.Empty Then
            RaiseOnComplete("No file was selected. Update has been canceled.", MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim blnCanceled As Boolean = False

        RaiseOnUpdate("Importing " + Name + "... Please Wait", 0)

        'Project.OpenConnection()
        Dim openedHere As Boolean = False
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            conn = New SqlClient.SqlConnection(Project.ConnectionString)
            conn.Open()
            openedHere = True
        End If

        Dim count As Integer = 0

        RaiseOnUpdate("Running " + Name + "... Please Wait", 0)


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range
        Dim sentCount As Integer = 0

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(FileName)


        Try

            'First process 1st worksheetwith completed cases
            xlWorkSheet = CType(xlWorkBook.Worksheets(1), Excel.Worksheet)
            range = xlWorkSheet.UsedRange

            'Expected Column Headers
            Const c1 As String = "MPRID"
            Const c2 As String = "InstrumentTypeID"
            Const c3 As String = "PhoneIndexToReload"
            Const c4 As String = "PhoneToReload"

            Dim mprid As String
            Dim instrumentTypeId As String
            Dim phoneIndex As String
            Dim phoneToReload As String

            Dim pct As Integer
            Dim testInstrumentTypeID As Integer
            Dim testMPRID As Integer
            Dim testPhoneIndex As Integer = 0

            For rowCnt As Integer = 1 To range.Rows.Count

                mprid = GetSafeCellValue(range, rowCnt, 1)
                instrumentTypeId = GetSafeCellValue(range, rowCnt, 2)
                phoneIndex = GetSafeCellValue(range, rowCnt, 3)
                phoneToReload = GetSafeCellValue(range, rowCnt, 4)

                If rowCnt = 1 Then
                    If c1 <> mprid OrElse c2 <> instrumentTypeId OrElse c3 <> phoneIndex OrElse c4 <> phoneToReload Then
                        RaiseOnComplete("Invalid file format. MPRID, InstrumentTypeID, PhoneIndexToReload, and PhoneToReload expected. Update has been canceled.", MessageBoxIcon.Exclamation)
                        Exit Sub
                    End If
                Else
                    If mprid.Length > 0 Then

                        ' do some validation on input rows
                        Try
                            testMPRID = CType(mprid, Integer)
                        Catch ex As Exception
                            RaiseOnComplete("MPRID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            Exit Sub
                        End Try

                        If mprid.Length <> 8 Then
                            RaiseOnComplete("MPRID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If

                        Try
                            testInstrumentTypeID = CType(instrumentTypeId, Integer)
                        Catch ex As Exception
                            RaiseOnComplete("InstrumentTypeID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            Exit Sub
                        End Try

                        Try
                            If phoneIndex <> String.Empty Then
                                testPhoneIndex = CType(phoneIndex, Integer)
                            End If
                        Catch ex As Exception
                            RaiseOnComplete("PhoneIndexToReload must be 0-20 or empty at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            Exit Sub
                        End Try


                        ' look up case to send to CATI
                        Try

                            Dim sm As New Person(mprid)
                            Dim smCase As New [Case](sm.CaseID.Value, True)
                            'If sampleMember.Case Is Nothing Then
                            '    sampleMember.Case = New [Case](sampleMember.CaseID.Value, True)
                            'End If
                            Dim sampleMember As Person = smCase.PrimarySampleMember
                            Dim instToUpdate As Instrument = sampleMember.Case.Instruments.GetByInstrumentTypeID(testInstrumentTypeID)

                            ' inst must not be final, and SM must have a loc status
                            If instToUpdate.LogicalStatusObj.IsFinalStatus.IsFalse AndAlso
                               GetSafeValue(instToUpdate.CurrentPhone) > 0 AndAlso
                               GetSafeValue(sampleMember.LocatingStatus.LocatingStatus) <> String.Empty Then
                                If GetSafeValue(sampleMember.LocatingStatus.LocatingStatus) <> "1890" AndAlso
                                   sampleMember.LocatingStatus.Status.IsCaseInLocatingSupervisor.IsTrue AndAlso
                                    Not smCase.IsReadOnly Then

                                    ' find phone based on what's supplied (actual # or index), and update best if needed
                                    ProcessPhone(sampleMember, instToUpdate, phoneToReload, phoneIndex)

                                    If sampleMember.BestPhone IsNot Nothing Then
                                        sampleMember.LocatingStatus.LocatingStatus = "1890"
                                        If smCase.Update() Then
                                            sentCount += 1
                                        Else
                                            MessageBox.Show(mprid)
                                        End If
                                    Else
                                        MessageBox.Show(mprid)
                                    End If

                                End If
                            End If

                            smCase.Unlock()

                        Catch ex As Exception
                            RaiseOnComplete("Error occurred at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            Exit Sub
                        End Try


                    End If

                End If

                pct = CType(rowCnt * 100 / range.Rows.Count, Integer)
                If pct > 99 Then pct = 99
                RaiseOnUpdate("Importing Sample... Please Wait", pct)

            Next


        Catch ex As Exception

            blnCanceled = True
            RaiseOnComplete("Update has been canceled. Error: " & ex.Message.ToString(), MessageBoxIcon.Exclamation)

        End Try



        ' Close the Database 
        'Project.CloseConnection()
        If openedHere Then
            conn.Close()
        End If

        xlApp.Workbooks.Close()
        'xlWorkSheet = Nothing
        'xlWorkBook.Close()
        'xlApp = Nothing

        If blnCanceled Then
            RaiseOnComplete("Sample Load has been canceled.", MessageBoxIcon.Exclamation)
        Else
            RaiseOnComplete("Sample has been successfully imported. Records sent to CATI: " & CStr(sentCount), MessageBoxIcon.Information)
        End If


    End Sub

    Private Sub ProcessPhone(SampleMember As Person, InstToUpdate As Instrument, PhoneNum As String, PhoneIndex As String)

        ' remove any formatting from phone
        PhoneNum = Regex.Replace(PhoneNum, "[^\d]", "")

        Dim phoneSupplied As Boolean = False
        If PhoneNum <> String.Empty Then
            phoneSupplied = True
        End If

        Dim phoneIndexInt As Integer = 0
        If Not String.IsNullOrEmpty(PhoneIndex) Then
            phoneIndexInt = CInt(PhoneIndex)
        End If

        ' if only index is supplied, look up the phone # from Confirmit
        If PhoneNum = String.Empty AndAlso phoneIndexInt > 0 And phoneIndexInt <= 20 Then
            PhoneNum = GetPhoneFromConfirmit(InstToUpdate, CStr(PhoneIndex))
        End If

        ' if no phone supplied or found, exit
        If PhoneNum = String.Empty Then
            Exit Sub
        End If

        Dim phoneExists As Boolean = False
        If SampleMember.BestPhone.PhoneNum.Value = PhoneNum Then
            phoneExists = True
        End If

        ' update SM's best phone
        If SampleMember.BestPhone Is Nothing OrElse SampleMember.BestPhone.PhoneNum.Value <> PhoneNum Then
            For Each ph As Phone In SampleMember.Phones
                If GetSafeValue(ph.PhoneNum) = PhoneNum Then
                    SampleMember.BestPhone = ph
                    phoneExists = True
                    Exit For
                End If
            Next
        End If

        If SampleMember.Phones.Count = 0 OrElse (phoneExists = False AndAlso phoneSupplied = True) Then
            Dim newPhone As New Phone(SampleMember.Case)
            newPhone.Person = SampleMember
            SetSafeValue(newPhone.PhoneNum, PhoneNum)
            SampleMember.BestPhone = newPhone
        End If

    End Sub

    Private Function GetPhoneFromConfirmit(ByVal objInstrument As Instrument, phoneIndex As String) As String

        Try

            Dim fieldList As List(Of String)
            fieldList = New List(Of String)(2)
            fieldList.Add("PhoneList_" + phoneIndex)
            fieldList.Add("CurrentPhone")

            Dim filter As String = "MPRID=" & GetSafeValue(objInstrument.SampleMemberMPRID)
            Dim currentPhone As String

            Dim dt As DataTable
            dt = APITest.Data.GetForProject(Project.APIUser, Project.APIPwd, True, GetSafeValue(objInstrument.InstrumentType.SurveyID), fieldList, filter).Tables(0)
            For Each row As DataRow In dt.Rows
                currentPhone = CStr(row("CurrentPhone"))
                If IsNumeric(currentPhone) Then
                    If CInt(currentPhone) > 0 And CInt(currentPhone) <> GetSafeValue(objInstrument.CurrentPhone) Then
                        SetSafeValue(objInstrument.CurrentPhone, currentPhone)
                    End If
                End If

                Return row("PhoneList_" + phoneIndex).ToString()
            Next

        Catch ex As Exception

            MessageBox.Show("Error retrieving phone number from Confirmit using phone index.", Name, MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End Try

        Return String.Empty

    End Function

    Private Function GetSafeCellValue(ByVal range As Excel.Range, ByVal row As Integer, ByVal col As Integer) As String

        Dim obj As Excel.Range
        obj = CType(range.Cells(row, col), Excel.Range)
        If obj.Value IsNot Nothing Then
            Return obj.Value().ToString()
        End If
        Return String.Empty

    End Function

End Class


Public Class UrlImportThread : Inherits ProgressThread 'Import Adult url
    Public ImportFile As String
    Public Overrides Sub Run()

        Dim blnCanceled As Boolean = False

        ImportFile = SqlHelper.ExecuteScalar(Project.ConnectionString,
                                                                  CommandType.Text,
                                                                  "Select Value from tlkpSettings where setting = 'UrlImport'").ToString

        If String.IsNullOrEmpty(ImportFile) Then
            RaiseOnComplete("No import file specified", MessageBoxIcon.Exclamation)
            Return
        Else
            If Not IO.File.Exists(ImportFile) Then
                RaiseOnComplete("Can not find import file: " + ImportFile + ".", MessageBoxIcon.Exclamation)
                Return
            End If
        End If

        Dim dt As DataTable = ImportUtility.GetImportDataTable(ImportFile)
        If dt.Rows.Count = 0 Then
            RaiseOnComplete("Error importing csv file.", MessageBoxIcon.Exclamation)
            Return
        End If

        If blnCanceled Then
            RaiseOnComplete("Import has been canceled.", MessageBoxIcon.Exclamation)
            Return
        End If

        SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.StoredProcedure, "SMS_Admin_CleanExtUrlImport")
        If Not ImportUtility.ImportDataTable(dt, "dbo.extUrlImport") Then
            RaiseOnComplete("Nothing imported.", MessageBoxIcon.Exclamation)
            Return
        End If

        SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.StoredProcedure, "SMS_Admin_UpdateUrl")
        RaiseOnComplete("Url file " + ImportFile + " has been successfully imported.", MessageBoxIcon.Information)

    End Sub
End Class

Public Class TowerDataImportThread : Inherits ProgressThread

    Public ImportFile As String

    Public Overrides Sub Run()

        Dim blnCanceled As Boolean = False

        If String.IsNullOrEmpty(ImportFile) Then
            RaiseOnComplete("No import file specified", MessageBoxIcon.Exclamation)
            Return
        Else
            If Not IO.File.Exists(ImportFile) Then
                RaiseOnComplete("Can not find import file: " + ImportFile + ".", MessageBoxIcon.Exclamation)
                Return
            End If
        End If

        Dim dt As DataTable = ImportUtility.GetImportDataTable(ImportFile)
        If dt.Rows.Count = 0 Then
            RaiseOnComplete("Error importing excel file.", MessageBoxIcon.Exclamation)
            Return
        End If

        If blnCanceled Then
            RaiseOnComplete("Import has been canceled.", MessageBoxIcon.Exclamation)
            Return
        End If

        SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.StoredProcedure, "SMS_Admin_CleanExtTowerDataOutput")
        If Not ImportUtility.ImportDataTable(dt, "dbo.ExtTowerDataOutput") Then
            RaiseOnComplete("Nothing imported.", MessageBoxIcon.Exclamation)
            Return
        End If
        Dim prm As New SqlParameter("@CommitTransaction", SqlDbType.Int, 10, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, 1)
        SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.StoredProcedure, "SMS_Admin_TowerDataImport", prm)
        RaiseOnComplete("Tower Data file " + vbCrLf + ImportFile + vbCrLf + " has been successfully imported.", MessageBoxIcon.Information)

    End Sub

End Class


Public Class ImportUtility
    Const Delimitter As Char = ","c


    Public Shared Function GetImportFileName(ByVal strImportDirectory As String, ByVal strFileType As String) As String
        Dim dlgImport As New OpenFileDialog
        Select Case strFileType.ToUpper()
            Case "XLSX"
                dlgImport.Filter = "Excel File|*.xlsx"
            Case "TXT"
                dlgImport.Filter = "Text File|*.txt"
            Case "CSV"
                dlgImport.Filter = "Text File|*.csv"
        End Select

        dlgImport.Title = "Open import file"
        If Not String.IsNullOrEmpty(strImportDirectory) Then
            dlgImport.InitialDirectory = strImportDirectory
        Else
            dlgImport.InitialDirectory = "c:\"
        End If
        dlgImport.ShowDialog()
        Return dlgImport.FileName

    End Function

    Public Shared Function GetImportDataTable(ByVal fileName As String) As DataTable
        Dim source As String = String.Empty
        Dim dt As DataTable = New DataTable

        If Not IO.File.Exists(fileName) Then
            Throw New IO.FileNotFoundException("Could not find the file at " & fileName, fileName)
        End If

        source = IO.File.ReadAllText(fileName)
        Dim rows() As String = source.Split({Environment.NewLine}, StringSplitOptions.None)

        ' the first row is the heading, get columns
        Dim cols() As String = rows(0).Split(Delimitter)
        For i As Integer = 0 To cols.Length - 1
            dt.Columns.Add(cols(i))
        Next

        ' process the rest of data rows
        For i As Integer = 1 To rows.Length - 1
            Dim dr As DataRow = dt.NewRow
            Dim rowvalues() As String = rows(i).Split(Delimitter)

            If rowvalues.Length = dt.Columns.Count Then
                For x As Integer = 0 To rowvalues.Length - 1
                    dr(x) = rowvalues(x)
                Next
            Else
                'Throw New Exception("The number of columns on row " & i & " is not the same as the header row")
                'skip
                Continue For
            End If


            dt.Rows.Add(dr)
        Next

        Return dt
    End Function

    Public Shared Function ImportDataTable(ByVal dt As DataTable, ByVal destinationTable As String) As Boolean
        Dim con As String = Project.ConnectionString
        Dim bulkCopy As SqlBulkCopy = New SqlBulkCopy(con)
        bulkCopy.DestinationTableName = destinationTable
        Try
            bulkCopy.WriteToServer(dt)

        Catch ex As Exception

            Return False

        End Try

        Return True

    End Function
End Class

#End Region

#Region "Short URL"

Public Class ConfirmitUrlLoad : Inherits ProgressThread

    Public Name As String
    Public FileName As String
    Private sqlda As New SqlDataAdapter
    Private conn As SqlClient.SqlConnection

    Public Overrides Sub Run()

        If FileName = String.Empty Then
            RaiseOnComplete("No file was selected. Update has been canceled.", MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Project.UrlShortenerApiKey = String.Empty Then
            RaiseOnComplete("A project-specific key is required to use the URL Shortener API. Please contact TSG Solutions Architecture team. Update has been canceled.", MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        Dim blnCanceled As Boolean = False

        RaiseOnUpdate("Importing " + Name + "... Please Wait", 0)

        'Project.OpenConnection()
        Dim openedHere As Boolean = False
        If conn Is Nothing OrElse conn.State = ConnectionState.Closed Then
            conn = New SqlClient.SqlConnection(Project.ConnectionString)
            conn.Open()
            openedHere = True
        End If

        Dim count As Integer = 0

        RaiseOnUpdate("Running " + Name + "... Please Wait", 0)


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim range As Excel.Range

        xlApp = New Excel.Application
        xlWorkBook = xlApp.Workbooks.Open(FileName)

        Dim objShort As New Shortener(Project.UrlShortenerApiKey)
        Dim shorturl As String

        Try

            'First process 1st worksheetwith completed cases
            xlWorkSheet = CType(xlWorkBook.Worksheets(1), Excel.Worksheet)
            range = xlWorkSheet.UsedRange

            'Expected Column Headers
            Const c1 As String = "MPRID"
            Const c2 As String = "InstrumentTypeID"
            Const c3 As String = "SurveyLink"

            Dim strCol1 As String
            Dim strCol2 As String
            Dim strCol3 As String
            Dim pct As Integer
            Dim sbXml As New System.Text.StringBuilder
            Dim testInstrumentTypeID As Integer
            Dim testMPRID As Integer
            Dim batchCount As Integer = 0

            For rowCnt As Integer = 1 To range.Rows.Count

                strCol1 = GetSafeCellValue(range, rowCnt, 1)
                strCol2 = GetSafeCellValue(range, rowCnt, 2)
                strCol3 = GetSafeCellValue(range, rowCnt, 3)


                If rowCnt = 1 Then
                    If c1 <> strCol1 OrElse c2.ToUpper() <> strCol2.ToUpper() OrElse c3 <> strCol3 Then
                        RaiseOnComplete("Invalid file format. MPRID, InstrumentTypeID, and SurveyLink expected. Update has been canceled.", MessageBoxIcon.Exclamation)
                        xlWorkBook.Close(SaveChanges:=False)
                        xlApp = Nothing
                        Exit Sub
                    End If
                Else
                    If strCol1.Length > 0 Then

                        batchCount += 1

                        Try
                            testMPRID = CType(strCol1, Integer)
                        Catch ex As Exception
                            RaiseOnComplete("MPRID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            xlWorkBook.Close(SaveChanges:=False)
                            xlApp = Nothing
                            Exit Sub
                        End Try

                        If strCol1.Length <> 8 Then
                            RaiseOnComplete("MPRID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            xlWorkBook.Close(SaveChanges:=False)
                            xlApp = Nothing
                            Exit Sub
                        End If

                        Try
                            testInstrumentTypeID = CType(strCol2, Integer)
                        Catch ex As Exception
                            RaiseOnComplete("InstrumentTypeID is not a valid format at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            xlWorkBook.Close(SaveChanges:=False)
                            xlApp = Nothing
                            Exit Sub
                        End Try

                        Try
                            shorturl = objShort.GetShortUrl(strCol3)
                        Catch ex As Exception
                            RaiseOnComplete("Url could not be shortened at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            xlWorkBook.Close(SaveChanges:=False)
                            xlApp = Nothing
                            Exit Sub
                        End Try

                        If shorturl <> "" Then
                            sbXml.Append(String.Format("<row><ID>{0}</ID><A>{1}</A><B>{2}</B><C>{3}</C></row>", strCol1, strCol2, strCol3, shorturl))
                        Else
                            'close excel
                            RaiseOnComplete("Url could not be shortened at row " & rowCnt.ToString() & ". Update has been canceled.", MessageBoxIcon.Exclamation)
                            xlWorkBook.Close(SaveChanges:=False)
                            xlApp = Nothing
                            Exit Sub
                        End If

                        '>> stay under string size
                        If batchCount = 25 Then
                            SqlHelper.ExecuteScalar(Project.ConnectionString,
                                                    CommandType.StoredProcedure,
                                                    "dbo.[SMS_LoadConfirmitURL]",
                                                    New SqlClient.SqlParameter("@xml", sbXml.ToString()))
                            batchCount = 0
                            sbXml.Clear()
                        End If

                    End If

                End If

                pct = CType(rowCnt * 100 / range.Rows.Count, Integer)
                If pct > 99 Then pct = 99
                RaiseOnUpdate("Importing Sample... Please Wait", pct)

            Next

            If sbXml.Length > 0 Then
                SqlHelper.ExecuteScalar(Project.ConnectionString,
                 CommandType.StoredProcedure,
                 "dbo.[SMS_LoadConfirmitURL]",
                 New SqlClient.SqlParameter("@xml", sbXml.ToString()))

            End If

        Catch ex As Exception

            blnCanceled = True
            RaiseOnComplete("Update has been canceled. Error: " & ex.Message.ToString(), MessageBoxIcon.Exclamation)
            'close excel
            xlWorkBook.Close(SaveChanges:=False)
            xlApp = Nothing



        End Try

        'close excel
        xlWorkBook.Close(SaveChanges:=False)
        xlApp = Nothing

        ' Close the Database 
        'Project.CloseConnection()
        If openedHere Then
            conn.Close()
        End If

        If blnCanceled Then
            RaiseOnComplete("Sample Load has been canceled.", MessageBoxIcon.Exclamation)
        Else
            RaiseOnComplete("Sample has been successfully imported.", MessageBoxIcon.Information)
        End If


    End Sub

    Private Function GetSafeCellValue(ByVal range As Excel.Range, ByVal row As Integer, ByVal col As Integer) As String

        Dim obj As Excel.Range
        obj = CType(range.Cells(row, col), Excel.Range)
        If obj.Value IsNot Nothing Then
            Return obj.Value().ToString()
        End If
        Return String.Empty

    End Function

End Class


Public Class Shortener

    Sub New(ByVal ApiKey As String)

        _apikey = ApiKey

        SetNewClient(ApiKey)

        _shrtenerResponse = New ShrtenerResponse

    End Sub

    Const PostUrl As String = "https://getsurvey.link/prod/"

    'Const PostDataTemplate As String = 
    Const PostDataParr1 As String = "{ url_long:"""
    Const PostDataParr2 As String = """, cdn_prefix:""getsurvey.link""}"

    Private _client As System.Net.WebClient

    Private _apikey As String

    Private _shrtenerResponse As ShrtenerResponse

    Public ErrorMessage As String

    Private Function GetPostData(ByVal longUrl As String) As String

        Return PostDataParr1 & longUrl & PostDataParr2

    End Function


    Public Function GetShortUrl(longUrl As String) As String

        Dim shortUrl As String = String.Empty

        Try

            If _client Is Nothing Then
                SetNewClient(_apikey)
            End If

            If longUrl.Length > 0 Then
                _client.Headers.Add("User-Agent: Mathematica-SMS/ProjectShortName")    ' Add your project short name
                Using _client
                    Dim result As String = _client.UploadString(PostUrl, GetPostData(longUrl))

                    _shrtenerResponse = JsonConvert.DeserializeObject(Of ShrtenerResponse)(result)

                    shortUrl = _shrtenerResponse.url_short
                    ErrorMessage = _shrtenerResponse.error

                End Using
            End If

        Catch ex As Exception
            ErrorMessage = ex.Message

        End Try

        Return shortUrl

    End Function

    Private Sub SetNewClient(ByVal ApiKey As String)
        _client = New System.Net.WebClient()
        _client.Headers(HttpRequestHeader.ContentType) = "application/json"
        _client.Headers.Add("x-api-key", ApiKey)
    End Sub


    Private Class ShrtenerResponse

        Private m_url_short As String
        Public Property url_short() As String
            Get
                Return m_url_short
            End Get
            Set
                m_url_short = Value
            End Set
        End Property

        Private m_url_long As String
        Public Property url_long() As String
            Get
                Return m_url_long
            End Get
            Set
                m_url_long = Value
            End Set
        End Property

        Private m_error As String

        Public Property [error]() As String
            Get
                Return m_error
            End Get
            Set
                m_error = Value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class

End Class

#End Region