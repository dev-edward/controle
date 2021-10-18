Imports System.Data.SqlClient
Public Class EventoLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim dtatual As DateTime
    Friend Sub New()
        spanel = Principal.splitconteiner_Dir.Panel1
        iniciar()
    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        spanel = _spanel
        iniciar()
    End Sub
    Private Sub iniciar()

    End Sub
    Private Sub atualizar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select getdate()"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            myReader.Read()

            dtatual = myReader.GetDateTime("")




        Catch ex As Exception
            MessageBox.Show("Erro ao obter telefones: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
    End Sub

End Class
