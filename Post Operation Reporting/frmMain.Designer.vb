<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.mnuMain = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DebriefsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewDebriefToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportIRSDataToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.IndividualDebriefsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MemberTasksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WindowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AdministrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuMain.SuspendLayout
        Me.StatusStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DebriefsToolStripMenuItem, Me.DataToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.WindowToolStripMenuItem, Me.AdministrationToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.MdiWindowListItem = Me.WindowToolStripMenuItem
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(1192, 24)
        Me.mnuMain.TabIndex = 1
        Me.mnuMain.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem, Me.LogoffToolStripMenuItem, Me.ToolStripSeparator2, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Image = Global.PostOpRep.My.Resources.Resources.key
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LoginToolStripMenuItem.Text = "&Login"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = Global.PostOpRep.My.Resources.Resources._exit
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4),System.Windows.Forms.Keys)
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.CloseToolStripMenuItem.Text = "&Exit"
        '
        'DebriefsToolStripMenuItem
        '
        Me.DebriefsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewDebriefToolStripMenuItem})
        Me.DebriefsToolStripMenuItem.Name = "DebriefsToolStripMenuItem"
        Me.DebriefsToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.DebriefsToolStripMenuItem.Text = "&Debriefs"
        '
        'NewDebriefToolStripMenuItem
        '
        Me.NewDebriefToolStripMenuItem.Name = "NewDebriefToolStripMenuItem"
        Me.NewDebriefToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.NewDebriefToolStripMenuItem.Text = "&New Debrief"
        '
        'DataToolStripMenuItem
        '
        Me.DataToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportIRSDataToolStripMenuItem1})
        Me.DataToolStripMenuItem.Enabled = false
        Me.DataToolStripMenuItem.Name = "DataToolStripMenuItem"
        Me.DataToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.DataToolStripMenuItem.Text = "&Data"
        Me.DataToolStripMenuItem.Visible = false
        '
        'ImportIRSDataToolStripMenuItem1
        '
        Me.ImportIRSDataToolStripMenuItem1.Name = "ImportIRSDataToolStripMenuItem1"
        Me.ImportIRSDataToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
        Me.ImportIRSDataToolStripMenuItem1.Text = "&Import IRS Data"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IndividualDebriefsToolStripMenuItem, Me.ToolStripSeparator1, Me.MemberTasksToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Enabled = false
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        Me.ReportsToolStripMenuItem.Visible = false
        '
        'IndividualDebriefsToolStripMenuItem
        '
        Me.IndividualDebriefsToolStripMenuItem.Name = "IndividualDebriefsToolStripMenuItem"
        Me.IndividualDebriefsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.IndividualDebriefsToolStripMenuItem.Text = "&Individual Debriefs"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(169, 6)
        '
        'MemberTasksToolStripMenuItem
        '
        Me.MemberTasksToolStripMenuItem.Name = "MemberTasksToolStripMenuItem"
        Me.MemberTasksToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.MemberTasksToolStripMenuItem.Text = "&Member Statistics"
        '
        'WindowToolStripMenuItem
        '
        Me.WindowToolStripMenuItem.Name = "WindowToolStripMenuItem"
        Me.WindowToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.WindowToolStripMenuItem.Text = "&Window"
        '
        'AdministrationToolStripMenuItem
        '
        Me.AdministrationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem})
        Me.AdministrationToolStripMenuItem.Enabled = false
        Me.AdministrationToolStripMenuItem.Name = "AdministrationToolStripMenuItem"
        Me.AdministrationToolStripMenuItem.Size = New System.Drawing.Size(98, 20)
        Me.AdministrationToolStripMenuItem.Text = "&Administration"
        Me.AdministrationToolStripMenuItem.Visible = false
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Image = Global.PostOpRep.My.Resources.Resources.settings
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 648)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1192, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblStatus
        '
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(29, 17)
        Me.lblStatus.Text = "Idle."
        '
        'statusTimer
        '
        Me.statusTimer.Enabled = true
        Me.statusTimer.Interval = 60000
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LogoffToolStripMenuItem.Text = "Lo&goff"
        Me.LogoffToolStripMenuItem.Visible = false
        '
        'frmMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = Global.PostOpRep.My.Resources.Resources._946378_196640293851376_265703448_n
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1192, 670)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuMain)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.IsMdiContainer = true
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Post Operation Reporting"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnuMain.ResumeLayout(false)
        Me.mnuMain.PerformLayout
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WindowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DebriefsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewDebriefToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IndividualDebriefsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MemberTasksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportIRSDataToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblStatus As ToolStripStatusLabel
    Friend WithEvents statusTimer As Timer
    Friend WithEvents LoginToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents AdministrationToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoffToolStripMenuItem As ToolStripMenuItem
End Class
