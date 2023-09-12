'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

Public Class AddressHistory
    Inherits TblAddressHistory

    Event OnInsert(objAddressHistory As AddressHistory)
    Event OnUpdate(objAddressHistory As AddressHistory)
    Event OnDelete(objAddressHistory As AddressHistory)

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mobjAddress As Address

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the Classroom belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Address">Address</see> object that the AddressHistory object is associated with.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Address">Address</see> object that the AddressHistory object is associated with.
    ''' </value>

        Public ReadOnly Property Address As Address
        Get
            ' Get the index of the associated Address object initializing the Address
            ' object reference as needed.
            If Not AddressID.IsNull Then

                Dim i As Integer = mobjCase.Addresses.IndexOf(AddressID.Value)

                If i >= 0 Then
                    mobjAddress = mobjCase.Addresses(i)
                End If
            End If

            Return mobjAddress
        End Get
    End Property

    ''' <summary>
    '''     Gets the full street address (Address lines 1-4) of the Address object.
    ''' </summary>
    ''' <value>
    '''     The full street address of the Address object.
    ''' </value>
    Public ReadOnly Property FullStreetAddress As String
        Get
            Dim strAddr As String = Address1.ToString
            If Not Address2.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address2.ToString
            End If
            If Not Address3.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address3.ToString
            End If
            If Not Address4.ToString.Length.Equals(0) Then
                strAddr = strAddr & ", " & Address4.ToString
            End If
            Return strAddr
        End Get
    End Property

    ''' <summary>
    '''     Gets the full address (Address, city, state, zip) of the Address object.
    ''' </summary>
    ''' <value>
    '''     The full address of the Address object.
    ''' </value>
    Public ReadOnly Property FullAddress As String
        Get
            Dim strAddr As String = Address1.ToString
            If Not Address2.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address2.ToString
            End If
            If Not Address3.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address3.ToString
            End If
            If Not Address4.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & Address4.ToString
            End If
            If Not City.ToString.Length.Equals(0) Or
               Not State.ToString.Length.Equals(0) Or
               Not PostalCode.ToString.Length.Equals(0) Then
                strAddr = strAddr & vbCrLf & City.ToString
                strAddr = strAddr & ", " & State.ToString
                strAddr = strAddr & "  " & GetSafeZip(PostalCode.ToString)
            End If
            Return strAddr
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the AddressHistory class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The Case that the AddressHistory object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the AddressHistory object is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        'ConnectionString = mobjProject.ConnectionString
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the AddressHistory class.
    ''' </summary>
    ''' <param name="intHistoryID">
    '''     The AddressHistoryID to retrieve
    ''' </param>
    ''' <remarks>
    '''     Use this to retrieve a specific record from the database.
    ''' </remarks>

        Sub New(intHistoryID As Integer)

        'mobjCase = objCase

        'Dim obj As New TblAddressHistory
        'obj.ConnectionString = Project.ConnectionString
        'obj.AddressHistoryID = AddressHistoryID
        'Dim dt As DataTable = obj.SelectOne()
        'If dt.Rows.Count > 0 Then
        '    Dim dr As DataRow = dt.Rows(0)
        '    mobjAddressHistory = New AddressHistory(mobjCase, dr)
        'End If

        MyBase.New()

        MyBase.AddressHistoryID = New SqlInt32(intHistoryID)

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

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a AddressHistory object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Insert()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates a AddressHistory object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Update() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Update()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a AddressHistory object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean = False

        ' If the Project's Connection Provider is open, use it

        If mobjCase.Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = mobjCase.Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Delete()
        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnDelete(Me)
        End If

        Return blnResult
    End Function

#End Region
End Class
