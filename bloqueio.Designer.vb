<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class bloqueio
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txt_mensagem = New System.Windows.Forms.TextBox()
        Me.btn_bloquear = New System.Windows.Forms.Button()
        Me.rbt_outro = New System.Windows.Forms.RadioButton()
        Me.rbt_almoco = New System.Windows.Forms.RadioButton()
        Me.rbt_banheiro = New System.Windows.Forms.RadioButton()
        Me.rbt_setor = New System.Windows.Forms.RadioButton()
        Me.btn_voltei = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txt_mensagem
        '
        Me.txt_mensagem.Location = New System.Drawing.Point(10, 10)
        Me.txt_mensagem.Multiline = True
        Me.txt_mensagem.Name = "txt_mensagem"
        Me.txt_mensagem.Size = New System.Drawing.Size(380, 90)
        Me.txt_mensagem.TabIndex = 0
        '
        'btn_bloquear
        '
        Me.btn_bloquear.BackColor = System.Drawing.Color.Tomato
        Me.btn_bloquear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_bloquear.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btn_bloquear.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_bloquear.Location = New System.Drawing.Point(150, 150)
        Me.btn_bloquear.Name = "btn_bloquear"
        Me.btn_bloquear.Size = New System.Drawing.Size(100, 30)
        Me.btn_bloquear.TabIndex = 1
        Me.btn_bloquear.Text = "Bloquear"
        Me.btn_bloquear.UseVisualStyleBackColor = False
        '
        'rbt_outro
        '
        Me.rbt_outro.AutoSize = True
        Me.rbt_outro.Location = New System.Drawing.Point(308, 106)
        Me.rbt_outro.Name = "rbt_outro"
        Me.rbt_outro.Size = New System.Drawing.Size(56, 19)
        Me.rbt_outro.TabIndex = 2
        Me.rbt_outro.TabStop = True
        Me.rbt_outro.Text = "Outro"
        Me.rbt_outro.UseVisualStyleBackColor = True
        '
        'rbt_almoco
        '
        Me.rbt_almoco.AutoSize = True
        Me.rbt_almoco.Location = New System.Drawing.Point(48, 106)
        Me.rbt_almoco.Name = "rbt_almoco"
        Me.rbt_almoco.Size = New System.Drawing.Size(67, 19)
        Me.rbt_almoco.TabIndex = 3
        Me.rbt_almoco.TabStop = True
        Me.rbt_almoco.Text = "Almoço"
        Me.rbt_almoco.UseVisualStyleBackColor = True
        '
        'rbt_banheiro
        '
        Me.rbt_banheiro.AutoSize = True
        Me.rbt_banheiro.Location = New System.Drawing.Point(138, 106)
        Me.rbt_banheiro.Name = "rbt_banheiro"
        Me.rbt_banheiro.Size = New System.Drawing.Size(72, 19)
        Me.rbt_banheiro.TabIndex = 4
        Me.rbt_banheiro.TabStop = True
        Me.rbt_banheiro.Text = "Banheiro"
        Me.rbt_banheiro.UseVisualStyleBackColor = True
        '
        'rbt_setor
        '
        Me.rbt_setor.AutoSize = True
        Me.rbt_setor.Location = New System.Drawing.Point(233, 106)
        Me.rbt_setor.Name = "rbt_setor"
        Me.rbt_setor.Size = New System.Drawing.Size(52, 19)
        Me.rbt_setor.TabIndex = 5
        Me.rbt_setor.TabStop = True
        Me.rbt_setor.Text = "Setor"
        Me.rbt_setor.UseVisualStyleBackColor = True
        '
        'btn_voltei
        '
        Me.btn_voltei.BackColor = System.Drawing.Color.SteelBlue
        Me.btn_voltei.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btn_voltei.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.btn_voltei.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btn_voltei.Location = New System.Drawing.Point(256, 150)
        Me.btn_voltei.Name = "btn_voltei"
        Me.btn_voltei.Size = New System.Drawing.Size(100, 30)
        Me.btn_voltei.TabIndex = 6
        Me.btn_voltei.Text = "Voltei"
        Me.btn_voltei.UseVisualStyleBackColor = False
        '
        'bloqueio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 191)
        Me.Controls.Add(Me.btn_voltei)
        Me.Controls.Add(Me.rbt_setor)
        Me.Controls.Add(Me.rbt_banheiro)
        Me.Controls.Add(Me.rbt_almoco)
        Me.Controls.Add(Me.rbt_outro)
        Me.Controls.Add(Me.btn_bloquear)
        Me.Controls.Add(Me.txt_mensagem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "bloqueio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bloqueio de tela"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_mensagem As TextBox
    Friend WithEvents btn_bloquear As Button
    Friend WithEvents rbt_outro As RadioButton
    Friend WithEvents rbt_almoco As RadioButton
    Friend WithEvents rbt_banheiro As RadioButton
    Friend WithEvents rbt_setor As RadioButton
    Friend WithEvents btn_voltei As Button
End Class
