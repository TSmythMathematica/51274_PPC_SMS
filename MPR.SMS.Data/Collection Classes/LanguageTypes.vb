'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LanguageType objects for the Project
''' </summary>

    Public Class LanguageTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default LanguageType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default LanguageType within the LanguageTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first LanguageType in the collection or Nothing (null) is no LanguageTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultLanguageType As LanguageType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), LanguageType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the LanguageType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the LanguageType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The LanguageType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As LanguageType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), LanguageType)
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
    '''     Initializes a new instance of the LanguageTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The LanguageTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's LanguageTypes

        Dim objLanguageType As New TlkpLanguageType

        objLanguageType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLanguageType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLanguageTypes As DataTable = objLanguageType.SelectAll()

        objLanguageType.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objLanguageTypes.Rows
            Add(New LanguageType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a LanguageType to the LanguageTypes collection.
    ''' </summary>
    ''' <param name="objLanguageType">
    '''     The LanguageType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the LanguageType has been added.
    ''' </returns>
    ''' <remarks>
    '''     LanguageTypes are maintained in ascending order by LanguageType Code.
    ''' </remarks>

        Public Function Add(objLanguageType As LanguageType) As Integer

        If objLanguageType.LanguageTypeID.IsNull Then
            If Not objLanguageType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingLanguageType As LanguageType = CType(List.Item(i), LanguageType)
            If objLanguageType.LanguageTypeID.Value() < objExistingLanguageType.LanguageTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objLanguageType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a LanguageType in the collection.
    ''' </summary>
    ''' <param name="objLanguageType">
    '''     The LanguageType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     LanguageTypes are maintained in ascending order by LanguageType Code.
    ''' </remarks>

        Public Function Update(objLanguageType As LanguageType) As Boolean

        If Not objLanguageType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingLanguageType As LanguageType = CType(List.Item(i), LanguageType)
            If objExistingLanguageType.LanguageTypeID.Value = objLanguageType.LanguageTypeID.Value Then
                List.RemoveAt(i)
                Add(objLanguageType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the LanguageType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the LanguageType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LanguageType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLanguageType As LanguageType = CType(List.Item(i), LanguageType)
                If objLanguageType.LanguageTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
