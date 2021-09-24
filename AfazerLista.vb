Imports System.Data.SqlClient
Public Class AfazerLista
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim conteiner As New Panel
    Dim controles As New Panel
    Dim btn_ordenar As New Button
    Dim btn_previsao As New Button
    Dim spanel As Panel

    Dim s_filtro As Boolean
    Dim s_previsao As Boolean
    Dim s_ordem As Boolean

    Dim slq_parte1 As String = "SELECT afazer_id, afazer_fkitem, afazer_titulo, afazer_temprevisao, afazer_previsao, afazer_status,COUNT(case when nota_excluido is null or nota_excluido = 0 then 1 else null end) as 'qtd_notas' FROM tb_afazer LEFT JOIN tb_notaitem ON  afazer_fkitem = nota_fkitem"
    Dim sql_parte2 As String = " group by  afazer_id, afazer_fkitem, afazer_titulo, afazer_temprevisao, afazer_previsao, afazer_status"
    Dim filtro_itens = ""
    Dim sql_filtro As String = " where afazer_status in(" & filtro_itens & ")"
    Dim sql_retornos As String = " OFFSET 0 ROWS FETCH NEXT 20 ROWS ONLY"
    Dim sql_previsao_crescente As String = " ORDER BY afazer_previsao asc" & sql_retornos
    Dim sql_previsao_decrescente As String = " ORDER BY afazer_previsao desc" & sql_retornos
    Dim sql_ordenar_crescente As String = " ORDER BY afazer_id asc" & sql_retornos
    Dim sql_ordenar_decrescente As String = " ORDER BY afazer_id desc" & sql_retornos

    Dim sql As String = slq_parte1 + sql_parte2 + sql_ordenar_decrescente

    Friend Sub New()
        spanel = Principal.splitconteiner.panel1
        iniciar()

    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        spanel = _spanel
        iniciar()

    End Sub
    Private Sub iniciar()
        Dim btn_adicionar As New Button
        Dim btn_atualizar As New Button
        Dim btn_filtro As New Button

        Dim panel_filtro As New Panel
        Dim cbx_status1 As New CheckBox
        Dim cbx_status2 As New CheckBox
        Dim cbx_status3 As New CheckBox
        Dim cbx_status4 As New CheckBox

        Dim btn_retorna As New Button
        Dim lbl_pagina As New Label
        Dim btn_avanca As New Button

        controles.Location = New Point(0, 0)
        controles.Size = New Size(280, 60)

        'conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 0)
        conteiner.Location = New Point(0, 60)
        conteiner.AutoSize = True

        btn_adicionar.BackgroundImage = img.mais
        btn_adicionar.BackgroundImageLayout = ImageLayout.Zoom
        btn_adicionar.Location = New Point(10, 10)
        btn_adicionar.Size = New Size(26, 26)
        btn_adicionar.FlatStyle = FlatStyle.Flat
        AddHandler btn_adicionar.Click, AddressOf novo

        btn_ordenar.BackgroundImage = img.sort1
        btn_ordenar.BackgroundImageLayout = ImageLayout.Zoom
        btn_ordenar.Location = New Point(40, 10)
        btn_ordenar.Size = New Size(26, 26)
        btn_ordenar.FlatStyle = FlatStyle.Flat
        AddHandler btn_ordenar.Click, AddressOf porData

        btn_previsao.BackgroundImage = img.previsao1
        btn_previsao.BackgroundImageLayout = ImageLayout.Zoom
        btn_previsao.Location = New Point(70, 10)
        btn_previsao.Size = New Size(26, 26)
        btn_previsao.FlatStyle = FlatStyle.Flat
        AddHandler btn_previsao.Click, AddressOf porPrevisao

        btn_filtro.BackgroundImage = img.filtro
        btn_filtro.BackgroundImageLayout = ImageLayout.Zoom
        btn_filtro.Location = New Point(100, 10)
        btn_filtro.Size = New Size(26, 26)
        btn_filtro.FlatStyle = FlatStyle.Flat
        AddHandler btn_filtro.Click, AddressOf filtrar

        btn_atualizar.BackgroundImage = img.refresh
        btn_atualizar.BackgroundImageLayout = ImageLayout.Zoom
        btn_atualizar.Location = New Point(250, 10)
        btn_atualizar.Size = New Size(26, 26)
        btn_atualizar.FlatStyle = FlatStyle.Flat
        AddHandler btn_atualizar.Click, AddressOf atualizarLista

        panel_filtro.Location = New Point(10, 36)
        panel_filtro.Size = New Size(260, 20)

        cbx_status1.Text = "Aguardando"
        cbx_status2.Text = "Em andamento"
        cbx_status3.Text = "Feito"
        cbx_status4.Text = "Descartado"

        cbx_status1.Location = New Point(0, 0)
        cbx_status2.Location = New Point(60, 0)
        cbx_status3.Location = New Point(120, 0)
        cbx_status4.Location = New Point(180, 0)

        cbx_status1.Size = New Size(60, 20)
        cbx_status2.Size = New Size(60, 20)
        cbx_status3.Size = New Size(60, 20)
        cbx_status4.Size = New Size(60, 20)

        cbx_status1.backgroundImge
        cbx_status2.backgroundImge
        cbx_status3.backgroundImge
        cbx_status4.backgroundImge

        panel_filtro.Controls.Add(cbx_status1)
        panel_filtro.Controls.Add(cbx_status2)
        panel_filtro.Controls.Add(cbx_status3)
        panel_filtro.Controls.Add(cbx_status4)

        controles.Controls.Add(btn_adicionar)
        controles.Controls.Add(btn_atualizar)
        controles.Controls.Add(btn_ordenar)
        controles.Controls.Add(btn_previsao)
        controles.Controls.Add(btn_filtro)
        controles.Controls.Add(panel_filtro)

        spanel.Controls.Add(controles)
        atualizarLista()

    End Sub
    Friend Sub atualizarLista()
        conteiner.Controls.Clear()
        For Each ctrl As Control In conteiner.Controls
            ctrl.Dispose()
        Next

        Dim pagina = 0

        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        consulta = conexao.CreateCommand
        consulta.CommandText = sql
        conexao.Open()
        myReader = consulta.ExecuteReader()

        Dim panelY As Integer
        panelY = 0

        Do While myReader.Read()
            Dim id As Integer
            Dim fkitem As Integer
            Dim titulo As String
            Dim temprevisao As Integer
            Dim previsao As DateTime
            Dim estado As String
            Dim qtdNotas As Integer
            Dim panel As New Panel()

            id = myReader.GetInt32(0)
            fkitem = myReader.GetInt32(1)
            titulo = If(myReader.IsDBNull(2), "", myReader.GetString(2))
            temprevisao = If(myReader.IsDBNull(3), 0, myReader.GetValue(3))
            previsao = If(myReader.IsDBNull(4), 0, myReader.GetValue(4))
            estado = If(myReader.IsDBNull(5), 0, myReader.GetValue(5))
            qtdNotas = If(myReader.IsDBNull(6), 0, myReader.GetInt32(6))

            Dim afazeres As New Afazer(Me, conteiner, id, fkitem, titulo, temprevisao, previsao, estado, qtdNotas, panelY)
            panelY += 56

        Loop

        'conteiner.BackColor = New Color().FromArgb(255, 0, 0, 150)
        spanel.Controls.Add(conteiner)

        myReader.Close()
        conexao.Close()
    End Sub
    Private Sub novo()
        If Application.OpenForms.OfType(Of AfazerDetalhes).Any() And formsAbertos.cadastroOUdetalhes = 1 Then
            Application.OpenForms.OfType(Of AfazerDetalhes).First().BringToFront()

        Else
            If Application.OpenForms.OfType(Of AfazerDetalhes).Any() And formsAbertos.cadastroOUdetalhes = 2 Then
                Application.OpenForms.OfType(Of AfazerDetalhes).First().Close()
            End If
            Dim verDetalhes = New AfazerDetalhes()
            verDetalhes.Show()
        End If

    End Sub
    Private Sub porData()
        If (s_ordem) Then
            sql = slq_parte1 + sql_parte2 + sql_ordenar_decrescente
            btn_ordenar.BackgroundImage = img.sort1
        Else
            sql = slq_parte1 + sql_parte2 + sql_ordenar_crescente
            btn_ordenar.BackgroundImage = img.sort2
        End If
        s_ordem = Not s_ordem
        atualizarLista()
    End Sub
    Private Sub porPrevisao()
        If (s_previsao) Then
            sql = slq_parte1 + sql_parte2 + sql_previsao_crescente
            btn_previsao.BackgroundImage = img.previsao2
        Else
            sql = slq_parte1 + sql_parte2 + sql_previsao_decrescente
            btn_previsao.BackgroundImage = img.previsao1
        End If
        s_previsao = Not s_previsao
        atualizarLista()
    End Sub
    Private Sub filtrar()
        If s_filtro Then

        Else

        End If
    End Sub

End Class
