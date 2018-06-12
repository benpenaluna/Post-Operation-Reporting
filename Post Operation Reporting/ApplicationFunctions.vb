Option Strict On

Public Class ApplicationFunctions

    Sub New()

    End Sub

    'Instantiate strings to determine the file path
    Shared _strSubDirectory As String = "Source Data\"

    'Instantiate string arrays which will be used to store received string array's in the CompositeKeyExists routine -
    'This will save a lot of computations if we do not need to re-examine that the same array is sorted
    Dim _strReceivedArray(,) As String
    Dim _strSortedArray(,) As String

    Shared Function FilePath() As String
        'Determine Resource File Path to change the form icon based on Debugging mode or Published mode
        Dim strFilePath As String
        If System.Diagnostics.Debugger.IsAttached() Then
            'In Debugging mode   
            strFilePath = System.IO.Path.GetFullPath(Application.StartupPath & "\..\..\resources\")
        Else
            'In Published mode   
            strFilePath = Application.StartupPath & "\"
        End If

        Return strFilePath
    End Function

    Shared Function GetDebriefDataFileName() As String
        Return _strSubDirectory & "DebriefData.txt"
    End Function

    Shared Function GetMemberDetailsFileName() As String
        Return _strSubDirectory & "MemberDetails.txt"
    End Function

    Function GetTempDataFileName() As String
        Return _strSubDirectory & "ReportData.tmp"
    End Function

    Function GetTempMembersFileName() As String
        Return _strSubDirectory & "MembersAttending.tmp"
    End Function

    Function GetServiceHistory() As String
        Return _strSubDirectory & "MemberServiceHistory.txt"
    End Function

    Function GetDebriefData() As String
        Return _strSubDirectory & "DebriefData.txt"
    End Function

    Shared Function GetMemberAttendingData() As String
        Return _strSubDirectory & "MembersAttending.txt"
    End Function

    Function GetSummaryData() As String
        Return _strSubDirectory & "SummaryData.txt"
    End Function

    Function GetIndiSummaryData() As String
        Return _strSubDirectory & "IndiSummaryData.txt"
    End Function

    Function GetAvailabilityData() As String
        Return _strSubDirectory & "AvailabilityData.txt"
    End Function

    Function GetLoginData() As String
        Return _strSubDirectory & "LoginData.txt"
    End Function

    Shared Function GetJobTypeData() As String
        If System.Diagnostics.Debugger.IsAttached() Then
            Return "JobType.txt"
        Else
            Return _strSubDirectory & "JobType.txt"
        End If
    End Function

    Shared Function GetTaskUndertakenData() As String
        If System.Diagnostics.Debugger.IsAttached() Then
            Return "Tasks.txt"
        Else
            Return _strSubDirectory & "Tasks.txt"
        End If
    End Function


    '---SUPPORTING SUBROUTINES---

    Function SplitCSV(ByVal strReference As String) As String()
        'Instantiate a boolean to indicate if there is an open or closed quotation mark
        Dim blnQuotationOpen As Boolean = False

        'Instantiate a counter store the data in the return string
        Dim strSplits(0) As String
        Dim intSplitIndex As Integer = 0

        'Convert the reference string to a character array
        Dim chrReference() As Char = strReference.ToCharArray()

        'Scan the reference string and populate strSplits
        For intCount = 0 To chrReference.Length - 1
            'Determine if the we are reader a quotation mark
            If chrReference(intCount) = Chr(34) Then 'flick the blnQuotationOpenSwitch
                If blnQuotationOpen = False Then
                    blnQuotationOpen = True
                Else
                    blnQuotationOpen = False
                End If
            ElseIf chrReference(intCount) = Chr(44) And blnQuotationOpen = False Then
                'We are examining a comma that is not contained within quotation marks, so increase the size of the array
                intSplitIndex += 1
                ReDim Preserve strSplits(intSplitIndex)
            Else
                'Add the character to the correct index in the return array
                strSplits(intSplitIndex) += chrReference(intCount)
            End If
        Next

        Return strSplits
    End Function

    Function CompositeKeyExists(ByVal strReference(,) As String, ByVal strMainKey As String, ByVal strSubKey As String,
                                ByVal intMainIndex As Integer, ByVal intSubIndex As Integer) As Boolean
        'The purpose of this routine is to return a boolean indicating if the composite key exists in the received array

        'Instantiate the return boolean
        Dim blnReturn As Boolean = False

        'Instantiate a string to store the main key examining, and boolean to indicate if the array is sorted
        'Dim strMainKeyExamining As String = strReference(intMainIndex, 0)
        Dim blnArraySorted As Boolean = True

        'Instantiate a counter
        Dim intCount As Integer

        'See if we have already examined this array previously
        If strReference Is _strReceivedArray Then
            'Set strReference to _strSortedArray
            strReference = _strSortedArray
        Else
            'Set the received array before any changes are made
            _strReceivedArray = strReference
            _strSortedArray = strReference

            'Make sure that there is sufficient data in the array to warrant checking to see if it is sorted
            If strReference.GetUpperBound(1) >= 1 Then
                'Ensure that the received array is sorted
                intCount = 1
                Do While intCount <= strReference.GetUpperBound(1) And blnArraySorted = True
                    ''See if we are exmaining the same main key
                    'If strReference(intMainIndex, intCount) = strReference(intMainIndex, intCount - 1) Then
                    '    'Check that the sub key is greater than the one before it
                    '    If strReference(intSubIndex, intCount) < strReference(intSubIndex, intCount - 1) Then
                    '        'Set blnArraySorted To False
                    '        blnArraySorted = False
                    '    End If

                    'Else 'Then we are examining a new main key so make sure that it is greater than the one before if
                    If Not strReference(intMainIndex, intCount) >= strReference(intMainIndex, intCount - 1) Then
                        'Set blnArraySorted To False
                        blnArraySorted = False
                    End If
                    'End If

                    'Incriment intCount 
                    intCount += 1
                Loop
            End If
        End If

        'See if the array needs to be sorted
        If blnArraySorted = False Then
            'Sort the array and store the results in _strSortedArray so that it may be used again later is required
            _strSortedArray = MultiSort(strReference, intMainIndex, -1)

            'Set the reference array to the sorted array
            strReference = _strSortedArray
        End If


        'Now that the recieved array is definitely sorted, locate the first index of strMainKey
        Dim intFirstMainIndex As Integer = LocateIndex(strReference, strMainKey, intMainIndex)

        'Makse sure that a result was found
        If intFirstMainIndex >= 0 Then
            'Scan the array to see if there is a match
            Dim blnStopLoop As Boolean = False
            Do While intFirstMainIndex <= strReference.GetUpperBound(1) And blnStopLoop = False
                'Check to make sure that we are still examining the strMainKey
                If strReference(intMainIndex, intFirstMainIndex) = strMainKey Then
                    'Check to see if the element at this index is the same as strSubKey
                    If strReference(intSubIndex, intFirstMainIndex) = strSubKey Then
                        'A solution has been found
                        blnReturn = True

                        'Stop the loop
                        blnStopLoop = True
                    End If
                Else
                    'Stop the looping process - no solution found
                    blnStopLoop = True
                End If

                'Incriment the counter
                intFirstMainIndex += 1
            Loop
        End If

        Return blnReturn
    End Function

    Function MultiSort(ByVal intReference(,) As Integer, ByVal intMainIndex As Integer,
                       Optional intSubIndex As Integer = -1) As Integer(,)
        'Convert the received integer array to any object
        Dim objReference(intReference.GetUpperBound(0), intReference.GetUpperBound(1)) As Object

        For intCountOuter = 0 To intReference.GetUpperBound(1)
            For intCountInner = 0 To intReference.GetUpperBound(0)
                objReference(intCountInner, intCountOuter) = intReference(intCountInner, intCountOuter)
            Next
        Next

        objReference = MultiSort(objReference, intMainIndex, intSubIndex)

        For intCountOuter = 0 To intReference.GetUpperBound(1)
            For intCountInner = 0 To intReference.GetUpperBound(0)
                intReference(intCountInner, intCountOuter) = CInt(objReference(intCountInner, intCountOuter))
            Next
        Next

        Return intReference
    End Function

    Function MultiSort(ByVal strReference(,) As String, ByVal intMainIndex As Integer,
                       Optional intSubIndex As Integer = -1) As String(,)
        'Convert the received integer array to any object
        Dim objReference(strReference.GetUpperBound(0), strReference.GetUpperBound(1)) As Object

        For intCountOuter = 0 To strReference.GetUpperBound(1)
            For intCountInner = 0 To strReference.GetUpperBound(0)
                objReference(intCountInner, intCountOuter) = strReference(intCountInner, intCountOuter)
            Next
        Next

        objReference = MultiSort(objReference, intMainIndex, intSubIndex)

        For intCountOuter = 0 To strReference.GetUpperBound(1)
            For intCountInner = 0 To strReference.GetUpperBound(0)
                strReference(intCountInner, intCountOuter) = CStr(objReference(intCountInner, intCountOuter))
            Next
        Next

        Return strReference
    End Function

    Function MultiSort(ByVal datReference(,) As DateTime, ByVal intMainIndex As Integer,
                       Optional intSubIndex As Integer = -1) As DateTime(,)
        'Convert the received integer array to any object
        Dim objReference(datReference.GetUpperBound(0), datReference.GetUpperBound(1)) As Object

        For intCountOuter = 0 To datReference.GetUpperBound(1)
            For intCountInner = 0 To datReference.GetUpperBound(0)
                objReference(intCountInner, intCountOuter) = datReference(intCountInner, intCountOuter)
            Next
        Next

        objReference = MultiSort(objReference, intMainIndex, intSubIndex)

        For intCountOuter = 0 To datReference.GetUpperBound(1)
            For intCountInner = 0 To datReference.GetUpperBound(0)
                datReference(intCountInner, intCountOuter) = CDate(objReference(intCountInner, intCountOuter))
            Next
        Next

        Return datReference
    End Function


    Private Function MultiSort(ByVal objReference(,) As System.Object, ByVal intMainIndex As Integer,
                       Optional intSubIndex As Integer = -1) As Object(,)
        'The purpose of this routine is to sort the received array by the column defined in intMainIndex, then by the column
        'defined in intSubIndex 

        'Instantiate a temporary array to store the sorted data
        Dim objTempReference(objReference.GetUpperBound(0), objReference.GetUpperBound(1)) As Object


        '---SORT THE MAIN TIER---

        'Instantiate an array to sort the temporal order
        Dim objMainIndex(objReference.GetUpperBound(1)) As Object
        Dim intIndex(objReference.GetUpperBound(1)) As Integer

        'Transfer the data from the the main index in objReference to objTempMainIndex for sortin
        For intCount = 0 To objReference.GetUpperBound(1)
            objMainIndex(intCount) = objReference(intMainIndex, intCount)
            intIndex(intCount) = intCount
        Next

        'Now that the parallel arrays are populated, we can sort the data by attainment date.
        Array.Sort(objMainIndex, intIndex)

        'Now sort the parallel arrays based on intIndex
        For intCountOuter = 0 To objReference.GetUpperBound(1)
            For intCountInner = 0 To objReference.GetUpperBound(0)
                'Sort the Data
                objTempReference(intCountInner, intCountOuter) = objReference(intCountInner, intIndex(intCountOuter))
            Next
        Next

        'Now to avoid later confusion, place the data in the temporary arrays back into the main array
        objReference = objTempReference



        '---SORT THE SECOND TIER---

        'Make sure that the user has specified an index to sort on
        If intSubIndex >= 0 And intSubIndex <> intMainIndex Then
            'Instantiate a boolean that we act as a switch to indicate weather or not the sorting code should commence.
            Dim blnCommenceSort As Boolean = False

            'Prime the loop
            Dim intFirstIndex As Integer = 0
            Dim intLastIndex As Integer = 0
            Dim intIndexCounter As Integer = 0 'This will keep which index we are up to
            Dim objElementBeingExamined As Object = objReference(0, 0)
            Dim objSubIndex() As Object

            'Start the sort process
            For intIndexCounter = 1 To objReference.GetUpperBound(1)
                'Check to see of the element in the intMainIndex is the same some that we are examining
                If objReference(intMainIndex, intIndexCounter).ToString = objElementBeingExamined.ToString Then
                    'Reset intLastIndex to the current value of intIndexCounter
                    intLastIndex = intIndexCounter

                    'We then need to ask if this is the last entry in the array. If so then, we need to sort it, as the loop will not re-enter to
                    'do so.
                    If intIndexCounter = objReference.GetUpperBound(1) Then 'Sort the second tier
                        'Set blnCommenceSort to True so that the sorting process will commence
                        blnCommenceSort = True
                    End If
                Else 'this element is not the same as the last one.
                    'Determine how many entries there are
                    If intLastIndex > intFirstIndex Then 'There is more than one entry
                        'Set blnCommenceSort to True so that the sorting process will commence
                        blnCommenceSort = True
                    Else 'There is only one entry - i.e. no need to sort
                        'Reset intFirstIndex, intLastIndex and strAccredBeingExamined
                        intFirstIndex = intIndexCounter
                        intLastIndex = intIndexCounter
                        objElementBeingExamined = objReference(intMainIndex, intIndexCounter)
                    End If
                End If

                'Sort the data if blnCommenceSort is true. This code is here instead of within the body of the If statements, because if it were 
                'located there, then the code would need to be entered twice, which creates difficulty if it needs to be modified in the future.
                If blnCommenceSort = True Then 'Commence the sorting process
                    'ReDimension the parallel arrays excluding elements with the same element at intMainIndex to the 
                    'length of intLastIndex - intFirstIndex
                    ReDim objTempReference(objReference.GetUpperBound(0), intLastIndex - intFirstIndex)

                    'Populate the temporary arrays with the required data to be sorted. We are using the temporary arrays since they are already
                    'instantiated, and no longer required by the first sorting process.
                    ReDim objSubIndex(intLastIndex - intFirstIndex)
                    ReDim intIndex(intLastIndex - intFirstIndex)
                    For intCount = intFirstIndex To intLastIndex
                        objSubIndex(intCount - intFirstIndex) = objReference(intSubIndex, intCount)
                        intIndex(intCount - intFirstIndex) = intCount
                    Next

                    'Sort the temporary name array
                    Array.Sort(objSubIndex, intIndex)

                    'Now sort the parallel arrays based on intIndex
                    For intCountOuter = intFirstIndex To intLastIndex
                        For intCountInner = 0 To objReference.GetUpperBound(0)
                            'Store the data
                            objTempReference(intCountInner, intCountOuter - intFirstIndex) =
                                objReference(intCountInner, intIndex(intCountOuter - intFirstIndex))
                        Next
                    Next

                    'Now we need to get the required data back into the main array
                    For intCountOuter = intFirstIndex To intLastIndex
                        For intCountInner = 0 To objTempReference.GetUpperBound(0)
                            objReference(intCountInner, intCountOuter) = objTempReference(intCountInner, intCountOuter - intFirstIndex)
                        Next
                    Next

                    'Reset intFirstIndex, intLastIndex and objElementBeingExamined
                    intFirstIndex = intIndexCounter
                    intLastIndex = intIndexCounter
                    objElementBeingExamined = objReference(0, intIndexCounter)

                    'Reset blnCommenceSort so that it is not inadvertently triggered on the next iteration
                    blnCommenceSort = False
                End If
            Next
        End If

        Return objReference
    End Function

    Function LocateIndex(ByVal strReferenceArray() As String, ByVal strReference As String) As Integer
        'The aim of this routine is to return the index of the reference element (strReference) in the reference array received (strReferenceArray). 
        'If it doesn't exist, return -1. This routine will assume that strReferenceArray has been sorted aphabetically.


        'Dim intReturn As Integer = -1
        'If strReferenceArray.GetUpperBound(1) >= 1 Then
        'Use the bisection method to locate the index of the reference element
        'Instantiate the variables required for the routine
        Dim intReturn As Integer = -1

        'Make sure that strReferenceArray <> Nothing
        If strReferenceArray.Length - 1 >= 1 Then
            Dim intA As Integer = 0
            Dim intB As Integer = strReferenceArray.Length - 1
            Dim intIndex As Integer = CInt((intB - intA) / 2) + intA

            'Loop until either a solution is found (i.e. the received reference element equals a reference element in strReferenceArray), or the sum of
            'intB - intA has reduced to 1 or less, which indicates that the reference code does not exist within strReferenceArray
            '(i.e. there is no reference element within strReferenceArray).
            'Select Case intWhichIndex
            'Case Is >= 0
            Do Until (intB - intA) <= 1 Or strReferenceArray(intIndex) = strReference
                If strReferenceArray(intIndex) < strReference Then
                    intA = intIndex
                Else 'strReferenceArray(intWhichIndex,intIndex) > strReference
                    intB = intIndex
                End If

                'Recalculate intIndex
                intIndex = CInt((intB - intA) / 2) + intA
            Loop

            'Next determine why the loop finished - was a solution found (intB-intA > 1) of did it run out of elements to examine (intB-intA <= 1).
            If (intB - intA) <= 1 Then 'No solution was found
                'Double check to make sure that the elements above and below intIndex do not contain the reference element. This check is merely to
                'avoid any error within the method.
                If intIndex = 0 Then
                    If strReferenceArray(intIndex) = strReference Then
                        intReturn = intIndex
                    ElseIf strReferenceArray(intIndex + 1) = strReference Then
                        intReturn = intIndex + 1
                    Else
                        intReturn = -1
                    End If
                ElseIf intIndex > 0 And intIndex < strReferenceArray.Length - 1 Then
                    If strReferenceArray(intIndex - 1) = strReference Then 'No soution was found
                        intReturn = intIndex - 1
                    ElseIf strReferenceArray(intIndex + 1) = strReference Then
                        intReturn = intIndex + 1
                    Else
                        intReturn = -1
                    End If
                ElseIf intIndex = strReferenceArray.Length - 1 Then
                    If strReferenceArray(intIndex) = strReference Then 'No soution was found
                        intReturn = intIndex
                    ElseIf strReferenceArray(intIndex - 1) = strReference Then
                        intReturn = intIndex - 1
                    Else
                        intReturn = -1
                    End If
                End If
            Else 'A solution was found

                'Since more that one reference element may exist within the received array, work examine the element before that element at intIndex to determine if
                'it is also the reference element. Continue to do this until this condition is no longer true to there are no more elements to examine
                Dim blnStopLoop As Boolean = False
                Do While blnStopLoop = False
                    If intIndex <> 0 Then 'We may examine the previous element
                        If strReferenceArray(intIndex - 1) = strReference Then
                            'Reset intIndex for use in the following loop
                            intIndex -= 1
                        Else 'This is the solution that we want
                            'Set intReturn
                            intReturn = intIndex

                            'Stop the loop
                            blnStopLoop = True
                        End If
                    Else 'intIndex = 0, there are no more previuos elements to examine
                        'Set intReturn equal to intIndex
                        intReturn = intIndex

                        'Set blnStopLoop
                        blnStopLoop = True
                    End If
                Loop
            End If
            'Case Else 'We must search all elements of the array for the particulat strReference

            'End Select
        Else
            'Check to see if strReference is in the first index
            If strReferenceArray(0) = strReference Then
                intReturn = 0
            End If
        End If

        Return intReturn
    End Function

    Function LocateIndex(ByVal strReferenceArray(,) As String, ByVal strReference As String, Optional ByVal intWhichIndex As Integer = 0) As Integer
        'The aim of this routine is to return the index of the reference element (strReference) in the reference array received (strReferenceArray). 
        'If it doesn't exist, return -1. This routine will assume that strReferenceArray has been sorted aphabetically.


        'Dim intReturn As Integer = -1
        'If strReferenceArray.GetUpperBound(1) >= 1 Then
        'Use the bisection method to locate the index of the reference element
        'Instantiate the variables required for the routine
        Dim intReturn As Integer = -1

        'Make sure that strReferenceArray <> Nothing
        If strReferenceArray.GetUpperBound(1) >= 1 Then
            Dim intA As Integer = 0
            Dim intB As Integer = strReferenceArray.GetUpperBound(1)
            Dim intIndex As Integer = CInt((intB - intA) / 2) + intA

            'Loop until either a solution is found (i.e. the received reference element equals a reference element in strReferenceArray), or the sum of
            'intB - intA has reduced to 1 or less, which indicates that the reference code does not exist within strReferenceArray
            '(i.e. there is no reference element within strReferenceArray).
            Select Case intWhichIndex
                Case Is >= 0
                    Do Until (intB - intA) <= 1 Or strReferenceArray(intWhichIndex, intIndex) = strReference
                        If strReferenceArray(intWhichIndex, intIndex) < strReference Then
                            intA = intIndex
                        Else 'strReferenceArray(intWhichIndex,intIndex) > strReference
                            intB = intIndex
                        End If

                        'Recalculate intIndex
                        intIndex = CInt((intB - intA) / 2) + intA
                    Loop

                    'Next determine why the loop finished - was a solution found (intB-intA > 1) of did it run out of elements to examine (intB-intA <= 1).
                    If (intB - intA) <= 1 Then 'No solution was found
                        'Double check to make sure that the elements above and below intIndex do not contain the reference element. This check is merely to
                        'avoid any error within the method.
                        If intIndex = 0 Then
                            If strReferenceArray(intWhichIndex, intIndex) = strReference Then
                                intReturn = intIndex
                            ElseIf strReferenceArray(intWhichIndex, intIndex + 1) = strReference Then
                                intReturn = intIndex + 1
                            Else
                                intReturn = -1
                            End If
                        ElseIf intIndex > 0 And intIndex < strReferenceArray.Length - 1 Then
                            If strReferenceArray(intWhichIndex, intIndex - 1) = strReference Then 'No soution was found
                                intReturn = intIndex - 1
                            ElseIf strReferenceArray(intWhichIndex, intIndex + 1) = strReference Then
                                intReturn = intIndex + 1
                            Else
                                intReturn = -1
                            End If
                        ElseIf intIndex = strReferenceArray.GetUpperBound(1) Then
                            If strReferenceArray(intWhichIndex, intIndex) = strReference Then 'No soution was found
                                intReturn = intIndex
                            ElseIf strReferenceArray(intWhichIndex, intIndex - 1) = strReference Then
                                intReturn = intIndex - 1
                            Else
                                intReturn = -1
                            End If
                        End If
                    Else 'A solution was found

                        'Since more that one reference element may exist within the received array, work examine the element before that element at intIndex to determine if
                        'it is also the reference element. Continue to do this until this condition is no longer true to there are no more elements to examine
                        Dim blnStopLoop As Boolean = False
                        Do While blnStopLoop = False
                            If intIndex <> 0 Then 'We may examine the previous element
                                If strReferenceArray(intWhichIndex, intIndex - 1) = strReference Then
                                    'Reset intIndex for use in the following loop
                                    intIndex -= 1
                                Else 'This is the solution that we want
                                    'Set intReturn
                                    intReturn = intIndex

                                    'Stop the loop
                                    blnStopLoop = True
                                End If
                            Else 'intIndex = 0, there are no more previuos elements to examine
                                'Set intReturn equal to intIndex
                                intReturn = intIndex

                                'Set blnStopLoop
                                blnStopLoop = True
                            End If
                        Loop
                    End If
                Case Else 'We must search all elements of the array for the particulat strReference

            End Select
        Else
            'Check to see if strReference is in the first index
            If strReferenceArray(intWhichIndex, 0) = strReference Then
                intReturn = 0
            End If
        End If

        Return intReturn
    End Function
End Class
