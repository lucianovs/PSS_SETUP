Imports System.Text

Module modSetup
    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Integer

    'Usa a função GetPrivateProfileString para obter os valores do Arquivo Ini
    Public Function LerDadosINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String
        Const MAX_LENGTH As Integer = 500

        Dim string_builder As New StringBuilder(MAX_LENGTH)

        GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)

        Return string_builder.ToString()

    End Function

    ' Retorna o nome do arquivo INI 
    Public Function nomeArquivoINI() As String
        Dim nome_arquivo_ini As String = Application.StartupPath

        Return nome_arquivo_ini & "\SetupSSVP.ini"

    End Function

    Public Function getNomeArquivo(fArquivo As String) As String
        Dim nPos As Integer

        nPos = InStr(fArquivo, "_", vbTextCompare)
        If nPos > 0 Then
            getNomeArquivo = Microsoft.VisualBasic.Left(fArquivo, nPos - 1)
        Else
            nPos = InStr(fArquivo, ".", vbTextCompare)
            If nPos > 0 Then
                getNomeArquivo = Microsoft.VisualBasic.Left(fArquivo, nPos - 1)
            Else
                getNomeArquivo = fArquivo
            End If
        End If
        getNomeArquivo = UCase(getNomeArquivo)
    End Function

End Module
