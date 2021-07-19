<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Me.btn_sair = New System.Windows.Forms.Button()
        Me.btn_entrar = New System.Windows.Forms.Button()
        Me.lbl_senha = New System.Windows.Forms.Label()
        Me.txt_senha = New System.Windows.Forms.TextBox()
        Me.lbl_usuario = New System.Windows.Forms.Label()
        Me.txt_usuario = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_sair
        '
        Me.btn_sair.Location = New System.Drawing.Point(295, 141)
        Me.btn_sair.Name = "btn_sair"
        Me.btn_sair.Size = New System.Drawing.Size(75, 23)
        Me.btn_sair.TabIndex = 20
        Me.btn_sair.Text = "Sair"
        Me.btn_sair.UseVisualStyleBackColor = True
        '
        'btn_entrar
        '
        Me.btn_entrar.Location = New System.Drawing.Point(190, 141)
        Me.btn_entrar.Name = "btn_entrar"
        Me.btn_entrar.Size = New System.Drawing.Size(75, 23)
        Me.btn_entrar.TabIndex = 19
        Me.btn_entrar.Text = "Entrar"
        Me.btn_entrar.UseVisualStyleBackColor = True
        '
        'lbl_senha
        '
        Me.lbl_senha.AutoSize = True
        Me.lbl_senha.Location = New System.Drawing.Point(190, 69)
        Me.lbl_senha.Name = "lbl_senha"
        Me.lbl_senha.Size = New System.Drawing.Size(39, 15)
        Me.lbl_senha.TabIndex = 18
        Me.lbl_senha.Text = "Senha"
        '
        'txt_senha
        '
        Me.txt_senha.Location = New System.Drawing.Point(190, 90)
        Me.txt_senha.Name = "txt_senha"
        Me.txt_senha.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txt_senha.PlaceholderText = "senha"
        Me.txt_senha.Size = New System.Drawing.Size(180, 23)
        Me.txt_senha.TabIndex = 17
        '
        'lbl_usuario
        '
        Me.lbl_usuario.AutoSize = True
        Me.lbl_usuario.Location = New System.Drawing.Point(190, 15)
        Me.lbl_usuario.Name = "lbl_usuario"
        Me.lbl_usuario.Size = New System.Drawing.Size(47, 15)
        Me.lbl_usuario.TabIndex = 16
        Me.lbl_usuario.Text = "Usuário"
        '
        'txt_usuario
        '
        Me.txt_usuario.Location = New System.Drawing.Point(190, 36)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.PlaceholderText = "nome de usuário"
        Me.txt_usuario.Size = New System.Drawing.Size(180, 23)
        Me.txt_usuario.TabIndex = 15
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(0, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(160, 192)
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_sair)
        Me.Controls.Add(Me.btn_entrar)
        Me.Controls.Add(Me.lbl_senha)
        Me.Controls.Add(Me.txt_senha)
        Me.Controls.Add(Me.lbl_usuario)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.PictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_sair As Button
    Friend WithEvents btn_entrar As Button
    Friend WithEvents lbl_senha As Label
    Friend WithEvents txt_senha As TextBox
    Friend WithEvents lbl_usuario As Label
    Friend WithEvents txt_usuario As TextBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
