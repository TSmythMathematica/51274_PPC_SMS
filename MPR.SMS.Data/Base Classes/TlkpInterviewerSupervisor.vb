' Generated by the MPR.Data.Access.Wizard on Friday, April 16, 2021, 11:56:37 AM

Imports System
Imports System.Data
Imports System.Reflection
Imports System.Data.SqlTypes
Imports System.Data.SqlClient

Namespace BaseClasses

	''' <summary>
	''' Data access class for the table named tlkpInterviewerSupervisor.
	''' </summary>

	Public Class TlkpInterviewerSupervisor
		Inherits DBInteractionBase

#Region "Private Fields"

		Private _region As SqlInt32
		Private _regionOld As SqlInt32
		Private _interviewerRegionID As SqlInt32
		Private _interviewerRegionIDOld As SqlInt32
		Private _interviewerSupervisorID As SqlInt32
		Private _interviewerSupervisorIDOld As SqlInt32

		Private _employeeID As SqlString
		Private _employeeIDOld As SqlString
		Private _password As SqlString
		Private _passwordOld As SqlString
		Private _firstName As SqlString
		Private _firstNameOld As SqlString
		Private _lastName As SqlString
		Private _lastNameOld As SqlString
		Private _userName As SqlString
		Private _userNameOld As SqlString

#End Region

		''' <overloads>
		''' The TlkpInterviewerSupervisor constructor has two overloads.
		''' </overloads>
		''' <summary>
		''' Initializes a new instance of the TlkpInterviewerSupervisor class.
		''' </summary>

		Public Sub New()

			FillDefaultProperties()

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpInterviewerSupervisor class.
		''' </summary>
		''' <param name="objDataRow">
		''' A DataRow object that contains the values that will be used to initialize the object.
		''' </param>

		Public Sub New(ByVal objDataRow As DataRow)

			FillProperties(objDataRow)

		End Sub

		''' <summary>
		''' Initializes a new instance of the TlkpInterviewerSupervisor class.
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

			
			_interviewerSupervisorID = New SqlInt32(CType(objDataRow("InterviewerSupervisorID"), Integer))
			
			_interviewerSupervisorIDOld = _interviewerSupervisorID
			
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
			
			If objDataRow("UserName") Is System.DBNull.Value Then
				_userName = New SqlString("")
			Else
				_userName = New SqlString(CType(objDataRow("UserName"), String))
			End If
			
			_userNameOld = _userName
			
			If objDataRow("Password") Is System.DBNull.Value Then
				_password = New SqlString("")
			Else
				_password = New SqlString(CType(objDataRow("Password"), String))
			End If
			
			_passwordOld = _password
			
			If objDataRow("InterviewerRegionID") Is System.DBNull.Value Then
				_interviewerRegionID = SqlInt32.Null
			Else
				_interviewerRegionID = New SqlInt32(CType(objDataRow("InterviewerRegionID"), Integer))
			End If
			
			_interviewerRegionIDOld = _interviewerRegionID
			
			If objDataRow("Region") Is System.DBNull.Value Then
				_region = SqlInt32.Null
			Else
				_region = New SqlInt32(CType(objDataRow("Region"), Integer))
			End If
			
			_regionOld = _region
			
			If objDataRow("EmployeeID") Is System.DBNull.Value Then
				_employeeID = New SqlString("")
			Else
				_employeeID = New SqlString(CType(objDataRow("EmployeeID"), String))
			End If
			
			_employeeIDOld = _employeeID
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillProperties(ByVal objSqlDataReader As SqlDataReader)

			
			_interviewerSupervisorID = New SqlInt32(CType(objSqlDataReader("InterviewerSupervisorID"), Integer))
			
			_interviewerSupervisorIDOld = _interviewerSupervisorID
			
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
			
			If objSqlDataReader("UserName") Is System.DBNull.Value Then
				_userName = New SqlString("")
			Else
				_userName = New SqlString(CType(objSqlDataReader("UserName"), String))
			End If
			
			_userNameOld = _userName
			
			If objSqlDataReader("Password") Is System.DBNull.Value Then
				_password = New SqlString("")
			Else
				_password = New SqlString(CType(objSqlDataReader("Password"), String))
			End If
			
			_passwordOld = _password
			
			If objSqlDataReader("InterviewerRegionID") Is System.DBNull.Value Then
				_interviewerRegionID = SqlInt32.Null
			Else
				_interviewerRegionID = New SqlInt32(CType(objSqlDataReader("InterviewerRegionID"), Integer))
			End If
			
			_interviewerRegionIDOld = _interviewerRegionID
			
			If objSqlDataReader("Region") Is System.DBNull.Value Then
				_region = SqlInt32.Null
			Else
				_region = New SqlInt32(CType(objSqlDataReader("Region"), Integer))
			End If
			
			_regionOld = _region
			
			If objSqlDataReader("EmployeeID") Is System.DBNull.Value Then
				_employeeID = New SqlString("")
			Else
				_employeeID = New SqlString(CType(objSqlDataReader("EmployeeID"), String))
			End If
			
			_employeeIDOld = _employeeID
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Private Sub FillDefaultProperties()

			
			
			_firstName = New SqlString("")
			_firstNameOld = _firstName
			
			_lastName = New SqlString("")
			_lastNameOld = _lastName
			
			_userName = New SqlString("")
			_userNameOld = _userName
			
			_password = New SqlString("")
			_passwordOld = _password
			
			
			
			_employeeID = New SqlString("")
			_employeeIDOld = _employeeID
			
			ModifiedColumnCount = 0
			
		End Sub

			
		Friend Sub RestoreModified()

			
			_interviewerSupervisorID = _interviewerSupervisorIDOld
			
			_firstName = _firstNameOld
			
			_lastName = _lastNameOld
			
			_userName = _userNameOld
			
			_password = _passwordOld
			
			_interviewerRegionID = _interviewerRegionIDOld
			
			_region = _regionOld
			
			_employeeID = _employeeIDOld
			
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
		'''		 <LI>UserName. May be SqlString.Null</LI>
		'''		 <LI>Password. May be SqlString.Null</LI>
		'''		 <LI>InterviewerRegionID. May be SqlInt32.Null</LI>
		'''		 <LI>Region. May be SqlInt32.Null</LI>
		'''		 <LI>EmployeeID. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>InterviewerSupervisorID</LI>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>

		Overrides Public Function Insert() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_Insert]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _firstName))
				cmdToExecute.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _lastName))
				cmdToExecute.Parameters.Add(New SqlParameter("@UserName", SqlDbType.NVarChar, 32, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _userName))
				cmdToExecute.Parameters.Add(New SqlParameter("@Password", SqlDbType.NVarChar, 32, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _password))
				cmdToExecute.Parameters.Add(New SqlParameter("@InterviewerRegionID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _interviewerRegionID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Region", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _region))
				cmdToExecute.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.VarChar, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _employeeID))
				cmdToExecute.Parameters.Add(new SqlParameter("@InterviewerSupervisorID", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, _interviewerSupervisorID))
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
				_interviewerSupervisorID = CType(cmdToExecute.Parameters.Item("@InterviewerSupervisorID").Value, SqlInt32)
				mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

				If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
					' Throw error.
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_Insert' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::Insert::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>InterviewerSupervisorID</LI>
		'''		 <LI>FirstName. May be SqlString.Null</LI>
		'''		 <LI>LastName. May be SqlString.Null</LI>
		'''		 <LI>UserName. May be SqlString.Null</LI>
		'''		 <LI>Password. May be SqlString.Null</LI>
		'''		 <LI>InterviewerRegionID. May be SqlInt32.Null</LI>
		'''		 <LI>Region. May be SqlInt32.Null</LI>
		'''		 <LI>EmployeeID. May be SqlString.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Update() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_Update]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@InterviewerSupervisorID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _interviewerSupervisorID))
				cmdToExecute.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _firstName))
				cmdToExecute.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 50, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _lastName))
				cmdToExecute.Parameters.Add(New SqlParameter("@UserName", SqlDbType.NVarChar, 32, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _userName))
				cmdToExecute.Parameters.Add(New SqlParameter("@Password", SqlDbType.NVarChar, 32, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _password))
				cmdToExecute.Parameters.Add(New SqlParameter("@InterviewerRegionID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _interviewerRegionID))
				cmdToExecute.Parameters.Add(New SqlParameter("@Region", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _region))
				cmdToExecute.Parameters.Add(New SqlParameter("@EmployeeID", SqlDbType.VarChar, 10, ParameterDirection.Input, True, 0, 0, "", DataRowVersion.Proposed, _employeeID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_Update' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::Update::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
			Finally
				If mblnConnectionIsLocal Then
					' Close connection.
					mobjSqlConnection.Close()
				End If
				cmdToExecute.Dispose()
			End Try
		End Function

		''' <summary>
		''' Update method for updating one or more rows using the Foreign Key 'InterviewerRegionID.
		''' It will reset the field 'InterviewerRegionID' in
		''' all rows which have as value for this field the value as set in property 'InterviewerRegionIDOld' to 
		''' the value as set in property 'InterviewerRegionID'.
		''' </summary>
		''' <returns>True if succeeded, otherwise an exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method: 
		''' <UL>
		'''		 <LI>InterviewerRegionID. May be SqlInt32.Null</LI>
		'''		 <LI>InterviewerRegionIDOld. May be SqlInt32.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method: 
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Public Function UpdateAllWInterviewerRegionIDLogic() As Boolean
			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_UpdateAllWInterviewerRegionIDLogic]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class' connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@InterviewerRegionID", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _interviewerRegionID))
				cmdToExecute.Parameters.Add(new SqlParameter("@InterviewerRegionIDOld", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _interviewerRegionIDOld))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_UpdateAllWInterviewerRegionIDLogic' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::UpdateAllWInterviewerRegionIDLogic::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>InterviewerSupervisorID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Overrides Public Function Delete() As Boolean

			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_Delete]"
			cmdToExecute.CommandType = CommandType.StoredProcedure

			' Use base class connection object

			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(New SqlParameter("@InterviewerSupervisorID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _interviewerSupervisorID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_Delete' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return True
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::Delete::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		'''		 <LI>InterviewerSupervisorID</LI>
		''' </UL>
		''' Properties set after a succesful call of this method:
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		'''		 <LI>InterviewerSupervisorID</LI>
		'''		 <LI>FirstName</LI>
		'''		 <LI>LastName</LI>
		'''		 <LI>UserName</LI>
		'''		 <LI>Password</LI>
		'''		 <LI>InterviewerRegionID</LI>
		'''		 <LI>Region</LI>
		'''		 <LI>EmployeeID</LI>
		''' </UL>
		''' Sets all properties corresponding with a field in the table with the value of the row selected.
		''' </remarks>

		Overrides Public Function SelectOne() As DataTable
			Dim cmdToExecute As SqlCommand = New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_SelectOne]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpInterviewerSupervisor")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@InterviewerSupervisorID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "", DataRowVersion.Proposed, _interviewerSupervisorID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_SelectOne' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				If toReturn.Rows.Count > 0 Then
					FillProperties(toReturn.Rows(0))

				End If
				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::SelectOne::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_SelectAll]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpInterviewerSupervisor")
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_SelectAll' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::SelectAll::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		''' Selects one or more rows from the database based on the Foreign Key 'InterviewerRegionID'
		''' </summary>
		''' <returns>DataTable object if succeeded, otherwise an Exception is thrown. </returns>
		''' <remarks>
		''' Properties needed for this method: 
		''' <UL>
		'''		 <LI>InterviewerRegionID. May be SqlInt32.Null</LI>
		''' </UL>
		''' Properties set after a succesful call of this method: 
		''' <UL>
		'''		 <LI>ErrorCode</LI>
		''' </UL>
		''' </remarks>
		Public Function SelectAllWInterviewerRegionIDLogic() As DataTable
			Dim cmdToExecute As SqlCommand	= New SqlCommand()
			cmdToExecute.CommandText = "dbo.[wiz_tlkpInterviewerSupervisor_SelectAllWInterviewerRegionIDLogic]"
			cmdToExecute.CommandType = CommandType.StoredProcedure
			Dim toReturn As DataTable = new DataTable("tlkpInterviewerSupervisor")
			Dim adapter As SqlDataAdapter = new SqlDataAdapter(cmdToExecute)

			' Use base class connection object
			cmdToExecute.Connection = mobjSqlConnection

			Try
				cmdToExecute.Parameters.Add(new SqlParameter("@InterviewerRegionID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "", DataRowVersion.Proposed, _interviewerRegionID))
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
					Throw New Exception("Stored Procedure 'wiz_tlkpInterviewerSupervisor_SelectAllWInterviewerRegionIDLogic' reported the ErrorCode: " & mErrorCode.ToString())
				End If

				Return toReturn
			Catch ex As Exception
				' Some error occured. Bubble it to caller and encapsulate Exception object
				Throw New Exception("TlkpInterviewerSupervisor::SelectAllWInterviewerRegionIDLogic::Error occured." + Environment.Newline + Environment.NewLine + ex.Message, ex)
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
		Public Property [InterviewerSupervisorID]() As SqlInt32
			Get
				Return _interviewerSupervisorID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _interviewerSupervisorID.Equals(Value) Then
					If _interviewerSupervisorIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _interviewerSupervisorID.Equals(_interviewerSupervisorIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				Dim interviewerSupervisorIDTmp As SqlInt32 = Value
				If interviewerSupervisorIDTmp.IsNull Then
					Throw New NullValueException("InterviewerSupervisorID", "InterviewerSupervisorID can't be NULL")
				End If
				_interviewerSupervisorID = Value
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
		Public Property [UserName]() As SqlString
			Get
				Return _userName
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _userName.IsNull Then
					CurrentValue = _userName.Value
				End If
				If Not _userNameOld.IsNull Then
					OldValue = _userNameOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_userName = Value
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
		Public Property [Password]() As SqlString
			Get
				Return _password
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _password.IsNull Then
					CurrentValue = _password.Value
				End If
				If Not _passwordOld.IsNull Then
					OldValue = _passwordOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_password = Value
			End Set
		End Property


		<DatabaseAttribute(HasUniqueConstraint:=False, _
		IsComputed:=False, _
		IsForeignKey:=True, _
		IsIdentity:=False, _
		IsNullable:=True, _
		IsPrimaryKey:=False, _
		IsRowGUIDColumn:=False, _
		DefaultValue:="", _
		IsTimeStamp:=False)> _
		Public Property [InterviewerRegionID]() As SqlInt32
			Get
				Return _interviewerRegionID
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _interviewerRegionID.Equals(Value) Then
					If _interviewerRegionIDOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _interviewerRegionID.Equals(_interviewerRegionIDOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_interviewerRegionID = Value
			End Set
		End Property
		Protected Property [InterviewerRegionIDOld]() As SqlInt32
			Get
				Return _interviewerRegionIDOld
			End Get
			Set(ByVal Value As SqlInt32)
				_interviewerRegionIDOld = Value
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
		Public Property [Region]() As SqlInt32
			Get
				Return _region
			End Get
			Set(ByVal Value As SqlInt32)
				If Not _region.Equals(Value) Then
					If _regionOld.Equals(Value) Then
						ModifiedColumnCount -= 1
					ElseIf _region.Equals(_regionOld) Then
						ModifiedColumnCount += 1
					End If
				End If 
				_region = Value
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
		Public Property [EmployeeID]() As SqlString
			Get
				Return _employeeID
			End Get
			Set(ByVal Value As SqlString)
				Dim NewValue As String = Nothing
				Dim CurrentValue As String = Nothing
				Dim OldValue As String = Nothing
				If Not Value.IsNull Then
					NewValue = Value.Value
				End If
				If Not _employeeID.IsNull Then
					CurrentValue = _employeeID.Value
				End If
				If Not _employeeIDOld.IsNull Then
					OldValue = _employeeIDOld.Value
				End If
				If String.Compare(CurrentValue, NewValue) <> 0 Then
					If String.Compare(OldValue, NewValue) = 0 Then
						ModifiedColumnCount -= 1
					ElseIf String.Compare(CurrentValue, OldValue) = 0 Then
						ModifiedColumnCount += 1
					End If
				End If
				_employeeID = Value
			End Set
		End Property

#End Region

	End Class
End Namespace
