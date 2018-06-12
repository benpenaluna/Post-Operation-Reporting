Option Strict On

Imports Microsoft.VisualBasic
Imports PostOpRep.Database

Namespace Common
    Public Class DebriefDeployment : Inherits Debrief
        Private _eventNumber As String = ""

        Public Overrides Property EventNumber As String
            Get
                Return _eventNumber
            End Get
            Set(value As String)
                If IsNumeric(Strings.Right(value, 4)) Then
                    _eventNumber = value
                    Return
                End If

                _eventNumber = value & DataDbConnection.NumberOfDeployments(value).ToString("0000")
            End Set
        End Property

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
            Me.EventNumber = eventNo
            MyBase.InitialiseProperties()
        End Sub
    End Class
End Namespace
