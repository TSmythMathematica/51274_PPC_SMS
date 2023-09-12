'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a District object.
''' </summary>

    Public Class District
    Inherits TblDistrict

#Region "Private Fields"

    Private mobjSite As Site
    Private mstrLastError As String
    'Private mobjErrors As Errors
    Private mobjDistrictCase As [Case]

#End Region

#Region "Events"

    Event OnInsert(objDistrict As District)

    Event OnUpdate(objDistrict As District)

    Event OnDelete(objDistrict As District)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the District belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the District belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Site that the District belongs to.
    ''' </summary>
    ''' <value>
    '''     The Site that the District belongs to.
    ''' </value>

        Public Property Site As Site
        Get
            If mobjSite Is Nothing Then
                mobjSite = New Site(SiteID.Value)
            End If
            Return mobjSite
        End Get
        Set
            mobjSite = Value
        End Set
    End Property

    Public ReadOnly Property Schools As Schools
        Get
            Return New Schools(DistrictID)
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the District.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the District.
    ''' </value>
    ''' <remarks>
    '''     If this property is used the Case must be explicitly disposed to destroy the Case lock.
    ''' </remarks>

        Public Property [Case] As [Case]
        Get
            If mobjDistrictCase Is Nothing Then
                mobjDistrictCase = New [Case](Me.CaseID.Value, True)
                mobjDistrictCase.District = Me
            End If
            Return mobjDistrictCase
        End Get
        Set
            mobjDistrictCase = Value
        End Set
    End Property

    Public ReadOnly Property NextCenterNumber As Integer
        Get
            Dim obj As Object = SqlHelper.ExecuteScalar(ConnectionString, "Web_GetMaxCenterNumberInProgram",
                                                        CInt(DistrictID))

            If obj Is DBNull.Value Then
                Return 1
            Else
                Return CInt(obj) + 1
            End If
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The District class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a District class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        'AF 12/15/04
        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the District class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The MPR Case for which the object will be initialized.
    ''' </param>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjDistrictCase = objCase

        objCase.District = Me

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

            'AF 12/15/04
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
    '''     Initializes a new instance of the District class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the District is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        'AF 12/15/04
        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the District class.
    ''' </summary>
    ''' <param name="DistrictID">
    '''     The DistrictID for which the object will be initialized.
    ''' </param>

        Public Sub New(DistrictID As Integer)

        MyBase.New()

        MyBase.DistrictID = New SqlInt32(DistrictID)

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

            ' Ensure the database is always closed if it was opened here

            If blnCloseConnection Then
                blnCloseConnection = False
                ConnectionProvider.CloseConnection(False)
            End If

            ConnectionProvider = Nothing

        End Try
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the District into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the District object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the District

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
        Finally
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
    '''     Updates a District object in the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Update the District

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
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
    '''     Deletes a District from the database
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Delete the District

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

#End Region

#Region "Contact Information"

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
End Class
