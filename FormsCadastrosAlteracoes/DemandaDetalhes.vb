Imports System.Data.SqlClient
Public Class DemandaDetalhes
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    'fontes
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim fontemenor As New Font("Microsoft Sans Serif", 8)

    'medidas padrão
    Dim largura1 As Integer = 150
    Dim largura2 As Integer = 260
    Dim posicao As Integer = (largura1 * 2 - largura2) / 2
    Dim altura1 As Integer = 30
    Dim altura3 As Integer = 40

    Dim posicaoInicial1 As New Point(Screen.FromControl(Principal.LateralEsquerda).WorkingArea.X + 310, Screen.FromControl(Principal.LateralEsquerda).WorkingArea.Y + 120)
    Dim posicaoInicial2 As New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)

    Dim pk As Integer
    Const tabela As String = "demanda"
    Dim novoid As Integer
    Dim temprevisao As Integer

    Dim panel As New Panel With {
        .Size = New Size(302, 480),
        .Location = New Point(10, 10)
    }
    Dim lbl_titulo As New Label With {
        .Text = "Título",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(posicao, 0)
    }
    Dim txt_titulo As New TextBox With{
        .Font = fonte,
        .Size = New Size(largura2, altura1)
    }
    Dim lbl_detalhes As New Label With{
        .Text = "Detalhes",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim txt_detalhes As New RichTextBox With{
        .Font = fontemenor,
        .Size = New Size(largura2, 50),
        .Multiline = True
    }
    Dim lbl_previsao As New Label With{
        .Text = "Previsao",
        .Font = fonte,
        .Size = New Size(largura2 - 12, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim WithEvents cbx_previsao As New CheckBox With{
        .Font = fonte,
        .Size = New Size(12, altura1),
        .CheckAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat
    }
    Dim lbl_semprevisao As New Label With{
        .Text = "Indeterminado",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim dtp_previsao As New DateTimePicker With{
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .Format = DateTimePickerFormat.Short,
        .Visible = False
    }
    Dim lbl_estado As New Label With{
        .Text = "Estado",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim cbx_estado As New ComboBox With {
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .DropDownStyle = ComboBoxStyle.DropDownList
    }
    Dim lbl_encarregado As New Label With {
        .Text = "Encarregado",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim cbx_encarregado As New ComboBox With {
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .DropDownStyle = ComboBoxStyle.DropDownList
    }
    Dim lbl_prioridade As New Label With {
        .Text = "Prioridade",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim WithEvents tkb_prioridade As New TrackBar With {
        .Maximum = 4,
        .LargeChange = 1,
        .Value = 2,
        .AutoSize = False,
        .Size = New Size(largura2, altura1)
    }
    Dim lbl_prioridadeValor As New Label With {
        .Text = "Normal",
        .Font = fonte,
        .Size = New Size(largura2, altura1),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Friend btn_notas As New Button With {
        .Size = New Size(largura1, altura3),
        .Padding = New Padding(0, 0, largura1 / 4 - 10, 0),
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleRight,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom
    }
    Dim btn_cancelar As New Button With{
        .Text = "Cancelar",
        .Font = fonte,
        .Size = New Size(largura1, altura3)
    }
    Dim btn_modificar As New Button With{
        .Text = "Editar",
        .Font = fonte,
        .Size = New Size(largura1, altura3)
    }
    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(largura1, altura3)
    }

    Dim demandaAtual As Demanda

    Friend Sub New()
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        classesAbertas.setAtualDetalhes(Me)
        Me.Text = "Cadastrar nova demanda"
        Me.Location = posicaoInicial1

        btn_salvar.Size = New Size(largura2, altura3)
        AddHandler btn_salvar.Click, AddressOf btn_salvar_Click

        ajusteComum3()
        cbx_estado.SelectedIndex = 0
        btn_salvar.Location = New Point(posicao, lbl_prioridadeValor.Location.Y + altura1 + 20)
        cbx_encarregado.SelectedItem = usuario.usuario_user

    End Sub
    Friend Sub New(ByRef _pk As Integer)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        Me.Text = "Detalhes da demanda"
        Me.Location = posicaoInicial2
        pk = _pk

        ajusteComum3()
        ajusteComum2()
    End Sub
    Friend Sub New(ByRef _demandaAtual As Demanda)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        classesAbertas.setAtualDetalhes(Me)
        Me.Text = "Detalhes da demanda"
        Me.Location = posicaoInicial1

        demandaAtual = _demandaAtual
        pk = demandaAtual.pk

        ajusteComum3()
        ajusteComum2()

    End Sub
    Private Sub ajusteComum2()
        btn_notas.Location = New Point(0, lbl_prioridadeValor.Location.Y + altura1 + 20)
        btn_cancelar.Location = New Point(0, lbl_prioridadeValor.Location.Y + altura1 + 20)
        btn_modificar.Location = New Point(largura1, lbl_prioridadeValor.Location.Y + altura1 + 20)
        btn_salvar.Location = New Point(largura1, lbl_prioridadeValor.Location.Y + altura1 + 20)

        'configurações específicas
        btn_salvar.Visible = False
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        cbx_encarregado.Enabled = False
        tkb_prioridade.Enabled = False
        btn_cancelar.Visible = False

        AddHandler btn_notas.Click, AddressOf btn_notas_Click
        AddHandler btn_cancelar.Click, AddressOf btn_cancelar_Click
        AddHandler btn_modificar.Click, AddressOf btn_modificar_Click
        AddHandler btn_salvar.Click, AddressOf btn_alterar_Click

        'adicionando controles ao panel
        panel.Controls.Add(btn_notas)
        panel.Controls.Add(btn_cancelar)
        panel.Controls.Add(btn_modificar)

        atualizarDados()
    End Sub
    Private Sub ajusteComum3()
        Me.ShowIcon = False

        'posição dos controles
        txt_titulo.Location = New Point(posicao, lbl_titulo.Location.Y + altura1)
        lbl_detalhes.Location = New Point(posicao, txt_titulo.Location.Y + altura1)
        txt_detalhes.Location = New Point(posicao, lbl_detalhes.Location.Y + altura1)
        lbl_previsao.Location = New Point(posicao, txt_detalhes.Location.Y + 50)
        cbx_previsao.Location = New Point(posicao + 248, txt_detalhes.Location.Y + 50)
        dtp_previsao.Location = New Point(posicao, cbx_previsao.Location.Y + altura1)
        lbl_semprevisao.Location = New Point(posicao, cbx_previsao.Location.Y + altura1)
        lbl_estado.Location = New Point(posicao, dtp_previsao.Location.Y + altura1)
        cbx_estado.Location = New Point(posicao, lbl_estado.Location.Y + altura1)

        lbl_encarregado.Location = New Point(posicao, cbx_estado.Location.Y + altura1)
        cbx_encarregado.Location = New Point(posicao, lbl_encarregado.Location.Y + altura1)
        lbl_prioridade.Location = New Point(posicao, cbx_encarregado.Location.Y + altura1)
        tkb_prioridade.Location = New Point(posicao, lbl_prioridade.Location.Y + altura1)
        lbl_prioridadeValor.Location = New Point(posicao, tkb_prioridade.Location.Y + altura1)

        cbx_estado.Items.AddRange({"Aguardando", "Em andamento", "Feito", "Descartado"})

        'carregando usuarios
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand
        consulta.CommandText = "select usuario_user from tb_usuario"
        conexao.Open()
        myReader = consulta.ExecuteReader()
        Do While myReader.Read()
            cbx_encarregado.Items.Add(myReader.GetString(0))
        Loop

        myReader.Close()
        conexao.Close()

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
        panel.Controls.Add(lbl_encarregado)
        panel.Controls.Add(cbx_encarregado)
        panel.Controls.Add(lbl_prioridade)
        panel.Controls.Add(tkb_prioridade)
        panel.Controls.Add(lbl_prioridadeValor)
        panel.Controls.Add(btn_salvar)

        Me.Controls.Add(panel)
    End Sub
    Private Sub atualizarDados()
        'extração de conteúdo do BD
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand
        consulta.CommandText = "select 
                                        demanda_id,
                                        demanda_titulo, 
                                        demanda_detalhes, 
                                        demanda_temprevisao, 
                                        demanda_previsao, 
                                        demanda_status,
                                        encarregado.usuario_user as demanda_encarregado,
                                        demanda_prioridade,
                                        (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                from tb_demanda 
								left join tb_usuario encarregado on tb_demanda.demanda_encarregado = encarregado.usuario_id
								where demanda_id = @id"

        consulta.Parameters.AddWithValue("@id", pk)
        consulta.Parameters.AddWithValue("@tabela", tabela)

        conexao.Open()
        myReader = consulta.ExecuteReader()
        myReader.Read()

        'conteudo dos controles extraido do BD
        pk = myReader.GetValue("demanda_id")
        txt_titulo.Text = If(myReader.IsDBNull("demanda_titulo"), "", myReader.GetString("demanda_titulo"))
        txt_detalhes.Text = If(myReader.IsDBNull("demanda_detalhes"), "", myReader.GetString("demanda_detalhes"))
        temprevisao = If(myReader.IsDBNull("demanda_temprevisao"), 0, myReader.GetValue("demanda_temprevisao"))
        If temprevisao > 0 Then
            lbl_semprevisao.Visible = False
            dtp_previsao.Visible = True
            cbx_previsao.Checked = True
        Else
            lbl_semprevisao.Visible = True
            dtp_previsao.Visible = False
            cbx_previsao.Checked = False
        End If
        dtp_previsao.Value = If(myReader.IsDBNull("demanda_previsao"), "", myReader.GetDateTime("demanda_previsao"))
        cbx_estado.SelectedIndex = If(myReader.IsDBNull("demanda_status"), 0, myReader.GetValue("demanda_status") - 1)
        cbx_encarregado.Text = If(myReader.IsDBNull("demanda_encarregado"), "", myReader.GetString("demanda_encarregado"))
        tkb_prioridade.Value = If(myReader.IsDBNull("demanda_prioridade"), 2, myReader.GetValue("demanda_prioridade") - 1)
        btn_notas.Text = Space(24) & myReader.GetValue("qtd_notas")

        myReader.Close()
        conexao.Close()
    End Sub
    Private Sub DetalhesDemanda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 490)
    End Sub
    Private Sub cbx_previsao_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_previsao.CheckedChanged
        If cbx_previsao.Checked Then
            lbl_semprevisao.Visible = False
            dtp_previsao.Visible = True
            dtp_previsao.Value = DateTime.Now
        ElseIf cbx_previsao.Checked = False Then
            lbl_semprevisao.Visible = True
            dtp_previsao.Visible = False
            dtp_previsao.Value = DateTime.Now.AddDays(30)
        End If
    End Sub
    Private Sub tkb_prioridade_ValueChanged(sender As Object, e As EventArgs) Handles tkb_prioridade.ValueChanged
        Select Case tkb_prioridade.Value
            Case 0
                lbl_prioridadeValor.Text = "Descartável"
            Case 1
                lbl_prioridadeValor.Text = "Baixa"
            Case 2
                lbl_prioridadeValor.Text = "Normal"
            Case 3
                lbl_prioridadeValor.Text = "Alta"
            Case 4
                lbl_prioridadeValor.Text = "Urgente"
        End Select

    End Sub

    Private Sub btn_notas_Click()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If Application.OpenForms.OfType(Of DemandaDetalhes).Any() Then
            Application.OpenForms.OfType(Of DemandaDetalhes).First().BringToFront()
        End If

        Dim notas = New listarNotas(pk, tabela, btn_notas)

        notas.Show()
    End Sub
    Private Sub btn_modificar_Click()
        Me.Text = "Editando demanda..."
        btn_notas.Visible = False
        btn_modificar.Visible = False
        btn_cancelar.Visible = True
        btn_salvar.Visible = True
        txt_titulo.ReadOnly = False
        txt_detalhes.ReadOnly = False
        cbx_previsao.Enabled = True
        dtp_previsao.Enabled = True
        cbx_estado.Enabled = True
        cbx_encarregado.Enabled = True
        tkb_prioridade.Enabled = True

    End Sub
    Private Sub btn_cancelar_Click()
        Me.Text = "Detalhes da demanda"
        btn_cancelar.Visible = False
        btn_salvar.Visible = False
        btn_notas.Visible = True
        btn_modificar.Visible = True
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        cbx_encarregado.Enabled = False
        tkb_prioridade.Enabled = False
        atualizarDados()

    End Sub
    Private Sub btn_alterar_Click()

        Me.Text = "Detalhes da demanda"
        btn_cancelar.Visible = False
        btn_salvar.Visible = False
        btn_notas.Visible = True
        btn_modificar.Visible = True
        txt_titulo.ReadOnly = True
        txt_detalhes.ReadOnly = True
        cbx_previsao.Enabled = False
        dtp_previsao.Enabled = False
        cbx_estado.Enabled = False
        cbx_encarregado.Enabled = False
        tkb_prioridade.Enabled = False

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_demanda SET 
                                demanda_dtalteracao = GETDATE(),
                                demanda_useralteracao = @useralteracao,
                                demanda_titulo = @titulo,
                                demanda_detalhes = @detalhes,
                                demanda_temprevisao = @temprevisao,
                                demanda_previsao = @previsao,
                                demanda_status = @status
                                WHERE demanda_id = @id"

            consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@titulo", txt_titulo.Text)
            consulta.Parameters.AddWithValue("@detalhes", txt_detalhes.Text)
            consulta.Parameters.AddWithValue("@temprevisao", If(cbx_previsao.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@previsao", dtp_previsao.Value)
            consulta.Parameters.AddWithValue("@status", cbx_estado.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()
            If demandaAtual IsNot Nothing Then
                demandaAtual.setDados(txt_titulo.Text, If(cbx_previsao.Checked, 1, 0), dtp_previsao.Value)
                demandaAtual.setEstado(cbx_estado.SelectedIndex + 1)
            End If

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar demanda: " & ex.Message, "Classe DemandaDetalhes")
        Finally
            conexao.Close()
        End Try

        atualizarDados()
    End Sub
    Private Sub btn_salvar_Click()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) 
                                    VALUES(
                                        @usercadastro,
                                        @titulo,
                                        @detalhes,
                                        @temprevisao,
                                        @previsao,
                                        @status,
                                        @encarregado,
                                        @prioridade)
                                    select scope_identity()"

            consulta.Parameters.AddWithValue("@usercadastro", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@titulo", txt_titulo.Text)
            consulta.Parameters.AddWithValue("@detalhes", txt_detalhes.Text)
            consulta.Parameters.AddWithValue("@temprevisao", If(cbx_previsao.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@previsao", dtp_previsao.Value)
            consulta.Parameters.AddWithValue("@status", cbx_estado.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@encarregado", cbx_encarregado.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@prioridade", tkb_prioridade.Value + 1)

            conexao.Open()

            myReader = consulta.ExecuteReader()
            myReader.Read()
            novoid = myReader.GetValue(0)

            classesAbertas.atualListaDemandas.MoverPanels()

            demandaAtual = New Demanda(classesAbertas.atualListaDemandas, novoid, txt_titulo.Text, If(cbx_previsao.Checked, 1, 0), dtp_previsao.Value, cbx_estado.SelectedIndex + 1, 0, 0)

            If Application.OpenForms.OfType(Of DemandaDetalhes).Any() Then
                Application.OpenForms.OfType(Of DemandaDetalhes).First().Close()
            End If

            Dim verDetalhes = New DemandaDetalhes(demandaAtual)
            verDetalhes.Show()
            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao Cadastrar Demanda: " & ex.Message, "Classe DemandaDetalhes")
        Finally
            conexao.Close()
        End Try
    End Sub
End Class