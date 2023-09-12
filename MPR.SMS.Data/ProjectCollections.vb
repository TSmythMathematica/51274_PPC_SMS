'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Class ProjectCollections

#Region "Shared (i.e. static) fields and properties"

    Private Shared ReadOnly MyLock As New Object

    Private Shared Instance As ProjectCollections = Nothing

    Public Shared Function GetInstance(Project As Project) As ProjectCollections

        SyncLock MyLock

            Try

                If Instance Is Nothing Then
                    Instance = New ProjectCollections(Project)
                    Instance.Refresh()
                End If

            Catch ex As Exception

                ' Clear the shared reference

                Instance = Nothing

                If Project.IsRuntime OrElse Project.IsWebApplication Then
                    Throw ex
                End If

            End Try

            Return Instance

        End SyncLock
    End Function

#End Region

#Region "Constructors"

    ' For singleton object, constructors should be private to insure only a single instance exists

    Private Sub New()
    End Sub

    Private Sub New(Project As Project)

        _Project = Project
    End Sub

#End Region

#Region "Private fields"

    Private ReadOnly _Project As Project

    'Private _Sites As Sites
    'Private _Districts As Districts
    'Private _Grantees As Grantees

    'Private _Roles As Roles

    'Private _Errors As Errors
    'Private _Duplicates As Duplicates

    Private _Statuses As Statuses
    Private _MobilityCodes As MobilityCodes

    'Private _StrataTable As StrataTable
    'Private _StratificationCodes As StratificationCodes

    Private _DocumentTypes As DocumentTypes
    Private _DocumentOutputTypes As DocumentOutputTypes
    Private _DocumentStatuses As DocumentStatuses
    Private _DocumentGroups As DocumentGroups

    Private _DataImports As DataImports
    Private _Settings As Settings

    Private _RaceTypes As RaceTypes

    Private _RelationshipTypes As RelationshipTypes

    Private _LanguageTypes As LanguageTypes
    Private _LocatedPhoneSettings As LocatedPhoneSettings
    Private _TimeZoneCodes As TimeZoneCodes

    Private _AssignmentTypes As AssignmentTypes
    Private _ConsentTypes As ConsentTypes

    'Private _AddressReviewStatuses As AddressReviewStatuses
    'Private _AddressReviewTypes As AddressReviewTypes

    Private _AddressTypes As AddressTypes
    Private _PhoneTypes As PhoneTypes
    Private _PhoneTimes As PhoneTimes
    Private _EmailTypes As EmailTypes
    Private _NoteTypes As NoteTypes

    Private _ReturnedMailReasons As ReturnedMailReasons

    Private _SourceQualities As SourceQualities
    Private _SourceTypes As SourceTypes
    Private _SocialNetworkTypes As SocialNetworkTypes
    Private _SocialNetworkStatuses As SocialNetworkStatuses

    'Private _SampleDropoutReasons As SampleDropoutReasons

    'Private _Assignments As Assignments

    Private _EntityTypes As EntityTypes

    Private _InstrumentTypes As InstrumentTypes

    Private _LocatingAttemptTypes As LocatingAttemptTypes
    Private _LocatingAttemptResults As LocatingAttemptResults

    'Private _Users As Users

#End Region

#Region "Read Only Properties"

    Public ReadOnly Property Project As Project

        Get
            Return _Project
        End Get
    End Property

    'Public ReadOnly Property Sites() As Sites
    '    Get
    '        Return _Sites
    '    End Get
    'End Property

    'Public ReadOnly Property Districts() As Districts
    '    Get
    '        Return _Districts
    '    End Get
    'End Property

    'Public ReadOnly Property Grantees() As Grantees
    '    Get
    '        Return _Grantees
    '    End Get
    'End Property

    ''Public ReadOnly Property Schools() As Schools
    ''    Get
    ''        Return _Schools
    ''    End Get
    ''End Property

    ''Public ReadOnly Property Classrooms() As Classrooms
    ''    Get
    ''        Return _ClassRooms
    ''    End Get
    ''End Property

    ''Public ReadOnly Property Teachers() As Teachers
    ''    Get
    ''        Return _Teachers
    ''    End Get
    ''End Property

    'Public ReadOnly Property Roles() As Roles
    '    Get
    '        Return _Roles
    '    End Get
    'End Property

    'Public ReadOnly Property Errors() As Errors
    '    Get
    '        Return _Errors
    '    End Get
    'End Property

    'Public ReadOnly Property Duplicates() As Duplicates
    '    Get
    '        Return _Duplicates
    '    End Get
    'End Property

    Public ReadOnly Property Statuses As Statuses
        Get
            Return _Statuses
        End Get
    End Property

    Public ReadOnly Property MobilityCodes As MobilityCodes
        Get
            Return _MobilityCodes
        End Get
    End Property

    'Public ReadOnly Property StrataTable() As StrataTable
    '    Get
    '        Return _StrataTable
    '    End Get
    'End Property

    'Public ReadOnly Property StratificationCodes() As StratificationCodes
    '    Get
    '        Return _StratificationCodes
    '    End Get
    'End Property

    Public ReadOnly Property DocumentGroups As DocumentGroups
        Get
            Return _DocumentGroups
        End Get
    End Property

    Public ReadOnly Property DocumentOutputTypes As DocumentOutputTypes
        Get
            Return _DocumentOutputTypes
        End Get
    End Property

    Public ReadOnly Property DocumentTypes As DocumentTypes
        Get
            Return _DocumentTypes
        End Get
    End Property

    Public ReadOnly Property DocumentStatuses As DocumentStatuses
        Get
            Return _DocumentStatuses
        End Get
    End Property

    Public ReadOnly Property DataImports As DataImports
        Get
            Return _DataImports
        End Get
    End Property

    Public ReadOnly Property Settings As Settings
        Get
            Return _Settings
        End Get
    End Property

    Public ReadOnly Property RaceTypes As RaceTypes
        Get
            Return _RaceTypes
        End Get
    End Property

    Public ReadOnly Property RelationshipTypes As RelationshipTypes
        Get
            Return _RelationshipTypes
        End Get
    End Property

    Public ReadOnly Property LanguageTypes As LanguageTypes
        Get
            Return _LanguageTypes
        End Get
    End Property

    Public ReadOnly Property LocatedPhoneSettings As LocatedPhoneSettings
        Get
            If _LocatedPhoneSettings Is Nothing Then
                _LocatedPhoneSettings = New LocatedPhoneSettings
            End If
            Return _LocatedPhoneSettings
        End Get
    End Property

    Public ReadOnly Property TimeZoneCodes As TimeZoneCodes
        Get
            If _TimeZoneCodes Is Nothing Then
                _TimeZoneCodes = New TimeZoneCodes
            End If
            Return _TimeZoneCodes
        End Get
    End Property

    Public ReadOnly Property AssignmentTypes As AssignmentTypes
        Get
            Return _AssignmentTypes
        End Get
    End Property

    Public ReadOnly Property ConsentTypes As ConsentTypes
        Get
            Return _ConsentTypes
        End Get
    End Property

    'Public ReadOnly Property AddressReviewStatuses() As AddressReviewStatuses
    '    Get
    '        Return _AddressReviewStatuses
    '    End Get
    'End Property

    'Public ReadOnly Property AddressReviewTypes() As AddressReviewTypes
    '    Get
    '        Return _AddressReviewTypes
    '    End Get
    'End Property

    Public ReadOnly Property AddressTypes As AddressTypes
        Get
            Return _AddressTypes
        End Get
    End Property

    Public ReadOnly Property PhoneTypes As PhoneTypes
        Get
            Return _PhoneTypes
        End Get
    End Property

    Public ReadOnly Property PhoneTimes As PhoneTimes
        Get
            Return _PhoneTimes
        End Get
    End Property

    Public ReadOnly Property EmailTypes As EmailTypes
        Get
            Return _EmailTypes
        End Get
    End Property

    Public ReadOnly Property NoteTypes As NoteTypes
        Get
            Return _NoteTypes
        End Get
    End Property

    Public ReadOnly Property ReturnedMailReasons As ReturnedMailReasons
        Get
            Return _ReturnedMailReasons
        End Get
    End Property

    Public ReadOnly Property SourceQualities As SourceQualities
        Get
            Return _SourceQualities
        End Get
    End Property

    Public ReadOnly Property SourceTypes As SourceTypes
        Get
            Return _SourceTypes
        End Get
    End Property

    Public ReadOnly Property SocialNetworkTypes As SocialNetworkTypes
        Get
            Return _SocialNetworkTypes
        End Get
    End Property

    Public ReadOnly Property SocialNetworkStatuses As SocialNetworkStatuses
        Get
            Return _SocialNetworkStatuses
        End Get
    End Property

    'Public ReadOnly Property SampleDropoutReasons() As SampleDropoutReasons
    '    Get
    '        If _SampleDropoutReasons Is Nothing Then
    '            If Project.OpenConnection() Then
    '                ' Create the SampleDropoutReasons collection
    '                _SampleDropoutReasons = New SampleDropoutReasons
    '                Project.CloseConnection()
    '            Else
    '                ' Open the Connection Provider  
    '                Project.ConnectionProvider.OpenConnection()
    '                ' Create the SampleDropoutReasons collection
    '                _SampleDropoutReasons = New SampleDropoutReasons
    '                ' Close the Connection Provider
    '                Project.ConnectionProvider.CloseConnection(False)
    '            End If
    '        End If
    '        Return _SampleDropoutReasons
    '    End Get
    'End Property

    'Public ReadOnly Property Assignments() As Assignments
    '    Get
    '        Return _Assignments
    '    End Get
    'End Property

    Public ReadOnly Property EntityTypes As EntityTypes
        Get
            Return _EntityTypes
        End Get
    End Property

    Public ReadOnly Property InstrumentTypes As InstrumentTypes
        Get
            Return _InstrumentTypes
        End Get
    End Property

    Public ReadOnly Property LocatingAttemptTypes As LocatingAttemptTypes
        Get
            Return _LocatingAttemptTypes
        End Get
    End Property

    Public ReadOnly Property LocatingAttemptResults As LocatingAttemptResults
        Get
            Return _LocatingAttemptResults
        End Get
    End Property

    'Public ReadOnly Property Users() As Users
    '    Get
    '        If _Users Is Nothing Then
    '            ' Open the Connection Provider  
    '            Project.ConnectionProvider.OpenConnection()
    '            ' Create the Users collection
    '            _Users = New Users
    '            ' Close the Connection Provider
    '            Project.ConnectionProvider.CloseConnection(False)
    '        End If
    '        Return _Users
    '    End Get
    'End Property

#End Region

    Friend Sub Refresh()

        Try

            Project.ConnectionProvider.OpenConnection()

            '' Initialize the Districts collection
            '_Districts = New Districts

            '' Initialize the Grantees collection
            '_Grantees = New Grantees

            '' Initialize the Sites collection
            '_Sites = New Sites

            '' Initialize the Schools Collection
            ''_Schools = New Schools

            '' Initialize the Teachers collection
            ''_Teachers = New Teachers

            '' Initialize the Classrooms collection
            ''_ClassRooms = New Classrooms

            '' Initialize the Errors collection
            '_Errors = New Errors

            '' Initialize the Roles collection
            '_Roles = New Roles

            '' Initialize the Duplicates collection
            '_Duplicates = New Duplicates

            ' Initialize the Statuses collection
            _Statuses = New Statuses

            ' Initialize the MobilityCodes collection
            _MobilityCodes = New MobilityCodes

            '' Initialize the StrataTable collection
            '_StrataTable = New StrataTable

            '' Initialize the StratificationCodes collection
            '_StratificationCodes = New StratificationCodes

            ' Initialize the DocumentGroups collection
            _DocumentGroups = New DocumentGroups

            ' Initialize the DocumentGroups collection
            _DocumentOutputTypes = New DocumentOutputTypes

            ' Initialize the DocumentTypes collection
            _DocumentTypes = New DocumentTypes

            ' Initialize the DocumentStatuses collection
            _DocumentStatuses = New DocumentStatuses

            ' Initialize the Imports collection
            _DataImports = New DataImports

            ' Initialize the Settings collection
            _Settings = New Settings

            ' Initialize the RaceTypes collection
            _RaceTypes = New RaceTypes

            ' Initialize the RelationshipTypes collection
            _RelationshipTypes = New RelationshipTypes

            ' Initialize the LanguageTypes collection
            _LanguageTypes = New LanguageTypes

            ' Initialize the AssignmentTypes collection
            _AssignmentTypes = New AssignmentTypes

            ' Initialize the ConsentTypes collection
            _ConsentTypes = New ConsentTypes

            '' Initialize the AddressReviewStatuses collection
            '_AddressReviewStatuses = New AddressReviewStatuses

            '' Initialize the AddressReviewTypes collection
            '_AddressReviewTypes = New AddressReviewTypes

            ' Initialize the AddressTypes collection
            _AddressTypes = New AddressTypes

            ' Initialize the PhoneTimes collection
            _PhoneTimes = New PhoneTimes

            ' Initialize the PhoneTypes collection
            _PhoneTypes = New PhoneTypes

            ' Initialize the EmailTypes collection
            _EmailTypes = New EmailTypes

            ' Initialize the NoteTypes collection
            _NoteTypes = New NoteTypes

            ' Initialize the SocialNetworkTypes collection
            _SocialNetworkTypes = New SocialNetworkTypes

            ' Initialize the SocialNetworkStatuses collection
            _SocialNetworkStatuses = New SocialNetworkStatuses

            ' Initialize the ReturnedMailReasons collection
            _ReturnedMailReasons = New ReturnedMailReasons

            ' Initialize the SourceQualities collection
            _SourceQualities = New SourceQualities

            ' Initialize the SourceTypes collection
            _SourceTypes = New SourceTypes

            '' Initialize the SampleDropoutReasons collection
            '_SampleDropoutReasons = New SampleDropoutReasons

            '' Initialize the Assignments Collection
            '_Assignments = New Assignments

            ' Initialize the EntityTypes Collection
            _EntityTypes = New EntityTypes

            ' Initialize the InstrumentTypes Collection
            _InstrumentTypes = New InstrumentTypes

            ' Initialize the LocatingAttemptTypes collection
            _LocatingAttemptTypes = New LocatingAttemptTypes

            ' Initialize the LocatingAttemptResults collection
            _LocatingAttemptResults = New LocatingAttemptResults

        Catch ex As Exception

            ' Terminate with extreme prejudice

            Throw ex

        Finally

            ' Insure the connection provider is always closed

            Project.ConnectionProvider.CloseConnection(False)

        End Try
    End Sub
End Class
