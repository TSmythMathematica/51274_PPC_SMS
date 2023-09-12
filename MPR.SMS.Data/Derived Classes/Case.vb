'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports System.Security.Principal
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Case object in the
'''     database.
''' </summary>

    Public Class [Case]
    Inherits TblCase

#Region "Events"

    Event OnInsert(objCase As [Case])
    Event OnUpdate(objCase As [Case])
    Event OnDelete(objCase As [Case])

    Event OnBeforeInsert(objCase As [Case], ByRef blnCancel As Boolean)
    Event OnBeforeUpdate(objCase As [Case], ByRef blnCancel As Boolean)
    Event OnBeforeDelete(objCase As [Case], ByRef blnCancel As Boolean)

#End Region

#Region "Private Fields"

    Private mobjEntityType As EntityType

    Private ReadOnly mobjPersons As Persons
    Private ReadOnly mobjAddresses As Addresses
    Private ReadOnly mobjPhones As Phones
    Private ReadOnly mobjEmails As Emails
    Private ReadOnly mobjSocialNetworks As SocialNetworks
    Private ReadOnly mobjAllNotes As AllNotes               'BT: 11/18/2014. Changed for vwAllNotes
    Private ReadOnly mobjNotes As Notes                     'BT: 11/18/2014. Added for tblNote
    Private ReadOnly mobjDocuments As Documents
    Private ReadOnly mobjInstruments As Instruments
    Private mobjCaseRA As CaseRA
    Private mobjCaseValidation As CaseValidation
    '  Private mobjAddressNotes As AddressNotes

    Private mstrLastError As String

    'Private mobjRAGroups As RAGroups

    'project-specific entity classes
    'Private mobjSite As Site   '<- uncomment this if Site is a Case Entity Type
    Private mobjDistrict As District
    Private mobjSchool As School
    Private mobjClassroom As Classroom
    Private mobjTeacher As Teacher

    'Field Management related properties
    Private mobjCaseAssignments As CaseAssignments
    Private mobjCaseTrackings As InterviewerCaseTrackings
    Private mobjFieldInstrument As Instrument
    Private mobjCallHistInstrument As Instrument

#End Region

#Region "Public Constants"

    'Public Const AlreadyRandomlyAssigned As String = "A"
    'Public Const ReadyForRandomAssignment As String = "R"
    'Public Const NotReadyForRandomAssignment As String = "N"

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Case objectbelongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Case object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Persons">Persons</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Persons">Persons</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Persons As Persons
        Get
            Return mobjPersons
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Addresses">Addresses</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Addresses">Addresses</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Addresses As Addresses
        Get
            Return mobjAddresses
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Phones">Phones</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Phones">Phones</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Phones As Phones
        Get
            Return mobjPhones
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Emails">Emails</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Emails">Emails</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Emails As Emails
        Get
            Return mobjEmails
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetworks">SocialNetworks</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetworks">SocialNetworks</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property SocialNetworks As SocialNetworks
        Get
            Return mobjSocialNetworks
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.AllNotes">AllNotes</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.AllNotes">AllNotes</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property AllNotes As AllNotes
        Get
            Return mobjAllNotes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Notes">Notes</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Notes">Notes</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Notes As Notes 'BT: 11/18/2014. Added for tblNote
        Get
            Return mobjNotes
        End Get
    End Property

    'Public ReadOnly Property AddressNotes() As AddressNotes     'BT: 11/18/2014. Changed for vwAllNotes
    '    Get
    '        Return mobjAddressNotes
    '    End Get
    'End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Documents">Documents</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Documents">Documents</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Documents As Documents
        Get
            Return mobjDocuments
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Instruments">Instruments</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Instruments">Instruments</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Instruments As Instruments
        Get
            Return mobjInstruments
        End Get
    End Property

    Public Property EntityType As EntityType
        Get
            Dim i As Integer
            If Not EntityTypeID.IsNull Then
                i = Project.EntityTypes.IndexOf(EntityTypeID.Value)
                If i >= 0 Then
                    mobjEntityType = Project.EntityTypes(i)
                End If
            End If
            Return mobjEntityType
        End Get
        Set
            mobjEntityType = Value
            EntityTypeID = mobjEntityType.EntityTypeID
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.CaseErrors">CaseErrors</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.CaseErrors">CaseErrors</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property CaseErrors As CaseErrors
        Get
            Return New CaseErrors(Me)
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Duplicates">Duplicates</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Duplicates">Duplicates</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property Duplicates As Duplicates
        Get
            Return New Duplicates(Me)
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object identified as the Primary Sample Member for
    '''     the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object identified as the Primary Sample member for the Case, or
    '''     Nothing if not defined.
    '''     If the case has multiple sample members, then it returns the first found.
    ''' </value>

        Public ReadOnly Property PrimarySampleMember As Person
        Get
            Dim objPerson As Person
            For Each objPerson In Me.Persons
                If (objPerson.RelationshipType IsNot Nothing AndAlso
                    CType(objPerson.RelationshipType.IsPrimarySampleMember, Boolean) = True) Then
                    Return objPerson
                End If
            Next
            Return Nothing
        End Get
    End Property

    ''' <summary>
    '''     Gets whether the Case object has been modified.
    ''' </summary>
    ''' <value>
    '''     True or False indicating whether the Case object has been modified.
    ''' </value>

        Public Shadows ReadOnly Property IsModified As Boolean
        Get

            If MyBase.IsModified Then
                Return True
            ElseIf Persons.IsModified Then
                Return True
            ElseIf Addresses.IsModified Then
                Return True
            ElseIf Phones.IsModified Then
                Return True
            ElseIf Emails.IsModified Then
                Return True
            ElseIf SocialNetworks.IsModified Then
                Return True
            ElseIf Notes.IsModified Then
                Return True
            ElseIf Documents.IsModified Then
                Return True
            ElseIf Instruments.IsModified Then
                Return True
            ElseIf (mobjCaseRA IsNot Nothing) AndAlso mobjCaseRA.IsModified Then
                Return True
            ElseIf (mobjCaseValidation IsNot Nothing) AndAlso mobjCaseValidation.IsModified Then
                Return True
            ElseIf (mobjCaseTrackings IsNot Nothing) AndAlso mobjCaseTrackings.IsModified Then
                Return True

                'NOTE: uncomment below if Site is a Case Entity Type
                'ElseIf (mobjSite IsNot Nothing) AndAlso mobjSite.IsModified Then
                '    Return True
            ElseIf (mobjDistrict IsNot Nothing) AndAlso mobjDistrict.IsModified Then
                Return True
            ElseIf (mobjSchool IsNot Nothing) AndAlso mobjSchool.IsModified Then
                Return True
            ElseIf (mobjClassroom IsNot Nothing) AndAlso mobjClassroom.IsModified Then
                Return True
            ElseIf (mobjTeacher IsNot Nothing) AndAlso mobjTeacher.IsModified Then
                Return True
            End If

            Return False
        End Get
    End Property

    Public Property CaseRA As CaseRA
        Get
            If mobjCaseRA Is Nothing Then
                mobjCaseRA = New CaseRA(Me)
            End If
            Return mobjCaseRA
        End Get
        Set
            mobjCaseRA = Value
        End Set
    End Property

    Public Property CaseValidation As CaseValidation
        Get
            If mobjCaseValidation Is Nothing Then
                mobjCaseValidation = New CaseValidation(Me)
            End If
            Return mobjCaseValidation
        End Get
        Set
            mobjCaseValidation = Value
        End Set
    End Property


    'Note: Uncomment this section if Sites are a Case Entity Type
    'Public Property Site() As Site
    '    Get
    ''        If mobjSite Is Nothing Then
    ''            mobjSite = New Site(Me)
    ''        End If
    '        Return mobjSite
    '    End Get
    '    Set(ByVal Value As Site)
    '        mobjSite = value
    '    End Set
    'End Property

    Public Property District As District
        Get
            'If mobjDistrict Is Nothing Then
            '    'mobjDistrict = New District(Me)
            '    Throw New Exception("Case.vb::You have tried to use a District object that has not been instantiated")
            'End If
            Return mobjDistrict
        End Get
        Set
            mobjDistrict = Value
        End Set
    End Property

    Public Property School As School
        Get
            'If mobjSchool Is Nothing Then
            '    '    mobjSchool = New School(Me)
            '    Throw New Exception("Case.vb::You have tried to use a School object that has not been instantiated")
            'End If
            Return mobjSchool
        End Get
        Set
            mobjSchool = Value
        End Set
    End Property

    Public Property Classroom As Classroom
        Get
            'If mobjClassroom Is Nothing Then
            '    '    mobjClassroom = New Classroom(Me)
            '    Throw New Exception("Case.vb::You have tried to use a Classroom object that has not been instantiated")
            'End If
            Return mobjClassroom
        End Get
        Set
            mobjClassroom = Value
        End Set
    End Property

    Public Property Teacher As Teacher
        Get
            'If mobjTeacher Is Nothing Then
            '    '    mobjTeacher = New Teacher(Me)
            '    Throw New Exception("Case.vb::You have tried to use a Teacher object that has not been instantiated")
            'End If
            Return mobjTeacher
        End Get
        Set
            mobjTeacher = Value
        End Set
    End Property

    Public Property CaseAssignments As CaseAssignments
        Get
            If mobjCaseAssignments Is Nothing Then
                mobjCaseAssignments = New CaseAssignments(Me)
            End If
            Return mobjCaseAssignments
        End Get
        Set
            mobjCaseAssignments = Value
        End Set
    End Property

    Public Property InterviewerCaseTrackings As InterviewerCaseTrackings
        Get
            If mobjCaseTrackings Is Nothing Then
                mobjCaseTrackings = New InterviewerCaseTrackings(Me)
            End If
            Return mobjCaseTrackings
        End Get
        Set
            mobjCaseTrackings = Value
        End Set
    End Property

    'the Instrument designated as IsPrimaryFieldInstrument
    Public Property FieldInstrument As Instrument
        Get
            If mobjFieldInstrument Is Nothing Then
                For Each objInst As Instrument In Instruments
                    If GetSafeValue(objInst.InstrumentType.IsPrimaryFieldInstrument) Then
                        mobjFieldInstrument = objInst
                        Exit For
                    End If
                Next
            End If
            Return mobjFieldInstrument
        End Get
        Set
            mobjFieldInstrument = Value
        End Set
    End Property

    Public ReadOnly Property IsFieldActive As Boolean
        Get
            If FieldInstrument IsNot Nothing Then
                Dim objStatus As Status = FieldInstrument.Status
                If Not objStatus.IsFinalStatus And
                   Not objStatus.Code.ToString.Equals("000") Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property IsFieldComplete As Boolean
        Get
            If FieldInstrument IsNot Nothing Then
                Dim objStatus As Status = FieldInstrument.Status
                Return GetSafeValue(objStatus.IsComplete)
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property IsFieldAssigned As Boolean
        Get
            If CaseAssignments IsNot Nothing Then
                For Each obj As CaseAssignment In CaseAssignments
                    If Not obj.InterviewerID.IsNull Then
                        Return True
                    End If
                Next
            Else
                Return False
            End If
        End Get
    End Property

    Public ReadOnly Property IsFieldValidation As Boolean
        Get
            If CaseValidation IsNot Nothing Then
                Return GetSafeValue(CaseValidation.IsValidate)
            Else
                Return False
            End If
        End Get
    End Property

    'the Instrument designated as the one to pull Confirmit CallHistory in locating
    Public ReadOnly Property CallHistoryInstrument As Instrument
        Get
            'Could there be more than 1 per case ???
            If mobjCallHistInstrument Is Nothing Then
                For Each objInst As Instrument In Instruments
                    If objInst.CanGetConfirmitCallHistory Then
                        mobjCallHistInstrument = objInst
                        Exit For
                    End If
                Next
            End If
            Return mobjCallHistInstrument
        End Get
    End Property

    Private mobjCallHistRecords As ConfirmitCallHistoryRecords

    Public ReadOnly Property ConfirmitCallHistoryRecords As ConfirmitCallHistoryRecords

        Get
            If mobjCallHistRecords IsNot Nothing Then
                Return mobjCallHistRecords
            End If

            mobjCallHistRecords = New ConfirmitCallHistoryRecords(Me)

            Return mobjCallHistRecords
        End Get
    End Property

#End Region

#Region "Shadowed Base Class Properties"

    ''' <summary>
    '''     Gets the CaseID of the Case object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Case object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the InSample flag of the Case object, and sets Insample flag for all the Person objects.
    ''' </summary>
    ''' <value>
    '''     The InSample flag of the Case object.
    ''' </value>

        Public Shadows Property InSample As SqlBoolean
        Get
            Return MyBase.InSample
        End Get
        Set
            MyBase.InSample = Value
            For Each objPerson As Person In Persons
                objPerson.InSample = Value
            Next
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the IsIneligible flag of the Case object, and sets IsIneligible flag for all the Person objects.
    ''' </summary>
    ''' <value>
    '''     The IsIneligible flag of the Case object.
    ''' </value>

        Public Shadows Property IsIneligible As SqlBoolean
        Get
            Return MyBase.IsIneligible
        End Get
        Set
            MyBase.IsIneligible = Value
            For Each objPerson As Person In Persons
                objPerson.IsIneligible = Value
            Next
        End Set
    End Property

    Private Shadows Sub ResetModified()

        MyBase.ResetModified()

        Persons.ResetModified()
        Addresses.ResetModified()
        Phones.ResetModified()
        Emails.ResetModified()
        SocialNetworks.ResetModified()
        Notes.ResetModified()
        CaseRA.ResetModified()
        CaseValidation.ResetModified()
        Documents.ResetModified()
        Instruments.ResetModified()
        InterviewerCaseTrackings.ResetModified()

        'If Site IsNot Nothing Then
        '    Site.ResetModified()
        'End If
        If District IsNot Nothing Then
            District.ResetModified()
        End If
        If School IsNot Nothing Then
            School.ResetModified()
        End If
        If Classroom IsNot Nothing Then
            Classroom.ResetModified()
        End If
        If Teacher IsNot Nothing Then
            Teacher.ResetModified()
        End If
    End Sub

    Public Shadows Sub RestoreModified()

        MyBase.RestoreModified()

        Persons.RestoreModified()
        Addresses.RestoreModified()
        Phones.RestoreModified()
        Emails.RestoreModified()
        SocialNetworks.RestoreModified()
        Notes.RestoreModified()
        CaseRA.RestoreModified()
        CaseValidation.RestoreModified()
        Documents.RestoreModified()
        Instruments.RestoreModified()
        InterviewerCaseTrackings.RestoreModified()

        'If Site IsNot Nothing Then
        '    Site.RestoreModified()
        'End If
        If District IsNot Nothing Then
            District.RestoreModified()
        End If
        If School IsNot Nothing Then
            School.RestoreModified()
        End If
        If Classroom IsNot Nothing Then
            Classroom.RestoreModified()
        End If
        If Teacher IsNot Nothing Then
            Teacher.RestoreModified()
        End If
    End Sub

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Case constructor has three overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the Case class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor initializes the Case object with no special logic.
    '''     This constructor is replaced by the EntityType constructor and should not be used.
    ''' </remarks>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Case class and locks the Case.
    ''' </summary>
    ''' <param name="intCaseID">
    '''     The MPR Case ID for which the object will be initialized.
    ''' </param>
    ''' <param name="blnPerformLock">
    '''     Determines whether the case should be locked now, or will be locked later manually, if needed.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is used for retrieving an existing case from
    '''     the database by specifying the CaseID.
    ''' </remarks>

        Public Sub New(intCaseID As Integer, blnPerformLock As Boolean)

        MyBase.New()

        If intCaseID = 0 Then Return

        MyBase.CaseID = New SqlInt32(intCaseID)

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            ' Attempt to lock the case

            If blnPerformLock Then Lock()

            SelectOne()

            'Retrieve the collections for this Case
            mobjPersons = New Persons(Me)
            mobjAddresses = New Addresses(Me)
            mobjPhones = New Phones(Me)
            mobjEmails = New Emails(Me)
            mobjSocialNetworks = New SocialNetworks(Me)
            mobjAllNotes = New AllNotes(Me)       'BT: 11/18/2014. Changed for vwAllNotes
            mobjNotes = New Notes(Me)             'BT: 11/18/2014. Added for tblNote 
            mobjDocuments = New Documents(Me)
            mobjInstruments = New Instruments(Me)
            mobjCaseTrackings = New InterviewerCaseTrackings(Me)
            '   mobjAddressNotes = New AddressNotes(Me)

            CreateEntityObject(CType(CInt(EntityTypeID), Enumerations.tlkpEntityType))

            ResetModified()

        Catch ex As Exception

            ' Ensure the case is unlocked if it cannot be opened

            Unlock()

            ' Rethrow the exception

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Case class.
    ''' </summary>
    ''' <param name="iEntityType">
    '''     The new Case's Entity Type.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is used for creating a new Case object, which should
    '''     require specifying the Entity Type.
    ''' </remarks>
    Public Sub New(iEntityType As Enumerations.tlkpEntityType)

        MyBase.New()

        ConnectionString = Project.ConnectionString

        'Create the collections
        mobjPersons = New Persons(Me)
        mobjAddresses = New Addresses(Me)
        mobjPhones = New Phones(Me)
        mobjEmails = New Emails(Me)
        mobjSocialNetworks = New SocialNetworks(Me)
        mobjAllNotes = New AllNotes(Me)               'BT: 11/18/2014. Changed for vwAllNotes
        mobjNotes = New Notes(Me)                     'BT: 11/18/2014. Added for tblNote
        mobjDocuments = New Documents(Me)
        mobjInstruments = New Instruments(Me)
        mobjCaseTrackings = New InterviewerCaseTrackings(Me)
        'mobjAddressNotes = New AddressNotes(Me)

        Me.EntityTypeID = iEntityType
        Me.InSample = True
        Me.IsIneligible = False

        CreateEntityObject(iEntityType)

        ResetModified()
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Case object and its dependent objects into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>
    ''' <remarks>
    '''     The Insert method always assigns a new CaseID to the Case. On return, the new CaseID
    '''     is available within the Case object.
    ''' </remarks>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            MyBase.CurrentRound = New SqlInt32(Project.CurrentRound)

            'Do Error & Duplicates checking, if project setting says to
            If Project.ErrorChecking <> Project.CheckingType.NoChecking Then
                CaseRA.NumberOfErrors = New SqlInt32(CaseErrors.Count)
            End If
            If Project.DuplicatesChecking <> Project.CheckingType.NoChecking Then
                CaseRA.NumberOfDuplicates = New SqlInt32(Duplicates.Count)
            End If


            Dim blnCancel As Boolean = False

            ' Let's allow the peanut gallery to have a say in whther this Insert occurs

            RaiseEvent OnBeforeInsert(Me, blnCancel)

            blnResult = Not blnCancel

            ' If there are no objections from the peanut gallery, insert the Case

            If blnResult Then

                'Perform Duplicate Checks for Students
                If EntityTypeID.Value = Enumerations.tlkpEntityType.Student AndAlso
                   Project.DuplicatesChecking <> Project.CheckingType.NoChecking Then
                    blnResult = (CaseRA.NumberOfDuplicates.Value = 0)
                End If

                ' Insert the Case
                If blnResult Then
                    blnResult = MyBase.Insert()
                End If

                ' If successful, update the Random Assignment info, if applicable
                If blnResult AndAlso (CaseRA IsNot Nothing) Then
                    blnResult = CaseRA.Insert()
                End If
                ' If successful, update the Validation info
                If blnResult Then
                    blnResult = CaseValidation.Insert()
                End If

                ' If successful, insert the Persons
                If blnResult Then
                    'if there are no Person records yet, insert a dummy record.
                    If Persons.Count.Equals(0) Then
                        Dim objPerson As New Person(Me)
                        objPerson.RelationshipTypeID = 0
                        objPerson.LanguageTypeID = 0
                        objPerson.InSample = Me.InSample
                        objPerson.IsIneligible = Me.IsIneligible
                    End If

                    blnResult = Persons.Insert()
                End If

                ' If successful, insert the Addresses
                If blnResult Then
                    blnResult = Addresses.Insert()
                End If

                ' If successful, insert the Phones
                If blnResult Then
                    blnResult = Phones.Insert()
                End If

                ' If successful, insert the Emails
                If blnResult Then
                    blnResult = Emails.Insert()
                End If

                ' If successful, insert the SocialNetworks
                If blnResult Then
                    blnResult = SocialNetworks.Insert()
                End If

                ' If successful, insert the Notes       'BT: 11/21/2014. Added for tblNote
                If blnResult Then
                    blnResult = Notes.Insert()
                End If

                ' If successful, insert the Documents
                If blnResult Then
                    blnResult = Documents.Insert()
                End If

                ' If successful, insert the Instruments
                If blnResult Then
                    blnResult = Instruments.Insert()
                End If

                ' If successful, insert the InterviewerCaseTrackings
                If blnResult Then
                    blnResult = InterviewerCaseTrackings.Insert()
                End If


                ' If successful, insert the District, School, Classroom, Teacher, or Student
                If blnResult AndAlso (Me.mobjDistrict IsNot Nothing) Then
                    mobjDistrict.CaseID = CaseID
                    blnResult = mobjDistrict.Insert()
                End If
                If blnResult AndAlso (Me.mobjSchool IsNot Nothing) Then
                    mobjSchool.CaseID = CaseID
                    blnResult = mobjSchool.Insert()
                End If
                If blnResult AndAlso (Me.mobjClassroom IsNot Nothing) Then
                    mobjClassroom.CaseID = CaseID
                    blnResult = mobjClassroom.Insert()
                End If
                If blnResult AndAlso (Me.mobjTeacher IsNot Nothing) Then
                    mobjTeacher.CaseID = CaseID
                    blnResult = mobjTeacher.Insert()
                End If
                'NOTE: uncomment this section if Site is a Case Entity Type
                'If blnResult AndAlso (Me.mobjSite IsNot Nothing) Then
                '    mobjSite.CaseID = CaseID
                '    blnResult = mobjSite.Insert()
                'End If

                ' If successful, insert the PersonBest records
                ' must be done after saving all Address, Phone & Email records
                If blnResult Then
                    For Each objPerson As Person In Persons
                        blnResult = objPerson.PersonBest.Insert()
                        blnResult = objPerson.LocatingAttempts.Insert()
                    Next
                End If


                ' If successful, lock the newly inserted Case 

                If blnResult Then
                    Me.Lock()
                End If

            End If

        Catch ex As Exception

            blnResult = False

            mstrLastError = ex.Message

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the Case object and its dependent objects within the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        ValidateLock()

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False
        Dim ToConfirmIt As List(Of Instrument) = new List(Of Instrument)

        'Do Error & Duplicates checking, if project setting says to
        If Project.ErrorChecking <> Project.CheckingType.NoChecking Then
            CaseRA.NumberOfErrors = New SqlInt32(CaseErrors.Count)
        End If
        If Project.DuplicatesChecking <> Project.CheckingType.NoChecking Then
            CaseRA.NumberOfDuplicates = New SqlInt32(Duplicates.Count)
        End If

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCancel As Boolean = False

        ' Let's allow the peanut gallery to have a say in whether this Update occurs

        RaiseEvent OnBeforeUpdate(Me, blnCancel)

        blnResult = Not blnCancel

        ' If there are no objections from the peanut gallery, update the Case

        If blnResult Then

            Try

                ' Open the database if needed
                If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                    blnCloseConnection = True
                    ConnectionProvider.OpenConnection()
                End If

                'if a Person's LocatingStatus indicates they were moved
                'in or out of locating, then update all Instrument 
                'statuses where that person is the current respondent.
                'The Instrument class will determine if the StatusUpdateRules
                'will allow the change, and then will set the Date and User
                For Each objPerson As Person In Persons
                    If objPerson.LocatingStatus IsNot Nothing AndAlso
                       (objPerson.LocatingStatus.IsMovedOutOfLocating Or
                        objPerson.LocatingStatus.IsMovedIntoLocating Or
                        objPerson.LocatingStatus.IsCallIn) Then

                        For Each objInstrument As Instrument In Instruments
                            'only update the instrument status if it wasn't already changed
                            'by some other process, and the instrument has been released
                            If Not objInstrument.IsModified AndAlso
                               objInstrument.CurrentRespondentMPRID.ToString.Equals(objPerson.MPRID.ToString) AndAlso
                               objInstrument.ReleaseDate.IsNull = False Then

                                'if the status is the same, force the Instrument object to look modified so that it still
                                'performs the status update rules. (for example, finding an additional phone, the status
                                'might go from 890 to 890, but we still want to update the status date)
                                If _
                                    GetSafeValue(objInstrument.CurrentStatus) =
                                    GetSafeValue(objPerson.LocatingStatus.LocatingStatus) Then
                                    objInstrument.StatusChangeDate = objPerson.LocatingStatus.StatusDate
                                End If
                                objInstrument.CurrentStatus = objPerson.LocatingStatus.LocatingStatus
                                '#1580 
                                objInstrument.LogicalStatus = objPerson.LocatingStatus.LocatingStatus


                                If _
                                    objPerson.LocatingStatus.IsMovedOutOfLocating AndAlso
                                    objPerson.LocatingStatus.Status.Code.Value = "1890" Then

                                    If objInstrument.InstrumentType IsNot Nothing AndAlso
                                       GetSafeValue(objInstrument.InstrumentType.SurveyID) <> String.Empty AndAlso
                                       GetSafeValue(objInstrument.InstrumentType.IsCATI) AndAlso
                                       GetSafeValue(objInstrument.LogicalStatus) = "1890" AndAlso
                                       Not objInstrument.Status.IsFinalStatus Then

                                        If PrimarySampleMember.BestPhone IsNot Nothing Then

                                            'If Locating gets R on phone and R wants to complete, they 
                                            '1. leave locating open
                                            '2. send call to confirmit to compelte (integrations run updating SMS status)
                                            '3. record locating attempt.
                                            'So, we need to ensure if instrumentbecame final after it was opened here, we don't overwrite it.
                                            Dim _
                                                reCheckInst As _
                                                    New Instrument(objInstrument.InstrumentID.Value,
                                                                   objInstrument.InstrumentTypeID.Value)
                                            If reCheckInst.Status.IsFinalStatus Then
                                                objInstrument.CancelUpdate = True
                                                Exit For
                                            End If

                                            If PrimarySampleMember.BestPhone.PhoneID.IsNull Then
                                                PrimarySampleMember.BestPhone.Insert()
                                            End If

                                            ' add this instrument to the list. The actualy send will be after case update is done
                                            ToConfirmIt.Add(objInstrument)

                                        End If
                                    End If
                                End If


                            End If
                        Next
                    End If
                Next

                ' Update the Case
                If blnResult AndAlso MyBase.IsModified Then
                    blnResult = MyBase.Update()
                End If

                ' If successful, update the Random Assignment info, if applicable
                If blnResult AndAlso (CaseRA IsNot Nothing) Then
                    blnResult = CaseRA.Update()
                End If

                ' If successful, update the Validation info
                If blnResult Then
                    blnResult = CaseValidation.Update()
                End If

                ' If successful, update the Persons
                If blnResult Then
                    blnResult = Persons.Update()
                End If

                ' If successful, update the Addresses
                If blnResult Then
                    blnResult = Addresses.Update()
                End If

                ' If successful, update the Phones
                If blnResult Then
                    blnResult = Phones.Update()
                End If

                ' If successful, update the Emails
                If blnResult Then
                    blnResult = Emails.Update()
                End If

                ' If successful, update the SocialNetworks
                If blnResult Then
                    blnResult = SocialNetworks.Update()
                End If

                ' If successful, update the Notes             'BT: 11/21/2014. Added for tblNote
                If blnResult Then
                    blnResult = Notes.Update()
                End If

                ' If successful, update the Documents
                If blnResult Then
                    blnResult = Documents.Update()
                End If

                ' If successful, update the Instruments
                If blnResult Then
                    blnResult = Instruments.Update()
                End If

                ' If successful, Update the InterviewerCaseTrackings
                If blnResult Then
                    blnResult = InterviewerCaseTrackings.Update()
                End If

                ' If successful, update the District, School, Classroom, Teacher, or Student
                If blnResult AndAlso (mobjDistrict IsNot Nothing) Then
                    If mobjDistrict.IsModified Then
                        blnResult = mobjDistrict.Update()
                    End If
                End If
                If blnResult AndAlso (mobjSchool IsNot Nothing) Then
                    If mobjSchool.IsModified Then
                        blnResult = mobjSchool.Update()
                    End If
                End If
                If blnResult AndAlso (mobjClassroom IsNot Nothing) Then
                    If mobjClassroom.IsModified Then
                        blnResult = mobjClassroom.Update()
                    End If
                End If
                If blnResult AndAlso (mobjTeacher IsNot Nothing) Then
                    If mobjTeacher.IsModified Then
                        blnResult = mobjTeacher.Update()
                    End If
                End If
                'NOTE: uncomment this section if Site is a Case Entity Type
                'If blnResult AndAlso (mobjSite IsNot Nothing) Then
                '    If mobjSite.IsModified Then
                '        blnResult = mobjSite.Update()
                '    End If
                'End If


                ' If successful, update the PersonBest records
                ' must be done after saving all Address, Phone & Email records
                If blnResult Then
                    For Each objPerson As Person In Persons
                        blnResult = objPerson.PersonBest.Update()
                        blnResult = objPerson.LocatingAttempts.Update()
                    Next
                End If

                 ' Send located person's best phone and other related fields to ConfirmIt
                If blnResult And ToConfirmIt.Count > 0 Then 
                    Dim isSuccess As Boolean = false                
                    For Each objInstrument As Instrument In ToConfirmIt
                        ' Send the best phone to ConfirmIt
                        ' type id 2 for locating related variables
                        ' If successfully sent, tblInstrument's DateLastSentToCATI field will be updated as well
                        SMSToConfirmIt.SendToConfirmIt(objInstrument.SampleMember.MPRID.ToString(), CInt(objInstrument.InstrumentTypeID), 2)     
                    Next          
                end If

            Catch ex As Exception

                Throw ex

            Finally

                ' Insure the database is always closed if it was opened here

                If blnCloseConnection Then
                    blnCloseConnection = False
                    ConnectionProvider.CloseConnection(False)
                End If

                ConnectionProvider = Nothing

            End Try

            ' If successful, raise the OnUpdate event

            If blnResult Then
                RaiseEvent OnUpdate(Me)
                ResetModified()
            End If

        End If

        ' Return the result
        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes the Case object and its dependent objects from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Case object has been deleted, otherwise false
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCancel As Boolean = False

        ' Let's allow the peanut gallery to have a say in whether this Delete occurs

        RaiseEvent OnBeforeDelete(Me, blnCancel)

        blnResult = Not blnCancel

        ' If no objections from the peanut gallery, delete the Case

        If blnResult Then

            ConnectionString = Project.ConnectionString

            ' If CaseID has not been assigned, skip delete

            If Not CaseID.IsNull Then

                Try

                    blnResult = MyBase.Delete()

                    If blnResult Then
                        Unlock()
                    End If

                Catch ex As Exception

                    blnResult = False

                    Throw ex

                End Try

            End If

        End If

        ' If successful, raise OnDelete event

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        ' Return result

        Return blnResult
    End Function

    Public Enum StatusHistoryResultCode
        Override = 1
        OverrideAsAnomaly = 2
        OverrideIsNoOp = 3
        OverrideIsNotAllowed = 4
        OverrideRuleNotFound = 5
    End Enum

#End Region

#Region "Private Methods"

    Private Sub CreateEntityObject(iEntityType As Enumerations.tlkpEntityType)

        Select Case iEntityType
            Case Enumerations.tlkpEntityType.Classroom
                mobjClassroom = New Classroom(Me)
            Case Enumerations.tlkpEntityType.District
                mobjDistrict = New District(Me)
            Case Enumerations.tlkpEntityType.Grantee
                'uncomment below if Grantees are an entity
                'mobjGrantee = New Grantee(Me)
            Case Enumerations.tlkpEntityType.School
                mobjSchool = New School(Me)
            Case Enumerations.tlkpEntityType.Site
                'uncomment below if Sites are an entity
                'mobjSite = New Site(Me)
            Case Enumerations.tlkpEntityType.Teacher
                mobjTeacher = New Teacher(Me)
            Case Enumerations.tlkpEntityType.Student
                'this is done in the Person constructor
        End Select
    End Sub
#End Region

#Region "Case Locking"

    Private mblnLocked As Boolean = False
    Private mblnAlreadyLocked As Boolean = False
    Private mobjCaseLock As CaseLock = Nothing

    Public ReadOnly Property IsReadOnly As Boolean
        Get
            Return Not mblnLocked
        End Get
    End Property

    Public ReadOnly Property GetReadOnlyStatus As String
        Get
            If Not IsReadOnly Then
                Return Nothing
            ElseIf mobjCaseLock Is Nothing Then
                Return "A lock for the case could not obtained."
            Else
                Return "The case is already locked by " & mobjCaseLock.UserName.Value &
                       " on " & mobjCaseLock.Workstation.Value & "."
            End If
        End Get
    End Property

    Public Sub Lock()

        ''Verify CaseID is valid and exists
        'If Regex.IsMatch(CaseID.ToString, "\D") Then
        '    Throw New Exception("Invalid CaseID--Must be numeric.")
        'ElseIf CaseID.Equals(vbNullString) Or CaseID.ToString.Length <> 8 Then
        '    Throw New Exception("Invalid CaseID--Must be 8 digits long.")
        'ElseIf Not Project.CheckDigitIsValid(CaseID.Value) Then
        '    Throw New Exception("Invalid CaseID--Check Digit does not match.")
        'End If

        ' Attempt to acquire the Case lock 

        Dim objNewCaseLock As New CaseLock

        objNewCaseLock.CaseID = CaseID
        'If Project.User Is Nothing Then
        objNewCaseLock.UserName = New SqlString(WindowsIdentity.GetCurrent().Name)
        'Else
        '   objNewCaseLock.UserNameSMS = Project.User.UserName
        'End If
        objNewCaseLock.Workstation = New SqlString(Environment.MachineName)
        objNewCaseLock.LockDate = New SqlDateTime(Now)

        ' If case lock inserted, indicate locked

        If objNewCaseLock.Insert() Then
            mblnLocked = True
            mobjCaseLock = objNewCaseLock
        Else
            Dim objExistingCaseLock As New CaseLock
            objExistingCaseLock.CaseID = CaseID
            Dim objDataTable As DataTable = objExistingCaseLock.SelectOne()
            If objDataTable.Rows.Count > 0 Then
                mblnAlreadyLocked = True
                mobjCaseLock = objExistingCaseLock
                mblnLocked = objNewCaseLock.UserName.Equals(objExistingCaseLock.UserName)
            End If
        End If
    End Sub

    Public Sub Unlock()

        If mblnLocked Then
            mblnLocked = False
            mobjCaseLock.Delete()
            mobjCaseLock = Nothing
        End If
    End Sub

    Protected Overloads Overrides Sub Dispose(isDisposing As Boolean)

        Unlock()

        MyBase.Dispose(isDisposing)
    End Sub

    Protected Sub ValidateLock()

        If Not mblnLocked Then
            Throw New Exception("Sorry, this case cannot be updated because it is currently locked by another user")
        End If

        Dim objCaseLock As New CaseLock(CaseID.Value)

        If Not mobjCaseLock.Equals(objCaseLock) Then
            mblnLocked = False
            mobjCaseLock = Nothing
            If objCaseLock.UserName.IsNull Then
                Throw _
                    New Exception(
                        "The System Administrator has released your lock on this Case, therefore any changes you have made will be lost")
            Else
                Throw _
                    New Exception(
                        "The System Administrator has released your lock on this Case and it is now locked by '" &
                        objCaseLock.UserName.Value & "', therefore any changes you have made will be lost.")
            End If
        End If
    End Sub

#End Region
End Class
