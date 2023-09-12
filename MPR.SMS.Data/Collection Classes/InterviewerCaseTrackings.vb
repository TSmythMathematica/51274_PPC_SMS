'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewerCaseTracking objects for the Project
''' </summary>

    Public Class InterviewerCaseTrackings
    Inherits CollectionBase

#Region "Private Variables"

    Private ReadOnly mobjCase As [Case]
    Private mblnObjDeleted As Boolean = False

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewerCaseTracking at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewerCaseTracking to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewerCaseTracking at the specified index within the collection.
    ''' </value>

        Default Public Property Item(index As Integer) As InterviewerCaseTracking

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewerCaseTracking)
            End If
            Return Nothing
        End Get
        Set
            List.Item(index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objInterviewerCaseTracking As InterviewerCaseTracking
            For Each objInterviewerCaseTracking In List
                If objInterviewerCaseTracking.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

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

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the InterviewerCaseTrackings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerCaseTrackings from the database. Do  not modify records in
    '''     the collection if this constructor is used.
    ''' </remarks>

        Public Sub New()

        Dim objInterviewerCaseTracking As New TblInterviewerCaseTracking

        objInterviewerCaseTracking.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerCaseTracking.ConnectionProvider = Project.ConnectionProvider
        End If

        mobjCase = Nothing
        Dim objInterviewerCaseTrackings As DataTable = objInterviewerCaseTracking.SelectAll()

        objInterviewerCaseTracking.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerCaseTrackings.Rows
            Add(New InterviewerCaseTracking(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerCaseTrackings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all InterviewerCaseTrackings for a Case
    ''' </remarks>

        Public Sub New(objCase As [Case])

        ' Retrieve the Project's InterviewerCaseTrackings

        Dim objInterviewerCaseTracking As New TblInterviewerCaseTracking

        mobjCase = objCase

        objInterviewerCaseTracking.CaseID = objCase.CaseID
        objInterviewerCaseTracking.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerCaseTracking.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInterviewerCaseTrackings As DataTable = objInterviewerCaseTracking.SelectAllWCaseIDLogic

        objInterviewerCaseTracking.ConnectionProvider = Nothing

        ' Add a new InterviewerCaseTracking to the collection for each InterviewerCaseTracking retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerCaseTrackings.Rows
            Add(New InterviewerCaseTracking(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerCaseTrackings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all InterviewerCaseTrackings for an Interviewer
    ''' </remarks>

        Public Sub New(intInterviewerID As Integer)

        ' Retrieve the Project's InterviewerCaseTrackings

        Dim objInterviewerCaseTracking As New TblInterviewerCaseTracking

        objInterviewerCaseTracking.InterviewerID = New SqlInt32(intInterviewerID)
        objInterviewerCaseTracking.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerCaseTracking.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInterviewerCaseTrackings As DataTable = objInterviewerCaseTracking.SelectAllWInterviewerIDLogic

        objInterviewerCaseTracking.ConnectionProvider = Nothing

        ' Add a new InterviewerCaseTracking to the collection for each InterviewerCaseTracking retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerCaseTrackings.Rows
            Add(New InterviewerCaseTracking(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewerCaseTracking to the InterviewerCaseTrackings collection.
    ''' </summary>
    ''' <param name="objInterviewerCaseTracking">
    '''     The InterviewerCaseTracking to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewerCaseTracking has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerCaseTrackings are maintained in ascending order by InterviewerCaseTrackingID.
    ''' </remarks>

        Public Function Add(objInterviewerCaseTracking As InterviewerCaseTracking) As Integer

        Return List.Add(objInterviewerCaseTracking)
    End Function

    Public Sub Remove(objInterviewerCaseTracking As InterviewerCaseTracking)

        Dim index As Integer = List.IndexOf(objInterviewerCaseTracking)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Updates a InterviewerCaseTracking in the collection.
    ''' </summary>
    ''' <param name="objInterviewerCaseTracking">
    '''     The InterviewerCaseTracking object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerCaseTrackings are maintained in ascending order by InterviewerCaseTracking Code.
    ''' </remarks>

        Public Function Update(objInterviewerCaseTracking As InterviewerCaseTracking) As Boolean

        If Not objInterviewerCaseTracking.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewerCaseTracking As InterviewerCaseTracking = CType(List.Item(i),
                                                                                      InterviewerCaseTracking)
            If _
                objExistingInterviewerCaseTracking.InterviewerCaseTrackingID.Value =
                objInterviewerCaseTracking.InterviewerCaseTrackingID.Value Then
                List.RemoveAt(i)
                Add(objInterviewerCaseTracking)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the InterviewerCaseTracking within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the InterviewerCaseTracking whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the InterviewerCaseTracking within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewerCaseTracking As InterviewerCaseTracking = CType(List.Item(i), InterviewerCaseTracking)
                If objInterviewerCaseTracking.InterviewerCaseTrackingID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified InterviewerCaseTracking object.
    ''' </summary>
    ''' <param name="objInterviewerCaseTracking">
    '''     The InterviewerCaseTracking object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified InterviewerCaseTracking object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objInterviewerCaseTracking As InterviewerCaseTracking) As Integer

        If Not objInterviewerCaseTracking Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objInterviewerCaseTracking) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a InterviewerCaseTracking object within the InterviewerCaseTracking collection.
    ''' </summary>
    ''' <param name="objInterviewerCaseTracking">
    '''     The InterviewerCaseTracking object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objInterviewerCaseTracking As InterviewerCaseTracking)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objInterviewerCaseTracking)
        If intIndex < 0 Then
            objInterviewerCaseTracking.Case = mobjCase
            Me.Add(objInterviewerCaseTracking)
        Else
            Me.Item(intIndex) = objInterviewerCaseTracking
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objInterviewerCaseTracking As InterviewerCaseTracking

        For Each objInterviewerCaseTracking In List
            objInterviewerCaseTracking.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objInterviewerCaseTracking As InterviewerCaseTracking

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).InterviewerCaseTrackingID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While

        For Each objInterviewerCaseTracking In List
            objInterviewerCaseTracking.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objInterviewerCaseTracking As InterviewerCaseTracking
        Dim blnResult As Boolean = True

        For Each objInterviewerCaseTracking In List
            blnResult = objInterviewerCaseTracking.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objInterviewerCaseTracking As InterviewerCaseTracking
        Dim blnResult As Boolean = True

        For Each objInterviewerCaseTracking In List
            blnResult = objInterviewerCaseTracking.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New InterviewerCaseTrackings(mobjCase)
            For Each objExistingClass As InterviewerCaseTracking In objExistingCollection
                If Me.IndexOf(objExistingClass.InterviewerCaseTrackingID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region
End Class
