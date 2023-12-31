' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:39 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpRelationshipType.
	''' </summary>

	Public Class TlkpRelationshipType
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _isActiveInSmartField As SqlBoolean
		Private _isActiveInSmartFieldOld As SqlBoolean
		Private _isContact As SqlBoolean
		Private _isContactOld As SqlBoolean
		Private _isRespondent As SqlBoolean
		Private _isRespondentOld As SqlBoolean
		Private _isPrimarySampleMember As SqlBoolean
		Private _isPrimarySampleMemberOld As SqlBoolean

		Private _entityTypeID As SqlInt32
		Private _entityTypeIDOld As SqlInt32
		Private _relationshipTypeID As SqlInt32
		Private _relationshipTypeIDOld As SqlInt32
		Private _guardianRank As SqlInt32
		Private _guardianRankOld As SqlInt32

		Private _relationshipType As SqlString
		Private _relationshipTypeOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpRelationshipType constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpRelationshipType class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpRelationshipType class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpRelationshipType class.
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

			
			_relationshipTypeID = New SqlInt32(CType(objDataRow("RelationshipTypeID"), Integer))
			
			_relationshipTypeIDOld = _relationshipTypeID
			
			_relationshipType = New SqlString(CType(objDataRow("RelationshipType"), String))
			
			_relationshipTypeOld = _relationshipType
			
			If objDataRow("IsRespondent") Is System.DBNull.Value Then
				_isRespondent = New SqlBoolean(False)
			Else
				_isRespondent = New SqlBoolean(CType(objDataRow("IsRespondent"), Boolean))
			End If
			
			_isRespondentOld = _isRespondent
			
			If objDataRow("IsPrimarySampleMember") Is System.DBNull.Value Then
				_isPrimarySampleMember = New SqlBoolean(False)
			Else
				_isPrimarySampleMember = New SqlBoolean(CType(objDataRow("IsPrimarySampleMember"), Boolean))
			End If
			
			_isPrimarySampleMemberOld = _isPrimarySampleMember
			
			If objDataRow("IsContact") Is System.DBNull.Value Then
				_isContact = New SqlBoolean(False)
			Else
				_isContact = New SqlBoolean(CType(objDataRow("IsContact"), Boolean))
			End If
			
			_isContactOld = _isContact
			
			If objDataRow("GuardianRank") Is System.DBNull.Value Then
				_guardianRank = SqlInt32.Null
			Else
				_guardianRank = New SqlInt32(CType(objDataRow("GuardianRank"), Integer))
			End If
			
			_guardianRankOld = _guardianRank
			
			If objDataRow("EntityTypeID") Is System.DBNull.Value Then
				_entityTypeID = SqlInt32.Null
			Else
				_entityTypeID = New SqlInt32(CType(objDataRow("EntityTypeID"), Integer))
			End If
			
			_entityTypeIDOld = _entityTypeID
			
			If objDataRow("IsActiveInSmartField") Is System.DBNull.Value Then
				_isActiveInSmartField = New SqlBoolean(False)
			Else
				_isActiveInSmartField = New SqlBoolean(CType(objDataRow("IsActiveInSmartField"), Boolean))
			End If
			
			_isActiveInSmartFieldOld = _isActiveInSmartField
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_relationshipTypeID = New SqlInt32(CType(objSqlDataReader("RelationshipTypeID"), Integer))
			
			_relationshipTypeIDOld = _relationshipTypeID
			
			_relationshipType = New SqlString(CType(objSqlDataReader("RelationshipType"), String))
			
			_relationshipTypeOld = _relationshipType
			
			If objSqlDataReader("IsRespondent") Is System.DBNull.Value Then
				_isRespondent = New SqlBoolean(False)
			Else
				_isRespondent = New SqlBoolean(CType(objSqlDataReader("IsRespondent"), Boolean))
			End If
			
			_isRespondentOld = _isRespondent
			
			If objSqlDataReader("IsPrimarySampleMember") Is System.DBNull.Value Then
				_isPrimarySampleMember = New SqlBoolean(False)
			Else
				_isPrimarySampleMember = New SqlBoolean(CType(objSqlDataReader("IsPrimarySampleMember"), Boolean))
			End If
			
			_isPrimarySampleMemberOld = _isPrimarySampleMember
			
			If objSqlDataReader("IsContact") Is System.DBNull.Value Then
				_isContact = New SqlBoolean(False)
			Else
				_isContact = New SqlBoolean(CType(objSqlDataReader("IsContact"), Boolean))
			End If
			
			_isContactOld = _isContact
			
			If objSqlDataReader("GuardianRank") Is System.DBNull.Value Then
				_guardianRank = SqlInt32.Null
			Else
				_guardianRank = New SqlInt32(CType(objSqlDataReader("GuardianRank"), Integer))
			End If
			
			_guardianRankOld = _guardianRank
			
			If objSqlDataReader("EntityTypeID") Is System.DBNull.Value Then
				_entityTypeID = SqlInt32.Null
			Else
				_entityTypeID = New SqlInt32(CType(objSqlDataReader("EntityTypeID"), Integer))
			End If
			
			_entityTypeIDOld = _entityTypeID
			
			If objSqlDataReader("IsActiveInSmartField") Is System.DBNull.Value Then
				_isActiveInSmartField = New SqlBoolean(False)
			Else
				_isActiveInSmartField = New SqlBoolean(CType(objSqlDataReader("IsActiveInSmartField"), Boolean))
			End If
			
			_isActiveInSmartFieldOld = _isActiveInSmartField
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_relationshipType = New SqlString("")
			_relationshipTypeOld = _relationshipType
			
			_isRespondent = New SqlBoolean(False)
			_isRespondentOld = _isRespondent
			
			_isPrimarySampleMember = New SqlBoolean(False)
			_isPrimarySampleMemberOld = _isPrimarySampleMember
			
			_isContact = New SqlBoolean(False)
			_isContactOld = _isContact
			
			
			
			_isActiveInSmartField = New SqlBoolean(False)
			_isActiveInSmartFieldOld = _isActiveInSmartField
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_relationshipTypeID = _relationshipTypeIDOld
			
			_relationshipType = _relationshipTypeOld
			
			_isRespondent = _isRespondentOld
			
			_isPrimarySampleMember = _isPrimarySampleMemberOld
			
			_isContact = _isContactOld
			
			_guardianRank = _guardianRankOld
			
			_entityTypeID = _entityTypeIDOld
			
			_isActiveInSmartField = _isActiveInSmartFieldOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>RelationshipType</LI>
		'''		 <LI>IsRespondent. May be SqlBoolean.Null</LI>
		'''		 <LI>IsPrimarySampleMember. May be SqlBoolean.Null</LI>
		'''		 <LI>IsContact. May be SqlBoolean.Null</LI>
		'''		 <LI>GuardianRank. May be SqlInt32.Null</LI>
		'''		 <LI>EntityTypeID. May be SqlInt32.Null</LI>
		'''		 <LI>IsActiveInSmartField. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>RelationshipTypeID</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpRelationshipType_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@RelationshipType", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _relationshipType))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsRespondent", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isRespondent))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsPrimarySampleMember", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isPrimarySampleMember))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsContact", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isContact))
				cmdToExecute.Parameters.Add(New SqlParameter("@GuardianRank", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _guardianRank))
				cmdToExecute.Parameters.Add(New SqlParameter("@EntityTypeID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _entityTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActiveInSmartField", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActiveInSmartField))
				cmdToExecute.Parameters.Add(new SqlParameter("@RelationshipTypeID", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _relationshipTypeID))
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
				_relationshipTypeID = CType(cmdToExecute.Parameters.Item("@RelationshipTypeID").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpRelationshipType_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpRelationshipType::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>RelationshipTypeID</LI>
		'''		 <LI>RelationshipType</LI>
		'''		 <LI>IsRespondent. May be SqlBoolean.Null</LI>
		'''		 <LI>IsPrimarySampleMember. May be SqlBoolean.Null</LI>
		'''		 <LI>IsContact. May be SqlBoolean.Null</LI>
		'''		 <LI>GuardianRank. May be SqlInt32.Null</LI>
		'''		 <LI>EntityTypeID. May be SqlInt32.Null</LI>
		'''		 <LI>IsActiveInSmartField. May be SqlBoolean.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpRelationshipType_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@RelationshipTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _relationshipTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@RelationshipType", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _relationshipType))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsRespondent", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isRespondent))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsPrimarySampleMember", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isPrimarySampleMember))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsContact", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isContact))
				cmdToExecute.Parameters.Add(New SqlParameter("@GuardianRank", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _guardianRank))
				cmdToExecute.Parameters.Add(New SqlParameter("@EntityTypeID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _entityTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@IsActiveInSmartField", SqlDbType.Bit, 1, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _isActiveInSmartField))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpRelationshipType_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpRelationshipType::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>RelationshipTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpRelationshipType_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@RelationshipTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _relationshipTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpRelationshipType_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpRelationshipType::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>RelationshipTypeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>RelationshipTypeID</LI>
		'''		 <LI>RelationshipType</LI>
		'''		 <LI>IsRespondent</LI>
		'''		 <LI>IsPrimarySampleMember</LI>
		'''		 <LI>IsContact</LI>
		'''		 <LI>GuardianRank</LI>
		'''		 <LI>EntityTypeID</LI>
		'''		 <LI>IsActiveInSmartField</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpRelationshipType_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpRelationshipType")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@RelationshipTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _relationshipTypeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpRelationshipType_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpRelationshipType::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpRelationshipType_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpRelationshipType")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpRelationshipType_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpRelationshipType::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [RelationshipTypeID]() As SqlInt32
			Get
				Return _relationshipTypeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _relationshipTypeID.Equals(Value) Then
					If _relationshipTypeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _relationshipTypeID.Equals(_relationshipTypeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim relationshipTypeIDTmp As SqlInt32 = Value
				If relationshipTypeIDTmp.IsNull Then
					Throw New NullValueException("RelationshipTypeID", "RelationshipTypeID can't be NULL")
				End If
				_relationshipTypeID = Value
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
		Public Property [RelationshipType]() As SqlString
			Get
				Return _relationshipType
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _relationshipType.IsNull Then
					CurrentValue = _relationshipType.Value
				End If
				If Not _relationshipTypeOld.IsNull Then
					OldValue = _relationshipTypeOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				Dim relationshipTypeTmp As SqlString = Value
				If relationshipTypeTmp.IsNull Then
					Throw New NullValueException("RelationshipType", "RelationshipType can't be NULL")
				End If
				_relationshipType = Value
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
		Public Property [IsRespondent]() As SqlBoolean
			Get
				Return _isRespondent
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isRespondent.Equals(Value) Then
					If _isRespondentOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isRespondent.Equals(_isRespondentOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isRespondent = Value
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
		Public Property [IsPrimarySampleMember]() As SqlBoolean
			Get
				Return _isPrimarySampleMember
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isPrimarySampleMember.Equals(Value) Then
					If _isPrimarySampleMemberOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isPrimarySampleMember.Equals(_isPrimarySampleMemberOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isPrimarySampleMember = Value
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
		Public Property [IsContact]() As SqlBoolean
			Get
				Return _isContact
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isContact.Equals(Value) Then
					If _isContactOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isContact.Equals(_isContactOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isContact = Value
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
		Public Property [GuardianRank]() As SqlInt32
			Get
				Return _guardianRank
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _guardianRank.Equals(Value) Then
					If _guardianRankOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _guardianRank.Equals(_guardianRankOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_guardianRank = Value
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
		DefaultValue:="((1))", _
		IsTimeStamp:=False)> _
		Public Property [IsActiveInSmartField]() As SqlBoolean
			Get
				Return _isActiveInSmartField
			End Get
			Set(ByVal Value As SqlBoolean)
				If Not _isActiveInSmartField.Equals(Value) Then
					If _isActiveInSmartFieldOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isActiveInSmartField.Equals(_isActiveInSmartFieldOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isActiveInSmartField = Value
			End Set
		End Property

#End Region

	End Class
End Namespace
