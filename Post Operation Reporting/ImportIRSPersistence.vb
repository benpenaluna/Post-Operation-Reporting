Option Strict On

Imports System.IO

Public Class ImportIRSPersistence
    'Instantiate links to various classes
    Dim _objAppFunctions As New ApplicationFunctions

    'Instantiate the separators array
    Dim _strSeparators() As String = {"/.,,?"}

    Sub New()

    End Sub

    Function RetrieveSummaryData(ByVal strFilePath As String) As String(,)
        'Instantiate the return array
        Dim strSummaryData(2, 0) As String

        If My.Computer.FileSystem.FileExists(strFilePath) = True Then
            'Open the reader
            Dim objReader As New StreamReader(strFilePath)

            'Instantiate the split string
            Dim strSplits() As String = objReader.ReadLine.Split(_strSeparators, StringSplitOptions.None)

            'Determine what length the summary data array should be
            Dim intSummaryDataLength As Integer = 2
            If strSplits.Length > 1 And strSplits(0) <> Nothing Then
                intSummaryDataLength = strSplits.Length - 1
            End If

            'Re-dimension the return array
            If intSummaryDataLength <> 2 Then
                Dim strTemp(intSummaryDataLength, 0) As String
                strSummaryData = strTemp
            End If

            'Make sure that there is data to actually return
            If strSplits(0) <> Nothing Then
                'Store the split data in the main array
                For intCount = 0 To intSummaryDataLength
                    strSummaryData(intCount, 0) = strSplits(intCount)
                Next

                'Read in the rest of the data
                Do While objReader.Peek <> -1
                    'Read in the next line
                    strSplits = objReader.ReadLine.Split(_strSeparators, StringSplitOptions.None)

                    'Store the data in the return array
                    ReDim Preserve strSummaryData(strSummaryData.GetUpperBound(0), strSummaryData.GetUpperBound(1) + 1)
                    For intCount = 0 To strSplits.Length - 1
                        strSummaryData(intCount, strSummaryData.GetUpperBound(1)) = strSplits(intCount)
                    Next
                Loop
            End If

            'Close the reader
            objReader.Close()
        End If

        Return strSummaryData
    End Function

    Sub SaveSummaryData(ByVal strSummaryData(,) As String, ByVal strFilePath As String)
        'Open the writer
        Dim objWriter As New StreamWriter(strFilePath)

        'Instantiate a string to store the line to write
        Dim strWriteLine As String = ""

        'Write the data
        For intCountOuter = 0 To strSummaryData.GetUpperBound(1)
            'Reset strWriteLine
            strWriteLine = ""

            For intCountInner = 0 To strSummaryData.GetUpperBound(0)
                'Add to strWriteLine
                strWriteLine += strSummaryData(intCountInner, intCountOuter)

                'Add the split
                If intCountInner <> strSummaryData.GetUpperBound(0) Then
                    strWriteLine += _strSeparators(0)
                End If
            Next

            'Write the line to the file
            objWriter.WriteLine(strWriteLine)
        Next

        'Close the writer
        objWriter.Close()
    End Sub

    Function ImportIncidentSummaryData(ByVal strFilePath As String) As String(,)
        'Instantiate a reader for retrieve the data
        Dim objReader As New StreamReader(strFilePath)

        'Instantiate a string to store the splits - these will be the headers and will no need to be stored in the
        'return array
        Dim strSplits() As String = objReader.ReadLine.Split({","}, StringSplitOptions.None)

        'Instantiate the return string
        Dim strImportedData(strSplits.Length - 1, 0) As String
        Dim intImportedData As Integer = 0

        'Retrieve the rest of the data
        Do While objReader.Peek <> -1
            'Split the read string
            strSplits = _objAppFunctions.SplitCSV(objReader.ReadLine)

            'Store the data in the return array
            ReDim Preserve strImportedData(strImportedData.GetUpperBound(0), intImportedData)
            For intCount = 0 To strImportedData.GetUpperBound(0)
                strImportedData(intCount, intImportedData) = strSplits(intCount)
            Next
            intImportedData += 1
        Loop

        'Close the reader
        objReader.Close()

        Return strImportedData
    End Function

    Function ImportAvailabilityData(ByVal strFilePath As String) As String(,)
        'Instantiate the return string
        Dim strReturn(5, 0) As String

        'Make sure that the file exists
        If My.Computer.FileSystem.FileExists(strFilePath) = True Then
            'Instantiate the reader
            Dim objReader As New StreamReader(strFilePath)

            'Determine the splits
            Dim strSplits() As String = objReader.ReadLine.Split({Chr(9)}, StringSplitOptions.None)

            'Instantiate the return  string
            Dim strTempReturn(strSplits.Length - 1, 0) As String
            strReturn = strTempReturn
            Dim intReturn As Integer = 0

            'Read in the data
            Do While objReader.Peek <> -1
                'Read in the next line
                strSplits = objReader.ReadLine.Split({Chr(9)}, StringSplitOptions.None)

                'Store the results in the return array
                ReDim Preserve strReturn(strReturn.GetUpperBound(0), intReturn)
                For intCount = 0 To strReturn.GetUpperBound(0)
                    strReturn(intCount, intReturn) = strSplits(intCount)
                Next
                intReturn += 1
            Loop

            'Close the reader
            objReader.Close()
        End If

        Return strReturn
    End Function

    'Function FirstDateOfAvailability() As String
    '    'The purose of this function is to retreive the first data that the availablity data has been collected from

    '    'Instantiate the split string to extract the date
    '    Dim strSplits(0) As String

    '    'Make sure that the target file exists 
    '    If My.Computer.FileSystem.FileExists(_objAppFunctions.FilePath & _objAppFunctions.GetAvailabilityData()) = True Then
    '        'Open the availability data records
    '        Dim objReader As New IO.StreamReader(_objAppFunctions.FilePath & _objAppFunctions.GetAvailabilityData())

    '        'Read the firstline of data
    '        strSplits = objReader.ReadLine.Split({_strSeparators(0)}, StringSplitOptions.None)

    '        'Close the reader
    '        objReader.Close()
    '    End If

    '    'Return the first element in strSplits
    '    Return strSplits(0)
    'End Function

    Function RetrieveLoginData(ByVal strFilePath As String) As String(,)
        'Instantiate a return string
        Dim strReturn(1, 0) As String

        'Make sure that the file exists
        If My.Computer.FileSystem.FileExists(strFilePath) Then
            'Instantiate the reader
            Dim objReader As New StreamReader(strFilePath)

            'Determine the splits
            Dim strSplits() As String = objReader.ReadLine.Split({_strSeparators(0)}, StringSplitOptions.None)

            'Instantiate the return  string
            Dim strTempReturn(strSplits.Length - 1, 0) As String
            strReturn = strTempReturn
            Dim intReturn As Integer = 1

            'Store the received splits
            For intCount = 0 To strReturn.GetUpperBound(0)
                strReturn(intCount, 0) = strSplits(intCount)
            Next

            'Read in the data
            Do While objReader.Peek <> -1
                'Read in the next line
                strSplits = objReader.ReadLine.Split({_strSeparators(0)}, StringSplitOptions.None)

                'Store the results in the return array
                ReDim Preserve strReturn(strReturn.GetUpperBound(0), intReturn)
                For intCount = 0 To strReturn.GetUpperBound(0)
                    strReturn(intCount, intReturn) = strSplits(intCount)
                Next
                intReturn += 1
            Loop

            'Close the reader
            objReader.Close()
        End If

        Return strReturn
    End Function
End Class