'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRemailDocument
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblPersonName = New System.Windows.Forms.Label()
        Me.ViewAddressRemail = New MPR.SMS.UserControls.ViewAddressRemail()
        Me.SuspendLayout()
        '
        'lblPersonName
        '
        Me.lblPersonName.AutoSize = True
        Me.lblPersonName.Location = New System.Drawing.Point(12, 9)
        Me.lblPersonName.Name = "lblPersonName"
        Me.lblPersonName.Size = New System.Drawing.Size(39, 13)
        Me.lblPersonName.TabIndex = 4
        Me.lblPersonName.Text = "Label1"
        Me.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ViewAddressRemail
        '
        Me.ViewAddressRemail.Location = New System.Drawing.Point(-2, 38)
        Me.ViewAddressRemail.Name = "ViewAddressRemail"
        Me.ViewAddressRemail.SelectedAddress = Nothing
        Me.ViewAddressRemail.SelectedCase = Nothing
        Me.ViewAddressRemail.SelectedDocumentType = Nothing
        Me.ViewAddressRemail.SelectedPerson = Nothing
        Me.ViewAddressRemail.Size = New System.Drawing.Size(661, 282)
        Me.ViewAddressRemail.TabIndex = 0
        '
        'frmRemailDocument
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(657, 332)
        Me.Controls.Add(Me.lblPersonName)
        Me.Controls.Add(Me.ViewAddressRemail)
        Me.Name = "frmRemailDocument"
        Me.Text = "No Forwarding Address"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ViewAddressRemail As MPR.SMS.UserControls.ViewAddressRemail
    Friend WithEvents lblPersonName As System.Windows.Forms.Label
End Class
