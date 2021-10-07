Public Class Telefone
    Dim id As Integer
    Dim panel As New Panel With {
        .Size = New Size(270, 36),
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim lbl_numero As New Label With {
        .TextAlign = ContentAlignment.MiddleRight,
        .Size = New Size(120, 18),
        .Location = New Point(0, 0),
        .ForeColor = Color.FromArgb(255, 15, 15, 15)
    }
    Dim lbl_pessoa As New Label With {
        .TextAlign = ContentAlignment.MiddleLeft,
        .Size = New Size(150, 18),
        .Location = New Point(120, 0)
    }
    Dim lbl_local As New Label With {
        .TextAlign = ContentAlignment.MiddleCenter,
        .Size = New Size(270, 16),
        .Location = New Point(0, 16)
    }
    Friend Sub New(ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _numero As String, ByVal _pessoa As String, ByVal _local As String, ByVal _posicaoY As Integer)
        id = _id
        lbl_numero.Text = _numero
        lbl_pessoa.Text = " | " & _pessoa
        lbl_local.Text = _local
        panel.Location = New Point(6, _posicaoY)
        lbl_numero.Font = New Font(lbl_numero.Font.FontFamily, 10, FontStyle.Bold)
        lbl_pessoa.Font = New Font(lbl_numero.Font.FontFamily, 9, FontStyle.Bold)
        panel.Controls.Add(lbl_numero)
        panel.Controls.Add(lbl_pessoa)
        panel.Controls.Add(lbl_local)
        _conteiner.Controls.Add(panel)
    End Sub
End Class
