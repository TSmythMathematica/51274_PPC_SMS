'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Web
Imports MPR.SMS.Data.BaseClasses

''' <summary>
'''     Provides methods for accessing, creating and manipulating a Project.
''' </summary>
''' <remarks>
'''     The Project class provides a high level abstraction of the Project database itself
'''     and does not represent any particular object within the database. Instead it exposes
'''     properties and methods that are specific to the Project including the configuration
'''     properties that are maintained in the application's configuration file.
''' </remarks>

Public Class Project
    'error & duplication checking
    Public Enum CheckingType
        NoChecking = 0
        PrimarySampleMemberOnly = 1
        AllCaseMemebers = 2
    End Enum

    Public Enum FieldAssignmentAssignByType
        SelectedCases = 0
        Classroom = 1
        School = 2
        District = 3
        Custom = 4
    End Enum

#Region "Private Fields"

    Private Shared Instance As Project = Nothing
    Private Shared _IsRuntime As Boolean = False

    ' Application Settings

    Private ReadOnly mobjAppSettings As NameValueCollection

    ' Project configuration fields from application settings 

    Private ReadOnly mstrProjectName As String
    Private ReadOnly mstrProjectShortName As String
    Private ReadOnly mstrProjectCode As String = ""
    Private ReadOnly mstrRPSTaskCode As String = ""
    Private ReadOnly mstrRPSBankAccount As String = ""
    Private ReadOnly mstrRPSModeOfPayment As String = ""
    Private ReadOnly mstrRPSProjectType As String = ""
    Private ReadOnly mstrRPSServer As String = ""
    Private ReadOnly mstrFMSiteAddress As String = ""
    Private ReadOnly mstrRPSConnectionString As String = ""
    Private ReadOnly mblnIsISMSProject As Boolean = False

    Private ReadOnly mintCurrentRound As Integer
    Private ReadOnly mblnShowRound As Boolean
    Private ReadOnly mblnAllowShared As Boolean
    Private ReadOnly mblnLockLocCases As Boolean
    Private ReadOnly mstrConnectionString As String
    'Private mblnHideReturnedMail As Boolean
    Private ReadOnly mintErrorChecking As Integer
    Private ReadOnly mintDuplicatesChecking As Integer
    Private ReadOnly mblnAllowManyClassroomsPerTeacher As Boolean
    Private ReadOnly mblnAllowManyTeachersPerClassroom As Boolean

    Private mintFieldAssignmentAssignBy As Integer
    Private mblnProjectUsesInterviewTeams As Boolean
    Private mblnCaseAssignmentsAllowCopy As Boolean
    Private mblnShowInterviewerCaseCount As Boolean
    Private mblnShowTeamCaseCount As Boolean

    'BT: Added on 05/03/2013.
    Private ReadOnly mblnBlaiseRealTimeProcess As Boolean
    Private ReadOnly mstrBlaiseDatabase As String
    Private ReadOnly mintBlaiseInstrumentTypeID As Integer
    'BT: Added on 05/03/2013.

    Private ReadOnly mblnGeocode As Boolean
    Private ReadOnly mblnMelissaData As Boolean
    Private Shared mstrTcpaLookupUrl As String
    Private Shared mstrBulkLocatingExportFolder As String
    Private Shared mstrTowerDataImportFolder As String

    ' Project Connection Provider 
    Private ReadOnly mobjConnectionProvider As ConnectionProvider

    Private _urlShortenerApiKey As String

#End Region

#Region "Public Functions"

    Public Shared LastURLProcess As String = ""

    Public Shared Function GetInstance() As Project

        Return GetInstance(Nothing)
    End Function

    Public Shared Function GetInstance(AppSettings As NameValueCollection) As Project

        Try

            If HttpContext.Current Is Nothing Then
                If Instance Is Nothing Then
                    Dim MyProject As Project = New Project(AppSettings)
                End If
                Return Instance
            End If

            ' For web applications, return the project from current context

            If Not HttpContext.Current.Items.Contains("MyProject") Then
                Dim MyProject As Project = New Project(AppSettings)
            End If

            Return CType(HttpContext.Current.Items("MyProject"), Project)

        Catch ex As Exception

            Instance = Nothing

            If IsRuntime OrElse IsWebApplication Then
                Throw ex
            End If

            Return Nothing

        End Try
    End Function

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Creates a new instance of the Project class.
    ''' </summary>

    Private Sub New(objAppSettings As NameValueCollection)

        ' Set the shared instance as needed

        If Not IsWebApplication Then
            Instance = Me
        Else
            HttpContext.Current.Items.Add("MyProject", Me)
        End If

        If Not objAppSettings Is Nothing Then
            mobjAppSettings = objAppSettings
        Else
            mobjAppSettings = ConfigurationManager.AppSettings
        End If

        ' Initialize the configuration settings 

        mstrProjectName = mobjAppSettings("ProjectName")
        mstrProjectShortName = mobjAppSettings("ProjectShortName")

        'the settings below were moved into the database (tlkpSettings),
        'and are loaded at the end of this constructor.
        'mintCurrentRound = CType(mobjAppSettings("CurrentRound"), Integer)
        'mstrProjectCode = mobjAppSettings("ProjectCode")
        'mstrRPSTaskCode = mobjAppSettings("RPSTaskCode")


        mblnShowRound = CType(mobjAppSettings("ShowRound"), Boolean)
        mblnAllowShared = CType(mobjAppSettings("AllowShared"), Boolean)
        mblnLockLocCases = CType(mobjAppSettings("LockLocatingCasesUponSelection"), Boolean)

        mstrConnectionString = ConfigurationManager.ConnectionStrings("MPR.SMS").ToString

        'mblnHideReturnedMail = CType(mobjAppSettings("HideDocReceiptReturnedMail"), Boolean)

        mintErrorChecking = CType(mobjAppSettings("ErrorChecking"), Integer)
        mintDuplicatesChecking = CType(mobjAppSettings("DuplicatesChecking"), Integer)

        mblnAllowManyClassroomsPerTeacher = CType(mobjAppSettings("AllowManyClassroomsPerTeacher"), Boolean)
        mblnAllowManyTeachersPerClassroom = CType(mobjAppSettings("AllowManyTeachersPerClassroom"), Boolean)

        If mobjAppSettings("FieldAssignmentAssignBy") IsNot Nothing Then
            mintFieldAssignmentAssignBy = CType(mobjAppSettings("FieldAssignmentAssignBy"), Integer)
        Else
            mintFieldAssignmentAssignBy = 0
        End If

        'mintFieldAssignmentAssignBy = CType(mobjAppSettings("FieldAssignmentAssignBy"), Integer)
        'mblnProjectUsesInterviewTeams = CType(mobjAppSettings("ProjectUsesInterviewTeams"), Boolean)
        'mblnCaseAssignmentsAllowCopy = CType(mobjAppSettings("CaseAssignmentsAllowCopy"), Boolean)
        'mblnShowInterviewerCaseCount = CType(mobjAppSettings("ShowInterviewerCaseCount"), Boolean)
        'mblnShowTeamCaseCount = CType(mobjAppSettings("ShowTeamCaseCount"), Boolean)

        'BT: Added on 05/03/2013.
        mblnBlaiseRealTimeProcess = CType(mobjAppSettings("BlaiseRealTimeProcess"), Boolean)
        mstrBlaiseDatabase = CType(mobjAppSettings("BlaiseDatabase"), String)
        mintBlaiseInstrumentTypeID = CType(mobjAppSettings("BlaiseInstrumentTypeID"), Integer)
        'BT: Added on 05/03/2013.


        Dim IsTrustedConnection As Boolean = False

        Dim Keywords As String() = mstrConnectionString.Split(CChar(";"))

        For Each Keyword As String In Keywords
            If Keyword.ToLower().StartsWith("trusted_connection") Then
                IsTrustedConnection = True
            End If
        Next

        ' Initialize and the Connection Provider

        mobjConnectionProvider = New ConnectionProvider(mstrConnectionString)

        ' Force Project Collections initialization if needed
        ProjectCollections.GetInstance(Me)

        For Each objSetting As Setting In Me.Settings
            Select Case objSetting.Setting.ToString
                Case "CurrentRound"
                    mintCurrentRound = CType(objSetting.Value.ToSqlInt16, Integer)
                Case "ProjectCode"
                    mstrProjectCode = objSetting.Value.ToString
                Case "RPSTaskCode"
                    mstrRPSTaskCode = objSetting.Value.ToString
                Case "RPSBankAccount"
                    mstrRPSBankAccount = objSetting.Value.ToString
                Case "RPSModeOfPayment"
                    mstrRPSModeOfPayment = objSetting.Value.ToString
                Case "RPSProjectType"
                    mstrRPSProjectType = objSetting.Value.ToString
                Case "RPSServer"
                    mstrRPSServer = objSetting.Value.ToString
                Case "FMSiteAddress"
                    mstrFMSiteAddress = objSetting.Value.ToString
                Case "IsISMSProject"
                    mblnIsISMSProject = (CInt("0" + objSetting.Value) = 1)
                Case "IsGeoCodeEnabled"
                    mblnGeocode = (CInt("0" + objSetting.Value) = 1)
                Case "IsMelissaDataEnabled"
                    mblnMelissaData = (CInt("0" + objSetting.Value) = 1)
                Case "APIUser"
                    APIUser = objSetting.Value.ToString
                Case "APIPwd"
                    APIPwd = objSetting.Value.ToString
                Case "TCPALookupURL"
                    mstrTcpaLookupUrl = objSetting.Value.ToString
                Case "FMShowInterviewerCaseCount"
                    mblnShowInterviewerCaseCount = CType(objSetting.Value.ToString(), Boolean)
                Case "BulkLocatingExportFolder"
                    mstrBulkLocatingExportFolder = objSetting.Value.ToString()
                Case "UrlShortenerApiKey"
                    _urlShortenerApiKey = objSetting.Value.ToString
                Case "TowerDataImportFolder"
                    mstrTowerDataImportFolder = objSetting.Value.ToString()
            End Select
        Next

        'AF 11/08/12 Added new connection string for RPS so we can get around Linked Server issues with M030 / SQL_ISProd
        mstrRPSConnectionString = "Data Source=" & RPSServer &
                                  ";Initial Catalog=SEC__RespPayment;Trusted_Connection=true"
    End Sub

#End Region

#Region "Public Properties"

    Public Shared Property IsRuntime As Boolean
        Get
            Return _IsRuntime
        End Get
        Set
            _IsRuntime = Value
        End Set
    End Property

    Public Shared ReadOnly Property IsWebApplication As Boolean
        Get
            Return Not (HttpContext.Current Is Nothing)
        End Get
    End Property

    ''' <summary>
    '''     Gets the connection string that is used to access the Project's database.
    ''' </summary>
    ''' <value>
    '''     The connection string that is used to connect to the Project's database.
    ''' </value>
    ''' <remarks>
    '''     The connection string is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ConnectionString As String
        Get
            Return mstrConnectionString
        End Get
    End Property

    ''' <summary>
    '''     Gets the RPS Connection String that is used to access the RPS Database
    ''' </summary>
    ''' <value>
    '''     The RPS connection string that is used to connect to the RPS database.
    ''' </value>
    ''' <remarks>
    '''     The connection string is maintained in tlkpSettings.
    ''' </remarks>

    Public ReadOnly Property RPSConnectionString As String
        Get
            Return mstrRPSConnectionString
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.BaseClasses.ConnectionProvider">ConnectionProvider</see> for the project.
    ''' </summary>
    ''' <value>
    '''     The Project's Connection Provider
    ''' </value>
    ''' <remarks>
    '''     The Project's Connection Provider is used to minimize open database connections
    '''     and provides transaction support.
    ''' </remarks>

    Public ReadOnly Property ConnectionProvider As ConnectionProvider
        Get
            Return mobjConnectionProvider
        End Get
    End Property

    ''' <summary>
    '''     Gets the name of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's name.
    ''' </value>
    ''' <remarks>
    '''     The Project's name is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property Name As String
        Get
            Return mstrProjectName
        End Get
    End Property

    ''' <summary>
    '''     Gets the Short Name (usually the acronym) of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Short Name.
    ''' </value>
    ''' <remarks>
    '''     The Project's Short Name is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ShortName As String
        Get
            Return mstrProjectShortName
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Code of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Code.
    ''' </value>
    ''' <remarks>
    '''     The Project's Code is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ProjectCode As String
        Get
            Return mstrProjectCode
        End Get
    End Property

    ''' <summary>
    '''     Gets the Respondent Payment Task Code of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Task Code for RPS.
    ''' </value>
    ''' <remarks>
    '''     The Project's Respondent Payment Task Code is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property RPSTaskCode As String
        Get
            Return mstrRPSTaskCode
        End Get
    End Property

    ''' <summary>
    '''     Gets the Respondent Payment Bank Account of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Bank Account for RPS.
    ''' </value>
    ''' <remarks>
    '''     The Project's Respondent Payment Bank Account is maintained in the database Settings table.
    ''' </remarks>

    Public ReadOnly Property RPSBankAccount As String
        Get
            Return mstrRPSBankAccount
        End Get
    End Property

    ''' <summary>
    '''     Gets the Respondent Payment Mode Of Payment of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Mode Of Payment for RPS.
    ''' </value>
    ''' <remarks>
    '''     The Project's Respondent Payment Mode Of Payment is maintained in the database Settings table.
    ''' </remarks>

    Public ReadOnly Property RPSModeOfPayment As String
        Get
            Return mstrRPSModeOfPayment
        End Get
    End Property

    ''' <summary>
    '''     Gets the Respondent Payment Project Type of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Project Type for RPS.
    ''' </value>
    ''' <remarks>
    '''     The Project's Project Type is maintained in the database Settings table.
    ''' </remarks>

    Public ReadOnly Property RPSProjectType As String
        Get
            Return mstrRPSProjectType
        End Get
    End Property

    ''' <summary>
    '''     Gets the Respondent Payment Server location.
    ''' </summary>
    ''' <value>
    '''     The Server location for RPS.
    ''' </value>
    ''' <remarks>
    '''     The RPS Server is maintained in the database Settings table.
    ''' </remarks>

    Public ReadOnly Property RPSServer As String
        Get
            Return mstrRPSServer
        End Get
    End Property

    ''' <summary>
    '''     Gets the Field Management Website location.
    ''' </summary>
    ''' <value>
    '''     The Site location for FM.
    ''' </value>
    ''' <remarks>
    '''     The FM Site is maintained in the database Settings table.
    ''' </remarks>

    Public ReadOnly Property FMSiteAddress As String
        Get
            Return mstrFMSiteAddress
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Code of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Code.
    ''' </value>
    ''' <remarks>
    '''     The Project's Code is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property IsISMSProject As Boolean
        Get
            Return mblnIsISMSProject
        End Get
    End Property


    ''' <summary>
    '''     Gets the Current Round of the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Current Round.
    ''' </value>
    ''' <remarks>
    '''     The Project's Current Round is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property CurrentRound As Integer
        Get
            Return mintCurrentRound
        End Get
    End Property

    ''' <summary>
    '''     Determines if we should show the Round # for this Project.
    ''' </summary>
    ''' <value>
    '''     The Project's ShowRound setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's ShowRound Round is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ShowRound As Boolean
        Get
            Return mblnShowRound
        End Get
    End Property

    ''' <summary>
    '''     Determines if we should allow shared addresses/phones/emails for this Project.
    ''' </summary>
    ''' <value>
    '''     The Project's AllowShared setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's AllowShared is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property AllowShared As Boolean
        Get
            Return mblnAllowShared
        End Get
    End Property

    ''' <summary>
    '''     Determines if we should immediately lock locating cases as soon as they are selected
    '''     (otherwise, wait until a locating attempt is made.)
    ''' </summary>
    ''' <value>
    '''     The Project's LockLocatingCases setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's LockLocatingCases is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property LockLocatingCases As Boolean
        Get
            Return mblnLockLocCases
        End Get
    End Property

    '' '
    '' <summary>
    ''     ' Gets the HideDocReceiptReturnedMail flag.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's HideDocReceiptReturnedMail flag.
    ''     '
    '' </value>
    '' '
    '' <remarks>
    ''     ' True=Hide the Returned Mail pull-down box on frmBarCodeScan
    ''     ' False=Show the Returned Mail pull-down box on frmBarCodeScan (default)
    ''     '
    '' </remarks>
    '' <summary>
    ''     Gets the ErrorChecking level.
    '' </summary>
    '' <value>
    ''     The Project's ErrorChecking level.
    '' </value>
    '' <remarks>
    ''     0=No checking
    ''     1=Check Primary Sample Member(s) only
    ''     2=Check all Case Members
    '' </remarks>

    'Public ReadOnly Property HideDocReceiptReturnedMail() As Boolean
    '    Get
    '        Return mblnHideReturnedMail
    '    End Get
    'End Property


    Public ReadOnly Property ErrorChecking As CheckingType
        Get
            Return CType(mintErrorChecking, CheckingType)
        End Get
    End Property

    ''' <summary>
    '''     Gets the DuplicatesChecking level.
    ''' </summary>
    ''' <value>
    '''     The Project's DuplicatesChecking level.
    ''' </value>
    ''' <remarks>
    '''     0=No checking
    '''     1=Check Primary Sample Member(s) only
    '''     2=Check all Case Members
    ''' </remarks>

    Public ReadOnly Property DuplicatesChecking As CheckingType
        Get
            Return CType(mintDuplicatesChecking, CheckingType)
        End Get
    End Property

    ''' <summary>
    '''     Determines if we should allow multiple Classrooms per Teacher for this Project.
    ''' </summary>
    ''' <value>
    '''     The Project's AllowManyClassroomsPerTeacher setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's AllowManyClassroomsPerTeacher is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property AllowManyClassroomsPerTeacher As Boolean
        Get
            Return mblnAllowManyClassroomsPerTeacher
        End Get
    End Property

    ''' <summary>
    '''     Determines if we should allow multiple Teachers per Classroom for this Project.
    ''' </summary>
    ''' <value>
    '''     The Project's AllowManyTeachersPerClassroom setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's AllowManyTeachersPerClassroom is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property AllowManyTeachersPerClassroom As Boolean
        Get
            Return mblnAllowManyTeachersPerClassroom
        End Get
    End Property

    ''' <summary>
    '''     Gets the FieldAssignmentAssignBy setting.
    ''' </summary>
    ''' <value>
    '''     The Project's FieldAssignmentAssignBy setting.
    ''' </value>
    ''' <remarks>
    '''     0=Case (default)
    '''     1=Classroom
    '''     2=School
    '''     3=District
    '''     4=Site/Region, etc.
    ''' </remarks>

    Public ReadOnly Property FieldAssignmentAssignBy As FieldAssignmentAssignByType
        Get
            Return CType(mintFieldAssignmentAssignBy, FieldAssignmentAssignByType)
        End Get
    End Property

    ''' <summary>
    '''     Determines if the Field Management UI will show Interviewer Teams.
    ''' </summary>
    ''' <value>
    '''     The Project's ProjectUsesInterviewTeams setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's ProjectUsesInterviewTeams is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ProjectUsesInterviewTeams As Boolean
        Get
            Return mblnProjectUsesInterviewTeams
        End Get
    End Property

    ''' <summary>
    '''     Determines if the Field Management UI Copies assignments (versus Moving assignments).
    ''' </summary>
    ''' <value>
    '''     The Project's CaseAssignmentsAllowCopy setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's CaseAssignmentsAllowCopy is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property CaseAssignmentsAllowCopy As Boolean
        Get
            Return mblnCaseAssignmentsAllowCopy
        End Get
    End Property

    ''' <summary>
    '''     Determines if the Field Management UI will show the Interviewer's Active Case Counts.
    ''' </summary>
    ''' <value>
    '''     The Project's ShowInterviewerCaseCount setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's ShowInterviewerCaseCount is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ShowInterviewerCaseCount As Boolean
        Get
            Return mblnShowInterviewerCaseCount
        End Get
    End Property

    ''' <summary>
    '''     Determines if the Field Management UI will show the Team's Active Case Counts.
    ''' </summary>
    ''' <value>
    '''     The Project's ShowTeamCaseCount setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's ShowTeamCaseCount is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property ShowTeamCaseCount As Boolean
        Get
            Return mblnShowTeamCaseCount
        End Get
    End Property

    Public ReadOnly Property LaunchedFromUrl As Boolean

        Get
            Try
                Dim uri As New Uri(CType(AppDomain.CurrentDomain.GetData("APPBASE"), String))
                Return (uri.Scheme = uri.UriSchemeHttp) Or (uri.Scheme = uri.UriSchemeHttps)
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Title for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Title for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Title is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Title As String
        Get

            Dim objAssembly As Assembly = Assembly.GetEntryAssembly()

            Dim objTitle As AssemblyTitleAttribute =
                    CType(AssemblyTitleAttribute.GetCustomAttribute(objAssembly, GetType(AssemblyTitleAttribute)),
                          AssemblyTitleAttribute)

            Return objTitle.Title
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Description for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Description for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Description is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Description As String
        Get

            Dim objAssembly As [Assembly] = Assembly.GetEntryAssembly()

            Dim objDescription As AssemblyDescriptionAttribute =
                    CType(AssemblyDescriptionAttribute.GetCustomAttribute(objAssembly,
                                                                          GetType(AssemblyDescriptionAttribute)),
                          AssemblyDescriptionAttribute)

            Return objDescription.Description
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Company for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Company for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Company is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Company As String
        Get

            Dim objAssembly As [Assembly] = Assembly.GetEntryAssembly()

            Dim objCompany As AssemblyCompanyAttribute =
                    CType(AssemblyCompanyAttribute.GetCustomAttribute(objAssembly, GetType(AssemblyCompanyAttribute)),
                          AssemblyCompanyAttribute)

            Return objCompany.Company
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Product for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Product for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Product is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Product As String
        Get

            Dim objAssembly As [Assembly] = Assembly.GetEntryAssembly()

            Dim objProduct As AssemblyProductAttribute =
                    CType(AssemblyProductAttribute.GetCustomAttribute(objAssembly, GetType(AssemblyProductAttribute)),
                          AssemblyProductAttribute)

            Return objProduct.Product
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Copyright for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Copyright for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Copyright is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Copyright As String
        Get

            Dim objAssembly As [Assembly] = Assembly.GetEntryAssembly()

            Dim objCopyright As AssemblyCopyrightAttribute =
                    CType(AssemblyCopyrightAttribute.GetCustomAttribute(objAssembly, GetType(AssemblyCopyrightAttribute)),
                          AssemblyCopyrightAttribute)

            Return objCopyright.Copyright
        End Get
    End Property

    ''' <summary>
    '''     Gets the Project Trademark for the executing assembly.
    ''' </summary>
    ''' <value>
    '''     The Project Trademark for the executing assembly.
    ''' </value>
    ''' <remarks>
    '''     The Project Trademark is retrieved from the AssemblyInfo for the executing Assembly.
    ''' </remarks>

    Public ReadOnly Property Trademark As String
        Get

            Dim objAssembly As [Assembly] = Assembly.GetEntryAssembly()

            Dim objTrademark As AssemblyTrademarkAttribute =
                    CType(AssemblyTrademarkAttribute.GetCustomAttribute(objAssembly, GetType(AssemblyTrademarkAttribute)),
                          AssemblyTrademarkAttribute)

            Return objTrademark.Trademark
        End Get
    End Property

    'BT: Added on 05/03/2013.

    ''' <summary>
    '''     Determines if the SMS to Bliase real time process need to implement.
    ''' </summary>
    ''' <value>
    '''     The Project's BlaiseRealTimeProcess setting.
    ''' </value>
    ''' <remarks>
    '''     The Project's BlaiseRealTimeProcess is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property BlaiseRealTimeProcess As Boolean
        Get
            Return mblnBlaiseRealTimeProcess
        End Get
    End Property

    ''' <summary>
    '''     Gets the Blaise Database Full Path string that is used to access the Blaise database.
    ''' </summary>
    ''' <value>
    '''     The Blaise Database Full Path string that is used to connect to the Blaise database.
    ''' </value>
    ''' <remarks>
    '''     The Blaise Database Full Path string is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property BlaiseDatabase As String
        Get
            Return mstrBlaiseDatabase
        End Get
    End Property

    ''' <summary>
    '''     Gets the Blaise Instrument Type ID to update Blaise database.
    ''' </summary>
    ''' <value>
    '''     The BlaiseInstrumentTypeID is used to update Blaise database.
    ''' </value>
    ''' <remarks>
    '''     The BlaiseInstrumentTypeID is maintained in the application configuration file.
    ''' </remarks>

    Public ReadOnly Property BlaiseInstrumentTypeID As Integer
        Get
            Return mintBlaiseInstrumentTypeID
        End Get
    End Property

    'BT: Added on 05/03/2013.

    Public ReadOnly Property ServerName As String
        Get
            Return mobjConnectionProvider.Connection.DataSource
        End Get
    End Property

    Public ReadOnly Property Database As String
        Get
            Return mobjConnectionProvider.Connection.Database
        End Get
    End Property

    Public ReadOnly Property Server As String
        Get
            Return mobjConnectionProvider.Connection.DataSource
        End Get
    End Property

    Public ReadOnly Property GeoCode As Boolean
        Get
            Return mblnGeocode
        End Get
    End Property

    Public ReadOnly Property MelissaDataEnabled As Boolean
        Get
            If mblnMelissaData = False Then
                MsgBox("MelissaData data cleaning is not enabled. Please contact your SMS programmer")
            End If
            Return mblnMelissaData
        End Get
    End Property

    Public Shared ReadOnly Property TcpaLookupUrl As String
        Get
            Return mstrTcpaLookupUrl
        End Get
    End Property

    Public Shared ReadOnly Property BulkLocatingExportFolder As String
        Get
            Return mstrBulkLocatingExportFolder
        End Get
    End Property

    Public Shared ReadOnly Property TowerDataImportFolder As String
        Get
            Return mstrTowerDataImportFolder
        End Get
    End Property

    Public Property APIUser As String
    Public Property APIPwd As String


    Public ReadOnly Property UrlShortenerApiKey() As String
        Get
            Return _urlShortenerApiKey
        End Get
    End Property

#End Region

#Region "Public Properties - Project Collections"

    '' '
    '' <summary>
    ''     ' Gets the <see cref="T:MPR.SMS.Data.Sites">Sites</see> collection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's Sites collection.
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' Gets the Assignment collection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's Assignments collection.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the <see cref="T:MPR.SMS.Data.Statuses">Statuses</see> colection for the Project.
    '' </summary>
    '' <value>
    ''     The Project's Statuses collection.
    '' </value>

    'Public ReadOnly Property Sites() As Sites
    '    Get
    '        Return ProjectCollections.GetInstance(Me).Sites
    '    End Get
    'End Property

    'Public ReadOnly Property Assignments() As Assignments
    '    Get
    '        Return ProjectCollections.GetInstance(Me).Assignments
    '    End Get
    'End Property


    Public ReadOnly Property Statuses As Statuses
        Get
            Return ProjectCollections.GetInstance(Me).Statuses
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.MobilityCodes">MobilityCodes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's MobilityCodes collection.
    ''' </value>

    Public ReadOnly Property MobilityCodes As MobilityCodes
        Get
            Return ProjectCollections.GetInstance(Me).MobilityCodes
        End Get
    End Property

    '' '
    '' <summary>
    ''     ' Gets the StrataTable colection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's StrataTable collection.
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' Gets the StratificationCodes colection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's StratificationCodes collection.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the <see cref="T:MPR.SMS.Data.DocumentTypes">DocumentTypes</see> collection for the Project.
    '' </summary>
    '' <value>
    ''     The Project's DocumentTypes collection.
    '' </value>

    'Public ReadOnly Property StrataTable() As StrataTable
    '    Get
    '        Return ProjectCollections.GetInstance(Me).StrataTable
    '    End Get
    'End Property

    'Public ReadOnly Property StratificationCodes() As StratificationCodes
    '    Get
    '        Return ProjectCollections.GetInstance(Me).StratificationCodes
    '    End Get
    'End Property


    Public ReadOnly Property DocumentTypes As DocumentTypes
        Get
            Return ProjectCollections.GetInstance(Me).DocumentTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.DocumentOutputTypes">DocumentOutputTypes</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's DocumentOutputTypes collection.
    ''' </value>

    Public ReadOnly Property DocumentOutputTypes As DocumentOutputTypes
        Get
            Return ProjectCollections.GetInstance(Me).DocumentOutputTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.DocumentStatuses">DocumentStatuses</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's DocumentTypes collection.
    ''' </value>

    Public ReadOnly Property DocumentStatuses As DocumentStatuses
        Get
            Return ProjectCollections.GetInstance(Me).DocumentStatuses
        End Get
    End Property

    ''' <summary>
    '''     Gets the DocumentGroups collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's DocumentGroups collection.
    ''' </value>

    Public ReadOnly Property DocumentGroups As DocumentGroups
        Get
            Return ProjectCollections.GetInstance(Me).DocumentGroups
        End Get
    End Property

    '' '
    '' <summary>
    ''     ' Gets the Grantees collection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's Grantees collection.
    ''     '
    '' </value>
    '' '
    '' <summary>
    ''     ' Gets the <see cref="T:MPR.SMS.Data.Districts">Districts</see> collection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's Districts collection.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the <see cref="T:MPR.SMS.Data.DataImports">DataImports</see> collection for the Project.
    '' </summary>
    '' <value>
    ''     The Project's DataImports collection.
    '' </value>

    'Public ReadOnly Property Grantees() As Grantees
    '    Get
    '        Return ProjectCollections.GetInstance(Me).Grantees
    '    End Get
    'End Property

    'Public ReadOnly Property Districts() As Districts
    '    Get
    '        Return ProjectCollections.GetInstance(Me).Districts
    '    End Get
    'End Property


    Public ReadOnly Property DataImports As DataImports
        Get
            Return ProjectCollections.GetInstance(Me).DataImports
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Settings">Settings</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's Settings collection.
    ''' </value>

    Public ReadOnly Property Settings As Settings
        Get
            Return ProjectCollections.GetInstance(Me).Settings
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.RaceTypes">RaceTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's RaceTypes collection.
    ''' </value>

    Public ReadOnly Property RaceTypes As RaceTypes
        Get
            Return ProjectCollections.GetInstance(Me).RaceTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.EntityTypes">EntityTypes</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's EntityTypes collection.
    ''' </value>

    Public ReadOnly Property EntityTypes As EntityTypes
        Get
            Return ProjectCollections.GetInstance(Me).EntityTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.InstrumentTypes">InstrumentTypes</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's InstrumentTypes collection.
    ''' </value>

    Public ReadOnly Property InstrumentTypes As InstrumentTypes
        Get
            Return ProjectCollections.GetInstance(Me).InstrumentTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.RelationshipTypes">RelationshipTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's RelationshipTypes collection.
    ''' </value>

    Public ReadOnly Property RelationshipTypes As RelationshipTypes
        Get
            Return ProjectCollections.GetInstance(Me).RelationshipTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.LanguageTypes">LanguageTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's LanguageTypes collection.
    ''' </value>

    Public ReadOnly Property LanguageTypes As LanguageTypes
        Get
            Return ProjectCollections.GetInstance(Me).LanguageTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the LocatedPhoneSettings colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's LocatedPhoneSettingss collection.
    ''' </value>

    Public ReadOnly Property LocatedPhoneSettings As LocatedPhoneSettings
        Get
            Return ProjectCollections.GetInstance(Me).LocatedPhoneSettings
        End Get
    End Property

    ''' <summary>
    '''     Gets the TimeZoneCodess colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's TimeZoneCodess collection.
    ''' </value>

    Public ReadOnly Property TimeZoneCodes As TimeZoneCodes
        Get
            Return ProjectCollections.GetInstance(Me).TimeZoneCodes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.AssignmentTypes">AssignmentTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's AssignmentTypes collection.
    ''' </value>

    Public ReadOnly Property AssignmentTypes As AssignmentTypes
        Get
            Return ProjectCollections.GetInstance(Me).AssignmentTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.ConsentTypes">ConsentTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's ConsentTypes collection.
    ''' </value>

    Public ReadOnly Property ConsentTypes As ConsentTypes
        Get
            Return ProjectCollections.GetInstance(Me).ConsentTypes
        End Get
    End Property

    '' '
    '' <summary>
    ''     ' Gets the AddressReviewStatuses colection for the Project.
    ''     '
    '' </summary>
    '' '
    '' <value>
    ''     ' The Project's AddressReviewStatuses collection.
    ''     '
    '' </value>
    '' <summary>
    ''     Gets the <see cref="T:MPR.SMS.Data.AddressTypes">AddressTypes</see> colection for the Project.
    '' </summary>
    '' <value>
    ''     The Project's AddressTypes collection.
    '' </value>

    'Public ReadOnly Property AddressReviewStatuses() As AddressReviewStatuses
    '    Get
    '        Return ProjectCollections.GetInstance(Me).AddressReviewStatuses
    '    End Get
    'End Property


    Public ReadOnly Property AddressTypes As AddressTypes
        Get
            Return ProjectCollections.GetInstance(Me).AddressTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.PhoneTimes">PhoneTimes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's PhoneTimes collection.
    ''' </value>

    Public ReadOnly Property PhoneTimes As PhoneTimes
        Get
            Return ProjectCollections.GetInstance(Me).PhoneTimes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.PhoneTypes">PhoneTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's PhoneTypes collection.
    ''' </value>

    Public ReadOnly Property PhoneTypes As PhoneTypes
        Get
            Return ProjectCollections.GetInstance(Me).PhoneTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.EmailTypes">EmailTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's EmailTypes collection.
    ''' </value>

    Public ReadOnly Property EmailTypes As EmailTypes
        Get
            Return ProjectCollections.GetInstance(Me).EmailTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.NoteTypes">NoteTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's NoteTypes collection.
    ''' </value>

    Public ReadOnly Property NoteTypes As NoteTypes
        Get
            Return ProjectCollections.GetInstance(Me).NoteTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.ReturnedMailReasons">ReturnedMailReasons</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's ReturnedMailReasons collection.
    ''' </value>

    Public ReadOnly Property ReturnedMailReasons As ReturnedMailReasons
        Get
            Return ProjectCollections.GetInstance(Me).ReturnedMailReasons
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SourceQualities">SourceQualities</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's SourceQualities collection.
    ''' </value>

    Public ReadOnly Property SourceQualities As SourceQualities
        Get
            Return ProjectCollections.GetInstance(Me).SourceQualities
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SourceTypes">SourceTypes</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's SourceTypes collection.
    ''' </value>

    Public ReadOnly Property SourceTypes As SourceTypes
        Get
            Return ProjectCollections.GetInstance(Me).SourceTypes
        End Get
    End Property


    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingAttemptResults">LocatingAttemptResults</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's LocatingAttemptResults collection.
    ''' </value>

    Public ReadOnly Property LocatingAttemptResults As LocatingAttemptResults
        Get
            Return ProjectCollections.GetInstance(Me).LocatingAttemptResults
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.LocatingAttemptTypes">LocatingAttemptTypes</see> colection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's LocatingAttemptTypes collection.
    ''' </value>

    Public ReadOnly Property LocatingAttemptTypes As LocatingAttemptTypes
        Get
            Return ProjectCollections.GetInstance(Me).LocatingAttemptTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetworkTypes">SocialNetworkType</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's SocialNetworkTypes collection.
    ''' </value>

    Public ReadOnly Property SocialNetworkTypes As SocialNetworkTypes
        Get
            Return ProjectCollections.GetInstance(Me).SocialNetworkTypes
        End Get
    End Property

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.SocialNetworkTypes">SocialNetworkType</see> collection for the Project.
    ''' </summary>
    ''' <value>
    '''     The Project's SocialNetworkTypes collection.
    ''' </value>

    Public ReadOnly Property SocialNetworkStatuses As SocialNetworkStatuses
        Get
            Return ProjectCollections.GetInstance(Me).SocialNetworkStatuses
        End Get
    End Property

#End Region

#Region "Public Methods"

    Public Function OpenConnection() As Boolean

        If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider.OpenConnection()
        End If

        Return ConnectionProvider.Connection.State = ConnectionState.Open
    End Function

    Public Sub CloseConnection()

        If ConnectionProvider.Connection.State = ConnectionState.Open Then
            ConnectionProvider.CloseConnection(False)
        End If
    End Sub

    ''' <summary>
    '''     Generates a unique Person MPRID.
    ''' </summary>
    ''' <returns>
    '''     The uniquely generated MPRID.
    ''' </returns>

    Friend Function GenerateMPRID() As String

        Dim strMPRID As String = ""

        Dim conn As SqlConnection

        If ConnectionProvider.Connection.State = ConnectionState.Open And Not ConnectionProvider.IsTransactionPending _
            Then
            conn = ConnectionProvider.Connection
        Else
            conn = New SqlConnection(ConnectionString)
            conn.Open()
        End If

        Try
            Dim strSQL As String
            Dim intLastID As Long
            Dim strLastID As String
            Dim strNextID As String
            Dim intDigit(10) As Double
            Dim intCheckDigit As Double


            strSQL = "Select MAX(MPRID) from tblPerson"

            Dim cmd As New SqlCommand

            With cmd
                .Connection = conn
                .CommandText = strSQL
                .CommandType = CommandType.Text
            End With


            Dim objLastID As Object = cmd.ExecuteScalar

            If Not objLastID.GetType().FullName = "System.DBNull" Then
                strLastID = objLastID.ToString
            Else
                strLastID = "10000000"
            End If

            intLastID = CLng(strLastID.Substring(0, strLastID.Length - 1))  'remove the check digit
            intLastID = intLastID + 1 'increment the root iD by one
            strNextID = Trim(Str(intLastID)) 'convert it to string

            '  Calculate Check Digit

            intDigit(1) = (Math.Truncate(intLastID / 1000000) Mod 10) * 7
            intDigit(2) = (Math.Truncate(intLastID / 100000) Mod 10) * 1
            intDigit(3) = (Math.Truncate(intLastID / 10000) Mod 10) * 3
            intDigit(4) = (Math.Truncate(intLastID / 1000) Mod 10) * 7
            intDigit(5) = (Math.Truncate(intLastID / 100) Mod 10) * 1
            intDigit(6) = (Math.Truncate(intLastID / 10) Mod 10) * 3
            intDigit(7) = Math.Truncate((intLastID Mod 10) * 7)

            intCheckDigit = 10 - ((intDigit(1) + intDigit(2) + intDigit(3) _
                                   + intDigit(4) + intDigit(5) + intDigit(6) _
                                   + intDigit(7)) Mod 10)

            If intCheckDigit = 10 Then
                intCheckDigit = 0
            End If

            strMPRID = strNextID & Trim(Str(intCheckDigit))


        Catch ex As Exception

        Finally

            If Not ConnectionProvider.Connection.State = ConnectionState.Open Then
                If conn.State = ConnectionState.Open Then
                    conn.Close()
                End If
            End If

        End Try

        Return strMPRID
    End Function


    Public Function CheckDigitIsValid(strMPRID As String) As Boolean

        Dim intDigit(10) As Double
        Dim intCheckDigit As Double
        Dim strNewCheckDigit As String

        Dim strOldCheckDigit As String = Right(strMPRID, 1)
        Dim intLastID As Double = CLng(strMPRID.Substring(0, strMPRID.Length - 1))  'remove the check digit

        '   Calculate Check Digit

        '  Calculate and add Check Digit

        intDigit(1) = (Math.Truncate(intLastID / 1000000) Mod 10) * 7
        intDigit(2) = (Math.Truncate(intLastID / 100000) Mod 10) * 1
        intDigit(3) = (Math.Truncate(intLastID / 10000) Mod 10) * 3
        intDigit(4) = (Math.Truncate(intLastID / 1000) Mod 10) * 7
        intDigit(5) = (Math.Truncate(intLastID / 100) Mod 10) * 1
        intDigit(6) = (Math.Truncate(intLastID / 10) Mod 10) * 3
        intDigit(7) = Math.Truncate((intLastID Mod 10) * 7)

        intCheckDigit = 10 - ((intDigit(1) + intDigit(2) + intDigit(3) _
                               + intDigit(4) + intDigit(5) + intDigit(6) _
                               + intDigit(7)) Mod 10)


        If intCheckDigit = 10 Then
            intCheckDigit = 0
        End If

        strNewCheckDigit = Trim(Str(intCheckDigit))
        If strOldCheckDigit = strNewCheckDigit Then
            Return True
        Else
            Return False
        End If
    End Function


#End Region
End Class

