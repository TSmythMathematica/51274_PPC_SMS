'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class EntityTypes
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As EntityType
        Get
            If Not Index < Count Then
                Throw New Exception("EntityTypes::Item::Supplied index is out of range")
            Else
                Return CType(list.Item(Index), EntityType)
            End If
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

    ''' <overloads>
    '''     The EntityTypes collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the EntityTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The EntityTypes collection is initialized from the database. This form of the constructor
    '''     is used get all of the EntityTypes defined for the Project.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's EntityTypes

        Dim objEntityType As New TlkpEntityType

        objEntityType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objEntityType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objEntityTypes As DataTable = objEntityType.SelectAll()

        objEntityType.ConnectionProvider = Nothing

        ' Add a new EntityType to the collection for each EntityType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objEntityTypes.Rows
            If CType(objDataRow("IsActive"), Boolean) = True Then
                Add(New EntityType(objDataRow))
            End If
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds an EntityType to the EntityTypess collection.
    ''' </summary>
    ''' <param name="objEntityType">
    '''     The EntityType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the EntityType has been added.
    ''' </returns>
    ''' <remarks>
    '''     EntityTypes are maintained in ascending order by Description.
    ''' </remarks>

        Public Function Add(objEntityType As EntityType) As Integer

        If objEntityType.EntityTypeID.IsNull Then
            If Not objEntityType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingEntityType As EntityType = CType(List.Item(i), EntityType)
            If objEntityType.EntityTypeID.Value() < objExistingEntityType.EntityTypeID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objEntityType)

        Return i
    End Function

    Public Function GetByID(iEntityType As Integer) As EntityType
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objEntityType As EntityType = CType(List.Item(i), EntityType)
            If objEntityType.EntityTypeID.Value = iEntityType Then
                Return objEntityType
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iEntityType As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objEntityType As EntityType = CType(List.Item(i), EntityType)
            If objEntityType.EntityTypeID.Value = iEntityType Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class