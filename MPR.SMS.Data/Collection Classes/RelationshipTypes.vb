'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of RelationshipType objects for the Project
''' </summary>

    Public Class RelationshipTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default RelationshipType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default RelationshipType within the RelationshipTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first RelationshipType in the collection or Nothing (null) is no RelationshipTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultRelationshipType As RelationshipType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), RelationshipType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the RelationshipType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the RelationshipType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The RelationshipType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As RelationshipType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), RelationshipType)
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
    '''     Initializes a new instance of the RelationshipTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The RelationshipTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's RelationshipTypes

        Dim objRelationshipType As New TlkpRelationshipType

        objRelationshipType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objRelationshipType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objRelationshipTypes As DataTable = objRelationshipType.SelectAll()

        objRelationshipType.ConnectionProvider = Nothing

        ' Add a new RelationshipType to the collection for each RelationshipType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objRelationshipTypes.Rows
            Add(New RelationshipType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a RelationshipType to the RelationshipTypes collection.
    ''' </summary>
    ''' <param name="objRelationshipType">
    '''     The RelationshipType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the RelationshipType has been added.
    ''' </returns>
    ''' <remarks>
    '''     RelationshipTypes are maintained in ascending order by RelationshipType Code.
    ''' </remarks>

        Public Function Add(objRelationshipType As RelationshipType) As Integer

        If objRelationshipType.RelationshipTypeID.IsNull Then
            If Not objRelationshipType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingRelationshipType As RelationshipType = CType(List.Item(i), RelationshipType)
            If objRelationshipType.RelationshipTypeID.Value() < objExistingRelationshipType.RelationshipTypeID.Value() _
                Then
                Exit For
            End If
        Next

        List.Insert(i, objRelationshipType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a RelationshipType in the collection.
    ''' </summary>
    ''' <param name="objRelationshipType">
    '''     The RelationshipType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     RelationshipTypes are maintained in ascending order by RelationshipType Code.
    ''' </remarks>

        Public Function Update(objRelationshipType As RelationshipType) As Boolean

        If Not objRelationshipType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingRelationshipType As RelationshipType = CType(List.Item(i), RelationshipType)
            If objExistingRelationshipType.RelationshipTypeID.Value = objRelationshipType.RelationshipTypeID.Value Then
                List.RemoveAt(i)
                Add(objRelationshipType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the RelationshipType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the RelationshipType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the RelationshipType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objRelationshipType As RelationshipType = CType(List.Item(i), RelationshipType)
                If objRelationshipType.RelationshipTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
