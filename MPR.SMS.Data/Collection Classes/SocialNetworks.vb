'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of SocialNetwork objects.
''' </summary>

    Public Class SocialNetworks
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
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object at the specified index within the
    '''     collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As SocialNetwork
        Get
            Return CType(List.Item(Index), SocialNetwork)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the SocialNetwork object within the collection with a specified SocialNetworkID.
    ''' </summary>
    ''' <param name="intSocialNetworkID">
    '''     The SocialNetworkID of the SocialNetwork object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the SocialNetwork object within the collection having the specified SocialNetworkID,
    '''     or -1 if not found.
    ''' </returns>

        Friend Function IndexOf(intSocialNetworkID As Integer) As Integer

        If intSocialNetworkID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSocialNetwork As SocialNetwork = CType(List.Item(i), SocialNetwork)
                If _
                    Not objSocialNetwork.SocialNetworkID.IsNull AndAlso
                    objSocialNetwork.SocialNetworkID.Value = intSocialNetworkID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Gets the index of the specified SocialNetwork object.
    ''' </summary>
    ''' <param name="objSocialNetwork">
    '''     The SocialNetwork object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified SocialNetwork object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objSocialNetwork As SocialNetwork) As Integer

        If Not objSocialNetwork Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objSocialNetwork) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a SocialNetwork object within the SocialNetwork collection.
    ''' </summary>
    ''' <param name="objSocialNetwork">
    '''     The SocialNetwork object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objSocialNetwork As SocialNetwork)
        'put the Person object into the Case object
        Dim intIndex As Integer = Me.IndexOfObject(objSocialNetwork)
        If intIndex < 0 AndAlso objSocialNetwork.IsValid Then
            objSocialNetwork.Case = mobjCase
            Me.Add(objSocialNetwork)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objSocialNetwork
        End If
    End Sub
    'Public ReadOnly Property PrimarySocialNetwork() As SocialNetwork
    '    Get
    '        For Each SocialNetwork As SocialNetwork In Me
    '            If SocialNetwork.IsPrimarySocialNetwork Then
    '                Return SocialNetwork
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object to the end of the SocialNetworks
    '''     collection.
    ''' </summary>
    ''' <param name="objSocialNetwork">
    '''     The <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.SocialNetwork">SocialNetwork</see> object has been
    '''     added.
    ''' </returns>

        Public Function Add(objSocialNetwork As SocialNetwork) As Integer

        Return List.Add(objSocialNetwork)
    End Function

    Public Sub Remove(objSocialNetwork As SocialNetwork)

        Dim index As Integer = List.IndexOf(objSocialNetwork)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objSocialNetwork As SocialNetwork
            For Each objSocialNetwork In List
                If objSocialNetwork.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    Friend Sub ResetModified()

        Dim objSocialNetwork As SocialNetwork

        For Each objSocialNetwork In List
            objSocialNetwork.ResetModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objSocialNetwork As SocialNetwork

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).SocialNetworkID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While


        For Each objSocialNetwork In List
            objSocialNetwork.RestoreModified()
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objSocialNetwork As SocialNetwork
        Dim blnResult As Boolean = True

        For Each objSocialNetwork In List
            blnResult = objSocialNetwork.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objSocialNetwork As SocialNetwork
        Dim blnResult As Boolean = True

        For Each objSocialNetwork In List
            blnResult = objSocialNetwork.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New SocialNetworks(mobjCase)
            For Each objExistingClass As SocialNetwork In objExistingCollection
                If Me.IndexOf(objExistingClass.SocialNetworkID.Value) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objSocialNetwork As New TblSocialNetwork

        mobjCase = objCase

        objSocialNetwork.CaseID = objCase.CaseID

        objSocialNetwork.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSocialNetwork.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSocialNetworks As DataTable = objSocialNetwork.SelectAllWCaseIDLogic()

        objSocialNetwork.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSocialNetworks.Rows
            Add(New SocialNetwork(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the SocialNetworks collection.
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
