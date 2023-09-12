' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:39 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpSocialNetworkStatus.
	''' </summary>

	Public Class TlkpSocialNetworkStatus
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _isActiveRequest As SqlBoolean
		Private _isActiveRequestOld As SqlBoolean

		Private _sortOrder As SqlInt32
		Private _sortOrderOld As SqlInt32
		Private _socialNetworkStatusID As SqlInt32
		Private _socialNetworkStatusIDOld As SqlInt32

		Private _description As SqlString
		Private _descriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpSocialNetworkStatus constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpSocialNetworkStatus class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpSocialNetworkStatus class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpSocialNetworkStatus class.
		''' </summary>
		''' <param name="objSqlDataReader">
		''' An SqlDataReader object that that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objSqlDataReader As SqlDataReader)

			FillProperties(objSqlDataReader)

		End Sub

		Friend Sub ResetModified()

			Dim pi As PropertyInfo

			Dim myType As System.Type = System.Type.GetType(Me.GetType().BaseType.FullName)

			Dim piCollection() As PropertyInfo = myType.GetProperties()

			For Each pi In piCollection
				If myType.BaseType.GetProperty(pi.Name) Is Nothing Then
					Dim strFieldName As String = "_" + pi.Name.SubString(0, 1).ToLower() + pi.Name.SubString(1, pi.Name.Length - 1) + "Old"
					Dim fi As FieldInfo = myType.GetField(strFieldName, BindingFlags.Instance Or BindingFlags.DeclaredOnly Or BindingFlags.NonPublic)
					If Not fi Is Nothing Then
						fi.SetValue(Me, pi.GetValue(Me, Nothing))
					End If
				End If
			Next

			ModifiedColumnCount = 0

		End Sub
			
		Private Sub FillProperties(ByVal objDataRow As DataRow)

			
			_socialNetworkStatusID = New SqlInt32(CType(objDataRow("SocialNetworkStatusID"), Integer))
			
			_socialNetworkStatusIDOld = _socialNetworkStatusID
			
			If objDataRow("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objDataRow("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objDataRow("SortOrder") Is System.DBNull.Value Then
				_sortOrder = SqlInt32.Null
			Else
				_sortOrder = New SqlInt32(CType(objDataRow("SortOrder"), Integer))
			End If
			
			_sortOrderOld = _sortOrder
			
			If objDataRow("IsActiveRequest") Is System.DBNull.Value Then
				_isActiveRequest = New SqlBoolean(False)
			Else
				_isActiveRequest = New SqlBoolean(CType(objDataRow("IsActiveRequest"), Boolean))
			End If
			
			_isActiveRequestOld = _isActiveRequest
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_socialNetworkStatusID = New SqlInt32(CType(objSqlDataReader("SocialNetworkStatusID"), Integer))
			
			_socialNetworkStatusIDOld = _socialNetworkStatusID
			
			If objSqlDataReader("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objSqlDataReader("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objSqlDataReader("SortOrder") Is System.DBNull.Value Then
				_sortOrder = SqlInt32.Null
			Else
				_sortOrder = New SqlInt32(CType(objSqlDataReader("SortOrder"), Integer))
			End If
			
			_sortOrderOld = _sortOrder
			
			If objSqlDataReader("IsActiveRequest") Is System.DBNull.Value Then
				_isActiveRequest = New SqlBoolean(False)
			Else
				_isActiveRequest = New SqlBoolean(CType(objSqlDataReader("IsActiveRequest"), Boolean))
			End If
			
			_isActiveRequestOld = _isActiveRequest
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			
			_isActiveRequest = New SqlBoolean(False)
			_isActiveRequestOld = _isActiveRequest
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_socialNetworkStatusID = _socialNetworkStatusIDOld
			
			_description = _descriptionOld
			
			_sortOrder = _sortOrderOld
			
			_isActiveRequest = _isActiveRequestOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>SortOrder. May be SqlInt32.Null</LI>
		'''		 <LI>IsActiveRequest. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>SocialNetworkStatusID</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSocialNetworkStatus_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _sortOrder))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActiveRequest", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActiveRequest))
				cmdToExecute.Parameters.Add(new SqlParameter("@SocialNetworkStatusID", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _socialNetworkStatusID))
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

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
				cmdToExecute.ExecuteNonQuery()
				_socialNetworkStatusID = CType(cmdToExecute.Parameters.Item("@SocialNetworkStatusID").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpSocialNetworkStatus_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSocialNetworkStatus::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
			End Try
		End Function

		''' <summary>
		''' Updates an existing row in the table.
		''' </summary>
		''' <returns>True if succeeded, otherwise an exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>SocialNetworkStatusID</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>SortOrder. May be SqlInt32.Null</LI>
		'''		 <LI>IsActiveRequest. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSocialNetworkStatus_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@SocialNetworkStatusID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _socialNetworkStatusID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@SortOrder", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _sortOrder))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActiveRequest", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActiveRequest))
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

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
				cmdToExecute.ExecuteNonQuery()
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpSocialNetworkStatus_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSocialNetworkStatus::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
			End Try
		End Function
 
		''' <summary>
		''' Purpose: Delete method. This method will Delete one existing row in the database, based on the Primary Key.
		''' </summary>
		''' <returns>True if succeeded, otherwise an Exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>SocialNetworkStatusID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSocialNetworkStatus_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@SocialNetworkStatusID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _socialNetworkStatusID))
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

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
				cmdToExecute.ExecuteNonQuery()
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpSocialNetworkStatus_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSocialNetworkStatus::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
			End Try
		End Function


		''' <summary>
		''' Select an existing row from the database based on the Primary Key.
		''' </summary>
		''' <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>SocialNetworkStatusID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>SocialNetworkStatusID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>SortOrder</LI>
		'''		 <LI>IsActiveRequest</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSocialNetworkStatus_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpSocialNetworkStatus")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@SocialNetworkStatusID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _socialNetworkStatusID))
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

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
					Throw New Exception("Stored Procedure 'wiz_tlkpSocialNetworkStatus_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSocialNetworkStatus::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		''' Selects all rows from the table.
		''' </summary>
		''' <returns>A DataTable if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function SelectAll() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSocialNetworkStatus_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpSocialNetworkStatus")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, mErrorCode))

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
					Throw New Exception("Stored Procedure 'wiz_tlkpSocialNetworkStatus_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSocialNetworkStatus::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
				adapter.Dispose()
			End Try
		End Function


#Region "Public Properties"

		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=True, _
		IsNullable:=False, _
		IsPrimaryKey:=True, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [SocialNetworkStatusID]() As SqlInt32
			Get
				Return _socialNetworkStatusID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _socialNetworkStatusID.Equals(Value) Then
					If _socialNetworkStatusIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _socialNetworkStatusID.Equals(_socialNetworkStatusIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim socialNetworkStatusIDTmp As SqlInt32 = Value
				If socialNetworkStatusIDTmp.IsNull Then
					Throw New NullValueException("SocialNetworkStatusID", "SocialNetworkStatusID can't be NULL")
				End If
				_socialNetworkStatusID = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [Description]() As SqlString
			Get
				Return _description
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _description.IsNull Then
					CurrentValue = _description.Value
				End If
				If Not _descriptionOld.IsNull Then
					OldValue = _descriptionOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_description = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [SortOrder]() As SqlInt32
			Get
				Return _sortOrder
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _sortOrder.Equals(Value) Then
					If _sortOrderOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _sortOrder.Equals(_sortOrderOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_sortOrder = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [IsActiveRequest]() As SqlBoolean
			Get
				Return _isActiveRequest
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isActiveRequest.Equals(Value) Then
					If _isActiveRequestOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isActiveRequest.Equals(_isActiveRequestOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isActiveRequest = Value
			End Set
		End Property

#End Region

	End Class
End Namespace