'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms

''' <summary>
'''     Represents an SMS ValidationStatus auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     ValidationStatusComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS ValidationStatus. The combo box is automatically populated with the current project's
'''     avaliable ValidationStatus. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class ValidationStatusComboBox
    Inherits UserControl

#Region "Private Fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the ValidationStatusComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        FillValidationStatus()
    End Sub

#End Region

#Region "Windows Form Designer generated code"

    ' ValidationStatusComboBox overrides dispose to clean up the component list.

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
    Friend WithEvents lblValidationStatus As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents cboValidationStatus As AutoCompleteComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboValidationStatus = New MPR.Windows.Forms.AutoCompleteComboBox
        Me.lblValidationStatus = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboValidationStatus
        '
        Me.cboValidationStatus.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboValidationStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboValidationStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboValidationStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboValidationStatus.Location = New System.Drawing.Point(88, 0)
        Me.cboValidationStatus.Name = "cboValidationStatus"
        Me.cboValidationStatus.Size = New System.Drawing.Size(115, 21)
        Me.cboValidationStatus.TabIndex = 0
        '
        'lblValidationStatus
        '
        Me.lblValidationStatus.AutoSize = True
        Me.lblValidationStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblValidationStatus.Name = "lblValidationStatus"
        Me.lblValidationStatus.Size = New System.Drawing.Size(49, 13)
        Me.lblValidationStatus.TabIndex = 1
        Me.lblValidationStatus.Text = "ValidationStatus:"
        Me.lblValidationStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ValidationStatusComboBox
        '
        Me.Controls.Add(Me.cboValidationStatus)
        Me.Controls.Add(Me.lblValidationStatus)
        Me.Name = "ValidationStatusComboBox"
        Me.Size = New System.Drawing.Size(203, 21)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> that the Form object belongs to.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Form object belongs to.
    ''' </value>
    Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ValidationStatus" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.ValidationStatus" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedValidationStatus As ValidationStatus
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.
            If Project Is Nothing Then
                Return Nothing
            End If

            If cboValidationStatus.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboValidationStatus.Items(cboValidationStatus.SelectedIndex), ValidationStatus)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboValidationStatus.SelectedIndex = - 1
            Else
                Dim objValidationStatus As ValidationStatus
                Dim i As Integer = 0
                For Each objValidationStatus In cboValidationStatus.Items
                    If objValidationStatus.StatusID.Value = Value.StatusID.Value Then
                        cboValidationStatus.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ValidationStatus" /> object in the combo box bu
    '''     ValidationStatus ID.
    ''' </summary>
    ''' <value>
    '''     The ValidationStatus ID of the currently selected <see cref="T:MPR.SMS.Data.ValidationStatus" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedValidationStatusID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.
            If Project Is Nothing Then
                Return - 1
            End If

            If cboValidationStatus.SelectedIndex = - 1 Then
                Return - 1
            Else
                Return _
                    CType(cboValidationStatus.Items(cboValidationStatus.SelectedIndex), ValidationStatus).StatusID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboValidationStatus.SelectedIndex = - 1
            Else
                Dim objValidationStatus As ValidationStatus
                Dim i As Integer = 0
                For Each objValidationStatus In cboValidationStatus.Items
                    If Not objValidationStatus.StatusID.IsNull Then
                        If objValidationStatus.StatusID.Value = Value Then
                            cboValidationStatus.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public ReadOnly Property ListCount As Integer
        Get
            Return cboValidationStatus.Items.Count
        End Get
    End Property

    Public Property SelectedIndex As Integer
        Get
            Return cboValidationStatus.SelectedIndex
        End Get
        Set
            cboValidationStatus.SelectedIndex = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return cboValidationStatus.Text
        End Get
        Set
            cboValidationStatus.Text = Value

            Dim i As Integer
            For i = 0 To cboValidationStatus.Items.Count - 1
                If CType(cboValidationStatus.Items(i), ValidationStatus).Description.ToString = Value Then
                    cboValidationStatus.SelectedIndex = i
                    Exit For
                End If
            Next
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblValidationStatus.Text
        End Get
        Set
            Me.lblValidationStatus.Text = Value
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
                cboValidationStatus.Left = 88
                cboValidationStatus.Width = Me.Width - cboValidationStatus.Left
            Else
                cboValidationStatus.Left = 0
                cboValidationStatus.Width = Me.Width
            End If
            Me.lblValidationStatus.Visible = Value
        End Set
    End Property


    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboValidationStatus.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboValidationStatus.BackColor = Color.LightGray
                Me.cboValidationStatus.ForeColor = Color.Black
            Else
                Me.cboValidationStatus.BackColor = Color.White
                Me.cboValidationStatus.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboValidationStatus_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboValidationStatus.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Public Methods"

    Public Sub FillValidationStatus()

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboValidationStatus.DisplayMember = "Description"

            Dim objValidationStatuses As New ValidationStatuses
            Dim objValidationStatus As New ValidationStatus

            For Each objValidationStatus In objValidationStatuses
                Me.cboValidationStatus.Items.Add(objValidationStatus)
            Next

        End If
    End Sub

#End Region
End Class

