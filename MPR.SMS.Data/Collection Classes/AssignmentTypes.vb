'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of AssignmentType objects for the Project
''' </summary>

    Public Class AssignmentTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default AssignmentType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default AssignmentType within the AssignmentTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first AssignmentType in the collection or Nothing (null) is no AssignmentTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultAssignmentType As AssignmentType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), AssignmentType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the AssignmentType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the AssignmentType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The AssignmentType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As AssignmentType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), AssignmentType)
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
    '''     Initializes a new instance of the AssignmentTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The AssignmentTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's AssignmentTypes

        Dim objAssignmentType As New TlkpAssignment

        objAssignmentType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objAssignmentType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objAssignmentTypes As DataTable = objAssignmentType.SelectAll()

        objAssignmentType.ConnectionProvider = Nothing

        ' Add a new AssignmentType to the collection for each AssignmentType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objAssignmentTypes.Rows
            Add(New AssignmentType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a AssignmentType to the AssignmentTypes collection.
    ''' </summary>
    ''' <param name="objAssignmentType">
    '''     The AssignmentType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the AssignmentType has been added.
    ''' </returns>
    ''' <remarks>
    '''     AssignmentTypes are maintained in ascending order by AssignmentType Code.
    ''' </remarks>

        Public Function Add(objAssignmentType As AssignmentType) As Integer

        If objAssignmentType.AssignmentID.IsNull Then
            If Not objAssignmentType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingAssignmentType As AssignmentType = CType(List.Item(i), AssignmentType)
            If objAssignmentType.AssignmentID.Value() < objExistingAssignmentType.AssignmentID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objAssignmentType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a AssignmentType in the collection.
    ''' </summary>
    ''' <param name="objAssignmentType">
    '''     The AssignmentType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     AssignmentTypes are maintained in ascending order by AssignmentType Code.
    ''' </remarks>

        Public Function Update(objAssignmentType As AssignmentType) As Boolean

        If Not objAssignmentType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingAssignmentType As AssignmentType = CType(List.Item(i), AssignmentType)
            If objExistingAssignmentType.AssignmentID.Value = objAssignmentType.AssignmentID.Value Then
                List.RemoveAt(i)
                Add(objAssignmentType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the AssignmentType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the AssignmentType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the AssignmentType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objAssignmentType As AssignmentType = CType(List.Item(i), AssignmentType)
                If objAssignmentType.AssignmentID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
