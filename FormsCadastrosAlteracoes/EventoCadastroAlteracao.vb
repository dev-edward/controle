Imports System.Data.SqlClient
Public Class EventoCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanho As New Size(260, 30)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "evento"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_evento As New Form With {
        .Text = "Cadastrar novo evento",
        .ClientSize = New Size(320, 300),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_descricao As New Label With {
        .Text = "Descrição do evento",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim txt_descricao As New TextBox With {
        .Size = tamanho,
        .Font = fonte,
        .Location = New Point(29, 40),
        .MaxLength = 128
    }
    Dim lbl_data As New Label With {
        .Text = "Data e horario do evento",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 70)
    }
    Dim dtp_data As New DateTimePicker With {
        .Size = tamanho,
        .Font = fonte,
        .Format = DateTimePickerFormat.Custom,
        .CustomFormat = "dd/MM/yyyy HH:mm",
        .Location = New Point(29, 100)
    }
    Dim lbl_frequencia As New Label With {
        .Text = "Frequência",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 130)
    }
    Dim cmb_frequencia As New ComboBox With {
        .Font = fonte,
        .Size = tamanho,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(29, 160)
    }
    Dim WithEvents cbx_allday As New CheckBox With {
        .Text = "Qualquer horario",
        .Font = fonte,
        .Size = New Size(180, 30),
        .Location = New Point(29, 190),
        .CheckAlign = ContentAlignment.MiddleLeft,
        .TextAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat
    }
    Dim cbx_ativo As New CheckBox With {
        .Text = "Ativo",
        .Font = fonte,
        .Size = New Size(80, 30),
        .Location = New Point(210, 190),
        .CheckAlign = ContentAlignment.MiddleLeft,
        .TextAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat,
        .Checked = True
    }
    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(30, 250)
    }
    Dim btn_notas As New Button With {
        .Size = New Size(130, 40),
        .Location = New Point(30, 250),
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleRight,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = New Size(130, 40),
        .Location = New Point(160, 250),
        .Visible = False
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = New Size(130, 40),
        .Location = New Point(160, 250)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(130, 40),
        .Location = New Point(30, 250)
    }
    Friend Sub New()
        carregarControles()
        frm_evento.Controls.Add(btn_salvar)
        cmb_frequencia.SelectedIndex = 0
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        pk = _pk
        alternarReadOnly()
        carregarControles()
        carregarDados()
        frm_evento.Controls.Add(btn_notas)
        frm_evento.Controls.Add(btn_editar)
        frm_evento.Controls.Add(btn_cancelar)
        frm_evento.Controls.Add(btn_alterar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar


    End Sub
    Private Sub carregarControles()
        If classesAbertas.atualCadAltEventos IsNot Nothing Then
            classesAbertas.atualCadAltEventos.Close()
        End If
        classesAbertas.setAtualCadAltEventos(frm_evento)

        AddHandler txt_descricao.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_descricao.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_descricao.LostFocus, AddressOf txt_LostFocus

        cmb_frequencia.Items.AddRange({"Uma vez", "Diário", "Semanal", "Mensal", "Anual"})
        frm_evento.Controls.Add(lbl_descricao)
        frm_evento.Controls.Add(txt_descricao)
        frm_evento.Controls.Add(lbl_data)
        frm_evento.Controls.Add(dtp_data)
        frm_evento.Controls.Add(lbl_frequencia)
        frm_evento.Controls.Add(cmb_frequencia)
        frm_evento.Controls.Add(cbx_allday)
        frm_evento.Controls.Add(cbx_ativo)
        frm_evento.Show()
    End Sub
    Private Sub cbx_allday_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_allday.CheckedChanged
        If cbx_allday.Checked Then
            dtp_data.CustomFormat = "dd/MM/yyyy"
        Else
            dtp_data.CustomFormat = "dd/MM/yyyy HH:mm"
        End If
    End Sub
    Private Sub alternarReadOnly()
        frm_evento.Text = If(frm_evento.Text = "Detalhes do evento", "Editando evento...", "Detalhes do evento")
        txt_descricao.ReadOnly = Not txt_descricao.ReadOnly
        dtp_data.Enabled = Not dtp_data.Enabled
        cmb_frequencia.Enabled = Not cmb_frequencia.Enabled
        cbx_allday.Enabled = Not cbx_allday.Enabled
        cbx_ativo.Enabled = Not cbx_ativo.Enabled
        btn_notas.Visible = Not btn_notas.Visible
        btn_editar.Visible = Not btn_editar.Visible
        btn_cancelar.Visible = Not btn_cancelar.Visible
        btn_alterar.Visible = Not btn_alterar.Visible
    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select 
                                        evento_id,
                                        evento_descricao, 
                                        evento_datahora, 
                                        evento_frequencia, 
                                        evento_allday, 
                                        evento_ativo,
		                                (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                from tb_evento 
								where evento_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_descricao.Text = myReader.GetString("evento_descricao")
            dtp_data.Value = myReader.GetDateTime("evento_datahora")
            cmb_frequencia.SelectedIndex = myReader.GetValue("evento_frequencia") - 1
            cbx_ativo.Checked = If(myReader.IsDBNull("evento_ativo"), 0, myReader.GetValue("evento_ativo"))
            cbx_allday.Checked = If(myReader.IsDBNull("evento_allday"), 0, myReader.GetValue("evento_allday"))
            btn_notas.Text = If(myReader.GetValue("qtd_notas") > 0, myReader.GetValue("qtd_notas"), "")

            If cbx_allday.Checked Then
                dtp_data.CustomFormat = "dd/MM/yyyy"
            Else
                dtp_data.CustomFormat = "dd/MM/yyyy HH:mm"
            End If


            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar evento: " & ex.Message, "Classe EventoCadastroAlteração")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub salvar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "insert into tb_evento(evento_usercadastro,evento_descricao,evento_datahora,evento_frequencia,evento_allday,evento_ativo)
                                    values(
                                        @usercadastro,
                                        @descricao,
                                        @datahora,
                                        @frequencia,
                                        @allday,
                                        @ativo
                                    )
                                    select scope_identity()"

            consulta.Parameters.AddWithValue("@usercadastro", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@descricao", txt_descricao.Text)
            consulta.Parameters.AddWithValue("@datahora", dtp_data.Value)
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
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If classesAbertas.atualCadAltEventos IsNot Nothing Then
            classesAbertas.atualCadAltEventos.BringToFront()
        End If

        Dim notas = New listarNotas(pk, tabela, btn_notas)

        notas.Show()
    End Sub
    Private Sub editarCancelar()
        alternarReadOnly()
        carregarDados()
    End Sub
    Private Sub alterar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "update tb_evento set 
                                    evento_dtalteracao = GETDATE(),
                                    evento_useralteracao = @useralteracao,
                                    evento_descricao = @descricao,
                                    evento_datahora = @datahora,
                                    evento_frequencia = @frequencia,
                                    evento_allday = @allday,
                                    evento_ativo = @ativo
                                    where evento_id = @id"

            consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@descricao", txt_descricao.Text)
            consulta.Parameters.AddWithValue("@datahora", dtp_data.Value)
            consulta.Parameters.AddWithValue("@frequencia", cmb_frequencia.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@allday", If(cbx_allday.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@ativo", If(cbx_ativo.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar evento: " & ex.Message, "Classe DemandaDetalhes")
        Finally
            conexao.Close()
        End Try

        carregarDados()
    End Sub
    Private Sub txt_KeyUp(sender As Object, e As EventArgs)
        lbl_maxchar.Text = "(" & sender.TextLength & "/" & sender.MaxLength & ")"
        If (sender.TextLength > 0 And Not lbl_maxchar.Visible) Then
            lbl_maxchar.Visible = True
        End If
    End Sub
    Private Sub txt_GotFocus(sender As Object, e As EventArgs)
        lbl_maxchar.Location = New Point(sender.location.x + 6, sender.location.y - 16)
        frm_evento.Controls.Add(lbl_maxchar)
        lbl_maxchar.BringToFront()
        If (sender.TextLength = 0) Then
            lbl_maxchar.Visible = False
        End If
    End Sub
    Private Sub txt_LostFocus(sender As Object, e As EventArgs)
        frm_evento.Controls.Remove(lbl_maxchar)
    End Sub
End Class
