Option Strict On
Imports System.Threading.Tasks
Imports PostOpRep.Common
Imports PostOpRep.Database
Imports PostOpRep.My.Resources

Public Class frmMain

    Private Async Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FrmInitialize.ShowDialog()

        Dim resend As Task = DebriefBusiness.ResendDebriefDataAsync(New Progress(Of String)(AddressOf ReportEmailProgress))

        Try
            If My.Computer.Network.IsAvailable Then
                Await resend.ConfigureAwait(False)
            End If
        Catch ex As InvalidOperationException
            'Do Nothing
        End Try
    End Sub

    Private Sub frmMain_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        For Each child In Me.MdiChildren
            child.Size = New Size()
        Next
    End Sub

    Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoginToolStripMenuItem.Click
        Dim login As New frmLogin

        AddHandler login.FormClosed, Async Sub(s As Object, args As FormClosedEventArgs)
                                         'If login.Cancelled Then
                                         '    Return
                                         'End If



                                         'If Await PasswordMatchAsync(login.Username, login.Username) Then
                                         '        'TODO: Force password reset
                                         'End If

                                         ''TODO: Set functionality
                                         'If Not (Settings.Settings.MemberExists(login.Username) Or Settings.Settings.SetCurrentUser(login.Username)) Then
                                         '    MsgBox(String.Format(LoginLoginIncorrect, login.Username), MsgBoxStyle.Exclamation, "Invalid User")
                                         '    Return
                                         'End If

                                         'If Not Await PasswordMatchAsync(login.Username, login.Password).ConfigureAwait(False) Then
                                         '    MsgBox(LoginPasswordIncorrect, MsgBoxStyle.Exclamation, "Invalid Password")
                                         '    Return
                                         'End If

                                         If login.Cancelled Then
                                             Return
                                         End If

                                         If login.Username = "admin" And login.Password = "orange5850" Then
                                             AdministrationToolStripMenuItem.Enabled = True
                                             AdministrationToolStripMenuItem.Visible = True
                                         End If

                                         LoginToolStripMenuItem.Visible = False
                                         LogoffToolStripMenuItem.Visible = True

                                         login.Dispose()
                                     End Sub

        login.ShowDialog()
    End Sub

    Private Sub LogoffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogoffToolStripMenuItem.Click
        AdministrationToolStripMenuItem.Enabled = False
        AdministrationToolStripMenuItem.Visible = False
        LoginToolStripMenuItem.Visible = True
        LogoffToolStripMenuItem.Visible = False
    End Sub

    Private Sub NewReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NewDebriefToolStripMenuItem.Click
        Dim newDebrief As New frmNewDebrief

        AddHandler newDebrief.FormClosed, Async Sub(s As Object, args As FormClosedEventArgs)
                                              If newDebrief.ReadyToEmail Then

                                                  Dim send As Task(Of String) = DebriefBusiness.EmailDebriefAsync(newDebrief.Debrief,
                                                                                        New Progress(Of String)(AddressOf ReportEmailProgress))
                                                  'If My.Computer.Network.IsAvailable Then
                                                  'New Progress(Of String)(AddressOf ReportEmailProgress))
                                                  'End If

                                                  Dim persist As Task(Of Boolean) = DataDbConnection.AddDebriefDataAsync(newDebrief.Debrief)

                                                  Try
                                                      Await Task.WhenAll(send, persist).ConfigureAwait(False)
                                                  Catch ex As InvalidOperationException
                                                      ' Do Nothing
                                                  End Try

                                                  lblStatus.Text = send.Result
                                              End If

                                              newDebrief.Dispose()
                                          End Sub

        Dim blnFormOpen As Boolean = False

        For Each form As Form In Application.OpenForms
            If form Is newDebrief Then
                blnFormOpen = True
            End If
        Next

        If blnFormOpen = True Then
            newDebrief.Activate()
        Else
            newDebrief.MdiParent = Me
            newDebrief.Show()
        End If
    End Sub

    Private Sub ImportIRSDataToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ImportIRSDataToolStripMenuItem1.Click
        frmImportIRSData.ShowDialog()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim settingsForm As New SettingsForm

        AddHandler settingsForm.FormClosed, Async Sub(s As Object, args As FormClosedEventArgs)

                                                If Not settingsForm.Cancelled Then
                                                    lblStatus.Text = My.Resources.StatusLabelUpdatingDatabase
                                                    Await settingsForm.PersistChangesAsync().ConfigureAwait(False)
                                                    settingsForm.Dispose()
                                                    lblStatus.Text = My.Resources.StatusLabelIdleText
                                                End If
                                            End Sub

        settingsForm.ShowDialog()
    End Sub

    Private Sub ReportEmailProgress(progress As String)
        lblStatus.Text = progress
    End Sub

    Private Sub lblStatus_TextChanged(sender As Object, e As EventArgs) Handles lblStatus.TextChanged
        statusTimer.Start()
    End Sub

    Private Sub statusTimer_Tick(sender As Object, e As EventArgs) Handles statusTimer.Tick
        lblStatus.Text = StatusLabelIdleText

        statusTimer.Stop()
    End Sub
End Class
