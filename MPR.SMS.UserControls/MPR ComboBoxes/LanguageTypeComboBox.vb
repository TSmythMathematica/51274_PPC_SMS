'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS LanguageType auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     LanguageTypeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS LanguageType. The combo box is automatically populated with the current project's
'''     avaliable LanguageTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class LanguageTypeComboBox
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
    Friend WithEvents lblLanguageType As System.Windows.Forms.Label
    Friend WithEvents cboLanguageTypes As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblLanguageType = New System.Windows.Forms.Label
        Me.cboLanguageTypes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblLanguageType
        '
        Me.lblLanguageType.AutoSize = True
        Me.lblLanguageType.Location = New System.Drawing.Point(0, 0)
        Me.lblLanguageType.Name = "lblLanguageType"
        Me.lblLanguageType.Size = New System.Drawing.Size(58, 13)
        Me.lblLanguageType.TabIndex = 0
        Me.lblLanguageType.Text = "Language:"
        Me.lblLanguageType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLanguageTypes
        '
        Me.cboLanguageTypes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboLanguageTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboLanguageTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLanguageTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLanguageTypes.DropDownWidth = 200
        Me.cboLanguageTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboLanguageTypes.Name = "cboLanguageTypes"
        Me.cboLanguageTypes.Size = New System.Drawing.Size(144, 21)
        Me.cboLanguageTypes.TabIndex = 1
        '
        'LanguageTypeComboBox
        '
        Me.Controls.Add(Me.cboLanguageTypes)
        Me.Controls.Add(Me.lblLanguageType)
        Me.Name = "LanguageTypeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the LanguageTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboLanguageTypes.DisplayMember = "Description"

            Dim objLanguageType As New LanguageType

            objLanguageType.Description = New SqlString("")

            'Me.cboLanguageTypes.Items.Add(objLanguageType)

            For Each objLanguageType In Project.LanguageTypes
                Me.cboLanguageTypes.Items.Add(objLanguageType)
            Next

        End If
    End Sub

#End Region


#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LanguageType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.LanguageType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedLanguageType As LanguageType
        Get
            If Project Is Nothing Then
                Return Nothing
            End If
            If cboLanguageTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboLanguageTypes.Items(cboLanguageTypes.SelectedIndex), LanguageType)
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value Is Nothing Then
                cboLanguageTypes.SelectedIndex = 0
            Else
                Dim objLanguageType As LanguageType
                Dim i As Integer = 0
                For Each objLanguageType In cboLanguageTypes.Items
                    If objLanguageType.LanguageTypeID.Value = Value.LanguageTypeID.Value Then
                        cboLanguageTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LanguageType" /> object in the combo box bu
    '''     LanguageType ID.
    ''' </summary>
    ''' <value>
    '''     The LanguageTypeID of the currently selected <see cref="T:MPR.SMS.Data.LanguageType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedLanguageTypeID As Integer
        Get
            If Project Is Nothing Then
                Return 0
            End If

            If cboLanguageTypes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboLanguageTypes.Items(cboLanguageTypes.SelectedIndex), LanguageType).LanguageTypeID.Value
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value < 0 Then
                cboLanguageTypes.SelectedIndex = 0
            Else
                Dim objLanguageType As LanguageType
                Dim i As Integer = 0
                For Each objLanguageType In cboLanguageTypes.Items
                    If Not objLanguageType.LanguageTypeID.IsNull Then
                        If objLanguageType.LanguageTypeID.Value = Value Then
                            cboLanguageTypes.SelectedIndex = i
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
            Return Me.lblLanguageType.Text
        End Get
        Set
            Me.lblLanguageType.Text = Value
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
                cboLanguageTypes.Left = 88
                cboLanguageTypes.Width = Me.Width - cboLanguageTypes.Left
            Else
                cboLanguageTypes.Left = 0
                cboLanguageTypes.Width = Me.Width
            End If
            lblLanguageType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboLanguageTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboLanguageTypes.BackColor = Color.Silver
                Me.cboLanguageTypes.ForeColor = Color.Black
            Else
                Me.cboLanguageTypes.BackColor = Color.White
                Me.cboLanguageTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboLanguageTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLanguageTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
