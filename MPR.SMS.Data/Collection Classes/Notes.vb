'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports System.Linq
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Note objects.
''' </summary>

    Public Class Notes
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Note">Note</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Note">Note</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Note
        Get
            Return CType(List.Item(Index), Note)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the Note object within the collection with a specified NoteID.
    ''' </summary>
    ''' <param name="intNoteID">
    '''     The NoteID of the Note object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Note object within the collection having the specified NoteID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intNoteID As Integer) As Integer

        If intNoteID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objNote As Note = CType(List.Item(i), Note)
                If Not objNote.NoteID.IsNull AndAlso objNote.NoteID.Value = intNoteID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Note object.
    ''' </summary>
    ''' <param name="objNote">
    '''     The Note object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Note object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objNote As Note) As Integer

        If Not objNote Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objNote) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Note object within the Note collection.
    ''' </summary>
    ''' <param name="objNote">
    '''     The Note object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objNote As Note)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objNote)
        If intIndex < 0 Then ' removed from the checking. AndAlso objNote.IsValid
            objNote.Case = mobjCase
            Me.Add(objNote)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objNote
        End If
    End Sub
    'Public ReadOnly Property PrimaryNote() As Note
    '    Get
    '        For Each Note As Note In Me
    '            If Note.IsPrimaryNote Then
    '                Return Note
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Note">Note</see> object to the end of the Notes collection.
    ''' </summary>
    ''' <param name="objNote">
    '''     The <see cref="T:MPR.SMS.Data.Note">Note</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Note">Note</see> object has been added.
    ''' </returns>

        Public Function Add(objNote As Note) As Integer

        Return List.Add(objNote)
    End Function

    Public Sub Remove(objNote As Note)

        Dim index As Integer = List.IndexOf(objNote)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objNote As Note
            For Each objNote In List
                If objNote.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    Friend Sub ResetModified()

        Dim objNote As Note

        For Each objNote In List
            objNote.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objNote As Note

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).NoteID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objNote In List
            objNote.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objNote As Note
        Dim blnResult As Boolean = True

        For Each objNote In List
            blnResult = objNote.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objNote As Note
        Dim blnResult As Boolean = True

        For Each objNote In List
            blnResult = objNote.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Notes(mobjCase)
            For Each objExistingClass As Note In objExistingCollection
                If Me.IndexOf(objExistingClass.NoteID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

    '3/9/2015, added by Angela, get AddressNotes (AF - copied from NBS 10/09/15)
    Public Function GetAddressNotes(addressID As SqlInt32) As List(Of Note)

        Dim nl As List(Of Note) = New List(Of Note)
        For Each objNote As Note In Me
            If objNote.TableID = addressID Then
                nl.Add(objNote)
            End If
        Next

        Return nl.OrderByDescending(Function(n) n.LastModifiedOn).ToList()
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objNote As New TblNote

        mobjCase = objCase

        objNote.CaseID = objCase.CaseID

        objNote.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objNote.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objNotes As DataTable = objNote.SelectAllWCaseIDLogic()

        objNote.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objNotes.Rows
            Add(New Note(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Notes collection.
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