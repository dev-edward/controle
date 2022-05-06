Imports System.Data.SqlClient
Public Class EstoqueCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(260, 26)
    Dim tamanhobtn As New Size(130, 40)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "estoque"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_estoque As New Form With {
        .Text = "Cadastrar novo item",
        .ClientSize = New Size(300, 440),
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
        .MaxLength = 20,
        .Location = New Point(lbl_nome.Location.X, lbl_nome.Location.Y + tamanholbl.Height)
    }
    Dim lbl_descricao As New Label With {
        .Text = "Descrição",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_nome.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_descricao As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 60,
        .Location = New Point(lbl_nome.Location.X, lbl_descricao.Location.Y + tamanholbl.Height)
    }
    Dim lbl_quantidade As New Label With {
        .Text = "Quantidade",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_descricao.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim nud_quantidade As New NumericUpDown With {
        .Font = fonte,
        .Size = New Size(234, 26),
        .Location = New Point(lbl_nome.Location.X, lbl_quantidade.Location.Y + tamanholbl.Height)
    }
    Dim lbl_localizacao As New Label With {
        .Text = "Localização",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, nud_quantidade.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_localizacao As New TextBox With {
        .Font = fonte,
        .Size = New Size(234, 26),
        .MaxLength = 40,
        .Location = New Point(lbl_nome.Location.X, lbl_localizacao.Location.Y + tamanholbl.Height)
    }
    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(lbl_nome.Location.X, txt_localizacao.Location.Y + tamanhobtn.Height)
    }
    Dim btn_notas As New Button With {
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .Size = tamanhobtn,
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(lbl_nome.Location.X, txt_localizacao.Location.Y + tamanhobtn.Height)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, txt_localizacao.Location.Y + tamanhobtn.Height)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, txt_localizacao.Location.Y + tamanhobtn.Height)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X, txt_localizacao.Location.Y + tamanhobtn.Height)
    }

    Friend Sub New()
        iniciar()
        frm_estoque.Controls.Add(btn_salvar)
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        pk = _pk
        iniciar()
        carregarDados()
        alternarReadOnly()
        frm_estoque.Controls.Add(btn_notas)
        frm_estoque.Controls.Add(btn_editar)
        frm_estoque.Controls.Add(btn_alterar)
        frm_estoque.Controls.Add(btn_cancelar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar
    End Sub
    Private Sub iniciar()
        classesAbertas.setAtualCadAltEmails(frm_estoque)

        AddHandler txt_nome.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_nome.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_nome.LostFocus, AddressOf txt_LostFocus
        AddHandler txt_descricao.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_descricao.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_descricao.LostFocus, AddressOf txt_LostFocus
        AddHandler txt_localizacao.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_localizacao.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_localizacao.LostFocus, AddressOf txt_LostFocus

        frm_estoque.Controls.Add(lbl_nome)
        frm_estoque.Controls.Add(txt_nome)
        frm_estoque.Controls.Add(lbl_descricao)
        frm_estoque.Controls.Add(txt_descricao)
        frm_estoque.Controls.Add(lbl_quantidade)
        frm_estoque.Controls.Add(nud_quantidade)
        frm_estoque.Controls.Add(lbl_localizacao)
        frm_estoque.Controls.Add(txt_localizacao)
        frm_estoque.Show()

    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select
                                        estoque_nome,
                                        estoque_descricao,
                                        estoque_quantidade,
                                        estoque_localizacao,
                                        (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                    from tb_estoque
                                    where estoque_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_nome.Text = If(myReader.IsDBNull("estoque_nome"), "", myReader.GetString("estoque_nome"))
            txt_descricao.Text = If(myReader.IsDBNull("estoque_descricao"), "", myReader.GetString("estoque_descricao"))
            nud_quantidade.Value = If(myReader.IsDBNull("estoque_quantidade"), "", myReader.GetValue("estoque_quantidade"))

            btn_notas.Text = If(myReader.GetValue("qtd_notas") > 0, myReader.GetValue("qtd_notas"), "")

            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar e-mail: " & ex.Message, "Classe EmailCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub editarCancelar()
        alternarReadOnly()
        carregarDados()
    End Sub
    Private Sub alternarReadOnly()
        frm_estoque.Text = If(frm_estoque.Text = "Detalhes do item", "Editando item...", "Detalhes do item")
        txt_nome.Enabled = Not txt_nome.Enabled
        txt_descricao.Enabled = Not txt_descricao.Enabled
        nud_quantidade.Enabled = Not nud_quantidade.Enabled
        txt_localizacao.Enabled = Not txt_localizacao.Enabled

    End Sub
    Private Sub notas()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If classesAbertas.atualCadAltEstoque IsNot Nothing Then
            classesAbertas.atualCadAltEstoque.BringToFront()
        End If

        Dim notas = New listarNotas(pk, tabela, btn_notas)

        notas.Show()
    End Sub
    Private Sub salvar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand

            consulta.CommandText = "insert into tb_estoque 
                                        (estoque_nome, estoque_descricao, estoque_quantidade, estoque_localizacao)
                                    VALUES(
                                        @nome,
                                        @descricao,
                                        @tag,
                                        @quantidade,
                                        localizacao
                                    )
                                    select SCOPE_IDENTITY()"

            consulta.Parameters.AddWithValue("@nome", txt_nome.Text)
            consulta.Parameters.AddWithValue("@descricao", txt_descricao.Text)
            consulta.Parameters.AddWithValue("@quantidade", nud_quantidade.Text)
            consulta.Parameters.AddWithValue("@localizacao", txt_localizacao.Text)

            conexao.Open()

            myReader = consulta.ExecuteReader()
            myReader.Read()
            novoid = myReader.GetValue(0)

            Dim verEstoque = New EstoqueCadastroAlteracao(novoid)
            myReader.Close()
        Catch ex As Exception
            MessageBox.Show("Erro ao Cadastrar item no estoque: " & ex.Message, "Classe EstoqueCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub alterar()
        alternarReadOnly()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_estoque SET
                                        estoque_nome = @nome,
                                        estoque_descricao = @descricao,
                                        estoque_quantidade = @quantidade,
                                        estoque_localizacao = @localizacao
                                    where estoque_id = @id"

            consulta.Parameters.AddWithValue("@nome", txt_nome.Text)
            consulta.Parameters.AddWithValue("@descricao", txt_descricao.Text)
            consulta.Parameters.AddWithValue("@quantidade", nud_quantidade.Value)
            consulta.Parameters.AddWithValue("@localizacao", nud_quantidade.Value)

            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar item no estoque: " & ex.Message, "Classe EstoqueCadastroAlteracao")
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
        frm_estoque.Controls.Add(lbl_maxchar)
        lbl_maxchar.BringToFront()
        If (sender.TextLength = 0) Then
            lbl_maxchar.Visible = False
        Else
            lbl_maxchar.Visible = True
        End If
    End Sub
    Private Sub txt_LostFocus(sender As Object, e As EventArgs)
        frm_estoque.Controls.Remove(lbl_maxchar)
    End Sub
End Class
