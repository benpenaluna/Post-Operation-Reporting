Option Strict On

Imports PostOpRep.Common
Imports PostOpRep.Settings.Privledges
Imports System.Reflection
Imports System.Runtime.ExceptionServices

Namespace Settings
    Public Class Permissions
        Private _member As Member

        Public Property Member As Member
            Get
                Return _member
            End Get
            Private Set(value As Member)
                _member = value
            End Set
        End Property

        Public Property CreateDebriefs As Boolean

        Public Property UserManagementPrivledges As UserManagementPrivledges

        Public Property MembersPrivledges As MembersPrivledges

        Public Property EmailSettingsPrivledges As EmailSettingsPrivledges

        Public Property JobTaskPrivledges As JobTaskPrivledges

        Public Property VehiclesEquipmentPrivledges As VehiclesEquipmentPrivledges

        Sub New()
            Initialise()
        End Sub

        Sub New(member As Member)
            Initialise(member)
        End Sub

        Sub New(permissions As Permissions)
            For Each prop As PropertyInfo In GetType(Permissions).GetProperties()
                prop.SetValue(Me, prop.GetValue(permissions))
            Next
        End Sub

        Sub New(member As Member, permissions As Permissions)
            HandleExceptions(member, permissions)

            Me.Member = member

            Dim nonMemberProps = (From prop In GetType(Permissions).GetProperties
                                  Where prop.PropertyType IsNot GetType(Member)).ToList()
            For Each prop As PropertyInfo in nonMemberProps
                prop.SetValue(Me, prop.GetValue(permissions))
            Next
        End Sub

        Private Shared Sub HandleExceptions(member As Member, permissions As Permissions)
            If member Is Nothing
                Throw New NullReferenceException(My.Resources.PermissionsMemberNullExceptionMessage)
            End If

            If permissions Is Nothing
                Throw New NullReferenceException(My.Resources.PermissionsPermissionsNullExceptionMessage)
            End If
        End Sub

        Private Sub Initialise(Optional mmbr As Member = Nothing)
            Me.Member = If(mmbr Is Nothing, New Member(), mmbr)

            Dim myProps = Me.GetType.GetProperties().ToList()

            Dim boolProps = (From prop In myProps Where prop.GetType = GetType(Boolean) Select prop).ToList()
            For Each prop As PropertyInfo In boolProps
                prop.SetValue(Me, False)
            Next

            Dim privProps = (From prop In myProps Where prop.PropertyType.BaseType = GetType(Privledges.Privledges) Select prop).ToList()
            For Each prop As PropertyInfo In privProps
                Dim construtor As ConstructorInfo = prop.PropertyType.GetConstructor(Type.EmptyTypes)
                prop.SetValue(Me, construtor.Invoke(New Object() {}))
            Next
        End Sub
    End Class
End Namespace
