<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPasswordReset
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblOld = New System.Windows.Forms.Label()
        Me.lblNew = New System.Windows.Forms.Label()
        Me.lblConfirm = New System.Windows.Forms.Label()
        Me.txtOld = New System.Windows.Forms.TextBox()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.txtNew = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(166, 107)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(247, 107)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblOld
        '
        Me.lblOld.AutoSize = True
        Me.lblOld.Location = New System.Drawing.Point(35, 15)
        Me.lblOld.Name = "lblOld"
        Me.lblOld.Size = New System.Drawing.Size(87, 15)
        Me.lblOld.TabIndex = 2
        Me.lblOld.Text = "Old Password:"
        '
        'lblNew
        '
        Me.lblNew.AutoSize = True
        Me.lblNew.Location = New System.Drawing.Point(32, 46)
        Me.lblNew.Name = "lblNew"
        Me.lblNew.Size = New System.Drawing.Size(90, 15)
        Me.lblNew.TabIndex = 3
        Me.lblNew.Text = "New Password:"
        '
        'lblConfirm
        '
        Me.lblConfirm.AutoSize = True
        Me.lblConfirm.Location = New System.Drawing.Point(12, 76)
        Me.lblConfirm.Name = "lblConfirm"
        Me.lblConfirm.Size = New System.Drawing.Size(110, 15)
        Me.lblConfirm.TabIndex = 4
        Me.lblConfirm.Text = "Confirm Password:"
        '
        'txtOld
        '
        Me.txtOld.Location = New System.Drawing.Point(127, 12)
        Me.txtOld.Name = "txtOld"
        Me.txtOld.Size = New System.Drawing.Size(195, 23)
        Me.txtOld.TabIndex = 5
        Me.txtOld.UseSystemPasswordChar = True
        '
        'txtConfirm
        '
        Me.txtConfirm.Location = New System.Drawing.Point(128, 73)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.Size = New System.Drawing.Size(194, 23)
        Me.txtConfirm.TabIndex = 6
        Me.txtConfirm.UseSystemPasswordChar = True
        '
        'txtNew
        '
        Me.txtNew.Location = New System.Drawing.Point(127, 43)
        Me.txtNew.Name = "txtNew"
        Me.txtNew.Size = New System.Drawing.Size(195, 23)
        Me.txtNew.TabIndex = 7
        Me.txtNew.UseSystemPasswordChar = True
        '
        'frmPasswordReset
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(333, 142)
        Me.Controls.Add(Me.txtNew)
        Me.Controls.Add(Me.txtConfirm)
        Me.Controls.Add(Me.txtOld)
        Me.Controls.Add(Me.lblConfirm)
        Me.Controls.Add(Me.lblNew)
        Me.Controls.Add(Me.lblOld)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPasswordReset"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reset Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents lblOld As Label
    Friend WithEvents lblNew As Label
    Friend WithEvents lblConfirm As Label
    Friend WithEvents txtOld As TextBox
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents txtNew As TextBox
End Class
