'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Phone objects.
''' </summary>

    Public Class Phones
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Phone">Phone</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Phone">Phone</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Phone
        Get
            Return CType(List.Item(Index), Phone)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the Phone object within the collection with a specified PhoneID.
    ''' </summary>
    ''' <param name="intPhoneID">
    '''     The PhoneID of the Phone object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Phone object within the collection having the specified PhoneID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intPhoneID As Integer) As Integer

        If intPhoneID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objPhone As Phone = CType(List.Item(i), Phone)
                If Not objPhone.PhoneID.IsNull AndAlso objPhone.PhoneID.Value = intPhoneID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Phone object.
    ''' </summary>
    ''' <param name="objPhone">
    '''     The Phone object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Phone object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objPhone As Phone) As Integer

        If Not objPhone Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objPhone) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Phone object within the Phone collection.
    ''' </summary>
    ''' <param name="objPhone">
    '''     The Phone object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objPhone As Phone)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objPhone)
        If intIndex < 0 AndAlso objPhone.IsValid Then
            objPhone.Case = mobjCase
            Me.Add(objPhone)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objPhone
        End If
    End Sub

    'Public ReadOnly Property DialingPhone() As Phone
    '    Get
    '        For Each Phone As Phone In Me
    '            If Phone.IsDialingPhone Then
    '                Return Phone
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Phone">Phone</see> object to the end of the Phones collection.
    ''' </summary>
    ''' <param name="objPhone">
    '''     The <see cref="T:MPR.SMS.Data.Phone">Phone</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Phone">Phone</see> object has been added.
    ''' </returns>

        Public Function Add(objPhone As Phone) As Integer

        Return List.Add(objPhone)
    End Function

    Public Sub Remove(objPhone As Phone)

        Dim index As Integer = List.IndexOf(objPhone)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objPhone As Phone
            For Each objPhone In List
                If objPhone.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    Friend Sub ResetModified()

        Dim objPhone As Phone

        For Each objPhone In List
            objPhone.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objPhone As Phone

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).PhoneID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objPhone In List
            objPhone.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objPhone As Phone
        Dim blnResult As Boolean = True

        For Each objPhone In List
            blnResult = objPhone.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objPhone As Phone
        Dim blnResult As Boolean = True

        For Each objPhone In List
            blnResult = objPhone.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Phones(mobjCase)
            For Each objExistingClass As Phone In objExistingCollection
                If Me.IndexOf(objExistingClass.PhoneID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objPhone As New TblPhone

        mobjCase = objCase

        objPhone.CaseID = objCase.CaseID

        objPhone.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPhone.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPhones As DataTable = objPhone.SelectAllWCaseIDLogic()

        objPhone.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPhones.Rows
            Add(New Phone(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Phones collection.
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
