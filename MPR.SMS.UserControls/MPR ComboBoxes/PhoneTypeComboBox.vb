'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS PhoneType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     PhoneTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS PhoneType. The combo box is automatically populated with the current project's
'''     avaliable PhoneTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class PhoneTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the PhoneTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboPhoneTypes.DisplayMember = "Description"

            Dim objPhoneType As New PhoneType

            objPhoneType.Description = New SqlString("")

            'Me.cboPhoneTypes.Items.Add(objPhoneType)

            For Each objPhoneType In Project.PhoneTypes
                Me.cboPhoneTypes.Items.Add(objPhoneType)
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
    Friend WithEvents cboPhoneTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblPhoneType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblPhoneType = New System.Windows.Forms.Label
        Me.cboPhoneTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblPhoneType
        '
        Me.lblPhoneType.AutoSize = True
        Me.lblPhoneType.Location = New System.Drawing.Point(0, 0)
        Me.lblPhoneType.Name = "lblPhoneType"
        Me.lblPhoneType.Size = New System.Drawing.Size(64, 13)
        Me.lblPhoneType.TabIndex = 0
        Me.lblPhoneType.Text = "Phone type:"
        Me.lblPhoneType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPhoneTypes
        '
        Me.cboPhoneTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboPhoneTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPhoneTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhoneTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPhoneTypes.DropDownWidth = 200
        Me.cboPhoneTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboPhoneTypes.Name = "cboPhoneTypes"
        Me.cboPhoneTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboPhoneTypes.Sorted = True
        Me.cboPhoneTypes.TabIndex = 1
        '
        'PhoneTypeComboBox
        '
        Me.Controls.Add(Me.cboPhoneTypes)
        Me.Controls.Add(Me.lblPhoneType)
        Me.Name = "PhoneTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.PhoneType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.PhoneType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedPhoneType As PhoneType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboPhoneTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboPhoneTypes.Items(cboPhoneTypes.SelectedIndex), PhoneType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboPhoneTypes.SelectedIndex = 0
            Else
                Dim objPhoneType As PhoneType
                Dim i As Integer = 0
                For Each objPhoneType In cboPhoneTypes.Items
                    If objPhoneType.PhoneTypeID.Value = Value.PhoneTypeID.Value Then
                        cboPhoneTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.PhoneType" /> object in the combo box bu PhoneType
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The PhoneType ID of the currently selected <see cref="T:MPR.SMS.Data.PhoneType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedPhoneTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboPhoneTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboPhoneTypes.Items(cboPhoneTypes.SelectedIndex), PhoneType).PhoneTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboPhoneTypes.SelectedIndex = 0
            Else
                Dim objPhoneType As PhoneType
                Dim i As Integer = 0
                For Each objPhoneType In cboPhoneTypes.Items
                    If Not objPhoneType.PhoneTypeID.IsNull Then
                        If objPhoneType.PhoneTypeID.Value = Value Then
                            cboPhoneTypes.SelectedIndex = i
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
            Return Me.lblPhoneType.Text
        End Get
        Set
            Me.lblPhoneType.Text = Value
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
                cboPhoneTypes.Left = 88
                cboPhoneTypes.Width = Me.Width - cboPhoneTypes.Left
            Else
                cboPhoneTypes.Left = 0
                cboPhoneTypes.Width = Me.Width
            End If
            lblPhoneType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboPhoneTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboPhoneTypes.BackColor = Color.Silver
                Me.cboPhoneTypes.ForeColor = Color.Black
            Else
                Me.cboPhoneTypes.BackColor = Color.White
                Me.cboPhoneTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboPhoneTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboPhoneTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
