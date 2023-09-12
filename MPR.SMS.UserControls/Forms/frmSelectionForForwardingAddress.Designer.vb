<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectionForForwardingAddress
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectionForForwardingAddress))
        Me.grdAddresses = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.DuplicateAddress = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.AddressID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.City = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ZipCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grdAddresses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdAddresses
        '
        Me.grdAddresses.AllowUserToDeleteRows = False
        Me.grdAddresses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdAddresses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DuplicateAddress, Me.AddressID, Me.Address1, Me.Address2, Me.City, Me.State, Me.ZipCode})
        Me.grdAddresses.Location = New System.Drawing.Point(18, 18)
        Me.grdAddresses.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.grdAddresses.Name = "grdAddresses"
        Me.grdAddresses.Size = New System.Drawing.Size(993, 575)
        Me.grdAddresses.TabIndex = 7
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(900, 635)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(111, 45)
        Me.btnCancel.TabIndex = 6
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(18, 622)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(256, 72)
        Me.btnYes.TabIndex = 5
        Me.btnYes.Text = "Yes, we have the same Address as Forwarding"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(303, 622)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(256, 72)
        Me.btnNo.TabIndex = 8
        Me.btnNo.Text = "No, we do not have the same Address as Forwarding"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "checkbox-checked.bmp")
        Me.imgList.Images.SetKeyName(1, "checkbox-unchecked.bmp")
        '
        'DuplicateAddress
        '
        Me.DuplicateAddress.HeaderText = "Address is a duplicate to the Forwarding Address"
        Me.DuplicateAddress.MinimumWidth = 8
        Me.DuplicateAddress.Name = "DuplicateAddress"
        Me.DuplicateAddress.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DuplicateAddress.Width = 150
        '
        'AddressID
        '
        Me.AddressID.HeaderText = "AddressID"
        Me.AddressID.MinimumWidth = 8
        Me.AddressID.Name = "AddressID"
        Me.AddressID.ReadOnly = True
        Me.AddressID.Width = 64
        '
        'Address1
        '
        Me.Address1.HeaderText = "Address1"
        Me.Address1.MinimumWidth = 8
        Me.Address1.Name = "Address1"
        Me.Address1.ReadOnly = True
        Me.Address1.Width = 150
        '
        'Address2
        '
        Me.Address2.HeaderText = "Address2"
        Me.Address2.MinimumWidth = 8
        Me.Address2.Name = "Address2"
        Me.Address2.ReadOnly = True
        Me.Address2.Width = 70
        '
        'City
        '
        Me.City.HeaderText = "City"
        Me.City.MinimumWidth = 8
        Me.City.Name = "City"
        Me.City.ReadOnly = True
        Me.City.Width = 150
        '
        'State
        '
        Me.State.HeaderText = "State"
        Me.State.MinimumWidth = 8
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.Width = 44
        '
        'ZipCode
        '
        Me.ZipCode.HeaderText = "Zip Code"
        Me.ZipCode.MinimumWidth = 8
        Me.ZipCode.Name = "ZipCode"
        Me.ZipCode.ReadOnly = True
        '
        'frmSelectionForForwardingAddress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 708)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.grdAddresses)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnYes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmSelectionForForwardingAddress"
        Me.Text = "List of unique Addresses"
        CType(Me.grdAddresses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdAddresses As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents imgList As System.Windows.Forms.ImageList
    Friend WithEvents DuplicateAddress As DataGridViewCheckBoxColumn
    Friend WithEvents AddressID As DataGridViewTextBoxColumn
    Friend WithEvents Address1 As DataGridViewTextBoxColumn
    Friend WithEvents Address2 As DataGridViewTextBoxColumn
    Friend WithEvents City As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewTextBoxColumn
    Friend WithEvents ZipCode As DataGridViewTextBoxColumn
End Class
