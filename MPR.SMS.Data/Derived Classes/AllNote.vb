'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Note object in the
'''     database.
''' </summary>

    Public Class AllNote
    Inherits VwAllNotes

#Region "Events"

    Event OnUpdate(objNote As AllNote)
    Event OnDelete(objNote As AllNote)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Note object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Note object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Note object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Note object belongs to.
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
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Note object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Note object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Note object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    '''     The Note object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see> object
    '''     whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Person As Person
        Get
            If mobjPerson Is Nothing Then
                ' Get the index of the associated Person object initializing the Person
                ' object reference as needed.
                If Not MPRID.IsNull Then

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
    '''     Gets the CaseID of the Note object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Note object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    '' '
    '' <summary>
    ''     ' Gets the NoteID of the Note object.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The NoteID of the Note object.
    ''     '
    '' </value>
    '' <overloads>
    ''     The Note class constructor has several overloads.
    '' </overloads>
    '' <summary>
    ''     Creates a new instance of the Note class.
    '' </summary>
    '' <param name="objCase">
    ''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Note belongs to.
    '' </param>
    '' <remarks>
    ''     This form of the Note constructor initializes the Note object with default values
    ''     and adds it to the <see cref="T:MPR.SMS.Data.Case">Case</see> object's Notes collection.
    '' </remarks>

    'Public Shadows ReadOnly Property NoteID() As SqlInt32
    '    Get
    '        Return MyBase.NoteID
    '    End Get
    'End Property

#End Region

#Region "Constructors"


    Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        mobjCase.AllNotes.Add(Me)                 'BT: 11/18/2014. Changed for vwAllNotes

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Note class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Note belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow from the Note table that will be used to initialize the new Note object.
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
    '''     Creates a new instance of the Note class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Note class pertaining
    '''     to a case, without adding it to the case's Notes collection.
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
    '''     Creates a new instance of the Note class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Note object.
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

    '''' <summary>
    '''' Inserts an Address object into the database.
    '''' </summary>
    '''' <returns>
    '''' True if successful, otherwise False.
    '''' </returns>

    'Public Overrides Function Insert() As Boolean

    '    Dim blnResult As Boolean = False

    '    MyBase.CaseID = mobjCase.CaseID

    '    If Not IsModified Then
    '        Return True
    '    End If

    '    If mobjPerson Is Nothing Then
    '        MyBase.MPRID = New SqlString("")
    '    Else
    '        MyBase.MPRID = mobjPerson.MPRID
    '    End If

    '    ' If the Project's Connection Provider is open, use it

    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Try
    '        blnResult = MyBase.Insert()
    '    Catch ex As Exception
    '        blnResult = False
    '        mstrLastError = ex.Message
    '        Throw ex
    '    Finally
    '        ConnectionProvider = Nothing
    '    End Try

    '    If blnResult Then
    '        RaiseEvent OnInsert(Me)
    '    End If

    '    Return blnResult

    'End Function

    '''' <summary>
    '''' Updates an Address object within the database. 
    '''' </summary>
    '''' <returns>
    '''' True if successful, otherwise False.
    '''' </returns>

    'Public Overrides Function Update() As Boolean

    '    If NoteID.IsNull Then
    '        Return Insert()
    '    ElseIf NoteID.Value <= 0 Then
    '        Return Insert()
    '    ElseIf Not IsModified Then
    '        Return True
    '    End If

    '    Dim blnResult As Boolean = False

    '    'MyBase.CaseID = mobjCase.CaseID

    '    If mobjPerson Is Nothing Then
    '        MyBase.MPRID = New SqlString("")
    '    Else
    '        MyBase.MPRID = mobjPerson.MPRID
    '    End If

    '    ' If the Project's Connection Provider is open, use it

    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Try
    '        blnResult = MyBase.Update()
    '    Catch ex As Exception
    '        blnResult = False
    '        mstrLastError = ex.Message
    '        Throw ex
    '    Finally
    '        ConnectionProvider = Nothing
    '    End Try

    '    If blnResult Then
    '        RaiseEvent OnUpdate(Me)
    '    End If

    '    Return blnResult

    'End Function

    '''' <summary>
    '''' Deletes an Address object from the database.
    '''' </summary>
    '''' <returns>
    '''' True if successful, otherwise False.
    '''' </returns>

    'Public Overrides Function Delete() As Boolean

    '    Dim blnResult As Boolean = False

    '    ' If the Project's Connection Provider is open, use it

    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Try
    '        blnResult = MyBase.Delete()
    '    Catch ex As Exception
    '        blnResult = False
    '        mstrLastError = ex.Message
    '        Throw ex
    '    Finally
    '        ConnectionProvider = Nothing
    '    End Try

    '    If blnResult Then
    '        RaiseEvent OnDelete(Me)
    '    End If

    '    Return blnResult

    'End Function

#End Region
End Class
