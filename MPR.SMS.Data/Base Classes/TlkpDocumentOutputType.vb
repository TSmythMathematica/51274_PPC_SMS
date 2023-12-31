' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:36 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpDocumentOutputType.
	''' </summary>

	Public Class TlkpDocumentOutputType
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _documentOutputTypeID As SqlInt32
		Private _documentOutputTypeIDOld As SqlInt32

		Private _fileExtension As SqlString
		Private _fileExtensionOld As SqlString
		Private _outputFormat As SqlString
		Private _outputFormatOld As SqlString
		Private _description As SqlString
		Private _descriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpDocumentOutputType constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpDocumentOutputType class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpDocumentOutputType class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpDocumentOutputType class.
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

			
			_documentOutputTypeID = New SqlInt32(CType(objDataRow("DocumentOutputTypeID"), Integer))
			
			_documentOutputTypeIDOld = _documentOutputTypeID
			
			If objDataRow("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objDataRow("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objDataRow("OutputFormat") Is System.DBNull.Value Then
				_outputFormat = New SqlString("")
			Else
				_outputFormat = New SqlString(CType(objDataRow("OutputFormat"), String))
			End If
			
			_outputFormatOld = _outputFormat
			
			If objDataRow("FileExtension") Is System.DBNull.Value Then
				_fileExtension = New SqlString("")
			Else
				_fileExtension = New SqlString(CType(objDataRow("FileExtension"), String))
			End If
			
			_fileExtensionOld = _fileExtension
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_documentOutputTypeID = New SqlInt32(CType(objSqlDataReader("DocumentOutputTypeID"), Integer))
			
			_documentOutputTypeIDOld = _documentOutputTypeID
			
			If objSqlDataReader("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objSqlDataReader("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objSqlDataReader("OutputFormat") Is System.DBNull.Value Then
				_outputFormat = New SqlString("")
			Else
				_outputFormat = New SqlString(CType(objSqlDataReader("OutputFormat"), String))
			End If
			
			_outputFormatOld = _outputFormat
			
			If objSqlDataReader("FileExtension") Is System.DBNull.Value Then
				_fileExtension = New SqlString("")
			Else
				_fileExtension = New SqlString(CType(objSqlDataReader("FileExtension"), String))
			End If
			
			_fileExtensionOld = _fileExtension
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			_outputFormat = New SqlString("")
			_outputFormatOld = _outputFormat
			
			_fileExtension = New SqlString("")
			_fileExtensionOld = _fileExtension
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_documentOutputTypeID = _documentOutputTypeIDOld
			
			_description = _descriptionOld
			
			_outputFormat = _outputFormatOld
			
			_fileExtension = _fileExtensionOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>DocumentOutputTypeID</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>OutputFormat. May be SqlString.Null</LI>
		'''		 <LI>FileExtension. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpDocumentOutputType_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@DocumentOutputTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _documentOutputTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 255, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@OutputFormat", SqlDbType.Char, 4, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _outputFormat))
				cmdToExecute.Parameters.Add(New SqlParameter("@FileExtension", SqlDbType.VarChar, 4, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _fileExtension))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpDocumentOutputType_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpDocumentOutputType::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>DocumentOutputTypeID</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>OutputFormat. May be SqlString.Null</LI>
		'''		 <LI>FileExtension. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpDocumentOutputType_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@DocumentOutputTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _documentOutputTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 255, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@OutputFormat", SqlDbType.Char, 4, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _outputFormat))
				cmdToExecute.Parameters.Add(New SqlParameter("@FileExtension", SqlDbType.VarChar, 4, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _fileExtension))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpDocumentOutputType_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpDocumentOutputType::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>DocumentOutputTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpDocumentOutputType_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@DocumentOutputTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _documentOutputTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpDocumentOutputType_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpDocumentOutputType::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>DocumentOutputTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>DocumentOutputTypeID</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>OutputFormat</LI>
		'''		 <LI>FileExtension</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpDocumentOutputType_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpDocumentOutputType")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@DocumentOutputTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _documentOutputTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpDocumentOutputType_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpDocumentOutputType::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpDocumentOutputType_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpDocumentOutputType")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpDocumentOutputType_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpDocumentOutputType::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [DocumentOutputTypeID]() As SqlInt32
			Get
				Return _documentOutputTypeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _documentOutputTypeID.Equals(Value) Then
					If _documentOutputTypeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _documentOutputTypeID.Equals(_documentOutputTypeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim documentOutputTypeIDTmp As SqlInt32 = Value
				If documentOutputTypeIDTmp.IsNull Then
					Throw New NullValueException("DocumentOutputTypeID", "DocumentOutputTypeID can't be NULL")
				End If
				_documentOutputTypeID = Value
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
		Public Property [OutputFormat]() As SqlString
			Get
				Return _outputFormat
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _outputFormat.IsNull Then
					CurrentValue = _outputFormat.Value
				End If
				If Not _outputFormatOld.IsNull Then
					OldValue = _outputFormatOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_outputFormat = Value
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
		Public Property [FileExtension]() As SqlString
			Get
				Return _fileExtension
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _fileExtension.IsNull Then
					CurrentValue = _fileExtension.Value
				End If
				If Not _fileExtensionOld.IsNull Then
					OldValue = _fileExtensionOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_fileExtension = Value
			End Set
		End Property

#End Region

	End Class
End Namespace
