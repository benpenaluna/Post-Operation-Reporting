<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInitialize
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
        Me.pbarComponent = New System.Windows.Forms.ProgressBar()
        Me.pbarTotal = New System.Windows.Forms.ProgressBar()
        Me.lblComponent = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalPercentage = New System.Windows.Forms.Label()
        Me.lblCompPercentage = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.bw = New System.ComponentModel.BackgroundWorker()
        Me.SuspendLayout()
        '
        'pbarComponent
        '
        Me.pbarComponent.Location = New System.Drawing.Point(22, 44)
        Me.pbarComponent.Name = "pbarComponent"
        Me.pbarComponent.Size = New System.Drawing.Size(287, 23)
        Me.pbarComponent.TabIndex = 0
        '
        'pbarTotal
        '
        Me.pbarTotal.Location = New System.Drawing.Point(21, 101)
        Me.pbarTotal.Name = "pbarTotal"
        Me.pbarTotal.Size = New System.Drawing.Size(288, 23)
        Me.pbarTotal.TabIndex = 1
        '
        'lblComponent
        '
        Me.lblComponent.AutoSize = True
        Me.lblComponent.Location = New System.Drawing.Point(19, 70)
        Me.lblComponent.Name = "lblComponent"
        Me.lblComponent.Size = New System.Drawing.Size(201, 15)
        Me.lblComponent.TabIndex = 2
        Me.lblComponent.Text = "Preparing the database for first use"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(19, 127)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(95, 15)
        Me.lblTotal.TabIndex = 3
        Me.lblTotal.Text = "Total Completed"
        '
        'lblTotalPercentage
        '
        Me.lblTotalPercentage.AutoSize = True
        Me.lblTotalPercentage.Location = New System.Drawing.Point(317, 105)
        Me.lblTotalPercentage.Name = "lblTotalPercentage"
        Me.lblTotalPercentage.Size = New System.Drawing.Size(77, 15)
        Me.lblTotalPercentage.TabIndex = 4
        Me.lblTotalPercentage.Text = "0% Complete"
        '
        'lblCompPercentage
        '
        Me.lblCompPercentage.AutoSize = True
        Me.lblCompPercentage.Location = New System.Drawing.Point(317, 48)
        Me.lblCompPercentage.Name = "lblCompPercentage"
        Me.lblCompPercentage.Size = New System.Drawing.Size(77, 15)
        Me.lblCompPercentage.TabIndex = 5
        Me.lblCompPercentage.Text = "0% Complete"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(18, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(200, 15)
        Me.lblTitle.TabIndex = 6
        Me.lblTitle.Text = "Initialising Components for first use"
        '
        'bw
        '
        Me.bw.WorkerReportsProgress = True
        '
        'FrmInitialize
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(406, 158)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblCompPercentage)
        Me.Controls.Add(Me.lblTotalPercentage)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.lblComponent)
        Me.Controls.Add(Me.pbarTotal)
        Me.Controls.Add(Me.pbarComponent)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInitialize"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Initialising Components"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pbarComponent As ProgressBar
    Friend WithEvents pbarTotal As ProgressBar
    Friend WithEvents lblComponent As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblTotalPercentage As Label
    Friend WithEvents lblCompPercentage As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents bw As System.ComponentModel.BackgroundWorker
End Class
