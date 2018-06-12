Option Strict On

Imports System.Reflection

Namespace Comparison

    Public Class Comparison

        Public Overloads Shared Function Equals(Of T)(obj1 As T, obj2 As T, prop As PropertyInfo) As Boolean
            Return Equals(obj1, obj2, New PropertyInfo() {prop})
        End Function

        Public Overloads Shared Function Equals(Of T)(obj1 As T, obj2 As T, properties As IEnumerable(Of PropertyInfo)) As Boolean
            For Each prop As PropertyInfo In properties
                ' Make sure that prop is a member of T, if not throw an exception
                Try
                    Call GetType(T).GetProperty(prop.Name)
                Catch ex As NullReferenceException
                    Throw
                End Try

                Dim obj1Null, obj2Null As Boolean

                Try
                    prop.GetValue(obj1, Nothing)
                Catch ex As Exception
                    obj1Null = True
                End Try

                Try
                    prop.GetValue(obj2, Nothing)
                Catch ex As Exception
                    obj2Null = True
                End Try

                If obj1Null Or obj2Null Then
                    Return obj1Null = obj2Null
                End If

                Dim val1 = CType(prop.GetValue(obj1, Nothing), IComparable)
                Dim val2 = prop.GetValue(obj2, Nothing)

                If val1.CompareTo(val2) <> 0 Then
                    Return False
                End If
            Next

            Return True
        End Function
    End Class
End Namespace