'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a CoderAssignment object.
''' </summary>

    Public Class CoderAssignment
    Inherits TblCoderAssignments

#Region "Private Fields"

    Private mstrLastError As String

    'Private mobjErrors As Errors

    Private mobjInstrument As Instrument
    Private mobjPerson As Person
    Private mobjCoder As Coder

    Private mobjCase As [Case]

    Private _DisplayName As String

#End Region

#Region "Private Methods"

#End Region

#Region "Events"

    Event OnInsert(objCoderAssignment As CoderAssignment)

    Event OnUpdate(objCoderAssignment As CoderAssignment)

    Event OnDelete(objCoderAssignment As CoderAssignment)

    Event OnBeforeDelete(objCoderAssignment As CoderAssignment, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The CoderAssignment class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a CoderAssignment class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CoderAssignment class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the CoderAssignment is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    '' '
    '' <summary>
    ''     ' Initializes a new instance of the CoderAssignment class.
    ''     '
    '' </summary>
    '' '
    '' <param name="objCase">
    ''     ' The MPR Case for which the object will be initialized.
    ''     '
    '' </param>
    '' <summary>
    ''     Initializes a new instance of the CoderAssignment class.
    '' </summary>
    '' <param name="CoderAssignmentID">
    ''     The CoderAssignmentID for which the object will be initialized.
    '' </param>

    'Public Sub New(ByVal objCase As [Case])

    '    MyBase.New()

    '    mobjCase = objCase

    '    MyBase.CaseID = objCase.CaseID

    '    ConnectionString = Project.ConnectionString

    '    ConnectionProvider = Project.ConnectionProvider

    '    Dim blnCloseConnection As Boolean = False

    '    Try

    '        ' Open the database if needed

    '        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
    '            blnCloseConnection = True
    '            ConnectionProvider.OpenConnection()
    '        End If
    '        SelectOne()

    '        ResetModified()

    '    Catch ex As Exception

    '        ' Rethrow the exception

    '        Throw ex

    '    Finally

    '        ' Insure the database is always closed if it was opened here

    '        If blnCloseConnection Then
    '            blnCloseConnection = False
    '            ConnectionProvider.CloseConnection(False)
    '        End If

    '        ConnectionProvider = Nothing

    '    End Try

    'End Sub


    Public Sub New(CoderAssignmentID As Integer)

        MyBase.New()

        MyBase.CoderAssignmentID = New SqlInt32(CoderAssignmentID)

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            SelectOne()


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

    Public Sub New(intInstrumentID As Integer, UnUsed As Integer)
        'Note: UnUsed is added to distinguish this constructor from the one that takes CoderAssignmentID

        MyBase.New()

        MyBase.Instrumentid = intInstrumentID

        ConnectionString = Project.ConnectionString

        ConnectionProvider = Project.ConnectionProvider

        Dim blnCloseConnection As Boolean = False

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            MyBase.CoderAssignmentID = CInt(SelectAllWinstrumentidLogic().Rows(0).Item("CoderAssignmentId"))

            SelectOne()

            mobjInstrument = New Instrument(intInstrumentID, 1)
            mobjInstrument.SelectOne()
            mobjInstrument.ResetModified()

            ResetModified()

        Catch ex As Exception

            ' Rethrow the exception

            Throw ex

        End Try
    End Sub


#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the CoderAssignment belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the CoderAssignment belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.CoderAssignment">CoderAssignment</see>'s Display Name (LastName, FirstName)
    '''     using SQLHelper so the Case object doesn't have to be instantiated.
    '''     <seealso cref="T:MPR.SMS.Data.CoderAssignment" />
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.CoderAssignment">CoderAssignment</see>'s Display Name (LastName, FirstName).
    ''' </value>

        Public ReadOnly Property DisplayName As String
        Get
            If Not Me.Caseid.IsNull Then
                If _DisplayName = "" Then
                    Dim blnCloseConnection As Boolean = False

                    If Not Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
                        blnCloseConnection = True
                        Project.ConnectionProvider.OpenConnection()
                    End If

                    Dim sqlstr As String = "SELECT LastName + ', ' + FirstName FROM tblcoder WHERE CoderID=" &
                                           Me.CoderId.Value  ' AND IsSampleMember=1
                    Dim dr As SqlDataReader = SqlHelper.ExecuteReader(Project.ConnectionProvider.Connection,
                                                                      CommandType.Text, sqlstr)
                    If dr.Read Then
                        _DisplayName = CStr(dr(0))
                    Else
                        _DisplayName = ""
                    End If

                    If blnCloseConnection Then
                        blnCloseConnection = False
                        Project.ConnectionProvider.CloseConnection(False)
                    End If
                    dr.Close()

                End If
            Else
                _DisplayName = ""
            End If
            Return _DisplayName
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the School that the CoderAssignment belongs to.
    ''' </summary>
    ''' <value>
    '''     The School that the CoderAssignment belongs to.
    ''' </value>

        Public Property Instrument As Instrument
        Get
            If mobjInstrument Is Nothing AndAlso Not Instrumentid.IsNull Then
                mobjInstrument = New Instrument(Instrumentid.Value)
            End If
            Return mobjInstrument
        End Get
        Set
            mobjInstrument = Value
        End Set
    End Property

    Public Property Coder As Coder
        Get
            If mobjCoder Is Nothing AndAlso Not CoderId.IsNull Then
                mobjCoder = New Coder(CoderId.Value)
            End If
            Return mobjCoder
        End Get
        Set
            mobjCoder = Value
        End Set
    End Property

    Public Property Person As Person
        Get
            If mobjPerson Is Nothing AndAlso Not Mprid.IsNull Then
                mobjPerson = New Person(Mprid.Value)
            End If
            Return mobjPerson
        End Get
        Set
            mobjPerson = Value
        End Set
    End Property

    '' '
    '' <summary>
    ''     ' Gets the first <see cref="T:MPR.SMS.Data.Classroom">Classroom</see>
    ''     ' that the CoderAssignment belongs to in the specified Grade.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> that the CoderAssignment belongs to.
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' This gets/sets the first Classroom for this CoderAssignment
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Classroom object for the CoderAssignment.
    ''     '
    '' </value>
    '' '
    '' <remarks>
    ''     ' This is a wrapper property for projects that only use one Classroom
    ''     ' per CoderAssignment. It hides some of the ClassroomCoderAssignment collection logic.
    ''     ' Be careful about setting a Classroom using this property: the Mobility
    ''     ' Code/Date won't get updated.  SL 4/26/06
    ''     '
    '' </remarks>
    '' '
    '' <summary>
    ''     ' Gets/Sets the ClassroomCoderAssignments collection for the Classroom.
    ''     ' ClassroomCoderAssignments binds the Classrooms to CoderAssignments in many-to-many relationship.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The ClassroomCoderAssignments collection for the Classroom.
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' Gets/Sets the Classrooms collection for the CoderAssignment.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Classrooms collection for the CoderAssignment.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets/Sets the Case associated with the CoderAssignment.
    '' </summary>
    '' <value>
    ''     The Case associated with the CoderAssignment.
    '' </value>
    '' <remarks>
    ''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    '' </remarks>

    'Public ReadOnly Property Classroom(ByVal strGrade As String) As Classroom

    '    Get
    '        For Each objClassroom As Classroom In Classrooms
    '            If objClassroom.Grade = strGrade Then
    '                Return objClassroom
    '            End If
    '        Next
    '        Return Nothing
    '    End Get

    'End Property

    'Public Property Classroom() As Classroom
    '    Get
    '        If mobjClassroom Is Nothing Then
    '            If Classrooms.Count > 0 Then
    '                mobjClassroom = Classrooms(0)
    '            End If
    '        End If
    '        Return mobjClassroom
    '    End Get
    '    Set(ByVal value As Classroom)
    '        mobjClassroom = value

    '        'if updating the existing Classroom...
    '        If ClassroomCoderAssignments.Count > 0 Then
    '            ClassroomCoderAssignments(0).Classroom = mobjClassroom
    '        Else    '...otherwise add a new Classroom
    '            Dim objCR As New ClassroomCoderAssignment
    '            objCR.Classroom = mobjClassroom
    '            objCR.CoderAssignment = Me
    '            ClassroomCoderAssignments.Add(objCR)
    '        End If
    '    End Set

    'End Property

    'Public Property ClassroomCoderAssignments() As ClassroomCoderAssignments
    '    Get
    '        If mobjClassroomCoderAssignments Is Nothing Then
    '            mobjClassroomCoderAssignments = New ClassroomCoderAssignments(Me)
    '        End If
    '        Return mobjClassroomCoderAssignments
    '    End Get
    '    Set(ByVal Value As ClassroomCoderAssignments)
    '        mobjClassroomCoderAssignments = Value
    '    End Set
    'End Property

    'Public Property Classrooms() As Classrooms
    '    Get
    '        If mobjClassrooms Is Nothing Then
    '            mobjClassrooms = New Classrooms(Me)
    '        End If

    '        Dim objClassCoderAssignments As ClassroomCoderAssignments = ClassroomCoderAssignments
    '        If objClassCoderAssignments.IsModified Then
    '            mobjClassrooms.Clear()
    '            For Each objClassroomCoderAssignment As ClassroomCoderAssignment In objClassCoderAssignments
    '                If objClassroomCoderAssignment.Classroom IsNot Nothing Then
    '                    mobjClassrooms.Add(objClassroomCoderAssignment.Classroom)
    '                End If
    '            Next
    '        End If
    '        Return mobjClassrooms
    '    End Get
    '    Set(ByVal Value As Classrooms)
    '        mobjClassrooms = Value
    '    End Set
    'End Property


    Public Property [Case] As [Case]
        Get
            If mobjCase Is Nothing Then
                mobjCase = New [Case](Me.CaseID.Value, True)
            End If
            Return mobjCase
        End Get
        Set
            mobjCase = Value
        End Set
    End Property

    Public Overloads ReadOnly Property IsModified As Boolean
        Get
            If MyBase.IsModified Then
                Return True
            End If
            Return False
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the CoderAssignment into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the CoderAssignment object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            ' insert the CoderAssignment
            blnResult = MyBase.Insert()

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
    '''     Updates a CoderAssignment object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = True

        Dim blnCloseConnection As Boolean = False

        ConnectionProvider = Project.ConnectionProvider

        Try

            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Update()

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

            ' Reset _DisplayName to force it to look up from the db
            _DisplayName = ""

            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a CoderAssignment from the database
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

            If Not Caseid.IsNull Then

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

    Friend Overloads Sub ResetModified()

        MyBase.ResetModified()
    End Sub

    Friend Overloads Sub RestoreModified()

        MyBase.RestoreModified()
    End Sub

#End Region
End Class
