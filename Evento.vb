Imports System.Data.SqlClient
Public Class Evento
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Dim id As Integer
    Dim frequencia As Integer
    Dim add As String
    Dim panel As New Panel With {
        .Size = New Size(270, 60),
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim btn_checar As New Button With {
        .BackgroundImage = img.certo,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup,
        .Size = New Size(26, 26),
        .Location = New Point(234, 17)
    }
    Dim lbl_hora As New Label With {
        .Location = New Point(10, 0),
        .Size = New Size(250, 18),
        .TextAlign = ContentAlignment.MiddleCenter,
        .ForeColor = Color.FromArgb(255, 15, 15, 15)
        '222, 175, 167)
    }
    Dim txt_descricao As New Label With {
        .Location = New Point(6, 18),
        .Size = New Size(220, 36),
        .BackColor = Color.FromArgb(100, 247, 247, 255)
    }
    Friend Sub New(ByRef _spanel As Panel, ByVal _id As Integer, ByVal _datahora As String, ByVal _descricao As String, ByVal _frequencia As Integer, ByVal _allday As Boolean, ByVal _proximo As Boolean, ByVal _checado As Boolean, ByVal _posicaoY As Integer)
        id = _id
        frequencia = _frequencia
        lbl_hora.Text = If(_allday, _datahora.Substring(0, 15), _datahora)
        txt_descricao.Text = _descricao

        If _proximo And Not _allday Then
            btn_checar.Enabled = False
        End If
        If Not _checado Then
            panel.Controls.Add(btn_checar)
        End If

        AddHandler btn_checar.Click, AddressOf checkar

        panel.Location = New Point(6, _posicaoY)
        panel.Controls.Add(lbl_hora)
        panel.Controls.Add(txt_descricao)

        _spanel.Controls.Add(panel)
    End Sub
    Private Sub checkar()
        Select Case frequencia
            Case 1
                add = "evento_ativo = 0"
            Case 2
                add = "evento_datahora = case 
	                    when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
	                    then DATEADD(d,1,evento_datahora)
	                    else evento_datahora
                    end"
            Case 3
                add = "evento_datahora = case 
	                    when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
	                    then DATEADD(w,1,evento_datahora)
	                    else evento_datahora
                    end"
            Case 4
                add = "evento_datahora = case 
	                    when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
	                    then DATEADD(m,1,evento_datahora)
	                    else evento_datahora
                    end"
            Case 5
                add = "evento_datahora = case 
	                    when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
	                    then DATEADD(y,1,evento_datahora)
	                    else evento_datahora
                    end"
        End Select

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_evento
                                SET
                                evento_ultimocheck = CASE
                                   WHEN DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE()))  or evento_ultimocheck is null
                                   THEN evento_datahora
                                   ELSE evento_ultimocheck
                                END, " & add & " where evento_id = " & id

            conexao.Open()
            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao checar evento: " & ex.Message, "Evento")
        Finally
            conexao.Close()
        End Try
        classesabertas.atualEventos.atualizar()
    End Sub
End Class
