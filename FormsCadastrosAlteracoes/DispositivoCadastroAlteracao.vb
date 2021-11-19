Imports System.Data.SqlClient
Public Class DispositivoCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim pk As Integer
    Const tabela As String = "dispositivo"
    Dim tamanholbl As New Size(170, 30)
    Dim fonte As New Font("Microsoft Sans Serif", 11)

    Dim frm_dispositivo As New Form With {
        .Text = "Cadastrar dispositivo",
        .ClientSize = New Size(420, 400),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_tipo As New Label With {
        .Text = "Tipo de dispositivo: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(12, 12)
    }
    Dim cmb_tipo As New ComboBox With {
        .Font = fonte,
        .Size = New Size(120, 30),
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_tipo.Location.Y)
    }
    Dim cbx_posto As New CheckBox With {
        .Text = "É de posto informático",
        .Font = fonte,
        .Size = New Size(200, 30),
        .CheckAlign = ContentAlignment.MiddleLeft,
        .TextAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width / 2, lbl_tipo.Location.Y + tamanholbl.Height)
    }
    Dim lbl_marcaModelo As New Label With {
        .Text = "Marca/Modelo: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, cbx_posto.Location.Y + tamanholbl.Height)
    }
    Dim txt_marcaModelo As New TextBox With {
        .Size = New Size(170, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_marcaModelo.Location.Y)
    }
    Dim lbl_hostname As New Label With {
        .Text = "Hostname: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_marcaModelo.Location.Y + tamanholbl.Height)
    }
    Dim txt_hostname As New TextBox With {
        .Size = New Size(200, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_hostname.Location.Y)
    }
    Dim lbl_ip As New Label With {
        .Text = "IP: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_hostname.Location.Y + tamanholbl.Height)
    }
    Dim txt_ip As New TextBox With {
        .Size = New Size(160, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_ip.Location.Y)
    }
    Dim lbl_mac As New Label With {
        .Text = "Mac Adress: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_ip.Location.Y + tamanholbl.Height)
    }
    Dim txt_mac As New TextBox With {
        .Size = New Size(180, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_mac.Location.Y)
    }
    Dim lbl_os As New Label With {
        .Text = "Sistema Operacional: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_mac.Location.Y + tamanholbl.Height)
    }
    Dim txt_os As New TextBox With {
        .Size = New Size(200, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_os.Location.Y)
    }
    Dim lbl_ram As New Label With {
        .Text = "Memória ram em GB: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_os.Location.Y + tamanholbl.Height)
    }
    Dim nud_ram As New NumericUpDown With {
        .Font = fonte,
        .Maximum = 64,
        .Size = New Size(60, 30),
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_ram.Location.Y)
    }
    Dim lbl_processador As New Label With {
        .Text = "Processador: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_ram.Location.Y + tamanholbl.Height)
    }
    Dim txt_processador As New TextBox With {
        .Size = New Size(200, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_processador.Location.Y)
    }
    Dim lbl_armazenamento As New Label With {
        .Text = "Armazenamento: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_processador.Location.Y + tamanholbl.Height)
    }
    Dim txt_armazenamento As New TextBox With {
        .Size = New Size(160, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_armazenamento.Location.Y)
    }
    Dim lbl_bateria As New Label With {
        .Text = "Bateria: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_tipo.Location.X, lbl_armazenamento.Location.Y + tamanholbl.Height)
    }
    Dim txt_bateria As New TextBox With {
        .Size = New Size(180, 30),
        .Font = fonte,
        .Location = New Point(lbl_tipo.Location.X + tamanholbl.Width, lbl_bateria.Location.Y)
    }
    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(320, 40),
        .Location = New Point(45, txt_bateria.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_notas As New Button With {
        .Text = "                        1",
        .Size = New Size(160, 40),
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(45, txt_bateria.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = New Size(160, 40),
        .Visible = False,
        .Location = New Point(205, txt_bateria.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = New Size(160, 40),
        .Location = New Point(205, txt_bateria.Location.Y + tamanholbl.Height + 10)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(160, 40),
        .Location = New Point(45, txt_bateria.Location.Y + tamanholbl.Height + 10)
    }

    Friend Sub New()

        carregarControles()
        frm_dispositivo.Controls.Add(btn_salvar)
        cmb_tipo.SelectedIndex = 0
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)

        pk = _pk
        carregarControles()
        alternarReadOnly()
        carregarDados()
        frm_dispositivo.Controls.Add(btn_notas)
        frm_dispositivo.Controls.Add(btn_editar)
        frm_dispositivo.Controls.Add(btn_alterar)
        frm_dispositivo.Controls.Add(btn_cancelar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar
    End Sub
    Private Sub carregarControles()
        If classesAbertas.atualCadAltDispositivos IsNot Nothing Then
            classesAbertas.atualCadAltDispositivos.Close()
        End If
        classesAbertas.setAtualCadAltDispositivos(frm_dispositivo)

        cmb_tipo.Items.AddRange({"Computador", "Notebook", "Chromebook", "Tablet", "Celular"})
        frm_dispositivo.Controls.Add(lbl_tipo)
        frm_dispositivo.Controls.Add(cmb_tipo)
        frm_dispositivo.Controls.Add(cbx_posto)
        frm_dispositivo.Controls.Add(lbl_marcaModelo)
        frm_dispositivo.Controls.Add(txt_marcaModelo)
        frm_dispositivo.Controls.Add(lbl_hostname)
        frm_dispositivo.Controls.Add(txt_hostname)
        frm_dispositivo.Controls.Add(lbl_ip)
        frm_dispositivo.Controls.Add(txt_ip)
        frm_dispositivo.Controls.Add(lbl_mac)
        frm_dispositivo.Controls.Add(txt_mac)
        frm_dispositivo.Controls.Add(lbl_os)
        frm_dispositivo.Controls.Add(txt_os)
        frm_dispositivo.Controls.Add(lbl_ram)
        frm_dispositivo.Controls.Add(nud_ram)
        frm_dispositivo.Controls.Add(lbl_processador)
        frm_dispositivo.Controls.Add(txt_processador)
        frm_dispositivo.Controls.Add(lbl_armazenamento)
        frm_dispositivo.Controls.Add(txt_armazenamento)
        frm_dispositivo.Controls.Add(lbl_bateria)
        frm_dispositivo.Controls.Add(txt_bateria)
        frm_dispositivo.Show()

    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select 
                                        dispositivo_tipo,
                                        dispositivo_posto, 
                                        dispositivo_marcamodelo, 
                                        dispositivo_hostname, 
                                        dispositivo_ip, 
                                        dispositivo_macadress,
                                        dispositivo_os,
                                        dispositivo_qtdmemoriaram,
                                        dispositivo_processador,
                                        dispositivo_armazenamento,
                                        dispositivo_bateria,
	                                    (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                    from tb_dispositivo 
                                    where dispositivo_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            cmb_tipo.SelectedIndex = If(myReader.IsDBNull("dispositivo_tipo"), "", myReader.GetValue("dispositivo_tipo") - 1)
            cbx_posto.Checked = If(myReader.IsDBNull("dispositivo_posto"), 0, myReader.GetValue("dispositivo_posto"))
            txt_marcaModelo.Text = If(myReader.IsDBNull("dispositivo_marcamodelo"), "", myReader.GetString("dispositivo_marcamodelo"))
            txt_hostname.Text = If(myReader.IsDBNull("dispositivo_hostname"), "", myReader.GetString("dispositivo_hostname"))
            txt_ip.Text = If(myReader.IsDBNull("dispositivo_ip"), "", myReader.GetString("dispositivo_ip"))
            txt_mac.Text = If(myReader.IsDBNull("dispositivo_macadress"), "", myReader.GetString("dispositivo_macadress"))
            txt_os.Text = If(myReader.IsDBNull("dispositivo_os"), "", myReader.GetString("dispositivo_os"))
            nud_ram.Value = If(myReader.IsDBNull("dispositivo_qtdmemoriaram"), 0, myReader.GetValue("dispositivo_qtdmemoriaram"))
            txt_processador.Text = If(myReader.IsDBNull("dispositivo_processador"), "", myReader.GetString("dispositivo_processador"))
            txt_armazenamento.Text = If(myReader.IsDBNull("dispositivo_armazenamento"), "", myReader.GetString("dispositivo_armazenamento"))
            txt_bateria.Text = If(myReader.IsDBNull("dispositivo_bateria"), "", myReader.GetString("dispositivo_bateria"))
            btn_notas.Text = Space(24) & myReader.GetValue("qtd_notas")

            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar Dispositivo: " & ex.Message, "Classe DispositivoCadastroAlteração")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub alternarReadOnly()
        cmb_tipo.Enabled = Not cmb_tipo.Enabled
        cbx_posto.Enabled = Not cbx_posto.Enabled
        txt_marcaModelo.ReadOnly = Not txt_marcaModelo.ReadOnly
        txt_hostname.ReadOnly = Not txt_hostname.ReadOnly
        txt_ip.ReadOnly = Not txt_ip.ReadOnly
        txt_mac.ReadOnly = Not txt_mac.ReadOnly
        txt_os.ReadOnly = Not txt_os.ReadOnly
        nud_ram.Enabled = Not nud_ram.Enabled
        txt_processador.ReadOnly = Not txt_processador.ReadOnly
        txt_armazenamento.ReadOnly = Not txt_armazenamento.ReadOnly
        txt_bateria.ReadOnly = Not txt_bateria.ReadOnly
        btn_notas.Visible = Not btn_notas.Visible
        btn_editar.Visible = Not btn_editar.Visible
        btn_cancelar.Visible = Not btn_cancelar.Visible
        btn_alterar.Visible = Not btn_alterar.Visible
    End Sub
    Private Sub salvar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "INSERT INTO tb_dispositivo(dispositivo_usercadastro,dispositivo_tipo,dispositivo_posto,dispositivo_marcamodelo,dispositivo_hostname,dispositivo_ip,dispositivo_macadress,dispositivo_os,dispositivo_qtdmemoriaram,dispositivo_processador,dispositivo_armazenamento,dispositivo_bateria)
                                    VALUES(
                                        @usercadastro,
                                        @tipo,
                                        @posto,
                                        @marcamodelo,
                                        @hostname,
                                        @ip,
                                        @macadress,
                                        @os,
                                        @qtdmemoriaram,
                                        @processador,
                                        @armazenamento,
                                        @bateria
                                    )
                                    select scope_identity()"

            consulta.Parameters.AddWithValue("@usercadastro", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@tipo", cmb_tipo.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@posto", If(cbx_posto.Checked, 1, 0))
            consulta.Parameters.AddWithValue("@marcamodelo", txt_marcaModelo.Text)
            consulta.Parameters.AddWithValue("@hostname", txt_hostname.Text)
            consulta.Parameters.AddWithValue("@ip", txt_ip.Text)
            consulta.Parameters.AddWithValue("@macadress", txt_mac.Text)
            consulta.Parameters.AddWithValue("@os", txt_os.Text)
            consulta.Parameters.AddWithValue("@qtdmemoriaram", nud_ram.Value)
            consulta.Parameters.AddWithValue("@processador", txt_processador.Text)
            consulta.Parameters.AddWithValue("@armazenamento",txt_armazenamento.Text)
            consulta.Parameters.AddWithValue("@bateria", txt_bateria.Text)

            conexao.Open()

            myReader = consulta.ExecuteReader()
            myReader.Read()
            novoid = myReader.GetValue(0)

            myReader.Close()
            Dim verDispositivo = New DispositivoCadastroAlteracao(novoid)
        Catch ex As Exception
            MessageBox.Show("Erro ao cadastrar dispositivo: " & ex.Message, "Classe DispositivoCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub notas()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If classesAbertas.atualCadAltDispositivos IsNot Nothing Then
            classesAbertas.atualCadAltDispositivos.BringToFront()
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
            consulta.CommandText = "UPDATE tb_dispositivo SET
                                    dispositivo_dtalteracao = GETDATE(),
                                    dispositivo_useralteracao = @useralteracao,
                                    dispositivo_tipo = @tipo,
                                    dispositivo_posto = @posto,
                                    dispositivo_marcamodelo = @marcamodelo,
                                    dispositivo_hostname = @hostname,
                                    dispositivo_ip = @ip
                                    dispositivo_macadress = @macadress,
                                    dispositivo_os = @os,
                                    dispositivo_qtdmemoriaram = @qtdmemoriaram,
                                    dispositivo_processador = @processador,
                                    dispositivo_armazenamento = @armazenamento,
                                    dispositivo_bateria = @bateria
                                    where dispositivo_id = @id"

            consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@tipo", cmb_tipo.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@posto", cbx_posto.Checked)
            consulta.Parameters.AddWithValue("@marcamodelo", txt_marcaModelo.Text)
            consulta.Parameters.AddWithValue("@hostname", txt_hostname.Text)
            consulta.Parameters.AddWithValue("@ip", txt_ip.Text)
            consulta.Parameters.AddWithValue("@macadress", txt_mac.Text)
            consulta.Parameters.AddWithValue("@os", txt_os.Text)
            consulta.Parameters.AddWithValue("@qtdmemoriaram", nud_ram.Value)
            consulta.Parameters.AddWithValue("@processador", txt_processador.Text)
            consulta.Parameters.AddWithValue("@armazenamento", txt_armazenamento.Text)
            consulta.Parameters.AddWithValue("@bateria", txt_bateria.Text)
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
End Class
