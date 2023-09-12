'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of PersonRace objects.
''' </summary>

    Public Class PersonRaces
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
    '''     Gets the <see cref="T:MPR.SMS.Data.PersonRace">PersonRace</see> object at the specified index within the
    '''     collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PersonRace">PersonRace</see> object at the specified index in the collection.
    ''' </value>

        Default Public ReadOnly Property Item(Index As Integer) As PersonRace
        Get
            Return CType(List.Item(Index), PersonRace)
        End Get
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objPersonRace As PersonRace
            For Each objPersonRace In List
                If objPersonRace.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.PersonRace">PersonRace</see> object to the end of the PersonPersonRaces
    '''     collection.
    ''' </summary>
    ''' <param name="objPersonRace">
    '''     The <see cref="T:MPR.SMS.Data.PersonRace">PersonRace</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.PersonRace">PersonRace</see> object has been added.
    ''' </returns>

        Public Function Add(objPersonRace As PersonRace) As Integer

        Return List.Add(objPersonRace)
    End Function

    Public Sub Remove(objPersonRace As PersonRace)

        Dim index As Integer = List.IndexOf(objPersonRace)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the PersonRace object within the collection with a specified PersonRaceID.
    ''' </summary>
    ''' <param name="intPersonRaceID">
    '''     The PersonRaceID of the PersonRace object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the PersonRace object within the collection having the specified PersonRaceID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intPersonRaceID As Integer) As Integer

        If intPersonRaceID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objPersonRace As PersonRace = CType(List.Item(i), PersonRace)
                If Not objPersonRace.PersonRaceID.IsNull AndAlso objPersonRace.PersonRaceID.Value = intPersonRaceID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Friend Sub ResetModified()

        Dim objPersonRace As PersonRace

        For Each objPersonRace In List
            objPersonRace.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objPersonRace As PersonRace

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).PersonRaceID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objPersonRace In List
            objPersonRace.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objPersonRace As PersonRace
        Dim blnResult As Boolean = True

        For Each objPersonRace In List
            blnResult = objPersonRace.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objPersonRace As PersonRace
        Dim blnResult As Boolean = True

        For Each objPersonRace In List
            blnResult = objPersonRace.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New PersonRaces(mobjPerson)
            For Each objExistingClass As PersonRace In objExistingCollection
                If Me.IndexOf(objExistingClass.PersonRaceID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    'Public Sub New(ByVal intCaseID As Integer)

    '    Dim objPersonRace As New TblPersonRace

    '    objPersonRace.CaseID = intCaseID

    '    objPersonRace.ConnectionString = Project.ConnectionString

    '    ' If the Project's Connection Provider is open, use it
    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        objPersonRace.ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Dim objPersonPersonRaces As DataTable = objPersonRace.SelectAllWMPRIDLogic()

    '    objPersonRace.ConnectionProvider = Nothing

    '    ' Add a new Person to the collection for each Person retrieved

    '    Dim objDataRow As DataRow

    '    For Each objDataRow In objPersonPersonRaces.Rows
    '        Add(New PersonRace(objDataRow))
    '    Next

    'End Sub
    'Public Sub New(ByVal MPRID As SqlTypes.SqlInt32)

    '    Dim objPersonRace As New TblPersonRace

    '    objPersonRace.MPRID = MPRID

    '    objPersonRace.ConnectionString = Project.ConnectionString

    '    ' If the Project's Connection Provider is open, use it
    '    If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
    '        objPersonRace.ConnectionProvider = Project.ConnectionProvider
    '    End If

    '    Dim objPersonPersonRaces As DataTable = objPersonRace.SelectAllWMPRIDLogic()

    '    objPersonRace.ConnectionProvider = Nothing

    '    ' Add a new Person to the collection for each Person retrieved

    '    Dim objDataRow As DataRow

    '    For Each objDataRow In objPersonPersonRaces.Rows
    '        Add(New PersonRace(objDataRow))
    '    Next

    'End Sub

    Public Sub New(objPerson As Person)

        Dim objPersonRace As New TblPersonRace

        mobjPerson = objPerson

        objPersonRace.MPRID = objPerson.MPRID

        objPersonRace.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPersonRace.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPersonPersonRaces As DataTable = objPersonRace.SelectAllWMPRIDLogic()

        objPersonRace.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPersonPersonRaces.Rows
            Add(New PersonRace(objPerson, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonPersonRaces collection.
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
