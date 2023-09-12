' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:38 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpMelissaResultCode.
	''' </summary>

	Public Class TlkpMelissaResultCode
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _isClean As SqlInt32
		Private _isCleanOld As SqlInt32
		Private _resultCodeTypeID As SqlInt32
		Private _resultCodeTypeIDOld As SqlInt32
		Private _resultCodeID As SqlInt32
		Private _resultCodeIDOld As SqlInt32

		Private _notes As SqlString
		Private _notesOld As SqlString
		Private _description As SqlString
		Private _descriptionOld As SqlString
		Private _resultCode As SqlString
		Private _resultCodeOld As SqlString
		Private _shortDescription As SqlString
		Private _shortDescriptionOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpMelissaResultCode constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCode class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCode class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpMelissaResultCode class.
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

			
			_resultCodeID = New SqlInt32(CType(objDataRow("ResultCodeID"), Integer))
			
			_resultCodeIDOld = _resultCodeID
			
			_resultCode = New SqlString(CType(objDataRow("ResultCode"), String))
			
			_resultCodeOld = _resultCode
			
			_shortDescription = New SqlString(CType(objDataRow("ShortDescription"), String))
			
			_shortDescriptionOld = _shortDescription
			
			If objDataRow("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objDataRow("Description"), String))
			End If
			
			_descriptionOld = _description
			
			_resultCodeTypeID = New SqlInt32(CType(objDataRow("ResultCodeTypeID"), Integer))
			
			_resultCodeTypeIDOld = _resultCodeTypeID
			
			If objDataRow("Notes") Is System.DBNull.Value Then
				_notes = New SqlString("")
			Else
				_notes = New SqlString(CType(objDataRow("Notes"), String))
			End If
			
			_notesOld = _notes
			
			If objDataRow("isClean") Is System.DBNull.Value Then
				_isClean = SqlInt32.Null
			Else
				_isClean = New SqlInt32(CType(objDataRow("isClean"), Integer))
			End If
			
			_isCleanOld = _isClean
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_resultCodeID = New SqlInt32(CType(objSqlDataReader("ResultCodeID"), Integer))
			
			_resultCodeIDOld = _resultCodeID
			
			_resultCode = New SqlString(CType(objSqlDataReader("ResultCode"), String))
			
			_resultCodeOld = _resultCode
			
			_shortDescription = New SqlString(CType(objSqlDataReader("ShortDescription"), String))
			
			_shortDescriptionOld = _shortDescription
			
			If objSqlDataReader("Description") Is System.DBNull.Value Then
				_description = New SqlString("")
			Else
				_description = New SqlString(CType(objSqlDataReader("Description"), String))
			End If
			
			_descriptionOld = _description
			
			_resultCodeTypeID = New SqlInt32(CType(objSqlDataReader("ResultCodeTypeID"), Integer))
			
			_resultCodeTypeIDOld = _resultCodeTypeID
			
			If objSqlDataReader("Notes") Is System.DBNull.Value Then
				_notes = New SqlString("")
			Else
				_notes = New SqlString(CType(objSqlDataReader("Notes"), String))
			End If
			
			_notesOld = _notes
			
			If objSqlDataReader("isClean") Is System.DBNull.Value Then
				_isClean = SqlInt32.Null
			Else
				_isClean = New SqlInt32(CType(objSqlDataReader("isClean"), Integer))
			End If
			
			_isCleanOld = _isClean
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_resultCode = New SqlString("")
			_resultCodeOld = _resultCode
			
			_shortDescription = New SqlString("")
			_shortDescriptionOld = _shortDescription
			
			_description = New SqlString("")
			_descriptionOld = _description
			
			
			_notes = New SqlString("")
			_notesOld = _notes
			
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_resultCodeID = _resultCodeIDOld
			
			_resultCode = _resultCodeOld
			
			_shortDescription = _shortDescriptionOld
			
			_description = _descriptionOld
			
			_resultCodeTypeID = _resultCodeTypeIDOld
			
			_notes = _notesOld
			
			_isClean = _isCleanOld
			
			ModifiedColumnCount = 0
			
		End Sub


		''' <summary>
		''' Inserts a new row into the database.
		''' </summary>
		''' <returns>True if successful, otherwise an exception is thrown.</returns>
		''' <remarks>
		''' Properties needed for this method:
		''' <UL>
		'''		 <LI>ResultCode</LI>
		'''		 <LI>ShortDescription</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>Notes. May be SqlString.Null</LI>
		'''		 <LI>IsClean. May be SqlInt32.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ResultCodeID</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCode", SqlDbType.VarChar, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _resultCode))
				cmdToExecute.Parameters.Add(New SqlParameter("@ShortDescription", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _shortDescription))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 200, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _notes))
				cmdToExecute.Parameters.Add(New SqlParameter("@isClean", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _isClean))
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeID", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _resultCodeID))
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
				_resultCodeID = CType(cmdToExecute.Parameters.Item("@ResultCodeID").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeID</LI>
		'''		 <LI>ResultCode</LI>
		'''		 <LI>ShortDescription</LI>
		'''		 <LI>Description. May be SqlString.Null</LI>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>Notes. May be SqlString.Null</LI>
		'''		 <LI>IsClean. May be SqlInt32.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCode", SqlDbType.VarChar, 5, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _resultCode))
				cmdToExecute.Parameters.Add(New SqlParameter("@ShortDescription", SqlDbType.VarChar, 100, ParameterDirection.Input, False, 0, 0, "", DataRowVersion.Proposed, _shortDescription))
				cmdToExecute.Parameters.Add(New SqlParameter("@Description", SqlDbType.VarChar, 500, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _description))
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Notes", SqlDbType.VarChar, 200, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _notes))
				cmdToExecute.Parameters.Add(New SqlParameter("@isClean", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _isClean))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
			End Try
		End Function

		''' <summary>
		''' Update method for updating one or more rows using the Foreign Key 'ResultCodeTypeID.
		''' It will reset the field 'ResultCodeTypeID' in
		''' all rows which have as value for this field the value as set in property 'ResultCodeTypeIDOld' to 
		''' the value as set in property 'ResultCodeTypeID'.
		''' </summary>
		''' <returns>True if succeeded, otherwise an exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method: 
		''' <UL>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>ResultCodeTypeIDOld</LI>
		''' </UL>
		''' Properties set after a succesful call of this method: 
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Public Function UpdateAllWResultCodeTypeIDLogic() As Boolean
			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_UpdateAllWResultCodeTypeIDLogic]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class' connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeTypeID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeID))
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeTypeIDOld", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeTypeIDOld))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_UpdateAllWResultCodeTypeIDLogic' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::UpdateAllWResultCodeTypeIDLogic::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@ResultCodeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>ResultCodeID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>ResultCodeID</LI>
		'''		 <LI>ResultCode</LI>
		'''		 <LI>ShortDescription</LI>
		'''		 <LI>Description</LI>
		'''		 <LI>ResultCodeTypeID</LI>
		'''		 <LI>Notes</LI>
		'''		 <LI>IsClean</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpMelissaResultCode")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@ResultCodeID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _resultCodeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpMelissaResultCode")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		''' Selects one or more rows from the database based on the Foreign Key 'ResultCodeTypeID'
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
		''' </UL>
		''' </remarks>
		Public Function SelectAllWResultCodeTypeIDLogic() As DataTable
			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpMelissaResultCode_SelectAllWResultCodeTypeIDLogic]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpMelissaResultCode")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpMelissaResultCode_SelectAllWResultCodeTypeIDLogic' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpMelissaResultCode::SelectAllWResultCodeTypeIDLogic::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [ResultCodeID]() As SqlInt32
			Get
				Return _resultCodeID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _resultCodeID.Equals(Value) Then
					If _resultCodeIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _resultCodeID.Equals(_resultCodeIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim resultCodeIDTmp As SqlInt32 = Value
				If resultCodeIDTmp.IsNull Then
					Throw New NullValueException("ResultCodeID", "ResultCodeID can't be NULL")
				End If
				_resultCodeID = Value
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
		Public Property [ResultCode]() As SqlString
			Get
				Return _resultCode
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _resultCode.IsNull Then
					CurrentValue = _resultCode.Value
				End If
				If Not _resultCodeOld.IsNull Then
					OldValue = _resultCodeOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				Dim resultCodeTmp As SqlString = Value
				If resultCodeTmp.IsNull Then
					Throw New NullValueException("ResultCode", "ResultCode can't be NULL")
				End If
				_resultCode = Value
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
		Public Property [ShortDescription]() As SqlString
			Get
				Return _shortDescription
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _shortDescription.IsNull Then
					CurrentValue = _shortDescription.Value
				End If
				If Not _shortDescriptionOld.IsNull Then
					OldValue = _shortDescriptionOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				Dim shortDescriptionTmp As SqlString = Value
				If shortDescriptionTmp.IsNull Then
					Throw New NullValueException("ShortDescription", "ShortDescription can't be NULL")
				End If
				_shortDescription = Value
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
		IsForeignKey:=True, _
		IsIdentity:=False, _
		IsNullable:=False, _
		IsPrimaryKey:=False, _
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
		Protected Property [ResultCodeTypeIDOld]() As SqlInt32
			Get
				Return _resultCodeTypeIDOld
			End Get
			Set(ByVal Value As SqlInt32)
				Dim resultCodeTypeIDOldTmp As SqlInt32 = Value
				If resultCodeTypeIDOldTmp.IsNull Then
					Throw New NullValueException("ResultCodeTypeIDOld", "ResultCodeTypeIDOld can't be NULL")
				End If
				_resultCodeTypeIDOld = Value
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


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=False, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [IsClean]() As SqlInt32
			Get
				Return _isClean
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _isClean.Equals(Value) Then
					If _isCleanOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _isClean.Equals(_isCleanOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_isClean = Value
			End Set
		End Property

#End Region

	End Class
End Namespace