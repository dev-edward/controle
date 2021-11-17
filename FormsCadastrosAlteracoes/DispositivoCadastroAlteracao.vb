Imports System.Data.SqlClient
Public Class DispositivoCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim pk As Integer
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
        .Text = "Sistema Operacional: ",
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
        If classesAbertas.atualCadAltEventos IsNot Nothing Then
            classesAbertas.atualCadAltEventos.Close()
        End If
        classesAbertas.setAtualCadAltEventos(frm_dispositivo)

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
            MessageBox.Show("Erro ao Cadastrar dispositivo: " & ex.Message, "Classe DispositivoCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub notas()

    End Sub
    Private Sub editarCancelar()

    End Sub
    Private Sub alterar()

    End Sub
End Class
