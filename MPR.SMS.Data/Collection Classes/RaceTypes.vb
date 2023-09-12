'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of RaceType objects for the Project
''' </summary>

    Public Class RaceTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default RaceType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default RaceType within the RaceTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first RaceType in the collection or Nothing (null) is no RaceTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultRaceType As RaceType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), RaceType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the RaceType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the RaceType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The RaceType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As RaceType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), RaceType)
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
    '''     Initializes a new instance of the RaceTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The RaceTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's RaceTypes

        Dim objRaceType As New TlkpRaceType

        objRaceType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objRaceType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objRaceTypes As DataTable = objRaceType.SelectAll()

        objRaceType.ConnectionProvider = Nothing

        ' Add a new RaceType to the collection for each RaceType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objRaceTypes.Rows
            Add(New RaceType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a RaceType to the RaceTypes collection.
    ''' </summary>
    ''' <param name="objRaceType">
    '''     The RaceType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the RaceType has been added.
    ''' </returns>
    ''' <remarks>
    '''     RaceTypes are maintained in ascending order by RaceType Code.
    ''' </remarks>

        Public Function Add(objRaceType As RaceType) As Integer

        If objRaceType.RaceTypeID.IsNull Then
            If Not objRaceType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingRaceType As RaceType = CType(List.Item(i), RaceType)
            If objRaceType.RaceTypeID.Value() < objExistingRaceType.RaceTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objRaceType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a RaceType in the collection.
    ''' </summary>
    ''' <param name="objRaceType">
    '''     The RaceType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     RaceTypes are maintained in ascending order by RaceType Code.
    ''' </remarks>

        Public Function Update(objRaceType As RaceType) As Boolean

        If Not objRaceType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingRaceType As RaceType = CType(List.Item(i), RaceType)
            If objExistingRaceType.RaceTypeID.Value = objRaceType.RaceTypeID.Value Then
                List.RemoveAt(i)
                Add(objRaceType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the RaceType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the RaceType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the RaceType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objRaceType As RaceType = CType(List.Item(i), RaceType)
                If objRaceType.RaceTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
