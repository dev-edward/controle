Public Class Afazer
    Friend pk As Integer
    Friend fk As Integer
    Friend estado As Integer
    Friend qtdNotas As Integer
    Dim panel As New Panel
    Dim txt_titulo As New TextBox
    Dim lbl_previsao As New Label
    Dim btn_vermais As New Button
    Dim btn_notas As New Button
    Dim btn_estado As New Button

    'Friend Property valor_pk() As Integer
    '    Get
    '        Return pk
    '    End Get
    '    Set(ByVal value As Integer)
    '        pk = value
    '    End Set
    'End Property
    'Friend Property valor_fk() As Integer
    '    Get
    '        Return fk
    '    End Get
    '    Set(ByVal value As Integer)
    '        fk = value
    '    End Set
    'End Property
    'Friend Property valor_estado() As Integer
    '    Get
    '        Return estado
    '    End Get
    '    Set(ByVal value As Integer)
    '        estado = value
    '    End Set
    'End Property
    'Friend Property valor_qtdNotas() As Integer
    '    Get
    '        Return qtdNotas
    '    End Get
    '    Set(ByVal value As Integer)
    '        qtdNotas = value
    '        btn_notas.Text = qtdNotas
    '    End Set
    'End Property

    'fonte padrão
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim cor_botao = Color.FromArgb(255, 26, 147, 111)

    Friend Sub New(ByRef _lista As AfazerLista, ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _fkitem As Integer, ByVal _titulo As String, ByVal _temprevisao As Integer, ByVal _previsao As DateTime, ByVal _estado As Integer, ByVal _qtdNotas As Integer, ByVal _panelY As Integer)

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
        qtdNotas = _qtdNotas
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
        btn_notas.Text = If(qtdNotas > 0, qtdNotas, "")
        btn_notas.ForeColor = Color.FromArgb(255, 255, 255, 255)
        btn_notas.TextAlign = ContentAlignment.TopRight
        btn_notas.Font = New Font("Impact", 10)
        btn_vermais.BackgroundImage = img.vermais
        btn_vermais.BackgroundImageLayout = ImageLayout.Zoom
        btn_notas.BackgroundImage = img.notas
        btn_notas.BackgroundImageLayout = ImageLayout.Zoom

        setEstado(estado)

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

        If Application.OpenForms.OfType(Of AfazerDetalhes).Any() And classesAbertas.cadastroOUdetalhes = 2 Then
            classesAbertas.atualdetalhes.atualizarDados(pk)
            Application.OpenForms.OfType(Of AfazerDetalhes).First().BringToFront()
        Else
            If Application.OpenForms.OfType(Of AfazerDetalhes).Any() And classesAbertas.cadastroOUdetalhes = 1 Then
                Application.OpenForms.OfType(Of AfazerDetalhes).First().Close()
            End If
            Dim verDetalhes = New AfazerDetalhes(Me)
            verDetalhes.Show()
        End If

    End Sub
    Private Sub btn_notas_Click()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            classesAbertas.atualnotas.atualizarNovaLista(Me)
            Application.OpenForms.OfType(Of listarNotas).First().BringToFront()
        Else
            Dim notas = New listarNotas(Me)
            notas.Show()
        End If
    End Sub
    Private Sub btn_estado_Click()
        Dim status As New AfazerEstado(Me)
        status.ShowDialog()
    End Sub

    Friend Sub setEstado(ByVal _estado As Integer)
        estado = _estado
        Select Case estado
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
    End Sub
    Friend Sub setDados(ByVal _titulo As String, ByVal _temprevisao As Integer, ByVal _previsao As DateTime)
        setEstado(estado)
        txt_titulo.Text = _titulo
        lbl_previsao.Text = If(_temprevisao > 0, _previsao, "Indeterminado")
    End Sub
    Friend Sub setQtdNotas(ByVal _qtdNotas As Integer)
        qtdNotas = _qtdNotas
        btn_notas.Text = If(qtdNotas > 0, qtdNotas, "")
    End Sub
End Class