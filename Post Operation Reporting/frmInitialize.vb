Option Strict On

Imports System.ComponentModel
Imports PostOpRep.Common
Imports PostOpRep.Database

Public Class FrmInitialize
    Private Sub frmInitialize_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Start the initialization
        bw.RunWorkerAsync()
    End Sub

    Private Sub frmInitialize_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Dispose()
    End Sub

    Private Async Sub bw_DoWorkAsync(sender As Object, e As DoWorkEventArgs) Handles bw.DoWork
        ' Get the BackgroundWorker object that raised this event. 
        Dim worker As BackgroundWorker
        worker = CType(sender, BackgroundWorker)

        ' Initialise the database
        DataDbConnection.Initialize(worker, e)
        Await Settings.Settings.InitialiseAsync(worker, e).ConfigureAwait(False)
    End Sub

    Private Sub bw_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles bw.ProgressChanged
        lblComponent.Text = InitialisationState.CurrentTask

        'Update the progress bars
        If pbarComponent.Maximum <> InitialisationState.CurrentComponentTotal Then
            pbarComponent.Maximum = InitialisationState.CurrentComponentTotal
        End If
        pbarComponent.Value = InitialisationState.CurrentComponentComplete
        lblCompPercentage.Text = String.Format("{0}% Complete", If(InitialisationState.CurrentComponentTotal = 0, 0, CInt(InitialisationState.CurrentComponentComplete / InitialisationState.CurrentComponentTotal * 100)))

        If pbarTotal.Maximum <> InitialisationState.Total Then
            pbarTotal.Maximum = InitialisationState.Total
        End If
        pbarTotal.Value = InitialisationState.TotalComplete
        lblTotalPercentage.Text = String.Format("{0}% Complete", If(InitialisationState.Total = 0, 0, CInt(InitialisationState.TotalComplete / InitialisationState.Total * 100)))
    End Sub

    Private Sub bw_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles bw.RunWorkerCompleted
        Close()
    End Sub
End Class