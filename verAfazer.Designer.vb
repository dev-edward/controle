<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class verAfazer
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
        Me.txt_titulo = New System.Windows.Forms.TextBox()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.lbl_estado = New System.Windows.Forms.Label()
        Me.cbx_estado = New System.Windows.Forms.ComboBox()
        Me.lbl_prazo = New System.Windows.Forms.Label()
        Me.dtp_prazo = New System.Windows.Forms.DateTimePicker()
        Me.btn_modificar = New System.Windows.Forms.Button()
        Me.btn_addnota = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txt_titulo
        '
        Me.txt_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_titulo.Location = New System.Drawing.Point(23, 91)
        Me.txt_titulo.Name = "txt_titulo"
        Me.txt_titulo.Size = New System.Drawing.Size(193, 26)
        Me.txt_titulo.TabIndex = 0
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_titulo.Location = New System.Drawing.Point(96, 60)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(47, 20)
        Me.lbl_titulo.TabIndex = 1
        Me.lbl_titulo.Text = "Título"
        '
        'lbl_estado
        '
        Me.lbl_estado.AutoSize = True
        Me.lbl_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_estado.Location = New System.Drawing.Point(440, 60)
        Me.lbl_estado.Name = "lbl_estado"
        Me.lbl_estado.Size = New System.Drawing.Size(60, 20)
        Me.lbl_estado.TabIndex = 9
        Me.lbl_estado.Text = "Estado"
        '
        'cbx_estado
        '
        Me.cbx_estado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbx_estado.FormattingEnabled = True
        Me.cbx_estado.Items.AddRange(New Object() {"Não feito", "Em andamento", "Feito"})
        Me.cbx_estado.Location = New System.Drawing.Point(410, 90)
        Me.cbx_estado.Name = "cbx_estado"
        Me.cbx_estado.Size = New System.Drawing.Size(121, 28)
        Me.cbx_estado.TabIndex = 8
        '
        'lbl_prazo
        '
        Me.lbl_prazo.AutoSize = True
        Me.lbl_prazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_prazo.Location = New System.Drawing.Point(295, 60)
        Me.lbl_prazo.Name = "lbl_prazo"
        Me.lbl_prazo.Size = New System.Drawing.Size(50, 20)
        Me.lbl_prazo.TabIndex = 7
        Me.lbl_prazo.Text = "Prazo"
        '
        'dtp_prazo
        '
        Me.dtp_prazo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtp_prazo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtp_prazo.Location = New System.Drawing.Point(260, 91)
        Me.dtp_prazo.Name = "dtp_prazo"
        Me.dtp_prazo.Size = New System.Drawing.Size(121, 26)
        Me.dtp_prazo.TabIndex = 6
        '
        'btn_modificar
        '
        Me.btn_modificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_modificar.Location = New System.Drawing.Point(540, 87)
        Me.btn_modificar.Name = "btn_modificar"
        Me.btn_modificar.Size = New System.Drawing.Size(85, 34)
        Me.btn_modificar.TabIndex = 10
        Me.btn_modificar.Text = "Modificar"
        Me.btn_modificar.UseVisualStyleBackColor = True
        '
        'btn_addnota
        '
        Me.btn_addnota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_addnota.Location = New System.Drawing.Point(629, 87)
        Me.btn_addnota.Name = "btn_addnota"
        Me.btn_addnota.Size = New System.Drawing.Size(85, 34)
        Me.btn_addnota.TabIndex = 12
        Me.btn_addnota.Text = "add. nota"
        Me.btn_addnota.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(23, 158)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(733, 57)
        Me.TextBox2.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lbl_titulo)
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.txt_titulo)
        Me.Panel1.Controls.Add(Me.btn_addnota)
        Me.Panel1.Controls.Add(Me.dtp_prazo)
        Me.Panel1.Controls.Add(Me.btn_modificar)
        Me.Panel1.Controls.Add(Me.lbl_prazo)
        Me.Panel1.Controls.Add(Me.lbl_estado)
        Me.Panel1.Controls.Add(Me.cbx_estado)
        Me.Panel1.Location = New System.Drawing.Point(12, 262)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(790, 248)
        Me.Panel1.TabIndex = 14
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(385, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(120, 26)
        Me.DateTimePicker1.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(243, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Data do cadastro:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(364, 135)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 20)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Detalhes"
        '
        'verAfazer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 555)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "verAfazer"
        Me.Text = "Lista de Afazeres"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents txt_titulo As TextBox
    Friend WithEvents lbl_titulo As Label
    Friend WithEvents lbl_estado As Label
    Friend WithEvents cbx_estado As ComboBox
    Friend WithEvents lbl_prazo As Label
    Friend WithEvents dtp_prazo As DateTimePicker
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_addnota As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
