'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of SocialNetworkStatus objects for the Project
''' </summary>

    Public Class SocialNetworkStatuses
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default SocialNetworkStatus within the collection.
    ''' </summary>
    ''' <value>
    '''     The default SocialNetworkStatus within the SocialNetworkStatuses collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first SocialNetworkStatus in the collection or Nothing (null) is no SocialNetworkStatuses
    '''     exist.
    ''' </remarks>

        Public ReadOnly Property DefaultSocialNetworkStatus As SocialNetworkStatus
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), SocialNetworkStatus)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the SocialNetworkStatus at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the SocialNetworkStatus to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The SocialNetworkStatus at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As SocialNetworkStatus
        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), SocialNetworkStatus)
            End If
            Return Nothing
        End Get
    End Property

    Public ReadOnly Property ItemByStatusID(StatusID As Integer) As SocialNetworkStatus

        Get
            For Each sn As SocialNetworkStatus In List
                If sn.SocialNetworkStatusID = StatusID Then
                    Return sn
                End If
            Next
            Return Nothing
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
    '''     Initializes a new instance of the SocialNetworkStatuses collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The SocialNetworkStatuses collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's SocialNetworkStatuses

        Dim objSocialNetworkStatus As New TlkpSocialNetworkStatus

        objSocialNetworkStatus.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSocialNetworkStatus.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSocialNetworkStatuses As DataTable = objSocialNetworkStatus.SelectAll()

        objSocialNetworkStatus.ConnectionProvider = Nothing

        ' Add a new SocialNetworkStatus to the collection for each SocialNetworkStatus retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSocialNetworkStatuses.Rows
            Add(New SocialNetworkStatus(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a SocialNetworkStatus to the SocialNetworkStatuses collection.
    ''' </summary>
    ''' <param name="objSocialNetworkStatus">
    '''     The SocialNetworkStatus to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the SocialNetworkStatus has been added.
    ''' </returns>
    ''' <remarks>
    '''     SocialNetworkStatuses are maintained in ascending order by SocialNetworkStatus Code.
    ''' </remarks>

        Public Function Add(objSocialNetworkStatus As SocialNetworkStatus) As Integer

        If objSocialNetworkStatus.SocialNetworkStatusID.IsNull Then
            If Not objSocialNetworkStatus.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSocialNetworkStatus As SocialNetworkStatus = CType(List.Item(i), SocialNetworkStatus)
            If objSocialNetworkStatus.SortOrder.Value() < objExistingSocialNetworkStatus.SortOrder.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objSocialNetworkStatus)

        Return i
    End Function

    ''' <summary>
    '''     Updates a SocialNetworkStatus in the collection.
    ''' </summary>
    ''' <param name="objSocialNetworkStatus">
    '''     The SocialNetworkStatus object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     SocialNetworkStatuses are maintained in ascending order by SocialNetworkStatus Code.
    ''' </remarks>

        Public Function Update(objSocialNetworkStatus As SocialNetworkStatus) As Boolean

        If Not objSocialNetworkStatus.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSocialNetworkStatus As SocialNetworkStatus = CType(List.Item(i), SocialNetworkStatus)
            If _
                objExistingSocialNetworkStatus.SocialNetworkStatusID.Value =
                objSocialNetworkStatus.SocialNetworkStatusID.Value Then
                List.RemoveAt(i)
                Add(objSocialNetworkStatus)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the SocialNetworkStatus within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the SocialNetworkStatus whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the SocialNetworkStatus within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSocialNetworkStatus As SocialNetworkStatus = CType(List.Item(i), SocialNetworkStatus)
                If objSocialNetworkStatus.SocialNetworkStatusID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
