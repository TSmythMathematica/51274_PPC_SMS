'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS Mobility auto-completion combo box control.
''' </summary>
''' <remarks>
'''     MobilityComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS Mobility. The combo box is automatically populated with the current project's
'''     avaliable Mobilityes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class MobilityComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the MobilityComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        If Not Me.DesignMode Then
            RefreshMobilityList()
        End If
    End Sub

#End Region

#Region "Windows Form Designer generated code"

    'MobilityComboBox overrides dispose to clean up the component list.

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
    Private WithEvents cboMobilityCodes As System.Windows.Forms.ComboBox
    Public WithEvents lblMobility As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblMobility = New System.Windows.Forms.Label
        Me.cboMobilityCodes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblMobility
        '
        Me.lblMobility.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                       Or System.Windows.Forms.AnchorStyles.Right),
                                      System.Windows.Forms.AnchorStyles)
        Me.lblMobility.AutoSize = True
        Me.lblMobility.Location = New System.Drawing.Point(0, 0)
        Me.lblMobility.Name = "lblMobility"
        Me.lblMobility.Size = New System.Drawing.Size(40, 13)
        Me.lblMobility.TabIndex = 0
        Me.lblMobility.Text = "Mobility:"
        Me.lblMobility.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboMobilityCodes
        '
        Me.cboMobilityCodes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboMobilityCodes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboMobilityCodes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMobilityCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMobilityCodes.DropDownWidth = 350
        Me.cboMobilityCodes.Location = New System.Drawing.Point(88, 0)
        Me.cboMobilityCodes.Name = "cboMobilityCodes"
        Me.cboMobilityCodes.Size = New System.Drawing.Size(144, 21)
        Me.cboMobilityCodes.TabIndex = 1
        '
        'MobilityComboBox
        '
        Me.Controls.Add(Me.cboMobilityCodes)
        Me.Controls.Add(Me.lblMobility)
        Me.Name = "MobilityComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"


    '' <summary>
    ''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Mobility" /> object in the combo box.
    '' </summary>
    '' <value>
    ''     The currently selected <see cref="T:MPR.SMS.Data.Mobility" /> in the combo box.
    '' </value>
    '' <remarks>
    ''     If no current selection exits, Nothing (null) is returned; the current selection may
    ''     also be set to Nothing (null).
    '' </remarks>

    Public Property SelectedMobility As MobilityCode
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboMobilityCodes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboMobilityCodes.Items(cboMobilityCodes.SelectedIndex), MobilityCode)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                If cboMobilityCodes.Items.Count >= 1 Then cboMobilityCodes.SelectedIndex = 0
            ElseIf Value.MobilityCode.ToString.Trim = "" Then
                cboMobilityCodes.SelectedIndex = 0
            Else
                Dim objMobility As MobilityCode
                Dim i As Integer = 0
                For Each objMobility In cboMobilityCodes.Items
                    If Not objMobility.MobilityCode.IsNull Then
                        If objMobility.MobilityCode.Value = Value.MobilityCode.Value Then
                            cboMobilityCodes.SelectedIndex = i
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
            Return Me.lblMobility.Text
        End Get
        Set
            Me.lblMobility.Text = Value
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
                cboMobilityCodes.Left = 88
                cboMobilityCodes.Width = Me.Width - cboMobilityCodes.Left
            Else
                cboMobilityCodes.Left = 0
                cboMobilityCodes.Width = Me.Width
            End If
            lblMobility.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboMobilityCodes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboMobilityCodes.BackColor = Color.Silver
                Me.cboMobilityCodes.ForeColor = Color.Black
            Else
                Me.cboMobilityCodes.BackColor = Color.White
                Me.cboMobilityCodes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboMobilityCodes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboMobilityCodes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub cboMobilityCodes_KeyUp(sender As Object, e As KeyEventArgs) Handles cboMobilityCodes.KeyUp

        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        RefreshMobilityList()
    End Sub

    Private Sub RefreshMobilityList()


        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box
            Me.cboMobilityCodes.Items.Clear()
            Me.cboMobilityCodes.DisplayMember = "DisplayName"

            Dim objMobility As New MobilityCode

            For Each objMobility In Project.MobilityCodes

                Me.cboMobilityCodes.Items.Add(objMobility)

            Next

        End If
    End Sub
End Class

