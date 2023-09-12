'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS Site auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SiteComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS Site. The combo box is automatically populated with the current project's
'''     avaliable Sites. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SiteComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SitesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()
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
    Friend WithEvents cboSites As System.Windows.Forms.ComboBox
    Friend WithEvents lblSite As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSite = New System.Windows.Forms.Label
        Me.cboSites = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblSite
        '
        Me.lblSite.AutoSize = True
        Me.lblSite.Location = New System.Drawing.Point(0, 0)
        Me.lblSite.Name = "lblSite"
        Me.lblSite.Size = New System.Drawing.Size(43, 13)
        Me.lblSite.TabIndex = 0
        Me.lblSite.Text = "Site:"
        Me.lblSite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSites
        '
        Me.cboSites.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                    Or System.Windows.Forms.AnchorStyles.Right),
                                   System.Windows.Forms.AnchorStyles)
        Me.cboSites.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSites.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSites.DropDownWidth = 200
        Me.cboSites.Location = New System.Drawing.Point(88, 0)
        Me.cboSites.Name = "cboSites"
        Me.cboSites.Size = New System.Drawing.Size(144, 21)
        Me.cboSites.Sorted = True
        Me.cboSites.TabIndex = 1
        '
        'SiteComboBox
        '
        Me.Controls.Add(Me.cboSites)
        Me.Controls.Add(Me.lblSite)
        Me.Name = "SiteComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Site" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.Site" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSite As Site
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboSites.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboSites.Items(cboSites.SelectedIndex), Site)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                If cboSites.Items.Count > 0 Then
                    cboSites.SelectedIndex = 0
                Else
                    cboSites.SelectedIndex = - 1
                End If

            Else
                If cboSites.Items.Count = 0 Then FillCombobox()

                Dim objSite As Site
                Dim i As Integer = 0
                For Each objSite In cboSites.Items
                    If objSite.SiteID.Value = Value.SiteID.Value Then
                        cboSites.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Site" /> object in the combo box bu Site ID.
    ''' </summary>
    ''' <value>
    '''     The Site ID of the currently selected <see cref="T:MPR.SMS.Data.Site" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSiteID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboSites.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboSites.Items(cboSites.SelectedIndex), Site).SiteID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value <= 0 Then
                If cboSites.Items.Count > 0 Then cboSites.SelectedIndex = 0
            Else
                If cboSites.Items.Count = 0 Then FillCombobox()

                Dim objSite As Site
                Dim i As Integer = 0
                For Each objSite In cboSites.Items
                    If Not objSite.SiteID.IsNull Then
                        If objSite.SiteID.Value = Value Then
                            cboSites.SelectedIndex = i
                            Return
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblSite.Text
        End Get
        Set
            Me.lblSite.Text = Value
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
                cboSites.Left = 88
                cboSites.Width = Me.Width - cboSites.Left
            Else
                cboSites.Left = 0
                cboSites.Width = Me.Width
            End If
            lblSite.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSites.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSites.BackColor = Color.Silver
                Me.cboSites.ForeColor = Color.Black
            Else
                Me.cboSites.BackColor = Color.White
                Me.cboSites.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Clear()

        cboSites.Items.Clear()
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"


    Private Sub cboSites_DropDown(sender As Object, e As EventArgs) Handles cboSites.DropDown

        If cboSites.Items.Count = 0 Then FillCombobox()
    End Sub

    Private Sub cboSites_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSites.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub SiteComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load

        'If Not Me.DesignMode Then FillCombobox()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillCombobox()

        cboSites.Items.Clear()
        If Project Is Nothing Then Return

        cboSites.DisplayMember = "Name"

        Dim objSites As New Sites
        Dim objSite As New Site

        'add a blank entry
        objSite.Name = New SqlString("")
        cboSites.Items.Add(objSite)

        For Each objSite In objSites
            cboSites.Items.Add(objSite)
        Next
    End Sub

#End Region
End Class
