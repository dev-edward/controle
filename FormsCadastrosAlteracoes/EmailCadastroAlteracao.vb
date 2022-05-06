Imports System.Data.SqlClient
Public Class EmailCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(260, 26)
    Dim tamanhobtn As New Size(130, 40)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "email"

    Dim senhaVisivel As Boolean = False

    Dim grupos As New Dictionary(Of String, Integer)

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_email As New Form With {
        .Text = "Cadastrar novo email",
        .ClientSize = New Size(300, 390),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_nome As New Label With {
        .Text = "Nome",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(20, 10),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_nome As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 40,
        .Location = New Point(lbl_nome.Location.X, lbl_nome.Location.Y + tamanholbl.Height)
    }
    Dim lbl_setor As New Label With {
        .Text = "Setor",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_nome.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_setor As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 30,
        .Location = New Point(lbl_nome.Location.X, lbl_setor.Location.Y + tamanholbl.Height)
    }
    Dim lbl_email As New Label With {
        .Text = "E-mail",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_setor.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_email As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 40,
        .Location = New Point(lbl_nome.Location.X, lbl_email.Location.Y + tamanholbl.Height)
    }
    Dim lbl_senha As New Label With {
        .Text = "Senha",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_email.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_senha As New TextBox With {
        .Font = fonte,
        .Size = New Size(234, 26),
        .MaxLength = 20,
        .PasswordChar = "*",
        .Location = New Point(lbl_nome.Location.X, lbl_senha.Location.Y + tamanholbl.Height)
    }
    Dim btn_olho As New Button With {
        .Size = New Size(26, 26),
        .Location = New Point(txt_senha.Location.X + txt_senha.Width, txt_senha.Location.Y),
        .BackgroundImage = img.olho_fechado,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup
    }
    Dim lbl_estado As New Label With {
        .Text = "Estado",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_senha.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim rbt_estadoAtivo As New RadioButton With {
        .Text = "Ativo",
        .Size = New Size(100, 30),
        .Font = fonte,
        .Location = New Point(lbl_nome.Location.X + 50, lbl_estado.Location.Y + tamanholbl.Height)
    }
    Dim rbt_estadoInativo As New RadioButton With {
        .Text = "Inativo",
        .Size = New Size(150, 30),
        .Font = fonte,
        .Location = New Point(lbl_nome.Location.X + 160, lbl_estado.Location.Y + tamanholbl.Height)
    }
    Dim lbl_grupo As New Label With {
        .Text = "Grupo",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, rbt_estadoAtivo.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim cmb_grupo As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nome.Location.X, lbl_grupo.Location.Y + tamanholbl.Height)
    }

    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(lbl_nome.Location.X, cmb_grupo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_notas As New Button With {
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .Size = tamanhobtn,
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(lbl_nome.Location.X, cmb_grupo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, cmb_grupo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, cmb_grupo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X, cmb_grupo.Location.Y + tamanhobtn.Height)
    }

    Friend Sub New()
        iniciar()
        frm_email.Controls.Add(btn_salvar)
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        pk = _pk
        iniciar()
        carregarDados()
        alternarReadOnly()
        frm_email.Controls.Add(btn_notas)
        frm_email.Controls.Add(btn_editar)
        frm_email.Controls.Add(btn_alterar)
        frm_email.Controls.Add(btn_cancelar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar
    End Sub
    Private Sub iniciar()
        classesAbertas.setAtualCadAltEmails(frm_email)

        AddHandler txt_nome.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_nome.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_nome.LostFocus, AddressOf txt_LostFocus
        AddHandler txt_setor.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_setor.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_setor.LostFocus, AddressOf txt_LostFocus
        AddHandler txt_email.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_email.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_email.LostFocus, AddressOf txt_LostFocus
        AddHandler txt_senha.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_senha.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_senha.LostFocus, AddressOf txt_LostFocus

        AddHandler btn_olho.Click, AddressOf mostrarSenha

        'carregando grupos
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select valor_numero,valor_valor from meta_valor where valor_tabela='tb_email' and valor_coluna = 'email_grupo'"
            conexao.Open()
            myReader = consulta.ExecuteReader()
            Do While myReader.Read()
                grupos.Add(myReader.GetString("valor_valor"), myReader.GetValue("valor_numero"))
                cmb_grupo.Items.Add(grupos.Last.Key)
            Loop

            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Não foi possivel carregar lista de grupos: " & ex.Message, "Classe EmailCadastroAlteracao")
        Finally
            conexao.Close()
        End Try

        frm_email.Controls.Add(lbl_nome)
        frm_email.Controls.Add(txt_nome)
        frm_email.Controls.Add(lbl_setor)
        frm_email.Controls.Add(txt_setor)
        frm_email.Controls.Add(lbl_email)
        frm_email.Controls.Add(txt_email)
        frm_email.Controls.Add(lbl_senha)
        frm_email.Controls.Add(txt_senha)
        frm_email.Controls.Add(btn_olho)
        frm_email.Controls.Add(lbl_estado)
        frm_email.Controls.Add(rbt_estadoAtivo)
        frm_email.Controls.Add(rbt_estadoInativo)
        frm_email.Controls.Add(lbl_grupo)
        frm_email.Controls.Add(cmb_grupo)
        frm_email.Show()
    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select
                                        email_nome,
                                        email_setor,
                                        email_email,
                                        email_senha,
                                        email_estado,
                                        grupo.valor_valor as 'grupo',
                                        (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                    from tb_email
                                    left join meta_valor grupo
                                    on grupo.valor_tabela = 'tb_email'
                                    and grupo.valor_coluna = 'email_grupo'
                                    and tb_email.email_grupo = grupo.valor_numero
                                    where email_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_nome.Text = If(myReader.IsDBNull("email_nome"), "", myReader.GetString("email_nome"))
            txt_setor.Text = If(myReader.IsDBNull("email_setor"), "", myReader.GetString("email_setor"))
            txt_email.Text = If(myReader.IsDBNull("email_email"), "", myReader.GetString("email_email"))
            txt_senha.Text = If(myReader.IsDBNull("email_senha"), "", myReader.GetString("email_senha"))

            If (myReader.IsDBNull("email_estado")) Then
                rbt_estadoAtivo.Checked = False
                rbt_estadoInativo.Checked = False
            Else
                If (myReader.GetValue("email_estado") = 0) Then
                    rbt_estadoInativo.Checked = True
                ElseIf (myReader.GetValue("email_estado") = 1) Then
                    rbt_estadoAtivo.Checked = True
                End If
            End If

            cmb_grupo.SelectedItem = If(myReader.IsDBNull("grupo"), "", myReader.GetString("grupo"))

            btn_notas.Text = If(myReader.GetValue("qtd_notas") > 0, myReader.GetValue("qtd_notas"), "")

            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar e-mail: " & ex.Message, "Classe EmailCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub mostrarSenha()
        If senhaVisivel Then
            btn_olho.BackgroundImage = img.olho_fechado
            txt_senha.PasswordChar = "*"
        Else
            btn_olho.BackgroundImage = img.olho_aberto
            txt_senha.PasswordChar = ""
        End If
        senhaVisivel = Not senhaVisivel
    End Sub
    Private Sub editarCancelar()
        alternarReadOnly()
        carregarDados()
    End Sub
    Private Sub alternarReadOnly()
        frm_email.Text = If(frm_email.Text = "Detalhes do e-mail", "Editando e-mail...", "Detalhes do e-mail")
        txt_nome.Enabled = Not txt_nome.Enabled
        txt_setor.Enabled = Not txt_setor.Enabled
        txt_email.Enabled = Not txt_email.Enabled
        txt_senha.Enabled = Not txt_senha.Enabled
        rbt_estadoAtivo.Enabled = Not rbt_estadoAtivo.Enabled
        rbt_estadoInativo.Enabled = Not rbt_estadoInativo.Enabled
        cmb_grupo.Enabled = Not cmb_grupo.Enabled
        btn_notas.Visible = Not btn_notas.Visible
        btn_editar.Visible = Not btn_editar.Visible
        btn_alterar.Visible = Not btn_alterar.Visible
        btn_cancelar.Visible = Not btn_cancelar.Visible
    End Sub
    Private Sub notas()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If classesAbertas.atualCadAltEmails IsNot Nothing Then
            classesAbertas.atualCadAltEmails.BringToFront()
        End If

        Dim notas = New listarNotas(pk, tabela, btn_notas)

        notas.Show()
    End Sub
    Private Sub salvar()

        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "INSERT INTO tb_email(
	                                    email_nome,email_setor,email_email,email_senha,email_estado,email_grupo
                                    )
                                    VALUES(
	                                    @nome,
	                                    @setor,
	                                    @email,
	                                    @senha,
	                                    @estado,
	                                    @grupo
                                    )
                                    select SCOPE_IDENTITY()"

            consulta.Parameters.AddWithValue("@nome", txt_nome.Text)
            consulta.Parameters.AddWithValue("@setor", txt_setor.Text)
            consulta.Parameters.AddWithValue("@email", txt_email.Text)
            consulta.Parameters.AddWithValue("@senha", txt_senha.Text)

            If rbt_estadoAtivo.Checked Then
                consulta.Parameters.AddWithValue("@estado", 1)
            ElseIf rbt_estadoInativo.Checked Then
                consulta.Parameters.AddWithValue("@estado", 0)
            Else
                consulta.Parameters.AddWithValue("@estado", DBNull.Value)
            End If

            consulta.Parameters.AddWithValue("@grupo", If(cmb_grupo.SelectedItem IsNot Nothing, grupos.Item(cmb_grupo.SelectedItem), DBNull.Value))

            conexao.Open()

            myReader = consulta.ExecuteReader()
            myReader.Read()
            novoid = myReader.GetValue(0)

            Dim verEmail = New EmailCadastroAlteracao(novoid)
            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao Cadastrar E-mail: " & ex.Message, "Classe EmailCadastroAlteracao")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub alterar()
        alternarReadOnly()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_email SET
                                    email_nome = @nome,
                                    email_setor = @setor,
                                    email_email = @email,
                                    email_senha = @senha,
                                    email_estado = @estado,
                                    email_grupo = @grupo
                                    where email_id = @id"

            consulta.Parameters.AddWithValue("@nome", txt_nome.Text)
            consulta.Parameters.AddWithValue("@setor", txt_setor.Text)
            consulta.Parameters.AddWithValue("@email", txt_email.Text)
            consulta.Parameters.AddWithValue("@senha", txt_senha.Text)

            If rbt_estadoAtivo.Checked Then
                consulta.Parameters.AddWithValue("@estado", 1)
            ElseIf rbt_estadoInativo.Checked Then
                consulta.Parameters.AddWithValue("@estado", 0)
            Else
                consulta.Parameters.AddWithValue("@estado", DBNull.Value)
            End If

            consulta.Parameters.AddWithValue("@grupo", If(cmb_grupo.SelectedItem IsNot Nothing, grupos.Item(cmb_grupo.SelectedItem), DBNull.Value))
            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar e-mail: " & ex.Message, "Classe EmailCadastroAlteracao")
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
        lbl_maxchar.Text = "(" & sender.TextLength & "/" & sender.MaxLength & ")"
        lbl_maxchar.Location = New Point(sender.location.x + 6, sender.location.y + 24)
        frm_email.Controls.Add(lbl_maxchar)
        lbl_maxchar.BringToFront()
        If (sender.TextLength = 0) Then
            lbl_maxchar.Visible = False
        Else
            lbl_maxchar.Visible = True
        End If
    End Sub
    Private Sub txt_LostFocus(sender As Object, e As EventArgs)
        frm_email.Controls.Remove(lbl_maxchar)
    End Sub

End Class
