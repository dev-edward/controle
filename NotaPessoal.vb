Imports System.Data.SqlClient
Public Class NotaPessoal
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim fk As Integer
    Dim num As Integer
    Dim posicaoY As Integer
    Dim spanel As Panel
    Dim txt_novaNota As New TextBox
    Dim btn_addNota As New Button

    Friend Sub New()
        classesAbertas.setAtualNtPessoal(Me)
        spanel = Principal.splitconteiner.Panel2
        iniciar()

    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        classesAbertas.setAtualNtPessoal(Me)
        spanel = _spanel
        iniciar()

    End Sub

    Private Sub iniciar()
        fk = usuario.usuario_id

        'posição dos controles
        txt_novaNota.Location = New Point(10, 10)
        btn_addNota.Location = New Point(240, 10)

        'tamanho dos controles
        txt_novaNota.Size = New Size(240, 30)
        btn_addNota.Size = New Size(50, 30)

        'específicos
        btn_addNota.BackgroundImage = img.mais
        btn_addNota.BackgroundImageLayout = ImageLayout.Zoom
        btn_addNota.FlatStyle = FlatStyle.Popup

        AddHandler btn_addNota.Click, AddressOf addNota


        atualizarLista()

    End Sub

    Friend Sub atualizarLista()

        spanel.Controls.Clear()


        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select nt_id, nt_nota from tb_notapessoal where nt_fkuser = " & fk & " and (nt_excluido = 0 or nt_excluido is null)"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            num = 0
            posicaoY = 50
            If myReader.HasRows Then
                Do While myReader.Read()
                    num += 1
                    Dim id As Integer = myReader.GetInt32("nt_id")
                    Dim textoNota As String = myReader.GetString("nt_nota")
                    Dim notas As New Nota(spanel, id, textoNota, posicaoY, num, True)
                    posicaoY += 44
                Loop
            Else
                Dim label As New Label
                label.Text = "Este item ainda não possui notas"
                label.Location = New Point(0, 40)
                label.Size = New Size(280, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                spanel.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
        spanel.Controls.Add(txt_novaNota)
        spanel.Controls.Add(btn_addNota)
    End Sub
    Private Sub addNota()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "insert into tb_notapessoal(nt_fkuser,nt_nota) values(@fk,@nota)"
            consulta.Parameters.AddWithValue("@fk", fk)
            consulta.Parameters.AddWithValue("@nota", txt_novaNota.Text)

            conexao.Open()
            consulta.ExecuteNonQuery()
            txt_novaNota.Text = ""

        Catch ex As Exception
            MessageBox.Show("Erro adicionar nova nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        atualizarLista()
    End Sub
End Class
