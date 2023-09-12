' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:41 AM

Imports System
Imports System.Data
Imports System.Collections
Imports System.Configuration
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Provides an SqlConnection object that may be shared among data-access objects to
	''' allow transactioning.
	''' </summary>

	Public Class ConnectionProvider
		Implements IDisposable

#Region "Private Fields"

		Private mblnDisposed As Boolean

		Private mlbnTransactionPending As Boolean

		Private mobjSqlConnection As SqlConnection

		Private mobjCurrentTransaction As SqlTransaction

		Private mSavePoints As ArrayList

        Private mstrCurrentUser As String

#End Region

#Region "Constructors"

		''' <summary>
		''' Initializes a new instance of the ConnectionProvider class.
		''' </summary>

		Public Sub New()

            Me.New(Nothing)

		End Sub

		''' <summary>
		''' Initializes a new instance of the ConnectionProvider class.
		''' </summary>
		''' <param name="ConnectionString">
		''' The connection string that will be established for this ConnectionProvider.
		''' </param>

		Public Sub New(ByVal ConnectionString As String)

			mblnDisposed = False

			mSavePoints = New ArrayList()

			mlbnTransactionPending = False

			mobjCurrentTransaction = Nothing

            If ConnectionString Is Nothing
                mobjSqlConnection = New SqlConnection()
            Else
    			mobjSqlConnection = New SqlConnection(ConnectionString)
            End If

		End Sub

#End Region

#Region "Public Methods"

		''' <summary>
		''' Implements the IDisposable.Dispose method
		''' </summary>

		Public Overloads Sub Dispose() Implements IDisposable.Dispose

			Dispose(True)

			GC.SuppressFinalize(Me)

		End Sub

		''' <summary>
		''' Implements the Dispose functionality.
		''' </summary>

		Protected Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)

			If Not mblnDisposed Then

				If isDisposing Then

					If Not (mobjCurrentTransaction Is Nothing) Then
						mobjCurrentTransaction.Dispose()
						mobjCurrentTransaction = Nothing
					End If

					If Not (mobjSqlConnection Is Nothing) Then
						mobjSqlConnection.Close()
						mobjSqlConnection.Dispose()
						mobjSqlConnection = Nothing
					End If

				End If
			End If

			mblnDisposed = True

		End Sub

		''' <summary>
		''' Opens the connection object.
		''' </summary>
		''' <returns>
		''' True if successful, otherwise an exception is thrown.
		''' </returns>

		Public Function OpenConnection() As Boolean

			Try

				If (mobjSqlConnection.State And ConnectionState.Open) > 0 Then
					Throw New Exception("ConnectionProvider.OpenConnection: Connection is already open.")
				End If

				mSavePoints.Clear()
				mobjSqlConnection.Open()
				mlbnTransactionPending = False

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

		''' <summary>
		''' Starts a new transaction.
		''' </summary>
		''' <param name="strTransactionName">
		''' Name to be assigned to the transaction.
		''' </param>
		''' <returns>
		'''	True if successful, otherwise an exception is thrown.
		''' </returns>

		Public Function BeginTransaction(ByVal strTransactionName As String) As Boolean

			Try

				If mlbnTransactionPending Then
					Throw New Exception("ConnectionProvider.BeginTransaction: Nested transactions are not allowed.")
				End If

				If (mobjSqlConnection.State And ConnectionState.Open) = 0 Then
					Throw New Exception("ConnectionProvider.BeginTransaction: Connection is not open.")
				End If

				' Begin the transaction

				mobjCurrentTransaction = mobjSqlConnection.BeginTransaction(IsolationLevel.ReadCommitted, strTransactionName)

				mlbnTransactionPending = True

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

		''' <summary>
		''' Commits a pending transaction.
		''' </summary>
		''' <returns>
		''' True if succesful, otherwise and exception is thrown
		''' </returns>

		Public Function CommitTransaction() As Boolean

			Try

				If Not mlbnTransactionPending Then
					Throw New Exception("ConectionProvider.CommitTransaction: No transaction is pending.")
				End If

				If (mobjSqlConnection.State And ConnectionState.Open) = 0 Then
					Throw New Exception("ConnectionProvider.CommitTransaction: Connection is not open.")
				End If

				' Commit the transaction

				mobjCurrentTransaction.Commit()
				mlbnTransactionPending = False
				mobjCurrentTransaction.Dispose()
				mobjCurrentTransaction = Nothing
				mSavePoints.Clear()

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

		''' <summary>
		''' Aborts a pending transaction or rolls back to a named save point. 
		''' </summary>
		''' <param name="strTransactionName">
		''' Name of transaction to roll back or the name of save point.</param>
		''' <returns>
		''' True if succesful, otherwise an exception is thrown.
		''' </returns>

		Public Function RollbackTransaction(ByVal strTransactionName As String) As Boolean

			Try

				If Not mlbnTransactionPending Then
					Throw New Exception("ConnectionProvider.RollbackTransaction: No transaction is pending.")
				End If

				If (mobjSqlConnection.State And ConnectionState.Open) = 0 Then
					Throw New Exception("ConnectionProvider.RollbackTransaction: Connection is not open.")
				End If

				' Rollback the transaction

				mobjCurrentTransaction.Rollback(strTransactionName)

				' If this isn't a savepoint, clean up the complete transaction

				If Not mSavePoints.Contains(strTransactionName) Then
					mlbnTransactionPending = False
					mobjCurrentTransaction.Dispose()
					mobjCurrentTransaction = Nothing
					mSavePoints.Clear()
				End If

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

		''' <summary>
		''' Saves a pending transaction.
		''' When a rollback is issued, the caller can rollback to this savepoint or roll back the complete transaction.
		''' </summary>
		''' <param name="strSavePointName">
		''' Name of the save point to save the pending transaction as.</param>
		''' <returns>
		''' True, if succesful, otherwise an exception is thrown.
		''' </returns>
		''' <remarks>
		''' When a rollback is issued, you can rollback to this savepoint or roll back the complete transaction.
		''' </remarks> 

		Public Function SaveTransaction(ByVal strSavePointName As String) As Boolean

			Try

				If Not mlbnTransactionPending Then
					Throw New Exception("ConnectionProvider.SaveTransaction: No transaction is pending.")
				End If

				If (mobjSqlConnection.State And ConnectionState.Open) = 0 Then
					Throw New Exception("SaveTransaction::Connection is not open.")
				End If

				' Save the pending transaction

				mobjCurrentTransaction.Save(strSavePointName)

				mSavePoints.Add(strSavePointName)

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

		''' <summary>
		''' Closes the open connection.
		''' </summary>
		''' <param name="blnCommit">
		''' Indicates whether a pending transaction is commited (True) or aborted (False).
        ''' </param>
		''' <returns>
		''' True if succesful, False if connection is not open.
		''' </returns>

		Public Function CloseConnection(ByVal blnCommit As Boolean) As Boolean

			Try

				If (mobjSqlConnection.State And ConnectionState.Open) = 0 Then
					Return False
				End If

				If mlbnTransactionPending Then

					If blnCommit Then
						' Commit the pending transaction
						mobjCurrentTransaction.Commit()
					Else
						' Rollback the pending transaction
						mobjCurrentTransaction.Rollback()
					End If

					mlbnTransactionPending = False
					mobjCurrentTransaction.Dispose()
					mobjCurrentTransaction = Nothing
					mSavePoints.Clear()

				End If

				' Close the connection

				mobjSqlConnection.Close()

				Return True

			Catch ex As Exception

				Throw ex

			End Try

		End Function

#End Region

#Region "Public Properties"

		''' <summary>
		''' Gets the current transaction.
		''' </summary>
		''' <value>
		''' The current transaction or Nothing (null).
		''' </value>

		Public ReadOnly Property CurrentTransaction() As SqlTransaction
			Get
				Return mobjCurrentTransaction
			End Get
		End Property

		''' <summary>
		''' Gets whether a transaction is pending.
		''' </summary>
		''' <value>
		''' True is a transaction is pending, otherwise False. 
		''' </value>

		Public ReadOnly Property IsTransactionPending() As Boolean
			Get
				Return mlbnTransactionPending
			End Get
		End Property

		''' <summary>
		''' Gets the connection object.
		''' </summary>
		''' <value>
		''' The SqlConnection object.
		''' </value>

		Public ReadOnly Property Connection() As SqlConnection
			Get
				Return mobjSqlConnection
			End Get
		End Property

		''' <summary>
		''' Gets or sets the connection string.
		''' </summary>
		''' <value>
		''' The SqlConnection object's connection string.
		''' </value>

		Public Property ConnectionString() As String
			Get
				Return mobjSqlConnection.ConnectionString
			End Get
			Set(ByVal Value As String)
				mobjSqlConnection.ConnectionString = Value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the current user.
		''' </summary>
		''' <value>
		''' The current user.
		''' </value>

        Public Property CurrentUser() As String
            
            Get
                If Not mstrCurrentUser Is Nothing Then
                    Return mstrCurrentUser
                ElseIf System.Threading.Thread.CurrentPrincipal Is Nothing Then
                    Return String.Empty
                Else
                    Return System.Threading.Thread.CurrentPrincipal.Identity.Name
                End If
            End Get
            Set(ByVal Value As String)
                If Value Is Nothing Then
                    mstrCurrentUser = Nothing
                Else
                    mstrCurrentUser = Value.Trim()
                End If
            End Set

        End Property

#End Region

	End Class

End Namespace