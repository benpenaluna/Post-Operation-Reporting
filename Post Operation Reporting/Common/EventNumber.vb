Namespace Common
    Public Class EventNumber

        Private _eventNumber As String

        Private ReadOnly _formatExceptionMessage = "Event numbers must be in the format [F/S][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]."

        Public Shared ReadOnly Property EventNumberLength As Integer = 10

        Public Property EventNumber As String
            Get
                Return _eventNumber
            End Get
            Set
                Dim test As Boolean? = CorrectFormat(Value)
                If test.HasValue AndAlso test = False Then
                    Throw New FormatException(_formatExceptionMessage)
                End If

                _eventNumber = If(test.HasValue, Value, "")
            End Set
        End Property

        Sub New()
            EventNumber = ""
        End Sub

        Sub New(eventNumber As String)
            Me.EventNumber = eventNumber
        End Sub

        Public Overrides Function ToString() As String
            Return EventNumber
        End Function

        Public Shared Function CorrectFormat(value As String) As Boolean?
            If value = String.Empty Then
                Return Nothing
            End If

            If value.Length <> EventNumberLength Then
                Return False
            End If

            Dim codes = New List(Of Char)(New Char() {"F"c, "S"c})
            If Not codes.Contains(Convert.ToChar(Left(value, 1))) Then
                Return False
            End If

            If Not IsNumeric(Right(value, EventNumberLength - 1)) Then
                Return False
            End If

            Return True
        End Function
    End Class
End Namespace