'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class DateWithValidator
    Inherits UserControl

#Region "Windows Form Designer generated code"

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Try
            Dim dt As Date = CType(TextBoxWithContextMenu1.Text, System.DateTime)
        Catch ex As Exception
        End Try
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
    Protected WithEvents DateValidator1 As MPR.Windows.Forms.Validation.DateValidator
    Protected WithEvents TextBoxWithContextMenu1 As MPR.SMS.UserControls.TextBoxWithContextMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager =
                New System.ComponentModel.ComponentResourceManager(GetType(DateWithValidator))
        Me.DateValidator1 = New MPR.Windows.Forms.Validation.DateValidator
        Me.TextBoxWithContextMenu1 = New MPR.SMS.UserControls.TextBoxWithContextMenu
        CType(Me.DateValidator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateValidator1
        '
        Me.DateValidator1.ControlToValidate = Me.TextBoxWithContextMenu1
        Me.DateValidator1.ErrorMessage = "Please enter a date in mm/dd/yyyy format."
        Me.DateValidator1.Icon = CType(resources.GetObject("DateValidator1.Icon"), System.Drawing.Icon)
        '
        'TextBoxWithContextMenu1
        '
        Me.TextBoxWithContextMenu1.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxWithContextMenu1.MaxLength = 10
        Me.TextBoxWithContextMenu1.Name = "TextBoxWithContextMenu1"
        Me.TextBoxWithContextMenu1.ReadOnly = False
        Me.TextBoxWithContextMenu1.RegExprPattern = "[^\d]"
        Me.TextBoxWithContextMenu1.Size = New System.Drawing.Size(68, 20)
        Me.TextBoxWithContextMenu1.TabIndex = 0
        Me.TextBoxWithContextMenu1.ValidatorType =
            MPR.SMS.UserControls.TextBoxWithContextMenu.TextBoxWithContextMenuType.[Date]
        '
        'DateWithValidator
        '
        Me.Controls.Add(Me.TextBoxWithContextMenu1)
        Me.Name = "DateWithValidator"
        Me.Size = New System.Drawing.Size(86, 20)
        CType(Me.DateValidator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

#End Region

#Region "Events"

    Public Shadows Event TextChanged(sender As Object, e As EventArgs)

#End Region

#Region "Public Properties"

    Public Overrides Property Text As String
        Get
            Return Me.TextBoxWithContextMenu1.Text
        End Get
        Set
            Me.TextBoxWithContextMenu1.Text = Value
            TextBoxWithContextMenu1_Leave(Nothing, Nothing)
            Me.DateValidator1.Validate()
        End Set
    End Property

    Public Property Required As Boolean
        Get
            Return Me.DateValidator1.Required
        End Get
        Set
            Me.DateValidator1.Required = Value
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

        Dim sDate As String = CleanInput(TextBoxWithContextMenu1.Text)
        If sDate.Length = 8 Then
            TextBoxWithContextMenu1.Text = String.Format("{0}/{1}/{2}", sDate.Substring(0, 2), sDate.Substring(2, 2),
                                                         sDate.Substring(4))
        Else

            Try
                Dim dt As Date = CType(TextBoxWithContextMenu1.Text, DateTime)
                Dim dy As String = dt.Day.ToString
                Dim mo As String = dt.Month.ToString
                Dim yr As String = dt.Year.ToString

                If dt.Day < 10 Then dy = "0" & dy
                If dt.Month < 10 Then mo = "0" & mo
                If yr.Length < 4 Then yr = yr.PadLeft(4, CType("0", Char))

                TextBoxWithContextMenu1.Text = String.Format("{0}/{1}/{2}", mo, dy, yr)

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub TextBoxWithContextMenu1_TextChanged(sender As Object, e As EventArgs) _
        Handles TextBoxWithContextMenu1.TextChanged

        If IsDate(TextBoxWithContextMenu1.Text) Or TextBoxWithContextMenu1.Text.Equals("") Then
            RaiseEvent TextChanged(Me, e)
        End If
    End Sub

#End Region

#Region "Private Methods"

    Function CleanInput(strIn As String) As String

        ' Replace invalid characters (decimal point, @, dash) with empty strings.
        Return Regex.Replace(strIn, Me.TextBoxWithContextMenu1.RegExprPattern, "")
    End Function

#End Region
End Class
