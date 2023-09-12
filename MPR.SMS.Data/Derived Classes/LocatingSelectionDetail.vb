'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses


Public Class LocatingSelectionDetail
    Inherits VwLocatingSelectionDetail

#Region "Private Fields"

    Private ReadOnly mobjLocatingSelectionDetails As DataTable
    Private ReadOnly mstrlocatingstatus As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Relationship belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property LocatingSelectionDetails As DataTable
        Get
            Return mobjLocatingSelectionDetails
        End Get
    End Property

#End Region

#Region "Constructors"

    Public Sub New()

        Dim objLocatingSelectionDetail As New VwLocatingSelectionDetail

        objLocatingSelectionDetail.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatingSelectionDetail.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLocatingSelectionDetails As DataTable = objLocatingSelectionDetail.SelectAll()
        mobjLocatingSelectionDetails = objLocatingSelectionDetails

        objLocatingSelectionDetail.ConnectionProvider = Nothing
    End Sub

    Public Sub New(strlocatingstatus As String)

        mstrlocatingstatus = strlocatingstatus

        Dim objLocatingSelectionDetail As New VwLocatingSelectionDetail

        Me.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            Me.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLocatingSelectionDetails As DataTable = SelectAllWlocatingstatusLogic()
        mobjLocatingSelectionDetails = objLocatingSelectionDetails

        objLocatingSelectionDetail.ConnectionProvider = Nothing
    End Sub

#End Region

#Region "Private Methods"

    Private Function SelectAllWlocatingstatusLogic() As DataTable

        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_vwLocatingSelectionDetail_SelectAllWlocatingstatusLogic]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("vwLocatingSelectionDetail")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try
            cmdToExecute.Parameters.Add(New SqlParameter("@locatingstatus", SqlDbType.VarChar, 4,
                                                         ParameterDirection.Input, True, 0, 0, "",
                                                         DataRowVersion.Proposed, mstrlocatingstatus))
            cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True,
                                                         0, 0, "", DataRowVersion.Proposed, mErrorCode))

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
                        "Stored Procedure 'SMS_vwLocatingSelectionDetail_SelectAllWLocatingStatusLogic' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "SMS_vwLocatingSelectionDetail::SelectAllWLocatingStatusLogic::Error occured." + Environment.NewLine +
                    Environment.NewLine + ex.Message, ex)
        Finally
            If mblnConnectionIsLocal Then
                ' Close connection.
                mobjSqlConnection.Close()
            End If
            cmdToExecute.Dispose()
            adapter.Dispose()
        End Try
    End Function

#End Region
End Class
