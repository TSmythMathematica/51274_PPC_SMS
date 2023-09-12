'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of State objects for the Project
''' </summary>

    Public Class States
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default State within the collection.
    ''' </summary>
    ''' <value>
    '''     The default State within the States collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first State in the collection or Nothing (null) is no States exist.
    ''' </remarks>

        Public ReadOnly Property DefaultState As State
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), State)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the State at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the State to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The State at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As State

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), State)
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
    '''     Initializes a new instance of the States collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The States collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's States

        Dim objState As New TlkpStates

        objState.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objState.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objStates As DataTable = objState.SelectAll()

        objState.ConnectionProvider = Nothing

        ' Add a new State to the collection for each State retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objStates.Rows
            Add(New State(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a State to the States collection.
    ''' </summary>
    ''' <param name="objState">
    '''     The State to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the State has been added.
    ''' </returns>
    ''' <remarks>
    '''     States are maintained in ascending order by State Code.
    ''' </remarks>

        Public Function Add(objState As State) As Integer

        If objState.StateID.IsNull Then
            If Not objState.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingState As State = CType(List.Item(i), State)
            If objState.StateID.Value() < objExistingState.StateID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objState)

        Return i
    End Function

    ''' <summary>
    '''     Updates a State in the collection.
    ''' </summary>
    ''' <param name="objState">
    '''     The State object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     States are maintained in ascending order by State Code.
    ''' </remarks>

        Public Function Update(objState As State) As Boolean

        If Not objState.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingState As State = CType(List.Item(i), State)
            If objExistingState.StateID.Value = objState.StateID.Value Then
                List.RemoveAt(i)
                Add(objState)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the State within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the State whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the State within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objState As State = CType(List.Item(i), State)
                If objState.StateID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
