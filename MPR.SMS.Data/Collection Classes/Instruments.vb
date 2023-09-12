'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Instrument objects.
''' </summary>

    Public Class Instruments
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
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
    '''     Gets the Instrument object at a specific index.
    ''' </summary>
    ''' <param name="Index">
    '''     The index of the Instrument object to be retrieved.
    ''' </param>
    ''' <value>
    '''     The Instrument object at the specified index within the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Instrument
        Get
            Return CType(List.Item(Index), Instrument)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objInstrument As Instrument
            For Each objInstrument In List
                If objInstrument.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Instrument object to the end of the collection.
    ''' </summary>
    ''' <param name="objInstrument">
    '''     The Instrument object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The index at which the Instrument object has been added within the collection.
    ''' </returns>

        Public Function Add(objInstrument As Instrument) As Integer

        Return List.Add(objInstrument)
    End Function

    Public Sub Remove(objInstrument As Instrument)

        Dim index As Integer = List.IndexOf(objInstrument)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the Instrument object within the collection with a specified InstrumentID.
    ''' </summary>
    ''' <param name="intInstrumentID">
    '''     The InstrumentID of the Instrument object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Instrument object within the collection having the specified InstrumentID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intInstrumentID As Integer) As Integer

        If intInstrumentID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInstrument As Instrument = CType(List.Item(i), Instrument)
                If Not objInstrument.InstrumentID.IsNull AndAlso objInstrument.InstrumentID.Value = intInstrumentID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Instrument object.
    ''' </summary>
    ''' <param name="objInstrument">
    '''     The Instrument object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Instrument object within the collection,
    '''     or -1 if not found.
    ''' </returns>

    Public Function IndexOfObject(objInstrument As Instrument) As Integer

        If Not objInstrument Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objInstrument) Then
                    Return i
                End If
            Next
        End If

        Return -1
    End Function

    Public Function GetByInstrumentTypeID(ByVal instrumentTypeId As Integer) As Instrument

        If instrumentTypeId > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInstrument As Instrument = CType(List.Item(i), Instrument)
                If Not objInstrument.InstrumentTypeID.IsNull AndAlso objInstrument.InstrumentTypeID.Value = instrumentTypeId Then
                    Return objInstrument
                End If
            Next
        End If

        Return Nothing

    End Function

    ''' <summary>
    '''     Adds/Updates a Instrument object within the Instrument collection.
    ''' </summary>
    ''' <param name="objInstrument">
    '''     The Instrument object to find and add/update into the collection.
    ''' </param>

    Public Sub ModifyObjectInCollection(objInstrument As Instrument)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objInstrument)
        If intIndex < 0 Then
            objInstrument.Case = mobjCase
            Me.Add(objInstrument)
        Else
            Me.Item(intIndex) = objInstrument
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objInstrument As Instrument

        For Each objInstrument In List
            objInstrument.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objInstrument As Instrument

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).InstrumentID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While

        For Each objInstrument In List
            objInstrument.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objInstrument As Instrument
        Dim blnResult As Boolean = True

        For Each objInstrument In List
            blnResult = objInstrument.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objInstrument As Instrument
        Dim blnResult As Boolean = True

        For Each objInstrument In List
            blnResult = objInstrument.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Instruments(mobjCase)
            For Each objExistingClass As Instrument In objExistingCollection
                If Me.IndexOf(objExistingClass.InstrumentID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objInstrument As New TblInstrument

        mobjCase = objCase

        objInstrument.CaseID = objCase.CaseID

        objInstrument.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInstrument.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInstruments As DataTable = objInstrument.SelectAllWCaseIDLogic()

        objInstrument.ConnectionProvider = Nothing

        ' Add a new Instrument to the collection for each Instrument retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInstruments.Rows
            Add(New Instrument(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Instruments collection.
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
