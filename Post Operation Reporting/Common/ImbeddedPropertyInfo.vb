Option Strict On

Imports System.Reflection

Namespace Common
    Public Class ImbeddedPropertyInfo
        Public Property BaseProperty As PropertyInfo
        Public Property ChildProperty As PropertyInfo

        Sub New(baseProp As PropertyInfo, childProp As PropertyInfo)
            Me.BaseProperty = baseProp
            Me.ChildProperty = childProp
        End Sub
    End Class
End Namespace
