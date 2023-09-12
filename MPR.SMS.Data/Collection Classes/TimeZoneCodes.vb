'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of TimeZoneCode objects for the Project
''' </summary>

    Public Class TimeZoneCodes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default TimeZoneCode within the collection.
    ''' </summary>
    ''' <value>
    '''     The default TimeZoneCode within the TimeZoneCodes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first TimeZoneCode in the collection or Nothing (null) is no TimeZoneCodes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultTimeZoneCode As TimeZoneCode
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), TimeZoneCode)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the TimeZoneCode at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the TimeZoneCode to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The TimeZoneCode at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As TimeZoneCode

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), TimeZoneCode)
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

    Public ReadOnly Property GetTimeZoneName(sConfirmitCode As String) As String
        Get
            For i As Integer = 0 To List.Count - 1
                If GetSafeValue(CType(List.Item(i), TimeZoneCode).ConfirmitCode) = sConfirmitCode Then
                    Return GetSafeValue(CType(List.Item(i), TimeZoneCode).TimeZoneName)
                End If
            Next
            Return String.Empty
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the TimeZoneCodes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The TimeZoneCodes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's TimeZoneCodes

        Dim objTimeZoneCode As New TlkpTimeZoneCode

        objTimeZoneCode.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objTimeZoneCode.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objTimeZoneCodes As DataTable = objTimeZoneCode.SelectAll()

        objTimeZoneCode.ConnectionProvider = Nothing

        ' Add a new TimeZoneCode to the collection for each TimeZoneCode retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objTimeZoneCodes.Rows
            Add(New TimeZoneCode(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a TimeZoneCode to the TimeZoneCodes collection.
    ''' </summary>
    ''' <param name="objTimeZoneCode">
    '''     The TimeZoneCode to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the TimeZoneCode has been added.
    ''' </returns>
    ''' <remarks>
    '''     TimeZoneCodes are maintained in ascending order by TimeZoneCode Code.
    ''' </remarks>

        Public Function Add(objTimeZoneCode As TimeZoneCode) As Integer

        If objTimeZoneCode.TimeZoneCode.IsNull Then
            If Not objTimeZoneCode.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingTimeZoneCode As TimeZoneCode = CType(List.Item(i), TimeZoneCode)
            If objTimeZoneCode.TimeZoneCode.Value() < objExistingTimeZoneCode.TimeZoneCode.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objTimeZoneCode)

        Return i
    End Function

    ''' <summary>
    '''     Updates a TimeZoneCode in the collection.
    ''' </summary>
    ''' <param name="objTimeZoneCode">
    '''     The TimeZoneCode object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     TimeZoneCodes are maintained in ascending order by TimeZoneCode Code.
    ''' </remarks>

        Public Function Update(objTimeZoneCode As TimeZoneCode) As Boolean

        If Not objTimeZoneCode.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingTimeZoneCode As TimeZoneCode = CType(List.Item(i), TimeZoneCode)
            If objExistingTimeZoneCode.TimeZoneCode.Value = objTimeZoneCode.TimeZoneCode.Value Then
                List.RemoveAt(i)
                Add(objTimeZoneCode)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the TimeZoneCode within the collection having a specific ID.
    ''' </summary>
    ''' <param name="strID">
    '''     The ID of the TimeZoneCode whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the TimeZoneCode within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(strID As string) As Integer


        If strID <> String.Empty Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objTimeZoneCode As TimeZoneCode = CType(List.Item(i), TimeZoneCode)
                If objTimeZoneCode.TimeZoneCode.Value = strID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
