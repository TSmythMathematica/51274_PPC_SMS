'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS Teacher auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     TeacherComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS Teacher. The combo box is automatically populated with the current project's
'''     avaliable Teachers. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class TeacherComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mintSchoolIDFilter As Integer = 0

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the TeachersComboBox class.
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
    Friend WithEvents cboTeachers As System.Windows.Forms.ComboBox
    Friend WithEvents lblTeacher As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTeacher = New System.Windows.Forms.Label
        Me.cboTeachers = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblTeacher
        '
        Me.lblTeacher.AutoSize = True
        Me.lblTeacher.Location = New System.Drawing.Point(0, 0)
        Me.lblTeacher.Name = "lblTeacher"
        Me.lblTeacher.Size = New System.Drawing.Size(58, 13)
        Me.lblTeacher.TabIndex = 0
        Me.lblTeacher.Text = "Teacher:"
        Me.lblTeacher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTeachers
        '
        Me.cboTeachers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                       Or System.Windows.Forms.AnchorStyles.Right),
                                      System.Windows.Forms.AnchorStyles)
        Me.cboTeachers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboTeachers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboTeachers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTeachers.DropDownWidth = 200
        Me.cboTeachers.Location = New System.Drawing.Point(88, 0)
        Me.cboTeachers.Name = "cboTeachers"
        Me.cboTeachers.Size = New System.Drawing.Size(144, 21)
        Me.cboTeachers.Sorted = True
        Me.cboTeachers.TabIndex = 1
        '
        'TeacherComboBox
        '
        Me.Controls.Add(Me.cboTeachers)
        Me.Controls.Add(Me.lblTeacher)
        Me.Name = "TeacherComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Teacher" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.Teacher" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedTeacher As Teacher
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboTeachers.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboTeachers.Items(cboTeachers.SelectedIndex), Teacher)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                If cboTeachers.Items.Count > 0 Then
                    cboTeachers.SelectedIndex = 0
                Else
                    cboTeachers.SelectedIndex = - 1
                End If

            Else
                If cboTeachers.Items.Count = 0 Then FillCombobox()

                Dim objTeacher As Teacher
                Dim i As Integer = 0
                For Each objTeacher In cboTeachers.Items
                    If objTeacher.TeacherID.Value = Value.TeacherID.Value Then
                        cboTeachers.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Teacher" /> object in the combo box bu Teacher ID.
    ''' </summary>
    ''' <value>
    '''     The Teacher ID of the currently selected <see cref="T:MPR.SMS.Data.Teacher" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedTeacherID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboTeachers.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboTeachers.Items(cboTeachers.SelectedIndex), Teacher).TeacherID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value <= 0 Then
                If cboTeachers.Items.Count > 0 Then cboTeachers.SelectedIndex = 0
            Else
                If cboTeachers.Items.Count = 0 Then FillCombobox()

                Dim objTeacher As Teacher
                Dim i As Integer = 0
                For Each objTeacher In cboTeachers.Items
                    If Not objTeacher.TeacherID.IsNull Then
                        If objTeacher.TeacherID.Value = Value Then
                            cboTeachers.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.School" /> SchoolIDFilter object to filter the list of Teachers.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.School" /> School ID to filter the Teachers by.
    ''' </value>
    ''' <remarks>
    '''     If 0, no filtering is done. All Teachers are displayed.
    ''' </remarks>

        <DefaultValue(0)>
    Public Property SchoolIDFilter As Integer
        Get
            Return mintSchoolIDFilter
        End Get
        Set
            mintSchoolIDFilter = value
            If Not Me.DesignMode Then FillCombobox()
        End Set
    End Property

    Public Property MyLabel As String
        Get
            Return Me.lblTeacher.Text
        End Get
        Set
            Me.lblTeacher.Text = Value
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
                cboTeachers.Left = 88
                cboTeachers.Width = Me.Width - cboTeachers.Left
            Else
                cboTeachers.Left = 0
                cboTeachers.Width = Me.Width
            End If
            lblTeacher.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboTeachers.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboTeachers.BackColor = Color.Silver
                Me.cboTeachers.ForeColor = Color.Black
            Else
                Me.cboTeachers.BackColor = Color.White
                Me.cboTeachers.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Clear()

        cboTeachers.Items.Clear()
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboTeachers_DropDown(sender As Object, e As EventArgs) Handles cboTeachers.DropDown

        If cboTeachers.Items.Count = 0 Then FillCombobox()
    End Sub

    Private Sub cboTeachers_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboTeachers.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillCombobox()

        cboTeachers.Items.Clear()
        If Project Is Nothing Then Return

        cboTeachers.DisplayMember = "DisplayName"

        Dim objTeachers As Teachers
        If mintSchoolIDFilter > 0 Then
            objTeachers = New Teachers(New School(mintSchoolIDFilter))
        Else
            objTeachers = New Teachers
        End If
        Dim objTeacher As New Teacher

        'add a blank entry
        'objTeacher.DisplayName = New SqlString("")
        cboTeachers.Items.Add(objTeacher)

        For Each objTeacher In objTeachers
            cboTeachers.Items.Add(objTeacher)
        Next
    End Sub

#End Region
End Class
