Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel

Public Enum AdvType As Integer
    Text = 0
    Image
    video
    Html 'Html template file
End Enum
Public Class Advertisement
    <[ReadOnly](True)>
    Public Property ID As Integer
    <Required()>
    Public Property Title As String
    <Required()>
    Public Property Customer As Integer
    <DisplayName("Customer")>
    Public Property CustomerAlise As String
    <Required()>
    <DisplayName("Advertisement")>
    Public Property Adver As String
    <Required()>
    <DataType(DataType.Url)>
    Public Property Link As String
    <Required()>
    <DisplayName("Advertisement Type")>
    Public Property Type As AdvType
    <Required()>
    Public Property Category As String
    Public Property Visited As Integer = 0
    Public Property Rate As Single = 0

    Public Shared Function AdvTypeToDict() As Dictionary(Of Integer, String)
        Return EnumToDictonary(GetType(AdvType))
    End Function
End Class
