'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and synchronizing a Person object in the
'''     database.
''' </summary>

    Public Class PersonRace
    Inherits TblPersonRace

#Region "Events"

    Event OnInsert(objPersonRace As PersonRace)
    Event OnUpdate(objPersonRace As PersonRace)
    Event OnDelete(objPersonRace As PersonRace)

#End Region

#Region "Private Fields"

    Private ReadOnly mobjPerson As Person

    Private mobjRaceType As RaceType

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the PersonRace object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the PersonRace object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return mobjPerson.Project
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonRace object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonRace object belongs to.
    ''' </value>

        Public ReadOnly Property Person As Person
        Get
            Return mobjPerson
        End Get
    End Property

    ''' <summary>
    '''     Gets the RaceType of the PersonRace object.
    ''' </summary>
    ''' <value>
    '''     The RaceType of the PersonRace object.
    ''' </value>
    Public Property RaceType As RaceType
        Get
            Dim i As Integer
            If Not RaceTypeID.IsNull Then
                i = Project.SourceTypes.IndexOf(RaceTypeID.Value)
                If i >= 0 Then
                    mobjRaceType = Project.RaceTypes(i)
                End If
            End If
            Return mobjRaceType
        End Get
        Set
            mobjRaceType = value
        End Set
    End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The PersonRace class constructor has three overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the PersonRace class.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonRace object belongs to.
    ''' </param>

        Public Sub New(objPerson As Person)

        mobjPerson = objPerson

        ConnectionString = mobjPerson.Project.ConnectionString

        If Not objPerson.CaseID.IsNull Then
            MyBase.MPRID = objPerson.MPRID
        End If

        mobjPerson.PersonRaces.Add(Me)

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonRace class.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The <see cref="T:MPR.SMS.Data.Person">Person</see> object that the PersonRace object belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the PersonRace object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objPerson As Person, objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjPerson = objPerson

        ConnectionString = mobjPerson.Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the PersonRace class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Person object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

#End Region

#Region "Private Methods"

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Inserts a PersonRace object into the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False.
    ''' </returns>

        Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjPerson.CaseID
        MyBase.MPRID = mobjPerson.MPRID

        If Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
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
            'AF 12/14/04 - Need to call reset modified or will always be dirty 
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the PersonRace object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If PersonRaceID.IsNull Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
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
            'AF 12/15/04 - Need to call reset modified or will always be dirty 
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes the PersonRace object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the PersonRace object has been deleted, otherwise false
    ''' </returns>

        Public Overrides Function Delete() As Boolean

        Dim blnResult As Boolean

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
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
