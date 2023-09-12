'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS ReturnedMailReason auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     ReturnedMailComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS ReturnedMailReason. The combo box is automatically populated with the current project's
'''     avaliable ReturnedMailReasons. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class ReturnedMailComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the ReturnedMailsComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboReturnedMails.DisplayMember = "Description"

            Dim objReturnedMailReason As New ReturnedMailReason

            objReturnedMailReason.Description = New SqlString("")

            'Me.cboReturnedMails.Items.Add(objReturnedMailReason)

            For Each objReturnedMailReason In Project.ReturnedMailReasons
                Me.cboReturnedMails.Items.Add(objReturnedMailReason)
            Next

        End If
    End Sub

#End Region

#Region " Windows Form Designer generated code "

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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents lblReturnedMail As System.Windows.Forms.Label
    Friend WithEvents cboReturnedMails As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblReturnedMail = New System.Windows.Forms.Label
        Me.cboReturnedMails = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblReturnedMail
        '
        Me.lblReturnedMail.AutoSize = True
        Me.lblReturnedMail.Location = New System.Drawing.Point(0, 0)
        Me.lblReturnedMail.Name = "lblReturnedMail"
        Me.lblReturnedMail.Size = New System.Drawing.Size(75, 13)
        Me.lblReturnedMail.TabIndex = 0
        Me.lblReturnedMail.Text = "Returned mail:"
        Me.lblReturnedMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboReturnedMails
        '
        Me.cboReturnedMails.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboReturnedMails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboReturnedMails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboReturnedMails.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboReturnedMails.DropDownWidth = 200
        Me.cboReturnedMails.Location = New System.Drawing.Point(88, 0)
        Me.cboReturnedMails.Name = "cboReturnedMails"
        Me.cboReturnedMails.Size = New System.Drawing.Size(144, 21)
        Me.cboReturnedMails.TabIndex = 1
        '
        'ReturnedMailComboBox
        '
        Me.Controls.Add(Me.cboReturnedMails)
        Me.Controls.Add(Me.lblReturnedMail)
        Me.Name = "ReturnedMailComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ReturnedMailReason" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.ReturnedMailReason" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedReturnedMail As ReturnedMailReason
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboReturnedMails.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboReturnedMails.Items(cboReturnedMails.SelectedIndex), ReturnedMailReason)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboReturnedMails.SelectedIndex = 0
            Else
                Dim objReturnedMailReason As ReturnedMailReason
                Dim i As Integer = 0
                For Each objReturnedMailReason In cboReturnedMails.Items
                    If objReturnedMailReason.ReturnedMailReasonID.Value = Value.ReturnedMailReasonID.Value Then
                        cboReturnedMails.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ReturnedMailReason" /> object in the combo box bu
    '''     ReturnedMailReasonID.
    ''' </summary>
    ''' <value>
    '''     The ReturnedMailReasonID of the currently selected <see cref="T:MPR.SMS.Data.ReturnedMailReason" /> in the combo
    '''     box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedReturnedMailReasonID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboReturnedMails.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboReturnedMails.Items(cboReturnedMails.SelectedIndex), ReturnedMailReason).
                        ReturnedMailReasonID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboReturnedMails.SelectedIndex = 0
            Else
                Dim objReturnedMailReason As ReturnedMailReason
                Dim i As Integer = 0
                For Each objReturnedMailReason In cboReturnedMails.Items
                    If Not objReturnedMailReason.ReturnedMailReasonID.IsNull Then
                        If objReturnedMailReason.ReturnedMailReasonID.Value = Value Then
                            cboReturnedMails.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblReturnedMail.Text
        End Get
        Set
            Me.lblReturnedMail.Text = Value
        End Set
    End Property

    <DefaultValue(True)>
    Public Property MyLabelVisible As Boolean
        Get
            Return mblnLabelVisible
        End Get
        Set
            mblnLabelVisible = Value
            If mblnLabelVisible Then
                cboReturnedMails.Left = 88
                cboReturnedMails.Width = Me.Width - cboReturnedMails.Left
            Else
                cboReturnedMails.Left = 0
                cboReturnedMails.Width = Me.Width
            End If
            lblReturnedMail.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboReturnedMails.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboReturnedMails.BackColor = Color.LightGray
                Me.cboReturnedMails.ForeColor = Color.Black
            Else
                Me.cboReturnedMails.BackColor = Color.White
                Me.cboReturnedMails.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboReturnedMails_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboReturnedMails.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class

