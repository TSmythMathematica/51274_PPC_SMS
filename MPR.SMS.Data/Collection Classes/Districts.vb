'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of District objects for the Project
''' </summary>

    Public Class Districts
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the District at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the District to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The District at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As District

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), District)
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
    '''     Initializes a new instance of the Districts collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Districts collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Districts

        Dim objDistrict As New TblDistrict

        objDistrict.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDistrict.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDistricts As DataTable = objDistrict.SelectAll()

        objDistrict.ConnectionProvider = Nothing

        ' Add a new District to the collection for each District retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDistricts.Rows
            Add(New District(objDataRow))
        Next
    End Sub

    Public Sub New(SiteID As SqlInt32)

        ' Retrieve the Project's Districts

        Dim objDistrict As New TblDistrict

        objDistrict.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDistrict.ConnectionProvider = Project.ConnectionProvider
        End If

        objDistrict.SiteID = SiteID
        Dim objDistricts As DataTable = objDistrict.SelectAllWSiteIDLogic()

        objDistrict.ConnectionProvider = Nothing

        ' Add a new District to the collection for each District retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDistricts.Rows
            Add(New District(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a District to the Districts collection.
    ''' </summary>
    ''' <param name="objDistrict">
    '''     The District to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the District has been added.
    ''' </returns>
    ''' <remarks>
    '''     Districts are maintained in ascending order by District Code.
    ''' </remarks>

        Public Function Add(objDistrict As District) As Integer

        If objDistrict.DistrictID.IsNull Then
            If Not objDistrict.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDistrict As District = CType(List.Item(i), District)
            If objDistrict.Name.Value.ToLower() < objExistingDistrict.Name.Value.ToLower() Then
                Exit For
            End If
        Next

        List.Insert(i, objDistrict)

        Return i
    End Function

    ''' <summary>
    '''     Updates a District in the collection.
    ''' </summary>
    ''' <param name="objDistrict">
    '''     The District object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Districts are maintained in ascending order by District Code.
    ''' </remarks>

        Public Function Update(objDistrict As District) As Boolean

        If Not objDistrict.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingDistrict As District = CType(List.Item(i), District)
            If objExistingDistrict.DistrictID.Value = objDistrict.DistrictID.Value Then
                List.RemoveAt(i)
                Add(objDistrict)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the District within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the District whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the District within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objDistrict As District = CType(List.Item(i), District)
                If objDistrict.DistrictID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region
End Class