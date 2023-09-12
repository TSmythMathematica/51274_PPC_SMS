'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses


''' <summary>
'''     Provides methods for accessing, creating and manipulating a Site object.
''' </summary>

    Public Class Site
    Inherits TblSite
    'Implements ContactInformation

#Region "Private Fields"

    'Private mobjStrata As Strata

    Private mobjCase As [Case]

#End Region

#Region "Events"

    Event OnInsert(objSite As Site)

    Event OnUpdate(objSite As Site)

    Event OnDelete(objSite As Site)

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Site belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Site belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    Public ReadOnly Property Districts As Districts
        Get
            Return New Districts(SiteID)
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Site class constructor has multiple overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a Site class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the Site class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the Site is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ' Create the Strata collection for the Site

        'mobjStrata = New Strata(Me)

        '' Create the Grantee object for the Site
        'If Not GranteeID.IsNull Then
        '    'Dim objGrantees As Grantees = New Grantees(mobjProject)
        '    Dim i As Integer = mobjProject.Grantees.IndexOf(GranteeID.Value)

        '    If i >= 0 Then
        '        'mobjGrantee = objGrantees(i)
        '        mobjGrantee = mobjProject.Grantees(i)
        '    End If
        'End If

        '' Create the District object for the Site
        'If Not DistrictID.IsNull Then
        '    'Dim objDistricts As Districts = New Districts(mobjProject)
        '    Dim i As Integer = mobjProject.Districts.IndexOf(DistrictID.Value)

        '    If i >= 0 Then
        '        ' mobjDistrict = objDistricts(i)
        '        mobjDistrict = mobjProject.Districts(i)
        '    End If
        'End If
    End Sub

    '' '
    '' <summary>
    ''     ' Initializes a new instance of the Site class.
    ''     ' Note: uncomment this section if Sites are a Case Entity Type
    ''     '
    '' </summary>
    '' '
    '' <param name="objCase">
    ''     ' The MPR Case for which the object will be initialized.
    ''     '
    '' </param>
    '' <summary>
    ''     Initializes a new instance of the Site class.
    '' </summary>
    '' <param name="SiteID">
    ''     An integer containing the value that the Site is to be initialized with.
    '' </param>
    '' <remarks>
    ''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    '' </remarks>

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
    '        SelectOneWCaseIDLogic()

    '        'AF 12/15/04
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

    Public Sub New(SiteID As Integer)

        MyBase.New()

        MyBase.SiteID = New SqlInt32(SiteID)

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

        ' Create the Strata collection for the Site

        'mobjStrata = New Strata(Me)

        '' Create the Grantee object for the Site
        'If Not GranteeID.IsNull Then
        '    'Dim objGrantees As Grantees = New Grantees(mobjProject)
        '    Dim i As Integer = mobjProject.Grantees.IndexOf(GranteeID.Value)

        '    If i >= 0 Then
        '        'mobjGrantee = objGrantees(i)
        '        mobjGrantee = mobjProject.Grantees(i)
        '    End If
        'End If

        '' Create the District object for the Site
        'If Not DistrictID.IsNull Then
        '    'Dim objDistricts As Districts = New Districts(mobjProject)
        '    Dim i As Integer = mobjProject.Districts.IndexOf(DistrictID.Value)

        '    If i >= 0 Then
        '        ' mobjDistrict = objDistricts(i)
        '        mobjDistrict = mobjProject.Districts(i)
        '    End If
        'End If
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the Site into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Site object has been successfully inserted, otherwise false.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        ' Insert the Site

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a Site object in the database
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

        ' Update the Site

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Site from the database
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

        ' Delete the Site

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

#Region "ContactInformation"

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

