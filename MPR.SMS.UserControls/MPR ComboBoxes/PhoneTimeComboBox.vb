'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports System.Data.SqlTypes
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS PhoneTime auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     PhoneTimeComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS PhoneTime. The combo box is automatically populated with the current project's
'''     avaliable PhoneTimes. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class PhoneTimeComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the PhoneTimesComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then

            ' Initialize and populate the combo box

            Me.cboPhoneTimes.DisplayMember = "Description"

            Dim objPhoneTime As New PhoneTime

            objPhoneTime.Description = New SqlString("")

            'Me.cboPhoneTimes.Items.Add(objPhoneTime)

            For Each objPhoneTime In Project.PhoneTimes
                Me.cboPhoneTimes.Items.Add(objPhoneTime)
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
    Friend WithEvents cboPhoneTimes As System.Windows.Forms.ComboBox
    Friend WithEvents lblPhoneTime As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblPhoneTime = New System.Windows.Forms.Label
        Me.cboPhoneTimes = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblPhoneTime
        '
        Me.lblPhoneTime.AutoSize = True
        Me.lblPhoneTime.Location = New System.Drawing.Point(0, 0)
        Me.lblPhoneTime.Name = "lblPhoneTime"
        Me.lblPhoneTime.Size = New System.Drawing.Size(63, 13)
        Me.lblPhoneTime.TabIndex = 0
        Me.lblPhoneTime.Text = "Phone time:"
        Me.lblPhoneTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboPhoneTimes
        '
        Me.cboPhoneTimes.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboPhoneTimes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboPhoneTimes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPhoneTimes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPhoneTimes.DropDownWidth = 200
        Me.cboPhoneTimes.Location = New System.Drawing.Point(88, 0)
        Me.cboPhoneTimes.Name = "cboPhoneTimes"
        Me.cboPhoneTimes.Size = New System.Drawing.Size(144, 21)
        Me.cboPhoneTimes.Sorted = True
        Me.cboPhoneTimes.TabIndex = 1
        '
        'PhoneTimeComboBox
        '
        Me.Controls.Add(Me.cboPhoneTimes)
        Me.Controls.Add(Me.lblPhoneTime)
        Me.Name = "PhoneTimeComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.PhoneTime" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.PhoneTime" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedPhoneTime As PhoneTime
        Get

            ' If the global Project is not available, assume we're in the designer and return Nothing.

            If Project Is Nothing Then
                Return Nothing
            End If

            If cboPhoneTimes.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return CType(cboPhoneTimes.Items(cboPhoneTimes.SelectedIndex), PhoneTime)
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value Is Nothing Then
                cboPhoneTimes.SelectedIndex = 0
            Else
                Dim objPhoneTime As PhoneTime
                Dim i As Integer = 0
                For Each objPhoneTime In cboPhoneTimes.Items
                    If objPhoneTime.PhoneTimeID.Value = Value.PhoneTimeID.Value Then
                        cboPhoneTimes.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.PhoneTime" /> object in the combo box bu PhoneTime
    '''     ID.
    ''' </summary>
    ''' <value>
    '''     The PhoneTime ID of the currently selected <see cref="T:MPR.SMS.Data.PhoneTime" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedPhoneTimeID As Integer
        Get

            ' If the global Project is not available, assume we're in the designer and return -1.

            If Project Is Nothing Then
                Return 0
            End If

            If cboPhoneTimes.SelectedIndex < 0 Then
                Return 0
            Else
                Return CType(cboPhoneTimes.Items(cboPhoneTimes.SelectedIndex), PhoneTime).PhoneTimeID.Value
            End If
        End Get

        Set

            ' If the global Project is not available, assume we're in the designer and return.

            If Project Is Nothing Then
                Return
            End If

            If Value < 0 Then
                cboPhoneTimes.SelectedIndex = 0
            Else
                Dim objPhoneTime As PhoneTime
                Dim i As Integer = 0
                For Each objPhoneTime In cboPhoneTimes.Items
                    If Not objPhoneTime.PhoneTimeID.IsNull Then
                        If objPhoneTime.PhoneTimeID.Value = Value Then
                            cboPhoneTimes.SelectedIndex = i
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
            Return Me.lblPhoneTime.Text
        End Get
        Set
            Me.lblPhoneTime.Text = Value
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
                cboPhoneTimes.Left = 88
                cboPhoneTimes.Width = Me.Width - cboPhoneTimes.Left
            Else
                cboPhoneTimes.Left = 0
                cboPhoneTimes.Width = Me.Width
            End If
            lblPhoneTime.Visible = Value
        End Set
    End Property


    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboPhoneTimes.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboPhoneTimes.BackColor = Color.Silver
                Me.cboPhoneTimes.ForeColor = Color.Black
            Else
                Me.cboPhoneTimes.BackColor = Color.White
                Me.cboPhoneTimes.ForeColor = Color.Black
            End If
        End Set
    End Property

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboPhoneTimes_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboPhoneTimes.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
