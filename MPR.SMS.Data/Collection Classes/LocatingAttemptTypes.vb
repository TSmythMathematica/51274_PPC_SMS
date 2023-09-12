'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LocatingAttemptType objects for the Project
''' </summary>

    Public Class LocatingAttemptTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default LocatingAttemptType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default LocatingAttemptType within the LocatingAttemptTypees collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first LocatingAttemptType in the collection or Nothing (null) is no LocatingAttemptTypees
    '''     exist.
    ''' </remarks>

        Public ReadOnly Property DefaultLocatingAttemptType As LocatingAttemptType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), LocatingAttemptType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the LocatingAttemptType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the LocatingAttemptType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The LocatingAttemptType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As LocatingAttemptType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), LocatingAttemptType)
            End If
            Return Nothing
        End Get
    End Property

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

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the LocatingAttemptTypees collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The LocatingAttemptTypees collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's LocatingAttemptTypees

        Dim objLocatingAttemptType As New TlkpLocatingAttemptType

        objLocatingAttemptType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatingAttemptType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLocatingAttemptTypes As DataTable = objLocatingAttemptType.SelectAll()

        objLocatingAttemptType.ConnectionProvider = Nothing

        ' Add a new LocatingAttemptType to the collection for each LocatingAttemptType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objLocatingAttemptTypes.Rows
            If CType(objDataRow("IsActive"), Boolean) = True And CType(objDataRow("IsFieldLocating"), Boolean) = False _
                Then
                Add(New LocatingAttemptType(objDataRow))
            End If
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a LocatingAttemptType to the LocatingAttemptTypees collection.
    ''' </summary>
    ''' <param name="objLocatingAttemptType">
    '''     The LocatingAttemptType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the LocatingAttemptType has been added.
    ''' </returns>
    ''' <remarks>
    '''     LocatingAttemptTypees are maintained in ascending order by LocatingAttemptType SortOrder.
    ''' </remarks>

        Public Function Add(objLocatingAttemptType As LocatingAttemptType) As Integer

        If objLocatingAttemptType.LocatingAttemptType.IsNull Then
            If Not objLocatingAttemptType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingLocatingAttemptType As LocatingAttemptType = CType(List.Item(i), LocatingAttemptType)
            'If objLocatingAttemptType.LocatingAttemptType.ToString.ToLower() < objExistingLocatingAttemptType.LocatingAttemptType.ToString.ToLower() Then
            If objLocatingAttemptType.SortOrder < objExistingLocatingAttemptType.SortOrder Then
                Exit For
            End If
        Next

        List.Insert(i, objLocatingAttemptType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a LocatingAttemptType in the collection.
    ''' </summary>
    ''' <param name="objLocatingAttemptType">
    '''     The LocatingAttemptType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     LocatingAttemptTypees are maintained in ascending order by LocatingAttemptType Code.
    ''' </remarks>

        Public Function Update(objLocatingAttemptType As LocatingAttemptType) As Boolean

        If Not objLocatingAttemptType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingLocatingAttemptType As LocatingAttemptType = CType(List.Item(i), LocatingAttemptType)
            If _
                objExistingLocatingAttemptType.LocatingAttemptType.ToString =
                objLocatingAttemptType.LocatingAttemptType.ToString Then
                List.RemoveAt(i)
                Add(objLocatingAttemptType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the LocatingAttemptType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="strCode">
    '''     The Code of the LocatingAttemptType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LocatingAttemptType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(strCode As String) As Integer


        If strCode > "" Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLocatingAttemptType As LocatingAttemptType = CType(List.Item(i), LocatingAttemptType)
                If objLocatingAttemptType.LocatingAttemptType.ToString = strCode Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
