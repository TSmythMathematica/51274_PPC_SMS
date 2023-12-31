' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:39 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpSourceType.
	''' </summary>

	Public Class TlkpSourceType
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _assignInField As SqlBoolean
		Private _assignInFieldOld As SqlBoolean

		Private _sourceTypeID As SqlInt32
		Private _sourceTypeIDOld As SqlInt32

		Private _ranking As SqlInt16
		Private _rankingOld As SqlInt16

		Private _description As SqlString
		Private _descriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpSourceType constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpSourceType class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpSourceType class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpSourceType class.
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

			
			_sourceTypeID = New SqlInt32(CType(objDataRow("SourceTypeID"), Integer))
			
			_sourceTypeIDOld = _sourceTypeID
			
			_description = New SqlString(CType(objDataRow("Description"), String))
			
			_descriptionOld = _description
			
			If objDataRow("AssignInField") Is System.DBNull.Value Then
				_assignInField = New SqlBoolean(False)
			Else
				_assignInField = New SqlBoolean(CType(objDataRow("AssignInField"), Boolean))
			End If
			
			_assignInFieldOld = _assignInField
			
			If objDataRow("Ranking") Is System.DBNull.Value Then
				_ranking = SqlInt16.Null
			Else
				_ranking = New SqlInt16(CType(objDataRow("Ranking"), Short))
			End If
			
			_rankingOld = _ranking
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_sourceTypeID = New SqlInt32(CType(objSqlDataReader("SourceTypeID"), Integer))
			
			_sourceTypeIDOld = _sourceTypeID
			
			_description = New SqlString(CType(objSqlDataReader("Description"), String))
			
			_descriptionOld = _description
			
			If objSqlDataReader("AssignInField") Is System.DBNull.Value Then
				_assignInField = New SqlBoolean(False)
			Else
				_assignInField = New SqlBoolean(CType(objSqlDataReader("AssignInField"), Boolean))
			End If
			
			_assignInFieldOld = _assignInField
			
			If objSqlDataReader("Ranking") Is System.DBNull.Value Then
				_ranking = SqlInt16.Null
			Else
				_ranking = New SqlInt16(CType(objSqlDataReader("Ranking"), Short))
			End If
			
			_rankingOld = _ranking
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			_assignInField = New SqlBoolean(False)
			_assignInFieldOld = _assignInField
			
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_sourceTypeID = _sourceTypeIDOld
			
			_description = _descriptionOld
			
			_assignInField = _assignInFieldOld
			
			_ranking = _rankingOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>SourceTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>AssignInField. May be SqlBoolean.Null</LI>
		'''		 <LI>Ranking. May be SqlInt16.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSourceType_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@SourceTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _sourceTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@AssignInField", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _assignInField))
				cmdToExecute.Parameters.Add(New SqlParameter("@Ranking", SqlDbType.SmallInt, 2, ParameterDirection.Input, True, 5, 0, "", DataRowVersion.Proposed, _ranking))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpSourceType_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSourceType::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>SourceTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>AssignInField. May be SqlBoolean.Null</LI>
		'''		 <LI>Ranking. May be SqlInt16.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSourceType_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@SourceTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _sourceTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@AssignInField", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _assignInField))
				cmdToExecute.Parameters.Add(New SqlParameter("@Ranking", SqlDbType.SmallInt, 2, ParameterDirection.Input, True, 5, 0, "", DataRowVersion.Proposed, _ranking))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpSourceType_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSourceType::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>SourceTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSourceType_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@SourceTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _sourceTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpSourceType_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSourceType::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>SourceTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>SourceTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>AssignInField</LI>
		'''		 <LI>Ranking</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSourceType_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpSourceType")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@SourceTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _sourceTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpSourceType_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSourceType::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpSourceType_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpSourceType")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpSourceType_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpSourceType::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		IsIdentity:=False, _
		IsNullable:=False, _
		IsPrimaryKey:=True, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [SourceTypeID]() As SqlInt32
			Get
				Return _sourceTypeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _sourceTypeID.Equals(Value) Then
					If _sourceTypeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _sourceTypeID.Equals(_sourceTypeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim sourceTypeIDTmp As SqlInt32 = Value
				If sourceTypeIDTmp.IsNull Then
					Throw New NullValueException("SourceTypeID", "SourceTypeID can't be NULL")
				End If
				_sourceTypeID = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=False, _
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
				Dim descriptionTmp As SqlString = Value
				If descriptionTmp.IsNull Then
					Throw New NullValueException("Description", "Description can't be NULL")
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
		Public Property [AssignInField]() As SqlBoolean
			Get
				Return _assignInField
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _assignInField.Equals(Value) Then
					If _assignInFieldOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _assignInField.Equals(_assignInFieldOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_assignInField = Value
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
		Public Property [Ranking]() As SqlInt16
			Get
				Return _ranking
			End Get
			Set(ByVal Value As SqlInt16)
				If Not _ranking.Equals(Value) Then
					If _rankingOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _ranking.Equals(_rankingOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_ranking = Value
			End Set
		End Property

#End Region

	End Class
End Namespace
