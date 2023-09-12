'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a School object.
''' </summary>

    Public Class School
    Inherits TblSchool

#Region "Private Fields"

    Private mstrLastError As String
    'Private mobjErrors As Errors
    Private mobjDistrict As District
    Private mobjSchoolCase As [Case]
    Private mobjClassrooms As Classrooms
    Private mobjStudents As Students
    Private mobjUnassignedStudents As Students

#End Region

#Region "Events"

    Event OnInsert(objSchool As School)

    Event OnUpdate(objSchool As School)

    Event OnDelete(objSchool As School)

    Event OnBeforeDelete(objSchool As School, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The School class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a School class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the School class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the School is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Public Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the School class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The MPR Case for which the object will be initialized.
    ''' </param>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjSchoolCase = objCase

        objCase.School = Me

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
            SelectOneWCaseIDLogic()

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

    ''' <summary>
    '''     Initializes a new instance of the School class.
    ''' </summary>
    ''' <param name="SchoolID">
    '''     The SchoolID for which the object will be initialized.
    ''' </param>

        Public Sub New(SchoolID As Integer)

        MyBase.New()

        MyBase.SchoolID = New SqlInt32(SchoolID)

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

#End Region

#Region "Private Functions"

    Private Function RetrieveStudents(blnUnassigned As Boolean) As Students

        Dim Students As Students = New Students

        Dim objStudent As New TblStudent

        objStudent.SchoolID = Me.SchoolID

        objStudent.ConnectionString = ConnectionString

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objStudent.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objStudents As DataTable = objStudent.SelectAllWSchoolIDLogic()

        objStudent.ConnectionProvider = Nothing

        ' Initialize the Students collection

        For Each objStudentDR As DataRow In objStudents.Rows
            If blnUnassigned = False OrElse
               GetSafeValue(CType(objStudentDR("ClassroomID"), SqlInt32)) = 0 Then
                Students.Add(New Student(objStudentDR))
            End If
        Next

        Return Students
    End Function

#End Region

#Region "Contact Properties"

    'Public Property AddressLine1() As String Implements ContactInformation.AddressLine1
    '    Get
    '        If Me.ContactAddressLine1.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactAddressLine1.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactAddressLine1 = SqlString.Null
    '        Else
    '            Me.ContactAddressLine1 = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property AddressLine2() As String Implements ContactInformation.AddressLine2
    '    Get
    '        If Me.ContactAddressLine2.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactAddressLine2.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactAddressLine2 = SqlString.Null
    '        Else
    '            Me.ContactAddressLine2 = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property City() As String Implements ContactInformation.City
    '    Get
    '        If Me.ContactCity.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactCity.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactCity = SqlString.Null
    '        Else
    '            Me.ContactCity = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property FirstName() As String Implements ContactInformation.FirstName
    '    Get
    '        If Me.ContactFirstName.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactFirstName.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactFirstName = SqlString.Null
    '        Else
    '            Me.ContactFirstName = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property LastName() As String Implements ContactInformation.LastName
    '    Get
    '        If Me.ContactLastName.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactLastName.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactLastName = SqlString.Null
    '        Else
    '            Me.ContactLastName = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property State() As String Implements ContactInformation.State
    '    Get
    '        If Me.ContactState.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactState.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactState = SqlString.Null
    '        Else
    '            Me.ContactState = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

    'Public Property Zip() As String Implements ContactInformation.Zip
    '    Get
    '        If Me.ContactZip.IsNull Then
    '            Return String.Empty
    '        Else
    '            Return Me.ContactZip.Value
    '        End If
    '    End Get
    '    Set(ByVal Value As String)
    '        If Value Is Nothing Then
    '            Me.ContactZip = SqlString.Null
    '        Else
    '            Me.ContactZip = New SqlString(Value)
    '        End If
    '    End Set
    'End Property

#End Region

#Region "Public Properties"

    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the School.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the School.
    ''' </value>
    ''' <remarks>
    '''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    ''' </remarks>

        Public Property [Case] As [Case]
        Get
            If mobjSchoolCase Is Nothing Then
                mobjSchoolCase = New [Case](Me.CaseID.Value, True)
                mobjSchoolCase.School = Me
            End If
            Return mobjSchoolCase
        End Get
        Set
            mobjSchoolCase = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the District that the School belongs to.
    ''' </summary>
    ''' <value>
    '''     The District that the School belongs to.
    ''' </value>

        Public Property District As District
        Get
            If mobjDistrict Is Nothing Then
                mobjDistrict = New District(DistrictID.Value)
            End If
            Return mobjDistrict
        End Get
        Set
            mobjDistrict = Value
        End Set
    End Property

    Public Property Classrooms As Classrooms
        Get
            If mobjClassrooms Is Nothing Then
                mobjClassrooms = New Classrooms(Me)
            End If
            Return mobjClassrooms
        End Get
        Set
            mobjClassrooms = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Students collection for the School.
    ''' </summary>
    ''' <value>
    '''     The Students collection for the School.
    ''' </value>

        Public Property Students As Students
        Get
            If mobjStudents Is Nothing Then
                mobjStudents = RetrieveStudents(False)
            End If
            Return mobjStudents
        End Get
        Set
            mobjStudents = Value
        End Set
    End Property

    ''' <summary>
    '''     Gets/Sets the Unassigned Students collection for the School.
    ''' </summary>
    ''' <value>
    '''     The Unassigned Students collection for the School.
    ''' </value>

        Public ReadOnly Property UnassignedStudents As Students
        Get
            If mobjUnassignedStudents Is Nothing Then
                mobjUnassignedStudents = RetrieveStudents(True)
            End If
            Return mobjUnassignedStudents
        End Get
    End Property

    Public ReadOnly Property NextClassroomNumber As Integer
        Get
            Dim obj As Object = SqlHelper.ExecuteScalar(ConnectionString, "Web_GetMaxClassroomNumberInSchool",
                                                        CInt(SchoolID))

            If obj Is DBNull.Value Then
                Return 1
            Else
                Return CInt(obj) + 1
            End If
        End Get
    End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a School object and its dependent objects into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
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

            ' insert the School
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
            'AF 12/14/04 - Need to call reset modified or will always be dirty 
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a School within the database
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
            'AF 12/15/04 - Need to call reset modified or will always be dirty 
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a School object from the database
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
