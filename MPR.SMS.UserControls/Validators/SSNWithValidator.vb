'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class SSNWithValidator
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
    Protected WithEvents TextBoxWithContextMenu1 As MPR.SMS.UserControls.TextBoxWithContextMenu
    Protected WithEvents SsnValidator1 As MPR.Windows.Forms.Validation.SSNValidator

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(SSNWithValidator))
        Me.TextBoxWithContextMenu1 = New MPR.SMS.UserControls.TextBoxWithContextMenu
        Me.SsnValidator1 = New MPR.Windows.Forms.Validation.SSNValidator
        CType(Me.SsnValidator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxWithContextMenu1
        '
        Me.TextBoxWithContextMenu1.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxWithContextMenu1.Name = "TextBoxWithContextMenu1"
        Me.TextBoxWithContextMenu1.RegExprPattern = "[^\d]"
        Me.TextBoxWithContextMenu1.Size = New System.Drawing.Size(80, 20)
        Me.TextBoxWithContextMenu1.TabIndex = 0
        Me.TextBoxWithContextMenu1.ValidatorType =
            MPR.SMS.UserControls.TextBoxWithContextMenu.TextBoxWithContextMenuType.SSN
        '
        'SsnValidator1
        '
        Me.SsnValidator1.ControlToValidate = Me.TextBoxWithContextMenu1
        Me.SsnValidator1.ErrorMessage = "Please enter a valid Social Security Number."
        Me.SsnValidator1.Icon = CType(resources.GetObject("SsnValidator1.Icon"), System.Drawing.Icon)
        '
        'SSNWithValidator
        '
        Me.Controls.Add(Me.TextBoxWithContextMenu1)
        Me.Name = "SSNWithValidator"
        Me.Size = New System.Drawing.Size(96, 20)
        CType(Me.SsnValidator1, System.ComponentModel.ISupportInitialize).EndInit()
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
            Me.SsnValidator1.Validate()
        End Set
    End Property

    Public Property Required As Boolean
        Get
            Return Me.SsnValidator1.Required
        End Get
        Set
            Me.SsnValidator1.Required = Value
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

#End Region

#Region "Event Handlers"

    Private Sub TextBoxWithContextMenu1_Leave(sender As Object, e As EventArgs) Handles TextBoxWithContextMenu1.Leave
        Dim ssn As String = CleanInput(TextBoxWithContextMenu1.Text)
        If ssn.Length = 9 Then
            TextBoxWithContextMenu1.Text = String.Format("{0}-{1}-{2}", ssn.Substring(0, 3), ssn.Substring(3, 2),
                                                         ssn.Substring(5, 4))
        End If
    End Sub

#End Region

#Region "Private Methods"

    Function CleanInput(strIn As String) As String
        ' Replace invalid characters (exceptdecimal point, @, dash) with empty strings.
        'Return Regex.Replace(strIn, "[^\w\.@-]", "")
        ' Replace invalid characters (decimal point, @, dash) with empty strings.
        Return Regex.Replace(strIn, "[^\d]", "")
        'Return Regex.Replace(strIn, Me.TextBoxWithContextMenu1.RegExprPattern, "")
    End Function

#End Region
End Class
