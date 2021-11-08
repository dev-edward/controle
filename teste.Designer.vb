<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class teste
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(13, 36)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(260, 23)
        Me.TextBox1.TabIndex = 0
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarFont = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.SystemColors.ControlDark
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.SystemColors.Menu
        Me.DateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(13, 97)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(10)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateTimePicker1.Size = New System.Drawing.Size(260, 23)
        Me.DateTimePicker1.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(13, 155)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(260, 23)
        Me.ComboBox1.TabIndex = 3
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(188, 203)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(85, 19)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox2.Location = New System.Drawing.Point(13, 203)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox2.Size = New System.Drawing.Size(130, 19)
        Me.CheckBox2.TabIndex = 5
        Me.CheckBox2.Text = "CheckBox2"
        Me.CheckBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(120, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Label2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(120, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Label4"
        '
        'teste
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(287, 368)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "teste"
        Me.Text = "teste"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
End Class
