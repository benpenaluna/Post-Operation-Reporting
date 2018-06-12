Option Strict On

Imports System.IO
Imports System.Threading.Tasks

Public Class DebriefPersistence
    'Instantiate a link to the application functions class
    Shared ReadOnly _objAppFunctions As New ApplicationFunctions

    'Instantiate the separators array
    Shared ReadOnly _strSeparators() As String = {"/.,", "/.,,?"}

    Sub New()

    End Sub

    Sub SaveNewDebriefData(ByVal strDebriefData() As String)
        'The purpose of this subroutine is to save the data for transmission and permanetly save it for future reference

        'Create a new stream writer
        Dim objWriter As New StreamWriter(ApplicationFunctions.FilePath & _objAppFunctions.GetTempDataFileName)

        'Write the data
        For intCount = 0 To strDebriefData.Length - 1
            objWriter.WriteLine(strDebriefData(intCount))
        Next

        'Close the writer
        objWriter.Close()
    End Sub

    Function RetrieveNewDebriefData() As String()
        'The purpose of this function is to retrieve the data for the report

        'Instantiate the return string
        Dim strData(0) As String
        Dim intData As Integer = 0

        'Make sure that the file exists
        If My.Computer.FileSystem.FileExists(ApplicationFunctions.FilePath & _objAppFunctions.GetTempDataFileName) Then
            'Instantiate a reader
            Dim objReader As New StreamReader(ApplicationFunctions.FilePath & _objAppFunctions.GetTempDataFileName)

            'Read in the stored data
            Do While objReader.Peek <> -1
                ReDim Preserve strData(intData)
                strData(intData) = objReader.ReadLine()
                intData += 1
            Loop

            'Close the reader
            objReader.Close()

            'Delete the temporary file
            My.Computer.FileSystem.DeleteFile(ApplicationFunctions.FilePath & _objAppFunctions.GetTempDataFileName)
        End If

        Return strData
    End Function

    Sub PermanentlySaveDebrief(ByVal strDebriefData() As String)
        'Permanently save the debrief
        Dim objWriter As StreamWriter
        Dim strFilePath As String = ApplicationFunctions.FilePath & _objAppFunctions.GetDebriefData
        If File.Exists(strFilePath) = False Then
            objWriter = File.CreateText(strFilePath)
        Else
            objWriter = File.AppendText(strFilePath)
        End If

        'Establish the save string
        Dim strWrite As String = ""
        For intCount = 0 To strDebriefData.Length - 1
            strWrite += strDebriefData(intCount)

            'Insert the separator if the data
            If intCount <> strDebriefData.Length - 1 Then
                strWrite += _strSeparators(1)
            End If
        Next

        'Write the new data
        objWriter.WriteLine(strWrite)

        'Close the writer
        objWriter.Flush()
        objWriter.Close()
    End Sub


    Sub SaveNewMembersAttending(ByVal strMembersAttending(,) As String)
        'The purpose of this routine is to save the members that the new report needs to be sent to

        'Create a new stream writer
        Dim objWriter As New StreamWriter(ApplicationFunctions.FilePath & _objAppFunctions.GetTempMembersFileName)

        'Write the data
        Dim strWrite As String
        For intCountOuter = 0 To strMembersAttending.GetUpperBound(1)
            strWrite = ""
            For intCountInner = 0 To strMembersAttending.GetUpperBound(0)
                strWrite += strMembersAttending(intCountInner, intCountOuter)

                If intCountInner <> strMembersAttending.GetUpperBound(0) Then
                    strWrite += _strSeparators(0)
                End If
            Next

            objWriter.WriteLine(strWrite)
        Next

        'Close the writer
        objWriter.Close()
    End Sub

    Async Function RetrieveNewMemberAttendingAsync(ByVal strDeleteTempFile As Boolean) As Task(Of List(Of String()))
        'The purpose of this function is to retrieve the data for the report

        'Instantiate the return string
        Dim membersAttending As New List(Of String())
        'Dim intMembersAttending As Integer = 0

        'Make sure that the file exists
        If My.Computer.FileSystem.FileExists(ApplicationFunctions.FilePath & _objAppFunctions.GetTempMembersFileName) Then
            'Instantiate a reader
            Using sr As New StreamReader(ApplicationFunctions.FilePath & _objAppFunctions.GetTempMembersFileName)

                ''Read in the stored data
                'Do While objReader.Peek <> -1
                '    'Read the new line
                '    strSplits = objReader.ReadLine.Split(_strSeparators, StringSplitOptions.None)

                '    'Store the data in the return string
                '    ReDim Preserve membersAttending(membersAttending.GetUpperBound(0), intMembersAttending)
                '    For intCount = 0 To strSplits.Length - 1
                '        membersAttending(intCount, intMembersAttending) = strSplits(intCount)
                '    Next
                '    intMembersAttending += 1
                'Loop

                While Not sr.EndOfStream
                    Dim line As String = Await sr.ReadLineAsync().ConfigureAwait(False)
                    membersAttending.Add(line.Split(_strSeparators, StringSplitOptions.None))
                End While
            End Using

            'Delete the temporary file
            If strDeleteTempFile = True Then
                'My.Computer.FileSystem.DeleteFile(ApplicationFunctions.FilePath & _objAppFunctions.GetTempMembersFileName)
                My.Computer.FileSystem.DeleteFile(Path.Combine(ApplicationFunctions.FilePath, _objAppFunctions.GetTempMembersFileName))
            End If
        End If

        Return membersAttending
    End Function

    Sub PermanentlySaveMembersAttending(strJobNumber As String, strNewMembersAttending(,) As String)
        'Permanently save the debrief
        Dim objWriter As StreamWriter
        Dim strFilePath As String = ApplicationFunctions.FilePath & ApplicationFunctions.GetMemberAttendingData
        Select Case File.Exists(strFilePath)
            Case False
                objWriter = File.CreateText(strFilePath)
            Case Else
                objWriter = File.AppendText(strFilePath)
        End Select

        'Establish the save string
        Dim strWrite As String
        For intCountOuter = 0 To strNewMembersAttending.GetUpperBound(1)
            strWrite = strJobNumber & _strSeparators(1)
            For intCountInner = 0 To strNewMembersAttending.GetUpperBound(0)
                strWrite += strNewMembersAttending(intCountInner, intCountOuter)

                If intCountInner <> strNewMembersAttending.GetUpperBound(0) Then
                    strWrite += _strSeparators(1)
                End If
            Next

            'Write the new data
            objWriter.WriteLine(strWrite)
        Next

        'Close the writer
        objWriter.Close()
    End Sub



    '---MEMBER DETAILS FUNCTIONS---

    Shared Function RetrieveMemberDetails() As List(Of String())
        'The purpose of this function is to retrieve the member details

        ' Intantiate the return list
        Dim rawMemberData As New List(Of String())

        'Instantiate an array to store the splits

        Dim fileName As String = ApplicationFunctions.FilePath & ApplicationFunctions.GetMemberDetailsFileName
        Try
            Using objReader As New StreamReader(fileName)
                While Not objReader.EndOfStream()
                    rawMemberData.Add(objReader.ReadLine.Split(_strSeparators, StringSplitOptions.None))
                End While
            End Using
        Catch ex As FileNotFoundException
            Throw
        End Try


        Return rawMemberData
    End Function


    Function RetrieveServiceHistory() As String(,)
        'Determine Resource File Path based on Debugging mode or Published mode
        Dim strFile As String = ApplicationFunctions.FilePath() & _objAppFunctions.GetServiceHistory()
        Dim intMinimumEntries = 1
        Dim intNumberOfFields = 8
        Dim strReturnedString As String
        Dim strReturnArray(intNumberOfFields - 1, 1) As String
        Dim strSplitString() As String
        Dim strSeparators() As String = {"/.,"}
        Dim intCountOuter As Integer
        Dim intCountInner As Integer

        Dim objReader As New StreamReader(strFile)

        intCountOuter = 0
        Do While objReader.Peek <> -1
            'If there more than two entries, redimension the array to store the data
            If intCountOuter >= intMinimumEntries Then
                ReDim Preserve strReturnArray(strReturnArray.GetUpperBound(0), intCountOuter)
            End If

            'Read in the saved member details for this particular member
            strReturnedString = objReader.ReadLine()

            'Split the returned string into the subdivisions, divied by the separator
            strSplitString = strReturnedString.Split(strSeparators, StringSplitOptions.None)

            'Copy the returned data into strReturnArray to be send to the business class when called to be processed in the
            'program
            intCountInner = 0
            For Each split As String In strSplitString
                strReturnArray(intCountInner, intCountOuter) = split
                intCountInner += 1
            Next

            'increment the outer counter to indicate a new member
            intCountOuter += 1
        Loop

        'Close the objReader
        objReader.Close()

        Return strReturnArray
    End Function

    Shared Async Function RetrieveTaskUndertakenAsync() As Task(Of List(Of String))
        Dim strTasks As New List(Of String)

        ' Extract the UpdatedTasks from the file
        Try
            Using objReader As New StreamReader(ApplicationFunctions.FilePath & ApplicationFunctions.GetTaskUndertakenData)
                While Not objReader.EndOfStream
                    strTasks.Add(Await objReader.ReadLineAsync().ConfigureAwait(False))
                End While
            End Using
        Catch ex As Exception
            Throw
        End Try

        Return strTasks
    End Function

    Shared Async Function RetrieveJobsTypesAsync() As Task(Of List(Of String))
        Dim strJobs As New List(Of String)

        ' Extract the UpdatedTasks from the file
        Try
            Using objReader As New StreamReader(ApplicationFunctions.FilePath & ApplicationFunctions.GetJobTypeData)
                While Not objReader.EndOfStream
                    strJobs.Add(Await objReader.ReadLineAsync().ConfigureAwait(False))
                End While
            End Using
        Catch ex As Exception
            Throw
        End Try

        Return strJobs
    End Function

    Shared Function RetieveAllDebriefDataFromText() As List(Of String())
        ' Instantiate the return string
        Dim rawData As New List(Of String())

        Try
            Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetDebriefDataFileName())
                While Not sr.EndOfStream()
                    Dim line As String = sr.ReadLine()
                    rawData.Add(line.Split({"/.,,?"}, StringSplitOptions.None))
                End While
            End Using
        Catch ex As FileNotFoundException
            Throw
        End Try


        Return rawData
    End Function

    Shared Async Function RetieveAllDebriefDataFromTextAsync() As Task(Of List(Of String()))
        ' Instantiate the return string
        Dim rawData As New List(Of String())

        Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetDebriefDataFileName())
            While Not sr.EndOfStream()
                Dim line As String = Await sr.ReadLineAsync().ConfigureAwait(False)
                rawData.Add(line.Split(_strSeparators, StringSplitOptions.None))
            End While
        End Using

        Return rawData
    End Function

    Shared Function RetrieveAllMembersAttendingFromText() As List(Of String())
        ' Instantiate the return string
        Dim rawData As New List(Of String())

        Try
            Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetMemberAttendingData())
                While Not sr.EndOfStream()
                    Dim line As String = sr.ReadLine()
                    rawData.Add(line.Split({"/.,,?"}, StringSplitOptions.None))
                End While
            End Using
        Catch ex As FileNotFoundException
            Throw
        End Try


        Return rawData
    End Function

    Shared Async Function RetrieveAllMembersAttendingFromTextAsync() As Task(Of List(Of String()))
        ' Instantiate the return string
        Dim rawData As New List(Of String())

        Using sr As New StreamReader(ApplicationFunctions.FilePath() & ApplicationFunctions.GetMemberAttendingData())
            While Not sr.EndOfStream()
                Dim line As String = Await sr.ReadLineAsync().ConfigureAwait(False)
                rawData.Add(line.Split(_strSeparators, StringSplitOptions.None))
            End While
        End Using

        Return rawData
    End Function
End Class