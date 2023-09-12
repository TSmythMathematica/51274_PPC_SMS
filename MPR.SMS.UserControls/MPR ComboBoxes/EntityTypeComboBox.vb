'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms

''' <summary>
'''     Represents an SMS EntityTypes auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     EntityTypesComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS EntityType. The combo box is automatically populated with the current project's
'''     avaliable EntityTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class EntityComboBox
    Inherits UserControl

#Region "Private Fields"

    Private mblnEntityAsSampleFilter As Boolean = True
    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the EntityTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        FillEntityTypes()
    End Sub

#End Region

#Region " Windows Form Designer generated code "

    ' EntityTypesComboBox overrides dispose to clean up the component list.

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
    Friend WithEvents lblEntityType As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents cboEntityTypes As AutoCompleteComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboEntityTypes = New MPR.Windows.Forms.AutoCompleteComboBox
        Me.lblEntityType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboEntityTypes
        '
        Me.cboEntityTypes.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboEntityTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboEntityTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboEntityTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEntityTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboEntityTypes.Name = "cboEntityTypes"
        Me.cboEntityTypes.Size = New System.Drawing.Size(115, 21)
        Me.cboEntityTypes.TabIndex = 0
        '
        'lblLanguageType
        '
        Me.lblEntityType.AutoSize = True
        Me.lblEntityType.Location = New System.Drawing.Point(0, 0)
        Me.lblEntityType.Name = "lblLanguageType"
        Me.lblEntityType.Size = New System.Drawing.Size(57, 13)
        Me.lblEntityType.TabIndex = 1
        Me.lblEntityType.Text = "Case type:"
        Me.lblEntityType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EntityComboBox
        '
        Me.Controls.Add(Me.cboEntityTypes)
        Me.Controls.Add(Me.lblEntityType)
        Me.Name = "EntityComboBox"
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
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.EntityType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.EntityType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedEntityType As EntityType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.
            If Project Is Nothing Then
                Return Nothing
            End If

            If cboEntityTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboEntityTypes.Items(cboEntityTypes.SelectedIndex), EntityType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboEntityTypes.SelectedIndex = - 1
            Else
                Dim objEntityType As EntityType
                Dim i As Integer = 0
                For Each objEntityType In cboEntityTypes.Items
                    If objEntityType.EntityTypeID.Value = Value.EntityTypeID.Value Then
                        cboEntityTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.EntityType" /> object in the combo box bu EntityType
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The EntityType ID of the currently selected <see cref="T:MPR.SMS.Data.EntityType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedEntityTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.
            If Project Is Nothing Then
                Return - 1
            End If

            If cboEntityTypes.SelectedIndex = - 1 Then
                Return - 1
            Else
                Return CType(cboEntityTypes.Items(cboEntityTypes.SelectedIndex), EntityType).EntityTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboEntityTypes.SelectedIndex = - 1
            Else
                Dim objEntityType As EntityType
                Dim i As Integer = 0
                For Each objEntityType In cboEntityTypes.Items
                    If Not objEntityType.EntityTypeID.IsNull Then
                        If objEntityType.EntityTypeID.Value = Value Then
                            cboEntityTypes.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property EntityAsSampleFilter As Boolean
        Get

            Return mblnEntityAsSampleFilter
        End Get

        Set
            mblnEntityAsSampleFilter = Value
            FillEntityTypes(mblnEntityAsSampleFilter)
        End Set
    End Property

    Public ReadOnly Property ListCount As Integer
        Get
            Return cboEntityTypes.Items.Count
        End Get
    End Property

    Public Property SelectedIndex As Integer
        Get
            Return cboEntityTypes.SelectedIndex
        End Get
        Set
            cboEntityTypes.SelectedIndex = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return cboEntityTypes.Text
        End Get
        Set
            cboEntityTypes.Text = Value

            Dim i As Integer
            For i = 0 To cboEntityTypes.Items.Count - 1
                If CType(cboEntityTypes.Items(i), EntityType).Description.ToString = Value Then
                    cboEntityTypes.SelectedIndex = i
                    Exit For
                End If
            Next
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblEntityType.Text
        End Get
        Set
            Me.lblEntityType.Text = Value
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
                cboEntityTypes.Left = 88
                cboEntityTypes.Width = Me.Width - cboEntityTypes.Left
            Else
                cboEntityTypes.Left = 0
                cboEntityTypes.Width = Me.Width
            End If
            Me.lblEntityType.Visible = Value
        End Set
    End Property


    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboEntityTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboEntityTypes.BackColor = Color.Silver
                Me.cboEntityTypes.ForeColor = Color.Black
            Else
                Me.cboEntityTypes.BackColor = Color.White
                Me.cboEntityTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboEntityTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboEntityTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Public Methods"

    Public Sub FillEntityTypes(blnEntityAsCase As Boolean)

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboEntityTypes.DisplayMember = "Description"

            Me.cboEntityTypes.Items.Clear()

            Dim objEntityType As New EntityType

            For Each objEntityType In Project.EntityTypes
                If mblnEntityAsSampleFilter = objEntityType.EntityAsSample.Value Then
                    If objEntityType.IsActive Then
                        Me.cboEntityTypes.Items.Add(objEntityType)
                    End If
                End If
            Next

        End If
    End Sub

    Public Sub FillEntityTypes()

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboEntityTypes.DisplayMember = "Description"

            Dim objEntityType As New EntityType

            'objEntityType.Description = New SqlString("")
            'Me.cboEntityTypes.Items.Add(objEntityType)

            For Each objEntityType In Project.EntityTypes
                If objEntityType.IsActive Then
                    Me.cboEntityTypes.Items.Add(objEntityType)
                End If
            Next

        End If
    End Sub

#End Region
End Class

