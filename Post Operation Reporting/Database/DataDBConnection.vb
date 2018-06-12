Option Strict On

Imports System.Collections.Specialized
Imports System.Data.SQLite
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms.VisualStyles
Imports PostOpRep.Common
Imports PostOpRep.Settings

Namespace Database

    Public Class DataDbConnection

#Region "Private Shared Fields"

        Private Shared _memberDetailsEmailAddress As String = "EmailAddress"
        Private Shared _memberDetailsID As String = "ID"
        Private Shared _memberDetailsFirstName As String = "FirstName"
        Private Shared _memberDetailsPosition As String = "Position"
        Private Shared _memberDetailsStatus As String = "Status"
        Private Shared _memberDetailsSurname As String = "Surname"
        Private Shared _memberDetailsOriginalId As String = "OriginalId"


        Private Shared _debriefDataCrewAdequatelyTrained As String = "CrewAdequatelyTrained"
        Private Shared _debriefDataCrewLeader As String = "CrewLeader"
        Private Shared _debriefDataFinishTime As String = "FinishTime"
        Private Shared _debriefDataEquipmentToMakeEasier As String = "EquipmentToMakeEasier"
        Private Shared _debriefDataEventNumber As String = "EventNumber"
        Private Shared _debriefDataFirstAider As String = "FirstAider"
        Private Shared _debriefDataIssuesForJob As String = "IssuesForJob"
        Private Shared _debriefDataJobDescription As String = "JobDescription"
        Private Shared _debriefDataJobType As String = "JobType"
        Private Shared _debriefDataMyCouncil As String = "MyCouncil"
        Private Shared _debriefDataPlan As String = "Plan"
        Private Shared _debriefDataPlanB As String = "PlanB"
        Private Shared _debriefDataPlanClearToAll As String = "PlanClearToAll"
        Private Shared _debriefDataSafety As String = "Safety"
        Private Shared _debriefDataSafetyConcerns As String = "SafetyConcerns"
        Private Shared _debriefDataSESCommander As String = "SESCommander"
        Private Shared _debriefDataSkills As String = "Skills"
        Private Shared _debriefDataStartTime As String = "StartTime"

        Private Shared _membersAttendingEventNumber As String = "EventNumber"
        Private Shared _membersAttendingMemberID As String = "MemberID"
        Private Shared _membersAttendingTaskUndertaken As String = "TaskUndertaken"

        Private Shared _equipmentUsedEventNumber As String = "EventNumber"
        Private Shared _equipmentUsedItem As String = "Item"
        Private Shared _equipmentUsedDuration As String = "Duration"
        Private Shared _equipmentUsedMemberID As String = "MemberID"

        Private Shared _vehicleUsedEventNumber As String = "EventNumber"
        Private Shared _vehicleUsedVehicle As String = "Vehicle"

        Private Shared _privledgesMember As String = "Member"
        Private Shared _privledgesCreateDebriefs As String = "CreateDebriefs"
        Private Shared _privledgesAssignPrivledges As String = "AssignPrivledges"
        Private Shared _privledgesResetOwnPassword As String = "ResetOwnPassword"
        Private Shared _privledgesResetOthersPassword As String = "ResetOthersPassword"
        Private Shared _privledgesCreateNewMember As String = "CreateNewMember"
        Private Shared _privledgesUpdateSelf As String = "UpdateSelf"
        Private Shared _privledgesUpdateAnotherMember As String = "UpdateAnotherMember"
        Private Shared _privledgesDeleteMember As String = "DeleteMember"
        Private Shared _privledgesUpdateEmailReceipients As String = "UpdateEmailReceipients"
        Private Shared _privledgesUpdateMailServer As String = "UpdateMailServer"
        Private Shared _privledgesUpdateNetworkCredentials As String = "UpdateNetworkCredentials"
        Private Shared _privledgesUpdateClientSettings As String = "UpdateClientSettings"
        Private Shared _privledgesUpdateFromAddress As String = "UpdateFromAddress"
        Private Shared _privledgesUpdateJobTypes As String = "UpdateJobTypes"
        Private Shared _privledgesUpdateTasks As String = "UpdateTasks"
        Private Shared _privledgesUpdateVehicles As String = "UpdateVehicles"
        Private Shared _privledgesUpdateEquipment As String = "UpdateEquipment"
        Private Shared _privledgesOriginalId As String = "OriginalId"

        Private Shared _passwordMember As String = "Member"
        Private Shared _passwordPassword As String = "Password"
        Private Shared _passwordOriginalId As String = "OriginalMemberId"

        Private Shared _emailSettingsAllMembersReceipientType As String = "AllMembersReceipientType"
        Private Shared _emailSettingsAllMembersReceive As String = "AllMembersReceive"
        Private Shared _emailSettingsFromAddress As String = "FromAddress"
        Private Shared _emailSettingsFromDisplayName As String = "FromDisplayName"
        Private Shared _emailSettingsMailPriority As String = "MailPriority"
        Private Shared _emailSettingsShowPassword As String = "ShowPassword"
        Private Shared _emailSettingsSmptClientHost As String = "SmptClientHost"
        Private Shared _emailSettingsSmtpClientPassword As String = "SmtpClientPassword"
        Private Shared _emailSettingsSmtpClientPort As String = "SmtpClientPort"
        Private Shared _emailSettingsSmtpClientUserName As String = "SmtpClientUserName"
        Private Shared _emailSettingsSmtpEnableSSL As String = "SmtpEnableSSL"
        Private Shared _emailSettingsSmtpTimeout As String = "SmtpTimeout"
        Private Shared _emailSettingsTimestamp As String = "Timestamp"

        Private Shared _membersToReceiveMemberID As String = "MemberID"
        Private Shared _membersToReceiveReceipientType As String = "ReceipientType"
        Private Shared _membersToReceiveTimestamp As String = "Timestamp"

        Private Shared _additionalEmailReceipientsDisplayName As String = "DisplayName"
        Private Shared _additionalEmailReceipientsEmailAddress As String = "EmailAddress"
        Private Shared _additionalEmailReceipientsReceipientType As String = "ReceipientType"
        Private Shared _additionalEmailReceipientsTimestamp As String = "Timestamp"

        Private Shared _jobTypeJobType As String = "JobType"
        Private Shared _jobTypeTimestamp As String = "Timestamp"

        Private Shared _taskTask As String = "Task"
        Private Shared _taskTimestamp As String = "Timestamp"

        Private Shared _vehicleVehcile As String = "Vehcile"
        Private Shared _vehicleTimestamp As String = "Timestamp"

        Private Shared _equipmentItem As String = "Item"
        Private Shared _equipmentTimestamp As String = "Timestamp"

#End Region


#Region "Shared Fields"

        Shared ReadOnly FilePath As String
        Shared ReadOnly TempFilePath As String

        Shared ReadOnly ConnectionString As String
        Shared ReadOnly DbName As String = "DebriefData.db3"
        Shared ReadOnly DebriefDataTableName As String = "Debrief"
        Shared ReadOnly EquipmentTableName As String = "Equipment"
        Shared ReadOnly EquipmentUsedTableName As String = "EquipmentUsed"
        Shared ReadOnly JobTypeTableName As String = "JobTypes"
        Shared ReadOnly MemberDetailsTableName As String = "MemberDetails"
        Shared ReadOnly MembersAttendingTableName As String = "MembersAttending"
        Shared ReadOnly PasswordTableName As String = "Password"
        Shared ReadOnly PrivledgesTableName As String = "Privledges"
        Shared ReadOnly TasksTableName As String = "UpdatedTasks"
        Shared ReadOnly VehiclesTableName As String = "Vehicles"
        Shared ReadOnly VehiclesUsedTableName As String = "VehiclesUsed"

        Shared ReadOnly AdditionalEmailReceipientsTableName As String = "AdditionalEmailReceipients"
        Shared ReadOnly EmailSettingsTableName As String = "EmailSettings"
        Shared ReadOnly MembersToReceiveTableName As String = "MembersToReceive"

#End Region


#Region "Shared Constructors"

        Shared Sub New()
            FilePath = If(Debugger.IsAttached(), Path.GetFullPath(Application.StartupPath & "\..\..\"), Application.StartupPath & "\")
            FilePath = Path.Combine(FilePath, "Database", DbName)
            TempFilePath = FilePath & ".tmp"

            ConnectionString = "data source=" & FilePath & ";version=3;"
        End Sub

#End Region


#Region "Shared Methods"

        Shared Function CreateDatabaseBackup() As Boolean
            Try
                My.Computer.FileSystem.CopyFile(FilePath, TempFilePath)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Shared Function RestoreDatabaseBackup() As Boolean
            Try
                My.Computer.FileSystem.DeleteFile(FilePath)
                My.Computer.FileSystem.CopyFile(TempFilePath, FilePath)
                My.Computer.FileSystem.DeleteFile(TempFilePath)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Shared Function DeleteDatabaseBackup() As Boolean
            Try
                My.Computer.FileSystem.DeleteFile(TempFilePath)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function

        Shared Async Function AddDebriefDataAsync(debrief As Debrief) As Task(Of Boolean)
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    InsertDebriefData(debrief, command)
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    For Each member As KeyValuePair(Of Member, String) In debrief.MembersAttending
                        InsertMembersAttending(debrief.EventNumber, member, command)
                        Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
                    Next

                    For Each vehicle As String In debrief.VehiclesUsed
                        InsertVehiclesUsedString(debrief.EventNumber, vehicle, command)
                        Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
                    Next

                    For Each itemUsed As EquipmentUse In debrief.EquipmentUsed
                        InsertEquipmentUsedString(debrief.EventNumber, itemUsed, command)
                        Await command.ExecuteNonQueryAsync().ConfigureAwait(False)
                    Next

                    connection.Close()
                End Using
            End Using

            Return True
        End Function

        Shared Sub Initialize(worker As System.ComponentModel.BackgroundWorker, e As System.ComponentModel.DoWorkEventArgs)
            If Not My.Computer.FileSystem.FileExists(FilePath) Then
                ' Create a new InitialisationState instance to use to report back to the caller
                Dim initialisationState As New InitialisationState

                Dim tables As New List(Of String)

                tables.Add(CreateMemberDetailsTableQuery())
                tables.Add(CreatePrivledgesTableQuery())
                tables.Add(CreatePasswordTableQuery())
                tables.Add(CreateDebriefDataTableQuery())
                tables.Add(CreateMembersAttendingTableQuery())
                tables.Add(CreateVehiclesUsedTableQuery())
                tables.Add(CreateEquipmentUsedTableQuery())
                tables.Add(CreateEmailSettingsTableQuery())
                tables.Add(CreateMembersToReceiveTableQuery())
                tables.Add(CreateAdditionalEmailReceipientsTableQuery())
                tables.Add(CreateJobTypeTableQuery())
                tables.Add(CreateTasksTableQuery())
                tables.Add(CreateVehiclesTableQuery())
                tables.Add(CreateEquipmentTableQuery())

                ' Retrieve the raw data to insert into the database
                InitialisationState.CurrentTask = "Retrieving Members Details"
                worker.ReportProgress(0, initialisationState)
                Dim members As List(Of Member) = RetrieveMemberDetailsFromText()

                ' make sure that there is at least one updateMember in the returned list before proceeding - 
                ' can 't import the debreif data if members can not be refereneced
                If members.Count > 0 Then
                    InitialisationState.CurrentTask = "Retrieving Debrief Data"
                    worker.ReportProgress(0, initialisationState)
                    Dim debriefs As List(Of DebriefSingleIncident) = RetieveAllDebriefDataFromText(members)

                    ' Retrieve the job types and UpdatedTasks
                    InitialisationState.CurrentTask = "Retrieving Job Types"
                    worker.ReportProgress(0, initialisationState)
                    Dim jobTypes As List(Of String) = RetieveJobTypesFromText()

                    ' Retrieve the job types and UpdatedTasks
                    InitialisationState.CurrentTask = "Retrieving UpdatedTasks"
                    worker.ReportProgress(0, initialisationState)
                    Dim tasks As List(Of String) = RetrieveTasksFromText()

                    ' Update the totals in the initialisationState
                    InitialisationState.TotalComplete = 0
                    InitialisationState.Total = members.Count + debriefs.Count + jobTypes.Count + tasks.Count

                    ' Create the database and open a connection
                    SQLiteConnection.CreateFile(FilePath)
                    Using connection = New SQLiteConnection(ConnectionString)
                        Using command = New SQLiteCommand(connection)
                            ' Open the connection to the database
                            connection.Open()

                            command.CommandText = EnableForeignKeysQuery()
                            command.ExecuteNonQuery()

                            ' Create the tables and execute
                            InitialisationState.CurrentTask = "Creating Tables"
                            worker.ReportProgress(0, initialisationState)
                            For Each table In tables
                                command.CommandText = table
                                command.ExecuteNonQuery()
                            Next

                            ' Insert the raw updateMember data into the newly created table
                            InitialisationState.CurrentTask = "Adding Member Details To Database"
                            InitialisationState.CurrentComponentComplete = 0
                            InitialisationState.CurrentComponentTotal = members.Count
                            worker.ReportProgress(0, initialisationState)
                            For Each member As Member In members
                                If member IsNot Nothing Then
                                    InsertMember(member, command)
                                    CreateInitialPermissions(member, command)
                                    CreateInitialPassword(member, command)
                                End If

                                InitialisationState.CurrentComponentComplete += 1
                                InitialisationState.TotalComplete += 1
                                worker.ReportProgress(0, initialisationState)
                            Next

                            ' Insert the raw debrief data into the newly created tables
                            InitialisationState.CurrentTask = "Adding Debrief Data To Database"
                            InitialisationState.CurrentComponentComplete = 0
                            InitialisationState.CurrentComponentTotal = debriefs.Count
                            worker.ReportProgress(0, initialisationState)
                            For Each debrief As DebriefSingleIncident In debriefs
                                ' Insert the debreif data into the database
                                InsertDebriefData(debrief, command)

                                Try
                                    command.ExecuteNonQuery()
                                Catch ex As SQLiteException
                                    ' do nothing
                                    If Debugger.IsAttached() Then
                                        Debug.WriteLine(ex.Message)
                                    End If
                                End Try

                                ' Insert into  MemberAttending
                                For Each attendingMember As KeyValuePair(Of Member, String) In debrief.MembersAttending
                                    InsertMembersAttending(debrief.EventNumber, attendingMember, command)

                                    Try
                                        command.ExecuteNonQuery()
                                    Catch ex As SQLiteException
                                        ' do nothing
                                        If Debugger.IsAttached() Then
                                            Debug.WriteLine(ex.Message)
                                        End If
                                    End Try
                                Next

                                ' Insert into vehciles used
                                For Each vehicle As String In debrief.VehiclesUsed
                                    InsertVehiclesUsedString(debrief.EventNumber, vehicle, command)

                                    Try
                                        command.ExecuteNonQuery()
                                    Catch ex As SQLiteException
                                        ' do nothing
                                        If Debugger.IsAttached() Then
                                            Debug.WriteLine(ex.Message)
                                        End If
                                    End Try
                                Next

                                InitialisationState.CurrentComponentComplete += 1
                                InitialisationState.TotalComplete += 1
                                worker.ReportProgress(0, initialisationState)
                            Next

                            'Insert the Job Types into the Database
                            InitialisationState.CurrentTask = "Adding Job Types To Database"
                            InitialisationState.CurrentComponentComplete = 0
                            InitialisationState.CurrentComponentTotal = jobTypes.Count
                            worker.ReportProgress(0, initialisationState)

                            Dim stamp = DateTime.Now()
                            command.CommandText = "INSERT INTO " & JobTypeTableName & " (" & _jobTypeJobType & ", " & _jobTypeTimestamp & ") VALUES (@JobType, @Timestamp);"
                            command.CommandType = CommandType.Text
                            For Each jobType In jobTypes
                                With command
                                    .Parameters.Clear()
                                    .Parameters.Add(New SQLiteParameter("@JobType", jobType))
                                    .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                                    .ExecuteNonQuery()
                                End With

                                InitialisationState.CurrentComponentComplete += 1
                                InitialisationState.TotalComplete += 1
                            Next

                            'Insert the UpdatedTasks into the Database
                            InitialisationState.CurrentTask = "Adding UpdatedTasks To Database"
                            InitialisationState.CurrentComponentComplete = 0
                            InitialisationState.CurrentComponentTotal = tasks.Count
                            worker.ReportProgress(0, initialisationState)
                            command.CommandText = "INSERT INTO " & TasksTableName & " (" & _taskTask & ", " & _taskTimestamp & ") VALUES (@Task, @Timestamp);"
                            command.CommandType = CommandType.Text
                            For Each task In tasks
                                With command
                                    .Parameters.Clear()
                                    .Parameters.Add(New SQLiteParameter("@Task", task))
                                    .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                                    .ExecuteNonQuery()
                                End With

                                InitialisationState.CurrentComponentComplete += 1
                                InitialisationState.TotalComplete += 1
                            Next

                            ' Close the connection to the database
                            connection.Close()
                        End Using
                    End Using
                End If
            End If
        End Sub

        Private Shared Function CreateNewTable(query As String) As Boolean
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    Try
                        command.CommandText = query
                        command.ExecuteNonQuery()
                    Catch ex As SQLiteException
                        Return False
                    End Try

                    connection.Close()
                End Using
            End Using

            Return True
        End Function

        Friend Shared Function RetrieveEmailSettings() As EmailSettings
            Dim settings As New EmailSettings()

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    'Open the connection to the database
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    ' --- Email Settings ---
                    command.CommandText = "Select * FROM " & EmailSettingsTableName

                    'Retrieve the email settings from the database
                    Dim readerValues = New NameValueCollection
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            readerValues = reader.GetValues()
                        End While
                    End Using

                    If readerValues.Count > 0 Then
                        SetEmailSettings(settings, readerValues)
                    End If

                    ' --- Members to Receive ---

                    command.CommandText = "Select * FROM " & MembersToReceiveTableName
                    Dim members As New Dictionary(Of Member, EmailSettings.TypeOfReceipient)
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            ' Find the updateMember in the list of members
                            Dim selectedMember As List(Of Member) = (From member In PostOpRep.Settings.Settings.MemberDetails
                                                                     Where member.Id = reader.GetValue(0).ToString()
                                                                     Select member).ToList()

                            If selectedMember.Count > 0 Then
                                members.Add(selectedMember.First(), DirectCast([Enum].Parse(GetType(EmailSettings.TypeOfReceipient), reader.GetValue(1).ToString()),
                                                                               EmailSettings.TypeOfReceipient))
                            End If
                        End While
                    End Using
                    settings.MembersToReceive = members

                    ' --- Additional Receipients

                    command.CommandText = "Select * FROM " & AdditionalEmailReceipientsTableName
                    Dim additionalReceipients As New Dictionary(Of Integer, Tuple(Of MailAddress, EmailSettings.TypeOfReceipient))
                    Dim i = 0
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim emailAddress As String = reader.GetValue(1).ToString()
                            Dim displayName As String = reader.GetValue(0).ToString()
                            Dim rType = DirectCast([Enum].Parse(GetType(EmailSettings.TypeOfReceipient), reader.GetValue(2).ToString()),
                                                                                     EmailSettings.TypeOfReceipient)
                            additionalReceipients.Add(i, New Tuple(Of MailAddress, EmailSettings.TypeOfReceipient)(New MailAddress(emailAddress, displayName), rType))
                            i += 1
                        End While
                    End Using
                    settings.AdditionalReceipients = additionalReceipients

                    'Close the connection to the database
                    connection.Close()
                End Using
            End Using

            Return settings
        End Function

        Private Shared Sub SetEmailSettings(settings As EmailSettings, readerValues As NameValueCollection)
            With settings
                .AllMemberReceipientType = DirectCast([Enum].Parse(GetType(EmailSettings.TypeOfReceipient),
                                                      readerValues.Item(_emailSettingsAllMembersReceipientType).ToString()),
                                                      EmailSettings.TypeOfReceipient)

                .AllMemberReceive = readerValues.Item(_emailSettingsAllMembersReceive).ToString() <> "0"

                If readerValues.Item(_emailSettingsFromAddress) <> Nothing Then
                    .FromAddress = New MailAddress(readerValues.Item(_emailSettingsFromAddress),
                                                   readerValues.Item(_emailSettingsFromDisplayName))
                End If

                .MailPriority = DirectCast([Enum].Parse(GetType(MailPriority),
                                                        readerValues.Item(_emailSettingsMailPriority).ToString()),
                                                        MailPriority)

                .ShowPassword = readerValues.Item(_emailSettingsShowPassword).ToString() <> "0"

                .SmtpClient = New SmtpClient()
                If readerValues.Item(_emailSettingsSmptClientHost) <> Nothing Then
                    .SmtpClient.Host = readerValues.Item(_emailSettingsSmptClientHost).ToString()
                End If
                .SmtpClient.Port = Integer.Parse(readerValues.Item(_emailSettingsSmtpClientPort).ToString())
                .SmtpClient.Credentials = New NetworkCredential(readerValues.Item(_emailSettingsSmtpClientUserName).ToString(),
                                                                readerValues.Item(_emailSettingsSmtpClientPassword).ToString())
                .SmtpClient.EnableSsl = readerValues.Item(_emailSettingsSmtpEnableSSL).ToString() <> "0"
                .SmtpClient.Timeout = Integer.Parse(readerValues.Item(_emailSettingsSmtpTimeout).ToString())
            End With
        End Sub

        Shared Async Function RetrieveMemberDetailsAsync(memberId As String) As Task(Of Member)
            Dim query As String = "Select * FROM " & MemberDetailsTableName & " WHERE " & _memberDetailsID & " = '" & memberId & "'"

            Dim readerValues = Await RetrieveValuesFromDatabaseAsync(query).ConfigureAwait(False)

            Return GetMembers(readerValues).FirstOrDefault()
        End Function

        Shared Async Function RetrieveMemberDetailsAsync() As Task(Of List(Of Member))
            Dim query As String = "Select * FROM " & MemberDetailsTableName & " WHERE " & _memberDetailsID &
                                  " NOT LIKE '" & My.Resources.PermissionControllerID.Substring(0, 7) & "%'"

            Dim readerValues = Await RetrieveValuesFromDatabaseAsync(query).ConfigureAwait(False)

            Return GetMembers(readerValues)
        End Function

        Private Shared Async Function RetrieveValuesFromDatabaseAsync(query As String) As Task(Of List(Of NameValueCollection))
            Dim valueCollection = New List(Of NameValueCollection)

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = query
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim readerValue = reader.GetValues()
                            valueCollection.Add(readerValue)
                        End While
                    End Using

                    connection.Close()
                End Using
            End Using

            Return valueCollection
        End Function

        Private Shared Function GetMembers(readerValues As List(Of NameValueCollection)) As List(Of Member)

            Dim members As New List(Of Member)
            For Each readValue In readerValues
                Dim member As Member

                Try
                    member = New Member(readValue.Item(_memberDetailsID).ToString())
                Catch ex As Exception
                    Continue For
                End Try

                member.EmailAddress = readValue.Item(_memberDetailsEmailAddress).ToString()
                member.FirstName = readValue.Item(_memberDetailsFirstName).ToString()
                member.Surname = readValue.Item(_memberDetailsSurname).ToString()

                Dim position As Integer
                If Integer.TryParse(readValue.Item(_memberDetailsPosition), position) Then
                    member.Position = position
                End If

                Dim status As Integer
                If Integer.TryParse(readValue.Item(_memberDetailsStatus), status) Then
                    member.Status = status
                End If

                members.Add(member)
            Next
            Return members
        End Function

        Shared Async Function RetrieveMemberPrivledgesAsync(member As Member) As Task(Of Permissions)
            Dim query As String = "Select * FROM " & PrivledgesTableName & " WHERE " & _privledgesMember & " = '" & member.Id & "'"

            Dim readerValues = Await RetrieveValuesFromDatabaseAsync(query).ConfigureAwait(False)

            Return GetPrivledges(readerValues).FirstOrDefault()
        End Function

        Shared Async Function RetrieveMemberPrivledgesAsync() As Task(Of List(Of Permissions))
            Dim query As String = "Select * FROM " & PrivledgesTableName

            Dim readerValues = Await RetrieveValuesFromDatabaseAsync(query).ConfigureAwait(False)

            Return GetPrivledges(readerValues)
        End Function

        Private Shared Function GetPrivledges(readerValues As List(Of NameValueCollection)) As List(Of Permissions)
            Dim values = (From readValue In readerValues Select readValue).ToList()

            Dim mutex As New Object()
            Dim permissions As New List(Of Permissions)
            Parallel.ForEach(values, Async Sub(value As NameValueCollection)
                                         Dim permission = Await CastNameValueCollectionToPrivledgesAsync(value).ConfigureAwait(False)

                                         SyncLock mutex
                                             permissions.Add(permission)
                                         End SyncLock
                                     End Sub)

            Return permissions
        End Function

        Private Shared Async Function CastNameValueCollectionToPrivledgesAsync(readValue As NameValueCollection) As Task(Of Permissions)
            Dim privledges As Permissions

            Dim member As New Member(Await RetrieveMemberDetailsAsync(readValue.Item(_privledgesMember).ToString()).ConfigureAwait(False))
            Try
                privledges = New Permissions(member)
            Catch ex As Exception
                Return Nothing
            End Try

            Dim value As Boolean
            AddMainScreenPrivledges(readValue, privledges, value)
            AddUserManagementPrivledges(readValue, privledges, value)
            AddMembersPrivledges(readValue, privledges, value)
            AddEmailSettingsPrivledges(readValue, privledges, value)
            AdditionalEmailReceipientsTableNameJobTaskPrivledges(readValue, privledges, value)
            AddVehiclesEquipmentPrivledges(readValue, privledges, value)

            Return privledges
        End Function

        Private Shared Sub AddMainScreenPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.CreateDebriefs = TryParseBooleanFromSQLite(readValue.Item(_privledgesCreateDebriefs), value) AndAlso value
            'Dim test1 As Boolean = False
            'TryParseBooleanFromSQLite(readValue.Item(_privledgesCreateDebriefs), test1)
            'privledges.CreateDebriefs = test1
        End Sub

        Private Shared Function TryParseBooleanFromSQLite(item As String, ByRef value As Boolean) As Boolean
            If Not (item = "0" OrElse item = "1") Then
                value = False
                Return False
            End If

            value = item = "1"
            Return True
        End Function

        Private Shared Sub AddUserManagementPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.UserManagementPrivledges.AssignPrivledges = TryParseBooleanFromSQLite(readValue.Item(_privledgesAssignPrivledges), value) AndAlso value
            privledges.UserManagementPrivledges.ResetOwnPassword = TryParseBooleanFromSQLite(readValue.Item(_privledgesResetOwnPassword), value) AndAlso value
            privledges.UserManagementPrivledges.ResetOthersPassword = TryParseBooleanFromSQLite(readValue.Item(_privledgesResetOthersPassword), value) AndAlso value
        End Sub

        Private Shared Sub AddMembersPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.MembersPrivledges.CreateNewMember = TryParseBooleanFromSQLite(readValue.Item(_privledgesCreateNewMember), value) AndAlso value
            privledges.MembersPrivledges.UpdateSelf = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateSelf), value) AndAlso value
            privledges.MembersPrivledges.UpdateAnotherMember = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateAnotherMember), value) AndAlso value
            privledges.MembersPrivledges.DeleteMember = TryParseBooleanFromSQLite(readValue.Item(_privledgesDeleteMember), value) AndAlso value
        End Sub

        Private Shared Sub AddEmailSettingsPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.EmailSettingsPrivledges.UpdateEmailReceipients = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateEmailReceipients), value) AndAlso value
            privledges.EmailSettingsPrivledges.UpdateMailServer = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateMailServer), value) AndAlso value
            privledges.EmailSettingsPrivledges.UpdateNetworkCredentials = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateNetworkCredentials), value) AndAlso value
            privledges.EmailSettingsPrivledges.UpdateClientSettings = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateClientSettings), value) AndAlso value
            privledges.EmailSettingsPrivledges.UpdateFromAddress = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateFromAddress), value) AndAlso value
        End Sub

        Private Shared Sub AdditionalEmailReceipientsTableNameJobTaskPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.JobTaskPrivledges.UpdateJobTypes = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateJobTypes), value) AndAlso value
            privledges.JobTaskPrivledges.UpdateTasks = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateTasks), value) AndAlso value
        End Sub

        Private Shared Sub AddVehiclesEquipmentPrivledges(readValue As NameValueCollection, ByRef privledges As Permissions, ByRef value As Boolean)
            privledges.VehiclesEquipmentPrivledges.UpdateVehicles = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateVehicles), value) AndAlso value
            privledges.VehiclesEquipmentPrivledges.UpdateEquipment = TryParseBooleanFromSQLite(readValue.Item(_privledgesUpdateEquipment), value) AndAlso value
        End Sub

        Public Shared Async Function RetrieveMemberPasswordAsync(id As String) As Task(Of String)
            Dim query As String = "Select * FROM " & PasswordTableName & " WHERE " & _passwordMember & " = '" & id & "'"

            Dim readValues = Await RetrieveValuesFromDatabaseAsync(query).ConfigureAwait(False)
            'Dim readValues = (From readValue In passwords Select readValue).ToList()

            If readValues.Count = 0 Then
                Return "Unknown"
            End If

            Return readValues.First().Item(_passwordPassword).ToString()
        End Function

        Public Shared Function MemberIdExists(id As String) As Boolean
            Try
                Dim query = "SELECT * FROM " & MemberDetailsTableName & " WHERE " & _memberDetailsID & " = @id"
                Dim parameters As New List(Of SQLiteParameter) From {New SQLiteParameter("@id", id)}

                Return RetrieveValueCollection(query, parameters).Count > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Async Function MemberIdExistsAsync(id As String) As Task(Of Boolean)
            Try
                Dim query = "SELECT * FROM " & MemberDetailsTableName & " WHERE " & _memberDetailsID & " = @id"
                Dim parameters As New List(Of SQLiteParameter) From {New SQLiteParameter("@id", id)}

                Dim collection = Await RetrieveValueCollectionAsync(query, parameters).ConfigureAwait(False)

                Return collection.Count > 0
            Catch ex As Exception
                Return False
            End Try
        End Function

        Public Shared Function NumberOfDeployments(deploymentName As String) As Integer
            Try
                Dim query = "SELECT * FROM " & DebriefDataTableName & " WHERE " & _debriefDataEventNumber & " LIKE @deploymentNumber" & "%"
                Dim parameters As New List(Of SQLiteParameter) From {New SQLiteParameter("@deploymentNumber", deploymentName)}

                Return RetrieveValueCollection(query, parameters).Count
            Catch ex As Exception
                Return 0
            End Try
        End Function

        Public Shared Async Function CreateMemberAsync(member As Member) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = InsertIntoMemberDetailsQuery()
                    AddMemberDetailsCommandParameters(member, command)
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    connection.Close()
                End Using
            End Using
        End Function

        Private Shared Sub AddMemberDetailsCommandParameters(member As Member, ByRef command As SQLiteCommand)
            With command
                .Parameters.Clear()
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsID, member.Id))
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsSurname, member.Surname))
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsFirstName, member.FirstName))
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsEmailAddress, member.EmailAddress))
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsPosition, member.Position))
                .Parameters.Add(New SQLiteParameter("@" & _memberDetailsStatus, member.Status))
            End With
        End Sub

        Public Shared Sub UpdateMember(memberUpdating As Member, originalMemberId As String)
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    With command
                        .CommandText = UpdateMemberDetailsQuery()
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsID, memberUpdating.Id))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsSurname, memberUpdating.Surname))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsFirstName, memberUpdating.FirstName))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsEmailAddress, memberUpdating.EmailAddress))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsPosition, memberUpdating.Position))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsStatus, memberUpdating.Status))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsOriginalId, originalMemberId))
                        .ExecuteNonQuery()
                    End With

                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Async Function UpdateMemberAsync(updateMember As Member, originalMemberId As String) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    With command
                        .CommandText = UpdateMemberDetailsQuery()
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsID, updateMember.Id))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsSurname, updateMember.Surname))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsFirstName, updateMember.FirstName))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsEmailAddress, updateMember.EmailAddress))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsPosition, updateMember.Position))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsStatus, updateMember.Status))
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsOriginalId, originalMemberId))
                        Await .ExecuteNonQueryAsync().ConfigureAwait(False)
                    End With

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Async Function DeleteMemberAsync(memberId As String) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    With command
                        .CommandText = DeleteMemberDetailsQuery()
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@" & _memberDetailsID, memberId))
                        Await .ExecuteNonQueryAsync().ConfigureAwait(False)
                    End With

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Async Function CreatePrivledgesAsync(permission As Permissions) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = InsertIntoPrivledgesQuery()
                    AddPrivledgesCommandParameters(permission, command)
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    connection.Close()
                End Using
            End Using
        End Function

        Private Shared Sub AddPrivledgesCommandParameters(permission As Permissions, ByRef command As SQLiteCommand)
            With command
                .Parameters.Clear()
                .Parameters.Add(New SQLiteParameter("@" & _privledgesMember, permission.Member.Id))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesCreateDebriefs, permission.CreateDebriefs))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesAssignPrivledges, permission.UserManagementPrivledges.AssignPrivledges))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesResetOwnPassword, permission.UserManagementPrivledges.ResetOthersPassword))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesResetOthersPassword, permission.UserManagementPrivledges.ResetOthersPassword))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesCreateNewMember, permission.MembersPrivledges.CreateNewMember))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateSelf, permission.MembersPrivledges.UpdateSelf))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateAnotherMember, permission.MembersPrivledges.UpdateAnotherMember))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesDeleteMember, permission.MembersPrivledges.DeleteMember))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateEmailReceipients, permission.EmailSettingsPrivledges.UpdateEmailReceipients))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateMailServer, permission.EmailSettingsPrivledges.UpdateMailServer))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateNetworkCredentials, permission.EmailSettingsPrivledges.UpdateNetworkCredentials))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateClientSettings, permission.EmailSettingsPrivledges.UpdateClientSettings))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateFromAddress, permission.EmailSettingsPrivledges.UpdateFromAddress))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateJobTypes, permission.JobTaskPrivledges.UpdateJobTypes))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateTasks, permission.JobTaskPrivledges.UpdateTasks))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateVehicles, permission.VehiclesEquipmentPrivledges.UpdateVehicles))
                .Parameters.Add(New SQLiteParameter("@" & _privledgesUpdateEquipment, permission.VehiclesEquipmentPrivledges.UpdateEquipment))
            End With
        End Sub

        Public Shared Sub UpdatePrivledges(permission As Permissions, originalMemberId As String)
            If permission Is Nothing OrElse originalMemberId Is Nothing Then
                Throw New NullReferenceException()
            End If

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    command.CommandText = UpdatePrivledgesQuery()
                    AddPrivledgesCommandParameters(permission, command)
                    command.Parameters.Add(New SQLiteParameter("@" & _privledgesOriginalId, originalMemberId))
                    command.ExecuteNonQuery()

                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Async Function UpdatePrivledgesAsync(permission As Permissions, originalMemberId As String) As Task
            If permission Is Nothing OrElse originalMemberId Is Nothing Then
                Throw New NullReferenceException()
            End If

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = UpdatePrivledgesQuery()
                    AddPrivledgesCommandParameters(permission, command)
                    command.Parameters.Add(New SQLiteParameter("@" & _privledgesOriginalId, originalMemberId))
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Async Function DeletePrivledgesAsync(memberId As String) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    With command
                        .CommandText = DeletePrivledgesQuery()
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@" & _privledgesMember, memberId))
                        Await .ExecuteNonQueryAsync().ConfigureAwait(False)
                    End With

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Async Function CreatePasswordAsync(memberId As String, password As String) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = InsertIntoPasswordQuery()
                    AddPasswordCommandParameters(memberId, password, command)
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    connection.Close()
                End Using
            End Using
        End Function

        Private Shared Sub AddPasswordCommandParameters(memberId As String, password As String, ByRef command As SQLiteCommand)
            With command
                .Parameters.Clear()
                .Parameters.Add(New SQLiteParameter("@" & _passwordMember, memberId))
                .Parameters.Add(New SQLiteParameter("@" & _passwordPassword, password))
            End With
        End Sub

        Public Shared Sub UpdatePassword(newMemberId As String, password As String, originalMemberId As String)
            Try
                DetermineExceptionsPassword(newMemberId, password, originalMemberId)
            Catch
                Throw
            End Try

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    command.CommandText = UpdatePasswordQuery()
                    AddPasswordCommandParameters(newMemberId, password, command)
                    command.Parameters.Add(New SQLiteParameter("@" & _passwordOriginalId, originalMemberId))
                    command.ExecuteNonQuery()

                    connection.Close()
                End Using
            End Using
        End Sub

        Private Shared Sub DetermineExceptionsPassword(newMemberId As String, password As String, originalMemberId As String)
            If newMemberId Is Nothing Then
                Throw New NullReferenceException(NameOf(newMemberId))
            End If

            If password Is Nothing Then
                Throw New NullReferenceException(NameOf(password))
            End If

            If originalMemberId Is Nothing Then
                Throw New NullReferenceException(NameOf(originalMemberId))
            End If
        End Sub

        Public Shared Async Function UpdatePasswordAsync(newMemberId As String, password As String, originalMemberId As String) As Task
            Try
                DetermineExceptionsPassword(newMemberId, password, originalMemberId)
            Catch
                Throw
            End Try

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = UpdatePasswordQuery()
                    AddPasswordCommandParameters(newMemberId, password, command)
                    command.Parameters.Add(New SQLiteParameter("@" & _passwordOriginalId, originalMemberId))
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Async Function DeletePasswordAsync(memberId As String) As Task
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    With command
                        .CommandText = DeletePasswordQuery()
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@" & _passwordMember, memberId))
                        Await .ExecuteNonQueryAsync().ConfigureAwait(False)
                    End With

                    connection.Close()
                End Using
            End Using
        End Function

        Public Shared Function RetrieveJobTypes() As List(Of String)
            Return RetrieveItems(JobTypeTableName, _jobTypeJobType, CreateJobTypeTableQuery())
        End Function

        Public Shared Function RetrieveTasks() As List(Of String)
            Return RetrieveItems(TasksTableName, _taskTask, CreateTasksTableQuery())
        End Function

        Public Shared Function RetrieveVehicles() As List(Of String)
            Return RetrieveItems(VehiclesTableName, _vehicleVehcile, CreateVehiclesTableQuery())
        End Function

        Public Shared Function RetrieveEquipment() As List(Of String)
            Return RetrieveItems(EquipmentTableName, _equipmentItem, CreateEquipmentTableQuery())
        End Function

        Private Shared Function RetrieveItems(tableName As String, item As String, newtableQuery As String) As List(Of String)
            If Not TableExists(tableName) Then
                CreateNewTable(newtableQuery)
                Return New List(Of String)
            End If

            Dim valueCollections = RetrieveValueCollection("Select * FROM " & tableName)
            Return GetValues(valueCollections, item)
        End Function

        Public Shared Sub SaveEmailSettings(settings As EmailSettings)
            ' Create the new key for the data
            Dim stamp As DateTime = Now()

            ' Create the database and open a connection
            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    ' Open the connection to the database
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    ' Instantiate the return string
                    Dim insertString As New StringBuilder()

                    For count = 0 To 2
                        ' Clear the insertString and SqliteCommand parameters
                        insertString.Clear()
                        command.Parameters.Clear()

                        Select Case count
                            Case 0 ' Email Settings
                                ' Construct the insert command
                                With insertString
                                    .Append("INSERT INTO ")
                                    .Append(EmailSettingsTableName)
                                    .Append(" (" & _emailSettingsAllMembersReceipientType & ", " &
                                                   _emailSettingsAllMembersReceive & ", " &
                                                   _emailSettingsFromAddress & ", " &
                                                   _emailSettingsFromDisplayName & ", " &
                                                   _emailSettingsMailPriority & ", " &
                                                   _emailSettingsShowPassword & ", " &
                                                   _emailSettingsSmptClientHost & ", " &
                                                   _emailSettingsSmtpClientPassword & ", " &
                                                   _emailSettingsSmtpClientPort & ", " &
                                                   _emailSettingsSmtpClientUserName & ", " &
                                                   _emailSettingsSmtpEnableSSL & ", " &
                                                   _emailSettingsSmtpTimeout & ", " &
                                                   _emailSettingsTimestamp & ") ")
                                    .Append("VALUES (@AllMembersReceipientType, @AllMembersReceive, @FromAddress, @FromDisplayName, @MailPriority, @ShowPassword, ")
                                    .Append("@SmptClientHost, @SmtpClientPassword, @SmtpClientPort, @SmtpClientUserName, @SmtpEnableSSL, @SmtpTimeout, @Timestamp);")
                                End With

                                command.CommandText = insertString.ToString()
                                command.CommandType = CommandType.Text

                                ' Determine if the from Address has been initilaised, and if so eth 
                                Dim fromAddress As String = Nothing
                                Dim fromDisplayName As String = Nothing
                                If settings.FromAddress IsNot Nothing Then
                                    fromAddress = settings.FromAddress.Address
                                    fromDisplayName = settings.FromAddress.DisplayName
                                End If

                                command.Parameters.Add(New SQLiteParameter("@AllMembersReceipientType", settings.AllMemberReceipientType.ToString()))
                                command.Parameters.Add(New SQLiteParameter("@AllMembersReceive", settings.AllMemberReceive))
                                command.Parameters.Add(New SQLiteParameter("@FromAddress", fromAddress))
                                command.Parameters.Add(New SQLiteParameter("@FromDisplayName", fromDisplayName))
                                command.Parameters.Add(New SQLiteParameter("@MailPriority", settings.MailPriority.ToString()))
                                command.Parameters.Add(New SQLiteParameter("@ShowPassword", settings.ShowPassword))
                                command.Parameters.Add(New SQLiteParameter("@SmptClientHost", settings.SmtpClient.Host))
                                command.Parameters.Add(New SQLiteParameter("@SmtpClientPassword", CType(settings.SmtpClient.Credentials, NetworkCredential).Password))
                                command.Parameters.Add(New SQLiteParameter("@SmtpClientPort", settings.SmtpClient.Port))
                                command.Parameters.Add(New SQLiteParameter("@SmtpClientUserName", CType(settings.SmtpClient.Credentials, NetworkCredential).UserName))
                                command.Parameters.Add(New SQLiteParameter("@SmtpEnableSSL", settings.SmtpClient.EnableSsl))
                                command.Parameters.Add(New SQLiteParameter("@SmtpTimeout", settings.SmtpClient.Timeout))
                                command.Parameters.Add(New SQLiteParameter("@Timestamp", stamp))

                                command.ExecuteNonQuery()

                            Case 1 ' Members to Receive
                                ' Construct the insert command
                                With insertString
                                    .Append("INSERT INTO ")
                                    .Append(MembersToReceiveTableName)
                                    .Append(" (" & _membersToReceiveMemberID & ", " &
                                                   _membersToReceiveReceipientType & ", " &
                                                   _membersToReceiveTimestamp & ") ")
                                    .Append("VALUES (@MemberID, @ReceipientType, @Timestamp);")
                                End With

                                command.CommandText = insertString.ToString()
                                command.CommandType = CommandType.Text

                                For Each receipient As Member In settings.MembersToReceive.Keys
                                    Dim value As EmailSettings.TypeOfReceipient
                                    If settings.MembersToReceive.TryGetValue(receipient, value) Then
                                        command.Parameters.Clear()
                                        command.Parameters.Add(New SQLiteParameter("@MemberID", receipient.Id))
                                        command.Parameters.Add(New SQLiteParameter("@ReceipientType", value.ToString()))
                                        command.Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                                        command.ExecuteNonQuery()
                                    End If
                                Next

                            ' Delete the previous settings

                            Case 2 ' Additional Receipients
                                ' Construct the insert command
                                With insertString
                                    .Append("INSERT INTO ")
                                    .Append(AdditionalEmailReceipientsTableName)
                                    .Append(" (" & _additionalEmailReceipientsDisplayName & ", " &
                                                   _additionalEmailReceipientsEmailAddress & ", " &
                                                   _additionalEmailReceipientsReceipientType & ", " &
                                                   _additionalEmailReceipientsTimestamp & ") ")
                                    .Append("VALUES (@DisplayName, @EmailAddress, @ReceipientType, @Timestamp);")
                                End With

                                command.CommandText = insertString.ToString()
                                command.CommandType = CommandType.Text

                                For Each entry As Integer In settings.AdditionalReceipients.Keys
                                    Dim value As Tuple(Of MailAddress, EmailSettings.TypeOfReceipient) = Nothing
                                    If settings.AdditionalReceipients.TryGetValue(entry, value) Then
                                        command.Parameters.Clear()
                                        command.Parameters.Add(New SQLiteParameter("@DisplayName", value.Item1.DisplayName))
                                        command.Parameters.Add(New SQLiteParameter("@EmailAddress", value.Item1.Address))
                                        command.Parameters.Add(New SQLiteParameter("@ReceipientType", value.Item2.ToString()))
                                        command.Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                                        command.ExecuteNonQuery()
                                    End If
                                Next
                        End Select
                    Next

                    ' Delete the previous settings
                    Dim tables() As String = {AdditionalEmailReceipientsTableName, MembersToReceiveTableName, EmailSettingsTableName}
                    For i = 0 To tables.Length - 1
                        command.Parameters.Clear()
                        command.CommandText = "DELETE FROM " & tables(i) & " WHERE Timestamp != @Timestamp"
                        command.Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                        command.ExecuteNonQuery()
                    Next

                    ' Close the connection to the database
                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Sub SaveJobTypes(jobTypes As List(Of String))
            Dim stamp = DateTime.Now()

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    Dim insertString = "INSERT OR REPLACE INTO " & JobTypeTableName & " (" & _jobTypeJobType & ", " & _jobTypeTimestamp & ") VALUES (@JobType, @Timestamp);"
                    command.CommandText = insertString
                    For Each jobType In jobTypes
                        With command
                            .Parameters.Clear()
                            .Parameters.Add(New SQLiteParameter("@JobType", jobType))
                            .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                            .ExecuteNonQuery()
                        End With
                    Next

                    Dim deleteString = "DELETE FROM " & JobTypeTableName & " WHERE " & _jobTypeTimestamp & " != @Timestamp;"
                    With command
                        .CommandText = deleteString
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                        .ExecuteNonQuery()
                    End With

                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Sub SaveTasks(tasks As List(Of String))
            Dim stamp = DateTime.Now()

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    Dim insertString = "INSERT OR REPLACE INTO " & TasksTableName & " (" & _taskTask & ", " & _taskTimestamp & ") VALUES (@Task, @Timestamp);"
                    command.CommandText = insertString
                    For Each task In tasks
                        With command
                            .Parameters.Clear()
                            .Parameters.Add(New SQLiteParameter("@Task", task))
                            .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                            .ExecuteNonQuery()
                        End With
                    Next

                    Dim deleteString = "DELETE FROM " & TasksTableName & " WHERE " & _taskTimestamp & " != @Timestamp;"
                    With command
                        .CommandText = deleteString
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                        .ExecuteNonQuery()
                    End With

                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Sub SaveVehicles(vehicles As List(Of String))
            Dim stamp = DateTime.Now()

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    Dim insertString = "INSERT OR REPLACE INTO " & VehiclesTableName & " (" & _vehicleVehcile & ", " & _vehicleTimestamp & ") VALUES (@Vehicle, @Timestamp);"
                    command.CommandText = insertString
                    For Each vehicle In vehicles
                        With command
                            .Parameters.Clear()
                            .Parameters.Add(New SQLiteParameter("@Vehicle", vehicle))
                            .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                            .ExecuteNonQuery()
                        End With
                    Next

                    Dim deleteString = "DELETE FROM " & VehiclesTableName & " WHERE " & _vehicleTimestamp & " != @Timestamp;"
                    With command
                        .CommandText = deleteString
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                        .ExecuteNonQuery()
                    End With

                    connection.Close()
                End Using
            End Using
        End Sub

        Public Shared Sub SaveEquipment(equipment As List(Of String))
            Dim stamp = DateTime.Now()

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    Dim insertString = "INSERT OR REPLACE INTO " & EquipmentTableName & " (" & _equipmentItem & ", " & _equipmentTimestamp & ") VALUES (@Item, @Timestamp);"
                    command.CommandText = insertString
                    For Each item In equipment
                        With command
                            .Parameters.Clear()
                            .Parameters.Add(New SQLiteParameter("@Item", item))
                            .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                            .ExecuteNonQuery()
                        End With
                    Next

                    Dim deleteString = "DELETE FROM " & EquipmentTableName & " WHERE " & _equipmentTimestamp & " != @Timestamp;"
                    With command
                        .CommandText = deleteString
                        .Parameters.Clear()
                        .Parameters.Add(New SQLiteParameter("@Timestamp", stamp))
                        .ExecuteNonQuery()
                    End With

                    connection.Close()
                End Using
            End Using
        End Sub

#End Region


#Region "Private Shared Methods"

        Private Shared Function CastToMember(rawData As String()) As Member
            Dim member As Member

            Try
                member = New Member(Cipher.AffineBifidDecrypt(rawData(2)))
            Catch ex As Exception
                Return Nothing
            End Try

            Try
                member.Surname = Cipher.AffineBifidDecrypt(rawData(0))
            Catch ex As Exception
                ' Ignore
            End Try

            Try
                member.FirstName = Cipher.AffineBifidDecrypt(rawData(1))
            Catch ex As Exception
                ' Ignore
            End Try

            Try
                member.EmailAddress = Cipher.AffineBifidDecrypt(rawData(22))
            Catch ex As Exception
                ' Ignore
            End Try

            Try
                member.Position = Convert.ToInt32(Cipher.AffineBifidDecrypt(rawData(25)))
            Catch ex As Exception
                ' Ignore
            End Try

            Try
                member.Status = Convert.ToInt32(Cipher.AffineBifidDecrypt(rawData(24)))
            Catch ex As Exception
                ' Ignore
            End Try

            Return member
        End Function

        Private Shared Sub InsertMember(member As Member, ByRef command As SQLiteCommand)
            With command
                .CommandType = CommandType.Text
                .CommandText = InsertIntoMemberDetailsQuery()
            End With

            AddMemberDetailsCommandParameters(member, command)

            Try
                command.ExecuteNonQuery()
            Catch ex As SQLiteException
                ' do nothing - member is already in database
            End Try
        End Sub

        Private Shared Sub CreateInitialPermissions(member As Member, ByRef command As SQLiteCommand)
            With command
                .CommandType = CommandType.Text
                .CommandText = InsertIntoPrivledgesQuery()
            End With

            AddPrivledgesCommandParameters(DefaultPermissions(member), command)

            command.ExecuteNonQuery()
        End Sub

        Private Shared Sub CreateInitialPassword(member As Member, ByRef command As SQLiteCommand)
            With command
                .CommandType = CommandType.Text
                .CommandText = InsertIntoPasswordQuery()
            End With

            AddPasswordCommandParameters(member.Id, EncryptPassword(member.Id), command)

            command.ExecuteNonQuery()
        End Sub

        Private Shared Function DefaultPermissions(member As Member) As Permissions
            Dim permission As New Permissions(member)

            permission.CreateDebriefs = True

            Return permission
        End Function

        Private Shared Sub InsertDebriefData(debrief As Debrief, ByRef command As SQLiteCommand)
            ' Instantiate the return string
            Dim insertString As New StringBuilder()

            ' clear the insertString and SqliteCommand parameters
            insertString.Clear()
            command.Parameters.Clear()

            ' Construct the debrief command
            With insertString
                .Append("INSERT INTO " & DebriefDataTableName & " ")
                .Append("(" & _debriefDataCrewAdequatelyTrained & ", ")
                .Append(_debriefDataCrewLeader & ", ")
                .Append(_debriefDataFinishTime & ", ")
                .Append(_debriefDataEquipmentToMakeEasier & ", ")
                .Append(_debriefDataEventNumber & ", ")
                .Append(_debriefDataFirstAider & ", ")
                .Append(_debriefDataIssuesForJob & ", ")
                .Append(_debriefDataJobDescription & ", ")
                .Append(_debriefDataJobType & ", ")
                .Append(_debriefDataMyCouncil & ", ")
                .Append(_debriefDataPlan & ", ")
                .Append(_debriefDataPlanB & ", ")
                .Append(_debriefDataPlanClearToAll & ", ")
                .Append(_debriefDataSafety & ", ")
                .Append(_debriefDataSafetyConcerns & ", ")
                .Append(_debriefDataSESCommander & ", ")
                .Append(_debriefDataSkills & ", ")
                .Append(_debriefDataStartTime & ") ")
                .Append("VALUES (@CrewAdequatelyTrained, @CrewLeader, @FinishTime, @EquipmentToMakeEasier, @EventNumber, @FirstAider, @IssuesForJob, @JobDescription, @JobType, @MyCouncil, @Plan, @PlanB, @PlanClearToAll, @Safety, @SafetyConcerns, @SESCommander, @Skills, @StartTime);")
            End With

            'command.CommandText = InsertDebriefDataString(debrief)
            command.CommandText = insertString.ToString()
            command.CommandType = CommandType.Text

            command.Parameters.Add(New SQLiteParameter("@CrewAdequatelyTrained", debrief.CrewAdequatelyTrained))
            command.Parameters.Add(New SQLiteParameter("@CrewLeader", If(debrief.CrewLeader Is Nothing, Nothing, debrief.CrewLeader.Id)))
            command.Parameters.Add(New SQLiteParameter("@FinishTime", debrief.FinishTime))
            command.Parameters.Add(New SQLiteParameter("@EquipmentToMakeEasier", debrief.EquipmentToMakeEasier))
            command.Parameters.Add(New SQLiteParameter("@EventNumber", debrief.EventNumber))
            command.Parameters.Add(New SQLiteParameter("@FirstAider", If(debrief.FirstAider Is Nothing, Nothing, debrief.FirstAider.Id)))
            command.Parameters.Add(New SQLiteParameter("@IssuesForJob", debrief.IssuesForJob))
            command.Parameters.Add(New SQLiteParameter("@JobDescription", debrief.JobDescription))
            command.Parameters.Add(New SQLiteParameter("@JobType", debrief.JobType))
            command.Parameters.Add(New SQLiteParameter("@MyCouncil", debrief.MyCouncil))
            command.Parameters.Add(New SQLiteParameter("@Plan", debrief.Plan))
            command.Parameters.Add(New SQLiteParameter("@PlanB", debrief.PlanB))
            command.Parameters.Add(New SQLiteParameter("@PlanClearToAll", debrief.PlanClearToAll))
            command.Parameters.Add(New SQLiteParameter("@Safety", If(debrief.Safety Is Nothing, Nothing, debrief.Safety.Id)))
            command.Parameters.Add(New SQLiteParameter("@SafetyConcerns", debrief.SafetyConcerns))
            command.Parameters.Add(New SQLiteParameter("@SESCommander", If(debrief.SesCommander Is Nothing, Nothing, debrief.SesCommander.Id)))
            command.Parameters.Add(New SQLiteParameter("@Skills", debrief.Skills))
            command.Parameters.Add(New SQLiteParameter("@StartTime", debrief.StartTime))
        End Sub

        Private Shared Sub InsertMembersAttending(eventNumber As String, attendingMember As KeyValuePair(Of Member, String),
                                                  ByRef command As SQLiteCommand)
            ' Instantiate the return string
            Dim insertString As New StringBuilder()
            ' clear the insertString and SqliteCommand parameters
            insertString.Clear()
            command.Parameters.Clear()

            With insertString
                .Append("INSERT INTO " & MembersAttendingTableName & " ")
                .Append(" (EventNumber, MemberID, TaskUndertaken) ")
                .Append(vbCrLf)
                .Append("VALUES (@EventNumber, @MemberID, @TaskUndertaken);")
            End With

            'command.CommandText = InsertMembersAttendingString(debrief.EventNumber, attendingMember.Key, attendingMember.Value)
            command.CommandText = insertString.ToString()
            command.CommandType = CommandType.Text

            command.Parameters.Add(New SQLiteParameter("@EventNumber", eventNumber))
            command.Parameters.Add(New SQLiteParameter("@MemberID", attendingMember.Key.Id))
            command.Parameters.Add(New SQLiteParameter("@TaskUndertaken", attendingMember.Value))
        End Sub

        Private Shared Sub InsertVehiclesUsedString(eventNumber As String, vehicle As String, ByRef command As SQLiteCommand)
            ' Instantiate the return string
            Dim insertString As New StringBuilder()

            ' clear the insertString and SqliteCommand parameters
            insertString.Clear()
            command.Parameters.Clear()

            ' Construct the debrief command
            With insertString
                .Append("INSERT INTO " & VehiclesUsedTableName & " ")
                .Append("(EventNumber, Vehicle) ")
                .Append("VALUES (@EventNumber, @Vehicle);")
            End With

            'command.CommandText = InsertMembersAttendingString(debrief.EventNumber, attendingMember.Key, attendingMember.Value)
            command.CommandText = insertString.ToString()
            command.CommandType = CommandType.Text

            command.Parameters.Add(New SQLiteParameter("@EventNumber", eventNumber))
            command.Parameters.Add(New SQLiteParameter("@Vehicle", vehicle))
        End Sub

        Private Shared Sub InsertEquipmentUsedString(eventNumber As String, itemUsed As EquipmentUse, ByRef command As SQLiteCommand)
            ' Instantiate the return string
            Dim insertString As New StringBuilder()

            ' clear the insertString and SqliteCommand parameters
            insertString.Clear()
            command.Parameters.Clear()

            ' Construct the debrief command
            With insertString
                .Append("INSERT INTO " & EquipmentUsedTableName & " ")
                .Append("(" & _equipmentUsedEventNumber & ", " & _equipmentUsedItem & ", " & _equipmentUsedDuration & ", " & _equipmentUsedMemberID & ") ")
                .Append("VALUES (@EventNumber, @Item, @Duration, @MemberID);")
            End With

            command.CommandText = insertString.ToString()
            command.CommandType = CommandType.Text

            command.Parameters.Add(New SQLiteParameter("@EventNumber", eventNumber))
            command.Parameters.Add(New SQLiteParameter("@Item", itemUsed.Item))
            command.Parameters.Add(New SQLiteParameter("@Duration", itemUsed.Duration))
            command.Parameters.Add(New SQLiteParameter("@MemberID", itemUsed.MemberUsing.Id))
        End Sub

        Private Shared Function RetieveAllDebriefDataFromText(members As List(Of Member)) As List(Of DebriefSingleIncident)
            ' Retrieve the raw data
            Dim encryptedDebriefData, encryptedMembersAttending As List(Of String())
            Try
                encryptedDebriefData = DebriefPersistence.RetieveAllDebriefDataFromText()
                encryptedMembersAttending = DebriefPersistence.RetrieveAllMembersAttendingFromText()
            Catch ex As FileNotFoundException
                ' File(s) can not be found, so simply return an empty list
                Return New List(Of DebriefSingleIncident)
            End Try

            'Decrypt the debrief data
            Dim decryptedDebriefData As New List(Of String())
            For Each record As String() In encryptedDebriefData
                Dim newRecord(record.Length - 1) As String
                For i = 0 To record.Length - 1
                    newRecord(i) = Cipher.AffineBifidDecrypt(record(i))
                Next
                decryptedDebriefData.Add(newRecord)
            Next

            ' Decrypt the attendance records
            Dim decryptedMembersAttending As New List(Of String())
            For Each record As String() In encryptedMembersAttending
                Dim newRecord(record.Length - 1) As String
                For i = 0 To record.Length - 1
                    newRecord(i) = Cipher.AffineBifidDecrypt(record(i))
                Next
                decryptedMembersAttending.Add(newRecord)
            Next

            ' Create the return string
            Dim debriefs As New List(Of DebriefSingleIncident)

            ' Cast the raw data to type DebriefSingleIncident
            For Each storedDebrief As String() In decryptedDebriefData
                ' Create the return string
                Dim debriefSingleIncident As DebriefSingleIncident

                ' Manually cast the rawData into type DebriefSingleIncident

                ' Event Number
                Try
                    debriefSingleIncident = New DebriefSingleIncident(storedDebrief(0))
                Catch ex As Exception
                    Return New List(Of DebriefSingleIncident)
                End Try

                ' Start/End Times
                Dim startString() As String = storedDebrief(1).Split({"/", " ", ":"}, StringSplitOptions.None)
                Dim endString() As String = storedDebrief(2).Split({"/", " ", ":"}, StringSplitOptions.None)
                Dim start(startString.Length - 1) As Integer
                Dim finish(endString.Length - 1) As Integer
                For i = 0 To startString.Length - 1
                    start(i) = Convert.ToInt32(startString(i))
                    finish(i) = Convert.ToInt32(endString(i))
                Next
                debriefSingleIncident.StartTime = New DateTime(start(2), start(1), start(0), start(3), start(4), 0)
                debriefSingleIncident.FinishTime = New DateTime(finish(2), finish(1), finish(0), finish(3), finish(4), 0)

                'Job Type
                debriefSingleIncident.JobType = storedDebrief(3)

                ' SES Commander
                Dim name() As String = storedDebrief(4).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
                Dim sesCommander As IEnumerable(Of Member) = GetMember(members, name)
                Try
                    debriefSingleIncident.SesCommander = New Member(sesCommander.FirstOrDefault)
                Catch ex As Exception
                    'Ignore
                End Try

                ' Crew Leader
                name = storedDebrief(5).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
                Dim crewLeader As IEnumerable(Of Member) = GetMember(members, name)
                Try
                    debriefSingleIncident.CrewLeader = New Member(crewLeader.FirstOrDefault)
                Catch ex As Exception
                    'Ignore
                End Try

                ' Safety
                name = storedDebrief(10).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
                Dim safety As IEnumerable(Of Member) = GetMember(members, name)
                Try
                    debriefSingleIncident.Safety = New Member(safety.FirstOrDefault)
                Catch ex As Exception
                    'Ignore
                End Try

                ' First Aider
                name = storedDebrief(16).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)
                Dim firstAider As IEnumerable(Of Member) = GetMember(members, name)
                Try
                    debriefSingleIncident.FirstAider = New Member(firstAider.FirstOrDefault)
                Catch ex As Exception
                    'Ignore
                End Try

                debriefSingleIncident.JobDescription = storedDebrief(6)
                debriefSingleIncident.Plan = storedDebrief(7)
                debriefSingleIncident.PlanClearToAll = storedDebrief(8) = "Yes"
                debriefSingleIncident.PlanB = storedDebrief(9) = "Yes"
                debriefSingleIncident.SafetyConcerns = storedDebrief(11)
                debriefSingleIncident.Skills = storedDebrief(12)
                debriefSingleIncident.CrewAdequatelyTrained = storedDebrief(13) = "Yes"
                debriefSingleIncident.IssuesForJob = storedDebrief(14)
                debriefSingleIncident.EquipmentToMakeEasier = storedDebrief(15)

                ' Add the Vehicles Used
                If storedDebrief.Length > 17 Then
                    For i = 17 To storedDebrief.Length - 1
                        debriefSingleIncident.VehiclesUsed.Add(storedDebrief(i))
                    Next
                End If

                ' Update the members attending
                Dim x = DetermineMembersAttending(decryptedMembersAttending, storedDebrief(0))

                For Each record As String() In x
                    debriefSingleIncident.MembersAttending.Add(New Member(record(1)), record(2))
                Next

                ' Add the new debrief to the list
                debriefs.Add(debriefSingleIncident)
            Next

            Return debriefs
        End Function

        Private Shared Function DetermineMembersAttending(decryptedMembersAttending As List(Of String()), eventNumber As String) As IEnumerable(Of String())

            Return From record In decryptedMembersAttending
                   Where record(0) = eventNumber
                   Select record
        End Function

        Private Shared Function GetMember(members As List(Of Member), name As String()) As IEnumerable(Of Member)
            Return From member In members
                   Where member.Surname = name(0) And member.FirstName = name(1)
                   Select member
        End Function

        Private Shared Function RetrieveMemberDetailsFromText() As List(Of Member)
            Dim membersText As New List(Of String())

            Try
                membersText = DebriefPersistence.RetrieveMemberDetails()
            Catch ex As FileNotFoundException
                Return New List(Of Member)
            End Try

            Dim members = (From member In membersText Select CastToMember(member)).ToList()

            members.Add(New Member(My.Resources.PermissionControllerID))
            members.Add(New Member(My.Resources.PermissionDeputyControllerID))
            members.Add(New Member(My.Resources.PermissionSectionLeaderID))
            members.Add(New Member(My.Resources.PermissionTeamLeaderID))
            members.Add(New Member(My.Resources.PermissionDeputyTeamLeaderID))
            members.Add(New Member(My.Resources.PermissionUnitMemberID))

            Return members
        End Function

        Private Shared Function RetieveJobTypesFromText() As List(Of String)
            ' Instantiate the return string
            Dim jobTypes As New List(Of String)

            Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetJobTypeData())
                While Not sr.EndOfStream()
                    jobTypes.Add(sr.ReadLine())
                End While
            End Using

            Return jobTypes
        End Function

        Private Shared Function RetrieveTasksFromText() As List(Of String)
            ' Instantiate the return string
            Dim tasks As New List(Of String)

            Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetTaskUndertakenData())
                While Not sr.EndOfStream()
                    tasks.Add(sr.ReadLine())
                End While
            End Using

            Return tasks
        End Function

        Private Shared Function TableExists(tableName As String) As Boolean
            Dim valueCollection = GetValues(RetrieveValueCollection(DatabaseTablesQuery()), "name")

            Return valueCollection.Contains(tableName)
        End Function

        Private Shared Function RetrieveValueCollection(query As String) As List(Of NameValueCollection)
            Return RetrieveValueCollection(query, Nothing)
        End Function

        Private Shared Function RetrieveValueCollection(query As String, parameters As List(Of SQLiteParameter)) As List(Of NameValueCollection)
            Dim valueCollections = New List(Of NameValueCollection)

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    'Open the connection to the database
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    command.ExecuteNonQuery()

                    command.CommandText = query
                    If parameters IsNot Nothing Then
                        For Each parameter As SQLiteParameter In parameters
                            command.Parameters.Add(parameter)
                        Next
                    End If

                    'Retrieve the updateMember details from the database
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim valueCollection = reader.GetValues()
                            valueCollections.Add(valueCollection)
                        End While
                    End Using

                    'Close the connection to the database
                    connection.Close()
                End Using
            End Using

            Return valueCollections
        End Function

        Private Shared Async Function RetrieveValueCollectionAsync(query As String, parameters As List(Of SQLiteParameter)) As Task(Of List(Of NameValueCollection))
            Dim valueCollections = New List(Of NameValueCollection)

            Using connection = New SQLiteConnection(ConnectionString)
                Using command = New SQLiteCommand(connection)
                    'Open the connection to the database
                    connection.Open()

                    command.CommandText = EnableForeignKeysQuery()
                    Await command.ExecuteNonQueryAsync().ConfigureAwait(False)

                    command.CommandText = query
                    If parameters IsNot Nothing Then
                        For Each parameter As SQLiteParameter In parameters
                            command.Parameters.Add(parameter)
                        Next
                    End If

                    'Retrieve the updateMember details from the database
                    Using reader As SQLiteDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim valueCollection = reader.GetValues()
                            valueCollections.Add(valueCollection)
                        End While
                    End Using

                    'Close the connection to the database
                    connection.Close()
                End Using
            End Using

            Return valueCollections
        End Function

        Private Shared Function GetValues(valueCollections As List(Of NameValueCollection), item As String) As List(Of String)
            Return (From valueCollection In valueCollections Select valueCollection.Item(item)).ToList()
        End Function

#End Region

#Region "Queries"

        Private Shared Function CreateAdditionalEmailReceipientsTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & AdditionalEmailReceipientsTableName & "( ")
                .Append(_additionalEmailReceipientsDisplayName & " VARCHAR(100) NULL, ")
                .Append(_additionalEmailReceipientsEmailAddress & " VARCHAR(320) Not NULL, ")
                .Append(_additionalEmailReceipientsReceipientType & " VARCHAR(3) Default ""Bcc"", ")
                .Append(_additionalEmailReceipientsTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _additionalEmailReceipientsEmailAddress & ", " & _additionalEmailReceipientsTimestamp & "), ")
                .Append("FOREIGN KEY(" & _additionalEmailReceipientsTimestamp & ") REFERENCES " & EmailSettingsTableName & "(" & _emailSettingsTimestamp & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateDebriefDataTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & DebriefDataTableName & "( ")
                .Append(_debriefDataCrewAdequatelyTrained & " Boolean NULL, ")
                .Append(_debriefDataCrewLeader & " VARCHAR(8) NULL, ")
                .Append(_debriefDataFinishTime & " DATETIME NULL, ")
                .Append(_debriefDataEquipmentToMakeEasier & " TEXT NULL, ")
                .Append(_debriefDataEventNumber & " VARCHAR(50) Not NULL, ")
                .Append(_debriefDataFirstAider & " VARCHAR(8) NULL, ")
                .Append(_debriefDataIssuesForJob & " TEXT NULL, ")
                .Append(_debriefDataJobDescription & " TEXT NULL, ")
                .Append(_debriefDataJobType & " TEXT NULL, ")
                .Append(_debriefDataMyCouncil & " Boolean NULL, ")
                .Append(_debriefDataPlan & " TEXT NULL, ")
                .Append(_debriefDataPlanB & " Boolean NULL, ")
                .Append(_debriefDataPlanClearToAll & " Boolean NULL, ")
                .Append(_debriefDataSafety & " VARCHAR(8) NULL, ")
                .Append(_debriefDataSafetyConcerns & " TEXT NULL, ")
                .Append(_debriefDataSESCommander & " VARCHAR(8) NULL, ")
                .Append(_debriefDataSkills & " TEXT NULL, ")
                .Append(_debriefDataStartTime & " DATETIME NULL, ")
                .Append("PRIMARY KEY(" & _debriefDataEventNumber & "), ")
                .Append("FOREIGN KEY(" & _debriefDataCrewLeader & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE, ")
                .Append("FOREIGN KEY(" & _debriefDataFirstAider & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE, ")
                .Append("FOREIGN KEY(" & _debriefDataSafety & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE, ")
                .Append("FOREIGN KEY(" & _debriefDataSESCommander & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateEmailSettingsTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & EmailSettingsTableName & "( ")
                .Append(_emailSettingsAllMembersReceipientType & " VARCHAR(3) Default ""Bcc"", ")
                .Append(_emailSettingsAllMembersReceive & " Boolean Default 0, ")
                .Append(_emailSettingsFromAddress & " VARCHAR(320) NULL, ")
                .Append(_emailSettingsFromDisplayName & " VARCHAR(100) NULL, ")
                .Append(_emailSettingsMailPriority & " VARCHAR(6) Default ""Normal"", ")
                .Append(_emailSettingsShowPassword & " Boolean Default 0, ")
                .Append(_emailSettingsSmptClientHost & " VARCHAR(100) NULL, ")
                .Append(_emailSettingsSmtpClientPassword & " VARCHAR(50) NULL, ")
                .Append(_emailSettingsSmtpClientPort & " Integer Default 25, ")
                .Append(_emailSettingsSmtpClientUserName & " VARCHAR(320) NULL, ")
                .Append(_emailSettingsSmtpEnableSSL & " Boolean Default 0, ")
                .Append(_emailSettingsSmtpTimeout & " Integer Default 100000, ")
                .Append(_emailSettingsTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _emailSettingsTimestamp & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateEquipmentTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & EquipmentTableName & "( ")
                .Append(_equipmentItem & " VARCHAR(100) Not NULL,  ")
                .Append(_equipmentTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _equipmentItem & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateEquipmentUsedTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & EquipmentUsedTableName & "( ")
                .Append(_equipmentUsedEventNumber & " VARCHAR(10) Not NULL, ")
                .Append(_equipmentUsedItem & " VARCHAR(100) Not NULL, ")
                .Append(_equipmentUsedDuration & " Integer Not NULL CHECK(" & _equipmentUsedDuration & " >= 0), ")
                .Append(_equipmentUsedMemberID & " VARCHAR(8) Not NULL, ")
                .Append("PRIMARY KEY(" & _equipmentUsedEventNumber & ", " & _equipmentUsedItem & "), ")
                .Append("FOREIGN KEY(" & _equipmentUsedEventNumber & ") REFERENCES " & DebriefDataTableName & "(" & _debriefDataEventNumber & "), ")
                .Append("FOREIGN KEY(" & _equipmentUsedItem & ") REFERENCES " & EquipmentTableName & "(" & _equipmentItem & ") On UPDATE CASCADE On DELETE CASCADE, ")
                .Append("FOREIGN KEY(" & _equipmentUsedMemberID & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateJobTypeTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & JobTypeTableName & "( ")
                .Append(_jobTypeJobType & " VARCHAR(100) Not NULL,  ")
                .Append(_jobTypeTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _jobTypeJobType & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateMemberDetailsTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & MemberDetailsTableName & "(")
                .Append(_memberDetailsEmailAddress & " VARCHAR(320) NULL, ")
                .Append(_memberDetailsID & " VARCHAR(8) Not NULL, ")
                .Append(_memberDetailsFirstName & " VARCHAR(50) NULL, ")
                .Append(_memberDetailsPosition & " VARCHAR(50), ")
                .Append(_memberDetailsStatus & " VARCHAR(50), ")
                .Append(_memberDetailsSurname & " VARCHAR(50), ")
                .Append("PRIMARY KEY(" & _memberDetailsID & "));")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateMembersAttendingTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & MembersAttendingTableName & "( ")
                .Append(_membersAttendingEventNumber & " VARCHAR(10) Not NULL, ")
                .Append(_membersAttendingMemberID & " VARCHAR(8) Not NULL, ")
                .Append(_membersAttendingTaskUndertaken & " TEXT NULL, ")
                .Append("PRIMARY KEY(" & _membersAttendingEventNumber & ", " & _membersAttendingMemberID & "), ")
                .Append("FOREIGN KEY(" & _membersAttendingEventNumber & ") REFERENCES " & DebriefDataTableName & "(" & _debriefDataEventNumber & "), ")
                .Append("FOREIGN KEY(" & _membersAttendingMemberID & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateMembersToReceiveTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & MembersToReceiveTableName & "( ")
                .Append(_membersToReceiveMemberID & " VARCHAR(8) Not NULL, ")
                .Append(_membersToReceiveReceipientType & " VARCHAR(3) Default ""Bcc"", ")
                .Append(_membersToReceiveTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _membersToReceiveMemberID & ", " & _membersToReceiveTimestamp & "), ")
                .Append("FOREIGN KEY(" & _membersToReceiveMemberID & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE, ")
                .Append("FOREIGN KEY(" & _membersToReceiveTimestamp & ") REFERENCES " & EmailSettingsTableName & "(" & _emailSettingsTimestamp & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreatePrivledgesTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & PrivledgesTableName & "(")
                .Append(_privledgesMember & " VARCHAR(8) Not NULL, ")
                .Append(_privledgesCreateDebriefs & " Boolean NULL, ")
                .Append(_privledgesAssignPrivledges & " Boolean NULL, ")
                .Append(_privledgesResetOwnPassword & " Boolean NULL, ")
                .Append(_privledgesResetOthersPassword & " Boolean NULL, ")
                .Append(_privledgesCreateNewMember & " Boolean NULL, ")
                .Append(_privledgesUpdateSelf & " Boolean NULL, ")
                .Append(_privledgesUpdateAnotherMember & " Boolean NULL, ")
                .Append(_privledgesDeleteMember & " Boolean NULL, ")
                .Append(_privledgesUpdateEmailReceipients & " Boolean NULL, ")
                .Append(_privledgesUpdateMailServer & " Boolean NULL, ")
                .Append(_privledgesUpdateNetworkCredentials & " Boolean NULL, ")
                .Append(_privledgesUpdateClientSettings & " Boolean NULL, ")
                .Append(_privledgesUpdateFromAddress & " Boolean NULL, ")
                .Append(_privledgesUpdateJobTypes & " Boolean NULL, ")
                .Append(_privledgesUpdateTasks & " Boolean NULL, ")
                .Append(_privledgesUpdateVehicles & " Boolean NULL, ")
                .Append(_privledgesUpdateEquipment & " Boolean NULL, ")
                .Append("PRIMARY KEY(" & _privledgesMember & ")")
                .Append("FOREIGN KEY(" & _privledgesMember & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE);")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreatePasswordTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & PasswordTableName & "(")
                .Append(_passwordMember & " VARCHAR(8) Not NULL, ")
                .Append(_passwordPassword & " VARCHAR(350) NULL, ")
                .Append("PRIMARY KEY(" & _passwordMember & ")")
                .Append("FOREIGN KEY(" & _passwordMember & ") REFERENCES " & MemberDetailsTableName & "(" & _memberDetailsID & ") On UPDATE CASCADE On DELETE CASCADE);")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateTasksTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & TasksTableName & "( ")
                .Append(_taskTask & " VARCHAR(100) Not NULL, ")
                .Append(_taskTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _taskTask & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateVehiclesTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & VehiclesTableName & "( ")
                .Append(_vehicleVehcile & " VARCHAR(100) Not NULL, ")
                .Append(_vehicleTimestamp & " DATETIME Not NULL, ")
                .Append("PRIMARY KEY(" & _vehicleVehcile & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function CreateVehiclesUsedTableQuery() As String
            Dim query As New StringBuilder
            With query
                .Append("CREATE TABLE If Not EXISTS " & VehiclesUsedTableName & "( ")
                .Append(_vehicleUsedEventNumber & " VARCHAR(10) Not NULL, ")
                .Append(_vehicleUsedVehicle & " VARCHAR(50) Not NULL, ")
                .Append("PRIMARY KEY(" & _vehicleUsedEventNumber & ", " & _vehicleUsedVehicle & "), ")
                .Append("FOREIGN KEY(" & _vehicleUsedEventNumber & ") REFERENCES " & DebriefDataTableName & "(" & _debriefDataEventNumber & ") ")
                .Append(");")
            End With
            Return query.ToString()
        End Function

        Private Shared Function DatabaseTablesQuery() As String
            Return "Select name FROM sqlite_master WHERE type='table';"
        End Function

        Private Shared Function EnableForeignKeysQuery() As String
            Return "PRAGMA foreign_keys = ON;"
        End Function

        Private Shared Function InsertIntoMemberDetailsQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("INSERT INTO ")
                .Append(MemberDetailsTableName)
                .Append("(")
                .Append(_memberDetailsID & ", ")
                .Append(_memberDetailsSurname & ", ")
                .Append(_memberDetailsFirstName & ", ")
                .Append(_memberDetailsEmailAddress & ", ")
                .Append(_memberDetailsPosition & ", ")
                .Append(_memberDetailsStatus & ") VALUES (")
                .Append("@" & _memberDetailsID & ", ")
                .Append("@" & _memberDetailsSurname & ", ")
                .Append("@" & _memberDetailsFirstName & ", ")
                .Append("@" & _memberDetailsEmailAddress & ", ")
                .Append("@" & _memberDetailsPosition & ", ")
                .Append("@" & _memberDetailsStatus & ");")
            End With

            Return query.ToString()
        End Function

        Private Shared Function UpdateMemberDetailsQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("UPDATE ")
                .Append(MemberDetailsTableName)
                .Append(" SET ")
                .Append(_memberDetailsID & " = @" & _memberDetailsID & ", ")
                .Append(_memberDetailsSurname & " = @" & _memberDetailsSurname & ", ")
                .Append(_memberDetailsFirstName & " = @" & _memberDetailsFirstName & ", ")
                .Append(_memberDetailsEmailAddress & " = @" & _memberDetailsEmailAddress & ", ")
                .Append(_memberDetailsPosition & " = @" & _memberDetailsPosition & ", ")
                .Append(_memberDetailsStatus & " = @" & _memberDetailsStatus)
                .Append(" WHERE " & _memberDetailsID & " = @" & _memberDetailsOriginalId & ";")
            End With

            Return query.ToString()
        End Function

        Private Shared Function DeleteMemberDetailsQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("DELETE FROM ")
                .Append(MemberDetailsTableName)
                .Append(" WHERE " & _memberDetailsID & " = @" & _memberDetailsID & ";")
            End With

            Return query.ToString()
        End Function

        Private Shared Function InsertIntoPrivledgesQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("INSERT INTO ")
                .Append(PrivledgesTableName)
                .Append("(")
                .Append(_privledgesMember & ", ")
                .Append(_privledgesCreateDebriefs & ", ")
                .Append(_privledgesAssignPrivledges & ", ")
                .Append(_privledgesResetOwnPassword & ", ")
                .Append(_privledgesResetOthersPassword & ", ")
                .Append(_privledgesCreateNewMember & ", ")
                .Append(_privledgesUpdateSelf & ", ")
                .Append(_privledgesUpdateAnotherMember & ", ")
                .Append(_privledgesDeleteMember & ", ")
                .Append(_privledgesUpdateEmailReceipients & ", ")
                .Append(_privledgesUpdateMailServer & ", ")
                .Append(_privledgesUpdateNetworkCredentials & ", ")
                .Append(_privledgesUpdateClientSettings & ", ")
                .Append(_privledgesUpdateFromAddress & ", ")
                .Append(_privledgesUpdateJobTypes & ", ")
                .Append(_privledgesUpdateTasks & ", ")
                .Append(_privledgesUpdateVehicles & ", ")
                .Append(_privledgesUpdateEquipment & ") VALUES (")
                .Append("@" & _privledgesMember & ", ")
                .Append("@" & _privledgesCreateDebriefs & ", ")
                .Append("@" & _privledgesAssignPrivledges & ", ")
                .Append("@" & _privledgesResetOwnPassword & ", ")
                .Append("@" & _privledgesResetOthersPassword & ", ")
                .Append("@" & _privledgesCreateNewMember & ", ")
                .Append("@" & _privledgesUpdateSelf & ", ")
                .Append("@" & _privledgesUpdateAnotherMember & ", ")
                .Append("@" & _privledgesDeleteMember & ", ")
                .Append("@" & _privledgesUpdateEmailReceipients & ", ")
                .Append("@" & _privledgesUpdateMailServer & ", ")
                .Append("@" & _privledgesUpdateNetworkCredentials & ", ")
                .Append("@" & _privledgesUpdateClientSettings & ", ")
                .Append("@" & _privledgesUpdateFromAddress & ", ")
                .Append("@" & _privledgesUpdateJobTypes & ", ")
                .Append("@" & _privledgesUpdateTasks & ", ")
                .Append("@" & _privledgesUpdateVehicles & ", ")
                .Append("@" & _privledgesUpdateEquipment & ");")
            End With

            Return query.ToString()
        End Function

        Private Shared Function UpdatePrivledgesQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("UPDATE ")
                .Append(PrivledgesTableName)
                .Append(" SET ")
                .Append(_privledgesMember & " = @" & _privledgesMember & ", ")
                .Append(_privledgesCreateDebriefs & " = @" & _privledgesCreateDebriefs & ", ")
                .Append(_privledgesAssignPrivledges & " = @" & _privledgesAssignPrivledges & ", ")
                .Append(_privledgesResetOwnPassword & " = @" & _privledgesResetOwnPassword & ", ")
                .Append(_privledgesResetOthersPassword & " = @" & _privledgesResetOthersPassword & ", ")
                .Append(_privledgesCreateNewMember & " = @" & _privledgesCreateNewMember & ", ")
                .Append(_privledgesUpdateSelf & " = @" & _privledgesUpdateSelf & ", ")
                .Append(_privledgesUpdateAnotherMember & " = @" & _privledgesUpdateAnotherMember & ", ")
                .Append(_privledgesDeleteMember & " = @" & _privledgesDeleteMember & ", ")
                .Append(_privledgesUpdateEmailReceipients & " = @" & _privledgesUpdateEmailReceipients & ", ")
                .Append(_privledgesUpdateMailServer & " = @" & _privledgesUpdateMailServer & ", ")
                .Append(_privledgesUpdateNetworkCredentials & " = @" & _privledgesUpdateNetworkCredentials & ", ")
                .Append(_privledgesUpdateClientSettings & " = @" & _privledgesUpdateClientSettings & ", ")
                .Append(_privledgesUpdateFromAddress & " = @" & _privledgesUpdateFromAddress & ", ")
                .Append(_privledgesUpdateJobTypes & " = @" & _privledgesUpdateJobTypes & ", ")
                .Append(_privledgesUpdateTasks & " = @" & _privledgesUpdateTasks & ", ")
                .Append(_privledgesUpdateVehicles & " = @" & _privledgesUpdateVehicles & ", ")
                .Append(_privledgesUpdateEquipment & " = @" & _privledgesUpdateEquipment)
                .Append(" WHERE " & _privledgesMember & " = @" & _privledgesOriginalId & ";")
            End With

            Return query.ToString()
        End Function

        Private Shared Function DeletePrivledgesQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("DELETE FROM ")
                .Append(PrivledgesTableName)
                .Append(" WHERE " & _privledgesMember & " = @" & _privledgesMember & ";")
            End With

            Return query.ToString()
        End Function

        Private Shared Function InsertIntoPasswordQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("INSERT INTO ")
                .Append(PasswordTableName)
                .Append("(")
                .Append(_passwordMember & ", ")
                .Append(_passwordPassword & ") VALUES (")
                .Append("@" & _passwordMember & ", ")
                .Append("@" & _passwordPassword & ");")
            End With

            Return query.ToString()
        End Function

        Private Shared Function UpdatePasswordQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("UPDATE ")
                .Append(PasswordTableName)
                .Append(" SET ")
                .Append(_passwordMember & " = @" & _passwordMember)
                .Append(_passwordPassword & " = @" & _passwordPassword)
                .Append(" WHERE " & _passwordMember & " = @" & _passwordOriginalId & ";")
            End With

            Return query.ToString()
        End Function

        Private Shared Function DeletePasswordQuery() As String
            Dim query As New StringBuilder

            With query
                .Append("DELETE FROM ")
                .Append(PasswordTableName)
                .Append(" WHERE " & _passwordMember & " = @" & _passwordMember & ";")
            End With

            Return query.ToString()
        End Function
#End Region
    End Class
End Namespace