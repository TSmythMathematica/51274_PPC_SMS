'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Site objects for the Project
''' </summary>

    Public Class Sites
    Inherits CollectionBase

#Region "Private Fields"

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Site belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Site belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the default Site within the collection.
    ''' </summary>
    ''' <value>
    '''     The default Site within the Sites collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first Site in the collection or Nothing (null) is no Sites exist.
    ''' </remarks>

        Public ReadOnly Property DefaultSite As Site
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), Site)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the Site at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the Site to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The Site at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As Site

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), Site)
            End If
            Return Nothing
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the Sites collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The Sites collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's Sites

        Dim objSite As New TblSite()

        objSite.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objSite.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objSites As DataTable = objSite.SelectAll()

        objSite.ConnectionProvider = Nothing

        ' Add a new Site to the collection for each Site retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objSites.Rows
            Add(New Site(objDataRow))
        Next

        objSites.Dispose()

        objSite.Dispose()
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Site to the Sites collection.
    ''' </summary>
    ''' <param name="objSite">
    '''     The Site to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the Site has been added.
    ''' </returns>
    ''' <remarks>
    '''     Sites are maintained in ascending order by Site Name.
    ''' </remarks>

        Public Function Add(objSite As Site) As Integer

        If objSite.SiteID.IsNull Then
            If Not objSite.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingSite As Site = CType(List.Item(i), Site)
            If objSite.Name.Value.ToLower() < objExistingSite.Name.Value.ToLower() Then
                Exit For
            End If
        Next

        List.Insert(i, objSite)

        Return i
    End Function

    ''' <summary>
    '''     Updates a Site in the collection.
    ''' </summary>
    ''' <param name="objSite">
    '''     The Site object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     Sites are maintained in ascending order by Site Name.
    ''' </remarks>

        Public Function Update(objSite As Site) As Boolean

        If Not objSite.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingSite As Site = CType(List.Item(i), Site)
            If objExistingSite.SiteID.Value = objSite.SiteID.Value Then
                List.RemoveAt(i)
                Add(objSite)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the Site within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the Site whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Site within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer

        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objSite As Site = CType(List.Item(i), Site)
                If objSite.SiteID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
