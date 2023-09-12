'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class ZipCodeWithValidator
    Inherits UserControl

#Region "Windows Form Designer generated code"

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Protected WithEvents ZipCodeValidator1 As MPR.Windows.Forms.Validation.ZIPCodeValidator

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Protected WithEvents TextBoxWithContextMenu1 As MPR.SMS.UserControls.TextBoxWithContextMenu

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(ZipCodeWithValidator))
        Me.ZipCodeValidator1 = New MPR.Windows.Forms.Validation.ZIPCodeValidator
        Me.TextBoxWithContextMenu1 = New MPR.SMS.UserControls.TextBoxWithContextMenu
        CType(Me.ZipCodeValidator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ZipCodeValidator1
        '
        Me.ZipCodeValidator1.ControlToValidate = Me.TextBoxWithContextMenu1
        Me.ZipCodeValidator1.ErrorMessage = "Please enter a valid ZIP or ZIP+4 Code."
        Me.ZipCodeValidator1.Icon = CType(resources.GetObject("ZipCodeValidator1.Icon"), System.Drawing.Icon)
        Me.ZipCodeValidator1.ValidateOnLoad = True
        '
        'TextBoxWithContextMenu1
        '
        Me.TextBoxWithContextMenu1.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxWithContextMenu1.MaxLength = 32767
        Me.TextBoxWithContextMenu1.Name = "TextBoxWithContextMenu1"
        Me.TextBoxWithContextMenu1.ReadOnly = False
        Me.TextBoxWithContextMenu1.RegExprPattern = "[^\d]"
        Me.TextBoxWithContextMenu1.Size = New System.Drawing.Size(80, 20)
        Me.TextBoxWithContextMenu1.TabIndex = 0
        Me.TextBoxWithContextMenu1.ValidatorType =
            MPR.SMS.UserControls.TextBoxWithContextMenu.TextBoxWithContextMenuType.Zip
        '
        'ZipCodeWithValidator
        '
        Me.Controls.Add(Me.TextBoxWithContextMenu1)
        Me.Name = "ZipCodeWithValidator"
        Me.Size = New System.Drawing.Size(96, 20)
        CType(Me.ZipCodeValidator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Private Fields"

    Private mblnAllowInternational As Boolean = False
    Private mstrValExp As String = ""

#End Region

#Region "Public Properties"

    Public Overrides Property Text As String
        Get
            Return CleanInput(Me.TextBoxWithContextMenu1.Text)
        End Get
        Set
            Me.TextBoxWithContextMenu1.Text = Value
            TextBoxWithContextMenu1_Leave(Nothing, Nothing)
            Me.ZipCodeValidator1.Validate()
        End Set
    End Property

    Public Property Required As Boolean
        Get
            Return Me.ZipCodeValidator1.Required
        End Get
        Set
            Me.ZipCodeValidator1.Required = Value
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return Me.TextBoxWithContextMenu1.ReadOnly
        End Get
        Set
            Me.TextBoxWithContextMenu1.ReadOnly = Value
        End Set
    End Property

    <Category("Behavior")> _
    <DefaultValue(False)>
    Public Shadows Property UseMask As Boolean
        Get
            Return Me.TextBoxWithContextMenu1.UseMask
        End Get
        Set
            Me.TextBoxWithContextMenu1.UseMask = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Property AllowInternational As Boolean
        Get
            Return mblnAllowInternational
        End Get
        Set
            mblnAllowInternational = value
            If mblnAllowInternational Then
                ZipCodeValidator1.ValidationExpression = ""
            Else
                ZipCodeValidator1.ValidationExpression = mstrValExp
            End If
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub TextBoxWithContextMenu1_Leave(sender As Object, e As EventArgs) Handles TextBoxWithContextMenu1.Leave

        Dim zip As String = CleanInput(TextBoxWithContextMenu1.Text)
        If zip.Length = 9 And Not mblnAllowInternational Then
            TextBoxWithContextMenu1.Text = String.Format("{0}-{1}", zip.Substring(0, 5), zip.Substring(5, 4))
        ElseIf zip.Length = 5 Then
            TextBoxWithContextMenu1.Text = zip
        End If
    End Sub

    Private Sub ZipCodeWithValidator_Load(sender As Object, e As EventArgs) Handles Me.Load

        If UseMask Then ZipCodeValidator1.ValidationExpression = ZipCodeValidator1.ValidationExpression & "|(^\d{5}-$)"
        mstrValExp = ZipCodeValidator1.ValidationExpression
    End Sub

#End Region

#Region "Private Methods"

    Function CleanInput(strIn As String) As String
        If mblnAllowInternational Then
            Return strIn
        Else
            ' Replace invalid characters (decimal point, @, dash) with empty strings.
            Return Regex.Replace(strIn, Me.TextBoxWithContextMenu1.RegExprPattern, "")
        End If
    End Function

#End Region
End Class
