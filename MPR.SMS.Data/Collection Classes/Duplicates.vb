'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

''' <summary>
'''     Provides a strongly typed collection of Duplicate objects.
''' </summary>

    Public Class Duplicates
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mblnObjDeleted As Boolean = False

    ''' <summary>
    '''     Data Access Error Enumerator
    ''' </summary>
    Private Enum DataAccessError
        OK
    End Enum

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Case objectbelongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Case object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Duplicate">Duplicate</see> object at the specified index within the collection.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Duplicate">Duplicate</see> object at the specified index in the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Duplicate
        Get
            Return CType(List.Item(Index), Duplicate)
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    ''' <summary>
    '''     Gets the index of the specified Duplicate object.
    ''' </summary>
    ''' <param name="objDuplicate">
    '''     The Duplicate object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Duplicate object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objDuplicate As Duplicate) As Integer

        If Not objDuplicate Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objDuplicate) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds an <see cref="T:MPR.SMS.Data.Duplicate">Duplicate</see> object to the end of the Duplicates collection.
    ''' </summary>
    ''' <param name="objDuplicate">
    '''     The <see cref="T:MPR.SMS.Data.Duplicate">Duplicate</see> object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The collection index at which the <see cref="T:MPR.SMS.Data.Duplicate">Duplicate</see> object has been added.
    ''' </returns>

        Public Function Add(objDuplicate As Duplicate) As Integer

        Return List.Add(objDuplicate)
    End Function

    Public Sub Remove(objDuplicate As Duplicate)

        Dim index As Integer = List.IndexOf(objDuplicate)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

#End Region

#Region "Private Methods"

    Private Function GetSafeValue(objSqlString As SqlString) As String

        If Not objSqlString.IsNull Then
            Return objSqlString.ToString.Replace("'", "''")
        Else
            Return ""
        End If
    End Function

    Private Function GetSafeValue(objSqlInt32 As SqlInt32) As Integer

        If Not objSqlInt32.IsNull Then
            Return objSqlInt32.Value
        Else
            Return 0
        End If
    End Function

    Private Function GetSafeValue(objSqlDateTime As SqlDateTime) As Date

        If Not objSqlDateTime.IsNull Then
            Return CDate(objSqlDateTime.Value)
        Else
            Return CDate(SqlDateTime.Null)
        End If
    End Function

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        mobjCase = objCase
        Me.Clear()

        Dim mErrorCode As SqlInt32

        For Each objPerson As Person In mobjCase.Persons

            'loop through each person in the case, 
            'or just the Sample Member(s), according to the Project Settings
            If Project.DuplicatesChecking <> Project.CheckingType.PrimarySampleMemberOnly Or
               objPerson.RelationshipType.IsPrimarySampleMember Then

                Dim DistrictID As Integer = 0
                If objPerson.RelationshipType.IsPrimarySampleMember = True AndAlso
                   mobjCase.EntityTypeID.Value = Enumerations.tlkpEntityType.Student AndAlso
                   objPerson.Student.School IsNot Nothing Then
                    DistrictID = GetSafeValue(objPerson.Student.School.DistrictID)
                End If
                Dim strPhone As String = ""
                If objPerson.BestPhone IsNot Nothing Then
                    strPhone = GetSafeValue(objPerson.BestPhone.PhoneNum)
                End If

                Dim blnCloseConnection As Boolean = False
                Dim cmdToExecute As SqlCommand = New SqlCommand()
                Dim dt As DataTable = New DataTable()
                Dim adapter As New SqlDataAdapter(cmdToExecute)
                Try
                    cmdToExecute.CommandType = CommandType.StoredProcedure
                    cmdToExecute.Connection = Project.ConnectionProvider.Connection

                    If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                        blnCloseConnection = True
                        Project.ConnectionProvider.OpenConnection()
                    End If

                    'add the Stored Proc parameters
                    cmdToExecute.Parameters.Clear()
                    cmdToExecute.Parameters.Add(New SqlParameter("@CaseID", SqlDbType.Int, 4, ParameterDirection.Input,
                                                                 False, 10, 0, "", DataRowVersion.Proposed,
                                                                 GetSafeValue(objPerson.CaseID)))
                    cmdToExecute.Parameters.Add(New SqlParameter("@MPRID", SqlDbType.VarChar, 8,
                                                                 ParameterDirection.Input, False, 10, 0, "",
                                                                 DataRowVersion.Proposed, GetSafeValue(objPerson.MPRID)))
                    cmdToExecute.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.VarChar, 20,
                                                                 ParameterDirection.Input, False, 10, 0, "",
                                                                 DataRowVersion.Proposed,
                                                                 GetSafeValue(objPerson.FirstName)))
                    cmdToExecute.Parameters.Add(New SqlParameter("@LastName", SqlDbType.VarChar, 30,
                                                                 ParameterDirection.Input, False, 10, 0, "",
                                                                 DataRowVersion.Proposed,
                                                                 GetSafeValue(objPerson.LastName)))
                    cmdToExecute.Parameters.Add(New SqlParameter("@DOB", SqlDbType.DateTime, 8, ParameterDirection.Input,
                                                                 False, 10, 0, "", DataRowVersion.Proposed,
                                                                 GetSafeValue(objPerson.DateOfBirth)))

                    'AF 01/22/13 - Removed "FACES" specific check
                    cmdToExecute.Parameters.Add(New SqlParameter("@PhoneNum", SqlDbType.VarChar, 25,
                                                                 ParameterDirection.Input, False, 10, 0, "",
                                                                 DataRowVersion.Proposed, strPhone))
                    cmdToExecute.Parameters.Add(New SqlParameter("@SSN", SqlDbType.VarChar, 11, ParameterDirection.Input,
                                                                 False, 10, 0, "", DataRowVersion.Proposed,
                                                                 GetSafeValue(objPerson.SSN)))
                    cmdToExecute.CommandText = "dbo.[SMS_GetDuplicates]"

                    cmdToExecute.Parameters.Add(New SqlParameter("@ErrorCode", SqlDbType.Int, 4,
                                                                 ParameterDirection.Output, True, 10, 0, "",
                                                                 DataRowVersion.Proposed, mErrorCode))

                    ' Execute query.
                    adapter.Fill(dt)
                    mErrorCode = CType(cmdToExecute.Parameters.Item("@ErrorCode").Value, SqlInt32)

                    If Not mErrorCode.Equals(New SqlInt32(DataAccessError.OK)) Then
                        Throw New Exception(mErrorCode.ToString())
                    End If

                    ' Add a new Duplicate object to the collection for each Duplicate retrieved
                    For Each objDataRow As DataRow In dt.Rows
                        Add(New Duplicate(objDataRow))
                    Next

                Catch ex As Exception
                    ' Some error occured. Bubble it to caller and encapsulate Exception object
                    Throw New Exception(ex.Message, ex)
                Finally
                    If blnCloseConnection Then
                        blnCloseConnection = False
                        Project.ConnectionProvider.CloseConnection(False)
                    End If
                    cmdToExecute.Dispose()
                    adapter.Dispose()
                End Try

            End If

        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Duplicates collection.
    ''' </summary>
    ''' <remarks>
    '''     This creates an empty collection.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
        Clear()
    End Sub

#End Region
End Class