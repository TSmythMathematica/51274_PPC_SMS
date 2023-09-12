'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses


''' <summary>
'''     Provides methods for accessing, creating and synchronizing an Address object in the
'''     database.
''' </summary>

    Public Class Address
    Inherits TblAddress

#Region "Events"

    Event OnInsert(objAddress As Address)
    Event OnUpdate(objAddress As Address)
    Event OnDelete(objAddress As Address)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjAddressHistory As AddressHistory
    ' Private mobjAddressNotes As AddressNotes

    Private mobjAddressType As AddressType
    Private mobjSourceType As SourceType
    Private mobjSourceQuality As SourceQuality
    Private mobjReturnedMailReason As ReturnedMailReason

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address object belongs to.
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

    'Public Property AddressNotes() As AddressNotes
    '    Get
    '        Return mobjAddressNotes
    '    End Get
    '    Set(ByVal value As AddressNotes)
    '        mobjAddressNotes = value
    '    End Set
    'End Property

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
                If Not MPRID.IsNull AndAlso Not MPRID.ToString.Equals("") Then

                    ' Get the index of the associated Person object initializing the Person
                    ' object reference as needed.
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
            If Not mobjPerson Is Nothing Then
                MPRID = mobjPerson.MPRID
            Else
                MPRID = ""
            End If
        End Set
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
    '''     Gets the AddressID of the Address object.
    ''' </summary>
    ''' <value>
    '''     The AddressID of the Address object.
    ''' </value>

        Public Shadows ReadOnly Property AddressID As SqlInt32
        Get
            Return MyBase.AddressID
        End Get
    End Property

    ''' <summary>
    '''     Gets the <B>most recent</B> <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> record for the Address
    '''     object.
    ''' </summary>
    ''' <value>
    '''     The <B>most recent</B> <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> record for the Address
    '''     object.
    '''     Will return Nothing if the record has not been saved yet.
    ''' </value>

        Public ReadOnly Property AddressHistory As AddressHistory
        Get

            If Not AddressID.IsNull Then
                Dim intHistID As Integer = 0
                Dim objHist As New TblAddressHistory

                objHist.ConnectionString = Project.ConnectionString
                objHist.AddressID = Me.AddressID

                Dim dt As DataTable = objHist.SelectAllWAddressIDLogic()
                For Each dr As DataRow In dt.Rows
                    If CType(dr("AddressHistoryID"), Integer) > intHistID Then
                        mobjAddressHistory = New AddressHistory(mobjCase, dr)
                    End If
                Next
            End If
            Return mobjAddressHistory
        End Get
    End Property

    ''' <summary>
    '''     Gets the AddressType of the Address object.
    ''' </summary>
    ''' <value>
    '''     The AddressType of the Address object.
    ''' </value>
    Public Property AddressType As AddressType
        Get
            Dim i As Integer
            If Not AddressTypeID.IsNull Then
                i = Project.AddressTypes.IndexOf(AddressTypeID.Value)
            Else
                i = Project.AddressTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjAddressType = Project.AddressTypes(i)
            End If
            Return mobjAddressType
        End Get
        Set
            mobjAddressType = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the SourceType of the Email object.
    ''' </summary>
    ''' <value>
    '''     The SourceType of the Email object.
    ''' </value>
    Public Property SourceType As SourceType
        Get
            Dim i As Integer
            If Not SourceTypeID.IsNull Then
                i = Project.SourceTypes.IndexOf(SourceTypeID.Value)
            Else
                i = Project.SourceTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjSourceType = Project.SourceTypes(i)
            End If
            Return mobjSourceType
        End Get
        Set
            mobjSourceType = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the SourceQuality of the Email object.
    ''' </summary>
    ''' <value>
    '''     The SourceQuality of the Email object.
    ''' </value>
    Public Property SourceQuality As SourceQuality
        Get
            Dim i As Integer
            If Not SourceQualityID.IsNull Then
                i = Project.SourceQualities.IndexOf(SourceQualityID.Value)
            Else
                i = Project.SourceQualities.IndexOf(0)
            End If
            If i >= 0 Then
                mobjSourceQuality = Project.SourceQualities(i)
            End If
            Return mobjSourceQuality
        End Get
        Set
            mobjSourceQuality = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the ReturnedMailReason of the Address object.
    ''' </summary>
    ''' <value>
    '''     The ReturnedMailReason of the Address object.
    ''' </value>
    Public Property ReturnedMailReason As ReturnedMailReason
        Get
            Dim i As Integer
            If Not ReturnedMailReasonID.IsNull Then
                i = Project.ReturnedMailReasons.IndexOf(ReturnedMailReasonID.Value)
            Else
                i = Project.ReturnedMailReasons.IndexOf(0)
            End If
            If i >= 0 Then
                mobjReturnedMailReason = Project.ReturnedMailReasons(i)
            End If
            Return mobjReturnedMailReason
        End Get
        Set
            mobjReturnedMailReason = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the full street address (Address lines 1-4) of the Address object.
    ''' </summary>
    ''' <value>
    '''     The full street address of the Address object.
    ''' </value>
    Public ReadOnly Property FullStreetAddress As String
        Get
            Dim strAddr As String = Address1.ToString
            If Not Address2.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address2.ToString
            End If
            If Not Address3.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address3.ToString
            End If
            If Not Address4.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address4.ToString
            End If
            Return strAddr
        End Get
    End Property

    ''' <summary>
    '''     Gets the full address (Address, city, state, zip) of the Address object.
    ''' </summary>
    ''' <value>
    '''     The full address of the Address object.
    ''' </value>
    Public ReadOnly Property FullAddress As String
        Get
            Dim strAddr As String = Address1.ToString
            If Not Address2.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address2.ToString
            End If
            If Not Address3.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address3.ToString
            End If
            If Not Address4.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address4.ToString
            End If
            If Not City.ToString.Length.Equals(0) Or
               Not State.ToString.Length.Equals(0) Or
               Not PostalCode.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & City.ToString
                strAddr = strAddr & ", " & State.ToString
                strAddr = strAddr & "  " & GetSafeZip(PostalCode.ToString)
            End If
            Return strAddr
        End Get
    End Property
    'returns whether this current Address object is "valid", based on the 
    'criteria noted within
    Public ReadOnly Property IsValid As Boolean
        Get
            'Address must have Address, City, State or Zip filled out, plus
            'the Person must be valid or the address is shared.
            If Me Is Nothing Then
                Return False
            Else
                Return ((Not Address1.ToString.Length.Equals(0) Or
                         Not City.ToString.Length.Equals(0) Or
                         Not State.ToString.Length.Equals(0) Or
                         Not PostalCode.ToString.Length.Equals(0)) And
                        (Person Is Nothing OrElse Person.IsValid))
            End If
        End Get
    End Property

    '4/7/2015, added by Angela, for showing single field note in SMS (AF - copied from NBS 10/09/15)
    Public ReadOnly Property FieldNote As String
        Get
            Dim notelist As List(Of Note) = [Case].Notes.GetAddressNotes(AddressID)
            Dim objNote As Note = notelist.Find(Function(n) If(n.IsFieldNote = SqlBoolean.True, True, False))
            If objNote IsNot Nothing Then
                Return objNote.Notes.ToString
            Else
                Return ""
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Address class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Address class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the Address constructor initializes the Address object with default
    '''     and adds it to the <see cref="T:MPR.SMS.Data.Case">Case</see> object's Addresses collection.
    ''' </remarks>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        mobjCase.Addresses.Add(Me)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        'IsCheckAddress = False
        'IsCurrentMailingAddress = False

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Address class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Address belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow from the Address table that will be used to initialize the new Address object.
    '''     object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Address class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new address class pertaining
    '''     to a case, without adding it to the case's Addresses collection.
    ''' </remarks>

        Public Sub New(intCaseID As Integer)

        MyBase.New()

        mobjCase = New [Case](intCaseID, False)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Address class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Address object.
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

    ''' <summary>
    '''     Creates a new instance of the Address class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts an Address object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        If mobjPerson Is Nothing Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = mobjPerson.MPRID
        End If

        If Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates an Address object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If AddressID.IsNull Then
            Return Insert()
        ElseIf AddressID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = False

        'MyBase.CaseID = mobjCase.CaseID

        '5/4/2017, fixed by Angela
        'mobjPerson is an internal valuable, it is NOT initialized until Person property is referenced.
        'should use Person instead of mobjPerson!

        'If mobjPerson Is Nothing Then
        '    MyBase.MPRID = New SqlString("")
        'Else
        '    MyBase.MPRID = mobjPerson.MPRID
        'End If

        If Person Is Nothing Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = Person.MPRID
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes an Address object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

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
