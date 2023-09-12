'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data


Module GlobalCaseManagement
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Sub SendToRPS()

        'AF 11/08/12 - Transmit now creates a staging table for the RPS - this actually sends the data to the RPS.

        Dim ErrOccured As Boolean = False

        Dim SMSConn As SqlConnection = New SqlConnection(Project.ConnectionString)
        Dim RPSConn As SqlConnection = New SqlConnection(Project.RPSConnectionString)
        SMSConn.Open()
        RPSConn.Open()

        Dim cmdSMS As SqlCommand = New SqlCommand("SMS_GetRPSPayments", SMSConn)
        Dim reader As SqlDataReader = cmdSMS.ExecuteReader

        Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(RPSConn)
            bulkCopy.DestinationTableName = "dbo.tblPayments"

            bulkCopy.ColumnMappings.Add("BankAccount", "BankAccount")
            bulkCopy.ColumnMappings.Add("ProjectCode", "ProjectCode")
            bulkCopy.ColumnMappings.Add("ProjectType", "ProjectType")
            bulkCopy.ColumnMappings.Add("ModeOfPayment", "ModeOfPayment")
            bulkCopy.ColumnMappings.Add("TypeOfPayment", "TypeOfPayment")
            bulkCopy.ColumnMappings.Add("VendorID", "VendorID")
            bulkCopy.ColumnMappings.Add("MPRID", "MPRID")
            bulkCopy.ColumnMappings.Add("FirstName", "FirstName")
            bulkCopy.ColumnMappings.Add("MiddleName", "MiddleName")
            bulkCopy.ColumnMappings.Add("LastName", "LastName")
            bulkCopy.ColumnMappings.Add("Name", "Name")
            bulkCopy.ColumnMappings.Add("Address1", "Address1")
            bulkCopy.ColumnMappings.Add("Address2", "Address2")
            bulkCopy.ColumnMappings.Add("Address3", "Address3")
            bulkCopy.ColumnMappings.Add("Address4", "Address4")
            bulkCopy.ColumnMappings.Add("City", "City")
            bulkCopy.ColumnMappings.Add("State", "State")
            bulkCopy.ColumnMappings.Add("Zip5", "Zip5")
            bulkCopy.ColumnMappings.Add("Zip4", "Zip4")
            bulkCopy.ColumnMappings.Add("FacilityName1", "FacilityName1")
            bulkCopy.ColumnMappings.Add("FacilityName2", "FacilityName2")
            bulkCopy.ColumnMappings.Add("Amount", "Amount")
            bulkCopy.ColumnMappings.Add("CheckMemo", "CheckMemo")
            bulkCopy.ColumnMappings.Add("CheckNo", "CheckNo")
            bulkCopy.ColumnMappings.Add("CheckDate", "CheckDate")
            bulkCopy.ColumnMappings.Add("Pin", "Pin")
            bulkCopy.ColumnMappings.Add("CashedDate", "CashedDate")
            bulkCopy.ColumnMappings.Add("SendToBank", "SendToBank")
            bulkCopy.ColumnMappings.Add("Status", "Status")
            bulkCopy.ColumnMappings.Add("StatusDate", "StatusDate")
            bulkCopy.ColumnMappings.Add("Notes", "Notes")
            bulkCopy.ColumnMappings.Add("Validation", "Validation")
            bulkCopy.ColumnMappings.Add("WhenCreated", "WhenCreated")
            bulkCopy.ColumnMappings.Add("WhenLastUpd", "WhenLastUpd")
            bulkCopy.ColumnMappings.Add("UserLastUpd", "UserLastUpd")

            Try
                bulkCopy.WriteToServer(reader)

            Catch ex As Exception
                ErrOccured = True
                MessageBox.Show(ex.Message, Project.ShortName & " - Error transmitting to RPS", MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation)
            Finally
                reader.Close()
            End Try
        End Using

        SMSConn.Close()
        RPSConn.Close()

        If ErrOccured = False Then SqlHelper.ExecuteNonQuery(Project.ConnectionString, "SMS_UpdateRPSPayments")
    End Sub
End Module
