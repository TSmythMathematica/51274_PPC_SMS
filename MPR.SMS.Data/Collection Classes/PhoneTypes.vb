'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of PhoneType objects for the Project
''' </summary>

    Public Class PhoneTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default PhoneType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default PhoneType within the PhoneTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first PhoneType in the collection or Nothing (null) is no PhoneTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultPhoneType As PhoneType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), PhoneType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the PhoneType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the PhoneType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The PhoneType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As PhoneType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), PhoneType)
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
    '''     Initializes a new instance of the PhoneTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The PhoneTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's PhoneTypes

        Dim objPhoneType As New TlkpPhoneType

        objPhoneType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPhoneType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPhoneTypes As DataTable = objPhoneType.SelectAll()

        objPhoneType.ConnectionProvider = Nothing

        ' Add a new PhoneType to the collection for each PhoneType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPhoneTypes.Rows
            Add(New PhoneType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a PhoneType to the PhoneTypes collection.
    ''' </summary>
    ''' <param name="objPhoneType">
    '''     The PhoneType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the PhoneType has been added.
    ''' </returns>
    ''' <remarks>
    '''     PhoneTypes are maintained in ascending order by PhoneType Code.
    ''' </remarks>

        Public Function Add(objPhoneType As PhoneType) As Integer

        If objPhoneType.PhoneTypeID.IsNull Then
            If Not objPhoneType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingPhoneType As PhoneType = CType(List.Item(i), PhoneType)
            If objPhoneType.PhoneTypeID.Value() < objExistingPhoneType.PhoneTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objPhoneType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a PhoneType in the collection.
    ''' </summary>
    ''' <param name="objPhoneType">
    '''     The PhoneType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     PhoneTypes are maintained in ascending order by PhoneType Code.
    ''' </remarks>

        Public Function Update(objPhoneType As PhoneType) As Boolean

        If Not objPhoneType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingPhoneType As PhoneType = CType(List.Item(i), PhoneType)
            If objExistingPhoneType.PhoneTypeID.Value = objPhoneType.PhoneTypeID.Value Then
                List.RemoveAt(i)
                Add(objPhoneType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the PhoneType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the PhoneType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the PhoneType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objPhoneType As PhoneType = CType(List.Item(i), PhoneType)
                If objPhoneType.PhoneTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
