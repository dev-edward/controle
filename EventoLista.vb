Imports System.Data.SqlClient
Public Class EventoLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim dtatual As DateTime
    Dim posicaoY As Integer
    Dim id As Integer
    Dim lbl_label As New Label With {
        .Text = "Telefones não encontrados",
        .Location = New Point(0, 40),
        .Size = New Size(280, 40),
        .TextAlign = ContentAlignment.MiddleCenter
    }
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
            dtatual = myReader.GetDateTime(0)
            myReader.Close()
            consulta.CommandText = "select getdate()"
            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                Do While myReader.Read()
                    id = 1

                    'Dim evento As New Evento()

                Loop
            Else
                spanel.Controls.Add(lbl_label)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao obter telefones: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
    End Sub

End Class
