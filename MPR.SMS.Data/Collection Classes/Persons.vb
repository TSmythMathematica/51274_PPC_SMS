'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides a strongly typed collection of Person objects.
''' </summary>

    Public Class Persons
    Inherits CollectionBase

#Region "Private Fields"

    Private ReadOnly mobjCase As [Case]
    Private mblnObjDeleted As Boolean = False

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
    '''     Gets the Person object at a specific index.
    ''' </summary>
    ''' <param name="Index">
    '''     The index of the Person object to be retrieved.
    ''' </param>
    ''' <value>
    '''     The Person object at the specified index within the collection.
    ''' </value>

        Default Public Property Item(Index As Integer) As Person
        Get
            If Index < List.Count Then
                Return CType(List.Item(Index), Person)
            Else
                Return Nothing
            End If
        End Get
        Set
            List.Item(Index) = value
        End Set
    End Property

    Public ReadOnly Property IsModified As Boolean
        Get
            Dim objPerson As Person
            For Each objPerson In List
                If objPerson.IsModified Then
                    Return True
                ElseIf objPerson.PersonRaces.IsModified Then
                    Return True
                ElseIf objPerson.PersonBest.IsModified Then
                    Return True
                    'ElseIf objPerson.LocatingAttempts.IsModified Then
                    '    Return True
                ElseIf objPerson.LocatingStatus IsNot Nothing AndAlso
                       objPerson.LocatingStatus.IsModified Then
                    Return True
                ElseIf objPerson.Student IsNot Nothing AndAlso
                       objPerson.Student.IsModified Then
                    Return True
                End If
            Next
            Return mblnObjDeleted
        End Get
    End Property

    'Public ReadOnly Property SampleMember() As Person
    '    Get
    '        For Each Person As Person In Me
    '            If Person.IsSampleMember Then
    '                Return Person
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

    'Public ReadOnly Property CurrentRespondent() As Person
    '    Get
    '        For Each Person As Person In Me
    '            If Person.IsCurrentRespondent Then
    '                Return Person
    '            End If
    '        Next
    '        Return Nothing
    '    End Get
    'End Property

    'Public ReadOnly Property Leads() As Persons
    '    Get
    '        Dim Persons As New Persons
    '        For Each Person As Person In Me
    '            If Person.IsLead Then
    '                Persons.Add(Person)
    '            End If
    '        Next
    '        Return Persons
    '    End Get
    'End Property

    'Public ReadOnly Property Contacts() As Persons
    '    Get
    '        Dim Persons As New Persons
    '        For Each Person As Person In Me
    '            If Person.IsContact Then
    '                Persons.Add(Person)
    '            End If
    '        Next
    '        Return Persons
    '    End Get
    'End Property

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Adds a Person object to the end of the collection.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The Person object to be added to the end of the collection.
    ''' </param>
    ''' <returns>
    '''     The index at which the Person object has been added within the collection.
    ''' </returns>

        Public Function Add(objPerson As Person) As Integer

        Return List.Add(objPerson)
    End Function

    Public Sub Remove(objPerson As Person)

        'remove all children records that are not "shared"
        Dim objAddresses As Addresses = objPerson.Addresses
        For Each obj As Address In objAddresses
            If obj.Person IsNot Nothing AndAlso
               obj.Person.Equals(objPerson) Then 'only remove records belonging to this person only
                mobjCase.Addresses.Remove(obj)
            End If
        Next
        Dim objPhones As Phones = objPerson.Phones
        For Each obj As Phone In objPhones 'only remove records belonging to this person only
            If obj.Person IsNot Nothing AndAlso
               obj.Person.Equals(objPerson) Then
                mobjCase.Phones.Remove(obj)
            End If
        Next
        Dim objEmails As Emails = objPerson.Emails
        For Each obj As Email In objEmails 'only remove records belonging to this person only
            If obj.Person IsNot Nothing AndAlso
               obj.Person.Equals(objPerson) Then
                mobjCase.Emails.Remove(obj)
            End If
        Next
        'If objPerson.Student IsNot Nothing Then objPerson.Student.Remove()

        Dim index As Integer = List.IndexOf(objPerson)

        If index >= 0 Then
            List.RemoveAt(index)
            mblnObjDeleted = True
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the Person object within the collection with a specified MPRID.
    ''' </summary>
    ''' <param name="strMPRID">
    '''     The MPRID of the Person object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the Person object within the collection having the specified MPRID,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOf(strMPRID As String) As Integer

        If strMPRID <> "" Then
            Dim i As Integer
            For i = 0 To (Count - 1)
                Dim objPerson As Person = CType(List.Item(i), Person)
                If Not objPerson.MPRID.IsNull AndAlso objPerson.MPRID.ToString = strMPRID Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    ''' <summary>
    '''     Adds/Updates a Person object within the Person collection.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The Person object to find and add/update into the collection.
    ''' </param>

        Public Sub ModifyObjectInCollection(objPerson As Person)

        'put the Person object into the Case's Person collection
        Dim intIndex As Integer = Me.IndexOfObject(objPerson)
        If intIndex < 0 AndAlso objPerson.IsValid Then
            objPerson.Case = mobjCase
            Me.Add(objPerson)
        ElseIf intIndex >= 0 Then
            Me.Item(intIndex) = objPerson
        End If
    End Sub

    ''' <summary>
    '''     Gets the index of the specified Person object.
    ''' </summary>
    ''' <param name="objPerson">
    '''     The Person object whose index within the collection is to be retrieved.
    ''' </param>
    ''' <returns>
    '''     The index of the specified Person object within the collection,
    '''     or -1 if not found.
    ''' </returns>

        Public Function IndexOfObject(objPerson As Person) As Integer

        If Not objPerson Is Nothing Then
            For i As Integer = 0 To List.Count - 1
                If List.Item(i).Equals(objPerson) Then
                    Return i
                End If
            Next
        End If

        Return - 1
    End Function

    Friend Sub ResetModified()

        Dim objPerson As Person

        For Each objPerson In List
            objPerson.ResetModified()
            objPerson.PersonBest.ResetModified()
            objPerson.PersonRaces.ResetModified()

            'If objPerson.LocatingAttempts IsNot Nothing Then
            '    objPerson.LocatingAttempts.ResetModified()
            'End If
            If objPerson.LocatingStatus IsNot Nothing Then
                objPerson.LocatingStatus.ResetModified()
            End If
            If objPerson.Student IsNot Nothing Then
                objPerson.Student.ResetModified()
            End If
        Next
        mblnObjDeleted = False
    End Sub

    Friend Sub RestoreModified()

        Dim objPerson As Person

        Dim i As Integer = List.Count

        While i > 0
            If Item(i - 1).MPRID.IsNull Then
                List.RemoveAt(i - 1)
            End If
            i = i - 1
        End While

        For Each objPerson In List
            objPerson.RestoreModified()
            objPerson.PersonBest.RestoreModified()
            objPerson.PersonRaces.RestoreModified()

            'If objPerson.LocatingAttempts IsNot Nothing Then
            '    objPerson.LocatingAttempts.RestoreModified()
            'End If
            If objPerson.LocatingStatus IsNot Nothing Then
                objPerson.LocatingStatus.RestoreModified()
            End If

            If objPerson.Student IsNot Nothing Then
                objPerson.Student.RestoreModified()
            End If
        Next
        mblnObjDeleted = False
    End Sub

    Friend Function Insert() As Boolean

        Dim objPerson As Person
        Dim blnResult As Boolean = True

        For Each objPerson In List
            blnResult = objPerson.Insert()
            If Not blnResult Then
                Exit For
            End If
        Next

        Return blnResult
    End Function

    Friend Function Update() As Boolean

        Dim objPerson As Person
        Dim blnResult As Boolean = True

        For Each objPerson In List
            blnResult = objPerson.Update()
            If Not blnResult Then
                Exit For
            End If
        Next

        'remove any records from the database that were removed from the collection
        If mblnObjDeleted Then
            Dim objExistingCollection As New Persons(mobjCase)
            For Each objExistingClass As Person In objExistingCollection
                If Me.IndexOf(objExistingClass.MPRID.ToString) = - 1 Then 'no longer exists
                    objExistingClass.Delete()
                End If
            Next
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Gets the Person object at a specific MPRID.
    ''' </summary>
    ''' <param name="strMPRID">
    '''     The MPRID of the Person object to be retrieved.
    ''' </param>

        Public Function GetByMPRID(strMPRID As String) As Person
        For Each Person As Person In Me
            If Person.MPRID.Value = strMPRID Then
                Return Person
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    '''     Gets the Person object at a specific RelationshipTypeID.
    ''' </summary>
    ''' <param name="RelationshipTypeID">
    '''     The RelationshipTypeID of the Person object to be retrieved.
    ''' </param>

        Public Function GetByRelationshipTypeID(RelationshipTypeID As Integer) As Person
        For Each Person As Person In Me
            If Person.RelationshipTypeID.Value = RelationshipTypeID Then
                Return Person
            End If
        Next
        Return Nothing
    End Function

    ''' <summary>
    '''     Gets the Person object at a specific RelationshipType.
    ''' </summary>
    ''' <param name="RelationshipType">
    '''     The RelationshipType string of the Person object to be retrieved.
    ''' </param>

        Public Function GetByRelationshipType(RelationshipType As String) As Person
        For Each Person As Person In Me
            If _
                Person.RelationshipType IsNot Nothing AndAlso
                Person.RelationshipType.RelationshipType.Value = RelationshipType Then
                Return Person
            End If
        Next
        Return Nothing
    End Function

    Public Sub SortByRelationshipTypeID()

        Me.InnerList.Sort(New RelTypeComparer)
    End Sub

#End Region

#Region "Constructors"

    Public Sub New(objCase As [Case])

        Dim objPerson As New TblPerson

        mobjCase = objCase

        objPerson.CaseID = objCase.CaseID

        objPerson.ConnectionString = Project.ConnectionString

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            objPerson.ConnectionProvider = Project.ConnectionProvider
        End If

        Dim objPersons As DataTable = objPerson.SelectAllWCaseIDLogic()

        objPerson.ConnectionProvider = Nothing

        ' Add a new Person to the collection for each Person retrieved

        Dim objDataRow As DataRow

        For Each objDataRow In objPersons.Rows
            Add(New Person(objCase, objDataRow))
        Next
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Persons collection.
    ''' </summary>
    ''' <remarks>
    '''     This creates an empty collection.
    ''' </remarks>

        Friend Sub New()

        MyBase.New()
        Clear()
    End Sub

#End Region

    Private Class RelTypeComparer
        Implements IComparer

        Public Function CompareTo(x As Object, y As Object) As Integer _
            Implements IComparer.Compare

            If Not (TypeOf x Is Person And TypeOf y Is Person) Then
                Throw New ArgumentException _
                    ("The objects to compare must be of type 'Person'")
            End If

            Dim RelID1 As Integer = CType(x, Person).RelationshipType.RelationshipTypeID.Value

            Dim RelID2 As Integer = CType(y, Person).RelationshipType.RelationshipTypeID.Value

            CompareTo = RelID1.CompareTo(RelID2)
        End Function
    End Class
End Class
