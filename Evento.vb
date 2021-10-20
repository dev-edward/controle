Public Class Evento
    Dim id As Integer
    Dim panel As New Panel With {
        .Size = New Size(270, 60),
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim btn_checar As New Button With {
        .BackgroundImage = img.certo,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup,
        .Size = New Size(26, 26),
        .Location = New Point(230, 17)
    }
    Dim lbl_hora As New Label With {
        .TextAlign = ContentAlignment.MiddleRight,
        .Size = New Size(120, 18),
        .Location = New Point(0, 0),
        .ForeColor = Color.FromArgb(255, 15, 15, 15)
    }
    Dim txt_descricao As New RichTextBox With {
        .Location = New Point(25, 0),
        .Size = New Size(200, 40),
        .Multiline = True,
        .ReadOnly = True
    }
    Friend Sub New(ByRef _spanel As Panel, ByVal _id As Integer, ByVal _hora As DateTime, ByVal _descricao As String, ByVal _checado As Boolean)
        id = _id
        lbl_hora.Text = _hora.ToString("hh:mm")
        txt_descricao.Text = _descricao
        AddHandler btn_checar.Click, AddressOf checkar
        panel.Controls.Add(lbl_hora)
        panel.Controls.Add(txt_descricao)
        panel.Controls.Add(btn_checar)
        _spanel.Controls.Add(panel)
    End Sub
    Private Sub checkar()

    End Sub
End Class
