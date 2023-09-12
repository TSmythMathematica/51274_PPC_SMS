'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports System.Text
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Person object in the
'''     database.
''' </summary>

    Public Class Person
    Inherits TblPerson

#Region "Events"

    Event OnInsert(objPerson As Person)
    Event OnUpdate(objPerson As Person)
    Event OnDelete(objPerson As Person)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]

    Private mobjPersonHistory As PersonHistory
    Private mobjAddresses As Addresses
    Private mobjPhones As Phones
    Private mobjEmails As Emails
    Private mobjSocialNetworks As SocialNetworks
    Private mobjNotes As AllNotes

    Private mobjStudent As Student

    Private mobjPersonRaces As PersonRaces
    Private mobjPersonBest As PersonBest
    Private mobjLocatingStatus As LocatingStatus
    Private mobjLocatingAttempts As LocatingAttempts

    Private mobjRelationshipType As RelationshipType
    Private mobjLanguageType As LanguageType
    Private mobjConsentType As ConsentType
    Private mobjAssentType As ConsentType

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Person object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Person object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Person object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Person object belongs to.
    ''' </value>

        Public Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            MyBase.CaseID = mobjCase.CaseID
        End Set
    End Property

    ''' <summary>
    '''     Gets the <B>most recent</B> <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> record for the Person
    '''     object.
    ''' </summary>
    ''' <value>
    '''     The <B>most recent</B> <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> record for the Person object.
    '''     Will return Nothing if the record has not been saved yet.
    ''' </value>

        Public ReadOnly Property PersonHistory As PersonHistory
        Get

            If Not Me.MPRID.IsNull Then
                Dim intHistID As Integer = 0
                Dim objHistories As New PersonHistories(Me)

                For Each objHist As PersonHistory In objHistories
                    If objHist.PersonHistoryID.Value > intHistID Then
                        mobjPersonHistory = objHist
                    End If
                Next
            End If

            Return mobjPersonHistory
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Addresses">Addresses</see> collection for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Addresses">Addresses</see> collection for the Person object.
    ''' </value>

        Public ReadOnly Property Addresses As Addresses
        Get
            'Addresses are always taken from the Case's Address collection.
            'Modifying of Addresses should be done at the Case level.
            ResolveAddresses()
            Return mobjAddresses
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Phones">Phones</see> collection for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Phones">Phones</see> collection for the Person object.
    ''' </value>

        Public ReadOnly Property Phones As Phones
        Get
            'Phones are always taken from the Case's Phones collection.
            'Modifying of Phones should be done at the Case level.
            ResolvePhones()
            Return mobjPhones
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Emails">Emails</see> collection for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Emails">Emails</see> collection for the Person object.
    ''' </value>

        Public ReadOnly Property Emails As Emails
        Get
            'Emails are always taken from the Case's Emails collection.
            'Modifying of Emails should be done at the Case level.
            ResolveEmails()
            Return mobjEmails
        End Get
    End Property


    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetworks">SocialNetworks</see> collection for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetworks">SocialNetworks</see> collection for the Person object.
    ''' </value>

        Public ReadOnly Property SocialNetworks As SocialNetworks
        Get
            'SocialNetworks are always taken from the Case's SocialNetworks collection.
            'Modifying of SocialNetworks should be done at the Case level.
            ResolveSocialNetworks()
            Return mobjSocialNetworks
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Notes">Notes</see> collection for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Notes">Notes</see> collection for the Person object.
    ''' </value>

        Public ReadOnly Property Notes As AllNotes
        Get
            'Notes are always taken from the Case's Notes collection.
            'Modifying of Notes should be done at the Case level.
            ResolveNotes()
            Return mobjNotes
        End Get
    End Property

    '' <summary>
    ''     Gets the <see cref="T:MPR.SMS.Data.PersonPersonRaces">PersonPersonRaces</see> collection for the Person object.
    '' </summary>
    '' <value>
    ''     The <see cref="T:MPR.SMS.Data.PersonPersonRaces">PersonPersonRaces</see> collection for the Person object.
    '' </value>

    Public Property PersonRaces As PersonRaces
        Get
            If mobjPersonRaces Is Nothing Then
                mobjPersonRaces = New PersonRaces(Me)
            End If
            Return mobjPersonRaces
        End Get
        Set
            mobjPersonRaces = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingAttempts">LocatingAttempts</see> collection for the Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.LocatingAttempts">LocatingAttempts</see> collection for the Case object.
    ''' </value>

        Public ReadOnly Property LocatingAttempts As LocatingAttempts
        Get
            If mobjLocatingAttempts Is Nothing Then
                mobjLocatingAttempts = New LocatingAttempts(Me)
            End If
            Return mobjLocatingAttempts
        End Get
    End Property

    Public ReadOnly Property NoteFromLoc As String
        Get
            For Each objLoc As LocatingAttempt In LocatingAttempts
                If objLoc.LocatingAttemptID.IsNull Then
                    Return objLoc.Note.Value
                End If
            Next

            Return String.Empty
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> class for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> class for the Person object.
    ''' </value>

        Public Property LocatingStatus As LocatingStatus
        Get
            If mobjLocatingStatus Is Nothing Then
                mobjLocatingStatus = New LocatingStatus(Me)
            End If
            Return mobjLocatingStatus
        End Get
        Set
            mobjLocatingStatus = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.PersonBest">PersonBest</see> class for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PersonBest">PersonBest</see> class for the Person object.
    ''' </value>

        Friend Property PersonBest As PersonBest
        Get
            If mobjPersonBest Is Nothing Then
                mobjPersonBest = New PersonBest(Me)
            End If
            Return mobjPersonBest
        End Get
        Set
            mobjPersonBest = value
        End Set
    End Property

    Public Property BestMailingAddress As Address
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestMailingAddress
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestMailingAddress = value
        End Set
    End Property

    Public Property BestPhysicalAddress As Address
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestPhysicalAddress
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestPhysicalAddress = value
        End Set
    End Property

    Public Property BestCheckAddress As Address
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestCheckAddress
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestCheckAddress = value
        End Set
    End Property

    Public Property BestPhone As Phone
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestPhone
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestPhone = value
        End Set
    End Property

    Public Property BestEmail As Email
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestEmail
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestEmail = value
        End Set
    End Property

    Public Property BestSocialNetwork As SocialNetwork
        Get
            If Not PersonBest Is Nothing Then
                Return PersonBest.BestSocialNetwork
            Else
                Return Nothing
            End If
        End Get
        Set
            PersonBest.BestSocialNetwork = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Address">OriginalAddress</see> for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">OriginalAddress</see> for the Person object is
    '''     the oldest address using the ranking of:
    '''     CreatedOn, BestPhysicalAdddress, BestMailingAddress, AddressID
    '''     NOTE: This could return Nothing, if there are no Addresses for this Person.
    ''' </value>

        Public ReadOnly Property OriginalAddress As Address
        Get
            Dim objOrig As Address = Nothing
            For Each objAddress As Address In Me.Addresses
                If objOrig Is Nothing Then
                    objOrig = objAddress
                ElseIf objAddress.CreatedOn < objOrig.CreatedOn Then
                    objOrig = objAddress
                ElseIf objAddress.CreatedOn = objOrig.CreatedOn Then
                    If Me.BestPhysicalAddress IsNot Nothing AndAlso
                       Me.BestPhysicalAddress.Equals(objAddress) Then
                        objOrig = objAddress
                    ElseIf Me.BestPhysicalAddress IsNot Nothing And
                           Me.BestMailingAddress IsNot Nothing Then

                        If Me.BestMailingAddress.Equals(objAddress) And
                           Not Me.BestPhysicalAddress.Equals(objOrig) Then
                            objOrig = objAddress
                        ElseIf objAddress.AddressID < objOrig.AddressID And
                               Not Me.BestPhysicalAddress.Equals(objOrig) And
                               Not Me.BestMailingAddress.Equals(objOrig) Then
                            objOrig = objAddress
                        End If
                    ElseIf objAddress.AddressID < objOrig.AddressID Then
                        objOrig = objAddress
                    End If
                End If
            Next

            Return objOrig
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Address">OriginalAddress</see> for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Phone">OriginalPhone</see> for the Person object is
    '''     the oldest Phone using the ranking of:
    '''     CreatedOn, BestPhone, PhoneID
    '''     NOTE: This could return Nothing, if there are no Phones for this Person.
    ''' </value>

        Public ReadOnly Property OriginalPhone As Phone
        Get
            Dim objOrig As Phone = Nothing
            For Each objPhone As Phone In Me.Phones
                If objOrig Is Nothing Then
                    objOrig = objPhone
                ElseIf objPhone.CreatedOn < objOrig.CreatedOn Then
                    objOrig = objPhone
                ElseIf objPhone.CreatedOn = objOrig.CreatedOn Then
                    If Me.BestPhone IsNot Nothing Then
                        If Me.BestPhone.Equals(objPhone) Then
                            objOrig = objPhone
                        ElseIf objPhone.PhoneID < objOrig.PhoneID And
                               Not Me.BestPhone.Equals(objOrig) Then
                            objOrig = objPhone
                        End If
                    ElseIf objPhone.PhoneID < objOrig.PhoneID Then
                        objOrig = objPhone
                    End If
                End If
            Next

            Return objOrig
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Address">OriginalAddress</see> for the Person object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Email">OriginalEmail</see> for the Person object is
    '''     the oldest Email using the ranking of:
    '''     CreatedOn, BestEmail, EmailID
    '''     NOTE: This could return Nothing, if there are no Emails for this Person.
    ''' </value>

        Public ReadOnly Property OriginalEmail As Email
        Get
            Dim objOrig As Email = Nothing
            For Each objEmail As Email In Me.Emails
                If objOrig Is Nothing Then
                    objOrig = objEmail
                ElseIf objEmail.CreatedOn < objOrig.CreatedOn Then
                    objOrig = objEmail
                ElseIf objEmail.CreatedOn = objOrig.CreatedOn Then
                    If Me.BestEmail IsNot Nothing Then
                        If Me.BestEmail.Equals(objEmail) Then
                            objOrig = objEmail
                        ElseIf objEmail.EmailID < objOrig.EmailID And
                               Not Me.BestEmail.Equals(objOrig) Then
                            objOrig = objEmail
                        End If
                    ElseIf objEmail.EmailID < objOrig.EmailID Then
                        objOrig = objEmail
                    End If
                End If
            Next

            Return objOrig
        End Get
    End Property

    Public Property Student As Student
        Get
            'If mobjStudent Is Nothing Then
            '    'If (Not CaseID.IsNull) AndAlso (Not MPRID.IsNull) Then
            '    '    mobjStudent = New Student(Me)   '(CaseID.Value, Me.MPRID.ToString)
            '    'End If
            '    Throw New Exception("Person.vb::You have tried to use a Student object before defining a Person within a 'Student' Case as RelationshipType = Primary Sample Member")
            'End If
            Return mobjStudent
        End Get
        Set
            mobjStudent = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets the full name of the person
    ''' </summary>
    ''' <value>
    '''     The full name constructed from first, middle, last name.
    ''' </value>

        Public ReadOnly Property FullName As String
        Get
            Dim sb As New StringBuilder
            If (Not FirstName.IsNull) AndAlso FirstName.Value <> "" Then
                sb.Append(FirstName.Value & " ")
            End If
            If (Not MiddleName.IsNull) AndAlso MiddleName.Value <> "" Then
                sb.Append(MiddleName.Value & " ")
            End If
            If (Not LastName.IsNull) AndAlso LastName.Value <> "" Then
                sb.Append(LastName.Value & " ")
            End If
            If (Not Suffix.IsNull) AndAlso Suffix.Value <> "" Then
                sb.Append(Suffix.Value & " ")
            End If
            If sb.Length > 0 Then
                sb.Remove(sb.Length - 1, 1)
            End If
            Return sb.ToString
        End Get
    End Property

    ''' <summary>
    '''     Gets the age of the Person represented by the Person object.
    ''' </summary>
    ''' <value>
    '''     The age of the person represented by the Person object or -1 if unavailable.
    ''' </value>
    ''' <remarks>
    '''     Age is calculated using today's date and the Person's date of birth.
    '''     If date of birth is Nothing (null), -1 is returned.
    ''' </remarks>

        Public Shadows ReadOnly Property Age As Integer
        Get
            If MyBase.DateOfBirth.IsNull Then
                Return - 1
            Else
                Return DateTime.Now.Year() - MyBase.DateOfBirth.Value.Year
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Person object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Person object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets the MPRID of the Person object
    ''' </summary>
    ''' <value>
    '''     The MPRID of the Person object.
    ''' </value>

        Public Shadows ReadOnly Property MPRID As SqlString
        Get
            Return MyBase.MPRID
        End Get
    End Property

    ''' <summary>
    '''     Gets the RelationshipType of the Person object.
    ''' </summary>
    ''' <value>
    '''     The RelationshipType of the Person object.
    ''' </value>

        Public Property RelationshipType As RelationshipType
        Get
            Dim i As Integer
            If Not RelationshipTypeID.IsNull Then
                i = Project.RelationshipTypes.IndexOf(RelationshipTypeID.Value)
            Else
                i = Project.RelationshipTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjRelationshipType = Project.RelationshipTypes(i)
            End If
            Return mobjRelationshipType
        End Get
        Set
            mobjRelationshipType = value
            RelationshipTypeID = mobjRelationshipType.RelationshipTypeID
            CreateEntityObject()
        End Set
    End Property

    Public Overloads Property RelationshipTypeID As SqlInt32
        Get
            Return MyBase.RelationshipTypeID
        End Get
        Set
            MyBase.RelationshipTypeID = value
            CreateEntityObject()
        End Set
    End Property

    ''' <summary>
    '''     Gets the LanguageType of the Person object.
    ''' </summary>
    ''' <value>
    '''     The LanguageType of the Person object.
    ''' </value>

        Public Property LanguageType As LanguageType
        Get
            Dim i As Integer
            If Not LanguageTypeID.IsNull Then
                i = Project.LanguageTypes.IndexOf(LanguageTypeID.Value)
            Else
                i = Project.LanguageTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjLanguageType = Project.LanguageTypes(i)
            End If
            Return mobjLanguageType
        End Get
        Set
            mobjLanguageType = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the ConsentType of the Person object.
    ''' </summary>
    ''' <value>
    '''     The ConsentType of the Person object.
    ''' </value>

        Public Property ConsentType As ConsentType
        Get
            Dim i As Integer
            If Not ConsentID.IsNull Then
                i = Project.ConsentTypes.IndexOf(ConsentID.Value)
            Else
                i = - 1  'Project.ConsentTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjConsentType = Project.ConsentTypes(i)
            Else
                mobjConsentType = New ConsentType()
                mobjConsentType.Description = "Not received"
            End If
            Return mobjConsentType
        End Get
        Set
            mobjConsentType = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the AssentType of the Person object.
    ''' </summary>
    ''' <value>
    '''     The AssentType of the Person object.
    ''' </value>

        Public Property AssentType As ConsentType
        Get
            Dim i As Integer
            If Not AssentID.IsNull Then
                i = Project.ConsentTypes.IndexOf(AssentID.Value)
            Else
                i = - 1  'Project.ConsentTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjAssentType = Project.ConsentTypes(i)
            Else
                mobjAssentType = New ConsentType()
                mobjAssentType.Description = "Not received"
            End If
            Return mobjAssentType
        End Get
        Set
            mobjAssentType = value
        End Set
    End Property

    ''' <summary>
    '''     Returns whether this current Person object is "valid", based on the criteria noted within.
    ''' </summary>
    ''' <value>
    '''     A boolean value representing whether the Person object is "valid".
    ''' </value>

        Public ReadOnly Property IsValid As Boolean
        Get

            'Person must have either first or last name filled out
            If Me Is Nothing Then
                Return False
            Else
                Return (Not LastName.ToString.Length.Equals(0) Or
                        Not FirstName.ToString.Length.Equals(0))
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Creates a new instance of the Person class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Person class pertaining
    '''     to a person.
    ''' </remarks>

        Public Sub New(strMPRID As String)

        MyBase.New()

        MyBase.MPRID = CType(New SqlInt32(CInt(strMPRID)), SqlString)

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        ' Open the database if needed

        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            ConnectionProvider.OpenConnection()
        End If

        SelectOne()

        ResetModified()

        ' Insure the database is always closed if it was opened here

        If blnCloseConnection Then
            blnCloseConnection = False
            ConnectionProvider.CloseConnection(False)
        End If

        ConnectionProvider = Nothing
    End Sub

    ''' <overloads>
    '''     The Person class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Person class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Person object belongs to.
    ''' </param>

        Public Sub New(objCase As [Case])

        mobjCase = objCase

        ConnectionString = mobjCase.Project.ConnectionString

        If Not objCase.CaseID.IsNull Then
            MyBase.CaseID = objCase.CaseID
        End If

        InSample = mobjCase.InSample
        IsIneligible = mobjCase.IsIneligible

        mobjAddresses = New Addresses
        mobjPhones = New Phones
        mobjEmails = New Emails
        mobjSocialNetworks = New SocialNetworks
        mobjNotes = New AllNotes
        mobjPersonRaces = New PersonRaces
        'mobjLocatingStatus = New LocatingStatus

        mobjCase.Persons.Add(Me)

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Person class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Person object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Person object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        ConnectionString = mobjCase.Project.ConnectionString

        CreateEntityObject()

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Person class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Person class pertaining
    '''     to a case, without adding it to the case's Persons collection.
    ''' </remarks>

        Public Sub New(intCaseID As Integer)

        MyBase.New()

        mobjCase = New [Case](intCaseID, False)

        If Not mobjCase.CaseID.IsNull AndAlso
           Not mobjCase.CaseID.Value.Equals(0) Then 'existing case
            MyBase.CaseID = mobjCase.CaseID
            InSample = mobjCase.InSample
            IsIneligible = mobjCase.IsIneligible
        Else 'new case
            InSample = True
            IsIneligible = False
        End If
        mobjPersonRaces = New PersonRaces(Me)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Person class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Person object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub ResolveAddresses()

        If mobjAddresses Is Nothing Then
            mobjAddresses = New Addresses
        End If
        mobjAddresses.Clear()

        Dim objAddress As Address

        For Each objAddress In mobjCase.Addresses
            If objAddress.Person Is Nothing OrElse
               objAddress.Person.Equals(Me) Then

                mobjAddresses.Add(objAddress)
            End If
        Next
    End Sub

    Private Sub ResolvePhones()

        If mobjPhones Is Nothing Then
            mobjPhones = New Phones
        End If
        mobjPhones.Clear()

        Dim objPhone As Phone

        For Each objPhone In mobjCase.Phones

            If objPhone.Person Is Nothing OrElse
               objPhone.Person.Equals(Me) Then

                mobjPhones.Add(objPhone)
            End If
        Next
    End Sub

    Private Sub ResolveEmails()

        If mobjEmails Is Nothing Then
            mobjEmails = New Emails
        End If
        mobjEmails.Clear()

        Dim objEmail As Email

        For Each objEmail In mobjCase.Emails
            If objEmail.Person Is Nothing OrElse
               objEmail.Person.Equals(Me) Then

                mobjEmails.Add(objEmail)
            End If
        Next
    End Sub


    Private Sub ResolveSocialNetworks()

        If mobjSocialNetworks Is Nothing Then
            mobjSocialNetworks = New SocialNetworks
        End If
        mobjSocialNetworks.Clear()

        Dim objSocialNetwork As SocialNetwork

        For Each objSocialNetwork In mobjCase.SocialNetworks
            If objSocialNetwork.Person Is Nothing OrElse
               objSocialNetwork.Person.Equals(Me) Then

                mobjSocialNetworks.Add(objSocialNetwork)
            End If
        Next
    End Sub

    Private Sub ResolveNotes()

        If mobjNotes Is Nothing Then
            mobjNotes = New AllNotes
        End If
        mobjNotes.Clear()

        Dim objNote As AllNote

        For Each objNote In mobjCase.Notes
            If objNote.Person Is Nothing OrElse
               objNote.Person.Equals(Me) Then

                mobjNotes.Add(objNote)
            End If
        Next
    End Sub

    Private Sub CreateEntityObject()

        'If the Case is a Student type, and the Person's RelationshipType
        'is the primary sample member (i.e. Student), then make sure we
        'have created the Student object.
        If mobjCase.EntityTypeID = Enumerations.tlkpEntityType.Student AndAlso
           RelationshipType.IsPrimarySampleMember = True AndAlso
           mobjStudent Is Nothing Then

            mobjStudent = New Student(Me)
        End If
    End Sub

    Private ReadOnly letters() As String = {"a", "b", "c", "d", "e", "f", "g", "h", "j", "k",
                                            "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}

    Private ReadOnly numbers() As String = {"2", "3", "4", "5", "6", "7", "8", "9"}

    Private Sub CreateWebLoginAndPassword()
        If Me.WebPassword.Value.Length = 0 AndAlso Me.WebUsername.Value.Length = 0 Then

            Dim sb As New StringBuilder
            Dim rnd As New Random()
            For i As Integer = 1 To 4
                sb.Append(letters(rnd.Next(0, 23)))
                sb.Append(numbers(rnd.Next(0, 8)))
            Next
            Me.WebPassword = sb.ToString

            Dim iUserName As Integer = 222222
            Try
                Dim obj As Object = SqlHelper.ExecuteScalar(ConnectionString, "SMS_GetMaxWebUsername")
                If obj IsNot DBNull.Value Then
                    iUserName = CInt(obj) + 1
                End If
            Catch ex As Exception
                Throw ex
            End Try

            Dim UserName As String = CStr(iUserName)

            If UserName.Substring(5, 1) = "0" Then
                iUserName = iUserName + 2
            Else
                If UserName.Substring(5, 1) = "1" Then
                    iUserName = iUserName + 1
                End If
            End If

            If UserName.Substring(4, 1) = "0" Then
                iUserName = iUserName + 20
            Else
                If UserName.Substring(4, 1) = "1" Then
                    iUserName = iUserName + 10
                End If
            End If

            If UserName.Substring(3, 1) = "0" Then
                iUserName = iUserName + 200
            Else
                If UserName.Substring(3, 1) = "1" Then
                    iUserName = iUserName + 100
                End If
            End If
            If UserName.Substring(2, 1) = "0" Then
                iUserName = iUserName + 2000
            Else
                If UserName.Substring(2, 1) = "1" Then
                    iUserName = iUserName + 1000
                End If
            End If

            If UserName.Substring(1, 1) = "0" Then
                iUserName = iUserName + 20000
            Else
                If UserName.Substring(1, 1) = "1" Then
                    iUserName = iUserName + 10000
                End If
            End If

            If UserName.Substring(0, 1) = "0" Then
                iUserName = iUserName + 20000
            Else
                If UserName.Substring(0, 1) = "1" Then
                    iUserName = iUserName + 10000
                End If
            End If

            Me.WebUsername = CStr(iUserName)

        End If
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a Person object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        If Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        MyBase.MPRID = New SqlString(Project.GenerateMPRID())
        CreateWebLoginAndPassword()
        Try
            blnResult = MyBase.Insert()
            If blnResult Then
                blnResult = mobjPersonRaces.Insert()
            End If

            ' If successful, insert the Locating Status
            If blnResult AndAlso
               mobjLocatingStatus IsNot Nothing AndAlso
               mobjLocatingStatus.IsModified Then
                blnResult = mobjLocatingStatus.Insert()
            End If

            'LocatingAttempts are saved in Case.vb
            '' If successful, insert the Locating Attempts
            'If blnResult AndAlso (mobjLocatingAttempts IsNot Nothing) Then
            '    blnResult = mobjLocatingAttempts.Insert()
            'End If

            'only save the Student record if the Case entity type = Student
            'and the Person RelationshipType is the Primary Sample Member (i.e. student).
            If blnResult AndAlso
               mobjCase.EntityTypeID = Enumerations.tlkpEntityType.Student AndAlso
               RelationshipType.IsPrimarySampleMember = True Then
                blnResult = mobjStudent.Insert
            End If

        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the Person object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If MPRID.IsNull OrElse MPRID.ToString = "" Then
            Return Insert()
            'ElseIf Not IsModified andalso not mobjPersonRaces.IsModified andalso Then
            '   Return True
        End If

        Dim blnResult As Boolean = True

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If
        Try
            If IsModified Then
                blnResult = MyBase.Update()
            Else
                blnResult = True
            End If
            If blnResult Then
                If mobjPersonRaces IsNot Nothing 
                    If  mobjPersonRaces.IsModified Then
                        blnResult = mobjPersonRaces.Update()
                    Else
                        blnResult = True
                    End If
                End If
            End If

            ' If successful, update the Locating Status
            If blnResult AndAlso
               mobjLocatingStatus IsNot Nothing AndAlso
               mobjLocatingStatus.IsModified Then
                blnResult = mobjLocatingStatus.Update()
            End If

            'LocatingAttempts are saved in Case.vb
            '' If successful, update the Locating Attempts
            'If blnResult AndAlso (LocatingAttempts IsNot Nothing) Then
            '    blnResult = LocatingAttempts.Update()
            'End If

            'only save the Student record if the Case entity type = Student
            'and the Person RelationshipType is the Primary Sample Member (i.e. student).
            'Otherwise, delete the Student record (if it existed)
            If blnResult AndAlso
               mobjCase.EntityTypeID = Enumerations.tlkpEntityType.Student AndAlso
               RelationshipType.IsPrimarySampleMember = True Then
                blnResult = Student.Update()
            ElseIf Student IsNot Nothing Then
                Student.Delete()
            End If

        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes the Person object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Person object has been deleted, otherwise false
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If
        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

#End Region
End Class
