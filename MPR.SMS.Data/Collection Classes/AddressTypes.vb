'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of AddressType objects for the Project
''' </summary>

    Public Class AddressTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default AddressType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default AddressType within the AddressTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first AddressType in the collection or Nothing (null) is no AddressTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultAddressType As AddressType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), AddressType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the AddressType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the AddressType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The AddressType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As AddressType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), AddressType)
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
    '''     Initializes a new instance of the AddressTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The AddressTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's AddressTypes

        Dim objAddressType As New TlkpAddressType

        objAddressType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objAddressType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objAddressTypes As DataTable = objAddressType.SelectAll()

        objAddressType.ConnectionProvider = Nothing

        ' Add a new AddressType to the collection for each AddressType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objAddressTypes.Rows
            Add(New AddressType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a AddressType to the AddressTypes collection.
    ''' </summary>
    ''' <param name="objAddressType">
    '''     The AddressType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the AddressType has been added.
    ''' </returns>
    ''' <remarks>
    '''     AddressTypes are maintained in ascending order by AddressType Code.
    ''' </remarks>

        Public Function Add(objAddressType As AddressType) As Integer

        If objAddressType.AddressTypeID.IsNull Then
            If Not objAddressType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingAddressType As AddressType = CType(List.Item(i), AddressType)
            If objAddressType.AddressTypeID.Value() < objExistingAddressType.AddressTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objAddressType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a AddressType in the collection.
    ''' </summary>
    ''' <param name="objAddressType">
    '''     The AddressType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     AddressTypes are maintained in ascending order by AddressType Code.
    ''' </remarks>

        Public Function Update(objAddressType As AddressType) As Boolean

        If Not objAddressType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingAddressType As AddressType = CType(List.Item(i), AddressType)
            If objExistingAddressType.AddressTypeID.Value = objAddressType.AddressTypeID.Value Then
                List.RemoveAt(i)
                Add(objAddressType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the AddressType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the AddressType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the AddressType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objAddressType As AddressType = CType(List.Item(i), AddressType)
                If objAddressType.AddressTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
