'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Document objects.
''' </summary>

    Public Class Documents
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mblnObjDeleted As Boolean = False

#End Region

#Region "Public Properties"

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

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Document">Document</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Document">Document</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Document
        Get
            Return CType(List.Item(Index), Document)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the Document object within the collection with a specified DocumentID.
    ''' </summary>
    ''' <param name="intDocumentID">
    '''     The DocumentID of the Document object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Document object within the collection having the specified DocumentID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intDocumentID As Integer) As Integer

        If intDocumentID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objDocument As Document = CType(List.Item(i), Document)
                If Not objDocument.DocumentID.IsNull AndAlso objDocument.DocumentID.Value = intDocumentID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Document object.
    ''' </summary>
    ''' <param name="objDocument">
    '''     The Document object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Document object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objDocument As Document) As Integer

        If Not objDocument Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objDocument) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Document object within the Document collection.
    ''' </summary>
    ''' <param name="objDocument">
    '''     The Document object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objDocument As Document)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objDocument)
        If intIndex < 0 Then
            objDocument.Case = mobjCase
            Me.Add(objDocument)
        Else
            Me.Item(intIndex) = objDocument
        End If
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Document">Document</see> object to the end of the Documents collection.
    ''' </summary>
    ''' <param name="objDocument">
    '''     The <see cref="T:MPR.SMS.Data.Document">Document</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Document">Document</see> object has been added.
    ''' </returns>

        Public Function Add(objDocument As Document) As Integer

        Return List.Add(objDocument)
    End Function

    Public Sub Remove(objDocument As Document)

        Dim index As Integer = List.IndexOf(objDocument)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objDocument As Document
            For Each objDocument In List
                If objDocument.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    Friend Sub ResetModified()

        Dim objDocument As Document

        For Each objDocument In List
            objDocument.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objDocument As Document

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).DocumentID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objDocument In List
            objDocument.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objDocument As Document
        Dim blnResult As Boolean = True

        For Each objDocument In List
            blnResult = objDocument.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objDocument As Document
        Dim blnResult As Boolean = True

        For Each objDocument In List
            blnResult = objDocument.Update()
            If Not blnResult Then
                Exit For
            End If
        Next


        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Documents(mobjCase)
            For Each objExistingClass As Document In objExistingCollection
                If Me.IndexOf(objExistingClass.DocumentID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objDocument As New TblDocument

        mobjCase = objCase

        objDocument.CaseID = objCase.CaseID

        objDocument.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocument.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocuments As DataTable = objDocument.SelectAllWCaseIDLogic()

        objDocument.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocuments.Rows
            Add(New Document(objCase, objDataRow))
        Next
    End Sub

    Public Sub New(objDocumentStatus As DocumentStatus)

        Dim objDocument As New TblDocument

        objDocument.DocumentStatusID = objDocumentStatus.DocumentStatusID

        objDocument.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDocument.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDocuments As DataTable = objDocument.SelectAllWDocumentStatusIDLogic

        objDocument.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDocuments.Rows
            Add(New Document(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Documents collection.
    ''' </summary>
    ''' <remarks>
    '''     This creates an empty collection.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
        Clear()
    End Sub

#End Region
End Class