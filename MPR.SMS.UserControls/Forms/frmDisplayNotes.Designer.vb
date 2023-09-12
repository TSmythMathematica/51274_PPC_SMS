'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDisplayNotes
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
        Me.ViewNotes = New MPR.SMS.UserControls.ViewNotes()
        Me.SuspendLayout()
        '
        'ViewNotes
        '
        Me.ViewNotes.Location = New System.Drawing.Point(12, 12)
        Me.ViewNotes.Name = "ViewNotes"
        Me.ViewNotes.SelectedAddress = Nothing
        Me.ViewNotes.SelectedCase = Nothing
        Me.ViewNotes.SelectedNote = Nothing
        Me.ViewNotes.Size = New System.Drawing.Size(963, 226)
        Me.ViewNotes.TabIndex = 0
        '
        'frmDisplayNotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 250)
        Me.Controls.Add(Me.ViewNotes)
        Me.Name = "frmDisplayNotes"
        Me.Text = "Display Notes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ViewNotes As MPR.SMS.UserControls.ViewNotes
End Class
