Option Strict On

Imports System.Reflection
Imports System.Runtime.Serialization
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Namespace Common

    Public Class Member : Implements IXmlSerializable, ISerializable, IEquatable(Of Member), IComparable(Of Member)
        Private _id As String
        Private _email As String

        Private _idFormatExceptionMessage As String = "Member IDs must be in the format 'ses[0-9][0-9][0-9][0-9][0-9]'."

        Public ReadOnly Property DisplayName As String
            Get
                Return Me.ToString()
            End Get
        End Property

        Public Property EmailAddress As String
            Get
                Return _email
            End Get
            Set
                If Value <> "" AndAlso Not Value.IsValidEmail() Then
                    Throw New FormatException("The provided Email address '" & Value & "' is not a valid Email format.")
                End If

                _email = Value
            End Set
        End Property

        Public Property Id As String
            Get
                Return _id
            End Get
            Set
                If Not (Value.Length = 8 And Left(Value, 3) = "ses" And IsNumeric(Right(Value, 5))) Then
                    Throw New FormatException(_idFormatExceptionMessage)
                End If

                _id = Value
            End Set
        End Property

        Public Property FirstName As String

        Public Property Position As Integer

        Public Property Status As Integer

        Public Property Surname As String

        Sub New()
            TryInstantiateStringProperties()
        End Sub

        Sub New(member As Member)
            For Each prop As PropertyInfo In member.GetType().GetProperties()
                If prop.CanWrite Then
                    prop.SetValue(Me, prop.GetValue(member, Nothing))
                End If
            Next
        End Sub

        Sub New(id As String)
            Initialise(id, "", "", "")
        End Sub

        Sub New(id As String, surname As String, firstName As String)
            Initialise(id, surname, firstName, "")
        End Sub

        Sub New(id As String, surname As String, firstName As String, email As String)
            Initialise(id, surname, firstName, email)
        End Sub

        Sub New(id As String, email As String)
            Initialise(id, "", "", email)
        End Sub

        Private Sub Initialise(ident As String, lastName As String, givenName As String, email As String)
            TryInstantiateStringProperties()

            Try
                Me.Id = ident
            Catch ex As FormatException
                Throw
            End Try

            Me.Surname = lastName
            Me.FirstName = givenName

            Try
                EmailAddress = email
            Catch ex As Exception
                Throw
            End Try
        End Sub

        Private Sub TryInstantiateStringProperties()
            Dim props = (From prop In GetType(Member).GetProperties()
                         Where prop.PropertyType = GetType(String)
                         Select prop).ToList

            For Each prop As PropertyInfo In props
                If prop.CanWrite Then
                    Try
                        prop.SetValue(Me, "")
                    Catch ex As Exception
                        ' Do Nothing
                    End Try
                End If
            Next
        End Sub

        Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function

        Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
            For Each prop As PropertyInfo In Me.GetType().GetProperties()
                reader.ReadToFollowing(prop.Name)
                prop.SetValue(Me, reader.ReadElementContentAsString(prop.Name, Nothing))
            Next
        End Sub

        Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
            For Each prop As PropertyInfo In Me.GetType().GetProperties()
                writer.WriteElementString(prop.Name, prop.GetValue(Me, Nothing).ToString())
            Next
        End Sub

        Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            Throw New NotImplementedException()
        End Sub

        Public Overloads Function Equals(other As Member) As Boolean Implements IEquatable(Of Member).Equals
            Return Equals(Me, other)
        End Function

        Public Shared Operator =(value1 As Member, value2 As Member) As Boolean
            Return Equals(value1, value2)
        End Operator

        Public Shared Operator <>(value1 As Member, value2 As Member) As Boolean
            Return Not Equals(value1, value2)
        End Operator

        Public Function CompareTo(other As Member) As Integer Implements IComparable(Of Member).CompareTo
            ' Make sure that other is not Nothing
            Try
                Dim test = other.Id
            Catch ex As Exception
                Return 1
            End Try

            Return String.Compare(Id, other.Id, StringComparison.Ordinal)
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("{0}, {1}", Surname, FirstName)
        End Function

        Public Overloads Shared Function Equals(value1 As Member, value2 As Member) As Boolean
            Return Comparison.Comparison.Equals(value1, value2, GetType(Member).GetProperty(NameOf(Id)))
        End Function
    End Class
End Namespace