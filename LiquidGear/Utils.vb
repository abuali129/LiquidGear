Imports System.IO
Imports System.Text
Public Class Utils
    Public Shared Function Read_String(Data As FileStream, Offset As Integer, Length As Integer) As String
        Data.Seek(Offset, SeekOrigin.Begin)
        Dim Text As New StringBuilder()
        For i As Integer = 0 To Length - 1
            Text.Append(Chr(Data.ReadByte()))
        Next
        Return Text.ToString()
    End Function

    Public Shared Function Read_String(Data() As Byte, Offset As Integer, Length As Integer) As String
        Dim Text As New StringBuilder()
        For i As Integer = 0 To Length - 1
            Text.Append(Chr(Data(Offset + i)))
        Next
        Return Text.ToString()
    End Function

    Public Shared Function Read_String(Data As FileStream, Offset As Integer) As String
        Data.Seek(Offset, SeekOrigin.Begin)
        Dim Text As New StringBuilder()
        Dim CurrByte As Byte = Data.ReadByte()
        While CurrByte <> 0
            If CurrByte = &HA Then '0x0A (LF)
                Text.Append(Environment.NewLine)
            ElseIf CurrByte = &H1F Then 'Espanhol
                CurrByte = Data.ReadByte()
                Text.Append(Chr((CurrByte + &HDA) And &HFF))
            ElseIf CurrByte >= &HC2 And CurrByte <= &HC5 Then 'UTF8
                Dim Buffer(1) As Byte
                Buffer(0) = CurrByte
                Buffer(1) = Data.ReadByte()
                Text.Append(Encoding.UTF8.GetString(Buffer))
            Else 'ANSI
                If CurrByte > &H7F Then
                    Text.Append("\0x" & Hex(CurrByte).PadLeft(2, "0"c))
                Else
                    Text.Append(Chr(CurrByte))
                End If
            End If
            CurrByte = Data.ReadByte()
        End While
        Return Text.ToString()
    End Function
End Class
