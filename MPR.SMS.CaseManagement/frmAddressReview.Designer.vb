'******************************************************************************
' Copyright © Mathematica Policy Research, Inc. 
' This code cannot be copied, distributed or used without the express written permission
' of Mathematica Policy Research, Inc. 
'******************************************************************************

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddressReview
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddressReview))
        Me.ssAddressReview = New System.Windows.Forms.StatusStrip()
        Me.TotalRecordsLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspProgress = New System.Windows.Forms.ToolStripProgressBar()
        Me.BlankLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.UserLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvAddressReview = New System.Windows.Forms.DataGridView()
        Me.tsAddressReview = New System.Windows.Forms.ToolStrip()
        Me.tsbtnSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tscbAddReviewStatus = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnAutoApprove = New System.Windows.Forms.ToolStripDropDownButton()
        Me.mnuApproveAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuApproveSelected = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbtnTransmit = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnReissue = New System.Windows.Forms.ToolStripButton()
        Me.tsbtnClose = New System.Windows.Forms.ToolStripButton()
        Me.OldGroupBox = New System.Windows.Forms.GroupBox()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblFac2 = New System.Windows.Forms.Label()
        Me.txtFacility2 = New System.Windows.Forms.TextBox()
        Me.lblFac1 = New System.Windows.Forms.Label()
        Me.txtFacility1 = New System.Windows.Forms.TextBox()
        Me.lblFacility = New System.Windows.Forms.Label()
        Me.txtZip = New MPR.SMS.UserControls.ZipCodeWithValidator()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblState = New System.Windows.Forms.Label()
        Me.lblAdd4 = New System.Windows.Forms.Label()
        Me.lblAdd3 = New System.Windows.Forms.Label()
        Me.lblAdd2 = New System.Windows.Forms.Label()
        Me.lblAdd1 = New System.Windows.Forms.Label()
        Me.txtAddress4 = New System.Windows.Forms.TextBox()
        Me.txtAddress3 = New System.Windows.Forms.TextBox()
        Me.txtAddress2 = New System.Windows.Forms.TextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.txtAddress1 = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.txtMName = New System.Windows.Forms.TextBox()
        Me.txtLName = New System.Windows.Forms.TextBox()
        Me.txtFName = New System.Windows.Forms.TextBox()
        Me.lblLName = New System.Windows.Forms.Label()
        Me.lblMI = New System.Windows.Forms.Label()
        Me.lblFN = New System.Windows.Forms.Label()
        Me.txtStateNew = New System.Windows.Forms.TextBox()
        Me.txtFacility2New = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFacility1New = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.NewGroupBox = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtZipNew = New MPR.SMS.UserControls.ZipCodeWithValidator()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtAddress4New = New System.Windows.Forms.TextBox()
        Me.txtAddress3New = New System.Windows.Forms.TextBox()
        Me.txtAddress2New = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtCityNew = New System.Windows.Forms.TextBox()
        Me.txtAddress1New = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMNameNew = New System.Windows.Forms.TextBox()
        Me.txtLNameNew = New System.Windows.Forms.TextBox()
        Me.txtFNameNew = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ssAddressReview.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvAddressReview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsAddressReview.SuspendLayout()
        Me.OldGroupBox.SuspendLayout()
        Me.NewGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ssAddressReview
        '
        Me.ssAddressReview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TotalRecordsLabel, Me.tspProgress, Me.BlankLabel, Me.UserLabel})
        Me.ssAddressReview.Location = New System.Drawing.Point(0, 498)
        Me.ssAddressReview.Name = "ssAddressReview"
        Me.ssAddressReview.Size = New System.Drawing.Size(830, 25)
        Me.ssAddressReview.TabIndex = 4
        Me.ssAddressReview.Text = "StatusStrip1"
        '
        'TotalRecordsLabel
        '
        Me.TotalRecordsLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.TotalRecordsLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.TotalRecordsLabel.Name = "TotalRecordsLabel"
        Me.TotalRecordsLabel.Size = New System.Drawing.Size(83, 20)
        Me.TotalRecordsLabel.Text = "Total Records"
        '
        'tspProgress
        '
        Me.tspProgress.Name = "tspProgress"
        Me.tspProgress.Size = New System.Drawing.Size(100, 19)
        '
        'BlankLabel
        '
        Me.BlankLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.BlankLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.BlankLabel.Name = "BlankLabel"
        Me.BlankLabel.Size = New System.Drawing.Size(444, 20)
        Me.BlankLabel.Spring = True
        '
        'UserLabel
        '
        Me.UserLabel.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.UserLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.UserLabel.Image = CType(resources.GetObject("UserLabel.Image"), System.Drawing.Image)
        Me.UserLabel.Name = "UserLabel"
        Me.UserLabel.Size = New System.Drawing.Size(20, 20)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvAddressReview)
        Me.Panel1.Location = New System.Drawing.Point(0, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 220)
        Me.Panel1.TabIndex = 1
        '
        'dgvAddressReview
        '
        Me.dgvAddressReview.AllowUserToAddRows = False
        Me.dgvAddressReview.AllowUserToDeleteRows = False
        Me.dgvAddressReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAddressReview.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAddressReview.Location = New System.Drawing.Point(0, 0)
        Me.dgvAddressReview.Name = "dgvAddressReview"
        Me.dgvAddressReview.Size = New System.Drawing.Size(830, 220)
        Me.dgvAddressReview.TabIndex = 0
        '
        'tsAddressReview
        '
        Me.tsAddressReview.AutoSize = False
        Me.tsAddressReview.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbtnSave, Me.ToolStripSeparator1, Me.tscbAddReviewStatus, Me.ToolStripSeparator2, Me.tsbtnAutoApprove, Me.tsbtnTransmit, Me.tsbtnReissue, Me.tsbtnClose})
        Me.tsAddressReview.Location = New System.Drawing.Point(0, 0)
        Me.tsAddressReview.Name = "tsAddressReview"
        Me.tsAddressReview.Size = New System.Drawing.Size(830, 35)
        Me.tsAddressReview.TabIndex = 0
        Me.tsAddressReview.Text = "ToolStrip1"
        '
        'tsbtnSave
        '
        Me.tsbtnSave.Image = CType(resources.GetObject("tsbtnSave.Image"), System.Drawing.Image)
        Me.tsbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSave.Name = "tsbtnSave"
        Me.tsbtnSave.Size = New System.Drawing.Size(35, 32)
        Me.tsbtnSave.Text = "Save"
        Me.tsbtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnSave.ToolTipText = "Save this session"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'tscbAddReviewStatus
        '
        Me.tscbAddReviewStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.tscbAddReviewStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.tscbAddReviewStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscbAddReviewStatus.Name = "tscbAddReviewStatus"
        Me.tscbAddReviewStatus.Size = New System.Drawing.Size(121, 35)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'tsbtnAutoApprove
        '
        Me.tsbtnAutoApprove.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuApproveAll, Me.mnuApproveSelected})
        Me.tsbtnAutoApprove.Image = CType(resources.GetObject("tsbtnAutoApprove.Image"), System.Drawing.Image)
        Me.tsbtnAutoApprove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnAutoApprove.Name = "tsbtnAutoApprove"
        Me.tsbtnAutoApprove.Size = New System.Drawing.Size(96, 32)
        Me.tsbtnAutoApprove.Text = "Auto-Approve"
        Me.tsbtnAutoApprove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnAutoApprove.ToolTipText = "Send pending address(es) for verification and cleaning (to Melissa Data Corp), an" & _
    "d automatically approve verified address(es)."
        '
        'mnuApproveAll
        '
        Me.mnuApproveAll.Name = "mnuApproveAll"
        Me.mnuApproveAll.Size = New System.Drawing.Size(144, 22)
        Me.mnuApproveAll.Text = "All Rows"
        Me.mnuApproveAll.ToolTipText = "Send all pending addresses for verification and cleaning (to Melissa Data Corp), " & _
    "and automatically approve all verified addresses."
        '
        'mnuApproveSelected
        '
        Me.mnuApproveSelected.Name = "mnuApproveSelected"
        Me.mnuApproveSelected.Size = New System.Drawing.Size(144, 22)
        Me.mnuApproveSelected.Text = "Selected Row"
        Me.mnuApproveSelected.ToolTipText = "Send selected pending address for verification and cleaning (to Melissa Data Corp" & _
    "), and automatically approve if verified."
        '
        'tsbtnTransmit
        '
        Me.tsbtnTransmit.Image = CType(resources.GetObject("tsbtnTransmit.Image"), System.Drawing.Image)
        Me.tsbtnTransmit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnTransmit.Name = "tsbtnTransmit"
        Me.tsbtnTransmit.Size = New System.Drawing.Size(74, 32)
        Me.tsbtnTransmit.Text = "Send to RPS"
        Me.tsbtnTransmit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnTransmit.ToolTipText = "Commit name/address changes to the database, and send payments to RPS"
        '
        'tsbtnReissue
        '
        Me.tsbtnReissue.Image = CType(resources.GetObject("tsbtnReissue.Image"), System.Drawing.Image)
        Me.tsbtnReissue.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnReissue.Name = "tsbtnReissue"
        Me.tsbtnReissue.Size = New System.Drawing.Size(86, 32)
        Me.tsbtnReissue.Text = "Reissue Check"
        Me.tsbtnReissue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbtnReissue.ToolTipText = "Reissue a check"
        '
        'tsbtnClose
        '
        Me.tsbtnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnClose.Name = "tsbtnClose"
        Me.tsbtnClose.Size = New System.Drawing.Size(40, 32)
        Me.tsbtnClose.Text = "Close"
        '
        'OldGroupBox
        '
        Me.OldGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OldGroupBox.Controls.Add(Me.txtState)
        Me.OldGroupBox.Controls.Add(Me.lblName)
        Me.OldGroupBox.Controls.Add(Me.lblFac2)
        Me.OldGroupBox.Controls.Add(Me.txtFacility2)
        Me.OldGroupBox.Controls.Add(Me.lblFac1)
        Me.OldGroupBox.Controls.Add(Me.txtFacility1)
        Me.OldGroupBox.Controls.Add(Me.lblFacility)
        Me.OldGroupBox.Controls.Add(Me.txtZip)
        Me.OldGroupBox.Controls.Add(Me.lblCity)
        Me.OldGroupBox.Controls.Add(Me.lblState)
        Me.OldGroupBox.Controls.Add(Me.lblAdd4)
        Me.OldGroupBox.Controls.Add(Me.lblAdd3)
        Me.OldGroupBox.Controls.Add(Me.lblAdd2)
        Me.OldGroupBox.Controls.Add(Me.lblAdd1)
        Me.OldGroupBox.Controls.Add(Me.txtAddress4)
        Me.OldGroupBox.Controls.Add(Me.txtAddress3)
        Me.OldGroupBox.Controls.Add(Me.txtAddress2)
        Me.OldGroupBox.Controls.Add(Me.lblGender)
        Me.OldGroupBox.Controls.Add(Me.txtCity)
        Me.OldGroupBox.Controls.Add(Me.txtAddress1)
        Me.OldGroupBox.Controls.Add(Me.lblAddress)
        Me.OldGroupBox.Controls.Add(Me.txtMName)
        Me.OldGroupBox.Controls.Add(Me.txtLName)
        Me.OldGroupBox.Controls.Add(Me.txtFName)
        Me.OldGroupBox.Controls.Add(Me.lblLName)
        Me.OldGroupBox.Controls.Add(Me.lblMI)
        Me.OldGroupBox.Controls.Add(Me.lblFN)
        Me.OldGroupBox.Location = New System.Drawing.Point(6, 262)
        Me.OldGroupBox.Name = "OldGroupBox"
        Me.OldGroupBox.Size = New System.Drawing.Size(394, 230)
        Me.OldGroupBox.TabIndex = 2
        Me.OldGroupBox.TabStop = False
        Me.OldGroupBox.Text = "Existing name/address:"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(76, 156)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(100, 20)
        Me.txtState.TabIndex = 19
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(12, 19)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(38, 13)
        Me.lblName.TabIndex = 0
        Me.lblName.Text = "Name:"
        '
        'lblFac2
        '
        Me.lblFac2.AutoSize = True
        Me.lblFac2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFac2.Location = New System.Drawing.Point(66, 198)
        Me.lblFac2.Name = "lblFac2"
        Me.lblFac2.Size = New System.Drawing.Size(10, 12)
        Me.lblFac2.TabIndex = 25
        Me.lblFac2.Text = "2"
        '
        'txtFacility2
        '
        Me.txtFacility2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFacility2.Location = New System.Drawing.Point(76, 198)
        Me.txtFacility2.MaxLength = 60
        Me.txtFacility2.Name = "txtFacility2"
        Me.txtFacility2.ReadOnly = True
        Me.txtFacility2.Size = New System.Drawing.Size(296, 20)
        Me.txtFacility2.TabIndex = 26
        '
        'lblFac1
        '
        Me.lblFac1.AutoSize = True
        Me.lblFac1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFac1.Location = New System.Drawing.Point(66, 178)
        Me.lblFac1.Name = "lblFac1"
        Me.lblFac1.Size = New System.Drawing.Size(10, 12)
        Me.lblFac1.TabIndex = 23
        Me.lblFac1.Text = "1"
        '
        'txtFacility1
        '
        Me.txtFacility1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFacility1.Location = New System.Drawing.Point(76, 178)
        Me.txtFacility1.MaxLength = 60
        Me.txtFacility1.Name = "txtFacility1"
        Me.txtFacility1.ReadOnly = True
        Me.txtFacility1.Size = New System.Drawing.Size(296, 20)
        Me.txtFacility1.TabIndex = 24
        '
        'lblFacility
        '
        Me.lblFacility.AutoSize = True
        Me.lblFacility.Location = New System.Drawing.Point(12, 178)
        Me.lblFacility.Name = "lblFacility"
        Me.lblFacility.Size = New System.Drawing.Size(42, 13)
        Me.lblFacility.TabIndex = 22
        Me.lblFacility.Text = "Facility:"
        '
        'txtZip
        '
        Me.txtZip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtZip.Location = New System.Drawing.Point(292, 156)
        Me.txtZip.Name = "txtZip"
        Me.txtZip.ReadOnly = True
        Me.txtZip.Required = False
        Me.txtZip.Size = New System.Drawing.Size(96, 20)
        Me.txtZip.TabIndex = 21
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Location = New System.Drawing.Point(12, 134)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(27, 13)
        Me.lblCity.TabIndex = 16
        Me.lblCity.Text = "City:"
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(12, 155)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(35, 13)
        Me.lblState.TabIndex = 18
        Me.lblState.Text = "State:"
        '
        'lblAdd4
        '
        Me.lblAdd4.AutoSize = True
        Me.lblAdd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd4.Location = New System.Drawing.Point(66, 112)
        Me.lblAdd4.Name = "lblAdd4"
        Me.lblAdd4.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd4.TabIndex = 14
        Me.lblAdd4.Text = "4"
        '
        'lblAdd3
        '
        Me.lblAdd3.AutoSize = True
        Me.lblAdd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd3.Location = New System.Drawing.Point(66, 92)
        Me.lblAdd3.Name = "lblAdd3"
        Me.lblAdd3.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd3.TabIndex = 12
        Me.lblAdd3.Text = "3"
        '
        'lblAdd2
        '
        Me.lblAdd2.AutoSize = True
        Me.lblAdd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd2.Location = New System.Drawing.Point(66, 72)
        Me.lblAdd2.Name = "lblAdd2"
        Me.lblAdd2.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd2.TabIndex = 10
        Me.lblAdd2.Text = "2"
        '
        'lblAdd1
        '
        Me.lblAdd1.AutoSize = True
        Me.lblAdd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdd1.Location = New System.Drawing.Point(66, 52)
        Me.lblAdd1.Name = "lblAdd1"
        Me.lblAdd1.Size = New System.Drawing.Size(10, 12)
        Me.lblAdd1.TabIndex = 8
        Me.lblAdd1.Text = "1"
        '
        'txtAddress4
        '
        Me.txtAddress4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4.Location = New System.Drawing.Point(76, 112)
        Me.txtAddress4.MaxLength = 60
        Me.txtAddress4.Name = "txtAddress4"
        Me.txtAddress4.ReadOnly = True
        Me.txtAddress4.Size = New System.Drawing.Size(296, 20)
        Me.txtAddress4.TabIndex = 15
        '
        'txtAddress3
        '
        Me.txtAddress3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3.Location = New System.Drawing.Point(76, 92)
        Me.txtAddress3.MaxLength = 60
        Me.txtAddress3.Name = "txtAddress3"
        Me.txtAddress3.ReadOnly = True
        Me.txtAddress3.Size = New System.Drawing.Size(296, 20)
        Me.txtAddress3.TabIndex = 13
        '
        'txtAddress2
        '
        Me.txtAddress2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2.Location = New System.Drawing.Point(76, 72)
        Me.txtAddress2.MaxLength = 60
        Me.txtAddress2.Name = "txtAddress2"
        Me.txtAddress2.ReadOnly = True
        Me.txtAddress2.Size = New System.Drawing.Size(296, 20)
        Me.txtAddress2.TabIndex = 11
        '
        'lblGender
        '
        Me.lblGender.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGender.AutoSize = True
        Me.lblGender.Location = New System.Drawing.Point(260, 157)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(25, 13)
        Me.lblGender.TabIndex = 20
        Me.lblGender.Text = "Zip:"
        '
        'txtCity
        '
        Me.txtCity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCity.Location = New System.Drawing.Point(76, 134)
        Me.txtCity.MaxLength = 25
        Me.txtCity.Name = "txtCity"
        Me.txtCity.ReadOnly = True
        Me.txtCity.Size = New System.Drawing.Size(296, 20)
        Me.txtCity.TabIndex = 17
        '
        'txtAddress1
        '
        Me.txtAddress1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1.Location = New System.Drawing.Point(76, 52)
        Me.txtAddress1.MaxLength = 60
        Me.txtAddress1.Name = "txtAddress1"
        Me.txtAddress1.ReadOnly = True
        Me.txtAddress1.Size = New System.Drawing.Size(296, 20)
        Me.txtAddress1.TabIndex = 9
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(12, 51)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(48, 13)
        Me.lblAddress.TabIndex = 7
        Me.lblAddress.Text = "Address:"
        '
        'txtMName
        '
        Me.txtMName.Location = New System.Drawing.Point(164, 16)
        Me.txtMName.MaxLength = 20
        Me.txtMName.Name = "txtMName"
        Me.txtMName.ReadOnly = True
        Me.txtMName.Size = New System.Drawing.Size(42, 20)
        Me.txtMName.TabIndex = 3
        '
        'txtLName
        '
        Me.txtLName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLName.Location = New System.Drawing.Point(208, 16)
        Me.txtLName.MaxLength = 30
        Me.txtLName.Name = "txtLName"
        Me.txtLName.ReadOnly = True
        Me.txtLName.Size = New System.Drawing.Size(164, 20)
        Me.txtLName.TabIndex = 5
        '
        'txtFName
        '
        Me.txtFName.Location = New System.Drawing.Point(76, 16)
        Me.txtFName.MaxLength = 20
        Me.txtFName.Name = "txtFName"
        Me.txtFName.ReadOnly = True
        Me.txtFName.Size = New System.Drawing.Size(85, 20)
        Me.txtFName.TabIndex = 1
        '
        'lblLName
        '
        Me.lblLName.AutoSize = True
        Me.lblLName.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLName.Location = New System.Drawing.Point(208, 34)
        Me.lblLName.Name = "lblLName"
        Me.lblLName.Size = New System.Drawing.Size(29, 12)
        Me.lblLName.TabIndex = 6
        Me.lblLName.Text = "(Last)"
        '
        'lblMI
        '
        Me.lblMI.AutoSize = True
        Me.lblMI.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMI.Location = New System.Drawing.Point(163, 34)
        Me.lblMI.Name = "lblMI"
        Me.lblMI.Size = New System.Drawing.Size(39, 12)
        Me.lblMI.TabIndex = 4
        Me.lblMI.Text = "(Middle)"
        '
        'lblFN
        '
        Me.lblFN.AutoSize = True
        Me.lblFN.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFN.Location = New System.Drawing.Point(74, 34)
        Me.lblFN.Name = "lblFN"
        Me.lblFN.Size = New System.Drawing.Size(30, 12)
        Me.lblFN.TabIndex = 2
        Me.lblFN.Text = "(First)"
        '
        'txtStateNew
        '
        Me.txtStateNew.Location = New System.Drawing.Point(79, 156)
        Me.txtStateNew.Name = "txtStateNew"
        Me.txtStateNew.ReadOnly = True
        Me.txtStateNew.Size = New System.Drawing.Size(40, 20)
        Me.txtStateNew.TabIndex = 19
        '
        'txtFacility2New
        '
        Me.txtFacility2New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFacility2New.Location = New System.Drawing.Point(79, 198)
        Me.txtFacility2New.MaxLength = 60
        Me.txtFacility2New.Name = "txtFacility2New"
        Me.txtFacility2New.ReadOnly = True
        Me.txtFacility2New.Size = New System.Drawing.Size(292, 20)
        Me.txtFacility2New.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 178)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Facility:"
        '
        'txtFacility1New
        '
        Me.txtFacility1New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFacility1New.Location = New System.Drawing.Point(79, 178)
        Me.txtFacility1New.MaxLength = 60
        Me.txtFacility1New.Name = "txtFacility1New"
        Me.txtFacility1New.ReadOnly = True
        Me.txtFacility1New.Size = New System.Drawing.Size(292, 20)
        Me.txtFacility1New.TabIndex = 24
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Name:"
        '
        'NewGroupBox
        '
        Me.NewGroupBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NewGroupBox.Controls.Add(Me.txtStateNew)
        Me.NewGroupBox.Controls.Add(Me.Label2)
        Me.NewGroupBox.Controls.Add(Me.Label3)
        Me.NewGroupBox.Controls.Add(Me.txtFacility2New)
        Me.NewGroupBox.Controls.Add(Me.Label4)
        Me.NewGroupBox.Controls.Add(Me.txtFacility1New)
        Me.NewGroupBox.Controls.Add(Me.Label1)
        Me.NewGroupBox.Controls.Add(Me.txtZipNew)
        Me.NewGroupBox.Controls.Add(Me.Label5)
        Me.NewGroupBox.Controls.Add(Me.Label6)
        Me.NewGroupBox.Controls.Add(Me.Label7)
        Me.NewGroupBox.Controls.Add(Me.Label8)
        Me.NewGroupBox.Controls.Add(Me.Label9)
        Me.NewGroupBox.Controls.Add(Me.Label10)
        Me.NewGroupBox.Controls.Add(Me.txtAddress4New)
        Me.NewGroupBox.Controls.Add(Me.txtAddress3New)
        Me.NewGroupBox.Controls.Add(Me.txtAddress2New)
        Me.NewGroupBox.Controls.Add(Me.Label11)
        Me.NewGroupBox.Controls.Add(Me.txtCityNew)
        Me.NewGroupBox.Controls.Add(Me.txtAddress1New)
        Me.NewGroupBox.Controls.Add(Me.Label12)
        Me.NewGroupBox.Controls.Add(Me.txtMNameNew)
        Me.NewGroupBox.Controls.Add(Me.txtLNameNew)
        Me.NewGroupBox.Controls.Add(Me.txtFNameNew)
        Me.NewGroupBox.Controls.Add(Me.Label13)
        Me.NewGroupBox.Controls.Add(Me.Label14)
        Me.NewGroupBox.Controls.Add(Me.Label15)
        Me.NewGroupBox.Location = New System.Drawing.Point(406, 262)
        Me.NewGroupBox.Name = "NewGroupBox"
        Me.NewGroupBox.Size = New System.Drawing.Size(394, 230)
        Me.NewGroupBox.TabIndex = 3
        Me.NewGroupBox.TabStop = False
        Me.NewGroupBox.Text = "New name/address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(69, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 12)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(69, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 12)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "1"
        '
        'txtZipNew
        '
        Me.txtZipNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtZipNew.Location = New System.Drawing.Point(291, 156)
        Me.txtZipNew.Name = "txtZipNew"
        Me.txtZipNew.ReadOnly = True
        Me.txtZipNew.Required = False
        Me.txtZipNew.Size = New System.Drawing.Size(96, 20)
        Me.txtZipNew.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 134)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(27, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "City:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "State:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(69, 112)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 12)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "4"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(69, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 12)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "3"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(69, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 12)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "2"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(69, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 12)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "1"
        '
        'txtAddress4New
        '
        Me.txtAddress4New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress4New.Location = New System.Drawing.Point(79, 112)
        Me.txtAddress4New.MaxLength = 60
        Me.txtAddress4New.Name = "txtAddress4New"
        Me.txtAddress4New.ReadOnly = True
        Me.txtAddress4New.Size = New System.Drawing.Size(292, 20)
        Me.txtAddress4New.TabIndex = 15
        '
        'txtAddress3New
        '
        Me.txtAddress3New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress3New.Location = New System.Drawing.Point(79, 92)
        Me.txtAddress3New.MaxLength = 60
        Me.txtAddress3New.Name = "txtAddress3New"
        Me.txtAddress3New.ReadOnly = True
        Me.txtAddress3New.Size = New System.Drawing.Size(292, 20)
        Me.txtAddress3New.TabIndex = 13
        '
        'txtAddress2New
        '
        Me.txtAddress2New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress2New.Location = New System.Drawing.Point(79, 72)
        Me.txtAddress2New.MaxLength = 60
        Me.txtAddress2New.Name = "txtAddress2New"
        Me.txtAddress2New.ReadOnly = True
        Me.txtAddress2New.Size = New System.Drawing.Size(292, 20)
        Me.txtAddress2New.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(252, 157)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Zip:"
        '
        'txtCityNew
        '
        Me.txtCityNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCityNew.Location = New System.Drawing.Point(79, 134)
        Me.txtCityNew.MaxLength = 25
        Me.txtCityNew.Name = "txtCityNew"
        Me.txtCityNew.ReadOnly = True
        Me.txtCityNew.Size = New System.Drawing.Size(292, 20)
        Me.txtCityNew.TabIndex = 17
        '
        'txtAddress1New
        '
        Me.txtAddress1New.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAddress1New.Location = New System.Drawing.Point(79, 52)
        Me.txtAddress1New.MaxLength = 60
        Me.txtAddress1New.Name = "txtAddress1New"
        Me.txtAddress1New.ReadOnly = True
        Me.txtAddress1New.Size = New System.Drawing.Size(292, 20)
        Me.txtAddress1New.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 13)
        Me.Label12.TabIndex = 7
        Me.Label12.Text = "Address:"
        '
        'txtMNameNew
        '
        Me.txtMNameNew.Location = New System.Drawing.Point(166, 16)
        Me.txtMNameNew.MaxLength = 20
        Me.txtMNameNew.Name = "txtMNameNew"
        Me.txtMNameNew.ReadOnly = True
        Me.txtMNameNew.Size = New System.Drawing.Size(42, 20)
        Me.txtMNameNew.TabIndex = 2
        '
        'txtLNameNew
        '
        Me.txtLNameNew.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLNameNew.Location = New System.Drawing.Point(210, 16)
        Me.txtLNameNew.MaxLength = 30
        Me.txtLNameNew.Name = "txtLNameNew"
        Me.txtLNameNew.ReadOnly = True
        Me.txtLNameNew.Size = New System.Drawing.Size(161, 20)
        Me.txtLNameNew.TabIndex = 3
        '
        'txtFNameNew
        '
        Me.txtFNameNew.Location = New System.Drawing.Point(79, 16)
        Me.txtFNameNew.MaxLength = 20
        Me.txtFNameNew.Name = "txtFNameNew"
        Me.txtFNameNew.ReadOnly = True
        Me.txtFNameNew.Size = New System.Drawing.Size(85, 20)
        Me.txtFNameNew.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(210, 34)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 12)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "(Last)"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(164, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 12)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "(Middle)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(77, 34)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 12)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "(First)"
        '
        'frmAddressReview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 523)
        Me.Controls.Add(Me.NewGroupBox)
        Me.Controls.Add(Me.OldGroupBox)
        Me.Controls.Add(Me.tsAddressReview)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ssAddressReview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAddressReview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAddressReview"
        Me.ssAddressReview.ResumeLayout(False)
        Me.ssAddressReview.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvAddressReview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsAddressReview.ResumeLayout(False)
        Me.tsAddressReview.PerformLayout()
        Me.OldGroupBox.ResumeLayout(False)
        Me.OldGroupBox.PerformLayout()
        Me.NewGroupBox.ResumeLayout(False)
        Me.NewGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ssAddressReview As System.Windows.Forms.StatusStrip
    Friend WithEvents TotalRecordsLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BlankLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents UserLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents tsAddressReview As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbtnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbtnClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscbAddReviewStatus As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents OldGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents txtMName As System.Windows.Forms.TextBox
    Friend WithEvents txtLName As System.Windows.Forms.TextBox
    Friend WithEvents txtFName As System.Windows.Forms.TextBox
    Friend WithEvents lblLName As System.Windows.Forms.Label
    Friend WithEvents lblMI As System.Windows.Forms.Label
    Friend WithEvents lblFN As System.Windows.Forms.Label
    Friend WithEvents lblFac2 As System.Windows.Forms.Label
    Friend WithEvents txtFacility2 As System.Windows.Forms.TextBox
    Friend WithEvents lblFac1 As System.Windows.Forms.Label
    Friend WithEvents txtFacility1 As System.Windows.Forms.TextBox
    Friend WithEvents lblFacility As System.Windows.Forms.Label
    Friend WithEvents txtZip As MPR.SMS.UserControls.ZipCodeWithValidator
    Friend WithEvents lblCity As System.Windows.Forms.Label
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents lblAdd4 As System.Windows.Forms.Label
    Friend WithEvents lblAdd3 As System.Windows.Forms.Label
    Friend WithEvents lblAdd2 As System.Windows.Forms.Label
    Friend WithEvents lblAdd1 As System.Windows.Forms.Label
    Friend WithEvents txtAddress4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents txtCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbtnReissue As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtStateNew As System.Windows.Forms.TextBox
    Friend WithEvents txtFacility2New As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFacility1New As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtZipNew As MPR.SMS.UserControls.ZipCodeWithValidator
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtAddress4New As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress3New As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress2New As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCityNew As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress1New As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMNameNew As System.Windows.Forms.TextBox
    Friend WithEvents txtLNameNew As System.Windows.Forms.TextBox
    Friend WithEvents txtFNameNew As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents tsbtnTransmit As System.Windows.Forms.ToolStripButton
    Friend WithEvents dgvAddressReview As System.Windows.Forms.DataGridView
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tspProgress As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsbtnAutoApprove As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents mnuApproveAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuApproveSelected As System.Windows.Forms.ToolStripMenuItem
End Class
