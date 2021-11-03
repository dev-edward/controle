Public Class Demanda
    Friend pk As Integer
    Friend estado As Integer
    Friend qtdNotas As Integer
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim cor_botao = Color.FromArgb(255, 110, 120, 148)
    Dim panel As New Panel With {
        .Size = New Size(280, 54)
    }
    Dim txt_titulo As New TextBox With {
        .Font = fonte,
        .Size = New Size(274, 26),
        .Location = New Point(4, 0),
        .ReadOnly = True
    }
    Dim lbl_previsao As New Label With {
        .Size = New Size(98, 26),
        .Location = New Point(4, 27),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim btn_vermais As New Button With {
        .Size = New Size(56, 26),
        .Location = New Point(98, 27),
        .BackColor = cor_botao,
        .BackgroundImage = img.vermais,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup
    }
    Dim btn_notas As New Button With {
        .Size = New Size(56, 26),
        .Location = New Point(158, 27),
        .BackColor = cor_botao,
        .ForeColor = Color.FromArgb(255, 255, 255, 255),
        .TextAlign = ContentAlignment.TopRight,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup
    }
    Dim btn_estado As New Button With {
        .Size = New Size(56, 26),
        .Location = New Point(218, 27),
        .BackColor = cor_botao,
        .FlatStyle = FlatStyle.Popup
    }

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

    Friend Sub New(ByRef _lista As DemandaLista, ByVal _id As Integer, ByVal _titulo As String, ByVal _temprevisao As Integer, ByVal _previsao As DateTime, ByVal _estado As Integer, ByVal _qtdNotas As Integer, ByVal _panelY As Integer)

        'adicionando controles no panel
        panel.Controls.Add(txt_titulo)
        panel.Controls.Add(lbl_previsao)
        panel.Controls.Add(btn_vermais)
        panel.Controls.Add(btn_notas)
        panel.Controls.Add(btn_estado)

        pk = _id
        estado = _estado
        qtdNotas = _qtdNotas
        txt_titulo.Text = _titulo
        lbl_previsao.Text = If(_temprevisao > 0, _previsao, "Indeterminado")

        '.Location = New Point(0, 0),
        panel.Location = New Point(0, _panelY)

        btn_notas.Text = If(qtdNotas > 0, qtdNotas, "")

        setEstado(estado)

        'vinculando funções aos botões
        AddHandler btn_vermais.Click, AddressOf btn_vermais_Click
        AddHandler btn_notas.Click, AddressOf btn_notas_Click
        AddHandler btn_estado.Click, AddressOf btn_estado_Click

        _lista.conteiner.Controls.Add(panel)

    End Sub
    Private Sub btn_vermais_Click()
        If Application.OpenForms.OfType(Of DemandaDetalhes).Any() And Not classesAbertas.cadastrodemanda Then
            classesAbertas.atualdetalhes.atualizarDados(pk)
            Application.OpenForms.OfType(Of DemandaDetalhes).First().BringToFront()
        Else
            If Application.OpenForms.OfType(Of DemandaDetalhes).Any() And classesAbertas.cadastrodemanda Then
                Application.OpenForms.OfType(Of DemandaDetalhes).First().Close()
            End If
            Dim verDetalhes = New DemandaDetalhes(Me)
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
        Dim status As New DemandaEstado(Me)
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