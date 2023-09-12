'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AddDocument
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddDocument))
        Me.lblDoc1 = New System.Windows.Forms.Label()
        Me.lblDoc2 = New System.Windows.Forms.Label()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ViewCaseMembers = New MPR.SMS.UserControls.ViewCaseMembers()
        Me.ViewCaseAddresses = New MPR.SMS.UserControls.ViewCaseAddresses()
        Me.cboDocumentType = New MPR.SMS.UserControls.DocumentTypeComboBox()
        Me.DocTypeValidator = New MPR.Windows.Forms.Validation.CustomValidator()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DocTypeValidator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDoc1
        '
        Me.lblDoc1.AutoSize = True
        Me.lblDoc1.Location = New System.Drawing.Point(6, 4)
        Me.lblDoc1.Name = "lblDoc1"
        Me.lblDoc1.Size = New System.Drawing.Size(127, 13)
        Me.lblDoc1.TabIndex = 0
        Me.lblDoc1.Text = "Send this document type:"
        '
        'lblDoc2
        '
        Me.lblDoc2.AutoSize = True
        Me.lblDoc2.Location = New System.Drawing.Point(6, 32)
        Me.lblDoc2.Name = "lblDoc2"
        Me.lblDoc2.Size = New System.Drawing.Size(138, 13)
        Me.lblDoc2.TabIndex = 3
        Me.lblDoc2.Text = "To this person and address:"
        '
        'btnPreview
        '
        Me.btnPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreview.Enabled = False
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(437, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 21)
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 48)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ViewCaseMembers)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.ViewCaseAddresses)
        Me.SplitContainer1.Size = New System.Drawing.Size(509, 339)
        Me.SplitContainer1.SplitterDistance = 169
        Me.SplitContainer1.TabIndex = 4
        '
        'ViewCaseMembers
        '
        Me.ViewCaseMembers.AllowAdd = False
        Me.ViewCaseMembers.AllowEdit = False
        Me.ViewCaseMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseMembers.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseMembers.Name = "ViewCaseMembers"
        Me.ViewCaseMembers.SelectedCase = Nothing
        Me.ViewCaseMembers.SelectedPerson = Nothing
        Me.ViewCaseMembers.ShowContacts = False
        Me.ViewCaseMembers.Size = New System.Drawing.Size(509, 169)
        Me.ViewCaseMembers.TabIndex = 0
        '
        'ViewCaseAddresses
        '
        Me.ViewCaseAddresses.AllowAdd = False
        Me.ViewCaseAddresses.AllowEdit = False
        Me.ViewCaseAddresses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewCaseAddresses.Location = New System.Drawing.Point(0, 0)
        Me.ViewCaseAddresses.Name = "ViewCaseAddresses"
        Me.ViewCaseAddresses.SelectedAddress = Nothing
        Me.ViewCaseAddresses.SelectedCase = Nothing
        Me.ViewCaseAddresses.SelectedPerson = Nothing
        Me.ViewCaseAddresses.Size = New System.Drawing.Size(509, 166)
        Me.ViewCaseAddresses.TabIndex = 0
        '
        'cboDocumentType
        '
        Me.cboDocumentType.AllowAddFilter = True
        Me.cboDocumentType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDocumentType.Location = New System.Drawing.Point(149, 3)
        Me.cboDocumentType.MyLabel = "Case type:"
        Me.cboDocumentType.MyLabelVisible = False
        Me.cboDocumentType.Name = "cboDocumentType"
        Me.cboDocumentType.SelectedDocumentType = Nothing
        Me.cboDocumentType.SelectedDocumentTypeID = -1
        Me.cboDocumentType.SelectedIndex = -1
        Me.cboDocumentType.Size = New System.Drawing.Size(265, 21)
        Me.cboDocumentType.TabIndex = 1
        '
        'DocTypeValidator
        '
        Me.DocTypeValidator.ControlToValidate = Me.cboDocumentType
        Me.DocTypeValidator.ErrorMessage = "Document type is required"
        Me.DocTypeValidator.Icon = CType(resources.GetObject("DocTypeValidator.Icon"), System.Drawing.Icon)
        Me.DocTypeValidator.Required = True
        '
        'AddDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.lblDoc2)
        Me.Controls.Add(Me.lblDoc1)
        Me.Controls.Add(Me.cboDocumentType)
        Me.Name = "AddDocument"
        Me.Size = New System.Drawing.Size(515, 390)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DocTypeValidator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboDocumentType As MPR.SMS.UserControls.DocumentTypeComboBox
    Friend WithEvents ViewCaseMembers As MPR.SMS.UserControls.ViewCaseMembers
    Friend WithEvents ViewCaseAddresses As MPR.SMS.UserControls.ViewCaseAddresses
    Friend WithEvents lblDoc1 As System.Windows.Forms.Label
    Friend WithEvents lblDoc2 As System.Windows.Forms.Label
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Protected WithEvents DocTypeValidator As MPR.Windows.Forms.Validation.CustomValidator

End Class
