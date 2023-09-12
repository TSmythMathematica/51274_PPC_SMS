'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS RelationshipType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     RelationshipTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS RelationshipType. The combo box is automatically populated with the current project's
'''     avaliable RelationshipTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class RelationshipTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mEntityTypeFilter As Data.Enumerations.tlkpEntityType = 0

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the RelationshipTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        FillList()
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
    Friend WithEvents lblRelationshipType As System.Windows.Forms.Label
    Friend WithEvents cboRelationshipTypes As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblRelationshipType = New System.Windows.Forms.Label
        Me.cboRelationshipTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblRelationshipType
        '
        Me.lblRelationshipType.AutoSize = True
        Me.lblRelationshipType.Location = New System.Drawing.Point(0, 0)
        Me.lblRelationshipType.Name = "lblRelationshipType"
        Me.lblRelationshipType.Size = New System.Drawing.Size(68, 13)
        Me.lblRelationshipType.TabIndex = 0
        Me.lblRelationshipType.Text = "Relationship:"
        Me.lblRelationshipType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboRelationshipTypes
        '
        Me.cboRelationshipTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboRelationshipTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboRelationshipTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRelationshipTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRelationshipTypes.DropDownWidth = 200
        Me.cboRelationshipTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboRelationshipTypes.Name = "cboRelationshipTypes"
        Me.cboRelationshipTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboRelationshipTypes.Sorted = True
        Me.cboRelationshipTypes.TabIndex = 1
        '
        'RelationshipTypeComboBox
        '
        Me.Controls.Add(Me.cboRelationshipTypes)
        Me.Controls.Add(Me.lblRelationshipType)
        Me.Name = "RelationshipTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.RelationshipType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.RelationshipType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedRelationshipType As RelationshipType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboRelationshipTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboRelationshipTypes.Items(cboRelationshipTypes.SelectedIndex), RelationshipType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboRelationshipTypes.SelectedIndex = 0
            Else
                Dim objRelationshipType As RelationshipType
                Dim i As Integer = 0
                For Each objRelationshipType In cboRelationshipTypes.Items
                    If objRelationshipType.RelationshipTypeID.Value = Value.RelationshipTypeID.Value Then
                        cboRelationshipTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.RelationshipType" /> object in the combo box bu
    '''     RelationshipTypeID.
    ''' </summary>
    ''' <value>
    '''     The RelationshipTypeID of the currently selected <see cref="T:MPR.SMS.Data.RelationshipType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedRelationshipTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboRelationshipTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboRelationshipTypes.Items(cboRelationshipTypes.SelectedIndex), RelationshipType).
                        RelationshipTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboRelationshipTypes.SelectedIndex = 0
            Else
                Dim objRelationshipType As RelationshipType
                Dim i As Integer = 0
                For Each objRelationshipType In cboRelationshipTypes.Items
                    If Not objRelationshipType.RelationshipTypeID.IsNull Then
                        If objRelationshipType.RelationshipTypeID.Value = Value Then
                            cboRelationshipTypes.SelectedIndex = i
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
            Return Me.lblRelationshipType.Text
        End Get
        Set
            Me.lblRelationshipType.Text = Value
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
                cboRelationshipTypes.Left = 88
                cboRelationshipTypes.Width = Me.Width - cboRelationshipTypes.Left
            Else
                cboRelationshipTypes.Left = 0
                cboRelationshipTypes.Width = Me.Width
            End If
            lblRelationshipType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboRelationshipTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboRelationshipTypes.BackColor = Color.Silver
                Me.cboRelationshipTypes.ForeColor = Color.Black
            Else
                Me.cboRelationshipTypes.BackColor = Color.White
                Me.cboRelationshipTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

    Public Property EntityTypeFilter As Data.Enumerations.tlkpEntityType
        Get
            Return mEntityTypeFilter
        End Get
        Set
            mEntityTypeFilter = value
            filllist()
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboRelationshipTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboRelationshipTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Private Methods"


    Private Sub FillList()

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            cboRelationshipTypes.Items.Clear()
            Me.cboRelationshipTypes.DisplayMember = "RelationshipType"

            Dim objRelationshipType As New RelationshipType

            objRelationshipType.RelationshipType = New SqlString("")

            'Me.cboRelationshipTypes.Items.Add(objRelationshipType)

            For Each objRelationshipType In Project.RelationshipTypes
                If mEntityTypeFilter = 0 OrElse objRelationshipType.EntityTypeID.IsNull Then
                    Me.cboRelationshipTypes.Items.Add(objRelationshipType)
                ElseIf objRelationshipType.EntityTypeID = mEntityTypeFilter Then
                    Me.cboRelationshipTypes.Items.Add(objRelationshipType)
                End If
            Next

        End If
    End Sub

#End Region
End Class

