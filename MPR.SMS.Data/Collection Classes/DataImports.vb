'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

Public Class DataImports
    Inherits CollectionBase

#Region "Public Properties"

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

    ''' <overloads>
    '''     The DataImports collection constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of the DataImports collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The DataImports collection is initialized from the database. This form of the constructor
    '''     is used get all of the DataImports defined for the Project.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's DataImports

        Dim objDataImport As New TlkpDataImport

        objDataImport.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objDataImport.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objDataImports As DataTable = objDataImport.SelectAll()

        objDataImport.ConnectionProvider = Nothing

        ' Add a new DataImport to the collection for each DataImport retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objDataImports.Rows
            Add(New DataImport(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Functions"

    ''' <summary>
    '''     Adds an DataImport to the DataImports collection.
    ''' </summary>
    ''' <param name="objDataImport">
    '''     The DataImport to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the DataImport has been added.
    ''' </returns>

        Public Function Add(objDataImport As DataImport) As Integer

        If objDataImport.DataImportID.IsNull Then
            If Not objDataImport.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingDataImport As DataImport = CType(List.Item(i), DataImport)
            If objDataImport.DataImportID.Value() < objExistingDataImport.DataImportID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objDataImport)

        Return i
    End Function


#End Region
End Class
