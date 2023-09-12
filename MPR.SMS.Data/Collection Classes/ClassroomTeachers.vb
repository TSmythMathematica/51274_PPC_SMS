'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of ClassroomTeacher objects.
''' </summary>

    Public Class ClassroomTeachers
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjClassroom As Classroom
    Private ReadOnly mobjTeacher As Teacher

    Private mblnObjDeleted As Boolean = False

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

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.ClassroomTeacher">ClassroomTeacher</see> object at the specified index
    '''     within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.ClassroomTeacher">ClassroomTeacher</see> object at the specified index in the
    '''     collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As ClassroomTeacher
        Get
            Return CType(List.Item(Index), ClassroomTeacher)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objClassroomTeacher As ClassroomTeacher
            For Each objClassroomTeacher In List
                If objClassroomTeacher.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.ClassroomTeacher">ClassroomTeacher</see> object to the end of the
    '''     PersonClassroomTeachers collection.
    ''' </summary>
    ''' <param name="objClassroomTeacher">
    '''     The <see cref="T:MPR.SMS.Data.ClassroomTeacher">ClassroomTeacher</see> object to be added to the end of the
    '''     collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.ClassroomTeacher">ClassroomTeacher</see> object has
    '''     been added.
    ''' </returns>

        Public Function Add(objClassroomTeacher As ClassroomTeacher) As Integer

        If objClassroomTeacher.MobilityCode.IsNull Then
            objClassroomTeacher.MobilityCode = "000"
        End If
        If objClassroomTeacher.MobilityDate.IsNull Then
            objClassroomTeacher.MobilityDate = Now()
        End If
        Return List.Add(objClassroomTeacher)
    End Function

    Public Sub Remove(objClassroomTeacher As ClassroomTeacher)

        Dim index As Integer = List.IndexOf(objClassroomTeacher)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the ClassroomTeacher object within the collection with a specified ClassroomTeacherID.
    ''' </summary>
    ''' <param name="intClassroomTeacherID">
    '''     The ClassroomTeacherID of the ClassroomTeacher object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the ClassroomTeacher object within the collection having the specified ClassroomTeacherID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intClassroomTeacherID As Integer) As Integer

        If intClassroomTeacherID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objClassroomTeacher As ClassroomTeacher = CType(List.Item(i), ClassroomTeacher)
                If _
                    Not objClassroomTeacher.ClassroomTeacherID.IsNull AndAlso
                    objClassroomTeacher.ClassroomTeacherID.Value = intClassroomTeacherID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified ClassroomTeacher object.
    ''' </summary>
    ''' <param name="objClassroomTeacher">
    '''     The ClassroomTeacher object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified ClassroomTeacher object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objClassroomTeacher As ClassroomTeacher) As Integer

        If Not objClassroomTeacher Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objClassroomTeacher) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a ClassroomTeacher object within the ClassroomTeachers collection.
    ''' </summary>
    ''' <param name="objClassroomTeacher">
    '''     The ClassroomTeacher object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objClassroomTeacher As ClassroomTeacher)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objClassroomTeacher)
        If intIndex < 0 Then
            Me.Add(objClassroomTeacher)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objClassroomTeacher
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objClassroomTeacher As ClassroomTeacher

        For Each objClassroomTeacher In List
            objClassroomTeacher.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objClassroomTeacher As ClassroomTeacher

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).ClassroomTeacherID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objClassroomTeacher In List
            objClassroomTeacher.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objClassroomTeacher As ClassroomTeacher
        Dim blnResult As Boolean = True

        For Each objClassroomTeacher In List
            blnResult = objClassroomTeacher.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objClassroomTeacher As ClassroomTeacher
        Dim blnResult As Boolean = True

        For Each objClassroomTeacher In List
            blnResult = objClassroomTeacher.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As ClassroomTeachers
            If mobjClassroom IsNot Nothing Then
                objExistingCollection = New ClassroomTeachers(mobjClassroom)
            Else
                objExistingCollection = New ClassroomTeachers(mobjTeacher)
            End If

            For Each objExistingClass As ClassroomTeacher In objExistingCollection
                If Me.IndexOf(objExistingClass.ClassroomTeacherID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objClassroom As Classroom)

        Dim objClassroomTeacher As New TblClassroomTeacher

        mobjClassroom = objClassroom
        mobjTeacher = Nothing

        objClassroomTeacher.ConnectionString = Project.ConnectionString

        If Not objClassroom.ClassroomID.IsNull Then
            objClassroomTeacher.ClassroomID = objClassroom.ClassroomID

            ' If the Project's Connection Provider is open, use it
            If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                objClassroomTeacher.ConnectionProvider = Project.ConnectionProvider
            End If

            Dim objClassroomTeachers As DataTable = objClassroomTeacher.SelectAllWClassroomIDLogic()

            objClassroomTeacher.ConnectionProvider = Nothing

            ' Add a new Person to the collection for each Person retrieved

            Dim objDataRow As DataRow

            For Each objDataRow In objClassroomTeachers.Rows
                Add(New ClassroomTeacher(objDataRow))
            Next
        End If
    End Sub

    Public Sub New(objTeacher As Teacher)

        Dim objClassroomTeacher As New TblClassroomTeacher

        mobjClassroom = Nothing
        mobjTeacher = objTeacher

        objClassroomTeacher.ConnectionString = Project.ConnectionString

        If Not objTeacher.TeacherID.IsNull Then
            objClassroomTeacher.TeacherID = objTeacher.TeacherID

            ' If the Project's Connection Provider is open, use it
            If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                objClassroomTeacher.ConnectionProvider = Project.ConnectionProvider
            End If

            Dim objClassroomTeachers As DataTable = objClassroomTeacher.SelectAllWTeacherIDLogic()

            objClassroomTeacher.ConnectionProvider = Nothing

            ' Add a new Person to the collection for each Person retrieved

            Dim objDataRow As DataRow

            For Each objDataRow In objClassroomTeachers.Rows
                Add(New ClassroomTeacher(objDataRow))
            Next
        End If
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonClassroomTeachers collection.
    ''' </summary>
    ''' <remarks>
    '''     This creates an empty collection.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
        Clear()
    End Sub

#End Region
End Class
