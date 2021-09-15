Imports System.Data.SqlClient

Public Class AfazerLista
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim conteiner As New Panel
    Dim spanel As Panel
    Dim Vbarra

<<<<<<< HEAD
    Class Afazer
        Dim pk As Integer
        Dim fk As Integer
        Dim lista As AfazerLista
        Dim panel As New Panel()
        Dim estado As New Integer()
        Dim txt_titulo As New TextBox()
        Dim lbl_previsao As New Label()
        Dim btn_vermais As New Button()
        Dim btn_notas As New Button()
        Dim btn_estado As New Button()

        'fonte padrão
        Dim fonte As New Font("Microsoft Sans Serif", 12)
        Dim cor_botao = Color.FromArgb(255, 26, 147, 111)

        Friend Sub New(ByRef _lista As AfazerLista, ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _fkitem As Integer, ByVal _titulo As String, ByVal _temprevisao As Integer, ByVal _previsao As DateTime, ByVal _estado As Integer, ByVal _panelY As Integer)

            lista = _lista

            'adicionando controles no panel
            panel.Controls.Add(txt_titulo)
            panel.Controls.Add(lbl_previsao)
            panel.Controls.Add(btn_vermais)
            panel.Controls.Add(btn_notas)
            panel.Controls.Add(btn_estado)

            'colocando fonte 12 para todos os itens
            txt_titulo.Font = fonte

            'conteudo dos controles extraido do BD
            pk = _id
            fk = _fkitem
            estado = _estado
            txt_titulo.Text = _titulo
            lbl_previsao.Text = If(_temprevisao > 0, _previsao, "Indeterminado")

            'tamanho dos controles
            panel.Size = New Size(280, 54)
            txt_titulo.Size = New Size(274, 26)
            lbl_previsao.Size = New Size(98, 26)
            btn_vermais.Size = New Size(56, 26)
            btn_notas.Size = New Size(56, 26)
            btn_estado.Size = New Size(56, 26)

            'posição dos controles
            panel.Location = New Point(0, _panelY)
            txt_titulo.Location = New Point(4, 0)
            lbl_previsao.Location = New Point(4, 27)
            btn_vermais.Location = New Point(98, 27)
            btn_notas.Location = New Point(158, 27)
            btn_estado.Location = New Point(218, 27)

            'configurações especificas
            'panel.BorderStyle = BorderStyle.FixedSingle
            txt_titulo.ReadOnly = True
            lbl_previsao.TextAlign = ContentAlignment.MiddleCenter
            btn_vermais.BackColor = cor_botao
            btn_notas.BackColor = cor_botao
            btn_estado.BackColor = cor_botao
            btn_notas.Text = pk
            btn_notas.ForeColor = Color.FromArgb(255, 255, 255, 255)
            btn_notas.TextAlign = ContentAlignment.TopRight
            btn_notas.Font = New Font("Impact", 10)
            btn_vermais.BackgroundImage = img.vermais
            btn_vermais.BackgroundImageLayout = ImageLayout.Zoom
            btn_notas.BackgroundImage = img.notas
            btn_notas.BackgroundImageLayout = ImageLayout.Zoom
            Select Case _estado
                Case 1
                    btn_estado.BackgroundImage = img.aguardando
                Case 2
                    btn_estado.BackgroundImage = img.andamento
                Case 3
                    btn_estado.BackgroundImage = img.feito
                Case 4
                    btn_estado.BackgroundImage = img.descartado
            End Select
            btn_estado.BackgroundImageLayout = ImageLayout.Zoom

            btn_vermais.FlatStyle = FlatStyle.Popup
            btn_notas.FlatStyle = FlatStyle.Popup
            btn_estado.FlatStyle = FlatStyle.Popup

            'vinculando funções aos botões
            AddHandler btn_vermais.Click, AddressOf btn_vermais_Click
            AddHandler btn_notas.Click, AddressOf btn_notas_Click
            AddHandler btn_estado.Click, AddressOf btn_estado_Click

            _conteiner.Controls.Add(panel)

        End Sub
        Private Sub btn_vermais_Click()
            'Dim verDetalhes = New DetalhesAfazer(id)
            'verDetalhes.Show()

            If Application.OpenForms.OfType(Of DetalhesAfazer).Any() Then
                Application.OpenForms.OfType(Of DetalhesAfazer).First().Close()
            End If
            Dim verDetalhes = New DetalhesAfazer(pk)
            verDetalhes.ShowIcon = False
            verDetalhes.Show()

        End Sub
        Private Sub btn_notas_Click()
            Dim notas = New listarNotas(fk)
            notas.Show()
        End Sub
        Private Sub btn_estado_Click()
            Dim status As New estadoAfazer(lista, btn_estado, pk, estado)
            status.ShowDialog()
        End Sub
    End Class

=======
>>>>>>> 31d9d10526f9f248f1aa1ca772d026aecff88a22
    Friend Sub New(ByRef _spanel As Panel)

        Dim btn_adicionar As New Button
        Dim cbx_filtro As New ComboBox
        Dim btn_retorna As New Button
        Dim lbl_pagina As New Label
        Dim btn_avanca As New Button
        spanel = _spanel

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
<<<<<<< HEAD
    Private Sub HandleScroll(sender As Object, e As ScrollEventArgs) b
        Vbarra = spanel.VerticalScroll.Value
        System.Diagnostics.Debug.WriteLine(Vbarra)
    End Sub
    Friend Sub ajustarBarra()
        spanel.VerticalScroll.Value = Vbarra
        System.Diagnostics.Debug.WriteLine(Vbarra)
    End Sub
=======


>>>>>>> 31d9d10526f9f248f1aa1ca772d026aecff88a22
End Class
