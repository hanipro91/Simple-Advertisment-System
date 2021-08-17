Imports System.Runtime.CompilerServices

Module Module1

    Public Function EnumToDictonary(ByVal en As Type) As Dictionary(Of Integer, String)
        If Not en.IsEnum Then Return Nothing
        Dim vs = [Enum].GetValues(en)
        Dim ns = [Enum].GetNames(en)
        Dim d As New Dictionary(Of Integer, String)
        For i = 0 To vs.Length - 1
            d.Add(vs(i), ns(i))
        Next
        Return d
    End Function

    
End Module
