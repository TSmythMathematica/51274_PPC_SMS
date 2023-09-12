'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Teacher object.
''' </summary>

    Public Class Teacher
    Inherits TblTeacher

#Region "Private Fields"

    Private mstrLastError As String

    'Private mobjErrors As Errors

    Private mobjSchool As School
    Private mobjClassrooms As Classrooms
    Private mobjClassroomTeachers As ClassroomTeachers
    Private mobjClassroom As Classroom

    Private mobjTeacherCase As [Case]

    Private _DisplayName As String

#End Region

#Region "Private Methods"

#End Region

#Region "Events"

    Event OnInsert(objTeacher As Teacher)

    Event OnUpdate(objTeacher As Teacher)

    Event OnDelete(objTeacher As Teacher)

    Event OnBeforeDelete(objTeacher As Teacher, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Teacher class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Teacher class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Teacher class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Teacher is to be initialized with.
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
    '''     Initializes a new instance of the Teacher class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The MPR Case for which the object will be initialized.
    ''' </param>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjTeacherCase = objCase

        objCase.Teacher = Me

        MyBase.CaseID = objCase.CaseID

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If
            SelectOneWCaseIDLogic()

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
    '''     Initializes a new instance of the Teacher class.
    ''' </summary>
    ''' <param name="TeacherID">
    '''     The TeacherID for which the object will be initialized.
    ''' </param>

        Public Sub New(TeacherID As Integer)

        MyBase.New()

        MyBase.TeacherID = New SqlInt32(TeacherID)

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

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Teacher belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Teacher belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Teacher">Teacher</see>'s Display Name (LastName, FirstName)
    '''     using SQLHelper so the Case object doesn't have to be instantiated.
    '''     <seealso cref="T:MPR.SMS.Data.Teacher" />
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Teacher">Teacher</see>'s Display Name (LastName, FirstName).
    ''' </value>

        Public ReadOnly Property DisplayName As String
        Get
            If Not Me.CaseID.IsNull Then
                If _DisplayName = "" Then
                    Dim blnCloseConnection As Boolean = False

                    If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                        blnCloseConnection = True
                        Project.ConnectionProvider.OpenConnection()
                    End If

                    Dim sqlstr As String = "SELECT LastName + ', ' + FirstName FROM tblPerson WHERE CaseID=" &
                                           Me.CaseID.Value  ' AND IsSampleMember=1
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
            Else
                _DisplayName = ""
            End If
            Return _DisplayName
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the School that the Teacher belongs to.
    ''' </summary>
    ''' <value>
    '''     The School that the Teacher belongs to.
    ''' </value>

        Public Property School As School
        Get
            If mobjSchool Is Nothing AndAlso Not SchoolID.IsNull Then
                mobjSchool = New School(SchoolID.Value)
            End If
            Return mobjSchool
        End Get
        Set
            mobjSchool = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets the first <see cref="T:MPR.SMS.Data.Classroom">Classroom</see>
    '''     that the Teacher belongs to in the specified Grade.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> that the Teacher belongs to.
    ''' </value>

        Public ReadOnly Property Classroom(strGrade As String) As Classroom

        Get
            For Each objClassroom As Classroom In Classrooms
                If objClassroom.Grade = strGrade Then
                    Return objClassroom
                End If
            Next
            Return Nothing
        End Get
    End Property

    ''' <summary>
    '''     This gets/sets the first Classroom for this Teacher
    ''' </summary>
    ''' <value>
    '''     The Classroom object for the Teacher.
    ''' </value>
    ''' <remarks>
    '''     This is a wrapper property for projects that only use one Classroom
    '''     per Teacher. It hides some of the ClassroomTeacher collection logic.
    '''     Be careful about setting a Classroom using this property: the Mobility
    '''     Code/Date won't get updated.  SL 4/26/06
    ''' </remarks>
    Public Property Classroom As Classroom
        Get
            If mobjClassroom Is Nothing Then
                If Classrooms.Count > 0 Then
                    mobjClassroom = Classrooms(0)
                End If
            End If
            Return mobjClassroom
        End Get
        Set
            mobjClassroom = value

            'if updating the existing Classroom...
            If ClassroomTeachers.Count > 0 Then
                ClassroomTeachers(0).Classroom = mobjClassroom
            Else '...otherwise add a new Classroom
                Dim objCR As New ClassroomTeacher
                objCR.Classroom = mobjClassroom
                objCR.Teacher = Me
                ClassroomTeachers.Add(objCR)
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the ClassroomTeachers collection for the Classroom.
    '''     ClassroomTeachers binds the Classrooms to Teachers in many-to-many relationship.
    ''' </summary>
    ''' <value>
    '''     The ClassroomTeachers collection for the Classroom.
    ''' </value>

        Public Property ClassroomTeachers As ClassroomTeachers
        Get
            If mobjClassroomTeachers Is Nothing Then
                mobjClassroomTeachers = New ClassroomTeachers(Me)
            End If
            Return mobjClassroomTeachers
        End Get
        Set
            mobjClassroomTeachers = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Classrooms collection for the Teacher.
    ''' </summary>
    ''' <value>
    '''     The Classrooms collection for the Teacher.
    ''' </value>

        Public Property Classrooms As Classrooms
        Get
            If mobjClassrooms Is Nothing Then
                mobjClassrooms = New Classrooms(Me)
            End If

            Dim objClassTeachers As ClassroomTeachers = ClassroomTeachers
            If objClassTeachers.IsModified Then
                mobjClassrooms.Clear()
                For Each objClassroomTeacher As ClassroomTeacher In objClassTeachers
                    If objClassroomTeacher.Classroom IsNot Nothing Then
                        mobjClassrooms.Add(objClassroomTeacher.Classroom)
                    End If
                Next
            End If
            Return mobjClassrooms
        End Get
        Set
            mobjClassrooms = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the Teacher.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the Teacher.
    ''' </value>
    ''' <remarks>
    '''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    ''' </remarks>

        Public Property [Case] As [Case]
        Get
            If mobjTeacherCase Is Nothing Then
                mobjTeacherCase = New [Case](Me.CaseID.Value, True)
                mobjTeacherCase.Teacher = Me
            End If
            Return mobjTeacherCase
        End Get
        Set
            mobjTeacherCase = Value
        End Set
    End Property

    Public Overloads ReadOnly Property IsModified As Boolean
        Get
            If MyBase.IsModified Then
                Return True
            ElseIf ClassroomTeachers.IsModified Then
                Return True
            End If
            Return False
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Teacher into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Teacher object has been successfully inserted, otherwise false.
    ''' </returns>

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

            ' insert the Teacher
            blnResult = MyBase.Insert()
            If blnResult Then
                blnResult = ClassroomTeachers.Insert()
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
    '''     Updates a Teacher object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Update()
            If blnResult And ClassroomTeachers.IsModified Then
                blnResult = ClassroomTeachers.Update()
            Else
                blnResult = True
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
    '''     Deletes a Teacher from the database
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

    Friend Overloads Sub ResetModified()

        MyBase.ResetModified()
        ClassroomTeachers.ResetModified()
    End Sub

    Friend Overloads Sub RestoreModified()

        MyBase.RestoreModified()
        ClassroomTeachers.RestoreModified()
    End Sub

#End Region
End Class
