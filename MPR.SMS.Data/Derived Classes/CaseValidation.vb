'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a CaseValidation object.
''' </summary>

    Public Class CaseValidation
    Inherits TblCaseValidation

#Region "Private Fields"

    Private mstrLastError As String

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

    Event OnInsert(objCaseValidation As CaseValidation)
    Event OnUpdate(objCaseValidation As CaseValidation)
    Event OnDelete(objCaseValidation As CaseValidation)
    Event OnBeforeDelete(objCaseValidation As CaseValidation, ByRef blnCancel As Boolean)

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The CaseValidation class constructor has two overloads.
    ''' </overloads>
    ''' <summary>
    '''     Initializes a new instance of a CaseValidation class with default values.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Initializes a new instance of the CaseValidation class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the CaseValidation is to be initialized with.
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
    '''     Initializes a new instance of the CaseValidation class.
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
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseValidation belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> that the CaseValidation belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the Case associated with the CaseValidation.
    ''' </summary>
    ''' <value>
    '''     The Case associated with the CaseValidation.
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

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts the CaseValidation into the database.
    ''' </summary>
    ''' <returns>
    '''     True if the CaseValidation object has been successfully inserted, otherwise false.
    ''' </returns>

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
    '''     Updates a CaseValidation object in the database
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
    '''     Deletes a CaseValidation from the database
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
