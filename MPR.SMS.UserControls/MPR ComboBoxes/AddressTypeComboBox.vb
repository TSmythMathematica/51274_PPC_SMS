'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS AddressType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     AddressTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS AddressType. The combo box is automatically populated with the current project's
'''     avaliable AddressTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class AddressTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the AddressTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboAddressTypes.DisplayMember = "Description"

            Dim objAddressType As New AddressType

            objAddressType.Description = New SqlString("")

            'Me.cboAddressTypes.Items.Add(objAddressType)

            For Each objAddressType In Project.AddressTypes
                Me.cboAddressTypes.Items.Add(objAddressType)
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
    Friend WithEvents cboAddressTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblAddressType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblAddressType = New System.Windows.Forms.Label
        Me.cboAddressTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblAddressType
        '
        Me.lblAddressType.AutoSize = True
        Me.lblAddressType.Location = New System.Drawing.Point(0, 0)
        Me.lblAddressType.Name = "lblAddressType"
        Me.lblAddressType.Size = New System.Drawing.Size(71, 13)
        Me.lblAddressType.TabIndex = 0
        Me.lblAddressType.Text = "Address type:"
        Me.lblAddressType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAddressTypes
        '
        Me.cboAddressTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboAddressTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboAddressTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAddressTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAddressTypes.DropDownWidth = 250
        Me.cboAddressTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboAddressTypes.Name = "cboAddressTypes"
        Me.cboAddressTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboAddressTypes.Sorted = True
        Me.cboAddressTypes.TabIndex = 1
        '
        'AddressTypeComboBox
        '
        Me.Controls.Add(Me.cboAddressTypes)
        Me.Controls.Add(Me.lblAddressType)
        Me.Name = "AddressTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.AddressType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.AddressType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedAddressType As AddressType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboAddressTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboAddressTypes.Items(cboAddressTypes.SelectedIndex), AddressType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboAddressTypes.SelectedIndex = 0
            Else
                Dim objAddressType As AddressType
                Dim i As Integer = 0
                For Each objAddressType In cboAddressTypes.Items
                    If objAddressType.AddressTypeID.Value = Value.AddressTypeID.Value Then
                        cboAddressTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.AddressType" /> object in the combo box bu
    '''     AddressType ID.
    ''' </summary>
    ''' <value>
    '''     The AddressType ID of the currently selected <see cref="T:MPR.SMS.Data.AddressType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedAddressTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboAddressTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboAddressTypes.Items(cboAddressTypes.SelectedIndex), AddressType).AddressTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboAddressTypes.SelectedIndex = 0
            Else
                Dim objAddressType As AddressType
                Dim i As Integer = 0
                For Each objAddressType In cboAddressTypes.Items
                    If Not objAddressType.AddressTypeID.IsNull Then
                        If objAddressType.AddressTypeID.Value = Value Then
                            cboAddressTypes.SelectedIndex = i
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
            Return Me.lblAddressType.Text
        End Get
        Set
            Me.lblAddressType.Text = Value
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
                cboAddressTypes.Left = 88
                cboAddressTypes.Width = Me.Width - cboAddressTypes.Left
            Else
                cboAddressTypes.Left = 0
                cboAddressTypes.Width = Me.Width
            End If
            lblAddressType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboAddressTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboAddressTypes.BackColor = Color.Silver
                Me.cboAddressTypes.ForeColor = Color.Black
            Else
                Me.cboAddressTypes.BackColor = Color.White
                Me.cboAddressTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboAddressTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboAddressTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
