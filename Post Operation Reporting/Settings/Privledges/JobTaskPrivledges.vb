Option Strict On

Namespace Settings.Privledges
    Public Class JobTaskPrivledges
        Inherits Privledges

        Public Sub New()
            MyBase.Initialise(Me)
        End Sub

        Public Overrides ReadOnly Property CanUpdate As Boolean
            Get
                Return MyBase.MayUpdate(Me)
            End Get
        End Property

        Public Property UpdateJobTypes As Boolean
        Public Property UpdateTasks As Boolean
    End Class
End Namespace
