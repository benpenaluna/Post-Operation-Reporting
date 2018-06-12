Option Strict On

Imports System.ComponentModel
Imports System.Threading.Tasks
Imports PostOpRep.Common
Imports PostOpRep.Database

Namespace Settings
    Public Module Settings

        Private _allPermissions As List(Of Permissions)
        Private _currentUserPermissions As Permissions
        Private _equipment As List(Of String)
        Private _jobTypes As List(Of String)
        Private _loggedInMember As Member
        Private _memberDetails As List(Of Member)
        Private _tasks As List(Of String)
        Private _vehicles As List(Of String)

        Property AllPermissions As List(Of Permissions)
            Get
                Return _allPermissions
            End Get
            Set
                _allPermissions = Value
                OnPermissionsChanged()
            End Set
        End Property

        Property CurrentUserPermissions As Permissions
            Get
                Return _currentUserPermissions
            End Get
            Set
                _currentUserPermissions = Value
                OnCurrentUserChanged()
            End Set
        End Property

        ReadOnly Property CurrentMemberDetails As List(Of Member)
            Get
                Return (From member In _memberDetails
                        Where member.Status <> 5
                        Order By member.Surname, member.FirstName
                        Select member).ToList()
            End Get
        End Property

        Property EmailSettings As EmailSettings

        Property Equipment As List(Of String)
            Get
                Return _equipment
            End Get
            Set
                _equipment = Value
                OnEquipmentChanged()
            End Set
        End Property

        Property JobTypes As List(Of String)
            Get
                Return _jobTypes
            End Get
            Set
                _jobTypes = Value
                OnJobTypesChanged()
            End Set
        End Property

        Property LoggedInMember As Member
            Get
                Return _loggedInMember
            End Get
            Set
                _loggedInMember = Value
                OnLoggedInMemberChanged()
            End Set
        End Property

        Property MemberDetails As List(Of Member)
            Get
                Return (From member In _memberDetails
                        Order By member.Surname, member.FirstName
                        Select member).ToList()
            End Get
            Set
                _memberDetails = Value
                _memberDetails.Sort()
                OnMemberDetailsChanged()
            End Set
        End Property


        ReadOnly Property ResignedMemberDetails As List(Of Member)
            Get
                Return (From member In _memberDetails
                        Where member.Status = 5
                        Order By member.Surname, member.FirstName
                        Select member).ToList()
            End Get
        End Property

        Property Tasks As List(Of String)
            Get
                Return _tasks
            End Get
            Set
                _tasks = Value
                OnTasksChanged()
            End Set
        End Property

        Property Vehicles As List(Of String)
            Get
                Return _vehicles
            End Get
            Set
                _vehicles = Value
                OnVehiclesChanged()
            End Set
        End Property


        Public Event CurrentUserChanged As EventHandler
        Public Event EquipmentChanged As EventHandler
        Public Event JobTypeChanged As EventHandler
        Public Event LoggedInMemberChanged As EventHandler
        Public Event MemberDetailsChanged As EventHandler
        Public Event PermissionsChanged As EventHandler
        Public Event TasksChanged As EventHandler
        Public Event VehiclesChanged As EventHandler


        Sub New()

        End Sub


        Public Async Function InitialiseAsync(worker As BackgroundWorker, e As DoWorkEventArgs) As Task
            Dim state As New InitialisationState

            Await RetrieveSettings(worker, state).ConfigureAwait(False)
        End Function

        Private Async Function RetrieveSettings(worker As BackgroundWorker, state As InitialisationState) As Task
            InitialisationState.CurrentTask = "Retrieving the Settings"
            worker.ReportProgress(0, state)

            Dim retrieveTasks As New List(Of Task)

            retrieveTasks.Add(RetriveMemberDetails())
            retrieveTasks.Add(RetrievePermissions())

            Await Task.WhenAll(retrieveTasks).ConfigureAwait(False)

            EmailSettings = DataDbConnection.RetrieveEmailSettings()
            JobTypes = DataDbConnection.RetrieveJobTypes()
            Tasks = DataDbConnection.RetrieveTasks()
            Vehicles = DataDbConnection.RetrieveVehicles()
            Equipment = DataDbConnection.RetrieveEquipment()
        End Function

        Private Async Function RetriveMemberDetails() As Task
            MemberDetails = Await DataDbConnection.RetrieveMemberDetailsAsync().ConfigureAwait(False)
        End Function

        Private Async Function RetrievePermissions() As Task
            AllPermissions = Await DataDbConnection.RetrieveMemberPrivledgesAsync().ConfigureAwait(False)
        End Function

        Public Function RetrieveMemberPrivledges(mmbr As Member) As Permissions
            Return (From permission In AllPermissions
                    Where permission.Member = mmbr
                    Select permission).ToList().FirstOrDefault()
        End Function

        Public Function MemberExists(memberId As String) As Boolean
            Return (From mmbr In MemberDetails
                    Where mmbr.Id = memberId).Count > 0
        End Function

        Public Function SetCurrentUser(memberId As String) As Boolean
            Dim userPermissions = (From p In AllPermissions
                                   Where p.Member.Id = memberId).ToList()

            If userPermissions.Count = 0 Then
                Return False
            End If

            CurrentUserPermissions = userPermissions.First()

            Return True
        End Function

        Private Sub OnCurrentUserChanged()
            If CurrentUserPermissions IsNot Nothing Then
                RaiseEvent CurrentUserChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnEquipmentChanged()
            If EquipmentChangedEvent IsNot Nothing Then
                RaiseEvent EquipmentChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnJobTypesChanged()
            If JobTypeChangedEvent IsNot Nothing Then
                RaiseEvent JobTypeChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnLoggedInMemberChanged()
            If LoggedInMemberChangedEvent IsNot Nothing Then
                RaiseEvent LoggedInMemberChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnMemberDetailsChanged()
            If MemberDetailsChangedEvent IsNot Nothing Then
                RaiseEvent MemberDetailsChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnPermissionsChanged()
            If AllPermissions IsNot Nothing Then
                RaiseEvent PermissionsChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnTasksChanged()
            If TasksChangedEvent IsNot Nothing Then
                RaiseEvent TasksChanged(Nothing, EventArgs.Empty)
            End If
        End Sub

        Private Sub OnVehiclesChanged()
            If VehiclesChangedEvent IsNot Nothing Then
                RaiseEvent VehiclesChanged(Nothing, EventArgs.Empty)
            End If
        End Sub
    End Module
End Namespace
