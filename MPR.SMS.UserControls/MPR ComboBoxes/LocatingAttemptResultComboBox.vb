'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************
Imports System.ComponentModel
Imports MPR.SMS.Data

''' <summary>
'''     Represents an SMS LocatingAttemptResult auto-completion combo box control.
''' </summary>
''' <remarks>
'''     Using the <see cref="T:MPR.Windows.Forms.AutoCompleteComboBox" />, the
'''     LocatingAttemptResultComboBox provides a reusable auto-completion combo box control for selecting
'''     an SMS LocatingAttemptResult. The combo box is automatically populated with the current project's
'''     avaliable LocatingAttemptResults. When working with the MPR solution, it is automatically integrated
'''     with Visual Studio .NET allowing drag and drop design from the Toolbox.
'''     working with the MPR solution.
''' </remarks>

    Public Class LocatingAttemptResultComboBox
    Inherits UserControl

#Region "Private fields"

    Private mblnLabelVisible As Boolean = True
    Private mblnReadOnly As Boolean = False
    Private mobjLocatingAttemptType As LocatingAttemptType

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
    Friend WithEvents lblLocatingAttemptResult As System.Windows.Forms.Label
    Friend WithEvents cboLocatingAttemptResults As System.Windows.Forms.ComboBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblLocatingAttemptResult = New System.Windows.Forms.Label
        Me.cboLocatingAttemptResults = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'lblLocatingAttemptResult
        '
        Me.lblLocatingAttemptResult.AutoSize = True
        Me.lblLocatingAttemptResult.Location = New System.Drawing.Point(0, 0)
        Me.lblLocatingAttemptResult.Name = "lblLocatingAttemptResult"
        Me.lblLocatingAttemptResult.Size = New System.Drawing.Size(79, 13)
        Me.lblLocatingAttemptResult.TabIndex = 0
        Me.lblLocatingAttemptResult.Text = "Locating result:"
        Me.lblLocatingAttemptResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboLocatingAttemptResults
        '
        Me.cboLocatingAttemptResults.Anchor =
            CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                   Or System.Windows.Forms.AnchorStyles.Right),
                  System.Windows.Forms.AnchorStyles)
        Me.cboLocatingAttemptResults.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cboLocatingAttemptResults.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocatingAttemptResults.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocatingAttemptResults.DropDownWidth = 200
        Me.cboLocatingAttemptResults.Location = New System.Drawing.Point(88, 0)
        Me.cboLocatingAttemptResults.Name = "cboLocatingAttemptResults"
        Me.cboLocatingAttemptResults.Size = New System.Drawing.Size(144, 21)
        Me.cboLocatingAttemptResults.TabIndex = 1
        '
        'LocatingAttemptResultComboBox
        '
        Me.Controls.Add(Me.cboLocatingAttemptResults)
        Me.Controls.Add(Me.lblLocatingAttemptResult)
        Me.Name = "LocatingAttemptResultComboBox"
        Me.Size = New System.Drawing.Size(232, 24)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

#End Region

#Region "Constructors"

    ''' <summary>
    '''     Initializes a new instance of the LocatingAttemptResultsComboBox class.
    ''' </summary>

        Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.

        InitializeComponent()

        ' If the global Project is not available, assume we're in the designer and skip initialization

        If Not Project Is Nothing Then
            FillList()
        End If
    End Sub

#End Region

#Region "Public Properties"

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptResult" /> object in the combo box.
    ''' </summary>
    ''' <value>
    '''     The currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptResult" /> in the combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, Nothing (null) is returned; the current selection may
    '''     also be set to Nothing (null).
    ''' </remarks>

        Public Property SelectedLocatingAttemptResult As LocatingAttemptResult
        Get
            If Project Is Nothing Then
                Return Nothing
            End If
            If cboLocatingAttemptResults.SelectedIndex = - 1 Then
                Return Nothing
            Else
                Return _
                    CType(cboLocatingAttemptResults.Items(cboLocatingAttemptResults.SelectedIndex),
                          LocatingAttemptResult)
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value Is Nothing Then
                cboLocatingAttemptResults.SelectedIndex = - 1
            Else
                Dim objLocatingAttemptResult As LocatingAttemptResult
                Dim i As Integer = 0
                For Each objLocatingAttemptResult In cboLocatingAttemptResults.Items
                    If objLocatingAttemptResult.LocatingAttemptResultID.Value = Value.LocatingAttemptResultID.Value Then
                        cboLocatingAttemptResults.SelectedIndex = i
                        Exit For
                    End If
                    i = i + 1
                Next
            End If
        End Set
    End Property

    ''' <summary>
    '''     Gets or sets the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptResult" /> object in the combo box by
    '''     LocatingAttemptResultID.
    ''' </summary>
    ''' <value>
    '''     The LocatingAttemptResultID of the currently selected <see cref="T:MPR.SMS.Data.LocatingAttemptResult" /> in the
    '''     combo box.
    ''' </value>
    ''' <remarks>
    '''     If no current selection exits, -1 is returned; and the current selection may be set to
    '''     Nothing (null) by specifying a value of -1.
    ''' </remarks>

        Public Property SelectedLocatingAttemptResultID As Integer
        Get
            If Project Is Nothing Then
                Return 0
            End If

            If cboLocatingAttemptResults.SelectedIndex < 0 Then
                Return 0
            Else
                Return _
                    CType(cboLocatingAttemptResults.Items(cboLocatingAttemptResults.SelectedIndex),
                          LocatingAttemptResult).LocatingAttemptResultID.Value
            End If
        End Get

        Set
            If Project Is Nothing Then
                Return
            End If
            If Value < 0 Then
                cboLocatingAttemptResults.SelectedIndex = 0
            Else
                Dim objLocatingAttemptResult As LocatingAttemptResult
                Dim i As Integer = 0
                For Each objLocatingAttemptResult In cboLocatingAttemptResults.Items
                    If Not objLocatingAttemptResult.LocatingAttemptResultID.IsNull Then
                        If objLocatingAttemptResult.LocatingAttemptResultID.Value = Value Then
                            cboLocatingAttemptResults.SelectedIndex = i
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
            Return Me.lblLocatingAttemptResult.Text
        End Get
        Set
            Me.lblLocatingAttemptResult.Text = Value
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
                cboLocatingAttemptResults.Left = 88
                cboLocatingAttemptResults.Width = Me.Width - cboLocatingAttemptResults.Left
            Else
                cboLocatingAttemptResults.Left = 0
                cboLocatingAttemptResults.Width = Me.Width
            End If
            lblLocatingAttemptResult.Visible = Value
        End Set
    End Property

    <DefaultValue(False)>
    Public Shadows Property [ReadOnly] As Boolean
        Get
            Return mblnReadOnly
        End Get
        Set
            mblnReadOnly = Value
            Me.cboLocatingAttemptResults.Enabled = Not mblnReadOnly
            If mblnReadOnly = True Then
                Me.cboLocatingAttemptResults.BackColor = Color.Silver
                Me.cboLocatingAttemptResults.ForeColor = Color.Black
            Else
                Me.cboLocatingAttemptResults.BackColor = Color.White
                Me.cboLocatingAttemptResults.ForeColor = Color.Black
            End If
        End Set
    End Property

    Public Property LocatingAttemptType As LocatingAttemptType
        Get
            Return mobjLocatingAttemptType
        End Get
        Set
            mobjLocatingAttemptType = value
            FillList()
        End Set
    End Property

#End Region

#Region "Private Methods"

    Private Sub FillList()

        If Project IsNot Nothing Then

            ' Initialize and populate the combo box

            cboLocatingAttemptResults.Items.Clear()
            cboLocatingAttemptResults.DisplayMember = "LocatingAttemptResult"

            Dim objLocatingAttemptResult As New LocatingAttemptResult

            'objLocatingAttemptResult.Description = New SqlString("")
            'Me.cboLocatingAttemptResults.Items.Add(objLocatingAttemptResult)

            For Each objLocatingAttemptResult In Project.LocatingAttemptResults
                If mobjLocatingAttemptType Is Nothing Then
                    Me.cboLocatingAttemptResults.Items.Add(objLocatingAttemptResult)
                Else
                    Dim blnOK As Boolean = True
                    Select Case GetSafeValue(objLocatingAttemptResult.AppliesTo)
                        'Case "N"    'Name
                        '    blnOK = GetSafeValue(mobjLocatingAttemptType.ShowPersonName)
                        Case "A" 'Address/Name
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowAddresses)
                        Case "P" 'Phone
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowPhones)
                        Case "E" 'Email
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowEmails)
                        Case "D" 'Documents
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowAddDocument)
                        Case "R" 'Respondent
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowChangeRespondent)
                        Case "C" 'Case member
                            blnOK = GetSafeValue(mobjLocatingAttemptType.ShowCaseMembers)
                        Case "F" 'Field Interview
                            blnOK = False   'added by nwu to filter out smf specific code
                    End Select
                    If blnOK Then
                        Me.cboLocatingAttemptResults.Items.Add(objLocatingAttemptResult)
                    End If
                End If
            Next
        End If
    End Sub

#End Region

#Region "Events"

    Event SelectedIndexChanged(sender As Object, e As EventArgs)

#End Region

#Region "Event Handlers"

    Private Sub cboLocatingAttemptResults_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles cboLocatingAttemptResults.SelectedIndexChanged

        RaiseEvent SelectedIndexChanged(Me, e)
    End Sub

#End Region
End Class
