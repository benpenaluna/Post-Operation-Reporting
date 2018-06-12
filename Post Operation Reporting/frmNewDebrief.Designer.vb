<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmNewDebrief
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpLogistics = New System.Windows.Forms.GroupBox()
        Me.txtEquipment = New System.Windows.Forms.TextBox()
        Me.lblEasier = New System.Windows.Forms.Label()
        Me.txtIssues = New System.Windows.Forms.TextBox()
        Me.btnRight = New System.Windows.Forms.Button()
        Me.lblIssues = New System.Windows.Forms.Label()
        Me.btnLeft = New System.Windows.Forms.Button()
        Me.lstUnitVehicles = New System.Windows.Forms.ListBox()
        Me.lblUnitVehicles = New System.Windows.Forms.Label()
        Me.lstVehiclesUsed = New System.Windows.Forms.ListBox()
        Me.lblVehiclesUsed = New System.Windows.Forms.Label()
        Me.grpPersonel = New System.Windows.Forms.GroupBox()
        Me.dgvMembersAttending = New System.Windows.Forms.DataGridView()
        Me.clmMember1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clmTask1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblTaskUndertaken = New System.Windows.Forms.Label()
        Me.btnRightMembers = New System.Windows.Forms.Button()
        Me.lblMembersAttending = New System.Windows.Forms.Label()
        Me.btnLeftMembers = New System.Windows.Forms.Button()
        Me.lblCurrentMembers = New System.Windows.Forms.Label()
        Me.lstCurrentMembers = New System.Windows.Forms.ListBox()
        Me.btnEmail = New System.Windows.Forms.Button()
        Me.grpSafetyTraining = New System.Windows.Forms.GroupBox()
        Me.cboTrained = New System.Windows.Forms.ComboBox()
        Me.lblTraining = New System.Windows.Forms.Label()
        Me.txtSkills = New System.Windows.Forms.TextBox()
        Me.lblSkills = New System.Windows.Forms.Label()
        Me.txtSafetyConcerns = New System.Windows.Forms.TextBox()
        Me.lblSafetyConcerns = New System.Windows.Forms.Label()
        Me.cboSafety = New System.Windows.Forms.ComboBox()
        Me.lblSafety = New System.Windows.Forms.Label()
        Me.grpOperational = New System.Windows.Forms.GroupBox()
        Me.cboMyCouncil = New System.Windows.Forms.ComboBox()
        Me.lblMyCouncil = New System.Windows.Forms.Label()
        Me.cboFirstAid = New System.Windows.Forms.ComboBox()
        Me.lblFirstAid = New System.Windows.Forms.Label()
        Me.cboPlanB = New System.Windows.Forms.ComboBox()
        Me.lblPlanB = New System.Windows.Forms.Label()
        Me.cboClearToAll = New System.Windows.Forms.ComboBox()
        Me.lblClearToAll = New System.Windows.Forms.Label()
        Me.txtPlan = New System.Windows.Forms.TextBox()
        Me.lblPlan = New System.Windows.Forms.Label()
        Me.txtJobDescription = New System.Windows.Forms.TextBox()
        Me.lblJobDescription = New System.Windows.Forms.Label()
        Me.cboCrewLeader = New System.Windows.Forms.ComboBox()
        Me.lblCrewLeader = New System.Windows.Forms.Label()
        Me.cboSESCommander = New System.Windows.Forms.ComboBox()
        Me.lblCommander = New System.Windows.Forms.Label()
        Me.grpEquipmentUsed = New System.Windows.Forms.GroupBox()
        Me.lblDuration = New System.Windows.Forms.Label()
        Me.lblMember = New System.Windows.Forms.Label()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.dgvEquipment = New System.Windows.Forms.DataGridView()
        Me.clmItemUsed = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Duration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.pnlDetails = New System.Windows.Forms.Panel()
        Me.lblDetails = New System.Windows.Forms.Label()
        Me.cboDebriefType = New System.Windows.Forms.ComboBox()
        Me.lblDebriefType = New System.Windows.Forms.Label()
        Me.lblEventNo = New System.Windows.Forms.Label()
        Me.lblIncorrectEventNumber = New System.Windows.Forms.Label()
        Me.txtEventNumber = New System.Windows.Forms.TextBox()
        Me.pnlDate = New System.Windows.Forms.Panel()
        Me.dtpStart = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtFinishTime = New System.Windows.Forms.MaskedTextBox()
        Me.lblJobType = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtStartTime = New System.Windows.Forms.MaskedTextBox()
        Me.cboJobType = New System.Windows.Forms.ComboBox()
        Me.lblStartTime = New System.Windows.Forms.Label()
        Me.dtpFinish = New System.Windows.Forms.DateTimePicker()
        Me.lblFinishDate = New System.Windows.Forms.Label()
        Me.lblPadding = New System.Windows.Forms.Label()
        Me.grpLogistics.SuspendLayout()
        Me.grpPersonel.SuspendLayout()
        CType(Me.dgvMembersAttending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSafetyTraining.SuspendLayout()
        Me.grpOperational.SuspendLayout()
        Me.grpEquipmentUsed.SuspendLayout()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetails.SuspendLayout()
        Me.pnlDate.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLogistics
        '
        Me.grpLogistics.BackColor = System.Drawing.Color.Violet
        Me.grpLogistics.Controls.Add(Me.txtEquipment)
        Me.grpLogistics.Controls.Add(Me.lblEasier)
        Me.grpLogistics.Controls.Add(Me.txtIssues)
        Me.grpLogistics.Controls.Add(Me.btnRight)
        Me.grpLogistics.Controls.Add(Me.lblIssues)
        Me.grpLogistics.Controls.Add(Me.btnLeft)
        Me.grpLogistics.Controls.Add(Me.lstUnitVehicles)
        Me.grpLogistics.Controls.Add(Me.lblUnitVehicles)
        Me.grpLogistics.Controls.Add(Me.lstVehiclesUsed)
        Me.grpLogistics.Controls.Add(Me.lblVehiclesUsed)
        Me.grpLogistics.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpLogistics.Location = New System.Drawing.Point(744, 323)
        Me.grpLogistics.Name = "grpLogistics"
        Me.grpLogistics.Size = New System.Drawing.Size(723, 372)
        Me.grpLogistics.TabIndex = 8
        Me.grpLogistics.TabStop = False
        Me.grpLogistics.Text = "Logistics"
        '
        'txtEquipment
        '
        Me.txtEquipment.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtEquipment.Location = New System.Drawing.Point(6, 271)
        Me.txtEquipment.Multiline = True
        Me.txtEquipment.Name = "txtEquipment"
        Me.txtEquipment.Size = New System.Drawing.Size(706, 94)
        Me.txtEquipment.TabIndex = 6
        '
        'lblEasier
        '
        Me.lblEasier.AutoSize = True
        Me.lblEasier.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblEasier.Location = New System.Drawing.Point(6, 253)
        Me.lblEasier.Name = "lblEasier"
        Me.lblEasier.Size = New System.Drawing.Size(270, 15)
        Me.lblEasier.TabIndex = 18
        Me.lblEasier.Text = "Equipment that would have made the job easier:"
        '
        'txtIssues
        '
        Me.txtIssues.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtIssues.Location = New System.Drawing.Point(6, 154)
        Me.txtIssues.Multiline = True
        Me.txtIssues.Name = "txtIssues"
        Me.txtIssues.Size = New System.Drawing.Size(706, 94)
        Me.txtIssues.TabIndex = 5
        '
        'btnRight
        '
        Me.btnRight.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnRight.Location = New System.Drawing.Point(344, 85)
        Me.btnRight.Name = "btnRight"
        Me.btnRight.Size = New System.Drawing.Size(28, 23)
        Me.btnRight.TabIndex = 3
        Me.btnRight.Text = ">>"
        Me.btnRight.UseVisualStyleBackColor = True
        '
        'lblIssues
        '
        Me.lblIssues.AutoSize = True
        Me.lblIssues.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblIssues.Location = New System.Drawing.Point(6, 136)
        Me.lblIssues.Name = "lblIssues"
        Me.lblIssues.Size = New System.Drawing.Size(188, 15)
        Me.lblIssues.TabIndex = 16
        Me.lblIssues.Text = "Issues for Vehicles or Equipment:"
        '
        'btnLeft
        '
        Me.btnLeft.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnLeft.Location = New System.Drawing.Point(344, 58)
        Me.btnLeft.Name = "btnLeft"
        Me.btnLeft.Size = New System.Drawing.Size(28, 23)
        Me.btnLeft.TabIndex = 2
        Me.btnLeft.Text = "<<"
        Me.btnLeft.UseVisualStyleBackColor = True
        '
        'lstUnitVehicles
        '
        Me.lstUnitVehicles.AllowDrop = True
        Me.lstUnitVehicles.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lstUnitVehicles.FormattingEnabled = True
        Me.lstUnitVehicles.ItemHeight = 15
        Me.lstUnitVehicles.Location = New System.Drawing.Point(377, 35)
        Me.lstUnitVehicles.Name = "lstUnitVehicles"
        Me.lstUnitVehicles.Size = New System.Drawing.Size(334, 94)
        Me.lstUnitVehicles.Sorted = True
        Me.lstUnitVehicles.TabIndex = 4
        '
        'lblUnitVehicles
        '
        Me.lblUnitVehicles.AutoSize = True
        Me.lblUnitVehicles.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblUnitVehicles.Location = New System.Drawing.Point(379, 17)
        Me.lblUnitVehicles.Name = "lblUnitVehicles"
        Me.lblUnitVehicles.Size = New System.Drawing.Size(81, 15)
        Me.lblUnitVehicles.TabIndex = 2
        Me.lblUnitVehicles.Text = "Unit Vehicles:"
        '
        'lstVehiclesUsed
        '
        Me.lstVehiclesUsed.AllowDrop = True
        Me.lstVehiclesUsed.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lstVehiclesUsed.FormattingEnabled = True
        Me.lstVehiclesUsed.ItemHeight = 15
        Me.lstVehiclesUsed.Location = New System.Drawing.Point(6, 35)
        Me.lstVehiclesUsed.Name = "lstVehiclesUsed"
        Me.lstVehiclesUsed.Size = New System.Drawing.Size(334, 94)
        Me.lstVehiclesUsed.Sorted = True
        Me.lstVehiclesUsed.TabIndex = 1
        '
        'lblVehiclesUsed
        '
        Me.lblVehiclesUsed.AutoSize = True
        Me.lblVehiclesUsed.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblVehiclesUsed.Location = New System.Drawing.Point(6, 17)
        Me.lblVehiclesUsed.Name = "lblVehiclesUsed"
        Me.lblVehiclesUsed.Size = New System.Drawing.Size(85, 15)
        Me.lblVehiclesUsed.TabIndex = 0
        Me.lblVehiclesUsed.Text = "Vehicles Used:"
        '
        'grpPersonel
        '
        Me.grpPersonel.BackColor = System.Drawing.Color.Orange
        Me.grpPersonel.Controls.Add(Me.dgvMembersAttending)
        Me.grpPersonel.Controls.Add(Me.lblTaskUndertaken)
        Me.grpPersonel.Controls.Add(Me.btnRightMembers)
        Me.grpPersonel.Controls.Add(Me.lblMembersAttending)
        Me.grpPersonel.Controls.Add(Me.btnLeftMembers)
        Me.grpPersonel.Controls.Add(Me.lblCurrentMembers)
        Me.grpPersonel.Controls.Add(Me.lstCurrentMembers)
        Me.grpPersonel.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpPersonel.Location = New System.Drawing.Point(10, 707)
        Me.grpPersonel.Name = "grpPersonel"
        Me.grpPersonel.Size = New System.Drawing.Size(723, 301)
        Me.grpPersonel.TabIndex = 9
        Me.grpPersonel.TabStop = False
        Me.grpPersonel.Text = "Members Attending"
        '
        'dgvMembersAttending
        '
        Me.dgvMembersAttending.AllowDrop = True
        Me.dgvMembersAttending.AllowUserToAddRows = False
        Me.dgvMembersAttending.AllowUserToDeleteRows = False
        Me.dgvMembersAttending.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.dgvMembersAttending.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMembersAttending.BackgroundColor = System.Drawing.Color.White
        Me.dgvMembersAttending.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvMembersAttending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMembersAttending.ColumnHeadersVisible = False
        Me.dgvMembersAttending.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmMember1, Me.clmTask1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMembersAttending.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMembersAttending.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvMembersAttending.Location = New System.Drawing.Point(227, 37)
        Me.dgvMembersAttending.MultiSelect = False
        Me.dgvMembersAttending.Name = "dgvMembersAttending"
        Me.dgvMembersAttending.RowHeadersVisible = False
        Me.dgvMembersAttending.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvMembersAttending.Size = New System.Drawing.Size(486, 243)
        Me.dgvMembersAttending.TabIndex = 3
        '
        'clmMember1
        '
        Me.clmMember1.HeaderText = "Member"
        Me.clmMember1.Name = "clmMember1"
        Me.clmMember1.ReadOnly = True
        Me.clmMember1.Width = 200
        '
        'clmTask1
        '
        Me.clmTask1.AutoComplete = False
        Me.clmTask1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.clmTask1.HeaderText = "Task Undertaken"
        Me.clmTask1.Items.AddRange(New Object() {"At LHQ", "Chainsaw Operator", "Coxswain", "Crew Leader (Assist Agency)", "Crew Leader (Land Search)", "Crew Leader (Other)", "Crew Leader (RCR)", "Crew Leader (Storm & Water Damage)", "Crew Person (Assist Agency)", "Crew Person (Land Search)", "Crew Person (Other)", "Crew Person (RCR)", "Crew Person (Rescue Boat)", "Crew Person (Storm & Water Damage)", "First Aid", "Four Wheel Drive Operator", "Incident Command Point Operator", "Incident Command Point Commander", "Incident Commander (Other)", "Incident Commander (Storm & Water Damage)", "Navigator (Land Search)", "Other", "Roof Safety System (On-Ground)", "Roof Safety System (On-Roof)", "Safety (Other)", "Safety (RCR)", "Sandbagging", "SES Commander (Other)", "SES Commander (RCR)", "Temporary Building Repairs", "Tool Operator (RCR)", "Traffic Management", "Truck Driver (EVS)", "Truck Driver (Other)", "USAR Operator (Cat 2.)", "USAR Operator (Cat. 1)", "Water Pumping"})
        Me.clmTask1.Name = "clmTask1"
        Me.clmTask1.Width = 259
        '
        'lblTaskUndertaken
        '
        Me.lblTaskUndertaken.AutoSize = True
        Me.lblTaskUndertaken.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblTaskUndertaken.Location = New System.Drawing.Point(490, 19)
        Me.lblTaskUndertaken.Name = "lblTaskUndertaken"
        Me.lblTaskUndertaken.Size = New System.Drawing.Size(100, 15)
        Me.lblTaskUndertaken.TabIndex = 22
        Me.lblTaskUndertaken.Text = "Task Undertaken:"
        '
        'btnRightMembers
        '
        Me.btnRightMembers.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnRightMembers.Location = New System.Drawing.Point(191, 142)
        Me.btnRightMembers.Name = "btnRightMembers"
        Me.btnRightMembers.Size = New System.Drawing.Size(28, 23)
        Me.btnRightMembers.TabIndex = 2
        Me.btnRightMembers.Text = ">>"
        Me.btnRightMembers.UseVisualStyleBackColor = True
        '
        'lblMembersAttending
        '
        Me.lblMembersAttending.AutoSize = True
        Me.lblMembersAttending.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblMembersAttending.Location = New System.Drawing.Point(224, 19)
        Me.lblMembersAttending.Name = "lblMembersAttending"
        Me.lblMembersAttending.Size = New System.Drawing.Size(139, 15)
        Me.lblMembersAttending.TabIndex = 3
        Me.lblMembersAttending.Text = "Members In Attendance:"
        '
        'btnLeftMembers
        '
        Me.btnLeftMembers.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.btnLeftMembers.Location = New System.Drawing.Point(191, 118)
        Me.btnLeftMembers.Name = "btnLeftMembers"
        Me.btnLeftMembers.Size = New System.Drawing.Size(28, 23)
        Me.btnLeftMembers.TabIndex = 1
        Me.btnLeftMembers.Text = "<<"
        Me.btnLeftMembers.UseVisualStyleBackColor = True
        '
        'lblCurrentMembers
        '
        Me.lblCurrentMembers.AutoSize = True
        Me.lblCurrentMembers.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblCurrentMembers.Location = New System.Drawing.Point(6, 19)
        Me.lblCurrentMembers.Name = "lblCurrentMembers"
        Me.lblCurrentMembers.Size = New System.Drawing.Size(123, 15)
        Me.lblCurrentMembers.TabIndex = 1
        Me.lblCurrentMembers.Text = "All Current Members:"
        '
        'lstCurrentMembers
        '
        Me.lstCurrentMembers.AllowDrop = True
        Me.lstCurrentMembers.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lstCurrentMembers.FormattingEnabled = True
        Me.lstCurrentMembers.ItemHeight = 15
        Me.lstCurrentMembers.Location = New System.Drawing.Point(6, 37)
        Me.lstCurrentMembers.Name = "lstCurrentMembers"
        Me.lstCurrentMembers.Size = New System.Drawing.Size(176, 244)
        Me.lstCurrentMembers.Sorted = True
        Me.lstCurrentMembers.TabIndex = 0
        '
        'btnEmail
        '
        Me.btnEmail.Image = Global.PostOpRep.My.Resources.Resources.e_mail1
        Me.btnEmail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmail.Location = New System.Drawing.Point(1323, 1018)
        Me.btnEmail.Name = "btnEmail"
        Me.btnEmail.Size = New System.Drawing.Size(143, 52)
        Me.btnEmail.TabIndex = 112
        Me.btnEmail.Text = "&Save and     " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Submit Report"
        Me.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEmail.UseVisualStyleBackColor = True
        '
        'grpSafetyTraining
        '
        Me.grpSafetyTraining.BackColor = System.Drawing.Color.PaleTurquoise
        Me.grpSafetyTraining.Controls.Add(Me.cboTrained)
        Me.grpSafetyTraining.Controls.Add(Me.lblTraining)
        Me.grpSafetyTraining.Controls.Add(Me.txtSkills)
        Me.grpSafetyTraining.Controls.Add(Me.lblSkills)
        Me.grpSafetyTraining.Controls.Add(Me.txtSafetyConcerns)
        Me.grpSafetyTraining.Controls.Add(Me.lblSafetyConcerns)
        Me.grpSafetyTraining.Controls.Add(Me.cboSafety)
        Me.grpSafetyTraining.Controls.Add(Me.lblSafety)
        Me.grpSafetyTraining.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpSafetyTraining.Location = New System.Drawing.Point(744, 12)
        Me.grpSafetyTraining.Name = "grpSafetyTraining"
        Me.grpSafetyTraining.Size = New System.Drawing.Size(723, 305)
        Me.grpSafetyTraining.TabIndex = 114
        Me.grpSafetyTraining.TabStop = False
        Me.grpSafetyTraining.Text = "Safety/Training"
        '
        'cboTrained
        '
        Me.cboTrained.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTrained.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboTrained.FormattingEnabled = True
        Me.cboTrained.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboTrained.Location = New System.Drawing.Point(602, 23)
        Me.cboTrained.Name = "cboTrained"
        Me.cboTrained.Size = New System.Drawing.Size(110, 23)
        Me.cboTrained.TabIndex = 26
        '
        'lblTraining
        '
        Me.lblTraining.AutoSize = True
        Me.lblTraining.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblTraining.Location = New System.Drawing.Point(399, 26)
        Me.lblTraining.Name = "lblTraining"
        Me.lblTraining.Size = New System.Drawing.Size(194, 15)
        Me.lblTraining.TabIndex = 30
        Me.lblTraining.Text = "Was the crew adequately trained?"
        '
        'txtSkills
        '
        Me.txtSkills.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtSkills.Location = New System.Drawing.Point(6, 201)
        Me.txtSkills.Multiline = True
        Me.txtSkills.Name = "txtSkills"
        Me.txtSkills.Size = New System.Drawing.Size(706, 94)
        Me.txtSkills.TabIndex = 25
        '
        'lblSkills
        '
        Me.lblSkills.AutoSize = True
        Me.lblSkills.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSkills.Location = New System.Drawing.Point(6, 183)
        Me.lblSkills.Name = "lblSkills"
        Me.lblSkills.Size = New System.Drawing.Size(259, 15)
        Me.lblSkills.TabIndex = 29
        Me.lblSkills.Text = "What Skills Would Have Made The Job Easier?"
        '
        'txtSafetyConcerns
        '
        Me.txtSafetyConcerns.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtSafetyConcerns.Location = New System.Drawing.Point(6, 78)
        Me.txtSafetyConcerns.Multiline = True
        Me.txtSafetyConcerns.Name = "txtSafetyConcerns"
        Me.txtSafetyConcerns.Size = New System.Drawing.Size(706, 94)
        Me.txtSafetyConcerns.TabIndex = 24
        '
        'lblSafetyConcerns
        '
        Me.lblSafetyConcerns.AutoSize = True
        Me.lblSafetyConcerns.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSafetyConcerns.Location = New System.Drawing.Point(6, 60)
        Me.lblSafetyConcerns.Name = "lblSafetyConcerns"
        Me.lblSafetyConcerns.Size = New System.Drawing.Size(97, 15)
        Me.lblSafetyConcerns.TabIndex = 28
        Me.lblSafetyConcerns.Text = "Safety Concerns:"
        '
        'cboSafety
        '
        Me.cboSafety.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSafety.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboSafety.FormattingEnabled = True
        Me.cboSafety.Location = New System.Drawing.Point(106, 23)
        Me.cboSafety.Name = "cboSafety"
        Me.cboSafety.Size = New System.Drawing.Size(250, 23)
        Me.cboSafety.TabIndex = 23
        '
        'lblSafety
        '
        Me.lblSafety.AutoSize = True
        Me.lblSafety.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSafety.Location = New System.Drawing.Point(6, 26)
        Me.lblSafety.Name = "lblSafety"
        Me.lblSafety.Size = New System.Drawing.Size(88, 15)
        Me.lblSafety.TabIndex = 27
        Me.lblSafety.Text = "Safety Advisor:"
        '
        'grpOperational
        '
        Me.grpOperational.BackColor = System.Drawing.Color.YellowGreen
        Me.grpOperational.Controls.Add(Me.cboMyCouncil)
        Me.grpOperational.Controls.Add(Me.lblMyCouncil)
        Me.grpOperational.Controls.Add(Me.cboFirstAid)
        Me.grpOperational.Controls.Add(Me.lblFirstAid)
        Me.grpOperational.Controls.Add(Me.cboPlanB)
        Me.grpOperational.Controls.Add(Me.lblPlanB)
        Me.grpOperational.Controls.Add(Me.cboClearToAll)
        Me.grpOperational.Controls.Add(Me.lblClearToAll)
        Me.grpOperational.Controls.Add(Me.txtPlan)
        Me.grpOperational.Controls.Add(Me.lblPlan)
        Me.grpOperational.Controls.Add(Me.txtJobDescription)
        Me.grpOperational.Controls.Add(Me.lblJobDescription)
        Me.grpOperational.Controls.Add(Me.cboCrewLeader)
        Me.grpOperational.Controls.Add(Me.lblCrewLeader)
        Me.grpOperational.Controls.Add(Me.cboSESCommander)
        Me.grpOperational.Controls.Add(Me.lblCommander)
        Me.grpOperational.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpOperational.Location = New System.Drawing.Point(10, 212)
        Me.grpOperational.Name = "grpOperational"
        Me.grpOperational.Size = New System.Drawing.Size(723, 483)
        Me.grpOperational.TabIndex = 115
        Me.grpOperational.TabStop = False
        Me.grpOperational.Text = "Operational"
        '
        'cboMyCouncil
        '
        Me.cboMyCouncil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMyCouncil.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboMyCouncil.FormattingEnabled = True
        Me.cboMyCouncil.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboMyCouncil.Location = New System.Drawing.Point(275, 453)
        Me.cboMyCouncil.Name = "cboMyCouncil"
        Me.cboMyCouncil.Size = New System.Drawing.Size(110, 23)
        Me.cboMyCouncil.TabIndex = 154
        '
        'lblMyCouncil
        '
        Me.lblMyCouncil.AutoSize = True
        Me.lblMyCouncil.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblMyCouncil.Location = New System.Drawing.Point(6, 456)
        Me.lblMyCouncil.Name = "lblMyCouncil"
        Me.lblMyCouncil.Size = New System.Drawing.Size(263, 15)
        Me.lblMyCouncil.TabIndex = 153
        Me.lblMyCouncil.Text = "Was 'My Council Services' notifciation lodged?"
        '
        'cboFirstAid
        '
        Me.cboFirstAid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFirstAid.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboFirstAid.FormattingEnabled = True
        Me.cboFirstAid.Location = New System.Drawing.Point(105, 80)
        Me.cboFirstAid.Name = "cboFirstAid"
        Me.cboFirstAid.Size = New System.Drawing.Size(419, 23)
        Me.cboFirstAid.TabIndex = 152
        '
        'lblFirstAid
        '
        Me.lblFirstAid.AutoSize = True
        Me.lblFirstAid.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblFirstAid.Location = New System.Drawing.Point(6, 83)
        Me.lblFirstAid.Name = "lblFirstAid"
        Me.lblFirstAid.Size = New System.Drawing.Size(67, 15)
        Me.lblFirstAid.TabIndex = 151
        Me.lblFirstAid.Text = "First Aider:"
        '
        'cboPlanB
        '
        Me.cboPlanB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPlanB.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboPlanB.FormattingEnabled = True
        Me.cboPlanB.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboPlanB.Location = New System.Drawing.Point(275, 417)
        Me.cboPlanB.Name = "cboPlanB"
        Me.cboPlanB.Size = New System.Drawing.Size(110, 23)
        Me.cboPlanB.TabIndex = 150
        '
        'lblPlanB
        '
        Me.lblPlanB.AutoSize = True
        Me.lblPlanB.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPlanB.Location = New System.Drawing.Point(6, 420)
        Me.lblPlanB.Name = "lblPlanB"
        Me.lblPlanB.Size = New System.Drawing.Size(193, 15)
        Me.lblPlanB.TabIndex = 149
        Me.lblPlanB.Text = "Crew Leader - Was there a plan B?"
        '
        'cboClearToAll
        '
        Me.cboClearToAll.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClearToAll.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboClearToAll.FormattingEnabled = True
        Me.cboClearToAll.Items.AddRange(New Object() {"Yes", "No"})
        Me.cboClearToAll.Location = New System.Drawing.Point(275, 382)
        Me.cboClearToAll.Name = "cboClearToAll"
        Me.cboClearToAll.Size = New System.Drawing.Size(110, 23)
        Me.cboClearToAll.TabIndex = 148
        '
        'lblClearToAll
        '
        Me.lblClearToAll.AutoSize = True
        Me.lblClearToAll.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblClearToAll.Location = New System.Drawing.Point(6, 385)
        Me.lblClearToAll.Name = "lblClearToAll"
        Me.lblClearToAll.Size = New System.Drawing.Size(224, 15)
        Me.lblClearToAll.TabIndex = 147
        Me.lblClearToAll.Text = "Was the plan followed and clear to all?"
        '
        'txtPlan
        '
        Me.txtPlan.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtPlan.Location = New System.Drawing.Point(7, 265)
        Me.txtPlan.Multiline = True
        Me.txtPlan.Name = "txtPlan"
        Me.txtPlan.Size = New System.Drawing.Size(706, 94)
        Me.txtPlan.TabIndex = 146
        '
        'lblPlan
        '
        Me.lblPlan.AutoSize = True
        Me.lblPlan.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPlan.Location = New System.Drawing.Point(3, 247)
        Me.lblPlan.Name = "lblPlan"
        Me.lblPlan.Size = New System.Drawing.Size(121, 15)
        Me.lblPlan.TabIndex = 145
        Me.lblPlan.Text = "What Was The Plan?"
        '
        'txtJobDescription
        '
        Me.txtJobDescription.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtJobDescription.Location = New System.Drawing.Point(7, 146)
        Me.txtJobDescription.Multiline = True
        Me.txtJobDescription.Name = "txtJobDescription"
        Me.txtJobDescription.Size = New System.Drawing.Size(706, 94)
        Me.txtJobDescription.TabIndex = 144
        '
        'lblJobDescription
        '
        Me.lblJobDescription.AutoSize = True
        Me.lblJobDescription.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblJobDescription.Location = New System.Drawing.Point(6, 128)
        Me.lblJobDescription.Name = "lblJobDescription"
        Me.lblJobDescription.Size = New System.Drawing.Size(123, 15)
        Me.lblJobDescription.TabIndex = 143
        Me.lblJobDescription.Text = "Brief Job Description:"
        '
        'cboCrewLeader
        '
        Me.cboCrewLeader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCrewLeader.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboCrewLeader.FormattingEnabled = True
        Me.cboCrewLeader.Location = New System.Drawing.Point(105, 48)
        Me.cboCrewLeader.Name = "cboCrewLeader"
        Me.cboCrewLeader.Size = New System.Drawing.Size(419, 23)
        Me.cboCrewLeader.TabIndex = 142
        '
        'lblCrewLeader
        '
        Me.lblCrewLeader.AutoSize = True
        Me.lblCrewLeader.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblCrewLeader.Location = New System.Drawing.Point(6, 51)
        Me.lblCrewLeader.Name = "lblCrewLeader"
        Me.lblCrewLeader.Size = New System.Drawing.Size(76, 15)
        Me.lblCrewLeader.TabIndex = 141
        Me.lblCrewLeader.Text = "Crew Leader:"
        '
        'cboSESCommander
        '
        Me.cboSESCommander.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSESCommander.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboSESCommander.FormattingEnabled = True
        Me.cboSESCommander.Location = New System.Drawing.Point(105, 16)
        Me.cboSESCommander.Name = "cboSESCommander"
        Me.cboSESCommander.Size = New System.Drawing.Size(419, 23)
        Me.cboSESCommander.TabIndex = 140
        '
        'lblCommander
        '
        Me.lblCommander.AutoSize = True
        Me.lblCommander.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblCommander.Location = New System.Drawing.Point(6, 19)
        Me.lblCommander.Name = "lblCommander"
        Me.lblCommander.Size = New System.Drawing.Size(97, 15)
        Me.lblCommander.TabIndex = 139
        Me.lblCommander.Text = "SES Commander:"
        '
        'grpEquipmentUsed
        '
        Me.grpEquipmentUsed.BackColor = System.Drawing.Color.MistyRose
        Me.grpEquipmentUsed.Controls.Add(Me.lblDuration)
        Me.grpEquipmentUsed.Controls.Add(Me.lblMember)
        Me.grpEquipmentUsed.Controls.Add(Me.lblItem)
        Me.grpEquipmentUsed.Controls.Add(Me.dgvEquipment)
        Me.grpEquipmentUsed.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpEquipmentUsed.Location = New System.Drawing.Point(744, 707)
        Me.grpEquipmentUsed.Name = "grpEquipmentUsed"
        Me.grpEquipmentUsed.Size = New System.Drawing.Size(723, 301)
        Me.grpEquipmentUsed.TabIndex = 117
        Me.grpEquipmentUsed.TabStop = False
        Me.grpEquipmentUsed.Text = "Equipment Used"
        '
        'lblDuration
        '
        Me.lblDuration.AutoSize = True
        Me.lblDuration.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblDuration.Location = New System.Drawing.Point(338, 18)
        Me.lblDuration.Name = "lblDuration"
        Me.lblDuration.Size = New System.Drawing.Size(96, 15)
        Me.lblDuration.TabIndex = 25
        Me.lblDuration.Text = "Duration (mins):"
        '
        'lblMember
        '
        Me.lblMember.AutoSize = True
        Me.lblMember.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblMember.Location = New System.Drawing.Point(438, 18)
        Me.lblMember.Name = "lblMember"
        Me.lblMember.Size = New System.Drawing.Size(140, 15)
        Me.lblMember.TabIndex = 24
        Me.lblMember.Text = "Member Using/Servcing:"
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblItem.Location = New System.Drawing.Point(25, 18)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(34, 15)
        Me.lblItem.TabIndex = 23
        Me.lblItem.Text = "Item:"
        '
        'dgvEquipment
        '
        Me.dgvEquipment.AllowDrop = True
        Me.dgvEquipment.AllowUserToAddRows = False
        Me.dgvEquipment.AllowUserToDeleteRows = False
        Me.dgvEquipment.AllowUserToResizeColumns = False
        Me.dgvEquipment.AllowUserToResizeRows = False
        Me.dgvEquipment.BackgroundColor = System.Drawing.Color.White
        Me.dgvEquipment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEquipment.ColumnHeadersVisible = False
        Me.dgvEquipment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmItemUsed, Me.DataGridViewTextBoxColumn1, Me.Duration, Me.DataGridViewComboBoxColumn1})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvEquipment.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvEquipment.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvEquipment.Location = New System.Drawing.Point(6, 38)
        Me.dgvEquipment.MultiSelect = False
        Me.dgvEquipment.Name = "dgvEquipment"
        Me.dgvEquipment.RowHeadersVisible = False
        Me.dgvEquipment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgvEquipment.Size = New System.Drawing.Size(709, 243)
        Me.dgvEquipment.TabIndex = 4
        '
        'clmItemUsed
        '
        Me.clmItemUsed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.clmItemUsed.HeaderText = "Used?"
        Me.clmItemUsed.Name = "clmItemUsed"
        Me.clmItemUsed.Width = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkGray
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Equipment Item"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 312
        '
        'Duration
        '
        Me.Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Duration.HeaderText = "Duration"
        Me.Duration.Name = "Duration"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoComplete = False
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.DarkGray
        Me.DataGridViewComboBoxColumn1.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.DataGridViewComboBoxColumn1.HeaderText = "Member"
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.ReadOnly = True
        Me.DataGridViewComboBoxColumn1.Width = 250
        '
        'pnlDetails
        '
        Me.pnlDetails.BackColor = System.Drawing.Color.SeaShell
        Me.pnlDetails.Controls.Add(Me.lblDetails)
        Me.pnlDetails.Controls.Add(Me.cboDebriefType)
        Me.pnlDetails.Controls.Add(Me.lblDebriefType)
        Me.pnlDetails.Controls.Add(Me.lblEventNo)
        Me.pnlDetails.Controls.Add(Me.lblIncorrectEventNumber)
        Me.pnlDetails.Controls.Add(Me.txtEventNumber)
        Me.pnlDetails.Location = New System.Drawing.Point(10, 12)
        Me.pnlDetails.Name = "pnlDetails"
        Me.pnlDetails.Size = New System.Drawing.Size(528, 93)
        Me.pnlDetails.TabIndex = 118
        '
        'lblDetails
        '
        Me.lblDetails.AutoSize = True
        Me.lblDetails.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDetails.Location = New System.Drawing.Point(8, 13)
        Me.lblDetails.Name = "lblDetails"
        Me.lblDetails.Size = New System.Drawing.Size(44, 15)
        Me.lblDetails.TabIndex = 141
        Me.lblDetails.Text = "Details"
        '
        'cboDebriefType
        '
        Me.cboDebriefType.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDebriefType.FormattingEnabled = True
        Me.cboDebriefType.Items.AddRange(New Object() {"Single Incident Debrief", "Deployment"})
        Me.cboDebriefType.Location = New System.Drawing.Point(100, 35)
        Me.cboDebriefType.Name = "cboDebriefType"
        Me.cboDebriefType.Size = New System.Drawing.Size(225, 23)
        Me.cboDebriefType.TabIndex = 140
        '
        'lblDebriefType
        '
        Me.lblDebriefType.AutoSize = True
        Me.lblDebriefType.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDebriefType.Location = New System.Drawing.Point(8, 38)
        Me.lblDebriefType.Name = "lblDebriefType"
        Me.lblDebriefType.Size = New System.Drawing.Size(74, 15)
        Me.lblDebriefType.TabIndex = 139
        Me.lblDebriefType.Text = "Debrief Type"
        '
        'lblEventNo
        '
        Me.lblEventNo.AutoSize = True
        Me.lblEventNo.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEventNo.Location = New System.Drawing.Point(6, 71)
        Me.lblEventNo.Name = "lblEventNo"
        Me.lblEventNo.Size = New System.Drawing.Size(82, 15)
        Me.lblEventNo.TabIndex = 129
        Me.lblEventNo.Text = "Event Number"
        '
        'lblIncorrectEventNumber
        '
        Me.lblIncorrectEventNumber.AutoSize = True
        Me.lblIncorrectEventNumber.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncorrectEventNumber.ForeColor = System.Drawing.Color.Red
        Me.lblIncorrectEventNumber.Location = New System.Drawing.Point(246, 71)
        Me.lblIncorrectEventNumber.Name = "lblIncorrectEventNumber"
        Me.lblIncorrectEventNumber.Size = New System.Drawing.Size(130, 15)
        Me.lblIncorrectEventNumber.TabIndex = 138
        Me.lblIncorrectEventNumber.Text = "*Invalid Event Number"
        Me.lblIncorrectEventNumber.Visible = False
        '
        'txtEventNumber
        '
        Me.txtEventNumber.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEventNumber.Location = New System.Drawing.Point(100, 66)
        Me.txtEventNumber.Name = "txtEventNumber"
        Me.txtEventNumber.Size = New System.Drawing.Size(140, 23)
        Me.txtEventNumber.TabIndex = 126
        '
        'pnlDate
        '
        Me.pnlDate.BackColor = System.Drawing.Color.LightPink
        Me.pnlDate.Controls.Add(Me.dtpStart)
        Me.pnlDate.Controls.Add(Me.lblDate)
        Me.pnlDate.Controls.Add(Me.txtFinishTime)
        Me.pnlDate.Controls.Add(Me.lblJobType)
        Me.pnlDate.Controls.Add(Me.Label1)
        Me.pnlDate.Controls.Add(Me.txtStartTime)
        Me.pnlDate.Controls.Add(Me.cboJobType)
        Me.pnlDate.Controls.Add(Me.lblStartTime)
        Me.pnlDate.Controls.Add(Me.dtpFinish)
        Me.pnlDate.Controls.Add(Me.lblFinishDate)
        Me.pnlDate.Location = New System.Drawing.Point(10, 106)
        Me.pnlDate.Name = "pnlDate"
        Me.pnlDate.Size = New System.Drawing.Size(535, 100)
        Me.pnlDate.TabIndex = 119
        '
        'dtpStart
        '
        Me.dtpStart.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpStart.Location = New System.Drawing.Point(100, 9)
        Me.dtpStart.Name = "dtpStart"
        Me.dtpStart.Size = New System.Drawing.Size(92, 23)
        Me.dtpStart.TabIndex = 138
        Me.dtpStart.Value = New Date(8888, 8, 28, 20, 48, 0, 0)
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(6, 15)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(64, 15)
        Me.lblDate.TabIndex = 139
        Me.lblDate.Text = "Start Date:"
        '
        'txtFinishTime
        '
        Me.txtFinishTime.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFinishTime.Location = New System.Drawing.Point(298, 41)
        Me.txtFinishTime.Mask = "00:00"
        Me.txtFinishTime.Name = "txtFinishTime"
        Me.txtFinishTime.Size = New System.Drawing.Size(43, 23)
        Me.txtFinishTime.TabIndex = 143
        Me.txtFinishTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtFinishTime.ValidatingType = GetType(Date)
        '
        'lblJobType
        '
        Me.lblJobType.AutoSize = True
        Me.lblJobType.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobType.Location = New System.Drawing.Point(6, 76)
        Me.lblJobType.Name = "lblJobType"
        Me.lblJobType.Size = New System.Drawing.Size(55, 15)
        Me.lblJobType.TabIndex = 141
        Me.lblJobType.Text = "Job Type:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(220, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Finish Time:"
        '
        'txtStartTime
        '
        Me.txtStartTime.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStartTime.Location = New System.Drawing.Point(298, 12)
        Me.txtStartTime.Mask = "00:00"
        Me.txtStartTime.Name = "txtStartTime"
        Me.txtStartTime.Size = New System.Drawing.Size(43, 23)
        Me.txtStartTime.TabIndex = 140
        Me.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtStartTime.ValidatingType = GetType(Date)
        '
        'cboJobType
        '
        Me.cboJobType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboJobType.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboJobType.FormattingEnabled = True
        Me.cboJobType.Items.AddRange(New Object() {"Air Observations and Assessment", "Aircraft Incident - Aircraft in Difficulty", "Aircraft Incident - Insufficient Information to Classify", "Aircraft Incident - No Injuries, Extrication", "Aircraft Incident - No injuries, No Extrication", "Aircraft Incident - With Injuries, Extrication", "Aircraft Incident - With Injuries, No Extrication", "Alpine Rescue", "Animal Rescue - From Dam", "Animal Rescue - From in or under Structure", "Animal Rescue - From Mobile Property", "Animal Rescue - From River to Creek", "Animal Rescue - From Tree", "Animal Rescue - From Well or Mine", "Animal Rescue - Other", "Assist Ambulance - Casualty Handling Only", "Assist Ambulance - Drive Ambulance", "Assist Ambulance - First Aid & Casualty Handling", "Assist Ambulance - First Aid Only", "Assist Ambulance - Specialist Resource Response - Lighting or Other", "Assist Ambulance - Specialist Resource Response - Mass Casualty", "Assist AMSA - Missing Person", "Assist AMSA - Missing Plane or Boat", "Assist DELWP (Non-Fire)", "Assist DELWP (Primary Industry)", "Assist DHS", "Assist Fire - Damage to Structure - Permanent or Mobile Property", "Assist Fire - Landing Zone Management or Support", "Assist Fire - Logistics Support", "Assist Fire - Staging Area Management or Support", "Assist Local Council - Shire", "Assist Other Government Agency", "Assist Police - Crime Scene", "Assist Police - Damage to Structure - Permanent or Mobile Property", "Assist Police - Emergency Coordination Centre - Divisional (DECC)", "Assist Police - Emergency Coordination Centre - Municipal (MECC)", "Assist Police - Evacuation", "Assist Police - Missing Person", "Assist Red Cross", "Assist Service Club", "Building Damage - Multi Storey - External", "Building Damage - Multi Storey - Including Sheeting Iron Roof", "Building Damage - Multi Storey - Including Tiles Roof", "Building Damage - Multi Storey - Internal", "Building Damage - Shed, Outbuilding, etc.", "Building Damage - Single Storey - External", "Building Damage - Single Storey - Including Sheeting Iron Roof", "Building Damage - Single Storey - Including Tiles Roof", "Building Damage - Single Storey - Internal", "Community Education - Other", "Control Centre - Assist Agency", "Control Centre - Earthquake", "Control Centre - Flood", "Control Centre - RAIR Rescue", "Control Centre - Rescue Other", "Control Centre - Storm", "Control Centre - Tsunami", "Control Centre - Unclassified", "Cover Assignment, Standby at LHQ", "Dispatched and Cancelled En-Route - Assist Agency", "Dispatched and Cancelled En-Route - Earthquake", "Dispatched and Cancelled En-Route - Flood", "Dispatched and Cancelled En-Route - RAIR Rescue", "Dispatched and Cancelled En-Route - Rescue Other", "Dispatched and Cancelled En-Route - Storm", "Dispatched and Cancelled En-Route - Tsunami", "Dispatched and Cancelled En-Route - Unclassified", "Driver Reviver", "Duress - Accidental Activation", "Duress - Hostile Situation", "Duress - Misuse", "Duress - Rescue Required", "Duress - Serious Accident - MVA", "Duress - Serious Injuries", "Fire Agency Liaison - CFA", "Fire Agency Liaison - DELWP", "Fire Agency Liaison - MFB", "Flood Smart", "Flooding - Appliance Failure", "Flooding - Burst Water Pipe or Main", "Flooding - Dam Incident or Failure", "Flooding - Flash Flooding", "Flooding - Mitigation", "Flooding - Other (Bath Overflow, etc.)", "Flooding - Riverina", "Fundraising - Charity", "Fundraising - Community Group", "Fundraising - Other ESO", "Fundraising - SES", "Good Intent Call - Insufficient Information to Classify", "Good Intent Call - Not Classified", "Ground Observations and Assessment", "Industrial Accident - Insufficient Information to Classify", "Industrial Accident - No Injuries, Extrication", "Industrial Accident - No injuries, No Extrication", "Industrial Accident - With Injuries, Extrication", "Industrial Accident - With Injuries, No Extrication", "Medical Assistance - Insufficient Information to Classify", "Medical Assistance - Not Classified", "Medical Assistance - With CPR-EAR", "Medical Assistance - With Oxygen Therapy", "Other Condition", "Other Service Call - Insufficient Information to Classify", "Other Service Call - Not Classified", "PR - Church/Charity", "PR - Local Community Festival, Event, Show", "PR - Local Community Group", "PR - Major Event - Avalon Airshow", "PR - Major Event - F1 Grand Prix", "PR - Major Event - Melbourne Show", "PR - Major Event - Moto Grand Prix", "PR - School - University - TAFE", "PR - Service Club, Lions, Rotary, Probus", "Rail Incident - Insufficient Information to Classify", "Rail Incident - No Injuries, Extrication", "Rail Incident - No injuries, No Extrication", "Rail Incident - With Injuries, Extrication", "Rail Incident - With Injuries, No Extrication", "Relief - Earthquake", "Relief - Fire", "Relief - Health Event", "Relief - Other", "Relief - Storm & Flood", "Relief - Tsunami", "Rescue - Coverage of another Provider", "Rescue Persons - Confined Space Rescue", "Rescue Persons - Domestic", "Rescue Persons - Elevator or Escalator - Removal of Victims", "Rescue Persons - Evelator or Escalator - No Occupants", "Rescue Persons - Extrication of Victim(s) from Structural Collapse", "Rescue Persons - Marine Rescue", "Rescue Persons - Rope Rescue", "Rescue Persons - Trench Rescue", "Rescue Standby at Public Event", "Rescue, EMS Calls - Insufficient Information to Classify", "Rescue, EMS Calls - Not Classified", "Road Rescue - Insufficient Information to Classify", "Road Rescue - No Injuries, Extrication", "Road Rescue - No injuries, No Extrication", "Road Rescue - With Injuries, Extrication", "Road Rescue - With Injuries, No Extrication", "Storm Smart", "Traffic Management - Fire Control Agency", "Traffic Management - Police Control Agency", "Traffic Management - SES Control Agency", "Tree Down - Limiting Access", "Tree Down - Mobile Property", "Tree Down - Non Threatening (backyard, etc.)", "Tree Down - Non-Structure (arch, fence, hedge, hooked up in another tree, etc.)", "Tree Down - Passed to Council", "Tree Down - Passed to DELWP or Parks Victoria", "Tree Down - Permanent Property", "Tree Down Traffic Hazard - Blocked Roadway (Fully)", "Tree Down Traffic Hazard - Blocked Roadway (Partially)", "Tree Down Traffic Hazard - Passed to Council", "Tree Down Traffic Hazard - Passed to DELWP or Parks Victoria", "Tree Down Traffic Hazard - Passed to Federal Authority", "Tree Down Traffic Hazard - Passed to Roadway Operator (Citylink, Eastlink etc.)", "Tree Down Traffic Hazard - Passed to VICROADS", "Type of Incident not Reported due to Industrial Action", "Type of Incident Undetermined", "Warning - Fire", "Warning - Flood", "Warning - Other", "Warning - Storm", "Warning - Tsunami", "Wrong Location"})
        Me.cboJobType.Location = New System.Drawing.Point(66, 73)
        Me.cboJobType.Name = "cboJobType"
        Me.cboJobType.Size = New System.Drawing.Size(461, 23)
        Me.cboJobType.TabIndex = 144
        '
        'lblStartTime
        '
        Me.lblStartTime.AutoSize = True
        Me.lblStartTime.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartTime.Location = New System.Drawing.Point(220, 15)
        Me.lblStartTime.Name = "lblStartTime"
        Me.lblStartTime.Size = New System.Drawing.Size(65, 15)
        Me.lblStartTime.TabIndex = 146
        Me.lblStartTime.Text = "Start Time:"
        '
        'dtpFinish
        '
        Me.dtpFinish.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinish.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinish.Location = New System.Drawing.Point(100, 41)
        Me.dtpFinish.Name = "dtpFinish"
        Me.dtpFinish.Size = New System.Drawing.Size(92, 23)
        Me.dtpFinish.TabIndex = 142
        Me.dtpFinish.Value = New Date(2013, 11, 9, 15, 43, 43, 0)
        '
        'lblFinishDate
        '
        Me.lblFinishDate.AutoSize = True
        Me.lblFinishDate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFinishDate.Location = New System.Drawing.Point(6, 45)
        Me.lblFinishDate.Name = "lblFinishDate"
        Me.lblFinishDate.Size = New System.Drawing.Size(72, 15)
        Me.lblFinishDate.TabIndex = 145
        Me.lblFinishDate.Text = "Finish Date:"
        '
        'lblPadding
        '
        Me.lblPadding.AutoSize = True
        Me.lblPadding.Location = New System.Drawing.Point(592, 82)
        Me.lblPadding.Name = "lblPadding"
        Me.lblPadding.Size = New System.Drawing.Size(0, 15)
        Me.lblPadding.TabIndex = 120
        '
        'frmNewDebrief
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1511, 873)
        Me.Controls.Add(Me.lblPadding)
        Me.Controls.Add(Me.grpEquipmentUsed)
        Me.Controls.Add(Me.grpPersonel)
        Me.Controls.Add(Me.pnlDate)
        Me.Controls.Add(Me.pnlDetails)
        Me.Controls.Add(Me.grpOperational)
        Me.Controls.Add(Me.grpSafetyTraining)
        Me.Controls.Add(Me.btnEmail)
        Me.Controls.Add(Me.grpLogistics)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(775, 500)
        Me.Name = "frmNewDebrief"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Post Operation Debrief"
        Me.grpLogistics.ResumeLayout(False)
        Me.grpLogistics.PerformLayout()
        Me.grpPersonel.ResumeLayout(False)
        Me.grpPersonel.PerformLayout()
        CType(Me.dgvMembersAttending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSafetyTraining.ResumeLayout(False)
        Me.grpSafetyTraining.PerformLayout()
        Me.grpOperational.ResumeLayout(False)
        Me.grpOperational.PerformLayout()
        Me.grpEquipmentUsed.ResumeLayout(False)
        Me.grpEquipmentUsed.PerformLayout()
        CType(Me.dgvEquipment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetails.ResumeLayout(False)
        Me.pnlDetails.PerformLayout()
        Me.pnlDate.ResumeLayout(False)
        Me.pnlDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpLogistics As System.Windows.Forms.GroupBox
    Friend WithEvents lstUnitVehicles As System.Windows.Forms.ListBox
    Friend WithEvents lblUnitVehicles As System.Windows.Forms.Label
    Friend WithEvents lstVehiclesUsed As System.Windows.Forms.ListBox
    Friend WithEvents lblVehiclesUsed As System.Windows.Forms.Label
    Friend WithEvents btnRight As System.Windows.Forms.Button
    Friend WithEvents btnLeft As System.Windows.Forms.Button
    Friend WithEvents txtEquipment As System.Windows.Forms.TextBox
    Friend WithEvents lblEasier As System.Windows.Forms.Label
    Friend WithEvents txtIssues As System.Windows.Forms.TextBox
    Friend WithEvents lblIssues As System.Windows.Forms.Label
    Friend WithEvents grpPersonel As System.Windows.Forms.GroupBox
    Friend WithEvents lblCurrentMembers As System.Windows.Forms.Label
    Friend WithEvents lstCurrentMembers As System.Windows.Forms.ListBox
    Friend WithEvents lblMembersAttending As System.Windows.Forms.Label
    Friend WithEvents btnRightMembers As System.Windows.Forms.Button
    Friend WithEvents btnLeftMembers As System.Windows.Forms.Button
    Friend WithEvents lblTaskUndertaken As System.Windows.Forms.Label
    Friend WithEvents dgvMembersAttending As System.Windows.Forms.DataGridView
    Friend WithEvents clmMember1 As DataGridViewTextBoxColumn
    Friend WithEvents clmTask1 As DataGridViewComboBoxColumn
    Friend WithEvents btnEmail As Button
    Friend WithEvents grpSafetyTraining As GroupBox
    Friend WithEvents cboTrained As ComboBox
    Friend WithEvents lblTraining As Label
    Friend WithEvents txtSkills As TextBox
    Friend WithEvents lblSkills As Label
    Friend WithEvents txtSafetyConcerns As TextBox
    Friend WithEvents lblSafetyConcerns As Label
    Friend WithEvents cboSafety As ComboBox
    Friend WithEvents lblSafety As Label
    Friend WithEvents grpOperational As GroupBox
    Friend WithEvents cboFirstAid As ComboBox
    Friend WithEvents lblFirstAid As Label
    Friend WithEvents cboPlanB As ComboBox
    Friend WithEvents lblPlanB As Label
    Friend WithEvents cboClearToAll As ComboBox
    Friend WithEvents lblClearToAll As Label
    Friend WithEvents txtPlan As TextBox
    Friend WithEvents lblPlan As Label
    Friend WithEvents txtJobDescription As TextBox
    Friend WithEvents lblJobDescription As Label
    Friend WithEvents cboCrewLeader As ComboBox
    Friend WithEvents lblCrewLeader As Label
    Friend WithEvents cboSESCommander As ComboBox
    Friend WithEvents lblCommander As Label
    Friend WithEvents cboMyCouncil As ComboBox
    Friend WithEvents lblMyCouncil As Label
    Friend WithEvents grpEquipmentUsed As GroupBox
    Friend WithEvents dgvEquipment As DataGridView
    Friend WithEvents pnlDetails As Panel
    Friend WithEvents lblDetails As Label
    Friend WithEvents cboDebriefType As ComboBox
    Friend WithEvents lblDebriefType As Label
    Friend WithEvents lblEventNo As Label
    Friend WithEvents lblIncorrectEventNumber As Label
    Friend WithEvents txtEventNumber As TextBox
    Friend WithEvents pnlDate As Panel
    Friend WithEvents dtpStart As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents txtFinishTime As MaskedTextBox
    Friend WithEvents lblJobType As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtStartTime As MaskedTextBox
    Friend WithEvents cboJobType As ComboBox
    Friend WithEvents lblStartTime As Label
    Friend WithEvents dtpFinish As DateTimePicker
    Friend WithEvents lblFinishDate As Label
    Friend WithEvents lblDuration As Label
    Friend WithEvents lblMember As Label
    Friend WithEvents lblItem As Label
    Friend WithEvents lblPadding As Label
    Friend WithEvents clmItemUsed As DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents Duration As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
End Class
