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
    Dim lbl_dtentrada As New Label With {
        .Text = "Data de entrada: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_estado.Location.Y + tamanholbl.Height)
    }
    Dim dtp_dtentrada As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_dtentrada.Location.Y)
    }
    Dim lbl_dtsaida As New Label With {
        .Text = "Data de saída: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_dtentrada.Location.Y + tamanholbl.Height)
    }
    Dim dtp_dtsaida As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_dtsaida.Location.Y)
    }


    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(320, 40),
        .Location = New Point(10, lbl_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_notas As New Button With {
        .Size = tamanhobtn,
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(10, lbl_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(170, lbl_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(170, lbl_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(10, lbl_dtsaida.Location.Y + tamanholbl.Height + 10)
    }
    Friend Sub New()
        iniciar()
        frm_impressora.Controls.Add(btn_salvar)
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        iniciar()
        frm_impressora.Controls.Add(btn_notas)
        frm_impressora.Controls.Add(btn_editar)
        frm_impressora.Controls.Add(btn_cancelar)
        frm_impressora.Controls.Add(btn_alterar)
        alternarReadOnly()
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
        frm_impressora.Controls.Add(lbl_dtentrada)
        frm_impressora.Controls.Add(dtp_dtentrada)
        frm_impressora.Controls.Add(lbl_dtsaida)
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
        dtp_dtentrada.Enabled = Not dtp_dtentrada.Enabled
        dtp_dtsaida.Enabled = Not dtp_dtsaida.Enabled
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
                                        end,
                                        tb_local.local_nome,
                                        case
                                        when impressora_estado = 1 then 'Ativo'
                                        when impressora_estado = 2 then 'Inativo'
                                        when impressora_estado = 3 then 'Devolvido'
                                        end,
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


            txt_descricao.Text = myReader.GetString("evento_descricao")
            dtp_data.Value = myReader.GetDateTime("evento_datahora")
            cmb_frequencia.SelectedIndex = myReader.GetValue("evento_frequencia") - 1
            cbx_ativo.Checked = If(myReader.IsDBNull("evento_ativo"), 0, myReader.GetValue("evento_ativo"))
            cbx_allday.Checked = If(myReader.IsDBNull("evento_allday"), 0, myReader.GetValue("evento_allday"))
            btn_notas.Text = Space(24) & myReader.GetValue("qtd_notas")



            If cbx_allday.Checked Then
                dtp_data.CustomFormat = "dd/MM/yyyy"
            Else
                dtp_data.CustomFormat = "dd/MM/yyyy HH:mm"
            End If


            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar impressora: " & ex.Message, "Classe ImpressoraCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub salvar()

    End Sub
End Class
