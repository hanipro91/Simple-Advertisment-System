Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel


Public Class Customer
    'Customer Types
    'Male
    'Femal
    'Company
    'Orgnization
    'Foundation
    'Government
    <ScaffoldColumn(True)>
    Public Property ID As Integer
    <Required()>
    <DisplayName("Full Name")>
    Public Property Name As String
    <Required()>
    <DisplayName("Cutomer Type")>
    Public Property Type As String
    Public Property Address As String
    <Required()>
    Public Property Email As String
    Public Property Phone As String
    Public Property Photo As String

End Class
