'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Configuration
Imports System.Reflection
Imports System.Security
Imports System.Security.Principal
Imports Microsoft.Win32
Imports MPR.SMS.Security

Module GlobalSMS
    'Public UserOptions As UserOptions

    Public ReadOnly Property Project As Data.Project
        Get
            Return Data.Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Provides the main entry point for the SMS application.
    ''' </summary>

        Sub Main()

        ' Verify that code access security and MDAC have been properly configured/installed.

        Dim strMDACVersion As String = ""

        Try

            Dim key As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\DataAccess")

            If Not key Is Nothing Then
                strMDACVersion = key.GetValue("FullInstallVer").ToString()
            End If

        Catch ex As SecurityException
            ' If a security exception is installed, Code Access Security has not been configured.
            MessageBox.Show(
                "Your workstation is not properly configured to run the SMS Application:" & Environment.NewLine &
                Environment.NewLine &
                "The MPR Code Access Security Policy has not been configured on your machine." & Environment.NewLine &
                Environment.NewLine &
                "Please contact Computer and Network Services to install the necessary operating system requirements.",
                "MPR .NET Version Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End Try

        If strMDACVersion Is Nothing OrElse strMDACVersion < "2.7" Then
            ' SMS requires that MDAC 2.7 or later be installed.
            MessageBox.Show(
                "Your workstation is not properly configured to run the SMS Application:" & Environment.NewLine &
                Environment.NewLine &
                "The SMS Application requires that Microsoft Data Access Components 2.7 or later be installed on your machine." &
                Environment.NewLine & Environment.NewLine &
                "Please contact Computer and Network Services to install the necessary operating system requirements.",
                "MPR .NET Version Check", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Data.Project.IsRuntime = True

        '  The Randomize statement will cause the program to generate a new
        '  set of random numbers every time it is run - otherwise the random
        '  number sequence will always be the same.  Run only once at startup
        '  for best results (seeds with system timer value).
        Randomize()

        'UserOptions = UserOptions.GetInstance()

        ' Display the startup dialog 

        Dim frmStartup As New frmStartup
        frmStartup.ShowDialog()

        If frmStartup.InitializationError Then
            Dim objEntryAssembly As Assembly = Assembly.GetEntryAssembly()
            Dim title As AssemblyTitleAttribute =
                    CType(AssemblyTitleAttribute.GetCustomAttribute(objEntryAssembly, GetType(AssemblyTitleAttribute)),
                          AssemblyTitleAttribute)
            MessageBox.Show(frmStartup.CompletionMessage, title.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If


        'Added 11/28/2011 by AV - no longer show login screen, use information from windows login only:

        CurrentUser.Login(Nothing)
        Dim strUserName As String = String.Empty
        strUserName = WindowsIdentity.GetCurrent.Name
        If IsAuthenticated() Then
            If CurrentUser.ProjectName = ConfigurationManager.AppSettings("ProjectShortName") Then
                Application.EnableVisualStyles()
                Application.Run(New frmSMSMain)
            End If
        Else
            MessageBox.Show("You do not have permission to the SMS for this project.", "Survey Management System",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

        '' Display the login dialog using the Projects collection initialized in the startup dialog  

        'Dim frmLogin As New frmLogin

        '' If login was successful, display the main window

        'If frmLogin.ShowDialog() = DialogResult.OK Then

        '    System.Windows.Forms.Application.Run(New frmSMSMain)
        '    'UserOptions.GetInstance().Save()

        'End If
    End Sub

    Private Function IsAuthenticated() As Boolean
        'copied here from frmlogin and adjusted on 11/28/2011 by AV

        Try
            CurrentUser.Login(ConfigurationManager.AppSettings("ProjectShortName"))
            If Not CurrentUser.IsAuthenticated Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
