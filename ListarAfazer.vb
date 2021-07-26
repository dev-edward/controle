Imports System.Data.SqlClient

Public Class listarAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Class Afazer
        'Create ADO.NET objects.
        Private conexao As SqlConnection
        Private consulta As SqlCommand
        Private myReader As SqlDataReader

        Dim panel As New Panel()
        Dim lbl_id As New Label()
        Dim lbl_fkitem As New Label()
        Dim lbl_dataCadastro As New Label()
        Dim lbl_dataCadastroValor As New Label()
        Dim lbl_titulo As New Label()
        Dim txt_titulo As New TextBox()
        Dim lbl_prazo As New Label()
        Dim dtp_prazo As New DateTimePicker()
        Dim lbl_estado As New Label()
        Dim cbx_estado As New ComboBox()
        Dim btn_addnotas As New Button()
        Dim btn_modificar As New Button()
        Dim btn_salvar As New Button()
        Dim lbl_detalhes As New Label()
        Dim txt_detalhes As New TextBox()

        'fonte padrão
        Dim fonte As New Font("Microsoft Sans Serif", 12)

        Friend Sub New(ByVal _conteiner As Panel, ByVal _id As Integer, ByVal _fkitem As Integer, ByVal _dataCadastro As DateTime, ByVal _titulo As String, ByVal _prazo As DateTime, ByVal _estado As Integer, ByVal _detalhes As String, ByVal _panelY As Integer)
            'adicionando controles no panel
            panel.Controls.Add(lbl_id)
            panel.Controls.Add(lbl_fkitem)
            panel.Controls.Add(lbl_dataCadastro)
            panel.Controls.Add(lbl_dataCadastroValor)
            panel.Controls.Add(lbl_titulo)
            panel.Controls.Add(txt_titulo)
            panel.Controls.Add(lbl_prazo)
            panel.Controls.Add(dtp_prazo)
            panel.Controls.Add(lbl_estado)
            panel.Controls.Add(cbx_estado)
            panel.Controls.Add(btn_addnotas)
            panel.Controls.Add(btn_modificar)
            panel.Controls.Add(btn_salvar)
            panel.Controls.Add(lbl_detalhes)
            panel.Controls.Add(txt_detalhes)

            'colocando fonte 12 para todos os itens
            lbl_id.Font = fonte
            lbl_fkitem.Font = fonte
            lbl_dataCadastro.Font = fonte
            lbl_dataCadastroValor.Font = fonte
            lbl_titulo.Font = fonte
            txt_titulo.Font = fonte
            lbl_prazo.Font = fonte
            dtp_prazo.Font = fonte
            lbl_estado.Font = fonte
            cbx_estado.Font = fonte
            btn_addnotas.Font = fonte
            btn_modificar.Font = fonte
            btn_salvar.Font = fonte
            lbl_detalhes.Font = fonte
            txt_detalhes.Font = New Font("Microsoft Sans Serif", 8)

            'labels
            lbl_dataCadastro.Text = "Data do Cadastro:"
            lbl_titulo.Text = "Título"
            lbl_prazo.Text = "Prazo"
            lbl_estado.Text = "Estado"
            lbl_detalhes.Text = "Detalhes"
            btn_addnotas.Text = "add. notas"
            btn_modificar.Text = "Editar"
            btn_salvar.Text = "Salvar"

            'conteudo dos controles extraido do BD
            lbl_id.Text = _id
            lbl_fkitem.Text = _fkitem
            lbl_dataCadastroValor.Text = _dataCadastro
            txt_titulo.Text = _titulo
            dtp_prazo.Value = _prazo
            cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
            cbx_estado.SelectedIndex = _estado - 1
            txt_detalhes.Text = _detalhes


            ''tamanho dos controles
            'panel.Size = New Size(660, 170)
            'lbl_id.Size = New Size(30, 20)
            'lbl_fkitem.Size = New Size(30, 20)
            'lbl_dataCadastro.Size = New Size(140, 20)
            'lbl_dataCadastroValor.Size = New Size(110, 20)
            'lbl_titulo.Size = New Size(260, 20)
            'txt_titulo.Size = New Size(260, 26)
            'lbl_prazo.Size = New Size(110, 20)
            'dtp_prazo.Size = New Size(110, 26)
            'lbl_estado.Size = New Size(140, 20)
            'cbx_estado.Size = New Size(140, 20)
            'btn_addnotas.Size = New Size(100, 30)
            'btn_modificar.Size = New Size(100, 30)
            'btn_salvar.Size = New Size(100, 30)
            'lbl_detalhes.Size = New Size(640, 20)
            ''lbl_titulo.BackColor = New Color().FromArgb(255, 215, 0, 0)
            'txt_detalhes.Size = New Size(640, 60)

            'posição dos controles
            panel.Location = New Point(0, _panelY)

            'lbl_id.Location = New Point(10, 10)
            'lbl_fkitem.Location = New Point(40, 10)
            'lbl_dataCadastro.Location = New Point(panel.Width / 2 - (lbl_dataCadastro.Width), 2)
            'lbl_dataCadastroValor.Location = New Point(panel.Width / 2, 2)
            'lbl_titulo.Location = New Point(10, 26)
            'txt_titulo.Location = New Point(10, 48)
            'lbl_prazo.Location = New Point(280, 26)
            'dtp_prazo.Location = New Point(280, 48)
            'lbl_estado.Location = New Point(400, 26)
            'cbx_estado.Location = New Point(400, 48)
            'btn_addnotas.Location = New Point(550, 16)
            'btn_modificar.Location = New Point(550, 47)
            'btn_salvar.Location = New Point(550, 47)
            'lbl_detalhes.Location = New Point(10, 80)
            'txt_detalhes.Location = New Point(10, 100)

            ''configurações especificas
            'panel.BorderStyle = BorderStyle.FixedSingle
            'dtp_prazo.Format = DateTimePickerFormat.Short
            'lbl_titulo.TextAlign = ContentAlignment.MiddleCenter
            'lbl_prazo.TextAlign = ContentAlignment.MiddleCenter
            'lbl_detalhes.TextAlign = ContentAlignment.MiddleCenter
            'txt_detalhes.Multiline = True
            'txt_titulo.ReadOnly = True
            'txt_detalhes.ReadOnly = True
            'dtp_prazo.Enabled = False
            'cbx_estado.Enabled = False
            'cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList

            ''vinculando funções aos botões
            'AddHandler btn_addnotas.Click, AddressOf btn_addnotas_Click
            'AddHandler btn_modificar.Click, AddressOf btn_modificar_Click
            'AddHandler btn_salvar.Click, AddressOf btn_salvar_Click

            btn_salvar.Visible = False

            _conteiner.Controls.Add(panel)


        End Sub

        Private Sub btn_addnotas_Click()

            Dim frm_addNotas As New addNotas(Me.lbl_fkitem.Text)
            'addNotas.MdiParent =
            frm_addNotas.ShowDialog()
        End Sub

        Private Sub btn_modificar_Click()
            btn_modificar.Visible = False
            btn_salvar.Visible = True

            txt_titulo.ReadOnly = False
            dtp_prazo.Enabled = True
            cbx_estado.Enabled = True
            txt_detalhes.ReadOnly = False

        End Sub

        Private Sub btn_salvar_Click()
            btn_salvar.Visible = False
            btn_modificar.Visible = True

            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_afazer SET afazer_titulo = '" & txt_titulo.Text & "',
                                   afazer_prazo = '" & dtp_prazo.Value & "',
                                   afazer_status = " & cbx_estado.SelectedIndex + 1 & ",
                                   afazer_detalhes = '" & txt_detalhes.Text & "' 
                                   WHERE afazer_id = " & lbl_id.Text

            conexao.Open()

            myReader = consulta.ExecuteReader()

            conexao.Close()

            txt_titulo.ReadOnly = True
            dtp_prazo.Enabled = False
            cbx_estado.Enabled = False
            txt_detalhes.ReadOnly = True

        End Sub


    End Class


    Friend Sub New(ByVal _form As Form)
        Dim panel_ferramentas As New Panel()
        Dim btn_cadastrar As New Button()
        Dim btn_atualizar As New Button()
        Dim conteiner = New Panel

        AddHandler btn_cadastrar.Click, AddressOf btn_cadastrar_Click
        AddHandler btn_atualizar.Click, AddressOf btn_atualizar_Click
        btn_cadastrar.Text = "+"
        btn_atualizar.Text = "(*)"
        btn_cadastrar.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        btn_atualizar.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        btn_cadastrar.Location = New Point(10, 10)
        btn_atualizar.Location = New Point(100, 10)

        panel_ferramentas.Size = New Size(660, 30)
        panel_ferramentas.Location = New Point((_form.ClientSize.Width - panel_ferramentas.Width) / 2, 0)
        panel_ferramentas.Controls.Add(btn_cadastrar)
        panel_ferramentas.Controls.Add(btn_atualizar)

        conteiner.Controls.Add(panel_ferramentas)

        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        consulta = conexao.CreateCommand
        consulta.CommandText = "select afazer_id, afazer_fkitem, afazer_dtcadastro,afazer_titulo,afazer_detalhes, afazer_prazo,afazer_status from tb_afazer ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"

        conexao.Open()

        myReader = consulta.ExecuteReader()

        Dim panelY As Integer
        panelY = 50

        Do While myReader.Read()
            Dim id As Integer
            Dim fkitem As Integer
            Dim dataCadastro As DateTime
            Dim titulo As String
            Dim detalhes As String
            Dim prazo As DateTime
            Dim estado As String


            id = myReader.GetInt32(0)
            fkitem = myReader.GetInt32(1)
            dataCadastro = myReader.GetDateTime(2)
            titulo = myReader.GetString(3)
            detalhes = myReader.GetString(4)
            prazo = myReader.GetDateTime(5)
            estado = myReader.GetByte(6)

            Dim a1 As New Afazer(conteiner, id, fkitem, dataCadastro, titulo, prazo, estado, detalhes, panelY)
            panelY += 180
        Loop
        conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 2)
        conteiner.AutoSize = True
        conteiner.BackColor = New Color().FromArgb(255, 0, 0, 150)
        _form.Controls.Add(conteiner)

        myReader.Close()
        conexao.Close()
    End Sub

    Private Sub btn_cadastrar_Click()
        'Dim CadastrarAfazer = New cadastrarAfazer
        'CadastrarAfazer.MdiParent = Principal
        'CadastrarAfazer.ShowIcon = False
        'CadastrarAfazer.MaximizeBox = False
        ''cadastrarAfazer.Dock = DockStyle.Left
        ''Me.Dock = DockStyle.Right
        'CadastrarAfazer.Show()
        'Me.Refresh()
        ''Principal.LayoutMdi(MdiLayout.TileVertical)

        ''If (Application.OpenForms.OfType(Of cadastrarAfazer).Any()) Then
        ''    Application.OpenForms.OfType(Of cadastrarAfazer).First().BringToFront()
        ''Else
        ''    'Dim CadastrarAfazer = New cadastrarAfazer
        ''    cadastrarAfazer.MdiParent = Principal
        ''    cadastrarAfazer.ShowIcon = False
        ''    cadastrarAfazer.MaximizeBox = False
        ''    cadastrarAfazer.Dock = DockStyle.Left
        ''    'Me.Dock = DockStyle.Right
        ''    cadastrarAfazer.Show()
        ''    Me.Refresh()
        ''    Principal.LayoutMdi(MdiLayout.TileVertical)
        ''End If

    End Sub
    Private Sub btn_atualizar_Click()
        'Principal.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

End Class