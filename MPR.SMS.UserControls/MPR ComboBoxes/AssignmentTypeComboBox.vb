'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS AssignmentType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     AssignmentTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS AssignmentType. The combo box is automatically populated with the current project's
'''     avaliable AssignmentTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class AssignmentTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

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
    Friend WithEvents lblAssignmentType As System.Windows.Forms.Label
    Friend WithEvents cboAssignmentTypes As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblAssignmentType = New System.Windows.Forms.Label
        Me.cboAssignmentTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblAssignmentType
        '
        Me.lblAssignmentType.AutoSize = True
        Me.lblAssignmentType.Location = New System.Drawing.Point(0, 0)
        Me.lblAssignmentType.Name = "lblAssignmentType"
        Me.lblAssignmentType.Size = New System.Drawing.Size(58, 13)
        Me.lblAssignmentType.TabIndex = 0
        Me.lblAssignmentType.Text = "Assignment:"
        Me.lblAssignmentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAssignmentTypes
        '
        Me.cboAssignmentTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboAssignmentTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAssignmentTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssignmentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssignmentTypes.DropDownWidth = 200
        Me.cboAssignmentTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboAssignmentTypes.Name = "cboAssignmentTypes"
        Me.cboAssignmentTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboAssignmentTypes.TabIndex = 1
        '
        'AssignmentTypeComboBox
        '
        Me.Controls.Add(Me.cboAssignmentTypes)
        Me.Controls.Add(Me.lblAssignmentType)
        Me.Name = "AssignmentTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the AssignmentTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboAssignmentTypes.DisplayMember = "Description"

            Dim objAssignmentType As New AssignmentType

            'objAssignmentType.Description = New SqlString("")
            'Me.cboAssignmentTypes.Items.Add(objAssignmentType)

            For Each objAssignmentType In Project.AssignmentTypes
                Me.cboAssignmentTypes.Items.Add(objAssignmentType)
            Next

        End If
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedAssignmentType As AssignmentType
        Get
            If Project Is Nothing Then
                Return Nothing
            End If
            If cboAssignmentTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboAssignmentTypes.Items(cboAssignmentTypes.SelectedIndex), AssignmentType)
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value Is Nothing Then
                cboAssignmentTypes.SelectedIndex = - 1
            Else
                Dim objAssignmentType As AssignmentType
                Dim i As Integer = 0
                For Each objAssignmentType In cboAssignmentTypes.Items
                    If objAssignmentType.AssignmentID.Value = Value.AssignmentID.Value Then
                        cboAssignmentTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> object in the combo box by
    '''     AssignmentTypeID.
    ''' </summary>
    ''' <value>
    '''     The AssignmentTypeID of the currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedAssignmentTypeID As Integer
        Get
            If Project Is Nothing Then
                Return 0
            End If

            If cboAssignmentTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboAssignmentTypes.Items(cboAssignmentTypes.SelectedIndex), AssignmentType).AssignmentID.Value
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value < 0 Then
                cboAssignmentTypes.SelectedIndex = 0
            Else
                Dim objAssignmentType As AssignmentType
                Dim i As Integer = 0
                For Each objAssignmentType In cboAssignmentTypes.Items
                    If Not objAssignmentType.AssignmentID.IsNull Then
                        If objAssignmentType.AssignmentID.Value = Value Then
                            cboAssignmentTypes.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> object in the combo box by
    '''     AssignmentCode.
    ''' </summary>
    ''' <value>
    '''     The AssignmentCode of the currently selected <see cref="T:MPR.SMS.Data.AssignmentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedAssignmentCode As String
        Get
            If Project Is Nothing Then
                Return "0"
            End If

            If cboAssignmentTypes.SelectedIndex < 0 Then
                Return "0"
            Else
                Return CType(cboAssignmentTypes.Items(cboAssignmentTypes.SelectedIndex), AssignmentType).Code.Value
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value = "" Then
                cboAssignmentTypes.SelectedIndex = - 1
            Else
                Dim objAssignmentType As AssignmentType
                Dim i As Integer = 0
                For Each objAssignmentType In cboAssignmentTypes.Items
                    If Not objAssignmentType.AssignmentID.IsNull Then
                        If objAssignmentType.Code.Value = Value Then
                            cboAssignmentTypes.SelectedIndex = i
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
            Return Me.lblAssignmentType.Text
        End Get
        Set
            Me.lblAssignmentType.Text = Value
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
                cboAssignmentTypes.Left = 88
                cboAssignmentTypes.Width = Me.Width - cboAssignmentTypes.Left
            Else
                cboAssignmentTypes.Left = 0
                cboAssignmentTypes.Width = Me.Width
            End If
            lblAssignmentType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboAssignmentTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboAssignmentTypes.BackColor = DefaultBackColor
                Me.cboAssignmentTypes.ForeColor = Color.Black
            Else
                Me.cboAssignmentTypes.BackColor = Color.White
                Me.cboAssignmentTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboAssignmentTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboAssignmentTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
