<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupSSVP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupSSVP))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelSetup = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnContinuar = New System.Windows.Forms.Button()
        Me.txtLocal = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkBoxAtalho = New System.Windows.Forms.CheckedListBox()
        Me.lblAguarde = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.Setup_SSVP_CNB.My.Resources.Resources.Install_SSVP
        Me.PictureBox1.Location = New System.Drawing.Point(-1, -2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(388, 320)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'LabelSetup
        '
        Me.LabelSetup.AutoSize = True
        Me.LabelSetup.BackColor = System.Drawing.Color.GreenYellow
        Me.LabelSetup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSetup.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LabelSetup.Location = New System.Drawing.Point(4, 322)
        Me.LabelSetup.Name = "LabelSetup"
        Me.LabelSetup.Size = New System.Drawing.Size(180, 13)
        Me.LabelSetup.TabIndex = 1
        Me.LabelSetup.Text = "Iniciar a Instalação do sistema"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(4, 339)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(377, 23)
        Me.ProgressBar1.TabIndex = 2
        '
        'btnContinuar
        '
        Me.btnContinuar.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.btnContinuar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContinuar.ForeColor = System.Drawing.Color.Green
        Me.btnContinuar.Location = New System.Drawing.Point(306, 271)
        Me.btnContinuar.Name = "btnContinuar"
        Me.btnContinuar.Size = New System.Drawing.Size(71, 36)
        Me.btnContinuar.TabIndex = 3
        Me.btnContinuar.Text = "Continuar"
        Me.btnContinuar.UseVisualStyleBackColor = False
        '
        'txtLocal
        '
        Me.txtLocal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLocal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLocal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtLocal.Location = New System.Drawing.Point(4, 280)
        Me.txtLocal.Name = "txtLocal"
        Me.txtLocal.Size = New System.Drawing.Size(259, 20)
        Me.txtLocal.TabIndex = 4
        Me.txtLocal.Text = "C:\App_SSVP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 265)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Local para a Instalação:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(261, 280)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(28, 19)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkBoxAtalho
        '
        Me.chkBoxAtalho.FormattingEnabled = True
        Me.chkBoxAtalho.Items.AddRange(New Object() {"Criar Atalho na área de trabalho", "Criar Atalho no menu Iniciar"})
        Me.chkBoxAtalho.Location = New System.Drawing.Point(168, 219)
        Me.chkBoxAtalho.Name = "chkBoxAtalho"
        Me.chkBoxAtalho.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkBoxAtalho.Size = New System.Drawing.Size(211, 49)
        Me.chkBoxAtalho.TabIndex = 7
        '
        'lblAguarde
        '
        Me.lblAguarde.AutoSize = True
        Me.lblAguarde.BackColor = System.Drawing.Color.White
        Me.lblAguarde.Location = New System.Drawing.Point(3, 302)
        Me.lblAguarde.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblAguarde.Name = "lblAguarde"
        Me.lblAguarde.Size = New System.Drawing.Size(272, 13)
        Me.lblAguarde.TabIndex = 8
        Me.lblAguarde.Text = "Aguarde, este processo pode demorar alguns minutos ..."
        Me.lblAguarde.Visible = False
        '
        'SetupSSVP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.GreenYellow
        Me.ClientSize = New System.Drawing.Size(386, 372)
        Me.Controls.Add(Me.lblAguarde)
        Me.Controls.Add(Me.chkBoxAtalho)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtLocal)
        Me.Controls.Add(Me.btnContinuar)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.LabelSetup)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SetupSSVP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "INSTALAÇÃO - SSVP-CNB"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents LabelSetup As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents btnContinuar As System.Windows.Forms.Button
    Friend WithEvents txtLocal As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkBoxAtalho As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblAguarde As System.Windows.Forms.Label

End Class
