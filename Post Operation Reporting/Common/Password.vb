Option Strict On

Imports System.IO
Imports System.Security.Cryptography
Imports System.Threading.Tasks
Imports PostOpRep.Database


Namespace Common
    Public Module Password
        Private ReadOnly _iv() As Byte = {10, 167, 253, 41, 76, 147, 169, 177, 231, 6, 49, 42, 87, 154, 9, 72}
        Private ReadOnly _key() As Byte = {76, 139, 87, 243, 221, 74, 165, 86, 42, 175, 171, 89, 6, 22, 148, 224,
                                           171, 199, 56, 241, 206, 45, 162, 76, 75, 84, 122, 124, 32, 27, 199, 10}

        Public Function EncryptPassword(password As String) As String
            If password = "" Then
                Throw New ArgumentNullException(NameOf(password))
            End If

            Dim encrypted() As Byte
            Using aesAlg As Aes = Aes.Create
                InitialiseAes(aesAlg)
                encrypted = PerformEncryption(password, aesAlg)
            End Using

            Return String.Join(",", encrypted)
        End Function

        Private Sub InitialiseAes(ByRef aesAlg As Aes)
            aesAlg.Key = _key
            aesAlg.IV = _iv
        End Sub

        Private Function PerformEncryption(password As String, aesAlg As Aes) As Byte()
            Dim encrypted As Byte()
            Dim encryptor As ICryptoTransform = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV)
            Using msEncrypt As New MemoryStream()
                Using csEncrypt As New CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)
                    Using swEncrypt As New StreamWriter(csEncrypt)
                        swEncrypt.Write(password)
                    End Using
                    encrypted = msEncrypt.ToArray()
                End Using
            End Using

            Return encrypted
        End Function

        Public Async Function PasswordMatchAsync(userInputtedId As String, userInputtedPassword As String) As Task(Of Boolean)
            If Not DataDbConnection.MemberIdExists(userInputtedId) Then
                Throw New ArgumentException()
            End If

            Try
                Return EncryptPassword(userInputtedPassword) = Await DataDbConnection.RetrieveMemberPasswordAsync(userInputtedId).ConfigureAwait(False)
            Catch ex As ArgumentNullException
                Throw
            End Try
        End Function
    End Module
End Namespace
