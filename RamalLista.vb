Imports System.Data.SqlClient
Public Class RamalLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel

    Friend Sub New()
        spanel = Principal.splitconteiner_Dir.Panel1
        iniciar()
    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        spanel = _spanel
        iniciar()
    End Sub
    Private Sub iniciar()
        'Try
        '    conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        '    consulta = conexao.CreateCommand
        '    consulta.CommandText = "select ROW_NUMBER() OVER(ORDER BY nt_id  asc) AS indice, nt_id, nt_nota from tb_notapessoal where nt_fkuser = " & fk & " and (nt_excluido = 0 or nt_excluido is null) order by nt_id  desc"
        '    conexao.Open()

        '    myReader = consulta.ExecuteReader()

        '    If myReader.HasRows Then
        '        Do While myReader.Read()


        '            posicaoY += 44
        '        Loop
        '    Else
        '        Dim label As New Label
        '        label.Text = "Sem anotações por aqui"
        '        label.Location = New Point(0, 40)
        '        label.Size = New Size(260, 40)
        '        label.TextAlign = ContentAlignment.MiddleCenter
        '        conteiner.Controls.Add(label)

        '    End If
        'Catch ex As Exception
        '    MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        'Finally
        '    conexao.Close()
        'End Try
    End Sub
End Class
