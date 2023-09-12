'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Duplicate object in the
'''     database.
''' </summary>

    Public Class CaseError

#Region "Events"

    Event OnDelete(objDuplicate As Duplicate)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person

    Private ReadOnly _CaseID As Integer
    Private ReadOnly _MPRID As String
    Private ReadOnly _ErrorTypeID As Integer
    Private ReadOnly _ErrorTypeDescription As String
    Private ReadOnly _ErrorValue As String

    'Project-specific: you may need to add your own error types
    Public Enum CaseErrorType
        InvalidSite = 1
        InvalidStratification
        MissingFirstName
        MissingLastName
        MissingAddress1
        MissingCity
        MissingState
        MissingZip
        InvalidAge
        InvalidDateOfBirth
        MissingGender
        InvalidPhoneNumber
        InvalidPhysicianID
        InvalidMedicareID
        MissingPatientID
        MissingGrade
        MissingConsent
        MissingAssent
    End Enum

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Duplicate object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Duplicate object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Duplicate object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Duplicate object belongs to.
    ''' </value>

        Public ReadOnly Property [Case] As [Case]
        Get
            If mobjCase Is Nothing Then
                mobjCase = New [Case](CaseID.Value, False)
            End If
            Return mobjCase
        End Get
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Duplicate object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Duplicate object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return _CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Duplicate object is associated
    '''     with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the Duplicate object is associated with.
    ''' </value>
    ''' <remarks>
    '''     To disassociate an Duplicate object from a <see cref="T:MPR.SMS.Data.Person">Person</see> object, set this property
    '''     to Nothing (null).
    '''     The Duplicate object is is fully disassociated from any existing <see cref="T:MPR.SMS.Data.Person">Person</see>
    '''     object whenever the
    '''     property is set.
    ''' </remarks>

        Public ReadOnly Property Person As Person
        Get
            If mobjPerson Is Nothing Then
                ' Get the index of the associated Person object initializing the Person
                ' object reference as needed.
                If Not MPRID.IsNull Then

                    Dim i As Integer = [Case].Persons.IndexOf(MPRID.ToString)
                    If i >= 0 Then
                        mobjPerson = [Case].Persons(i)
                    End If
                End If
            End If

            Return mobjPerson
        End Get
    End Property

    Public Shadows ReadOnly Property MPRID As SqlString
        Get
            Return _MPRID
        End Get
    End Property

    Public Shadows ReadOnly Property ErrorTypeID As CaseErrorType
        Get
            Return CType(_ErrorTypeID, CaseErrorType)
        End Get
    End Property

    Public Shadows ReadOnly Property ErrorTypeDescription As SqlString
        Get
            Return _ErrorTypeDescription
        End Get
    End Property

    Public Shadows ReadOnly Property ErrorValue As SqlString
        Get
            Return _ErrorValue
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Creates a new instance of the Duplicate class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Note class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is called from the CaseError collection constructor
    ''' </remarks>

        Friend Sub New(objCaseID As Integer, objMPRID As String, objErrorTypeID As CaseErrorType,
                       objErrorValue As String)

        MyBase.New()

        _CaseID = objCaseID
        _MPRID = objMPRID
        _ErrorTypeID = objErrorTypeID
        _ErrorTypeDescription = GetErrorDescription(objErrorTypeID)
        _ErrorValue = objErrorValue
    End Sub

#End Region

#Region "Public Methods"

    Private Function GetErrorDescription(objErrorTypeID As CaseErrorType) As String

        Select Case objErrorTypeID
            Case CaseErrorType.InvalidSite
                Return "Invalid Site"
            Case CaseErrorType.InvalidStratification
                Return "Invalid Stratification"
            Case CaseErrorType.MissingFirstName
                Return "Missing First Name"
            Case CaseErrorType.MissingLastName
                Return "Missing Last Name"
            Case CaseErrorType.MissingAddress1
                Return "Missing Address1"
            Case CaseErrorType.MissingCity
                Return "Missing City"
            Case CaseErrorType.MissingState
                Return "Missing State"
            Case CaseErrorType.MissingZip
                Return "Missing Zipcode"
            Case CaseErrorType.InvalidAge
                Return "Missing/Invalid Age"
            Case CaseErrorType.InvalidDateOfBirth
                Return "Missing/Invalid Date of Birth"
            Case CaseErrorType.MissingGender
                Return "Missing Gender"
            Case CaseErrorType.InvalidPhoneNumber
                Return "Invalid Phone Number"
            Case CaseErrorType.InvalidPhysicianID
                Return "Invalid Phsyician ID"
            Case CaseErrorType.InvalidMedicareID
                Return "Invalid Medicare ID"
            Case CaseErrorType.MissingPatientID
                Return "Missing Patient ID"
            Case CaseErrorType.MissingGrade
                Return "Missing Grade"
            Case CaseErrorType.MissingConsent
                Return "Missing Consent"
            Case CaseErrorType.MissingAssent
                Return "Missing Assent"
            Case Else
                Return "Unknown Error"
        End Select
    End Function

#End Region
End Class
