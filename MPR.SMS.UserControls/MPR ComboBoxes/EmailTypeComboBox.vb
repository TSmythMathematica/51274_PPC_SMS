'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS EmailType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     EmailTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS EmailType. The combo box is automatically populated with the current project's
'''     avaliable EmailTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class EmailTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the EmailTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboEmailTypes.DisplayMember = "Description"

            Dim objEmailType As New EmailType

            objEmailType.Description = New SqlString("")

            'Me.cboEmailTypes.Items.Add(objEmailType)

            For Each objEmailType In Project.EmailTypes
                Me.cboEmailTypes.Items.Add(objEmailType)
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
    Friend WithEvents cboEmailTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmailType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblEmailType = New System.Windows.Forms.Label
        Me.cboEmailTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblEmailType
        '
        Me.lblEmailType.AutoSize = True
        Me.lblEmailType.Location = New System.Drawing.Point(0, 0)
        Me.lblEmailType.Name = "lblEmailType"
        Me.lblEmailType.Size = New System.Drawing.Size(64, 13)
        Me.lblEmailType.TabIndex = 0
        Me.lblEmailType.Text = "Email type:"
        Me.lblEmailType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmailTypes
        '
        Me.cboEmailTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboEmailTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboEmailTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEmailTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmailTypes.DropDownWidth = 200
        Me.cboEmailTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboEmailTypes.Name = "cboEmailTypes"
        Me.cboEmailTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboEmailTypes.Sorted = True
        Me.cboEmailTypes.TabIndex = 1
        '
        'EmailTypeComboBox
        '
        Me.Controls.Add(Me.cboEmailTypes)
        Me.Controls.Add(Me.lblEmailType)
        Me.Name = "EmailTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.EmailType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.EmailType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedEmailType As EmailType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboEmailTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboEmailTypes.Items(cboEmailTypes.SelectedIndex), EmailType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboEmailTypes.SelectedIndex = 0
            Else
                Dim objEmailType As EmailType
                Dim i As Integer = 0
                For Each objEmailType In cboEmailTypes.Items
                    If objEmailType.EmailTypeID.Value = Value.EmailTypeID.Value Then
                        cboEmailTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.EmailType" /> object in the combo box bu EmailType
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The EmailType ID of the currently selected <see cref="T:MPR.SMS.Data.EmailType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedEmailTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboEmailTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboEmailTypes.Items(cboEmailTypes.SelectedIndex), EmailType).EmailTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboEmailTypes.SelectedIndex = 0
            Else
                Dim objEmailType As EmailType
                Dim i As Integer = 0
                For Each objEmailType In cboEmailTypes.Items
                    If Not objEmailType.EmailTypeID.IsNull Then
                        If objEmailType.EmailTypeID.Value = Value Then
                            cboEmailTypes.SelectedIndex = i
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
            Return Me.lblEmailType.Text
        End Get
        Set
            Me.lblEmailType.Text = Value
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
                cboEmailTypes.Left = 88
                cboEmailTypes.Width = Me.Width - cboEmailTypes.Left
            Else
                cboEmailTypes.Left = 0
                cboEmailTypes.Width = Me.Width
            End If
            lblEmailType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboEmailTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboEmailTypes.BackColor = Color.Silver
                Me.cboEmailTypes.ForeColor = Color.Black
            Else
                Me.cboEmailTypes.BackColor = Color.White
                Me.cboEmailTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboEmailTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboEmailTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
