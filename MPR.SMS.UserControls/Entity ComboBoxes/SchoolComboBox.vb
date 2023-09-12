'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS School auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     SchoolComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS School. The combo box is automatically populated with the current project's
'''     avaliable Schools. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class SchoolComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mintDistrictIDFilter As Integer = 0

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the SchoolsComboBox class.
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
    Friend WithEvents cboSchools As System.Windows.Forms.ComboBox
    Friend WithEvents lblSchool As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblSchool = New System.Windows.Forms.Label
        Me.cboSchools = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblSchool
        '
        Me.lblSchool.AutoSize = True
        Me.lblSchool.Location = New System.Drawing.Point(0, 0)
        Me.lblSchool.Name = "lblSchool"
        Me.lblSchool.Size = New System.Drawing.Size(43, 13)
        Me.lblSchool.TabIndex = 0
        Me.lblSchool.Text = "School:"
        Me.lblSchool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboSchools
        '
        Me.cboSchools.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                      Or System.Windows.Forms.AnchorStyles.Right),
                                     System.Windows.Forms.AnchorStyles)
        Me.cboSchools.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboSchools.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSchools.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSchools.DropDownWidth = 200
        Me.cboSchools.Location = New System.Drawing.Point(88, 0)
        Me.cboSchools.Name = "cboSchools"
        Me.cboSchools.Size = New System.Drawing.Size(144, 21)
        Me.cboSchools.Sorted = True
        Me.cboSchools.TabIndex = 1
        '
        'SchoolComboBox
        '
        Me.Controls.Add(Me.cboSchools)
        Me.Controls.Add(Me.lblSchool)
        Me.Name = "SchoolComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.School" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.School" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedSchool As School
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboSchools.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboSchools.Items(cboSchools.SelectedIndex), School)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                If cboSchools.Items.Count > 0 Then
                    cboSchools.SelectedIndex = 0
                Else
                    cboSchools.SelectedIndex = - 1
                End If

            Else
                If cboSchools.Items.Count = 0 Then FillCombobox()

                Dim objSchool As School
                Dim i As Integer = 0
                For Each objSchool In cboSchools.Items
                    If objSchool.SchoolID.Value = Value.SchoolID.Value Then
                        cboSchools.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.School" /> object in the combo box bu School ID.
    ''' </summary>
    ''' <value>
    '''     The School ID of the currently selected <see cref="T:MPR.SMS.Data.School" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedSchoolID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboSchools.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboSchools.Items(cboSchools.SelectedIndex), School).SchoolID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value <= 0 Then
                If cboSchools.Items.Count > 0 Then cboSchools.SelectedIndex = 0
            Else
                If cboSchools.Items.Count = 0 Then FillCombobox()

                Dim objSchool As School
                Dim i As Integer = 0
                For Each objSchool In cboSchools.Items
                    If Not objSchool.SchoolID.IsNull Then
                        If objSchool.SchoolID.Value = Value Then
                            cboSchools.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.District" /> DistrictIDFilter object to filter the list of schools.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.District" /> District ID to filter the Schools by.
    ''' </value>
    ''' <remarks>
    '''     If 0, no filtering is done. All schools are displayed.
    ''' </remarks>

        <DefaultValue(0)>
    Public Property DistrictIDFilter As Integer
        Get
            Return mintDistrictIDFilter
        End Get
        Set
            mintDistrictIDFilter = value
            If Not Me.DesignMode Then FillCombobox()
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblSchool.Text
        End Get
        Set
            Me.lblSchool.Text = Value
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
                cboSchools.Left = 88
                cboSchools.Width = Me.Width - cboSchools.Left
            Else
                cboSchools.Left = 0
                cboSchools.Width = Me.Width
            End If
            lblSchool.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboSchools.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboSchools.BackColor = Color.Silver
                Me.cboSchools.ForeColor = Color.Black
            Else
                Me.cboSchools.BackColor = Color.White
                Me.cboSchools.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Clear()

        cboSchools.Items.Clear()
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboSchools_DropDown(sender As Object, e As EventArgs) Handles cboSchools.DropDown

        If cboSchools.Items.Count = 0 Then FillCombobox()
    End Sub

    Private Sub cboSchools_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboSchools.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

    Private Sub SchoolComboBox_Load(sender As Object, e As EventArgs) Handles Me.Load

        'If Not Me.DesignMode Then FillCombobox()
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillCombobox()

        cboSchools.Items.Clear()
        If Project Is Nothing Then Return

        cboSchools.DisplayMember = "Name"

        Dim objSchools As New Schools
        If mintDistrictIDFilter > 0 Then
            objSchools = New Schools(mintDistrictIDFilter)
        End If
        Dim objSchool As New School

        'add a blank entry
        objSchool.Name = New SqlString("")
        cboSchools.Items.Add(objSchool)

        For Each objSchool In objSchools
            cboSchools.Items.Add(objSchool)
        Next
    End Sub

#End Region
End Class
