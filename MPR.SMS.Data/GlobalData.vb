'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Net

Public Module GlobalData
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Function GetSafeValue(objSqlBoolean As SqlBoolean) As Boolean

        Return objSqlBoolean.IsTrue
    End Function

    Public Function GetSafeValue(objSqlDateTime As SqlDateTime) As DateTime

        If objSqlDateTime.IsNull Then
            Return Nothing
        Else
            Return objSqlDateTime.Value
        End If
    End Function

    Public Function GetSafeValue(objSqlDouble As SqlDouble) As Double

        If objSqlDouble.IsNull Then
            Return Nothing
        Else
            Return objSqlDouble.Value
        End If
    End Function

    Public Function GetSafeValue(objSqlInt32 As SqlInt32) As Int32

        If objSqlInt32.IsNull Then
            Return Nothing
        Else
            Return objSqlInt32.Value
        End If
    End Function

    Public Function GetSafeValue(objSqlString As SqlString) As String

        If objSqlString.IsNull Then
            Return Nothing
        Else
            Return objSqlString.Value
        End If
    End Function

    Public Function GetSafeValue(objSqlGuid As SqlGuid) As String

        If objSqlGuid.IsNull Then
            Return Nothing
        Else
            Return objSqlGuid.ToString()
        End If
    End Function

    Public Sub SetSafeValue(ByRef objSqlBoolean As SqlBoolean, objValue As Boolean)

        objSqlBoolean = New SqlBoolean(objValue)
    End Sub

    Public Sub SetSafeValue(ByRef objSqlDateTime As SqlDateTime, objValue As String)

        If objValue Is Nothing OrElse objValue = "" Then
            objSqlDateTime = SqlDateTime.Null
        Else
            Try
                Dim dt As Date = CType(objValue, Date)
                objSqlDateTime = New SqlDateTime(dt)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Public Sub SetSafeValue(ByRef objSqlInt32 As SqlInt32, objValue As String)

        If objValue Is Nothing OrElse objValue = "" Then
            objSqlInt32 = SqlInt32.Null
        Else
            Try
                Dim int As Integer = CType(objValue, Integer)
                objSqlInt32 = New SqlInt32(int)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Public Sub SetSafeValue(ByRef objSqlInt16 As SqlInt16, objValue As String)

        If objValue Is Nothing OrElse objValue = "" Then
            objSqlInt16 = SqlInt16.Null
        Else
            Try
                Dim shortint As Short = CType(objValue, Short)
                objSqlInt16 = New SqlInt16(shortint)
            Catch ex As Exception
                Throw
            End Try
        End If
    End Sub

    Public Sub SetSafeValue(ByRef objSqlString As SqlString, objValue As String)

        If objValue Is Nothing Then
            objSqlString = SqlString.Null
            Return
        End If

        objSqlString = New SqlString(objValue)
    End Sub

    Public Sub SetSafeValue(ByRef objSqlSingle As SqlSingle, objValue As String)

        If objValue Is Nothing OrElse objValue = "" Then
            objSqlSingle = SqlSingle.Null
        Else
            Try
                Dim num As Single = CType(objValue, Single)
                objSqlSingle = New SqlSingle(num)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    Public Sub SetSafeValue(ByRef objSqlMoney As SqlMoney, objValue As String)

        If objValue Is Nothing OrElse objValue = "" Then
            objSqlMoney = SqlMoney.Null
        Else
            Try
                Dim num As Double = CType(objValue, Double)
                objSqlMoney = New SqlMoney(num)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub

    'returns the displayable date-only portion of a DateTime field
    Public Function GetSafeDate(objSqlDateTime As SqlDateTime) As String

        If objSqlDateTime.IsNull Then
            Return ""
        Else
            Return Format(objSqlDateTime.Value, "MM/dd/yyyy")
        End If
    End Function

    'returns the displayable formatted SSN
    Public Function GetSafeSSN(objSqlString As SqlString) As String

        If objSqlString.IsNull Then
            Return ""
        Else
            Dim SSN As String = GetSafeValue(objSqlString)
            If SSN.Length = 9 Then
                Return String.Format("{0}-{1}-{2}", SSN.Substring(0, 3), SSN.Substring(3, 2), SSN.Substring(5, 4))
            Else
                Return SSN
            End If
        End If
    End Function

    'returns the displayable formatted Phone Number
    Public Function GetSafePhone(objSqlString As SqlString) As String

        If objSqlString.IsNull Then
            Return ""
        Else
            Dim phone As String = GetSafeValue(objSqlString)
            If phone.Length = 10 Then
                Return String.Format("({0}) {1}-{2}", phone.Substring(0, 3), phone.Substring(3, 3), phone.Substring(6))
            Else
                Return phone
            End If
        End If
    End Function

    'returns the displayable formatted Zip + 4
    Public Function GetSafeZip(objSqlString As SqlString) As String

        If objSqlString.IsNull Then
            Return ""
        Else
            Dim zip As String = GetSafeValue(objSqlString).Trim
            If zip.Length = 9 Then
                Return String.Format("{0}-{1}", zip.Substring(0, 5), zip.Substring(5, 4))
            Else
                Return zip
            End If
        End If
    End Function

    'This function takes a SQL statement as a parameter, and then
    'returns a DataTable. 
    'Useful for setting the DataSource for a DataGridView, or a collection
    'class based on a query.
    Public ReadOnly Property GetDataTable(sqlCommand As String) As DataTable
        Get
            Dim adapter As New SqlDataAdapter(sqlCommand, Project.GetInstance.ConnectionString)

            Dim table As New DataTable
            'table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Try
                adapter.Fill(table)
                Return table
            Catch ex As Exception
                Throw _
                    New Exception("Error retrieving data" + Environment.NewLine + Environment.NewLine + ex.Message, ex)
                Return (Nothing)
            End Try
        End Get
    End Property


    'This function takes a SQL statement as a parameter, and then
    'returns a DataTable (USING RPS, not SMS database)
    'Useful for setting the DataSource for a DataGridView, or a collection
    'class based on a query.
    Public ReadOnly Property GetRPSDataTable(sqlCommand As String) As DataTable
        Get
            Dim adapter As New SqlDataAdapter(sqlCommand, Project.GetInstance.RPSConnectionString)

            Dim table As New DataTable
            'table.Locale = System.Globalization.CultureInfo.InvariantCulture
            Try
                adapter.Fill(table)
                Return table
            Catch ex As Exception
                Throw _
                    New Exception("Error retrieving data" + Environment.NewLine + Environment.NewLine + ex.Message, ex)
                Return (Nothing)
            End Try
        End Get
    End Property

    'BT: 05/06/2014. Added this code for SRDEE functionality of SMS.

    Public Sub AddSRDEELockRecord(strMPRID As String,
                                  strUserName As String,
                                  intInstTypeID As Integer)

        Dim conn As New SqlConnection(Project.GetInstance.ConnectionString)
        Dim cmdSQL As New SqlCommand("SRDEE_LockRecord_Insert", conn)

        cmdSQL.Parameters.Add(New SqlParameter("@MPRID", SqlDbType.Char, 8, ParameterDirection.Input, False, 0, 0, "",
                                               DataRowVersion.Proposed, strMPRID))
        cmdSQL.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 10,
                                               0, "", DataRowVersion.Proposed, strUserName))
        cmdSQL.Parameters.Add(New SqlParameter("@InstrumentTypeID", SqlDbType.Int, 3, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, intInstTypeID))


        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure

            cmdSQL.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Public Sub DeleteSRDEELockRecord(strMPRID As String,
                                     strUserName As String,
                                     intInstTypeID As Integer)


        Dim conn As New SqlConnection(Project.GetInstance.ConnectionString)
        Dim cmdSQL As New SqlCommand("SRDEE_LockRecord_Delete", conn)

        cmdSQL.Parameters.Add(New SqlParameter("@MPRID", SqlDbType.Char, 8, ParameterDirection.Input, False, 0, 0, "",
                                               DataRowVersion.Proposed, strMPRID))
        cmdSQL.Parameters.Add(New SqlParameter("@UserName", SqlDbType.VarChar, 50, ParameterDirection.Input, False, 10,
                                               0, "", DataRowVersion.Proposed, strUserName))
        cmdSQL.Parameters.Add(New SqlParameter("@InstrumentTypeID", SqlDbType.Int, 3, ParameterDirection.Input, False,
                                               10, 0, "", DataRowVersion.Proposed, intInstTypeID))


        Try
            conn.Open()
            cmdSQL.CommandType = CommandType.StoredProcedure

            cmdSQL.ExecuteNonQuery()

        Catch ex As Exception
            Throw ex
        End Try

        conn.Close()
        cmdSQL.Dispose()
    End Sub

    Public Function GetSRDEEUser(User As String) As Boolean
        Dim sqldr As SqlDataReader = Nothing
        Dim blnFlag As Boolean = False
        Try
            sqldr = SqlHelper.ExecuteReader(Project.GetInstance.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SRDEE_IsUser",
                                            New SqlParameter("@Option", "SRDEE"),
                                            New SqlParameter("@User", User))

            If sqldr.HasRows = True Then
                blnFlag = True
            Else
                blnFlag = False
            End If

            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If

            Return blnFlag

        Catch ex As Exception
            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If
            Return False
        End Try
    End Function

    Public Function GetSRDEESupervisor(User As String) As Boolean
        Dim sqldr As SqlDataReader = Nothing
        Dim blnFlag As Boolean = False
        Try
            sqldr = SqlHelper.ExecuteReader(Project.GetInstance.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SRDEE_IsSupervisor",
                                            New SqlParameter("@Option", "SRDEE"),
                                            New SqlParameter("@User", User))

            If sqldr.HasRows = True Then
                blnFlag = True
            Else
                blnFlag = False
            End If

            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If

            Return blnFlag

        Catch ex As Exception
            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If
            Return False
        End Try
    End Function

    Public Function IsSRDEEOverride(User As String) As Boolean
        Dim sqldr As SqlDataReader = Nothing
        Dim blnFlag As Boolean = False
        Try
            sqldr = SqlHelper.ExecuteReader(Project.GetInstance.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SRDEE_IsSupervisor",
                                            New SqlParameter("@Option", "SRDEEOverride"),
                                            New SqlParameter("@User", User))

            If sqldr.HasRows = True Then
                blnFlag = True
            Else
                blnFlag = False
            End If

            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If

            Return blnFlag

        Catch ex As Exception
            If sqldr.IsClosed = True Then
                sqldr.Close()
            End If
            Return False
        End Try
    End Function

    Public Function IsSRDEELock(intInstrumentTypeID As Integer) As Boolean
        Dim blnFlag As Boolean = False
        Dim sqldr As SqlDataReader = Nothing
        Try
            sqldr = SqlHelper.ExecuteReader(Project.GetInstance.ConnectionString,
                                            CommandType.StoredProcedure,
                                            "SRDEE_IsLock",
                                            New SqlParameter("@InstrumentTypeID", intInstrumentTypeID))
            If sqldr.HasRows = True Then
                blnFlag = True
            Else
                blnFlag = False
            End If

            sqldr.Close()

            Return blnFlag
        Catch ex As Exception
            If sqldr IsNot Nothing Then
                sqldr.Close()
            End If
            Return False
        End Try
    End Function

    Public ReadOnly Property GetDataTableByID(sqlCommand As String, intID As Integer) As DataTable
        Get
            Dim SqlConn As New SqlConnection
            SqlConn.ConnectionString = Project.GetInstance.ConnectionString
            Dim SqlCmd As New SqlCommand(sqlCommand, SqlConn)
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add(New SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, False, 10, 0, "",
                                                   DataRowVersion.Proposed, intID))

            Dim adapter As New SqlDataAdapter(SqlCmd)

            Dim table As New DataTable
            Try
                adapter.Fill(table)
                SqlConn.Close()
                SqlConn.Dispose()
                Return table
            Catch ex As Exception
                If SqlConn.State = ConnectionState.Open Then
                    SqlConn.Close()
                    SqlConn.Dispose()
                End If
                Return Nothing
            End Try
        End Get
    End Property

    'BT: 05/06/2014. Added this code for SRDEE functionality of SMS.

    '03/18/2021 WJ: Copied two functions from MIHOPE_CheckIn SMS / MPR.SMS.Data / DataUtility for dupilcate address fix when receipting documents with status forword address provided
    Public Function GetDataTable2Par(procName As String, stringParamName As String,
     stringParamSize As Integer, stringParamValue As String,
     intParamName As String, intParamValue As Integer) As DataTable
        Dim intError As Integer
        Dim thisConnection As New SqlConnection(Project.GetInstance.ConnectionString)
        Dim reader As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand

        If Not thisConnection.State = ConnectionState.Open Then
            thisConnection.Open()
        End If
        cmd.Connection = thisConnection
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = procName

        Dim param1 As SqlParameter = cmd.CreateParameter
        param1.ParameterName = stringParamName
        param1.DbType = DbType.String
        param1.Direction = ParameterDirection.Input
        param1.Value = stringParamValue
        param1.Size = stringParamSize
        cmd.Parameters.Add(param1)

        Dim param2 As SqlParameter = cmd.CreateParameter
        param2.ParameterName = intParamName
        param2.DbType = DbType.Int32
        param2.Direction = ParameterDirection.Input
        param2.Value = intParamValue
        cmd.Parameters.Add(param2)

        cmd.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, intError))

        reader = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(reader)

        reader.Close()
        thisConnection.Close()
        thisConnection.Dispose()

        Return dt
    End Function

    'One varchar Parameter
    Public Function GetDataTable1Par(procName As String, paramName As String,
                           paramValue As String, paramSize As Integer) As DataTable
        Dim intError As Integer
        Dim thisConnection As New SqlConnection(Project.GetInstance.ConnectionString)
        Dim reader As SqlDataReader
        Dim cmd As SqlCommand = New SqlCommand

        If Not thisConnection.State = ConnectionState.Open Then
            thisConnection.Open()
        End If
        cmd.Connection = thisConnection
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = procName

        Dim param1 As SqlParameter = cmd.CreateParameter
        param1.ParameterName = paramName
        param1.DbType = DbType.String
        param1.Direction = ParameterDirection.Input
        param1.Value = paramValue
        param1.Size = paramSize
        cmd.Parameters.Add(param1)

        cmd.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4, ParameterDirection.Output, True, 10, 0, "", DataRowVersion.Proposed, intError))

        reader = cmd.ExecuteReader()
        Dim dt As New DataTable
        dt.Load(reader)

        reader.Close()
        thisConnection.Close()
        thisConnection.Dispose()

        Return dt
    End Function
    '03/18/2021 WJ

End Module

Public Class TCPAPhoneLookup
    Const SingleQuote As String = """"

    Public Shared Function GetPhoneType(phoneNumber As String) As String

        Dim phoneNum As String = StripToDigits(phoneNumber)
        Dim postUrl As String = Project.TcpaLookupUrl
        Dim phoneType As String = "U"

        If phoneNum.Length > 0 Then
            Using client As WebClient = New WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"
                client.UseDefaultCredentials = True
                phoneType = client.UploadString(postUrl, "POST", phoneNum)
            End Using
        End If

        Return phoneType.Replace(SingleQuote, String.Empty)
    End Function

    Public Shared Function StripToDigits(inStr As String) As String

        Dim numString As String = [String].Empty
        For x As Integer = 0 To inStr.Length - 1
            If Char.IsDigit(inStr(x)) Then
                numString += inStr(x)
            End If
        Next
        Return numString
    End Function
End Class
