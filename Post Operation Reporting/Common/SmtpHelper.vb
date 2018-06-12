Option Strict On

Imports System.Configuration
Imports System.IO
Imports System.Net
Imports System.Net.Configuration
Imports System.Net.Sockets
Imports System.Text

Namespace Common

    Public Class SmtpHelper

        Public Shared Function IsValidSmtpServer(hostName As String, Optional ByVal port As Integer = 25) As Boolean
            Try
                Return TestConnection(hostName)
            Catch ex As Exception
                Return False
            End Try
        End Function

        Private Shared Function TestConnection(hostName As String) As Boolean
            Dim smtpTest = New TcpClient()
            Try
                smtpTest.Connect(hostName, 25)
                If smtpTest.Connected Then
                    Using ns As NetworkStream = smtpTest.GetStream()
                        Using sr = New StreamReader(ns)
                            If sr.ReadLine().Contains("220") Then
                                Return True
                            End If
                        End Using
                    End Using
                End If
            Finally
                smtpTest.Close()
            End Try

            Return False
        End Function

        Public Shared Function TestConnection(ByVal config As Configuration) As Boolean
            Dim mailSettings = CType(config.GetSectionGroup("system.net/mailSettings"), MailSettingsSectionGroup)
            If mailSettings Is Nothing Then
                Throw New ConfigurationErrorsException("The system.net/mailSettings configuration section group could not be read.")
            End If

            Return TestConnection(mailSettings.Smtp.Network.Host, mailSettings.Smtp.Network.Port)
        End Function

        Public Shared Function TestConnection(smtpServerAddress As String, port As Integer) As Boolean
            Dim hostEntry As IPHostEntry = Dns.GetHostEntry(smtpServerAddress)
            Dim endPoint = New IPEndPoint(hostEntry.AddressList(0), port)
            Using tcpSocket = New Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                tcpSocket.Connect(endPoint)
                If Not CheckResponse(tcpSocket, 220) Then
                    Return False
                End If

                SendData(tcpSocket, String.Format("HELO {0}\r\n", Dns.GetHostName()))
                If Not CheckResponse(tcpSocket, 250) Then
                    Return False
                End If

                Return True
            End Using
        End Function

        Private Shared Function CheckResponse(socket As Socket, expectedCode As Integer) As Boolean
            While socket.Available = 0
                Threading.Thread.Sleep(100)
            End While

            Dim responseArray(1024) As Byte
            socket.Receive(responseArray, 0, socket.Available, SocketFlags.None)
            Dim responseData = Encoding.ASCII.GetString(responseArray)
            Dim responseCode = Convert.ToInt32(responseData.Substring(0, 3))

            Return responseCode = expectedCode
        End Function

        Private Shared Sub SendData(socket As Socket, data As String)
            Dim dataArray() As Byte = Encoding.ASCII.GetBytes(data)
            socket.Send(dataArray, 0, dataArray.Length, SocketFlags.None)
        End Sub

    End Class
End Namespace