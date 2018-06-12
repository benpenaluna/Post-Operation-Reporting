Namespace Common
    Public Class EquipmentUse

        Public Property Duration As Integer
        Public Property Item As String
        Public Property MemberUsing As Member

        Public Sub New()
            Me.MemberUsing = New Member()
        End Sub

        Public Sub New(item As String, duration As Integer, memberUsing As Member)
            Me.Item = item
            Me.Duration = duration
            Me.MemberUsing = memberUsing
        End Sub
    End Class
End Namespace
