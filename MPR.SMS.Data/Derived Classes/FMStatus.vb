'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Imports System.Text
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Collections.Specialized
Imports MPR.SMS.Data.BaseClasses

''' <summary>
''' Provides methods for accessing, creating and manipulating a Status object.
''' </summary>

Public Class FMStatus : Inherits TlkpFMStatus

#Region "Events"

    Event OnInsert(ByVal objStatus As FMStatus)

    Event OnUpdate(ByVal objStatus As FMStatus)

    Event OnDelete(ByVal objStatus As FMStatus)

#End Region

#Region "Public Properties"

    ''' <summary>
    ''' Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Status belongs to.
    ''' </summary>
    ''' <value>
    ''' The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Status belongs to.
    ''' </value>

    Public ReadOnly Property Project() As Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property
    ''' <summary>
    ''' Gets the displayable Status: "Code - Description".
    ''' </summary>

    Public ReadOnly Property DisplayName() As String
        Get
            If Me.Description.ToString.Trim <> "" Then
                Return Me.Code.ToString & " - " & Me.Description.ToString
            Else
                Return Me.Code.ToString
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    ''' The Status class constructor has two overloads. 
    ''' </overloads>
    ''' <summary>
    ''' Initializes a new instance of a Status class with default values.
    ''' </summary>

    Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

    End Sub

    ''' <summary>
    ''' Initializes a new instance of the Status class.
    ''' </summary>
    ''' <param name="objDataRow">
    ''' A DataRow object containing the values that the Status is to be initialized with.
    ''' </param>
    ''' <remarks>
    ''' This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

    Public Sub New(ByVal objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

    End Sub

    ''' <summary>
    ''' Initializes a new instance of the Status class.
    ''' </summary>
    ''' <param name="strStatusCode">
    ''' The 3-char unique Status Code
    ''' </param>
    Public Sub New(ByVal strStatusCode As String)

        MyBase.New()

        If String.IsNullOrEmpty(strStatusCode) Then strStatusCode = "0"
        MyBase.Code = New SqlString(strStatusCode)

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

        Catch ex As Exception

            ' Rethrow the exception
            'Throw ex

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
    ''' Inserts the Status into the database.
    ''' </summary>
    ''' <returns>
    ''' True if the Status object has been successfully inserted, otherwise false.
    ''' </returns>

    Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the Status

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult

    End Function

    ''' <summary>
    ''' Updates a Status object in the database 
    ''' </summary>
    ''' <returns>
    ''' True if successful, otherwise False
    ''' </returns>

    Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the Status

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult

    End Function

    ''' <summary>
    ''' Deletes a Status from the database 
    ''' </summary>
    ''' <returns>
    ''' True if successful, otherwise False
    ''' </returns>

    Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the Status

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
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
