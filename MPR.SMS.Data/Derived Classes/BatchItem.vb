'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class BatchItem
    Inherits TblBatchItem

#Region "Events"

    Event OnInsert(objBatchItem As BatchItem)
    Event OnUpdate(objBatchItem As BatchItem)
    Event OnDelete(objBatchItem As BatchItem)

#End Region

#Region "Private Fields"

    Private mobjBatch As Batch
    Private mobjInstrument As Instrument

#End Region

#Region "Public Properties"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Property Batch As Batch
        Get
            Return mobjBatch
        End Get
        Set
            mobjBatch = value
            MyBase.BatchID = mobjBatch.BatchID
        End Set
    End Property

    Public ReadOnly Property Instrument As Instrument
        Get
            If (mobjInstrument Is Nothing) AndAlso (Not Me.InstrumentID.IsNull) Then

                'AF 03/13/15 - removed code that instantiated a case to get an instrument and added this for performance purposes. 
                mobjInstrument = New Instrument(InstrumentID.Value, 0)

            End If

            Return mobjInstrument
        End Get
    End Property

    Public Overloads Property ITCode As String
        Get
            Return InstrumentITCode(Me.Instrument)
        End Get
        Set
            MyBase.ITCode = value
        End Set
    End Property


    ''' <summary>
    '''     Assigns specified status code to BatchItem.Instrument
    ''' </summary>
    Public Function UpdateInstrumentStatus(strNewStatus As String) As Boolean

        Dim blnReturn As Boolean = False
        Dim blnCloseConnection As Boolean

        If Me.Instrument IsNot Nothing Then
            'AF - 03/12/10 - if we are batching a TwoBags video type and we are creating a QC or TimeStamp Batch
            ' we should check if the ECI and Picillo instruments exist, if they do  - update statuses
            ' if they don't, create them...  This code was created for BabyFaces and is commented out so that the example exists if other projects need it.

            'If Instrument.InstrumentType.InstrumentTypeID = Enumerations.VideoInstrumentType.TwoBags And _
            '     (Me.Batch.BatchType = Enumerations.BatchType.QC Or _
            '            Me.Batch.BatchType = Enumerations.BatchType.TimeStamp) Then
            '    If Not InsertUpdateVideoInstruments(strNewStatus) Then Return False
            'End If

            Try
                blnCloseConnection = PrepareConnectionProvider()
                Instrument.ConnectionProvider = Project.ConnectionProvider
                Instrument.CurrentStatus = strNewStatus
                Instrument.LogicalStatus = strNewStatus
                blnReturn = Me.Instrument.Update()
            Catch ex As Exception
                Throw ex
            Finally
                ' If I opened connection, then close it
                If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
                ConnectionProvider = Nothing
            End Try
        End If

        Return blnReturn
    End Function

#End Region


#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the BatchItem class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the BatchItem is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>
    Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

    Public Sub New(objBatch As Batch)

        MyBase.New()

        Me.Batch = objBatch

        ConnectionString = Project.ConnectionString
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    '''     Prepares ConnectionProvider for database access.
    ''' </summary>
    ''' <returns>
    '''     Returns True if the connection needed to be opened.
    '''     Returns False if connection was already open.
    ''' </returns>
    ''' <remarks>
    '''     It is responsiblity of calling block to [as needed] CloseConnection and
    '''     set ConnectionProvider = Nothing.
    ''' </remarks>

        Private Function PrepareConnectionProvider() As Boolean
        ConnectionProvider = Project.ConnectionProvider

        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider.OpenConnection()
            Return True
        Else
            Return False
        End If
    End Function

    ' Sets Instrument.StatusCode = ExecuteScalar(strSQL), and updates in DB.
    ' Returns True if updated successfully, otherwise False.
    Private Function UpdateInstrumentStatusWithScalarSQLResult(strSQL As String) As Boolean

        Dim blnReturn As Boolean = False

        If Me.Instrument IsNot Nothing Then

            Try
                Dim objSqlResult As Object = SqlHelper.ExecuteScalar(Project.ConnectionString, CommandType.Text, strSQL)
                If objSqlResult IsNot DBNull.Value Then
                    Dim strStatusCode As String = CStr(objSqlResult)
                    Me.Instrument.CurrentStatus = strStatusCode
                    Me.Instrument.LogicalStatus = strStatusCode
                    blnReturn = Me.Instrument.Update()
                End If

            Catch ex As Exception
                Throw ex
            End Try

        End If

        Return blnReturn
    End Function

    Private Function InsertUpdateVideoInstruments(strNewStatus As String) As Boolean

        Dim blnReturn As Boolean = False
        Dim blnCloseConnection As Boolean

        Dim strSQL As String = "SELECT InstrumentID from tblInstrument WHERE SampleMemberMPRID = " _
                               &
                               CStr(Instrument.SampleMemberMPRID) + " and InstrumentTypeID = " +
                               CStr(Enumerations.VideoInstrumentType.ECI)

        Dim ECIInstrumentID As Integer = CInt(SqlHelper.ExecuteScalar(Project.GetInstance.ConnectionString,
                                                                      CommandType.Text, strSQL))

        strSQL = "SELECT InstrumentID from tblInstrument WHERE SampleMemberMPRID = " _
                 &
                 CStr(Instrument.SampleMemberMPRID) + " and InstrumentTypeID = " +
                 CStr(Enumerations.VideoInstrumentType.Picillo)

        Dim PicilloInstrumentID As Integer = CInt(SqlHelper.ExecuteScalar(Project.GetInstance.ConnectionString,
                                                                          CommandType.Text, strSQL))

        Dim objInstrumentVideo As Instrument

        If ECIInstrumentID = 0 Then 'Add new instrument
            objInstrumentVideo = New Instrument(Instrument.Case)

            With objInstrumentVideo
                .SampleMember = Instrument.SampleMember
                .CurrentRespondent = Instrument.CurrentRespondent
                .InstrumentTypeID = Enumerations.VideoInstrumentType.ECI
                .Status = New Status(strNewStatus)
                .StatusChangeDate = Now
                .StatusChangedBy = "VideoBatching"
                .LastModifiedOn = Now
                .LastModifiedBy = "VideoBatching"
                .CreatedOn = Now
                .CreatedBy = "VideoBatching"
                .ReleaseDate = Now
                blnReturn = .Insert()
            End With
        Else 'Update Existing Instrument

            Dim objTblInstrument As New TblInstrument
            objTblInstrument.ConnectionString = Project.ConnectionString
            objTblInstrument.InstrumentID = New SqlInt32(ECIInstrumentID)
            Dim dt As DataTable = objTblInstrument.SelectOne

            objInstrumentVideo = New Instrument(Instrument.Case, dt.Rows(0))

            Try
                blnCloseConnection = PrepareConnectionProvider()
                With objInstrumentVideo
                    .ConnectionProvider = Project.ConnectionProvider
                    .CurrentStatus = strNewStatus
                    .StatusChangeDate = Now
                    .StatusChangedBy = "VideoBatching"
                    .LastModifiedOn = Now
                    .LastModifiedBy = "VideoBatching"
                    blnReturn = .Update()
                End With
            Catch ex As Exception
                Throw ex
            Finally
                ' If I opened connection, then close it
                If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
                ConnectionProvider = Nothing
            End Try

        End If


        If PicilloInstrumentID = 0 Then 'Add new instrument
            objInstrumentVideo = New Instrument(Instrument.Case)

            With objInstrumentVideo
                .SampleMember = Instrument.SampleMember
                .CurrentRespondent = Instrument.CurrentRespondent
                .InstrumentTypeID = Enumerations.VideoInstrumentType.Picillo
                .Status = New Status(strNewStatus)
                .StatusChangeDate = Now
                .StatusChangedBy = "VideoBatching"
                .ReleaseDate = Now
                blnReturn = .Insert()
            End With
        Else 'Update Existing Instrument

            Dim objTblInstrument As New TblInstrument
            objTblInstrument.ConnectionString = Project.ConnectionString
            objTblInstrument.InstrumentID = New SqlInt32(PicilloInstrumentID)
            Dim dt As DataTable = objTblInstrument.SelectOne

            objInstrumentVideo = New Instrument(Instrument.Case, dt.Rows(0))

            Try
                blnCloseConnection = PrepareConnectionProvider()
                With objInstrumentVideo
                    .ConnectionProvider = Project.ConnectionProvider
                    .CurrentStatus = strNewStatus
                    .StatusChangeDate = Now
                    .StatusChangedBy = "VideoBatching"
                    .LastModifiedOn = Now
                    .LastModifiedBy = "VideoBatching"
                    blnReturn = .Update()
                End With
            Catch ex As Exception
                Throw ex
            Finally
                ' If I opened connection, then close it
                If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
                ConnectionProvider = Nothing
            End Try

        End If


        Return blnReturn
    End Function

#End Region

#Region "Public Methods"


    Public Function DeleteAllWInstrumentIDLogic() As DataTable
        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_BatchItem_DeleteAllWInstrumentIDLogic]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("tblBatchItem")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try
            cmdToExecute.Parameters.Add(New SqlParameter("@InstrumentID", SqlDbType.Int, 4, ParameterDirection.Input,
                                                         False, 10, 0, "", DataRowVersion.Proposed, Me.InstrumentID))
            cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True,
                                                         10, 0, "", DataRowVersion.Proposed, mErrorCode))

            If mblnConnectionIsLocal Then
                ' Open connection.
                mobjSqlConnection.ConnectionString = Me.ConnectionString
                mobjSqlConnection.Open()
            Else
                If mConnectionProvider.IsTransactionPending Then
                    cmdToExecute.Transaction = mConnectionProvider.CurrentTransaction
                End If
            End If

            ' Execute query.
            adapter.Fill(toReturn)
            mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

            If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
                ' Throw error.
                Throw _
                    New Exception(
                        "Stored Procedure 'SMS_BatchItem_DeleteAllWInstrumentIDLogic' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "BatchItem_DeleteAllWInstrumentIDLogic::Error occured." + Environment.NewLine + Environment.NewLine +
                    ex.Message, ex)
        Finally
            If mblnConnectionIsLocal Then
                ' Close connection.
                mobjSqlConnection.Close()
            End If
            cmdToExecute.Dispose()
            adapter.Dispose()
        End Try
    End Function


    ''' <summary>
    '''     Returns default status code that should be assigned to a batched instrument.
    ''' </summary>

        Public Shared Function StatusCodeWhenBatched(enmBatchType As Enumerations.BatchType) As String
        Dim objSqlResult As Object
        Dim strSQL As String = "SELECT StatusCodeWhenBatched FROM tlkpBatchType WHERE BatchTypeID = " +
                               CStr(enmBatchType)

        objSqlResult = SqlHelper.ExecuteScalar(Project.GetInstance.ConnectionString, CommandType.Text, strSQL)
        If objSqlResult IsNot DBNull.Value Then
            Return CStr(objSqlResult)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    '''     Returns default status code that should be assigned to a batched instrument.
    ''' </summary>

        Public Shared Function StatusCodeWhenBatchReceived(enmBatchType As Enumerations.BatchType) As String
        Dim objSqlResult As Object
        Dim strSQL As String = "SELECT StatusCodeWhenBatchReceived FROM tlkpBatchType WHERE BatchTypeID = " +
                               CStr(enmBatchType)

        objSqlResult = SqlHelper.ExecuteScalar(Project.GetInstance.ConnectionString, CommandType.Text, strSQL)
        If objSqlResult IsNot DBNull.Value Then
            Return CStr(objSqlResult)
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    '''     Returns ITCode for given instrument.
    ''' </summary>
    ''' <returns>
    '''     ITCode, or "" if indeterminable (e.g. if Instrument Is Nothing).
    ''' </returns>

        Public Shared Function InstrumentITCode(objInstrument As Instrument) As String
        Dim strInstrumentTypeID As String

        If objInstrument Is Nothing Then
            Return ""
        Else
            If objInstrument.InstrumentType Is Nothing Then
                strInstrumentTypeID = ""
            Else
                strInstrumentTypeID = objInstrument.InstrumentType.InstrumentTypeID.ToString
                If strInstrumentTypeID.Length = 1 Then
                    ' pad it w/ leading zero
                    strInstrumentTypeID = "0" + strInstrumentTypeID
                End If
            End If

            Return objInstrument.SampleMemberMPRID.ToString + "-" + strInstrumentTypeID
        End If
    End Function

    ''' <summary>
    '''     Inserts BatchItem object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        Try
            blnCloseConnection = PrepareConnectionProvider()
            blnResult = MyBase.Insert()

        Catch ex As Exception
            Throw ex

        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a BatchItem object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        Try
            blnCloseConnection = PrepareConnectionProvider()
            blnResult = MyBase.Update()

        Catch ex As Exception
            Throw ex

        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a BatchItem from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False
        Dim blnCloseConnection As Boolean = False

        Try
            blnCloseConnection = PrepareConnectionProvider()
            blnResult = MyBase.Delete()

        Catch ex As Exception
            blnResult = False

        Finally
            ' If I opened connection, then close it
            If blnCloseConnection Then ConnectionProvider.CloseConnection(False)
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function


    ''' <summary>
    '''     Assigns appropriate status code to BatchItem.Instrument
    ''' </summary>
    ''' <Remarks>
    '''     Use this method to status an BatchItem that has been added to a Batch.
    ''' </Remarks>

        Public Function UpdateInstrumentToBatchedStatus() As Boolean

        Dim strSQL As String = "SELECT StatusCodeWhenBatched FROM tlkpBatchType WHERE BatchTypeID = " _
                               & Me.Batch.BatchTypeID.ToString
        Return UpdateInstrumentStatusWithScalarSQLResult(strSQL)
    End Function

    ''' <summary>
    '''     Assigns appropriate status code to BatchItem.Instrument
    ''' </summary>
    ''' <Remarks>
    '''     Use this method to status an BatchItem that has been received (e.g. received into QC).
    ''' </Remarks>

        Public Function UpdateInstrumentToBatchReceivedStatus() As Boolean

        Dim strSQL As String = "SELECT StatusCodeWhenBatchReceived FROM tlkpBatchType WHERE BatchTypeID = " _
                               & Me.Batch.BatchTypeID.ToString
        Return UpdateInstrumentStatusWithScalarSQLResult(strSQL)
    End Function

#End Region
End Class
