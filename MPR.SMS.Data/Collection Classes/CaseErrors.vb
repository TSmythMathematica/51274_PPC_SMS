'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes

''' <summary>
'''     Provides a strongly typed collection of CaseError objects.
''' </summary>

    Public Class CaseErrors
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Case objectbelongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Case object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.CaseError">CaseError</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.CaseError">CaseError</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As CaseError
        Get
            Return CType(List.Item(Index), CaseError)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the specified CaseError object.
    ''' </summary>
    ''' <param name="objCaseError">
    '''     The CaseError object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified CaseError object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objCaseError As CaseError) As Integer

        If Not objCaseError Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objCaseError) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.CaseError">CaseError</see> object to the end of the CaseErrors collection.
    ''' </summary>
    ''' <param name="objCaseError">
    '''     The <see cref="T:MPR.SMS.Data.CaseError">CaseError</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.CaseError">CaseError</see> object has been added.
    ''' </returns>

        Public Function Add(objCaseError As CaseError) As Integer

        Return List.Add(objCaseError)
    End Function

    Public Sub Remove(objCaseError As CaseError)

        Dim index As Integer = List.IndexOf(objCaseError)

        If index >= 0 Then
            List.RemoveAt(index)
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Function GetSafeValue(objSqlString As SqlString) As String

        If Not objSqlString.IsNull Then
            Return objSqlString.ToString
        Else
            Return ""
        End If
    End Function

    Private Function GetSafeValue(objSqlInt32 As SqlInt32) As Integer

        If Not objSqlInt32.IsNull Then
            Return objSqlInt32.Value
        Else
            Return 0
        End If
    End Function

    Private Function GetSafeValue(objSqlDateTime As SqlDateTime) As String

        If Not objSqlDateTime.IsNull Then
            Return objSqlDateTime.ToString
        Else
            Return ""
        End If
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        mobjCase = objCase
        Me.Clear()

        For Each objPerson As Person In mobjCase.Persons

            'loop through each person in the case, 
            'or just the Sample Member(s), according to the Project Settings
            If Project.ErrorChecking <> Project.CheckingType.PrimarySampleMemberOnly Or
               objPerson.RelationshipType.IsPrimarySampleMember Then

                'BEGIN: Project-specific Error Checking
                'CaseErrorType.InvalidSite
                If GetSafeValue(objCase.SiteID).Equals(0) Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.InvalidSite, objCase.SiteID.ToString))
                End If

                'CaseErrorType.InvalidStratification
                'Project-specific

                'CaseErrorType.MissingFirstName
                If GetSafeValue(objPerson.FirstName).Equals("") Then
                    'Me.Add(New CaseError(objPerson.CaseID.Value, objPerson.MPRID.ToString, CaseError.CaseErrorType.MissingFirstName, objPerson.FirstName.ToString))
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.MissingFirstName, objPerson.FirstName.ToString))
                End If

                'CaseErrorType.MissingLastName
                If GetSafeValue(objPerson.LastName).Equals("") Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.MissingLastName, objPerson.LastName.ToString))
                End If

                'Missing Address
                If objPerson.BestPhysicalAddress Is Nothing Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.MissingAddress1, ""))
                Else
                    'CaseErrorType.MissingAddress1
                    If GetSafeValue(objPerson.BestPhysicalAddress.Address1).Equals("") Then
                        Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                             CaseError.CaseErrorType.MissingAddress1,
                                             objPerson.BestPhysicalAddress.Address1.ToString))
                    End If
                    'CaseErrorType.MissingCity
                    If GetSafeValue(objPerson.BestPhysicalAddress.City).Equals("") Then
                        Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                             CaseError.CaseErrorType.MissingCity,
                                             objPerson.BestPhysicalAddress.City.ToString))
                    End If
                    'CaseErrorType.MissingState
                    If GetSafeValue(objPerson.BestPhysicalAddress.State).Equals("") Then
                        Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                             CaseError.CaseErrorType.MissingState,
                                             objPerson.BestPhysicalAddress.State.ToString))
                    End If
                    'CaseErrorType.MissingZip
                    If GetSafeValue(objPerson.BestPhysicalAddress.PostalCode).Equals("") Then
                        Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                             CaseError.CaseErrorType.MissingZip,
                                             objPerson.BestPhysicalAddress.PostalCode.ToString))
                    End If
                End If

                'CaseErrorType.InvalidAge
                'project-specific

                'CaseErrorType.InvalidDateOfBirth
                If objPerson.DateOfBirth.IsNull OrElse Not IsDate(GetSafeValue(objPerson.DateOfBirth)) Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.InvalidDateOfBirth, objPerson.DateOfBirth.ToString))
                End If

                'CaseErrorType.MissingGender
                If GetSafeValue(objPerson.GenderID).Equals(0) Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.MissingGender, objPerson.GenderID.ToString))
                End If

                'CaseErrorType.InvalidPhoneNumber
                If objPerson.Phones.Count = 0 OrElse objPerson.BestPhone Is Nothing Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.InvalidPhoneNumber, ""))
                ElseIf objPerson.BestPhone.PhoneNum.ToString.Length < 10 Then
                    Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                         CaseError.CaseErrorType.InvalidPhoneNumber,
                                         objPerson.BestPhone.PhoneNum.ToString))
                End If

                'CaseErrorType.InvalidPhysicianID
                'project-specific
                'If GetSafeValue(objPerson.PhysicianCode).Equals("") Then
                '   Me.Add(New CaseError(objPerson.CaseID, objPerson.MPRID, CaseError.CaseErrorType.InvalidPhysicianID, objPerson.PhysicianCode.ToString))
                'End If

                'CaseErrorType.InvalidMedicareID
                'project-specific. see SMSBaseV2 for example of Medicare # validation

                'CaseErrorType.MissingPatientID
                'If GetSafeValue(objPerson.PatientID).Equals(0) Then
                '   Me.Add(New CaseError(objPerson.CaseID, objPerson.MPRID, CaseError.CaseErrorType.MissingPatientID, objPerson.PatientID.ToString))
                'End If

                If objPerson.Case.EntityTypeID.Value.Equals(Enumerations.tlkpEntityType.Student) AndAlso
                   objPerson.Student IsNot Nothing Then
                    'CaseErrorType.MissingConsent
                    'Project specific
                    'CaseErrorType.MissingAssent
                    'Project specific

                    'CaseErrorType.MissingGrade
                    If GetSafeValue(objPerson.Student.Grade).Equals("") Then
                        Me.Add(New CaseError(GetSafeValue(objPerson.CaseID), objPerson.MPRID.ToString,
                                             CaseError.CaseErrorType.MissingGrade, objPerson.Student.Grade.ToString))
                    End If
                End If

                'END: Project-specific Error Checking

            End If

        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the CaseErrors collection.
    ''' </summary>
    ''' <remarks>
    '''     This creates an empty collection.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
        Clear()
    End Sub

#End Region
End Class