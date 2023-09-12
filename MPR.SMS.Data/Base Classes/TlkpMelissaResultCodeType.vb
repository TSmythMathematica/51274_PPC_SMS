' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:38 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpMelissaResultCodeType.
	''' </summary>

	Public Class TlkpMelissaResultCodeType
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _resultCodeTypeID As SqlInt32
		Private _resultCodeTypeIDOld As SqlInt32

		Private _notes As SqlString
		Private _notesOld As SqlString
		Private _prefix As SqlString
		Private _prefixOld As SqlString
		Private _description As SqlString
		Private _descriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpMelissaResultCodeType constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCodeType class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCodeType class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCodeType class.
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

			
			_resultCodeTypeID = New SqlInt32(CType(objDataRow("ResultCodeTypeID"), Integer))
			
			_resultCodeTypeIDOld = _resultCodeTypeID
			
			_description = New SqlString(CType(objDataRow("Description"), String))
			
			_descriptionOld = _description
			
			_prefix = New SqlString(CType(objDataRow("Prefix"), String))
			
			_prefixOld = _prefix
			
			If objDataRow("Notes") Is System.DBNull.Value Then
				_notes = New SqlString("")
			Else
				_notes = New SqlString(CType(objDataRow("Notes"), String))
			End If
			
			_notesOld = _notes
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_resultCodeTypeID = New SqlInt32(CType(objSqlDataReader("ResultCodeTypeID"), Integer))
			
			_resultCodeTypeIDOld = _resultCodeTypeID
			
			_description = New SqlString(CType(objSqlDataReader("Description"), String))
			
			_descriptionOld = _description
			
			_prefix = New SqlString(CType(objSqlDataReader("Prefix"), String))
			
			_prefixOld = _prefix
			
			If objSqlDataReader("Notes") Is System.DBNull.Value Then
				_notes = New SqlString("")
			Else
				_notes = New SqlString(CType(objSqlDataReader("Notes"), String))
			End If
			
			_notesOld = _notes
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			_prefix = New SqlString("")
			_prefixOld = _prefix
			
			_notes = New SqlString("")
			_notesOld = _notes
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_resultCodeTypeID = _resultCodeTypeIDOld
			
			_description = _descriptionOld
			
			_prefix = _prefixOld
			
			_notes = _notesOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>Description</LI>
		'''		 <LI>Prefix</LI>
		'''		 <LI>Notes. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCodeType_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@Prefix", SqlDbType.VarChar, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _prefix))
				cmdToExecute.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 200, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _notes))
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
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
				_resultCodeTypeID = CType(cmdToExecute.Parameters.Item("@ResultCodeTypeID").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCodeType_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCodeType::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>Prefix</LI>
		'''		 <LI>Notes. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCodeType_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@Prefix", SqlDbType.VarChar, 2, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _prefix))
				cmdToExecute.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 200, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _notes))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCodeType_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCodeType::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCodeType_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCodeType_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCodeType::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>Prefix</LI>
		'''		 <LI>Notes</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCodeType_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpMelissaResultCodeType")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCodeType_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCodeType::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCodeType_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpMelissaResultCodeType")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCodeType_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCodeType::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [ResultCodeTypeID]() As SqlInt32
			Get
				Return _resultCodeTypeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _resultCodeTypeID.Equals(Value) Then
					If _resultCodeTypeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _resultCodeTypeID.Equals(_resultCodeTypeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim resultCodeTypeIDTmp As SqlInt32 = Value
				If resultCodeTypeIDTmp.IsNull Then
					Throw New NullValueException("ResultCodeTypeID", "ResultCodeTypeID can't be NULL")
				End If
				_resultCodeTypeID = Value
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
		IsNullable:=False, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [Prefix]() As SqlString
			Get
				Return _prefix
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _prefix.IsNull Then
					CurrentValue = _prefix.Value
				End If
				If Not _prefixOld.IsNull Then
					OldValue = _prefixOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				Dim prefixTmp As SqlString = Value
				If prefixTmp.IsNull Then
					Throw New NullValueException("Prefix", "Prefix can't be NULL")
				End If
				_prefix = Value
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
		Public Property [Notes]() As SqlString
			Get
				Return _notes
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _notes.IsNull Then
					CurrentValue = _notes.Value
				End If
				If Not _notesOld.IsNull Then
					OldValue = _notesOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_notes = Value
			End Set
		End Property

#End Region

	End Class
End Namespace