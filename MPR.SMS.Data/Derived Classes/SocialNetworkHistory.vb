'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class SocialNetworkHistory
    Inherits TblSocialNetworkHistory

    Event OnInsert(objSocialNetworkHistory As SocialNetworkHistory)
    Event OnUpdate(objSocialNetworkHistory As SocialNetworkHistory)
    Event OnDelete(objSocialNetworkHistory As SocialNetworkHistory)

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjSocialNetwork As SocialNetwork

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
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object that the SocialNetworkHistory object
    '''     is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object that the SocialNetworkHistory object is
    '''     associated with.
    ''' </value>

        Public ReadOnly Property SocialNetwork As SocialNetwork
        Get
            ' Get the index of the associated SocialNetwork object initializing the SocialNetwork
            ' object reference as needed.
            If Not SocialNetworkID.IsNull Then

                Dim i As Integer = mobjCase.SocialNetworks.IndexOf(SocialNetworkID.Value)

                If i >= 0 Then
                    mobjSocialNetwork = mobjCase.SocialNetworks(i)
                End If
            End If

            Return mobjSocialNetwork
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SocialNetworkHistory class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The Case that the SocialNetworkHistory object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the SocialNetworkHistory object is to be initialized with.
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
    '''     Initializes a new instance of the SocialNetworkHistory class.
    ''' </summary>
    ''' <param name="intHistoryID">
    '''     The SocialNetworkHistoryID to retrieve
    ''' </param>
    ''' <remarks>
    '''     Use this to retrieve a specific record from the database.
    ''' </remarks>

        Friend Sub New(intHistoryID As Integer)

        'mobjCase = objCase

        'Dim obj As New TblSocialNetworkHistory
        'obj.ConnectionString = Project.ConnectionString
        'obj.SocialNetworkHistoryID = SocialNetworkHistoryID
        'Dim dt As DataTable = obj.SelectOne()
        'If dt.Rows.Count > 0 Then
        '    Dim dr As DataRow = dt.Rows(0)
        '    mobjSocialNetworkHistory = New SocialNetworkHistory(mobjCase, dr)
        'End If

        MyBase.New()

        MyBase.SocialNetworkHistoryID = New SqlInt32(intHistoryID)

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
    '''     Inserts a SocialNetworkHistory object into the database.
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
    '''     Updates a SocialNetworkHistory object within the database.
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
    '''     Deletes a SocialNetworkHistory object from the database.
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
