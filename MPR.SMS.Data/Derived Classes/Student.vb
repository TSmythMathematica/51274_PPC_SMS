'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Student object.
''' </summary>

    Public Class [Student]
    Inherits TblStudent

#Region "Private Fields"

    Private mstrLastError As String
    Private mobjCase As [Case]
    Private mobjPerson As Person
    Private mobjSchool As School
    Private mobjClassroom As Classroom
    Private _DisplayName As String

    'Private mobjErrors As Errors

#End Region

#Region "Events"

    Event OnInsert(objStudent As Student)

    Event OnUpdate(objStudent As Student)

    Event OnDelete(objStudent As Student)

    Event OnBeforeDelete(objStudent As Student, ByRef blnCancel As Boolean)

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

    '' '
    '' <summary>
    ''     ' Gets the <see cref="T:MPR.SMS.Data.Errors">Errors</see> collection for the Case object.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The <see cref="T:MPR.SMS.Data.Errors">Errors</see> collection for the Case object.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets/Sets the Case associated with the Student.
    '' </summary>
    '' <value>
    ''     The Case associated with the Student.
    '' </value>
    '' <remarks>
    ''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    '' </remarks>

    'Public ReadOnly Property Errors() As Errors
    '    Get
    '        If mobjErrors Is Nothing Then
    '            mobjErrors = New Errors(Me)
    '            mobjErrors.PerformErrorChecks(Me)
    '        End If
    '        Return mobjErrors
    '    End Get
    'End Property


    Public Property [Case] As [Case]
        Get
            If mobjCase Is Nothing Then
                mobjCase = New [Case](Me.CaseID.Value, True)
            End If
            Return mobjCase
        End Get
        Set
            mobjCase = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Student object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Student object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a Student object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property to
    '''     Nothing (null).
    '''     The Student object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
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
    '''     Gets the name of the student using SQLHelper so the Case object doesn't
    '''     have to be instantiated.
    ''' </summary>
    ''' <value>
    '''     The last and first name associated with the student.
    ''' </value>

        Public ReadOnly Property DisplayName As String
        Get
            If _DisplayName = "" Then
                Dim blnCloseConnection As Boolean = False

                If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                    blnCloseConnection = True
                    Project.ConnectionProvider.OpenConnection()
                End If

                Dim sqlstr As String = "SELECT LastName + ', ' + FirstName from tblPerson WHERE MPRID = '" &
                                       Me.MPRID.ToString & "'"  'IsPrimarySampleMember=1 and CaseID=" & Me.CaseID.Value
                Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionProvider.Connection,
                                                                  CommandType.Text, sqlstr)
                If dr.Read Then
                    _DisplayName = CStr(dr(0))
                Else
                    _DisplayName = ""
                End If

                If blnCloseConnection Then
                    blnCloseConnection = False
                    Project.ConnectionProvider.CloseConnection(False)
                End If
                dr.Close()

            End If
            Return _DisplayName
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the School that the Student belongs to.
    ''' </summary>
    ''' <value>
    '''     The School that the Student belongs to.
    ''' </value>

        Public Property School As School
        Get
            If mobjSchool Is Nothing Then
                If Not Classroom Is Nothing AndAlso Not Classroom.SchoolID.IsNull Then
                    mobjSchool = New School(Classroom.SchoolID.Value)
                End If
            End If
            Return mobjSchool
        End Get
        Set
            mobjSchool = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Classroom associated with the Student.
    ''' </summary>
    ''' <value>
    '''     The Classroom associated with the Student.
    ''' </value>

        Public Property Classroom As Classroom
        Get
            If mobjClassroom Is Nothing AndAlso Not Me.ClassroomID.IsNull Then
                mobjClassroom = New [Classroom](Me.ClassroomID.Value)
            End If
            Return mobjClassroom
        End Get
        Set
            mobjClassroom = Value
        End Set
    End Property

    Public ReadOnly Property MobilityTypeID As Integer
        Get
            Dim objMobilityCode As New MobilityCode(MobilityCode.ToString)
            If Not objMobilityCode.MobilityTypeID.IsNull Then
                Return CType(objMobilityCode.MobilityTypeID, Integer)
            Else
                Return 0
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The student constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the Student class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        'AF 12/15/04
        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Student class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Student is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    '' '
    '' <summary>
    ''     ' Initializes a new instance of the Student class.
    ''     '
    '' </summary>
    '' '
    '' <param name="intCaseID">
    ''     ' The Case's CaseID for which the object will be initialized. (not used)
    ''     '
    '' </param>
    '' '
    '' <param name="MPRID">
    ''     ' The Person's MPRID for which the object will be initialized.
    ''     '
    '' </param>
    '' <summary>
    ''     Initializes a new instance of the Student class.
    '' </summary>
    '' <param name="objPerson">
    ''     The Person object for which the Student object will be initialized.
    '' </param>

    'Public Sub New(ByVal intCaseID As Integer, ByVal MPRID As String)

    '    MyBase.New()

    '    MyBase.MPRID = New SqlString(MPRID)

    '    ConnectionString = Project.ConnectionString

    '    ConnectionProvider = Project.ConnectionProvider

    '    Dim blnCloseConnection As Boolean = False

    '    Try

    '        ' Open the database if needed

    '        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
    '            blnCloseConnection = True
    '            ConnectionProvider.OpenConnection()
    '        End If
    '        SelectOneWMPRIDLogic()

    '        ResetModified()
    '    Catch ex As Exception

    '        ' Rethrow the exception

    '        Throw ex

    '    Finally

    '        ' Insure the database is always closed if it was opened here

    '        If blnCloseConnection Then
    '            blnCloseConnection = False
    '            ConnectionProvider.CloseConnection(False)
    '        End If

    '        ConnectionProvider = Nothing

    '    End Try

    'End Sub

    Public Sub New(objPerson As Person)

        MyBase.New()

        mobjPerson = objPerson
        mobjCase = objPerson.Case

        MyBase.MPRID = mobjPerson.MPRID
        MyBase.CaseID = mobjCase.CaseID

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If
            SelectOneWMPRIDLogic()

            ResetModified()
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

    ''' <summary>
    '''     Initializes a new instance of the Student class.
    ''' </summary>
    ''' <param name="StudentID">
    '''     The StudentID for which the object will be initialized.
    ''' </param>

        Public Sub New(StudentID As Integer)

        MyBase.New()

        MyBase.StudentID = New SqlInt32(StudentID)

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            SelectOne()

            'AF 12/15/04
            ResetModified()
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
    '''     Inserts the Case object and its dependent objects into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>
    ''' <remarks>
    '''     The Person property must be set before Insert can be called, thus setting MPRID and CaseID
    '''     which are required fields.  Otherwise, mobjPerson will be Null and an exception will be thrown.
    ''' </remarks>

        Public Overrides Function Insert() As Boolean

        MyBase.CaseID = Person.CaseID
        MyBase.MPRID = Person.MPRID

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Insert()

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

        MyBase.CaseID = Person.CaseID
        MyBase.MPRID = Person.MPRID

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            ' Update the Student
            If MyBase.StudentID.IsNull Then
                blnResult = MyBase.Insert()
            ElseIf MyBase.IsModified Then
                blnResult = MyBase.Update()
            End If

        Catch ex As Exception

            blnResult = False

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
            RaiseEvent OnUpdate(Me)
            ' Reset _DisplayName to force it to look up from the db
            _DisplayName = ""

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Student from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
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

#End Region
End Class
