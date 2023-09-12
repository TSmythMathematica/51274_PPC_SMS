' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:36 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpEntityType.
	''' </summary>

	Public Class TlkpEntityType
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _isActive As SqlBoolean
		Private _isActiveOld As SqlBoolean
		Private _entityAsSample As SqlBoolean
		Private _entityAsSampleOld As SqlBoolean

		Private _entityTypeID As SqlInt32
		Private _entityTypeIDOld As SqlInt32

		Private _description As SqlString
		Private _descriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpEntityType constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpEntityType class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpEntityType class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpEntityType class.
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

			
			_entityTypeID = New SqlInt32(CType(objDataRow("EntityTypeID"), Integer))
			
			_entityTypeIDOld = _entityTypeID
			
			If objDataRow("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objDataRow("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objDataRow("IsActive") Is System.DBNull.Value Then
				_isActive = New SqlBoolean(False)
			Else
				_isActive = New SqlBoolean(CType(objDataRow("IsActive"), Boolean))
			End If
			
			_isActiveOld = _isActive
			
			If objDataRow("EntityAsSample") Is System.DBNull.Value Then
				_entityAsSample = New SqlBoolean(False)
			Else
				_entityAsSample = New SqlBoolean(CType(objDataRow("EntityAsSample"), Boolean))
			End If
			
			_entityAsSampleOld = _entityAsSample
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_entityTypeID = New SqlInt32(CType(objSqlDataReader("EntityTypeID"), Integer))
			
			_entityTypeIDOld = _entityTypeID
			
			If objSqlDataReader("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objSqlDataReader("Description"), String))
			End If
			
			_descriptionOld = _description
			
			If objSqlDataReader("IsActive") Is System.DBNull.Value Then
				_isActive = New SqlBoolean(False)
			Else
				_isActive = New SqlBoolean(CType(objSqlDataReader("IsActive"), Boolean))
			End If
			
			_isActiveOld = _isActive
			
			If objSqlDataReader("EntityAsSample") Is System.DBNull.Value Then
				_entityAsSample = New SqlBoolean(False)
			Else
				_entityAsSample = New SqlBoolean(CType(objSqlDataReader("EntityAsSample"), Boolean))
			End If
			
			_entityAsSampleOld = _entityAsSample
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			_isActive = New SqlBoolean(False)
			_isActiveOld = _isActive
			
			_entityAsSample = New SqlBoolean(False)
			_entityAsSampleOld = _entityAsSample
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_entityTypeID = _entityTypeIDOld
			
			_description = _descriptionOld
			
			_isActive = _isActiveOld
			
			_entityAsSample = _entityAsSampleOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>EntityTypeID</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>IsActive. May be SqlBoolean.Null</LI>
		'''		 <LI>EntityAsSample. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpEntityType_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@EntityTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _entityTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActive", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActive))
				cmdToExecute.Parameters.Add(New SqlParameter("@EntityAsSample", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _entityAsSample))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpEntityType_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpEntityType::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpEntityType_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpEntityType")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpEntityType_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpEntityType::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [EntityTypeID]() As SqlInt32
			Get
				Return _entityTypeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _entityTypeID.Equals(Value) Then
					If _entityTypeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _entityTypeID.Equals(_entityTypeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim entityTypeIDTmp As SqlInt32 = Value
				If entityTypeIDTmp.IsNull Then
					Throw New NullValueException("EntityTypeID", "EntityTypeID can't be NULL")
				End If
				_entityTypeID = Value
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


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [EntityAsSample]() As SqlBoolean
			Get
				Return _entityAsSample
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _entityAsSample.Equals(Value) Then
					If _entityAsSampleOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _entityAsSample.Equals(_entityAsSampleOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_entityAsSample = Value
			End Set
		End Property

#End Region

	End Class
End Namespace