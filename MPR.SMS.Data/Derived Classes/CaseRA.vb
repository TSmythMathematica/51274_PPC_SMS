'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a CaseRA object.
''' </summary>

    Public Class CaseRA
    Inherits TblCaseRA

#Region "Private Fields"

    Private mstrLastError As String

    'Private mobjErrors As Errors
    Private mblnIsNew As Boolean = False

    Private mobjCase As [Case]

#End Region

#Region "Private Methods"


#End Region

#Region "Private Properties"

    Private Property IsNew As Boolean
        Get
            Return mblnIsNew
        End Get
        Set
            mblnIsNew = value
        End Set
    End Property

#End Region

#Region "Events"

    Event OnInsert(objCaseRA As CaseRA)

    Event OnUpdate(objCaseRA As CaseRA)

    Event OnDelete(objCaseRA As CaseRA)

    Event OnBeforeDelete(objCaseRA As CaseRA, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The CaseRA class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a CaseRA class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseRA class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the CaseRA is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseRA class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The MPR Case for which the object will be initialized.
    ''' </param>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        MyBase.CaseID = objCase.CaseID

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If
            Dim dt As DataTable = SelectOne()

            IsNew = dt.Rows.Count = 0

            If RandomNumber.IsNull OrElse RandomNumber.Value.Equals(0) Then
                'AF 06/21/12 Changed methods after DOC found that RND is not truely random...
                Dim r As New Random()
                RandomNumber = r.NextDouble()

                '   RandomNumber = New SqlDouble(Rnd())
            End If

            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseRA belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseRA belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the CaseRA.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the CaseRA.
    ''' </value>

        Public Property [Case] As [Case]
        Get
            If mobjCase Is Nothing Then
                mobjCase = New [Case](Me.CaseID.Value, False)
            End If
            Return mobjCase
        End Get
        Set
            mobjCase = Value
        End Set
    End Property

    '' '
    '' <summary>
    ''     ' Gets the <see cref="T:MPR.SMS.Data.Errors">Errors</see> collection for the Case object.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The <see cref="T:MPR.SMS.Data.Errors">Errors</see> collection for the Case object.
    ''     '
    '' </value>
    '' <summary>
    ''     Inserts the CaseRA into the database.
    '' </summary>
    '' <returns>
    ''     True if the CaseRA object has been successfully inserted, otherwise false.
    '' </returns>

    'Public ReadOnly Property Errors() As Errors
    '    Get
    '        If mobjErrors Is Nothing Then
    '            mobjErrors = New Errors(Me)
    '            mobjErrors.PerformErrorChecks(Me)
    '        End If
    '        Return mobjErrors
    '    End Get
    'End Property
    'Public ReadOnly Property RAGroups() As RAGroups
    '    Get
    '        If mobjRAGroups Is Nothing Then
    '            mobjRAGroups = New RAGroups(Me)
    '        End If
    '        Return mobjRAGroups
    '    End Get
    'End Property

    'Public ReadOnly Property StrataID()

    '    Get
    '        Dim objStrataTableRow As StrataTableRow
    '        Dim sStratumValue(10) As SqlString
    '        Dim i As Integer
    '        Dim iStratumCount As Integer
    '        Dim sStratumName As String
    '        Dim sStratumTableValue As SqlString
    '        Dim blnFound As Boolean
    '        Dim strTrim As String
    '        Dim iSQL As SqlInt32
    '        Dim objCasePerson As Object
    '        Dim objStratum As Stratum
    '        Dim objSite As Site

    '        If Not Me.SiteID.IsNull Then
    '            i = Project.Sites.IndexOf(Me.SiteID.Value)
    '            objSite = Project.Sites(i)

    '            'Added 
    '            If Not Me.SampleMember.Case.Student.SchoolIDAtBaseline.IsNull Then
    '                objSite.ReviseStrata(Int(Me.SampleMember.Case.Student.SchoolIDAtBaseline.ToString))
    '            End If


    '            i = -1

    '            '  First get the strata values from the current Case and SampleMember objects
    '            For Each objStratum In objSite.Strata
    '                i = i + 1
    '                ' What Table (object) is the strata value in
    '                Select Case objStratum.StrataTable.Value
    '                    Case "Case"
    '                        objCasePerson = Me
    '                    Case "Person"
    '                        objCasePerson = Me.SampleMember
    '                    Case "Student"
    '                        objCasePerson = Me.Student
    '                End Select

    '                ' Get the value and store it in an array
    '                Try
    '                    Dim stest = CallByName(objCasePerson, _
    '                            objStratum.StrataColumn.Value, CallType.Get).GetType.Name()
    '                Catch
    '                    MsgBox("The Name for a strata column you have specified does not exist")
    '                Finally
    '                    Select Case CallByName(objCasePerson, _
    '                            objStratum.StrataColumn.Value, CallType.Get).GetType.Name()
    '                        Case "SqlString"
    '                            sStratumValue(i) = CallByName(objCasePerson, _
    '                                objStratum.StrataColumn.Value, CallType.Get)
    '                        Case "SqlInt32"
    '                            iSQL = CallByName(objCasePerson, _
    '                                objStratum.StrataColumn.Value, CallType.Get)

    '                            sStratumValue(i) = iSQL.ToSqlString

    '                    End Select

    '                End Try
    '            Next
    '            iStratumCount = i


    '            ' if any strata values are null then the strata is invalid

    '            Dim blnNull = False
    '            For i = 1 To iStratumCount
    '                If sStratumValue(i).IsNull Then
    '                    blnNull = True
    '                    Exit For
    '                End If
    '            Next

    '            If blnNull Then
    '                StrataID = -1
    '            Else

    '                '  Now check Strata Table (tlkpStrata) to see if that combination of 
    '                '   strata values are in the table

    '                blnFound = False
    '                For Each objStrataTableRow In Project.StrataTable
    '                    If objSite.SiteID.Value = objStrataTableRow.Site.Value Then

    '                        '  Here is a strata for that site.  Assume it is the right strata
    '                        '  (blnFound is true) until we find a non match

    '                        blnFound = True
    '                        For i = 1 To iStratumCount
    '                            sStratumName = "StratVar" & i.ToString.Trim
    '                            sStratumTableValue = CallByName(objStrataTableRow, _
    '                                        sStratumName, CallType.Get)
    '                            strTrim = sStratumValue(i).Value.Trim
    '                            If strTrim <> sStratumTableValue.Value Then
    '                                blnFound = False
    '                                Exit For
    '                            End If
    '                        Next
    '                        If blnFound Then
    '                            Exit For
    '                        End If
    '                    End If
    '                Next

    '                '  If that combination of strata values is not found
    '                '     then it is an error
    '                If Not blnFound Then
    '                    StrataID = -1
    '                Else
    '                    StrataID = objStrataTableRow.StrataID.Value
    '                End If
    '            End If
    '        End If

    '    End Get
    'End Property

#End Region

#Region "Public Methods"


    Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = True

        MyBase.CaseID = mobjCase.CaseID

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Insert()
            IsNew = False

        Catch ex As Exception

            blnResult = False

            mstrLastError = ex.Message

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a CaseRA object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            If IsNew Then
                blnResult = Insert()
                IsNew = False
            Else
                blnResult = MyBase.Update()
            End If

        Catch ex As Exception

            blnResult = False

            Throw ex

        Finally

            ' Insure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a CaseRA from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        Dim blnCancel As Boolean = False

        ' Let's allow the peanut gallery to have a say in whether this Delete occurs

        RaiseEvent OnBeforeDelete(Me, blnCancel)

        blnResult = Not blnCancel

        ' If no objections from the peanut gallery, delete the Case

        If blnResult Then

            ConnectionString = Project.ConnectionString

            ' If CaseID has not been assigned, skip delete

            If Not CaseID.IsNull Then

                Try

                    blnResult = MyBase.Delete()

                Catch ex As Exception

                    blnResult = False

                    Throw ex

                End Try

            End If

        End If

        ' If successful, raise OnDelete event

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        ' Return result

        Return blnResult
    End Function

#End Region
End Class
