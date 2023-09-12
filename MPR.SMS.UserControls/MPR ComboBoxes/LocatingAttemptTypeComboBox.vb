'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS LocatingAttemptType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     LocatingAttemptTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS LocatingAttemptType. The combo box is automatically populated with the current project's
'''     avaliable LocatingAttemptTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class LocatingAttemptTypeComboBox
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
    Friend WithEvents lblLocatingAttemptType As System.Windows.Forms.Label
    Friend WithEvents cboLocatingAttemptTypes As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblLocatingAttemptType = New System.Windows.Forms.Label
        Me.cboLocatingAttemptTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblLocatingAttemptType
        '
        Me.lblLocatingAttemptType.AutoSize = True
        Me.lblLocatingAttemptType.Location = New System.Drawing.Point(0, 0)
        Me.lblLocatingAttemptType.Name = "lblLocatingAttemptType"
        Me.lblLocatingAttemptType.Size = New System.Drawing.Size(74, 13)
        Me.lblLocatingAttemptType.TabIndex = 0
        Me.lblLocatingAttemptType.Text = "Locating type:"
        Me.lblLocatingAttemptType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLocatingAttemptTypes
        '
        Me.cboLocatingAttemptTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboLocatingAttemptTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboLocatingAttemptTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocatingAttemptTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocatingAttemptTypes.DropDownWidth = 200
        Me.cboLocatingAttemptTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboLocatingAttemptTypes.Name = "cboLocatingAttemptTypes"
        Me.cboLocatingAttemptTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboLocatingAttemptTypes.TabIndex = 1
        '
        'LocatingAttemptTypeComboBox
        '
        Me.Controls.Add(Me.cboLocatingAttemptTypes)
        Me.Controls.Add(Me.lblLocatingAttemptType)
        Me.Name = "LocatingAttemptTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the LocatingAttemptTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboLocatingAttemptTypes.DisplayMember = "LocatingAttemptType"

            Dim objLocatingAttemptType As New LocatingAttemptType

            'objLocatingAttemptType.Description = New SqlString("")
            'Me.cboLocatingAttemptTypes.Items.Add(objLocatingAttemptType)

            For Each objLocatingAttemptType In Project.LocatingAttemptTypes
                Me.cboLocatingAttemptTypes.Items.Add(objLocatingAttemptType)
            Next

        End If
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedLocatingAttemptType As LocatingAttemptType
        Get
            If Project Is Nothing Then
                Return Nothing
            End If
            If cboLocatingAttemptTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboLocatingAttemptTypes.Items(cboLocatingAttemptTypes.SelectedIndex), LocatingAttemptType)
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value Is Nothing Then
                cboLocatingAttemptTypes.SelectedIndex = - 1
            Else
                Dim objLocatingAttemptType As LocatingAttemptType
                Dim i As Integer = 0
                For Each objLocatingAttemptType In cboLocatingAttemptTypes.Items
                    If objLocatingAttemptType.LocatingAttemptTypeID.Value = Value.LocatingAttemptTypeID.Value Then
                        cboLocatingAttemptTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptType" /> object in the combo box by
    '''     LocatingAttemptTypeID.
    ''' </summary>
    ''' <value>
    '''     The LocatingAttemptTypeID of the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptType" /> in the combo
    '''     box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedLocatingAttemptTypeID As Integer
        Get
            If Project Is Nothing Then
                Return 0
            End If

            If cboLocatingAttemptTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboLocatingAttemptTypes.Items(cboLocatingAttemptTypes.SelectedIndex), LocatingAttemptType).
                        LocatingAttemptTypeID.Value
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value < 0 Then
                cboLocatingAttemptTypes.SelectedIndex = 0
            Else
                Dim objLocatingAttemptType As LocatingAttemptType
                Dim i As Integer = 0
                For Each objLocatingAttemptType In cboLocatingAttemptTypes.Items
                    If Not objLocatingAttemptType.LocatingAttemptTypeID.IsNull Then
                        If objLocatingAttemptType.LocatingAttemptTypeID.Value = Value Then
                            cboLocatingAttemptTypes.SelectedIndex = i
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
            Return Me.lblLocatingAttemptType.Text
        End Get
        Set
            Me.lblLocatingAttemptType.Text = Value
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
                cboLocatingAttemptTypes.Left = 88
                cboLocatingAttemptTypes.Width = Me.Width - cboLocatingAttemptTypes.Left
            Else
                cboLocatingAttemptTypes.Left = 0
                cboLocatingAttemptTypes.Width = Me.Width
            End If
            lblLocatingAttemptType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboLocatingAttemptTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboLocatingAttemptTypes.BackColor = Color.Silver
                Me.cboLocatingAttemptTypes.ForeColor = Color.Black
            Else
                Me.cboLocatingAttemptTypes.BackColor = Color.White
                Me.cboLocatingAttemptTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboLocatingAttemptTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLocatingAttemptTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
