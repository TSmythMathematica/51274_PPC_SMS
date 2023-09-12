'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Person's Locating Status information.
''' </summary>

    Public Class LocatingAttempt
    Inherits TblLocatingAttempt

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person            'the person attached to this attempt (MPRID)

    Private mobjPersonLocated As Person     'the person added/edited during this locating attempt
    Private mobjPersonHistory As PersonHistory = Nothing    'history record of the PersonLocated record
    Private mobjAddress As Address = Nothing
    Private mobjAddressHistory As AddressHistory = Nothing
    Private mobjPhone As Phone = Nothing
    Private mobjPhoneHistory As PhoneHistory = Nothing
    Private mobjEmail As Email = Nothing
    Private mobjEmailHistory As EmailHistory = Nothing
    Private mobjSocialNetwork As SocialNetwork = Nothing
    Private mobjSocialNetworkHistory As SocialNetworkHistory = Nothing
    Private mobjDocument As Document = Nothing

    Private mobjLocatingAttemptType As LocatingAttemptType
    Private mobjLocatingAttemptResult As LocatingAttemptResult

#End Region

#Region "Events"

    Event OnInsert(objRelationship As LocatingAttempt)
    Event OnUpdate(objRelationship As LocatingAttempt)
    Event OnDelete(objRelationship As LocatingAttempt)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Locating Attempt belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Locating Attempt belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Locating Attempt object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Locating Attempt object belongs to.
    ''' </value>

        Public ReadOnly Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Locating Attempt object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Locating Attempt object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingAttempt object is
    '''     associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingAttempt object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an LocatingAttempt object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this
    '''     property to Nothing (null).
    '''     The Address object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Person As Person
        Get
            If mobjPerson Is Nothing Then
                ' Get the index of the associated Person object initializing the Person
                ' object reference as needed.
                If mobjCase IsNot Nothing AndAlso
                   Not MPRID.IsNull AndAlso Not MPRID.ToString.Equals("") Then

                    Dim i As Integer = mobjCase.Persons.IndexOf(MPRID.ToString)

                    If i >= 0 Then
                        mobjPerson = mobjCase.Persons(i)
                    End If
                End If
            End If
            Return mobjPerson
        End Get
        Set
            mobjPerson = Value
            MPRID = mobjPerson.MPRID
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that was added/edited during this locating
    '''     attempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that was modified during this locating attempt
    ''' </value>
    ''' <remarks>
    '''     The PersonLocated may or may not be the same as the Person that this locating attempt belongs to. For example,
    '''     when Leads/Contacts are found for a person in locating, the PersonLocated is that Lead/Contact, whereas the
    '''     Person object is the MPRID that is in Locating.
    ''' </remarks>

        Public Property PersonLocated As Person
        Get
            If mobjPersonLocated Is Nothing Then
                If PersonHistory IsNot Nothing Then
                    mobjPersonLocated = PersonHistory.Person
                End If
            End If

            Return mobjPersonLocated
        End Get
        Set
            mobjPersonLocated = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object of this LocatingAttempt's
    '''     PersonLocating.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object of this LocatingAttempt's PersonLocated.
    ''' </value>
    ''' <remarks>
    '''     This is the History record of the PersonLocated at the time this LocatingAttempt was inserted.
    ''' </remarks>
    Public Property PersonHistory As PersonHistory
        Get
            If mobjPersonHistory Is Nothing Then
                If Not PersonHistoryID.IsNull Then
                    mobjPersonHistory = New PersonHistory(PersonHistoryID.Value)
                    mobjPersonHistory.Case = mobjCase
                End If
            End If
            Return mobjPersonHistory
        End Get
        Set
            mobjPersonHistory = Value
            If Not mobjPersonHistory Is Nothing Then
                PersonHistoryID = mobjPersonHistory.PersonHistoryID
            Else
                PersonHistoryID = 0
            End If
        End Set
    End Property

    'Gets/Sets the Current Address. 
    'Use Address when dealing with Addresses that have been updated or added, but not saved to the database yet.
    'Use AddressHistory to get the Address at the time this LocatingAttempt was made.
    Public Property Address As Address
        Get
            'If mobjAddress Is Nothing AndAlso _
            '   AddressHistory IsNot Nothing Then
            '    mobjAddress = AddressHistory.Address
            'End If
            Return mobjAddress
        End Get
        Set
            mobjAddress = value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object of this LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object of this LocatingAttempt.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a LocatingAttempt object from a <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see>
    '''     object, set this property to Nothing (null).
    '''     The LocatingAttempt object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>
    Public Property AddressHistory As AddressHistory
        Get
            If mobjAddressHistory Is Nothing Then
                If Not AddressHistoryID.IsNull Then
                    mobjAddressHistory = New AddressHistory(AddressHistoryID.Value)
                    'ElseIf mobjAddress IsNot Nothing Then
                    '    mobjAddressHistory = mobjAddress.AddressHistory
                End If
            End If
            Return mobjAddressHistory
        End Get
        Set
            mobjAddressHistory = Value
            If Not mobjAddressHistory Is Nothing Then
                AddressHistoryID = mobjAddressHistory.AddressHistoryID
            Else
                AddressHistoryID = 0
            End If
            'Address = mobjAddressHistory.Address
        End Set
    End Property

    'Gets/Sets the Current Phone. 
    'Use Phone when dealing with Phones that have been updated or added, but not saved to the database yet.
    'Use PhoneHistory to get the Phone at the time this LocatingAttempt was made.
    Public Property Phone As Phone
        Get
            'If mobjPhone Is Nothing AndAlso _
            '   PhoneHistory IsNot Nothing Then
            '    mobjPhone = mobjPhoneHistory.Phone
            'End If
            Return mobjPhone
        End Get
        Set
            mobjPhone = value
        End Set
    End Property

    ''' <summary>
    '''     Gets/sets the <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> object of this LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> object of this LocatingAttempt.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a LocatingAttempt object from a <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> object,
    '''     set this property to Nothing (null).
    '''     The LocatingAttempt object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>
    Public Property PhoneHistory As PhoneHistory
        Get
            If mobjPhoneHistory Is Nothing Then
                If Not PhoneHistoryID.IsNull Then
                    mobjPhoneHistory = New PhoneHistory(PhoneHistoryID.Value)
                    'ElseIf mobjPhone IsNot Nothing Then
                    '    mobjPhoneHistory = mobjPhone.PhoneHistory
                End If
            End If
            Return mobjPhoneHistory
        End Get
        Set
            mobjPhoneHistory = Value
            If Not mobjPhoneHistory Is Nothing Then
                PhoneHistoryID = mobjPhoneHistory.PhoneHistoryID
            Else
                PhoneHistoryID = 0
            End If
            'Phone = mobjPhoneHistory.Phone
        End Set
    End Property

    'Gets/Sets the Current Email. 
    'Use Email when dealing with Emails that have been updated or added, but not saved to the database yet.
    'Use EmailHistory to get the Email at the time this LocatingAttempt was made.
    Public Property Email As Email
        Get
            'If mobjEmail Is Nothing AndAlso _
            '   EmailHistory IsNot Nothing Then
            '    mobjEmail = EmailHistory.Email
            'End If
            Return mobjEmail
        End Get
        Set
            mobjEmail = value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> object of this LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> object of this LocatingAttempt.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a LocatingAttempt object from a <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> object,
    '''     set this property to Nothing (null).
    '''     The LocatingAttempt object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>
    Public Property EmailHistory As EmailHistory
        Get
            If mobjEmailHistory Is Nothing Then
                If Not EmailHistoryID.IsNull Then
                    mobjEmailHistory = New EmailHistory(EmailHistoryID.Value)
                    'ElseIf mobjEmail IsNot Nothing Then
                    '    mobjEmailHistory = mobjEmail.EmailHistory
                End If
            End If
            Return mobjEmailHistory
        End Get
        Set
            mobjEmailHistory = Value
            If Not mobjEmailHistory Is Nothing Then
                EmailHistoryID = mobjEmailHistory.EmailHistoryID
            Else
                EmailHistoryID = 0
            End If
            'Email = mobjEmailHistory.Email
        End Set
    End Property


    'Gets/Sets the Current SocialNetwork. 
    'Use SocialNetwork when dealing with SocialNetworks that have been updated or added, but not saved to the database yet.
    'Use SocialNetworkHistory to get the SocialNetwork at the time this LocatingAttempt was made.
    Public Property SocialNetwork As SocialNetwork
        Get
            'If mobjSocialNetwork Is Nothing AndAlso _
            '   SocialNetworkHistory IsNot Nothing Then
            '    mobjSocialNetwork = SocialNetworkHistory.SocialNetwork
            'End If
            Return mobjSocialNetwork
        End Get
        Set
            mobjSocialNetwork = value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.SocialNetworkHistory">SocialNetworkHistory</see> object of this
    '''     LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetworkHistory">SocialNetworkHistory</see> object of this LocatingAttempt.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a LocatingAttempt object from a
    '''     <see cref="T:MPR.SMS.Data.SocialNetworkHistory">SocialNetworkHistory</see> object, set this property to Nothing
    '''     (null).
    '''     The LocatingAttempt object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.SocialNetworkHistory">SocialNetworkHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>
    Public Property SocialNetworkHistory As SocialNetworkHistory
        Get
            If mobjSocialNetworkHistory Is Nothing Then
                If Not SocialNetworkHistoryID.IsNull Then
                    mobjSocialNetworkHistory = New SocialNetworkHistory(SocialNetworkHistoryID.Value)
                    'ElseIf mobjSocialNetwork IsNot Nothing Then
                    '    mobjSocialNetworkHistory = mobjSocialNetwork.SocialNetworkHistory
                End If
            End If
            Return mobjSocialNetworkHistory
        End Get
        Set
            mobjSocialNetworkHistory = Value
            If Not mobjSocialNetworkHistory Is Nothing Then
                SocialNetworkHistoryID = mobjSocialNetworkHistory.SocialNetworkHistoryID
            Else
                SocialNetworkHistoryID = 0
            End If
            'SocialNetwork = mobjSocialNetworkHistory.SocialNetwork
        End Set
    End Property

    'Gets/Sets the current associated Document. 
    Public Property Document As Document
        Get
            Return mobjDocument
        End Get
        Set
            mobjDocument = value
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingAttempt.
    ''' </value>

        Public Property LocatingAttemptType As LocatingAttemptType
        Get
            mobjLocatingAttemptType = New LocatingAttemptType(LocatingAttemptTypeID.Value)

            Return mobjLocatingAttemptType
        End Get
        Set
            mobjLocatingAttemptType = Value
            LocatingAttemptTypeID = mobjLocatingAttemptType.LocatingAttemptTypeID
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingAttempt.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Status">Status</see> object of the LocatingAttempt.
    ''' </value>

        Public Property LocatingAttemptResult As LocatingAttemptResult
        Get
            mobjLocatingAttemptResult = New LocatingAttemptResult(LocatingAttemptResultID.Value)

            Return mobjLocatingAttemptResult
        End Get
        Set
            mobjLocatingAttemptResult = Value
            LocatingAttemptResultID = mobjLocatingAttemptResult.LocatingAttemptResultID
        End Set
    End Property

    Public ReadOnly Property DisplayName As String
        Get
            If PersonHistory IsNot Nothing Then
                Return mobjPersonHistory.FullName
            ElseIf PersonLocated IsNot Nothing Then
                Return mobjPersonLocated.FullName
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property DisplayAddress As String
        Get
            If Address IsNot Nothing Then
                Return mobjAddress.FullAddress
            ElseIf AddressHistory IsNot Nothing Then
                Return mobjAddressHistory.FullAddress
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property DisplayPhone As String
        Get
            If Phone IsNot Nothing Then
                Return GetSafePhone(mobjPhone.PhoneNum)
            ElseIf PhoneHistory IsNot Nothing Then
                Return GetSafePhone(mobjPhoneHistory.PhoneNum)
            Else
                Return String.Empty
            End If
        End Get
    End Property

    Public ReadOnly Property DisplayEmail As String
        Get
            If Email IsNot Nothing Then
                Return GetSafeValue(mobjEmail.EmailAddress)
            ElseIf EmailHistory IsNot Nothing Then
                Return GetSafeValue(mobjEmailHistory.EmailAddress)
            Else
                Return String.Empty
            End If
        End Get
    End Property

#End Region

#Region "Private Properties"

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Relationship class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Relationship class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    Friend Sub New(forPerson As Person, objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjPerson = forPerson

        If forPerson IsNot Nothing AndAlso forPerson.Case IsNot Nothing Then
            mobjCase = forPerson.Case
        End If
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the LocatingAttempt class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the LocatingAttempt is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        'Dim intcaseid As Integer
        'intcaseid = CInt(objDataRow.Item(caseid)

        'mobjCase = New MPR.SMS.Data.Case(Me.CaseID, False)
        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Creates a new instance of the LocatingAttempt class.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the LocatingAttempt object belongs to.
    ''' </param>

        Public Sub New(objPerson As Person)

        mobjPerson = objPerson

        ConnectionString = mobjPerson.Project.ConnectionString

        If Not objPerson.CaseID.IsNull Then
            MyBase.MPRID = objPerson.MPRID
        End If

        mobjPerson.LocatingAttempts.Add(Me)

        ResetModified()
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Relationship into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Relationship object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjPerson.CaseID
        MyBase.MPRID = mobjPerson.MPRID

        If mobjPersonHistory IsNot Nothing Then
            MyBase.PersonHistoryID = mobjPersonHistory.PersonHistoryID
        ElseIf mobjPersonLocated IsNot Nothing Then
            MyBase.PersonHistoryID = mobjPersonLocated.PersonHistory.PersonHistoryID
        Else
            MyBase.PersonHistoryID = New SqlInt32(0)
        End If
        If mobjAddress IsNot Nothing Then
            MyBase.AddressHistoryID = mobjAddress.AddressHistory.AddressHistoryID
        ElseIf mobjAddressHistory IsNot Nothing Then
            MyBase.AddressHistoryID = mobjAddressHistory.AddressHistoryID
        Else
            MyBase.AddressHistoryID = New SqlInt32(0)
        End If
        If mobjPhone IsNot Nothing Then
            MyBase.PhoneHistoryID = mobjPhone.PhoneHistory.PhoneHistoryID
        ElseIf mobjPhoneHistory IsNot Nothing Then
            MyBase.PhoneHistoryID = mobjPhoneHistory.PhoneHistoryID
        Else
            MyBase.PhoneHistoryID = New SqlInt32(0)
        End If
        If mobjEmail IsNot Nothing Then
            MyBase.EmailHistoryID = mobjEmail.EmailHistory.EmailHistoryID
        ElseIf mobjEmailHistory IsNot Nothing Then
            MyBase.EmailHistoryID = mobjEmailHistory.EmailHistoryID
        Else
            MyBase.EmailHistoryID = New SqlInt32(0)
        End If

        If mobjDocument IsNot Nothing Then
            MyBase.DocumentID = mobjDocument.DocumentID
        Else
            MyBase.DocumentID = New SqlInt32(0)
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        'Insert the LocatingAttempt
        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
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
    '''     Updates a Relationship object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If LocatingAttemptID.IsNull Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = False

        If mobjPersonHistory IsNot Nothing Then
            MyBase.PersonHistoryID = mobjPersonHistory.PersonHistoryID
        ElseIf mobjPersonLocated IsNot Nothing Then
            MyBase.PersonHistoryID = mobjPersonLocated.PersonHistory.PersonHistoryID
        Else
            MyBase.PersonHistoryID = New SqlInt32(0)
        End If
        If mobjAddress IsNot Nothing Then
            MyBase.AddressHistoryID = mobjAddress.AddressHistory.AddressHistoryID
        ElseIf mobjAddressHistory IsNot Nothing Then
            MyBase.AddressHistoryID = mobjAddressHistory.AddressHistoryID
        Else
            MyBase.AddressHistoryID = New SqlInt32(0)
        End If
        If mobjPhone IsNot Nothing Then
            MyBase.PhoneHistoryID = mobjPhone.PhoneHistory.PhoneHistoryID
        ElseIf mobjPhoneHistory IsNot Nothing Then
            MyBase.PhoneHistoryID = mobjPhoneHistory.PhoneHistoryID
        Else
            MyBase.PhoneHistoryID = New SqlInt32(0)
        End If
        If mobjEmail IsNot Nothing Then
            MyBase.EmailHistoryID = mobjEmail.EmailHistory.EmailHistoryID
        ElseIf mobjEmailHistory IsNot Nothing Then
            MyBase.EmailHistoryID = mobjEmailHistory.EmailHistoryID
        Else
            MyBase.EmailHistoryID = New SqlInt32(0)
        End If

        If mobjDocument IsNot Nothing Then
            MyBase.DocumentID = mobjDocument.DocumentID
        Else
            MyBase.DocumentID = New SqlInt32(0)
        End If

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If


        ' Update the LocatingAttempt
        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            ResetModified()
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Relationship from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the LocatingAttempt

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
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
