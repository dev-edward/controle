Imports System.Data.SqlClient
Public Class ImpressoraCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(160, 30)
    Dim tamanhobtn As New Size(160, 40)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "impressora"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_impressora As New Form With {
        .Text = "Cadastrar nova impressora",
        .ClientSize = New Size(340, 400),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_nserie As New Label With {
        .Text = "Número de série: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(5, 10)
    }
    Dim txt_nserie As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nserie.Location.Y),
        .MaxLength = 12
    }
    Dim lbl_nnota As New Label With {
        .Text = "Número da nota: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_nserie.Location.Y + tamanholbl.Height)
    }
    Dim txt_nnota As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nnota.Location.Y),
        .MaxLength = 16
    }
    Dim lbl_nproduto As New Label With {
        .Text = "Número do produto: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_nnota.Location.Y + tamanholbl.Height)
    }
    Dim txt_nproduto As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nproduto.Location.Y),
        .MaxLength = 16
    }
    Dim lbl_marcaModelo As New Label With {
        .Text = "Marca/Modelo: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_nproduto.Location.Y + tamanholbl.Height)
    }
    Dim txt_marcaModelo As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_marcaModelo.Location.Y),
        .MaxLength = 24
    }
    Dim lbl_suprimento As New Label With {
        .Text = "Suprimento: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_marcaModelo.Location.Y + tamanholbl.Height)
    }
    Dim cmb_suprimento As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_suprimento.Location.Y)
    }
    Dim lbl_ip As New Label With {
        .Text = "IP: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_suprimento.Location.Y + tamanholbl.Height)
    }
    Dim txt_ip As New MaskedTextBox With {
        .Size = New Size(140, 30),
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_ip.Location.Y),
        .Mask = "###.###.###.###"
    }
    Dim rbt_cor As New RadioButton With {
        .Text = "Colorido",
        .Size = New Size(100, 30),
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width / 2, lbl_ip.Location.Y + tamanholbl.Height)
    }
    Dim rbt_peb As New RadioButton With {
        .Text = "Preto & Branco",
        .Size = New Size(150, 30),
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width * 1.2, lbl_ip.Location.Y + tamanholbl.Height)
    }
    Dim lbl_local As New Label With {
        .Text = "Local: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, rbt_cor.Location.Y + tamanholbl.Height)
    }
    Dim cmb_local As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_local.Location.Y)
    }
    Dim lbl_estado As New Label With {
        .Text = "Estado: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_local.Location.Y + tamanholbl.Height)
    }
    Dim cmb_estado As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_estado.Location.Y)
    }
    Dim WithEvents cbx_dtentrada As New CheckBox With {
        .Text = "Data de entrada: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .CheckAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_estado.Location.Y + tamanholbl.Height)
    }
    Dim dtp_dtentrada As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, cbx_dtentrada.Location.Y)
    }
    Dim WithEvents cbx_dtsaida As New CheckBox With {
        .Text = "Data de saída: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .CheckAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, cbx_dtentrada.Location.Y + tamanholbl.Height)
    }
    Dim dtp_dtsaida As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, cbx_dtsaida.Location.Y)
    }


    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(320, 40),
        .Location = New Point(10, cbx_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_notas As New Button With {
        .Size = tamanhobtn,
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(10, cbx_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(170, cbx_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(170, cbx_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(10, cbx_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Friend Sub New()
        iniciar()
        frm_impressora.Controls.Add(btn_salvar)
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        pk = _pk
        iniciar()
        carregarDados()
        alternarReadOnly()
        frm_impressora.Controls.Add(btn_notas)
        frm_impressora.Controls.Add(btn_editar)
        frm_impressora.Controls.Add(btn_cancelar)
        frm_impressora.Controls.Add(btn_alterar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar
    End Sub
    Private Sub iniciar()
        If classesAbertas.atualCadAltImpressoras IsNot Nothing Then
            classesAbertas.atualCadAltImpressoras.Close()
        End If
        classesAbertas.setAtualCadAltImpressoras(frm_impressora)

        cmb_estado.Items.AddRange({"Ativo", "Inativo", "Devolvido"})

        'carregando suprimentos
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select estoque_nome from tb_estoque where estoque_tag = 'SuprimentoImpressora'"
            conexao.Open()
            myReader = consulta.ExecuteReader()
            Do While myReader.Read()
                cmb_suprimento.Items.Add(myReader.GetString(0))
            Loop

            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Não foi possivel carregar lista de suprimentos: " & ex.Message, "Classe ImpressoraCadastroAlteracao")
        Finally
            conexao.Close()
        End Try

        frm_impressora.Controls.Add(lbl_nserie)
        frm_impressora.Controls.Add(txt_nserie)
        frm_impressora.Controls.Add(lbl_nnota)
        frm_impressora.Controls.Add(txt_nnota)
        frm_impressora.Controls.Add(lbl_nproduto)
        frm_impressora.Controls.Add(txt_nproduto)
        frm_impressora.Controls.Add(lbl_marcaModelo)
        frm_impressora.Controls.Add(txt_marcaModelo)
        frm_impressora.Controls.Add(lbl_suprimento)
        frm_impressora.Controls.Add(cmb_suprimento)
        frm_impressora.Controls.Add(lbl_ip)
        frm_impressora.Controls.Add(txt_ip)
        frm_impressora.Controls.Add(rbt_cor)
        frm_impressora.Controls.Add(rbt_peb)
        frm_impressora.Controls.Add(lbl_local)
        frm_impressora.Controls.Add(cmb_local)
        frm_impressora.Controls.Add(lbl_estado)
        frm_impressora.Controls.Add(cmb_estado)
        frm_impressora.Controls.Add(cbx_dtentrada)
        frm_impressora.Controls.Add(dtp_dtentrada)
        frm_impressora.Controls.Add(cbx_dtsaida)
        frm_impressora.Controls.Add(dtp_dtsaida)

        frm_impressora.Show()

    End Sub
    Private Sub alternarReadOnly()
        frm_impressora.Text = If(frm_impressora.Text = "Detalhes da impressora", "Editando impressora...", "Detalhes da impressora")
        txt_nserie.ReadOnly = Not txt_nserie.ReadOnly
        txt_nnota.ReadOnly = Not txt_nnota.ReadOnly
        txt_nproduto.ReadOnly = Not txt_nproduto.ReadOnly
        txt_marcaModelo.ReadOnly = Not txt_marcaModelo.ReadOnly
        cmb_suprimento.Enabled = Not cmb_suprimento.Enabled
        txt_ip.Enabled = Not txt_ip.Enabled
        rbt_cor.Enabled = Not rbt_cor.Enabled
        rbt_peb.Enabled = Not rbt_peb.Enabled
        cmb_local.Enabled = Not cmb_local.Enabled
        cmb_estado.Enabled = Not cmb_estado.Enabled
        cbx_dtentrada.Enabled = Not cbx_dtentrada.Enabled
        dtp_dtentrada.Enabled = Not dtp_dtentrada.Enabled
        cbx_dtsaida.Enabled = Not cbx_dtsaida.Enabled
        dtp_dtsaida.Enabled = Not dtp_dtsaida.Enabled
        btn_notas.Visible = Not btn_notas.Visible
        btn_editar.Visible = Not btn_editar.Visible
        btn_alterar.Visible = Not btn_alterar.Visible
        btn_cancelar.Visible = Not btn_cancelar.Visible

    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select 
                                        impressora_id,
                                        impressora_nserie,
                                        impressora_nnota,
                                        impressora_nproduto,
                                        impressora_marcamodelo,
                                        tb_estoque.estoque_nome,
                                        case 
                                        when impressora_corimpressao = 0 then 0
                                        when impressora_corimpressao = 1 then 1
                                        end as 'impressora_corimpressao',
                                        tb_local.local_nome,
                                        impressora_estado,
                                        impressora_dtentrada,
                                        impressora_dtsaida,
                                        (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                    from tb_impressora
                                    left join tb_estoque on tb_impressora.impressora_suprimento = tb_estoque.estoque_id
                                    left join tb_local on tb_impressora.impressora_local = tb_local.local_id
                                    where impressora_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_nserie.Text = If(myReader.IsDBNull("impressora_nserie"), "", myReader.GetString("impressora_nserie"))
            txt_nnota.Text = If(myReader.IsDBNull("impressora_nnota"), "", myReader.GetString("impressora_nnota"))
            txt_nproduto.Text = If(myReader.IsDBNull("impressora_nproduto"), "", myReader.GetString("impressora_nproduto"))
            txt_marcaModelo.Text = If(myReader.IsDBNull("impressora_marcamodelo"), "", myReader.GetString("impressora_marcamodelo"))

            cmb_suprimento.SelectedItem = If(myReader.IsDBNull("estoque_nome"), "", myReader.GetString("estoque_nome"))
            If (myReader.IsDBNull("impressora_corimpressao")) Then
                rbt_cor.Checked = False
                rbt_peb.Checked = False
            Else
                If (myReader.GetValue("impressora_corimpressao") = 0) Then
                    rbt_peb.Checked = True
                ElseIf (myReader.GetValue("impressora_corimpressao") = 1) Then
                    rbt_cor.Checked = True
                End If
            End If
            cmb_local.SelectedItem = If(myReader.IsDBNull("local_nome"), "", myReader.GetString("local_nome"))
            cmb_estado.SelectedIndex = If(myReader.IsDBNull("impressora_estado"), 0, myReader.GetValue("impressora_estado") - 1)

            If (myReader.IsDBNull("impressora_dtentrada")) Then
                cbx_dtentrada.Checked = False
                dtp_dtentrada.Visible = False
            Else
                cbx_dtentrada.Checked = True
                dtp_dtentrada.Visible = True
                dtp_dtentrada.Value = myReader.GetDateTime("impressora_dtentrada")
            End If

            If (myReader.IsDBNull("impressora_dtsaida")) Then
                cbx_dtsaida.Checked = False
                dtp_dtsaida.Visible = False
            Else
                cbx_dtsaida.Checked = True
                dtp_dtsaida.Visible = True
                dtp_dtsaida.Value = myReader.GetDateTime("impressora_dtsaida")
            End If

            btn_notas.Text = If(myReader.GetValue("qtd_notas") > 0, myReader.GetValue("qtd_notas"), "")


            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar impressora: " & ex.Message, "Classe ImpressoraCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub cbx_dtentrada_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_dtentrada.CheckedChanged
        dtp_dtentrada.Visible = sender.checked
    End Sub
    Private Sub cbx_dtsaida_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_dtsaida.CheckedChanged
        dtp_dtsaida.Visible = sender.checked
    End Sub
    Private Sub salvar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "INSERT INTO tb_impressora(
                                        impressora_usercadastro,impressora_nserie,impressora_nnota,impressora_nproduto,impressora_marcamodelo,impressora_suprimento,impressora_ip,impressora_corimpressao,impressora_local,impressora_estado,impressora_dtentrada,impressora_dtsaida
                                    )
                                    VALUES(
                                        @usercadastro,
                                        @nserie,
                                        @nnota,
                                        @nproduto,
                                        @marcamodelo,
                                        (select estoque_id from tb_estoque where estoque_nome = @suprimento),
                                        @ip,
                                        @corimpressao,
                                        (select local_id from tb_local where local_nome = @local),
                                        @estado,
                                        @dtentrada,
                                        @dtsaida
                                    )
                                    select scope_identity()"

            consulta.Parameters.AddWithValue("@usercadastro", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@nserie", txt_nserie.Text)
            consulta.Parameters.AddWithValue("@nnota", txt_nnota.Text)
            consulta.Parameters.AddWithValue("@nproduto", txt_nproduto.Text)
            consulta.Parameters.AddWithValue("@marcamodelo", txt_marcaModelo.Text)
            consulta.Parameters.AddWithValue("@suprimento", cmb_suprimento.SelectedItem)
            consulta.Parameters.AddWithValue("@ip", txt_ip.Text)



            If rbt_cor.Checked Then
                consulta.Parameters.AddWithValue("@corimpressao", 1)
            ElseIf rbt_peb.Checked Then
                consulta.Parameters.AddWithValue("@corimpressao", 0)
            Else
                consulta.Parameters.AddWithValue("@corimpressao", Nothing)
            End If

            consulta.Parameters.AddWithValue("@local", cmb_local.SelectedItem)

            consulta.Parameters.AddWithValue("@local", cmb_local.Text)



            consulta.Parameters.AddWithValue("@frequencia", cmb_frequencia.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@allday", If(cbx_allday.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@ativo", If(cbx_ativo.Checked, 1, 0))

            conexao.Open()

            myReader = consulta.ExecuteReader()
            myReader.Read()
            novoid = myReader.GetValue(0)

            Dim verEvento = New EventoCadastroAlteracao(novoid)
            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao Cadastrar Evento: " & ex.Message, "Classe EventoCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub notas()

    End Sub
    Private Sub editarCancelar()
        alternarReadOnly()
        carregarDados()
    End Sub
    Private Sub alterar()

    End Sub
End Class
