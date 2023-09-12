'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of InterviewWeek objects for the Project
''' </summary>

    Public Class InterviewWeeks
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the InterviewWeek at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the InterviewWeek to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The InterviewWeek at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As InterviewWeek

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), InterviewWeek)
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
    '''     Initializes a new instance of the InterviewWeeks collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     Returns ALL InterviewWeeks from the database.
    ''' </remarks>

        Public Sub New()

        Dim objIntWeek As New TlkpInterviewWeek

        objIntWeek.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objIntWeek.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objIntWeeks As DataTable = objIntWeek.SelectAll()

        objIntWeek.ConnectionProvider = Nothing

        ' Add a new LanguageType to the collection for each LanguageType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objIntWeeks.Rows
            Add(New InterviewWeek(objDataRow))
        Next
    End Sub


#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a InterviewWeek to the InterviewWeeks collection.
    ''' </summary>
    ''' <param name="objInterviewWeek">
    '''     The InterviewWeek to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the InterviewWeek has been added.
    ''' </returns>
    ''' <remarks>
    '''     InterviewWeeks are maintained in ascending order by WeekBeg.
    ''' </remarks>

        Public Function Add(objInterviewWeek As InterviewWeek) As Integer

        If objInterviewWeek.WeekBeg.IsNull Then
            If Not objInterviewWeek.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingInterviewWeek As InterviewWeek = CType(List.Item(i), InterviewWeek)
            If objInterviewWeek.WeekBeg.Value < objExistingInterviewWeek.WeekBeg.Value Then
                Exit For
            End If
        Next

        List.Insert(i, objInterviewWeek)

        Return i
    End Function

    ''' <summary>
    '''     Updates a InterviewWeek in the collection.
    ''' </summary>
    ''' <param name="objInterviewWeek">
    '''     The InterviewWeek object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     InterviewWeeks are maintained in ascending order by WeekBeg.
    ''' </remarks>

        Public Function Update(objInterviewWeek As InterviewWeek) As Boolean

        If Not objInterviewWeek.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingInterviewWeek As InterviewWeek = CType(List.Item(i), InterviewWeek)
            If objExistingInterviewWeek.WeekBeg.Value = objInterviewWeek.WeekBeg.Value Then
                List.RemoveAt(i)
                Add(objInterviewWeek)
                Exit For
            End If
        Next

        Return True
    End Function

    'this method truncates the tlkpInterviewWeek table, and fills it
    'with iNumWeeks records, starting with WeekBeg
    Public Function CreateInterviewWeeks(WeekBeg As DateTime, iNumWeeks As Integer) As Boolean

        Return SqlHelper.ExecuteNonQuery(Project.ConnectionString, "SMS_CreateInterviewWeeks", WeekBeg, iNumWeeks) > 0
    End Function

#End Region
End Class
