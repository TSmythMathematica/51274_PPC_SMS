'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Security.Principal
Imports MPR.SMS.Data

Public Class frmStudentEntry
    Inherits Form

    'NOTE: This is a template form for doing batch inserts of Student records
    '(or other types) under the same district/school (or even classroom). You 
    'should expect to modify this form for your project's needs, including 
    'adding fields, value validators, and required-field validators. 

#Region "Private Fields"

#End Region

#Region "Public Properties"

#End Region

#Region "Constructors"

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        Me.Text = "SMS - [" & Project.ShortName.ToString & "] - Student Entry"

        If Not Me.DesignMode Then
            Me.CenterToScreen()
            cboDistrict.SelectedDistrictID = - 1
            cboDistrict.SiteIDFilter = 0    'show all Districts
            cboSchools.DistrictIDFilter = - 1
            ClearFields()
            btnAddUpdate.Enabled = False
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Function AddCase() As Boolean

        Dim blnIsEligible As Boolean
        Dim strCurrStat As String

        If Not ValidateCase() Then
            Return False
            Exit Function
        End If

        '  Create a new Case object and a Person object within that case for the SampleMember

        Dim objCase As [Case] = New [Case](Data.Enumerations.tlkpEntityType.Student)


        '  Set all Case level data

        With objCase
            SetSafeValue(.EntityName, txtLastName.Text.ToString & " Family")
            'AF 06/21/12 Changed methods after DOC found that RND is not truely random...
            Dim r As New Random()
            .CaseRA.RandomNumber = r.NextDouble()
            '            .CaseRA.RandomNumber = New SqlDouble(Rnd())

            'determine eligibility
            blnIsEligible = True    'Not (GetSafeValue(objSampleLoad.ChildGradeLevel) = "0")

            SetSafeValue(.InSample, blnIsEligible)
            SetSafeValue(.IsIneligible, Not blnIsEligible)

            '  We now fill in Sample Member as the Student
            Dim objPersonSM As New Person(objCase)
            With objPersonSM
                SetSafeValue(.Title, "Student")
                .RelationshipTypeID = 1    '1=PrimarySampleMember

                SetSafeValue(.FirstName, StrConv(txtFirstName.Text, VbStrConv.ProperCase))
                SetSafeValue(.MiddleName, StrConv(txtMiddleName.Text, VbStrConv.Uppercase))
                SetSafeValue(.LastName, StrConv(txtLastName.Text, VbStrConv.ProperCase))
                If Not txtDOB.Text.Length.Equals(0) Then
                    SetSafeValue(.DateOfBirth, txtDOB.Text)
                End If
                If Not cboSex.Text.Equals("") Then
                    .GenderID = cboSex.SelectedIndex
                End If
                .InSample = objCase.InSample
                .IsIneligible = objCase.IsIneligible
                .ConsentID = 1             'Consented

                ' set up the Entity record, in this case Student
                With .Student
                    'SetSafeValue(.CaseID, objCase.CaseID.ToString)
                    SetSafeValue(.Grade, txtGrade.Text.ToString)
                    .GradeBaseline = .Grade
                    SetSafeValue(.SelectionOrder, txtSelOrder.Text)
                    SetSafeValue(.StudentNumber, txtStudentNum.Text)
                    '== get the Sample Indicator
                    If optMain.Checked Then
                        SetSafeValue(.SelectionType, "M")
                    Else
                        SetSafeValue(.SelectionType, "R")
                    End If
                    ' get the Student's School
                    .SchoolID = cboSchools.SelectedSchoolID

                    .MobilityCode = "000"
                    .MobilityDate = Now()
                End With

                'determine the Student's current age
                Try
                    SetSafeValue(.AgeAtSampling,
                                 DateDiff(DateInterval.Year, CType(txtDOB.ToString, Date), Now).ToString())
                Catch ex As Exception

                End Try

            End With

            '  We now fill in Current Respondent as the Parent
            Dim objPersonCR As New Person(objCase)
            With objPersonCR
                SetSafeValue(.Title, cboRelation.SelectedRelationshipType.RelationshipType.ToString)
                SetSafeValue(.FirstName, StrConv(txtPFirstName.Text, VbStrConv.ProperCase))
                SetSafeValue(.MiddleName, StrConv(txtPMiddleName.Text, VbStrConv.Uppercase))
                SetSafeValue(.LastName, StrConv(txtPLastName.Text, VbStrConv.ProperCase))
                .RelationshipTypeID = cboRelation.SelectedRelationshipTypeID
                .InSample = objCase.InSample
                .IsIneligible = objCase.IsIneligible
                .ConsentID = 1

            End With

            'set up the instrument
            strCurrStat = "0000"
            If Not blnIsEligible Then strCurrStat = "2460" 'Does not meet survey criteria

            Dim objInstrument As New Instrument(objCase)
            With objInstrument
                SetSafeValue(.CurrentStatus, strCurrStat)
                SetSafeValue(.StatusChangeDate, Now.ToString)
                SetSafeValue(.StatusChangedBy, WindowsIdentity.GetCurrent.Name)
                .InstrumentTypeID = 1     'change as needed
                .SampleMember = objPersonSM
                .CurrentRespondent = objPersonCR
            End With


            '  create a phone object, even if blank (easier for updating later).
            Dim objPhone1 As New Phone(objCase)
            objPersonSM.BestPhone = objPhone1
            objPersonCR.BestPhone = objPhone1
            With objPhone1
                SetSafeValue(.PhoneNum, txtPhoneNumber.Text)
                .PhoneTypeID = 0        'unknown
                .SourceTypeID = 1       'original sample
                .SourceQualityID = 2    'good
            End With

            '  create a secondary phone object, if given
            If Not txtSecondaryPhoneNum.Text.Equals("") Then

                Dim objPhone2 As New Phone(objCase)
                With objPhone2
                    SetSafeValue(.PhoneNum, txtSecondaryPhoneNum.Text)
                    .PhoneTypeID = 0        'unknown
                    .SourceTypeID = 1       'original sample
                    .SourceQualityID = 2    'good
                End With
            End If

            'create an Address, even if blank (easier for updating later)
            'Address info - Primary Mailing address
            Dim objAddress As New Address(objCase)
            With objAddress
                'SetSafeValue(.CaseID, objCase.CaseID.ToString)
                .SourceTypeID = 1       'original sample
                .AddressTypeID = 1      'Home
                .SourceQualityID = 2    'good

                SetSafeValue(.Address1, StrConv(txtAddress1.Text, VbStrConv.ProperCase))
                SetSafeValue(.Address2, StrConv(txtAddress2.Text, VbStrConv.ProperCase))
                'SetSafeValue(.Address3, StrConv(txtAddress3.Text, VbStrConv.ProperCase))
                'SetSafeValue(.Address4, StrConv(txtAddress4.Text, VbStrConv.ProperCase))
                SetSafeValue(.City, StrConv(txtCity.Text, VbStrConv.ProperCase))
                SetSafeValue(.State, cboState.SelectedStateAbbreviation)
                SetSafeValue(.PostalCode, txtZIP.Text)

            End With
            objPersonSM.BestPhysicalAddress = objAddress
            objPersonSM.BestMailingAddress = objAddress
            objPersonSM.BestCheckAddress = objAddress
            objPersonCR.BestPhysicalAddress = objAddress
            objPersonCR.BestMailingAddress = objAddress
            objPersonCR.BestCheckAddress = objAddress
        End With


        Try
            objCase.Insert()

            Dim objLock As New CaseLock(objCase.CaseID.Value)
            objLock.Delete()

            FillList(objCase)
            ClearFields()

            objCase.Dispose()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Project.Name, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Private Function ValidateCase() As Boolean

        Dim msg As String = ""

        Try
            'If txtGrade.Text.Length > 0 Then
            '    Try
            '        Dim i As Integer = System.Int32.Parse(txtGrade.Text)
            '        If Not (i >= 0 And i <= 12) Then
            '            msg = msg & vbCrLf & "Invalid value: Grade"
            '        End If
            '    Catch ex As Exception
            '        If Not (txtGrade.Text.ToUpper() = "K" Or txtGrade.Text.ToUpper() = "PK") Then
            '            msg = msg & vbCrLf & "Invalid value: Grade"
            '        End If
            '    End Try

            'End If
            'If Not (CType(txtSelOrder.Text, Integer) > 0 And CType(txtSelOrder.Text, Integer) < 21) Then
            '    msg = msg & vbCrLf & "Invalid value: Selection Order"
            'End If
            'If Not (CType(txtStudentNum.Text, Integer) > 0 And CType(txtStudentNum.Text, Integer) < 9999) Then
            '    msg = msg & vbCrLf & "Invalid value: Student #"
            'End If
            'If txtPhoneNumber.Text.Length > 0 And txtPhoneNumber.Text.Length < 10 Then
            '    msg = msg & vbCrLf & "Invalid length: Phone number"
            'End If


            ' validate selection order range
            Dim selOrder As Integer
            selOrder = Convert.ToInt32("0" + txtSelOrder.Text)


            'look-up existing cases to see if any dupes exist 
            '(by Name or Selection Order, per School)
            Dim strSQL As String
            Dim drSiteLookup As SqlDataReader

            strSQL = "SELECT COUNT(*) FROM tblStudent" &
                     " WHERE SchoolID = " & cboSchools.SelectedSchoolID &
                     " AND SelectionOrder = " & selOrder

            drSiteLookup = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, strSQL)

            While drSiteLookup.Read()
                If drSiteLookup.GetInt32(0) > 0 Then
                    msg = msg & vbCrLf &
                          "Duplicate Selection Order: a case with this Selection Order already exists for this school/certification."
                End If
            End While

            strSQL = "SELECT COUNT(*) FROM tblStudent INNER JOIN "
            strSQL = strSQL & "tblPerson ON tblStudent.MPRID = tblPerson.MPRID "
            strSQL = strSQL & "WHERE FirstName = '" & txtFirstName.Text.ToString & "' "
            strSQL = strSQL & "AND LastName = '" & txtLastName.Text.ToString & "' "
            strSQL = strSQL & "AND SchoolID = " & cboSchools.SelectedSchoolID & " "

            drSiteLookup = SqlHelper.ExecuteReader(Project.ConnectionString, CommandType.Text, strSQL)

            While drSiteLookup.Read()
                If drSiteLookup.GetInt32(0) > 0 Then
                    msg = msg & vbCrLf &
                          "Duplicate Student: a case with this First and Last Name already exists for this school."
                End If
            End While

            drSiteLookup.Close()

        Catch ex As Exception
            msg = msg & vbCrLf & "Invalid value - please check all fields"
        End Try

        If msg.Length > 0 Then
            msg = "This case cannot be entered because of the following:" & vbCrLf & msg
            MessageBox.Show(msg, Project.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ClearFields()

        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtGrade.Text = ""
        txtDOB.Text = ""
        cboSex.Text = ""
        txtSelOrder.Text = ""
        txtStudentNum.Text = ""
        optMain.Checked = False
        optReplacement.Checked = False
        txtPFirstName.Text = ""
        txtPMiddleName.Text = ""
        txtPLastName.Text = ""
        txtAddress1.Text = ""
        txtAddress2.Text = ""
        txtCity.Text = ""
        cboState.Text = ""
        txtZIP.Text = ""
        txtPhoneNumber.Text = ""
        txtSecondaryPhoneNum.Text = ""
        cboRelation.SelectedRelationshipTypeID = 2  '2=Parent/Guardian
        optMain.TabStop = True

        txtFirstName.Focus()
    End Sub

    Private Sub FillList(objCase As [Case])

        ' fill the listview
        Dim lvi As New ListViewItem(objCase.CaseID.ToString)
        lvi.Tag = objCase

        lvi.SubItems.Add(objCase.Persons(0).FullName)
        lvi.SubItems.Add(objCase.Persons(1).FullName)
        lvi.SubItems.Add(objCase.PrimarySampleMember.Student.StudentNumber.ToString)
        If GetSafeValue(objCase.PrimarySampleMember.Student.SelectionType) = "M" Then
            lvi.SubItems.Add(objCase.PrimarySampleMember.Student.SelectionOrder.ToString + " - Main")
        Else
            lvi.SubItems.Add(objCase.PrimarySampleMember.Student.SelectionOrder.ToString + " - Replacement")
        End If
        lvi.SubItems.Add(objCase.Persons(1).BestPhone.PhoneNum.ToString)

        lvwCases.Items.Add(lvi)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnAddUpdate_Click(sender As Object, e As EventArgs) Handles btnAddUpdate.Click

        If FormValidator.IsValid() Then
            DialogResult = DialogResult.OK
        Else
            FormValidator.Validate()
            DialogResult = DialogResult.None
        End If

        If DialogResult = DialogResult.OK Then
            If AddCase() Then
                ClearFields()
            End If
        End If
    End Sub

    Private Sub cmdExit_Click(sender As Object, e As EventArgs) Handles cmdExit.Click

        Dim dlgResult As DialogResult = DialogResult.No

        dlgResult = MessageBox.Show("Are you sure you want to exit?", Project.Name, MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        If dlgResult = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub cboDistrict_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDistrict.SelectedIndexChanged

        If cboSchools.Visible Then
            If cboDistrict.SelectedDistrictID > 0 Then
                Me.cboSchools.DistrictIDFilter = cboDistrict.SelectedDistrictID
            Else
                Me.cboSchools.DistrictIDFilter = - 1
            End If
            cboSchools.SelectedSchoolID = - 1
            cboSchools.Text = ""
        End If
        btnAddUpdate.Enabled = Not cboDistrict.SelectedDistrictID.Equals(0) And
                               Not cboSchools.SelectedSchoolID.Equals(0)
    End Sub

    Private Sub cboSchools_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSchools.SelectedIndexChanged

        btnAddUpdate.Enabled = Not cboDistrict.SelectedDistrictID.Equals(0) And
                               Not cboSchools.SelectedSchoolID.Equals(0)
    End Sub

    Private Sub txtStudentNum_TextChanged(sender As Object, e As EventArgs) Handles txtStudentNum.TextChanged

        Dim n As Integer
        Dim strReplacement As String
        'We want to only allow numbers in the student number field, so anything non-numeric, we can ignore.
        strReplacement = ""

        For n = 1 To Len(txtStudentNum.Text)
            If IsNumeric(Mid(txtStudentNum.Text, n, 1)) = True Then
                strReplacement = strReplacement & Mid(txtStudentNum.Text, n, 1)
            End If
        Next
        txtStudentNum.Text = strReplacement
        'Move the cursor to the end of the string
        txtStudentNum.SelectionStart = Len(txtStudentNum.Text)
    End Sub

    Private Sub txtSelOrder_TextChanged(sender As Object, e As EventArgs) Handles txtSelOrder.TextChanged

        Dim n As Integer
        Dim strReplacement As String
        'We want to only allow numbers in the position number field, so anything non-numeric, we can ignore.
        strReplacement = ""

        For n = 1 To Len(txtSelOrder.Text)
            If IsNumeric(Mid(txtSelOrder.Text, n, 1)) = True Then
                strReplacement = strReplacement & Mid(txtSelOrder.Text, n, 1)
            End If
        Next
        txtSelOrder.Text = strReplacement
        'Move the cursor to the end of the string
        txtSelOrder.SelectionStart = Len(txtSelOrder.Text)
    End Sub

#End Region
End Class
