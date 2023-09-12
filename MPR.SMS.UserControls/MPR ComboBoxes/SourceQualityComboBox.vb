'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS SourceQuality auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SourceQualityComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS SourceQuality. The combo box is automatically populated with the current project's
'''     avaliable SourceQualities. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SourceQualityComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SourceQualitiesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboSourceQualities.DisplayMember = "Description"

            Dim objSourceQuality As New SourceQuality

            objSourceQuality.Description = New SqlString("")

            'Me.cboSourceQualities.Items.Add(objSourceQuality)

            For Each objSourceQuality In Project.SourceQualities
                Me.cboSourceQualities.Items.Add(objSourceQuality)
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
    Friend WithEvents lblSourceQuality As System.Windows.Forms.Label
    Friend WithEvents cboSourceQualities As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSourceQuality = New System.Windows.Forms.Label
        Me.cboSourceQualities = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblSourceQuality
        '
        Me.lblSourceQuality.AutoSize = True
        Me.lblSourceQuality.Location = New System.Drawing.Point(0, 0)
        Me.lblSourceQuality.Name = "lblSourceQuality"
        Me.lblSourceQuality.Size = New System.Drawing.Size(89, 13)
        Me.lblSourceQuality.TabIndex = 0
        Me.lblSourceQuality.Text = "Quality of source:"
        Me.lblSourceQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSourceQualities
        '
        Me.cboSourceQualities.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboSourceQualities.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSourceQualities.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSourceQualities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceQualities.DropDownWidth = 200
        Me.cboSourceQualities.Location = New System.Drawing.Point(88, 0)
        Me.cboSourceQualities.Name = "cboSourceQualities"
        Me.cboSourceQualities.Size = New System.Drawing.Size(144, 21)
        Me.cboSourceQualities.Sorted = True
        Me.cboSourceQualities.TabIndex = 1
        '
        'SourceQualityComboBox
        '
        Me.Controls.Add(Me.cboSourceQualities)
        Me.Controls.Add(Me.lblSourceQuality)
        Me.Name = "SourceQualityComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SourceQuality" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.SourceQuality" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSourceQuality As SourceQuality
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboSourceQualities.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboSourceQualities.Items(cboSourceQualities.SelectedIndex), SourceQuality)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboSourceQualities.SelectedIndex = 0
            Else
                Dim objSourceQuality As SourceQuality
                Dim i As Integer = 0
                For Each objSourceQuality In cboSourceQualities.Items
                    If objSourceQuality.SourceQualityID.Value = Value.SourceQualityID.Value Then
                        cboSourceQualities.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SourceQuality" /> object in the combo box bu
    '''     SourceQuality ID.
    ''' </summary>
    ''' <value>
    '''     The SourceQuality ID of the currently selected <see cref="T:MPR.SMS.Data.SourceQuality" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSourceQualityID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboSourceQualities.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboSourceQualities.Items(cboSourceQualities.SelectedIndex), SourceQuality).SourceQualityID.
                        Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboSourceQualities.SelectedIndex = 0
            Else
                Dim objSourceQuality As SourceQuality
                Dim i As Integer = 0
                For Each objSourceQuality In cboSourceQualities.Items
                    If Not objSourceQuality.SourceQualityID.IsNull Then
                        If objSourceQuality.SourceQualityID.Value = Value Then
                            cboSourceQualities.SelectedIndex = i
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
            Return Me.lblSourceQuality.Text
        End Get
        Set
            Me.lblSourceQuality.Text = Value
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
                cboSourceQualities.Left = 88
                cboSourceQualities.Width = Me.Width - cboSourceQualities.Left
            Else
                cboSourceQualities.Left = 0
                cboSourceQualities.Width = Me.Width
            End If
            lblSourceQuality.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSourceQualities.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSourceQualities.BackColor = Color.LightGray
                Me.cboSourceQualities.ForeColor = Color.Black
            Else
                Me.cboSourceQualities.BackColor = Color.White
                Me.cboSourceQualities.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboSourceQualities_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSourceQualities.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class

