Imports System.Data.SqlClient
Public Class NotaPessoal
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim pkitem As Integer
    Dim id As Integer
    Dim textoNota As String
    Dim num As Integer
    Dim posicaoY As Integer
    Dim spanel As Panel
    Dim txt_novaNota As New RichTextBox
    Dim btn_addNota As New Button
    Dim conteiner As New Panel
    Dim label As New Label With {
        .Text = "Sem anotações por aqui",
        .Location = New Point(0, 40),
        .Size = New Size(260, 40),
        .TextAlign = ContentAlignment.MiddleCenter
    }


    Friend Sub New()
        classesAbertas.setAtualNtPessoal(Me)
        spanel = Principal.splitconteiner_Esq.Panel2
        iniciar()

    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        classesAbertas.setAtualNtPessoal(Me)
        spanel = _spanel
        iniciar()

    End Sub

    Private Sub iniciar()
        pkitem = usuario.usuario_id

        'posição dos controles
        conteiner.Location = New Point(0, 60)
        txt_novaNota.Location = New Point(35, 10)
        btn_addNota.Location = New Point(240, 17)

        'tamanho dos controles
        conteiner.Size = New Point(250, 60)
        txt_novaNota.Size = New Size(200, 40)
        btn_addNota.Size = New Size(26, 26)

        'específicos
        conteiner.AutoSize = True
        btn_addNota.BackgroundImage = img.mais
        btn_addNota.BackgroundImageLayout = ImageLayout.Zoom
        btn_addNota.FlatStyle = FlatStyle.Popup

        AddHandler btn_addNota.Click, AddressOf addNota

        spanel.Controls.Add(conteiner)
        spanel.Controls.Add(txt_novaNota)
        spanel.Controls.Add(btn_addNota)
        atualizarLista()

    End Sub

    Friend Sub atualizarLista()

        conteiner.Controls.Clear()

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            'consulta.CommandText = "select ROW_NUMBER() OVER(ORDER BY nt_id  asc) AS indice, nt_id, nt_nota from tb_notapessoal where nt_fkuser = " & fk & " and (nt_excluido = 0 or nt_excluido is null) order by nt_id  desc"
            consulta.CommandText = "select ROW_NUMBER() OVER(ORDER BY nota_id  asc) AS indice, nota_id, nota_nota from tb_anotacao where nota_pkitem = " & pkitem & " and nota_tabela = 'usuario' and nota_excluido is null  order by nota_id desc"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            num = 0
            posicaoY = 0
            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("nota_id")
                    textoNota = myReader.GetString("nota_nota")
                    num = myReader.GetValue("indice")
                    Dim notas As New Nota(conteiner, id, textoNota, posicaoY, num, True)
                    posicaoY += 44
                Loop
            Else

                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub addNota()
        If txt_novaNota.Text <> "" Then
            Try
                conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
                consulta = conexao.CreateCommand
                consulta.CommandText = "insert into tb_anotacao(nota_pkitem,nota_tabela,nota_nota) values(@fk,@tabela,@nota)"
                consulta.Parameters.AddWithValue("@fk", pkitem)
                consulta.Parameters.AddWithValue("@tabela", "usuario")
                consulta.Parameters.AddWithValue("@nota", txt_novaNota.Text)

                conexao.Open()
                consulta.ExecuteNonQuery()
                txt_novaNota.Text = ""

            Catch ex As Exception
                MessageBox.Show("Erro adicionar nova anotação: " & ex.Message, "Insert Records")
            Finally
                conexao.Close()
            End Try

            atualizarLista()
        End If
    End Sub
End Class
