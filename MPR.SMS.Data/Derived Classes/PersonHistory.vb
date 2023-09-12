'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports System.Text
Imports MPR.SMS.Data.BaseClasses

Public Class PersonHistory
    Inherits TblPersonHistory

    Event OnInsert(objPersonHistory As PersonHistory)
    Event OnUpdate(objPersonHistory As PersonHistory)
    Event OnDelete(objPersonHistory As PersonHistory)

#Region "Private Fields"

    Private mobjCase As [Case]
    Private mobjPerson As Person

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </value>

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    ''' Gets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the PersonHistory object is associated with.
    ''' </summary>
    ''' <value>
    ''' The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the PersonHistory object is associated with.
    ''' </value>

    Public Property [Case]() As [Case]
        Get
            Return mobjCase
        End Get
        Set(value As [Case])
            mobjCase = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonHistory object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonHistory object is associated with.
    ''' </value>

    Public ReadOnly Property Person As Person
        Get
            ' Get the index of the associated Person object initializing the Person
            ' object reference as needed.
            If Not MPRID.IsNull Then

                Dim i As Integer = mobjCase.Persons.IndexOf(MPRID.ToString)

                If i >= 0 Then
                    mobjPerson = mobjCase.Persons(i)
                End If
            End If

            Return mobjPerson
        End Get
    End Property

    ''' <summary>
    '''     Gets the full name of the person
    ''' </summary>
    ''' <value>
    '''     The full name constructed from first, middle, last name.
    ''' </value>

    Public ReadOnly Property FullName As String
        Get
            Dim sb As New StringBuilder
            If (Not FirstName.IsNull) AndAlso FirstName.Value <> "" Then
                sb.Append(FirstName.Value & " ")
            End If
            If (Not MiddleName.IsNull) AndAlso MiddleName.Value <> "" Then
                sb.Append(MiddleName.Value & " ")
            End If
            If (Not LastName.IsNull) AndAlso LastName.Value <> "" Then
                sb.Append(LastName.Value & " ")
            End If
            If (Not Suffix.IsNull) AndAlso Suffix.Value <> "" Then
                sb.Append(Suffix.Value & " ")
            End If
            If sb.Length > 0 Then
                sb.Remove(sb.Length - 1, 1)
            End If
            Return sb.ToString
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the PersonHistory class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The Case that the PersonHistory object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the PersonHistory object is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

    Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        'ConnectionString = mobjProject.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the PersonHistory class.
    ''' </summary>
    ''' <param name="intHistoryID">
    '''     The PersonHistoryID to retrieve
    ''' </param>
    ''' <remarks>
    '''     Use this to retrieve a specific record from the database.
    ''' </remarks>

    Friend Sub New(intHistoryID As Integer)

        'mobjCase = objCase

        'Dim obj As New TblPersonHistory
        'obj.ConnectionString = Project.ConnectionString
        'obj.PersonHistoryID = PersonHistoryID
        'Dim dt As DataTable = obj.SelectOne()
        'If dt.Rows.Count > 0 Then
        '    Dim dr As DataRow = dt.Rows(0)
        '    mobjPersonHistory = New PersonHistory(mobjCase, dr)
        'End If

        MyBase.New()

        MyBase.PersonHistoryID = New SqlInt32(intHistoryID)

        ConnectionString = Project.ConnectionString
        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            SelectOne()

            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a PersonHistory object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

    Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a PersonHistory object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

    Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a PersonHistory object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

    Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

#End Region
End Class
