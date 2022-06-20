<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Me.MenuStripPrincipal = New System.Windows.Forms.MenuStrip()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.lbl_usuarioLogado = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStripPrincipal
        '
        Me.MenuStripPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.MenuStripPrincipal.Name = "MenuStripPrincipal"
        Me.MenuStripPrincipal.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStripPrincipal.Size = New System.Drawing.Size(884, 24)
        Me.MenuStripPrincipal.TabIndex = 5
        Me.MenuStripPrincipal.Text = "MenuStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbl_usuarioLogado})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 419)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(884, 22)
        Me.StatusStrip.TabIndex = 9
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'lbl_usuarioLogado
        '
        Me.lbl_usuarioLogado.Name = "lbl_usuarioLogado"
        Me.lbl_usuarioLogado.Size = New System.Drawing.Size(0, 17)
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(884, 441)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStripPrincipal)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStripPrincipal
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MinimumSize = New System.Drawing.Size(480, 320)
        Me.Name = "Principal"
        Me.Opacity = 0.5R
        Me.ShowIcon = False
        Me.Text = "Controle"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStripPrincipal As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents lbl_usuarioLogado As ToolStripStatusLabel
End Class
