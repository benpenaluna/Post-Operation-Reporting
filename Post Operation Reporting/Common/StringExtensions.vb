Option Strict On

Imports System.Runtime.CompilerServices

Namespace Common
    Public Module StringExtensions
        <Extension()>
        Public Function RemoveWhitespace(fullString As String) As String
            Return New String(fullString.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray())
        End Function
    End Module
End Namespace
