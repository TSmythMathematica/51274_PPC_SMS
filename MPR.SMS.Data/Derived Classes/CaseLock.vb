'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a CaseLock object.
''' </summary>

    Public Class CaseLock
    Inherits TblCaseLock

#Region "Events"

    Event OnInsert(objCaseLock As CaseLock)
    Event OnUpdate(objCaseLock As CaseLock)
    Event OnDelete(objCaseLock As CaseLock)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Case">Case</see> that the CaseLock belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> that the CaseLock belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The CaseLock class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a CaseLock class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseLock class.
    ''' </summary>
    ''' <param name="intCaseID">
    '''     The MPR Case ID for which the object will be initialized.
    ''' </param>

        Public Sub New(intCaseID As Integer)

        MyBase.New()

        MyBase.CaseID = New SqlInt32(intCaseID)

        Dim blnResult As Boolean = False

        ConnectionString = Project.ConnectionString

        ConnectionProvider = New ConnectionProvider(Project.ConnectionString)

        Try

            ' Open Connection
            ConnectionProvider.OpenConnection()

            SelectOne()

            blnResult = True
            ResetModified()

        Catch ex As Exception
            blnResult = False

        Finally
            ConnectionProvider.CloseConnection(False)
            ConnectionProvider.Dispose()
            ConnectionProvider = Nothing

        End Try
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the CaseLock into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the CaseLock object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ConnectionString = Project.ConnectionString

        ' If the Case's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the CaseLock

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
    '''     Updates a CaseLock object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ConnectionString = Project.ConnectionString

        ' If the Case's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the CaseLock

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
    '''     Deletes a CaseLock from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ConnectionString = Project.ConnectionString

        ' If the Case's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the CaseLock

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

    Public Overloads Function Equals(objCaseLock As CaseLock) As Boolean

        Return CaseID.Equals(objCaseLock.CaseID) AndAlso
               UserName.Equals(objCaseLock.UserName) AndAlso
               Workstation.Equals(objCaseLock.Workstation) AndAlso
               LockDate.Equals(objCaseLock.LockDate)
    End Function

#End Region
End Class
