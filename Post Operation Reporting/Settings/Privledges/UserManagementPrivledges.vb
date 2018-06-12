Option Strict On

Namespace Settings.Privledges
    Public Class UserManagementPrivledges
        Inherits Privledges

        Public Sub New()
            MyBase.Initialise(Me)
        End Sub

        Public Overrides ReadOnly Property CanUpdate As Boolean
            Get
                Return MyBase.MayUpdate(Me)
            End Get
        End Property

        Public Property AssignPrivledges As Boolean
        Public Property ResetOwnPassword As Boolean
        Public Property ResetOthersPassword As Boolean
    End Class
End Namespace