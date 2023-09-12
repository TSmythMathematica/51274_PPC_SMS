'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see>
'''     objects for a <see cref="T:MPR.SMS.Data.Project">Project</see>.
''' </summary>

    Public Class CaseLocks
    Inherits CollectionBase

#Region "Private Fields"

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object at a specific index within the collection.
    ''' </summary>
    ''' <param name="index">
    '''     The index of the <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to be retrieved from the collection.
    ''' </param>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object at the specified index within the collection.
    ''' </value>

        Default Public ReadOnly Property Item(index As Integer) As CaseLock
        Get
            Return CType(List.Item(index), CaseLock)
        End Get
    End Property


    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Form object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Form object belongs to.
    ''' </value>
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the CaseLocks collection for a <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>

        Public Sub New()

        ' Retrieve all CaseLocks for the project

        Dim objCaseLock As New TblCaseLock

        objCaseLock.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objCaseLock.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objCaseLocks As DataTable = objCaseLock.SelectAll()

        objCaseLock.ConnectionProvider = Nothing

        ' Add a new CaseLock object to the collection for each CaseLock retrieved  

        Dim objDataRow As DataRow

        For Each objDataRow In objCaseLocks.Rows
            Add(New CaseLock(CType(objDataRow.Item("CaseID"), Integer)))
        Next
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to the CaseLocks collection.
    ''' </summary>
    ''' <param name="objNewCaseLock">
    '''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to be added to the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object has been added or -1 if
    '''     unsuccessful.
    ''' </returns>
    ''' <remarks>
    '''     The CaseLocks collection is maintained in sorted order by CaseLock Grade. If the CaseLockID
    '''     of the <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object is Nothing (null), the
    '''     <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object is inserted into the database as
    '''     well as the collection.
    ''' </remarks>

        Public Function Add(objNewCaseLock As CaseLock) As Integer

        ' If the CaseID is Null, then exit out with error

        If objNewCaseLock.CaseID.IsNull Then
            Return - 1
        End If

        ' Locate the index at which the CaseLock is to be inserted

        Dim i As Integer

        For i = 0 To (List.Count - 1)
            Dim objCaseLock As CaseLock = CType(List.Item(i), CaseLock)
            If objNewCaseLock.CaseID.Value < objCaseLock.CaseID.Value Then
                Exit For
            End If
        Next

        ' Insert the new CaseLock object into the collection

        List.Insert(i, objNewCaseLock)

        Return i
    End Function

    '' <summary>
    ''     Updates a <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object within the CaseLocks collection.
    '' </summary>
    '' <param name="objCaseLock">
    ''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to be updated within the collection.
    '' </param>
    '' <returns>
    ''     True if successful, otherwise False
    '' </returns>
    '' <remarks>
    ''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object is updated within the database and the collection.
    ''     The
    ''     collection is maintained in sorted order by <see cref="T:MPR.SMS.Data.CaseLock.Grade">Grade</see>.
    '' </remarks>

    Public Function Update(objCaseLock As CaseLock) As Boolean

        Dim i As Integer = IndexOf(objCaseLock)

        ' Update the CaseLock object

        Dim blnResult As Boolean = objCaseLock.Update()

        ' If successful, remove the CaseLock object from the collection

        If blnResult And i >= 0 Then
            List.RemoveAt(i)
        End If

        ' Re-add the CaseLock object to the collection in sorted order

        Add(objCaseLock)

        Return blnResult
    End Function

    ''' <summary>
    '''     Removes a <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object from the CaseLocks collection.
    ''' </summary>
    ''' <param name="objCaseLock">
    '''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to be removed from the collection.
    ''' </param>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>
    ''' <remarks>
    '''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object is deleted from the database and removed from the
    '''     collection.
    ''' </remarks>

        Public Function Delete(objCaseLock As CaseLock) As Boolean

        Dim i As Integer = IndexOf(objCaseLock)

        ' Delete the CaseLock object from the database

        Dim blnResult As Boolean = objCaseLock.Delete()

        ' If succesful, remove the CaseLock object from the collection

        If blnResult And i >= 0 Then
            List.RemoveAt(i)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Gets the zero-based index of the <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object within the CaseLocks
    '''     collection.
    ''' </summary>
    ''' <param name="objCaseLock">
    '''     The <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object to be located within the collection.
    ''' </param>
    ''' <returns>
    '''     The zero-based index of <see cref="T:MPR.SMS.Data.CaseLock">CaseLock</see> object within the CaseLocks collection
    '''     if found, otherwise -1.
    ''' </returns>

        Public Function IndexOf(objCaseLock As CaseLock) As Integer

        Dim i As Integer

        For i = 0 To (Count - 1)
            Dim objExistingCaseLock As CaseLock = CType(List.Item(i), CaseLock)
            If objCaseLock.CaseID.Value = objExistingCaseLock.CaseID.Value Then
                Return i
            End If
        Next

        Return - 1
    End Function

#End Region
End Class

