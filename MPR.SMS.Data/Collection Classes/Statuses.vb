'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Status objects for the Project
''' </summary>

    Public Class Statuses
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default Status within the collection.
    ''' </summary>
    ''' <value>
    '''     The default Status within the Statuses collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first Status in the collection or Nothing (null) is no Statuses exist.
    ''' </remarks>

        Public ReadOnly Property DefaultStatus As Status
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), Status)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the Status at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Status to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Status at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Status

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Status)
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
    '''     Initializes a new instance of the Statuses collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Statuses collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Statuses

        Dim objStatus As New TlkpStatus

        objStatus.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objStatus.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objStatuses As DataTable = objStatus.SelectAll()

        objStatus.ConnectionProvider = Nothing

        ' Add a new Status to the collection for each Status retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objStatuses.Rows
            Add(New Status(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Status to the Statuses collection.
    ''' </summary>
    ''' <param name="objStatus">
    '''     The Status to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Status has been added.
    ''' </returns>
    ''' <remarks>
    '''     Statuses are maintained in ascending order by Status Code.
    ''' </remarks>

        Public Function Add(objStatus As Status) As Integer

        If objStatus.Code.IsNull Then
            If Not objStatus.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingStatus As Status = CType(List.Item(i), Status)
            If objStatus.Code.Value.ToLower() < objExistingStatus.Code.Value.ToLower() Then
                Exit For
            End If
        Next

        List.Insert(i, objStatus)

        Return i
    End Function

    ''' <summary>
    '''     Updates a Status in the collection.
    ''' </summary>
    ''' <param name="objStatus">
    '''     The Status object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Statuses are maintained in ascending order by Status Code.
    ''' </remarks>

        Public Function Update(objStatus As Status) As Boolean

        If Not objStatus.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingStatus As Status = CType(List.Item(i), Status)
            If objExistingStatus.Code.Value = objStatus.Code.Value Then
                List.RemoveAt(i)
                Add(objStatus)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the Status within the collection having a specific ID.
    ''' </summary>
    ''' <param name="strCode">
    '''     The Code of the Status whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Status within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(strCode As String) As Integer


        If strCode > "" Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objStatus As Status = CType(List.Item(i), Status)
                If objStatus.Code.ToString = strCode Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
