'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Address objects.
''' </summary>

    Public Class Addresses
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Address">Address</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">Address</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Address
        Get
            Return CType(List.Item(Index), Address)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objAddress As Address
            For Each objAddress In List
                If objAddress.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Address">Address</see> object to the end of the Addresses collection.
    ''' </summary>
    ''' <param name="objAddress">
    '''     The <see cref="T:MPR.SMS.Data.Address">Address</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Address">Address</see> object has been added.
    ''' </returns>

        Public Function Add(objAddress As Address) As Integer

        Return List.Add(objAddress)
    End Function

    Public Sub Remove(objAddress As Address)

        Dim index As Integer = List.IndexOf(objAddress)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Friend Sub ResetModified()

        Dim objAddress As Address

        For Each objAddress In List
            objAddress.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objAddress As Address

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).AddressID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objAddress In List
            objAddress.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objAddress As Address
        Dim blnResult As Boolean = True

        For Each objAddress In List
            blnResult = objAddress.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objAddress As Address
        Dim blnResult As Boolean = True

        For Each objAddress In List
            blnResult = objAddress.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Addresses(mobjCase)
            For Each objExistingClass As Address In objExistingCollection
                If Me.IndexOf(objExistingClass.AddressID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Gets the index of the Address object within the collection with a specified AddressID.
    ''' </summary>
    ''' <param name="intAddressID">
    '''     The AddressID of the Address object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Address object within the collection having the specified AddressID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intAddressID As Integer) As Integer

        If intAddressID > 0 Then
            For i As Integer = 0 To (Count - 1)
                Dim objAddress As Address = CType(List.Item(i), Address)
                If Not objAddress.AddressID.IsNull AndAlso objAddress.AddressID.Value = intAddressID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Address object.
    ''' </summary>
    ''' <param name="objAddress">
    '''     The Address object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Address object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objAddress As Address) As Integer

        If Not objAddress Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objAddress) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Address object within the Address collection.
    ''' </summary>
    ''' <param name="objAddress">
    '''     The Address object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objAddress As Address)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objAddress)
        If intIndex < 0 AndAlso objAddress.IsValid Then
            objAddress.Case = mobjCase
            Me.Add(objAddress)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objAddress
        End If
    End Sub

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objAddress As New TblAddress

        mobjCase = objCase

        objAddress.CaseID = objCase.CaseID

        objAddress.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objAddress.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objAddresses As DataTable = objAddress.SelectAllWCaseIDLogic()

        objAddress.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objAddresses.Rows
            Add(New Address(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Addresses collection.
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
