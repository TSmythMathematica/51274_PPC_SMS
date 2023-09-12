'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS RaceType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     RaceTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS RaceType. The combo box is automatically populated with the current project's
'''     avaliable RaceTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class RaceTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the RaceTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboRaceTypes.DisplayMember = "Description"

            Dim objRaceType As New RaceType

            objRaceType.Description = New SqlString("")

            'Me.cboRaceTypes.Items.Add(objRaceType)

            For Each objRaceType In Project.RaceTypes
                Me.cboRaceTypes.Items.Add(objRaceType)
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
    Friend WithEvents cboRaceTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblRaceType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboRaceTypes = New System.Windows.Forms.ComboBox
        Me.lblRaceType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboRaceTypes
        '
        Me.cboRaceTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboRaceTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRaceTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRaceTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRaceTypes.DropDownWidth = 200
        Me.cboRaceTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboRaceTypes.Name = "cboRaceTypes"
        Me.cboRaceTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboRaceTypes.Sorted = True
        Me.cboRaceTypes.TabIndex = 1
        '
        'lblRaceType
        '
        Me.lblRaceType.AutoSize = True
        Me.lblRaceType.Location = New System.Drawing.Point(0, 0)
        Me.lblRaceType.Name = "lblRaceType"
        Me.lblRaceType.Size = New System.Drawing.Size(36, 13)
        Me.lblRaceType.TabIndex = 0
        Me.lblRaceType.Text = "Race:"
        Me.lblRaceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RaceTypeComboBox
        '
        Me.Controls.Add(Me.cboRaceTypes)
        Me.Controls.Add(Me.lblRaceType)
        Me.Name = "RaceTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.RaceType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.RaceType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedRaceType As RaceType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboRaceTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboRaceTypes.Items(cboRaceTypes.SelectedIndex), RaceType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboRaceTypes.SelectedIndex = 0
            Else
                Dim objRaceType As RaceType
                Dim i As Integer = 0
                For Each objRaceType In cboRaceTypes.Items
                    If objRaceType.RaceTypeID.Value = Value.RaceTypeID.Value Then
                        cboRaceTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.RaceType" /> object in the combo box by RaceTypeID.
    ''' </summary>
    ''' <value>
    '''     The RaceTypeID of the currently selected <see cref="T:MPR.SMS.Data.RaceType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedRaceTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboRaceTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboRaceTypes.Items(cboRaceTypes.SelectedIndex), RaceType).RaceTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboRaceTypes.SelectedIndex = 0
            Else
                Dim objRaceType As RaceType
                Dim i As Integer = 0
                For Each objRaceType In cboRaceTypes.Items
                    If Not objRaceType.RaceTypeID.IsNull Then
                        If objRaceType.RaceTypeID.Value = Value Then
                            cboRaceTypes.SelectedIndex = i
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
            Return Me.lblRaceType.Text
        End Get
        Set
            Me.lblRaceType.Text = Value
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
                cboRaceTypes.Left = 88
                cboRaceTypes.Width = Me.Width - cboRaceTypes.Left
            Else
                cboRaceTypes.Left = 0
                cboRaceTypes.Width = Me.Width
            End If
            lblRaceType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboRaceTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboRaceTypes.BackColor = Color.Silver
                Me.cboRaceTypes.ForeColor = Color.Black
            Else
                Me.cboRaceTypes.BackColor = Color.White
                Me.cboRaceTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboRaceTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboRaceTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class

