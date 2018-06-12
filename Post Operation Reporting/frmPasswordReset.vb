Option Strict On

Imports PostOpRep.Database.DataDbConnection

Public Class frmPasswordReset

    Sub New()
        InitializeComponent()
    End Sub

    Sub New(initialPasswordReset As Boolean)
        InitializeComponent()

        DisableOldPassword()
    End Sub

    Private Sub DisableOldPassword()
        _lblOld.Enabled = False
        _txtOld.Enabled = False
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

    End Sub
End Class