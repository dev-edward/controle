Imports System.Data.SqlClient
Public Class TelefoneCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(260, 26)
    Dim tamanhobtn As New Size(130, 40)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "telefone"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_telefone As New Form With {
        .Text = "Cadastrar nova impressora",
        .ClientSize = New Size(300, 340),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_numero As New Label With {
        .Text = "Número",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(20, 10),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_numero As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 16,
        .Location = New Point(lbl_numero.Location.X, lbl_numero.Location.Y + tamanholbl.Height)
    }
    Dim lbl_pessoa As New Label With {
        .Text = "Pessoa",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_numero.Location.X, txt_numero.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_pessoa As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 30,
        .Location = New Point(lbl_numero.Location.X, lbl_pessoa.Location.Y + tamanholbl.Height)
    }
    Dim lbl_local As New Label With {
        .Text = "Local",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_numero.Location.X, txt_pessoa.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_local As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 30,
        .Location = New Point(lbl_numero.Location.X, lbl_local.Location.Y + tamanholbl.Height)
    }
    Dim lbl_tipo As New Label With {
        .Text = "Tipo",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_numero.Location.X, txt_local.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim cmb_tipo As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_numero.Location.X, lbl_tipo.Location.Y + tamanholbl.Height)
    }

    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(lbl_numero.Location.X, cmb_tipo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_notas As New Button With {
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .Size = tamanhobtn,
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(lbl_numero.Location.X, cmb_tipo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(lbl_numero.Location.X + tamanhobtn.Width, cmb_tipo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_numero.Location.X + tamanhobtn.Width, cmb_tipo.Location.Y + tamanhobtn.Height)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(160, 40),
        .Location = New Point(lbl_numero.Location.X, cmb_tipo.Location.Y + tamanhobtn.Height)
    }
    Friend Sub New()
        iniciar()
        frm_telefone.Controls.Add(btn_salvar)
        AddHandler btn_salvar.Click, AddressOf salvar
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        pk = _pk
        iniciar()
        carregarDados()
        alternarReadOnly()
        frm_telefone.Controls.Add(btn_notas)
        frm_telefone.Controls.Add(btn_editar)
        frm_telefone.Controls.Add(btn_alterar)
        frm_telefone.Controls.Add(btn_cancelar)
        AddHandler btn_notas.Click, AddressOf notas
        AddHandler btn_editar.Click, AddressOf editarCancelar
        AddHandler btn_cancelar.Click, AddressOf editarCancelar
        AddHandler btn_alterar.Click, AddressOf alterar
    End Sub
    Private Sub iniciar()
        classesAbertas.setAtualCadAltTelefones(frm_telefone)

        frm_telefone.Controls.Add(lbl_numero)
        frm_telefone.Controls.Add(txt_numero)
        frm_telefone.Controls.Add(lbl_pessoa)
        frm_telefone.Controls.Add(txt_pessoa)
        frm_telefone.Controls.Add(lbl_local)
        frm_telefone.Controls.Add(txt_local)
        frm_telefone.Controls.Add(lbl_tipo)
        frm_telefone.Controls.Add(cmb_tipo)
        frm_telefone.Show()
    End Sub
    Private Sub alternarReadOnly()
        frm_telefone.Text = If(frm_telefone.Text = "Detalhes do telefone", "Editando telefone...", "Detalhes do telefone")
        txt_numero.ReadOnly = Not txt_numero.ReadOnly
        txt_pessoa.ReadOnly = Not txt_pessoa.ReadOnly
        txt_local.ReadOnly = Not txt_local.ReadOnly
        cmb_tipo.Enabled = Not cmb_tipo.Enabled
        btn_notas.Visible = Not btn_notas.Visible
        btn_editar.Visible = Not btn_editar.Visible
        btn_cancelar.Visible = Not btn_cancelar.Visible
        btn_alterar.Visible = Not btn_alterar.Visible
    End Sub
    Private Sub notas()
        If Application.OpenForms.OfType(Of listarNotas).Any() Then
            Application.OpenForms.OfType(Of listarNotas).First().Close()
        End If
        If classesAbertas.atualCadAltTelefones IsNot Nothing Then
            classesAbertas.atualCadAltTelefones.BringToFront()
        End If

        Dim notas = New listarNotas(pk, tabela, btn_notas)

        notas.Show()
    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select
                                        telefone_numero,
                                        telefone_pessoa,
                                        telefone_local,
                                        meta_valor.valor_valor as 'tipo',
                                        (select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
                                    from tb_telefone
                                    left join meta_valor on tb_telefone.telefone_tipo = meta_valor.valor_numero
                                    and meta_valor.valor_tabela = 'tb_telefone' 
                                    and meta_valor.valor_coluna = 'telefone_tipo'
                                    where telefone_id = @id"

            consulta.Parameters.AddWithValue("@id", pk)
            consulta.Parameters.AddWithValue("@tabela", tabela)

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_numero.Text = If(myReader.IsDBNull("telefone_numero"), "", myReader.GetString("telefone_numero"))
            txt_pessoa.Text = If(myReader.IsDBNull("telefone_pessoa"), "", myReader.GetString("telefone_pessoa"))
            txt_local.Text = myReader.GetString("telefone_local")
            cmb_tipo.SelectedItem = If(myReader.IsDBNull("tipo"), "", myReader.GetString("tipo"))

            btn_notas.Text = If(myReader.GetValue("qtd_notas") > 0, myReader.GetValue("qtd_notas"), "")

            myReader.Close()

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar impressora: " & ex.Message, "Classe TelefoneCadastroAlteracao")
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub salvar()

    End Sub
    Private Sub alterar()

    End Sub
    Private Sub editarCancelar()

    End Sub
End Class
