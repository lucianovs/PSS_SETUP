Imports System
Imports System.IO
Imports System.Net.NetworkInformation
Imports IWshRuntimeLibrary

Public Class SetupSSVP
    Private sMensagemVPN As String = ""

    Private Sub btnContinuar_Click(sender As Object, e As EventArgs) Handles btnContinuar.Click
        Dim sDirVPN As String = LerDadosINI(nomeArquivoINI(), "SETUP", "DIR VPN", "%Roaming%\Microsoft\Network\Connections\Pbk")
        Dim sNomeArqVPN As String = LerDadosINI(nomeArquivoINI(), "SETUP", "ARQ VPN", "hasphone.Pbk")
        Dim sDirAppUser As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Dim s As String
        '"C:\Users\usuario local\AppData\Roaming\Microsoft\Network\Connections\Pbk"

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Environment.SpecialFolder.LocalApplicationData.ToString

        sDirVPN = Replace(LCase(sDirVPN), "%roaming%", sDirAppUser)

        lblAguarde.Visible = True
        btnContinuar.Enabled = True

        LabelSetup.Text = "Testando a Conexão com o Servidor SSVP-CNB ..."
        LabelSetup.Refresh()

        Application.DoEvents()

        'Verificar se a VPN está Ativa
        If Not PingVPN("192.168.2.1") Then
            'Instalar a VPN
            If Dir(sDirVPN & "\" & sNomeArqVPN) = "" Then
                'Verificar se existe o arquivo da VPN
                If Dir(Application.StartupPath & "\" & sNomeArqVPN) = "" Then
                    MsgBox("O arquivo de configuração da VPN não foi encontrado!! Contactar a equipe do sistema.")
                    GoTo FimProcesso
                Else
                    LabelSetup.Text = "Instalando as configurações da VPN ... "
                    LabelSetup.Refresh()

                    If Not System.IO.Directory.Exists(sDirVPN) Then
                        Try
                            System.IO.Directory.CreateDirectory(sDirVPN)
                        Catch
                            MsgBox(Err.Description & Chr(13) & "Favor contactar o administrador do sistema ou faça um logon como administrador.")
                            GoTo FimProcesso
                        Finally

                        End Try
                    End If

                    System.IO.File.Copy(Application.StartupPath & "\" & sNomeArqVPN, sDirVPN & "\" & sNomeArqVPN, True)

                    LabelSetup.Text = "Aguarde, este processo pode demorar alguns minutos ... "
                    LabelSetup.Visible = False

                    MsgBox("VPN instalada com sucesso!! Uma janela da VPN irá aparecer para você se Conectar com a VPN. Repetir a instalação assim que se autenticar." & Chr(13) & "Caso não consiga conectar com a VPN, entrar em contato com a equipe do sistema!!")
                End If
            Else
                MsgBox("VPN não ativa!! Uma janela da VPN irá aparecer para você se Conectar com a VPN. Repetir a instalação assim que se autenticar." & Chr(13) & "Caso não consiga conectar com a VPN, entrar em contato com a equipe do sistema!!")
            End If
        Else
            btnContinuar.Enabled = False
        End If

        If btnContinuar.Enabled Then
            Try
                Dim startInfo2 As New ProcessStartInfo(sDirVPN & "\" & sNomeArqVPN)
                startInfo2.WindowStyle = ProcessWindowStyle.Normal
                Process.Start(startInfo2)
            Catch
                MsgBox(Err.Description)
            Finally
            End Try
            GoTo FimProcesso
        End If

        LabelSetup.Text = "Criando o Diretório ..."
        LabelSetup.Refresh()

        If Not System.IO.Directory.Exists(txtLocal.Text) Then
            System.IO.Directory.CreateDirectory(txtLocal.Text)
        End If

        'Diretório para os Reports
        If Not System.IO.Directory.Exists(txtLocal.Text & "\Reports") Then
            System.IO.Directory.CreateDirectory(txtLocal.Text & "\Reports")
        End If

        'Arquivos Principais
        Dim DirDiretorio As DirectoryInfo = New DirectoryInfo("\\192.168.2.1\publicos\App_SSVP")
        Dim oFileInfoCollection() As FileInfo
        Dim oFileInfo As FileInfo
        Dim i As Integer

        oFileInfoCollection = DirDiretorio.GetFiles("*.*")

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = oFileInfoCollection.Length()
        ProgressBar1.Value = 0

        'Copiando os Arquivos executaveis
        For i = 0 To oFileInfoCollection.Length() - 1

            ProgressBar1.Value += 1
            ProgressBar1.Refresh()
            oFileInfo = oFileInfoCollection.GetValue(i)

            If LerDadosINI(nomeArquivoINI(), "SETUP", getNomeArquivo(oFileInfo.Name), "NAO") = "SIM" Or _
                LCase(oFileInfo.Name) = "logo.png" Or LCase(oFileInfo.Name) = "ssvp.ini" Then

                'lblAguarde.Visible = Not lblAguarde.Visible
                LabelSetup.Text = "Copiando arquivo ... " & oFileInfo.Name
                LabelSetup.Refresh()

                System.IO.File.Copy(oFileInfo.DirectoryName & "\" & oFileInfo.Name, txtLocal.Text & "\" & oFileInfo.Name, True)

                Me.Refresh()
                Application.DoEvents()
            End If
        Next

        'Arquivos de relatórios
        DirDiretorio = New DirectoryInfo("\\192.168.2.1\publicos\App_SSVP\Reports")
        oFileInfoCollection = DirDiretorio.GetFiles("*.*")

        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = oFileInfoCollection.Length()
        ProgressBar1.Value = 0

        'Copiando os Arquivos executaveis
        For i = 0 To oFileInfoCollection.Length() - 1
            ProgressBar1.Value += 1
            ProgressBar1.Refresh()
            oFileInfo = oFileInfoCollection.GetValue(i)

            If LerDadosINI(nomeArquivoINI(), "SETUP", getNomeArquivo(oFileInfo.Name), "NAO") = "SIM" Then

                'lblAguarde.Visible = Not lblAguarde.Visible
                LabelSetup.Text = "Copiando arquivo ... " & oFileInfo.Name
                LabelSetup.Refresh()

                System.IO.File.Copy(oFileInfo.DirectoryName & "\" & oFileInfo.Name, txtLocal.Text & "\Reports\" & oFileInfo.Name, True)

                Me.Refresh()
                Application.DoEvents()
            End If
        Next

        'Verificar se definiu a criação dos Atalhos
        If chkBoxAtalho.GetItemChecked(0) = True Then
            'Criar Atalho no DeskTop
            LabelSetup.Text = "Gerando Atalho no DeskTop ..."
            LabelSetup.Refresh()

            CriarAtalho("Desktop")
        End If
        If chkBoxAtalho.GetItemChecked(0) Then
            'Criar Atalho no Menu Iniciar
            LabelSetup.Text = "Gerando Atalho no menu Iniciar ..."
            LabelSetup.Refresh()

            CriarAtalho("StartMenu")
        End If

        LabelSetup.Text = "Instalando a Plataforma de relatórios ..."
        LabelSetup.Refresh()

        'Verificar a instalaçao do crystal report
        If Environment.Is64BitOperatingSystem Then
            s = Application.StartupPath & "\CRRuntime_64bit_13_0_12.msi"
        Else
            s = Application.StartupPath & "\CRRuntime_32bit_13_0_12.msi"
        End If

        If My.Computer.FileSystem.FileExists(s) Then
            s = """" & s & """"
            Shell(s, , True, 1000)
        Else
            s = ""
            MsgBox("Erro ao instalar a plataforma de Relatórios. Contactar o administrador do sistema.")
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default

        MsgBox("Instalação Concluída com Sucesso !!" & IIf(s = "", "", Chr(13) & "Com erros na Plataforma de relatórios."))
        Application.Exit()

FimProcesso:
        Me.Cursor = System.Windows.Forms.Cursors.Default
        lblAguarde.Visible = False

        LabelSetup.Text = ""
        LabelSetup.Refresh()

    End Sub

    Private Function PingVPN(fIPNum As String) As Boolean
        Dim PingSender As New Ping

        Try
            Dim reply As PingReply = PingSender.Send(fIPNum)

            If (reply.Status = IPStatus.Success) Then
                Return True
            Else
                sMensagemVPN = "A instalação não pode continuar. O Servidor do CNB não está respondendo. Possíveis causas:" & Chr(13) & _
                    "1 - Você está sem Internet;" & Chr(13) & _
                    "2 - A VPN não está conectada;" & Chr(13) & _
                    "3 - A rede do CNB está offline." & Chr(13) & _
                    "Caso nenhuma das opções acima é o seu caso, entrar em contato com o Suporte do Sistema."
                Return False
            End If

            Return True
        Catch err As Exception
            sMensagemVPN = "O Servidor do CNB não está respondendo. Possíveis causas:" & Chr(13) & _
                   "1 - Está sem Internet na sua rede;" & Chr(13) & _
                   "2 - A VPN não está conectada;" & Chr(13) & _
                   "3 - A rede do CNB está off line." & Chr(13) & _
                    "Caso nenhuma das opções acima é o seu caso, entrar em contato com o Suporte do Sistema."
            Return False
        End Try

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FolderBrowserDialog1.Description = "Selecione um diretório para a instalação:"
        FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
        FolderBrowserDialog1.ShowNewFolderButton = False

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            txtLocal.Text = FolderBrowserDialog1.SelectedPath & "\App_SSVP"
        End If
    End Sub

    Private Sub CriarAtalho(ByVal fDestino As String)

        Dim WshShell As New IWshRuntimeLibrary.WshShell
        Dim diretorioDesktop As String = CType(WshShell.SpecialFolders.Item(fDestino), String)
        Dim atalho As IWshRuntimeLibrary.IWshShortcut

        'Apagar o Atalho, Caso Exista
        If Dir(diretorioDesktop & "\Desktop.lnk") <> "" Then
            Kill(diretorioDesktop & "\Desktop.lnk")
        End If

        'Criar o Atalho - Só será gravado o arquivo quando executar o save
        atalho = CType(WshShell.CreateShortcut(diretorioDesktop & "\Desktop.lnk"), IWshRuntimeLibrary.IWshShortcut)

        ' Define as propriedades do atalho
        With atalho
            .TargetPath = txtLocal.Text & "\" & "Desktop.exe"
            .WindowStyle = 1
            .Description = "Sistema SSVP-CNB"
            .WorkingDirectory = txtLocal.Text
            ' obtem o icon do programa executor
            '.IconLocation = System.Reflection.Assembly.GetExecutingAssembly.Location() & ", 0"
            .IconLocation = txtLocal.Text & "\" & "Desktop.exe, 0"
            'salva o arquivo de atalho
            .Save()
        End With

    End Sub

    Private Sub SetupSSVP_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        chkBoxAtalho.SetItemChecked(0, True)
        chkBoxAtalho.SetItemChecked(1, True)

    End Sub
End Class
