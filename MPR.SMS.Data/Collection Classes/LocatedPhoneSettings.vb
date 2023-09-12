'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of LocatedPhoneSetting objects for the Project
''' </summary>

    Public Class LocatedPhoneSettings
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default LocatedPhoneSetting within the collection.
    ''' </summary>
    ''' <value>
    '''     The default LocatedPhoneSetting within the LocatedPhoneSettings collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first LocatedPhoneSetting in the collection or Nothing (null) is no LocatedPhoneSettings
    '''     exist.
    ''' </remarks>

        Public ReadOnly Property DefaultLocatedPhoneSetting As LocatedPhoneSetting
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), LocatedPhoneSetting)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the LocatedPhoneSetting at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the LocatedPhoneSetting to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The LocatedPhoneSetting at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As LocatedPhoneSetting

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), LocatedPhoneSetting)
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
    '''     Initializes a new instance of the LocatedPhoneSettings collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The LocatedPhoneSettings collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's LocatedPhoneSettings

        Dim objLocatedPhoneSetting As New TlkpLocatedPhoneSettings

        objLocatedPhoneSetting.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objLocatedPhoneSetting.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objLocatedPhoneSettings As DataTable = objLocatedPhoneSetting.SelectAll()

        objLocatedPhoneSetting.ConnectionProvider = Nothing

        ' Add a new LocatedPhoneSetting to the collection for each LocatedPhoneSetting retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objLocatedPhoneSettings.Rows
            Add(New LocatedPhoneSetting(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a LocatedPhoneSetting to the LocatedPhoneSettings collection.
    ''' </summary>
    ''' <param name="objLocatedPhoneSetting">
    '''     The LocatedPhoneSetting to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the LocatedPhoneSetting has been added.
    ''' </returns>
    ''' <remarks>
    '''     LocatedPhoneSettings are maintained in ascending order by LocatedPhoneSetting Code.
    ''' </remarks>

        Public Function Add(objLocatedPhoneSetting As LocatedPhoneSetting) As Integer

        If objLocatedPhoneSetting.ID.IsNull Then
            If Not objLocatedPhoneSetting.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingLocatedPhoneSetting As LocatedPhoneSetting = CType(List.Item(i), LocatedPhoneSetting)
            If objLocatedPhoneSetting.ID.Value() < objExistingLocatedPhoneSetting.ID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objLocatedPhoneSetting)

        Return i
    End Function

    ''' <summary>
    '''     Updates a LocatedPhoneSetting in the collection.
    ''' </summary>
    ''' <param name="objLocatedPhoneSetting">
    '''     The LocatedPhoneSetting object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     LocatedPhoneSettings are maintained in ascending order by LocatedPhoneSetting Code.
    ''' </remarks>

        Public Function Update(objLocatedPhoneSetting As LocatedPhoneSetting) As Boolean

        If Not objLocatedPhoneSetting.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingLocatedPhoneSetting As LocatedPhoneSetting = CType(List.Item(i), LocatedPhoneSetting)
            If objExistingLocatedPhoneSetting.ID.Value = objLocatedPhoneSetting.ID.Value Then
                List.RemoveAt(i)
                Add(objLocatedPhoneSetting)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the LocatedPhoneSetting within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the LocatedPhoneSetting whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the LocatedPhoneSetting within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objLocatedPhoneSetting As LocatedPhoneSetting = CType(List.Item(i), LocatedPhoneSetting)
                If objLocatedPhoneSetting.ID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
