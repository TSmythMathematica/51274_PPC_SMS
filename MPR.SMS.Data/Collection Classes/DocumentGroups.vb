'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class DocumentGroups
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As DocumentGroup
        Get
            If Not Index < Count Then
                Throw New Exception("DocumentGroups::Item::Supplied index is out of range")
            Else
                Return CType(list.Item(Index), DocumentGroup)
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
    '''     The DocumentGroups collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the DocumentGroups collection for a Project.
    ''' </summary>

        Public Sub New()

        ' Retrieve the Project's Documents

        Dim objDocumentGroup As New TlkpDocumentGroup

        objDocumentGroup.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocumentGroup.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocumentGroups As DataTable = objDocumentGroup.SelectAll()

        objDocumentGroup.ConnectionProvider = Nothing

        ' Add a new DocumentGroup to the collection for each DocumentGroup retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocumentGroups.Rows
            Add(New DocumentGroup(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds an DocumentGroup to the DocumentGroups collection.
    ''' </summary>
    ''' <param name="objDocumentGroup">
    '''     The Document to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the DocumentGroup has been added.
    ''' </returns>
    ''' <remarks>
    '''     Document are maintained in ascending order by Description.
    ''' </remarks>

        Public Function Add(objDocumentGroup As DocumentGroup) As Integer

        If objDocumentGroup.DocumentGroupID.IsNull Then
            If Not objDocumentGroup.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDocumentGroup As DocumentGroup = CType(List.Item(i), DocumentGroup)
            If objDocumentGroup.DocumentGroupID.Value() < objExistingDocumentGroup.DocumentGroupID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objDocumentGroup)

        Return i
    End Function

    Public Function GetByID(iDocType As Integer) As DocumentGroup
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objDocumentGroup As DocumentGroup = CType(List.Item(i), DocumentGroup)
            If objDocumentGroup.DocumentGroupID.Value = iDocType Then
                Return objDocumentGroup
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iDocType As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objDocumentGroup As DocumentGroup = CType(List.Item(i), DocumentGroup)
            If objDocumentGroup.DocumentGroupID.Value = iDocType Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class