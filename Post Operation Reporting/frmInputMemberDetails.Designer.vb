<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InputMemberDetails
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
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.MaskedTextBox()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cboPosition = New System.Windows.Forms.ComboBox()
        Me.lblPosition = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'lblID
        '
        Me.lblID.AutoSize = true
        Me.lblID.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblID.Location = New System.Drawing.Point(59, 15)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(19, 15)
        Me.lblID.TabIndex = 12
        Me.lblID.Text = "ID"
        '
        'txtID
        '
        Me.txtID.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtID.Location = New System.Drawing.Point(84, 12)
        Me.txtID.Mask = "ses00000"
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(61, 23)
        Me.txtID.TabIndex = 0
        '
        'lblSurname
        '
        Me.lblSurname.AutoSize = true
        Me.lblSurname.Enabled = false
        Me.lblSurname.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblSurname.Location = New System.Drawing.Point(23, 44)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(55, 15)
        Me.lblSurname.TabIndex = 14
        Me.lblSurname.Text = "Surname"
        '
        'txtSurname
        '
        Me.txtSurname.Enabled = false
        Me.txtSurname.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtSurname.Location = New System.Drawing.Point(84, 41)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(264, 23)
        Me.txtSurname.TabIndex = 1
        '
        'lblFirstName
        '
        Me.lblFirstName.AutoSize = true
        Me.lblFirstName.Enabled = false
        Me.lblFirstName.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblFirstName.Location = New System.Drawing.Point(12, 73)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(66, 15)
        Me.lblFirstName.TabIndex = 16
        Me.lblFirstName.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.Enabled = false
        Me.txtFirstName.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtFirstName.Location = New System.Drawing.Point(84, 70)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(264, 23)
        Me.txtFirstName.TabIndex = 2
        '
        'cboStatus
        '
        Me.cboStatus.Enabled = false
        Me.cboStatus.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboStatus.FormattingEnabled = true
        Me.cboStatus.Items.AddRange(New Object() {"Associate Member", "Non-Operational", "On Leave", "Operational", "Probationary", "Resigned"})
        Me.cboStatus.Location = New System.Drawing.Point(84, 156)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(193, 23)
        Me.cboStatus.TabIndex = 5
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = true
        Me.lblEmail.Enabled = false
        Me.lblEmail.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblEmail.Location = New System.Drawing.Point(40, 101)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(38, 15)
        Me.lblEmail.TabIndex = 18
        Me.lblEmail.Text = "Email"
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Enabled = false
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(37, 159)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Status"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = false
        Me.txtEmail.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.txtEmail.Location = New System.Drawing.Point(84, 98)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(264, 23)
        Me.txtEmail.TabIndex = 3
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnOK.Enabled = false
        Me.btnOK.Location = New System.Drawing.Point(189, 202)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = true
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(272, 202)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = true
        '
        'cboPosition
        '
        Me.cboPosition.Enabled = false
        Me.cboPosition.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.cboPosition.FormattingEnabled = true
        Me.cboPosition.Items.AddRange(New Object() {"Controller", "Deputy Controller", "Section Leader", "Team Leader", "Deputy Team Leader", "Unit Member"})
        Me.cboPosition.Location = New System.Drawing.Point(84, 127)
        Me.cboPosition.Name = "cboPosition"
        Me.cboPosition.Size = New System.Drawing.Size(263, 23)
        Me.cboPosition.TabIndex = 4
        '
        'lblPosition
        '
        Me.lblPosition.AutoSize = true
        Me.lblPosition.Enabled = false
        Me.lblPosition.Font = New System.Drawing.Font("Calibri", 9.75!)
        Me.lblPosition.Location = New System.Drawing.Point(26, 130)
        Me.lblPosition.Name = "lblPosition"
        Me.lblPosition.Size = New System.Drawing.Size(52, 15)
        Me.lblPosition.TabIndex = 24
        Me.lblPosition.Text = "Position"
        '
        'InputMemberDetails
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(359, 237)
        Me.Controls.Add(Me.cboPosition)
        Me.Controls.Add(Me.lblPosition)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.txtSurname)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.txtFirstName)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEmail)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "InputMemberDetails"
        Me.ShowIcon = false
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Member"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents lblID As Label
    Friend WithEvents txtID As MaskedTextBox
    Friend WithEvents lblSurname As Label
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents lblEmail As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cboPosition As ComboBox
    Friend WithEvents lblPosition As Label
End Class
