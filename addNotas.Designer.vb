<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class addNotas
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
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.btn_adicionar = New System.Windows.Forms.Button()
        Me.txt_nota = New System.Windows.Forms.TextBox()
        Me.lbl_titulo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btn_cancelar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_cancelar.Location = New System.Drawing.Point(194, 98)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(100, 30)
        Me.btn_cancelar.TabIndex = 7
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'btn_adicionar
        '
        Me.btn_adicionar.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btn_adicionar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btn_adicionar.Location = New System.Drawing.Point(34, 98)
        Me.btn_adicionar.Name = "btn_adicionar"
        Me.btn_adicionar.Size = New System.Drawing.Size(100, 30)
        Me.btn_adicionar.TabIndex = 6
        Me.btn_adicionar.Text = "Adicionar"
        Me.btn_adicionar.UseVisualStyleBackColor = True
        '
        'txt_nota
        '
        Me.txt_nota.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.txt_nota.Location = New System.Drawing.Point(14, 32)
        Me.txt_nota.Multiline = True
        Me.txt_nota.Name = "txt_nota"
        Me.txt_nota.Size = New System.Drawing.Size(300, 60)
        Me.txt_nota.TabIndex = 5
        '
        'lbl_titulo
        '
        Me.lbl_titulo.AutoSize = True
        Me.lbl_titulo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.lbl_titulo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl_titulo.Location = New System.Drawing.Point(55, 10)
        Me.lbl_titulo.Name = "lbl_titulo"
        Me.lbl_titulo.Size = New System.Drawing.Size(215, 19)
        Me.lbl_titulo.TabIndex = 4
        Me.lbl_titulo.Text = "Adicione uma nota para este item"
        '
        'addNotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 138)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_adicionar)
        Me.Controls.Add(Me.txt_nota)
        Me.Controls.Add(Me.lbl_titulo)
        Me.Name = "addNotas"
        Me.Text = "addNotas"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_cancelar As Button
    Friend WithEvents btn_adicionar As Button
    Friend WithEvents txt_nota As TextBox
    Friend WithEvents lbl_titulo As Label
End Class
