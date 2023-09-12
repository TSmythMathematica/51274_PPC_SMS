'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses


''' <summary>
'''     Provides methods for accessing, creating and manipulating a Coder object.
''' </summary>

    Public Class Coder
    Inherits TlkpCoders

#Region "Events"

    Event OnInsert(objCoder As Coder)

    Event OnUpdate(objCoder As Coder)

    Event OnDelete(objCoder As Coder)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Coder belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Coder belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the displayable Status: "Coder - Name".
    ''' </summary>
    Public ReadOnly Property DisplayName As String

        Get
            Dim Name As String
            If Me.FirstName.ToString.Trim <> "" Then
                Name = Me.FirstName.ToString.Trim
                If Me.LastName.ToString.Trim <> "" Then
                    Name = Name & " " & Me.LastName.ToString.Trim
                End If
                Return Name
            ElseIf Me.LastName.ToString.Trim <> "" Then
                Return Me.LastName.ToString.Trim
            Else
                Return ""
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Coder class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Coder class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    Public Sub New(objCoder As Coder)

        MyBase.New()

        MyBase.CoderId = objCoder.CoderId


        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            MyBase.SelectOne()
            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

    Public Sub New(coderid As Integer)

        MyBase.New()

        MyBase.CoderId = coderid


        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            MyBase.SelectOne()
            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Coder class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Coder is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Coder into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Coder object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the Coder

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a Coder object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the Coder

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Coder from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the Coder

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function


    'Public Function SelectAllByType(ByVal instrumenttypeid As Integer) As DataTable

    ' THIS IS PROJECT SPECIFIC CODE used on Babyfaces to limit coder pool on an instrument basis.  
    'I left this in the base but commented out because it could be useful to other projects later on but is not 
    'generalized enough to leave in the base for all projects.

    '    Dim cmdToExecute As SqlCommand = New SqlCommand()
    '    cmdToExecute.CommandText = "dbo.[BabyFaces_tlkpCoders_SelectAllbyType]"
    '    cmdToExecute.CommandType = CommandType.StoredProcedure
    '    Dim toReturn As DataTable = New DataTable("tlkpCoders")
    '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)
    '    Dim intcodertypeid As Integer

    '    ' Use base class connection object
    '    cmdToExecute.Connection = mobjSqlConnection

    '    Try
    '        Select Case instrumenttypeid
    '            Case 49
    '                intcodertypeid = 1
    '            Case 50
    '                intcodertypeid = 2
    '            Case 51
    '                intcodertypeid = 3
    '        End Select
    '        cmdToExecute.Parameters.Add(New SqlParameter("@CoderTypeId", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, intcodertypeid))
    '        cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

    '        If mblnConnectionIsLocal Then
    '            ' Open connection.
    '            mobjSqlConnection.ConnectionString = Me.ConnectionString
    '            mobjSqlConnection.Open()
    '        Else
    '            If mConnectionProvider.IsTransactionPending Then
    '                cmdToExecute.Transaction = mConnectionProvider.CurrentTransaction
    '            End If
    '        End If

    '        ' Execute query.
    '        adapter.Fill(toReturn)
    '        mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

    '        If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
    '            ' Throw error.
    '            Throw New Exception("Stored Procedure 'BabyFaces_tlkpCoders_SelectAllbyType' reported the ErrorCode: " & mErrorCode.ToString())
    '        End If

    '        Return toReturn
    '    Catch ex As Exception
    '        ' Some error occured. Bubble it to caller and encapsulate Exception object
    '        Throw New Exception("TlkpCoders::SelectAllByType::Error occured." + Environment.NewLine + Environment.NewLine + ex.Message, ex)
    '    Finally
    '        If mblnConnectionIsLocal Then
    '            ' Close connection.
    '            mobjSqlConnection.Close()
    '        End If
    '        cmdToExecute.Dispose()
    '        adapter.Dispose()
    '    End Try
    'End Function


    'Public Function SelectAllByTypePlusConsensus(ByVal instrumenttypeid As Integer) As DataTable

    ' THIS IS PROJECT SPECIFIC CODE used on Babyfaces to limit coder pool on an instrument basis.  
    'I left this in the base but commented out because it could be useful to other projects later on but is not 
    'generalized enough to leave in the base for all projects.

    '    Dim cmdToExecute As SqlCommand = New SqlCommand()
    '    cmdToExecute.CommandText = "dbo.[BabyFaces_tlkpCoders_SelectAllbyTypePlusConsensus]"
    '    cmdToExecute.CommandType = CommandType.StoredProcedure
    '    Dim toReturn As DataTable = New DataTable("tlkpCoders")
    '    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)
    '    Dim intcodertypeid As Integer

    '    ' Use base class connection object
    '    cmdToExecute.Connection = mobjSqlConnection

    '    Try
    '        Select Case instrumenttypeid
    '            Case 49
    '                intcodertypeid = 1
    '            Case 50
    '                intcodertypeid = 2
    '            Case 51
    '                intcodertypeid = 3
    '        End Select
    '        cmdToExecute.Parameters.Add(New SqlParameter("@CoderTypeId", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, intcodertypeid))
    '        cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

    '        If mblnConnectionIsLocal Then
    '            ' Open connection.
    '            mobjSqlConnection.ConnectionString = Me.ConnectionString
    '            mobjSqlConnection.Open()
    '        Else
    '            If mConnectionProvider.IsTransactionPending Then
    '                cmdToExecute.Transaction = mConnectionProvider.CurrentTransaction
    '            End If
    '        End If

    '        ' Execute query.
    '        adapter.Fill(toReturn)
    '        mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

    '        If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
    '            ' Throw error.
    '            Throw New Exception("Stored Procedure 'BabyFaces_tlkpCoders_SelectAllbyTypePlusConsensus' reported the ErrorCode: " & mErrorCode.ToString())
    '        End If

    '        Return toReturn
    '    Catch ex As Exception
    '        ' Some error occured. Bubble it to caller and encapsulate Exception object
    '        Throw New Exception("TlkpCoders::SelectAllByTypePlusConsensus::Error occured." + Environment.NewLine + Environment.NewLine + ex.Message, ex)
    '    Finally
    '        If mblnConnectionIsLocal Then
    '            ' Close connection.
    '            mobjSqlConnection.Close()
    '        End If
    '        cmdToExecute.Dispose()
    '        adapter.Dispose()
    '    End Try
    'End Function

    Public Function SelectAllPlusConsensus() As DataTable

        'Pulls all coder assignment options except MASTER Coder (included Consensus coder and Supervisor Review)

        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_tlkpCoders_SelectAllPlusConsensus]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("tlkpCoders")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try

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
                        "Stored Procedure 'SMS_tlkpCoders_SelectAllPlusConsensus' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "TlkpCoders::SelectAllPlusConsensus::Error occured." + Environment.NewLine + Environment.NewLine +
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

    Public Function SelectAllActual() As DataTable

        'Pulls ONLY actual coders, no consensus, master or sup review

        Dim cmdToExecute As SqlCommand = New SqlCommand()
        cmdToExecute.CommandText = "dbo.[SMS_tlkpCoders_SelectAllActual]"
        cmdToExecute.CommandType = CommandType.StoredProcedure
        Dim toReturn As DataTable = New DataTable("tlkpCoders")
        Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

        ' Use base class connection object
        cmdToExecute.Connection = mobjSqlConnection

        Try

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
                        "Stored Procedure 'SMS_tlkpCoders_SelectAllActual' reported the ErrorCode: " &
                        mErrorCode.ToString())
            End If

            Return toReturn
        Catch ex As Exception
            ' Some error occured. Bubble it to caller and encapsulate Exception object
            Throw _
                New Exception(
                    "TlkpCoders::SelectAllActual::Error occured." + Environment.NewLine + Environment.NewLine +
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


#End Region
End Class
