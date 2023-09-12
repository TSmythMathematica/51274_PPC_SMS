'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS Status auto-completion combo box control.
''' </summary>
''' <remarks>
'''     StatusComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS status. The combo box is automatically populated with the current project's
'''     avaliable statuses. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class StatusComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

    Private mFilters As String = ""

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the StatusComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        'AF 02/05/14 - Removed refresh so list isn't filled right away. Need to send a filter or explicitly call refresh to get list populated now. 
        'If Not Project Is Nothing Then
        '    Refresh()
        'End If
    End Sub

#End Region

#Region "Windows Form Designer generated code"

    'StatusComboBox overrides dispose to clean up the component list.

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
    Private WithEvents cboStatuses As System.Windows.Forms.ComboBox
    Private WithEvents lblStatus As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblStatus = New System.Windows.Forms.Label
        Me.cboStatuses = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblStatus
        '
        Me.lblStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                     Or System.Windows.Forms.AnchorStyles.Right),
                                    System.Windows.Forms.AnchorStyles)
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(40, 13)
        Me.lblStatus.TabIndex = 0
        Me.lblStatus.Text = "Status:"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboStatuses
        '
        Me.cboStatuses.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                       Or System.Windows.Forms.AnchorStyles.Right),
                                      System.Windows.Forms.AnchorStyles)
        Me.cboStatuses.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboStatuses.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatuses.DropDownWidth = 350
        Me.cboStatuses.Location = New System.Drawing.Point(88, 0)
        Me.cboStatuses.Name = "cboStatuses"
        Me.cboStatuses.Size = New System.Drawing.Size(144, 21)
        Me.cboStatuses.TabIndex = 1
        '
        'StatusComboBox
        '
        Me.Controls.Add(Me.cboStatuses)
        Me.Controls.Add(Me.lblStatus)
        Me.Name = "StatusComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets the <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Project">Project</see> object that the Address object belongs to.
    ''' </value>

        Public ReadOnly Property Project As Project
        Get
            Return Project.GetInstance()
        End Get
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Status" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.Status" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedStatus As Status
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboStatuses.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboStatuses.Items(cboStatuses.SelectedIndex), Status)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                'If cboStatuses.Items.Count > 0 Then cboStatuses.SelectedIndex = 0
                cboStatuses.SelectedIndex = - 1
            ElseIf Value.Code.ToString.Trim = "" Then
                cboStatuses.SelectedIndex = 0
            Else
                Dim objStatus As Status
                Dim i As Integer = 0
                For Each objStatus In cboStatuses.Items
                    If Not objStatus.Code.IsNull Then
                        If objStatus.Code.Value = Value.Code.Value Then
                            cboStatuses.SelectedIndex = i
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
            Return Me.lblStatus.Text
        End Get
        Set
            Me.lblStatus.Text = Value
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
                cboStatuses.Left = 88
                cboStatuses.Width = Me.Width - cboStatuses.Left
            Else
                cboStatuses.Left = 0
                cboStatuses.Width = Me.Width
            End If
            lblStatus.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboStatuses.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboStatuses.BackColor = Color.LightGray
                Me.cboStatuses.ForeColor = Color.Black
            Else
                Me.cboStatuses.BackColor = Color.White
                Me.cboStatuses.ForeColor = Color.Black
            End If
        End Set
    End Property

    <DefaultValue("")> _
    <Category("Behavior")>
    Public Property Filters As String
        Get
            Return mFilters
        End Get
        Set
            mFilters = value
            FillList()
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboStatuses_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboStatuses.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub cboStatuses_KeyUp(sender As Object, e As KeyEventArgs) Handles cboStatuses.KeyUp

        If e.KeyData = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

#End Region

#Region "Public Methods"

    Public Overrides Sub Refresh()
        MyBase.Refresh()
        FillList()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillList()

        'a simple way to check if we're in runtime or not.  Me.DesignMode doesn't work here in a sub user control.
        If Project Is Nothing Then Return

        Dim strSQL As String = "SELECT * FROM tlkpStatus "
        If mFilters.Length > 0 AndAlso Not mFilters.Substring(0, 5).ToUpper.Equals("WHERE") Then
            strSQL += "WHERE "
        ElseIf mFilters.Length = 0 Then
            strSQL += "WHERE IsActive = 1" _
            'limit to active statuses only. Other callers who pass a filter should do this as well.
        End If
        strSQL += mFilters

        Dim ds As DataSet = SqlHelper.ExecuteDataset(Project.ConnectionString, CommandType.Text, strSQL)

        cboStatuses.Items.Clear()
        cboStatuses.DisplayMember = "DisplayName"

        Dim objStatus As Status

        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            ds.Tables(0).DefaultView.RowFilter = "IsActive = 1" _
            'dbl-check incase the caller didn't do this in their SQL filter.
            For Each dr As DataRow In ds.Tables(0).DefaultView.Table.Rows
                objStatus = New Status(dr)
                cboStatuses.Items.Add(objStatus)
            Next
        End If
    End Sub

#End Region
End Class

