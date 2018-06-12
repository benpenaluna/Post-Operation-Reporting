'Program: Member Statistics Report
'Author: Ben Penaluna
'Date: 29 Novemmber 2013
'Purpose: To determine the report parameters from the user, and generate the subsequent report

Option Strict On

Public Class frmMemberStatistics
    ''Instantiate links to other classes
    'Dim _objBusiness As New DebriefBusiness
    'Dim _objIRSBusiness As New ImportIRSBusiness

    ''Initialise the class variable parallel arrays to store the individual user details
    'Dim _memberDetails(,) As List(Of Member)
    'Dim _bytCheckedName(1) As Byte

    ''Instantiate a string to store all the names of the members in the order that they appear in _memberDetails for later use of 
    ''Array.IndexOf
    'Dim _strID(0) As String
    'Dim _strCombinedNames(0) As String

    ''Create an integer array to store the number of days for each of the availabilites
    'Dim _intTotalDaysAvailability() As Integer

    ''Instantiate a string to store the availability data for the selected member
    'Dim _strAvailability() As String

    ''Instantiate a switch to indicate if the form has been loaded, and another to skip code to skip code to handle multiple runnings of code
    ''when status radio buttons are changed
    'Dim _blnFormLoaded As Boolean = False
    ''Dim _intCodeSkip As Integer = 0

    'Private Sub frmMemberStatistics_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    '    'Change the cursor to the wait cursor
    '    Me.Cursor = Cursors.WaitCursor

    '    'Set the dimensions of the form to fill the parent container
    '    Me.Dock = DockStyle.Fill

    '    'Re-szie the form controls
    '    SetControlDimensions()

    '    'Retrieve the member names
    '    _memberDetails = _objBusiness.MemberNames(True)

    '    'Place all the member names into strCombinedNames
    '    ReDim Preserve _strID(_memberDetails.GetUpperBound(1))
    '    ReDim Preserve _strCombinedNames(_memberDetails.GetUpperBound(1))
    '    For intCount = 0 To _memberDetails.GetUpperBound(1)
    '        _strID(intCount) = _memberDetails(0, intCount)
    '        _strCombinedNames(intCount) = _memberDetails(1, intCount)
    '    Next

    '    'ReDimension _bytCheckedNames 
    '    ReDim _bytCheckedName(_memberDetails.GetUpperBound(1))

    '    'Sort the combined member names into the correct order. We must also ensure to sort _strSurname, _strFirstName, _strID and _intStatus
    '    'into the same order
    '    SortCombinedNames()

    '    'Populate clbMembers with the received members
    '    DisplayCurrentMembers()

    '    'Set _blnFormLoaded to True
    '    _blnFormLoaded = True

    '    'Now that the form is loaded, change the cursor back to pointer
    '    Me.Cursor = Cursors.Default
    'End Sub

    'Private Sub frmMemberStatistics_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Me.Dispose()
    'End Sub

    'Private Sub rbtAllMembers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rbtAllMembers.Checked = True Or rbtAllCurrentMembers.Checked = True Then
    '        gpbStatus.Enabled = False
    '        chkCheckAllNames.Enabled = False
    '        clbMembers.Enabled = False
    '    Else ' rbtSelectedMembers must be selected
    '        gpbStatus.Enabled = True
    '        chkCheckAllNames.Enabled = True
    '        clbMembers.Enabled = True
    '    End If
    'End Sub

    'Private Sub rbtStatus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    If _blnFormLoaded = True Then
    '        Dim SelectedRadioButton As RadioButton = DirectCast(sender, RadioButton)

    '        Select Case SelectedRadioButton.Name
    '            Case rbtStatusCurrentMembers.Name
    '                DisplayCurrentMembers()
    '            Case rbtStatusResignedMembers.Name
    '                DisplayResignedMembers()
    '            Case rbtStatusAllMembers.Name
    '                DisplayAllMembers()
    '        End Select

    '        'Check all previously checked names if they exist in the list unless check all names is selected
    '        Select Case chkCheckAllNames.Checked
    '            Case True
    '                CheckAllNames()
    '            Case False
    '                CheckPreviouslyCheckedName()
    '        End Select
    '    End If
    'End Sub

    'Private Sub chkCheckAllNames_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    CheckAllNames()
    'End Sub

    'Private Sub clbMembers_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SaveCheckedNames()
    'End Sub

    'Private Sub cboMember_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboMember.SelectedIndexChanged
    '    'The event will trigger the totals and percentages to be changed

    '    'Populate the availability totals
    '    PopuluateAvailability()

    '    'Update display
    '    UpdateAvailabilityDisplay()

    'End Sub



    ''---ADDITIONAL SUBROUTINES---

    'Private Sub SetControlDimensions()
    '    'Re-size the tab control
    '    tbcStatistics.Size = New Size(Me.DisplayRectangle.Width - 2 * 12, Me.DisplayRectangle.Height - 2 * 12)

    '    'Resize pnlMemberStats
    '    pnlAttendance.Size = New Size(tbcStatistics.DisplayRectangle.Width - 2 * pnlAttendance.Location.X,
    '                                   tbcStatistics.DisplayRectangle.Height - pnlAttendance.Location.Y - pnlAttendance.Location.X)
    'End Sub

    'Private Sub SortCombinedNames()
    '    ''The purpose of this routine is to sort all combined names into alphabetical order so that they are displayed on the screen to the user
    '    ''in alphabetical order

    '    ''Store _strSurname, _strFirstName, _strID and _intStatus into temporary arrays.
    '    'Dim strTempMemberDetails(_memberDetails.GetUpperBound(0), _memberDetails.GetUpperBound(1)) As String

    '    ''Instantiate an array to will serve to indicate the new location of the indicies
    '    'Dim intIndex(1) As Integer

    '    ''Populate intIndex
    '    'For intCount = 0 To _strCombinedNames.Length - 1
    '    '    'Redimension intCount is necessary to accomodate another entry
    '    '    If intCount > 1 Then
    '    '        ReDim Preserve intIndex(intCount)
    '    '    End If

    '    '    'Populate intIndex
    '    '    intIndex(intCount) = intCount
    '    'Next

    '    ''Sort _strCombinedNames into alphabetical order and intIndex subject to that
    '    'Array.Sort(_strCombinedNames, intIndex)

    '    ''Sort the remaining arrays (_strSurname, _strFirstName, _strID and _intStatus) subject to _strCombinedNames
    '    'Dim intLoopIndex As Integer
    '    'For intCountOuter = 0 To _memberDetails.GetUpperBound(1)
    '    '    'Set intLoopIndex
    '    '    intLoopIndex = intIndex(intCountOuter)

    '    '    For intCountInner = 0 To _memberDetails.GetUpperBound(0)
    '    '        strTempMemberDetails(intCountInner, intCountOuter) = _memberDetails(intCountInner, intLoopIndex)
    '    '    Next
    '    'Next

    '    ''Repopulate _memberDetails
    '    '_memberDetails = strTempMemberDetails
    'End Sub

    'Private Sub DisplayCurrentMembers()
    '    clbMembers.Items.Clear()
    '    cboMember.Items.Clear()
    '    For intCount = 0 To _memberDetails.GetUpperBound(1)
    '        If _memberDetails(2, intCount) <> "5" Then
    '            clbMembers.Items.Add(_memberDetails(1, intCount))
    '            cboMember.Items.Add(_memberDetails(1, intCount))
    '        End If
    '    Next

    '    'Set the current index of cboMember
    '    If cboMember.Items.Count > 0 Then
    '        cboMember.SelectedIndex = 0
    '    End If
    'End Sub

    'Private Sub DisplayResignedMembers()
    '    'If _intCodeSkip Mod 2 = 0 Then
    '    clbMembers.Items.Clear()
    '    For intCount = 0 To _memberDetails.GetUpperBound(1)
    '        If _memberDetails(2, intCount) = "5" Then
    '            clbMembers.Items.Add(_memberDetails(1, intCount))
    '        End If
    '    Next
    '    'End If

    '    'Incriment the code skip integer
    '    '_intCodeSkip += 1
    'End Sub

    'Private Sub DisplayAllMembers()
    '    'If _intCodeSkip Mod 2 = 0 Then
    '    clbMembers.Items.Clear()
    '    For intCount = 0 To _memberDetails.GetUpperBound(1)
    '        clbMembers.Items.Add(_memberDetails(1, intCount))
    '    Next
    '    'End If

    '    'Incriment the code skip integer
    '    '_intCodeSkip += 1
    'End Sub

    'Private Sub CheckAllNames()
    '    If chkCheckAllNames.Checked = True Then
    '        'Check all the names in the list
    '        For intCount = 0 To clbMembers.Items.Count - 1
    '            clbMembers.SetItemChecked(intCount, True)
    '        Next

    '        'Ensure that _bytCheckedNames reflects the selected names in the list
    '        SaveCheckedNames()
    '    Else 'Users want all items unchecked
    '        'Uncheck all the names in the list
    '        For intCount = 0 To clbMembers.Items.Count - 1
    '            clbMembers.SetItemChecked(intCount, False)
    '        Next

    '        'Ensure that _bytCheckedNames reflects the selected names in the list
    '        SaveCheckedNames()
    '    End If
    'End Sub

    'Private Sub SaveCheckedNames()
    '    'Ensure that all values in _bytCheckedName = 0
    '    For intCount = 0 To _bytCheckedName.Length - 1
    '        _bytCheckedName(intCount) = 0
    '    Next

    '    'Set the value of _bytCheckedName(intCount) to 1 if the user has checked the corresponding name in _strCombinedNames
    '    For Each CheckedItem In clbMembers.CheckedItems
    '        _bytCheckedName(Array.IndexOf(_strCombinedNames, CheckedItem.ToString)) = 1
    '    Next
    'End Sub

    'Private Sub CheckPreviouslyCheckedName()
    '    'If _blnFormLoaded = True And _intCodeSkip Mod 2 = 1 Then
    '    If _blnFormLoaded = True Then
    '        For intCount = 0 To _bytCheckedName.Length - 1
    '            If _bytCheckedName(intCount) = 1 Then
    '                Try
    '                    clbMembers.SetItemChecked(clbMembers.Items.IndexOf(_strCombinedNames(intCount)), True)
    '                Catch ex As Exception
    '                    'Do nothing
    '                End Try
    '            End If
    '        Next
    '    End If
    'End Sub

    'Private Sub PopuluateAvailability()
    '    'This routine will populate the total availability labels

    '    'Retrieve the availability data
    '    If cboMember.SelectedIndex >= 0 Then
    '        _strAvailability = _objIRSBusiness.MemberAvailability(_strID(cboMember.SelectedIndex), _blnFormLoaded)

    '        'Display the availability numbers
    '        lblProvisionNumberLastMonth.Text = _strAvailability(0)
    '        lblProvisionNumberLast3Months.Text = _strAvailability(1)
    '        lblProvisionNumberLast6Months.Text = _strAvailability(2)
    '        lblProvisionNumberLast12Months.Text = _strAvailability(3)
    '        lblProvisionNumberLast24Months.Text = _strAvailability(4)
    '        lblProvisionNumberLast36Months.Text = _strAvailability(5)

    '        'Display the availability totals
    '        lblProvisionTotalLastMonth.Text = _strAvailability(6)
    '        lblProvisionTotalLast3Months.Text = _strAvailability(7)
    '        lblProvisionTotalLast6Months.Text = _strAvailability(8)
    '        lblProvisionTotalLast12Months.Text = _strAvailability(9)
    '        lblProvisionTotalLast24Months.Text = _strAvailability(10)
    '        lblProvisionTotalLast36Months.Text = _strAvailability(11)

    '        'Displat the percentages
    '        lblProvisionPercentageLastMonth.Text = _strAvailability(12)
    '        lblProvisionPercentageLast3Months.Text = _strAvailability(13)
    '        lblProvisionPercentageLast6Months.Text = _strAvailability(14)
    '        lblProvisionPercentageLast12Months.Text = _strAvailability(15)
    '        lblProvisionPercentageLast24Months.Text = _strAvailability(16)
    '        lblProvisionPercentageLast36Months.Text = _strAvailability(17)
    '    End If
    'End Sub

    'Private Sub UpdateAvailabilityDisplay()
    '    'The purpose of this routine is to disable sections of the data if it is the same as the previous block of data

    '    'Examine th 36 month 
    '    If Convert.ToInt32(lblProvisionTotalLast36Months.Text) <= Convert.ToInt32(lblProvisionTotalLast24Months.Text) Then
    '        'The provision labels for 36 months do not need to be displayed
    '        lblProvisionProvidedLast36Months.Enabled = False
    '        lblProvisionNumberLast36Months.Enabled = False
    '        lblProvisionProvidedLast36MonthsOf.Enabled = False
    '        lblProvisionTotalLast36Months.Enabled = False
    '        lblProvisionProvidedLast36MonthsOblique.Enabled = False
    '        lblProvisionPercentageLast36Months.Enabled = False
    '        lblProvisionProvidedLast36MonthsPercent.Enabled = False
    '    Else
    '        lblProvisionProvidedLast36Months.Enabled = True
    '        lblProvisionNumberLast36Months.Enabled = True
    '        lblProvisionProvidedLast36MonthsOf.Enabled = True
    '        lblProvisionTotalLast36Months.Enabled = True
    '        lblProvisionProvidedLast36MonthsOblique.Enabled = True
    '        lblProvisionPercentageLast36Months.Enabled = True
    '        lblProvisionProvidedLast36MonthsPercent.Enabled = True
    '    End If

    '    'Examine th 24 month 
    '    If Convert.ToInt32(lblProvisionTotalLast24Months.Text) <= Convert.ToInt32(lblProvisionTotalLast12Months.Text) Then
    '        'The provision labels for 24 months do not need to be displayed
    '        lblProvisionProvidedLast24Months.Enabled = False
    '        lblProvisionNumberLast24Months.Enabled = False
    '        lblProvisionProvidedLast24MonthsOf.Enabled = False
    '        lblProvisionTotalLast24Months.Enabled = False
    '        lblProvisionProvidedLast24MonthsOblique.Enabled = False
    '        lblProvisionPercentageLast24Months.Enabled = False
    '        lblProvisionProvidedLast24MonthsPercent.Enabled = False
    '    Else
    '        lblProvisionProvidedLast24Months.Enabled = True
    '        lblProvisionNumberLast24Months.Enabled = True
    '        lblProvisionProvidedLast24MonthsOf.Enabled = True
    '        lblProvisionTotalLast24Months.Enabled = True
    '        lblProvisionProvidedLast24MonthsOblique.Enabled = True
    '        lblProvisionPercentageLast24Months.Enabled = True
    '        lblProvisionProvidedLast24MonthsPercent.Enabled = True
    '    End If

    '    'Examine th 12 month 
    '    If Convert.ToInt32(lblProvisionTotalLast12Months.Text) <= Convert.ToInt32(lblProvisionTotalLast6Months.Text) Then
    '        'The provision labels for 12 months do not need to be displayed
    '        lblProvisionProvidedLast12Months.Enabled = False
    '        lblProvisionNumberLast12Months.Enabled = False
    '        lblProvisionProvidedLast12MonthsOf.Enabled = False
    '        lblProvisionTotalLast12Months.Enabled = False
    '        lblProvisionProvidedLast12MonthsOblique.Enabled = False
    '        lblProvisionPercentageLast12Months.Enabled = False
    '        lblProvisionProvidedLast12MonthsPercent.Enabled = False
    '    Else
    '        lblProvisionProvidedLast12Months.Enabled = True
    '        lblProvisionNumberLast12Months.Enabled = True
    '        lblProvisionProvidedLast12MonthsOf.Enabled = True
    '        lblProvisionTotalLast12Months.Enabled = True
    '        lblProvisionProvidedLast12MonthsOblique.Enabled = True
    '        lblProvisionPercentageLast12Months.Enabled = True
    '        lblProvisionProvidedLast12MonthsPercent.Enabled = True
    '    End If

    '    'Examine th 6 month 
    '    If Convert.ToInt32(lblProvisionTotalLast6Months.Text) <= Convert.ToInt32(lblProvisionTotalLast3Months.Text) Then
    '        'The provision labels for 6 months do not need to be displayed
    '        lblProvisionProvidedLast6Months.Enabled = False
    '        lblProvisionNumberLast6Months.Enabled = False
    '        lblProvisionProvidedLast6MonthsOf.Enabled = False
    '        lblProvisionTotalLast6Months.Enabled = False
    '        lblProvisionProvidedLast6MonthsOblique.Enabled = False
    '        lblProvisionPercentageLast6Months.Enabled = False
    '        lblProvisionProvidedLast6MonthsPercent.Enabled = False
    '    Else
    '        lblProvisionProvidedLast6Months.Enabled = True
    '        lblProvisionNumberLast6Months.Enabled = True
    '        lblProvisionProvidedLast6MonthsOf.Enabled = True
    '        lblProvisionTotalLast6Months.Enabled = True
    '        lblProvisionProvidedLast6MonthsOblique.Enabled = True
    '        lblProvisionPercentageLast6Months.Enabled = True
    '        lblProvisionProvidedLast6MonthsPercent.Enabled = True
    '    End If

    '    'Examine th 3 month 
    '    If Convert.ToInt32(lblProvisionTotalLast3Months.Text) <= Convert.ToInt32(lblProvisionTotalLastMonth.Text) Then
    '        'The provision labels for 3 months do not need to be displayed
    '        lblProvisionProvidedLast3Months.Enabled = False
    '        lblProvisionNumberLast3Months.Enabled = False
    '        lblProvisionProvidedLast3MonthsOf.Enabled = False
    '        lblProvisionTotalLast3Months.Enabled = False
    '        lblProvisionProvidedLast3MonthsOblique.Enabled = False
    '        lblProvisionPercentageLast3Months.Enabled = False
    '        lblProvisionProvidedLast3MonthsPercent.Enabled = False
    '    Else
    '        lblProvisionProvidedLast3Months.Enabled = True
    '        lblProvisionNumberLast3Months.Enabled = True
    '        lblProvisionProvidedLast3MonthsOf.Enabled = True
    '        lblProvisionTotalLast3Months.Enabled = True
    '        lblProvisionProvidedLast3MonthsOblique.Enabled = True
    '        lblProvisionPercentageLast3Months.Enabled = True
    '        lblProvisionProvidedLast3MonthsPercent.Enabled = True
    '    End If
    'End Sub
End Class