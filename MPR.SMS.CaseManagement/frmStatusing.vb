'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Drawing.Drawing2D
Imports MPR.SMS.Data
Imports MPR.SMS.Locating
Imports MPR.SMS.Security
Imports MPR.SMS.UserControls

Public Class frmStatusing

#Region "Private Variables"

    Private mobjCase As [Case]
    Private mobjInstrument As Instrument = Nothing
    Private mobjDocument As Document = Nothing
    Private mintLastInstType As Integer = 0

    Private mScanType As ScanType
    Private SM_MPRID As String = ""     'Sample Member MPRID
    Private CR_MPRID As String = ""     'Current Respondent MPRID

    Private boolBestCheck As Boolean = False
    Private boolBestmail As Boolean = False
    Private boolBestPhys As Boolean = False
    Private mobjSMPerson As Person
    Private mobjDocStatus As DocumentStatus

    Const ToLocStatus As String = "1503"

    Private Enum ScanType
        Invalid = 0
        Instrument = 1
        Document = 2
    End Enum

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        tsslUser.Text = CurrentUser.Name
        optStatusing.Checked = True

        If Not Me.DesignMode Then FillDocumentStatuses()
        StartPosition = FormStartPosition.CenterScreen
    End Sub

#End Region

#Region "Private Methods"

    Private Sub SetForm()

        If Not TabOptions.TabPages("tabBatching") Is Nothing Then
            TabOptions.TabPages.Remove(TabOptions.TabPages("tabBatching"))
        End If
        If Not TabOptions.TabPages("tabReceipting") Is Nothing Then
            TabOptions.TabPages.Remove(TabOptions.TabPages("tabReceipting"))
        End If

        If optReceipt.Checked Or optStatusing.Checked Then
            TabOptions.TabPages.Add(tabReceipting)
            txtBarcode.Focus()
        Else
            TabOptions.TabPages.Add(tabBatching)
        End If
        cboInstrumentStatus.Visible = optStatusing.Checked
        cboDocumentStatus.Visible = optStatusing.Checked
        btnUpdate.Visible = optStatusing.Checked
        lblNotes.Visible = optStatusing.Checked
        txtNotes.Visible = optStatusing.Checked
        chkStatus.Visible = optStatusing.Checked
    End Sub

    Private Sub FillInstrumentStatuses(objInstType As InstrumentType)

        Dim strDefaultStatus As String = "0000"
        Dim SQL As String = ""
        If GetSafeValue(objInstType.IsCATI) Then
            SQL += "IsCATIStatus = 1"
            strDefaultStatus = "2010"
        End If
        If GetSafeValue(objInstType.IsCAPI) Then
            If Not SQL.Length.Equals(0) Then SQL += " OR "
            SQL += "IsCAPIStatus = 1"
            strDefaultStatus = "2020"
        End If
        If GetSafeValue(objInstType.IsCAWI) Then
            If Not SQL.Length.Equals(0) Then SQL += " OR "
            SQL += "IsCAWIStatus = 1"
            strDefaultStatus = "2030"
        End If
        If GetSafeValue(objInstType.IsHardcopy) Then
            If Not SQL.Length.Equals(0) Then SQL += " OR "
            SQL += "IsHardcopyStatus = 1"
            strDefaultStatus = "1353"
        End If
        If Not SQL.Length.Equals(0) Then SQL = "WHERE (" & SQL & ")"
        SQL += " AND (IsStatusAvailableInLocating = 0 AND IsStatusAvailableInLocatingSupervisor = 0)"

        'AS 05/07/14 - added IsActive=1, since StatusComboBox only shows Active statuses
        SQL += " AND IsActive = 1"
        cboInstrumentStatus.Filters = SQL

        cboInstrumentStatus.SelectedStatus = New Status(strDefaultStatus)
    End Sub

    Private Sub FillDocumentStatuses()

        cboDocumentStatus.Items.Clear()
        cboDocumentStatus.DisplayMember = "StatusDesc"
        cboDocumentStatus.ValueMember = "DocumentStatusID"

        For Each objStat As DocumentStatus In Project.DocumentStatuses
            'don't add "Queued" or "Sent"
            If objStat.DocumentStatusID.Value >= 3 Then
                cboDocumentStatus.Items.Add(objStat)
            End If
        Next
    End Sub

    Private Function GetScannedItem() As Boolean

        mobjInstrument = Nothing
        mobjDocument = Nothing

        'proper format of a Barcode ID should be either
        'Instruments: xxxxxxx-yy, where xxxxxxx = SM's MPRID, yy=InstrumentTypeID 
        'Documents: xxxxxxx-yy-zz, where xxxxxxx = SM's MPRID, yy=DocumentTypeID zz=Doc#

        ''Note: We are not scanning Documents at this time. Most of the code
        ''is here and ready to go, but we would need to add MPRID to tblDocument,
        ''in order to create barcode labels and scan them in. (see To-do below).
        ''Anything that requires scanning or statusing should be an Instrument.

        'Document scanning has been enabled. MPRID is extracted from the PersonHistoryID
        'SL 8/1/07

        Dim BarcodeParts As Array = txtBarcode.Text.Split(CChar("-"))

        Select Case BarcodeParts.Length
            Case 2
                mScanType = ScanType.Instrument
            Case 1
                mScanType = ScanType.Document
            Case Else
                mScanType = ScanType.Invalid
        End Select

        If mScanType = ScanType.Invalid Then
            MessageBox.Show("This is not a valid ID (incorrect length/format). Please re-enter or re-scan to try again.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False

            'uncomment this Else condition below to disallow scanning of documents
            'ElseIf mScanType = ScanType.Document Then
            '    MessageBox.Show("Documents cannot be scanned at this time. Only Instruments can be statused.", Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return False

        Else
            Try

                Dim objPerson As Person = Nothing
                Dim iType As Integer

                If mScanType = ScanType.Instrument Then

                    SM_MPRID = CStr(BarcodeParts.GetValue(0))
                    iType = CInt(BarcodeParts.GetValue(1))

                    objPerson = New Person(SM_MPRID)

                    If mobjCase IsNot Nothing Then mobjCase.Dispose()
                    Try
                        mobjCase = New [Case](objPerson.CaseID.Value, True)
                    Catch ex As Exception
                        MessageBox.Show(
                            "Case not found! The ID that was entered was mistyped or invalid. Please try again.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End Try

                    If mobjCase.IsReadOnly Then
                        MessageBox.Show(
                            "This case is either locked by another user, or you are not authorized to modify it.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    For i As Integer = 0 To mobjCase.Instruments.Count - 1
                        If mobjCase.Instruments(i).SampleMemberMPRID.ToString.Equals(SM_MPRID) AndAlso
                           mobjCase.Instruments(i).InstrumentTypeID.Value.Equals(iType) Then
                            mobjInstrument = mobjCase.Instruments(i)
                            Exit For
                        End If
                    Next
                    If mobjInstrument Is Nothing Then
                        MessageBox.Show(
                            "This barcode ID is not valid. The instrument type could not be found for this MPRID.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                    CR_MPRID = mobjInstrument.CurrentRespondentMPRID.ToString

                ElseIf mScanType = ScanType.Document Then
                    Dim iDocID As Integer = CInt(BarcodeParts.GetValue(0))

                    Dim objDocument As New Document(iDocID, True)
                    If objDocument Is Nothing Then
                        MessageBox.Show(
                            "Case not found! The ID that was entered was mistyped or invalid. Please try again.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    SM_MPRID = objDocument.PersonHistory.MPRID.ToString

                    objPerson = New Person(SM_MPRID)

                    If mobjCase IsNot Nothing Then mobjCase.Dispose()
                    Try
                        mobjCase = New [Case](objPerson.CaseID.Value, True)
                    Catch ex As Exception
                        MessageBox.Show(
                            "Case not found! The ID that was entered was mistyped or invalid. Please try again.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End Try

                    If mobjCase.IsReadOnly Then
                        MessageBox.Show(
                            "This case is either locked by another user, or you are not authorized to modify it.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If

                    mobjDocument = objDocument

                    'For i As Integer = 0 To mobjCase.Documents.Count - 1
                    '    If mobjCase.Documents(i).PersonHistory.MPRID.ToString.Equals(SM_MPRID) AndAlso _
                    '       mobjCase.Documents(i).DocumentID.Value.Equals(iDocID) Then
                    '        mobjDocument = mobjCase.Documents(i)
                    '        Exit For
                    '    End If
                    'Next
                    'CR_MPRID = ""   'not applicable to Documents
                    CR_MPRID = SM_MPRID
                End If

                If mobjInstrument Is Nothing And mobjDocument Is Nothing Then
                    mScanType = ScanType.Invalid
                    MessageBox.Show(
                        "This is not a valid ID (record not found). Please re-enter or re-scan to try again.",
                        Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                Else
                    lblMPRID.Text = SM_MPRID
                    lblSMName.Text = objPerson.FullName
                    lblCRName.Text = "n/a"
                    If mScanType = ScanType.Instrument Then
                        lblItemType.Text = mobjInstrument.InstrumentType.Description.ToString
                        lblStatus.Text = mobjInstrument.Status.DisplayName
                        If Not CR_MPRID.Equals("") Then lblCRName.Text = (New Person(CR_MPRID)).FullName

                        If iType <> mintLastInstType Then
                            FillInstrumentStatuses(mobjInstrument.InstrumentType)
                        End If
                        mintLastInstType = iType
                    Else
                        lblItemType.Text = mobjDocument.DocumentType.Description.ToString
                        lblStatus.Text = mobjDocument.DocumentStatus.StatusDesc.ToString
                        lblCRName.Text = ""
                        cboDocumentStatus.SelectedValue = 4     '4 = "Received - No QC"
                    End If
                    cboInstrumentStatus.Visible = (mScanType = ScanType.Instrument And optStatusing.Checked)
                    cboDocumentStatus.Visible = (mScanType = ScanType.Document And optStatusing.Checked)
                    Return True
                End If

            Catch ex As Exception
                MessageBox.Show("The following error occurred: " & ex.Message, Project.ShortName, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return False
            End Try

        End If
    End Function

    Private Sub UpdateAddressVariables()

        'Exit sub if no address is associated with the document
        If mobjDocument.AddressHistoryID.IsNull Then
            Exit Sub
        End If

        Dim objaddresshistory As New AddressHistory(CInt(mobjDocument.AddressHistoryID))

        For i As Integer = 0 To mobjCase.Addresses.Count - 1
            If mobjCase.Addresses(i).AddressID = objaddresshistory.AddressID Then
                'DO NOT change the original source type!
                'mobjCase.Addresses(i).SourceTypeID = GetSafeValue(MPR.SMS.Data.Enumerations.SourceType.PostOffice)
                If Not mobjDocStatus.SetOrigAddrQualityTo.IsNull Then
                    mobjCase.Addresses(i).SourceQualityID = GetSafeValue(mobjDocStatus.SetOrigAddrQualityTo)
                End If
                If Not mobjDocStatus.ReturnedMailSetTo.IsNull Then
                    mobjCase.Addresses(i).ReturnedMailReasonID = CInt(mobjDocStatus.ReturnedMailSetTo)
                End If
                Dim objAddressNote As New Note(mobjCase)
                With objAddressNote
                    .TableID = objaddresshistory.AddressID
                    SetSafeValue(.TableTypeID, "1") ' hard coded for now, needs to match to tlkpNoteType
                    .Case = mobjCase
                    .Person = mobjSMPerson
                    .MPRID = mobjSMPerson.MPRID
                    .SourceTypeID = GetSafeValue(Data.Enumerations.SourceType.PostOffice)
                    .CreatedOn = Now
                    If Not mobjDocStatus.OrigAddressNoteSet.IsNull Then
                        .Notes = mobjDocStatus.OrigAddressNoteSet
                    End If
                    .DocumentID = mobjDocument.DocumentID
                End With
                mobjCase.Notes.Add(objAddressNote)
                If _
                    Not mobjSMPerson.BestCheckAddress Is Nothing AndAlso
                    mobjSMPerson.BestCheckAddress.AddressID = objaddresshistory.AddressID Then
                    boolBestCheck = True
                End If
                If _
                    Not mobjSMPerson.BestMailingAddress Is Nothing AndAlso
                    mobjSMPerson.BestMailingAddress.AddressID = objaddresshistory.AddressID Then
                    boolBestmail = True
                    If mobjDocStatus.SetOrigAddrBestMailTo = "clear" Then
                        mobjSMPerson.BestMailingAddress = Nothing
                    End If
                End If
                If _
                    Not mobjSMPerson.BestPhysicalAddress Is Nothing AndAlso
                    mobjSMPerson.BestPhysicalAddress.AddressID = objaddresshistory.AddressID Then
                    boolBestPhys = True
                    If mobjDocStatus.SetOrigAddrBestPhysicalTo = "clear" Then
                        mobjSMPerson.BestPhysicalAddress = Nothing
                    End If
                End If
                Exit For  'exit after finding address
            End If
        Next i
    End Sub

    Private Function UpdateCase() As Boolean

        Dim sStatOld As String = ""
        Dim sStatNew As String = ""
        Dim sStatRes As String = ""
        Dim sPrevLastModifiedBy As String = ""
        Dim blnUpdateLastModified As Boolean = False

        mobjSMPerson = mobjCase.Persons(mobjCase.Persons.IndexOf(SM_MPRID))

        'AF 09/10/09 Changed logic to get caregiver from new case instead of person collection 
        '       of sample member case to fix issue where caregiver is not in the same case as sample member.
        Dim objCRPerson As Person = Nothing
        If Not CR_MPRID.Equals("") Then
            objCRPerson = New Person(CR_MPRID)
            objCRPerson.Case = New [Case](GetSafeValue(objCRPerson.CaseID), False)
        End If

        Dim iDocStatus As SqlInt32 = New SqlInt32(4)  'received - no QC
        Dim sType As String = ""
        Dim sInstStatus As SqlString = New SqlString("1353")
        If cboInstrumentStatus.SelectedStatus IsNot Nothing Then sInstStatus = cboInstrumentStatus.SelectedStatus.Code


        If mScanType = ScanType.Document Then
            If optStatusing.Checked Then
                iDocStatus =
                    New SqlInt32(GetSafeValue(CType(cboDocumentStatus.SelectedItem, DocumentStatus).DocumentStatusID))
            End If

            mobjDocStatus = New DocumentStatus(iDocStatus.Value)

            sStatOld = mobjDocument.DocumentStatus.StatusDesc.ToString
            mobjDocument.DocumentStatusID = iDocStatus
            sStatNew = mobjDocStatus.StatusDesc.ToString
            sType = mobjDocument.DocumentType.Description.ToString


            Try
                If mobjDocStatus.StatusTypeId = Data.Enumerations.DocumentStatusType.ForwardingAddressProvided Then
                    '03/18/2021 WJ: Copied codes from MIHOPE_CheckIn SMS / MPR.SMS.CaseManagement / frmStatusing.vb for dupilcate address fix when receipting documents with status forword address provided
                    Dim dt As DataTable
                    Dim NumberOfUniqueAddresses As Integer
                    Dim objAddressHistory As AddressHistory
                    Dim AddressID As Integer = 0

                    If Not mobjDocument.AddressHistoryID.IsNull Then
                        objAddressHistory = New AddressHistory(CInt(mobjDocument.AddressHistoryID))
                        AddressID = CInt(objAddressHistory.AddressID)
                    End If

                    'Cannot process forwarding address without Person or Mailing Address
                    If mobjSMPerson.MPRID.IsNull Or AddressID = 0 Then
                        MsgBox("No Person or Address connected to Document")
                        Exit Function
                    End If

                    'Check number of unique addresses per Person
                    'dt = DataUtility.GetDataTable("dbo.[SMS_GetNumberUniqueAddressesPerPerson]",
                    '     "@MPRID", CStr(mobjSMPerson.MPRID), 8)
                    'NumberOfUniqueAddresses = CInt(dt.Rows(0).Item("NumberUniqueAddresses"))

                    dt = GetDataTable1Par("dbo.[SMS_GetNumberUniqueAddressesPerPerson]",
                        "@MPRID", CStr(mobjSMPerson.MPRID), 8)
                    NumberOfUniqueAddresses = CInt(dt.Rows(0).Item("NumberUniqueAddresses"))

                    '**Boris - added to check if Forwarding Address already exists
                    If NumberOfUniqueAddresses > 1 Then
                        Dim frmFindAddress As New frmSelectionForForwardingAddress(mobjCase, mobjSMPerson, AddressID)

                        frmFindAddress.ShowDialog(Me)
                        If frmFindAddress.ExitMode = frmSelectionForForwardingAddress.Mode.Cancel Then
                            Exit Function
                        ElseIf frmFindAddress.ExitMode = frmSelectionForForwardingAddress.Mode.AddressExists Then
                            UpdateAddressVariables()
                        ElseIf frmFindAddress.ExitMode = frmSelectionForForwardingAddress.Mode.AddressNotExists Then
                            UpdateAddressVariables()

                            '***Boris September 11, 2020
                            'Define boolBestCheck=True, boolBestMail=True, boolBestPhys=True 
                            Dim frmForwardingAddress As New frmAddAddress(objCase:=mobjCase, objPerson:=mobjSMPerson,
                                boolBestCheck:=False, boolBestMail:=True, boolBestPhys:=True, Document:=mobjDocument)
                            frmForwardingAddress.ShowDialog(Me)
                        End If
                    Else
                        UpdateAddressVariables()

                        Dim frmForwardingAddress As New frmAddAddress(mobjCase, mobjSMPerson, boolBestCheck, boolBestmail, boolBestPhys, mobjDocument)
                        frmForwardingAddress.ShowDialog(Me)
                    End If
                    '03/18/2021 WJ:

                    '03/18/2021 WJ: commented out old codes
                    'UpdateAddressVariables()

                    ' Dim _
                    'frmForwardingAddress As _
                    '        New frmAddAddress(mobjCase, mobjSMPerson, boolBestCheck, boolBestmail, boolBestPhys,
                    'mobjDocument)
                    'frmForwardingAddress.ShowDialog(Me)
                    '03/18/2021 WJ: commented out old codes

                ElseIf _
                    mobjDocStatus.StatusTypeId = Data.Enumerations.DocumentStatusType.NoForwardingAddressProvided AndAlso
                    mobjDocument.DocumentType.IsNoForwardingAddressRemail = True Then

                    UpdateAddressVariables()

                    Dim _
                        frmNoForwardingAddress As _
                            New frmRemailDocument(mobjCase, mobjSMPerson, mobjDocument.DocumentType, mobjDocument)
                    frmNoForwardingAddress.ShowDialog(Me)

                ElseIf _
                    mobjDocStatus.StatusTypeId = Data.Enumerations.DocumentStatusType.NoForwardingAddressProvided AndAlso
                    mobjDocument.DocumentType.IsNoForwardingAddressRemail = False Then

                    If mobjDocument.DocumentType.IsSendToLocating = True Then

                        If mobjDocument.DocumentType.MailType = "I" Then
                            Dim intInstrument As Integer
                            For intInstrument = 0 To mobjCase.Instruments.Count - 1
                                If _
                                    mobjCase.Instruments(intInstrument).InstrumentTypeID =
                                    mobjDocument.DocumentType.InstrumentTypeId Then
                                    If _
                                        mobjCase.Instruments(intInstrument).StatusUpdateRuleResult(
                                            mobjCase.Instruments(intInstrument).CurrentStatus, ToLocStatus) =
                                        Instrument.StatusUpdateResult.Override Then
                                        mobjCase.Instruments(intInstrument).CurrentStatus = ToLocStatus
                                        mobjCase.Instruments(intInstrument).LogicalStatus = ToLocStatus
                                        Dim _
                                            objlocatingstatus As _
                                                New LocatingStatus(mobjCase.Instruments(intInstrument).CurrentRespondent)
                                        objlocatingstatus.LocatingStatus = ToLocStatus
                                        objlocatingstatus.StatusDate = Now
                                        objlocatingstatus.DateSentToLocating = Now
                                        mobjCase.Instruments(intInstrument).CurrentRespondent.LocatingStatus =
                                            objlocatingstatus
                                    ElseIf _
                                        mobjCase.Instruments(intInstrument).StatusUpdateRuleResult(
                                            mobjCase.Instruments(intInstrument).CurrentStatus, ToLocStatus) =
                                        Instrument.StatusUpdateResult.Error Then
                                        MsgBox(
                                            "The status was unable to be updated due to Status Update Rules.  Please contact your SMS programmer to resolve.",
                                            MsgBoxStyle.Information, "Status Cannot Be Updated")
                                    End If
                                End If
                            Next intInstrument

                        Else

                            'From Dan 12/10/2014: why loop through the case to find the person with same MPRID as mobjSMPerson, instead of just using mobjSMPerson?

                            'Dim intperson As Integer
                            'For intperson = 0 To mobjCase.Persons.Count - 1
                            '    If mobjCase.Persons(intperson).MPRID = mobjSMPerson.MPRID Then
                            '        If mobjCase.Persons(intperson).LocatingStatus.StatusUpdateRuleResult(mobjCase.Persons(intperson).LocatingStatus.Status.Code, ToLocStatus) = Instrument.StatusUpdateResult.Override Then
                            '            mobjCase.Persons(intperson).LocatingStatus.Status.Code = ToLocStatus
                            '        ElseIf mobjCase.Persons(intperson).LocatingStatus.StatusUpdateRuleResult(mobjCase.Persons(intperson).LocatingStatus.Status.Code, ToLocStatus) = Instrument.StatusUpdateResult.Error Then
                            '            MsgBox("The status was unable to be updated due to Status Update Rules.  Please contact your SMS programmer to resolve.", MsgBoxStyle.Information, "Status Cannot Be Updated")
                            '        End If
                            '    End If
                            'Next intperson

                            If _
                                mobjSMPerson.LocatingStatus.StatusUpdateRuleResult(
                                    mobjSMPerson.LocatingStatus.Status.Code, ToLocStatus) =
                                Instrument.StatusUpdateResult.Override Then
                                mobjSMPerson.LocatingStatus.Status.Code = ToLocStatus
                            ElseIf _
                                mobjSMPerson.LocatingStatus.StatusUpdateRuleResult(
                                    mobjSMPerson.LocatingStatus.Status.Code, ToLocStatus) =
                                Instrument.StatusUpdateResult.Error Then
                                MsgBox(
                                    "The status was unable to be updated due to Status Update Rules.  Please contact your SMS programmer to resolve.",
                                    MsgBoxStyle.Information, "Status Cannot Be Updated")
                            End If

                        End If

                    End If

                    UpdateAddressVariables()

                ElseIf mobjDocStatus.StatusTypeId = Data.Enumerations.DocumentStatusType.PostageDue Then

                    If mobjDocument.DocumentType.IsForwardingAddressRemail = True Then
                        Dim objNewDoc As New Document(mobjCase, mobjDocument.DocumentType)
                        With objNewDoc
                            .PersonHistory = mobjDocument.PersonHistory
                            .AddressHistory = mobjDocument.AddressHistory
                            .DocumentNum = mobjDocument.DocumentNum + 1
                            .DocumentStatusID = 1
                            .Instrument = mobjDocument.Instrument
                            .Round = mobjDocument.Round
                        End With

                        mobjCase.Documents.Add(objNewDoc)

                    End If

                    UpdateAddressVariables()

                End If
            Catch ex As Exception
                MessageBox.Show("The following error occurred: " & ex.Message, Project.ShortName, MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            End Try

            mobjDocument.DocumentStatus.StatusTypeId = iDocStatus
            mobjDocument.Update()

        Else 'scanned an Instrument
            sStatOld = mobjInstrument.CurrentStatus.ToString
            mobjInstrument.CurrentStatus = sInstStatus
            '#1580
            sStatNew = sInstStatus.ToString
            sType = mobjInstrument.InstrumentType.Description.ToString

            'if this Instrument Type is a Consent Form, pop-up the Consent window.
            If GetSafeValue(mobjInstrument.InstrumentType.IsConsentForm) Then
                Dim frm As New frmConsent(mobjSMPerson, True, True)
                frm.StartPosition = FormStartPosition.CenterParent
                frm.ShowDialog()
            End If

            'If the Status changed...
            Dim enmStatusUpdateResult As Instrument.StatusUpdateResult = Instrument.StatusUpdateResult.NoAction
            Try
                enmStatusUpdateResult = mobjInstrument.StatusUpdateRuleResult(sStatOld, sStatNew)
            Catch ex As Exception
                MessageBox.Show("Problem updating status from " & sStatOld & " to " & sStatNew & ".  " _
                                & "Please report this error to tech support:" _
                                & Environment.NewLine & Environment.NewLine & ex.Message,
                                Project.ShortName & " - Status Update Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
                Return False ' >>>>
            End Try
            If enmStatusUpdateResult = Instrument.StatusUpdateResult.Override Then

                mobjInstrument.LogicalStatus = sInstStatus

                'BEGIN: Locating logic
                If objCRPerson IsNot Nothing Then
                    Dim blnNewInLocating As Boolean =
                            (GetSafeValue(cboInstrumentStatus.SelectedStatus.IsCaseInLocating) Or
                             GetSafeValue(cboInstrumentStatus.SelectedStatus.IsCaseInLocatingSupervisor))
                    Dim blnOldInLocating As Boolean =
                            (GetSafeValue(objCRPerson.LocatingStatus.Status.IsCaseInLocating) Or
                             GetSafeValue(objCRPerson.LocatingStatus.Status.IsCaseInLocatingSupervisor))

                    'flag to denote Final but not Unlocatable
                    'AF 12/27/07 add flag for unlocatable to check below... 
                    Dim blnIsFinal As Boolean = GetSafeValue(mobjInstrument.Status.IsFinalStatus)
                    'Dim blnIsFinalUnlocatable As Boolean = GetSafeValue(mobjInstrument.CurrentStatus).Equals("2590") Or _
                    '                                       GetSafeValue(mobjInstrument.CurrentStatus).Equals("2591")
                    Dim blnIsFinalUnlocatable As Boolean = GetSafeValue(mobjInstrument.CurrentStatus).StartsWith("25") _
                    'check for ANY final unlocatable.


                    'if the New Status is IN Locating, update LocatingStatus
                    If blnNewInLocating Then

                        With objCRPerson.LocatingStatus
                            .LocatingStatus = sStatNew
                            .StatusDate = Now
                            .NoOfTimesTouched = GetSafeValue(.NoOfTimesTouched) + 1
                            If .IsMovedIntoLocating Then
                                .NoOfTimesLocating = GetSafeValue(.NoOfTimesLocating) + 1
                                .DateSentToLocating = Now
                            End If
                        End With


                        'if the New Status is final (and not 2590/2591) and 
                        'new status is OUT of Locating and the Old 
                        'Status was IN Locating...
                    ElseIf blnIsFinal AndAlso blnOldInLocating Then

                        'create a locating attempt record, with a note, indicating the original
                        'respondent in locating had a final status outside of locating.
                        'for each case member still in locating, add the attempt/note
                        For Each objPerson As Person In mobjCase.Persons
                            If objPerson.LocatingStatus IsNot Nothing AndAlso
                               (objPerson.LocatingStatus.Status.IsCaseInLocating Or
                                objPerson.LocatingStatus.Status.IsCaseInLocatingSupervisor Or
                                objPerson.MPRID.ToString.Equals(CR_MPRID)) Then
                                Dim objLocAtt As New LocatingAttempt(objPerson)
                                With objLocAtt
                                    .Person = objPerson
                                    .PersonLocated = objCRPerson
                                    .Note = GetSafeValue(mobjInstrument.InstrumentType.Description) &
                                            " has been final statused as " & sStatNew &
                                            " for " & objCRPerson.FullName & " (" & objCRPerson.MPRID.ToString & ")"
                                    .LocatingStatus = sStatNew
                                    .LocatingAttemptTypeID = 0      'Other
                                    .LocatingAttemptResultID = 0    'No new info found
                                    .LocatingAttemptDate = Now
                                End With

                            End If
                        Next

                        'then if there are no other instruments in Locating for 
                        'this Respondent, then update LocatingStatus to take them
                        'out of Locating.
                        Dim blnOutOfLocating As Boolean = True
                        For Each objInst As Instrument In mobjCase.Instruments
                            If objInst.CurrentRespondentMPRID.ToString.Equals(CR_MPRID) AndAlso
                               Not objInst.InstrumentID.Value.Equals(mobjInstrument.InstrumentID.Value) AndAlso
                               (objInst.Status.IsCaseInLocating Or
                                objInst.Status.IsCaseInLocatingSupervisor) Then
                                blnOutOfLocating = False
                                Exit For
                            End If
                        Next

                        If blnOutOfLocating Then
                            'take respondent out of locating
                            Try
                                With objCRPerson.LocatingStatus
                                    'first store current LastModifiedBy...
                                    sPrevLastModifiedBy = GetSafeValue(.LastModifiedBy)

                                    If blnIsFinalUnlocatable Then 'if 2590 or 2591 just set locating code = status code
                                        .LocatingStatus = sStatNew
                                    ElseIf mobjInstrument.Status.IsCAWIStatus Or
                                           mobjInstrument.Status.IsCAPIStatus Or
                                           mobjInstrument.Status.IsHardcopyStatus Then
                                        .LocatingStatus = "1891"     'address found?
                                        blnUpdateLastModified = True
                                    Else
                                        .LocatingStatus = "1890"     'phone # found
                                        blnUpdateLastModified = True
                                    End If
                                    .StatusDate = Now
                                    .Update()
                                End With
                            Catch ex As Exception
                                MessageBox.Show("Problem removing " & objCRPerson.MPRID.ToString & " from Locating  " _
                                                & "Please report this error to tech support:" _
                                                & Environment.NewLine & Environment.NewLine & ex.Message,
                                                Project.ShortName & " - Remove from Locating Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End Try
                        End If
                    End If
                End If
                'END: Locating logic - AF 12/27/07 we need to now do one more step
                ' after case update below (check and possibly update lastmodifiedby)
            End If
        End If

        Try
            'if update was successful, then insert a Note record if one was entered
            'DJO 12/15/2014: Update Case after adding Note
            If optStatusing.Checked AndAlso
               txtNotes.Text.Length > 0 Then

                Dim NoteMPRID As String

                If CR_MPRID.Equals("") Then
                    NoteMPRID = GetSafeValue(SM_MPRID) + ", "
                Else
                    NoteMPRID = GetSafeValue(CR_MPRID) + ", "
                End If

                'tblNote doesn't allow for this
                'If mScanType = ScanType.Instrument Then
                '    NoteInstrumentTypeID = GetSafeValue(mobjInstrument.InstrumentTypeID)
                '    NoteSource = "Instrument Statusing"
                'Else
                '    NoteInstrumentTypeID = Nothing
                '    NoteSource = "Document Statusing"
                'End If

                'InsertInstrumentNote(mobjCase.CaseID, NoteMPRID, NoteInstrumentTypeID, NoteSource, CurrentUser.Name, txtNotes.Text)
                Dim objNote As New Note(mobjCase)
                With objNote
                    If mobjDocument IsNot Nothing Then
                        .DocumentID = mobjDocument.DocumentID
                        .TableID = mobjDocument.DocumentID  'redundant, but need to enter a value
                        SetSafeValue(.TableTypeID, "5") ' hard coded for now, needs to match to tlkpNoteType
                    ElseIf mobjInstrument IsNot Nothing Then
                        .TableID = mobjInstrument.InstrumentID
                        SetSafeValue(.TableTypeID, "6") ' hard coded for now, needs to match to tlkpNoteType
                    End If
                    .MPRID = NoteMPRID 'setting MPRID is useless. In Note.Insert, if Person is Nothing, it sets MPRID=""
                    .Person = objCRPerson
                    .SourceTypeID = 16 'Other?
                    .Notes = txtNotes.Text
                End With
                mobjCase.Notes.Add(objNote)
            End If

            If Not mobjCase.Update() Then
                MessageBox.Show("Case Update failed in frmStatusing. Please contact your SMS Programmer to resolve.",
                                Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

            'AF 12/27/07 Update LastmodifiedBy in LocatingStatus if necessary
            '   (this is done for productivity reports, so the locator gets credit instead of the barcode scanner)
            If blnUpdateLastModified Then
                objCRPerson.LocatingStatus.UpdateLastModifiedBy(objCRPerson.LocatingStatus.LocatingStatusID,
                                                                sPrevLastModifiedBy)
            End If

            'get the result status (after the Case is updated.)
            If mScanType = ScanType.Document Then
                sStatRes = sStatNew   'Document Statuses always overwrite
            Else 'Instrument statuses go through the Update Rules upon updating the Case.
                sStatRes = mobjInstrument.CurrentStatus.ToString
            End If

            'add the item to the listbox
            Dim lvi As New ListViewItem(txtBarcode.Text)
            lvi.SubItems.Add(sType.ToString)
            If CR_MPRID.Equals("") Then
                lvi.SubItems.Add("n/a")
            Else
                lvi.SubItems.Add((New Person(CR_MPRID)).FullName)
            End If
            lvi.SubItems.Add(sStatOld)
            lvi.SubItems.Add(sStatNew)
            lvi.SubItems.Add(sStatRes)
            lstSession.Items.Add(lvi)
            tsslCount.Text = "Items scanned: " & lstSession.Items.Count.ToString

            'if a Locating status is selected (and overrides the old code), 
            'check if the user opted to open the Respondent in locating now.
            Dim frm As Form = Nothing
            If chkLocating.Visible AndAlso chkLocating.Checked AndAlso
               sStatRes = sStatNew AndAlso Not CR_MPRID.Equals("") Then
                frm = New frmLocatingMain(mobjCase, CR_MPRID)
                frm.Show()
            Else
                mobjCase.Dispose()
            End If

            'if statusing, clear the info fields after each update:
            If optStatusing.Checked Then
                lblMPRID.Text = ""
                lblSMName.Text = ""
                lblCRName.Text = ""
                lblItemType.Text = ""
                lblStatus.Text = ""
            End If

            'clear the form's fields
            txtBarcode.Text = ""
            If Not chkStatus.Checked Then
                cboDocumentStatus.SelectedIndex = -1
                cboInstrumentStatus.SelectedStatus = Nothing
            End If
            txtNotes.Text = ""
            txtBarcode.Focus()

            If frm IsNot Nothing Then frm.BringToFront()

            Return True

        Catch ex As Exception
            MessageBox.Show("The following error occurred: " & ex.Message, Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
            Return False
        End Try
    End Function

    Private Sub ExecuteSQL(SQL As String)

        Try
            Dim conn As New SqlConnection(Project.ConnectionString)
            Dim cmdSQL As New SqlCommand(SQL, conn)
            conn.Open()
            cmdSQL.ExecuteNonQuery()
            conn.Close()
            cmdSQL.Dispose()
        Catch ex As Exception
            MessageBox.Show("The following error occurred: " & ex.Message, Project.ShortName, MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub InsertInstrumentNote(CaseID As SqlInt32, MPRID As SqlString, InstrumentTypeID As SqlInt32,
                                     Source As SqlString, UserName As SqlString, Notes As SqlString)

        Dim ErrorCode As Integer
        Dim cmdSQL As SqlCommand = New SqlCommand
        cmdSQL.Connection = New SqlConnection
        cmdSQL.Connection.ConnectionString = Project.ConnectionString
        cmdSQL.Connection.Open()

        cmdSQL.CommandText = "SMS_InsertStatusingNote"
        cmdSQL.CommandType = CommandType.StoredProcedure

        Try
            cmdSQL.Parameters.Clear()
            cmdSQL.Parameters.Add(New SqlParameter("@CaseID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0,
                                                   "", DataRowVersion.Proposed, CaseID))
            cmdSQL.Parameters.Add(New SqlParameter("@MPRID", SqlDbType.VarChar, 8, ParameterDirection.Input, True, 0, 0,
                                                   "", DataRowVersion.Proposed, MPRID))
            cmdSQL.Parameters.Add(New SqlParameter("@InstrumentTypeID", SqlDbType.Int, 4, ParameterDirection.Input, True,
                                                   10, 0, "", DataRowVersion.Proposed, InstrumentTypeID))
            cmdSQL.Parameters.Add(New SqlParameter("@Source", SqlDbType.VarChar, 25, ParameterDirection.Input, True, 0,
                                                   0, "", DataRowVersion.Proposed, Source))
            cmdSQL.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0,
                                                   0, "", DataRowVersion.Proposed, UserName))
            cmdSQL.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 2000, ParameterDirection.Input, True, 0,
                                                   0, "", DataRowVersion.Proposed, Notes))
            cmdSQL.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10,
                                                   0, "", DataRowVersion.Proposed, ErrorCode))

            cmdSQL.ExecuteNonQuery()

            ErrorCode = CType(cmdSQL.Parameters.Item("@ErrorCode").Value, Integer)

            If Not ErrorCode.Equals(0) Then
                Throw _
                    New Exception(
                        "Stored Procedure 'SMS_InsertStatusingNote' reported the ErrorCode: " & ErrorCode.ToString())
            End If

        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "SMS_InsertStatusingNote::Error occured." + Environment.NewLine + Environment.NewLine + ex.Message,
                    ex)

        Finally
            cmdSQL.Dispose()
        End Try
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub optReceipt_CheckedChanged(sender As Object, e As EventArgs) Handles optReceipt.CheckedChanged

        tabReceipting.Text = "Receipting"
        SetForm()
    End Sub

    Private Sub optStatusing_CheckedChanged(sender As Object, e As EventArgs) Handles optStatusing.CheckedChanged

        tabReceipting.Text = "Statusing"
        SetForm()
    End Sub

    Private Sub optBatching_CheckedChanged(sender As Object, e As EventArgs) Handles optBatching.CheckedChanged

        SetForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        If mobjCase IsNot Nothing Then mobjCase.Dispose()
        Me.Close()
    End Sub

    Private Sub txtBarcode_Enter(sender As Object, e As EventArgs) Handles txtBarcode.Enter

        tsslStatus.Text = "Scan the barcode ID, or type in the ID and then press Enter."
        txtBarcode.SelectAll()
    End Sub

    Private Sub txtBarcode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBarcode.KeyPress

        If e.KeyChar = Chr(Keys.Enter) Or e.KeyChar = Chr(Keys.Tab) Then
            txtSkip.Focus()
        End If
    End Sub

    Private Sub txtBarcode_LostFocus(sender As Object, e As EventArgs) Handles txtBarcode.LostFocus

        'If txtBarcode.Text.Length >= 8 AndAlso _
        '   SM_MPRID <> txtBarcode.Text.Substring(0, 8) Then
        '    txtSkip.Focus()
        'ElseIf txtBarcode.Text.Length < 8 Then
        '    txtBarcode.Focus()
        'End If
    End Sub

    Private Sub txtSkip_Enter(sender As Object, e As EventArgs) Handles txtSkip.Enter

        If GetScannedItem() Then
            If optReceipt.Checked Then
                UpdateCase()
            ElseIf optStatusing.Checked Then
                SendKeys.Flush()
                If mScanType = ScanType.Document Then
                    cboDocumentStatus.Focus()
                Else
                    cboInstrumentStatus.Focus()
                End If
            End If
        Else
            txtBarcode.Focus()
        End If
    End Sub

    Private Sub txtNotes_Enter(sender As Object, e As EventArgs) Handles txtNotes.Enter

        tsslStatus.Text = "Enter an optional note about this "
        If mScanType = ScanType.Document Then
            tsslStatus.Text += "document."
        Else
            tsslStatus.Text += "instrument."
        End If
    End Sub

    Private Sub cboDocumentStatus_Enter(sender As Object, e As EventArgs) Handles cboDocumentStatus.Enter

        tsslStatus.Text = "Select a valid status code."
    End Sub

    Private Sub cboDocumentStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDocumentStatus.SelectedIndexChanged

        If cboDocumentStatus.SelectedIndex >= 0 Then
            'if Doc Status = "Returned / Undeliverable", then allow opening in locating
            chkLocating.Visible =
                (GetSafeValue(CType(cboDocumentStatus.SelectedItem, DocumentStatus).DocumentStatusID) = 3)
        End If
    End Sub

    Private Sub cboInstrumentStatus_Enter(sender As Object, e As EventArgs) Handles cboInstrumentStatus.Enter

        tsslStatus.Text = "Select a valid status code."
    End Sub

    Private Sub cboInstrumentStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboInstrumentStatus.SelectedIndexChanged

        If cboInstrumentStatus.SelectedStatus Is Nothing Then
            chkLocating.Visible = False
        Else
            chkLocating.Visible = (GetSafeValue(cboInstrumentStatus.SelectedStatus.IsCaseInLocating) Or
                                   GetSafeValue(cboInstrumentStatus.SelectedStatus.IsCaseInLocatingSupervisor))
            If chkLocating.Visible And CR_MPRID.Equals("") Then
                MessageBox.Show("Locating statuses are not applicable for this instrument type.", "Invalid status code",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        If mScanType = ScanType.Invalid Then
            MessageBox.Show("This is not a valid ID (incorrect length/format). Please re-enter or re-scan to try again.",
                            Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf txtBarcode.Text.Length > 0 And
               (cboDocumentStatus.SelectedIndex >= 0 Or cboInstrumentStatus.SelectedStatus IsNot Nothing) Then
            If _
                chkLocating.Visible AndAlso chkLocating.Checked AndAlso
                (CR_MPRID.Equals("") And mScanType = ScanType.Instrument) Then
                MessageBox.Show("Locating statuses are not applicable for this instrument type.", "Invalid status code",
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                UpdateCase()
            End If
        End If
    End Sub


    ''' <summary>
    '''     Safely show the form in a Try/Catch block.
    ''' </summary>
    Private Sub ShowForm(frm As Form)
        Try
            frm.Show()
        Catch ex As Exception
            Dim strMsg As String = "A problem occurred trying to open the window." + Environment.NewLine +
                                   "If problem persists, please notify technical support." + Environment.NewLine +
                                   Environment.NewLine +
                                   "[Error Details]" + Environment.NewLine +
                                   ex.Message
            MessageBox.Show(strMsg, Project.ShortName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

#End Region

#Region "Batching"

    'Private Sub btnReleaseVideoCodingSheets_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    ' Project specific for BabyFaces.  Allowed only 1 instrument to be created at release and further instruments created after the DVD was timestamped.

    '    Dim dlgResult As DialogResult = System.Windows.Forms.DialogResult.No

    '    dlgResult = MessageBox.Show("Are you sure you generate coding cover sheets?", Project.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    '    If dlgResult = System.Windows.Forms.DialogResult.Yes Then
    '        MPR.SMS.DocumentProcessing.ReleaseDocuments.ReleaseDocumentGroup(Me, Project.ShortName, "Video Coding Sheet Cover Sheets")
    '    End If
    'End Sub

    Private Sub cmdBatchClose_Click(sender As Object, e As EventArgs) Handles cmdBatchClose.Click
        If mobjCase IsNot Nothing Then mobjCase.Dispose()
        Me.Close()
    End Sub

    Private Sub btnBatchCreateForQC_Click(sender As Object, e As EventArgs) Handles btnBatchCreateForQC.Click
        Dim frm As New frmBatchCreate(Data.Enumerations.BatchType.QC)
        ShowForm(frm)
    End Sub

    Private Sub btnBatchReceiveIntoQC_Click(sender As Object, e As EventArgs) Handles btnBatchReceiveIntoQC.Click
        Dim frm As New frmBatchReceive(Data.Enumerations.BatchType.QC)
        ShowForm(frm)
    End Sub

    Private Sub btnBatchCreateForDE_Click(sender As Object, e As EventArgs) Handles btnBatchCreateForDE.Click
        Dim frm As New frmBatchCreate(Data.Enumerations.BatchType.DE)
        ShowForm(frm)
    End Sub

    Private Sub btnBatchReceiveIntoDE_Click(sender As Object, e As EventArgs) Handles btnBatchReceiveIntoDE.Click
        Dim frm As New frmBatchReceive(Data.Enumerations.BatchType.DE)
        ShowForm(frm)
    End Sub

    Private Sub btnTimeStamp_Click(sender As Object, e As EventArgs) Handles btnTimeStamp.Click
        Dim frm As New frmBatchCreate2(Data.Enumerations.BatchType.TimeStamp)
        ShowForm(frm)
    End Sub

    Private Sub btnQCDVD_Click(sender As Object, e As EventArgs) Handles btnQCDVD.Click
        Dim frm As New frmBatchCreate2(Data.Enumerations.BatchType.QCDVD)
        ShowForm(frm)
    End Sub

    Private Sub btnSupReview_Click(sender As Object, e As EventArgs) Handles btnSupReview.Click
        Dim frm As New frmBatchCreate2(Data.Enumerations.BatchType.SupReviewDVD)
        ShowForm(frm)
    End Sub

    Private Sub btnAssignCoder_Click(sender As Object, e As EventArgs) Handles btnAssignCoder.Click
        Dim frm As New frmAssignCoder(Data.Enumerations.BatchType.CodeDVD)
        ShowForm(frm)
    End Sub

    Private Sub btnReAssignCoder_Click(sender As Object, e As EventArgs) Handles btnReAssignCoder.Click
        Dim frm As New frmAssignCoder(Data.Enumerations.BatchType.ReassignDVD)
        ShowForm(frm)
    End Sub

    Private Sub btnCreateFinalBatch_Click(sender As Object, e As EventArgs) Handles btnCreateFinalBatch.Click
        Dim frm As New frmBatchCreate2(Data.Enumerations.BatchType.Final)
        ShowForm(frm)
    End Sub

    Private Sub btnBatchSearch_Click(sender As Object, e As EventArgs) Handles btnBatchSearch.Click
        Dim frm As New frmBatchSearch()
        ShowForm(frm)
    End Sub

#End Region

#Region "Arrows"

    Private Sub tabBatching_Paint(sender As Object, e As PaintEventArgs) Handles tabBatching.Paint

        Dim Graph As Graphics = tabBatching.CreateGraphics()
        Dim Pen As New Pen(Color.DarkGray, 3)
        Dim cap As New AdjustableArrowCap(4, 3)

        Pen.StartCap = LineCap.RoundAnchor
        Pen.EndCap = LineCap.ArrowAnchor
        Pen.CustomEndCap = cap


        DrawSideToSide(Graph, Pen, btnBatchCreateForQC, btnTimeStamp)
        DrawSideToSide(Graph, Pen, btnAssignCoder, btnBatchCreateForDE)
        DrawSideToSide(Graph, Pen, btnReAssignCoder, btnBatchCreateForDE)
        DrawUpAndDown(Graph, Pen, btnBatchCreateForQC, btnBatchReceiveIntoQC)
        DrawUpAndDown(Graph, Pen, btnBatchReceiveIntoQC, btnBatchCreateForDE)
        DrawUpAndDown(Graph, Pen, btnBatchCreateForDE, btnBatchReceiveIntoDE)
        DrawUpAndDown(Graph, Pen, btnBatchReceiveIntoDE, btnCreateFinalBatch)
        DrawUpAndDown(Graph, Pen, btnBatchCreateForQC, btnBatchReceiveIntoQC)
        DrawUpAndDown(Graph, Pen, btnTimeStamp, btnQCDVD)
        DrawUpAndDown(Graph, Pen, btnQCDVD, btnSupReview)
        DrawSideToSide(Graph, Pen, btnSupReview, btnAssignCoder)
        DrawUpAndDown(Graph, Pen, btnAssignCoder, btnReAssignCoder)
        DrawUpAndDown(Graph, Pen, btnQCDVD, btnAssignCoder)
        DrawUpAndDown(Graph, Pen, btnReAssignCoder, btnSupReview)
    End Sub

    Private Sub DrawSideToSide(Graph As Graphics, Pen As Pen, FromControl As Control, ToControl As Control)

        Dim FromPoint As New Point
        Dim ToPoint As New Point

        If FromControl.Location.X > ToControl.Location.X Then 'left to right
            FromPoint.X = FromControl.Location.X - 1
            ToPoint.X = ToControl.Location.X + ToControl.Size.Width
        Else 'right to left
            FromPoint.X = FromControl.Location.X + FromControl.Size.Width
            ToPoint.X = ToControl.Location.X
        End If
        FromPoint.Y = FromControl.Location.Y + CInt(FromControl.Size.Height / 2)
        ToPoint.Y = ToControl.Location.Y + CInt(ToControl.Size.Height / 2)

        Graph.DrawLine(Pen, FromPoint, ToPoint)
    End Sub

    Private Sub DrawUpAndDown(Graph As Graphics, Pen As Pen, FromControl As Control, ToControl As Control)

        Dim FromPoint As New Point
        Dim ToPoint As New Point

        If FromControl.Location.Y > ToControl.Location.Y Then 'bottom to top
            FromPoint.Y = FromControl.Location.Y
            ToPoint.Y = ToControl.Location.Y + ToControl.Size.Height + 1
        Else 'top to bottom
            FromPoint.Y = FromControl.Location.Y + FromControl.Size.Height
            ToPoint.Y = ToControl.Location.Y - 2
        End If
        FromPoint.X = FromControl.Location.X + CInt(FromControl.Size.Width / 2)
        ToPoint.X = ToControl.Location.X + CInt(ToControl.Size.Width / 2)

        Graph.DrawLine(Pen, FromPoint, ToPoint)
    End Sub

#End Region
End Class