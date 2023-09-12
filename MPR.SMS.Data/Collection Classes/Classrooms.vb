'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> objects.
''' </summary>

    Public Class Classrooms
    Inherits CollectionBase

#Region "Private Variables"

    Private mblnObjDeleted As Boolean = False

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object at a specific index within the collection.
    ''' </summary>
    ''' <param name="index">
    '''     The index of the <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object to be retrieved from the collection.
    ''' </param>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Classroom
        Get
            If index >= 0 And index < Count Then
                Return CType(List.Item(index), Classroom)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objClassroom As Classroom
            For Each objClassroom In List
                If objClassroom.IsModified Then
                    Return True
                ElseIf objClassroom.ClassroomTeachers.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classrooms collection
    '''     belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classrooms collection belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a collection of all Classrooms.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor creates a Classrooms collection consisting of all
    '''     Classrooms in the database.
    ''' </remarks>
    Public Sub New()

        ' Retrieve ALL Classrooms

        Dim objClassroom As New TblClassroom

        objClassroom.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objClassroom.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objClassrooms As DataTable = objClassroom.SelectAll()

        objClassroom.ConnectionProvider = Nothing

        ' Add a new Classroom object to the collection for each Classroom retrieved  

        Dim objDataRow As DataRow

        For Each objDataRow In objClassrooms.Rows
            Add(New Classroom(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Classrooms collection for a <see cref="T:MPR.SMS.Data.School">School</see>.
    ''' </summary>
    ''' <param name="objSchool">
    '''     The <see cref="T:MPR.SMS.Data.School">School</see> that the Classrooms collection belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor creates a Classrooms collection consisting of all
    '''     Classrooms in the specified <see cref="T:MPR.SMS.Data.School">School</see>.
    ''' </remarks>
    Public Sub New(objSchool As School)

        ' Retrieve all Classrooms for the School

        Dim objClassroom As New TblClassroom

        objClassroom.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objClassroom.ConnectionProvider = Project.ConnectionProvider
        End If

        objClassroom.SchoolID = New SqlInt32(objSchool.SchoolID.Value)

        Dim objClassrooms As DataTable = objClassroom.SelectAllWSchoolIDLogic()

        objClassroom.ConnectionProvider = Nothing

        ' Add a new Classroom object to the collection for each Classroom retrieved  

        Dim objDataRow As DataRow

        For Each objDataRow In objClassrooms.Rows
            Add(New Classroom(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Classrooms collection for a <see cref="T:MPR.SMS.Data.Teacher">Teacher</see>.
    ''' </summary>
    ''' <param name="objTeacher">
    '''     The <see cref="T:MPR.SMS.Data.Teacher">Teacher</see> that the Classrooms collection belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor creates a Classrooms collection consisting of all
    '''     Classrooms that the specified <see cref="T:MPR.SMS.Data.Teacher">Teacher</see> has been
    '''     assigned to.
    ''' </remarks>

        Public Sub New(objTeacher As Teacher)

        ' Retrieve the Teacher's Classrooms

        Dim objClassroomTeacher As New TblClassroomTeacher

        objClassroomTeacher.TeacherID = objTeacher.TeacherID

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        objClassroomTeacher.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objClassroomTeacher.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objClassroomTeachers As DataTable = objClassroomTeacher.SelectAllWTeacherIDLogic()

        ' Add a new Classroom to the collection for each Classroom retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objClassroomTeachers.Rows

            Dim objClassroom As New Classroom

            objClassroom.ClassroomID = New SqlInt32(CType(objDataRow("ClassroomID"), Integer))

            objClassroom.SelectOne()

            List.Add(objClassroom)

        Next

        ' Insure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objClassroomTeacher.ConnectionProvider = Nothing
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object to the Classrooms collection.
    ''' </summary>
    ''' <param name="objNewClassroom">
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object has been added or -1
    '''     if unsuccessful.
    ''' </returns>
    ''' <remarks>
    '''     The Classrooms collection is maintained in sorted order by Classroom Grade. If the ClassroomID
    '''     of the <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object is Nothing (null), the
    '''     <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object is inserted into the database as
    '''     well as the collection.
    ''' </remarks>

        Public Function Add(objNewClassroom As Classroom) As Integer

        ' If the ClassroomID is Nothing, insert it into the database

        If objNewClassroom.ClassroomID.IsNull Then
            If Not objNewClassroom.Insert() Then
                Return - 1
            End If
        End If

        ' Locate the index at which the Classroom is to be inserted

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objClassroom As Classroom = CType(List.Item(i), Classroom)
            If objNewClassroom.Grade.Value < objClassroom.Grade.Value Then
                Exit For
            End If
        Next

        ' Insert the new Classroom object into the collection

        List.Insert(i, objNewClassroom)

        Return i
    End Function

    Friend Function Insert() As Boolean

        Dim objClassroom As Classroom
        Dim blnResult As Boolean = True

        For Each objClassroom In List
            blnResult = objClassroom.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> collection.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>
    Public Function Update() As Boolean

        Dim objClassroom As Classroom
        Dim blnResult As Boolean = True

        For Each objClassroom In List
            blnResult = objClassroom.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Classrooms()
            For Each objExistingClass As Classroom In objExistingCollection
                If Me.IndexOf(objExistingClass.ClassroomID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Removes a <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object from the Classrooms collection.
    ''' </summary>
    ''' <param name="objClassroom">
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object to be removed from the collection.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>
    ''' <remarks>
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object is deleted from the database and removed from the
    '''     collection.
    ''' </remarks>

        Public Function Delete(objClassroom As Classroom) As Boolean

        Dim i As Integer = IndexOf(objClassroom.ClassroomID.Value)

        ' Delete the Classroom object from the database

        Dim blnResult As Boolean = objClassroom.Delete()

        ' If succesful, remove the Classroom object from the collection

        If blnResult And i >= 0 Then
            List.RemoveAt(i)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Gets the index of the Classroom within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Classroom whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Classroom within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objClassroom As Classroom = CType(List.Item(i), Classroom)
                If objClassroom.ClassroomID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the Classroom within the collection having a specific Classroom Number, specific to FACES project.
    ''' </summary>
    ''' <param name="ClassroomNumber">
    '''     The Classroom Number of the Classroom within the collection to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The Classroom within the collection having the specified Classroom Number or Nothing.
    ''' </returns>

        Public Function GetClassroomByClassroomNumber(ClassroomNumber As Integer) As Classroom

        For Each Classroom As Classroom In Me
            If Classroom.ClassroomNumber = ClassroomNumber Then
                Return Classroom
            End If
        Next

        Return Nothing
    End Function

    Public Sub Remove(objClassroom As Classroom)

        Dim index As Integer = List.IndexOf(objClassroom)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objClassroom As Classroom

        For Each objClassroom In List
            objClassroom.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objClassroom As Classroom

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).ClassroomID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objClassroom In List
            objClassroom.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

#End Region
End Class

