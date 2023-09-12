Imports MPR.SMS.Data
Imports System.Configuration
'Imports MPR.SMS.Security

Public Module GlobalFSM
    Public Supervisors As InterviewerSupervisors
    Public Regions As InterviewerRegions
    Public StatusBar As System.Windows.Forms.StatusStrip
    Public InterviewWeeks As InterviewWeeks
    Public Statuses As Statuses = Nothing
    Public ProjectUsesInterviewTeams As Boolean
    Public CaseAssignmentsAllowCopy As Boolean

    Public ReadOnly Property Project() As Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property

    'Public Function GetSupervisors(ByVal IncludeInterviewers As Boolean) As InterviewerSupervisors

    '    Return New InterviewerSupervisors(IncludeInterviewers)

    'End Function

    'Public Function AddSupervisor(ByVal Supervisor As InterviewerSupervisor) As InterviewerSupervisor

    '    If Not Supervisor.Insert() Then
    '        Return Nothing
    '    Else
    '        Return Supervisor
    '    End If

    'End Function


    'Public Function UpdateSupervisor(ByVal Supervisor As InterviewerSupervisor) As Boolean

    '    Return Supervisor.Update()

    'End Function

    'Public Function UpdateSupervisorEx(ByVal Supervisor As Supervisor) As Supervisor

    '    If Not Supervisor.Update() Then
    '        Return Nothing
    '    Else
    '        Return Supervisor
    '    End If

    'End Function

    'Public Function AddInterviewerTeam(ByVal InterviewerTeam As InterviewerTeam) As InterviewerTeam

    '    If Not InterviewerTeam.Insert() Then
    '        Return Nothing
    '    Else
    '        Return InterviewerTeam
    '    End If

    'End Function

    'Public Function UpdateInterviewerTeam(ByVal InterviewerTeam As InterviewerTeam) As InterviewerTeam

    '    If Not InterviewerTeam.Update() Then
    '        Return Nothing
    '    Else
    '        Return InterviewerTeam
    '    End If

    'End Function

    Public Function AddInterviewer(ByVal Interviewer As Interviewer) As Interviewer

        If Not Interviewer.Insert() Then
            Return Nothing
        Else
            Return Interviewer
        End If
    End Function

    Public Function UpdateInterviewer(ByVal Interviewer As Interviewer) As Boolean

        Return Interviewer.Update()
    End Function

    Public Function UpdateInterviewerEx(ByVal Interviewer As Interviewer) As Interviewer

        If Not Interviewer.Update() Then
            Return Nothing
        Else
            Return Interviewer
        End If
    End Function

    Public Function AssignCases(ByVal CaseAssignments As CaseAssignment(), ByVal SupervisorID As Integer,
                                ByVal InterviewerTeamID As Integer, ByVal AssignAllInCase As Boolean) _
        As CaseAssignment()

        'This will return Nothing if any CaseAssignment has been released.
        'Without this, all CaseAssignments will be returned with detailed 
        'ErrorMessages set for each CaseAssignment that failed.
        'For Each CaseAssignment As CaseAssignment In CaseAssignments
        '    If CaseAssignment.ReleasedToField Then Return Nothing
        'Next

        For Each CaseAssignment As CaseAssignment In CaseAssignments
            'to-do
            'CaseAssignment.Update(SupervisorID, InterviewerTeamID, MPR.SMS.Security.CurrentUser.Name, AssignAllInCase)
        Next

        Return CaseAssignments
    End Function

    'Public Function CopyCases(ByVal CaseAssignments As CaseAssignment(), ByVal SupervisorID As Integer, ByVal InterviewerTeamID As Integer, ByVal AssignAllInCase As Boolean) As CaseAssignment()

    '    For Each CaseAssignment As CaseAssignment In CaseAssignments
    '        CaseAssignment.Copy(SupervisorID, InterviewerTeamID, MPR.SMS.Security.CurrentUser.Name, AssignAllInCase)
    '    Next

    '    Return CaseAssignments

    'End Function

    'Public Function CopyCasesInSchool(ByVal CaseAssignments As CaseAssignment(), ByVal SupervisorID As Integer, ByVal InterviewerTeamID As Integer) As CaseAssignment()

    '    For Each CaseAssignment As CaseAssignment In CaseAssignments
    '        CaseAssignment.CopySchool(SupervisorID, InterviewerTeamID, MPR.SMS.Security.CurrentUser.Name)
    '    Next

    '    Return CaseAssignments

    'End Function

    'Public Function CopyCasesInDistrict(ByVal CaseAssignments As CaseAssignment(), ByVal SupervisorID As Integer, ByVal InterviewerTeamID As Integer) As CaseAssignment()

    '    For Each CaseAssignment As CaseAssignment In CaseAssignments
    '        CaseAssignment.CopyDistrict(SupervisorID, InterviewerTeamID, Authentication.UserName)
    '    Next

    '    Return CaseAssignments

    'End Function


    Public Function ComputeDistanceToInterviewer(ByVal objCaseAddress As Address, ByVal objInterviewerAddress As Address) _
        As Double

        'Dim lat1 As Double
        'Dim long1 As Double
        'Dim lat2 As Double
        'Dim long2 As Double

        'comment out by Angela
        'Dim obj As New DataQuality.DataQuality
        'obj.AddressInput.Address = GlobalData.GetSafeValue(objCaseAddress.Address1)
        'obj.AddressInput.City = GlobalData.GetSafeValue(objCaseAddress.City)
        'obj.AddressInput.State = GlobalData.GetSafeValue(objCaseAddress.State)
        'obj.AddressInput.Zip5 = GlobalData.GetSafeZip(objCaseAddress.PostalCode)
        'obj.ProcessAddress(True)

        'Try
        '    lat1 = CDbl(obj.AddressOutput.Latitude)
        '    long1 = CDbl(obj.AddressOutput.Longitude)
        'Catch ex As Exception
        '    Return -1
        'End Try

        'obj.AddressInput.Address = GlobalData.GetSafeValue(objInterviewerAddress.Address1)
        'obj.AddressInput.City = GlobalData.GetSafeValue(objInterviewerAddress.City)
        'obj.AddressInput.State = GlobalData.GetSafeValue(objInterviewerAddress.State)
        'obj.AddressInput.Zip5 = GlobalData.GetSafeZip(objInterviewerAddress.PostalCode)
        'obj.ProcessAddress(True)

        'Try
        '    lat2 = CDbl(obj.AddressOutput.Latitude)
        '    long2 = CDbl(obj.AddressOutput.Longitude)
        'Catch ex As Exception
        '    Return -1
        'End Try


        'Return obj.ComputeDistance(lat1, long1, lat2, long2)

        Return Nothing
    End Function

    'Public Function GetRegions(ByVal GetUnassignedRegions As Boolean) As InterviewerRegions

    '    Return New Regions(GetUnassignedRegions)

    'End Function

    'Public Function GetValidationStatuses() As MPR.SMS.Data.ValidationStatuses

    '    Return New ValidationStatuses(True)

    'End Function
End Module
