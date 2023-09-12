'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of SourceQuality objects for the Project
''' </summary>

    Public Class SourceQualities
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default SourceQuality within the collection.
    ''' </summary>
    ''' <value>
    '''     The default SourceQuality within the SourceQualities collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first SourceQuality in the collection or Nothing (null) is no SourceQualities exist.
    ''' </remarks>

        Public ReadOnly Property DefaultSourceQuality As SourceQuality
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), SourceQuality)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the SourceQuality at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the SourceQuality to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The SourceQuality at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As SourceQuality

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), SourceQuality)
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
    '''     Initializes a new instance of the SourceQualities collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The SourceQualities collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's SourceQualities

        Dim objSourceQuality As New TlkpSourceQuality

        objSourceQuality.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSourceQuality.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSourceQualities As DataTable = objSourceQuality.SelectAll()

        objSourceQuality.ConnectionProvider = Nothing

        ' Add a new SourceQuality to the collection for each SourceQuality retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSourceQualities.Rows
            Add(New SourceQuality(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a SourceQuality to the SourceQualities collection.
    ''' </summary>
    ''' <param name="objSourceQuality">
    '''     The SourceQuality to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the SourceQuality has been added.
    ''' </returns>
    ''' <remarks>
    '''     SourceQualities are maintained in ascending order by SourceQuality Code.
    ''' </remarks>

        Public Function Add(objSourceQuality As SourceQuality) As Integer

        If objSourceQuality.SourceQualityID.IsNull Then
            If Not objSourceQuality.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSourceQuality As SourceQuality = CType(List.Item(i), SourceQuality)
            If objSourceQuality.SourceQualityID.Value() < objExistingSourceQuality.SourceQualityID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objSourceQuality)

        Return i
    End Function

    ''' <summary>
    '''     Updates a SourceQuality in the collection.
    ''' </summary>
    ''' <param name="objSourceQuality">
    '''     The SourceQuality object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     SourceQualities are maintained in ascending order by SourceQuality Code.
    ''' </remarks>

        Public Function Update(objSourceQuality As SourceQuality) As Boolean

        If Not objSourceQuality.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSourceQuality As SourceQuality = CType(List.Item(i), SourceQuality)
            If objExistingSourceQuality.SourceQualityID.Value = objSourceQuality.SourceQualityID.Value Then
                List.RemoveAt(i)
                Add(objSourceQuality)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the SourceQuality within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the SourceQuality whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the SourceQuality within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSourceQuality As SourceQuality = CType(List.Item(i), SourceQuality)
                If objSourceQuality.SourceQualityID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
