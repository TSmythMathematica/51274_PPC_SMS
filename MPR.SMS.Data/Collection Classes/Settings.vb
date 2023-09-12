'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class Settings
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the Message of the Day <see cref="T:MPR.SMS.Data.Setting">Setting</see> from tlkpSettings.
    ''' </summary>
    ''' <value>
    '''     The Message of the Day <see cref="T:MPR.SMS.Data.Setting">Setting</see>.
    ''' </value>

        Public ReadOnly Property MessageOfTheDay As Setting
        Get
            For Each objSetting As Setting In Me
                If objSetting.Setting.ToString = "MsgOfTheDay" Then
                    Return objSetting
                End If
            Next
            Return Nothing
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Settings collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the Settings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Settings collection is initialized from the database. This form of the constructor
    '''     is used get all of the Settings defined for the Project.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Settings

        Dim objSetting As New TlkpSettings

        objSetting.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSetting.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSettings As DataTable = objSetting.SelectAll()

        objSetting.ConnectionProvider = Nothing

        ' Add a new Setting to the collection for each Setting retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSettings.Rows
            Add(New Setting(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds a Setting to the Settings collection.
    ''' </summary>
    ''' <param name="objSetting">
    '''     The Setting to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Setting has been added.
    ''' </returns>

        Public Function Add(objSetting As Setting) As Integer

        If objSetting.Setting.IsNull Then
            If Not objSetting.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSetting As Setting = CType(List.Item(i), Setting)
            If objSetting.Setting.ToString < objExistingSetting.Setting.ToString Then
                Exit For
            End If
        Next

        List.Insert(i, objSetting)

        Return i
    End Function

#End Region
End Class
