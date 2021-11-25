Imports System.Data.SqlClient
Public Class EventoLista
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim spanel As Panel
    Dim posicaoY As Integer
    Dim id As Integer
    Dim datahora As String
    Dim descricao As String
    Dim frequencia As Integer
    Dim allday As Boolean
    Dim checado As Boolean
    Dim proximo As Boolean
    Dim lbl_label As New Label With {
        .Text = "Nenhum evento encontrado",
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
    Friend Sub atualizar()
        spanel.Controls.Clear()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select
                                evento_id
                                ,evento_descricao
                                ,SUBSTRING(DATENAME(dw, evento_datahora), 0,4) + ', ' + format(evento_datahora,'dd/MM/yyyy HH:mm','pt-br') as 'evento_datahora'
                                ,evento_ultimocheck
                                ,evento_frequencia
                                ,evento_allday
                                ,case when evento_datahora >= getdate() then 1 else 0 end as 'proximo'
                                ,case when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) = DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) then 1 else 0 end as 'checado'
                                from tb_evento
                                where
                                evento_ativo = 1
                                and 
                                (
                                DATEADD(dd, 0, DATEDIFF(dd,0,evento_datahora)) <= DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE()))
                                or
                                DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) = DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE()))
                                )
                                order by 'checado'"

            conexao.Open()
            myReader = consulta.ExecuteReader()

            posicaoY = 10
            If myReader.HasRows Then
                Do While myReader.Read()
                    id = myReader.GetInt32("evento_id")
                    datahora = If(myReader.IsDBNull("evento_datahora"), "", myReader.GetString("evento_datahora"))
                    descricao = If(myReader.IsDBNull("evento_descricao"), "", myReader.GetString("evento_descricao"))
                    frequencia = If(myReader.IsDBNull("evento_frequencia"), 2, myReader.GetValue("evento_frequencia"))
                    allday = If(myReader.GetValue("evento_allday") = 0, False, True)
                    proximo = If(myReader.GetValue("proximo") = 0, False, True)
                    checado = If(myReader.GetValue("checado") = 0, False, True)
                    Dim evento As New Evento(spanel, id, datahora, descricao, frequencia, allday, proximo, checado, posicaoY)
                    posicaoY += 64
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
