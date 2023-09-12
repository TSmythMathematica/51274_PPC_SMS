'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms

''' <summary>
'''     Represents an SMS ConsentTypes auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     ConsentTypesComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS ConsentType. The combo box is automatically populated with the current project's
'''     avaliable ConsentTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class ConsentComboBox
    Inherits UserControl

#Region "Private Fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the ConsentTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        FillConsentTypes()
    End Sub

#End Region

#Region "Windows Form Designer generated code"

    ' ConsentTypesComboBox overrides dispose to clean up the component list.

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
    Friend WithEvents lblConsentType As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents cboConsentTypes As AutoCompleteComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboConsentTypes = New MPR.Windows.Forms.AutoCompleteComboBox
        Me.lblConsentType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboConsentTypes
        '
        Me.cboConsentTypes.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboConsentTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboConsentTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConsentTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboConsentTypes.Name = "cboConsentTypes"
        Me.cboConsentTypes.Size = New System.Drawing.Size(115, 21)
        Me.cboConsentTypes.TabIndex = 0
        '
        'lblConsentType
        '
        Me.lblConsentType.AutoSize = True
        Me.lblConsentType.Location = New System.Drawing.Point(0, 0)
        Me.lblConsentType.Name = "lblConsentType"
        Me.lblConsentType.Size = New System.Drawing.Size(49, 13)
        Me.lblConsentType.TabIndex = 1
        Me.lblConsentType.Text = "Consent:"
        Me.lblConsentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ConsentComboBox
        '
        Me.Controls.Add(Me.cboConsentTypes)
        Me.Controls.Add(Me.lblConsentType)
        Me.Name = "ConsentComboBox"
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
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ConsentType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.ConsentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedConsentType As ConsentType
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.
            If Project Is Nothing Then
                Return Nothing
            End If

            If cboConsentTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboConsentTypes.Items(cboConsentTypes.SelectedIndex), ConsentType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboConsentTypes.SelectedIndex = - 1
            Else
                Dim objConsentType As ConsentType
                Dim i As Integer = 0
                For Each objConsentType In cboConsentTypes.Items
                    If objConsentType.ConsentID.Value = Value.ConsentID.Value Then
                        cboConsentTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.ConsentType" /> object in the combo box bu
    '''     ConsentType ID.
    ''' </summary>
    ''' <value>
    '''     The ConsentType ID of the currently selected <see cref="T:MPR.SMS.Data.ConsentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedConsentID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.
            If Project Is Nothing Then
                Return - 1
            End If

            If cboConsentTypes.SelectedIndex = - 1 Then
                Return - 1
            Else
                Return CType(cboConsentTypes.Items(cboConsentTypes.SelectedIndex), ConsentType).ConsentID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboConsentTypes.SelectedIndex = - 1
            Else
                Dim objConsentType As ConsentType
                Dim i As Integer = 0
                For Each objConsentType In cboConsentTypes.Items
                    If Not objConsentType.ConsentID.IsNull Then
                        If objConsentType.ConsentID.Value = Value Then
                            cboConsentTypes.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public ReadOnly Property ListCount As Integer
        Get
            Return cboConsentTypes.Items.Count
        End Get
    End Property

    Public Property SelectedIndex As Integer
        Get
            Return cboConsentTypes.SelectedIndex
        End Get
        Set
            cboConsentTypes.SelectedIndex = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return cboConsentTypes.Text
        End Get
        Set
            cboConsentTypes.Text = Value

            Dim i As Integer
            For i = 0 To cboConsentTypes.Items.Count - 1
                If CType(cboConsentTypes.Items(i), ConsentType).Description.ToString = Value Then
                    cboConsentTypes.SelectedIndex = i
                    Exit For
                End If
            Next
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblConsentType.Text
        End Get
        Set
            Me.lblConsentType.Text = Value
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
                cboConsentTypes.Left = 88
                cboConsentTypes.Width = Me.Width - cboConsentTypes.Left
            Else
                cboConsentTypes.Left = 0
                cboConsentTypes.Width = Me.Width
            End If
            Me.lblConsentType.Visible = Value
        End Set
    End Property


    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboConsentTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboConsentTypes.BackColor = Color.Silver
                Me.cboConsentTypes.ForeColor = Color.Black
            Else
                Me.cboConsentTypes.BackColor = Color.White
                Me.cboConsentTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboConsentTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboConsentTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Public Methods"

    Public Sub FillConsentTypes()

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboConsentTypes.DisplayMember = "Description"

            Dim objConsentType As New ConsentType

            For Each objConsentType In Project.ConsentTypes
                Me.cboConsentTypes.Items.Add(objConsentType)
            Next

        End If
    End Sub

#End Region
End Class

