Option Strict On

Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mime

Imports System.IO
Imports System.Text
Imports System.Threading.Tasks

Public Class frmEmailReport
    ''Instantiate links to other classes
    'Dim _objBusiness As New DebriefBusiness

    ''Instantiate a string to store the the data, members Email addresses
    'Dim _strData() As String
    'Dim _strMembersAttending As New List(Of Member)
    'Dim _strMembersEmail(,) As String

    ''Instantiate a boolean to indicate that the message has been sent
    'Dim _blnMessageSent As Boolean = False

    'Private Async Sub frmEmailReport_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    'Change the cursor to the wait cursor
    '    Me.Cursor = Cursors.WaitCursor

    '    'Retrieve the data
    '    Dim tasks(2) As Task
    '    _strData = _objBusiness.RetrieveDataToEmail()
    '    _strMembersAttending = Await _objBusiness.RetrieveMembersInAttendanceAsync()
    '    _strMembersEmail = _objBusiness.RetrieveMembersEmail()


    '    'Start the timer, so that the E-mail will start sending when this event has finished
    '    Timer1.Start()

    '    'Now that the form is loaded, change the cursor back to pointer
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub frmEmailReport_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Me.Dispose()
    'End Sub


    'Private Async Sub Timer1_TickAsync(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
    '    'Stop the Timer
    '    Timer1.Stop()

    '    'Create a list to store the members whose E-mail address was incorrect
    '    Dim unknownEmailAddress As New List(Of String)

    '    'Make sure that there is a network connect available
    '    If My.Computer.Network.IsAvailable = True Then
    '        'Write the text of the E-mail
    '        Dim messageBody As New StringBuilder

    '        With messageBody
    '            ' Header
    '            .Append("<!DOCTYPE HTML PUBLIC \""-//W3C//DTD HTML 4.0 Transitional//EN\"">" &
    '                               "<HTML><HEAD><META http-equiv=Content-Type content=\""text/html; charset=iso-8859-1\"">" &
    '                               "</HEAD><BODY><DIV><FONT face=Courier New color=#000000 size=2>")

    '            .Append("<b>VICTORIA STATE EMEGENCY SERVICE - SUNBURY UNIT</b><br>" &
    '                    "<b>POST OPERATIONS DEBRIEF REPORT</b><br><br><br>")

    '            .Append("<b>*** JOB DETAILS ***</b><br><br>")

    '            .Append("<b>EVENT NUMBER:</b><br><p>" & _strData(0) & "</p><br>")

    '            .Append("<b>START DATE/TIME:</b><br><p>" & _strData(1) & "</p><br>")

    '            .Append("<b>FINISH DATE/TIME:</b><br><p>" & _strData(2) & "</p><br>")

    '            .Append("<b>JOB TYPE:</b><br><p>" & _strData(3) & "</p><br><br>")

    '            .Append("<b>*** OPERATIONAL ***</b>" & "<br><br>")

    '            .Append("<b>SES COMMANDER:</b>&nbsp;<p>" & _strData(4) & "</p><br>")

    '            .Append("<b>CREW LEADER:</b><br><p>" & _strData(5) & "</p><br>")

    '            .Append("<b>FIRST AIDER:</b><br><p>" & _strData(16) & "</p><br>")

    '            .Append("<b>BRIEF JOB DESCRIPTION:</b>" & "<br><p>" & _strData(6) & "</p><br>")

    '            .Append("<b>WHAT WAS THE PLAN:</b>" & "<br><p>" & _strData(7) & "</p><br>")

    '            .Append("<b>WAS THE PLAN CLEAR TO ALL:</b><br><p>" & _strData(8) & "</p><br>")

    '            .Append("<b>CREW LEADER - WAS THERE A PLAN B:</b><br><p>" & _strData(9) & "</p><br><br>")

    '            .Append("<b>*** SAFETY/TRAINING ***</b><br><br>")

    '            .Append("<b>SAFETY ADVISOR:</b><p>" & _strData(10) & "</p><br>")

    '            .Append("<b>SAFETY CONCERNS:</b>" & "<br><p>" & _strData(11) & "</p><br>")

    '            .Append("<b>WHAT SKILLS WOULD HAVE MADE THE JOB EASIER: </b>" & "<br><p>" & _strData(12) & "</p><br>")

    '            .Append("<b>WAS THE CREW ADEQUATELY TRAINED: </b><p>" & _strData(13) & "</p><br><br>")

    '            .Append("<b>*** LOGISTICS ***</b><br><br>")

    '            .Append("<b>VEHICLES USED: </b>")
    '        End With


    '        'Add the vehicles used
    '        If _strData.Length - 1 >= 17 Then
    '            For intCount = 17 To _strData.Length - 1
    '                messageBody.Append("<p>" & _strData(intCount) & "</p>")

    '                'If intCount <> _strData.Length - 1 Then
    '                '    messageBody.Append(", ")
    '                'End If
    '            Next

    '            'Insert a new line
    '            'messageBody.Append("<br>")
    '        Else
    '            messageBody.Append("<p>Nil</p>" & "<br>")
    '        End If

    '        'Complete the message body
    '        With messageBody
    '            .Append("<br><b>ISSUES FOR VEHICLES OR EQUIPMENT:</b><br><p>" & _strData(14) & "</p><br>")

    '            .Append("<b>EQUIPMENT THAT WOULD HAVE MADE THE JOB EASIER:</b>" & "<br><p>" & _strData(15) & "</p><br><br>")

    '            .Append("<b>*** MEMBERS ATTENDING ***<b><br><br>")

    '            '.Append("MEMBERS IN ATTENDANCE&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" &
    '            '              "TASK UNDERTAKEN<br>")
    '        End With

    '        ' Insert membes attending
    '        messageBody.Append("<table border=""1"" style=""width:100%"">")

    '        messageBody.Append("<tr><td><b>MEMBERS IN ATTENDANCE</b></td><td><b>TASK UNDERTAKEN</b></td></tr>")

    '        'For intCount = 0 To _strMembersAttending.GetUpperBound(1)
    '        For Each member As Member In _strMembersAttending
    '            With messageBody
    '                .Append("<tr>")
    '                .Append("<td>" & _strMembersAttending(0, intCount) & "</td>")
    '                .Append("<td>" & _strMembersAttending(1, intCount) & "</td>")
    '                .Append("</tr>")
    '            End With
    '        Next

    '        messageBody.Append("</table><br>")

    '        'Finishing putting in the HTML code
    '        messageBody.Append("</FONT></DIV></BODY></HTML>")


    '        'E-mail the debrief
    '        Dim testMessage As New System.Net.Mail.MailMessage
    '        Dim fromAddress As New System.Net.Mail.MailAddress("sunbury@ses.vic.gov.au", "Unit - Sunbury")
    '        'Dim ToAddress As New System.Net.Mail.MailAddress("sunbury@ses.vic.gov.au", "Unit - Sunbury")
    '        Dim BccAddress As System.Net.Mail.MailAddress
    '        Dim objSmtpClient As New SmtpClient("smtp.gmail.com", 587)
    '        objSmtpClient.Credentials = New NetworkCredential("sunbury5850", "PythoN98*")
    '        objSmtpClient.EnableSsl = True
    '        objSmtpClient.Timeout = 60000
    '        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

    '        'Change the message body to plain text
    '        Dim mimeType As New System.Net.Mime.ContentType("text/html")
    '        'Dim alternate As AlternateView = AlternateView.CreateAlternateViewFromString(body, mimeType)
    '        Dim alternate As AlternateView = AlternateView.CreateAlternateViewFromString(messageBody.ToString(), mimeType)

    '        ' From address
    '        testMessage.From = fromAddress

    '        'To address
    '        If System.Diagnostics.Debugger.IsAttached() Then
    '            'testMessage.To.Add("penalunaben@gmail.com")
    '            'testMessage.Bcc.Add(New System.Net.Mail.MailAddress("bap_83@bigpond.net.au", "Ben Penaluna"))
    '            testMessage.Bcc.Add(New System.Net.Mail.MailAddress("benjamin.penaluna@members.ses.vic.gov.au", "Benjamin Penaluna"))
    '        Else
    '            testMessage.To.Add(New System.Net.Mail.MailAddress("sunbury@ses.vic.gov.au", "Unit - Sunbury"))

    '            For intCount = 0 To _strMembersEmail.GetUpperBound(1)
    '                If _strMembersEmail(1, intCount) <> "" Then
    '                    BccAddress = New System.Net.Mail.MailAddress(_strMembersEmail(1, intCount), _strMembersEmail(0, intCount))
    '                    Try
    '                        testMessage.Bcc.Add(BccAddress)
    '                    Catch ex As FormatException
    '                        unknownEmailAddress.Add(_strMembersEmail(0, intCount))
    '                    End Try
    '                End If
    '            Next
    '        End If
    '        testMessage.Subject = "Post Operation Debrief - " & _strData(0)
    '        testMessage.Body = messageBody.ToString()
    '        testMessage.Priority = MailPriority.Normal
    '        testMessage.AlternateViews.Add(alternate)
    '        testMessage.IsBodyHtml = False
    '        Try
    '            objSmtpClient.Send(testMessage)

    '            Await objSmtpClient.SendMailAsync(testMessage)
    '            'Set the message sent boolean to true
    '            _blnMessageSent = True
    '        Catch ex As Exception
    '            MessageBox.Show(ex.ToString)
    '        Finally
    '            objSmtpClient = Nothing
    '            fromAddress = Nothing
    '        End Try
    '    Else 'There is no network connection available, save the data for transmission next time the program starts

    '    End If

    '    'Tell the user if the message transmission was successful
    '    If _blnMessageSent = True And unknownEmailAddress.Count = 0 Then
    '        MsgBox("The Post Operation Debrief has been sucessfully submitted.", MsgBoxStyle.Information, "E-mail Submission")
    '    ElseIf _blnMessageSent = True And unknownEmailAddress.Count > 0 Then
    '        Dim messageText As String = "The Post Operation Debrief has been sucessfully submitted, but was unable To be sent To the following members:\r\n"
    '        For Each name As String In unknownEmailAddress
    '            messageText += name & "\r\n"
    '        Next

    '        MsgBox(messageText, MsgBoxStyle.Information, "E-mail Submission")
    '    Else 'The mesaage was not sent successfully
    '        MsgBox("The Post Operation Debrief was not successully submitted. Please try again", MsgBoxStyle.Information,
    '               "E-mail Submission")
    '    End If

    '    'Close the form
    '    Me.Close()
    'End Sub
End Class