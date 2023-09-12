'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Imports System.Data.SqlClient
Imports System.Text
Imports APITest

Public Class RealTimeProcess

#Region "Private properties and methods "
    Private Shared ReadOnly Property Project() As Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property

    Private Property SurveyID As String
    Private Property ResponseData As Dictionary(Of String, String)
    Private Property RespondentData As Dictionary(Of String, String)
    Private Property SchedulingData As Dictionary(Of String, String)
    Private Property LogData As Dictionary(Of String, String)

    Private Property MPRID() As String
    Private Property InstrumentTypeID() As Integer
    Private Property TypeID() As Integer


#End Region

#Region "Constructor"
    Public Sub New(ByVal mprid As String, ByVal instrumentTypeID As Integer, ByVal typeID As Integer)
        Me.MPRID = mprid
        Me.InstrumentTypeID = instrumentTypeID
        Me.TypeID = typeID
    End Sub
#End Region

#Region "Public properties and methods"
   
    Public Function Send() As Boolean

        If Not FillVariables() Then Return False

        If Not SendDataToConfirmit() Then
            If LogData.Count > 0 Then
                WriteSendLog("Fail")
            End If
            Return False
        Else
            If LogData.Count > 0 Then
                Return WriteSendLog("Success")
            End If
        End If

        Return True
    End Function

#End Region

#Region "Private methods"

    Private Function FillVariables() As Boolean
        Dim dataToUpdate As New Dictionary(Of String, String)
        Dim responseDataToUpdate As New Dictionary(Of String, String)
        Dim schedulingDataToUpdate As New Dictionary(Of String, String)
        Dim logDataToUpdate As New Dictionary(Of String, String)

        Dim strKey As String
        Dim strValue As String
        Dim keyCount As Integer
        Dim logIt As Boolean = False

        'get all settings to make sure it is valid
        Dim ds As DataSet = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString,
                                                            CommandType.StoredProcedure,
                                                            "RT_GetAllSettings",
                                                            New SqlClient.SqlParameter("@InstrumentTypeID", InstrumentTypeID),
                                                            New SqlClient.SqlParameter("@TypeID", TypeID)
                                                            )
        'nothing needs to be sent, return false
        If ds.Tables(0).Rows.Count = 0 Then Return false

        Try
            Dim dsvalue As DataSet = SqlHelper.ExecuteDataset(Project.GetInstance.ConnectionString,
                                                                CommandType.StoredProcedure,
                                                                "RT_GetAllValues",
                                                                New SqlClient.SqlParameter("@InstrumentTypeID", InstrumentTypeID),
                                                                New SqlClient.SqlParameter("@MPRID", MPRID),
                                                                New SqlClient.SqlParameter("@TypeID", TypeID)
                                                                )
            If dsvalue.Tables(0).Rows.Count = 0 Then Return False
            SurveyID = ds.Tables(0).Rows(0).Item("SurveyID").ToString()

            For Each curRow As DataRow In ds.Tables(0).Rows

                strKey = curRow("ConfirmitVariable").ToString
                strValue = String.Empty
                keyCount = 0
                logIt = False

                If curRow("ConfirmitVarHasSuffix").ToString = "True" Then
                    keyCount = CInt(dsvalue.Tables(0).Rows(0).Item("CurrentPhone")) + 1
                    'remove _ from end of variable name, as the column name in value doesn't contain _
                    strKey = strKey.Substring(0, Len(strKey) - 1)
                End If


                If curRow("StaticValue").ToString <> String.Empty Then
                    strValue = CurRow("StaticValue").ToString
                Else
                    If dsvalue.Tables(0).Columns.Contains(strKey) Then
                        strValue = dsvalue.Tables(0).Rows(0).Item(strKey).ToString

                        'increase currentphone count
                        If strKey = "CurrentPhone" Then
                            strValue = (CInt(strValue) + 1).ToString
                        End If

                    Else
                        ' if no value found, skip this variable
                        Continue For
                    End If
                End If

                If keyCount > 0 Then
                    'prepare the actual key for those array type of the variables
                    strKey = strKey + "_" + keyCount.ToString
                End If

                If curRow("InRespondent").ToString = "True" Then
                    dataToUpdate.Add(strKey, strValue)
                    logIt = True
                End If

                If curRow("InResponse").ToString = "True" Then
                    responseDataToUpdate.Add(strKey, strValue)
                    logIt = True
                End If

                If curRow("UpdateScheduling").ToString = "True" Then
                    schedulingDataToUpdate.Add(strKey, strValue)
                    logIt = True
                End If

                If logIt Then
                    logDataToUpdate.Add(strKey, strValue)
                End If

            Next
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return False
        End Try

        RespondentData = dataToUpdate
        ResponseData = responseDataToUpdate
        SchedulingData = schedulingDataToUpdate
        LogData = logDataToUpdate

        Return True
    End Function

    Private Function SendDataToConfirmit() As Boolean

        Try     
            'This is a new API call which will return ConfirmItAPIException object when erroring out
            Return APITest.Data.SendDataByMPRID(Project.APIUser, Project.APIPwd, SurveyID, MPRID, RespondentData, ResponseData, SchedulingData)
        Catch ex As ConfirmItAPIException
            WriteConfirmitErrorLog(ex.MPRID, ex.SurveyID, ex.InnException.Message)
            Debug.WriteLine(ex.InnException.Message)
            Return False
        End Try

    End Function

    Private Function WriteSendLog(ByVal result As String) As Boolean
        Dim data As String = PrepareLogData()
        Dim rtn As Integer
        Try
            rtn = CInt(SqlHelper.ExecuteScalar(Project.GetInstance.ConnectionString,
                CommandType.StoredProcedure,
                "RT_CreateLog",
                New SqlClient.SqlParameter("@InstrumentTypeID", InstrumentTypeID),
                New SqlClient.SqlParameter("@MPRID", MPRID),
                New SqlClient.SqlParameter("@TypeID", TypeID),
                New SqlClient.SqlParameter("@Data", data),
                New SqlClient.SqlParameter("@Result", result)))
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
            Return False

        End Try

        Return rtn = 1
    End Function

    Private Function PrepareLogData() As String
        Dim sbXml As StringBuilder = New StringBuilder()

        sbXml.Append("<rows>")
        For Each item As KeyValuePair(Of String, String) In LogData
            sbXml.Append("<r>")
            sbXml.Append("<s>")
            sbXml.Append(item.Key)
            sbXml.Append("</s>")
            sbXml.Append("<v>")
            sbXml.Append(item.Value)
            sbXml.Append("</v>")
            sbXml.Append("</r>")
        Next
        sbXml.Append("</rows>")

        Return sbXml.ToString
    End Function

    Private Sub WriteConfirmitErrorLog(ByVal strMPRID As String, _
                                           ByVal strProjectID As String, _
                                           ByVal strErrMsg As String)


        Dim conn As New SqlClient.SqlConnection(Project.GetInstance.ConnectionString)
        Dim cmdSQL As New SqlClient.SqlCommand("RT_CreateErrorLog", conn)

        'send the parameters:
        cmdSQL.Parameters.Add(New SqlParameter("@MPRID", strMPRID))
        cmdSQL.Parameters.Add(New SqlParameter("@ProjectID", strProjectID))
        cmdSQL.Parameters.Add(New SqlParameter("@ErrMsg", strErrMsg))

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
#End Region

End Class