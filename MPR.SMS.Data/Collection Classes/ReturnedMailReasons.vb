'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of ReturnedMailReason objects for the Project
''' </summary>

    Public Class ReturnedMailReasons
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default ReturnedMailReason within the collection.
    ''' </summary>
    ''' <value>
    '''     The default ReturnedMailReason within the ReturnedMailReasons collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first ReturnedMailReason in the collection or Nothing (null) is no ReturnedMailReasons exist.
    ''' </remarks>

        Public ReadOnly Property DefaultReturnedMail As ReturnedMailReason
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), ReturnedMailReason)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the ReturnedMailReason at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the ReturnedMailReason to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The ReturnedMailReason at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As ReturnedMailReason

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), ReturnedMailReason)
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
    '''     Initializes a new instance of the ReturnedMailReasons collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The ReturnedMailReasons collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's ReturnedMailReasons

        Dim objReturnedMailReason As New TlkpReturnedMailReason

        objReturnedMailReason.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objReturnedMailReason.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objReturnedMailReasons As DataTable = objReturnedMailReason.SelectAll()

        objReturnedMailReason.ConnectionProvider = Nothing

        ' Add a new ReturnedMailReason to the collection for each ReturnedMailReason retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objReturnedMailReasons.Rows
            Add(New ReturnedMailReason(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a ReturnedMailReason to the ReturnedMailReasons collection.
    ''' </summary>
    ''' <param name="objReturnedMailReason">
    '''     The ReturnedMailReason to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the ReturnedMailReason has been added.
    ''' </returns>
    ''' <remarks>
    '''     ReturnedMailReasons are maintained in ascending order by ReturnedMailReason Code.
    ''' </remarks>

        Public Function Add(objReturnedMailReason As ReturnedMailReason) As Integer

        If objReturnedMailReason.ReturnedMailReasonID.IsNull Then
            If Not objReturnedMailReason.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingReturnedMail As ReturnedMailReason = CType(List.Item(i), ReturnedMailReason)
            If objReturnedMailReason.ReturnedMailReasonID.Value() < objExistingReturnedMail.ReturnedMailReasonID.Value() _
                Then
                Exit For
            End If
        Next

        List.Insert(i, objReturnedMailReason)

        Return i
    End Function

    ''' <summary>
    '''     Updates a ReturnedMailReason in the collection.
    ''' </summary>
    ''' <param name="objReturnedMailReason">
    '''     The ReturnedMailReason object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     ReturnedMailReasons are maintained in ascending order by ReturnedMailReason Code.
    ''' </remarks>

        Public Function Update(objReturnedMailReason As ReturnedMailReason) As Boolean

        If Not objReturnedMailReason.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingReturnedMail As ReturnedMailReason = CType(List.Item(i), ReturnedMailReason)
            If objExistingReturnedMail.ReturnedMailReasonID.Value = objReturnedMailReason.ReturnedMailReasonID.Value _
                Then
                List.RemoveAt(i)
                Add(objReturnedMailReason)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the ReturnedMailReason within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the ReturnedMailReason whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the ReturnedMailReason within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objReturnedMailReason As ReturnedMailReason = CType(List.Item(i), ReturnedMailReason)
                If objReturnedMailReason.ReturnedMailReasonID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
