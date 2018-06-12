Option Strict On

Public Class ImportIRSBusiness
    ''Instantiate links to various classes
    'Dim _objCipher As New Cipher
    'Dim _objPersistence As New ImportIRSPersistence
    'Dim _objAppFunctions As New ApplicationFunctions

    ''Instantiate a class array to store the AttendanceData for using by multiple functions
    'Dim _strAttendance(,) As String

    ''Instantiate a class array to store the availability for each member
    'Dim _intAvailabilityFields As Integer = 5
    'Dim _strMemberID(0) As String
    'Dim _intNumberAvailability(_intAvailabilityFields, 0) As Integer
    'Dim _intTotalAvailability(_intAvailabilityFields, 0) As Integer
    'Dim _dblPercentageAvailability(_intAvailabilityFields, 0) As Double

    ''Instantiate DateTime objects to store the date for the last 1, 3, 6, 12, 24 and 36
    'Dim _datLastCutoffDates(_intAvailabilityFields) As DateTime

    ''Instantiate datetime to record the first and the last record in the attendance records
    'Dim _datFirstAvailabilityRecords As DateTime
    'Dim _datLastAvailabilityRecords As DateTime
    'Dim _datLastConsideredDate As DateTime

    ''Instantiate arrays to store the dates that members are probationary, resigned or on leave
    'Dim _strServiceMemberID(0) As String
    'Dim _datServiceStartDate(0) As DateTime
    'Dim _datServiceEntryStartDate(0) As DateTime
    'Dim _datServiceEntryEndDate(0) As DateTime
    'Dim _intHistoryStatus(0) As Integer
    'Dim _intService As Integer = 0

    'Sub New()

    'End Sub

    'Function RetrieveSummaryData(ByVal strFilePath As String) As String(,)
    '    'Retrive the saved data
    '    Dim strSummaryData(,) As String = _objPersistence.RetrieveSummaryData(strFilePath)

    '    'Decipher the data
    '    For intCountOuter = 0 To strSummaryData.GetUpperBound(1)
    '        For intCountInner = 0 To strSummaryData.GetUpperBound(0)
    '            strSummaryData(intCountInner, intCountOuter) = _objCipher.AffineBifidDecrypt(strSummaryData(intCountInner, intCountOuter))
    '        Next
    '    Next

    '    Return strSummaryData
    'End Function

    'Sub SaveSummaryData(ByVal strSummaryData(,) As String, ByVal strFilePath As String)
    '    'Cipher the data
    '    For intCountOuter = 0 To strSummaryData.GetUpperBound(1)
    '        For intCountInner = 0 To strSummaryData.GetUpperBound(0)
    '            strSummaryData(intCountInner, intCountOuter) = _objCipher.AffineBifidEncrypt(strSummaryData(intCountInner, intCountOuter))
    '        Next
    '    Next

    '    'Save the data
    '    _objPersistence.SaveSummaryData(strSummaryData, strFilePath)
    'End Sub

    'Function RetrieveLoginData(ByVal strFilePath As String) As String(,)
    '    'Retrive the saved data
    '    Dim strLoginData(,) As String = _objPersistence.RetrieveLoginData(strFilePath)

    '    'Decipher the data
    '    'For intCountOuter = 0 To strLoginData.GetUpperBound(1)
    '    '    For intCountInner = 0 To strLoginData.GetUpperBound(0)
    '    '        strLoginData(intCountInner, intCountOuter) = _objCipher.AffineBifidDecrypt(strLoginData(intCountInner, intCountOuter))
    '    '    Next
    '    'Next

    '    Return strLoginData
    'End Function

    'Sub SaveLoginData(ByVal strLoginData(,) As String, ByVal strFilePath As String)
    '    'Cipher the data
    '    'For intCountOuter = 0 To strLoginData.GetUpperBound(1)
    '    '    For intCountInner = 0 To strLoginData.GetUpperBound(0)
    '    '        strLoginData(intCountInner, intCountOuter) = _objCipher.AffineBifidEncrypt(strLoginData(intCountInner, intCountOuter))
    '    '    Next
    '    'Next

    '    'Save the data
    '    _objPersistence.SaveSummaryData(strLoginData, strFilePath)
    'End Sub

    'Sub ImportIncidentSummaryData(ByVal strFilePath As String)
    '    'Import the data
    '    Dim strImportedSummaryData(,) As String = _objPersistence.ImportIncidentSummaryData(strFilePath)

    '    'Retrive the saved data
    '    Dim strSummaryData(,) As String = RetrieveSummaryData(ApplicationFunctions.FilePath & _objAppFunctions.GetSummaryData())
    '    Dim intSummaryData As Integer = strSummaryData.GetUpperBound(1) + 1
    '    If strSummaryData(0, 0) = Nothing Then
    '        intSummaryData = 0
    '    End If

    '    'Instantiate a parallel array to store all the incident numbers
    '    Dim strIncidentNumbers(strSummaryData.GetUpperBound(1)) As String
    '    If strSummaryData(0, 0) <> Nothing Then
    '        For intCount = 0 To strSummaryData.GetUpperBound(1)
    '            strIncidentNumbers(intCount) = strSummaryData(0, intCount)
    '        Next
    '    End If

    '    'Instantiate a boolean to indicate if data has been imported
    '    Dim blnDataImported As Boolean = False

    '    'Store all the required details back into the main array
    '    Dim intOrderToImport() As Integer = {2, 0, 4} 'The location of the data strImportedSummaryData
    '    For intCountImported = 0 To strImportedSummaryData.GetUpperBound(1)
    '        'Make sure that the data is not already in our records
    '        If Array.IndexOf(strIncidentNumbers, strImportedSummaryData(2, intCountImported)) < 0 Then
    '            'The data is not already in the system, so add it
    '            ReDim Preserve strSummaryData(strSummaryData.GetUpperBound(0), intSummaryData)
    '            For intCountInner = 0 To strSummaryData.GetUpperBound(0)
    '                strSummaryData(intCountInner, intSummaryData) = strImportedSummaryData(intOrderToImport(intCountInner), intCountImported)
    '            Next

    '            'Add the data to strIncidentNumbers
    '            ReDim Preserve strIncidentNumbers(intSummaryData)
    '            strIncidentNumbers(intSummaryData) = strImportedSummaryData(2, intCountImported)

    '            'Incriment intSummaryData
    '            intSummaryData += 1

    '            'Set blnDataImported
    '            blnDataImported = True
    '        End If
    '    Next

    '    'If data has been imported, then sort and save
    '    If blnDataImported = True Then
    '        'Instantiate a index array to help with the sorting process
    '        Dim intIndex(strIncidentNumbers.Length - 1) As Integer
    '        For intCount = 0 To strIncidentNumbers.Length - 1
    '            intIndex(intCount) = intCount
    '        Next

    '        'Sort the data
    '        Array.Sort(strIncidentNumbers, intIndex)

    '        'Sort the summary data
    '        Dim strTempSummaryData(strSummaryData.GetUpperBound(0), strSummaryData.GetUpperBound(1)) As String
    '        For intCountOuter = 0 To strSummaryData.GetUpperBound(1)
    '            For intCountInner = 0 To strSummaryData.GetUpperBound(0)
    '                strTempSummaryData(intCountInner, intCountOuter) = strSummaryData(intCountInner, intIndex(intCountOuter))
    '            Next
    '        Next

    '        'Save the data
    '        SaveSummaryData(strTempSummaryData, ApplicationFunctions.FilePath & _objAppFunctions.GetSummaryData())
    '    End If
    'End Sub

    'Sub ImportIndividualData(ByVal strFilePath As String)
    '    'Import the data
    '    Dim strImportedIndividualData(,) As String = _objPersistence.ImportIncidentSummaryData(strFilePath)

    '    'Retrive the saved data
    '    Dim strIndividualData(,) As String = RetrieveSummaryData(ApplicationFunctions.FilePath & _objAppFunctions.GetIndiSummaryData())
    '    Dim intIndividualData As Integer = strIndividualData.GetUpperBound(1) + 1
    '    If strIndividualData(0, 0) = Nothing Then
    '        intIndividualData = 0
    '    End If

    '    'Check to see that the size of strIndividualData is the correct length
    '    If strIndividualData(0, 0) = Nothing Then
    '        If strIndividualData.GetUpperBound(0) <> 1 Then
    '            'Create a temporary array for strIndividual data
    '            Dim strTempIndividualData(1, 0) As String
    '            strIndividualData = strTempIndividualData
    '        End If
    '    End If

    '    'Instantiate a boolean to indicate if data has been imported
    '    Dim blnDataImported As Boolean = False

    '    'Store all the required details back into the main array
    '    For intCountImported = 0 To strImportedIndividualData.GetUpperBound(1)
    '        'Make sure that the data is not already in our records
    '        If _objAppFunctions.CompositeKeyExists(strIndividualData, "ses" & Strings.Right(strImportedIndividualData(0, intCountImported), 5), _
    '                                               Strings.Right(strImportedIndividualData(2, intCountImported), strImportedIndividualData(2, intCountImported).Length - 2), _
    '                                                0, 1) = False Then
    '            'Composite key does not exist, so add it to strIndidualData
    '            ReDim Preserve strIndividualData(strIndividualData.GetUpperBound(0), intIndividualData)
    '            strIndividualData(0, intIndividualData) = "ses" & Strings.Right(strImportedIndividualData(0, intCountImported), 5)
    '            strIndividualData(1, intIndividualData) = Strings.Right(strImportedIndividualData(2, intCountImported), strImportedIndividualData(2, intCountImported).Length - 2)
    '            intIndividualData += 1

    '            'Reset blnDataImported
    '            blnDataImported = True
    '        End If
    '    Next

    '    'If data has been imported then sort and save
    '    If blnDataImported = True Then
    '        'Make sure that the data is sorted
    '        strIndividualData = _objAppFunctions.MultiSort(strIndividualData, 0, 1)

    '        'Save the data
    '        SaveSummaryData(strIndividualData, ApplicationFunctions.FilePath & _objAppFunctions.GetIndiSummaryData())
    '    End If
    'End Sub

    'Sub ImportAvailabilityData(ByVal strFilePath As String)
    '    'The purpose of this routine is to import and save the extract of availability data 

    '    'Update the login data
    '    'UpdateMemberWebLogon()

    '    'Import the data
    '    'The order is:
    '    '0 - Date
    '    '1 - Member Name
    '    '2 - Working Hours Availability
    '    '3 - Evening Availability
    '    '4 - Sleeping Hours Availability
    '    '5 - Busy
    '    Dim strImportedAvailabilityData(,) As String = _objPersistence.ImportAvailabilityData(strFilePath)

    '    'Sort the imported availability data
    '    strImportedAvailabilityData = _objAppFunctions.MultiSort(strImportedAvailabilityData, 0, 1)

    '    'Retrive the login data and split it into parallel arrays
    '    Dim strLoginDetails(,) As String = RetrieveLoginData(ApplicationFunctions.FilePath & _objAppFunctions.GetLoginData())
    '    Dim strID(strLoginDetails.GetUpperBound(1)) As String
    '    Dim strMemberName(strLoginDetails.GetUpperBound(1)) As String
    '    For intCount = 0 To strLoginDetails.GetUpperBound(1)
    '        strID(intCount) = strLoginDetails(0, intCount)
    '        strMemberName(intCount) = strLoginDetails(1, intCount).ToLower()
    '    Next

    '    'Retrive the saved data
    '    Dim strAvailabilityData(,) As String = RetrieveSummaryData(ApplicationFunctions.FilePath & _objAppFunctions.GetAvailabilityData())
    '    Dim intAvailabilityData As Integer = strAvailabilityData.GetUpperBound(1) + 1
    '    If strAvailabilityData(0, 0) = Nothing Then
    '        intAvailabilityData = 0
    '    End If

    '    'Check to see that the size of strAvailabilityData is the correct length
    '    If strAvailabilityData(0, 0) = Nothing Then
    '        If strAvailabilityData.GetUpperBound(0) <> 5 Then
    '            'Create a temporary array for strIndividual data
    '            Dim strTempIndividualData(5, 0) As String
    '            strAvailabilityData = strTempIndividualData
    '        End If
    '    End If

    '    'Instantiate a boolean to indicate if data has been imported
    '    Dim blnDataImported As Boolean = False

    '    'Instantiate an integer to store the location member id
    '    Dim intMemberID As Integer = -1

    '    'Store all the required details back into the main array
    '    For intCountImported = 0 To strImportedAvailabilityData.GetUpperBound(1)
    '        'Determine the location in strMemberName of the imported name
    '        intMemberID = Array.IndexOf(strMemberName, strImportedAvailabilityData(1, intCountImported).ToLower())

    '        'Make sure that the member ID is in the database
    '        If intMemberID >= 0 Then
    '            'See if the details have already been recorded
    '            If _objAppFunctions.CompositeKeyExists(strAvailabilityData, strImportedAvailabilityData(0, intCountImported), _
    '                                               strID(intMemberID), 0, 1) = False Then
    '                'Add the data to the array
    '                ReDim Preserve strAvailabilityData(strAvailabilityData.GetUpperBound(0), intAvailabilityData)
    '                For intCountInner = 0 To strAvailabilityData.GetUpperBound(0)
    '                    Select Case intCountInner
    '                        Case 1 'Member ID
    '                            strAvailabilityData(intCountInner, intAvailabilityData) = strID(intMemberID)
    '                        Case Else
    '                            strAvailabilityData(intCountInner, intAvailabilityData) = strImportedAvailabilityData(intCountInner, intCountImported)
    '                    End Select
    '                Next
    '                intAvailabilityData += 1

    '                'Set blnDataImported to true
    '                blnDataImported = True
    '            Else
    '                Dim strTellMe1 As String = ""
    '            End If
    '        Else 'The member ID is not recorded, output the error
    '            Dim strTellMe As String = ""
    '        End If

    '    Next

    '    'If data has been imported then sort and save
    '    If blnDataImported = True Then
    '        'Make sure that the data is sorted
    '        strAvailabilityData = _objAppFunctions.MultiSort(strAvailabilityData, 0, 1)

    '        'Save the data
    '        SaveSummaryData(strAvailabilityData, ApplicationFunctions.FilePath & _objAppFunctions.GetAvailabilityData())
    '    End If
    'End Sub

    ''Sub UpdateMemberWebLogon()
    ''    'Retrieve the stored login details
    ''    Dim strLoginDetails(,) As String = RetrieveLoginData(ApplicationFunctions.FilePath & _objAppFunctions.GetLoginData())

    ''    'Import the member details
    ''    Dim objDebriefBusiness As New DebriefBusiness
    ''    Dim memberDetails(,) As String = objDebriefBusiness.MemberNames()

    ''    'Instantiate an array to store the ses id's already stored in strLoginDetails
    ''    Dim strID(strLoginDetails.GetUpperBound(1)) As String
    ''    For intCount = 0 To strLoginDetails.GetUpperBound(1)
    ''        strID(intCount) = strLoginDetails(0, intCount)
    ''    Next

    ''    'Instantiate an integer to store the length of strLogin
    ''    Dim intLoginDetails As Integer = strLoginDetails.GetUpperBound(1) + 1
    ''    If strLoginDetails(0, 0) = Nothing Then
    ''        intLoginDetails = 0
    ''    End If

    ''    'Instantiate a split string
    ''    Dim strSplits() As String

    ''    'Check to see if there are any new login details
    ''    For intCount = 0 To memberDetails.GetUpperBound(1)
    ''        'Check to see if this ID has already been stored in strLoginDetails
    ''        If Array.IndexOf(strID, memberDetails(0, intCount)) < 0 Then
    ''            'Extract the member login name
    ''            strSplits = memberDetails(1, intCount).Split({",", " "}, StringSplitOptions.RemoveEmptyEntries)

    ''            'Store the data in the array
    ''            ReDim Preserve strLoginDetails(strLoginDetails.GetUpperBound(0), intLoginDetails)
    ''            ReDim Preserve strID(intLoginDetails)
    ''            strLoginDetails(0, intCount) = memberDetails(0, intCount)
    ''            strLoginDetails(1, intCount) = strSplits(1).ToLower & "." & Strings.Left(strSplits(0), 1).ToLower
    ''            strID(intCount) = memberDetails(0, intCount)
    ''            intLoginDetails += 1
    ''        End If
    ''    Next

    ''    'Create an index array for thge sorting process
    ''    Dim strNames(strID.Length - 1) As String
    ''    Dim intIndex(strID.Length - 1) As Integer
    ''    For intCount = 0 To strID.Length - 1
    ''        strNames(intCount) = strLoginDetails(1, intCount)
    ''        intIndex(intCount) = intCount
    ''    Next

    ''    'Sort the data
    ''    Array.Sort(strNames, intIndex)
    ''    Dim strTempLoginDetails(strLoginDetails.GetUpperBound(0), strLoginDetails.GetUpperBound(1)) As String
    ''    For intCountOuter = 0 To strLoginDetails.GetUpperBound(1)
    ''        For intCountInner = 0 To strLoginDetails.GetUpperBound(0)
    ''            strTempLoginDetails(intCountInner, intCountOuter) = strLoginDetails(intCountInner, intIndex(intCountOuter))
    ''        Next
    ''    Next

    ''    'Save the login details
    ''    SaveLoginData(strTempLoginDetails, ApplicationFunctions.FilePath & _objAppFunctions.GetLoginData())
    ''End Sub

    'Function MemberAvailability(ByVal strID As String, blnFormLoaded As Boolean) As String()
    '    'The purpose of this routine is to return the availability data for the specified member

    '    'If the form is still loading, then calculate the attendance data for all members
    '    If blnFormLoaded = False Then
    '        'Retieve the attendance data
    '        InitialiseAttendance()

    '        'Populate the list of member IDs
    '        PopulateMembersIDs()

    '        'Calculate the availability
    '        CalculateAvailability()

    '        'Calculate the totals()
    '        'CalculateTotals()

    '        'CalculatePercentages()
    '        CalculatePercentages()
    '    End If

    '    'Instantiate the return string
    '    Dim strAvailability(17) As String

    '    'Store the data in the availability array
    '    Dim intMemberIDLocation As Integer = Array.IndexOf(_strMemberID, strID)
    '    If intMemberIDLocation >= 0 Then
    '        For intCount = 0 To _intNumberAvailability.GetUpperBound(0)
    '            'Store the number of availability
    '            strAvailability(intCount) = Convert.ToString(_intNumberAvailability(intCount, intMemberIDLocation))

    '            'Store the totals
    '            strAvailability(intCount + (_intAvailabilityFields + 1)) = Convert.ToString(_intTotalAvailability(intCount, intMemberIDLocation))

    '            'Store the percentages
    '            strAvailability(intCount + CInt(2I * (_intAvailabilityFields + 1))) = Format(_dblPercentageAvailability(intCount, intMemberIDLocation), "0.00")
    '        Next
    '    End If

    '    Return strAvailability
    'End Function


    ''---ROUTINES FOR THE AVAILABILITY DATA

    'Private Sub InitialiseAttendance()
    '    'Retieve the attendance data
    '    _strAttendance = RetrieveSummaryData(ApplicationFunctions.FilePath & _objAppFunctions.GetAvailabilityData)

    '    'Set the date strings for the first and last records
    '    _datFirstAvailabilityRecords = Convert.ToDateTime(_strAttendance(0, 0), _
    '                                                                         New System.Globalization.CultureInfo("en-AU"))
    '    _datLastAvailabilityRecords = Convert.ToDateTime(_strAttendance(0, _strAttendance.GetUpperBound(1)), _
    '                                                                    New System.Globalization.CultureInfo("en-AU"))

    '    'Set _datLastConsideredDate To the first of the last month in the records
    '    '_datLastConsideredDate = DateSerial(Year(_datLastAvailabilityRecords), Month(_datLastAvailabilityRecords), 1)
    '    _datLastConsideredDate = DateSerial(Year(Now()), Month(Now()), 1)

    '    'Populate the cutoff dates
    '    Dim intLast() As Integer = {-1, -3, -6, -12, -24, -36}
    '    For intCount = 0 To _intAvailabilityFields
    '        _datLastCutoffDates(intCount) = DateSerial(Year(_datLastConsideredDate.AddMonths(intLast(intCount))), Month(_datLastConsideredDate.AddMonths(intLast(intCount))), 1)
    '    Next


    'End Sub

    'Private Sub PopulateMembersIDs()
    '    'Import the member details
    '    Dim objDebriefBusiness As New DebriefBusiness
    '    Dim memberDetails As List(Of Member) = objDebriefBusiness.MemberNames()

    '    'Redimension the class variables
    '    ReDim _strMemberID(memberDetails.GetUpperBound(1))
    '    ReDim _intNumberAvailability(_intNumberAvailability.GetUpperBound(0), memberDetails.GetUpperBound(1))
    '    ReDim _intTotalAvailability(_intTotalAvailability.GetUpperBound(0), memberDetails.GetUpperBound(1))
    '    ReDim _dblPercentageAvailability(_dblPercentageAvailability.GetUpperBound(0), memberDetails.GetUpperBound(1))

    '    'Input the IDs into _strMemberID
    '    For intCount = 0 To memberDetails.GetUpperBound(1)
    '        _strMemberID(intCount) = memberDetails(0, intCount)
    '    Next
    'End Sub

    'Private Sub CalculateAvailability()
    '    'The purpose of this routine is to calculate the availability for each member

    '    'Instantiate an index counter for _strAttendance
    '    Dim intAttendanceCount As Integer = 0
    '    Dim blnAttendanceStopLoop As Boolean = False

    '    'Instantiate a string array to store the IDs already examined on that day
    '    Dim strIDsExamined(0) As String
    '    Dim intIDsExamined As Integer = 0

    '    'Scan through the availability data, and incriment the numbers as required
    '    Dim intMemberIDLocation As Integer = -1
    '    Dim datExamining As DateTime = _datFirstAvailabilityRecords
    '    Do While datExamining <= _datLastConsideredDate
    '        'Examine the availability data
    '        blnAttendanceStopLoop = False
    '        ReDim strIDsExamined(_strMemberID.Length - 1)
    '        intIDsExamined = 0
    '        Do While intAttendanceCount <= _strAttendance.GetUpperBound(1) And blnAttendanceStopLoop = False
    '            'Determine the location of the member ID in _strMemberID
    '            intMemberIDLocation = Array.IndexOf(_strMemberID, _strAttendance(1, intAttendanceCount))
    '            If intMemberIDLocation >= 0 Then
    '                'Populate the availability numbers as required
    '                For intCountInner = 0 To _intAvailabilityFields
    '                    'Make sure that the date that we are examining is greater than or equal to the date last cutoff dates
    '                    If datExamining >= _datLastCutoffDates(intCountInner) And datExamining < _datLastConsideredDate Then
    '                        'Incriment the availability and total counters as required
    '                        _intNumberAvailability(intCountInner, intMemberIDLocation) += 1
    '                        _intTotalAvailability(intCountInner, intMemberIDLocation) += 1
    '                    End If
    '                Next

    '                'Add the member name to the list of those examined for this day
    '                strIDsExamined(intIDsExamined) = _strAttendance(1, intAttendanceCount)
    '                intIDsExamined += 1
    '            End If

    '            'Determine if we need to stop the loop
    '            If intAttendanceCount <> _strAttendance.GetUpperBound(1) Then
    '                'Check to see if the next index is also examining the same day. If not stop the looping process
    '                If Convert.ToDateTime(_strAttendance(0, intAttendanceCount + 1), New System.Globalization.CultureInfo("en-AU")) <> datExamining Then
    '                    'Stop the loop
    '                    blnAttendanceStopLoop = True
    '                End If
    '            End If

    '            'Incriment the attendance counter
    '            intAttendanceCount += 1
    '        Loop


    '        'Cylce through the rest of the members and see if they should have provided an availablity - i.e. they weren't probationary,
    '        'on leave or resigned
    '        For intCountOuter = 0 To _strMemberID.Length - 1
    '            'Check to see if we have already considered this member for this day
    '            If Array.IndexOf(strIDsExamined, _strMemberID(intCountOuter)) <= -1 Then
    '                'Check to see if they were on leave
    '                If MemberOnLeave(_strMemberID(intCountOuter), datExamining) = False Then
    '                    'Incriment the total counters as required
    '                    For intCountInner = 0 To _intAvailabilityFields
    '                        'Make sure that the date that we are examining is greater than or equal to the date last cutoff dates
    '                        If datExamining >= _datLastCutoffDates(intCountInner) And datExamining < _datLastConsideredDate Then
    '                            'Incriment total counter as required
    '                            _intTotalAvailability(intCountInner, intCountOuter) += 1
    '                        End If
    '                    Next
    '                End If
    '            End If
    '        Next

    '        'Incriment datExamining
    '        datExamining = datExamining.AddDays(1)
    '    Loop
    'End Sub

    ''Private Sub CalculateTotals()
    ''    'The purpose of the this function is to determine the number of days have passed:
    ''    '0 - Last Month
    ''    '1 - Last 3 Months
    ''    '2 - Last 6 Months
    ''    '3 - Last 12 Months
    ''    '4 - Last 24 Months
    ''    '5 - Last 36 Months
    ''    '
    ''    'If the number of days that have passed since we started collecting availability data is less than
    ''    'the number of days in any of the above elements, then the element will be set to the number of days
    ''    'since data collection started.

    ''    'Intantiate the return string
    ''    Dim intTotalDays(_intAvailabilityFields) As Integer

    ''    'Make sure that there is data to process
    ''    If _strAttendance(0, 0) <> Nothing Then
    ''        'Instantiate a datetime to store the first date that availability records exist from and another indicating the date
    ''        'of the last record
    ''        Dim tspDaysRecorded As TimeSpan = _datLastConsideredDate - _datFirstAvailabilityRecords

    ''        'Populate the return array
    ''        Dim tspDummy As TimeSpan
    ''        For intCount = 0 To _datLastCutoffDates.Length - 1
    ''            'Calculate the number of days in the specified period

    ''            tspDummy = _datLastConsideredDate - _datLastCutoffDates(intCount)

    ''            'Make sure that the number of days is less than the duration of the records that are being kept
    ''            If tspDummy.Days <= tspDaysRecorded.Days Then
    ''                intTotalDays(intCount) = tspDummy.Days
    ''            Else
    ''                intTotalDays(intCount) = tspDaysRecorded.Days
    ''            End If
    ''        Next
    ''    End If

    ''    'Store the data in the _intTotalAvailability
    ''    For intCountOuter = 0 To _intTotalAvailability.GetUpperBound(1)
    ''        For intCountInner = 0 To _intAvailabilityFields
    ''            _intTotalAvailability(intCountInner, intCountOuter) = intTotalDays(intCountInner)
    ''        Next
    ''    Next
    ''End Sub

    'Private Sub CalculatePercentages()
    '    'Caculate the percentages for each number of entries and total entries
    '    For intCountOuter = 0 To _intTotalAvailability.GetUpperBound(1)
    '        For intCountInner = 0 To _intAvailabilityFields
    '            _dblPercentageAvailability(intCountInner, intCountOuter) = CDbl((_intNumberAvailability(intCountInner, intCountOuter) / _
    '                                                                            _intTotalAvailability(intCountInner, intCountOuter)) * 100D)
    '        Next
    '    Next
    'End Sub

    'Private Function MemberOnLeave(ByVal strMemberID As String, ByVal datToExamine As DateTime) As Boolean
    '    'The purpose of this routine is to reduce the numbers and total for members who have recently started or those who have been on
    '    'leave

    '    'See if we need to calculate the service histroy data
    '    If _strServiceMemberID(0) = Nothing Then
    '        'Retreive the service history data
    '        Dim objDebriefBusiness As New DebriefBusiness
    '        Dim intHistoryStatus() As Integer = New Integer(0) {}
    '        Dim strServiceHistory(,) As String = objDebriefBusiness.MemberServiceHistory(intHistoryStatus)

    '        'ReDimension _datServiceStartDate to accomodate all members
    '        ReDim _datServiceStartDate(_strMemberID.Length - 1)

    '        'Determine when members we unavailable
    '        Dim intMemberIDLocation As Integer = -1
    '        Dim strMemberExamining As String = ""
    '        For intCount = 0 To strServiceHistory.GetUpperBound(1)
    '            'Determine the location of the memnber ID examining in _strMemberID
    '            intMemberIDLocation = Array.IndexOf(_strMemberID, strServiceHistory(0, intCount))

    '            'Set each members start date - this will be the first entry for each member
    '            If strServiceHistory(0, intCount) <> strMemberExamining Then
    '                'Set the start date
    '                If intMemberIDLocation >= 0 Then
    '                    _datServiceStartDate(intMemberIDLocation) = Convert.ToDateTime(strServiceHistory(1, intCount), _
    '                                                                                   New System.Globalization.CultureInfo("en-AU"))
    '                End If

    '                'Set strMemberExamining
    '                strMemberExamining = strServiceHistory(0, intCount)
    '            End If

    '            'If strMemberExamining = "ses64453" Then
    '            '    Dim bytTellMe As Byte = 0
    '            'End If

    '            'Examine each index to see if the data holds any of the above mentioned items
    '            If strServiceHistory(3, intCount) = "Probationary Member" Or _
    '               strServiceHistory(3, intCount) = "Resigned" Or _
    '               strServiceHistory(3, intCount) = "Associate Member" Or _
    '               Strings.Right(strServiceHistory(3, intCount), 10) = "(On Leave)" Then
    '                'If intHistoryStatus(intCount) <> 3 Then ' Operational
    '                'Then member is unavailable to turn out

    '                'See if we care about the member id
    '                If intMemberIDLocation >= 0 Then
    '                    'ReDimension the parallel arrays
    '                    ReDim Preserve _strServiceMemberID(_intService)
    '                    ReDim Preserve _datServiceEntryStartDate(_intService)
    '                    ReDim Preserve _datServiceEntryEndDate(_intService)
    '                    ReDim Preserve _intHistoryStatus(_intService)

    '                    'Store the data
    '                    _strServiceMemberID(_intService) = strServiceHistory(0, intCount)
    '                    _datServiceEntryStartDate(_intService) = Convert.ToDateTime(strServiceHistory(1, intCount), _
    '                                                                                New System.Globalization.CultureInfo("en-AU"))
    '                    _datServiceEntryEndDate(_intService) = Convert.ToDateTime(strServiceHistory(2, intCount), _
    '                                                                              New System.Globalization.CultureInfo("en-AU"))
    '                    _intHistoryStatus(_intService) = intHistoryStatus(intCount)

    '                    'Incriment the counter
    '                    _intService += 1
    '                End If
    '            End If
    '        Next
    '    End If

    '    'Instantiate the return boolean
    '    Dim blnReturn As Boolean = False

    '    'Determine the first index of the specified member in _strServiceMemberID
    '    Dim intIndex As Integer = _objAppFunctions.LocateIndex(_strServiceMemberID, strMemberID)
    '    If intIndex >= 0 Then
    '        'Check to make sure that the member Start Date is on or after datToExamine
    '        Dim intStartDateIndex As Integer = Array.IndexOf(_strMemberID, strMemberID)
    '        If intStartDateIndex >= 0 Then
    '            If datToExamine >= _datServiceStartDate(intStartDateIndex) Then
    '                'Loop through and see if the member was on leave
    '                Dim blnStopLoop As Boolean = False
    '                Do While intIndex <= _strServiceMemberID.Length - 1 And blnStopLoop = False
    '                    'Look to see if the values the date supplied is between the dates indicated at this index
    '                    If datToExamine >= _datServiceEntryStartDate(intIndex) And datToExamine < _datServiceEntryEndDate(intIndex) Then
    '                        'We have found a match so set blnReturn and blnStopLoop to True
    '                        blnReturn = True
    '                        blnStopLoop = True
    '                    Else
    '                        'Check to see if the same member ID exists at the next index
    '                        If intIndex <> _strServiceMemberID.Length - 1 Then
    '                            If _strServiceMemberID(intIndex + 1) = strMemberID Then
    '                                'Incriment the counter
    '                                intIndex += 1
    '                            Else
    '                                blnStopLoop = True
    '                            End If
    '                        Else
    '                            'Stop the loop
    '                            blnStopLoop = True
    '                        End If
    '                    End If
    '                Loop
    '            Else
    '                'Set blnReturn to True
    '                blnReturn = True
    '            End If
    '        End If
    '    End If

    '    Return blnReturn
    'End Function
End Class
