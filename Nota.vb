Imports System.Data.SqlClient
Public Class Nota
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim parent As listarNotas
    Dim panel As New Panel
    Dim lbl_notaNum As New Label
    Dim txt_nota As New RichTextBox
    Dim btn_excluir As New Button

    Dim idNota As Integer
    Friend Sub New(ByRef _parent As listarNotas, ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _textoNota As String, ByVal _posicaoY As Integer, ByVal _num As Integer)

        idNota = _id

        'posição dos controles
        panel.Location = New Point(10, _posicaoY)
        lbl_notaNum.Location = New Point(0, 5)
        txt_nota.Location = New Point(25, 0)
        btn_excluir.Location = New Point(230, 0)

        'tamanho dos controles
        panel.Size = New Size(280, 40)
        lbl_notaNum.Size = New Size(20, 30)
        txt_nota.Size = New Size(200, 40)
        btn_excluir.Size = New Size(50, 40)

        'especuficos
        lbl_notaNum.ForeColor = Color.FromArgb(255, 15, 15, 15)
        lbl_notaNum.TextAlign = ContentAlignment.MiddleCenter
        lbl_notaNum.Font = New Font("Impact", 11)
        lbl_notaNum.Text = _num
        txt_nota.Multiline = True
        txt_nota.ReadOnly = True
        txt_nota.Text = _textoNota
        btn_excluir.BackgroundImage = img.xis
        btn_excluir.BackgroundImageLayout = ImageLayout.Zoom
        btn_excluir.FlatStyle = FlatStyle.Popup
        txt_nota.BackColor = Color.FromArgb(255, 230, 230, 240)

        AddHandler btn_excluir.Click, AddressOf excluir

        panel.Controls.Add(lbl_notaNum)
        panel.Controls.Add(txt_nota)
        panel.Controls.Add(btn_excluir)
        _conteiner.Controls.Add(panel)

        parent = _parent

    End Sub

    Friend Sub excluir()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "update tb_notaitem set nota_excluido = 1 where nota_id = " & idNota
            conexao.Open()
            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao excluir nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        parent.atualizarLista()

    End Sub

End Class
