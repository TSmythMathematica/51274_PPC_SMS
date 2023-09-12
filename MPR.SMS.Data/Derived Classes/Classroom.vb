'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Classroom object.
''' </summary>

    Public Class Classroom
    Inherits TblClassroom

#Region "Private Fields"

    Private mobjTeachers As Teachers
    Private mobjClassroomTeachers As ClassroomTeachers
    Private mobjSchool As School
    Private mobjClassroomCase As [Case]
    Private mobjStudents As Students

    Private mobjTeacher As Teacher
    Private mstrLastError As String

#End Region

#Region "Events"

    Event OnInsert(objClassroom As Classroom)

    Event OnUpdate(objClassroom As Classroom)

    Event OnDelete(objClassroom As Classroom)

    Event OnBeforeDelete(objClassroom As Classroom, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Classroom class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the Classroom class.
    '''     default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub


    ''' <summary>
    '''     Initializes a new instance of the Classroom class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow containing the data that the Classroom object will be initialized with.
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
    '''     Initializes a new instance of the Classroom class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The MPR Case for which the object will be initialized.
    ''' </param>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjClassroomCase = objCase

        objCase.Classroom = Me

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
    '''     Initializes a new instance of the Classroom class.
    ''' </summary>
    ''' <param name="ClassroomID">
    '''     The ClassroomID for which the object will be initialized.
    ''' </param>

        Public Sub New(ClassroomID As Integer)

        MyBase.New()

        MyBase.ClassroomID = New SqlInt32(ClassroomID)

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

#Region "Private Functions"

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets/Sets the School that the Classroom belongs to.
    ''' </summary>
    ''' <value>
    '''     The School that the Classroom belongs to.
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the ClassroomTeachers collection for the Classroom.
    '''     ClassroomTeachers binds the Classrooms to Teachers as a many-to-many relationship.
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
    '''     Gets the Teachers collection for the Classroom. Read-only. To modify
    '''     the collection, use the ClassroomTeachers collection.
    ''' </summary>
    ''' <value>
    '''     The Teachers collection for the Classroom.
    ''' </value>

        Public ReadOnly Property Teachers As Teachers
        Get
            'if not defined yet, get it from the database
            If mobjTeachers Is Nothing Then
                mobjTeachers = New Teachers(Me)
            End If

            'but if there are unsaved changes to the collection, use that instead.
            Dim objClassTeachers As ClassroomTeachers = ClassroomTeachers
            If objClassTeachers.IsModified Then
                mobjTeachers.Clear()
                For Each objClassroomTeacher As ClassroomTeacher In objClassTeachers
                    If objClassroomTeacher.Teacher IsNot Nothing Then
                        mobjTeachers.Add(objClassroomTeacher.Teacher)
                    End If
                Next
            End If
            Return mobjTeachers
        End Get
    End Property

    ''' <summary>
    '''     This gets/sets the first Teacher for this Classroom
    ''' </summary>
    ''' <value>
    '''     The Teacher object for the Classroom.
    ''' </value>
    ''' <remarks>
    '''     This is a wrapper property for projects that only use one Teacher
    '''     per Classroom. It hides some of the ClassroomTeacher collection logic.
    '''     Be careful about setting a Teacher using this property: the Mobility
    '''     Code/Date won't get updated.  SL 4/26/06
    ''' </remarks>
    Public Property Teacher As Teacher
        Get
            If mobjTeacher Is Nothing Then
                If Teachers.Count > 0 Then
                    mobjTeacher = Teachers(0)
                End If
            End If
            Return mobjTeacher
        End Get
        Set
            mobjTeacher = value

            'if updating the existing teacher...
            If ClassroomTeachers.Count > 0 Then
                ClassroomTeachers(0).Teacher = mobjTeacher
            Else '...otherwise add a new teacher
                Dim objCR As New ClassroomTeacher
                objCR.Classroom = Me
                objCR.Teacher = mobjTeacher
                ClassroomTeachers.Add(objCR)
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the Classroom.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the Classroom.
    ''' </value>
    ''' <remarks>
    '''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    ''' </remarks>

        Public Property [Case] As [Case]
        Get
            If mobjClassroomCase Is Nothing Then
                mobjClassroomCase = New [Case](Me.CaseID.Value, True)
                mobjClassroomCase.Classroom = Me
            End If
            Return mobjClassroomCase
        End Get
        Set
            mobjClassroomCase = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Students collection for the Classroom.
    ''' </summary>
    ''' <value>
    '''     The Students collection for the Classroom.
    ''' </value>

        Public Property Students As Students
        Get
            If mobjStudents Is Nothing Then
                mobjStudents = New Students(ClassroomID.Value)
            End If
            Return mobjStudents
        End Get
        Set
            mobjStudents = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets the displayable Classroom name: "Grade - TeacherLast, TeacherFirst".
    ''' </summary>

        Public ReadOnly Property DisplayName As String
        Get
            If Me.Grade.ToString.Length = 0 AndAlso
               Me.Teachers(0).DisplayName.Length = 0 Then
                Return ""
            Else
                Return Me.Grade.Value & " - " & Me.Teachers(0).DisplayName
            End If
        End Get
    End Property

    Public ReadOnly Property DisplayClassName As String
        Get
            Return Me.Name.Value
        End Get
    End Property

    Public ReadOnly Property NextStudentNumber As Integer
        Get
            Dim obj As Object = SqlHelper.ExecuteScalar(ConnectionString, "Web_GetMaxStudentNumberInClassroom",
                                                        CInt(ClassroomID))

            If obj Is DBNull.Value Then
                Return 1
            Else
                Return CInt(obj) + 1
            End If
        End Get
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
    '''     Inserts a Classroom object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
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

            ' insert the Classroom 
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
            'AF 12/14/04 - Need to call reset modified or will always be dirty 
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a Classroom within the database
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
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Classroom object from the database
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
