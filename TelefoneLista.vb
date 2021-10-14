Imports System.Data.SqlClient
Public Class TelefoneLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim WithEvents txt_filtro As New TextBox With {
        .Width = 250,
        .Location = New Point(15, 6),
        .PlaceholderText = "Procurar..."
    }
    Dim conteiner As New Panel With {
        .Location = New Point(0, 40),
        .AutoSize = True,
        .Size = New Point(280, 60)
    }
    Dim posicaoY As Integer

    Dim id As Integer
    Dim numero As String
    Dim pessoa As String
    Dim local As String
    Dim label As New Label With {
        .Text = "Telefones não encontrados",
        .Location = New Point(0, 40),
        .Size = New Size(280, 40),
        .TextAlign = ContentAlignment.MiddleCenter
    }


    Dim sql As String = "select * from tb_telefone"

    Friend Sub New()
        spanel = Principal.splitconteiner_Dir.Panel1
        iniciar()
    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        spanel = _spanel
        iniciar()
    End Sub
    Private Sub iniciar()
        spanel.Controls.Add(txt_filtro)
        spanel.Controls.Add(conteiner)
        atualizar()
    End Sub
    Private Sub atualizar()
        conteiner.Controls.Clear()
        For Each ctrl As Control In conteiner.Controls
            ctrl.Dispose()
        Next
        posicaoY = 0
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = sql
            conexao.Open()

            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("telefone_id")
                    numero = myReader.GetString("telefone_numero")
                    pessoa = myReader.GetString("telefone_pessoa")
                    local = myReader.GetString("telefone_local")

                    Dim telefone As New Telefone(conteiner, id, numero, pessoa, local, posicaoY)

                    posicaoY += 38
                Loop
            Else
                conteiner.Controls.Add(label)
            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter telefones: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
        conteiner.Width = 260
    End Sub
    Private Sub txt_filtro_TextChanged(sender As Object, e As EventArgs) Handles txt_filtro.TextChanged
        sql = "select * from tb_telefone where telefone_numero like '" & txt_filtro.Text & "%' or telefone_pessoa like '%" & txt_filtro.Text & "%' or telefone_local like '%" & txt_filtro.Text & "%'"
        atualizar()
    End Sub

End Class
