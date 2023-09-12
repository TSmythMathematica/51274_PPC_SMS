'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of DocumentOutputType objects for the Project
''' </summary>

    Public Class DocumentOutputTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default DocumentOutputType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default DocumentOutputType within the DocumentOutputTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first DocumentOutputType in the collection or Nothing (null) is no DocumentOutputTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultDocumentOutputType As DocumentOutputType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), DocumentOutputType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the DocumentOutputType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the DocumentOutputType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The DocumentOutputType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As DocumentOutputType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), DocumentOutputType)
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
    '''     Initializes a new instance of the DocumentOutputTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The DocumentOutputTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's DocumentOutputTypes

        Dim objDocumentOutputType As New TlkpDocumentOutputType

        objDocumentOutputType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocumentOutputType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocumentOutputTypes As DataTable = objDocumentOutputType.SelectAll()

        objDocumentOutputType.ConnectionProvider = Nothing

        ' Add a new DocumentOutputType to the collection for each DocumentOutputType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocumentOutputTypes.Rows
            Add(New DocumentOutputType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a DocumentOutputType to the DocumentOutputTypes collection.
    ''' </summary>
    ''' <param name="objDocumentOutputType">
    '''     The DocumentOutputType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the DocumentOutputType has been added.
    ''' </returns>
    ''' <remarks>
    '''     DocumentOutputTypes are maintained in ascending order by DocumentOutputType Code.
    ''' </remarks>

        Public Function Add(objDocumentOutputType As DocumentOutputType) As Integer

        If objDocumentOutputType.DocumentOutputTypeID.IsNull Then
            If Not objDocumentOutputType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDocumentOutputType As DocumentOutputType = CType(List.Item(i), DocumentOutputType)
            If _
                objDocumentOutputType.DocumentOutputTypeID.Value <
                objExistingDocumentOutputType.DocumentOutputTypeID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objDocumentOutputType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a DocumentOutputType in the collection.
    ''' </summary>
    ''' <param name="objDocumentOutputType">
    '''     The DocumentOutputType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     DocumentOutputTypes are maintained in ascending order by DocumentOutputType Code.
    ''' </remarks>

        Public Function Update(objDocumentOutputType As DocumentOutputType) As Boolean

        If Not objDocumentOutputType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingDocumentOutputType As DocumentOutputType = CType(List.Item(i), DocumentOutputType)
            If _
                objExistingDocumentOutputType.DocumentOutputTypeID.Value =
                objDocumentOutputType.DocumentOutputTypeID.Value Then
                List.RemoveAt(i)
                Add(objDocumentOutputType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the DocumentOutputType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the DocumentOutputType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the DocumentOutputType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objDocumentOutputType As DocumentOutputType = CType(List.Item(i), DocumentOutputType)
                If objDocumentOutputType.DocumentOutputTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
