'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of NoteType objects for the Project
''' </summary>

    Public Class NoteTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default NoteType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default NoteType within the NoteTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first NoteType in the collection or Nothing (null) is no NoteTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultNoteType As NoteType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), NoteType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the NoteType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the NoteType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The NoteType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As NoteType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), NoteType)
            End If
            Return Nothing
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the NoteTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The NoteTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's NoteTypes

        Dim objNoteType As New TlkpNoteType

        objNoteType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objNoteType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objNoteTypes As DataTable = objNoteType.SelectAll()

        objNoteType.ConnectionProvider = Nothing

        ' Add a new NoteType to the collection for each NoteType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objNoteTypes.Rows
            Add(New NoteType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a NoteType to the NoteTypes collection.
    ''' </summary>
    ''' <param name="objNoteType">
    '''     The NoteType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the NoteType has been added.
    ''' </returns>
    ''' <remarks>
    '''     NoteTypes are maintained in ascending order by NoteType Code.
    ''' </remarks>

        Public Function Add(objNoteType As NoteType) As Integer

        If objNoteType.NoteTypeID.IsNull Then
            If Not objNoteType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingNoteType As NoteType = CType(List.Item(i), NoteType)
            If objNoteType.NoteTypeID.Value() < objExistingNoteType.NoteTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objNoteType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a NoteType in the collection.
    ''' </summary>
    ''' <param name="objNoteType">
    '''     The NoteType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     NoteTypes are maintained in ascending order by NoteType Code.
    ''' </remarks>

        Public Function Update(objNoteType As NoteType) As Boolean

        If Not objNoteType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingNoteType As NoteType = CType(List.Item(i), NoteType)
            If objExistingNoteType.NoteTypeID.Value = objNoteType.NoteTypeID.Value Then
                List.RemoveAt(i)
                Add(objNoteType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the NoteType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the NoteType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the NoteType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objNoteType As NoteType = CType(List.Item(i), NoteType)
                If objNoteType.NoteTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
