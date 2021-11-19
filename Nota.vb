Imports System.Data.SqlClient
Public Class Nota
    Private conexao As SqlConnection
    Private consulta As SqlCommand

    Dim anotacao As New Boolean
    Dim idNota As Integer
    Dim panel As New Panel With {
        .Size = New Size(260, 40)
    }
    Dim lbl_notaNum As New Label With {
        .Location = New Point(0, 5),
        .Size = New Size(20, 30),
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 11)
    }
    Dim txt_nota As New RichTextBox With {
        .Location = New Point(25, 0),
        .Size = New Size(200, 40),
        .Multiline = True,
        .ReadOnly = True,
        .BackColor = Color.FromArgb(255, 240, 240, 250)
    }
    Dim btn_excluir As New Button With {
        .Location = New Point(230, 7),
        .Size = New Size(26, 26),
        .BackgroundImage = img.xis,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup
    }


    Friend Sub New(ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _textoNota As String, ByVal _posicaoY As Integer, ByVal _num As Integer, Optional ByVal _anotacao As Boolean = False)

        idNota = _id
        lbl_notaNum.Text = _num
        txt_nota.Text = _textoNota
        anotacao = _anotacao
        panel.Location = New Point(10, _posicaoY)

        AddHandler btn_excluir.Click, AddressOf excluir

        panel.Controls.Add(lbl_notaNum)
        panel.Controls.Add(txt_nota)
        panel.Controls.Add(btn_excluir)
        _conteiner.Controls.Add(panel)

    End Sub

    Friend Sub excluir()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "update tb_anotacao set nota_excluido = 1 where nota_id = " & idNota
            conexao.Open()
            consulta.ExecuteNonQuery()

            If anotacao Then
                classesAbertas.atualntpessoal.atualizarLista()
            Else
                classesAbertas.atualnotas.atualizarLista()
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao excluir nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
    End Sub

End Class
