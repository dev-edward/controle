Imports System.Data.SqlClient
Public Class Evento
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Dim id As Integer
    Dim frequencia As Integer
    Dim sql As String
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
    Friend Sub New(ByRef _spanel As Panel, ByVal _id As Integer, ByVal _hora As DateTime, ByVal _descricao As String, ByVal _checado As Boolean, ByVal _frequencia As Integer, ByVal _allday As Boolean, ByVal _posicaoY As Integer)
        id = _id
        frequencia = _frequencia
        lbl_hora.Text = If(_allday, "Qualquer hora", _hora.ToString("hh:mm"))
        txt_descricao.Text = _descricao
        AddHandler btn_checar.Click, AddressOf checkar
        panel.Location = New Point(6, _posicaoY)
        panel.Controls.Add(lbl_hora)
        panel.Controls.Add(txt_descricao)
        panel.Controls.Add(btn_checar)
        If _checado Then
            panel.BackColor = SystemColors.Control
        Else
            'panel.BackColor = Color.Azure
        End If
        _spanel.Controls.Add(panel)
    End Sub
    Private Sub checkar()
        Select Case frequencia
            Case 1
                sql = "evento_ativo = 0"
            Case 2
                sql = "evento_datahora = DATEADD(d,1,evento_datahora)"
            Case 3
                sql = "evento_datahora = DATEADD(w,1,evento_datahora)"
            Case 4
                sql = "evento_datahora = DATEADD(m,1,evento_datahora)"
            Case 5
                sql = "evento_datahora = DATEADD(y,1,evento_datahora)"
        End Select

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "update tb_evento set evento_ultimocheck = DATEADD(hh, 22, DATEDIFF(dd, 0, GETDATE()))," & sql & " where evento_id = " & id
            conexao.Open()
            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao checar evento: " & ex.Message, "Evento")
        Finally
            conexao.Close()
        End Try

    End Sub
End Class
