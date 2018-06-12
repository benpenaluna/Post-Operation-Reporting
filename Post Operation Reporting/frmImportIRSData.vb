Option Strict On

Public Class frmImportIRSData
    ''Instantiate a link to the business class
    'Dim _objBusiness As New ImportIRSBusiness

    ''Create some class variables for the locations of the Data to Import
    'Dim _strIncident As String = ""
    'Dim _strIndi As String = ""
    'Dim _strWebsite As String = ""

    'Private Sub frmImportIRSData_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    '    Me.Dispose()
    'End Sub

    'Private Sub btnIncident_Click(sender As System.Object, e As System.EventArgs) Handles btnIncident.Click
    '    'Find the location of the Incident Summary Data
    '    OpenFileDialog1.Filter = "Comma Separated Values|*.csv"
    '    OpenFileDialog1.Title = "Select a CSV File"
    '    OpenFileDialog1.FileName = ""

    '    'Open the OpenFileDialog to get the location of the file to link to the accreditation
    '    OpenFileDialog1.ShowDialog()

    '    'Store the filepath of the selected file in _strLink for later storage
    '    '_strLink = OpenFileDialog1.FileName
    '    If OpenFileDialog1.FileName <> "" Then 'If it does equal "" then the user pressed cancel
    '        _strIncident = OpenFileDialog1.FileName
    '        lblIncident.Text = OpenFileDialog1.SafeFileName
    '    End If
    'End Sub

    'Private Sub btnIndi_Click(sender As System.Object, e As System.EventArgs) Handles btnIndi.Click
    '    'Find the location of the Incident Summary Data
    '    OpenFileDialog1.Filter = "Comma Separated Values|*.csv"
    '    OpenFileDialog1.Title = "Select a CSV File"
    '    OpenFileDialog1.FileName = ""

    '    'Open the OpenFileDialog to get the location of the file to link to the accreditation
    '    OpenFileDialog1.ShowDialog()

    '    'Store the filepath of the selected file in _strLink for later storage
    '    '_strLink = OpenFileDialog1.FileName
    '    If OpenFileDialog1.FileName <> "" Then 'If it does equal "" then the user pressed cancel
    '        _strIndi = OpenFileDialog1.FileName
    '        lblIndi.Text = OpenFileDialog1.SafeFileName
    '    End If
    'End Sub

    'Private Sub btnWebsite_Click(sender As System.Object, e As System.EventArgs) Handles btnWebsite.Click
    '    'Find the location of the Incident Summary Data
    '    OpenFileDialog1.Filter = "Text Files|*.txt"
    '    OpenFileDialog1.Title = "Select a Text File"
    '    OpenFileDialog1.FileName = ""

    '    'Open the OpenFileDialog to get the location of the file to link to the accreditation
    '    OpenFileDialog1.ShowDialog()

    '    'Store the filepath of the selected file in _strLink for later storage
    '    '_strLink = OpenFileDialog1.FileName
    '    If OpenFileDialog1.FileName <> "" Then 'If it does equal "" then the user pressed cancel
    '        _strWebsite = OpenFileDialog1.FileName
    '        lblWebsite.Text = OpenFileDialog1.SafeFileName
    '    End If
    'End Sub

    'Private Sub btnImport_Click(sender As System.Object, e As System.EventArgs) Handles btnImport.Click
    '    'Import the data
    '    If _strIncident <> Nothing Then
    '        _objBusiness.ImportIncidentSummaryData(_strIncident)
    '    End If

    '    If _strIndi <> Nothing Then
    '        _objBusiness.ImportIndividualData(_strIndi)
    '    End If

    '    If _strWebsite <> Nothing Then
    '        _objBusiness.ImportAvailabilityData(_strWebsite)
    '    End If

    '    'Close the form
    '    Me.Close()
    'End Sub
End Class