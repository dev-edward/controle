Imports System.Data.SqlClient
Public Class DemandaLista
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Friend conteiner As New Panel
    Dim controles As New Panel
    Dim btn_ordenar As New Button
    Dim btn_previsao As New Button
    Dim spanel As Panel

    Dim s_filtro As Boolean
    Dim s_previsao As Boolean
    Dim s_ordem As Boolean

    Dim panel_filtro As New Panel
    Dim cbx_status1 As New CheckBox
    Dim cbx_status2 As New CheckBox
    Dim cbx_status3 As New CheckBox
    Dim cbx_status4 As New CheckBox

    Dim slq_select As String = "SELECT demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status,demanda_encarregado,demanda_prioridade,sum(case when nota_pkitem = demanda_id and nota_tabela = 'demanda' and nota_excluido is null then 1 else 0 end) as 'qtd_notas' FROM tb_demanda LEFT JOIN tb_anotacao ON  demanda_id = nota_pkitem and nota_tabela = 'demanda'"
    Dim sql_groupby As String = " group by  demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status,demanda_encarregado,demanda_prioridade"

    Dim filtro_itens = "0,1,2,3,4"
    Dim sql_filtro As String = " where demanda_status in(" & filtro_itens & ")"
    Dim sql_retornos As String = " OFFSET 0 ROWS FETCH NEXT 20 ROWS ONLY"
    Dim sql_previsao_crescente As String = " ORDER BY demanda_previsao asc" & sql_retornos
    Dim sql_previsao_decrescente As String = " ORDER BY demanda_previsao desc" & sql_retornos
    Dim sql_ordenar_crescente As String = " ORDER BY demanda_id asc" & sql_retornos
    Dim sql_ordenar_decrescente As String = " ORDER BY demanda_id desc" & sql_retornos


    Dim sql_ordem As String = sql_ordenar_decrescente
    Dim sql As String

    Friend Sub New()
        classesAbertas.setAtualListaDemandas(Me)
        spanel = Principal.splitconteiner_Esq.Panel1
        iniciar()

    End Sub
    Friend Sub New(ByRef _spanel As Panel)
        classesAbertas.setAtualListaDemandas(Me)
        spanel = _spanel
        iniciar()

    End Sub
    Private Sub iniciar()
        Dim btn_adicionar As New Button
        Dim btn_atualizar As New Button
        Dim btn_filtro As New Button
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

        panel_filtro.Location = New Point(40, 34)
        panel_filtro.Size = New Size(200, 20)
        panel_filtro.Visible = False

        cbx_status1.Location = New Point(0, 0)
        cbx_status2.Location = New Point(50, 0)
        cbx_status3.Location = New Point(100, 0)
        cbx_status4.Location = New Point(150, 0)

        cbx_status1.Size = New Size(50, 20)
        cbx_status2.Size = New Size(50, 20)
        cbx_status3.Size = New Size(50, 20)
        cbx_status4.Size = New Size(50, 20)

        cbx_status1.Checked = True
        cbx_status2.Checked = True
        cbx_status3.Checked = True
        cbx_status4.Checked = True

        cbx_status1.BackgroundImage = img.aguardando
        cbx_status2.BackgroundImage = img.andamento
        cbx_status3.BackgroundImage = img.feito
        cbx_status4.BackgroundImage = img.descartado
        cbx_status1.BackgroundImageLayout = ImageLayout.Zoom
        cbx_status2.BackgroundImageLayout = ImageLayout.Zoom
        cbx_status3.BackgroundImageLayout = ImageLayout.Zoom
        cbx_status4.BackgroundImageLayout = ImageLayout.Zoom

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
        spanel.Controls.Add(conteiner)
        atualizarLista()

    End Sub
    Friend Sub atualizarLista()
        sql = slq_select + sql_filtro + sql_groupby + sql_ordem
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
            Dim titulo As String
            Dim temprevisao As Integer
            Dim previsao As DateTime
            Dim estado As String
            Dim qtdNotas As Integer
            Dim encarregado As Integer
            Dim prioridade As Integer
            Dim panel As New Panel

            'id = myReader.GetInt32(0)
            'titulo = If(myReader.IsDBNull(1), "", myReader.GetString(1))
            'temprevisao = If(myReader.IsDBNull(2), 0, myReader.GetValue(2))
            'previsao = If(myReader.IsDBNull(3), 0, myReader.GetValue(3))
            'estado = If(myReader.IsDBNull(4), 0, myReader.GetValue(4))
            'qtdNotas = If(myReader.IsDBNull(5), 0, myReader.GetInt32(5))

            id = myReader.GetInt32("demanda_id")
            titulo = If(myReader.IsDBNull("demanda_titulo"), "", myReader.GetString("demanda_titulo"))
            temprevisao = If(myReader.IsDBNull("demanda_temprevisao"), 0, myReader.GetValue("demanda_temprevisao"))
            previsao = If(myReader.IsDBNull("demanda_previsao"), Nothing, myReader.GetValue("demanda_previsao"))
            estado = If(myReader.IsDBNull("demanda_status"), 0, myReader.GetValue("demanda_status"))
            qtdNotas = If(myReader.IsDBNull("qtd_notas"), 0, myReader.GetInt32("qtd_notas"))
            encarregado = If(myReader.IsDBNull("demanda_encarregado"), 0, myReader.GetValue("demanda_encarregado"))
            prioridade = If(myReader.IsDBNull("demanda_prioridade"), 0, myReader.GetValue("demanda_prioridade"))

            Dim demandas As New Demanda(Me, id, titulo, temprevisao, previsao, estado, qtdNotas, panelY)
            panelY += 56

        Loop

        'conteiner.BackColor = New Color().FromArgb(255, 0, 0, 150)


        myReader.Close()
        conexao.Close()
        conteiner.Width = 260
    End Sub
    Private Sub novo()
        If Application.OpenForms.OfType(Of DemandaDetalhes).Any() Then
            Application.OpenForms.OfType(Of DemandaDetalhes).First().Close()
        End If
        Dim verDetalhes = New DemandaDetalhes()
        verDetalhes.Show()

    End Sub
    Private Sub porData()
        If (s_ordem) Then
            sql_ordem = sql_ordenar_decrescente
            btn_ordenar.BackgroundImage = img.sort1
        Else
            sql_ordem = sql_ordenar_crescente
            btn_ordenar.BackgroundImage = img.sort2
        End If
        s_ordem = Not s_ordem
        atualizarLista()
    End Sub
    Private Sub porPrevisao()
        If (s_previsao) Then
            sql_ordem = sql_previsao_crescente
            btn_previsao.BackgroundImage = img.previsao2
        Else
            sql_ordem = sql_previsao_decrescente
            btn_previsao.BackgroundImage = img.previsao1
        End If
        s_previsao = Not s_previsao
        atualizarLista()
    End Sub
    Private Sub filtrar()
        If s_filtro Then
            filtro_itens = "0"
            filtro_itens = If(cbx_status1.Checked, filtro_itens + ",1", filtro_itens)
            filtro_itens = If(cbx_status2.Checked, filtro_itens + ",2", filtro_itens)
            filtro_itens = If(cbx_status3.Checked, filtro_itens + ",3", filtro_itens)
            filtro_itens = If(cbx_status4.Checked, filtro_itens + ",4", filtro_itens)

            sql_filtro = " where demanda_status in(" & filtro_itens & ")"
            panel_filtro.Visible = False

            atualizarLista()
        Else
            panel_filtro.Visible = True
        End If
        s_filtro = Not s_filtro

    End Sub

    Friend Sub MoverPanels()
        For Each pnl As Control In conteiner.Controls
            pnl.Top += 56
        Next
    End Sub

End Class
