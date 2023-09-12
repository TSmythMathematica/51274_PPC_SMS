'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class Schools
    Inherits CollectionBase

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the Schools collection.
    ''' </summary>
    ''' <remarks>
    '''     The Schools collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Schools

        Dim objSchool As New TblSchool

        objSchool.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSchool.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSchools As DataTable = objSchool.SelectAll()

        objSchool.ConnectionProvider = Nothing

        ' Add a new School to the collection for each School retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSchools.Rows
            Add(New School(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Schools collection.
    ''' </summary>
    ''' <remarks>
    '''     The Schools collection is initialized from the database.
    ''' </remarks>
    ''' <param name="DistrictID">
    '''     The District that the Schools belong to.
    ''' </param>

        Public Sub New(DistrictID As SqlInt32)

        ' Retrieve the Schools

        Dim objSchool As New TblSchool

        objSchool.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSchool.ConnectionProvider = Project.ConnectionProvider
        End If

        objSchool.DistrictID = DistrictID
        Dim objSchools As DataTable = objSchool.SelectAllWDistrictIDLogic()

        objSchool.ConnectionProvider = Nothing

        ' Add a new School to the collection for each School retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSchools.Rows
            Add(New School(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Properties"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the School at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the School to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The School at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As School

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), School)
            End If
            Return Nothing
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a School to the Schools collection.
    ''' </summary>
    ''' <param name="objSchool">
    '''     The School to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the School has been added.
    ''' </returns>
    ''' <remarks>
    '''     Schools are maintained in ascending order by School ID.
    ''' </remarks>

        Public Function Add(objSchool As School) As Integer

        If objSchool.SchoolID.IsNull Then
            If Not objSchool.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSchool As School = CType(List.Item(i), School)
            If objSchool.SchoolID.Value < objExistingSchool.SchoolID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objSchool)

        Return i
    End Function

    '' <summary>
    ''     Updates a <see cref="T:MPR.SMS.Data.School">School</see> object within the Schools collection.
    '' </summary>
    '' <param name="objSchool">
    ''     The <see cref="T:MPR.SMS.Data.School">School</see> object to be updated within the collection.
    '' </param>
    '' <returns>
    ''     True if successful, otherwise False
    '' </returns>
    '' <remarks>
    ''     The <see cref="T:MPR.SMS.Data.School">School</see> object is updated within the database and the collection. The
    ''     collection is maintained in sorted order by <see cref="T:MPR.SMS.Data.School.SchoolID">SchoolID</see>.
    '' </remarks>

    Public Function Update(objSchool As School) As Boolean

        If Not objSchool.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSchool As School = CType(List.Item(i), School)
            If objExistingSchool.SchoolID.Value = objSchool.SchoolID.Value Then
                List.RemoveAt(i)
                Add(objSchool)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the School within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the School whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the School within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSchool As School = CType(List.Item(i), School)
                If objSchool.SchoolID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region
End Class
