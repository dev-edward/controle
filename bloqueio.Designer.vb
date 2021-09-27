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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.rbt_outro = New System.Windows.Forms.RadioButton()
        Me.rbt_almoco = New System.Windows.Forms.RadioButton()
        Me.rbt_banheiro = New System.Windows.Forms.RadioButton()
        Me.rbt_setor = New System.Windows.Forms.RadioButton()
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
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(150, 150)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Bloquear tela"
        Me.Button1.UseVisualStyleBackColor = True
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
        'bloqueio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(404, 191)
        Me.Controls.Add(Me.rbt_setor)
        Me.Controls.Add(Me.rbt_banheiro)
        Me.Controls.Add(Me.rbt_almoco)
        Me.Controls.Add(Me.rbt_outro)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txt_mensagem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "bloqueio"
        Me.Text = "Bloqueio de tela"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_mensagem As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents rbt_outro As RadioButton
    Friend WithEvents rbt_almoco As RadioButton
    Friend WithEvents rbt_banheiro As RadioButton
    Friend WithEvents rbt_setor As RadioButton
End Class
