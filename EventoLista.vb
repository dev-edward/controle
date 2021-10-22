Imports System.Data.SqlClient
Public Class EventoLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim dtatual As DateTime
    Dim posicaoY As Integer
    Dim id As Integer
    Dim hora As DateTime
    Dim descricao As String
    Dim checado As Boolean
    Dim allday As Boolean
    Dim frequencia As Integer
    Dim lbl_label As New Label With {
        .Text = "Telefones não encontrados",
        .Location = New Point(0, 40),
        .Size = New Size(280, 40),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Friend Sub New()
        classesAbertas.setAtualNtEventos(Me)
        spanel = Principal.splitconteiner_Dir.Panel2
        iniciar()
    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        classesAbertas.setAtualNtEventos(Me)
        spanel = _spanel
        iniciar()
    End Sub
    Private Sub iniciar()
        atualizar()
    End Sub
    Private Sub atualizar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select
                                evento_id,
                                evento_descricao,
                                evento_datahora,
                                evento_frequencia,
                                evento_allday,
                                case when evento_ultimocheck > evento_datahora then 1 else 0 end as 'checado'
                                from tb_evento
                                where evento_ativo = 1 and evento_datahora > CONVERT(date, GETDATE()) and evento_datahora < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))
                                order by 'checado'"
            conexao.Open()
            myReader = consulta.ExecuteReader()

            posicaoY = 10
            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("evento_id")
                    hora = If(myReader.IsDBNull("evento_datahora"), "", myReader.GetDateTime("evento_datahora"))
                    descricao = If(myReader.IsDBNull("evento_descricao"), "", myReader.GetString("evento_descricao"))
                    checado = If(myReader.GetValue("checado") = 0, False, True)
                    allday = If(myReader.GetValue("evento_allday") = 0, False, True)
                    frequencia = If(myReader.GetValue("evento_frequencia") = 2, False, True)
                    Dim evento As New Evento(spanel, id, hora, descricao, checado, frequencia, allday, posicaoY)
                    posicaoY += 44
                Loop

            Else
                spanel.Controls.Add(lbl_label)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao obter Eventos: " & ex.Message, "Lista de eventos")
        Finally
            conexao.Close()
        End Try
    End Sub

End Class
