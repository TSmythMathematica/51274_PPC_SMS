' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:35 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpCoders.
	''' </summary>

	Public Class TlkpCoders
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _isActive As SqlBoolean
		Private _isActiveOld As SqlBoolean

		Private _coderId As SqlInt32
		Private _coderIdOld As SqlInt32

		Private _lastName As SqlString
		Private _lastNameOld As SqlString
		Private _fullName As SqlString
		Private _fullNameOld As SqlString
		Private _firstName As SqlString
		Private _firstNameOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpCoders constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpCoders class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpCoders class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpCoders class.
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

			
			_coderId = New SqlInt32(CType(objDataRow("CoderId"), Integer))
			
			_coderIdOld = _coderId
			
			If objDataRow("FirstName") Is System.DBNull.Value Then
				_firstName = New SqlString("")
			Else
				_firstName = New SqlString(CType(objDataRow("FirstName"), String))
			End If
			
			_firstNameOld = _firstName
			
			If objDataRow("LastName") Is System.DBNull.Value Then
				_lastName = New SqlString("")
			Else
				_lastName = New SqlString(CType(objDataRow("LastName"), String))
			End If
			
			_lastNameOld = _lastName
			
			If objDataRow("FullName") Is System.DBNull.Value Then
				_fullName = New SqlString("")
			Else
				_fullName = New SqlString(CType(objDataRow("FullName"), String))
			End If
			
			_fullNameOld = _fullName
			
			If objDataRow("IsActive") Is System.DBNull.Value Then
				_isActive = New SqlBoolean(False)
			Else
				_isActive = New SqlBoolean(CType(objDataRow("IsActive"), Boolean))
			End If
			
			_isActiveOld = _isActive
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_coderId = New SqlInt32(CType(objSqlDataReader("CoderId"), Integer))
			
			_coderIdOld = _coderId
			
			If objSqlDataReader("FirstName") Is System.DBNull.Value Then
				_firstName = New SqlString("")
			Else
				_firstName = New SqlString(CType(objSqlDataReader("FirstName"), String))
			End If
			
			_firstNameOld = _firstName
			
			If objSqlDataReader("LastName") Is System.DBNull.Value Then
				_lastName = New SqlString("")
			Else
				_lastName = New SqlString(CType(objSqlDataReader("LastName"), String))
			End If
			
			_lastNameOld = _lastName
			
			If objSqlDataReader("FullName") Is System.DBNull.Value Then
				_fullName = New SqlString("")
			Else
				_fullName = New SqlString(CType(objSqlDataReader("FullName"), String))
			End If
			
			_fullNameOld = _fullName
			
			If objSqlDataReader("IsActive") Is System.DBNull.Value Then
				_isActive = New SqlBoolean(False)
			Else
				_isActive = New SqlBoolean(CType(objSqlDataReader("IsActive"), Boolean))
			End If
			
			_isActiveOld = _isActive
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_firstName = New SqlString("")
			_firstNameOld = _firstName
			
			_lastName = New SqlString("")
			_lastNameOld = _lastName
			
			_fullName = New SqlString("")
			_fullNameOld = _fullName
			
			_isActive = New SqlBoolean(False)
			_isActiveOld = _isActive
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_coderId = _coderIdOld
			
			_firstName = _firstNameOld
			
			_lastName = _lastNameOld
			
			_fullName = _fullNameOld
			
			_isActive = _isActiveOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>FirstName. May be SqlString.Null</LI>
		'''		 <LI>LastName. May be SqlString.Null</LI>
		'''		 <LI>FullName. May be SqlString.Null</LI>
		'''		 <LI>IsActive. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>CoderId</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpCoders_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _firstName))
				cmdToExecute.Parameters.Add(New SqlParameter("@LastName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _lastName))
				cmdToExecute.Parameters.Add(New SqlParameter("@FullName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _fullName))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActive", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActive))
				cmdToExecute.Parameters.Add(new SqlParameter("@CoderId", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _coderId))
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
				_coderId = CType(cmdToExecute.Parameters.Item("@CoderId").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpCoders_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpCoders::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>CoderId</LI>
		'''		 <LI>FirstName. May be SqlString.Null</LI>
		'''		 <LI>LastName. May be SqlString.Null</LI>
		'''		 <LI>FullName. May be SqlString.Null</LI>
		'''		 <LI>IsActive. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpCoders_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@CoderId", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _coderId))
				cmdToExecute.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _firstName))
				cmdToExecute.Parameters.Add(New SqlParameter("@LastName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _lastName))
				cmdToExecute.Parameters.Add(New SqlParameter("@FullName", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _fullName))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActive", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActive))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpCoders_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpCoders::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>CoderId</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpCoders_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@CoderId", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _coderId))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpCoders_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpCoders::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>CoderId</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>CoderId</LI>
		'''		 <LI>FirstName</LI>
		'''		 <LI>LastName</LI>
		'''		 <LI>FullName</LI>
		'''		 <LI>IsActive</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpCoders_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpCoders")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@CoderId", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _coderId))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpCoders_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpCoders::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpCoders_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpCoders")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpCoders_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpCoders::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [CoderId]() As SqlInt32
			Get
				Return _coderId
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _coderId.Equals(Value) Then
					If _coderIdOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _coderId.Equals(_coderIdOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim coderIdTmp As SqlInt32 = Value
				If coderIdTmp.IsNull Then
					Throw New NullValueException("CoderId", "CoderId can't be NULL")
				End If
				_coderId = Value
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
		Public Property [FirstName]() As SqlString
			Get
				Return _firstName
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _firstName.IsNull Then
					CurrentValue = _firstName.Value
				End If
				If Not _firstNameOld.IsNull Then
					OldValue = _firstNameOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_firstName = Value
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
		Public Property [LastName]() As SqlString
			Get
				Return _lastName
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _lastName.IsNull Then
					CurrentValue = _lastName.Value
				End If
				If Not _lastNameOld.IsNull Then
					OldValue = _lastNameOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_lastName = Value
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
		Public Property [FullName]() As SqlString
			Get
				Return _fullName
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _fullName.IsNull Then
					CurrentValue = _fullName.Value
				End If
				If Not _fullNameOld.IsNull Then
					OldValue = _fullNameOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_fullName = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="((0))", _
		IsTimeStamp:=False)> _
		Public Property [IsActive]() As SqlBoolean
			Get
				Return _isActive
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isActive.Equals(Value) Then
					If _isActiveOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isActive.Equals(_isActiveOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isActive = Value
			End Set
		End Property

#End Region

	End Class
End Namespace
