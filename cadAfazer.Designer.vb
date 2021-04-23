<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class cadAfazer
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txt_detalhes = New System.Windows.Forms.TextBox()
        Me.lbl_detalhes = New System.Windows.Forms.Label()
        Me.dtp_prazo = New System.Windows.Forms.DateTimePicker()
        Me.lbl_prazo = New System.Windows.Forms.Label()
        Me.cbx_estado = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_salvar = New System.Windows.Forms.Button()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.txt_titulo = New System.Windows.Forms.TextBox()
        Me.lbl_cadastre = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_detalhes
        '
        Me.txt_detalhes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_detalhes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_detalhes.Location = New System.Drawing.Point(54, 179)
        Me.txt_detalhes.Multiline = True
        Me.txt_detalhes.Name = "txt_detalhes"
        Me.txt_detalhes.Size = New System.Drawing.Size(219, 83)
        Me.txt_detalhes.TabIndex = 0
        '
        'lbl_detalhes
        '
        Me.lbl_detalhes.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_detalhes.AutoSize = True
        Me.lbl_detalhes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_detalhes.Location = New System.Drawing.Point(123, 143)
        Me.lbl_detalhes.Name = "lbl_detalhes"
        Me.lbl_detalhes.Size = New System.Drawing.Size(73, 20)
        Me.lbl_detalhes.TabIndex = 1
        Me.lbl_detalhes.Text = "Detalhes"
        '
        'dtp_prazo
        '
        Me.dtp_prazo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dtp_prazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_prazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_prazo.Location = New System.Drawing.Point(103, 314)
        Me.dtp_prazo.Name = "dtp_prazo"
        Me.dtp_prazo.Size = New System.Drawing.Size(121, 26)
        Me.dtp_prazo.TabIndex = 2
        '
        'lbl_prazo
        '
        Me.lbl_prazo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lbl_prazo.AutoSize = True
        Me.lbl_prazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prazo.Location = New System.Drawing.Point(138, 278)
        Me.lbl_prazo.Name = "lbl_prazo"
        Me.lbl_prazo.Size = New System.Drawing.Size(50, 20)
        Me.lbl_prazo.TabIndex = 3
        Me.lbl_prazo.Text = "Prazo"
        '
        'cbx_estado
        '
        Me.cbx_estado.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.cbx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_estado.FormattingEnabled = True
        Me.cbx_estado.Items.AddRange(New Object() {"Não feito", "Em andamento", "Feito"})
        Me.cbx_estado.Location = New System.Drawing.Point(103, 392)
        Me.cbx_estado.Name = "cbx_estado"
        Me.cbx_estado.Size = New System.Drawing.Size(121, 28)
        Me.cbx_estado.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 356)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Estado"
        '
        'btn_salvar
        '
        Me.btn_salvar.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btn_salvar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_salvar.Location = New System.Drawing.Point(54, 436)
        Me.btn_salvar.Name = "btn_salvar"
        Me.btn_salvar.Size = New System.Drawing.Size(219, 43)
        Me.btn_salvar.TabIndex = 6
        Me.btn_salvar.Text = "Salvar"
        Me.btn_salvar.UseVisualStyleBackColor = True
        '
        'lbl_titulo
        '
        Me.lbl_titulo.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(140, 63)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(47, 20)
        Me.lbl_titulo.TabIndex = 8
        Me.lbl_titulo.Text = "Titulo"
        '
        'txt_titulo
        '
        Me.txt_titulo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.txt_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_titulo.Location = New System.Drawing.Point(54, 99)
        Me.txt_titulo.Multiline = True
        Me.txt_titulo.Name = "txt_titulo"
        Me.txt_titulo.Size = New System.Drawing.Size(219, 28)
        Me.txt_titulo.TabIndex = 7
        '
        'lbl_cadastre
        '
        Me.lbl_cadastre.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lbl_cadastre.AutoSize = True
        Me.lbl_cadastre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_cadastre.Location = New System.Drawing.Point(40, 23)
        Me.lbl_cadastre.Name = "lbl_cadastre"
        Me.lbl_cadastre.Size = New System.Drawing.Size(246, 24)
        Me.lbl_cadastre.TabIndex = 9
        Me.lbl_cadastre.Text = "Cadastre uma nova tarefa"
        '
        'cadAfazer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(326, 530)
        Me.ControlBox = False
        Me.Controls.Add(Me.lbl_cadastre)
        Me.Controls.Add(Me.lbl_titulo)
        Me.Controls.Add(Me.txt_titulo)
        Me.Controls.Add(Me.btn_salvar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbx_estado)
        Me.Controls.Add(Me.lbl_prazo)
        Me.Controls.Add(Me.dtp_prazo)
        Me.Controls.Add(Me.lbl_detalhes)
        Me.Controls.Add(Me.txt_detalhes)
        Me.Name = "cadAfazer"
        Me.Text = "Cadastrar afazer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_detalhes As TextBox
    Friend WithEvents lbl_detalhes As Label
    Friend WithEvents dtp_prazo As DateTimePicker
    Friend WithEvents lbl_prazo As Label
    Friend WithEvents cbx_estado As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_salvar As Button
    Friend WithEvents lbl_titulo As Label
    Friend WithEvents txt_titulo As TextBox
    Friend WithEvents lbl_cadastre As Label
End Class
