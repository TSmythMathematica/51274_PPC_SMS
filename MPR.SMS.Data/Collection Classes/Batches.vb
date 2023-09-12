'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class Batches
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As Batch
        Get
            If Not Index < Count Then
                Throw New Exception("Batches::Item::Supplied index is out of range")
            Else
                Return CType(List.Item(Index), Batch)
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

    Public Sub New(enmBatchType As Enumerations.BatchType, objInstrumentType As InstrumentType)

        Dim dtBatches As DataTable
        Dim objBatch As New Batch
        '  Try
        dtBatches = objBatch.SelectAllWInstrumentandBatchTypeIDLogic(CInt(objInstrumentType.InstrumentTypeID),
                                                                     enmBatchType)
        ' dtBatches = RetrieveAllBatches()
        'Catch ex As Exception
        '    ' probably DB access exception
        '    Throw ex
        'End Try

        Dim objDataRow As DataRow

        For Each objDataRow In dtBatches.Rows
            Add(New Batch(objDataRow))
        Next

        'Dim objDataRow As DataRow
        'For Each objDataRow In dtBatches.Rows
        '    Dim objBatch As New Batch(objDataRow)

        '    ' Only add it if BatchType and InstrumentType are a match
        '    If (objBatch.BatchType = enmBatchType) _
        '    AndAlso (objBatch.InstrumentTypeID = objInstrumentType.InstrumentTypeID) Then

        '        Add(objBatch)

        '    End If
        'Next
    End Sub

#End Region

#Region "Private Methods"

    Private Function RetrieveAllBatches() As DataTable
        Dim dtBatches As DataTable
        Dim objTblBatch As New TblBatch
        Dim blnCloseConnection As Boolean = False

        Try
            With objTblBatch
                .ConnectionString = Project.ConnectionString
                .ConnectionProvider = Project.ConnectionProvider

                If Not .ConnectionProvider.Connection.State = ConnectionState.Open Then
                    .ConnectionProvider.OpenConnection()
                    blnCloseConnection = True
                End If

                dtBatches = .SelectAll()
            End With

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then objTblBatch.ConnectionProvider.CloseConnection(False)
            objTblBatch.ConnectionProvider = Nothing
        End Try

        Return dtBatches
    End Function


#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an Batch to the Batches collection.
    ''' </summary>
    ''' <param name="objBatch">
    '''     The Batch to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Batch has been added.
    ''' </returns>

        Public Function Add(objBatch As Batch) As Integer

        Return List.Add(objBatch)
    End Function

    Public Function GetByID(iBatchID As Integer) As Batch
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objBatch As Batch = CType(List.Item(i), Batch)
            If objBatch.BatchID.Value = iBatchID Then
                Return objBatch
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iBatch As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objBatch As Batch = CType(List.Item(i), Batch)
            If objBatch.BatchID.Value = iBatch Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class
