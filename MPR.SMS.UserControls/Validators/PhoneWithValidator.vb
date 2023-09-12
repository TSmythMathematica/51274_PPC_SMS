'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class PhoneWithValidator
    Inherits UserControl

#Region "Private Fields"

    Private mblnAllowInternational As Boolean = False

#End Region

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
    Protected WithEvents PhoneValidator1 As MPR.Windows.Forms.Validation.PhoneValidator

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Protected WithEvents TextBoxWithContextMenu1 As MPR.SMS.UserControls.TextBoxWithContextMenu

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(PhoneWithValidator))
        Me.PhoneValidator1 = New MPR.Windows.Forms.Validation.PhoneValidator
        Me.TextBoxWithContextMenu1 = New MPR.SMS.UserControls.TextBoxWithContextMenu
        CType(Me.PhoneValidator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PhoneValidator1
        '
        Me.PhoneValidator1.ControlToValidate = Me.TextBoxWithContextMenu1
        Me.PhoneValidator1.ErrorMessage = "Please enter a valid telephone number."
        Me.PhoneValidator1.Icon = CType(resources.GetObject("PhoneValidator1.Icon"), System.Drawing.Icon)
        '
        'TextBoxWithContextMenu1
        '
        Me.TextBoxWithContextMenu1.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxWithContextMenu1.MaxLength = 14
        Me.TextBoxWithContextMenu1.Name = "TextBoxWithContextMenu1"
        Me.TextBoxWithContextMenu1.ReadOnly = False
        Me.TextBoxWithContextMenu1.RegExprPattern = "[^\d]"
        Me.TextBoxWithContextMenu1.Size = New System.Drawing.Size(80, 20)
        Me.TextBoxWithContextMenu1.TabIndex = 0
        Me.TextBoxWithContextMenu1.ValidatorType =
            MPR.SMS.UserControls.TextBoxWithContextMenu.TextBoxWithContextMenuType.Phone
        '
        'PhoneWithValidator
        '
        Me.Controls.Add(Me.TextBoxWithContextMenu1)
        Me.Name = "PhoneWithValidator"
        Me.Size = New System.Drawing.Size(96, 20)
        CType(Me.PhoneValidator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Public Properties"

    Public Overrides Property Text As String
        Get
            Return CleanInput(Me.TextBoxWithContextMenu1.Text)
        End Get
        Set
            Me.TextBoxWithContextMenu1.Text = Value
            TextBoxWithContextMenu1_Leave(Nothing, Nothing)
            Me.PhoneValidator1.Validate()
            Me.TextBoxWithContextMenu1.TextBox.SelectAll()
        End Set
    End Property

    Public Property TextFormatted As String
        Get
            Return Me.TextBoxWithContextMenu1.Text
        End Get
        Set
            Me.TextBoxWithContextMenu1.Text = Value
            TextBoxWithContextMenu1_Leave(Nothing, Nothing)
            Me.PhoneValidator1.Validate()
            Me.TextBoxWithContextMenu1.TextBox.SelectAll()
        End Set
    End Property

    Public Property Required As Boolean
        Get
            Return Me.PhoneValidator1.Required
        End Get
        Set
            Me.PhoneValidator1.Required = Value
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
                PhoneValidator1.ValidationExpression = ""
                TextBoxWithContextMenu1.MaxLength = 25
            Else
                PhoneValidator1.ValidationExpression = "(^|\s)((1)(\s|-|\.))?((\d{3})(\s|-|\.))?(\d{3})(\s|-|\.)(\d{4})"
                TextBoxWithContextMenu1.MaxLength = 14
            End If
            PhoneValidator1.Validate()
        End Set
    End Property

#End Region

#Region "Event Handlers"

    Private Sub TextBoxWithContextMenu1_Leave(sender As Object, e As EventArgs) Handles TextBoxWithContextMenu1.Leave
        Dim phone As String = CleanInput(TextBoxWithContextMenu1.Text)
        If phone.Length = 10 And Not mblnAllowInternational Then
            TextBoxWithContextMenu1.Text = String.Format("({0}) {1}-{2}", phone.Substring(0, 3), phone.Substring(3, 3),
                                                         phone.Substring(6))
        End If
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
