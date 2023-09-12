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

    Public Class Duplicate

#Region "Events"

    Event OnDelete(objDuplicate As Duplicate)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person

    Private ReadOnly _CaseID As Integer
    Private ReadOnly _DupeCaseID As Integer
    Private ReadOnly _MPRID As String
    Private ReadOnly _DupeMPRID As String
    Private ReadOnly _DupeTypeID As Integer
    Private ReadOnly _DupeType As String
    Private ReadOnly _Duplicate As String

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

    Public Shadows ReadOnly Property DupeMPRID As SqlString
        Get
            Return _DupeMPRID
        End Get
    End Property

    Public Shadows ReadOnly Property DupeCaseID As SqlInt32
        Get
            Return _DupeCaseID
        End Get
    End Property

    Public Shadows ReadOnly Property DupeTypeID As SqlInt32
        Get
            Return _DupeTypeID
        End Get
    End Property

    Public Shadows ReadOnly Property DupeType As SqlString
        Get
            Return _DupeType
        End Get
    End Property

    Public Shadows ReadOnly Property Duplicate As SqlString
        Get
            Return _Duplicate
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
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Note object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New()

        _CaseID = CType(objDataRow("CaseID"), Integer)
        _DupeCaseID = CType(objDataRow("DupeCaseID"), Integer)
        _MPRID = CType(objDataRow("MPRID"), String)
        _DupeMPRID = CType(objDataRow("DupeMPRID"), String)
        _DupeTypeID = CType(objDataRow("DupeTypeID"), Integer)
        _DupeType = CType(objDataRow("DupeType"), String)
        _Duplicate = CType(objDataRow("Duplicate"), String)
    End Sub

#End Region

#Region "Public Methods"

#End Region
End Class
