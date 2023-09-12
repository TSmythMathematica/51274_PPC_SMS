'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Student objects.
''' </summary>

    Public Class Students
    Inherits CollectionBase

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#Region "Public Properties"


    ''' <summary>
    '''     Gets the Student at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Student to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Student at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Student

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Student)
            End If
            Return Nothing
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the Students collection.
    ''' </summary>
    ''' <remarks>
    '''     The Students collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        Me.New(False)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Students collection.
    ''' </summary>
    ''' <param name="blnSortByDisplayName">
    '''     Boolean value indicating whether to sort the collection by DisplayName (Ture) or not (False).
    ''' </param>
    ''' <remarks>
    '''     The Students collection is initialized from the database.
    ''' </remarks>

        Public Sub New(blnSortByDisplayName As Boolean)

        ' Retrieve the Students

        Dim objStudent As New TblStudent

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        objStudent.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objStudent.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objStudents As DataTable = objStudent.SelectAll()

        ' Add a new Student to the collection for each Student retrieved

        Dim objDataRow As DataRow
        For Each objDataRow In objStudents.Rows
            Add(New Student(objDataRow), blnSortByDisplayName)
        Next

        ' Ensure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objStudent.ConnectionProvider = Nothing
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Students collection.
    ''' </summary>
    ''' <param name="ClassroomID">
    '''     Integer value representing the classroom the students belong to.
    ''' </param>

        Public Sub New(ClassroomID As Integer)

        ' Retrieve the Students

        Dim objStudent As New TblStudent

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        objStudent.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objStudent.ConnectionProvider = Project.ConnectionProvider
        End If

        objStudent.ClassroomID = New SqlInt32(ClassroomID)
        Dim objStudents As DataTable = objStudent.SelectAllWClassroomIDLogic()

        ' Add a new Student to the collection for each Student retrieved

        Dim objDataRow As DataRow
        For Each objDataRow In objStudents.Rows
            Add(New Student(objDataRow))
        Next

        ' Ensure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If

        objStudent.ConnectionProvider = Nothing
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Student to the Students collection.
    ''' </summary>
    ''' <param name="objStudent">
    '''     The Student to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Student has been added.
    ''' </returns>
    ''' <remarks>
    '''     Students are added in the reverse order from which they are retrieved from the
    '''     database.  Students may be maintained in ascending order by DisplayName (LastName, FirstName)
    '''     by using the overload Function Add(objStudent, AlphaSort) in Students.vb, or by calling the
    '''     Sort Method.
    ''' </remarks>

        Public Function Add(objStudent As Student) As Integer

        Return Add(objStudent, False)
    End Function

    ''' <summary>
    '''     Adds a Student to the Students collection.
    ''' </summary>
    ''' <param name="objStudent">
    '''     The Student to be added to the collection.
    ''' </param>
    ''' <param name="blnSortByDisplayName">
    '''     Boolean value indicating whether to sort the collection by DisplayName (Ture) or not (False).
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Student has been added.
    ''' </returns>
    ''' <remarks>
    '''     Students are added in the reverse order from which they are retrieved from the
    '''     database if AlphaSort is set to False.  Students may be maintained in ascending order
    '''     by DisplayName (LastName, FirstName) by setting AlphaSort to True.
    ''' </remarks>

        Public Function Add(objStudent As Student, blnSortByDisplayName As Boolean) As Integer

        If objStudent.StudentID.IsNull Then
            If Not objStudent.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer = 0
        'If blnSortByDisplayName Then
        '    For i = 0 To (List.Count - 1)
        '        Dim objExistingStudent As Student = CType(List.Item(i), Student)
        '        If objStudent.DisplayName < objExistingStudent.DisplayName Then
        '            Exit For
        '        End If
        '    Next
        'End If

        List.Insert(i, objStudent)

        Return i
    End Function

    ''' <summary>
    '''     Sorts the Students collection by DisplayName (LastName, FirstName).
    ''' </summary>

        Public Sub Sort()

        ' Open the database if needed
        Dim blnCloseConnection As Boolean = False
        If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            blnCloseConnection = True
            Project.ConnectionProvider.OpenConnection()
        End If

        Dim objStudents As Students = New Students
        For i As Integer = 0 To Me.List.Count - 1
            objStudents.List.Insert(i, CType(Me.Item(i), Student))
        Next

        Me.Clear()
        For Each objStudent As Student In objStudents
            Add(objStudent, True)
        Next

        ' Ensure the database is always closed if it was opened here
        If blnCloseConnection Then
            blnCloseConnection = False
            Project.ConnectionProvider.CloseConnection(False)
        End If
    End Sub

    ''' <summary>
    '''     Updates a Student in the collection.
    ''' </summary>
    ''' <param name="objStudent">
    '''     The Student object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Students are maintained in ascending order by Student Code.
    ''' </remarks>

        Public Function Update(objStudent As Student) As Boolean

        If Not objStudent.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingStudent As Student = CType(List.Item(i), Student)
            If objExistingStudent.StudentID.Value = objStudent.StudentID.Value Then
                List.RemoveAt(i)
                Add(objStudent)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the Student within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Student whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Student within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objStudent As Student = CType(List.Item(i), Student)
                If objStudent.StudentID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region
End Class