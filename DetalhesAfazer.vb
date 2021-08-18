Imports System.Data.SqlClient
Public Class DetalhesAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

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
    Dim dtp_prazo As New DateTimePicker()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()
    Dim btn_addnotas As New Button()
    Dim btn_modificar As New Button()
    Dim btn_salvar As New Button()

    'fontes
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim fontemenor As New Font("Microsoft Sans Serif", 8)

    Friend Sub New(ByVal _id As Integer)

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
        lbl_estado.Text = "Estado"
        lbl_detalhes.Text = "Detalhes"
        btn_addnotas.Text = "add. notas"
        btn_modificar.Text = "Editar"
        btn_salvar.Text = "Salvar"

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
                                        afazer_prazo, 
                                        afazer_status 
                                from tb_afazer where afazer_id=" & _id
        conexao.Open()
        myReader = consulta.ExecuteReader()

        myReader.Read()

        'conteudo dos controles extraido do BD
        lbl_id.Text = myReader.GetValue(0)
        lbl_fkitem.Text = myReader.GetValue(1)
        lbl_dataCadastroValor.Text = If(myReader.IsDBNull(2), "", myReader.GetDateTime(2))
        lbl_userCadastroValor.Text = If(myReader.IsDBNull(3), "", myReader.GetValue(3))
        lbl_dataAlteracaoValor.Text = If(myReader.IsDBNull(4), "", myReader.GetDateTime(4))
        lbl_useralteracaoValor.Text = If(myReader.IsDBNull(5), "", myReader.GetValue(5))
        txt_titulo.Text = If(myReader.IsDBNull(6), "", myReader.GetString(6))
        txt_detalhes.Text = If(myReader.IsDBNull(7), "", myReader.GetString(7))
        dtp_prazo.Value = If(myReader.IsDBNull(8), "", myReader.GetDateTime(8))
        cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
        cbx_estado.SelectedIndex = If(myReader.IsDBNull(5), 0, myReader.GetValue(9) - 1)

        myReader.Close()
        conexao.Close()

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
        dtp_prazo.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte
        btn_addnotas.Font = fonte
        btn_modificar.Font = fonte
        btn_salvar.Font = fonte

        'tamanho dos controles
        Dim largura1 As Integer = 100
        Dim largura2 As Integer = 160
        Dim largura3 As Integer = 80
        Dim altura1 As Integer = 30
        Dim altura2 As Integer = 25
        Dim altura3 As Integer = 40

        'tamanho dos controles
        panel.Size = New Size(240, 400)
        lbl_id.Size = New Size(20, 20)
        lbl_fkitem.Size = New Size(20, 20)
        lbl_dataCadastro.Size = New Size(largura1, altura2)
        lbl_dataCadastroValor.Size = New Size(largura1, altura2)
        lbl_userCadastro.Size = New Size(largura1, altura2)
        lbl_userCadastroValor.Size = New Size(largura1, altura2)
        lbl_dataAlteracao.Size = New Size(50, altura2)
        lbl_dataAlteracaoValor.Size = New Size(largura1, altura2)
        lbl_useralteracao.Size = New Size(largura1, altura2)
        lbl_useralteracaoValor.Size = New Size(largura1, altura2)
        lbl_titulo.Size = New Size(largura1, altura1)
        txt_titulo.Size = New Size(largura2, altura1)
        lbl_detalhes.Size = New Size(largura1, altura1)
        txt_detalhes.Size = New Size(largura2, altura2 * 2)
        lbl_prazo.Size = New Size(largura1, altura1)
        dtp_prazo.Size = New Size(largura1, altura1)
        lbl_estado.Size = New Size(largura1, altura1)
        cbx_estado.Size = New Size(largura1, altura1)
        btn_addnotas.Size = New Size(largura3, altura3)
        btn_modificar.Size = New Size(largura3, altura3)
        btn_salvar.Size = New Size(largura3, altura3)

        'posição dos controles
        panel.Location = New Point(10, 10)
        lbl_id.Location = New Point(60, 0)
        lbl_fkitem.Location = New Point(160, 0)
        lbl_dataCadastro.Location = New Point(20, 20)
        lbl_dataCadastroValor.Location = New Point(20, 45)
        lbl_userCadastro.Location = New Point(20, 70)
        lbl_userCadastroValor.Location = New Point(20, 95)
        lbl_dataAlteracao.Location = New Point(120, 20)
        lbl_dataAlteracaoValor.Location = New Point(120, 45)
        lbl_useralteracao.Location = New Point(120, 70)
        lbl_useralteracaoValor.Location = New Point(120, 95)
        lbl_titulo.Location = New Point(70, 120)
        txt_titulo.Location = New Point(40, 150)
        lbl_detalhes.Location = New Point(70, 180)
        txt_detalhes.Location = New Point(40, 210)
        lbl_prazo.Location = New Point(70, 240)
        dtp_prazo.Location = New Point(40, 270)
        lbl_estado.Location = New Point(70, 300)
        cbx_estado.Location = New Point(40, 330)
        btn_addnotas.Location = New Point(0, 360)
        btn_modificar.Location = New Point(80, 360)
        btn_salvar.Location = New Point(160, 360)

        'configurações especificas
        panel.BorderStyle = BorderStyle.FixedSingle
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
        lbl_detalhes.TextAlign = ContentAlignment.MiddleCenter
        lbl_estado.TextAlign = ContentAlignment.MiddleCenter
        dtp_prazo.Format = DateTimePickerFormat.Short
        txt_detalhes.Multiline = True
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        dtp_prazo.Enabled = False
        cbx_estado.Enabled = False
        cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList

        'vinculando funções aos botões
        AddHandler btn_addnotas.Click, AddressOf btn_addnotas_Click
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
        panel.Controls.Add(lbl_prazo)
        panel.Controls.Add(dtp_prazo)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(btn_addnotas)
        panel.Controls.Add(btn_modificar)
        panel.Controls.Add(btn_salvar)
        panel.Controls.Add(lbl_detalhes)
        panel.Controls.Add(txt_detalhes)

        Me.Controls.Add(panel)

    End Sub
    Private Sub DetalhesAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.ClientSize = New Size(260, 420)
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