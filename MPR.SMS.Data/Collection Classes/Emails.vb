'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Email objects.
''' </summary>

    Public Class Emails
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Email">Email</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Email">Email</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Email
        Get
            Return CType(List.Item(Index), Email)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the Email object within the collection with a specified EmailID.
    ''' </summary>
    ''' <param name="intEmailID">
    '''     The EmailID of the Email object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Email object within the collection having the specified EmailID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intEmailID As Integer) As Integer

        If intEmailID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objEmail As Email = CType(List.Item(i), Email)
                If Not objEmail.EmailID.IsNull AndAlso objEmail.EmailID.Value = intEmailID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified Email object.
    ''' </summary>
    ''' <param name="objEmail">
    '''     The Email object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Email object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objEmail As Email) As Integer

        If Not objEmail Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objEmail) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Email object within the Email collection.
    ''' </summary>
    ''' <param name="objEmail">
    '''     The Email object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objEmail As Email)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objEmail)
        If intIndex < 0 AndAlso objEmail.IsValid Then
            objEmail.Case = mobjCase
            Me.Add(objEmail)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objEmail
        End If
    End Sub
    'Public ReadOnly Property PrimaryEmail() As Email
    '    Get
    '        For Each Email As Email In Me
    '            If Email.IsPrimaryEmail Then
    '                Return Email
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Email">Email</see> object to the end of the Emails collection.
    ''' </summary>
    ''' <param name="objEmail">
    '''     The <see cref="T:MPR.SMS.Data.Email">Email</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Email">Email</see> object has been added.
    ''' </returns>

        Public Function Add(objEmail As Email) As Integer

        Return List.Add(objEmail)
    End Function

    Public Sub Remove(objEmail As Email)

        Dim index As Integer = List.IndexOf(objEmail)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objEmail As Email
            For Each objEmail In List
                If objEmail.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    Friend Sub ResetModified()

        Dim objEmail As Email

        For Each objEmail In List
            objEmail.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objEmail As Email

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).EmailID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objEmail In List
            objEmail.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objEmail As Email
        Dim blnResult As Boolean = True

        For Each objEmail In List
            blnResult = objEmail.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objEmail As Email
        Dim blnResult As Boolean = True

        For Each objEmail In List
            blnResult = objEmail.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Emails(mobjCase)
            For Each objExistingClass As Email In objExistingCollection
                If Me.IndexOf(objExistingClass.EmailID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objEmail As New TblEmail

        mobjCase = objCase

        objEmail.CaseID = objCase.CaseID

        objEmail.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objEmail.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objEmails As DataTable = objEmail.SelectAllWCaseIDLogic()

        objEmail.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objEmails.Rows
            Add(New Email(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Emails collection.
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