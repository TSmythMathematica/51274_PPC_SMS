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

    Public Class ClassroomTeacher
    Inherits TblClassroomTeacher

#Region "Events"

    Event OnInsert(objClassroomTeacher As ClassroomTeacher)
    Event OnUpdate(objClassroomTeacher As ClassroomTeacher)
    Event OnDelete(objClassroomTeacher As ClassroomTeacher)

#End Region

#Region "Private Fields"

    Private mobjClassroom As Classroom
    Private mobjTeacher As Teacher

    Private mstrLastError As String

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the ClassroomTeacher object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the ClassroomTeacher object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Teacher">Teacher</see> object that the ClassroomTeacher object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Teacher">Teacher</see> object that the ClassroomTeacher object belongs to.
    ''' </value>

        Public Property Teacher As Teacher
        Get
            If mobjTeacher Is Nothing AndAlso
               Not TeacherID.IsNull AndAlso
               Not TeacherID.Value.Equals(0) Then
                mobjTeacher = New Teacher(TeacherID.Value)
            End If
            Return mobjTeacher
        End Get
        Set
            mobjTeacher = value
            TeacherID = mobjTeacher.TeacherID
        End Set
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object that the ClassroomTeacher object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Classroom">Classroom</see> object that the ClassroomTeacher object belongs to.
    ''' </value>

        Public Property Classroom As Classroom
        Get
            If mobjClassroom Is Nothing AndAlso
               Not ClassroomID.IsNull AndAlso
               Not ClassroomID.Value.Equals(0) Then
                mobjClassroom = New Classroom(ClassroomID.Value)
            End If
            Return mobjClassroom
        End Get
        Set
            mobjClassroom = value
            ClassroomID = mobjClassroom.ClassroomID
        End Set
    End Property

    Public ReadOnly Property MobilityTypeID As Integer
        Get
            Dim objMobilityCode As New MobilityCode(MobilityCode.ToString)
            Return CType(objMobilityCode.MobilityTypeID, Integer)
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Creates a new instance of the ClassroomTeacher class.
    ''' </summary>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within the MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Public Sub New()

        MyBase.New()

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

    ''' <summary>
    '''     Creates a new instance of the ClassroomTeacher class.
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
    'the following two overloads were created, and should work, but have not
    'been needed yet. if you need them, just un-comment and debug if necessary.
    'If not, they may eventually be removed.

    '' '
    '' <summary>
    ''     ' Creates a new instance of the ClassroomTeacher class.
    ''     '
    '' </summary>
    '' '
    '' <param name="objClassroom">
    ''     ' The Classroom that will be used to initialize the ClassroomTeacher object.
    ''     '
    '' </param>
    '' '
    '' <param name="objTeacher">
    ''     ' The Teacher that will be used to initialize the ClassroomTeacher object.
    ''     '
    '' </param>
    '' '
    '' <remarks>
    ''     ' This form of the constructor is to retrieve a single ClassroomTeacher object
    ''     ' given a Classroom-Teacher combination
    ''     ' assembly.
    ''     '
    '' </remarks>
    '' '
    '' <summary>
    ''     ' Creates a new instance of the ClassroomTeacher class.
    ''     '
    '' </summary>
    '' '
    '' <param name="intClassroomTeacherID">
    ''     ' The ClassroomTeacherID that will be used to initialize the ClassroomTeacher object.
    ''     '
    '' </param>
    '' '
    '' <remarks>
    ''     ' This form of the constructor is to retrieve a single ClassroomTeacher object
    ''     ' given a primary key ID.
    ''     ' assembly.
    ''     '
    '' </remarks>
    '' <summary>
    ''     Inserts a ClassroomTeacher object into the database.
    '' </summary>
    '' <returns>
    ''     True if successful, otherwise False.
    '' </returns>

    'Public Sub New(ByVal objClassroom As Classroom, ByVal objTeacher As Teacher)

    '    MyBase.New()

    '    ConnectionString = Project.ConnectionString

    '    Dim objClassTeachers As New ClassroomTeachers(objClassroom)
    '    For Each objClassTeacher As ClassroomTeacher In objClassTeachers
    '        If objClassTeacher.TeacherID.Value.Equals(objTeacher.TeacherID.Value) Then

    '            Me.ClassroomTeacherID = objClassTeacher.ClassroomTeacherID
    '            Try
    '                SelectOne()
    '            Catch ex As Exception

    '                ' Rethrow the exception

    '                Throw ex
    '            Finally
    '            End Try

    '            Exit For

    '        End If
    '    Next

    '    ResetModified()

    'End Sub

    'Public Sub New(ByVal intClassroomTeacherID As Integer)

    '    MyBase.New()

    '    ConnectionString = Project.ConnectionString

    '    Me.ClassroomTeacherID = New SqlInt32(intClassroomTeacherID)

    '    SelectOne()

    '    ResetModified()

    'End Sub

#End Region

#Region "Private Methods"

#End Region

#Region "Public Methods"


    Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.TeacherID = mobjTeacher.TeacherID
        MyBase.ClassroomID = mobjClassroom.ClassroomID

        If Not IsModified Then
            Return True
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            blnResult = MyBase.Insert()

            If blnResult AndAlso MobilityTypeID.Equals(3) Then
                'You should be wondering why this is doing a Delete after the
                'Update. Mobility Type 3 = "Transfer Out of Study" and causes
                'the Teacher to become unassigned to this Classroom. The above
                'Update also records the mobility event to the ClassroomTeacherHistory
                'table. Then the Delete below removes it from the ClassroomTeacher
                'table so that it is unassigned, but it remains in the History table.
                'It is critical that there is no Cascade Delete Relationship between
                'ClassroomTeacher and ClassroomTeacherHistory.  SL 4/19/06
                MyBase.Delete()
            End If

        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnInsert(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Updates the ClassroomTeacher object within the database.
    ''' </summary>
    ''' <returns>
    '''     True if successful, otherwise False
    ''' </returns>

        Public Overrides Function Update() As Boolean

        If ClassroomTeacherID.IsNull Then
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

            If blnResult AndAlso MobilityTypeID.Equals(3) Then
                'You should be wondering why this is doing a Delete after the
                'Update. Mobility Type 3 = "Transfer Out of Study" and causes
                'the Teacher to become unassigned to this Classroom. The above
                'Update also records the mobility event to the ClassroomTeacherHistory
                'table. Then the Delete below removes it from the ClassroomTeacher
                'table so that it is unassigned, but it remains in the History table.
                'It is critical that there is no Cascade Delete Relationship between
                'ClassroomTeacher and ClassroomTeacherHistory.  SL 4/19/06
                MyBase.Delete()
            End If

        Catch ex As Exception
            blnResult = False
            mstrLastError = ex.Message
            Throw ex
        Finally
            ConnectionProvider = Nothing
        End Try

        If blnResult Then
            RaiseEvent OnUpdate(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes the ClassroomTeacher object from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the ClassroomTeacher object has been deleted, otherwise false
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
