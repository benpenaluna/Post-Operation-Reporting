Option Strict On

Imports System.Reflection

Namespace Settings.Privledges
    Public Class EmailSettingsPrivledges
        Inherits Privledges

        Public Sub New()
            MyBase.Initialise(Me)
        End Sub

        Public Overrides ReadOnly Property CanUpdate As Boolean
            Get
                Return MyBase.MayUpdate(Me)
            End Get
        End Property

        Public Property UpdateEmailReceipients As Boolean
        Public Property UpdateMailServer As Boolean
        Public Property UpdateNetworkCredentials As Boolean
        Public Property UpdateClientSettings As Boolean
        Public Property UpdateFromAddress As Boolean

        Public Function Enabled() As Boolean
            Return MyBase.GetMyProperties(Me).Aggregate(False, Function(current, prop) current OrElse CType(prop.GetValue(Me), Boolean))
        End Function
    End Class
End Namespace
