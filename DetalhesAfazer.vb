Imports System.Data.SqlClient
Public Class DetalhesAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim fk As Integer
    Dim pk As Integer
    Dim semprazo As Integer
    Dim panel As New Panel()
    Dim lbl_id As New Label()
    Dim lbl_fkitem As New Label()
    Dim lbl_dataCadastro As New Label()
    Dim lbl_dataCadastroValor As New Label()
    Dim lbl_userCadastro As New Label()
    Dim lbl_userCadastroValor As New Label()
    Dim lbl_dataAlteracao As New Label()
    Dim lbl_dataAlteracaoValor As New Label()
    Dim lbl_useralteracao As New Label()
    Dim lbl_useralteracaoValor As New Label()
    Dim lbl_titulo As New Label()
    Dim txt_titulo As New TextBox()
    Dim lbl_detalhes As New Label()
    Dim txt_detalhes As New TextBox()
    Dim lbl_prazo As New Label()
    Dim lbl_semprazo As New Label()
    Dim dtp_prazo As New DateTimePicker()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()
    Dim btn_addnotas As New Button()
    Dim btn_cancelar As New Button()
    Dim btn_modificar As New Button()
    Dim btn_salvar As New Button()

    'fontes
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim fontemenor As New Font("Microsoft Sans Serif", 8)

    Friend Sub New(ByVal _id As Integer)
        pk = _id
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        'texto dos labels
        lbl_dataCadastro.Text = "Data do Cadastro:"
        lbl_userCadastro.Text = "Usuário que cadastrou"
        lbl_dataAlteracao.Text = "Data da última alteração"
        lbl_useralteracao.Text = "Usuário que alterou"
        lbl_titulo.Text = "Título"
        lbl_prazo.Text = "Prazo"
        lbl_semprazo.Text = "Indeterminado"
        lbl_estado.Text = "Estado"
        lbl_detalhes.Text = "Detalhes"
        btn_addnotas.Text = "add. notas"
        btn_cancelar.Text = "Cancelar"
        btn_modificar.Text = "Editar"
        btn_salvar.Text = "Salvar"

        'fonte dos controles
        lbl_id.Font = fontemenor
        lbl_fkitem.Font = fontemenor
        lbl_dataCadastro.Font = fontemenor
        lbl_dataCadastroValor.Font = fontemenor
        lbl_userCadastro.Font = fontemenor
        lbl_userCadastroValor.Font = fontemenor
        lbl_dataAlteracao.Font = fontemenor
        lbl_dataAlteracaoValor.Font = fontemenor
        lbl_useralteracao.Font = fontemenor
        lbl_useralteracaoValor.Font = fontemenor
        lbl_titulo.Font = fonte
        txt_titulo.Font = fonte
        lbl_detalhes.Font = fonte
        txt_detalhes.Font = fontemenor
        lbl_prazo.Font = fonte
        lbl_semprazo.Font = fonte
        dtp_prazo.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte
        btn_addnotas.Font = fonte
        btn_cancelar.Font = fonte
        btn_modificar.Font = fonte
        btn_salvar.Font = fonte

        'tamanho dos controles
        Dim largura1 As Integer = 150
        Dim largura2 As Integer = 260
        Dim posicao As Integer = (largura1 * 2 - largura2) / 2
        Dim altura1 As Integer = 30
        Dim altura2 As Integer = 15
        Dim altura3 As Integer = 40

        panel.Size = New Size(302, 400)
        lbl_id.Size = New Size(largura1, altura2)
        lbl_fkitem.Size = New Size(largura1, altura2)
        lbl_dataCadastro.Size = New Size(largura1, altura2)
        lbl_dataCadastroValor.Size = New Size(largura1, altura2)
        lbl_userCadastro.Size = New Size(largura1, altura2)
        lbl_userCadastroValor.Size = New Size(largura1, altura2)
        lbl_dataAlteracao.Size = New Size(largura1, altura2)
        lbl_dataAlteracaoValor.Size = New Size(largura1, altura2)
        lbl_useralteracao.Size = New Size(largura1, altura2)
        lbl_useralteracaoValor.Size = New Size(largura1, altura2)
        lbl_titulo.Size = New Size(largura2, altura1)
        txt_titulo.Size = New Size(largura2, altura1)
        lbl_detalhes.Size = New Size(largura2, altura1)
        txt_detalhes.Size = New Size(largura2, 50)
        lbl_prazo.Size = New Size(largura2, altura1)
        lbl_semprazo.Size = New Size(largura2, altura1)
        dtp_prazo.Size = New Size(largura2, altura1)
        lbl_estado.Size = New Size(largura2, altura1)
        cbx_estado.Size = New Size(largura2, altura1)
        btn_addnotas.Size = New Size(largura1, altura3)
        btn_cancelar.Size = New Size(largura1, altura3)
        btn_modificar.Size = New Size(largura1, altura3)
        btn_salvar.Size = New Size(largura1, altura3)

        'posição dos controles
        panel.Location = New Point(10, 10)
        lbl_id.Location = New Point(0, 0)
        lbl_fkitem.Location = New Point(largura1, 0)
        lbl_dataCadastro.Location = New Point(0, altura2)
        lbl_dataCadastroValor.Location = New Point(0, lbl_dataCadastro.Location.Y + altura2)
        lbl_userCadastro.Location = New Point(0, lbl_dataCadastroValor.Location.Y + altura2)
        lbl_userCadastroValor.Location = New Point(0, lbl_userCadastro.Location.Y + altura2)
        lbl_dataAlteracao.Location = New Point(largura1, altura2)
        lbl_dataAlteracaoValor.Location = New Point(largura1, lbl_dataAlteracao.Location.Y + altura2)
        lbl_useralteracao.Location = New Point(largura1, lbl_dataAlteracaoValor.Location.Y + altura2)
        lbl_useralteracaoValor.Location = New Point(largura1, lbl_useralteracao.Location.Y + altura2)
        lbl_titulo.Location = New Point(posicao, lbl_useralteracaoValor.Location.Y + altura2)
        txt_titulo.Location = New Point(posicao, lbl_titulo.Location.Y + altura1)
        lbl_detalhes.Location = New Point(posicao, txt_titulo.Location.Y + altura1)
        txt_detalhes.Location = New Point(posicao, lbl_detalhes.Location.Y + altura1)
        lbl_prazo.Location = New Point(posicao, txt_detalhes.Location.Y + 50)
        lbl_semprazo.Location = New Point(posicao, lbl_prazo.Location.Y + altura1)
        dtp_prazo.Location = New Point(posicao, lbl_prazo.Location.Y + altura1)
        lbl_estado.Location = New Point(posicao, dtp_prazo.Location.Y + altura1)
        cbx_estado.Location = New Point(posicao, lbl_estado.Location.Y + altura1)
        btn_addnotas.Location = New Point(0, cbx_estado.Location.Y + altura1 + 20)
        btn_cancelar.Location = New Point(0, cbx_estado.Location.Y + altura1 + 20)
        btn_modificar.Location = New Point(largura1, cbx_estado.Location.Y + altura1 + 20)
        btn_salvar.Location = New Point(largura1, cbx_estado.Location.Y + altura1 + 20)

        'configurações especificas
        'panel.BorderStyle = BorderStyle.FixedSingle
        lbl_id.TextAlign = ContentAlignment.MiddleCenter
        lbl_fkitem.TextAlign = ContentAlignment.MiddleCenter
        lbl_dataCadastro.TextAlign = ContentAlignment.MiddleCenter
        lbl_userCadastro.TextAlign = ContentAlignment.MiddleCenter
        lbl_dataCadastroValor.TextAlign = ContentAlignment.MiddleCenter
        lbl_userCadastroValor.TextAlign = ContentAlignment.MiddleCenter
        lbl_dataAlteracao.TextAlign = ContentAlignment.MiddleCenter
        lbl_useralteracao.TextAlign = ContentAlignment.MiddleCenter
        lbl_dataAlteracaoValor.TextAlign = ContentAlignment.MiddleCenter
        lbl_useralteracaoValor.TextAlign = ContentAlignment.MiddleCenter
        lbl_titulo.TextAlign = ContentAlignment.MiddleCenter
        lbl_prazo.TextAlign = ContentAlignment.MiddleCenter
        lbl_semprazo.TextAlign = ContentAlignment.MiddleCenter
        lbl_detalhes.TextAlign = ContentAlignment.MiddleCenter
        lbl_estado.TextAlign = ContentAlignment.MiddleCenter
        cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
        dtp_prazo.Format = DateTimePickerFormat.Short
        dtp_prazo.Visible = False
        txt_detalhes.Multiline = True
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        dtp_prazo.Enabled = False
        cbx_estado.Enabled = False
        cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList
        btn_salvar.Visible = False
        btn_cancelar.Visible = False

        'vinculando funções aos botões
        AddHandler btn_addnotas.Click, AddressOf btn_addnotas_Click
        AddHandler btn_cancelar.Click, AddressOf btn_cancelar_Click
        AddHandler btn_modificar.Click, AddressOf btn_modificar_Click
        AddHandler btn_salvar.Click, AddressOf btn_salvar_Click

        'adicionando controles ao panel
        panel.Controls.Add(lbl_id)
        panel.Controls.Add(lbl_fkitem)
        panel.Controls.Add(lbl_dataCadastro)
        panel.Controls.Add(lbl_dataCadastroValor)
        panel.Controls.Add(lbl_userCadastro)
        panel.Controls.Add(lbl_userCadastroValor)
        panel.Controls.Add(lbl_dataAlteracao)
        panel.Controls.Add(lbl_dataAlteracaoValor)
        panel.Controls.Add(lbl_useralteracao)
        panel.Controls.Add(lbl_useralteracaoValor)
        panel.Controls.Add(lbl_titulo)
        panel.Controls.Add(txt_titulo)
        panel.Controls.Add(lbl_detalhes)
        panel.Controls.Add(txt_detalhes)
        panel.Controls.Add(lbl_prazo)
        panel.Controls.Add(lbl_semprazo)
        panel.Controls.Add(dtp_prazo)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(btn_addnotas)
        panel.Controls.Add(btn_cancelar)
        panel.Controls.Add(btn_modificar)
        panel.Controls.Add(btn_salvar)

        Me.Controls.Add(panel)
        atualizarDados()

    End Sub
    Private Sub atualizarDados()
        'extração de conteúdo do BD
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand
        consulta.CommandText = "select 
                                        afazer_id,
                                        afazer_fkitem, 
                                        afazer_dtcadastro, 
                                        afazer_usercadastro, 
                                        afazer_dtalteracao, 
                                        afazer_useralteracao, 
                                        afazer_titulo, 
                                        afazer_detalhes, 
                                        afazer_temprazo, 
                                        afazer_prazo, 
                                        afazer_status 
                                from tb_afazer where afazer_id=" & pk
        conexao.Open()
        myReader = consulta.ExecuteReader()

        myReader.Read()

        'conteudo dos controles extraido do BD
        lbl_id.Text = "PK: " & pk
        fk = myReader.GetValue(1)
        lbl_fkitem.Text = "FK: " & fk
        lbl_dataCadastroValor.Text = If(myReader.IsDBNull(2), "", myReader.GetDateTime(2))
        lbl_userCadastroValor.Text = If(myReader.IsDBNull(3), "", myReader.GetValue(3))
        lbl_dataAlteracaoValor.Text = If(myReader.IsDBNull(4), "", myReader.GetDateTime(4))
        lbl_useralteracaoValor.Text = If(myReader.IsDBNull(5), "", myReader.GetValue(5))
        txt_titulo.Text = If(myReader.IsDBNull(6), "", myReader.GetString(6))
        txt_detalhes.Text = If(myReader.IsDBNull(7), "", myReader.GetString(7))
        semprazo = If(myReader.IsDBNull(8), 0, myReader.GetValue(8))
        If semprazo > 0 Then
            lbl_semprazo.Visible = False
            dtp_prazo.Visible = True
            dtp_prazo.Value = If(myReader.IsDBNull(8), "", myReader.GetDateTime(9))
        End If
        cbx_estado.SelectedIndex = If(myReader.IsDBNull(5), 0, myReader.GetValue(10) - 1)

        myReader.Close()
        conexao.Close()
    End Sub
    Private Sub DetalhesAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 420)

    End Sub

    Private Sub btn_addnotas_Click()

        Dim frm_addNotas As New addNotas(fk)
        'addNotas.MdiParent =
        frm_addNotas.ShowDialog()
    End Sub
    Private Sub btn_modificar_Click()
        btn_addnotas.Visible = False
        btn_modificar.Visible = False
        btn_cancelar.Visible = True
        btn_salvar.Visible = True
        txt_titulo.ReadOnly = False
        dtp_prazo.Enabled = True
        cbx_estado.Enabled = True
        txt_detalhes.ReadOnly = False

    End Sub
    Private Sub btn_cancelar_Click()
        btn_cancelar.Visible = False
        btn_salvar.Visible = False
        btn_addnotas.Visible = True
        btn_modificar.Visible = True
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        dtp_prazo.Enabled = False
        cbx_estado.Enabled = False
        atualizarDados()

    End Sub
    Private Sub btn_salvar_Click()
        btn_cancelar.Visible = False
        btn_salvar.Visible = False
        btn_addnotas.Visible = True
        btn_modificar.Visible = True

        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        consulta = conexao.CreateCommand
        consulta.CommandText = "UPDATE tb_afazer SET 
                                afazer_dtalteracao = GETDATE(),
                                afazer_useralteracao ='" & usuario.usuario_id & "',
                                afazer_titulo = '" & txt_titulo.Text & "',
                                afazer_prazo = '" & dtp_prazo.Value & "',
                                afazer_status = " & cbx_estado.SelectedIndex + 1 & ",
                                afazer_detalhes = '" & txt_detalhes.Text & "' 
                                WHERE afazer_id = " & pk

        conexao.Open()

        myReader = consulta.ExecuteReader()

        conexao.Close()

        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        dtp_prazo.Enabled = False
        cbx_estado.Enabled = False
        atualizarDados()
    End Sub



End Class