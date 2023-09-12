'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Coder objects for the Project
''' </summary>

    Public Class Coders
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default Coder within the collection.
    ''' </summary>
    ''' <value>
    '''     The default Coder within the Coders collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first Coder in the collection or Nothing (null) is no Coders exist.
    ''' </remarks>

        Public ReadOnly Property DefaultCoder As Coder
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), Coder)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the Coder at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Coder to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Coder at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Coder

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Coder)
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
    '''     Initializes a new instance of the Coders collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Coders collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Coders

        Dim objCoder As New TlkpCoders

        objCoder.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objCoder.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objCoders As DataTable = objCoder.SelectAll()

        objCoder.ConnectionProvider = Nothing

        ' Add a new Coder to the collection for each Coder retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objCoders.Rows
            Add(New Coder(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Coder to the Coders collection.
    ''' </summary>
    ''' <param name="objCoder">
    '''     The Coder to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Coder has been added.
    ''' </returns>
    ''' <remarks>
    '''     Coders are maintained in ascending order by Coder Code.
    ''' </remarks>

        Public Function Add(objcoder As Coder) As Integer

        If objcoder.CoderId.IsNull Then
            If Not objcoder.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingCoder As Coder = CType(List.Item(i), Coder)
            If objcoder.CoderId.Value() < objExistingCoder.CoderId.Value() Then
                Exit For
            End If
        Next

        If objcoder.CoderId <> 1 Then
            List.Insert(i, objcoder)
        End If

        Return i
    End Function

    ''' <summary>
    '''     Updates a Coder in the collection.
    ''' </summary>
    ''' <param name="objCoder">
    '''     The Coder object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Coders are maintained in ascending order by Coder Code.
    ''' </remarks>

        Public Function Update(objCoder As Coder) As Boolean

        If Not objCoder.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingCoder As Coder = CType(List.Item(i), Coder)
            If objExistingCoder.CoderId.Value = objCoder.CoderID.Value Then
                List.RemoveAt(i)
                Add(objCoder)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the Coder within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Coder whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Coder within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objCoder As Coder = CType(List.Item(i), Coder)
                If objCoder.CoderId.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
