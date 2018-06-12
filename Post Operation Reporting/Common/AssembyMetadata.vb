Option Strict On

Namespace Common
    Public Class AssembyMetadata(Of T)
        Public Shared Function DerivedClasses() As IEnumerable(Of T)
            Return GetType(T).Assembly.
                              GetTypes().
                              Where(Function(t)
                                        Return t.IsSubclassOf(GetType(T)) AndAlso Not t.IsAbstract
                                    End Function).
                              Select(Function(t)
                                         Return CType(Activator.CreateInstance(t), T)
                                     End Function)
        End Function
    End Class
End Namespace
