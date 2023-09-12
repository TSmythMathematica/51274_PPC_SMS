'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS SourceType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SourceTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS SourceType. The combo box is automatically populated with the current project's
'''     avaliable SourceTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SourceTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region " Windows Form Designer generated code "

    'Public Sub New()
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call

    'End Sub

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
    Friend WithEvents lblSourceType As System.Windows.Forms.Label
    Friend WithEvents cboSourceTypes As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSourceType = New System.Windows.Forms.Label
        Me.cboSourceTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblSourceType
        '
        Me.lblSourceType.AutoSize = True
        Me.lblSourceType.Location = New System.Drawing.Point(0, 0)
        Me.lblSourceType.Name = "lblSourceType"
        Me.lblSourceType.Size = New System.Drawing.Size(83, 13)
        Me.lblSourceType.TabIndex = 0
        Me.lblSourceType.Text = "Address source:"
        Me.lblSourceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSourceTypes
        '
        Me.cboSourceTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboSourceTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSourceTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSourceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSourceTypes.DropDownWidth = 200
        Me.cboSourceTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboSourceTypes.Name = "cboSourceTypes"
        Me.cboSourceTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboSourceTypes.Sorted = True
        Me.cboSourceTypes.TabIndex = 1
        '
        'SourceTypeComboBox
        '
        Me.Controls.Add(Me.cboSourceTypes)
        Me.Controls.Add(Me.lblSourceType)
        Me.Name = "SourceTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SourceTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboSourceTypes.DisplayMember = "Description"

            Dim objSourceType As New SourceType

            objSourceType.Description = New SqlString("")

            'Me.cboSourceTypes.Items.Add(objSourceType)

            For Each objSourceType In Project.SourceTypes
                Me.cboSourceTypes.Items.Add(objSourceType)
            Next

        End If
    End Sub

#End Region


#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SourceType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.SourceType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSourceType As SourceType
        Get

            If Project Is Nothing Then
                Return Nothing
            End If
            'If cboSourceTypes.SelectedIndex = 0 Or cboSourceTypes.SelectedIndex = -1 Then
            If cboSourceTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboSourceTypes.Items(cboSourceTypes.SelectedIndex), SourceType)
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboSourceTypes.SelectedIndex = 0
            Else
                Dim objSourceType As SourceType
                Dim i As Integer = 0
                For Each objSourceType In cboSourceTypes.Items
                    If objSourceType.SourceTypeID.Value = Value.SourceTypeID.Value Then
                        cboSourceTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SourceType" /> object in the combo box bu SourceType
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The SourceType ID of the currently selected <see cref="T:MPR.SMS.Data.SourceType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSourceTypeID As Integer
        Get
            If Project Is Nothing Then
                Return 0
            End If
            If cboSourceTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboSourceTypes.Items(cboSourceTypes.SelectedIndex), SourceType).SourceTypeID.Value
            End If
        End Get

        Set

            If Project Is Nothing Then
                Return
            End If
            If Value < 0 Then
                cboSourceTypes.SelectedIndex = 0
            Else
                Dim objSourceType As SourceType
                Dim i As Integer = 0
                For Each objSourceType In cboSourceTypes.Items
                    If Not objSourceType.SourceTypeID.IsNull Then
                        If objSourceType.SourceTypeID.Value = Value Then
                            cboSourceTypes.SelectedIndex = i
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
            Return Me.lblSourceType.Text
        End Get
        Set
            Me.lblSourceType.Text = Value
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
                cboSourceTypes.Left = 88
                cboSourceTypes.Width = Me.Width - cboSourceTypes.Left
            Else
                cboSourceTypes.Left = 0
                cboSourceTypes.Width = Me.Width
            End If
            lblSourceType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSourceTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSourceTypes.BackColor = Color.LightGray
                Me.cboSourceTypes.ForeColor = Color.Black
            Else
                Me.cboSourceTypes.BackColor = Color.White
                Me.cboSourceTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboSourceTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSourceTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
