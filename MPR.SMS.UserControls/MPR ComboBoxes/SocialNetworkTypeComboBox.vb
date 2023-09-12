'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS SocialNetworkType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SocialNetworkTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS SocialNetworkType. The combo box is automatically populated with the current project's
'''     avaliable SocialNetworkTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SocialNetworkTypeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SocialNetworkTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboSocialNetworkTypes.DisplayMember = "Description"

            Dim objSocialNetworkType As New SocialNetworkType

            objSocialNetworkType.Description = New SqlString("")

            'Me.cboSocialNetworkTypes.Items.Add(objSocialNetworkType)

            For Each objSocialNetworkType In Project.SocialNetworkTypes
                Me.cboSocialNetworkTypes.Items.Add(objSocialNetworkType)
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
    Friend WithEvents cboSocialNetworkTypes As System.Windows.Forms.ComboBox
    Friend WithEvents lblSocialNetworkType As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSocialNetworkType = New System.Windows.Forms.Label()
        Me.cboSocialNetworkTypes = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'lblSocialNetworkType
        '
        Me.lblSocialNetworkType.AutoSize = True
        Me.lblSocialNetworkType.Location = New System.Drawing.Point(0, 0)
        Me.lblSocialNetworkType.Name = "lblSocialNetworkType"
        Me.lblSocialNetworkType.Size = New System.Drawing.Size(80, 13)
        Me.lblSocialNetworkType.TabIndex = 0
        Me.lblSocialNetworkType.Text = "Social network:"
        Me.lblSocialNetworkType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSocialNetworkTypes
        '
        Me.cboSocialNetworkTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboSocialNetworkTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSocialNetworkTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSocialNetworkTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocialNetworkTypes.DropDownWidth = 200
        Me.cboSocialNetworkTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboSocialNetworkTypes.Name = "cboSocialNetworkTypes"
        Me.cboSocialNetworkTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboSocialNetworkTypes.Sorted = True
        Me.cboSocialNetworkTypes.TabIndex = 1
        '
        'SocialNetworkTypeComboBox
        '
        Me.Controls.Add(Me.cboSocialNetworkTypes)
        Me.Controls.Add(Me.lblSocialNetworkType)
        Me.Name = "SocialNetworkTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.SocialNetworkType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSocialNetworkType As SocialNetworkType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboSocialNetworkTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboSocialNetworkTypes.Items(cboSocialNetworkTypes.SelectedIndex), SocialNetworkType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboSocialNetworkTypes.SelectedIndex = 0
            Else
                Dim objSocialNetworkType As SocialNetworkType
                Dim i As Integer = 0
                For Each objSocialNetworkType In cboSocialNetworkTypes.Items
                    If objSocialNetworkType.SocialNetworkTypeID.Value = Value.SocialNetworkTypeID.Value Then
                        cboSocialNetworkTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkType" /> object in the combo box bu
    '''     SocialNetworkType ID.
    ''' </summary>
    ''' <value>
    '''     The SocialNetworkType ID of the currently selected <see cref="T:MPR.SMS.Data.SocialNetworkType" /> in the combo
    '''     box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSocialNetworkTypeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboSocialNetworkTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboSocialNetworkTypes.Items(cboSocialNetworkTypes.SelectedIndex), SocialNetworkType).
                        SocialNetworkTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboSocialNetworkTypes.SelectedIndex = 0
            Else
                Dim objSocialNetworkType As SocialNetworkType
                Dim i As Integer = 0
                For Each objSocialNetworkType In cboSocialNetworkTypes.Items
                    If Not objSocialNetworkType.SocialNetworkTypeID.IsNull Then
                        If objSocialNetworkType.SocialNetworkTypeID.Value = Value Then
                            cboSocialNetworkTypes.SelectedIndex = i
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
            Return Me.lblSocialNetworkType.Text
        End Get
        Set
            Me.lblSocialNetworkType.Text = Value
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
                cboSocialNetworkTypes.Left = 88
                cboSocialNetworkTypes.Width = Me.Width - cboSocialNetworkTypes.Left
            Else
                cboSocialNetworkTypes.Left = 0
                cboSocialNetworkTypes.Width = Me.Width
            End If
            lblSocialNetworkType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSocialNetworkTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSocialNetworkTypes.BackColor = Color.Silver
                Me.cboSocialNetworkTypes.ForeColor = Color.Black
            Else
                Me.cboSocialNetworkTypes.BackColor = Color.White
                Me.cboSocialNetworkTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboSocialNetworkTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSocialNetworkTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
