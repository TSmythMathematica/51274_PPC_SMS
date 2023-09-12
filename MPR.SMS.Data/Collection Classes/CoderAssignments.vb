'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class CoderAssignments
    Inherits CollectionBase

#Region "Public Properties"

    Default Public ReadOnly Property Item(Index As Integer) As CoderAssignment
        Get
            If Not Index < Count Then
                Throw New Exception("CoderAssignments::Item::Supplied index is out of range")
            Else
                Return CType(List.Item(Index), CoderAssignment)
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

    Public Sub New()

        Dim dtCoderAssignments As DataTable
        Try
            dtCoderAssignments = RetrieveAllBatches()
        Catch ex As Exception
            ' probably DB access exception
            Throw ex
        End Try

        Dim objDataRow As DataRow
        For Each objDataRow In dtCoderAssignments.Rows
            Dim objCoderAssignment As New CoderAssignment(objDataRow)

            ' Only add it if BatchType and InstrumentType are a match
            'If (objBatch.BatchType = enmBatchType) _
            'AndAlso (objBatch.InstrumentTypeID = objInstrumentType.InstrumentTypeID) Then

            Add(objCoderAssignment)

            'End If
        Next
    End Sub

    Public Sub New(objCoder As Coder)

        Dim dtCoderAssignments As DataTable
        Try
            dtCoderAssignments = RetrieveAllBatchesbyCoder(objCoder)
        Catch ex As Exception
            ' probably DB access exception
            Throw ex
        End Try

        Dim objDataRow As DataRow
        For Each objDataRow In dtCoderAssignments.Rows
            Dim objCoderAssignment As New CoderAssignment(objDataRow)

            ' Only add it if BatchType and InstrumentType are a match
            'If (objBatch.BatchType = enmBatchType) _
            'AndAlso (objBatch.InstrumentTypeID = objInstrumentType.InstrumentTypeID) Then

            Add(objCoderAssignment)

            'End If
        Next
    End Sub

#End Region

#Region "Private Methods"

    Private Function RetrieveAllBatches() As DataTable
        Dim dtCoderAssignments As DataTable
        Dim objTblCoderAssignments As New TblCoderAssignments
        Dim blnCloseConnection As Boolean = False

        Try
            With objTblCoderAssignments
                .ConnectionString = Project.ConnectionString
                .ConnectionProvider = Project.ConnectionProvider

                If Not .ConnectionProvider.Connection.State = ConnectionState.Open Then
                    .ConnectionProvider.OpenConnection()
                    blnCloseConnection = True
                End If

                dtCoderAssignments = .SelectAll()
            End With

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then objTblCoderAssignments.ConnectionProvider.CloseConnection(False)
            objTblCoderAssignments.ConnectionProvider = Nothing
        End Try

        Return dtCoderAssignments
    End Function


    Public Function RetrieveAllBatchesbyCoder(objCoder As Coder) As DataTable
        Dim dtCoderAssignments As DataTable
        Dim objTblCoderAssignments As New TblCoderAssignments
        Dim blnCloseConnection As Boolean = False

        Try
            With objTblCoderAssignments
                .ConnectionString = Project.ConnectionString
                .ConnectionProvider = Project.ConnectionProvider

                If Not .ConnectionProvider.Connection.State = ConnectionState.Open Then
                    .ConnectionProvider.OpenConnection()
                    blnCloseConnection = True
                End If

                objTblCoderAssignments.CoderId = objCoder.CoderId
                dtCoderAssignments = .SelectAllWCoderIdLogic()
            End With

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then objTblCoderAssignments.ConnectionProvider.CloseConnection(False)
            objTblCoderAssignments.ConnectionProvider = Nothing
        End Try

        Return dtCoderAssignments
    End Function

    Public Function RetrieveAllBatchesbyCaseId(intcaseid As Integer) As DataTable
        Dim dtCoderAssignments As DataTable
        Dim objTblCoderAssignments As New TblCoderAssignments
        Dim blnCloseConnection As Boolean = False

        Try
            With objTblCoderAssignments
                .ConnectionString = Project.ConnectionString
                .ConnectionProvider = Project.ConnectionProvider

                If Not .ConnectionProvider.Connection.State = ConnectionState.Open Then
                    .ConnectionProvider.OpenConnection()
                    blnCloseConnection = True
                End If

                objTblCoderAssignments.Caseid = intcaseid
                dtCoderAssignments = .SelectAllWCaseIdLogic()
            End With

        Catch ex As Exception
            Throw ex
        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then objTblCoderAssignments.ConnectionProvider.CloseConnection(False)
            objTblCoderAssignments.ConnectionProvider = Nothing
        End Try

        Return dtCoderAssignments
    End Function

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an Batch to the Batches collection.
    ''' </summary>
    ''' <param name="objCoderAssignment">
    '''     The Batch to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Batch has been added.
    ''' </returns>

        Public Function Add(objCoderAssignment As CoderAssignment) As Integer

        Return List.Add(objCoderAssignment)
    End Function

    Public Function GetByID(iCoderAssignmentID As Integer) As CoderAssignment
        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objCoderAssignment As CoderAssignment = CType(List.Item(i), CoderAssignment)
            If objCoderAssignment.CoderAssignmentID.Value = iCoderAssignmentID Then
                Return objCoderAssignment
            End If
        Next

        Return Nothing
    End Function

    Public Function IndexOf(iCoderAssignment As Integer) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objCoderAssignment As CoderAssignment = CType(List.Item(i), CoderAssignment)
            If objCoderAssignment.CoderAssignmentID.Value = iCoderAssignment Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class
