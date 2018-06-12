Option Strict On

Imports System.Reflection
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports Serializable

Namespace Common

    Public MustInherit Class Debrief : Implements IXmlSerializable, IEquatable(Of Debrief), IComparable(Of Debrief)


#Region "Fields"
        ' Fields for Methods
        Private _finishTime As DateTime
        Private _startTime As DateTime

        ' DateTime serialisation format
        Private _dateTimeSerializationFormat As String = "s"

#End Region

#Region "Static Properties"

#End Region


#Region "Non-Static Properties"

        Public Overridable Property CrewAdequatelyTrained As Boolean

        Public Overridable Property CrewLeader As Member

        Public MustOverride Property EventNumber As String

        Public Overridable Property EquipmentToMakeEasier As String

        Public Overridable Property EquipmentUsed As SerializableList(Of EquipmentUse)

        Public Overridable Property FinishTime As DateTime
            Get
                Return _finishTime
            End Get
            Set
                ' Make sure that the received value is greater than the end time if it is initialised
                If StartTime <> Nothing Then
                    If Value < StartTime Then
                        Throw New InvalidOperationException("The finish time must be greater than or equal to the start time.")
                    End If
                End If

                ' No exceptions throw so set the value
                _finishTime = Value
            End Set
        End Property

        Public Overridable Property FirstAider As Member

        Public Overridable Property IssuesForJob As String

        Public Overridable Property JobDescription As String

        Public Overridable Property JobType As String

        Public Overridable Property MembersAttending As SerializableDictionary(Of Member, String)

        Public Overridable Property MyCouncil As Boolean

        Public Overridable Property Plan As String

        Public Overridable Property PlanB As Boolean

        Public Overridable Property PlanClearToAll As Boolean

        Public Overridable Property Safety As Member

        Public Overridable Property SafetyConcerns As String

        Public Overridable Property SesCommander As Member

        Public Overridable Property Skills As String

        Public Overridable Property StartTime As DateTime
            Get
                Return _startTime
            End Get
            Set
                ' Make sure that the start time is less than the end time if it is initialised
                If FinishTime <> Nothing Then
                    If Value > FinishTime Then
                        Throw New InvalidOperationException("The start time must be less than or equal to the end time.")
                    End If
                End If

                ' No exceptions throw so set the value
                _startTime = Value
            End Set
        End Property

        Public Overridable Property VehiclesUsed As SerializableList(Of String)

        Protected Sub InstantiateFromExisting(debrief As Debrief)
            InitialiseProperties()

            Dim writeableProperties = (From prop In GetType(Debrief).GetProperties
                                       Where prop.CanWrite
                                       Select prop).ToList()

            For Each prop As PropertyInfo In writeableProperties
                If prop.Name <> NameOf(EventNumber) Then
                    prop.SetValue(Me, prop.GetValue(debrief))
                End If
            Next
        End Sub

#End Region


#Region "Methods For IXmlSerialization"

        Overridable Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
            Return Nothing
        End Function

        Overridable Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
            reader.MoveToContent()
            reader.ReadStartElement()

            For Each prop As PropertyInfo In Me.GetType().GetProperties().OrderBy(Function(p) p.Name)
                Select Case prop.PropertyType
                    Case GetType(String)
                        SetPropertyString(reader, prop)
                    Case GetType(Boolean)
                        SetPropertyBoolean(reader, prop)
                    Case GetType(DateTime)
                        SetPropertyDateTime(reader, prop)
                    Case GetType(Member)
                        SetPropertyMember(reader, prop)
                    Case GetType(SerializableList(Of String))
                        SetPropertySerializableListOfString(reader, prop)
                    Case GetType(SerializableList(Of EquipmentUse))
                        SetPropertySerializableListOfEquipmentUse(reader, prop)
                    Case GetType(SerializableDictionary(Of Member, String))
                        SetPropertySerializableDictionary(reader, prop)
                End Select
            Next

            'reader.ReadEndElement()
        End Sub

        Protected Overridable Sub SetPropertySerializableDictionary(reader As XmlReader, prop As PropertyInfo)
            Dim elementText As String

            Dim ma As New SerializableDictionary(Of Member, String)

            reader.ReadStartElement(prop.Name)
            reader.ReadStartElement("SerializableDictionarytOfMemberString")

            ' Get each item
            While reader.Name = "Item"
                reader.ReadStartElement("Item")

                'Read in the key
                Dim key As New Member()
                reader.ReadStartElement("Key")
                reader.ReadStartElement(GetType(Member).Name)
                For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                    If propMember.CanWrite Then
                        elementText = reader.ReadElementContentAsString(propMember.Name, "")
                        propMember.SetValue(key, CTypeDynamic(elementText, propMember.PropertyType))
                    End If
                Next
                reader.ReadEndElement() ' NameOf Member
                reader.ReadEndElement() ' Key

                ' Determine the value
                Dim value As String = reader.ReadElementContentAsString("Value", "")

                ' Add the entry to ma
                ma.Add(key, value)

                ' Set the position of the reader for the next item (if it exists)
                reader.ReadEndElement() ' Item
            End While

            prop.SetValue(Me, ma)

            reader.ReadEndElement() ' NameOf serialiable list
            reader.ReadEndElement() ' prop name
        End Sub

        Protected Overridable Sub SetPropertySerializableListOfString(reader As XmlReader, prop As PropertyInfo)

            Dim vehicles As New SerializableList(Of String)
            reader.ReadStartElement(prop.Name)
            reader.ReadStartElement("SerializableListOfString")

            ' Read in each item
            While reader.Name = "Item"
                vehicles.Add(reader.ReadElementContentAsString("Item", ""))
            End While

            prop.SetValue(Me, vehicles)

            reader.ReadEndElement() ' NameOf "SerializableListOfString"
            reader.ReadEndElement() ' property name
        End Sub

        Protected Overridable Sub SetPropertySerializableListOfEquipmentUse(reader As XmlReader, prop As PropertyInfo)
            reader.ReadStartElement(prop.Name)
            reader.ReadStartElement("SerializableListOfEquipmentUse")

            ' Read in each item
            Dim itemsUsed As New SerializableList(Of EquipmentUse)
            While reader.Name = "ItemUsed"
                reader.ReadStartElement("ItemUsed", "")
                itemsUsed.Add(ReadItemUsed(reader))
                reader.ReadEndElement() 'ItemUsed
            End While

            prop.SetValue(Me, itemsUsed)

            reader.ReadEndElement() ' NameOf "SerializableListOfString"
            reader.ReadEndElement() ' property name
        End Sub

        Private Shared Function ReadItemUsed(reader As XmlReader) As EquipmentUse
            Dim itemUsed As New EquipmentUse

            itemUsed.Duration = Convert.ToInt32(reader.ReadElementContentAsString(NameOf(itemUsed.Duration), ""))
            itemUsed.Item = reader.ReadElementContentAsString(NameOf(itemUsed.Item), "")
            itemUsed.MemberUsing = ReadMemberUsed(reader)

            Return itemUsed
        End Function

        Private Shared Function ReadMemberUsed(reader As XmlReader) As Member
            Dim memberUsed As New Member

            reader.ReadStartElement(NameOf(Member))
            For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                If propMember.CanWrite Then
                    Dim elementText = reader.ReadElementContentAsString(propMember.Name, "")
                    propMember.SetValue(memberUsed, CTypeDynamic(elementText, propMember.PropertyType))
                End If
            Next
            reader.ReadEndElement()

            Return memberUsed
        End Function

        Protected Overridable Sub SetPropertyMember(reader As XmlReader, prop As PropertyInfo)
            Dim elementText As String

            Dim member As New Member()
            reader.ReadStartElement(prop.Name)
            reader.ReadStartElement(GetType(Member).Name)
            For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                If propMember.CanWrite Then
                    elementText = reader.ReadElementContentAsString(propMember.Name, "")
                    propMember.SetValue(member, CTypeDynamic(elementText, propMember.PropertyType))
                End If
            Next
            reader.ReadEndElement() ' Nameof member
            reader.ReadEndElement() ' property name

            prop.SetValue(Me, member)
        End Sub

        Protected Overridable Sub SetPropertyDateTime(reader As XmlReader, prop As PropertyInfo)
            Dim elementText As String

            elementText = reader.ReadElementContentAsString(prop.Name, "")
            Dim splits() As String = elementText.Split(New String() {"-", "T", ":"}, StringSplitOptions.RemoveEmptyEntries)
            prop.SetValue(Me, New DateTime(Convert.ToInt32(splits(0)), Convert.ToInt32(splits(1)), Convert.ToInt32(splits(2)), Convert.ToInt32(splits(3)), Convert.ToInt32(splits(4)), Convert.ToInt32(splits(5))))
        End Sub

        Protected Overridable Sub SetPropertyBoolean(reader As XmlReader, prop As PropertyInfo)
            Dim elementText As String

            elementText = reader.ReadElementContentAsString(prop.Name,"")
            prop.SetValue(Me, elementText = "True")
        End Sub

        Protected Overridable Sub SetPropertyString(reader As XmlReader, prop As PropertyInfo)
            Dim elementText As String

            elementText = reader.ReadElementContentAsString(prop.Name, "")
            prop.SetValue(Me, elementText.Replace("<br>", Environment.NewLine()))
        End Sub

        Overridable Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
            Dim outputText As String

            For Each propDebrief As PropertyInfo In Me.GetType().GetProperties().OrderBy(Function(p) p.Name)
                If propDebrief.CanWrite Then
                    Dim t As Type = propDebrief.PropertyType
                    Select Case t
                        Case GetType(String), GetType(Boolean)
                            outputText = propDebrief.GetValue(Me, Nothing).ToString()
                            writer.WriteElementString(propDebrief.Name, outputText.Replace(vbCrLf, "<br>"))

                        Case GetType(DateTime)
                            outputText = CType(propDebrief.GetValue(Me, Nothing), DateTime).ToString(_dateTimeSerializationFormat)
                            writer.WriteElementString(propDebrief.Name, outputText)

                        Case GetType(Member)
                            writer.WriteStartElement(propDebrief.Name)
                            writer.WriteStartElement(GetType(Member).Name)
                            For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                                If propMember.CanWrite Then
                                    outputText = propMember.GetValue(CType(propDebrief.GetValue(Me, Nothing), Member), Nothing).ToString()
                                    writer.WriteElementString(propMember.Name, outputText)
                                End If
                            Next
                            writer.WriteEndElement() ' Nameof member
                            writer.WriteEndElement() ' property name

                        Case GetType(SerializableList(Of String))
                            writer.WriteStartElement(propDebrief.Name)
                            writer.WriteStartElement("SerializableListOfString")
                            For Each item As String In CType(propDebrief.GetValue(Me, Nothing), SerializableList(Of String))
                                writer.WriteElementString("Item", item)
                            Next
                            writer.WriteEndElement() ' NameOf serialiable list
                            writer.WriteEndElement() ' property name

                        Case GetType(SerializableList(Of EquipmentUse))
                            writer.WriteStartElement(propDebrief.Name)
                            writer.WriteStartElement("SerializableListOfEquipmentUse")
                            For Each item As EquipmentUse In CType(propDebrief.GetValue(Me, Nothing), SerializableList(Of EquipmentUse))
                                writer.WriteStartElement("ItemUsed")
                                For Each propEntry As PropertyInfo In GetType(EquipmentUse).GetProperties().OrderBy(Function(p) p.Name)
                                    Select Case propEntry.PropertyType
                                        Case GetType(Member)
                                            writer.WriteStartElement(GetType(Member).Name)
                                            For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                                                If propMember.CanWrite Then
                                                    outputText = propMember.GetValue(item.MemberUsing, Nothing).ToString()
                                                    writer.WriteElementString(propMember.Name, outputText)
                                                End If
                                            Next
                                            writer.WriteEndElement() ' Nameof member

                                        Case Else
                                            outputText = propEntry.GetValue(item, Nothing).ToString()
                                            writer.WriteElementString(propEntry.Name, outputText)
                                    End Select

                                Next
                                writer.WriteEndElement() 'ItemUsed
                            Next
                            writer.WriteEndElement() ' NameOf serialiable list
                            writer.WriteEndElement() ' property name

                        Case GetType(SerializableDictionary(Of Member, String))
                            writer.WriteStartElement(propDebrief.Name)
                            writer.WriteStartElement("SerializableDictionarytOfMemberString")
                            For Each item As KeyValuePair(Of Member, String) In CType(propDebrief.GetValue(Me, Nothing), SerializableDictionary(Of Member, String))
                                writer.WriteStartElement("Item")
                                writer.WriteStartElement("Key")
                                writer.WriteStartElement(GetType(Member).Name)
                                For Each propMember As PropertyInfo In GetType(Member).GetProperties().OrderBy(Function(p) p.Name)
                                    If propMember.CanWrite Then
                                        outputText = propMember.GetValue(item.Key, Nothing).ToString()
                                        writer.WriteElementString(propMember.Name, outputText)
                                    End If
                                Next
                                writer.WriteEndElement() ' NameOf Member
                                writer.WriteEndElement() 'Key
                                writer.WriteElementString("Value", item.Value)
                                writer.WriteEndElement() 'Item
                            Next
                            writer.WriteEndElement() ' NameOf serialiable list
                            writer.WriteEndElement() ' property name
                    End Select
                End If
            Next
        End Sub

#End Region


#Region "Methods For IEquatable(Of DebebriefData)"

        Public Overridable Overloads Function Equals(other As Debrief) As Boolean Implements IEquatable(Of Debrief).Equals
            Return Equals(Me, other)
        End Function

#End Region


#Region "Method for IComparable(Of Debrief Data)"

        Public Overridable Function CompareTo(other As Debrief) As Integer Implements IComparable(Of Debrief).CompareTo
            Try
                Dim test = other.EventNumber
            Catch ex As Exception
                Return 1
            End Try

            Return String.Compare(EventNumber, other.EventNumber, StringComparison.Ordinal)
        End Function

#End Region

#Region "Operator Overloads"


#End Region

#Region "Public Static Methods"

        Public Overloads Shared Function Equals(value1 As Debrief, value2 As Debrief) As Boolean
            Return Comparison.Comparison.Equals(value1, value2, GetType(Debrief).GetProperty(NameOf(value1.EventNumber)))
        End Function

#End Region


#Region "Private Non-Static Methods"

        Protected Overridable Sub InitialiseProperties()
            For Each prop As PropertyInfo In [GetType]().GetProperties()
                If prop.PropertyType = GetType(String) Then
                    prop.SetValue(Me, "")
                End If
            Next

            MembersAttending = New SerializableDictionary(Of Member, String)
            VehiclesUsed = New SerializableList(Of String)
        End Sub

#End Region
    End Class
End Namespace
