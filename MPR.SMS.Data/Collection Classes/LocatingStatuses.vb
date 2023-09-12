'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LocatingStatus objects.
''' </summary>

    Public Class LocatingStatuses
    Inherits CollectionBase

#Region "Private Fields"

    Private mobjPerson As Person

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
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> object at the specified index within the
    '''     collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> object at the specified index in the collection.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As LocatingStatus
        Get
            Return CType(List.Item(Index), LocatingStatus)
        End Get
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objLocatingStatus As LocatingStatus
            For Each objLocatingStatus In List
                If objLocatingStatus.IsModified Then
                    Return True
                End If
            Next
            Return False
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> object to the end of the
    '''     PersonLocatingStatuses collection.
    ''' </summary>
    ''' <param name="objLocatingStatus">
    '''     The <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.LocatingStatus">LocatingStatus</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(objLocatingStatus As LocatingStatus) As Integer

        Return List.Add(objLocatingStatus)
    End Function

    Public Sub Remove(objLocatingStatus As LocatingStatus)

        Dim index As Integer = List.IndexOf(objLocatingStatus)

        If index >= 0 Then
            List.RemoveAt(index)
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the LocatingStatus object within the collection with a specified LocatingStatusID.
    ''' </summary>
    ''' <param name="intLocatingStatusID">
    '''     The LocatingStatusID of the LocatingStatus object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LocatingStatus object within the collection having the specified LocatingStatusID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intLocatingStatusID As Integer) As Integer

        If intLocatingStatusID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLocatingStatus As LocatingStatus = CType(List.Item(i), LocatingStatus)
                If _
                    Not objLocatingStatus.LocatingStatusID.IsNull AndAlso
                    objLocatingStatus.LocatingStatusID.Value = intLocatingStatusID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    'Friend Sub ResetModified()

    '    Dim objLocatingStatus As LocatingStatus

    '    For Each objLocatingStatus In List
    '        objLocatingStatus.ResetModified()
    '    Next

    'End Sub

    'Friend Sub RestoreModified()

    '    Dim objLocatingStatus As LocatingStatus

    '    Dim i As Integer = List.Count

    '    While i > 0
    '        If Item(i - 1).LocatingStatusID.IsNull Then
    '            List.RemoveAt(i - 1)
    '        End If
    '        i = i - 1
    '    End While


    '    For Each objLocatingStatus In List
    '        objLocatingStatus.RestoreModified()
    '    Next

    'End Sub

    'Friend Function Insert() As Boolean

    '    Dim objLocatingStatus As LocatingStatus
    '    Dim blnResult As Boolean = True

    '    For Each objLocatingStatus In List
    '        blnResult = objLocatingStatus.Insert()
    '        If Not blnResult Then
    '            Exit For
    '        End If
    '    Next

    '    Return blnResult

    'End Function

    'Friend Function Update() As Boolean

    '    Dim objLocatingStatus As LocatingStatus
    '    Dim blnResult As Boolean = True

    '    For Each objLocatingStatus In List
    '        blnResult = objLocatingStatus.Update()
    '        If Not blnResult Then
    '            Exit For
    '        End If
    '    Next

    '    Return blnResult

    'End Function

#End Region

#Region "Constructors"

    Public Sub New(strStatusCode As String)

        Dim objLocatingStatus As New TblLocatingStatus

        objLocatingStatus.LocatingStatus = strStatusCode

        objLocatingStatus.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatingStatus.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPersonLocatingStatuses As DataTable = objLocatingStatus.SelectAllWLocatingStatusLogic

        objLocatingStatus.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPersonLocatingStatuses.Rows
            Add(New LocatingStatus(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonLocatingStatuses collection.
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
