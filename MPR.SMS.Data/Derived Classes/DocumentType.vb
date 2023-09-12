'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a DocumentType object.
''' </summary>

    Public Class DocumentType
    Inherits TlkpDocumentType

#Region "Private Vars"

    Private ReadOnly mstrOutputFormat As String
    Private mobjDocumentGroup As DocumentGroup
    Private mobjDocumentOutputType As DocumentOutputType

#End Region

#Region "Public Methods"

    ''' <summary>
    '''     Returns a dataset associated with this DocumentType.
    ''' </summary>
    ''' <returns>
    '''     If successful, a DataTable used in the creation of documents. If an error occurs, nothing is returned.
    ''' </returns>
    ''' <remarks>
    '''     The GetDocumentData routine executes a stored procedure or a view associated with a DocumentType
    '''     and returns the resulting dataset.
    '''     The column DocumentDataSource in the table DocumentTypes must be the name of a stored
    '''     procedure or a view for this routine to execute.
    '''     Stored Procedures must begin with the letters SP to be recognized as such. All other
    '''     names are considered the name of a view.
    '''     The first column of all DataTables is assumed to be the Document ID.
    '''     The first column is never exported as part of the data set,
    '''     so if you need DocumentID to be exported, include it somewhere else in your data
    '''     table in addition to the first column.
    ''' </remarks>

        Public Function GetDocumentData() As DataTable

        If DataSourceStoredProc.IsNull Then
            Throw _
                New Exception(
                    "DocumentType::GetDocumentData::The DocumentDataSource column for this DocumentType is empty")
            Return Nothing
        End If

        If DataSourceStoredProc.Value = "" Then
            Throw _
                New Exception(
                    "DocumentType::GetDocumentData::The DocumentDataSource column for this DocumentType is empty")
            Return Nothing
        End If


        Dim connSQL As New SqlConnection(ConnectionString)
        Dim cmdSQL As SqlCommand


        cmdSQL = New SqlCommand(DataSourceStoredProc.Value, connSQL)
        cmdSQL.CommandType = CommandType.StoredProcedure
        cmdSQL.CommandTimeout = 120     '2 minutes
        cmdSQL.Parameters.Add(New SqlParameter("@DocTypeID", SqlDbType.Int, 4, ParameterDirection.Input, True, 10, 0, "",
                                               DataRowVersion.Proposed, Me.DocumentTypeID))

        Dim daSQL As New SqlDataAdapter(cmdSQL)
        Dim toReturn As New DataTable

        Try
            connSQL.Open()
            daSQL.Fill(toReturn)

        Catch ex As Exception
            Throw New Exception("DocumentType::GetDocumentData::Error occured", ex)
            Return Nothing
        Finally
            connSQL.Close()

            cmdSQL.Dispose()
            daSQL.Dispose()
            connSQL.Dispose()
        End Try

        Return toReturn
    End Function

    ''' <summary>
    '''     Returns whether the user has Write Permissions to the DocumentType's OutputFilePath.
    ''' </summary>
    ''' <returns>
    '''     True if user has Write Permissions to the OutputFilePath, False if they do not or if the OutputFilePath is Null or
    '''     blank.
    ''' </returns>

        Public Function OutputFileAccess() As Boolean

        If OutputFilePath.ToString = "" Then
            Return False
        End If

        Dim iFileNum As Short
        Dim strFileName As String = OutputFilePath.ToString & "TestForWriteAccess.txt"
        Try
            iFileNum = CType(FreeFile(), Short)
            FileOpen(iFileNum, strFileName, OpenMode.Output)
        Catch ex As Exception
            Return False
        Finally
            FileClose(iFileNum)
        End Try
        Kill(strFileName)
        Return True
    End Function


#End Region

#Region "Private Methods"

    Private Function StripChar(strText As String, strStripChars As String) As String

        Dim i As Integer
        Dim strTemp As String = strText

        For i = 1 To strStripChars.Length
            strTemp = Replace(strTemp, strStripChars.Chars(i - 1), "")
        Next
        Return strTemp
    End Function

#End Region

#Region "Public Properties"

    Public ReadOnly Property OutputFormat As String
        Get
            Return mstrOutputFormat
        End Get
    End Property

    Public Property DocumentOutputType As DocumentOutputType
        Get
            Return mobjDocumentOutputType
        End Get
        Set
            mobjDocumentOutputType = Value
        End Set
    End Property

    Public Property DocumentGroup As DocumentGroup
        Get
            Return mobjDocumentGroup
        End Get
        Set
            mobjDocumentGroup = Value
        End Set
    End Property

    Public Shadows Property OutputFilePath As String
        Get
            If MyBase.OutputFilePath.IsNull Then
                Return ""
            ElseIf MyBase.OutputFilePath.ToString = "" Then
                Return ""
            ElseIf Right(MyBase.OutputFilePath.ToString, 1) <> "\" Then
                Return MyBase.OutputFilePath.ToString & "\"
            Else
                Return MyBase.OutputFilePath.ToString
            End If
        End Get
        Set
            MyBase.OutputFilePath = New SqlString(Value)
        End Set
    End Property

    Public ReadOnly Property OutputFileFullName As String

        Get
            Dim strName As String

            If Not Project.ShortName = Nothing Then
                strName = Project.ShortName.ToString & "_"
            Else
                strName = ""
            End If
            strName = OutputFilePath.ToString & strName & OutputFileName.ToString & "_" & Format(Now, "yyyyMMdd") & "_" &
                      Format(Now, "HHmmss") & "." & OutputFormat

            Return strName
        End Get
    End Property

    Public ReadOnly Property OutputFileFullName(Param1 As String) As String

        Get
            Dim strName As String
            Dim strStripChars As String = "\/:*?<>| ,." & Chr(34)

            If Not Project.ShortName = Nothing Then
                strName = Project.ShortName.ToString & "_"
            Else
                strName = ""
            End If
            strName = OutputFilePath.ToString & strName & OutputFileName.ToString & "_" &
                      StripChar(Param1, strStripChars) & "_" & Format(Now, "yyyyMMdd") & "_" & Format(Now, "HHmmss") &
                      "." & OutputFormat

            Return strName
        End Get
    End Property

    Public ReadOnly Property OutputFileFullName(Param1 As String, Param2 As String) As String

        Get
            Dim strName As String
            Dim strStripChars As String = "\/:*?<>| ,." & Chr(34)

            If Not Project.ShortName = Nothing Then
                strName = Project.ShortName.ToString & "_"
            Else
                strName = ""
            End If
            strName = OutputFilePath.ToString & strName & OutputFileName.ToString & "_" &
                      StripChar(Param1 & "_" & Param2, strStripChars) & "_" & Format(Now, "yyyyMMdd") & "_" &
                      Format(Now, "HHmmss") & "." & OutputFormat

            Return strName
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see>.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the DocumentType class.
    ''' </summary>
    ''' <param name="objDataRow">
    '''     A DataRow object containing the values that the DocumentType is to be initialized with.
    ''' </param>
    ''' <remarks>
    '''     This form of the constructor is only intended to be used internally by the MPR.SMS.Data assembly/namespace.
    ''' </remarks>

        Friend Sub New(objDataRow As DataRow)

        MyBase.New(objDataRow)

        ConnectionString = Project.ConnectionString

        Dim i As Integer
        If Not DocumentGroupID.IsNull Then
            i = Project.DocumentGroups.IndexOf(DocumentGroupID.Value)
            If i >= 0 Then
                mobjDocumentGroup = Project.DocumentGroups(i)
            End If
        End If
        If Not DocumentOutputTypeID.IsNull Then
            i = Project.DocumentOutputTypes.IndexOf(DocumentOutputTypeID.Value)
            If i >= 0 Then
                mobjDocumentOutputType = Project.DocumentOutputTypes(i)
            End If
        End If

        mstrOutputFormat = mobjDocumentOutputType.OutputFormat.ToString
    End Sub

#End Region
End Class


