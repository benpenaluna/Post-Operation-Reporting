Option Strict On

Public Class Cipher
    Shared _intAlphabetLength As Integer = 100I
    Shared _intAlphabetSquare As Integer = 10I
    'Define the character array to store the alphabet for use in the Affine
    Shared _chrAlphabetArray(_intAlphabetLength - 1I) As Char
    'Define the Matrix to store the values of the alphabet for use in the Bifid Cipher
    Shared _chrAlphabetMatrix(_intAlphabetSquare - 1I, _intAlphabetSquare - 1I) As Char
    'Define the constants for use the in the Affine cipher: 
    'Encrypt - y = a(x+b) Mod _intAlphabetLength
    'Decrypt - x = a^(-1)*)y-b) Mod _intAlphabetLength
    Shared _intA As Integer = 7I
    Shared _intB As Integer = 37I

    Shared Sub New()
        Dim intCount As Integer
        Dim intCountOuter As Integer
        Dim intCountInner As Integer
        'Populate the alphabet array with the characters of the alphabet for use in the Affine Cipher
        _chrAlphabetArray(0) = Chr(0) 'null
        For intCount = 1 To _intAlphabetLength - 1I
            _chrAlphabetArray(intCount) = Chr(intCount + 28I)
        Next

        'Convert the alphabet array to a matrix for use in the Bifid Cipher
        intCount = 0I
        For intCountOuter = 0I To _intAlphabetSquare - 1I
            For intCountInner = 0I To _intAlphabetSquare - 1I
                _chrAlphabetMatrix(intCountOuter, intCountInner) = _chrAlphabetArray(intCount)
                intCount += 1I
            Next
        Next
    End Sub

    Shared Function AffineBifidEncrypt(ByVal strEncrypt As String) As String
        'If item to sent to function is null, then there is no need to cipher, so return null string
        If strEncrypt = "" Then
            Return ""
            'Else a has length greater than 0 has been passed to the function
        Else
            'Remove any unsupported characters from the received array before proceeding
            strEncrypt = RemoveUnsupportedChars(strEncrypt)

            'Initialise variables for the subroutine
            Dim intCountOuter As Integer
            Dim intCountInner As Integer
            Dim intAffineEncrypt As Integer
            Dim intArrayValue As Integer
            Dim intBifidArray((strEncrypt.Length * 2I) - 1I) As Integer
            Dim intBifidArrayCount As Integer
            Dim intLocation(1I) As Integer
            Dim chrArray(strEncrypt.Length - 1I) As Char
            Dim chrAffineEncryptedArray(strEncrypt.Length - 1I) As Char
            Dim chrBifidEncryptedArray(strEncrypt.Length - 1I) As Char
            Dim chrLengthenedArray((strEncrypt.Length * 3I) - 1I) As Char

            chrArray = (strEncrypt).ToCharArray

            'Convert any carriage return or new line keys into the 2nd and 3rd characters in the alphabet array respectively
            For intCount = 0 To chrArray.Length - 1
                If chrArray(intCount) = Chr(13) Then
                    chrArray(intCount) = _chrAlphabetArray(1)
                End If

                If chrArray(intCount) = Chr(10) Then
                    chrArray(intCount) = _chrAlphabetArray(2)
                End If
            Next

            'Apply the Affine cipher to each element of _chrTextArray
            For intCountOuter = 0I To chrAffineEncryptedArray.Length - 1I
                intArrayValue = Array.BinarySearch(_chrAlphabetArray, chrArray(intCountOuter))
                intAffineEncrypt = (_intA * intArrayValue + _intB) Mod _intAlphabetLength
                chrAffineEncryptedArray(intCountOuter) = _chrAlphabetArray(intAffineEncrypt)
            Next

            'Determine the location of the values in the matrix alphabet for the character
            intBifidArrayCount = 0I
            For intCountOuter = 0I To chrAffineEncryptedArray.Length - 1I
                intLocation = MatrixLocation(chrAffineEncryptedArray(intCountOuter))
                intBifidArray(intBifidArrayCount) = intLocation(0)
                intBifidArray(intBifidArrayCount + 1I) = intLocation(1)
                intBifidArrayCount += 2I
            Next

            'Reorganise intBifidArray so that all row elements are listed first, then all column elements
            intBifidArray = ApplyBifid(intBifidArray)

            'Convert intBifidArray back to corresponding characters in the alphabet matrix
            intCountInner = 0I
            For intCountOuter = 0I To intBifidArray.Length - 1I Step 2I
                chrBifidEncryptedArray(intCountInner) = _chrAlphabetMatrix(intBifidArray(intCountOuter),
                                                                              intBifidArray(intCountOuter + 1I))
                intCountInner += 1I
            Next

            'Lengthen the array to store the required values in every third position
            Randomize()
            intCountInner = 0I
            For intCountOuter = 0I To chrBifidEncryptedArray.Length - 1I
                chrLengthenedArray(intCountInner) = _chrAlphabetArray(Convert.ToInt32(Rnd() * 99.0F))
                chrLengthenedArray(intCountInner + 1I) = _chrAlphabetArray(Convert.ToInt32(Rnd() * 99.0F))
                If chrLengthenedArray(intCountInner) = "/" And chrLengthenedArray(intCountInner + 1I) = "." Then
                    'Change chrLengthenedArray(intCountInner + 1I)
                    Do While chrLengthenedArray(intCountInner + 1I) = "."
                        chrLengthenedArray(intCountInner + 1I) = _chrAlphabetArray(Convert.ToInt32(Rnd() * 99.0F))
                    Loop
                End If
                chrLengthenedArray(intCountInner + 2I) = chrBifidEncryptedArray(intCountOuter)
                intCountInner += 3I
            Next

            'Convert the character array containing the cipher back into a string, and print it to txtAffine
            Dim strResult As New String(chrLengthenedArray)

            Return strResult
        End If
    End Function

    Shared Function AffineBifidDecrypt(ByVal strDecrypt As String) As String
        'If item to sent to function is null, then there is no need to decipher, so return null string
        If strDecrypt = "" Then
            Return ""
            'Else a has length greater than 0 has been passed to the function
        Else
            'Initialise the variables of the subroutine 
            Dim intCountOuter As Integer
            Dim intCountInner As Integer
            Dim intAffineD As Integer
            Dim intAInv As Integer
            Dim intAInvCount As Integer
            Dim blnSolutionFound As Boolean
            Dim intValue As Integer
            Dim intResult As Integer
            Dim intLocation(1) As Integer
            Dim intBifidArrayCount As Integer
            Dim intBifidArray(((strDecrypt.Length * 2I) \ 3I) - 1I) As Integer
            Dim chrAffineDecryptedArray((strDecrypt.Length \ 3I) - 1I) As Char
            Dim chrDecrypt(strDecrypt.Length - 1I) As Char
            Dim chrShortenedArray((strDecrypt.Length \ 3I) - 1I) As Char

            chrDecrypt = strDecrypt.ToCharArray

            intCountInner = 0I
            For intCountOuter = 2I To strDecrypt.Length - 1I Step 3I
                chrShortenedArray(intCountInner) = chrDecrypt(intCountOuter)
                intCountInner += 1I
            Next

            'Determine location of each character in the alphabet matrix
            intBifidArrayCount = 0I
            For intCountOuter = 0I To chrShortenedArray.Length - 1I
                intLocation = MatrixLocation(chrShortenedArray(intCountOuter))
                intBifidArray(intBifidArrayCount) = intLocation(0)
                intBifidArray(intBifidArrayCount + 1I) = intLocation(1)
                intBifidArrayCount += 2I
            Next

            'Sort the chrSavedString back into proper order
            intBifidArray = UnapplyBifid(intBifidArray)

            'Determine the proper location of the character in the alphabet matrix
            ReDim chrDecrypt(chrShortenedArray.Length - 1I)
            intCountInner = 0I
            For intCountOuter = 0I To intBifidArray.Length - 1I Step 2I
                If intCountOuter < intBifidArray.Length - 1 Then
                    chrDecrypt(intCountInner) = _chrAlphabetMatrix(intBifidArray(intCountOuter),
                                                                       intBifidArray(intCountOuter + 1I))
                    intCountInner += 1I
                End If
            Next

            'Determine the multiplicative inverse of _intA (a^(-1))
            intAInvCount = 1I
            blnSolutionFound = False
            Do Until blnSolutionFound
                If (_intA * intAInvCount) Mod _intAlphabetLength = 1I Then
                    intAInv = intAInvCount
                    blnSolutionFound = True
                Else
                    intAInvCount += 1I
                End If
            Loop

            'Apply the Affine decryption cipher
            For intCountOuter = 0I To chrDecrypt.Length - 1I
                intValue = Array.BinarySearch(_chrAlphabetArray, chrDecrypt(intCountOuter))
                intResult = intAInv * (intValue - _intB)
                intAffineD = intResult Mod _intAlphabetLength
                If intAffineD < 0 Then
                    intAffineD += _intAlphabetLength
                End If
                chrAffineDecryptedArray(intCountOuter) = _chrAlphabetArray(intAffineD)
            Next

            'Convert any characters equallying the charactrs in the 2nd or 3rd position of the alphabet array back to carriage 
            'return and new line respectively
            For intCount = 0 To chrAffineDecryptedArray.Length - 1
                If chrAffineDecryptedArray(intCount) = _chrAlphabetArray(1) Then
                    chrAffineDecryptedArray(intCount) = Chr(13)
                End If

                If chrAffineDecryptedArray(intCount) = _chrAlphabetArray(2) Then
                    chrAffineDecryptedArray(intCount) = Chr(10)
                End If
            Next

            'Convert the decrypted char array back to a string
            Dim strResult As New String(chrAffineDecryptedArray)

            Return strResult
        End If
    End Function

    Private Shared Function MatrixLocation(ByVal chrToBeTested As Char) As Integer()
        Dim intCountOuter As Integer
        Dim intCountInner As Integer
        Dim intBifidRow As Integer
        Dim intBifidColumn As Integer
        Dim intResult(1) As Integer

        For intCountOuter = 0I To _intAlphabetSquare - 1I
            For intCountInner = 0I To _intAlphabetSquare - 1I
                If _chrAlphabetMatrix(intCountOuter, intCountInner) = chrToBeTested Then
                    intBifidRow = intCountOuter
                    intBifidColumn = intCountInner
                End If
            Next
        Next

        intResult = {intBifidRow, intBifidColumn}
        Return intResult
    End Function

    Private Shared Function ApplyBifid(ByVal intSortArrayToBifid() As Integer) As Integer()
        Dim intSortedArray(intSortArrayToBifid.Length - 1I) As Integer
        Dim intCount As Integer
        Dim intCountOuter As Integer

        intCount = 0I
        For intCountOuter = 0I To intSortArrayToBifid.Length - 1I Step 2I
            intSortedArray(intCount) = intSortArrayToBifid(intCountOuter)
            intCount += 1I
        Next

        For intCountOuter = 1I To intSortArrayToBifid.Length - 1I Step 2I
            intSortedArray(intCount) = intSortArrayToBifid(intCountOuter)
            intCount += 1I
        Next

        Return intSortedArray
    End Function

    Private Shared Function UnapplyBifid(ByVal intSortArrayToBifid() As Integer) As Integer()
        Dim intSortedArray(intSortArrayToBifid.Length - 1) As Integer
        Dim intCount As Integer
        Dim intCountOuter As Integer

        intCount = 0I
        For intCountOuter = 0I To intSortArrayToBifid.Length - 1I Step 2I
            intSortedArray(intCountOuter) = intSortArrayToBifid(intCount)
            intCount += 1I
        Next

        For intCountOuter = 1I To intSortArrayToBifid.Length - 1I Step 2I
            intSortedArray(intCountOuter) = intSortArrayToBifid(intCount)
            intCount += 1I
        Next

        Return intSortedArray
    End Function

    Private Shared Function RemoveUnsupportedChars(ByVal strTestString As String) As String
        'The purpose of this function is to remove any characters that are not supported by the cipher, prior to encrypting

        'Instantiate the return string
        Dim strReturn As String = ""

        'Convert the received string to a character array
        Dim chrTestString() As Char = strTestString.ToCharArray()

        'Cycle through all the characters and remove the characters that are not supported
        For intCount = 0 To chrTestString.Length - 1
            'Fix the known problem with hyphens
            If chrTestString(intCount) = "–"c Then
                strReturn += "-"c
            ElseIf Array.IndexOf(_chrAlphabetArray, chrTestString(intCount)) = -1 Then
                'Do Nothing
            Else
                strReturn += chrTestString(intCount)
            End If
        Next

        Return strReturn
    End Function
End Class
