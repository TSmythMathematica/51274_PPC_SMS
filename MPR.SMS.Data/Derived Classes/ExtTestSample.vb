'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports MPR.SMS.Data.BaseClasses


''' <summary>
'''     Provides methods for accessing, creating and synchronizing an Address object in the
'''     database.
''' </summary>

    Public Class ExtTestSample
    Inherits VwExtTestSample

#Region "Private Fields"

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property


#End Region

    Public Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)
    End Sub


    Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            Dim cmdToExecute As SqlCommand = New SqlCommand()
            cmdToExecute.CommandText = "UPDATE exttestsample SET ImportedON = GETDATE() WHERE ID = " & ID.ToString
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = mobjSqlConnection
            cmdToExecute.ExecuteNonQuery()

        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        'If blnResult Then
        '    RaiseEvent OnUpdate(Me)
        'End If

        Return blnResult
    End Function
End Class
