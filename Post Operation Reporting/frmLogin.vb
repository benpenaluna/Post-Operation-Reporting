Public Class frmLogin
    Public Property Username As String
    Public Property Password As String

    Public Property Cancelled As Boolean

    Sub New()
        InitializeComponent()

        Me.Username = ""
        Me.Password = ""
        Me.Cancelled = False
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Username = txtUsername.Text
        Me.Password = txtPassword.Text

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Cancelled = True
        Me.Close()
    End Sub
End Class