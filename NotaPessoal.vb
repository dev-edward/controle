﻿Imports System.Data.SqlClient
Public Class NotaPessoal
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim fk As Integer
    Dim id As Integer
    Dim textoNota As String
    Dim num As Integer
    Dim posicaoY As Integer
    Dim spanel As Panel
    Dim txt_novaNota As New RichTextBox
    Dim btn_addNota As New Button
    Dim conteiner As New Panel

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
        fk = usuario.usuario_id

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
            consulta.CommandText = "select ROW_NUMBER() OVER(ORDER BY nt_id  asc) AS indice, nt_id, nt_nota from tb_notapessoal where nt_fkuser = " & fk & " and (nt_excluido = 0 or nt_excluido is null) order by nt_id  desc"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            num = 0
            posicaoY = 0
            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("nt_id")
                    textoNota = myReader.GetString("nt_nota")
                    num = myReader.GetValue("indice")
                    Dim notas As New Nota(conteiner, id, textoNota, posicaoY, num, True)
                    posicaoY += 44
                Loop
            Else
                Dim label As New Label
                label.Text = "Sem anotações por aqui"
                label.Location = New Point(0, 40)
                label.Size = New Size(260, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

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