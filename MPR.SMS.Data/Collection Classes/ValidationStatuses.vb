'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of ValidationStatus objects for the Project
''' </summary>

    Public Class ValidationStatuses
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the ValidationStatus at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the ValidationStatus to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The ValidationStatus at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As ValidationStatus

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), ValidationStatus)
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
    '''     Initializes a new instance of the ValidationStatuses collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL ValidationStatuses from the database.
    ''' </remarks>

        Public Sub New()

        Me.New(False)
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the ValidationStatuses collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL ValidationStatuses from the database if blnReportOrderOnly = False.
    '''     If blnReportOrderOnly = True, then only return ValidationStatuses which have
    '''     a non-null ReportOrder
    ''' </remarks>

        Public Sub New(blnReportOrderOnly As Boolean)

        ' Retrieve the Project's ValidationStatuses

        Dim objValidationStatus As New TlkpValidationStatus

        objValidationStatus.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objValidationStatus.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objValidationStatuses As DataTable = objValidationStatus.SelectAll()

        objValidationStatus.ConnectionProvider = Nothing

        ' Add a new ValidationStatus to the collection for each ValidationStatus retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objValidationStatuses.Rows
            If blnReportOrderOnly = False OrElse objDataRow("ReportOrder") IsNot DBNull.Value Then
                Add(New ValidationStatus(objDataRow))
            End If
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a ValidationStatus to the ValidationStatuses collection.
    ''' </summary>
    ''' <param name="objValidationStatus">
    '''     The ValidationStatus to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the ValidationStatus has been added.
    ''' </returns>
    ''' <remarks>
    '''     ValidationStatuses are maintained in ascending order by ValidationStatus Code.
    ''' </remarks>

        Public Function Add(objValidationStatus As ValidationStatus) As Integer

        If objValidationStatus.StatusID.IsNull Then
            If Not objValidationStatus.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingValidationStatus As ValidationStatus = CType(List.Item(i), ValidationStatus)
            If objValidationStatus.StatusID.Value < objExistingValidationStatus.StatusID.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objValidationStatus)

        Return i
    End Function

    ''' <summary>
    '''     Updates a ValidationStatus in the collection.
    ''' </summary>
    ''' <param name="objValidationStatus">
    '''     The ValidationStatus object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     ValidationStatuses are maintained in ascending order by ValidationStatus Code.
    ''' </remarks>

        Public Function Update(objValidationStatus As ValidationStatus) As Boolean

        If Not objValidationStatus.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingValidationStatus As ValidationStatus = CType(List.Item(i), ValidationStatus)
            If objExistingValidationStatus.StatusID.Value = objValidationStatus.StatusID.Value Then
                List.RemoveAt(i)
                Add(objValidationStatus)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the ValidationStatus within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the ValidationStatus whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the ValidationStatus within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID > 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objValidationStatus As ValidationStatus = CType(List.Item(i), ValidationStatus)
                If objValidationStatus.StatusID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Public Function GetByID(intID As Integer) As ValidationStatus

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objValidationStatus As ValidationStatus = CType(List.Item(i), ValidationStatus)
            If objValidationStatus.StatusID.Value = intID Then
                Return objValidationStatus
            End If
        Next

        Return Nothing
    End Function

#End Region
End Class
