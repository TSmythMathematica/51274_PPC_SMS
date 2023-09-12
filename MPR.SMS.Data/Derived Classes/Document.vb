'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Document object.
''' </summary>

    Public Class Document
    Inherits TblDocument

#Region "Events"

    Event OnInsert(objDocument As Document)
    Event OnUpdate(objDocument As Document)
    Event OnDelete(objDocument As Document)

#End Region

#Region "Private Fields"

    Private mobjCase As [Case]

    Private mobjInstrument As Instrument = Nothing
    Private mobjPersonHistory As PersonHistory = Nothing
    Private mobjAddressHistory As AddressHistory = Nothing

    Private mobjDocumentType As DocumentType
    Private mobjDocumentStatus As DocumentStatus

    Private mstrLastError As String

    'Private mstrDocCtrlID As String = ""

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Document object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Document object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets/Sets the <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Document object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Document object belongs to.
    ''' </value>
    Public Property [Case] As [Case]
        Get
            Return mobjCase
        End Get
        Set
            mobjCase = value
            MyBase.CaseID = mobjCase.CaseID
        End Set
    End Property

    ''' <summary>
    '''     Gets the CaseID of the Document object.
    ''' </summary>
    ''' <value>
    '''     The CaseID of the Document object.
    ''' </value>

        Public Shadows ReadOnly Property CaseID As SqlInt32
        Get
            Return MyBase.CaseID
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Instrument">Instrument</see> object of this Document.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Person">Instrument</see> object of this Document.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a Document object from a <see cref="T:MPR.SMS.Data.Instrument">Instrument</see> object, set this
    '''     property to Nothing (null).
    '''     The Document object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.Instrument">Instrument</see> object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property Instrument As Instrument
        Get
            If mobjInstrument Is Nothing Then
                If Not Me.InstrumentID.IsNull Then
                    Dim obj As New TblInstrument
                    obj.ConnectionString = Project.ConnectionString
                    obj.InstrumentID = Me.InstrumentID
                    Dim dt As DataTable = obj.SelectOne()
                    Dim dr As DataRow
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)
                        mobjInstrument = New Instrument(mobjCase, dr)
                    End If
                End If
            End If
            Return mobjInstrument
        End Get
        Set
            mobjInstrument = Value
            If Not mobjInstrument Is Nothing Then
                InstrumentID = mobjInstrument.InstrumentID
            Else
                InstrumentID = Nothing
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object of this Document.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object of this Document.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a Document object from a <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object, set
    '''     this property to Nothing (null).
    '''     The Document object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.PersonHistory">PersonHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>

        Public Property PersonHistory As PersonHistory
        Get
            If mobjPersonHistory Is Nothing Then
                If Not Me.PersonHistoryID.IsNull Then
                    Dim obj As New TblPersonHistory
                    obj.ConnectionString = Project.ConnectionString
                    obj.PersonHistoryID = Me.PersonHistoryID
                    Dim dt As DataTable = obj.SelectOne()
                    Dim dr As DataRow
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)
                        mobjPersonHistory = New PersonHistory(mobjCase, dr)
                    End If
                End If
            End If
            Return mobjPersonHistory
        End Get
        Set
            mobjPersonHistory = Value
            If Not mobjPersonHistory Is Nothing Then
                PersonHistoryID = mobjPersonHistory.PersonHistoryID
            Else
                PersonHistoryID = 0
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object of this Document.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object of this Document.
    ''' </value>
    ''' <remarks>
    '''     To disassociate a Document object from a <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object, set
    '''     this property to Nothing (null).
    '''     The Document object is is fully disassociated from any existing
    '''     <see cref="T:MPR.SMS.Data.AddressHistory">AddressHistory</see> object whenever the
    '''     property is set.
    ''' </remarks>
    Public Property AddressHistory As AddressHistory
        Get
            If mobjAddressHistory Is Nothing Then
                If Not Me.AddressHistoryID.IsNull Then
                    Dim obj As New TblAddressHistory
                    obj.ConnectionString = Project.ConnectionString
                    obj.AddressHistoryID = Me.AddressHistoryID
                    Dim dt As DataTable = obj.SelectOne()
                    Dim dr As DataRow
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)
                        mobjAddressHistory = New AddressHistory(mobjCase, dr)
                    End If
                End If
            End If
            Return mobjAddressHistory
        End Get
        Set
            mobjAddressHistory = Value
            If Not mobjAddressHistory Is Nothing Then
                AddressHistoryID = mobjAddressHistory.AddressHistoryID
            Else
                AddressHistoryID = 0
            End If
        End Set
    End Property

    Public Property DocumentType As DocumentType
        Get
            Dim i As Integer
            If Not DocumentTypeID.IsNull Then
                i = Project.DocumentTypes.IndexOf(DocumentTypeID.Value)
                If i >= 0 Then
                    mobjDocumentType = Project.DocumentTypes(i)
                End If
            End If
            Return mobjDocumentType
        End Get
        Set
            mobjDocumentType = Value
        End Set
    End Property

    Public Property DocumentStatus As DocumentStatus
        Get
            Dim i As Integer
            If Not DocumentStatusID.IsNull Then
                i = Project.DocumentStatuses.IndexOf(DocumentStatusID.Value)
                If i >= 0 Then
                    mobjDocumentStatus = Project.DocumentStatuses(i)
                End If
            End If
            Return mobjDocumentStatus
        End Get
        Set
            mobjDocumentStatus = Value
        End Set
    End Property
    'Public ReadOnly Property DocumentControlNumber() As String
    '    Get
    '        Return mstrDocCtrlID
    '    End Get
    'End Property

#End Region

#Region "Constructors"

    ''' <overloads>
    '''     The Document class constructor has several overloads.
    ''' </overloads>
    ''' <summary>
    '''     Creates a new instance of the Document class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Document belongs to.
    ''' </param>
    ''' <remarks>
    '''     This form of the Document constructor initializes the Document object with default values
    '''     and adds it to the <see cref="T:MPR.SMS.Data.Case">Case</see> object's Documents collection.
    ''' </remarks>

        Public Sub New(objCase As [Case])

        MyBase.New()

        mobjCase = objCase

        mobjCase.Documents.Add(Me)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        ResetModified()

        'Doesn't work in this version
        'Instrument = New Instrument(CInt(Me.InstrumentID), CInt(Me.InstrumentID))
        'AddressHistory = New AddressHistory(CInt(Me.AddressHistoryID))
    End Sub


    ''' <summary>
    '''     Creates a new instance of the Document class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Document belongs to.
    ''' </param>
    ''' <param name="objDocumentType">
    '''     The DocumentType that will be used to initialize the new Document object.
    '''     object.
    ''' </param>

        Public Sub New(objCase As [Case], objDocumentType As DocumentType)

        MyBase.New()

        mobjCase = objCase

        mobjCase.Documents.Add(Me)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        'mobjDocumentType = objDocumentType
        DocumentTypeID = objDocumentType.DocumentTypeID

        ConnectionString = Project.ConnectionString

        ResetModified()

        'Doesn't work in this version
        'Instrument = New Instrument(CInt(Me.InstrumentID), CInt(Me.InstrumentID))
        'AddressHistory = New AddressHistory(CInt(Me.AddressHistoryID))
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Document class.
    ''' </summary>
    ''' <param name="objCase">
    '''     The <see cref="T:MPR.SMS.Data.Case">Case</see> object that the Document belongs to.
    ''' </param>
    ''' <param name="objDataRow">
    '''     The DataRow from the Document table that will be used to initialize the new Document object.
    '''     object.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended for internal use within MPR.SMS.Data
    '''     assembly.
    ''' </remarks>

        Friend Sub New(objCase As [Case], objDataRow As DataRow)

        MyBase.New(objDataRow)

        mobjCase = objCase

        If Not Me.InstrumentID.IsNull Then
            Instrument = New Instrument(CInt(Me.InstrumentID), CInt(Me.InstrumentID))
        End If
        If Not Me.AddressHistoryID.IsNull Then
            AddressHistory = New AddressHistory(CInt(Me.AddressHistoryID))
        End If

        ConnectionString = Project.ConnectionString

        'mobjDocumentType = Project.DocumentTypes.GetByID(DocumentTypeID.Value)
        'mobjDocumentStatus = Project.DocumentStatuses.GetByID(DocumentStatusID.Value)
    End Sub

    ''' '
    ''' <summary>
    '''     ' Initializes a new instance of the Document class using a DocumentID.
    '''     '
    ''' </summary>
    ''' '
    ''' <param name="intDocumentID">
    '''     ' The Document ID for which the object will be initialized.
    '''     '
    ''' </param>

        Public Sub New(intDocumentID As Integer, IsDocumentBarcode As Boolean)

        MyBase.New()

        ConnectionString = Project.ConnectionString

        Me.DocumentID = New SqlInt32(intDocumentID)

        Try
            SelectOne()
            If Not Me.InstrumentID.IsNull Then
                Instrument = New Instrument(CInt(Me.InstrumentID), CInt(Me.InstrumentID))
            End If
            If Not Me.AddressHistoryID.IsNull Then
                AddressHistory = New AddressHistory(CInt(Me.AddressHistoryID))
            End If
        Catch ex As Exception
            Throw New Exception("Document::New Constructor(iDocumentID)::SelectOne method failed", ex)
        Finally
            'mobjDocumentType = Project.DocumentTypes.GetByID(DocumentTypeID.Value)
            'mobjDocumentStatus = Project.DocumentStatuses.GetByID(DocumentStatusID.Value)
        End Try
    End Sub

    ''' <summary>
    '''     Creates a new instance of the Document class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     The DataRow that will be used to initialize the Document object.
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

    ''' <summary>
    '''     Creates a new instance of the Document class.
    ''' </summary>
    ''' <remarks>
    '''     This constructor is used to create a new Document class pertaining
    '''     to a case, without adding it to the case's Documents collection.
    ''' </remarks>

        Public Sub New(intCaseID As Integer)

        MyBase.New()

        mobjCase = New [Case](intCaseID, False)

        If Not mobjCase.CaseID.IsNull Then
            MyBase.CaseID = mobjCase.CaseID
        End If

        ConnectionString = Project.ConnectionString

        ResetModified()
    End Sub

#End Region

#Region "Public Methods"

    'To-do: don't know what this is for
    'Public Overloads Function SelectOne(ByVal CaseID As Integer) As DataTable

    '    Dim connSQL As New SqlConnection(mobjCase.ConnectionString)
    '    Dim cmdSQL As New SqlCommand("sp_doc_SelectOne", connSQL)
    '    Dim daSQL As New SqlDataAdapter(cmdSQL)
    '    Dim dtToReturn As New DataTable("tblDocument")

    '    cmdSQL.CommandType = CommandType.StoredProcedure
    '    cmdSQL.Parameters.Add(New SqlParameter("@cCaseID", CaseID))

    '    Try
    '        connSQL.Open()
    '        daSQL.Fill(dtToReturn)
    '    Catch exSQL As SqlException
    '        Throw New Exception("Document::Overloaded SelectOne(CaseID)::Error occured", exSQL)
    '        Return Nothing
    '    Finally
    '        connSQL.Close()
    '        daSQL.Dispose()
    '        cmdSQL.Dispose()
    '        connSQL.Dispose()
    '    End Try

    '    Return dtToReturn
    'End Function

    'To-do: don't know why these were specifically needed.
    '' '
    '' <overloads>
    ''     ' The Recieved method has two overloads. An institated member function
    ''     ' without parameters.
    ''     '
    '' </overloads>
    '' '
    '' <summary>
    ''     ' Marks a document as recieved.
    ''     '
    '' </summary>
    '' '
    '' <summary>
    ''     ' Statuses a document as recieved by DocumentID."
    ''     '
    '' </summary>
    '' '
    '' <param name="iDocumentID">
    ''     ' The DocumentID to be statused as Recieved.
    ''     '
    '' </param>
    '' '
    '' <remarks>
    ''     ' Use this method when a Document object has not been instantied yet.
    ''     '
    '' </remarks>
    '' <summary>
    ''     Inserts the Document into the database.
    '' </summary>
    '' <returns>
    ''     True if the Document object has been successfully inserted, otherwise false
    '' </returns>
    '' <remarks>
    ''     If the Document object is not succesfully inserted, the LastError property contains
    ''     a message indicating the reason for failure.
    '' </remarks>

    'Public Overloads Sub Received()

    '    If DocumentStatusID.Value = 3 Then     'to-do: check tlkpDocumentStatus table for value
    '        Return
    '    End If

    '    Try
    '        DocumentStatusID = New SqlInt32(3) 'to-do: check tlkpDocumentStatus table for value
    '        Update()
    '    Catch ex As Exception
    '        Throw New Exception("Document::Received:Error updating status", ex)
    '    End Try

    'End Sub

    'Overloads Shared Sub Received(ByVal iDocumentID As Integer)

    '    Try
    '        Dim objDocument As New Document(iDocumentID)
    '        objDocument.Received()
    '    Catch ex As Exception
    '        Throw New Exception("Document::Overloaded Recieved::Error encountered", ex)
    '    Finally

    '    End Try

    'End Sub
    'Public Sub Undeliverable()

    '    If DocumentStatusID.Value = 4 Then 'to-do: check tlkpDocumentStatus table for value
    '        Return
    '    End If

    '    Try
    '        DocumentStatusID = New SqlInt32(4) 'to-do: check tlkpDocumentStatus table for value
    '        Update()
    '    Catch ex As Exception
    '        Throw New Exception("Document::Recieved:Error updating status", ex)
    '    End Try

    'End Sub


    Public Overrides Function Insert() As Boolean

        Dim blnResult As Boolean = False

        MyBase.CaseID = mobjCase.CaseID

        If mobjInstrument Is Nothing Then
            If Not Me.InstrumentID.IsNull Then
                MyBase.InstrumentID = Me.InstrumentID
            Else
                MyBase.InstrumentID = Nothing
            End If
        Else
            MyBase.InstrumentID = mobjInstrument.InstrumentID
        End If


        If mobjPersonHistory Is Nothing Then
            MyBase.PersonHistoryID = New SqlInt32(0)
        Else
            MyBase.PersonHistoryID = mobjPersonHistory.PersonHistoryID
        End If
        If mobjAddressHistory Is Nothing Then
            MyBase.AddressHistoryID = New SqlInt32(0)
        Else
            MyBase.AddressHistoryID = mobjAddressHistory.AddressHistoryID
        End If

        If Not IsModified Then
            Return True
        End If

        Dim blnCloseConnection As Boolean = False
        ConnectionProvider = Project.ConnectionProvider

        ' If the Project's Connection Provider is open, use it
        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If

        Try
            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

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
    '''     Update the Document in the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Document object has been successfully updated, otherwise false
    ''' </returns>
    ''' <remarks>
    '''     If the Document object is not succesfully updated, the LastError property contains
    '''     a message indicating the reason for failure.
    ''' </remarks>

        Public Overrides Function Update() As Boolean

        If DocumentID.IsNull Then
            Return Insert()
        ElseIf DocumentID.Value <= 0 Then
            Return Insert()
        ElseIf Not IsModified Then
            Return True
        End If

        Dim blnResult As Boolean

        Dim blnCloseConnection As Boolean = False
        ConnectionProvider = Project.ConnectionProvider

        If mobjInstrument Is Nothing Then
            If Not Me.InstrumentID.IsNull Then
                MyBase.InstrumentID = Me.InstrumentID
            Else
                MyBase.InstrumentID = Nothing
            End If
        Else
            MyBase.InstrumentID = mobjInstrument.InstrumentID
        End If

        If mobjPersonHistory Is Nothing Then
            MyBase.PersonHistoryID = New SqlInt32(0)
        Else
            MyBase.PersonHistoryID = mobjPersonHistory.PersonHistoryID
        End If
        If mobjAddressHistory Is Nothing Then
            MyBase.AddressHistoryID = New SqlInt32(0)
        Else
            MyBase.AddressHistoryID = mobjAddressHistory.AddressHistoryID
        End If

        ' If the Project's Connection Provider is open, use it

        If Project.ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider = Project.ConnectionProvider
        End If
        Try
            ' Open the database if needed
            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                blnCloseConnection = True
                ConnectionProvider.OpenConnection()
            End If

            blnResult = MyBase.Update()
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
            RaiseEvent OnUpdate(Me)
            ResetModified()
        End If

        Return blnResult
    End Function

    ''' <summary>
    '''     Deletes a Document from the database.
    ''' </summary>
    ''' <returns>
    '''     True if the Document object has been deleted, otherwise false
    ''' </returns>
    ''' <remarks>
    '''     If the Document object is not succesfully deleted, the LastError property contains
    '''     a message indicating the reason for failure.
    ''' </remarks>

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

#Region "Shared Members"


#End Region
End Class
