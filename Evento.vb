Public Class Evento
    Dim id As Integer
    Dim btn_checar As New Button With {
        .BackgroundImage = img.certo,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup,
        .Size = New Size(26, 26),
        .Location = New Point(230, 7)
    }
    Dim panel As New Panel With {
        .Size = New Size(270, 50),
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim lbl_hora As New Label With {
        .TextAlign = ContentAlignment.MiddleRight,
        .Size = New Size(120, 18),
        .Location = New Point(0, 0),
        .ForeColor = Color.FromArgb(255, 15, 15, 15)
    }


    Friend Sub New(ByRef _spanel As Panel, ByVal _id As Integer, ByVal _hora As DateTime, ByVal _descricao As String)

    End Sub
End Class
