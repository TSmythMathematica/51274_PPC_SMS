'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.Configuration
Imports System.Reflection
Imports System.Threading
Imports MPR.SMS.Data

Public Class frmStartup
    Inherits Form

    Private mobjThread As Thread

    Private mobjStartupThread As StartupThread

    Private mstrComplete As String

    Private _InitializationError As Boolean = False

    Public ReadOnly Property InitializationError As Boolean
        Get
            Return _InitializationError
        End Get
    End Property

    Public ReadOnly Property CompletionMessage As String
        Get
            Return mstrComplete
        End Get
    End Property

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblSMS As System.Windows.Forms.Label
    Friend WithEvents pbSMS As System.Windows.Forms.PictureBox
    Friend WithEvents lblInitializationStatus As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(frmStartup))
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblSMS = New System.Windows.Forms.Label()
        Me.pbSMS = New System.Windows.Forms.PictureBox()
        Me.lblInitializationStatus = New System.Windows.Forms.Label()
        CType(Me.pbSMS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVersion
        '
        Me.lblVersion.AccessibleDescription = "Version label"
        Me.lblVersion.AccessibleName = "Version Label"
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(96, 40)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(350, 24)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "< version >"
        Me.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSMS
        '
        Me.lblSMS.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!, System.Drawing.FontStyle.Bold,
                                                 System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSMS.Location = New System.Drawing.Point(96, 16)
        Me.lblSMS.Name = "lblSMS"
        Me.lblSMS.Size = New System.Drawing.Size(350, 24)
        Me.lblSMS.TabIndex = 4
        Me.lblSMS.Text = "MPR Survey Management System"
        Me.lblSMS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pbSMS
        '
        Me.pbSMS.Image = CType(resources.GetObject("pbSMS.Image"), System.Drawing.Image)
        Me.pbSMS.Location = New System.Drawing.Point(24, 16)
        Me.pbSMS.Name = "pbSMS"
        Me.pbSMS.Size = New System.Drawing.Size(48, 48)
        Me.pbSMS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbSMS.TabIndex = 3
        Me.pbSMS.TabStop = False
        '
        'lblInitializationStatus
        '
        Me.lblInitializationStatus.AccessibleDescription = ""
        Me.lblInitializationStatus.AccessibleName = ""
        Me.lblInitializationStatus.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblInitializationStatus.Location = New System.Drawing.Point(96, 80)
        Me.lblInitializationStatus.Name = "lblInitializationStatus"
        Me.lblInitializationStatus.Size = New System.Drawing.Size(350, 22)
        Me.lblInitializationStatus.TabIndex = 6
        Me.lblInitializationStatus.Text = "Initializing..."
        Me.lblInitializationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmStartup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(458, 170)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblInitializationStatus)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.lblSMS)
        Me.Controls.Add(Me.pbSMS)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStartup"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Please wait..."
        CType(Me.pbSMS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

    Private Sub frmStartup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'this Startup form caused a threading error under VS2005.
        'the line below disables the thread checking, making it run
        'as it did under VS2003.
        CheckForIllegalCrossThreadCalls = False

        ' Get the application domain's executing assembly

        Dim objEntryAssembly As Assembly = Assembly.GetEntryAssembly()

        Dim title As AssemblyTitleAttribute =
                CType(AssemblyTitleAttribute.GetCustomAttribute(objEntryAssembly, GetType(AssemblyTitleAttribute)),
                      AssemblyTitleAttribute)

        lblInitializationStatus.Text = "Initializing " & title.Title & "..."

        ' Initialize version information

        lblVersion.Text = "Version " & Application.ProductVersion

        mobjStartupThread = New StartupThread

        AddHandler mobjStartupThread.OnError, AddressOf Me.OnError

        AddHandler mobjStartupThread.OnComplete, AddressOf Me.OnComplete

        mobjThread = New Thread(AddressOf mobjStartupThread.Run)

        mobjThread.Start()
    End Sub

    Private Sub OnComplete(message As String)

        mstrComplete = message

        Me.lblInitializationStatus.Text = "Initialization complete."

        Me.Close()
    End Sub

    Private Sub OnError(message As String)

        _InitializationError = True

        mstrComplete = message

        Me.lblInitializationStatus.Text = mstrComplete

        Me.Close()
    End Sub
End Class

Public Class StartupThread
    Public Event OnUpdate(message As String)

    Public Event OnComplete(message As String)

    Public Event OnError(message As String)

    Public Sub Run()

        Try

            'Dim strUpdate As String = System.Configuration.ConfigurationManager.AppSettings("UpdateInProgress")

            'If Not strUpdate Is Nothing Then
            '    RaiseEvent OnComplete(strUpdate)
            'Else
            Project.GetInstance(ConfigurationManager.AppSettings)
            RaiseEvent OnComplete("Initialization complete.")
            'End If
        Catch ex As Exception
            RaiseEvent OnError(ex.Message)
        End Try
    End Sub
End Class
