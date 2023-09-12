'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class DocumentTypes
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As DocumentType
        Get
            If Not Index < Count Then
                Throw New Exception("DocumentTypes::Item::Supplied index is out of range")
            Else
                Return CType(list.Item(Index), DocumentType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Case objectbelongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Case object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Case constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the DocumentTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Documents collection is initialized from the database. This form of the constructor
    '''     is used get all of the documents defined for the Project.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Document Types

        Dim objDocumentType As New TlkpDocumentType

        objDocumentType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocumentType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocumentTypes As DataTable = objDocumentType.SelectAll()

        objDocumentType.ConnectionProvider = Nothing

        ' Add a new DocumentType to the collection for each DocumentType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocumentTypes.Rows
            Add(New DocumentType(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the DocumentTypes collection for a DocumentGroup.
    ''' </summary>
    ''' <param name="objDocumentGroup">
    '''     The DocumentGroup that the DocumentTypes collection belongs to.
    ''' </param>
    ''' <remarks>
    '''     The Documents collection is initialized from the database. This form of the constructor
    '''     is used get all of the documents defined for the Project.
    ''' </remarks>

        Public Sub New(objDocumentGroup As DocumentGroup)

        ' Retrieve the Project's Document Types

        Dim objDocumentType As New TlkpDocumentType

        objDocumentType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocumentType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocumentTypes As DataTable = objDocumentType.SelectAll()

        objDocumentType.ConnectionProvider = Nothing

        ' Add a new DocumentType to the collection for each DocumentType in the DocumentGroup

        Dim objDataRow As DataRow

        For Each objDataRow In objDocumentTypes.Rows
            If Not (objDataRow("DocumentGroupID") Is DBNull.Value) Then
                If CType(objDataRow("DocumentGroupID"), Integer) = objDocumentGroup.DocumentGroupID.Value Then
                    Add(New DocumentType(objDataRow))
                End If
            End If
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds an DocumentType to the DocumentTypess collection.
    ''' </summary>
    ''' <param name="objDocumentType">
    '''     The Document to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the DocumentType has been added.
    ''' </returns>
    ''' <remarks>
    '''     Document are maintained in ascending order by Description.
    ''' </remarks>

        Public Function Add(objDocumentType As DocumentType) As Integer

        If objDocumentType.DocumentTypeID.IsNull Then
            If Not objDocumentType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDocumentType As DocumentType = CType(List.Item(i), DocumentType)
            If objDocumentType.DocumentTypeID.Value() < objExistingDocumentType.DocumentTypeID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objDocumentType)

        Return i
    End Function

    Public Function GetByID(iDocType As Integer) As DocumentType
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objDocumentType As DocumentType = CType(List.Item(i), DocumentType)
            If objDocumentType.DocumentTypeID.Value = iDocType Then
                Return objDocumentType
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iDocType As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objDocumentType As DocumentType = CType(List.Item(i), DocumentType)
            If objDocumentType.DocumentTypeID.Value = iDocType Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class