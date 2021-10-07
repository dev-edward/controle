<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DemandaEstado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DemandaEstado))
        Me.rdb_aguardando = New System.Windows.Forms.RadioButton()
        Me.rdb_andamento = New System.Windows.Forms.RadioButton()
        Me.rdb_feito = New System.Windows.Forms.RadioButton()
        Me.rdb_descartado = New System.Windows.Forms.RadioButton()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_alterar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'rdb_aguardando
        '
        Me.rdb_aguardando.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.rdb_aguardando.FlatAppearance.CheckedBackColor = System.Drawing.Color.Yellow
        Me.rdb_aguardando.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rdb_aguardando.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdb_aguardando.Image = CType(resources.GetObject("rdb_aguardando.Image"), System.Drawing.Image)
        Me.rdb_aguardando.Location = New System.Drawing.Point(20, 10)
        Me.rdb_aguardando.Name = "rdb_aguardando"
        Me.rdb_aguardando.Size = New System.Drawing.Size(100, 83)
        Me.rdb_aguardando.TabIndex = 0
        Me.rdb_aguardando.Text = "Aguardando"
        Me.rdb_aguardando.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdb_aguardando.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdb_aguardando.UseVisualStyleBackColor = True
        '
        'rdb_andamento
        '
        Me.rdb_andamento.Image = CType(resources.GetObject("rdb_andamento.Image"), System.Drawing.Image)
        Me.rdb_andamento.Location = New System.Drawing.Point(130, 10)
        Me.rdb_andamento.Name = "rdb_andamento"
        Me.rdb_andamento.Size = New System.Drawing.Size(100, 83)
        Me.rdb_andamento.TabIndex = 1
        Me.rdb_andamento.Text = "Em andamento"
        Me.rdb_andamento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdb_andamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdb_andamento.UseVisualStyleBackColor = True
        '
        'rdb_feito
        '
        Me.rdb_feito.Image = CType(resources.GetObject("rdb_feito.Image"), System.Drawing.Image)
        Me.rdb_feito.Location = New System.Drawing.Point(240, 10)
        Me.rdb_feito.Name = "rdb_feito"
        Me.rdb_feito.Size = New System.Drawing.Size(100, 83)
        Me.rdb_feito.TabIndex = 2
        Me.rdb_feito.Text = "Feito"
        Me.rdb_feito.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdb_feito.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdb_feito.UseVisualStyleBackColor = True
        '
        'rdb_descartado
        '
        Me.rdb_descartado.Image = CType(resources.GetObject("rdb_descartado.Image"), System.Drawing.Image)
        Me.rdb_descartado.Location = New System.Drawing.Point(350, 10)
        Me.rdb_descartado.Name = "rdb_descartado"
        Me.rdb_descartado.Size = New System.Drawing.Size(100, 83)
        Me.rdb_descartado.TabIndex = 3
        Me.rdb_descartado.Text = "Descartado"
        Me.rdb_descartado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rdb_descartado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.rdb_descartado.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(120, 110)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(90, 30)
        Me.btn_cancelar.TabIndex = 4
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_alterar
        '
        Me.btn_alterar.Location = New System.Drawing.Point(265, 110)
        Me.btn_alterar.Name = "btn_alterar"
        Me.btn_alterar.Size = New System.Drawing.Size(90, 30)
        Me.btn_alterar.TabIndex = 5
        Me.btn_alterar.Text = "Alterar"
        Me.btn_alterar.UseVisualStyleBackColor = True
        '
        'estadoAfazer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(464, 161)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_alterar)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.rdb_descartado)
        Me.Controls.Add(Me.rdb_feito)
        Me.Controls.Add(Me.rdb_andamento)
        Me.Controls.Add(Me.rdb_aguardando)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "estadoAfazer"
        Me.Text = "Alterar status do afazer para:"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rdb_aguardando As RadioButton
    Friend WithEvents rdb_andamento As RadioButton
    Friend WithEvents rdb_feito As RadioButton
    Friend WithEvents rdb_descartado As RadioButton
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_alterar As Button
End Class
