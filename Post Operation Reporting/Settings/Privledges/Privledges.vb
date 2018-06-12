Option Strict On

Imports System.Reflection

Namespace Settings.Privledges
    Public MustInherit Class Privledges
        Public MustOverride ReadOnly Property CanUpdate As Boolean

        Protected Sub Initialise(ByRef priv As Privledges)
            For Each prop As PropertyInfo In priv.GetType().GetProperties()
                If prop.GetType = GetType(Boolean) Then
                    prop.SetValue(priv, False)
                End If
            Next
        End Sub

        Protected Overridable Function MayUpdate(priv As Privledges) As Boolean
            Return GetMyProperties(priv).Any(Function(prop) CType(prop.GetValue(priv), Boolean) = True)
        End Function

        Protected Overridable Function GetMyProperties(priv As Privledges) As List(Of PropertyInfo)
            Return (From prop In priv.GetType.GetProperties()
                    Where prop.GetType = GetType(Boolean)
                    Select prop).ToList()
        End Function
    End Class
End Namespace