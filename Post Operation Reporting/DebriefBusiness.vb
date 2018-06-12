'Option Strict On
Imports System.IO
Imports System.Net.Mail
Imports System.Xml.Serialization
Imports System.Text
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.Runtime.Remoting.Messaging
Imports PostOpRep.Common
Imports PostOpRep.Database
Imports PostOpRep.Settings

Public Class DebriefBusiness
    'Instantiate link to various classes
    ReadOnly _objPersistence As New DebriefPersistence

    'Instantiate a string to use as a substitute for the carriage return character Chr(13)
    Private Shared _strCarriageReturn As String = "<br>"
    Private Shared ReadOnly CacheDirectory As String

    Public Shared Property MemberDetails As List(Of Member)

    Shared Sub New()
        'Retrieve the member details, and cache in the MemberDetails property
        Dim memberDetailsCaller As New RetrieveMemberDetailsAsync(AddressOf DataDbConnection.RetrieveMemberDetailsAsync)
        memberDetailsCaller.BeginInvoke(AddressOf UpdateMemberDetails, Nothing)

        ' determine the cache directory
        CacheDirectory = Path.Combine(ApplicationFunctions.FilePath, "Cache")
    End Sub

    Private Delegate Function RetrieveMemberDetailsAsync() As Task(Of List(Of Member))

    Private Shared Sub UpdateMemberDetails(ByVal ar As IAsyncResult)
        Dim result = CType(ar, AsyncResult)
        Dim caller = CType(result.AsyncDelegate, RetrieveMemberDetailsAsync)

        MemberDetails = caller.EndInvoke(ar).Result
    End Sub


    Sub New()
    End Sub

    'Async Function SaveAndEmailNewDebriefAsync(ByVal strDebriefData() As String, ByVal strMembersAttending(,) As String) As Task
    Shared Async Function SaveAndEmailNewDebriefAsync(debriefSingleIncident As DebriefSingleIncident, progress As IProgress(Of String)) As Task
        'The purpose of this subroutine is to save the data for transmission and permanetly save it for future reference

        For Each prop As PropertyInfo In debriefSingleIncident.GetType().GetProperties()
            If prop.GetType Is GetType(String) Then
                prop.SetValue(debriefSingleIncident, CType(prop.GetValue(debriefSingleIncident, Nothing), String).Replace(vbCrLf, _strCarriageReturn))
            End If
        Next

        Await EmailDebriefAsync(debriefSingleIncident, progress).ConfigureAwait(False)

    End Function

    Function RetrieveDataToEmail() As String()
        Return _objPersistence.RetrieveNewDebriefData()
    End Function

    Async Function RetrieveMembersInAttendanceAsync() As Task(Of List(Of Member))
        'Retrive the members in attendance
        Dim strMembersAttending As List(Of String()) = Await _objPersistence.RetrieveNewMemberAttendingAsync(False).ConfigureAwait(False)

        Dim membersAttending As New List(Of Member)

        For Each attendingMember As String() In strMembersAttending
            Dim x = ExtractMember(attendingMember(0))

            For Each member In x
                If Not membersAttending.Contains(member) Then
                    membersAttending.Add(member)
                End If
            Next
        Next

        Return membersAttending
    End Function

    Private Function ExtractMember(attendingMemberId As String) As IEnumerable(Of Member)

        Return From member In MemberDetails
               Where member.Id = attendingMemberId
               Select member
    End Function

    'Private Async Function EmailDebriefAsync(strDebriefData() As String, strMembersAttending(,) As String) As Task(Of String)
    Public Shared Async Function EmailDebriefAsync(debrief As Debrief, progress As IProgress(Of String)) As Task(Of String)
        'Create a list to store the members whose E-mail address was incorrect
        Dim unknownEmailAddress As New List(Of String)

        ' Replace the carriage returns in DebriefSingleIncident with the HTML equivalent
        For Each prop As PropertyInfo In debrief.GetType().GetProperties()
            If prop.PropertyType Is GetType(String) Then
                prop.SetValue(debrief, CType(prop.GetValue(debrief, Nothing), String).Replace(vbCrLf, _strCarriageReturn))
            End If
        Next

        ' Update the user
        progress.Report("Preparing the E-mail Content")

        ' Define the require DateTime format
        Dim dateTimeFormat As String = "dd/MM/yyyy HH:mm"

        'Write the text of the E-mail
        Dim messageBody As New StringBuilder
        With messageBody
            ' Header
            .Append("<!DOCTYPE HTML PUBLIC \""-//W3C//DTD HTML 4.0 Transitional//EN\"">" & "<HTML><HEAD><META http-equiv=Content-Type content=\""text/html; charset=iso-8859-1\"">" & "</HEAD><BODY><DIV><FONT face=Courier New color=#000000 size=2>")

            .Append("<b>VICTORIA STATE EMEGENCY SERVICE - SUNBURY UNIT</b><br>" & "<b>POST OPERATIONS DEBRIEF REPORT</b><br><br><br>")

            .Append("<b>*** JOB DETAILS ***</b><br><br>")

            .Append("<b>EVENT NUMBER:</b><br><p>" & debrief.EventNumber & "</p><br>")

            .Append("<b>START DATE/TIME:</b><br><p>" & debrief.StartTime.ToString(dateTimeFormat) & "</p><br>")

            .Append("<b>FINISH DATE/TIME:</b><br><p>" & debrief.FinishTime.ToString(dateTimeFormat) & "</p><br>")

            .Append("<b>JOB TYPE:</b><br><p>" & debrief.JobType & "</p><br><br>")

            .Append("<b>*** OPERATIONAL ***</b>" & "<br><br>")

            .Append("<b>SES COMMANDER:</b>&nbsp;<p>" & debrief.SesCommander.ToString() & "</p><br>")

            .Append("<b>CREW LEADER:</b><br><p>" & debrief.CrewLeader.ToString() & "</p><br>")

            .Append("<b>FIRST AIDER:</b><br><p>" & debrief.FirstAider.ToString() & "</p><br>")

            .Append("<b>BRIEF JOB DESCRIPTION:</b>" & "<br><p>" & debrief.JobDescription & "</p><br>")

            .Append("<b>WHAT WAS THE PLAN:</b>" & "<br><p>" & debrief.Plan & "</p><br>")

            .Append("<b>WAS THE PLAN CLEAR TO ALL:</b><br><p>" & If(debrief.PlanClearToAll, "Yes", "No") & "</p><br>")

            .Append("<b>CREW LEADER - WAS THERE A PLAN B:</b><br><p>" & If(debrief.PlanB, "Yes", "No") & "</p><br><br>")

            .Append("<b>WAS 'MY COUNCIL SERVICES' NOTIFICATION LODGED?:</b><br><p>" & If(debrief.MyCouncil, "Yes", "No") & "</p><br><br>")

            .Append("<b>*** SAFETY/TRAINING ***</b><br><br>")

            .Append("<b>SAFETY ADVISOR:</b><p>" & debrief.Safety.ToString() & "</p><br>")

            .Append("<b>SAFETY CONCERNS:</b>" & "<br><p>" & debrief.SafetyConcerns & "</p><br>")

            .Append("<b>WHAT SKILLS WOULD HAVE MADE THE JOB EASIER: </b>" & "<br><p>" & debrief.Skills & "</p><br>")

            .Append("<b>WAS THE CREW ADEQUATELY TRAINED: </b><p>" & If(debrief.CrewAdequatelyTrained, "Yes", "No") & "</p><br><br>")

            .Append("<b>*** LOGISTICS ***</b><br><br>")

            .Append("<b>VEHICLES USED: </b>")
        End With


        'Add the vehicles used
        If debrief.VehiclesUsed.Count = 0 Then
            messageBody.Append("<p>Nil</p>" & "<br>")
        Else
            For Each vehicle In debrief.VehiclesUsed
                messageBody.Append("<p>" & vehicle & "</p>")
            Next
        End If

        'Complete the message body
        With messageBody
            .Append("<br><b>ISSUES FOR VEHICLES OR EQUIPMENT:</b><br><p>" & debrief.IssuesForJob & "</p><br>")

            .Append("<b>EQUIPMENT THAT WOULD HAVE MADE THE JOB EASIER:</b>" & "<br><p>" & debrief.Skills & "</p><br><br>")

            .Append("<b>*** MEMBERS ATTENDING ***<b><br><br>")
        End With

        ' Insert membes attending
        messageBody.Append("<table border=""1"" style=""width:100%"">")

        messageBody.Append("<tr><td><b>MEMBERS IN ATTENDANCE</b></td><td><b>TASK UNDERTAKEN</b></td></tr>")

        For Each attendingMember As Member In debrief.MembersAttending.Keys
            ' Try to get the task undertaken
            Dim task As String = "No task defined"
            debrief.MembersAttending.TryGetValue(attendingMember, task)

            ' Add the content to the message body
            With messageBody
                .Append("<tr>")
                .Append("<td>" & attendingMember.ToString() & "</td>")
                .Append("<td>" & task & "</td>")
                .Append("</tr>")
            End With
        Next

        messageBody.Append("</table><br><br>")

        'Insert Equipment Use
        messageBody.Append("<b>*** EQUIPMENT USED ***<b><br><br>")

        messageBody.Append("<table border=""1"" style=""width:100%"">")

        messageBody.Append("<tr><td><b>ITEM</b></td><td><b>DURATION</b></td><td><b>MEMBER USED</b></td></tr>")

        For Each item In debrief.EquipmentUsed
            With messageBody
                .Append("<tr>")
                .Append("<td>" & item.Item & "</td>")
                .Append("<td>" & String.Format("{0} mins", item.Duration.ToString()) & "</td>")
                .Append("<td>" & item.MemberUsing.ToString() & "</td>")
                .Append("</tr>")
            End With
        Next

        messageBody.Append("</table><br>")

        'Finishing putting in the HTML code
        messageBody.Append("</FONT></DIV></BODY></HTML>")

        'E-mail the debrief
        Dim cacheData = False
        Dim mailMessage As New MailMessage
        Dim objSmtpClient As SmtpClient = Settings.Settings.EmailSettings.SmtpClient
        objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network

        'Change the message body to plain text
        Dim alternate As AlternateView = AlternateView.CreateAlternateViewFromString(messageBody.ToString(), New Net.Mime.ContentType("text/html"))

        ' From address
        If Settings.Settings.EmailSettings.FromAddress IsNot Nothing Then
            mailMessage.From = Settings.Settings.EmailSettings.FromAddress
        End If

        'To address
        If Debugger.IsAttached() Then
            mailMessage.Bcc.Add(New MailAddress("benjamin.penaluna@members.ses.vic.gov.au", "Benjamin Penaluna"))
        Else
            AddReceipients(debrief, mailMessage, unknownEmailAddress)
        End If

        'Subject, message body, priority etc.
        With mailMessage
            .Subject = "Post Operation Debrief - " & debrief.EventNumber
            .Body = messageBody.ToString()
            .Priority = Settings.Settings.EmailSettings.MailPriority
            .AlternateViews.Add(alternate)
            .IsBodyHtml = False
        End With

        'Make sure that there is a network connect available
        If My.Computer.Network.IsAvailable = True Then
            ' Update the user
            progress.Report("Sending the E-mail")

            Try
                Dim sendMessage As Task = objSmtpClient.SendMailAsync(mailMessage)
                Await sendMessage.ConfigureAwait(False)

                If sendMessage.Status = TaskStatus.RanToCompletion And unknownEmailAddress.Count = 0 Then
                    Return "The Post Operation Debrief has been sucessfully submitted."
                ElseIf sendMessage.Status = TaskStatus.RanToCompletion And unknownEmailAddress.Count = 0 Then
                    Dim messageText = "The Post Operation Debrief has been sucessfully submitted, but was unable To be sent To the following members:" & Environment.NewLine()

                    Return unknownEmailAddress.Aggregate(messageText, Function(current, name) current + (name & Environment.NewLine()))
                ElseIf sendMessage.Status = TaskStatus.Faulted Or sendMessage.Status = TaskStatus.Canceled Then
                    cacheData = True
                End If
            Catch ex As Exception
                'There has been an error in transmission, so set cacheMessage to True to be sent later 
                cacheData = True
            End Try
        Else 'There is no network connection available, save the data for transmission next time the program starts
            cacheData = True
        End If

        If cacheData Then
            ' Update the user
            progress.Report("Sending E-mail unsuccessful. Caching debrief for later transmission.")

            ' Cache the debrief data for later transmission
            SerialiseDebriefData(debrief)

            Return "Unable to establish a connection with the E-mail server. Debrief will be cached and sent when a connection can be established."
        End If

        ' This is the fail safe - this line of code of reached then, exceptions have not be properly handled.
        Return "The Post Operation Debrief was not successully submitted. Please try again later."
    End Function

    Private Shared Sub AddReceipients(debrief As Debrief, mailMessage As MailMessage, ByRef unknownEmailAddresses As List(Of String))
        Dim toAddresses = RetrieveReceipients(EmailSettings.TypeOfReceipient.Too, debrief, unknownEmailAddresses)
        For Each address In toAddresses
            mailMessage.To.Add(address)
        Next

        Dim ccAddresses = RetrieveReceipients(EmailSettings.TypeOfReceipient.Cc, debrief, unknownEmailAddresses)
        For Each address In ccAddresses
            mailMessage.CC.Add(address)
        Next

        Dim bccAddresses = RetrieveReceipients(EmailSettings.TypeOfReceipient.Bcc, debrief, unknownEmailAddresses)
        For Each address In bccAddresses
            mailMessage.Bcc.Add(address)
        Next
    End Sub

    Private Shared Function RetrieveReceipients(type As EmailSettings.TypeOfReceipient, debrief As Debrief, ByRef unknownEmailAddresses As List(Of String)) As List(Of MailAddress)
        Dim receipients As New List(Of MailAddress)
        With receipients
            .AddRange(GetAdditionalReceipients(type))
            .AddRange(GetMembersToReceive(type, unknownEmailAddresses))
        End With

        If Settings.Settings.EmailSettings.AllMemberReceive AndAlso Settings.Settings.EmailSettings.AllMemberReceipientType = type Then
            receipients.AddRange(GetMembersAttending(debrief, unknownEmailAddresses))
        End If

        Return receipients
    End Function

    Private Shared Function GetAdditionalReceipients(type As EmailSettings.TypeOfReceipient) As List(Of MailAddress)
        Return (From receipient In Settings.Settings.EmailSettings.AdditionalReceipients
                Where receipient.Value.Item2 = type
                Select receipient.Value.Item1).ToList()
    End Function

    Private Shared Function GetMembersToReceive(type As EmailSettings.TypeOfReceipient, ByRef unknownEmailAddresses As List(Of String)) As List(Of MailAddress)
        Dim addresses As New List(Of MailAddress)

        Dim members = (From receipient In Settings.Settings.EmailSettings.MembersToReceive
                       Where receipient.Value = type
                       Select receipient.Key).ToList()

        For Each member In members
            Try
                addresses.Add(New MailAddress(member.EmailAddress, member.DisplayName))
            Catch ex As Exception
                unknownEmailAddresses.Add(member.FirstName & " " & member.Surname)
            End Try
        Next

        Return addresses
    End Function

    Private Shared Function GetMembersAttending(debrief As Debrief, ByRef unknownEmailAddresses As List(Of String)) As List(Of MailAddress)
        Dim addresses As New List(Of MailAddress)

        For Each memberAttending In debrief.MembersAttending
            Try
                addresses.Add(New MailAddress(memberAttending.Key.EmailAddress, memberAttending.Key.DisplayName))
            Catch ex As Exception
                unknownEmailAddresses.Add(memberAttending.Key.FirstName & " " & memberAttending.Key.Surname)
            End Try
        Next

        Return addresses
    End Function

    Private Shared Function MembersAttending(attendingMember As Member) As IEnumerable(Of Member)
        Return From member In MemberDetails
               Where member.Id = attendingMember.Id
               Select member
    End Function

    Private Shared Sub SerialiseDebriefData(data As Debrief)
        If Not My.Computer.FileSystem.DirectoryExists(CacheDirectory) Then
            My.Computer.FileSystem.CreateDirectory(CacheDirectory)
        End If

        Using fs = New FileStream(Path.Combine(CacheDirectory, DateTime.Now.ToString("yyyyMMddHHmmss") & ".xml"), FileMode.CreateNew, FileAccess.Write)
            Using sw = New StreamWriter(fs)
                Dim x As New XmlSerializer(data.GetType)
                x.Serialize(sw, data)
            End Using
        End Using
    End Sub

    Public Shared Async Function ResendDebriefDataAsync(progress As IProgress(Of String)) As Task
        ' Check to see of there are any debriefs to be re-sent

        ' Make sure that the directory exists, if not then return
        If My.Computer.FileSystem.DirectoryExists(CacheDirectory) Then
            ' Get all the files in the cache directory
            Dim files As ObjectModel.ReadOnlyCollection(Of String) = My.Computer.FileSystem.GetFiles(CacheDirectory, FileIO.SearchOption.SearchTopLevelOnly, "*.xml")
            Dim count = 1

            ' Check to see if there debriefs to be re-emailed
            For Each file As String In files
                Dim debrief

                ' Deserialise the debrief
                Dim serialisedType As Type
                Try
                    serialisedType = DetermineSerializedType(file)
                Catch ex As Exception
                    Throw
                End Try

                Using fs = New FileStream(file, FileMode.Open, FileAccess.Read)
                    Using sr = New StreamReader(fs)
                        Dim x As New XmlSerializer(serialisedType)
                        debrief = CTypeDynamic(x.Deserialize(sr), serialisedType)
                    End Using
                End Using

                ' Try to send the debrief
                Dim reportText As String = String.Format("Attempting to resend Debrief {0} of {1}", count, files.Count)
                progress.Report(reportText)
                Await EmailDebriefAsync(debrief, New Progress(Of String)(Sub(p As String)
                                                                             progress.Report(reportText & ": " & p)
                                                                         End Sub)).ConfigureAwait(False)

                ' Delete the file (regarless of whether it send, since EmailDebriefAsync will re-serialise it
                My.Computer.FileSystem.DeleteFile(file)
            Next

            If files.Count > 0 Then
                progress.Report("Resend Complete")
            End If
        End If
    End Function

    Private Shared Function DetermineSerializedType(file As String) As Type
        Dim serialisedType As Type

        Using fs = New FileStream(file, FileMode.Open, FileAccess.Read)
            Using sr = New StreamReader(fs)
                serialisedType = ExtractSerializedType(sr)

                If serialisedType Is Nothing Then
                    Throw New ArgumentException("The serialized object does not derive from 'Debrief'.")
                End If
            End Using
        End Using

        Return serialisedType
    End Function

    Private Shared Function ExtractSerializedType(sr As StreamReader) As Type
        sr.ReadLine()
        Dim typeString = sr.ReadLine().Replace("<", "").Replace(">", "")

        Dim exportors = AssembyMetadata(Of Debrief).DerivedClasses()
        Dim type As Type = Nothing
        For Each export In From export1 In exportors Where export1.GetType().Name = typeString
            type = export.GetType()
            Exit For
        Next
        Return type
    End Function


    '---ADDITIONAL SUBROUTINES----

    Shared Function MemberNames(comparision As Comparison(Of Member), Optional ByVal blnCurrentOnly As Boolean = True) As List(Of Member)
        Dim members = (From member In MemberDetails
                       Where member.Status <> 5 ' Resigned
                       Select member).ToList()

        If comparision IsNot Nothing Then
            members.Sort(comparision)
        End If

        Return members
    End Function

    Function MemberServiceHistory(ByRef intHistoryStatus() As Integer, Optional ByVal blnCurrentOnly As Boolean = True) As String(,)
        Dim strRetrievedServiceHistory(,) As String

        strRetrievedServiceHistory = _objPersistence.RetrieveServiceHistory()

        'De-cipher the data
        'Dim intCountInner As Integer = 0
        For intCountOuter = 0 To strRetrievedServiceHistory.GetUpperBound(1)
            For intCountInner = 0 To strRetrievedServiceHistory.GetUpperBound(0)
                strRetrievedServiceHistory(intCountInner, intCountOuter) = Cipher.AffineBifidDecrypt(strRetrievedServiceHistory(intCountInner, intCountOuter))
            Next
        Next

        'Dimension or re-dimension the arrays to return the retrieved data
        Dim strReturn(strRetrievedServiceHistory.GetUpperBound(0) - 4, strRetrievedServiceHistory.GetUpperBound(1)) As String
        ReDim intHistoryStatus(strRetrievedServiceHistory.GetUpperBound(1))

        'Sort the data into the integer array to store the positions history, and the string array to store the service history
        'Dim intIndices() As Integer = {0, 4, 5, 6, 7}
        For intCountOuter = 0 To strRetrievedServiceHistory.GetUpperBound(1)
            'Prime the loop
            'intCountInner = 0
            For intCountInner = 3 To strRetrievedServiceHistory.GetUpperBound(0)
                Select Case intCountInner
                    Case 3
                        If strRetrievedServiceHistory(intCountInner, intCountOuter) = "" Then
                            intHistoryStatus(intCountOuter) = -1
                        Else
                            intHistoryStatus(intCountOuter) = Convert.ToInt32(strRetrievedServiceHistory(intCountInner, intCountOuter))
                        End If
                    Case Else
                        strReturn(intCountInner - 4, intCountOuter) = strRetrievedServiceHistory(intCountInner, intCountOuter)
                End Select
            Next
        Next

        Return strReturn
    End Function

    Shared Async Function RetrieveJobsTypesAsync() As Task(Of List(Of String))
        Try
            Return Await DebriefPersistence.RetrieveJobsTypesAsync().ConfigureAwait(False)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Shared Async Function RetrieveTaskUndertakenAsync() As Task(Of List(Of String))
        Try
            Return Await DebriefPersistence.RetrieveTaskUndertakenAsync().ConfigureAwait(False)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Shared Async Function RetrieveVehiclesAsync() As Task(Of List(Of String))
        Try
            Return Await DebriefPersistence.RetrieveTaskUndertakenAsync().ConfigureAwait(False)
        Catch ex As Exception
            Throw
        End Try
    End Function

    Shared Async Function RetieveAllDebriefDataFromTextAsync() As Task(Of List(Of DebriefSingleIncident))
        ' Retrieve the raw data
        Dim rawDebriefData As List(Of String()) = Await DebriefPersistence.RetieveAllDebriefDataFromTextAsync().ConfigureAwait(False)
        Dim rawMembersAttending As List(Of String()) = Await DebriefPersistence.RetrieveAllMembersAttendingFromTextAsync().ConfigureAwait(False)

        Return ProcessDebriefData(rawDebriefData, rawMembersAttending)
    End Function

    Private Shared Function ProcessDebriefData(rawDebriefData As List(Of String()), rawMembersAttending As List(Of String())) As List(Of DebriefSingleIncident)
        ' Create the return string
        Dim debriefs As New List(Of DebriefSingleIncident)

        ' Decrypt the attendance records
        For Each record As String() In rawMembersAttending
            For Each element As String In record
                element = Cipher.AffineBifidDecrypt(element)
            Next
        Next

        ' Cast the raw data to type DebriefSingleIncident
        For Each storedDebrief As String() In rawDebriefData
            ' Create the return string
            Dim debriefSingleIncident As DebriefSingleIncident

            ' Decrypt each element
            For Each element As String In storedDebrief
                element = Cipher.AffineBifidDecrypt(element)
            Next

            ' Manually cast the rawData into type DebriefSingleIncident

            ' Event Number
            Try
                debriefSingleIncident = New DebriefSingleIncident(storedDebrief(0))
            Catch ex As Exception
                Return New List(Of DebriefSingleIncident)
            End Try

            ' Start/End Times
            Dim startString() As String = storedDebrief(1).Split({"/", " ", ":"}, StringSplitOptions.None)
            Dim endString() As String = storedDebrief(2).Split({"/", " ", ":"}, StringSplitOptions.None)
            Dim start(startString.Length - 1) As Integer
            Dim finish(endString.Length - 1) As Integer
            For i = 0 To startString.Length - 1
                start(i) = Convert.ToInt32(startString(i))
                finish(i) = Convert.ToInt32(endString(i))
            Next
            debriefSingleIncident.StartTime = New DateTime(start(2), start(1), start(0), start(3), start(4), 0)
            debriefSingleIncident.FinishTime = New DateTime(finish(2), finish(1), finish(0), finish(3), finish(4), 0)

            debriefSingleIncident.JobType = storedDebrief(3)
            debriefSingleIncident.SesCommander = New Member(storedDebrief(4))
            debriefSingleIncident.CrewLeader = New Member(storedDebrief(5))
            debriefSingleIncident.JobDescription = storedDebrief(6)
            debriefSingleIncident.Plan = storedDebrief(7)
            debriefSingleIncident.PlanClearToAll = storedDebrief(8) = "Yes"
            debriefSingleIncident.PlanB = storedDebrief(9) = "Yes"
            debriefSingleIncident.Safety = New Member(storedDebrief(10))
            debriefSingleIncident.SafetyConcerns = storedDebrief(11)
            debriefSingleIncident.Skills = storedDebrief(12)
            debriefSingleIncident.CrewAdequatelyTrained = storedDebrief(13) = "Yes"
            debriefSingleIncident.IssuesForJob = storedDebrief(14)
            debriefSingleIncident.EquipmentToMakeEasier = storedDebrief(15)
            debriefSingleIncident.FirstAider = New Member(storedDebrief(16))

            ' Add the Vehicles Used
            If storedDebrief.Length > 17 Then
                For i = 17 To storedDebrief.Length - 1
                    debriefSingleIncident.VehiclesUsed.Add(storedDebrief(i))
                Next
            End If

            ' Update the members attending
            Dim members = MembersAttending(rawMembersAttending, storedDebrief(0))
            For Each record As String() In members
                debriefSingleIncident.MembersAttending.Add(New Member(record(1)), record(2))
            Next

            debriefs.Add(debriefSingleIncident)
        Next

        Return debriefs
    End Function

    Private Shared Function MembersAttending(rawMembersAttending As List(Of String()), eventNumber As String) As IEnumerable(Of String())
        Return From record In rawMembersAttending
               Where record(0) = eventNumber
               Select record
    End Function
End Class



