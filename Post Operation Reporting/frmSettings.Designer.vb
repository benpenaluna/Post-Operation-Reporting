<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingsForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Debriefs")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Assign Privledges")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reset Own Password")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reset Other Password")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User Management", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Create New Member")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Self")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Another Member")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Delete Member")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Members", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8, TreeNode9})
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Email Receipients")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Mail Server")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Network Credentials")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Client Settings")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update From Address")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Email Settings", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12, TreeNode13, TreeNode14, TreeNode15})
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Job Types")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Tasks")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Job Types & Tasks", New System.Windows.Forms.TreeNode() {TreeNode17, TreeNode18})
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Vehicles")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Update Equipment")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Logistics", New System.Windows.Forms.TreeNode() {TreeNode20, TreeNode21})
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Settings", New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode10, TreeNode16, TreeNode19, TreeNode22})
        Me.tabPageJobsTasks = New System.Windows.Forms.TabPage()
        Me.grpTasks = New System.Windows.Forms.GroupBox()
        Me.dgvTasks = New System.Windows.Forms.DataGridView()
        Me.clmTask = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpJobTypes = New System.Windows.Forms.GroupBox()
        Me.dgvJobType = New System.Windows.Forms.DataGridView()
        Me.clmJobType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabPageEmail = New System.Windows.Forms.TabPage()
        Me.gbpFromAddress = New System.Windows.Forms.GroupBox()
        Me.txtFromAddress = New System.Windows.Forms.TextBox()
        Me.txtDisplayName = New System.Windows.Forms.TextBox()
        Me.lblDisplayName = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.gbpClient = New System.Windows.Forms.GroupBox()
        Me.lblSeconds = New System.Windows.Forms.Label()
        Me.txtSMTPTimeout = New System.Windows.Forms.TextBox()
        Me.lblTimeout = New System.Windows.Forms.Label()
        Me.cboEnableSSL = New System.Windows.Forms.ComboBox()
        Me.lblEnableSSL = New System.Windows.Forms.Label()
        Me.lblPriority = New System.Windows.Forms.Label()
        Me.cboPriority = New System.Windows.Forms.ComboBox()
        Me.gpbReceipt = New System.Windows.Forms.GroupBox()
        Me.chkSelectAllToReceive = New System.Windows.Forms.CheckBox()
        Me.dgvMembersToReceive = New System.Windows.Forms.DataGridView()
        Me.clmSelected = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.clmMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmReceipientType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblReceipientType = New System.Windows.Forms.Label()
        Me.cboRecepientType = New System.Windows.Forms.ComboBox()
        Me.dgvAdditionalReceipients = New System.Windows.Forms.DataGridView()
        Me.clmDisplayName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmAddress = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmType = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblAdditionalReceipients = New System.Windows.Forms.Label()
        Me.lblMembersToReceive = New System.Windows.Forms.Label()
        Me.chkAllMembersReceive = New System.Windows.Forms.CheckBox()
        Me.gbpCredentials = New System.Windows.Forms.GroupBox()
        Me.chkShowPassword = New System.Windows.Forms.CheckBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.gbpMailServer = New System.Windows.Forms.GroupBox()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.txtHost = New System.Windows.Forms.TextBox()
        Me.lblHost = New System.Windows.Forms.Label()
        Me.cmsDeleteRow = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteRowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabSettings = New System.Windows.Forms.TabControl()
        Me.tabPageMemberDetails = New System.Windows.Forms.TabPage()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.grpUserManagement = New System.Windows.Forms.GroupBox()
        Me.btnDefaultPrivledges = New System.Windows.Forms.Button()
        Me.btnResetPassword = New System.Windows.Forms.Button()
        Me.grpMemberDetails = New System.Windows.Forms.GroupBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblStatusTitle = New System.Windows.Forms.Label()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblIDTitle = New System.Windows.Forms.Label()
        Me.lblSurnameTitle = New System.Windows.Forms.Label()
        Me.lblFirstNameTitle = New System.Windows.Forms.Label()
        Me.lblEmailTitle = New System.Windows.Forms.Label()
        Me.lblPositionTitle = New System.Windows.Forms.Label()
        Me.grpPrivledges = New System.Windows.Forms.GroupBox()
        Me.tstvPrivledges = New PostOpRep.Controls.TriStateTreeView()
        Me.lblMember = New System.Windows.Forms.Label()
        Me.cboMember = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblStatusFilter = New System.Windows.Forms.Label()
        Me.cboStatusFilter = New System.Windows.Forms.ComboBox()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.tabLogistics = New System.Windows.Forms.TabPage()
        Me.grpEquipment = New System.Windows.Forms.GroupBox()
        Me.dgvEquipment = New System.Windows.Forms.DataGridView()
        Me.clmEquipmentItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpVehicles = New System.Windows.Forms.GroupBox()
        Me.dgvVehicles = New System.Windows.Forms.DataGridView()
        Me.clmVehicleName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.tipSMTPHost = New System.Windows.Forms.ToolTip(Me.components)
        Me.tabPageJobsTasks.SuspendLayout
        Me.grpTasks.SuspendLayout
        CType(Me.dgvTasks,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpJobTypes.SuspendLayout
        CType(Me.dgvJobType,System.ComponentModel.ISupportInitialize).BeginInit
        Me.tabPageEmail.SuspendLayout
        Me.gbpFromAddress.SuspendLayout
        Me.gbpClient.SuspendLayout
        Me.gpbReceipt.SuspendLayout
        CType(Me.dgvMembersToReceive,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.dgvAdditionalReceipients,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbpCredentials.SuspendLayout
        Me.gbpMailServer.SuspendLayout
        Me.cmsDeleteRow.SuspendLayout
        Me.tabSettings.SuspendLayout
        Me.tabPageMemberDetails.SuspendLayout
        Me.grpUserManagement.SuspendLayout
        Me.grpMemberDetails.SuspendLayout
        Me.grpPrivledges.SuspendLayout
        Me.tabLogistics.SuspendLayout
        Me.grpEquipment.SuspendLayout
        CType(Me.dgvEquipment,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpVehicles.SuspendLayout
        CType(Me.dgvVehicles,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'tabPageJobsTasks
        '
        Me.tabPageJobsTasks.BackColor = System.Drawing.Color.Silver
        Me.tabPageJobsTasks.Controls.Add(Me.grpTasks)
        Me.tabPageJobsTasks.Controls.Add(Me.grpJobTypes)
        Me.tabPageJobsTasks.Location = New System.Drawing.Point(4, 24)
        Me.tabPageJobsTasks.Name = "tabPageJobsTasks"
        Me.tabPageJobsTasks.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageJobsTasks.Size = New System.Drawing.Size(733, 404)
        Me.tabPageJobsTasks.TabIndex = 0
        Me.tabPageJobsTasks.Text = "Job Type & Tasks"
        '
        'grpTasks
        '
        Me.grpTasks.Controls.Add(Me.dgvTasks)
        Me.grpTasks.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpTasks.Location = New System.Drawing.Point(374, 6)
        Me.grpTasks.Name = "grpTasks"
        Me.grpTasks.Size = New System.Drawing.Size(353, 392)
        Me.grpTasks.TabIndex = 1
        Me.grpTasks.TabStop = false
        Me.grpTasks.Text = "Tasks"
        '
        'dgvTasks
        '
        Me.dgvTasks.AllowUserToResizeColumns = false
        Me.dgvTasks.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTasks.ColumnHeadersVisible = false
        Me.dgvTasks.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmTask})
        Me.dgvTasks.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvTasks.Location = New System.Drawing.Point(6, 22)
        Me.dgvTasks.Name = "dgvTasks"
        Me.dgvTasks.RowHeadersVisible = false
        Me.dgvTasks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvTasks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvTasks.Size = New System.Drawing.Size(341, 364)
        Me.dgvTasks.TabIndex = 1
        '
        'clmTask
        '
        Me.clmTask.HeaderText = "Task"
        Me.clmTask.Name = "clmTask"
        '
        'grpJobTypes
        '
        Me.grpJobTypes.Controls.Add(Me.dgvJobType)
        Me.grpJobTypes.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpJobTypes.Location = New System.Drawing.Point(6, 6)
        Me.grpJobTypes.Name = "grpJobTypes"
        Me.grpJobTypes.Size = New System.Drawing.Size(353, 392)
        Me.grpJobTypes.TabIndex = 0
        Me.grpJobTypes.TabStop = false
        Me.grpJobTypes.Text = "Job Types"
        '
        'dgvJobType
        '
        Me.dgvJobType.AllowUserToResizeColumns = false
        Me.dgvJobType.AllowUserToResizeRows = false
        Me.dgvJobType.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvJobType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvJobType.ColumnHeadersVisible = false
        Me.dgvJobType.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmJobType})
        Me.dgvJobType.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvJobType.Location = New System.Drawing.Point(6, 22)
        Me.dgvJobType.MultiSelect = false
        Me.dgvJobType.Name = "dgvJobType"
        Me.dgvJobType.RowHeadersVisible = false
        Me.dgvJobType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvJobType.ShowEditingIcon = false
        Me.dgvJobType.Size = New System.Drawing.Size(341, 364)
        Me.dgvJobType.TabIndex = 0
        '
        'clmJobType
        '
        Me.clmJobType.HeaderText = "Type"
        Me.clmJobType.Name = "clmJobType"
        '
        'tabPageEmail
        '
        Me.tabPageEmail.BackColor = System.Drawing.Color.Silver
        Me.tabPageEmail.Controls.Add(Me.gbpFromAddress)
        Me.tabPageEmail.Controls.Add(Me.gbpClient)
        Me.tabPageEmail.Controls.Add(Me.gpbReceipt)
        Me.tabPageEmail.Controls.Add(Me.gbpCredentials)
        Me.tabPageEmail.Controls.Add(Me.gbpMailServer)
        Me.tabPageEmail.Location = New System.Drawing.Point(4, 24)
        Me.tabPageEmail.Name = "tabPageEmail"
        Me.tabPageEmail.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageEmail.Size = New System.Drawing.Size(733, 404)
        Me.tabPageEmail.TabIndex = 2
        Me.tabPageEmail.Text = "Email"
        '
        'gbpFromAddress
        '
        Me.gbpFromAddress.Controls.Add(Me.txtFromAddress)
        Me.gbpFromAddress.Controls.Add(Me.txtDisplayName)
        Me.gbpFromAddress.Controls.Add(Me.lblDisplayName)
        Me.gbpFromAddress.Controls.Add(Me.lblAddress)
        Me.gbpFromAddress.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbpFromAddress.Location = New System.Drawing.Point(435, 308)
        Me.gbpFromAddress.Name = "gbpFromAddress"
        Me.gbpFromAddress.Size = New System.Drawing.Size(286, 81)
        Me.gbpFromAddress.TabIndex = 8
        Me.gbpFromAddress.TabStop = false
        Me.gbpFromAddress.Text = "From Address"
        '
        'txtFromAddress
        '
        Me.txtFromAddress.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtFromAddress.Location = New System.Drawing.Point(92, 48)
        Me.txtFromAddress.Name = "txtFromAddress"
        Me.txtFromAddress.Size = New System.Drawing.Size(184, 23)
        Me.txtFromAddress.TabIndex = 3
        '
        'txtDisplayName
        '
        Me.txtDisplayName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDisplayName.Location = New System.Drawing.Point(92, 19)
        Me.txtDisplayName.Name = "txtDisplayName"
        Me.txtDisplayName.Size = New System.Drawing.Size(184, 23)
        Me.txtDisplayName.TabIndex = 2
        '
        'lblDisplayName
        '
        Me.lblDisplayName.AutoSize = true
        Me.lblDisplayName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDisplayName.Location = New System.Drawing.Point(6, 22)
        Me.lblDisplayName.Name = "lblDisplayName"
        Me.lblDisplayName.Size = New System.Drawing.Size(83, 15)
        Me.lblDisplayName.TabIndex = 1
        Me.lblDisplayName.Text = "Display Name"
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = true
        Me.lblAddress.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblAddress.Location = New System.Drawing.Point(6, 51)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(51, 15)
        Me.lblAddress.TabIndex = 0
        Me.lblAddress.Text = "Address"
        '
        'gbpClient
        '
        Me.gbpClient.Controls.Add(Me.lblSeconds)
        Me.gbpClient.Controls.Add(Me.txtSMTPTimeout)
        Me.gbpClient.Controls.Add(Me.lblTimeout)
        Me.gbpClient.Controls.Add(Me.cboEnableSSL)
        Me.gbpClient.Controls.Add(Me.lblEnableSSL)
        Me.gbpClient.Controls.Add(Me.lblPriority)
        Me.gbpClient.Controls.Add(Me.cboPriority)
        Me.gbpClient.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbpClient.Location = New System.Drawing.Point(435, 197)
        Me.gbpClient.Name = "gbpClient"
        Me.gbpClient.Size = New System.Drawing.Size(286, 105)
        Me.gbpClient.TabIndex = 7
        Me.gbpClient.TabStop = false
        Me.gbpClient.Text = "Client Settings"
        '
        'lblSeconds
        '
        Me.lblSeconds.AutoSize = true
        Me.lblSeconds.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSeconds.Location = New System.Drawing.Point(152, 77)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(52, 15)
        Me.lblSeconds.TabIndex = 7
        Me.lblSeconds.Text = "seconds"
        '
        'txtSMTPTimeout
        '
        Me.txtSMTPTimeout.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtSMTPTimeout.Location = New System.Drawing.Point(112, 74)
        Me.txtSMTPTimeout.Name = "txtSMTPTimeout"
        Me.txtSMTPTimeout.Size = New System.Drawing.Size(34, 23)
        Me.txtSMTPTimeout.TabIndex = 6
        '
        'lblTimeout
        '
        Me.lblTimeout.AutoSize = true
        Me.lblTimeout.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblTimeout.Location = New System.Drawing.Point(6, 77)
        Me.lblTimeout.Name = "lblTimeout"
        Me.lblTimeout.Size = New System.Drawing.Size(84, 15)
        Me.lblTimeout.TabIndex = 5
        Me.lblTimeout.Text = "SMTP Timeout"
        '
        'cboEnableSSL
        '
        Me.cboEnableSSL.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboEnableSSL.FormattingEnabled = true
        Me.cboEnableSSL.Items.AddRange(New Object() {"True", "False"})
        Me.cboEnableSSL.Location = New System.Drawing.Point(112, 45)
        Me.cboEnableSSL.Name = "cboEnableSSL"
        Me.cboEnableSSL.Size = New System.Drawing.Size(121, 23)
        Me.cboEnableSSL.TabIndex = 4
        '
        'lblEnableSSL
        '
        Me.lblEnableSSL.AutoSize = true
        Me.lblEnableSSL.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblEnableSSL.Location = New System.Drawing.Point(6, 48)
        Me.lblEnableSSL.Name = "lblEnableSSL"
        Me.lblEnableSSL.Size = New System.Drawing.Size(64, 15)
        Me.lblEnableSSL.TabIndex = 3
        Me.lblEnableSSL.Text = "Enable SSL"
        '
        'lblPriority
        '
        Me.lblPriority.AutoSize = true
        Me.lblPriority.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPriority.Location = New System.Drawing.Point(6, 19)
        Me.lblPriority.Name = "lblPriority"
        Me.lblPriority.Size = New System.Drawing.Size(100, 15)
        Me.lblPriority.TabIndex = 1
        Me.lblPriority.Text = "Message Priority"
        '
        'cboPriority
        '
        Me.cboPriority.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboPriority.FormattingEnabled = true
        Me.cboPriority.Items.AddRange(New Object() {"High", "Low", "Normal"})
        Me.cboPriority.Location = New System.Drawing.Point(112, 16)
        Me.cboPriority.Name = "cboPriority"
        Me.cboPriority.Size = New System.Drawing.Size(121, 23)
        Me.cboPriority.TabIndex = 2
        '
        'gpbReceipt
        '
        Me.gpbReceipt.Controls.Add(Me.chkSelectAllToReceive)
        Me.gpbReceipt.Controls.Add(Me.dgvMembersToReceive)
        Me.gpbReceipt.Controls.Add(Me.lblReceipientType)
        Me.gpbReceipt.Controls.Add(Me.cboRecepientType)
        Me.gpbReceipt.Controls.Add(Me.dgvAdditionalReceipients)
        Me.gpbReceipt.Controls.Add(Me.lblAdditionalReceipients)
        Me.gpbReceipt.Controls.Add(Me.lblMembersToReceive)
        Me.gpbReceipt.Controls.Add(Me.chkAllMembersReceive)
        Me.gpbReceipt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gpbReceipt.Location = New System.Drawing.Point(6, 7)
        Me.gpbReceipt.Name = "gpbReceipt"
        Me.gpbReceipt.Size = New System.Drawing.Size(423, 382)
        Me.gpbReceipt.TabIndex = 6
        Me.gpbReceipt.TabStop = false
        Me.gpbReceipt.Text = "Email Receipt"
        '
        'chkSelectAllToReceive
        '
        Me.chkSelectAllToReceive.AutoSize = true
        Me.chkSelectAllToReceive.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.chkSelectAllToReceive.Location = New System.Drawing.Point(337, 70)
        Me.chkSelectAllToReceive.Name = "chkSelectAllToReceive"
        Me.chkSelectAllToReceive.Size = New System.Drawing.Size(76, 19)
        Me.chkSelectAllToReceive.TabIndex = 11
        Me.chkSelectAllToReceive.Text = "Select All"
        Me.chkSelectAllToReceive.UseVisualStyleBackColor = true
        '
        'dgvMembersToReceive
        '
        Me.dgvMembersToReceive.AllowUserToAddRows = false
        Me.dgvMembersToReceive.AllowUserToDeleteRows = false
        Me.dgvMembersToReceive.AllowUserToResizeColumns = false
        Me.dgvMembersToReceive.AllowUserToResizeRows = false
        Me.dgvMembersToReceive.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvMembersToReceive.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMembersToReceive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMembersToReceive.ColumnHeadersVisible = false
        Me.dgvMembersToReceive.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmSelected, Me.clmMemberName, Me.clmReceipientType})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMembersToReceive.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMembersToReceive.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvMembersToReceive.Location = New System.Drawing.Point(6, 89)
        Me.dgvMembersToReceive.Name = "dgvMembersToReceive"
        Me.dgvMembersToReceive.RowHeadersVisible = false
        Me.dgvMembersToReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMembersToReceive.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvMembersToReceive.ShowEditingIcon = false
        Me.dgvMembersToReceive.Size = New System.Drawing.Size(407, 134)
        Me.dgvMembersToReceive.TabIndex = 10
        '
        'clmSelected
        '
        Me.clmSelected.HeaderText = ""
        Me.clmSelected.Name = "clmSelected"
        Me.clmSelected.Width = 25
        '
        'clmMemberName
        '
        Me.clmMemberName.HeaderText = "Member Name"
        Me.clmMemberName.Name = "clmMemberName"
        Me.clmMemberName.ReadOnly = true
        Me.clmMemberName.Width = 300
        '
        'clmReceipientType
        '
        Me.clmReceipientType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.clmReceipientType.HeaderText = "Recepient Type"
        Me.clmReceipientType.Items.AddRange(New Object() {"Bcc", "CC", "To"})
        Me.clmReceipientType.Name = "clmReceipientType"
        Me.clmReceipientType.Width = 60
        '
        'lblReceipientType
        '
        Me.lblReceipientType.AutoSize = true
        Me.lblReceipientType.Enabled = false
        Me.lblReceipientType.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblReceipientType.Location = New System.Drawing.Point(25, 46)
        Me.lblReceipientType.Name = "lblReceipientType"
        Me.lblReceipientType.Size = New System.Drawing.Size(91, 15)
        Me.lblReceipientType.TabIndex = 9
        Me.lblReceipientType.Text = "Receipient Type"
        '
        'cboRecepientType
        '
        Me.cboRecepientType.Enabled = false
        Me.cboRecepientType.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboRecepientType.FormattingEnabled = true
        Me.cboRecepientType.Items.AddRange(New Object() {"Bcc", "CC", "To"})
        Me.cboRecepientType.Location = New System.Drawing.Point(122, 43)
        Me.cboRecepientType.Name = "cboRecepientType"
        Me.cboRecepientType.Size = New System.Drawing.Size(121, 23)
        Me.cboRecepientType.TabIndex = 8
        '
        'dgvAdditionalReceipients
        '
        Me.dgvAdditionalReceipients.AllowUserToResizeColumns = false
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvAdditionalReceipients.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAdditionalReceipients.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvAdditionalReceipients.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAdditionalReceipients.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAdditionalReceipients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAdditionalReceipients.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmDisplayName, Me.clmAddress, Me.clmType})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAdditionalReceipients.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAdditionalReceipients.Location = New System.Drawing.Point(9, 245)
        Me.dgvAdditionalReceipients.Name = "dgvAdditionalReceipients"
        Me.dgvAdditionalReceipients.RowHeadersVisible = false
        Me.dgvAdditionalReceipients.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvAdditionalReceipients.ShowEditingIcon = false
        Me.dgvAdditionalReceipients.Size = New System.Drawing.Size(404, 124)
        Me.dgvAdditionalReceipients.TabIndex = 7
        '
        'clmDisplayName
        '
        Me.clmDisplayName.HeaderText = "Display Name"
        Me.clmDisplayName.Name = "clmDisplayName"
        Me.clmDisplayName.Width = 133
        '
        'clmAddress
        '
        Me.clmAddress.HeaderText = "Email Address"
        Me.clmAddress.Name = "clmAddress"
        Me.clmAddress.Width = 190
        '
        'clmType
        '
        Me.clmType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.[Nothing]
        Me.clmType.HeaderText = "Type"
        Me.clmType.Items.AddRange(New Object() {"Bcc", "CC", "To"})
        Me.clmType.Name = "clmType"
        Me.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clmType.Width = 60
        '
        'lblAdditionalReceipients
        '
        Me.lblAdditionalReceipients.AutoSize = true
        Me.lblAdditionalReceipients.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblAdditionalReceipients.Location = New System.Drawing.Point(6, 226)
        Me.lblAdditionalReceipients.Name = "lblAdditionalReceipients"
        Me.lblAdditionalReceipients.Size = New System.Drawing.Size(216, 15)
        Me.lblAdditionalReceipients.TabIndex = 6
        Me.lblAdditionalReceipients.Text = "Additional receipients for every Email:"
        '
        'lblMembersToReceive
        '
        Me.lblMembersToReceive.AutoSize = true
        Me.lblMembersToReceive.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblMembersToReceive.Location = New System.Drawing.Point(6, 71)
        Me.lblMembersToReceive.Name = "lblMembersToReceive"
        Me.lblMembersToReceive.Size = New System.Drawing.Size(245, 15)
        Me.lblMembersToReceive.TabIndex = 4
        Me.lblMembersToReceive.Text = "Members to receive every debrief via Email:"
        '
        'chkAllMembersReceive
        '
        Me.chkAllMembersReceive.AutoSize = true
        Me.chkAllMembersReceive.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.chkAllMembersReceive.Location = New System.Drawing.Point(6, 21)
        Me.chkAllMembersReceive.Name = "chkAllMembersReceive"
        Me.chkAllMembersReceive.Size = New System.Drawing.Size(328, 19)
        Me.chkAllMembersReceive.TabIndex = 0
        Me.chkAllMembersReceive.Text = "All members attending should receive debrief via Email"
        Me.chkAllMembersReceive.UseVisualStyleBackColor = true
        '
        'gbpCredentials
        '
        Me.gbpCredentials.Controls.Add(Me.chkShowPassword)
        Me.gbpCredentials.Controls.Add(Me.lblPassword)
        Me.gbpCredentials.Controls.Add(Me.txtPassword)
        Me.gbpCredentials.Controls.Add(Me.txtUserName)
        Me.gbpCredentials.Controls.Add(Me.lblUsername)
        Me.gbpCredentials.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbpCredentials.Location = New System.Drawing.Point(435, 94)
        Me.gbpCredentials.Name = "gbpCredentials"
        Me.gbpCredentials.Size = New System.Drawing.Size(286, 97)
        Me.gbpCredentials.TabIndex = 5
        Me.gbpCredentials.TabStop = false
        Me.gbpCredentials.Text = "Network Credentials"
        '
        'chkShowPassword
        '
        Me.chkShowPassword.AutoSize = true
        Me.chkShowPassword.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkShowPassword.Location = New System.Drawing.Point(82, 74)
        Me.chkShowPassword.Name = "chkShowPassword"
        Me.chkShowPassword.Size = New System.Drawing.Size(112, 19)
        Me.chkShowPassword.TabIndex = 8
        Me.chkShowPassword.Text = "Show Password"
        Me.chkShowPassword.UseVisualStyleBackColor = true
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = true
        Me.lblPassword.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPassword.Location = New System.Drawing.Point(15, 48)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(61, 15)
        Me.lblPassword.TabIndex = 7
        Me.lblPassword.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Wingdings", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2,Byte))
        Me.txtPassword.Location = New System.Drawing.Point(82, 45)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtPassword.Size = New System.Drawing.Size(194, 22)
        Me.txtPassword.TabIndex = 6
        '
        'txtUserName
        '
        Me.txtUserName.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtUserName.Location = New System.Drawing.Point(82, 16)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(194, 23)
        Me.txtUserName.TabIndex = 5
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = true
        Me.lblUsername.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblUsername.Location = New System.Drawing.Point(7, 19)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(66, 15)
        Me.lblUsername.TabIndex = 4
        Me.lblUsername.Text = "User Name"
        '
        'gbpMailServer
        '
        Me.gbpMailServer.BackColor = System.Drawing.Color.Silver
        Me.gbpMailServer.Controls.Add(Me.txtPort)
        Me.gbpMailServer.Controls.Add(Me.lblPort)
        Me.gbpMailServer.Controls.Add(Me.txtHost)
        Me.gbpMailServer.Controls.Add(Me.lblHost)
        Me.gbpMailServer.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbpMailServer.Location = New System.Drawing.Point(435, 7)
        Me.gbpMailServer.Name = "gbpMailServer"
        Me.gbpMailServer.Size = New System.Drawing.Size(286, 81)
        Me.gbpMailServer.TabIndex = 0
        Me.gbpMailServer.TabStop = false
        Me.gbpMailServer.Text = "Mail Server"
        '
        'txtPort
        '
        Me.txtPort.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtPort.Location = New System.Drawing.Point(115, 48)
        Me.txtPort.MaxLength = 3
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(29, 23)
        Me.txtPort.TabIndex = 3
        '
        'lblPort
        '
        Me.lblPort.AutoSize = true
        Me.lblPort.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPort.Location = New System.Drawing.Point(79, 51)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(30, 15)
        Me.lblPort.TabIndex = 2
        Me.lblPort.Text = "Port"
        '
        'txtHost
        '
        Me.txtHost.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtHost.Location = New System.Drawing.Point(115, 20)
        Me.txtHost.Name = "txtHost"
        Me.txtHost.Size = New System.Drawing.Size(161, 23)
        Me.txtHost.TabIndex = 1
        '
        'lblHost
        '
        Me.lblHost.AutoSize = true
        Me.lblHost.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblHost.Location = New System.Drawing.Point(7, 23)
        Me.lblHost.Name = "lblHost"
        Me.lblHost.Size = New System.Drawing.Size(102, 15)
        Me.lblHost.TabIndex = 0
        Me.lblHost.Text = "SMTP Host Server"
        '
        'cmsDeleteRow
        '
        Me.cmsDeleteRow.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteRowToolStripMenuItem})
        Me.cmsDeleteRow.Name = "cmsDeleteRow"
        Me.cmsDeleteRow.Size = New System.Drawing.Size(134, 26)
        '
        'DeleteRowToolStripMenuItem
        '
        Me.DeleteRowToolStripMenuItem.Name = "DeleteRowToolStripMenuItem"
        Me.DeleteRowToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.DeleteRowToolStripMenuItem.Text = "&Delete Row"
        '
        'tabSettings
        '
        Me.tabSettings.Controls.Add(Me.tabPageMemberDetails)
        Me.tabSettings.Controls.Add(Me.tabPageEmail)
        Me.tabSettings.Controls.Add(Me.tabPageJobsTasks)
        Me.tabSettings.Controls.Add(Me.tabLogistics)
        Me.tabSettings.Location = New System.Drawing.Point(13, 13)
        Me.tabSettings.Name = "tabSettings"
        Me.tabSettings.SelectedIndex = 0
        Me.tabSettings.Size = New System.Drawing.Size(741, 432)
        Me.tabSettings.TabIndex = 0
        '
        'tabPageMemberDetails
        '
        Me.tabPageMemberDetails.BackColor = System.Drawing.Color.Silver
        Me.tabPageMemberDetails.Controls.Add(Me.btnUpdate)
        Me.tabPageMemberDetails.Controls.Add(Me.grpUserManagement)
        Me.tabPageMemberDetails.Controls.Add(Me.grpMemberDetails)
        Me.tabPageMemberDetails.Controls.Add(Me.grpPrivledges)
        Me.tabPageMemberDetails.Controls.Add(Me.lblMember)
        Me.tabPageMemberDetails.Controls.Add(Me.cboMember)
        Me.tabPageMemberDetails.Controls.Add(Me.btnDelete)
        Me.tabPageMemberDetails.Controls.Add(Me.lblStatusFilter)
        Me.tabPageMemberDetails.Controls.Add(Me.cboStatusFilter)
        Me.tabPageMemberDetails.Controls.Add(Me.btnCreate)
        Me.tabPageMemberDetails.Location = New System.Drawing.Point(4, 24)
        Me.tabPageMemberDetails.Name = "tabPageMemberDetails"
        Me.tabPageMemberDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageMemberDetails.Size = New System.Drawing.Size(733, 404)
        Me.tabPageMemberDetails.TabIndex = 3
        Me.tabPageMemberDetails.Text = "Members"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnUpdate.Location = New System.Drawing.Point(155, 6)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 19
        Me.btnUpdate.Text = "&Update"
        Me.btnUpdate.UseVisualStyleBackColor = true
        '
        'grpUserManagement
        '
        Me.grpUserManagement.Controls.Add(Me.btnDefaultPrivledges)
        Me.grpUserManagement.Controls.Add(Me.btnResetPassword)
        Me.grpUserManagement.Enabled = false
        Me.grpUserManagement.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpUserManagement.Location = New System.Drawing.Point(8, 315)
        Me.grpUserManagement.Name = "grpUserManagement"
        Me.grpUserManagement.Size = New System.Drawing.Size(351, 73)
        Me.grpUserManagement.TabIndex = 18
        Me.grpUserManagement.TabStop = false
        Me.grpUserManagement.Text = "User Management"
        '
        'btnDefaultPrivledges
        '
        Me.btnDefaultPrivledges.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnDefaultPrivledges.Location = New System.Drawing.Point(125, 22)
        Me.btnDefaultPrivledges.Name = "btnDefaultPrivledges"
        Me.btnDefaultPrivledges.Size = New System.Drawing.Size(113, 23)
        Me.btnDefaultPrivledges.TabIndex = 14
        Me.btnDefaultPrivledges.Text = "Default &Privledges"
        Me.btnDefaultPrivledges.UseVisualStyleBackColor = true
        '
        'btnResetPassword
        '
        Me.btnResetPassword.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnResetPassword.Location = New System.Drawing.Point(6, 22)
        Me.btnResetPassword.Name = "btnResetPassword"
        Me.btnResetPassword.Size = New System.Drawing.Size(113, 23)
        Me.btnResetPassword.TabIndex = 13
        Me.btnResetPassword.Text = "&Reset Password"
        Me.btnResetPassword.UseVisualStyleBackColor = true
        '
        'grpMemberDetails
        '
        Me.grpMemberDetails.Controls.Add(Me.lblPosition)
        Me.grpMemberDetails.Controls.Add(Me.lblStatus)
        Me.grpMemberDetails.Controls.Add(Me.lblStatusTitle)
        Me.grpMemberDetails.Controls.Add(Me.lblID)
        Me.grpMemberDetails.Controls.Add(Me.lblEmail)
        Me.grpMemberDetails.Controls.Add(Me.lblFirstName)
        Me.grpMemberDetails.Controls.Add(Me.lblSurname)
        Me.grpMemberDetails.Controls.Add(Me.lblIDTitle)
        Me.grpMemberDetails.Controls.Add(Me.lblSurnameTitle)
        Me.grpMemberDetails.Controls.Add(Me.lblFirstNameTitle)
        Me.grpMemberDetails.Controls.Add(Me.lblEmailTitle)
        Me.grpMemberDetails.Controls.Add(Me.lblPositionTitle)
        Me.grpMemberDetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpMemberDetails.Location = New System.Drawing.Point(8, 107)
        Me.grpMemberDetails.Name = "grpMemberDetails"
        Me.grpMemberDetails.Size = New System.Drawing.Size(351, 202)
        Me.grpMemberDetails.TabIndex = 17
        Me.grpMemberDetails.TabStop = false
        Me.grpMemberDetails.Text = "Member Details"
        '
        'lblPosition
        '
        Me.lblPosition.BackColor = System.Drawing.Color.White
        Me.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPosition.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPosition.Location = New System.Drawing.Point(79, 136)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(260, 23)
        Me.lblPosition.TabIndex = 20
        Me.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatus
        '
        Me.lblStatus.BackColor = System.Drawing.Color.White
        Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblStatus.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblStatus.Location = New System.Drawing.Point(80, 165)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(260, 23)
        Me.lblStatus.TabIndex = 19
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStatusTitle
        '
        Me.lblStatusTitle.AutoSize = true
        Me.lblStatusTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblStatusTitle.Location = New System.Drawing.Point(33, 169)
        Me.lblStatusTitle.Name = "lblStatusTitle"
        Me.lblStatusTitle.Size = New System.Drawing.Size(41, 15)
        Me.lblStatusTitle.TabIndex = 17
        Me.lblStatusTitle.Text = "Status"
        '
        'lblID
        '
        Me.lblID.BackColor = System.Drawing.Color.White
        Me.lblID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblID.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblID.Location = New System.Drawing.Point(80, 21)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(62, 23)
        Me.lblID.TabIndex = 16
        Me.lblID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmail
        '
        Me.lblEmail.BackColor = System.Drawing.Color.White
        Me.lblEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEmail.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblEmail.Location = New System.Drawing.Point(79, 107)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(260, 23)
        Me.lblEmail.TabIndex = 15
        Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFirstName
        '
        Me.lblFirstName.BackColor = System.Drawing.Color.White
        Me.lblFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblFirstName.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblFirstName.Location = New System.Drawing.Point(79, 79)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(260, 23)
        Me.lblFirstName.TabIndex = 14
        Me.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSurname
        '
        Me.lblSurname.BackColor = System.Drawing.Color.White
        Me.lblSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSurname.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSurname.Location = New System.Drawing.Point(80, 50)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(260, 23)
        Me.lblSurname.TabIndex = 13
        Me.lblSurname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIDTitle
        '
        Me.lblIDTitle.AutoSize = true
        Me.lblIDTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblIDTitle.Location = New System.Drawing.Point(55, 25)
        Me.lblIDTitle.Name = "lblIDTitle"
        Me.lblIDTitle.Size = New System.Drawing.Size(19, 15)
        Me.lblIDTitle.TabIndex = 2
        Me.lblIDTitle.Text = "ID"
        '
        'lblSurnameTitle
        '
        Me.lblSurnameTitle.AutoSize = true
        Me.lblSurnameTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSurnameTitle.Location = New System.Drawing.Point(19, 54)
        Me.lblSurnameTitle.Name = "lblSurnameTitle"
        Me.lblSurnameTitle.Size = New System.Drawing.Size(55, 15)
        Me.lblSurnameTitle.TabIndex = 4
        Me.lblSurnameTitle.Text = "Surname"
        '
        'lblFirstNameTitle
        '
        Me.lblFirstNameTitle.AutoSize = true
        Me.lblFirstNameTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblFirstNameTitle.Location = New System.Drawing.Point(8, 83)
        Me.lblFirstNameTitle.Name = "lblFirstNameTitle"
        Me.lblFirstNameTitle.Size = New System.Drawing.Size(66, 15)
        Me.lblFirstNameTitle.TabIndex = 6
        Me.lblFirstNameTitle.Text = "First Name"
        '
        'lblEmailTitle
        '
        Me.lblEmailTitle.AutoSize = true
        Me.lblEmailTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblEmailTitle.Location = New System.Drawing.Point(36, 111)
        Me.lblEmailTitle.Name = "lblEmailTitle"
        Me.lblEmailTitle.Size = New System.Drawing.Size(38, 15)
        Me.lblEmailTitle.TabIndex = 8
        Me.lblEmailTitle.Text = "Email"
        '
        'lblPositionTitle
        '
        Me.lblPositionTitle.AutoSize = true
        Me.lblPositionTitle.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPositionTitle.Location = New System.Drawing.Point(19, 140)
        Me.lblPositionTitle.Name = "lblPositionTitle"
        Me.lblPositionTitle.Size = New System.Drawing.Size(52, 15)
        Me.lblPositionTitle.TabIndex = 10
        Me.lblPositionTitle.Text = "Position"
        '
        'grpPrivledges
        '
        Me.grpPrivledges.Controls.Add(Me.tstvPrivledges)
        Me.grpPrivledges.Enabled = false
        Me.grpPrivledges.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpPrivledges.Location = New System.Drawing.Point(376, 6)
        Me.grpPrivledges.Name = "grpPrivledges"
        Me.grpPrivledges.Size = New System.Drawing.Size(351, 303)
        Me.grpPrivledges.TabIndex = 16
        Me.grpPrivledges.TabStop = false
        Me.grpPrivledges.Text = "Privledges"
        '
        'tstvPrivledges
        '
        Me.tstvPrivledges.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.tstvPrivledges.Location = New System.Drawing.Point(9, 22)
        Me.tstvPrivledges.Name = "tstvPrivledges"
        TreeNode1.Name = "ndeDebriefs"
        TreeNode1.StateImageIndex = 0
        TreeNode1.Text = "Debriefs"
        TreeNode2.Name = "ndeAssignPrivledges"
        TreeNode2.StateImageIndex = 0
        TreeNode2.Text = "Assign Privledges"
        TreeNode3.Name = "ndeResetOwnPassword"
        TreeNode3.StateImageIndex = 0
        TreeNode3.Text = "Reset Own Password"
        TreeNode4.Name = "ndeResetOtherPassword"
        TreeNode4.StateImageIndex = 0
        TreeNode4.Text = "Reset Other Password"
        TreeNode5.Name = "ndeUserManagement"
        TreeNode5.StateImageIndex = 0
        TreeNode5.Text = "User Management"
        TreeNode6.Name = "ndeCreateNewMember"
        TreeNode6.StateImageIndex = 0
        TreeNode6.Text = "Create New Member"
        TreeNode7.Name = "ndeUpdateSelf"
        TreeNode7.StateImageIndex = 0
        TreeNode7.Text = "Update Self"
        TreeNode8.Name = "ndeUpdateAnotherMember"
        TreeNode8.StateImageIndex = 0
        TreeNode8.Text = "Update Another Member"
        TreeNode9.Name = "ndeDeleteMember"
        TreeNode9.StateImageIndex = 0
        TreeNode9.Text = "Delete Member"
        TreeNode10.Name = "ndeMembers"
        TreeNode10.StateImageIndex = 0
        TreeNode10.Text = "Members"
        TreeNode11.Name = "ndeUpdateEmailReceipients"
        TreeNode11.StateImageIndex = 0
        TreeNode11.Text = "Update Email Receipients"
        TreeNode12.Name = "ndeUpdateMailServer"
        TreeNode12.StateImageIndex = 0
        TreeNode12.Text = "Update Mail Server"
        TreeNode13.Name = "ndeUpdateNetworkCredentials"
        TreeNode13.StateImageIndex = 0
        TreeNode13.Text = "Update Network Credentials"
        TreeNode14.Name = "ndeUpdateClientSettings"
        TreeNode14.StateImageIndex = 0
        TreeNode14.Text = "Update Client Settings"
        TreeNode15.Name = "ndeUpdateFromAddress"
        TreeNode15.StateImageIndex = 0
        TreeNode15.Text = "Update From Address"
        TreeNode16.Name = "ndeEmailSettings"
        TreeNode16.StateImageIndex = 0
        TreeNode16.Text = "Email Settings"
        TreeNode17.Name = "ndeUpdateJobTypes"
        TreeNode17.StateImageIndex = 0
        TreeNode17.Text = "Update Job Types"
        TreeNode18.Name = "ndeUpdateTasks"
        TreeNode18.StateImageIndex = 0
        TreeNode18.Text = "Update Tasks"
        TreeNode19.Name = "ndeJobTypesAndTasks"
        TreeNode19.StateImageIndex = 0
        TreeNode19.Text = "Job Types & Tasks"
        TreeNode20.Name = "ndeUpdateVehicles"
        TreeNode20.StateImageIndex = 0
        TreeNode20.Text = "Update Vehicles"
        TreeNode21.Name = "ndeUpdateEquipment"
        TreeNode21.StateImageIndex = 0
        TreeNode21.Text = "Update Equipment"
        TreeNode22.Name = "ndeLogistics"
        TreeNode22.StateImageIndex = 0
        TreeNode22.Text = "Logistics"
        TreeNode23.Name = "ndeSettings"
        TreeNode23.StateImageIndex = 0
        TreeNode23.Text = "Settings"
        Me.tstvPrivledges.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode23})
        Me.tstvPrivledges.Size = New System.Drawing.Size(336, 267)
        Me.tstvPrivledges.TabIndex = 3
        Me.tstvPrivledges.TriStateStyleProperty = PostOpRep.Controls.TriStateTreeView.TriStateStyles.Standard
        '
        'lblMember
        '
        Me.lblMember.AutoSize = true
        Me.lblMember.Location = New System.Drawing.Point(29, 75)
        Me.lblMember.Name = "lblMember"
        Me.lblMember.Size = New System.Drawing.Size(52, 15)
        Me.lblMember.TabIndex = 15
        Me.lblMember.Text = "Member"
        '
        'cboMember
        '
        Me.cboMember.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMember.FormattingEnabled = true
        Me.cboMember.Location = New System.Drawing.Point(87, 72)
        Me.cboMember.Name = "cboMember"
        Me.cboMember.Size = New System.Drawing.Size(212, 23)
        Me.cboMember.TabIndex = 14
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnDelete.Location = New System.Drawing.Point(248, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = true
        '
        'lblStatusFilter
        '
        Me.lblStatusFilter.AutoSize = true
        Me.lblStatusFilter.Location = New System.Drawing.Point(8, 41)
        Me.lblStatusFilter.Name = "lblStatusFilter"
        Me.lblStatusFilter.Size = New System.Drawing.Size(73, 15)
        Me.lblStatusFilter.TabIndex = 1
        Me.lblStatusFilter.Text = "Status Filter"
        '
        'cboStatusFilter
        '
        Me.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusFilter.FormattingEnabled = true
        Me.cboStatusFilter.Location = New System.Drawing.Point(87, 38)
        Me.cboStatusFilter.Name = "cboStatusFilter"
        Me.cboStatusFilter.Size = New System.Drawing.Size(212, 23)
        Me.cboStatusFilter.TabIndex = 0
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnCreate.Location = New System.Drawing.Point(62, 6)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(75, 23)
        Me.btnCreate.TabIndex = 12
        Me.btnCreate.Text = "&Create"
        Me.btnCreate.UseVisualStyleBackColor = true
        '
        'tabLogistics
        '
        Me.tabLogistics.BackColor = System.Drawing.Color.Silver
        Me.tabLogistics.Controls.Add(Me.grpEquipment)
        Me.tabLogistics.Controls.Add(Me.grpVehicles)
        Me.tabLogistics.Location = New System.Drawing.Point(4, 24)
        Me.tabLogistics.Name = "tabLogistics"
        Me.tabLogistics.Size = New System.Drawing.Size(733, 404)
        Me.tabLogistics.TabIndex = 4
        Me.tabLogistics.Text = "Logistics"
        '
        'grpEquipment
        '
        Me.grpEquipment.Controls.Add(Me.dgvEquipment)
        Me.grpEquipment.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpEquipment.Location = New System.Drawing.Point(374, 6)
        Me.grpEquipment.Name = "grpEquipment"
        Me.grpEquipment.Size = New System.Drawing.Size(353, 392)
        Me.grpEquipment.TabIndex = 2
        Me.grpEquipment.TabStop = false
        Me.grpEquipment.Text = "Equipment"
        '
        'dgvEquipment
        '
        Me.dgvEquipment.AllowUserToResizeColumns = false
        Me.dgvEquipment.AllowUserToResizeRows = false
        Me.dgvEquipment.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipment.ColumnHeadersVisible = false
        Me.dgvEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmEquipmentItem})
        Me.dgvEquipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEquipment.Location = New System.Drawing.Point(6, 22)
        Me.dgvEquipment.MultiSelect = false
        Me.dgvEquipment.Name = "dgvEquipment"
        Me.dgvEquipment.RowHeadersVisible = false
        Me.dgvEquipment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEquipment.ShowEditingIcon = false
        Me.dgvEquipment.Size = New System.Drawing.Size(341, 364)
        Me.dgvEquipment.TabIndex = 0
        '
        'clmEquipmentItem
        '
        Me.clmEquipmentItem.HeaderText = "Item"
        Me.clmEquipmentItem.Name = "clmEquipmentItem"
        '
        'grpVehicles
        '
        Me.grpVehicles.Controls.Add(Me.dgvVehicles)
        Me.grpVehicles.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpVehicles.Location = New System.Drawing.Point(6, 6)
        Me.grpVehicles.Name = "grpVehicles"
        Me.grpVehicles.Size = New System.Drawing.Size(353, 392)
        Me.grpVehicles.TabIndex = 1
        Me.grpVehicles.TabStop = false
        Me.grpVehicles.Text = "Vehicles"
        '
        'dgvVehicles
        '
        Me.dgvVehicles.AllowUserToResizeColumns = false
        Me.dgvVehicles.AllowUserToResizeRows = false
        Me.dgvVehicles.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVehicles.ColumnHeadersVisible = false
        Me.dgvVehicles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmVehicleName})
        Me.dgvVehicles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvVehicles.Location = New System.Drawing.Point(6, 22)
        Me.dgvVehicles.MultiSelect = false
        Me.dgvVehicles.Name = "dgvVehicles"
        Me.dgvVehicles.RowHeadersVisible = false
        Me.dgvVehicles.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvVehicles.ShowEditingIcon = false
        Me.dgvVehicles.Size = New System.Drawing.Size(341, 364)
        Me.dgvVehicles.TabIndex = 0
        '
        'clmVehicleName
        '
        Me.clmVehicleName.HeaderText = "Name"
        Me.clmVehicleName.Name = "clmVehicleName"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(518, 453)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(599, 453)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(679, 453)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 3
        Me.btnApply.Text = "&Apply"
        Me.btnApply.UseVisualStyleBackColor = true
        '
        'SettingsForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(766, 483)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.tabSettings)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "SettingsForm"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.tabPageJobsTasks.ResumeLayout(false)
        Me.grpTasks.ResumeLayout(false)
        CType(Me.dgvTasks,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpJobTypes.ResumeLayout(false)
        CType(Me.dgvJobType,System.ComponentModel.ISupportInitialize).EndInit
        Me.tabPageEmail.ResumeLayout(false)
        Me.gbpFromAddress.ResumeLayout(false)
        Me.gbpFromAddress.PerformLayout
        Me.gbpClient.ResumeLayout(false)
        Me.gbpClient.PerformLayout
        Me.gpbReceipt.ResumeLayout(false)
        Me.gpbReceipt.PerformLayout
        CType(Me.dgvMembersToReceive,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.dgvAdditionalReceipients,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbpCredentials.ResumeLayout(false)
        Me.gbpCredentials.PerformLayout
        Me.gbpMailServer.ResumeLayout(false)
        Me.gbpMailServer.PerformLayout
        Me.cmsDeleteRow.ResumeLayout(false)
        Me.tabSettings.ResumeLayout(false)
        Me.tabPageMemberDetails.ResumeLayout(false)
        Me.tabPageMemberDetails.PerformLayout
        Me.grpUserManagement.ResumeLayout(false)
        Me.grpMemberDetails.ResumeLayout(false)
        Me.grpMemberDetails.PerformLayout
        Me.grpPrivledges.ResumeLayout(false)
        Me.tabLogistics.ResumeLayout(false)
        Me.grpEquipment.ResumeLayout(false)
        CType(Me.dgvEquipment,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpVehicles.ResumeLayout(false)
        CType(Me.dgvVehicles,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents tabPageJobsTasks As TabPage
    Friend WithEvents tabPageEmail As TabPage
    Friend WithEvents gpbReceipt As GroupBox
    Friend WithEvents chkAllMembersReceive As CheckBox
    Friend WithEvents gbpCredentials As GroupBox
    Friend WithEvents chkShowPassword As CheckBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserName As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents gbpMailServer As GroupBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents lblPort As Label
    Friend WithEvents txtHost As TextBox
    Friend WithEvents lblHost As Label
    Friend WithEvents tabSettings As TabControl
    Friend WithEvents lblPriority As Label
    Friend WithEvents cboPriority As ComboBox
    Friend WithEvents lblMembersToReceive As Label
    Friend WithEvents tabPageMemberDetails As TabPage
    Friend WithEvents gbpClient As GroupBox
    Friend WithEvents lblAdditionalReceipients As Label
    Friend WithEvents cboEnableSSL As ComboBox
    Friend WithEvents lblEnableSSL As Label
    Friend WithEvents txtSMTPTimeout As TextBox
    Friend WithEvents lblTimeout As Label
    Friend WithEvents lblSeconds As Label
    Friend WithEvents dgvAdditionalReceipients As DataGridView
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents gbpFromAddress As GroupBox
    Friend WithEvents lblAddress As Label
    Friend WithEvents txtFromAddress As TextBox
    Friend WithEvents txtDisplayName As TextBox
    Friend WithEvents lblDisplayName As Label
    Friend WithEvents btnApply As Button
    Friend WithEvents lblReceipientType As Label
    Friend WithEvents cboRecepientType As ComboBox
    Friend WithEvents dgvMembersToReceive As DataGridView
    Friend WithEvents clmSelected As DataGridViewCheckBoxColumn
    Friend WithEvents clmMemberName As DataGridViewTextBoxColumn
    Friend WithEvents clmReceipientType As DataGridViewComboBoxColumn
    Friend WithEvents chkSelectAllToReceive As CheckBox
    Friend WithEvents clmDisplayName As DataGridViewTextBoxColumn
    Friend WithEvents clmAddress As DataGridViewTextBoxColumn
    Friend WithEvents clmType As DataGridViewComboBoxColumn
    Friend WithEvents cmsDeleteRow As ContextMenuStrip
    Friend WithEvents DeleteRowToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tipSMTPHost As ToolTip
    Friend WithEvents cboStatusFilter As ComboBox
    Friend WithEvents lblStatusFilter As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents lblMember As Label
    Friend WithEvents cboMember As ComboBox
    Friend WithEvents grpPrivledges As GroupBox
    Friend WithEvents grpJobTypes As GroupBox
    Friend WithEvents grpTasks As GroupBox
    Friend WithEvents dgvJobType As DataGridView
    Friend WithEvents clmJobType As DataGridViewTextBoxColumn
    Friend WithEvents dgvTasks As DataGridView
    Friend WithEvents clmTask As DataGridViewTextBoxColumn
    Friend WithEvents tabLogistics As TabPage
    Friend WithEvents grpVehicles As GroupBox
    Friend WithEvents dgvVehicles As DataGridView
    Friend WithEvents grpEquipment As GroupBox
    Friend WithEvents dgvEquipment As DataGridView
    Friend WithEvents clmEquipmentItem As DataGridViewTextBoxColumn
    Friend WithEvents clmVehicleName As DataGridViewTextBoxColumn
    Friend WithEvents grpMemberDetails As GroupBox
    Friend WithEvents grpUserManagement As GroupBox
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents lblIDTitle As Label
    Friend WithEvents lblSurnameTitle As Label
    Friend WithEvents lblFirstNameTitle As Label
    Friend WithEvents lblEmailTitle As Label
    Friend WithEvents lblPositionTitle As Label
    Friend WithEvents lblSurname As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents lblID As Label
    Friend WithEvents btnUpdate As Button
    Friend WithEvents tstvPrivledges As Controls.TriStateTreeView
    Friend WithEvents btnDefaultPrivledges As Button
    Friend WithEvents lblStatusTitle As Label
    Friend WithEvents lblPosition As Label
    Friend WithEvents lblStatus As Label
End Class
