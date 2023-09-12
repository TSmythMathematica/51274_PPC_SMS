'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Teacher objects.
''' </summary>

    Public Class Teachers
    Inherits CollectionBase

#Region "Private Variables"

    Private mblnObjDeleted As Boolean = False

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the Teacher at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Teacher to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Teacher at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Teacher

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Teacher)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objTeacher As Teacher
            For Each objTeacher In List
                If objTeacher.IsModified Then
                    Return True
                ElseIf objTeacher.ClassroomTeachers.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the ClassRooms collection
    '''     belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the ClassRooms collection belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the Teachers collection.
    ''' </summary>
    ''' <remarks>
    '''     The Teachers collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve ALL Teachers

        Dim objTeacher As New TblTeacher

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        objTeacher.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objTeacher.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objTeachers As DataTable = objTeacher.SelectAll()

        ' Add a new Teacher to the collection for each Teacher retrieved

        Dim objDataRow As DataRow
        For Each objDataRow In objTeachers.Rows
            Add(New Teacher(objDataRow))
        Next

        ' Insure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objTeacher.ConnectionProvider = Nothing
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Teachers collection for a <see cref="T:MPR.SMS.Data.Classroom">Classroom</see>.
    ''' </summary>
    ''' <param name="objClassroom">
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> that the Teachers collection belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor creates a Teachers collection consisting of all
    '''     Teachers that the specified <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> has been
    '''     assigned to. Currently a <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> may only
    '''     be assigned to a single Teacher.
    ''' </remarks>

        Public Sub New(objClassroom As ClassRoom)

        ' Initialize the Classroom

        'mobjClassroom = objClassroom

        ' Retrieve the Classroom's Teachers

        Dim objClassroomTeacher As New TblClassroomTeacher

        objClassroomTeacher.ClassroomID = objClassroom.ClassroomID

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

        Dim objClassroomTeachers As DataTable = objClassroomTeacher.SelectAllWClassroomIDLogic()

        ' Add a new Teacher to the collection for each Teacher retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objClassroomTeachers.Rows

            Dim objTeacher As New Teacher

            objTeacher.TeacherID = New SqlInt32(CType(objDataRow("TeacherID"), Integer))

            objTeacher.SelectOne()

            List.Add(objTeacher)

        Next

        ' Insure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objClassroomTeacher.ConnectionProvider = Nothing
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Teachers collection for a School ID.
    ''' </summary>
    ''' <param name="objSchool">
    '''     The School that the Teachers collection belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor creates a Teachers collection consisting of all
    '''     Teachers belonging to the specified school.
    ''' </remarks>

        Public Sub New(objSchool As School)

        ' Retrieve the Teachers

        Dim objTeacher As New TblTeacher
        objTeacher.SchoolID = New SqlInt32(objSchool.SchoolID.Value)

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        objTeacher.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objTeacher.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objTeachers As DataTable = objTeacher.SelectAllWSchoolIDLogic()

        ' Add a new Teacher to the collection for each Teacher retrieved

        Dim objDataRow As DataRow
        For Each objDataRow In objTeachers.Rows
            Add(New Teacher(objDataRow))
        Next

        ' Insure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objTeacher.ConnectionProvider = Nothing
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Teacher to the Teachers collection.
    ''' </summary>
    ''' <param name="objTeacher">
    '''     The Teacher to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Teacher has been added.
    ''' </returns>
    ''' <remarks>
    '''     Teachers are added in the reverse order from which they are retrieved from the
    '''     database.  Teachers may be maintained in ascending order by DisplayName (LastName, FirstName)
    '''     by using the overload Function Add(objTeacher, AlphaSort) in Teachers.vb, or by calling the
    '''     Sort Method.
    ''' </remarks>

        Public Function Add(objTeacher As Teacher) As Integer

        Return Add(objTeacher, False)
    End Function

    ''' <summary>
    '''     Adds a Teacher to the Teachers collection.
    ''' </summary>
    ''' <param name="objTeacher">
    '''     The Teacher to be added to the collection.
    ''' </param>
    ''' <param name="blnSortByDisplayName">
    '''     Boolean flag indicating whether to sort the collection by DisplayName (True) or not (False).
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Teacher has been added.
    ''' </returns>
    ''' <remarks>
    '''     Teachers are added in the reverse order from which they are retrieved from the
    '''     database if AlphaSort is set to False.  Teachers may be maintained in ascending order
    '''     by DisplayName (LastName, FirstName) by setting AlphaSort to True.
    ''' </remarks>

        Public Function Add(objTeacher As Teacher, blnSortByDisplayName As Boolean) As Integer

        If objTeacher.TeacherID.IsNull Then
            If Not objTeacher.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer = 0
        If blnSortByDisplayName Then
            For i = 0 To (List.Count - 1)
                Dim objExistingTeacher As Teacher = CType(List.Item(i), Teacher)
                If objTeacher.DisplayName < objExistingTeacher.DisplayName Then
                    Exit For
                End If
            Next
        End If

        List.Insert(i, objTeacher)

        Return i
    End Function

    Friend Function Insert() As Boolean

        Dim objTeacher As Teacher
        Dim blnResult As Boolean = True

        For Each objTeacher In List
            blnResult = objTeacher.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the Teacher collection.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>

        Public Function Update() As Boolean

        Dim objTeacher As Teacher
        Dim blnResult As Boolean = True

        For Each objTeacher In List
            blnResult = objTeacher.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Teachers()
            For Each objExistingClass As Teacher In objExistingCollection
                If Me.IndexOf(objExistingClass.TeacherID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Gets the index of the Teacher within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Teacher whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Teacher within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objTeacher As Teacher = CType(List.Item(i), Teacher)
                If objTeacher.TeacherID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Sub Remove(objTeacher As Teacher)

        Dim index As Integer = List.IndexOf(objTeacher)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objTeacher As Teacher

        For Each objTeacher In List
            objTeacher.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objTeacher As Teacher

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).TeacherID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objTeacher In List
            objTeacher.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

#End Region
End Class