<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportIRSData
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
        Me.grbDataImport = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnWebsite = New System.Windows.Forms.Button()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.btnIndi = New System.Windows.Forms.Button()
        Me.lblIndi = New System.Windows.Forms.Label()
        Me.btnIncident = New System.Windows.Forms.Button()
        Me.lblIncident = New System.Windows.Forms.Label()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.grbDataImport.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbDataImport
        '
        Me.grbDataImport.Controls.Add(Me.Label6)
        Me.grbDataImport.Controls.Add(Me.Label5)
        Me.grbDataImport.Controls.Add(Me.Label4)
        Me.grbDataImport.Controls.Add(Me.btnWebsite)
        Me.grbDataImport.Controls.Add(Me.lblWebsite)
        Me.grbDataImport.Controls.Add(Me.btnIndi)
        Me.grbDataImport.Controls.Add(Me.lblIndi)
        Me.grbDataImport.Controls.Add(Me.btnIncident)
        Me.grbDataImport.Controls.Add(Me.lblIncident)
        Me.grbDataImport.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grbDataImport.Location = New System.Drawing.Point(12, 12)
        Me.grbDataImport.Name = "grbDataImport"
        Me.grbDataImport.Size = New System.Drawing.Size(443, 213)
        Me.grbDataImport.TabIndex = 0
        Me.grbDataImport.TabStop = False
        Me.grbDataImport.Text = "Data To Import"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(7, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 15)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Availability Website Data"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(161, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "IRS Individual Summary Data"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "IRS Incident Summary Data"
        '
        'btnWebsite
        '
        Me.btnWebsite.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnWebsite.Location = New System.Drawing.Point(6, 166)
        Me.btnWebsite.Name = "btnWebsite"
        Me.btnWebsite.Size = New System.Drawing.Size(100, 23)
        Me.btnWebsite.TabIndex = 5
        Me.btnWebsite.Text = "File Location"
        Me.btnWebsite.UseVisualStyleBackColor = True
        '
        'lblWebsite
        '
        Me.lblWebsite.AutoSize = True
        Me.lblWebsite.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWebsite.Location = New System.Drawing.Point(112, 170)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(128, 15)
        Me.lblWebsite.TabIndex = 4
        Me.lblWebsite.Text = "No Location specified..."
        '
        'btnIndi
        '
        Me.btnIndi.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIndi.Location = New System.Drawing.Point(6, 108)
        Me.btnIndi.Name = "btnIndi"
        Me.btnIndi.Size = New System.Drawing.Size(100, 23)
        Me.btnIndi.TabIndex = 3
        Me.btnIndi.Text = "File Location"
        Me.btnIndi.UseVisualStyleBackColor = True
        '
        'lblIndi
        '
        Me.lblIndi.AutoSize = True
        Me.lblIndi.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIndi.Location = New System.Drawing.Point(112, 112)
        Me.lblIndi.Name = "lblIndi"
        Me.lblIndi.Size = New System.Drawing.Size(128, 15)
        Me.lblIndi.TabIndex = 2
        Me.lblIndi.Text = "No Location specified..."
        '
        'btnIncident
        '
        Me.btnIncident.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIncident.Location = New System.Drawing.Point(6, 50)
        Me.btnIncident.Name = "btnIncident"
        Me.btnIncident.Size = New System.Drawing.Size(100, 23)
        Me.btnIncident.TabIndex = 1
        Me.btnIncident.Text = "File Location"
        Me.btnIncident.UseVisualStyleBackColor = True
        '
        'lblIncident
        '
        Me.lblIncident.AutoSize = True
        Me.lblIncident.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIncident.Location = New System.Drawing.Point(112, 54)
        Me.lblIncident.Name = "lblIncident"
        Me.lblIncident.Size = New System.Drawing.Size(128, 15)
        Me.lblIncident.TabIndex = 0
        Me.lblIncident.Text = "No Location specified..."
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(196, 231)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(75, 23)
        Me.btnImport.TabIndex = 1
        Me.btnImport.Text = "Import Data"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmImportIRSData
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(467, 262)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.grbDataImport)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmImportIRSData"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import IRS Data"
        Me.grbDataImport.ResumeLayout(False)
        Me.grbDataImport.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbDataImport As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnWebsite As System.Windows.Forms.Button
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents btnIndi As System.Windows.Forms.Button
    Friend WithEvents lblIndi As System.Windows.Forms.Label
    Friend WithEvents btnIncident As System.Windows.Forms.Button
    Friend WithEvents lblIncident As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
