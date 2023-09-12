'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of SocialNetworkType objects for the Project
''' </summary>

    Public Class SocialNetworkTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default SocialNetworkType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default SocialNetworkType within the SocialNetworkTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first SocialNetworkType in the collection or Nothing (null) is no SocialNetworkTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultSocialNetworkType As SocialNetworkType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), SocialNetworkType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the SocialNetworkType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the SocialNetworkType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The SocialNetworkType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As SocialNetworkType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), SocialNetworkType)
            End If
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
    '''     Initializes a new instance of the SocialNetworkTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The SocialNetworkTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's SocialNetworkTypes

        Dim objSocialNetworkType As New TlkpSocialNetworkType

        objSocialNetworkType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSocialNetworkType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSocialNetworkTypes As DataTable = objSocialNetworkType.SelectAll()

        objSocialNetworkType.ConnectionProvider = Nothing

        ' Add a new SocialNetworkType to the collection for each SocialNetworkType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSocialNetworkTypes.Rows
            Add(New SocialNetworkType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a SocialNetworkType to the SocialNetworkTypes collection.
    ''' </summary>
    ''' <param name="objSocialNetworkType">
    '''     The SocialNetworkType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the SocialNetworkType has been added.
    ''' </returns>
    ''' <remarks>
    '''     SocialNetworkTypes are maintained in ascending order by SocialNetworkType Code.
    ''' </remarks>

        Public Function Add(objSocialNetworkType As SocialNetworkType) As Integer

        If objSocialNetworkType.SocialNetworkTypeID.IsNull Then
            If Not objSocialNetworkType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSocialNetworkType As SocialNetworkType = CType(List.Item(i), SocialNetworkType)
            If _
                objSocialNetworkType.SocialNetworkTypeID.Value() <
                objExistingSocialNetworkType.SocialNetworkTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objSocialNetworkType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a SocialNetworkType in the collection.
    ''' </summary>
    ''' <param name="objSocialNetworkType">
    '''     The SocialNetworkType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     SocialNetworkTypes are maintained in ascending order by SocialNetworkType Code.
    ''' </remarks>

        Public Function Update(objSocialNetworkType As SocialNetworkType) As Boolean

        If Not objSocialNetworkType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSocialNetworkType As SocialNetworkType = CType(List.Item(i), SocialNetworkType)
            If objExistingSocialNetworkType.SocialNetworkTypeID.Value = objSocialNetworkType.SocialNetworkTypeID.Value _
                Then
                List.RemoveAt(i)
                Add(objSocialNetworkType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the SocialNetworkType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the SocialNetworkType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the SocialNetworkType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSocialNetworkType As SocialNetworkType = CType(List.Item(i), SocialNetworkType)
                If objSocialNetworkType.SocialNetworkTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
