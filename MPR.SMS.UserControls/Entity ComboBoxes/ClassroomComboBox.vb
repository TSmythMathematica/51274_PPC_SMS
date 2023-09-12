'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS Classroom auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     ClassroomComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS Classroom. The combo box is automatically populated with the current project's
'''     avaliable Classrooms. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class ClassroomComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mintSchoolIDFilter As Integer = 0

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the ClassroomsComboBox class.
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
    Friend WithEvents cboClassrooms As System.Windows.Forms.ComboBox
    Friend WithEvents lblClassroom As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblClassroom = New System.Windows.Forms.Label
        Me.cboClassrooms = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblClassroom
        '
        Me.lblClassroom.AutoSize = True
        Me.lblClassroom.Location = New System.Drawing.Point(0, 0)
        Me.lblClassroom.Name = "lblClassroom"
        Me.lblClassroom.Size = New System.Drawing.Size(58, 13)
        Me.lblClassroom.TabIndex = 0
        Me.lblClassroom.Text = "Classroom:"
        Me.lblClassroom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboClassrooms
        '
        Me.cboClassrooms.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboClassrooms.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboClassrooms.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboClassrooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClassrooms.DropDownWidth = 200
        Me.cboClassrooms.Location = New System.Drawing.Point(88, 0)
        Me.cboClassrooms.Name = "cboClassrooms"
        Me.cboClassrooms.Size = New System.Drawing.Size(144, 21)
        Me.cboClassrooms.Sorted = True
        Me.cboClassrooms.TabIndex = 1
        '
        'ClassroomComboBox
        '
        Me.Controls.Add(Me.cboClassrooms)
        Me.Controls.Add(Me.lblClassroom)
        Me.Name = "ClassroomComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Classroom" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.Classroom" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedClassroom As Classroom
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboClassrooms.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboClassrooms.Items(cboClassrooms.SelectedIndex), Classroom)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If cboClassrooms.Items.Count > 0 Then
                cboClassrooms.SelectedIndex = 0
            Else
                cboClassrooms.SelectedIndex = - 1
            End If
            If Value IsNot Nothing AndAlso Not Value.ClassroomID.IsNull Then
                If cboClassrooms.Items.Count = 0 Then FillCombobox()

                Dim objClassroom As Classroom
                Dim i As Integer = 0
                For Each objClassroom In cboClassrooms.Items
                    If GetSafeValue(objClassroom.ClassroomID) = GetSafeValue(Value.ClassroomID) Then
                        cboClassrooms.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.Classroom" /> object in the combo box bu Classroom
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The Classroom ID of the currently selected <see cref="T:MPR.SMS.Data.Classroom" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedClassroomID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboClassrooms.SelectedIndex <= 0 Then
                Return 0
            Else
                Return CType(cboClassrooms.Items(cboClassrooms.SelectedIndex), Classroom).ClassroomID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            cboClassrooms.SelectedIndex = - 1
            If Value <= 0 Then
                If cboClassrooms.Items.Count > 0 Then cboClassrooms.SelectedIndex = 0
            Else
                If cboClassrooms.Items.Count = 0 Then FillCombobox()

                Dim objClassroom As Classroom
                Dim i As Integer = 0
                For Each objClassroom In cboClassrooms.Items
                    If Not objClassroom.ClassroomID.IsNull Then
                        If objClassroom.ClassroomID.Value = Value Then
                            cboClassrooms.SelectedIndex = i
                            Exit For
                        End If
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the <see cref="T:MPR.SMS.Data.School" /> SchoolIDFilter object to filter the list of Classrooms.
    ''' </summary>
    ''' <value>
    '''     The <see cref="T:MPR.SMS.Data.School" /> School ID to filter the Classrooms by.
    ''' </value>
    ''' <remarks>
    '''     If 0, no filtering is done. All Classrooms are displayed.
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
            Return Me.lblClassroom.Text
        End Get
        Set
            Me.lblClassroom.Text = Value
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
                cboClassrooms.Left = 88
                cboClassrooms.Width = Me.Width - cboClassrooms.Left
            Else
                cboClassrooms.Left = 0
                cboClassrooms.Width = Me.Width
            End If
            lblClassroom.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboClassrooms.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboClassrooms.BackColor = Color.Silver
                Me.cboClassrooms.ForeColor = Color.Black
            Else
                Me.cboClassrooms.BackColor = Color.White
                Me.cboClassrooms.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Public Methods"

    Public Sub Clear()

        cboClassrooms.Items.Clear()
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboClassrooms_DropDown(sender As Object, e As EventArgs) Handles cboClassrooms.DropDown

        If cboClassrooms.Items.Count = 0 Then FillCombobox()
    End Sub

    Private Sub cboClassrooms_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboClassrooms.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region

#Region "Private Methods"

    Private Sub FillCombobox()

        cboClassrooms.Items.Clear()
        If Project Is Nothing Then Return

        cboClassrooms.DisplayMember = "Name"

        Dim objClassrooms As Classrooms
        If mintSchoolIDFilter > 0 Then
            objClassrooms = New Classrooms(New School(mintSchoolIDFilter))
        Else
            objClassrooms = New Classrooms
        End If
        Dim objClassroom As New Classroom

        'add a blank entry
        objClassroom.Name = New SqlString("")
        cboClassrooms.Items.Add(objClassroom)

        For Each objClassroom In objClassrooms
            cboClassrooms.Items.Add(objClassroom)
        Next
    End Sub

#End Region
End Class
