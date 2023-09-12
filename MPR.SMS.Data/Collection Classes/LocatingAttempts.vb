'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LocatingAttempt objects.
''' </summary>

    Public Class LocatingAttempts
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjPerson As Person
    Private mblnObjDeleted As Boolean = False

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
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object at the specified index within the
    '''     collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object at the specified index in the
    '''     collection.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As LocatingAttempt
        Get
            Return CType(List.Item(Index), LocatingAttempt)
        End Get
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objLocatingAttempt As LocatingAttempt
            For Each objLocatingAttempt In List
                If objLocatingAttempt.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object to the end of the
    '''     PersonLocatingAttempts collection.
    ''' </summary>
    ''' <param name="objLocatingAttempt">
    '''     The <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object to be added to the end of the
    '''     collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(objLocatingAttempt As LocatingAttempt) As Integer

        Return List.Add(objLocatingAttempt)
    End Function

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object to the end of the
    '''     PersonLocatingAttempts collection.
    ''' </summary>
    ''' <param name="Index">
    '''     The Index within the collection to insert the object.
    ''' </param>
    ''' <param name="objLocatingAttempt">
    '''     The <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.LocatingAttempt">LocatingAttempt</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(Index As Integer, objLocatingAttempt As LocatingAttempt) As Integer

        List.Insert(Index, objLocatingAttempt)
        Return Index
    End Function

    Public Sub Remove(objLocatingAttempt As LocatingAttempt)

        Dim index As Integer = List.IndexOf(objLocatingAttempt)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the LocatingAttempt object within the collection with a specified LocatingAttemptID.
    ''' </summary>
    ''' <param name="intLocatingAttemptID">
    '''     The LocatingAttemptID of the LocatingAttempt object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LocatingAttempt object within the collection having the specified LocatingAttemptID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intLocatingAttemptID As Integer) As Integer

        If intLocatingAttemptID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLocatingAttempt As LocatingAttempt = CType(List.Item(i), LocatingAttempt)
                If _
                    Not objLocatingAttempt.LocatingAttemptID.IsNull AndAlso
                    objLocatingAttempt.LocatingAttemptID.Value = intLocatingAttemptID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Friend Sub ResetModified()

        Dim objLocatingAttempt As LocatingAttempt

        For Each objLocatingAttempt In List
            objLocatingAttempt.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objLocatingAttempt As LocatingAttempt

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).LocatingAttemptID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objLocatingAttempt In List
            objLocatingAttempt.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objLocatingAttempt As LocatingAttempt
        Dim blnResult As Boolean = True

        For Each objLocatingAttempt In List
            blnResult = objLocatingAttempt.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objLocatingAttempt As LocatingAttempt
        Dim blnResult As Boolean = True

        For Each objLocatingAttempt In List
            blnResult = objLocatingAttempt.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New LocatingAttempts(mobjPerson)
            For Each objExistingClass As LocatingAttempt In objExistingCollection
                If Me.IndexOf(objExistingClass.LocatingAttemptID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objPerson As Person)

        Dim objLocatingAttempt As New TblLocatingAttempt

        mobjPerson = objPerson

        objLocatingAttempt.MPRID = objPerson.MPRID

        objLocatingAttempt.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatingAttempt.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPersonLocatingAttempts As DataTable = objLocatingAttempt.SelectAllWMPRIDLogic()

        objLocatingAttempt.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPersonLocatingAttempts.Rows
            Add(New LocatingAttempt(objPerson, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonLocatingAttempts collection.
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
