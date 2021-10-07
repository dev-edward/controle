Imports System.Data.SqlClient
Public Class TelefoneLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim conteiner As New Panel
    Dim posicaoY As Integer

    Dim id As Integer
    Dim numero As String
    Dim pessoa As String
    Dim local As String

    Friend Sub New()
        spanel = Principal.splitconteiner_Dir.Panel1
        iniciar()
    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        spanel = _spanel
        iniciar()
    End Sub
    Private Sub iniciar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select * from tb_telefone"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("telefone_id")
                    numero = myReader.GetString("telefone_numero")
                    pessoa = myReader.GetString("telefone_pessoa")
                    local = myReader.GetString("telefone_local")

                    posicaoY += 30

                    Dim telefone As New Telefone(spanel, id, numero, pessoa, local, posicaoY)

                Loop
            Else
                Dim label As New Label
                label.Text = "Sem telefones cadastrados"
                label.Location = New Point(0, 40)
                label.Size = New Size(260, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter telefones: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
        spanel.Controls.Add(conteiner)
    End Sub


End Class
