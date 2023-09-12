'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS NoteType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     NoteTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS NoteType. The combo box is automatically populated with the current project's
'''     avaliable NoteTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class NoteTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the NoteTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboNoteTypes.DisplayMember = "Description"

            Dim objNoteType As New NoteType

            objNoteType.Description = New SqlString("")

            'Me.cboNoteTypes.Items.Add(objNoteType)

            For Each objNoteType In Project.NoteTypes
                Me.cboNoteTypes.Items.Add(objNoteType)
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
    Friend WithEvents cboNoteTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblNoteType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblNoteType = New System.Windows.Forms.Label
        Me.cboNoteTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblNoteType
        '
        Me.lblNoteType.AutoSize = True
        Me.lblNoteType.Location = New System.Drawing.Point(0, 0)
        Me.lblNoteType.Name = "lblNoteType"
        Me.lblNoteType.Size = New System.Drawing.Size(64, 13)
        Me.lblNoteType.TabIndex = 0
        Me.lblNoteType.Text = "Note type:"
        Me.lblNoteType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboNoteTypes
        '
        Me.cboNoteTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboNoteTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboNoteTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboNoteTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboNoteTypes.DropDownWidth = 200
        Me.cboNoteTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboNoteTypes.Name = "cboNoteTypes"
        Me.cboNoteTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboNoteTypes.Sorted = True
        Me.cboNoteTypes.TabIndex = 1
        '
        'NoteTypeComboBox
        '
        Me.Controls.Add(Me.cboNoteTypes)
        Me.Controls.Add(Me.lblNoteType)
        Me.Name = "NoteTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.NoteType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.NoteType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedNoteType As NoteType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboNoteTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboNoteTypes.Items(cboNoteTypes.SelectedIndex), NoteType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboNoteTypes.SelectedIndex = 0
            Else
                Dim objNoteType As NoteType
                Dim i As Integer = 0
                For Each objNoteType In cboNoteTypes.Items
                    If objNoteType.NoteTypeID.Value = Value.NoteTypeID.Value Then
                        cboNoteTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.NoteType" /> object in the combo box bu NoteType ID.
    ''' </summary>
    ''' <value>
    '''     The NoteType ID of the currently selected <see cref="T:MPR.SMS.Data.NoteType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedNoteTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboNoteTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboNoteTypes.Items(cboNoteTypes.SelectedIndex), NoteType).NoteTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboNoteTypes.SelectedIndex = 0
            Else
                Dim objNoteType As NoteType
                Dim i As Integer = 0
                For Each objNoteType In cboNoteTypes.Items
                    If Not objNoteType.NoteTypeID.IsNull Then
                        If objNoteType.NoteTypeID.Value = Value Then
                            cboNoteTypes.SelectedIndex = i
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
            Return Me.lblNoteType.Text
        End Get
        Set
            Me.lblNoteType.Text = Value
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
                cboNoteTypes.Left = 88
                cboNoteTypes.Width = Me.Width - cboNoteTypes.Left
            Else
                cboNoteTypes.Left = 0
                cboNoteTypes.Width = Me.Width
            End If
            lblNoteType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboNoteTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboNoteTypes.BackColor = Color.Silver
                Me.cboNoteTypes.ForeColor = Color.Black
            Else
                Me.cboNoteTypes.BackColor = Color.White
                Me.cboNoteTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboNoteTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboNoteTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
