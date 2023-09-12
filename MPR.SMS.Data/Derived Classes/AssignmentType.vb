'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating an AssignmentType object.
''' </summary>

    Public Class AssignmentType
    Inherits TlkpAssignment

#Region "Events"

    Event OnInsert(objAssignment As AssignmentType)

    Event OnUpdate(objAssignment As AssignmentType)

    Event OnDelete(objAssignment As AssignmentType)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Assignment belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Assignment belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property DisplayName As String
        Get
            Return Code.ToString + " - " + Description.ToString
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Assignment class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Assignment class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Assignment class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Assignment is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Assignment into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Assignment object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the Assignment

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
    '''     Updates a Assignment object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the Assignment

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
    '''     Deletes a Assignment from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the Assignment

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
