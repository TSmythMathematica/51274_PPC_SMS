'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS District auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     DistrictComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS District. The combo box is automatically populated with the current project's
'''     avaliable Districts. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class DistrictComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mintSiteIDFilter As Integer = 0

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the DistrictsComboBox class.
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
    Friend WithEvents cboDistricts As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrict As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblDistrict = New System.Windows.Forms.Label
        Me.cboDistricts = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblDistrict
        '
        Me.lblDistrict.AutoSize = True
        Me.lblDistrict.Location = New System.Drawing.Point(0, 0)
        Me.lblDistrict.Name = "lblDistrict"
        Me.lblDistrict.Size = New System.Drawing.Size(43, 13)
        Me.lblDistrict.TabIndex = 0
        Me.lblDistrict.Text = "District:"
        Me.lblDistrict.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDistricts
        '
        Me.cboDistricts.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboDistricts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboDistricts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDistricts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistricts.DropDownWidth = 200
        Me.cboDistricts.Location = New System.Drawing.Point(88, 0)
        Me.cboDistricts.Name = "cboDistricts"
        Me.cboDistricts.Size = New System.Drawing.Size(144, 21)
        Me.cboDistricts.Sorted = True
        Me.cboDistricts.TabIndex = 1
        '
        'DistrictComboBox
        '
        Me.Controls.Add(Me.cboDistricts)
        Me.Controls.Add(Me.lblDistrict)
        Me.Name = "DistrictComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.District" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.District" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedDistrict As District
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboDistricts.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboDistricts.Items(cboDistricts.SelectedIndex), District)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                If cboDistricts.Items.Count > 0 Then
                    cboDistricts.SelectedIndex = 0
                Else
                    cboDistricts.SelectedIndex = - 1
                End If

            Else
                If cboDistricts.Items.Count = 0 Then FillCombobox()

                Dim objDistrict As District
                Dim i As Integer = 0
                For Each objDistrict In cboDistricts.Items
                    If objDistrict.DistrictID.Value = Value.DistrictID.Value Then
                        cboDistricts.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.District" /> object in the combo box bu District ID.
    ''' </summary>
    ''' <value>
    '''     The District ID of the currently selected <see cref="T:MPR.SMS.Data.District" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedDistrictID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboDistricts.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboDistricts.Items(cboDistricts.SelectedIndex), District).DistrictID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value <= 0 Then
                If cboDistricts.Items.Count > 0 Then cboDistricts.SelectedIndex = 0
            Else
                If cboDistricts.Items.Count = 0 Then FillCombobox()

                Dim objDistrict As District
                Dim i As Integer = 0
                For Each objDistrict In cboDistricts.Items
                    If Not objDistrict.DistrictID.IsNull Then
                        If objDistrict.DistrictID.Value = Value Then
                            cboDistricts.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.Site" /> SiteIDFilter object to filter the list of Districts.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.Site" /> Site ID to filter the Districts by.
    ''' </value>
    ''' <remarks>
    '''     If 0, no filtering is done. All Districts are displayed.
    ''' </remarks>

        <DefaultValue(0)>
    Public Property SiteIDFilter As Integer
        Get
            Return mintSiteIDFilter
        End Get
        Set
            mintSiteIDFilter = value
            If Not Me.DesignMode Then FillCombobox()
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblDistrict.Text
        End Get
        Set
            Me.lblDistrict.Text = Value
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
                cboDistricts.Left = 88
                cboDistricts.Width = Me.Width - cboDistricts.Left
            Else
                cboDistricts.Left = 0
                cboDistricts.Width = Me.Width
            End If
            lblDistrict.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboDistricts.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboDistricts.BackColor = Color.Silver
                Me.cboDistricts.ForeColor = Color.Black
            Else
                Me.cboDistricts.BackColor = Color.White
                Me.cboDistricts.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Clear()

        cboDistricts.Items.Clear()
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboDistricts_DropDown(sender As Object, e As EventArgs) Handles cboDistricts.DropDown

        If cboDistricts.Items.Count = 0 Then FillCombobox()
    End Sub

    Private Sub cboDistricts_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboDistricts.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub DistrictComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load

        'If Not Me.DesignMode Then FillCombobox()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillCombobox()

        cboDistricts.Items.Clear()
        If Project Is Nothing Then Return

        cboDistricts.DisplayMember = "Name"

        Dim objDistricts As New Districts
        If mintSiteIDFilter > 0 Then
            objDistricts = New Districts(mintSiteIDFilter)
        End If
        Dim objDistrict As New District

        'add a blank entry
        objDistrict.Name = New SqlString("")
        cboDistricts.Items.Add(objDistrict)

        For Each objDistrict In objDistricts
            cboDistricts.Items.Add(objDistrict)
        Next
    End Sub

#End Region
End Class
