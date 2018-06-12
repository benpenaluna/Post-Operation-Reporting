Imports System.Drawing
Imports PostOpRep.Common
Imports PostOpRep.Database

Public Class InputMemberDetails
    Public Property MemberUpdating As Member
    Public Property AllMembers As List(Of Member)

    Private WithEvents _emailTimer As New Timer
    Private _emailToolTip As New ToolTip
    Private ReadOnly _receivedId As String = ""

    Sub New(allMembers As List(Of Member))
        InitializeComponent()

        Me.AllMembers = allMembers 
    End Sub

    Sub New(member As Member, title As String, allMembers As List(Of Member))
        InitializeComponent()

        Me.MemberUpdating = member
        Me.AllMembers = allMembers
        Me.Text = title

        _receivedId = member.Id
    End Sub

    Private Sub NewMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Me.MemberUpdating Is Nothing Then
            cboPosition.SelectedIndex = cboPosition.Items.Count - 1
            cboStatus.SelectedIndex = 4
        Else
            CompleteForm()
        End If

        ResetEmailTimer()

        txtID.Focus()
    End Sub

    Private Sub CompleteForm()
        txtID.Text = Me.MemberUpdating.Id
        txtSurname.Text = Me.MemberUpdating.Surname
        txtFirstName.Text = Me.MemberUpdating.FirstName
        txtEmail.Text = Me.MemberUpdating.EmailAddress
        cboPosition.SelectedIndex = Me.MemberUpdating.Position
        cboStatus.SelectedIndex = Me.MemberUpdating.Status
    End Sub

    Private Sub ResetEmailTimer()
        _emailTimer = New Timer()
        _emailTimer.Interval = 2000
    End Sub

    Private Sub txtID_TextChanged(sender As Object, e As EventArgs) Handles txtID.TextChanged
        If txtID.MaskFull Then
            CheckIdValidity()
        Else
            DisableFormControls()
        End If
    End Sub

    Private Function CheckIdValidity() As Boolean
        'If txtID.Text <> _receivedId AndAlso DataDbConnection.MemberIdExists(txtID.Text) Then
        If txtID.Text <> _receivedId AndAlso MembersExists(txtId.Text) Then
            MsgBox(String.Format(My.Resources.NewMemberIDAlreadyExists, txtID.Text), MsgBoxStyle.Exclamation, My.Resources.NewMemberIDAlreadyExistsTitle)
            txtID.Focus()
            Return False
        End If

        EnableFormControls()
        Return True
    End Function


    Private Function MembersExists(id As String) As Boolean
        Return (From member In AllMembers Where member.Id = id).Count > 0
    End Function

    Private Sub EnableFormControls()
        For Each ctrl In Me.Controls
            ctrl.Enabled = True
        Next
    End Sub

    Private Sub DisableFormControls()
        Dim exempt As New List(Of Control) From {lblID, txtID, btnCancel}

        For Each ctrl In Me.Controls
            If Not exempt.Contains(ctrl) Then
                ctrl.Enabled = False
            End If
        Next
    End Sub

    Private Sub txtEmail_Enter(sender As Object, e As EventArgs) Handles txtEmail.Enter
        If txtEmail.Text = "" AndAlso txtSurname.Text <> "" AndAlso txtFirstName.Text <> "" Then
            txtEmail.Text = txtFirstName.Text.ToLower().RemoveWhitespace() & "." &
                            txtSurname.Text.ToLower().RemoveWhitespace() &
                            My.Resources.StandardEmailEnding
            txtEmail.SelectAll()
        End If
    End Sub

    Private Sub txtEmail_TextChanged(sender As Object, e As EventArgs) Handles txtEmail.TextChanged
        EmailFormatNormal()
        ResetEmailTimer()
        _emailTimer.Start()
    End Sub

    Private Sub EmailTimerEventProcessor(sender As Object, e As EventArgs) Handles _emailTimer.Tick
        _emailTimer.Stop()

        CheckEmailFormat()
    End Sub

    Private Function CheckEmailFormat() As Boolean
        If Not txtEmail.Text.IsValidEmail() Then
            EmailFormatHighlighted()
            Return False
        End If

        EmailFormatNormal()
        Return True
    End Function

    Private Sub EmailFormatHighlighted()
        txtEmail.ForeColor = Color.Red
        _emailToolTip.SetToolTip(txtEmail, My.Resources.InvalidEmailAddress)
    End Sub

    Private Sub EmailFormatNormal()
        txtEmail.ForeColor = Color.Black
        _emailToolTip.RemoveAll()
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        CheckEmailFormat()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Not ChangesMade() Then
            Me.MemberUpdating = Nothing
            Me.Close()
            Return
        End If

        If Not ValidateData() Then
            Return
        End If

        CreateNewMember()
        Me.Close()
    End Sub

    Private Function ChangesMade() As Boolean
        If Me.MemberUpdating Is Nothing Then
            Return True
        End If

        If txtID.Text <> Me.MemberUpdating.Id OrElse
            txtSurname.Text <> Me.MemberUpdating.Surname OrElse
            txtFirstName.Text <> Me.MemberUpdating.FirstName OrElse
            txtEmail.Text <> Me.MemberUpdating.EmailAddress OrElse
            cboPosition.SelectedIndex <> Me.MemberUpdating.Position OrElse
            cboStatus.SelectedIndex <> Me.MemberUpdating.Status Then
            Return True
        End If

        Return False
    End Function

    Private Function ValidateData() As Boolean
        If Not CheckIdValidity() Then
            Return False
        End If

        Return CheckEmailFormat()
    End Function

    Private Sub CreateNewMember()
        Me.MemberUpdating = New Member(txtID.Text)

        With Me.MemberUpdating
            .Surname = txtSurname.Text
            .FirstName = txtFirstName.Text
            .EmailAddress = txtEmail.Text
            .Position = cboPosition.SelectedIndex
            .Status = cboStatus.SelectedIndex
        End With
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.MemberUpdating = Nothing
        Me.Close()
    End Sub
End Class