'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Person's Best Address/Phone/Email.
''' </summary>

    Public Class PersonBest
    Inherits TblPersonBest

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjPerson As Person

    Private mobjBestMailingAddress As Address
    Private mobjBestPhysicalAddress As Address
    Private mobjBestCheckAddress As Address
    Private mobjBestPhone As Phone
    Private mobjBestEmail As Email
    Private mobjBestSocialNetwork As SocialNetwork
    Private mblnIsNew As Boolean = False

#End Region

#Region "Events"

    Event OnInsert(objRelationship As PersonBest)
    Event OnUpdate(objRelationship As PersonBest)
    Event OnDelete(objRelationship As PersonBest)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
    ''' </value>

        Public ReadOnly Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Address object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Address object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Address object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Address object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Address object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property
    '''     to Nothing (null).
    '''     The Address object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Person As Person
        Get
            If mobjPerson Is Nothing Then
                ' Get the index of the associated Person object initializing the Person
                ' object reference as needed.
                If Not MPRID.IsNull AndAlso Not MPRID.ToString.Equals("") Then

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
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Address">BestMailingAddress</see> object of the Person.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">BestMailingAddress</see> object of the Person.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Address object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property
    '''     to Nothing (null).
    ''' </remarks>

        Public Property BestMailingAddress As Address
        Get
            ' Get the index of the associated Address object initializing the Person
            ' object reference as needed.
            If mobjBestMailingAddress Is Nothing AndAlso
               Not BestMailingAddressID.IsNull AndAlso
               Not BestMailingAddressID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.Addresses.IndexOf(BestMailingAddressID.Value)

                If i >= 0 Then
                    mobjBestMailingAddress = mobjCase.Addresses(i)
                    Return mobjBestMailingAddress
                End If
            End If

            Return mobjBestMailingAddress
        End Get
        Set
            mobjBestMailingAddress = Value
            If mobjBestMailingAddress IsNot Nothing AndAlso Not mobjBestMailingAddress.AddressID.IsNull Then
                BestMailingAddressID = mobjBestMailingAddress.AddressID
            Else
                BestMailingAddressID = 0
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Address">BestPhysicalAddress</see> object of the Person.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">BestPhysicalAddress</see> object of the Person.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Address object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property
    '''     to Nothing (null).
    ''' </remarks>

        Public Property BestPhysicalAddress As Address
        Get
            ' Get the index of the associated Address object initializing the Person
            ' object reference as needed.
            If mobjBestPhysicalAddress Is Nothing AndAlso
               Not BestPhysicalAddressID.IsNull AndAlso
               Not BestPhysicalAddressID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.Addresses.IndexOf(BestPhysicalAddressID.Value)

                If i >= 0 Then
                    mobjBestPhysicalAddress = mobjCase.Addresses(i)
                End If
            End If

            Return mobjBestPhysicalAddress
        End Get
        Set
            mobjBestPhysicalAddress = Value
            If mobjBestPhysicalAddress IsNot Nothing AndAlso Not mobjBestPhysicalAddress.AddressID.IsNull Then
                BestPhysicalAddressID = mobjBestPhysicalAddress.AddressID
            Else
                BestPhysicalAddressID = 0
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Address">Address</see> object identified as the Check Address for the
    '''     Case object.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">Address</see> object identified as the Check Address for the Case, or
    '''     Nothing if not defined.
    ''' </value>

        Public Property BestCheckAddress As Address
        Get
            ' Get the index of the associated Address object initializing the Person
            ' object reference as needed.
            If mobjBestCheckAddress Is Nothing AndAlso
               Not BestCheckAddressID.IsNull AndAlso
               Not BestCheckAddressID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.Addresses.IndexOf(BestCheckAddressID.Value)

                If i >= 0 Then
                    mobjBestCheckAddress = mobjCase.Addresses(i)
                End If
            End If

            Return mobjBestCheckAddress
        End Get
        Set
            mobjBestCheckAddress = Value
            If mobjBestCheckAddress IsNot Nothing AndAlso Not mobjBestCheckAddress.AddressID.IsNull Then
                BestCheckAddressID = mobjBestCheckAddress.AddressID
            Else
                BestCheckAddressID = 0
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Phone">BestPhone</see> object of the Person.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Phone">BestPhone</see> object of the Person.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a Phone object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    ''' </remarks>

        Public Property BestPhone As Phone
        Get
            ' Get the index of the associated Phone object initializing the Person
            ' object reference as needed.
            If mobjBestPhone Is Nothing AndAlso
               Not BestPhoneID.IsNull AndAlso
               Not BestPhoneID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.Phones.IndexOf(BestPhoneID.Value)

                If i >= 0 Then
                    mobjBestPhone = mobjCase.Phones(i)
                End If
            End If

            Return mobjBestPhone
        End Get
        Set
            mobjBestPhone = Value
            If mobjBestPhone IsNot Nothing AndAlso Not mobjBestPhone.PhoneID.IsNull Then
                BestPhoneID = mobjBestPhone.PhoneID
            Else
                BestPhoneID = 0
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Email">BestEmail</see> object of the Person.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Email">BestEmail</see> object of the Person.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Email object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    ''' </remarks>

        Public Property BestEmail As Email
        Get
            ' Get the index of the associated Email object initializing the Person
            ' object reference as needed.
            If mobjBestEmail Is Nothing AndAlso
               Not BestEmailID.IsNull AndAlso
               Not BestEmailID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.Emails.IndexOf(BestEmailID.Value)

                If i >= 0 Then
                    mobjBestEmail = mobjCase.Emails(i)
                End If
            End If

            Return mobjBestEmail
        End Get
        Set
            mobjBestEmail = Value
            If mobjBestEmail IsNot Nothing AndAlso Not mobjBestEmail.EmailID.IsNull Then
                BestEmailID = mobjBestEmail.EmailID
            Else
                BestEmailID = 0
            End If
        End Set
    End Property


    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.SocialNetwork">BestSocialNetwork</see> object of the Person.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetwork">BestSocialNetwork</see> object of the Person.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an SocialNetwork object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this
    '''     property to Nothing (null).
    ''' </remarks>

        Public Property BestSocialNetwork As SocialNetwork
        Get
            ' Get the index of the associated SocialNetwork object initializing the Person
            ' object reference as needed.
            If mobjBestSocialNetwork Is Nothing AndAlso
               Not BestSocialNetworkID.IsNull AndAlso
               Not BestSocialNetworkID.Value.Equals(0) Then

                Dim i As Integer = mobjCase.SocialNetworks.IndexOf(BestSocialNetworkID.Value)

                If i >= 0 Then
                    mobjBestSocialNetwork = mobjCase.SocialNetworks(i)
                End If
            End If

            Return mobjBestSocialNetwork
        End Get
        Set
            mobjBestSocialNetwork = Value
            If mobjBestSocialNetwork IsNot Nothing AndAlso Not mobjBestSocialNetwork.SocialNetworkID.IsNull Then
                BestSocialNetworkID = mobjBestSocialNetwork.SocialNetworkID
            Else
                BestSocialNetworkID = 0
            End If
        End Set
    End Property

#End Region

#Region "Private Properties"

    Private Property IsNew As Boolean
        Get
            Return mblnIsNew
        End Get
        Set
            mblnIsNew = value
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The PersonBest class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Relationship class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the PersonBest class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the PersonBest is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonBest class.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonBest object belongs to.
    ''' </param>

        Public Sub New(objPerson As Person)

        MyBase.New()

        mobjPerson = objPerson
        mobjCase = objPerson.Case

        If objPerson.MPRID.IsNull Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = New SqlString(objPerson.MPRID.ToString)
        End If

        ConnectionString = Project.ConnectionString
        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            Dim dt As DataTable = SelectOne()

            IsNew = dt.Rows.Count = 0

            ResetModified()
            'If IsNew Then
            '    MyBase.CaseID = mobjPerson.CaseID
            'End If


        Catch ex As Exception

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

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Relationship into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Relationship object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        ResolveBest()

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the Relationship

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
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
    '''     Updates a Relationship object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        ResolveBest()

        If Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the Relationship

        Try
            If IsNew Then
                blnResult = Insert()
                IsNew = False
            Else
                blnResult = MyBase.Update()
            End If
        Catch ex As Exception
            blnResult = False
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            ResetModified()
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    Private Sub ResolveBest()

        If MPRID.ToString.Equals("") Then MPRID = mobjPerson.MPRID
        MyBase.CaseID = mobjPerson.CaseID

        If mobjBestMailingAddress IsNot Nothing Then
            BestMailingAddressID = mobjBestMailingAddress.AddressID
        End If

        If mobjBestPhysicalAddress IsNot Nothing Then
            BestPhysicalAddressID = mobjBestPhysicalAddress.AddressID
        End If

        If mobjBestCheckAddress IsNot Nothing Then
            BestCheckAddressID = mobjBestCheckAddress.AddressID
        End If

        If mobjBestPhone IsNot Nothing Then
            BestPhoneID = mobjBestPhone.PhoneID
        End If

        If mobjBestEmail IsNot Nothing Then
            BestEmailID = mobjBestEmail.EmailID
        End If
    End Sub

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

        ' Delete the Relationship

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
