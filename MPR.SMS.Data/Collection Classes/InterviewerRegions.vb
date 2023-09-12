'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewerRegion objects for the Project
''' </summary>

    Public Class InterviewerRegions
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewerRegion at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewerRegion to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewerRegion at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As InterviewerRegion

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewerRegion)
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
    '''     Initializes a new instance of the InterviewerRegions collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerRegions from the database.
    ''' </remarks>

        Public Sub New()

        Dim objIntSup As New TlkpInterviewerRegion

        objIntSup.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntSup.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objIntSups As DataTable = objIntSup.SelectAll()

        objIntSup.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objIntSups.Rows
            Add(New InterviewerRegion(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewerRegion to the InterviewerRegions collection.
    ''' </summary>
    ''' <param name="objInterviewerRegion">
    '''     The InterviewerRegion to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewerRegion has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerRegions are maintained in ascending order by InterviewerRegionID.
    ''' </remarks>

        Public Function Add(objInterviewerRegion As InterviewerRegion) As Integer

        If objInterviewerRegion.InterviewerRegionID.IsNull Then
            If Not objInterviewerRegion.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInterviewerRegion As InterviewerRegion = CType(List.Item(i), InterviewerRegion)
            If objInterviewerRegion.InterviewerRegionID.Value < objExistingInterviewerRegion.InterviewerRegionID.Value _
                Then
                Exit For
            End If
        Next

        List.Insert(i, objInterviewerRegion)

        Return i
    End Function

    ''' <summary>
    '''     Updates a InterviewerRegion in the collection.
    ''' </summary>
    ''' <param name="objInterviewerRegion">
    '''     The InterviewerRegion object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerRegions are maintained in ascending order by InterviewerRegion Code.
    ''' </remarks>

        Public Function Update(objInterviewerRegion As InterviewerRegion) As Boolean

        If Not objInterviewerRegion.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewerRegion As InterviewerRegion = CType(List.Item(i), InterviewerRegion)
            If objExistingInterviewerRegion.InterviewerRegionID.Value = objInterviewerRegion.InterviewerRegionID.Value _
                Then
                List.RemoveAt(i)
                Add(objInterviewerRegion)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the InterviewerRegion within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the InterviewerRegion whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the InterviewerRegion within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewerRegion As InterviewerRegion = CType(List.Item(i), InterviewerRegion)
                If objInterviewerRegion.InterviewerRegionID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(intID As Integer) As InterviewerRegion

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInterviewerRegion As InterviewerRegion = CType(List.Item(i), InterviewerRegion)
            If objInterviewerRegion.InterviewerRegionID.Value = intID Then
                Return objInterviewerRegion
            End If
        Next

        Return Nothing
    End Function

#End Region
End Class
