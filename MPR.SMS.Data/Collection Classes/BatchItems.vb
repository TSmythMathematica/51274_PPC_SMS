'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class BatchItems
    Inherits CollectionBase

#Region "Private Fields"

    Dim ReadOnly mobjBatch As Batch

#End Region

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As BatchItem
        Get
            If Not Index < Count Then
                Throw New Exception("BatchItems::Item::Supplied index is out of range")
            Else
                Return CType(List.Item(Index), BatchItem)
            End If
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

    Friend Sub New(objBatch As Batch)

        MyBase.New()

        mobjBatch = objBatch

        ' ** Retrieve the Batches's BatchItems **
        Dim dtBatchItems As New DataTable
        Dim objTblBatchItem As New TblBatchItem
        Dim blnCloseConnection As Boolean = False

        Try

            ' prepare the connection
            objTblBatchItem.ConnectionString = Project.ConnectionString
            objTblBatchItem.ConnectionProvider = Project.ConnectionProvider
            If objTblBatchItem.ConnectionProvider.Connection.State = ConnectionState.Open Then
                objTblBatchItem.ConnectionProvider = Project.ConnectionProvider
                blnCloseConnection = True
            End If

            ' fill the BatchItems dataset
            objTblBatchItem.BatchID = mobjBatch.BatchID
            dtBatchItems = objTblBatchItem.SelectAllWBatchIDLogic

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then objTblBatchItem.ConnectionProvider.CloseConnection(False)
            objTblBatchItem.ConnectionProvider = Nothing
        End Try

        ' Add a new BatchItem to the collection for each row retrieved
        Dim objDataRow As DataRow
        For Each objDataRow In dtBatchItems.Rows
            Dim objBatchItem As New BatchItem(objDataRow)
            Add(objBatchItem)
            ' know thy Batch
            objBatchItem.Batch = mobjBatch
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a BatchItem to the BatchItems collection (and to DB, if a new BatchItem).
    ''' </summary>
    ''' <param name="objBatchItem">
    '''     The BatchItem to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the BatchItem has been added.
    ''' </returns>

        Public Function Add(objBatchItem As BatchItem) As Integer

        ' ID it w/ Batch
        If mobjBatch IsNot Nothing Then
            objBatchItem.BatchID = mobjBatch.BatchID
            ' Insert as needed
            If objBatchItem.BatchItemID.IsNull Then
                If Not objBatchItem.Insert() Then
                    Return - 1
                End If
            End If
        End If

        Return List.Add(objBatchItem)
    End Function

#End Region
End Class
