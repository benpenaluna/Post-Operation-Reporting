Option Strict On

Imports System.Net
Imports System.Net.Mail
Imports PostOpRep.Common

Namespace Settings

    Public Class EmailSettings

        Enum TypeOfReceipient
            Bcc
            Cc
            Too
        End Enum

        Property AdditionalReceipients As Dictionary(Of Integer, Tuple(Of MailAddress, TypeOfReceipient))

        Property AllMemberReceipientType As TypeOfReceipient

        Property AllMemberReceive As Boolean

        Property FromAddress As MailAddress

        Property MailPriority As MailPriority

        Property MembersToReceive As Dictionary(Of Member, TypeOfReceipient)

        Property ShowPassword As Boolean

        Property SmtpClient As SmtpClient

        Sub New()
            AdditionalReceipients = New Dictionary(Of Integer, Tuple(Of MailAddress, TypeOfReceipient))
            AllMemberReceive = False
            MailPriority = New MailPriority
            MembersToReceive = New Dictionary(Of Member, TypeOfReceipient)
            AllMemberReceipientType = New TypeOfReceipient
            SmtpClient = New SmtpClient
            SmtpClient.Credentials = New NetworkCredential()
        End Sub

    End Class
End Namespace