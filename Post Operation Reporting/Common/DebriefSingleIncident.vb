Option Strict On

Imports System.Xml

Namespace Common

    Public Class DebriefSingleIncident : Inherits Debrief
        Private _eventNumber As EventNumber

        Public Overrides Property EventNumber As String
            Get
                Return _eventNumber.ToString()
            End Get
            Set(value As String)
                Try
                    _eventNumber = New EventNumber(value)
                Catch ex As FormatException
                    Throw
                End Try
            End Set
        End Property


#Region "Constructors"

        Sub New()
            InitialiseFromNothing("")
        End Sub

        Sub New(eventNumber As String)
            InitialiseFromNothing(eventNumber)
        End Sub

        Sub New(debrief As Debrief, Optional eventNumber As String = "")
            Me.EventNumber = eventNumber

            If debrief IsNot Nothing Then
                MyBase.InstantiateFromExisting(debrief)
            Else
                InitialiseFromNothing(eventNumber)
            End If
        End Sub

        Private Sub InitialiseFromNothing(eventNo As String)
            Try
                Me.EventNumber = eventNo
            Catch ex As Exception
                Throw
            End Try
            MyBase.InitialiseProperties()
        End Sub

#End Region
    End Class
End Namespace