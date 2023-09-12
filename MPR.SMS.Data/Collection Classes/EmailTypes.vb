'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of EmailType objects for the Project
''' </summary>

    Public Class EmailTypes
    Inherits CollectionBase

#Region "Public Properties"

    ''' <summary>
    '''     Gets the default EmailType within the collection.
    ''' </summary>
    ''' <value>
    '''     The default EmailType within the EmailTypes collection
    ''' </value>
    ''' <remarks>
    '''     Currently returns the first EmailType in the collection or Nothing (null) is no EmailTypes exist.
    ''' </remarks>

        Public ReadOnly Property DefaultEmailType As EmailType
        Get
            If List.Count < 1 Then
                Return Nothing
            Else
                Return CType(List.Item(0), EmailType)
            End If
        End Get
    End Property

    ''' <summary>
    '''     Gets the EmailType at a specific index.
    ''' </summary>
    ''' <param name="index">
    '''     Index of the EmailType to be retrieved in the collection.
    ''' </param>
    ''' <value>
    '''     The EmailType at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As EmailType

        Get
            If index >= 0 And index < Count Then
                Return CType(List(index), EmailType)
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
    '''     Initializes a new instance of the EmailTypes collection for a Project.
    ''' </summary>
    ''' <remarks>
    '''     The EmailTypes collection is initialized from the database.
    ''' </remarks>

        Public Sub New()

        ' Retrieve the Project's EmailTypes

        Dim objEmailType As New TlkpEmailType

        objEmailType.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objEmailType.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objEmailTypes As DataTable = objEmailType.SelectAll()

        objEmailType.ConnectionProvider = Nothing

        ' Add a new EmailType to the collection for each EmailType retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objEmailTypes.Rows
            Add(New EmailType(objDataRow))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a EmailType to the EmailTypes collection.
    ''' </summary>
    ''' <param name="objEmailType">
    '''     The EmailType to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the EmailType has been added.
    ''' </returns>
    ''' <remarks>
    '''     EmailTypes are maintained in ascending order by EmailType Code.
    ''' </remarks>

        Public Function Add(objEmailType As EmailType) As Integer

        If objEmailType.EmailTypeID.IsNull Then
            If Not objEmailType.Insert() Then
                Return - 1
            End If
        End If

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objExistingEmailType As EmailType = CType(List.Item(i), EmailType)
            If objEmailType.EmailTypeID.Value() < objExistingEmailType.EmailTypeID.Value() Then
                Exit For
            End If
        Next

        List.Insert(i, objEmailType)

        Return i
    End Function

    ''' <summary>
    '''     Updates a EmailType in the collection.
    ''' </summary>
    ''' <param name="objEmailType">
    '''     The EmailType object to be updated.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise false.
    ''' </returns>
    ''' <remarks>
    '''     EmailTypes are maintained in ascending order by EmailType Code.
    ''' </remarks>

        Public Function Update(objEmailType As EmailType) As Boolean

        If Not objEmailType.Update() Then
            Return False
        End If

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingEmailType As EmailType = CType(List.Item(i), EmailType)
            If objExistingEmailType.EmailTypeID.Value = objEmailType.EmailTypeID.Value Then
                List.RemoveAt(i)
                Add(objEmailType)
                Exit For
            End If
        Next

        Return True
    End Function

    ''' <summary>
    '''     Gets the index of the EmailType within the collection having a specific ID.
    ''' </summary>
    ''' <param name="intID">
    '''     The ID of the EmailType whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the EmailType within the collection having the specified ID or -1
    '''     if not found.
    ''' </returns>

        Public Function IndexOf(intID As Integer) As Integer


        If intID >= 0 Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objEmailType As EmailType = CType(List.Item(i), EmailType)
                If objEmailType.EmailTypeID.Value = intID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function


#End Region
End Class
