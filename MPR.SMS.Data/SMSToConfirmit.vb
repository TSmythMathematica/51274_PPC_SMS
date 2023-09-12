Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Text

' This class should be used to transfer SMS data to ConfirmIt
' DO NOT Instantiate it! Sample codes are in MPR.SMS.Data\Derived Classes\case.vb. 
'
' Before using this class, please make sure following
' 1) SurveyID field in tlkpInstrumentType table is filled for this particular InstrumentTypeID
' 2) tlkpConfirmitSettingsType and tlkpConfirmitSettings tables are filled.
'    Pay attentions to "IsActive" in both tables - Only IsActive = 1 types and variables will be transferred. Others will be ignored.
' 3) Add all variables to RT_vw_ToConfirmIt or RT_vw_ToConfirmIt_Loc (specifically for TypeID=2, locating related array type of variables). 
'    Note: all column names in both views should be 100% match with what configured in tlkpConfirmItSettings 
' After invoking any of the methods:
' 4) Check tblConfirmItLog for data that has been transferred (success or failure)
' 5) check tblConfirmitLog for detailed error message (if any)
Public Class SMSToConfirmIt

    ' 
    ' to prevent initialization outside of the class
    '
    Private Sub New()
 
    End Sub

    Public Shared Function SendToConfirmIt(ByVal MPRID As String, ByVal InstrumentTypeID As Integer, ByVal Types As Integer()) As Boolean

        Dim rtn As Boolean = True
        For Each type As Integer In Types

            If Not SendToConfirmIt(MPRID, InstrumentTypeID, type) Then
                rtn = False
                Continue For
            End If
        Next

        Return rtn

    End Function


    Public Shared Function SendToConfirmIt(ByVal MPRID As String, ByVal InstrumentTypeID As Integer, ByVal TypeID As Integer) As Boolean

        Dim processObj As RealTimeProcess = New RealTimeProcess(MPRID, InstrumentTypeID, TypeID)

        Return processObj.Send()

    End Function

   

End Class

