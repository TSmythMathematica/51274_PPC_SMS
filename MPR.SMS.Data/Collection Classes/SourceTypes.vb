'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of SourceType objects for the Project
''' </summary>

    Public Class SourceTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default SourceType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default SourceType within the SourceTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first SourceType in the collection or Nothing (null) is no SourceTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultSourceType As SourceType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), SourceType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the SourceType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the SourceType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The SourceType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As SourceType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), SourceType)
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
    '''     Initializes a new instance of the SourceTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The SourceTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's SourceTypes

        Dim objSourceType As New TlkpSourceType

        objSourceType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSourceType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSourceTypes As DataTable = objSourceType.SelectAll()

        objSourceType.ConnectionProvider = Nothing

        ' Add a new SourceType to the collection for each SourceType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSourceTypes.Rows
            Add(New SourceType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a SourceType to the SourceTypes collection.
    ''' </summary>
    ''' <param name="objSourceType">
    '''     The SourceType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the SourceType has been added.
    ''' </returns>
    ''' <remarks>
    '''     SourceTypes are maintained in ascending order by SourceType Code.
    ''' </remarks>

        Public Function Add(objSourceType As SourceType) As Integer

        If objSourceType.SourceTypeID.IsNull Then
            If Not objSourceType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSourceType As SourceType = CType(List.Item(i), SourceType)
            If objSourceType.SourceTypeID.Value() < objExistingSourceType.SourceTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objSourceType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a SourceType in the collection.
    ''' </summary>
    ''' <param name="objSourceType">
    '''     The SourceType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     SourceTypes are maintained in ascending order by SourceType Code.
    ''' </remarks>

        Public Function Update(objSourceType As SourceType) As Boolean

        If Not objSourceType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSourceType As SourceType = CType(List.Item(i), SourceType)
            If objExistingSourceType.SourceTypeID.Value = objSourceType.SourceTypeID.Value Then
                List.RemoveAt(i)
                Add(objSourceType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the SourceType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the SourceType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the SourceType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSourceType As SourceType = CType(List.Item(i), SourceType)
                If objSourceType.SourceTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
