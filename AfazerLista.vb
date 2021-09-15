Imports System.Data.SqlClient

Public Class AfazerLista
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim conteiner As New Panel
    Dim spanel As Panel
    Dim Vbarra

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
        Dim cbx_filtro As New ComboBox
        Dim btn_retorna As New Button
        Dim lbl_pagina As New Label
        Dim btn_avanca As New Button

        'conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 0)
        conteiner.Location = New Point(0, 2)
        conteiner.AutoSize = True

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
        panelY = 60

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


End Class
