'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

Public Class Enumerations
    Public Enum tlkpEntityType
        None = 0
        SampleMember = 1
        Site = 2
        Teacher = 3
        Grantee = 4
        District = 5
        School = 6
        Classroom = 7
        Student = 8
    End Enum

    Public Enum LocatingAttemptResult
        NoNewInfo = 0
        NewAddress = 1
        NewPhone = 2
        NewEmail = 3
        PhoneVerified = 4
        DocumentSent = 5
        RespondentChanged = 6
    End Enum

    Public Enum DocumentStatus
        Queued = 1
        Sent
        Received
        Held
        ForwardingAddress
        NotDeliverable
        MovedBoxClosed
        Vacant
        TemporarilyAway
        NoMailReceptacle
        Refused
        PostageDue
    End Enum

    Public Enum DocumentStatusType
        ForwardingAddressProvided = 1
        NoForwardingAddressProvided
        PostageDue
    End Enum

    ' This maps directly to tlkpBatchType.BatchTypeID
    Public Enum BatchType As Integer
        QC = 1
        DE = 2
        Final = 3
        TimeStamp = 4
        QCDVD = 5
        SupReviewDVD = 6
        CodeDVD = 7
        ReassignDVD = 8
    End Enum

    Public Enum VideoInstrumentType As Integer
        TwoBags = 49
        ECI = 50
        Picillo = 51
    End Enum

    Public Enum ReleationshipType As Integer
        Other
        PrimarySampleMember
        ParentGuardian
        Proxy
        OtherContact
        Mother
        Father
        OtherGuardian
        Grandmother
        Grandfather
        Spouse
        GroupHome
    End Enum

    Public Enum SourceQuality As Integer
        Unknown = 0
        Bad
        ConfirmedGood
        Duplicate
    End Enum

    Public Enum SourceType As Integer
        Unknown = 0
        OriginalSample
        Respondent
        FieldInterview
        Contact
        DirectoryAssistance
        AccurintBatch
        AccurintManual
        Facebook
        WebInterview
        Internet
        PostOffice
        ClientUpdate
        Other
    End Enum

    Public Enum AddressType As Integer
        Unknown
        HomeAddress
        HomeMailingAddressOnly
        WorkAddress
        WorkMailingAddressOnly
        InstitutionAddress
        InstitutionMailingAddressOnly
        Other
    End Enum

    Public Enum PhoneType As Integer
        Unknown = 0
        Home = 1
        Business = 2
        HomeOffice = 3
        Cell = 4
        Pager = 5
        ComputerFax = 6
        Other = 7
    End Enum

    Public Enum NoteTableType As Integer
        Address = 1
        Phone
        EMail
        SocialNetwork
        Document
    End Enum
End Class

