Option Strict On

Imports PostOpRep.Common
Imports PostOpRep.My.Resources
Imports Serializable

<Runtime.InteropServices.Guid("BAE09B75-83E7-4D78-992F-7699D4CD0C80")>
Public Class frmNewDebrief
    'Set a boolean to indicticate that the mouse is down for the drag/drop events
    Dim _blnMouseDown As Boolean = False

    Dim _datStart As DateTime
    Dim _datFinish As DateTime

    Private _standardMargin As Integer = 12

#Region "Public Properties"

    Public Property ReadyToEmail As Boolean

    Public Property Debrief As Debrief

#End Region


#Region "Constructor"

    Sub New()
        InitializeComponent()

        ReadyToEmail = False
    End Sub

#End Region


#Region "Private Methods"

    Private Sub UpdateMemberNames()
        ' Suspend form layout
        Me.SuspendLayout()

        'Populate comboboxes
        Dim ctrls = New List(Of ComboBox)()
        ctrls.AddRange({cboSESCommander, cboCrewLeader, cboFirstAid, cboSafety})
        For Each control In ctrls
            ' Determine if an item is currently selected in the control
            Dim selectedMember As Member = CType(control.SelectedItem, Member)

            ' clear the controls items
            control.Items.Clear()

            For Each member As Member In Settings.Settings.CurrentMemberDetails
                control.Items.Add(member)
            Next

            ' reset the previously selected member
            If Settings.Settings.CurrentMemberDetails.Contains(selectedMember) Then
                control.SelectedItem = selectedMember
            Else
                control.SelectedIndex = -1
            End If
        Next

        ' Delete any members from dgvMemberAttending that are no contained in Settings.CurrentMemberDetails
        For i = dgvMembersAttending.Rows.Count - 1 To 0 Step -1
            If Not Settings.Settings.CurrentMemberDetails.Contains(CType(dgvMembersAttending.Rows(i).Cells(0).Value, Member)) Then
                dgvMembersAttending.Rows.Remove(dgvMembersAttending.Rows(i))
            End If
        Next

        'Determine which members are already contained in members attending
        Dim containedMembers As New List(Of Member)
        For Each row As DataGridViewRow In dgvMembersAttending.Rows
            containedMembers.Add(CType(row.Cells(0).Value, Member))
        Next

        ' Add member to the list of current members, if it is not already contained in dgvMembersAttending
        lstCurrentMembers.Items.Clear()
        For Each member In Settings.Settings.CurrentMemberDetails
            If Not containedMembers.Contains(member) Then
                lstCurrentMembers.Items.Add(member)
            End If
        Next

        ' Resume form layout
        Me.ResumeLayout()
    End Sub

    Private Sub SetStartFinishTimes()
        'Set the date to todays date
        dtpStart.Value = Convert.ToDateTime(Format(Now(), "dd/MM/yyyy"))
        txtStartTime.Text = Format(Now(), "HHmm")
        dtpFinish.Value = Convert.ToDateTime(Format(Now(), "dd/MM/yyyy"))
        txtFinishTime.Text = Format(Now(), "HHmm")
    End Sub

    Private Sub UpdateJobTypes()
        Dim selectedJobType = cboJobType.SelectedItem
        cboJobType.DataSource = Settings.Settings.JobTypes
        If selectedJobType IsNot Nothing AndAlso cboJobType.Items.Contains(selectedJobType) Then
            cboJobType.SelectedItem = selectedJobType
        Else
            cboJobType.SelectedIndex = -1
        End If
    End Sub

    Private Sub UpdateTaskUndertaken()
        Dim i = 0
        Dim selectedItems As New Dictionary(Of Integer, String)
        For Each row As DataGridViewRow In dgvMembersAttending.Rows
            selectedItems.Add(i, row.Cells(NameOf(clmTask1)).Value.ToString())
            i += 1
        Next

        i = 0
        clmTask1.DataSource = Settings.Settings.Tasks
        For Each row As DataGridViewRow In dgvMembersAttending.Rows
            Dim value As String = Nothing
            selectedItems.TryGetValue(i, value)
            CType(row.Cells(1), DataGridViewComboBoxCell).Value = value
        Next
    End Sub

    Private Sub UpdateVehiclesChanged()
        AddNewVehicles()

        RemoveUndefinedVehicles()
    End Sub

    Private Sub AddNewVehicles()
        For Each vehicle As String In Settings.Settings.Vehicles
            If Not (lstVehiclesUsed.Items.Contains(vehicle) Or lstUnitVehicles.Items.Contains(vehicle)) Then
                lstUnitVehicles.Items.Add(vehicle)
            End If
        Next
    End Sub

    Private Sub RemoveUndefinedVehicles()
        Dim unitVehiclesDisplayed = (From vehicle In lstUnitVehicles.Items Select vehicle).ToList()
        For Each unitVehicle As String In unitVehiclesDisplayed
            If Not Settings.Settings.Vehicles.Contains(unitVehicle) Then
                lstUnitVehicles.Items.Remove(unitVehicle)
            End If
        Next

        Dim usedVehiclesDisplayed = (From usedVehicle In lstVehiclesUsed.Items Select vehicle = usedVehicle).ToList()
        For Each vehicleUsed As String In usedVehiclesDisplayed
            If Not Settings.Settings.Vehicles.Contains(vehicleUsed) Then
                lstVehiclesUsed.Items.Remove(vehicleUsed)
            End If
        Next
    End Sub

    Private Sub UpdateEquipmentChanged()
        RemoveUndefinedEquipment()

        AddNewEquipment()
    End Sub

    Private Sub RemoveUndefinedEquipment()
        For Each row As DataGridViewRow In dgvEquipment.Rows
            If Not Settings.Settings.Equipment.Contains(CType(row.Cells(1).Value, String)) Then
                dgvEquipment.Rows.Remove(row)
            End If
        Next
    End Sub

    Private Sub AddNewEquipment()
        Dim itemsDisplayed As New List(Of String)
        For Each row As DataGridViewRow In dgvEquipment.Rows
            itemsDisplayed.Add(CType(row.Cells(1).Value, String))
        Next

        For Each newItem As String In Settings.Settings.Equipment.Except(itemsDisplayed)
            DisplayEquipment(newItem)
        Next
    End Sub

    Private Sub DisplayVehicles()
        For Each vehicle In Settings.Settings.Vehicles
            lstUnitVehicles.Items.Add(vehicle)
        Next
    End Sub

    Private Sub DisplayAllEquipment()
        DisplayEquipment(Settings.Settings.Equipment)
    End Sub

    Private Sub DisplayEquipment(item As String)
        DisplayEquipment(New List(Of String)(New String() {item}))
    End Sub

    Private Sub DisplayEquipment(items As List(Of String))
        For Each item In items
            dgvEquipment.Rows.Add(False, item, "0", Nothing)
        Next

        Dim memberCol = CType(dgvEquipment.Columns(3), DataGridViewComboBoxColumn)
        With memberCol
            .DataSource = Settings.Settings.CurrentMemberDetails
            .ValueType = GetType(Member)
            .ValueMember = NameOf(Member.Id)
            .DisplayMember = NameOf(Member.DisplayName)
        End With
    End Sub

    Private Function AllDataInput() As Boolean
        'The purpoose of this function is to return a boolean indicating whether or not all the required data on the form has been
        'input prior to distributing

        'Instantiate the return boolean
        Dim blnReturn As Boolean = True

        'Add the start/finish times
        _datStart = dtpStart.Value
        _datStart = _datStart.AddHours(Convert.ToDouble(Strings.Left(txtStartTime.Text, 2)))
        _datStart = _datStart.AddMinutes(Convert.ToDouble(Strings.Right(txtStartTime.Text, 2)))
        _datFinish = _dtpFinish.Value
        _datFinish = _datFinish.AddHours(Convert.ToDouble(Strings.Left(txtFinishTime.Text, 2)))
        _datFinish = _datFinish.AddMinutes(Convert.ToDouble(Strings.Right(txtFinishTime.Text, 2)))


        'Run the gaulntlet of tests
        If txtEventNumber.TextLength <> 10 Then
            'See if deployment is selected
            If cboDebriefType.SelectedIndex = 0 Then
                'Tell the user that the event nuber has been entered incorrectly
                MsgBox("Please enter a valid CAD Event Number.", MsgBoxStyle.Critical, "Invalid Event Number")

                'Reset the focus
                txtEventNumber.Text = ""
                txtEventNumber.Focus()

                'Set blnReturn to false
                blnReturn = False
            ElseIf cboDebriefType.SelectedIndex = 1 Then
                If Not txtEventNumber.TextLength > 0 Then
                    'Tell the user that the event nuber has been entered incorrectly
                    MsgBox("Please enter a valid deployment identifer.", MsgBoxStyle.Critical, "Invalid Deployment Identifyer")

                    'Reset the focus
                    txtEventNumber.Text = ""
                    txtEventNumber.Focus()

                    'Set blnReturn to false
                    blnReturn = False
                End If
            End If
        ElseIf _datStart > _datFinish Then
            'Tell the user that the start/finish times are inconsistent
            MsgBox("The finish time occurs before that start time.", MsgBoxStyle.Critical, "Inconsistent Start/Finish Times")

            'Reset the focus
            txtStartTime.Focus()

            'Set blnReturn to false
            blnReturn = False
        ElseIf cboJobType.SelectedIndex < 0 Then
            'Tell the user that a job type must be selected
            MsgBox("Please select a job type.", MsgBoxStyle.Critical, "Unselected Job Type")

            'Reset the focus
            cboJobType.Focus()

            'Set blnReturn to false
            blnReturn = False
        ElseIf cboSESCommander.SelectedIndex < 0 Then
            'Tell the user that an SES Commander must be selected
            MsgBox("Please select an SES Commander.", MsgBoxStyle.Critical, "No Commander Selected")

            'Reset the focus
            cboSESCommander.Focus()

            'Set blnReturn to false
            blnReturn = False
        ElseIf cboCrewLeader.SelectedIndex < 0 Then
            'Tell the user that a Crew Leader must be selected
            MsgBox("Please select a Crew Leader.", MsgBoxStyle.Critical, "No Crew Leader Selected")

            'Reset the focus
            cboCrewLeader.Focus()

            'Set blnReturn to false
            blnReturn = False
        ElseIf cboFirstAid.SelectedIndex < 0 Then
            'Tell the user that a Crew Leader must be selected
            MsgBox("Please nominate a First Aider.", MsgBoxStyle.Critical, "No First Aider Selected")

            'Reset the focus
            cboCrewLeader.Focus()

            'Set blnReturn to false
            blnReturn = False
        ElseIf cboSafety.SelectedIndex < 0 Then
            'Tell the user that a Safety Advisor must be selected
            MsgBox("Please select a Safety Advisor.", MsgBoxStyle.Critical, "No Safety Advisor Selected")

            'Reset the focus
            cboSafety.Focus()

            'Set blnReturn to false
            blnReturn = False
        End If

        Return blnReturn
    End Function

    Private Sub ControlInteractable(state As Boolean)
        For Each ctrl As Control In Me.Controls
            If ctrl.Name <> NameOf(pnlDetails) Then
                ctrl.Enabled = state
            End If
        Next

        Dim displayColour = If(state, Color.Black, Color.DarkGray)
        For Each row As DataGridViewRow In dgvEquipment.Rows
            With CType(row.Cells(1), DataGridViewTextBoxCell)
                .Style.ForeColor = displayColour
                .Style.SelectionForeColor = displayColour
            End With

            Dim rowChecked = CType(CType(row.Cells(0), DataGridViewCheckBoxCell).Value, Boolean)
            With CType(row.Cells(3), DataGridViewComboBoxCell)
                .DisplayStyle = If(state And rowChecked, DataGridViewComboBoxDisplayStyle.DropDownButton, DataGridViewComboBoxDisplayStyle.Nothing)
                .Style.ForeColor = displayColour
                .Style.SelectionForeColor = displayColour
            End With
        Next
    End Sub

#End Region


#Region "Event Handlers"

    Private Sub frmNewDebrief_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'Change the cursor to the wait cursor
        Me.Cursor = Cursors.WaitCursor

        'Set the dimensions of the form to fill the parent container
        'If Debugger.IsAttached Then
        '    For Each ctrl In frmMain.Controls
        '        If TypeOf (ctrl) Is MdiClient Then
        '            Me.Size = New Size(CType(ctrl, MdiClient).Size.Width - 14, CType(ctrl, MdiClient).Size.Height - 20)
        '        End If
        '    Next
        'Else
        Me.Dock = DockStyle.Fill
        'End If

        DetermineVisualState()

        'Populate the required controls with the names of the current members
        UpdateMemberNames()

        cboDebriefType.SelectedIndex = 0

        'Set the Yes/No comboboxes to No as default
        cboClearToAll.SelectedIndex = 1
        cboPlanB.SelectedIndex = 1
        cboMyCouncil.SelectedIndex = 1
        cboTrained.SelectedIndex = 1

        'Add the Event Handler for txtEventNumber.TextChanged
        'AddHandler txtEventNumber.TextChanged, AddressOf txtEventNumber_TextChanged

        'Add the event handlers for the textboxes
        For Each formControl As Control In Me.Controls
            If TypeOf formControl Is GroupBox Then
                For Each groupBoxControl As Control In formControl.Controls
                    If TypeOf groupBoxControl Is TextBox Then
                        AddHandler groupBoxControl.KeyPress, AddressOf textBox_KeyPress
                    End If
                Next

                formControl.BackColor = Color.Gainsboro
            End If

            If TypeOf formControl Is Panel Then
                formControl.BackColor = Color.Gainsboro
            End If
        Next

        ' Disable all the controls on the form except txtEventNumber
        ControlInteractable(False)

        'Set the focus to txtEventNumber
        txtEventNumber.Focus()

        SetStartFinishTimes()
        ' Populate Job Types and tasks undertaken
        UpdateJobTypes()
        UpdateTaskUndertaken()
        DisplayVehicles()
        DisplayAllEquipment()

        ' Subscribe to the Settings.MemberDetailsChange event in case the member details are updated while the form is open
        AddHandler Settings.Settings.MemberDetailsChanged, AddressOf OnMemberDetailsChanged
        AddHandler Settings.Settings.JobTypeChanged, AddressOf OnJobTypesChanged
        AddHandler Settings.Settings.TasksChanged, AddressOf OnTasksChanged
        AddHandler Settings.Settings.VehiclesChanged, AddressOf OnVehiclesChanged
        AddHandler Settings.Settings.EquipmentChanged, AddressOf OnEquipmentChanged

        'Now that the form is loaded, change the cursor back to pointer
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub DetermineVisualState()
        If Me.Size.Width > 1510 Then
            SetVisualState1510()
            Return
        End If

        If Me.Width > 775 Then
            SetVisualState775()
            Return
        End If
    End Sub

    Private Sub SetVisualState1510()
        Me.SuspendLayout()
        Me.VerticalScroll.Value = 0

        Dim clm1Controls = New List(Of Control)(New Control() {pnlDetails, pnlDate, grpOperational, grpPersonel})
        Dim clm2Controls = New List(Of Control)(New Control() {grpSafetyTraining, grpLogistics, grpEquipmentUsed, btnEmail})
        Dim clm1Max = MaxWidth(clm1Controls)
        Dim clm2Max = MaxWidth(clm2Controls)

        ' Column 0
        Dim xLoc = Math.Max(CInt((Me.ClientSize.Width - clm1Max - clm2Max - _standardMargin) / 2), _standardMargin)
        pnlDetails.Location = New Point(xLoc, _standardMargin)
        pnlDate.Location = New Point(xLoc, pnlDetails.Location.Y + pnlDetails.Height)
        grpOperational.Location = New Point(xLoc, pnlDate.Location.Y + pnlDate.Height + _standardMargin)
        grpPersonel.Location = New Point(xLoc, grpOperational.Location.Y + grpOperational.Height + _standardMargin)

        ' Column 1
        'Dim locX = Math.Max(pnlDetails.Width, Math.Max(pnlDate.Width, Math.Max(grpOperational.Width, grpPersonel.Width))) + _standardMargin * 2
        xLoc = xLoc + clm1Max + _standardMargin
        grpSafetyTraining.Location = New Point(xLoc, _standardMargin)
        grpLogistics.Location = New Point(xLoc, grpSafetyTraining.Location.Y + grpSafetyTraining.Height + _standardMargin)
        grpEquipmentUsed.Location = New Point(xLoc, grpLogistics.Location.Y + grpLogistics.Height + _standardMargin)
        btnEmail.Location = New Point(xLoc + grpEquipmentUsed.Width - btnEmail.Width,
                                      grpEquipmentUsed.Location.Y + grpEquipmentUsed.Height + _standardMargin)
        lblPadding.Location = New Point(_standardMargin, btnEmail.Location.Y + btnEmail.Height)

        Me.ResumeLayout()
    End Sub

    Private Function MaxWidth(crtls As List(Of Control)) As Integer
        Return (From ctrl In crtls Select ctrl.Width).Concat(New Integer() {0}).Max()
    End Function

    Private Sub SetVisualState775()
        Me.SuspendLayout()
        Me.VerticalScroll.Value = 0

        Dim ctrls = New List(Of Control)(New Control() {pnlDetails, pnlDate, grpOperational, grpPersonel,
                                                        grpSafetyTraining, grpLogistics, grpEquipmentUsed, btnEmail})
        Dim xLoc As Integer = Math.Max(CInt((Me.ClientSize.Width - MaxWidth(ctrls)) / 2), _standardMargin)

        pnlDetails.Location = New Point(xLoc, _standardMargin)
        pnlDate.Location = New Point(xLoc, pnlDetails.Location.Y + pnlDetails.Height)
        grpOperational.Location = New Point(xLoc, pnlDate.Location.Y + pnlDate.Height + _standardMargin)
        grpPersonel.Location = New Point(xLoc, grpOperational.Location.Y + grpOperational.Height + _standardMargin)
        grpSafetyTraining.Location = New Point(xLoc, grpPersonel.Location.Y + grpPersonel.Height + _standardMargin)
        grpLogistics.Location = New Point(xLoc, grpSafetyTraining.Location.Y + grpSafetyTraining.Height + _standardMargin)
        grpEquipmentUsed.Location = New Point(xLoc, grpLogistics.Location.Y + grpLogistics.Height + _standardMargin)
        btnEmail.Location = New Point(xLoc + grpEquipmentUsed.Width - btnEmail.Width,
                                      grpEquipmentUsed.Location.Y + grpEquipmentUsed.Height + _standardMargin)
        lblPadding.Location = New Point(_standardMargin, btnEmail.Location.Y + btnEmail.Height)

        Me.ResumeLayout()
    End Sub

    Private Sub frmNewDebrief_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        DetermineVisualState()
    End Sub

    Private Sub txtEventNumber_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEventNumber.KeyPress
        If e.KeyChar = vbBack Then
            Return
        End If

        If cboDebriefType.SelectedIndex = 1 Then
            If Not Char.IsLetterOrDigit(e.KeyChar) Then
                e.Handled = True
            ElseIf Char.IsLetter(e.KeyChar) Then
                e.KeyChar = Char.ToUpper(e.KeyChar)
            End If

            Return
        End If

        If txtEventNumber.TextLength = 0 Then
            'Make sure that the user is entering an "F" or an "S"
            If e.KeyChar = "F"c Or e.KeyChar = "S"c Then
                'F and S are okay
            ElseIf e.KeyChar = "f"c Then
                e.KeyChar = "F"c
            ElseIf e.KeyChar = "s"c Then
                e.KeyChar = "S"c
            Else
                e.Handled = True
            End If
        ElseIf txtEventNumber.TextLength < EventNumber.EventNumberLength Then
            If [Char].IsDigit(e.KeyChar) Then
                ' Digits are OK
            ElseIf e.KeyChar = vbBack Then
                ' Backspace key is OK
                '    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
                '    {
                '     // Let the edit control handle control and alt key combinations
                '    }
                'ElseIf e.KeyChar = " "c Then

            Else
                ' Swallow this invalid key and beep
                e.Handled = True
            End If
        Else
            'Do not allow more than 10 characters
            If e.KeyChar = vbBack Then 'Backspace is okay
                'Make sure that all elements on the form are diabled
                ControlInteractable(False)
            Else
                ' Handle the key
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtEventNumber_TextChanged(sender As Object, e As EventArgs) Handles txtEventNumber.TextChanged
        If cboDebriefType.SelectedIndex = 0 Then
            SingleIncidentEventNumberChange()
        ElseIf cboDebriefType.SelectedIndex = 1 Then
            DeploymentEventNumberChange()
        End If
    End Sub

    Private Sub SingleIncidentEventNumberChange()
        If txtEventNumber.Text = "" Then
            FormInteractable(False)
            Return
        End If

        ' If the text length is 10 characters long, then check to make sure that the format is correct, and change the visibility of the form
        ' controls accordingly

        If txtEventNumber.Text.Length = EventNumber.EventNumberLength Then
            ' Make sure that the event number is the correct

            Dim message As String = String.Empty
            If Me.Debrief Is Nothing Then
                Try
                    Me.Debrief = New DebriefSingleIncident(txtEventNumber.Text)
                Catch ex As Exception
                    message = ex.Message
                End Try
            Else
                Try
                    Me.Debrief.EventNumber = txtEventNumber.Text
                Catch ex As Exception
                    message = ex.Message
                End Try
            End If

            If message <> String.Empty Then
                MessageBox.Show(message, "Incorrect Event Format", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                'Make sure that all elements on the form are diabled
                FormInteractable(False)
            Else ' No erros thrown, so enable all the contols on the form
                FormInteractable(True)
            End If
        End If
    End Sub

    Private Sub FormInteractable(interactable As Boolean)
        ControlInteractable(interactable)
        lblIncorrectEventNumber.Visible = Not interactable

        If Not interactable Then
            txtEventNumber.SelectAll()
        End If
    End Sub

    Private Sub DeploymentEventNumberChange()
        Me.Debrief.EventNumber = txtEventNumber.Text

        If txtEventNumber.Text = "" Then
            FormInteractable(False)
        Else
            FormInteractable(True)
        End If
    End Sub

    Private Sub dgvEquipment_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvEquipment.CurrentCellDirtyStateChanged
        If dgvEquipment.IsCurrentCellDirty Then
            dgvEquipment.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvEquipment_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEquipment.CellValueChanged
        If Not (e.ColumnIndex = 0 And e.RowIndex >= 0) Then
            Return
        End If

        Dim row = dgvEquipment.Rows(e.RowIndex)
        Dim comboBox = CType(row.Cells(3), DataGridViewComboBoxCell)
        UpdateEquipmentComboBox(row, comboBox)
        UpdateEquipmentDisplayColour(row, comboBox)
    End Sub

    Private Sub dgvEquipment_CellParsing(sender As Object, e As DataGridViewCellParsingEventArgs) Handles dgvEquipment.CellParsing
        If e.ColumnIndex = 3 Then
            Dim selectedMember = From member In Settings.Settings.CurrentMemberDetails
                                 Where member.DisplayName = CType(e.Value, String)
                                 Select member
            e.Value = Activator.CreateInstance(GetType(Member), New Object() {selectedMember.FirstOrDefault})
            e.ParsingApplied = True
        End If
    End Sub

    Private Sub dgvEquipment_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvEquipment.EditingControlShowing
        If Me.dgvEquipment.CurrentCell.ColumnIndex = 2 And Not e.Control Is Nothing Then
            Dim tb As TextBox = CType(e.Control, TextBox)
            AddHandler tb.KeyPress, AddressOf DurationTextBox_KeyPress
        End If
    End Sub

    Private Sub UpdateEquipmentComboBox(row As DataGridViewRow, ByRef comboBox As DataGridViewComboBoxCell)
        comboBox.ReadOnly = Not CType(row.Cells(0).Value, Boolean)
        comboBox.DisplayStyle = If(comboBox.ReadOnly, DataGridViewComboBoxDisplayStyle.Nothing, DataGridViewComboBoxDisplayStyle.DropDownButton)
    End Sub

    Private Sub UpdateEquipmentDisplayColour(row As DataGridViewRow, comboBox As DataGridViewComboBoxCell)
        Dim displayColour = If(comboBox.ReadOnly, Color.DarkGray, Color.Black)
        With comboBox.Style
            .ForeColor = displayColour
            .SelectionForeColor = displayColour
        End With
    End Sub

    Private Sub btnEmail_Click(sender As System.Object, e As System.EventArgs) Handles btnEmail.Click
        'Make sure that all the required data has been entered correctly
        If AllDataInput() = True Then
            'Confirm that the user wishes to submit the data
            Select Case MessageBox.Show(EmailConfirmation, EmailConfirmationTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Case Windows.Forms.DialogResult.Yes
                    Me.ReadyToEmail = True

                    Me.Close()
                Case Windows.Forms.DialogResult.No
                    'Do Nothing
            End Select
        End If
    End Sub

    Private Sub dgvMembersAttending_RowsAdded(sender As System.Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles dgvMembersAttending.RowsAdded
        'Set the combo box drop down menu to 'Other'
        dgvMembersAttending(1, dgvMembersAttending.RowCount - 1).Value = "Crew Person (Other)"
    End Sub


    '---DRAG AND DROP EVENTS---

    Private Sub btnLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnLeft.Click
        'Move the resource from the list of unit resources to the list of used resources

        'Determine which resource is selected if any
        Dim strResource As String = ""

        Try
            strResource = lstUnitVehicles.SelectedItem.ToString
        Catch ex As Exception
            'Do nothing
        End Try

        If strResource <> "" Then
            'Remove the resource from the list of unit resources
            lstUnitVehicles.Items.Remove(strResource)

            'Add the resource to lstVehiclesUsed
            lstVehiclesUsed.Items.Add(strResource)

            ' Update _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.VehiclesUsed.Remove(strResource)
            End If
        End If
    End Sub

    Private Sub btnRight_Click(sender As System.Object, e As System.EventArgs) Handles btnRight.Click
        'Move the resource from the list of used resources to the list of unit resources

        'Determine which resource is selected if any
        Dim strResource As String = ""

        Try
            strResource = lstVehiclesUsed.SelectedItem.ToString
        Catch ex As Exception
            'Do nothing
        End Try

        If strResource <> "" Then
            'Remove the resource from the list of unit resources
            lstVehiclesUsed.Items.Remove(strResource)

            'Add the resource to lstVehiclesUsed
            lstUnitVehicles.Items.Add(strResource)

            ' Update _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.VehiclesUsed.Add(strResource)
            End If
        End If
    End Sub


    Private Sub lstVehiclesUsed_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstVehiclesUsed.MouseDown, lstUnitVehicles.MouseDown
        'Set a flag to show that the mouse is down.
        _blnMouseDown = True
    End Sub

    Private Sub lstVehiclesUsed_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lstVehiclesUsed.DragEnter, lstUnitVehicles.DragEnter
        ' Check the format of the data being dropped
        If (e.Data.GetDataPresent(DataFormats.Text)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
            'e.Effect = DragDropEffects.All
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstVehiclesUsed_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lstVehiclesUsed.DragDrop
        If Not (e.Data.GetData(DataFormats.Text) Is lstVehiclesUsed.SelectedItem) Then
            'Instantiate a string to store the item is to be dumped
            Dim droppedText As String = CStr(e.Data.GetData(DataFormats.Text))

            'Paste the text
            lstVehiclesUsed.Items.Add(droppedText)

            'Remove the same item from the listbox that it can from
            lstUnitVehicles.Items.Remove(droppedText)

            ' Update _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.VehiclesUsed.Add(droppedText)
            End If
        End If
    End Sub

    Private Sub lstUnitVehicles_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstUnitVehicles.MouseMove
        If _blnMouseDown = True Then
            ' Initiate dragging
            Try
                lstUnitVehicles.DoDragDrop(lstUnitVehicles.SelectedItem, DragDropEffects.Copy)
            Catch ex As Exception
                Dim strTest As String = ex.Message
            End Try
        End If

        'Reset _blnMouseDown
        _blnMouseDown = False
    End Sub

    Private Sub lstUnitVehicles_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lstUnitVehicles.DragDrop
        If Not (e.Data.GetData(DataFormats.Text) Is lstUnitVehicles.SelectedItem) Then
            'Instantiate a string to store the item is to be dumped
            Dim strDroppedText As String = CStr(e.Data.GetData(DataFormats.Text))

            'Paste the text
            lstUnitVehicles.Items.Add(strDroppedText)

            'Remove the same item from the listbox that it can from
            lstVehiclesUsed.Items.Remove(strDroppedText)

            ' Remove from the _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.VehiclesUsed.Add(strDroppedText)
            End If
        End If
    End Sub

    Private Sub btnLeftMembers_Click(sender As System.Object, e As System.EventArgs) Handles btnLeftMembers.Click
        'Move from Members Attending to Current Members

        'Determine which member is selected if any
        'Dim member As String = ""
        Dim member As Member = Nothing
        Dim gvrSelected As DataGridViewCell = Nothing

        Try
            'For Each dgvRow In dgvMembersAttending.SelectedRows
            gvrSelected = dgvMembersAttending.SelectedCells(0)
            member = CType(gvrSelected.Value, Member)
            'Next
        Catch ex As Exception
            'Do nothing
        End Try

        If member IsNot Nothing Then
            'Update the members attending data
            'UpdateMembersAttending(gvrSelected.RowIndex, False)

            'Remove the member from the list of members attending
            For Each dgvRow As DataGridViewRow In dgvMembersAttending.Rows
                If dgvRow.Cells(0).Value Is member Then
                    dgvMembersAttending.Rows.Remove(dgvRow)
                End If
            Next

            'Add the resource to lstCurrentMembers
            lstCurrentMembers.Items.Add(member)

            ' Remove from _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.MembersAttending.Remove(member)
            End If
        End If
    End Sub

    Private Sub btnRightMembers_Click(sender As System.Object, e As System.EventArgs) Handles btnRightMembers.Click
        'Move from Current Members to Members Attending

        'Determine which member is selected if any
        'Dim strMember As String = ""
        Dim member As Member = Nothing

        Try
            member = CType(lstCurrentMembers.SelectedItem, Member)
        Catch ex As Exception
            'Do nothing
        End Try

        If member IsNot Nothing Then
            'Update the members attending data
            'UpdateMembersAttending(lstCurrentMembers.SelectedIndex, True)

            'Remove the member from the list of current members
            lstCurrentMembers.Items.Remove(member)

            'Add the resource to lstMembersAttending
            dgvMembersAttending.Rows.Add({member, ""})
        End If
    End Sub

    Private Sub lstCurrentMembers_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCurrentMembers.MouseDown, dgvMembersAttending.MouseDown
        'Set a flag to show that the mouse is down.
        _blnMouseDown = True
    End Sub

    Private Sub lstCurrentMembers_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lstCurrentMembers.DragEnter, dgvMembersAttending.DragEnter
        ' Check the format of the data being dropped
        If (e.Data.GetDataPresent(DataFormats.Serializable)) Then
            ' Display the copy cursor.
            e.Effect = DragDropEffects.Copy
        Else
            ' Display the no-drop cursor.
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub lstCurrentMembers_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lstCurrentMembers.MouseMove, lstVehiclesUsed.MouseMove
        If _blnMouseDown = True Then
            ' Initiate dragging
            Try
                lstCurrentMembers.DoDragDrop(lstCurrentMembers.SelectedItem, DragDropEffects.Copy)
            Catch ex As Exception
                'Do Nothing
            End Try
        End If

        'Reset _blnMouseDown
        _blnMouseDown = False
    End Sub

    Private Sub lstCurrentMembers_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles lstCurrentMembers.DragDrop
        If Not (e.Data.GetData(DataFormats.Serializable) Is lstCurrentMembers.SelectedItem) Then
            'Instantiate a string to store the item is to be dumped
            Dim droppedMember As Member = DirectCast(e.Data.GetData(DataFormats.Serializable), Member)

            'Update the members attending data
            Dim dvgCellSelected As DataGridViewCell = dgvMembersAttending.SelectedCells(0)
            'UpdateMembersAttending(dvgCellSelected.RowIndex, False)

            'Paste the text
            lstCurrentMembers.Items.Add(droppedMember)

            'Remove the member from the list of members attending
            For Each dgvRow As DataGridViewRow In dgvMembersAttending.Rows
                If dgvRow.Cells(0).Value Is droppedMember Then
                    dgvMembersAttending.Rows.Remove(dgvRow)
                End If
            Next

            ' Remove from _debriefData
            If Me.Debrief IsNot Nothing Then
                Me.Debrief.MembersAttending.Remove(droppedMember)
            End If
        End If
    End Sub

    Private Sub dgvMembersAttending_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvMembersAttending.MouseMove
        If _blnMouseDown = True Then
            ' Initiate dragging
            Try
                dgvMembersAttending.DoDragDrop(CType(dgvMembersAttending.SelectedCells(0).Value, Member), DragDropEffects.Copy)
            Catch ex As Exception
                'Do Nothing
            End Try
        End If

        'Reset _blnMouseDown
        _blnMouseDown = False
    End Sub

    Private Sub dgvMembersAttending_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles dgvMembersAttending.DragDrop
        Dim dgvCellSelected As DataGridViewCell
        Dim strSelectedMember As String = ""

        Try
            dgvCellSelected = dgvMembersAttending.SelectedCells(0)
            strSelectedMember = Convert.ToString(dgvCellSelected.Value)
        Catch ex As Exception

        End Try

        'If Not (e.Data.GetData(DataFormats.Text) Is strSelectedMember) Then
        If e.Data.GetData(DataFormats.Serializable) IsNot strSelectedMember Then
            'Instantiate a string to store the item is to be dumped
            Dim droppedMember As Member = DirectCast(e.Data.GetData(DataFormats.Serializable), Member)

            ' Determine if the member being dropped already exists in the datagridview
            Dim isFound As Boolean = False
            For Each rw As DataGridViewRow In dgvMembersAttending.Rows
                If CType(rw.Cells(0).Value, Member).Equals(droppedMember) Then
                    isFound = True
                End If
            Next

            ' Add the member os not found
            If Not isFound Then
                'Paste the text
                dgvMembersAttending.Rows.Add({droppedMember, ""})

                'Remove the same item from the listbox that it can from
                lstCurrentMembers.Items.Remove(droppedMember)
            End If
        End If
    End Sub

    Private Sub dgvMembersAttending_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembersAttending.CellClick
        ' Show the drop down list for the receipient type
        If dgvMembersAttending.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
            dgvMembersAttending.BeginEdit(True)
            CType(dgvMembersAttending.EditingControl, ComboBox).DroppedDown = True
        End If

        If dgvMembersAttending.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
            dgvMembersAttending.BeginEdit(True)
            CType(dgvMembersAttending.EditingControl, ComboBox).DroppedDown = True
        End If
    End Sub

    Private Sub dgvMembersAttending_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembersAttending.CellValueChanged
        If dgvMembersAttending.IsCurrentCellDirty Then
            dgvMembersAttending.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

        ' Update the task undertaken for the selected member
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.MembersAttending.Item(CType(dgvMembersAttending.Rows(e.RowIndex).Cells(0).Value, Member)) =
            CType(dgvMembersAttending.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
        End If
    End Sub

    Private Sub cboDebriefType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDebriefType.SelectedIndexChanged
        If cboDebriefType.SelectedIndex < 0 Then
            Return
        End If

        If cboDebriefType.SelectedIndex = 0 Then
            UpdateFormForSingleIncident()
        ElseIf cboDebriefType.SelectedIndex = 1 Then
            Debrief = New DebriefDeployment(Me.Debrief)
        End If
    End Sub

    Private Sub UpdateFormForSingleIncident()
        Debrief = New DebriefSingleIncident(Me.Debrief)
        If EventNumber.CorrectFormat(txtEventNumber.Text) = False Then
            txtEventNumber.Text = ""
        End If
    End Sub

    Private Sub StartTime(sender As Object, e As EventArgs) Handles txtStartTime.TextChanged, dtpStart.ValueChanged
        If Me.Debrief IsNot Nothing AndAlso txtStartTime.MaskCompleted Then
            Dim startTime = dtpStart.Value.AddHours(Convert.ToDouble(Strings.Left(txtStartTime.Text, 2))) _
                                                   .AddMinutes(Convert.ToDouble(Strings.Right(txtStartTime.Text, 2)))

            Try
                Me.Debrief.StartTime = startTime
            Catch ex As InvalidOperationException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Invalid Start Time")
                txtStartTime.Focus()
                txtStartTime.SelectAll()
            End Try
        End If
    End Sub

    Private Sub FinishTime(sender As Object, e As EventArgs) Handles txtFinishTime.TextChanged, dtpFinish.ValueChanged
        If Me.Debrief IsNot Nothing AndAlso txtFinishTime.MaskCompleted Then
            Dim finishTime = dtpFinish.Value.AddHours(Convert.ToDouble(Strings.Left(txtFinishTime.Text, 2))) _
                                                       .AddMinutes(Convert.ToDouble(Strings.Right(txtFinishTime.Text, 2)))

            Try
                Me.Debrief.FinishTime = finishTime
            Catch ex As InvalidOperationException
                MsgBox(ex.Message, MsgBoxStyle.Critical, "Invalid Finish Time")
                txtFinishTime.Focus()
                txtFinishTime.SelectAll()
            End Try
        End If
    End Sub

    Private Sub cboJobType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboJobType.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            'Set the Job Type
            Me.Debrief.JobType = cboJobType.Text
        End If
    End Sub

    Private Sub cboSESCommander_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSESCommander.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.SesCommander = DirectCast(cboSESCommander.SelectedItem, Member)
        End If
    End Sub

    Private Sub cboCrewLeader_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCrewLeader.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.CrewLeader = DirectCast(cboCrewLeader.SelectedItem, Member)
        End If
    End Sub

    Private Sub cboFirstAid_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFirstAid.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.FirstAider = DirectCast(cboFirstAid.SelectedItem, Member)
        End If
    End Sub

    Private Sub txtJobDescription_Leave(sender As Object, e As EventArgs) Handles txtJobDescription.Leave
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.JobDescription = txtJobDescription.Text
        End If
    End Sub

    Private Sub txtPlan_Leave(sender As Object, e As EventArgs) Handles txtPlan.Leave
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.Plan = txtPlan.Text
        End If
    End Sub

    Private Sub cboClearToAll_TextChanged(sender As Object, e As EventArgs) Handles cboClearToAll.TextChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.PlanClearToAll = cboClearToAll.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboPlanB_Leave(sender As Object, e As EventArgs) Handles cboPlanB.Leave
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.PlanB = cboPlanB.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboMyCouncil_Leave(sender As Object, e As EventArgs) Handles cboMyCouncil.Leave
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.MyCouncil = cboMyCouncil.SelectedIndex = 0
        End If
    End Sub

    Private Sub cboSafety_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSafety.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.Safety = DirectCast(cboSafety.SelectedItem, Member)
        End If
    End Sub

    Private Sub txtSafetyConcerns_TextChanged(sender As Object, e As EventArgs) Handles txtSafetyConcerns.TextChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.SafetyConcerns = txtSafetyConcerns.Text
        End If
    End Sub

    Private Sub txtSkills_TextChanged(sender As Object, e As EventArgs) Handles txtSkills.TextChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.Skills = txtSkills.Text
        End If
    End Sub

    Private Sub cboTrained_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTrained.SelectedIndexChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.CrewAdequatelyTrained = cboPlanB.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtIssues_TextChanged(sender As Object, e As EventArgs) Handles txtIssues.TextChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.IssuesForJob = txtIssues.Text
        End If
    End Sub

    Private Sub txtEquipment_TextChanged(sender As Object, e As EventArgs) Handles txtEquipment.TextChanged
        If Me.Debrief IsNot Nothing Then
            Me.Debrief.EquipmentToMakeEasier = txtEquipment.Text
        End If
    End Sub

    Private Sub dgvEquipment_Leave(sender As Object, e As EventArgs) Handles dgvEquipment.Leave
        Me.Debrief.EquipmentUsed = New SerializableList(Of EquipmentUse)
        For Each row As DataGridViewRow In dgvEquipment.Rows
            If CType(CType(row.Cells(0), DataGridViewCheckBoxCell).Value, Boolean) Then
                Dim item = CType(row.Cells(1), DataGridViewTextBoxCell).Value.ToString()

                Dim timeUsed As Integer
                Try
                    timeUsed = Convert.ToInt32(CType(row.Cells(2), DataGridViewTextBoxCell).Value)
                Catch ex As Exception
                    MsgBox(String.Format("Please enter a duration for {0}.", item), MsgBoxStyle.Critical, "Invalid Duration")
                    ActiveControl = dgvEquipment
                    Return
                End Try

                Dim selectedMemberId As String
                Try
                    selectedMemberId = CType(row.Cells(3), DataGridViewComboBoxCell).Value.ToString()
                Catch ex As Exception
                    MsgBox(String.Format("Please select the member who used the {0}.", item), MsgBoxStyle.Critical, "Select Member")
                    ActiveControl = dgvEquipment
                    Return
                End Try

                Dim selectedMember = From member In Settings.Settings.CurrentMemberDetails
                                     Where member.Id = selectedMemberId
                                     Select member

                Me.Debrief.EquipmentUsed.Add(New EquipmentUse(item, timeUsed, selectedMember.FirstOrDefault))
            End If
        Next
    End Sub

    Private Sub textBox_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Prevent the the < or > symbols being pressed so that the this does not distruve HTML parsing when 
        ' generating the E-mail
        If e.KeyChar = "<"c Or e.KeyChar = ">"c Then
            e.Handled = True
        End If
    End Sub

    Private Sub DurationTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) OrElse e.KeyChar = vbBack Then
            Return
        End If

        e.Handled = True
    End Sub

    Private Sub OnMemberDetailsChanged(sender As Object, e As EventArgs)
        UpdateMemberNames()
    End Sub

    Private Sub OnJobTypesChanged(sender As Object, args As EventArgs)
        UpdateJobTypes()
    End Sub

    Private Sub OnTasksChanged(sender As Object, args As EventArgs)
        UpdateTaskUndertaken()
    End Sub

    Private Sub OnVehiclesChanged(sender As Object, args As EventArgs)
        UpdateVehiclesChanged()
    End Sub

    Private Sub OnEquipmentChanged(sender As Object, args As EventArgs)
        UpdateEquipmentChanged()
    End Sub

#End Region

End Class