'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS State auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     StateComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS State. The combo box is automatically populated with the current project's
'''     avaliable States. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class StateComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the StatesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboStates.DisplayMember = "DisplayName"

            Dim objStates As New States
            Dim objState As New State

            objState.State = New SqlString("")
            objState.StateName = New SqlString("")
            Me.cboStates.Items.Add(objState)

            For Each objState In objStates
                Me.cboStates.Items.Add(objState)
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
    Friend WithEvents cboStates As System.Windows.Forms.ComboBox
    Friend WithEvents lblState As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblState = New System.Windows.Forms.Label
        Me.cboStates = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(0, 0)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 0
        Me.lblState.Text = "State:"
        Me.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStates
        '
        Me.cboStates.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                     Or System.Windows.Forms.AnchorStyles.Right),
                                    System.Windows.Forms.AnchorStyles)
        Me.cboStates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboStates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStates.DropDownWidth = 200
        Me.cboStates.Location = New System.Drawing.Point(88, 0)
        Me.cboStates.Name = "cboStates"
        Me.cboStates.Size = New System.Drawing.Size(50, 21)
        Me.cboStates.Sorted = True
        Me.cboStates.TabIndex = 1
        '
        'StateComboBox
        '
        Me.Controls.Add(Me.cboStates)
        Me.Controls.Add(Me.lblState)
        Me.Name = "StateComboBox"
        Me.Size = New System.Drawing.Size(138, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.State" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.State" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedState As State
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboStates.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboStates.Items(cboStates.SelectedIndex), State)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboStates.SelectedIndex = 0
            Else
                Dim objState As State
                Dim i As Integer = 0
                For Each objState In cboStates.Items
                    If objState.StateID.Value = Value.StateID.Value Then
                        cboStates.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.State" /> object in the combo box bu State ID.
    ''' </summary>
    ''' <value>
    '''     The State ID of the currently selected <see cref="T:MPR.SMS.Data.State" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedStateID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboStates.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboStates.Items(cboStates.SelectedIndex), State).StateID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value <= 0 Then
                cboStates.SelectedIndex = 0
            Else
                Dim objState As State
                Dim i As Integer = 0
                For Each objState In cboStates.Items
                    If Not objState.StateID.IsNull Then
                        If objState.StateID.Value = Value Then
                            cboStates.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.State" /> object in the combo box by State
    '''     Abbreviation.
    ''' </summary>
    ''' <value>
    '''     The State Abbreviation of the currently selected <see cref="T:MPR.SMS.Data.State" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedStateAbbreviation As String
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.
            If Project Is Nothing Then
                Return "0"
            End If

            If cboStates.SelectedIndex <= 0 Then
                Return "0"
            Else
                Return CType(cboStates.Items(cboStates.SelectedIndex), State).State.ToString
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value = "" Then
                cboStates.SelectedIndex = 0
            Else
                Dim objState As State
                Dim i As Integer = 0
                For Each objState In cboStates.Items
                    If Not objState.State.IsNull Then
                        If objState.State.ToString = Value Then
                            cboStates.SelectedIndex = i
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
            Return Me.lblState.Text
        End Get
        Set
            Me.lblState.Text = Value
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
                cboStates.Left = 88
                cboStates.Width = Me.Width - cboStates.Left
            Else
                cboStates.Left = 0
                cboStates.Width = Me.Width
            End If
            lblState.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboStates.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboStates.BackColor = Color.LightGray
                Me.cboStates.ForeColor = Color.Black
            Else
                Me.cboStates.BackColor = Color.White
                Me.cboStates.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStates.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub cboStates_TextChanged(sender As Object, e As EventArgs) Handles cboStates.TextChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
