'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewerSupervisor objects for the Project
''' </summary>

    Public Class InterviewerSupervisors
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewerSupervisor at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewerSupervisor to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewerSupervisor at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As InterviewerSupervisor

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewerSupervisor)
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
    '''     Initializes a new instance of the InterviewerSupervisors collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerSupervisors from the database.
    ''' </remarks>

        Public Sub New()

        Dim objIntSup As New TlkpInterviewerSupervisor

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
            Add(New InterviewerSupervisor(objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerSupervisors collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerSupervisors from the database if blnReportOrderOnly = False.
    '''     If blnReportOrderOnly = True, then only return InterviewerSupervisors which have
    '''     a non-null ReportOrder
    ''' </remarks>

        Public Sub New(blnReportOrderOnly As Boolean)

        ' Retrieve the Project's InterviewerSupervisors

        Dim objInterviewerSupervisor As New TlkpInterviewerSupervisor

        objInterviewerSupervisor.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objInterviewerSupervisor.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objInterviewerSupervisors As DataTable = objInterviewerSupervisor.SelectAll()

        objInterviewerSupervisor.ConnectionProvider = Nothing

        ' Add a new InterviewerSupervisor to the collection for each InterviewerSupervisor retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objInterviewerSupervisors.Rows
            If blnReportOrderOnly = False OrElse objDataRow("ReportOrder") IsNot DBNull.Value Then
                Add(New InterviewerSupervisor(objDataRow))
            End If
        Next
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the InterviewerSupervisors collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewerSupervisors from the database.
    ''' </remarks>

        Public Sub New(objRegion As InterviewerRegion)

        Dim objIntSup As New TlkpInterviewerSupervisor

        objIntSup.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntSup.ConnectionProvider = Project.ConnectionProvider
        End If

        objIntSup.InterviewerRegionID = objRegion.InterviewerRegionID
        Dim objIntSups As DataTable = objIntSup.SelectAllWInterviewerRegionIDLogic

        objIntSup.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objIntSups.Rows
            Add(New InterviewerSupervisor(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewerSupervisor to the InterviewerSupervisors collection.
    ''' </summary>
    ''' <param name="objInterviewerSupervisor">
    '''     The InterviewerSupervisor to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewerSupervisor has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerSupervisors are maintained in ascending order by InterviewerSupervisorID.
    ''' </remarks>

        Public Function Add(objInterviewerSupervisor As InterviewerSupervisor) As Integer

        If objInterviewerSupervisor.InterviewerSupervisorID.IsNull Then
            If Not objInterviewerSupervisor.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInterviewerSupervisor As InterviewerSupervisor = CType(List.Item(i), InterviewerSupervisor)
            If _
                objInterviewerSupervisor.InterviewerSupervisorID.Value <
                objExistingInterviewerSupervisor.InterviewerSupervisorID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objInterviewerSupervisor)

        Return i
    End Function

    ''' <summary>
    '''     Updates a InterviewerSupervisor in the collection.
    ''' </summary>
    ''' <param name="objInterviewerSupervisor">
    '''     The InterviewerSupervisor object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewerSupervisors are maintained in ascending order by InterviewerSupervisor Code.
    ''' </remarks>

        Public Function Update(objInterviewerSupervisor As InterviewerSupervisor) As Boolean

        If Not objInterviewerSupervisor.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewerSupervisor As InterviewerSupervisor = CType(List.Item(i), InterviewerSupervisor)
            If _
                objExistingInterviewerSupervisor.InterviewerSupervisorID.Value =
                objInterviewerSupervisor.InterviewerSupervisorID.Value Then
                List.RemoveAt(i)
                Add(objInterviewerSupervisor)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the InterviewerSupervisor within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the InterviewerSupervisor whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the InterviewerSupervisor within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objInterviewerSupervisor As InterviewerSupervisor = CType(List.Item(i), InterviewerSupervisor)
                If objInterviewerSupervisor.InterviewerSupervisorID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(intID As Integer) As InterviewerSupervisor

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objInterviewerSupervisor As InterviewerSupervisor = CType(List.Item(i), InterviewerSupervisor)
            If objInterviewerSupervisor.InterviewerSupervisorID.Value = intID Then
                Return objInterviewerSupervisor
            End If
        Next

        Return Nothing
    End Function

#End Region
End Class
