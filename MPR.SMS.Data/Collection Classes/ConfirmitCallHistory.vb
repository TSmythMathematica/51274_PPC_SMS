'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Class ConfirmitCallHistoryRecord
    Public Property CallDateTime As String = String.Empty
    Public Property CallStatusName As String = String.Empty
    Public Property CallComment As String = String.Empty
    Public Property CallPhoneNumber As String = String.Empty
    Public Property CallTimezone As String = String.Empty
    Public Property CallCountCalls As String = String.Empty
    Public Property CallPhoneIndex As String = String.Empty
    Public Property CallSMVerified As String = String.Empty
    Public Property CallRefusalScore As String = String.Empty
    Public Property CallQL As String = String.Empty
    Public Property CallInter_Name As String = String.Empty
    Public Property InstrumentType As String = String.Empty
    Public Property Round As String = String.Empty

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property TimeZoneName As String
        Get
            Return Project.TimeZoneCodes.GetTimeZoneName(CallTimezone)
        End Get
    End Property

    Public ReadOnly Property SMVerifiedLabel As String
        Get
            Select Case CallSMVerified
                Case "0"
                    Return "No"
                Case "1"
                    Return "Yes"
                Case Else
                    Return String.Empty
            End Select
        End Get
    End Property

    Public ReadOnly Property CallDateFormatted As String
        Get
            Try
                'Confirmit passes: Fri Jul 28 16:46:49 EDT 2017
                'Rearrange to create string like: 2017 Jul 28 16:46:49

                'Dim sqldt As DateTime
                'Dim strYear As String = CallDateTime.Substring(Len(CallDateTime) - 4, 4) 'e.g. "2017"
                'Dim strMonDayTime As String = CallDateTime.Substring(3, Len(CallDateTime) - 12) 'e.g. " Jul 28 16:46:49"
                'sqldt = CType(strYear & strMonDayTime, DateTime)
                'Return sqldt.ToString()

                If CallDateTime.Length >= 27 Then
                    Return CType(CallDateTime.Substring(Len(CallDateTime) - 4, 4) _
                                 & CallDateTime.Substring(3, Len(CallDateTime) - 12),
                                 DateTime).ToString()
                Else
                    Return CallDateTime
                End If

            Catch ex As Exception
                Return CallDateTime 'if convert to DateTime fails
            End Try
        End Get
    End Property
End Class

Public Class ConfirmitCallHistoryRecords
    Inherits CollectionBase

    Private ReadOnly mobjCase As [Case]

    Const CallDateTime As String = "CallDateTime"
    Const CallStatusName As String = "CallStatusName"
    Const CallComment As String = "CallComment"
    Const CallPhoneNumber As String = "CallPhoneNumber"
    Const CallTimezone As String = "CallTimezone"
    Const CallCountCalls As String = "CallCountCalls"
    Const CallPhoneIndex As String = "CallPhoneIndex"
    Const CallSMVerified As String = "CallSMVerified"
    Const CallRefusalScore As String = "CallRefusalScore"
    Const CallQL As String = "CallQL"
    Const CallInter_Name As String = "CallInter_Name"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public Sub New(objCase As [Case])

        mobjCase = objCase
        Clear()

        If mobjCase.CallHistoryInstrument Is Nothing Then
            Dim ch As New ConfirmitCallHistoryRecord
            ch.CallComment = "Confirmit CATI instrument not found for this sample member."
            List.Add(ch)
            'Return mobjCallHistRecords
        End If

        Dim iInstCallRecsCount As Integer = 0

        For Each objInst As Instrument In mobjCase.Instruments
            If objInst.CanGetConfirmitCallHistory Then

                Try

                    Dim fieldList As List(Of String) = Nothing
                    fieldList = New List(Of String)(11)
                    fieldList.Add(CallDateTime)
                    fieldList.Add(CallStatusName)
                    fieldList.Add(CallComment)
                    fieldList.Add(CallPhoneNumber)
                    fieldList.Add(CallTimezone)
                    fieldList.Add(CallCountCalls)
                    fieldList.Add(CallPhoneIndex)
                    fieldList.Add(CallSMVerified)
                    fieldList.Add(CallRefusalScore)
                    fieldList.Add(CallQL)
                    fieldList.Add(CallInter_Name)

                    Dim dt As DataTable
                    dt = APITest.Data.GetForProject_CallHistory(Project.APIUser, Project.APIPwd,
                                                                objInst.InstrumentType.SurveyID.Value,
                                                                fieldList,
                                                                objInst.SampleMemberMPRID.Value
                                                                ).Tables(0)

                    iInstCallRecsCount = 0

                    For Each row As DataRow In dt.Rows

                        iInstCallRecsCount += 1

                        Dim ch As New ConfirmitCallHistoryRecord
                        ch.CallDateTime = row(CallDateTime).ToString()
                        ch.CallStatusName = row(CallStatusName).ToString()
                        ch.CallComment = row(CallComment).ToString()
                        ch.CallPhoneNumber = row(CallPhoneNumber).ToString()
                        ch.CallTimezone = row(CallTimezone).ToString()
                        ch.CallCountCalls = row(CallCountCalls).ToString()
                        ch.CallPhoneIndex = row(CallPhoneIndex).ToString()
                        ch.CallSMVerified = row(CallSMVerified).ToString() 'Display as 1=Yes, 2=No (is no=0?)
                        ch.CallRefusalScore = row(CallRefusalScore).ToString()
                        ch.CallQL = row(CallQL).ToString()
                        ch.CallInter_Name = row(CallInter_Name).ToString()
                        ch.InstrumentType = objInst.InstrumentType.Description.Value
                        ch.Round = GetSafeValue(objInst.Round).ToString()
                        'Source: Hardcode to 'Confirmit'
                        List.Add(ch)

                        'Try

                        '    For x As Integer = 1 To dt.Columns.Count
                        '        dim sColumnName As String=dt.Columns(x).ColumnName
                        '        Dim sRowValue As String = row.Item(x).ToString()
                        '    Next

                        'Catch ex As Exception

                        'End Try

                        ' ''add a few records for testing
                        'Dim ch1 As New ConfirmitCallHistoryRecord
                        'ch1.CallComment = "Ask for: Special FirstName LastName, R tried to refuse again saying her teacher doesnt know about the study and doesnt understand why were doing it. " & _
                        '                  "I explained she agreed to join the study when she applied to XYZ, and were doing this with everyone who applied to XYZ during that time and shell get 25$. " & _
                        '                  "she keeps saying CB another day but wont say WHEN."
                        'ch1.CallDateTime = Now.ToString()
                        'ch1.CallTimezone = "62"
                        'List.Add(ch1)

                    Next

                Catch ex As Exception

                    'SetStatusMsg("Error occurred. Please check inputs.")
                    'MessageBox.Show(ex.Message)
                    Dim ch As New ConfirmitCallHistoryRecord
                    ch.CallComment = "Error retrieving Call History."
                    ch.InstrumentType = objInst.InstrumentType.Description.Value
                    List.Add(ch)

                Finally

                    If iInstCallRecsCount = 0 Then
                        Dim ch As New ConfirmitCallHistoryRecord
                        ch.CallComment = "No call history exists for this sample member."
                        ch.InstrumentType = objInst.InstrumentType.Description.Value
                        List.Add(ch)
                    End If

                End Try

            End If
        Next
    End Sub
End Class