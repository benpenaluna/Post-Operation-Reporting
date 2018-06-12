Option Strict On
Imports System.Net
Imports System.Net.Mail
Imports System.Reflection
Imports System.Runtime.Remoting.Messaging
Imports System.Threading.Tasks
Imports PostOpRep.Common
Imports PostOpRep.Database
Imports PostOpRep.My.Resources
Imports PostOpRep.Settings
Imports PostOpRep.Settings.Privledges

Public Class SettingsForm


#Region "Private Fields"

    Private _rowIndex As Integer
    Private _dummyDataGridView As DataGridView

    Private ReadOnly _positions As New Dictionary(Of Integer, String) From {{0, "Controller"},
                                                                   {1, "Deputy Controller"},
                                                                   {2, "Section Leader"},
                                                                   {3, "Team Leader"},
                                                                   {4, "Deputy Team Leader"},
                                                                   {5, "Unit Member"}}

    Private ReadOnly _statuses As New Dictionary(Of Integer, String) From {{0, "Associate Member"},
                                                                 {1, "Non-Operational"},
                                                                 {2, "On Leave"},
                                                                 {3, "Operational"},
                                                                 {4, "Probationary"},
                                                                 {5, "Resigned"}}

    Private _formLoading As Boolean = True
#End Region

#Region "Public Properties"

    Public Property PersistChangesEmailSettings As Boolean
    Public Property PersistChangesEquipment As Boolean
    Public Property PersistChangesJobTypes As Boolean
    Public Property PersistChangesMembers As Boolean
    Public Property PersistChangesPermissions As Boolean
    Public Property PersistPrivledges As Boolean
    Public Property PersistChangesTasks As Boolean
    Public Property PersistChangesVehicles As Boolean

    Public Property UpdatedEmailSettings As EmailSettings
    Public Property UpdatedEquipment As List(Of String)
    Public Property UpdatedJobTypes As List(Of String)
    Public Property UpdatedMembers As List(Of Member)
    Public Property UpdatedPrivledges As List(Of Permissions)
    Public Property UpdatedTasks As List(Of String)
    Public Property UpdatedVehicles As List(Of String)

    Public Property MembersUpdated As List(Of Tuple(Of String, String))
    Public Property PrivledgesUpdated As List(Of Tuple(Of String, String))

    Public Property Cancelled As Boolean

    Private ReadOnly Property UpdatedCurrentMemberDetails As List(Of Member)
        Get
            Return (From member In UpdatedMembers
                    Where member.Status <> 5
                    Order By member.Surname, member.FirstName
                    Select member).ToList()
        End Get
    End Property

    Private ReadOnly Property UpdatedResignedMemberDetails As List(Of Member)
        Get
            Return (From member In UpdatedMembers
                    Where member.Status = 5
                    Order By member.Surname, member.FirstName
                    Select member).ToList()
        End Get
    End Property

    Private ReadOnly Property UpdatedMemberDetails As List(Of Member)
        Get
            Return (From member In UpdatedMembers
                    Order By member.Surname, member.FirstName
                    Select member).ToList()
        End Get
    End Property
#End Region


#Region "Constructors"

    Sub New()
        InitializeComponent()

        SetPersistanceDefaults()

        InitialiseMemberDetails()
        InitialiseEmailSettings()
        InitialiseJobsTasks()
        InitialisePrivledges()
        InitialiseVehiclesEquipment()

        Cancelled = False
    End Sub

    Private Sub SetPersistanceDefaults()
        For Each prop As PropertyInfo In Me.GetType().GetProperties()
            If prop.GetType() = GetType(Boolean) AndAlso prop.Name.StartsWith("PersistChanges") Then
                prop.SetValue(Me, False)
            End If
        Next
    End Sub

    Private Sub InitialiseMemberDetails()
        With cboStatusFilter.Items
            .Add(My.Resources.SettingsCurrentMembers)
            .Add(My.Resources.SettingsResignedMembers)
            .Add(My.Resources.SettingsAllMembers)
        End With

        UpdatedMembers = New List(Of Member)
        For Each member In Settings.Settings.MemberDetails
            UpdatedMembers.Add(New Member(member))
        Next
        MembersUpdated = New List(Of Tuple(Of String, String))

        cboMember.SelectedItem = My.Resources.SettingsCurrentMembers
    End Sub

    Private Sub InitialiseEmailSettings()
        UpdatedEmailSettings = New EmailSettings
        For Each prop As PropertyInfo In GetType(EmailSettings).GetProperties
            prop.SetValue(Me.UpdatedEmailSettings, prop.GetValue(Settings.Settings.EmailSettings, Nothing))
        Next
    End Sub

    Private Sub InitialiseJobsTasks()
        UpdatedJobTypes = New List(Of String)
        For Each jobType As String In Settings.Settings.JobTypes
            Me.UpdatedJobTypes.Add(jobType)
        Next

        UpdatedTasks = New List(Of String)
        For Each task As String In Settings.Settings.Tasks
            Me.UpdatedTasks.Add(task)
        Next
    End Sub

    Private Sub InitialisePrivledges()
        UpdatedPrivledges = New List(Of Permissions)
        For Each privledge As Permissions In Settings.Settings.AllPermissions
            Me.UpdatedPrivledges.Add(privledge)
        Next

        PrivledgesUpdated = New List(Of Tuple(Of String, String))
    End Sub

    Private Sub InitialiseVehiclesEquipment()
        UpdatedVehicles = New List(Of String)
        For Each vehicle As String In Settings.Settings.Vehicles
            Me.UpdatedVehicles.Add(vehicle)
        Next
        UpdatedVehicles.Sort()

        UpdatedEquipment = New List(Of String)
        For Each item As String In Settings.Settings.Equipment
            Me.UpdatedEquipment.Add(item)
        Next
        UpdatedEquipment.Sort()
    End Sub

#End Region


#Region "Event Handlers"

#Region "Form Events"

    Private Async Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.SuspendLayout()

        Cursor.Current = Cursors.WaitCursor
        'Dim memberDetailsCaller As New RetrieveMemberDetailsAsync(AddressOf DataDbConnection.RetrieveMemberDetailsAsync)
        'memberDetailsCaller.BeginInvoke(AddressOf UpdateMemberDetails, Nothing)


        Await UpdateMemberDetailsAsync().ConfigureAwait(False)

        If CType(dgvAdditionalReceipients.Rows(0).Cells(2).Value, String) = "" And
            CType(dgvAdditionalReceipients.Rows(0).Cells(2).Value, String) = "" Then
            dgvAdditionalReceipients.Rows(0).Cells(2).Value = CType(dgvAdditionalReceipients.Rows(0).Cells(2), DataGridViewComboBoxCell).Items(0)
        End If

        LoadMemberSettings()
        LoadEmailSettings()
        LoadJobsTasks()
        LoadVehiclesEquipment()

        DataDbConnection.CreateDatabaseBackup()

        Cursor.Current = Cursors.Default

        _formLoading = False

        Me.ResumeLayout()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If ValidateEmailSettingsData() Then
            Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Cancelled = True
        DataDbConnection.RestoreDatabaseBackup()
        Close()
    End Sub

    Private Async Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Await PersistChangesAsync().ConfigureAwait(False)
        DataDbConnection.CreateDatabaseBackup()
    End Sub

    Public Async Function PersistChangesAsync() As Threading.Tasks.Task
        Try
            Await PersistMemberDetailsToDbAsync().ConfigureAwait(False)
            Await PersistPrivledgesToDbAsync().ConfigureAwait(False)
            PersistEmailSettingsToDb()
            PersistJobTypesToDb()
            PersistTasksToDb()
            PersistVehiclesToDb()
            PersistEquipmentToDb()
        Catch ex As Exception
            DataDbConnection.RestoreDatabaseBackup()
            Throw
        Finally
            DataDbConnection.DeleteDatabaseBackup()
        End Try
    End Function

    Private Async Function PersistMemberDetailsToDbAsync() As Task
        If PersistChangesMembers Then
            For Each memberId As Tuple(Of String, String) In MembersUpdated
                Dim member = GetMemberFromUpdatedMembers(memberId.Item1)

                If (memberId.Item1 = "" AndAlso memberId.Item2 = "") Then
                    Continue For
                ElseIf memberId.Item1 <> "" AndAlso memberId.Item2 <> "" Then
                    Await DataDbConnection.UpdateMemberAsync(member, memberId.Item2).ConfigureAwait(False)
                ElseIf memberId.Item2 = "" Then
                    Await DataDbConnection.CreateMemberAsync(member).ConfigureAwait(False)
                ElseIf memberId.Item1 = "" Then
                    Await DataDbConnection.DeleteMemberAsync(memberId.Item2).ConfigureAwait(False)
                End If
            Next
            MembersUpdated.Clear()
            Settings.Settings.MemberDetails = UpdatedMembers
        End If
    End Function

    Private Async Function PersistPrivledgesToDbAsync() As Threading.Tasks.Task
        If PersistChangesPermissions Then
            For Each memberId As Tuple(Of String, String) In PrivledgesUpdated
                Dim privledges = GetPrivledgesFromUpdatedPrivledges(memberId.Item1)

                If (memberId.Item1 = "" AndAlso memberId.Item2 = "") Then
                    Continue For
                ElseIf memberId.Item1 <> "" AndAlso memberId.Item2 <> "" Then
                    Await DataDbConnection.UpdatePrivledgesAsync(privledges, memberId.Item2).ConfigureAwait(False)
                ElseIf memberId.Item2 = "" Then
                    Await DataDbConnection.CreatePrivledgesAsync(privledges).ConfigureAwait(False)
                ElseIf memberId.Item1 = "" Then
                    Await DataDbConnection.DeletePrivledgesAsync(memberId.Item2).ConfigureAwait(False)
                End If
            Next
            PrivledgesUpdated.Clear()
            Settings.Settings.AllPermissions = UpdatedPrivledges
        End If
    End Function

    Private Sub PersistEmailSettingsToDb()
        If PersistChangesEmailSettings AndAlso ValidateEmailSettingsData() Then
            DataDbConnection.SaveEmailSettings(UpdatedEmailSettings)
            Settings.Settings.EmailSettings = Me.UpdatedEmailSettings
        End If
    End Sub

    Private Sub PersistJobTypesToDb()
        If PersistChangesJobTypes Then
            DataDbConnection.SaveJobTypes(UpdatedJobTypes)
            Settings.Settings.JobTypes = Me.UpdatedJobTypes
        End If
    End Sub

    Private Sub PersistTasksToDb()
        If PersistChangesTasks Then
            DataDbConnection.SaveTasks(UpdatedTasks)
            Settings.Settings.Tasks = Me.UpdatedTasks
        End If
    End Sub

    Private Sub PersistVehiclesToDb()
        If PersistChangesVehicles Then
            DataDbConnection.SaveVehicles(UpdatedVehicles)
            Settings.Settings.Vehicles = Me.UpdatedVehicles
        End If
    End Sub

    Private Sub PersistEquipmentToDb()
        If PersistChangesEquipment Then
            DataDbConnection.SaveEquipment(UpdatedEquipment)
            Settings.Settings.Equipment = Me.UpdatedEquipment
        End If
    End Sub

    Public Function GetPrivledgesFromUpdatedPrivledges(memberId As String) As Permissions
        Return (From privledge In UpdatedPrivledges
                Where privledge.Member.Id = memberId
                Select privledge).ToList().FirstOrDefault()
    End Function

    Public Function GetMemberFromUpdatedMembers(memberId As String) As Member
        Return (From mmbr In UpdatedMembers
                Where mmbr.Id = memberId
                Select mmbr).ToList().FirstOrDefault()
    End Function

#End Region

#Region "Member Details"

    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim newMember As New InputMemberDetails(UpdatedMembers)

        AddHandler newMember.FormClosed, Async Sub(s As Object, args As FormClosedEventArgs)
                                             If newMember.MemberUpdating <> Nothing Then
                                                 'Await DataDbConnection.CreateMemberAsync(newMember.MemberUpdating)
                                                 UpdatedMembers.Add(newMember.MemberUpdating)
                                                 MembersUpdated.Add(Tuple.Create(newMember.MemberUpdating.Id, ""))
                                                 PersistChangesMembers = True

                                                 Dim priv As Permissions = Await RetrieveDefaultPermissionsAsync(newMember.MemberUpdating).ConfigureAwait(False)
                                                 UpdatedPrivledges.Add(priv)
                                                 PrivledgesUpdated.Add(Tuple.Create(newMember.MemberUpdating.Id, ""))
                                                 PersistChangesPermissions = True

                                                 UpdateForm(newMember.MemberUpdating)
                                             End If

                                             newMember.Dispose()
                                         End Sub

        newMember.ShowDialog()
    End Sub

    Private Shared Async Function RetrieveDefaultPermissionsAsync(mmbr As Member) As Task(Of Permissions)
        Dim defaultId = PermissionControllerID.Substring(0, 7) + mmbr.Position.ToString()
        Dim defaultPriv = Await DataDbConnection.RetrieveMemberPrivledgesAsync(New Member(defaultId)).ConfigureAwait(False)
        Return New Permissions(mmbr, defaultPriv)
    End Function

    Private Sub UpdateMemberComboBox(selectedMember As Member)
        SuspendLayout()

        cboMember.Items.Clear()

        DisplayMembers(selectedMember, DetermineMembersToDisplay())

        ResumeLayout()
    End Sub

    Private Function DetermineMembersToDisplay() As List(Of Member)
        Dim displayMembers As New List(Of Member)
        Select Case cboStatusFilter.SelectedItem.ToString()
            Case My.Resources.SettingsCurrentMembers
                displayMembers = UpdatedCurrentMemberDetails

            Case My.Resources.SettingsResignedMembers
                displayMembers = UpdatedResignedMemberDetails

            Case My.Resources.SettingsAllMembers
                displayMembers = UpdatedMemberDetails
        End Select

        Return displayMembers
    End Function

    Private Sub DisplayMembers(selectedMember As Member, displayMembers As List(Of Member))
        For Each member As Member In displayMembers
            cboMember.Items.Add(member)
        Next

        If displayMembers.Contains(selectedMember) Then
            cboMember.SelectedItem = selectedMember
        Else
            cboMember.SelectedIndex = If(cboMember.Items.Count > 0, 0, -1)
        End If
    End Sub

    Private Sub UpdateForm(member As Member)
        UpdateMemberComboBox(member)
        PersistChangesMembers = True
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim selectedMember = New Member(CType(cboMember.SelectedItem, Member))
        Dim member As New InputMemberDetails(selectedMember, My.Resources.SettingsUpdateMemberTitle, UpdatedMembers)


        AddHandler member.FormClosed, Sub(s As Object, args As FormClosedEventArgs)
                                          If member.MemberUpdating <> Nothing Then
                                              UpdateMembers(selectedMember, member)
                                              UpdatePrivledges(selectedMember, member)
                                              UpdateForm(member.MemberUpdating)
                                          End If

                                          member.Dispose()
                                      End Sub

        member.ShowDialog()
    End Sub

    Private Sub UpdateMembers(selectedMember As Member, member As InputMemberDetails)
        UpdateMembersUpdatedListUpdate(member.MemberUpdating.Id, selectedMember.Id)
        UpdatedMembers.Remove(selectedMember)
        UpdatedMembers.Add(member.MemberUpdating)
        PersistChangesMembers = True
    End Sub

    Private Sub UpdateMembersUpdatedListUpdate(newId As String, oldId As String)
        Dim newMembersUpdated As List(Of Tuple(Of String, String)) = (From update In MembersUpdated
                                                                      Where update.Item1 = oldId).ToList()

        If newMembersUpdated.Count = 0 Then
            MembersUpdated.Add(Tuple.Create(newId, oldId))
            Return
        End If

        For Each update As Tuple(Of String, String) In newMembersUpdated
            If update.Item2 = "" Then
                UpdateMembersCreation(newId, update)
            Else
                UpdateMembersUpdate(newId, update)
            End If
        Next
    End Sub

    Private Sub UpdateMembersCreation(newId As String, update As Tuple(Of String, String))
        MembersUpdated.Remove(update)
        MembersUpdated.Add(Tuple.Create(newId, ""))
    End Sub

    Private Sub UpdateMembersUpdate(newId As String, update As Tuple(Of String, String))
        Dim oldId As String = update.Item2
        MembersUpdated.Remove(update)
        MembersUpdated.Add(Tuple.Create(newId, oldId))
    End Sub

    Private Sub UpdatePrivledges(selectedMember As Member, member As InputMemberDetails)
        Dim privledges = RetrieveMemberPrivledges(selectedMember)
        UpdatePermissionssUpdatedListUpdate(member.MemberUpdating.Id, selectedMember.Id)
        UpdatedPrivledges.Remove(privledges)
        UpdatedPrivledges.Add(New Permissions(member.MemberUpdating, privledges))
        PersistChangesPermissions = True
    End Sub

    Private Sub UpdatePermissionssUpdatedListUpdate(newId As String, oldId As String)
        Dim newPrivledgesUpdated As List(Of Tuple(Of String, String)) = (From update In PrivledgesUpdated
                                                                         Where update.Item1 = oldId).ToList()

        If newPrivledgesUpdated.Count = 0 Then
            PrivledgesUpdated.Add(Tuple.Create(newId, oldId))
            Return
        End If

        For Each update As Tuple(Of String, String) In newPrivledgesUpdated
            If update.Item2 = "" Then
                UpdatePrivledgesCreation(newId, update)
            Else
                UpdatePrivledgesUpdate(newId, update)
            End If
        Next
    End Sub

    Private Sub UpdatePrivledgesCreation(newId As String, update As Tuple(Of String, String))
        PrivledgesUpdated.Remove(update)
        PrivledgesUpdated.Add(Tuple.Create(newId, ""))
    End Sub

    Private Sub UpdatePrivledgesUpdate(newId As String, update As Tuple(Of String, String))
        Dim oldId As String = update.Item2
        PrivledgesUpdated.Remove(update)
        PrivledgesUpdated.Add(Tuple.Create(newId, oldId))
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim selectedMember = New Member(CType(cboMember.SelectedItem, Member))

        Select Case MessageBox.Show(String.Format(My.Resources.SettingsDeleteMemberCaption, selectedMember.FirstName, selectedMember.Surname),
                                    My.Resources.SettingsDeleteMemberTitle,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Stop)
            Case DialogResult.Yes
                DeleteMembers(selectedMember)
                DeletePrivledges(selectedMember)
                UpdateForm(selectedMember)
            Case Else
                Return
        End Select
    End Sub

    Private Sub DeleteMembers(selectedMember As Member)
        UpdatedMembers.Remove(selectedMember)
        UpdateMembersUpdatedListDeletion(selectedMember.Id)
        PersistChangesMembers = True
    End Sub

    Private Sub UpdateMembersUpdatedListDeletion(id As String)
        Dim newMembersUpdated As List(Of Tuple(Of String, String)) = (From update In MembersUpdated
                                                                      Where (update.Item1 = id OrElse update.Item2 = id)).ToList()

        If newMembersUpdated.Count = 0 Then
            MembersUpdated.Add(Tuple.Create("", id))
            Return
        End If

        For Each update As Tuple(Of String, String) In newMembersUpdated
            MembersUpdated.Remove(update)
            If update.Item1 <> "" AndAlso update.Item2 <> "" Then
                MembersUpdated.Add(Tuple.Create("", update.Item2))
            End If
        Next
    End Sub

    Private Sub DeletePrivledges(selectedMember As Member)
        Dim privledges = RetrieveMemberPrivledges(selectedMember)
        UpdatedPrivledges.Remove(privledges)
        UpdatePrivledgesUpdatedListDeletion(selectedMember.Id)
        PersistChangesPermissions = True
    End Sub

    Private Function RetrieveMemberPrivledges(selectedMember As Member) As Permissions
        Return (From priv In UpdatedPrivledges
                Where priv.Member = selectedMember
                Select priv).ToList().FirstOrDefault()
    End Function

    Private Sub UpdatePrivledgesUpdatedListDeletion(id As String)
        Dim newPrivledgesUpdated As List(Of Tuple(Of String, String)) = (From update In PrivledgesUpdated
                                                                         Where (update.Item1 = id OrElse update.Item2 = id)).ToList()

        If newPrivledgesUpdated.Count = 0 Then
            PrivledgesUpdated.Add(Tuple.Create("", id))
            Return
        End If

        For Each update As Tuple(Of String, String) In newPrivledgesUpdated
            PrivledgesUpdated.Remove(update)
            If update.Item1 <> "" AndAlso update.Item2 <> "" Then
                PrivledgesUpdated.Add(Tuple.Create("", id))
            End If
        Next
    End Sub

    Private Sub cboStatusFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboStatusFilter.SelectedIndexChanged
        Dim selectedMember = CType(cboMember.SelectedItem, Member)

        UpdateMemberComboBox(selectedMember)
    End Sub

    Private Sub cboMember_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMember.SelectedIndexChanged
        If cboMember.SelectedIndex >= 0 Then
            SetMemberDetails()
            DisplayPermissions()
        Else
            SetMemberDetailDefaults()
        End If
    End Sub

    Private Sub SetMemberDetails()
        Dim selectedMember = CType(cboMember.SelectedItem, Member)

        lblID.Text = selectedMember.Id
        lblSurname.Text = selectedMember.Surname
        lblFirstName.Text = selectedMember.FirstName
        lblEmail.Text = selectedMember.EmailAddress

        Dim value As String = ""
        _positions.TryGetValue(selectedMember.Position, value)
        lblPosition.Text = If(Not value = "", value, "Unknown")

        value = ""
        _statuses.TryGetValue(selectedMember.Status, value)
        lblStatus.Text = If(Not value = "", value, "Unknown")

        grpPrivledges.Text = String.Format(My.Resources.SettingsPrivledgesPersonalText,
                                           CType(cboMember.SelectedItem, Member).FirstName)
    End Sub

    Private Sub DisplayPermissions()
        Dim selectedMember = CType(cboMember.SelectedItem, Member)

        'Dim permissions = Settings.Settings.RetrieveMemberPrivledges(selectedMember)
        Dim permissions = RetrieveMemberPermissions(selectedMember)

        PopulatePermissions(permissions)
    End Sub

    Private Function RetrieveMemberPermissions(selectedMember As Member) As Permissions
        Return (From priv In UpdatedPrivledges
                Where priv.Member = selectedMember
                Select priv).ToList().FirstOrDefault()
    End Function

    Private Sub PopulatePermissions(permissions As Permissions)
        Dim mappings = RetrieveNodePrivledgesMapping()

        For Each mapping As KeyValuePair(Of Tuple(Of String, String), String) In mappings
            Dim checked As Boolean
            If mapping.Key.Item2 = "" Then
                checked = CType(GetType(Permissions).GetProperty(mapping.Key.Item1).GetValue(permissions), Boolean)
            Else
                checked = GetImbeddedPropertyValue(permissions, mapping)
            End If

            tstvPrivledges.Nodes.Find(mapping.Value, True).FirstOrDefault().Checked = checked
        Next
    End Sub

    Private Function RetrieveNodePrivledgesMapping() As Dictionary(Of Tuple(Of String, String), String)
        Dim mapping = New Dictionary(Of Tuple(Of String, String), String)

        With mapping
            .Add(New Tuple(Of String, String)(NameOf(Permissions.CreateDebriefs), ""), "ndeDebriefs")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.UserManagementPrivledges), NameOf(UserManagementPrivledges.AssignPrivledges)), "ndeAssignPrivledges")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.UserManagementPrivledges), NameOf(UserManagementPrivledges.ResetOwnPassword)), "ndeResetOwnPassword")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.UserManagementPrivledges), NameOf(UserManagementPrivledges.ResetOthersPassword)), "ndeResetOtherPassword")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.MembersPrivledges), NameOf(MembersPrivledges.CreateNewMember)), "ndeCreateNewMember")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.MembersPrivledges), NameOf(MembersPrivledges.UpdateSelf)), "ndeUpdateSelf")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.MembersPrivledges), NameOf(MembersPrivledges.UpdateAnotherMember)), "ndeUpdateAnotherMember")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.MembersPrivledges), NameOf(MembersPrivledges.DeleteMember)), "ndeDeleteMember")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.EmailSettingsPrivledges), NameOf(EmailSettingsPrivledges.UpdateEmailReceipients)), "ndeUpdateEmailReceipients")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.EmailSettingsPrivledges), NameOf(EmailSettingsPrivledges.UpdateMailServer)), "ndeUpdateMailServer")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.EmailSettingsPrivledges), NameOf(EmailSettingsPrivledges.UpdateNetworkCredentials)), "ndeUpdateNetworkCredentials")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.EmailSettingsPrivledges), NameOf(EmailSettingsPrivledges.UpdateClientSettings)), "ndeUpdateClientSettings")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.EmailSettingsPrivledges), NameOf(EmailSettingsPrivledges.UpdateFromAddress)), "ndeUpdateFromAddress")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.JobTaskPrivledges), NameOf(JobTaskPrivledges.UpdateJobTypes)), "ndeUpdateJobTypes")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.JobTaskPrivledges), NameOf(JobTaskPrivledges.UpdateTasks)), "ndeUpdateTasks")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.VehiclesEquipmentPrivledges), NameOf(VehiclesEquipmentPrivledges.UpdateVehicles)), "ndeUpdateVehicles")
            .Add(New Tuple(Of String, String)(NameOf(Permissions.VehiclesEquipmentPrivledges), NameOf(VehiclesEquipmentPrivledges.UpdateEquipment)), "ndeUpdateEquipment")
        End With

        Return mapping
    End Function

    Private Shared Function GetImbeddedPropertyValue(permissions As Permissions, mapping As KeyValuePair(Of Tuple(Of String, String), String)) As Boolean
        Dim props = DetermineBaseChildProperties(mapping)

        Dim baseValue = props.BaseProperty.GetValue(permissions)
        Return CType(props.ChildProperty.GetValue(baseValue), Boolean)
    End Function

    Private Shared Sub SetImbeddedPropertyValue(ByRef permissions As Permissions, mapping As KeyValuePair(Of Tuple(Of String, String), String), value As Boolean)
        Dim props = DetermineBaseChildProperties(mapping)

        'If props.ChildProperty Is Nothing Then
        '    props.BaseProperty.SetValue(permissions, value)
        'Else
        Dim baseValue = props.BaseProperty.GetValue(permissions)
        props.ChildProperty.SetValue(baseValue, value)
        'End If
    End Sub


    Private Shared Function DetermineBaseChildProperties(mapping As KeyValuePair(Of Tuple(Of String, String), String)) As ImbeddedPropertyInfo
        Dim baseProp As PropertyInfo = GetType(Permissions).GetProperty(mapping.Key.Item1)
        Dim childProp = baseProp.PropertyType().GetProperty(mapping.Key.Item2)

        Return New ImbeddedPropertyInfo(baseProp, childProp)
    End Function

    Private Sub tstvPrivledges_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tstvPrivledges.AfterCheck
        PersistPrivledges = True
    End Sub

    Private Sub tstvPrivledges_Leave(sender As Object, e As EventArgs) Handles tstvPrivledges.Leave
        'Dim newPrivledges As New Permissions(CType(cboMember.SelectedItem, Member))

        Dim newPrivledges = DeterminePrivledges(CType(cboMember.SelectedItem, Member))

        UpdatePrivledgesList(newPrivledges)

        PersistChangesPermissions = True
    End Sub

    Private Function DeterminePrivledges(member As Member) As Permissions
        Dim mappings = RetrieveNodePrivledgesMapping()
        Dim newPrivledges As New Permissions(member)

        For Each mapping As KeyValuePair(Of Tuple(Of String, String), String) In mappings
            Dim node As TreeNode = tstvPrivledges.Nodes.Find(mapping.Value, True).FirstOrDefault()

            If node Is Nothing Then
                Continue For
            End If

            If mapping.Key.Item2 = "" Then
                Dim prop = GetType(Permissions).GetProperty(mapping.Key.Item1)
                prop.SetValue(newPrivledges, node.Checked)
            Else
                SetImbeddedPropertyValue(newPrivledges, mapping, node.Checked)
            End If
        Next

        Return newPrivledges
    End Function

    Private Sub UpdatePrivledgesList(newPrivledges As Permissions)
        Dim currentPrivledges = (From privledges In UpdatedPrivledges
                                 Where privledges.Member = newPrivledges.Member
                                 Select privledges).ToList()
        For Each priv As Permissions In currentPrivledges
            UpdatedPrivledges.Remove(priv)
        Next

        UpdatedPrivledges.Add(newPrivledges)
    End Sub

    Private Sub SetMemberDetailDefaults()
        lblID.Text = ""
        lblSurname.Text = ""
        lblFirstName.Text = ""
        lblEmail.Text = ""
        lblPosition.Text = ""
        lblStatus.Text = ""

        grpPrivledges.Text = My.Resources.SettingsPrivledgesDefaultText
    End Sub

    Private Sub CheckAllChildNodes(treeNode As TreeNode, nodeChecked As Boolean)
        Dim node As TreeNode
        For Each node In treeNode.Nodes
            node.Checked = nodeChecked
            If node.Nodes.Count > 0 Then
                CheckAllChildNodes(node, nodeChecked)
            End If
        Next node
    End Sub

#End Region

#Region "Email Settings"

    Private Sub chkAllMembersReceive_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllMembersReceive.CheckedChanged
        ' Make the recipient type combobox visible
        lblReceipientType.Enabled = chkAllMembersReceive.Checked
        cboRecepientType.Enabled = chkAllMembersReceive.Checked

        ' Store the changes
        UpdatedEmailSettings.AllMemberReceive = chkAllMembersReceive.Checked

        PersistChangesEmailSettings = True
    End Sub

    Private Sub cboRecepientType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRecepientType.SelectedIndexChanged
        ' Store the changes
        Select Case cboRecepientType.SelectedIndex
            Case 0 ' Bcc
                UpdatedEmailSettings.AllMemberReceipientType = EmailSettings.TypeOfReceipient.Bcc

            Case 1 ' CC
                UpdatedEmailSettings.AllMemberReceipientType = EmailSettings.TypeOfReceipient.Cc

            Case 2 'To
                UpdatedEmailSettings.AllMemberReceipientType = EmailSettings.TypeOfReceipient.Too
        End Select

        PersistChangesEmailSettings = True
    End Sub

    Private Sub dgvMembersToReceive_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvMembersToReceive.CurrentCellDirtyStateChanged
        'Update the value of the cell
        If dgvMembersToReceive.IsCurrentCellDirty Then
            dgvMembersToReceive.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvMembersToReceive_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembersToReceive.CellValueChanged
        If e.RowIndex < 0 Then
            Return
        End If

        Dim selectedMember As Member = CType(dgvMembersToReceive.Rows(e.RowIndex).Cells(1).Value, Member)
        Dim rType As EmailSettings.TypeOfReceipient
        Select Case CType(dgvMembersToReceive.Rows(e.RowIndex).Cells(2).Value, String)
            Case "Bcc"
                rType = EmailSettings.TypeOfReceipient.Bcc

            Case "CC"
                rType = EmailSettings.TypeOfReceipient.Cc

            Case "To"
                rType = EmailSettings.TypeOfReceipient.Too
        End Select

        Select Case e.ColumnIndex
            Case 0 ' Member to receive
                'Dim checked As Boolean = CType(dgvMembersToReceive.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, CheckBox).Checked
                If CType(dgvMembersToReceive.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, Boolean) Then ' Add the member to the receipient list
                    If Not UpdatedEmailSettings.MembersToReceive.ContainsKey(selectedMember) Then
                        UpdatedEmailSettings.MembersToReceive.Add(selectedMember, rType)
                    Else
                        UpdatedEmailSettings.MembersToReceive(selectedMember) = rType
                    End If
                Else ' Remove the member from the receipient list
                    If UpdatedEmailSettings.MembersToReceive.ContainsKey(selectedMember) Then
                        UpdatedEmailSettings.MembersToReceive.Remove(selectedMember)
                    End If
                End If

            Case 2 ' Receipient Type
                If Not UpdatedEmailSettings.MembersToReceive.ContainsKey(selectedMember) Then
                    'Add the selected member
                    UpdatedEmailSettings.MembersToReceive.Add(selectedMember, rType)
                Else
                    UpdatedEmailSettings.MembersToReceive(selectedMember) = rType
                End If
        End Select

        PersistChangesEmailSettings = True
    End Sub

    Private Sub dgvMembersToReceive_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMembersToReceive.CellClick
        ' Show the drop down list for the receipient type
        If dgvMembersToReceive.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
            dgvMembersToReceive.BeginEdit(True)
            CType(dgvMembersToReceive.EditingControl, ComboBox).DroppedDown = True
        End If
    End Sub

    Private Sub chkSelectAllToReceive_CheckedChanged(sender As Object, e As EventArgs) Handles chkSelectAllToReceive.CheckedChanged
        ' Check all the members in dgvMembersToReceive
        For Each row As DataGridViewRow In dgvMembersToReceive.Rows
            row.Cells(0).Value = chkSelectAllToReceive.Checked
        Next

        PersistChangesEmailSettings = True
    End Sub

    Private Sub dgvAdditionalReceipients_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdditionalReceipients.CellClick
        ' Show the drop down list for the receipient type
        If e.ColumnIndex >= 0 Then
            If dgvAdditionalReceipients.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
                dgvAdditionalReceipients.BeginEdit(True)
                CType(dgvAdditionalReceipients.EditingControl, ComboBox).DroppedDown = True
            End If
        End If
    End Sub

    Private Sub dgvAdditionalReceipients_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvAdditionalReceipients.CurrentCellDirtyStateChanged
        'Update the value of the cell
        If dgvAdditionalReceipients.IsCurrentCellDirty Then
            dgvAdditionalReceipients.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvAdditionalReceipients_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdditionalReceipients.CellValueChanged
        If e.RowIndex < 0 Then
            Return
        End If

        Dim headerText As String = dgvAdditionalReceipients.Columns(e.ColumnIndex).HeaderText

        ' Abort validation if cell is not in the CompanyName column.
        If Not headerText.Equals("Email Address") Then Return

        ' Confirm that the cell is a valid E-mail address
        Dim address As String = CType(dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
        If address.IsValidEmail Then
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = dgvAdditionalReceipients.ForeColor
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = String.Empty
        End If

        PersistChangesEmailSettings = True
    End Sub

    Private Sub dgvAdditionalReceipients_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvAdditionalReceipients.CellValidating
        Dim headerText As String = dgvAdditionalReceipients.Columns(e.ColumnIndex).HeaderText

        ' Abort validation if cell is not in the CompanyName column.
        If Not headerText.Equals("Email Address") Then Return

        'Update the value of the cell
        If dgvAdditionalReceipients.IsCurrentCellDirty Then
            dgvAdditionalReceipients.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

        ' Confirm that the cell is a valid E-mail address
        Dim address As String = CType(dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
        If Not address.IsValidEmail Then
            dgvAdditionalReceipients.Rows(e.RowIndex).ErrorText = My.Resources.InvalidEmailAddress
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = Color.Red
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = My.Resources.InvalidEmailAddress
        Else
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.ForeColor = dgvAdditionalReceipients.ForeColor
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex).ToolTipText = String.Empty
        End If
    End Sub

    Private Sub dgvAdditionalReceipients_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdditionalReceipients.CellEndEdit
        ' Clear the row error in case the user presses ESC. 
        dgvAdditionalReceipients.Rows(e.RowIndex).ErrorText = String.Empty
    End Sub

    Private Sub dgvAdditionalReceipients_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAdditionalReceipients.CellEnter
        ' Show the Ibeam in the textbox
        dgvAdditionalReceipients.CurrentCell = dgvAdditionalReceipients.Rows(e.RowIndex).Cells(e.ColumnIndex)
        dgvAdditionalReceipients.BeginEdit(False)
    End Sub

    Private Sub dgvAdditionalReceipients_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvAdditionalReceipients.RowsAdded
        Try
            'Dim type As Type = dgvAdditionalReceipients.Rows(e.RowIndex).Cells(2).ValueType
            dgvAdditionalReceipients.Rows(e.RowIndex).Cells(2).Value = CType(dgvAdditionalReceipients.Rows(e.RowIndex).Cells(2), DataGridViewComboBoxCell).Items(0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtHost_Leave(sender As Object, e As EventArgs) Handles txtHost.Leave
        If txtHost.Text <> UpdatedEmailSettings.SmtpClient.Host Then
            Dim isValidCaller As New IsValidSmtpServerAsync(AddressOf SmtpHelper.IsValidSmtpServer)
            isValidCaller.BeginInvoke(txtHost.Text, AddressOf UpdateHostFormat, Nothing)

            PersistChangesEmailSettings = True
        End If
    End Sub

    Private Sub txtPort_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPort.KeyPress
        ' Handle any non-numeric keypresses
        If e.KeyChar = vbBack Or IsNumeric(e.KeyChar) Then
            PersistChangesEmailSettings = True
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtUserName_Leave(sender As Object, e As EventArgs) Handles txtUserName.Leave, txtPassword.Leave
        UpdatedEmailSettings.SmtpClient.Credentials = New NetworkCredential(txtUserName.Text, txtPassword.Text)

        PersistChangesEmailSettings = True
    End Sub

    Private Sub chkShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowPassword.CheckedChanged
        ' Temporarily suspent the layout
        txtPassword.SuspendLayout()

        ' Make the appropriate modifications for the textbox
        txtPassword.PasswordChar = CType(If(chkShowPassword.Checked, "", "l"), Char)
        txtPassword.Font = If(chkShowPassword.Checked, New Font(chkShowPassword.Parent.Font, FontStyle.Regular),
                              New Font("Wingdings", chkShowPassword.Parent.Font.Size))

        ' Resume the layout
        txtPassword.ResumeLayout()

        ' Update Email Settings
        UpdatedEmailSettings.ShowPassword = chkShowPassword.Checked
    End Sub

    Private Sub cboPriority_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPriority.SelectedIndexChanged
        Select Case cboPriority.SelectedIndex
            Case 0 ' High
                UpdatedEmailSettings.MailPriority = MailPriority.High

            Case 1 ' Low
                UpdatedEmailSettings.MailPriority = MailPriority.Low

            Case 2 ' Normal
                UpdatedEmailSettings.MailPriority = MailPriority.Normal

        End Select

        PersistChangesEmailSettings = True
    End Sub

    Private Sub cboEnableSSL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEnableSSL.SelectedIndexChanged
        Select Case cboEnableSSL.SelectedIndex
            Case 0 'True
                UpdatedEmailSettings.SmtpClient.EnableSsl = True

            Case 1 ' False
                UpdatedEmailSettings.SmtpClient.EnableSsl = False

        End Select

        PersistChangesEmailSettings = True
    End Sub

    Private Sub txtSMTPTimeout_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSMTPTimeout.KeyPress
        If Not (IsNumeric(e.KeyChar) Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSMTPTimeout_TextChanged(sender As Object, e As EventArgs) Handles txtSMTPTimeout.TextChanged
        If txtSMTPTimeout.Text.Length >= 1 And Not _formLoading Then
            UpdatedEmailSettings.SmtpClient.Timeout = CType(txtSMTPTimeout.Text, Integer) * 1000
        End If

        PersistChangesEmailSettings = True
    End Sub

    Private Sub txtDisplayName_Leave(sender As Object, e As EventArgs) Handles txtDisplayName.Leave
        PersistChangesEmailSettings = True
    End Sub

    Private Sub txtFromAddress_Leave(sender As Object, e As EventArgs) Handles txtFromAddress.Leave
        ' Check to make sure that the E-mail address provided is valid
        If txtFromAddress.Text.IsValidEmail Then
            txtFromAddress.ForeColor = Color.Black
        Else
            txtFromAddress.ForeColor = Color.Red
        End If

        PersistChangesEmailSettings = True

    End Sub

#End Region


#Region "JobsTasks"

    Private Sub dgvJobType_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJobType.CellClick
        ' Show the drop down list for the receipient type
        If e.ColumnIndex > 0 Then
            If dgvJobType.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
                dgvJobType.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub dgvJobType_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvJobType.CellValueChanged
        If e.RowIndex >= 0 And UpdatedJobTypes IsNot Nothing Then
            ' No matter what changes, set Me.PersistChangesJobTypes
            PersistChangesJobTypes = True

            ' Find the row in the list of job types, then update or add it
            If e.RowIndex > UpdatedJobTypes.Count - 1 Then ' A new row needs to be added
                UpdatedJobTypes.Add(CType(dgvJobType.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String))
            Else ' The row in the list needs to be updated
                UpdatedJobTypes(e.RowIndex) = CType(dgvJobType.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
            End If
        End If
    End Sub

    Private Sub dgvJobType_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvJobType.CurrentCellDirtyStateChanged
        'Update the value of the cell
        If dgvJobType.IsCurrentCellDirty Then
            dgvJobType.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvJobType_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvJobType.RowsRemoved
        ' Remove the deleted item from UpdatedJobTypes
        UpdatedJobTypes.RemoveAt(e.RowIndex)
        dgvJobType.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvJobType_Leave(sender As Object, e As EventArgs) Handles dgvJobType.Leave
        Dim nullRows = (From row In dgvJobType.Rows.Cast(Of DataGridViewRow)
                        Where row.Cells(0).Value Is Nothing And row.Index <> dgvJobType.Rows.Count - 1
                        Select row).ToList()
        For Each row As DataGridViewRow In nullRows
            dgvJobType.Rows.RemoveAt(row.Index)
        Next
    End Sub

    Private Sub dgvTasks_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTasks.CellClick
        ' Show the drop down list for the receipient type
        If e.ColumnIndex > 0 Then
            If dgvTasks.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
                dgvTasks.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub dgvTasks_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTasks.CellValueChanged
        If e.RowIndex >= 0 And UpdatedTasks IsNot Nothing Then
            ' No matter what changes, set Me.PersistChangesTasks
            PersistChangesTasks = True

            ' Find the row in the list of tasks, then update or add it
            If e.RowIndex > UpdatedTasks.Count - 1 Then ' A new row needs to be added
                UpdatedTasks.Add(CType(dgvTasks.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String))
            Else ' The row in the list needs to be updated
                UpdatedTasks(e.RowIndex) = CType(dgvTasks.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
            End If
        End If
    End Sub

    Private Sub dgvTasks_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvTasks.CurrentCellDirtyStateChanged
        If dgvTasks.IsCurrentCellDirty Then
            dgvTasks.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvTasks_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvTasks.RowsRemoved
        UpdatedTasks.RemoveAt(e.RowIndex)
    End Sub

    Private Sub dgvTasks_Leave(sender As Object, e As EventArgs) Handles dgvTasks.Leave
        Dim nullRows = (From row In dgvTasks.Rows.Cast(Of DataGridViewRow)
                        Where row.Cells(0).Value Is Nothing And row.Index <> dgvTasks.Rows.Count - 1
                        Select row).ToList()
        For Each row As DataGridViewRow In nullRows
            dgvTasks.Rows.RemoveAt(row.Index)
        Next
    End Sub

#End Region


#Region "VehcilesEquipment"

    Private Sub dgvVehicles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVehicles.CellClick
        ' Show the drop down list for the receipient type
        If e.ColumnIndex > 0 Then
            If dgvVehicles.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
                dgvVehicles.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub dgvVehicles_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVehicles.CellValueChanged
        If e.RowIndex >= 0 And UpdatedVehicles IsNot Nothing Then
            ' No matter what changes, set Me.PersistChangesVehicles
            PersistChangesVehicles = True

            ' Find the row in the list of job types, then update or add it
            If e.RowIndex > UpdatedVehicles.Count - 1 Then ' A new row needs to be added
                UpdatedVehicles.Add(CType(dgvVehicles.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String))
            Else ' The row in the list needs to be updated
                UpdatedVehicles(e.RowIndex) = CType(dgvVehicles.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
            End If
        End If
    End Sub

    Private Sub dgvVehicles_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvVehicles.CurrentCellDirtyStateChanged
        'Update the value of the cell
        If dgvVehicles.IsCurrentCellDirty Then
            dgvVehicles.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvVehicles_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvVehicles.RowsRemoved
        ' Remove the deleted item from UpdatedVehicles
        UpdatedVehicles.RemoveAt(e.RowIndex)
        dgvVehicles.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvVehicles_Leave(sender As Object, e As EventArgs) Handles dgvVehicles.Leave
        Dim nullRows = (From row In dgvVehicles.Rows.Cast(Of DataGridViewRow)
                        Where row.Cells(0).Value Is Nothing And row.Index <> dgvVehicles.Rows.Count - 1
                        Select row).ToList()
        For Each row As DataGridViewRow In nullRows
            dgvVehicles.Rows.RemoveAt(row.Index)
        Next
    End Sub

    Private Sub dgvEquipment_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEquipment.CellClick
        ' Show the drop down list for the receipient type
        If e.ColumnIndex > 0 Then
            If dgvEquipment.Columns(e.ColumnIndex).GetType = GetType(DataGridViewComboBoxColumn) And e.RowIndex >= 0 Then
                dgvEquipment.BeginEdit(True)
            End If
        End If
    End Sub

    Private Sub dgvEquipment_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEquipment.CellValueChanged
        If e.RowIndex >= 0 And UpdatedEquipment IsNot Nothing Then
            ' No matter what changes, set Me.PersistChangesEquipment
            PersistChangesEquipment = True

            ' Find the row in the list of Equipment, then update or add it
            If e.RowIndex > UpdatedEquipment.Count - 1 Then ' A new row needs to be added
                UpdatedEquipment.Add(CType(dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String))
            Else ' The row in the list needs to be updated
                UpdatedEquipment(e.RowIndex) = CType(dgvEquipment.Rows(e.RowIndex).Cells(e.ColumnIndex).Value, String)
            End If
        End If
    End Sub

    Private Sub dgvEquipment_CurrentCellDirtyStateChanged(sender As Object, e As EventArgs) Handles dgvEquipment.CurrentCellDirtyStateChanged
        'Update the value of the cell
        If dgvEquipment.IsCurrentCellDirty Then
            dgvEquipment.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub dgvEquipment_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dgvEquipment.RowsRemoved
        ' Remove the deleted item from Equipment
        UpdatedEquipment.RemoveAt(e.RowIndex)
        dgvEquipment.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    Private Sub dgvEquipment_Leave(sender As Object, e As EventArgs) Handles dgvEquipment.Leave
        Dim nullRows = (From row In dgvEquipment.Rows.Cast(Of DataGridViewRow)
                        Where row.Cells(0).Value Is Nothing And row.Index <> dgvEquipment.Rows.Count - 1
                        Select row).ToList()
        For Each row As DataGridViewRow In nullRows
            dgvEquipment.Rows.RemoveAt(row.Index)
        Next
    End Sub

#End Region


#Region "DataGridView Deletions"

    Private Sub dgvJobType_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) _
        Handles dgvAdditionalReceipients.CellMouseUp, dgvJobType.CellMouseUp, dgvTasks.CellMouseUp, dgvVehicles.CellMouseUp, dgvEquipment.CellMouseUp

        If Not (e.Button = MouseButtons.Right And e.RowIndex >= 0 And e.ColumnIndex >= 0) Then
            Return
        End If

        ' Set the variables for the delete button
        _rowIndex = e.RowIndex
        _dummyDataGridView = CType(sender, DataGridView)

        ' Prepare the data for deletion
        _dummyDataGridView.Rows(e.RowIndex).Selected = True
        _dummyDataGridView.CurrentCell = _dummyDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
        cmsDeleteRow.Show(_dummyDataGridView, e.Location)
        cmsDeleteRow.Show(Cursor.Position)
    End Sub

#End Region


#Region "Context Menu Strip Buttons"

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        ' Return if the sender is not a DataGridView, or if the _rowIndex is less than 0
        If _dummyDataGridView Is Nothing Or _rowIndex < 0 Or _dummyDataGridView.Rows(_rowIndex).IsNewRow Then
            Return
        End If

        ' Delete the row from the data grid view
        _dummyDataGridView.Rows.RemoveAt(_rowIndex)

        Select Case _dummyDataGridView.Name
            Case dgvJobType.Name
                PersistChangesJobTypes = True

            Case dgvTasks.Name
                PersistChangesTasks = True

            Case dgvVehicles.Name
                PersistChangesVehicles = True

            Case dgvEquipment.Name
                PersistChangesEquipment = True
        End Select

        ' Reset the row index
        _rowIndex = -2
        _dummyDataGridView = Nothing
    End Sub

#End Region

#End Region


#Region "Private Delegate Methods"

    Private Delegate Function IsValidSmtpServerAsync(ByVal hostName As String) As Boolean

    Private Delegate Function RetrieveMemberDetailsAsync() As List(Of Member)

#End Region


#Region "Callback Methods"

    Private Sub UpdateHostFormat(ByVal ar As IAsyncResult)
        ' Retrieve the result
        Dim result = CType(ar, AsyncResult)
        Dim caller = CType(result.AsyncDelegate, IsValidSmtpServerAsync)

        Dim isValid As Boolean = caller.EndInvoke(ar)

        If isValid Then
            txtHost.ForeColor = Color.Black
        Else
            txtHost.ForeColor = Color.Red
        End If
    End Sub

    Private Async Function UpdateMemberDetailsAsync() As Task
        Dim memberDetails = Await DataDbConnection.RetrieveMemberDetailsAsync().ConfigureAwait(False)

        ' Determine which members need to be selected
        Dim selectedMembers As New Dictionary(Of String, EmailSettings.TypeOfReceipient)
        For Each m As Member In UpdatedEmailSettings.MembersToReceive.Keys
            Dim value = EmailSettings.TypeOfReceipient.Bcc
            UpdatedEmailSettings.MembersToReceive.TryGetValue(m, value)
            selectedMembers.Add(m.Id, value)
        Next

        ' Populate Members to receive
        For Each member As Member In memberDetails.OrderBy(Function(m) m.ToString())
            ' Add all members that have not resigned
            If member.Status <> 5 Then
                ' Add the members to the Email tab
                If selectedMembers.ContainsKey(member.Id) Then
                    Dim value As EmailSettings.TypeOfReceipient
                    If selectedMembers.TryGetValue(member.Id, value) Then
                        dgvMembersToReceive.Rows.Add({Nothing, member, If(value = EmailSettings.TypeOfReceipient.Too, "To", value.ToString())})
                    Else
                        dgvMembersToReceive.Rows.Add({Nothing, member, "Bcc"})
                    End If
                    dgvMembersToReceive.Rows(dgvMembersToReceive.Rows.Count - 1).Cells(0).Value = True
                Else
                    dgvMembersToReceive.Rows.Add({Nothing, member, "Bcc"})
                    dgvMembersToReceive.Rows(dgvMembersToReceive.Rows.Count - 1).Cells(0).Value = False
                End If

            End If
        Next
        chkSelectAllToReceive.Checked = CheckSelectAll()
    End Function

    'Private Sub UpdateMemberDetails(ByVal ar As IAsyncResult)
    '    ' Retrieve the result
    '    Dim result = CType(ar, AsyncResult)
    '    Dim caller = CType(result.AsyncDelegate, RetrieveMemberDetailsAsync)

    '    ' Retrieve the list that was passed as state information
    '    '_memberDetails = CType(ar.AsyncState, List(Of Member))

    '    ' Call EndInvoke to retrieve the results.
    '    Dim memberDetails As List(Of Member) = caller.EndInvoke(ar)

    '    ' Determine which members need to be selected
    '    Dim selectedMembers As New Dictionary(Of String, EmailSettings.TypeOfReceipient)
    '    For Each m As Member In UpdatedEmailSettings.MembersToReceive.Keys
    '        Dim value = EmailSettings.TypeOfReceipient.Bcc
    '        UpdatedEmailSettings.MembersToReceive.TryGetValue(m, value)
    '        selectedMembers.Add(m.Id, value)
    '    Next

    '    ' Populate Members to receive
    '    For Each member As Member In memberDetails.OrderBy(Function(m) m.ToString())
    '        ' Add all members that have not resigned
    '        If member.Status <> 5 Then
    '            ' Add the members to the Email tab
    '            If selectedMembers.ContainsKey(member.Id) Then
    '                Dim value As EmailSettings.TypeOfReceipient
    '                If selectedMembers.TryGetValue(member.Id, value) Then
    '                    dgvMembersToReceive.Rows.Add({Nothing, member, If(value = EmailSettings.TypeOfReceipient.Too, "To", value.ToString())})
    '                Else
    '                    dgvMembersToReceive.Rows.Add({Nothing, member, "Bcc"})
    '                End If
    '                dgvMembersToReceive.Rows(dgvMembersToReceive.Rows.Count - 1).Cells(0).Value = True
    '            Else
    '                dgvMembersToReceive.Rows.Add({Nothing, member, "Bcc"})
    '                dgvMembersToReceive.Rows(dgvMembersToReceive.Rows.Count - 1).Cells(0).Value = False
    '            End If

    '        End If
    '    Next
    '    chkSelectAllToReceive.Checked = CheckSelectAll()
    'End Sub

#End Region

#Region "Private Methods"

    Private Function CheckSelectAll() As Boolean
        Return dgvMembersToReceive.Rows.Cast(Of DataGridViewRow)().All(Function(row) CType(row.Cells(0).Value, Boolean) <> False)
    End Function

    Private Sub LoadEmailSettings()
        ' All members to received
        chkAllMembersReceive.Checked = UpdatedEmailSettings.AllMemberReceive
        Try
            cboRecepientType.SelectedIndex = cboRecepientType.FindString(UpdatedEmailSettings.AllMemberReceipientType.ToString())
        Catch ex As Exception
            cboRecepientType.SelectedIndex = cboRecepientType.FindString("Bcc")
        End Try

        ' Additional receipients
        Dim cbCol As DataGridViewComboBoxColumn = CType(dgvAdditionalReceipients.Columns(2), DataGridViewComboBoxColumn)
        Dim cbCell As DataGridViewComboBoxCell
        For Each key As Integer In UpdatedEmailSettings.AdditionalReceipients.Keys
            Dim value As Tuple(Of MailAddress, EmailSettings.TypeOfReceipient) = Nothing
            If UpdatedEmailSettings.AdditionalReceipients.TryGetValue(key, value) Then
                ' Add the new row
                dgvAdditionalReceipients.Rows.Add(value.Item1.DisplayName, value.Item1.Address, Nothing)

                ' Update the receipient type
                cbCell = CType(dgvAdditionalReceipients.Rows(dgvAdditionalReceipients.Rows.Count - 2).Cells(2), DataGridViewComboBoxCell)
                cbCell.Value = cbCol.Items(cbCol.Items.IndexOf(If(value.Item2 = EmailSettings.TypeOfReceipient.Too, "To", value.Item2.ToString())))
            End If
        Next

        ' Mail Server
        txtHost.Text = UpdatedEmailSettings.SmtpClient.Host
        txtPort.Text = UpdatedEmailSettings.SmtpClient.Port.ToString()

        ' Network Credentials
        chkShowPassword.Checked = UpdatedEmailSettings.ShowPassword
        txtUserName.Text = CType(UpdatedEmailSettings.SmtpClient.Credentials, NetworkCredential).UserName
        txtPassword.Text = CType(UpdatedEmailSettings.SmtpClient.Credentials, NetworkCredential).Password

        ' Client Settings
        Try
            cboPriority.SelectedIndex = cboPriority.FindString(UpdatedEmailSettings.MailPriority.ToString())
        Catch ex As Exception
            cboPriority.SelectedIndex = cboPriority.FindString("Normal")
        End Try
        cboEnableSSL.SelectedIndex = cboEnableSSL.FindString(UpdatedEmailSettings.SmtpClient.EnableSsl.ToString())
        txtSMTPTimeout.Text = CInt(UpdatedEmailSettings.SmtpClient.Timeout / 1000).ToString()

        ' From Address
        If UpdatedEmailSettings.FromAddress IsNot Nothing Then
            txtDisplayName.Text = UpdatedEmailSettings.FromAddress.DisplayName
            txtFromAddress.Text = UpdatedEmailSettings.FromAddress.Address
        End If
    End Sub

    Private Sub LoadJobsTasks()
        clmJobType.Width = dgvJobType.ClientSize.Width
        clmTask.Width = dgvJobType.ClientSize.Width

        ' Display the job types
        For Each jobType In Me.UpdatedJobTypes.OrderBy(Function(x) x)
            dgvJobType.Rows.Add(jobType)
        Next

        ' Display the tasks
        For Each task In Me.UpdatedTasks.OrderBy(Function(x) x)
            dgvTasks.Rows.Add(task)
        Next
    End Sub

    Private Sub LoadVehiclesEquipment()
        clmVehicleName.Width = dgvVehicles.ClientSize.Width
        clmEquipmentItem.Width = dgvEquipment.ClientSize.Width

        For Each vehicle In Me.UpdatedVehicles.OrderBy(Function(x) x)
            dgvVehicles.Rows.Add(vehicle)
        Next

        For Each item In Me.UpdatedEquipment.OrderBy(Function(x) x)
            dgvEquipment.Rows.Add(item)
        Next
    End Sub

    Private Sub LoadMemberSettings()
        cboStatusFilter.SelectedIndex = cboStatusFilter.FindString("Current Members")
    End Sub

    Private Function ValidateEmailSettingsData() As Boolean
        ' Make sure that each Additional receipient has a valid Email address and display name
        UpdatedEmailSettings.AdditionalReceipients.Clear()
        For Each row As DataGridViewRow In dgvAdditionalReceipients.Rows
            'If CType(row.Cells(0).Value) <> "" And CType(row.Cells(1).Value) Then
            If row.Index <> dgvAdditionalReceipients.Rows.Count - 1 Then
                ' Extract the data entered by the user
                Dim emailAddress = CType(row.Cells(1).Value, String)
                Dim displayName = CType(row.Cells(0).Value, String)
                Dim rType As EmailSettings.TypeOfReceipient
                Select Case CType(row.Cells(2).Value, String)
                    Case "Bcc"
                        rType = EmailSettings.TypeOfReceipient.Bcc

                    Case "CC"
                        rType = EmailSettings.TypeOfReceipient.Cc

                    Case "To"
                        rType = EmailSettings.TypeOfReceipient.Too
                End Select

                ' Make sure that the E-mail address is valid
                If Not emailAddress.IsValidEmail Then
                    MsgBox("'" & emailAddress & "' is a valid Email Address.", MsgBoxStyle.Critical, "Invalid Email Address")
                    dgvAdditionalReceipients.Focus()
                    dgvAdditionalReceipients.CurrentCell = dgvAdditionalReceipients.Rows(row.Index).Cells(1)

                    Return False
                End If

                ' Add the receipient to the list of additioanl receipients
                UpdatedEmailSettings.AdditionalReceipients.Add(row.Index,
                        New Tuple(Of MailAddress, EmailSettings.TypeOfReceipient)(New MailAddress(emailAddress, displayName), rType))
            End If
        Next

        ' Make sure that the SMTP Host Name and port work
        If Not (txtHost.Text = UpdatedEmailSettings.SmtpClient.Host And CType(txtPort.Text, Integer) = UpdatedEmailSettings.SmtpClient.Port) Then
            If SmtpHelper.IsValidSmtpServer(txtHost.Text, CType(txtPort.Text, Integer)) Then
                UpdatedEmailSettings.SmtpClient.Host = txtHost.Text
                UpdatedEmailSettings.SmtpClient.Port = CType(txtPort.Text, Integer)
            Else
                Select Case MessageBox.Show(Invalid_SMTP_Host_Provided, Invalid_SMTP_Message_Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                    Case DialogResult.Yes
                        txtHost.Text = UpdatedEmailSettings.SmtpClient.Host
                        txtPort.Text = UpdatedEmailSettings.SmtpClient.Port.ToString()
                        txtHost.ForeColor = Color.Black

                    Case DialogResult.No
                        Return False

                End Select
            End If
        End If

        ' If the from address is valid then update the from address
        If txtFromAddress.Text <> "" Then
            If txtFromAddress.Text.IsValidEmail Then
                UpdatedEmailSettings.FromAddress = New MailAddress(txtFromAddress.Text, txtDisplayName.Text)
            Else
                MsgBox("The 'From' address provided is not a valid Email address.", MsgBoxStyle.Critical, "Invalid From Address")
                txtFromAddress.Focus()
                txtFromAddress.SelectAll()

                Return False
            End If
        End If

        'No errors
        Return True
    End Function

#End Region
End Class