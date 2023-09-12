'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of ConsentType objects for the Project
''' </summary>

    Public Class ConsentTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the ConsentType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the ConsentType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The ConsentType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As ConsentType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), ConsentType)
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
    '''     Initializes a new instance of the ConsentTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The ConsentTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's ConsentTypes

        Dim objConsentType As New TlkpConsentType

        objConsentType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objConsentType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objConsentTypes As DataTable = objConsentType.SelectAll()

        objConsentType.ConnectionProvider = Nothing

        ' Add a new ConsentType to the collection for each ConsentType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objConsentTypes.Rows
            Add(New ConsentType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a ConsentType to the ConsentTypes collection.
    ''' </summary>
    ''' <param name="objConsentType">
    '''     The ConsentType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the ConsentType has been added.
    ''' </returns>
    ''' <remarks>
    '''     ConsentTypes are maintained in ascending order by ConsentType Code.
    ''' </remarks>

        Public Function Add(objConsentType As ConsentType) As Integer

        If objConsentType.ConsentID.IsNull Then
            If Not objConsentType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingConsentType As ConsentType = CType(List.Item(i), ConsentType)
            If objConsentType.ConsentID.Value() < objExistingConsentType.ConsentID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objConsentType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a ConsentType in the collection.
    ''' </summary>
    ''' <param name="objConsentType">
    '''     The ConsentType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     ConsentTypes are maintained in ascending order by ConsentType Code.
    ''' </remarks>

        Public Function Update(objConsentType As ConsentType) As Boolean

        If Not objConsentType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingConsentType As ConsentType = CType(List.Item(i), ConsentType)
            If objExistingConsentType.ConsentID.Value = objConsentType.ConsentID.Value Then
                List.RemoveAt(i)
                Add(objConsentType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the ConsentType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the ConsentType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the ConsentType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objConsentType As ConsentType = CType(List.Item(i), ConsentType)
                If objConsentType.ConsentID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
