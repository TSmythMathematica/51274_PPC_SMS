'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Email object in the
'''     database.
''' </summary>

    Public Class Email
    Inherits TblEmail

#Region "Events"

    Event OnInsert(objEmail As Email)
    Event OnUpdate(objEmail As Email)
    Event OnDelete(objEmail As Email)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjEmailHistory As EmailHistory

    Private mobjEmailType As EmailType
    Private mobjSourceType As SourceType
    Private mobjSourceQuality As SourceQuality

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Email object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Email object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Email object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Email object belongs to.
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
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Email object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Email object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Email object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    '''     The Email object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see> object
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
    ''     ' Gets or sets whether the Email object represents the Current Primary Email.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' True if the Email object is the Current Primary Email, otherwise False
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the CaseID of the Email object.
    '' </summary>
    '' <value>
    ''     The CaseID of the Email object.
    '' </value>

    'Public Shadows Property IsPrimaryEmail() As Boolean
    '    Get
    '        Return MyBase.IsPrimaryEmail.Value
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        If Value Then
    '            Dim objEmail As Email
    '            For Each objEmail In Me.Person.Emails
    '                objEmail.IsPrimaryEmail = False
    '            Next
    '        End If
    '        MyBase.IsPrimaryEmail = New SqlBoolean(Value)
    '    End Set
    'End Property


    Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets the EmailID of the Email object.
    ''' </summary>
    ''' <value>
    '''     The EmailID of the Email object.
    ''' </value>

        Public Shadows ReadOnly Property EmailID As SqlInt32
        Get
            Return MyBase.EmailID
        End Get
    End Property

    ''' <summary>
    '''     Gets the <B>most recent</B> <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> record for the Email object.
    ''' </summary>
    ''' <value>
    '''     The <B>most recent</B> <see cref="T:MPR.SMS.Data.EmailHistory">EmailHistory</see> record for the Email object.
    '''     Will return Nothing if the record has not been saved yet.
    ''' </value>

        Public ReadOnly Property EmailHistory As EmailHistory
        Get

            If Not EmailID.IsNull Then
                Dim intHistID As Integer = 0
                Dim objHist As New TblEmailHistory

                objHist.ConnectionString = Project.ConnectionString
                objHist.EmailID = Me.EmailID

                Dim dt As DataTable = objHist.SelectAllWEmailIDLogic()
                For Each dr As DataRow In dt.Rows
                    If CType(dr("EmailHistoryID"), Integer) > intHistID Then
                        mobjEmailHistory = New EmailHistory(mobjCase, dr)
                    End If
                Next
            End If

            Return mobjEmailHistory
        End Get
    End Property

    ''' <summary>
    '''     Gets the EmailType of the Email object.
    ''' </summary>
    ''' <value>
    '''     The EmailType of the Email object.
    ''' </value>

        Public Property EmailType As EmailType
        Get
            Dim i As Integer
            If Not EmailTypeID.IsNull Then
                i = Project.EmailTypes.IndexOf(EmailTypeID.Value)
            Else
                i = Project.EmailTypes.IndexOf(0)
            End If
            If i >= 0 Then
                mobjEmailType = Project.EmailTypes(i)
            End If
            Return mobjEmailType
        End Get
        Set
            mobjEmailType = value
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
    'returns whether this current Email object is "valid", based on the 
    'criteria noted within
    Public ReadOnly Property IsValid As Boolean
        Get
            'Email must have the email address filled out, plus
            'the Person must be valid or the email is shared.
            If Me Is Nothing Then
                Return False
            Else
                Return (Not EmailAddress.ToString.Length.Equals(0) And
                        (Person Is Nothing OrElse Person.IsValid))
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Email class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Email class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Email belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the Email constructor initializes the Email object with default values
    '''     and adds it to the <see cref="T:MPR.SMS.Data.Case">Case</see> object's Emails collection.
    ''' </remarks>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        mobjCase.Emails.Add(Me)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        'Me.IsPrimaryEmail = False

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Email class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Email belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow from the Email table that will be used to initialize the new Email object.
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
    '''     Creates a new instance of the Email class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Email class pertaining
    '''     to a case, without adding it to the case's Emails collection.
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
    '''     Creates a new instance of the Email class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Email object.
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

        If EmailID.IsNull Then
            Return Insert()
        ElseIf EmailID.Value <= 0 Then
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
