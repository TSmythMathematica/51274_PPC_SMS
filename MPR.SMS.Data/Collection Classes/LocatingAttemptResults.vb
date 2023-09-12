'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LocatingAttemptResult objects for the Project
''' </summary>

    Public Class LocatingAttemptResults
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default LocatingAttemptResult within the collection.
    ''' </summary>
    ''' <value>
    '''     The default LocatingAttemptResult within the LocatingAttemptResultes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first LocatingAttemptResult in the collection or Nothing (null) is no LocatingAttemptResultes
    '''     exist.
    ''' </remarks>

        Public ReadOnly Property DefaultLocatingAttemptResult As LocatingAttemptResult
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), LocatingAttemptResult)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the LocatingAttemptResult at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the LocatingAttemptResult to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The LocatingAttemptResult at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As LocatingAttemptResult

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), LocatingAttemptResult)
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
    '''     Initializes a new instance of the LocatingAttemptResultes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The LocatingAttemptResultes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's LocatingAttemptResultes

        Dim objLocatingAttemptResult As New TlkpLocatingAttemptResult

        objLocatingAttemptResult.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatingAttemptResult.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLocatingAttemptResultes As DataTable = objLocatingAttemptResult.SelectAll()

        objLocatingAttemptResult.ConnectionProvider = Nothing

        ' Add a new LocatingAttemptResult to the collection for each LocatingAttemptResult retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objLocatingAttemptResultes.Rows
            Add(New LocatingAttemptResult(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a LocatingAttemptResult to the LocatingAttemptResultes collection.
    ''' </summary>
    ''' <param name="objLocatingAttemptResult">
    '''     The LocatingAttemptResult to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the LocatingAttemptResult has been added.
    ''' </returns>
    ''' <remarks>
    '''     LocatingAttemptResultes are maintained in ascending order by LocatingAttemptResult Code.
    ''' </remarks>

        Public Function Add(objLocatingAttemptResult As LocatingAttemptResult) As Integer

        If objLocatingAttemptResult.LocatingAttemptResult.IsNull Then
            If Not objLocatingAttemptResult.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingLocatingAttemptResult As LocatingAttemptResult = CType(List.Item(i), LocatingAttemptResult)
            'If objLocatingAttemptResult.LocatingAttemptResult.ToString.ToLower() < objExistingLocatingAttemptResult.LocatingAttemptResult.ToString.ToLower() Then
            If objLocatingAttemptResult.SortOrder < objExistingLocatingAttemptResult.SortOrder Then
                Exit For
            End If
        Next

        List.Insert(i, objLocatingAttemptResult)

        Return i
    End Function

    ''' <summary>
    '''     Updates a LocatingAttemptResult in the collection.
    ''' </summary>
    ''' <param name="objLocatingAttemptResult">
    '''     The LocatingAttemptResult object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     LocatingAttemptResultes are maintained in ascending order by LocatingAttemptResult Code.
    ''' </remarks>

        Public Function Update(objLocatingAttemptResult As LocatingAttemptResult) As Boolean

        If Not objLocatingAttemptResult.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingLocatingAttemptResult As LocatingAttemptResult = CType(List.Item(i), LocatingAttemptResult)
            If _
                objExistingLocatingAttemptResult.LocatingAttemptResult.ToString =
                objLocatingAttemptResult.LocatingAttemptResult.ToString Then
                List.RemoveAt(i)
                Add(objLocatingAttemptResult)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the LocatingAttemptResult within the collection having a specific ID.
    ''' </summary>
    ''' <param name="strCode">
    '''     The Code of the LocatingAttemptResult whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LocatingAttemptResult within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(strCode As String) As Integer


        If strCode > "" Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLocatingAttemptResult As LocatingAttemptResult = CType(List.Item(i), LocatingAttemptResult)
                If objLocatingAttemptResult.LocatingAttemptResult.ToString = strCode Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
