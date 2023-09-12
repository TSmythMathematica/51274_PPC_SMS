'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS SocialNetworkStatus auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SocialNetworkStatusComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS SocialNetworkStatus. The combo box is automatically populated with the current project's
'''     avaliable SocialNetworkStatuses. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SocialNetworkStatusComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SocialNetworkStatusesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboSocialNetworkStatuses.DisplayMember = "Description"

            'Dim objSocialNetworkStatus As New SocialNetworkStatus

            'objSocialNetworkStatus.Description = New SqlString("")
            'objSocialNetworkStatus.SocialNetworkStatusID = 0

            'Me.cboSocialNetworkStatuses.Items.Add(objSocialNetworkStatus)

            For Each objSocialNetworkStatus As SocialNetworkStatus In Project.SocialNetworkStatuses
                Me.cboSocialNetworkStatuses.Items.Add(objSocialNetworkStatus)
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
    Friend WithEvents cboSocialNetworkStatuses As System.Windows.Forms.ComboBox
    Friend WithEvents lblSocialNetworkStatus As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSocialNetworkStatus = New System.Windows.Forms.Label()
        Me.cboSocialNetworkStatuses = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblSocialNetworkStatus
        '
        Me.lblSocialNetworkStatus.AutoSize = True
        Me.lblSocialNetworkStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblSocialNetworkStatus.Name = "lblSocialNetworkStatus"
        Me.lblSocialNetworkStatus.Size = New System.Drawing.Size(125, 13)
        Me.lblSocialNetworkStatus.TabIndex = 0
        Me.lblSocialNetworkStatus.Text = "Friend/Follow accepted?"
        Me.lblSocialNetworkStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSocialNetworkStatuses
        '
        Me.cboSocialNetworkStatuses.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboSocialNetworkStatuses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSocialNetworkStatuses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSocialNetworkStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocialNetworkStatuses.DropDownWidth = 200
        Me.cboSocialNetworkStatuses.Location = New System.Drawing.Point(130, 0)
        Me.cboSocialNetworkStatuses.Name = "cboSocialNetworkStatuses"
        Me.cboSocialNetworkStatuses.Size = New System.Drawing.Size(161, 21)
        Me.cboSocialNetworkStatuses.TabIndex = 1
        '
        'SocialNetworkStatusComboBox
        '
        Me.Controls.Add(Me.cboSocialNetworkStatuses)
        Me.Controls.Add(Me.lblSocialNetworkStatus)
        Me.Name = "SocialNetworkStatusComboBox"
        Me.Size = New System.Drawing.Size(291, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkStatus" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.SocialNetworkStatus" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSocialNetworkStatus As SocialNetworkStatus
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboSocialNetworkStatuses.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return _
                    CType(cboSocialNetworkStatuses.Items(cboSocialNetworkStatuses.SelectedIndex), SocialNetworkStatus)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboSocialNetworkStatuses.SelectedIndex = 0
            Else
                Dim objSocialNetworkStatus As SocialNetworkStatus
                Dim i As Integer = 0
                For Each objSocialNetworkStatus In cboSocialNetworkStatuses.Items
                    If objSocialNetworkStatus.SocialNetworkStatusID.Value = Value.SocialNetworkStatusID.Value Then
                        cboSocialNetworkStatuses.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkStatus" /> object in the combo box bu
    '''     SocialNetworkStatus ID.
    ''' </summary>
    ''' <value>
    '''     The SocialNetworkStatus ID of the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkStatus" /> in the combo
    '''     box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSocialNetworkStatusID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboSocialNetworkStatuses.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboSocialNetworkStatuses.Items(cboSocialNetworkStatuses.SelectedIndex), SocialNetworkStatus).
                        SocialNetworkStatusID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboSocialNetworkStatuses.SelectedIndex = 0
            Else
                Dim objSocialNetworkStatus As SocialNetworkStatus
                Dim i As Integer = 0
                For Each objSocialNetworkStatus In cboSocialNetworkStatuses.Items
                    If Not objSocialNetworkStatus.SocialNetworkStatusID.IsNull Then
                        If objSocialNetworkStatus.SocialNetworkStatusID.Value = Value Then
                            cboSocialNetworkStatuses.SelectedIndex = i
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
            Return Me.lblSocialNetworkStatus.Text
        End Get
        Set
            Me.lblSocialNetworkStatus.Text = Value
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
                cboSocialNetworkStatuses.Left = 88
                cboSocialNetworkStatuses.Width = Me.Width - cboSocialNetworkStatuses.Left
            Else
                cboSocialNetworkStatuses.Left = 0
                cboSocialNetworkStatuses.Width = Me.Width
            End If
            lblSocialNetworkStatus.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSocialNetworkStatuses.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSocialNetworkStatuses.BackColor = Color.Silver
                Me.cboSocialNetworkStatuses.ForeColor = Color.Black
            Else
                Me.cboSocialNetworkStatuses.BackColor = Color.White
                Me.cboSocialNetworkStatuses.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboSocialNetworkStatuses_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSocialNetworkStatuses.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
