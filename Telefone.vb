Public Class Telefone
    Dim id As Integer
    Dim panel As New Panel With {
            .Size = New Size(280, 40),
            .BackColor = Color.FromArgb(255, 115, 15, 115)
    }
    Dim lbl_numero As New Label With {
        .TextAlign = ContentAlignment.MiddleRight,
        .Width = 90,
        .Location = New Point(10, 0)
    }
    Dim lbl_pessoa As New Label With {
        .TextAlign = ContentAlignment.MiddleCenter,
        .Width = 90,
        .Location = New Point(100, 0),
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .Font = New Font("Impact", 11)
    }
    Dim lbl_local As New Label With {
        .TextAlign = ContentAlignment.MiddleLeft,
        .Width = 90,
        .Location = New Point(190, 0)
    }
    Friend Sub New(ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _numero As String, ByVal _pessoa As String, ByVal _local As String, ByVal _posicaoY As Integer)
        id = _id
        lbl_numero.Text = _numero
        lbl_pessoa.Text = _local
        lbl_local.Text = _local

        panel.Controls.Add(lbl_numero)
        panel.Controls.Add(lbl_pessoa)
        panel.Controls.Add(lbl_local)
        _conteiner.Controls.Add(panel)
    End Sub
End Class
