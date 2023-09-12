'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewerTracking objects for the Project
''' </summary>

    Public Class InterviewerTrackings
    Inherits CollectionBase

#Region "Private Variables"

    Private ReadOnly mobjInterviewer As Interviewer
    Private mblnObjDeleted As Boolean = False

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewerTracking at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewerTracking to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewerTracking at the specified index within the collection.
    ''' </value>

        Default Public Property Item(index As Integer) As InterviewerTracking

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewerTracking)
            End If
            Return Nothing
        End Get
        Set
            List.Item(index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objInterviewerTracking As InterviewerTracking
            For Each objInterviewerTracking In List
                If objInterviewerTracking.IsModified Then
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
    '''     Initializes a new instance of the InterviewerTrackings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerTrackings from the database. Do  not modify records in
    '''     the collection if this constructor is used.
    ''' </remarks>

        Public Sub New()

        Dim objInterviewerTracking As New TblInterviewerTracking

        objInterviewerTracking.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerTracking.ConnectionProvider = Project.ConnectionProvider
        End If

        mobjInterviewer = Nothing
        Dim objInterviewerTrackings As DataTable = objInterviewerTracking.SelectAll()

        objInterviewerTracking.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerTrackings.Rows
            Add(New InterviewerTracking(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerTrackings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns all InterviewerTrackings for an Interviewer
    ''' </remarks>

        Public Sub New(objInterviewer As Interviewer)

        ' Retrieve the Project's InterviewerTrackings

        mobjInterviewer = objInterviewer

        Dim objInterviewerTracking As New TblInterviewerTracking

        objInterviewerTracking.ConnectionString = Project.ConnectionString

        objInterviewerTracking.InterviewerID = objInterviewer.InterviewerID

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerTracking.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInterviewerTrackings As DataTable = objInterviewerTracking.SelectAllWInterviewerIDLogic

        objInterviewerTracking.ConnectionProvider = Nothing

        ' Add a new InterviewerTracking to the collection for each InterviewerTracking retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerTrackings.Rows
            Add(New InterviewerTracking(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewerTracking to the InterviewerTrackings collection.
    ''' </summary>
    ''' <param name="objInterviewerTracking">
    '''     The InterviewerTracking to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewerTracking has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerTrackings are maintained in ascending order by InterviewerTrackingID.
    ''' </remarks>

        Public Function Add(objInterviewerTracking As InterviewerTracking) As Integer

        Return List.Add(objInterviewerTracking)
    End Function

    Public Sub Remove(objInterviewerTracking As InterviewerTracking)

        Dim index As Integer = List.IndexOf(objInterviewerTracking)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Updates a InterviewerTracking in the collection.
    ''' </summary>
    ''' <param name="objInterviewerTracking">
    '''     The InterviewerTracking object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerTrackings are maintained in ascending order by InterviewerTracking Code.
    ''' </remarks>

        Public Function Update(objInterviewerTracking As InterviewerTracking) As Boolean

        If Not objInterviewerTracking.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewerTracking As InterviewerTracking = CType(List.Item(i), InterviewerTracking)
            If _
                objExistingInterviewerTracking.InterviewerTrackingID.Value =
                objInterviewerTracking.InterviewerTrackingID.Value Then
                List.RemoveAt(i)
                Add(objInterviewerTracking)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the InterviewerTracking within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the InterviewerTracking whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the InterviewerTracking within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewerTracking As InterviewerTracking = CType(List.Item(i), InterviewerTracking)
                If objInterviewerTracking.InterviewerTrackingID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified InterviewerTracking object.
    ''' </summary>
    ''' <param name="objInterviewerTracking">
    '''     The InterviewerTracking object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified InterviewerTracking object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objInterviewerTracking As InterviewerTracking) As Integer

        If Not objInterviewerTracking Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objInterviewerTracking) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a InterviewerTracking object within the InterviewerTracking collection.
    ''' </summary>
    ''' <param name="objInterviewerTracking">
    '''     The InterviewerTracking object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objInterviewerTracking As InterviewerTracking)
        'put the Tracking object into the Trackings collection
        Dim intIndex As Integer = Me.IndexOfObject(objInterviewerTracking)
        If intIndex < 0 Then
            objInterviewerTracking.Interviewer = mobjInterviewer
            Me.Add(objInterviewerTracking)
        Else
            Me.Item(intIndex) = objInterviewerTracking
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objInterviewerTracking As InterviewerTracking

        For Each objInterviewerTracking In List
            objInterviewerTracking.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objInterviewerTracking As InterviewerTracking

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).InterviewerTrackingID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While

        For Each objInterviewerTracking In List
            objInterviewerTracking.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objInterviewerTracking As InterviewerTracking
        Dim blnResult As Boolean = True

        For Each objInterviewerTracking In List
            blnResult = objInterviewerTracking.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objInterviewerTracking As InterviewerTracking
        Dim blnResult As Boolean = True

        For Each objInterviewerTracking In List
            blnResult = objInterviewerTracking.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New InterviewerTrackings(mobjInterviewer)
            For Each objExistingClass As InterviewerTracking In objExistingCollection
                If Me.IndexOf(objExistingClass.InterviewerTrackingID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region
End Class
