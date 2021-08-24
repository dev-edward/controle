Imports System.Data.SqlClient

Public Class listaAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Class Afazer
        Dim id As Integer
        Dim fk As Integer
        Dim panel As New Panel()
        Dim txt_titulo As New TextBox()
        Dim btn_vermais As New Button()
        Dim btn_notas As New Button()
        Dim btn_estado As New Button()

        'fonte padrão
        Dim fonte As New Font("Microsoft Sans Serif", 12)
        Dim cor_botao = New Color().FromArgb(255, 77, 80, 87)

        Friend Sub New(ByVal _conteiner As Panel, ByVal _id As Integer, ByVal _fkitem As Integer, ByVal _titulo As String, ByVal _prazo As DateTime, ByVal _estado As Integer, ByVal _panelY As Integer)
            'adicionando controles no panel
            panel.Controls.Add(txt_titulo)
            panel.Controls.Add(btn_vermais)
            panel.Controls.Add(btn_notas)
            panel.Controls.Add(btn_estado)

            'colocando fonte 12 para todos os itens
            txt_titulo.Font = fonte

            'conteudo dos controles extraido do BD
            id = _id
            fk = _fkitem
            txt_titulo.Text = _titulo

            'tamanho dos controles
            panel.Size = New Size(280, 60)
            txt_titulo.Size = New Size(274, 26)
            btn_vermais.Size = New Size(60, 30)
            btn_notas.Size = New Size(60, 30)
            btn_estado.Size = New Size(60, 30)

            'posição dos controles
            panel.Location = New Point(0, _panelY)
            txt_titulo.Location = New Point(4, 0)
            btn_vermais.Location = New Point(25, 26)
            btn_notas.Location = New Point(115, 26)
            btn_estado.Location = New Point(205, 26)

            'configurações especificas
            'panel.BorderStyle = BorderStyle.FixedSingle
            txt_titulo.ReadOnly = True
            btn_vermais.BackColor = cor_botao
            btn_notas.BackColor = cor_botao
            btn_estado.BackColor = cor_botao

            'vinculando funções aos botões
            AddHandler btn_vermais.Click, AddressOf btn_vermais_Click
            AddHandler btn_notas.Click, AddressOf btn_notas_Click
            AddHandler btn_estado.Click, AddressOf btn_estado_Click

            _conteiner.Controls.Add(panel)

        End Sub
        Private Sub btn_vermais_Click()

        End Sub
        Private Sub btn_notas_Click()

        End Sub
        Private Sub btn_estado_Click()

        End Sub
    End Class

    Friend Sub New(ByVal _spanel As Panel)

        Dim btn_adicionar As New Button
        Dim cbx_filtro As New ComboBox
        Dim btn_retorna As New Button
        Dim lbl_pagina As New Label
        Dim btn_avanca As New Button


        buscaTarefa(_spanel)

    End Sub
    Private Sub buscaTarefa(_spanel As Panel)

        Dim conteiner As New Panel
        Dim pagina = 0
        Dim sql = "select afazer_id, afazer_fkitem, afazer_titulo, afazer_prazo, afazer_status from tb_afazer "
        Dim ordem_recentes = "ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"
        Dim ordem_prazo = "ORDER BY afazer_prazo asc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"

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
            Dim prazo As DateTime
            Dim estado As String
            Dim panel As New Panel()

            id = myReader.GetInt32(0)
            fkitem = myReader.GetInt32(1)
            titulo = myReader.GetString(2)
            prazo = myReader.GetDateTime(3)
            estado = myReader.GetByte(4)

            Dim afazeres As New Afazer(conteiner, id, fkitem, titulo, prazo, estado, panelY)
            panelY += 60
        Loop
        'conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 0)
        conteiner.Location = New Point(0, 2)
        conteiner.AutoSize = True
        'conteiner.BackColor = New Color().FromArgb(255, 0, 0, 150)
        _spanel.Controls.Add(conteiner)

        myReader.Close()
        conexao.Close()
    End Sub
End Class
