'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of PhoneTime objects for the Project
''' </summary>

    Public Class PhoneTimes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default PhoneTime within the collection.
    ''' </summary>
    ''' <value>
    '''     The default PhoneTime within the PhoneTimes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first PhoneTime in the collection or Nothing (null) is no PhoneTimes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultPhoneTime As PhoneTime
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), PhoneTime)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the PhoneTime at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the PhoneTime to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The PhoneTime at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As PhoneTime

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), PhoneTime)
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
    '''     Initializes a new instance of the PhoneTimes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The PhoneTimes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's PhoneTimes

        Dim objPhoneTime As New TlkpPhoneTime

        objPhoneTime.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPhoneTime.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPhoneTimes As DataTable = objPhoneTime.SelectAll()

        objPhoneTime.ConnectionProvider = Nothing

        ' Add a new PhoneTime to the collection for each PhoneTime retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPhoneTimes.Rows
            Add(New PhoneTime(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a PhoneTime to the PhoneTimes collection.
    ''' </summary>
    ''' <param name="objPhoneTime">
    '''     The PhoneTime to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the PhoneTime has been added.
    ''' </returns>
    ''' <remarks>
    '''     PhoneTimes are maintained in ascending order by PhoneTime Code.
    ''' </remarks>

        Public Function Add(objPhoneTime As PhoneTime) As Integer

        If objPhoneTime.PhoneTimeID.IsNull Then
            If Not objPhoneTime.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingPhoneTime As PhoneTime = CType(List.Item(i), PhoneTime)
            If objPhoneTime.PhoneTimeID.Value() < objExistingPhoneTime.PhoneTimeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objPhoneTime)

        Return i
    End Function

    ''' <summary>
    '''     Updates a PhoneTime in the collection.
    ''' </summary>
    ''' <param name="objPhoneTime">
    '''     The PhoneTime object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     PhoneTimes are maintained in ascending order by PhoneTime Code.
    ''' </remarks>

        Public Function Update(objPhoneTime As PhoneTime) As Boolean

        If Not objPhoneTime.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingPhoneTime As PhoneTime = CType(List.Item(i), PhoneTime)
            If objExistingPhoneTime.PhoneTimeID.Value = objPhoneTime.PhoneTimeID.Value Then
                List.RemoveAt(i)
                Add(objPhoneTime)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the PhoneTime within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the PhoneTime whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the PhoneTime within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objPhoneTime As PhoneTime = CType(List.Item(i), PhoneTime)
                If objPhoneTime.PhoneTimeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
