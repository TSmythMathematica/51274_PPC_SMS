'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of DocumentStatus objects for the Project
''' </summary>

    Public Class DocumentStatuses
    Inherits CollectionBase

#Region "Public Properties"

    '' '
    '' <summary>
    ''     ' Gets the default DocumentStatus within the collection.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The default DocumentStatus within the DocumentStatuses collection
    ''     '
    '' </value>
    '' '
    '' <remarks>
    ''     ' Currently returns the first DocumentStatus in the collection or Nothing (null) is no DocumentStatuses exist.
    ''     '
    '' </remarks>
    '' <summary>
    ''     Gets the DocumentStatus at a specific index.
    '' </summary>
    '' <param name="index">
    ''     Index of the DocumentStatus to be retrieved in the collection.
    '' </param>
    '' <value>
    ''     The DocumentStatus at the specified index within the collection.
    '' </value>

    'Public ReadOnly Property DefaultDocumentStatus() As DocumentStatus
    '    Get
    '        If List.Count < 1 Then
    '            Return Nothing
    '        Else
    '            Return CType(List.Item(0), DocumentStatus)
    '        End If
    '    End Get
    'End Property

    Default Public ReadOnly Property Item(index As Integer) As DocumentStatus

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), DocumentStatus)
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
    '''     Initializes a new instance of the DocumentStatuses collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The DocumentStatuses collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's DocumentStatuses

        Dim objDocumentStatus As New TlkpDocumentStatus

        objDocumentStatus.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocumentStatus.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocumentStatuses As DataTable = objDocumentStatus.SelectAll()

        objDocumentStatus.ConnectionProvider = Nothing

        ' Add a new DocumentStatus to the collection for each DocumentStatus retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocumentStatuses.Rows
            Add(New DocumentStatus(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a DocumentStatus to the DocumentStatuses collection.
    ''' </summary>
    ''' <param name="objDocumentStatus">
    '''     The DocumentStatus to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the DocumentStatus has been added.
    ''' </returns>
    ''' <remarks>
    '''     DocumentStatuses are maintained in ascending order by DocumentStatus Code.
    ''' </remarks>

        Public Function Add(objDocumentStatus As DocumentStatus) As Integer

        If objDocumentStatus.DocumentStatusID.IsNull Then
            If Not objDocumentStatus.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDocumentStatus As DocumentStatus = CType(List.Item(i), DocumentStatus)
            If objDocumentStatus.DocumentStatusID.Value < objExistingDocumentStatus.DocumentStatusID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objDocumentStatus)

        Return i
    End Function

    ''' <summary>
    '''     Updates a DocumentStatus in the collection.
    ''' </summary>
    ''' <param name="objDocumentStatus">
    '''     The DocumentStatus object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     DocumentStatuses are maintained in ascending order by DocumentStatus Code.
    ''' </remarks>

        Public Function Update(objDocumentStatus As DocumentStatus) As Boolean

        If Not objDocumentStatus.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingDocumentStatus As DocumentStatus = CType(List.Item(i), DocumentStatus)
            If objExistingDocumentStatus.DocumentStatusID.Value = objDocumentStatus.DocumentStatusID.Value Then
                List.RemoveAt(i)
                Add(objDocumentStatus)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the DocumentStatus within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the DocumentStatus whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the DocumentStatus within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objDocumentStatus As DocumentStatus = CType(List.Item(i), DocumentStatus)
                If objDocumentStatus.DocumentStatusID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(iDocStatus As Integer) As DocumentStatus

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objDocumentStatus As DocumentStatus = CType(List.Item(i), DocumentStatus)
            If objDocumentStatus.DocumentStatusID.Value = iDocStatus Then
                Return objDocumentStatus
            End If
        Next

        Return Nothing
    End Function

#End Region
End Class
