'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class TextBoxWithContextMenu
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
    Protected WithEvents MyTextBox As System.Windows.Forms.MaskedTextBox
    Protected WithEvents MyContextMenu As System.Windows.Forms.ContextMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents mnuCopy As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCopyUnformatted As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPaste As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDelete As System.Windows.Forms.MenuItem
    Friend WithEvents mnuUndo As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCut As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSelectAll As System.Windows.Forms.MenuItem
    Friend WithEvents mnuPasteUnformatted As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MyTextBox = New System.Windows.Forms.MaskedTextBox
        Me.MyContextMenu = New System.Windows.Forms.ContextMenu
        Me.mnuUndo = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.mnuCut = New System.Windows.Forms.MenuItem
        Me.mnuCopy = New System.Windows.Forms.MenuItem
        Me.mnuCopyUnformatted = New System.Windows.Forms.MenuItem
        Me.mnuPaste = New System.Windows.Forms.MenuItem
        Me.mnuPasteUnformatted = New System.Windows.Forms.MenuItem
        Me.mnuDelete = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.mnuSelectAll = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'MyTextBox
        '
        Me.MyTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                     Or System.Windows.Forms.AnchorStyles.Right),
                                    System.Windows.Forms.AnchorStyles)
        Me.MyTextBox.ContextMenu = Me.MyContextMenu
        Me.MyTextBox.Location = New System.Drawing.Point(0, 0)
        Me.MyTextBox.Name = "MyTextBox"
        Me.MyTextBox.Size = New System.Drawing.Size(80, 20)
        Me.MyTextBox.TabIndex = 0
        '
        'MyContextMenu
        '
        Me.MyContextMenu.MenuItems.AddRange(
            New System.Windows.Forms.MenuItem() _
                                               {Me.mnuUndo, Me.MenuItem3, Me.mnuCut, Me.mnuCopy, Me.mnuCopyUnformatted,
                                                Me.mnuPaste, Me.mnuPasteUnformatted, Me.mnuDelete, Me.MenuItem2,
                                                Me.mnuSelectAll})
        '
        'mnuUndo
        '
        Me.mnuUndo.Index = 0
        Me.mnuUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ
        Me.mnuUndo.Text = "&Undo"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'mnuCut
        '
        Me.mnuCut.Index = 2
        Me.mnuCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX
        Me.mnuCut.Text = "Cut"
        '
        'mnuCopy
        '
        Me.mnuCopy.Index = 3
        Me.mnuCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mnuCopy.Text = "&Copy"
        '
        'mnuCopyUnformatted
        '
        Me.mnuCopyUnformatted.Index = 4
        Me.mnuCopyUnformatted.Text = "Copy &Unformatted"
        '
        'mnuPaste
        '
        Me.mnuPaste.Index = 5
        Me.mnuPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.mnuPaste.Text = "&Paste"
        '
        'mnuPasteUnformatted
        '
        Me.mnuPasteUnformatted.Index = 6
        Me.mnuPasteUnformatted.Text = "Paste Unformatted"
        Me.mnuPasteUnformatted.Visible = False
        '
        'mnuDelete
        '
        Me.mnuDelete.Index = 7
        Me.mnuDelete.Text = "&Delete"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 8
        Me.MenuItem2.Text = "-"
        '
        'mnuSelectAll
        '
        Me.mnuSelectAll.Index = 9
        Me.mnuSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mnuSelectAll.Text = "Select &All"
        '
        'TextBoxWithContextMenu
        '
        Me.Controls.Add(Me.MyTextBox)
        Me.Name = "TextBoxWithContextMenu"
        Me.Size = New System.Drawing.Size(80, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Properties"

    'This expression can be customized when setting the ValidatorType Property if new types are added
    Private _RegExprPattern As String = "[^\d]"

    Public Property RegExprPattern As String
        Get
            Return _RegExprPattern
        End Get
        Set
            _RegExprPattern = Value
        End Set
    End Property

    Public ReadOnly Property TextBox As MaskedTextBox
        Get
            Return Me.MyTextBox
        End Get
    End Property

    Public Overrides Property Text As String
        Get
            If CleanInput(Me.MyTextBox.Text) = "" Then
                Return ""
            Else
                Return Me.MyTextBox.Text
            End If
        End Get
        Set
            Me.MyTextBox.Text = Value
        End Set
    End Property

    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return Me.MyTextBox.ReadOnly
        End Get
        Set
            Me.MyTextBox.ReadOnly = Value
        End Set
    End Property

    Private mblnUseMask As Boolean = False

    <DefaultValue(False)>
    <Category("Behavior")>
    Public Property UseMask As Boolean
        Get
            Return mblnUseMask
        End Get
        Set
            mblnUseMask = value
            If mblnUseMask Then
                Select Case ValidatorType
                    Case TextBoxWithContextMenuType.Date
                        MyTextBox.Mask = "00/00/0000"
                    Case TextBoxWithContextMenuType.Phone
                        MyTextBox.Mask = "(999) 000-0000"
                    Case TextBoxWithContextMenuType.SSN
                        MyTextBox.Mask = "000-00-0000"
                    Case TextBoxWithContextMenuType.Zip
                        MyTextBox.Mask = "00000-9999"
                    Case Else
                        MyTextBox.Mask = ""
                End Select
            Else
                MyTextBox.Mask = ""
            End If
        End Set
    End Property

    Public Enum TextBoxWithContextMenuType
        [Date]
        Phone
        SSN
        Zip
    End Enum

    Private MyValidatorType As TextBoxWithContextMenuType

    Public Property ValidatorType As TextBoxWithContextMenuType
        Get
            Return MyValidatorType
        End Get
        Set
            MyValidatorType = Value
            Select Case Value
                Case TextBoxWithContextMenuType.Date
                    MaxLength = 10
                Case TextBoxWithContextMenuType.Phone
                    MaxLength = 14
                Case TextBoxWithContextMenuType.SSN
                    MaxLength = 11
                Case TextBoxWithContextMenuType.Zip
                    MaxLength = 10
            End Select
        End Set
    End Property

    Public Property MaxLength As Integer
        Get
            Return MyTextBox.MaxLength
        End Get
        Set
            MyTextBox.MaxLength = Value
        End Set
    End Property

#End Region

#Region "Context Menu"

    Private Sub mnuUndo_Click(sender As Object, e As EventArgs) Handles mnuUndo.Click
        Me.MyTextBox.Undo()
    End Sub

    Private Sub mnuCut_Click(sender As Object, e As EventArgs) Handles mnuCut.Click
        Clipboard.SetDataObject(Me.MyTextBox.SelectedText)
        Me.MyTextBox.SelectedText = ""
    End Sub

    Private Sub mnuCopy_Click(sender As Object, e As EventArgs) Handles mnuCopy.Click
        Clipboard.SetDataObject(Me.MyTextBox.SelectedText)
    End Sub

    Private Sub mnuCopyUnformatted_Click(sender As Object, e As EventArgs) Handles mnuCopyUnformatted.Click
        Select Case ValidatorType
            Case TextBoxWithContextMenuType.Date
                Try
                    Dim dt As Date = CType(Me.MyTextBox.SelectedText, Date)
                    Dim dy As String = dt.Day.ToString
                    Dim mo As String = dt.Month.ToString
                    Dim yr As String = dt.Year.ToString
                    If dt.Day < 10 Then dy = "0" & dy
                    If dt.Month < 10 Then mo = "0" & mo
                    If yr.Length < 4 Then yr = yr.PadLeft(4, CType("0", Char))

                    Clipboard.SetDataObject(mo & dy & yr)

                Catch ex As Exception
                    Clipboard.SetDataObject("")
                End Try
            Case Else
                Clipboard.SetDataObject(CleanInput(Me.MyTextBox.SelectedText))
        End Select
    End Sub

    Private Sub mnuPaste_Click(sender As Object, e As EventArgs) Handles mnuPaste.Click

        ''This code only pastes as much of the clipboard as will fit 
        ''in the space available in the textbox (as Ctrl-V does):
        Dim c As String = Clipboard.GetDataObject.GetData(DataFormats.Text).ToString

        'space available for pasting is MaxLength - Length of text + text to be replaced (SelectedText)
        Dim available As Integer = MaxLength - MyTextBox.Text.Length + MyTextBox.SelectedText.Length
        If c.Length > available Then
            Me.MyTextBox.SelectedText = c.Substring(0, available)
        Else
            Me.MyTextBox.SelectedText = c
        End If

        ''This code inserts the clipboard text and then chops off the end as necessary:
        'Me.MyTextBox.SelectedText = Clipboard.GetDataObject.GetData(System.Windows.Forms.DataFormats.Text)
        'If Me.MyTextBox.Text.Length > MaxLength Then
        '    Me.MyTextBox.Text = Me.MyTextBox.Text.Substring(0, Me.MaxLength)
        'End If
    End Sub

    Private Sub mnuPasteUnformatted_Click(sender As Object, e As EventArgs) Handles mnuPasteUnformatted.Click
        Me.MyTextBox.SelectedText = CleanInput(Clipboard.GetDataObject.GetData(DataFormats.Text).ToString)
        If Me.MyTextBox.Text.Length > MaxLength Then
            Me.MyTextBox.Text = Me.MyTextBox.Text.Substring(0, Me.MaxLength)
        End If
    End Sub

    Private Sub mnuDelete_Click(sender As Object, e As EventArgs) Handles mnuDelete.Click
        Me.MyTextBox.SelectedText = ""
    End Sub

    Private Sub mnuSelectAll_Click(sender As Object, e As EventArgs) Handles mnuSelectAll.Click
        Me.MyTextBox.SelectAll()
    End Sub

    Private Sub MyContextMenu_Popup(sender As Object, e As EventArgs) Handles MyContextMenu.Popup
        Dim HasText As Boolean = Me.MyTextBox.Text.Length > 0
        Dim IsSelected As Boolean = Me.MyTextBox.SelectedText.Length > 0

        Me.mnuUndo.Enabled = Me.MyTextBox.CanUndo
        Me.mnuCut.Enabled = HasText AndAlso IsSelected
        Me.mnuCopy.Enabled = HasText AndAlso IsSelected
        Me.mnuCopyUnformatted.Enabled = HasText AndAlso IsSelected
        Me.mnuPaste.Enabled = Clipboard.GetDataObject.GetDataPresent(DataFormats.Text)
        Me.mnuPasteUnformatted.Enabled = Clipboard.GetDataObject.GetDataPresent(DataFormats.Text)
        Me.mnuDelete.Enabled = HasText AndAlso IsSelected
        Me.mnuSelectAll.Enabled = HasText

        'Don't enable copy unformatted if an invalid date is entered
        Select Case ValidatorType
            Case TextBoxWithContextMenuType.Date
                Try
                    'Dim dt As Date = CType(Me.MyTextBox.SelectedText, Date)
                Catch ex As Exception
                    Me.mnuCopyUnformatted.Enabled = False
                End Try
        End Select
    End Sub

#End Region

#Region "Events"

    Public Shadows Event TextChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub MyTextBox_TextChanged(sender As Object, e As EventArgs) Handles MyTextBox.TextChanged

        RaiseEvent TextChanged(Me, e)
    End Sub

#End Region

#Region "Private Methods"

    Function CleanInput(strIn As String) As String
        ' Replace invalid characters (exceptdecimal point, @, dash) with empty strings.
        'Return Regex.Replace(strIn, "[^\w\.@-]", "")
        ' Replace invalid characters (decimal point, @, dash) with empty strings.
        Return Regex.Replace(strIn, RegExprPattern, "")
    End Function

#End Region
End Class
