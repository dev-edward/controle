Imports System.Data.SqlClient
Public Class AfazerDetalhes
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim fk As Integer
    Dim pk As Integer
    Dim temprevisao As Integer
    Dim panel As New Panel
    Dim lbl_id As New Label
    Dim lbl_fkitem As New Label
    Dim lbl_dataCadastro As New Label
    Dim lbl_dataCadastroValor As New Label
    Dim lbl_userCadastro As New Label
    Dim lbl_userCadastroValor As New Label
    Dim lbl_dataAlteracao As New Label
    Dim lbl_dataAlteracaoValor As New Label
    Dim lbl_useralteracao As New Label
    Dim lbl_useralteracaoValor As New Label
    Dim lbl_titulo As New Label
    Dim txt_titulo As New TextBox
    Dim lbl_detalhes As New Label
    Dim txt_detalhes As New RichTextBox
    Dim lbl_previsao As New Label
    Dim WithEvents cbx_previsao As New CheckBox
    Dim lbl_semprevisao As New Label
    Dim dtp_previsao As New DateTimePicker
    Dim lbl_estado As New Label
    Dim cbx_estado As New ComboBox
    Dim btn_addnotas As New Button
    Dim btn_cancelar As New Button
    Dim btn_modificar As New Button
    Dim btn_salvar As New Button

    Dim largura1 As Integer = 150
    Dim largura2 As Integer = 260
    Dim posicao As Integer = (largura1 * 2 - largura2) / 2
    Dim altura1 As Integer = 30
    Dim altura2 As Integer = 15
    Dim altura3 As Integer = 40

    'fontes
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim fontemenor As New Font("Microsoft Sans Serif", 8)

    Friend Sub New()

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        'lbl_titulo.Location = New Point(posicao, lbl_useralteracaoValor.Location.Y + altura2)
        btn_salvar.Size = New Size(largura1, altura3)
        btn_salvar.Location = New Point(largura1, cbx_estado.Location.Y + altura1 + 20)
        AddHandler btn_salvar.Click, AddressOf btn_salvar_Click

        configurarForm()
    End Sub
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
        lbl_previsao.Text = "Previsao"
        lbl_semprevisao.Text = "Indeterminado"
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
        btn_addnotas.Font = fonte
        btn_cancelar.Font = fonte
        btn_modificar.Font = fonte
        btn_salvar.Font = fonte

        'tamanho dos controles
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
        btn_addnotas.Size = New Size(largura1, altura3)
        btn_cancelar.Size = New Size(largura1, altura3)
        btn_modificar.Size = New Size(largura1, altura3)
        btn_salvar.Size = New Size(largura1, altura3)

        'posição dos controles
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
        btn_addnotas.Location = New Point(0, cbx_estado.Location.Y + altura1 + 20)
        btn_cancelar.Location = New Point(0, cbx_estado.Location.Y + altura1 + 20)
        btn_modificar.Location = New Point(largura1, cbx_estado.Location.Y + altura1 + 20)
        btn_salvar.Location = New Point(largura1, cbx_estado.Location.Y + altura1 + 20)

        lbl_titulo.Location = New Point(posicao, lbl_useralteracaoValor.Location.Y + altura2)

        'configurações específicas
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
        btn_salvar.Visible = False
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        btn_cancelar.Visible = False

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
        panel.Controls.Add(btn_addnotas)
        panel.Controls.Add(btn_cancelar)
        panel.Controls.Add(btn_modificar)

        configurarForm()
        atualizarDados()
    End Sub
    Private Sub configurarForm()
        'fonte dos controles
        lbl_titulo.Font = fonte
        txt_titulo.Font = fonte
        lbl_detalhes.Font = fonte
        txt_detalhes.Font = fontemenor
        lbl_previsao.Font = fonte
        cbx_previsao.Font = fonte
        lbl_semprevisao.Font = fonte
        dtp_previsao.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte

        'tamanho dos controles
        panel.Size = New Size(302, 400)
        lbl_titulo.Size = New Size(largura2, altura1)
        txt_titulo.Size = New Size(largura2, altura1)
        lbl_detalhes.Size = New Size(largura2, altura1)
        txt_detalhes.Size = New Size(largura2, 50)
        lbl_previsao.Size = New Size(largura2 - 12, altura1)
        cbx_previsao.Size = New Size(12, altura1)
        lbl_semprevisao.Size = New Size(largura2, altura1)
        dtp_previsao.Size = New Size(largura2, altura1)
        lbl_estado.Size = New Size(largura2, altura1)
        cbx_estado.Size = New Size(largura2, altura1)

        'posição dos controles
        panel.Location = New Point(10, 10)
        txt_titulo.Location = New Point(posicao, lbl_titulo.Location.Y + altura1)
        lbl_detalhes.Location = New Point(posicao, txt_titulo.Location.Y + altura1)
        txt_detalhes.Location = New Point(posicao, lbl_detalhes.Location.Y + altura1)
        lbl_previsao.Location = New Point(posicao, txt_detalhes.Location.Y + 50)
        cbx_previsao.Location = New Point(posicao + 248, txt_detalhes.Location.Y + 50)
        dtp_previsao.Location = New Point(posicao, cbx_previsao.Location.Y + altura1)
        lbl_semprevisao.Location = New Point(posicao, cbx_previsao.Location.Y + altura1)
        lbl_estado.Location = New Point(posicao, dtp_previsao.Location.Y + altura1)
        cbx_estado.Location = New Point(posicao, lbl_estado.Location.Y + altura1)

        'configurações especificas
        'panel.BorderStyle = BorderStyle.FixedSingle
        lbl_titulo.TextAlign = ContentAlignment.MiddleCenter
        lbl_previsao.TextAlign = ContentAlignment.MiddleCenter
        cbx_previsao.CheckAlign = ContentAlignment.MiddleCenter
        lbl_semprevisao.TextAlign = ContentAlignment.MiddleCenter
        lbl_detalhes.TextAlign = ContentAlignment.MiddleCenter
        lbl_estado.TextAlign = ContentAlignment.MiddleCenter
        cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento", "Descartado"})
        dtp_previsao.Format = DateTimePickerFormat.Short
        dtp_previsao.Visible = False
        txt_detalhes.Multiline = True
        cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList
        cbx_previsao.FlatStyle = FlatStyle.Flat

        'adicionando controles ao panel
        panel.Controls.Add(lbl_titulo)
        panel.Controls.Add(txt_titulo)
        panel.Controls.Add(lbl_detalhes)
        panel.Controls.Add(txt_detalhes)
        panel.Controls.Add(lbl_previsao)
        panel.Controls.Add(cbx_previsao)
        panel.Controls.Add(lbl_semprevisao)
        panel.Controls.Add(dtp_previsao)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(btn_salvar)

        Me.Controls.Add(panel)
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
                                        afazer_temprevisao, 
                                        afazer_previsao, 
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
        temprevisao = If(myReader.IsDBNull(8), 0, myReader.GetValue(8))
        dtp_previsao.Value = If(myReader.IsDBNull(9), "", myReader.GetDateTime(9))
        cbx_estado.SelectedIndex = If(myReader.IsDBNull(10), 0, myReader.GetValue(10) - 1)

        myReader.Close()
        conexao.Close()

        If temprevisao > 0 Then
            lbl_semprevisao.Visible = False
            dtp_previsao.Visible = True
            cbx_previsao.Checked = True
        Else
            lbl_semprevisao.Visible = True
            dtp_previsao.Visible = False
            cbx_previsao.Checked = False
        End If

    End Sub
    Private Sub DetalhesAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 420)

    End Sub
    Private Sub cbx_previsao_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_previsao.CheckedChanged
        If cbx_previsao.Checked Then
            lbl_semprevisao.Visible = False
            dtp_previsao.Visible = True
        ElseIf cbx_previsao.Checked = False Then
            lbl_semprevisao.Visible = True
            dtp_previsao.Visible = False
        End If

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
        cbx_previsao.Enabled = True
        dtp_previsao.Enabled = True
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
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        atualizarDados()

    End Sub
    Private Sub btn_salvar_Click()
        btn_cancelar.Visible = False
        btn_salvar.Visible = False
        btn_addnotas.Visible = True
        btn_modificar.Visible = True

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_afazer SET 
                                afazer_dtalteracao = GETDATE(),
                                afazer_useralteracao = @useralteracao,
                                afazer_titulo = @titulo,
                                afazer_temprevisao = @temprevisao,
                                afazer_previsao = @previsao,
                                afazer_status = @status,
                                afazer_detalhes = @detalhes 
                                WHERE afazer_id = @id"

            consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@titulo", txt_titulo.Text)
            consulta.Parameters.AddWithValue("@temprevisao", If(cbx_previsao.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@previsao", dtp_previsao.Value)
            consulta.Parameters.AddWithValue("@status", cbx_estado.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@detalhes", txt_detalhes.Text)
            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        atualizarDados()
    End Sub

End Class