<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDefaultPrivledges
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
        Me.grpPosition = New System.Windows.Forms.GroupBox()
        Me.rbtController = New System.Windows.Forms.RadioButton()
        Me.rbtDeputy = New System.Windows.Forms.RadioButton()
        Me.rbtUnitMember = New System.Windows.Forms.RadioButton()
        Me.rbtDeputyTeamLeader = New System.Windows.Forms.RadioButton()
        Me.rbtTeamLeader = New System.Windows.Forms.RadioButton()
        Me.rbtSectionLeader = New System.Windows.Forms.RadioButton()
        Me.grpPrivledges = New System.Windows.Forms.GroupBox()
        Me.tstvPrivledges = New PostOpRep.Controls.TriStateTreeView()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.grpPosition.SuspendLayout
        Me.grpPrivledges.SuspendLayout
        Me.SuspendLayout
        '
        'grpPosition
        '
        Me.grpPosition.Controls.Add(Me.rbtSectionLeader)
        Me.grpPosition.Controls.Add(Me.rbtTeamLeader)
        Me.grpPosition.Controls.Add(Me.rbtDeputyTeamLeader)
        Me.grpPosition.Controls.Add(Me.rbtUnitMember)
        Me.grpPosition.Controls.Add(Me.rbtDeputy)
        Me.grpPosition.Controls.Add(Me.rbtController)
        Me.grpPosition.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpPosition.Location = New System.Drawing.Point(12, 12)
        Me.grpPosition.Name = "grpPosition"
        Me.grpPosition.Size = New System.Drawing.Size(146, 245)
        Me.grpPosition.TabIndex = 0
        Me.grpPosition.TabStop = false
        Me.grpPosition.Text = "Position"
        '
        'rbtController
        '
        Me.rbtController.AutoSize = true
        Me.rbtController.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtController.Location = New System.Drawing.Point(6, 22)
        Me.rbtController.Name = "rbtController"
        Me.rbtController.Size = New System.Drawing.Size(81, 19)
        Me.rbtController.TabIndex = 0
        Me.rbtController.TabStop = true
        Me.rbtController.Text = "Controller"
        Me.rbtController.UseVisualStyleBackColor = true
        '
        'rbtDeputy
        '
        Me.rbtDeputy.AutoSize = true
        Me.rbtDeputy.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtDeputy.Location = New System.Drawing.Point(6, 61)
        Me.rbtDeputy.Name = "rbtDeputy"
        Me.rbtDeputy.Size = New System.Drawing.Size(122, 19)
        Me.rbtDeputy.TabIndex = 1
        Me.rbtDeputy.TabStop = true
        Me.rbtDeputy.Text = "Deputy Controller"
        Me.rbtDeputy.UseVisualStyleBackColor = true
        '
        'rbtUnitMember
        '
        Me.rbtUnitMember.AutoSize = true
        Me.rbtUnitMember.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtUnitMember.Location = New System.Drawing.Point(6, 217)
        Me.rbtUnitMember.Name = "rbtUnitMember"
        Me.rbtUnitMember.Size = New System.Drawing.Size(96, 19)
        Me.rbtUnitMember.TabIndex = 2
        Me.rbtUnitMember.TabStop = true
        Me.rbtUnitMember.Text = "Unit Member"
        Me.rbtUnitMember.UseVisualStyleBackColor = true
        '
        'rbtDeputyTeamLeader
        '
        Me.rbtDeputyTeamLeader.AutoSize = true
        Me.rbtDeputyTeamLeader.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtDeputyTeamLeader.Location = New System.Drawing.Point(6, 178)
        Me.rbtDeputyTeamLeader.Name = "rbtDeputyTeamLeader"
        Me.rbtDeputyTeamLeader.Size = New System.Drawing.Size(133, 19)
        Me.rbtDeputyTeamLeader.TabIndex = 3
        Me.rbtDeputyTeamLeader.TabStop = true
        Me.rbtDeputyTeamLeader.Text = "Deputy Team Leader"
        Me.rbtDeputyTeamLeader.UseVisualStyleBackColor = true
        '
        'rbtTeamLeader
        '
        Me.rbtTeamLeader.AutoSize = true
        Me.rbtTeamLeader.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtTeamLeader.Location = New System.Drawing.Point(6, 139)
        Me.rbtTeamLeader.Name = "rbtTeamLeader"
        Me.rbtTeamLeader.Size = New System.Drawing.Size(92, 19)
        Me.rbtTeamLeader.TabIndex = 4
        Me.rbtTeamLeader.TabStop = true
        Me.rbtTeamLeader.Text = "Team Leader"
        Me.rbtTeamLeader.UseVisualStyleBackColor = true
        '
        'rbtSectionLeader
        '
        Me.rbtSectionLeader.AutoSize = true
        Me.rbtSectionLeader.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.rbtSectionLeader.Location = New System.Drawing.Point(5, 100)
        Me.rbtSectionLeader.Name = "rbtSectionLeader"
        Me.rbtSectionLeader.Size = New System.Drawing.Size(103, 19)
        Me.rbtSectionLeader.TabIndex = 5
        Me.rbtSectionLeader.TabStop = true
        Me.rbtSectionLeader.Text = "Section Leader"
        Me.rbtSectionLeader.UseVisualStyleBackColor = true
        '
        'grpPrivledges
        '
        Me.grpPrivledges.Controls.Add(Me.tstvPrivledges)
        Me.grpPrivledges.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpPrivledges.Location = New System.Drawing.Point(164, 12)
        Me.grpPrivledges.Name = "grpPrivledges"
        Me.grpPrivledges.Size = New System.Drawing.Size(351, 245)
        Me.grpPrivledges.TabIndex = 17
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
        Me.tstvPrivledges.Size = New System.Drawing.Size(336, 217)
        Me.tstvPrivledges.TabIndex = 3
        Me.tstvPrivledges.TriStateStyleProperty = PostOpRep.Controls.TriStateTreeView.TriStateStyles.Standard
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(440, 263)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 20
        Me.btnApply.Text = "&Apply"
        Me.btnApply.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(358, 263)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(275, 263)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = true
        '
        'frmDefaultPrivledges
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(526, 298)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.grpPrivledges)
        Me.Controls.Add(Me.grpPosition)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmDefaultPrivledges"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Set Default Privledges"
        Me.grpPosition.ResumeLayout(false)
        Me.grpPosition.PerformLayout
        Me.grpPrivledges.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents grpPosition As GroupBox
    Friend WithEvents rbtSectionLeader As RadioButton
    Friend WithEvents rbtTeamLeader As RadioButton
    Friend WithEvents rbtDeputyTeamLeader As RadioButton
    Friend WithEvents rbtUnitMember As RadioButton
    Friend WithEvents rbtDeputy As RadioButton
    Friend WithEvents rbtController As RadioButton
    Friend WithEvents grpPrivledges As GroupBox
    Friend WithEvents tstvPrivledges As Controls.TriStateTreeView
    Friend WithEvents btnApply As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
End Class
