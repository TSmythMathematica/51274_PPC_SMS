'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data
Imports MPR.Windows.Forms

''' <summary>
'''     Represents an SMS DocumentTypes auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     DocumentTypesComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS DocumentType. The combo box is automatically populated with the current project's
'''     avaliable DocumentTypes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class DocumentTypeComboBox
    Inherits UserControl

#Region "Private Fields"

    Private mblnAllowAddFilter As Boolean = True
    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the DocumentTypesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        FillDocumentTypes()
    End Sub

#End Region

#Region " Windows Form Designer generated code "

    ' DocumentTypesComboBox overrides dispose to clean up the component list.

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
    Friend WithEvents lblDocumentType As System.Windows.Forms.Label

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private WithEvents cboDocumentTypes As AutoCompleteComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cboDocumentTypes = New MPR.Windows.Forms.AutoCompleteComboBox
        Me.lblDocumentType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cboDocumentTypes
        '
        Me.cboDocumentTypes.Anchor =
            CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboDocumentTypes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDocumentTypes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDocumentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumentTypes.Location = New System.Drawing.Point(88, 0)
        Me.cboDocumentTypes.Name = "cboDocumentTypes"
        Me.cboDocumentTypes.Size = New System.Drawing.Size(115, 21)
        Me.cboDocumentTypes.TabIndex = 0
        '
        'lblDocumentType
        '
        Me.lblDocumentType.AutoSize = True
        Me.lblDocumentType.Location = New System.Drawing.Point(0, 0)
        Me.lblDocumentType.Name = "lblDocumentType"
        Me.lblDocumentType.Size = New System.Drawing.Size(82, 13)
        Me.lblDocumentType.TabIndex = 1
        Me.lblDocumentType.Text = "Document type:"
        Me.lblDocumentType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DocumentTypeComboBox
        '
        Me.Controls.Add(Me.cboDocumentTypes)
        Me.Controls.Add(Me.lblDocumentType)
        Me.Name = "DocumentTypeComboBox"
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
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.DocumentType" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.DocumentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedDocumentType As DocumentType
        Get
            ' If the global Project is not available, assume we're in the designer and return Nothing.
            If Project Is Nothing Then
                Return Nothing
            End If

            If cboDocumentTypes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboDocumentTypes.Items(cboDocumentTypes.SelectedIndex), DocumentType)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboDocumentTypes.SelectedIndex = - 1
            Else
                Dim objDocumentType As DocumentType
                Dim i As Integer = 0
                For Each objDocumentType In cboDocumentTypes.Items
                    If objDocumentType.DocumentTypeID.Value = Value.DocumentTypeID.Value Then
                        cboDocumentTypes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.DocumentType" /> object in the combo box bu
    '''     DocumentType ID.
    ''' </summary>
    ''' <value>
    '''     The DocumentType ID of the currently selected <see cref="T:MPR.SMS.Data.DocumentType" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedDocumentTypeID As Integer
        Get
            ' If the global Project is not available, assume we're in the designer and return -1.
            If Project Is Nothing Then
                Return - 1
            End If

            If cboDocumentTypes.SelectedIndex = - 1 Then
                Return - 1
            Else
                Return CType(cboDocumentTypes.Items(cboDocumentTypes.SelectedIndex), DocumentType).DocumentTypeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.
            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboDocumentTypes.SelectedIndex = - 1
            Else
                Dim objDocumentType As DocumentType
                Dim i As Integer = 0
                For Each objDocumentType In cboDocumentTypes.Items
                    If Not objDocumentType.DocumentTypeID.IsNull Then
                        If objDocumentType.DocumentTypeID.Value = Value Then
                            cboDocumentTypes.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property AllowAddFilter As Boolean
        Get
            Return mblnAllowAddFilter
        End Get
        Set
            mblnAllowAddFilter = Value
            FillDocumentTypes()
        End Set
    End Property

    Public ReadOnly Property ListCount As Integer
        Get
            Return cboDocumentTypes.Items.Count
        End Get
    End Property

    Public Property SelectedIndex As Integer
        Get
            Return cboDocumentTypes.SelectedIndex
        End Get
        Set
            cboDocumentTypes.SelectedIndex = Value
        End Set
    End Property

    Public Overrides Property Text As String
        Get
            Return cboDocumentTypes.Text
        End Get
        Set
            cboDocumentTypes.Text = Value

            Dim i As Integer
            For i = 0 To cboDocumentTypes.Items.Count - 1
                If CType(cboDocumentTypes.Items(i), DocumentType).Description.ToString = Value Then
                    cboDocumentTypes.SelectedIndex = i
                    Exit For
                End If
            Next
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblDocumentType.Text
        End Get
        Set
            Me.lblDocumentType.Text = Value
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
                cboDocumentTypes.Left = 88
                cboDocumentTypes.Width = Me.Width - cboDocumentTypes.Left
            Else
                cboDocumentTypes.Left = 0
                cboDocumentTypes.Width = Me.Width
            End If
            Me.lblDocumentType.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboDocumentTypes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboDocumentTypes.BackColor = Color.Silver
                Me.cboDocumentTypes.ForeColor = Color.Black
            Else
                Me.cboDocumentTypes.BackColor = Color.White
                Me.cboDocumentTypes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboDocumentTypes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDocumentTypes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Public Methods"

    Public Sub FillDocumentTypes()

        ' If the global Project is not available, assume we're in the designer and skip initialization
        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboDocumentTypes.DisplayMember = "Description"
            Me.cboDocumentTypes.Items.Clear()

            For Each objDocumentType As DocumentType In Project.DocumentTypes
                If objDocumentType.IsActive Then
                    If objDocumentType.AllowOnTheFlyAdd Or AllowAddFilter = False Then
                        Me.cboDocumentTypes.Items.Add(objDocumentType)
                    End If
                End If
            Next

        End If
    End Sub

#End Region
End Class

