Imports System.Data.SqlClient
Public Class AfazerLista
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim conteiner As New Panel
    Dim controles As New Panel
    Dim spanel As Panel

    Dim slq_parte1 As String = "SELECT afazer_id, afazer_fkitem, afazer_titulo, afazer_temprevisao, afazer_previsao, afazer_status,COUNT(nota_fkitem) as 'qtd_notas' FROM tb_afazer LEFT JOIN tb_notaitem ON  afazer_fkitem = nota_fkitem"
    Dim sql_parte2 As String = "group by  afazer_id, afazer_fkitem, afazer_titulo, afazer_temprevisao, afazer_previsao, afazer_status"

    Dim filtro_items = ""
    Dim sql_filtro As String = "where afazer_status in(" & filtro_items & ")"
    Dim sql_previsao_crescente As String = "ORDER BY afazer_previsao asc"
    Dim sql_previsao_decrescente As String = "ORDER BY afazer_previsao desc"
    Dim sql_ordenar_crescente As String = "ORDER BY afazer_id asc"
    Dim sql_ordenar_decrescente As String = "ORDER BY afazer_id desc"

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
        Dim btn_ordenar As New Button
        Dim btn_filtro As New Button


        Dim cbx_filtro As New ComboBox

        Dim btn_retorna As New Button
        Dim lbl_pagina As New Label
        Dim btn_avanca As New Button

        controles.Location = New Point(0, 0)
        controles.Size = New Size(280, 40)

        'conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 0)
        conteiner.Location = New Point(0, 50)
        conteiner.AutoSize = True

        btn_adicionar.BackgroundImage = img.mais
        btn_adicionar.BackgroundImageLayout = ImageLayout.Zoom
        btn_adicionar.Location = New Point(10, 10)
        btn_adicionar.Size = New Size(26, 26)
        btn_adicionar.FlatStyle = FlatStyle.Flat
        AddHandler btn_adicionar.Click, AddressOf novo

        btn_atualizar.BackgroundImage = img.refresh
        btn_atualizar.BackgroundImageLayout = ImageLayout.Zoom
        btn_atualizar.Location = New Point(250, 10)
        btn_atualizar.Size = New Size(26, 26)
        btn_atualizar.FlatStyle = FlatStyle.Flat
        AddHandler btn_atualizar.Click, AddressOf atualizarLista

        btn_ordenar.BackgroundImage = img.sort
        btn_ordenar.BackgroundImageLayout = ImageLayout.Zoom
        btn_ordenar.Location = New Point(220, 10)
        btn_ordenar.Size = New Size(26, 26)
        btn_ordenar.FlatStyle = FlatStyle.Flat
        AddHandler btn_ordenar.Click, AddressOf ordenar


        controles.Controls.Add(btn_adicionar)
        controles.Controls.Add(btn_atualizar)

        spanel.Controls.Add(controles)
        atualizarLista()

    End Sub
    Friend Sub atualizarLista()
        conteiner.Controls.Clear()
        For Each ctrl As Control In conteiner.Controls
            ctrl.Dispose()
        Next

        Dim pagina = 0

        Dim sql = "select afazer_id, afazer_fkitem, afazer_titulo, afazer_temprevisao, afazer_previsao, afazer_status from tb_afazer "
        Dim ordem_recentes = "ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
        Dim ordem_previsao = "ORDER BY afazer_previsao asc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"

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
            Dim panel As New Panel()

            id = myReader.GetInt32(0)
            fkitem = myReader.GetInt32(1)
            titulo = If(myReader.IsDBNull(2), "", myReader.GetString(2))
            temprevisao = If(myReader.IsDBNull(3), 0, myReader.GetValue(3))
            previsao = If(myReader.IsDBNull(4), 0, myReader.GetValue(4))
            estado = If(myReader.IsDBNull(5), 0, myReader.GetValue(5))

            Dim afazeres As New Afazer(Me, conteiner, id, fkitem, titulo, temprevisao, previsao, estado, panelY)
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
    Private Sub ordenar()

    End Sub

End Class
