Option Strict On

Namespace Settings.Privledges
    Public Class MembersPrivledges
        Inherits Privledges

        Public Sub New()
            MyBase.Initialise(Me)
        End Sub

        Public Overrides ReadOnly Property CanUpdate As Boolean
            Get
                Return MyBase.MayUpdate(Me)
            End Get
        End Property

        Public Property CreateNewMember As Boolean
        Public Property UpdateSelf As Boolean
        Public Property UpdateAnotherMember As Boolean
        Public Property DeleteMember As Boolean
    End Class
End Namespace
