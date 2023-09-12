'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Phone object in the
'''     database.
''' </summary>

    Public Class Phone
    Inherits TblPhone

#Region "Events"

    Event OnInsert(objPhone As Phone)
    Event OnUpdate(objPhone As Phone)
    Event OnDelete(objPhone As Phone)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjPhoneHistory As PhoneHistory

    Private mobjPhoneType As PhoneType
    Private mobjPhoneTime As PhoneTime
    Private mobjSourceType As SourceType
    Private mobjSourceQuality As SourceQuality

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Phone object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Phone object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Phone object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Phone object belongs to.
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
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Phone object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Phone object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Phone object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    '''     The Phone object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see> object
    '''     whenever the
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
            If Not mobjPerson Is Nothing Then
                MPRID = mobjPerson.MPRID
            Else
                MPRID = ""
            End If
        End Set
    End Property

    '' '
    '' <summary>
    ''     ' Gets or sets whether the Phone object represents the Current Dialing Phone.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' True if the Phone object is the Current Dialing Phone, otherwise False
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' Gets or sets whether the Phone object represents a fax number.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' True if the Phone object is a fax number, otherwise False
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the CaseID of the Phone object.
    '' </summary>
    '' <value>
    ''     The CaseID of the Phone object.
    '' </value>

    'Public Shadows Property IsDialingPhone() As Boolean
    '    Get
    '        Return MyBase.IsDialingPhone.Value
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Value Then
    '            For Each objPhone As Phone In Me.Person.Phones
    '                objPhone.IsDialingPhone = False
    '            Next
    '        End If
    '        MyBase.IsDialingPhone = New SqlBoolean(Value)
    '    End Set
    'End Property

    'Public Shadows Property IsFax() As Boolean
    '    Get
    '        Return MyBase.PhoneTypeID.Value = 5
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        MyBase.PhoneTypeID = New SqlInt32(5)
    '    End Set
    'End Property


    Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets the PhoneID of the Phone object.
    ''' </summary>
    ''' <value>
    '''     The PhoneID of the Phone object.
    ''' </value>

        Public Shadows ReadOnly Property PhoneID As SqlInt32
        Get
            Return MyBase.PhoneID
        End Get
    End Property

    ''' <summary>
    '''     Gets the <B>most recent</B> <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> record for the Phone object.
    ''' </summary>
    ''' <value>
    '''     The <B>most recent</B> <see cref="T:MPR.SMS.Data.PhoneHistory">PhoneHistory</see> record for the Phone object.
    '''     Will return Nothing if the record has not been saved yet.
    ''' </value>

        Public ReadOnly Property PhoneHistory As PhoneHistory
        Get

            If Not PhoneID.IsNull Then
                Dim intHistID As Integer = 0
                Dim objHist As New TblPhoneHistory

                objHist.ConnectionString = Project.ConnectionString
                objHist.PhoneID = Me.PhoneID

                Dim dt As DataTable = objHist.SelectAllWPhoneIDLogic()
                For Each dr As DataRow In dt.Rows
                    If CType(dr("PhoneHistoryID"), Integer) > intHistID Then
                        mobjPhoneHistory = New PhoneHistory(mobjCase, dr)
                    End If
                Next
            End If

            Return mobjPhoneHistory
        End Get
    End Property

    ''' <summary>
    '''     Gets the PhoneType of the Phone object.
    ''' </summary>
    ''' <value>
    '''     The PhoneType of the Phone object.
    ''' </value>

        Public Property PhoneType As PhoneType
        Get
            Dim i As Integer
            If Not PhoneTypeID.IsNull Then
                i = Project.PhoneTypes.IndexOf(PhoneTypeID.Value)
            Else
                i = Project.PhoneTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjPhoneType = Project.PhoneTypes(i)
            End If
            Return mobjPhoneType
        End Get
        Set
            mobjPhoneType = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the PhoneTime of the Phone object.
    ''' </summary>
    ''' <value>
    '''     The PhoneTime of the Phone object.
    ''' </value>

        Public Property PhoneTime As PhoneTime
        Get
            Dim i As Integer
            If Not PhoneTimeID.IsNull Then
                i = Project.PhoneTimes.IndexOf(PhoneTimeID.Value)
            Else
                i = Project.PhoneTimes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjPhoneTime = Project.PhoneTimes(i)
            End If
            Return mobjPhoneTime
        End Get
        Set
            mobjPhoneTime = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the SourceType of the Phone object.
    ''' </summary>
    ''' <value>
    '''     The SourceType of the Phone object.
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
    '''     Gets the SourceQuality of the Phone object.
    ''' </summary>
    ''' <value>
    '''     The SourceQuality of the Phone object.
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

    'returns whether this current Phone object is "valid", based on the 
    'criteria noted within
    Public ReadOnly Property IsValid As Boolean
        Get
            'Phone must have the Phone # filled out, plus
            'the Person must be valid or the phone is shared.
            If Me Is Nothing Then
                Return False
            Else
                Return (Not PhoneNum.ToString.Length.Equals(0) And
                        (Person Is Nothing OrElse Person.IsValid))
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Phone class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Phone class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Phone belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the Phone constructor initializes the Phone object with default values
    '''     and adds it to the <see cref="T:MPR.SMS.Data.Case">Case</see> object's Phones collection.
    ''' </remarks>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        mobjCase.Phones.Add(Me)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        'Me.IsDialingPhone = False

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Phone class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Phone belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow from the Phone table that will be used to initialize the new Phone object.
    '''     object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Phone class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Phone class pertaining
    '''     to a case, without adding it to the case's Phones collection.
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
    '''     Creates a new instance of the Phone class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Phone object.
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

        If Not IsModified Then
            Return True
        End If

        If mobjPerson Is Nothing Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = mobjPerson.MPRID
        End If

        If GetSafeValue(TCPAPhoneType) = String.Empty Then
            'TCPAPhoneType = TCPAPhoneLookup.GetPhoneType(GetSafeValue(PhoneNum))    
            LookupTCPAType()
        End If
        TCPALastModifiedOn = New SqlDateTime(Now())

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

    Public Sub LookupTCPAType()

        'For sending to CATI we may need to do the lookup before the phone is inserted.
        If GetSafeValue(TCPAPhoneType) = String.Empty _
           OrElse TCPALastModifiedOn.IsNull _
           OrElse DateDiff(DateInterval.Day, GetSafeValue(TCPALastModifiedOn), Now()) > 1 Then
            TCPAPhoneType = TCPAPhoneLookup.GetPhoneType(GetSafeValue(PhoneNum))
            TCPALastModifiedOn = New SqlDateTime(Now())
        End If
    End Sub

    ''' <summary>
    '''     Updates an Address object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If PhoneID.IsNull Then
            Return Insert()
        ElseIf PhoneID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = False

        'MyBase.CaseID = mobjCase.CaseID

        If mobjPerson Is Nothing Then
            MyBase.MPRID = New SqlString("")
        Else
            MyBase.MPRID = mobjPerson.MPRID
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
