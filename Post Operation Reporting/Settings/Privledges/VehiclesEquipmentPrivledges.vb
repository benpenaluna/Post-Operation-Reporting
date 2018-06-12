Option Strict On

Namespace Settings.Privledges
    Public Class VehiclesEquipmentPrivledges
        Inherits Privledges

        Public Sub New()
            MyBase.Initialise(Me)
        End Sub

        Public Overrides ReadOnly Property CanUpdate As Boolean
            Get
                Return MyBase.MayUpdate(Me)
            End Get
        End Property

        Public Property UpdateVehicles As Boolean
        Public Property UpdateEquipment As Boolean
    End Class
End Namespace
