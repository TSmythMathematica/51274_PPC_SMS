'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************


Public Class GradeWithValidator
    Inherits UserControl

#Region " Windows Form Designer generated code "

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
    Protected WithEvents RegularExpressionValidator1 As MPR.Windows.Forms.Validation.RegularExpressionValidator
    Protected WithEvents txtGrade As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(GradeWithValidator))
        Me.RegularExpressionValidator1 = New MPR.Windows.Forms.Validation.RegularExpressionValidator
        Me.txtGrade = New System.Windows.Forms.TextBox
        CType(Me.RegularExpressionValidator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RegularExpressionValidator1
        '
        Me.RegularExpressionValidator1.ControlToValidate = Me.txtGrade
        Me.RegularExpressionValidator1.ErrorMessage = "Please enter a valid Grade (1-12, K, PK)"
        Me.RegularExpressionValidator1.Icon = CType(resources.GetObject("RegularExpressionValidator1.Icon"),
                                                    System.Drawing.Icon)
        Me.RegularExpressionValidator1.ValidationExpression = "[^\d]"
        '
        'txtGrade
        '
        Me.txtGrade.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                     Or System.Windows.Forms.AnchorStyles.Left) _
                                    Or System.Windows.Forms.AnchorStyles.Right),
                                   System.Windows.Forms.AnchorStyles)
        Me.txtGrade.Location = New System.Drawing.Point(0, 0)
        Me.txtGrade.MaxLength = 2
        Me.txtGrade.Name = "txtGrade"
        Me.txtGrade.Size = New System.Drawing.Size(24, 20)
        Me.txtGrade.TabIndex = 0
        '
        'GradeWithValidator
        '
        Me.Controls.Add(Me.txtGrade)
        Me.Name = "GradeWithValidator"
        Me.Size = New System.Drawing.Size(40, 20)
        CType(Me.RegularExpressionValidator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Private Fields"

    Private mAllow0 As Boolean = False
    Private mAllowK As Boolean = True
    Private mAllowPK As Boolean = False

#End Region

#Region "Public Properties"

    Public Property AllowGrade0 As Boolean
        Get
            Return mAllow0
        End Get
        Set
            mAllow0 = Value
            RegularExpressionValidator1.ValidationExpression = GetRegExp()
            RegularExpressionValidator1.ErrorMessage = GetErrorMsg()
        End Set
    End Property

    Public Property AllowGradeK As Boolean
        Get
            Return mAllowK
        End Get
        Set
            mAllowK = Value
            RegularExpressionValidator1.ValidationExpression = GetRegExp()
            RegularExpressionValidator1.ErrorMessage = GetErrorMsg()
        End Set
    End Property

    Public Property AllowGradePK As Boolean
        Get
            Return mAllowPK
        End Get
        Set
            mAllowPK = Value
            RegularExpressionValidator1.ValidationExpression = GetRegExp()
            RegularExpressionValidator1.ErrorMessage = GetErrorMsg()
        End Set
    End Property

    Public Property Required As Boolean
        Get
            Return Me.RegularExpressionValidator1.Required
        End Get
        Set
            Me.RegularExpressionValidator1.Required = Value
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return Me.txtGrade.ReadOnly
        End Get
        Set
            Me.txtGrade.ReadOnly = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return txtGrade.Text
        End Get
        Set
            Me.txtGrade.Text = Value
            txtGrade_Leave(Nothing, Nothing)
            Me.RegularExpressionValidator1.Validate()
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Function GetRegExp() As String

        Dim pStr As String

        pStr = "10|11|12|"
        If mAllow0 Then
            pStr = pStr + "^[0-9]$"
        Else
            pStr = pStr + "^[1-9]$"
        End If
        If mAllowPK Then pStr = pStr + "|PK"
        If mAllowK Then pStr = pStr + "|^K$"

        Return pStr
    End Function

    Private Function GetErrorMsg() As String

        Dim pStr As String

        pStr = "Please enter a valid Grade ("
        If mAllow0 Then
            pStr = pStr + "0-12"
        Else
            pStr = pStr + "1-12"
        End If
        If mAllowK Then pStr = pStr + ", K"
        If mAllowPK Then pStr = pStr + ", PK"

        pStr = pStr + ")"

        Return pStr
    End Function

#End Region

#Region "Events"

    Public Shadows Event TextChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub txtGrade_Leave(sender As Object, e As EventArgs) Handles txtGrade.Leave

        txtGrade.Text = txtGrade.Text.ToUpper
    End Sub

    Private Sub txtGrade_TextChanged(sender As Object, e As EventArgs) Handles txtGrade.TextChanged
        Me.RegularExpressionValidator1.Validate()
        RaiseEvent TextChanged(Me, e)
    End Sub

#End Region
End Class
