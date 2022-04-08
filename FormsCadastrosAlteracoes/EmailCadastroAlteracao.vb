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

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_email As New Form With {
        .Text = "Cadastrar novo email",
        .ClientSize = New Size(300, 340),
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
        .MaxLength = 30,
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
        .Size = tamanholbl,
        .MaxLength = 30,
        .Location = New Point(lbl_nome.Location.X, lbl_senha.Location.Y + tamanholbl.Height)
    }
    Dim lbl_domimio As New Label With {
        .Text = "Domimio",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_senha.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim cmb_domimio As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nome.Location.X, lbl_domimio.Location.Y + tamanholbl.Height)
    }
    Dim lbl_estado As New Label With {
        .Text = "Estado",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, txt_email.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim rbt_estadoAtivo As New RadioButton With {
        .Text = "Ativo",
        .Size = New Size(100, 30),
        .Font = fonte,
        .Location = New Point(lbl_nome.Location.X + tamanholbl.Width / 2, lbl_estado.Location.Y + tamanholbl.Height)
    }
    Dim rbt_estadoInativo As New RadioButton With {
        .Text = "Inativo",
        .Size = New Size(150, 30),
        .Font = fonte,
        .Location = New Point(lbl_nome.Location.X + tamanholbl.Width * 1.2, lbl_estado.Location.Y + tamanholbl.Height)
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
        .Location = New Point(lbl_nome.Location.X, rbt_estadoAtivo.Location.Y + tamanholbl.Height)
    }


    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(lbl_nome.Location.X, cmb_domimio.Location.Y + tamanhobtn.Height)
    }
    Dim btn_notas As New Button With {
        .Visible = False,
        .ForeColor = Color.FromArgb(255, 15, 15, 15),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Font = New Font("Impact", 10),
        .Size = tamanhobtn,
        .BackgroundImage = img.notas,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .Location = New Point(lbl_nome.Location.X, cmb_domimio.Location.Y + tamanhobtn.Height)
    }
    Dim btn_editar As New Button With {
        .Text = "Editar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Visible = False,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, cmb_domimio.Location.Y + tamanhobtn.Height)
    }
    Dim btn_cancelar As New Button With {
        .Text = "Cancelar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X + tamanhobtn.Width, cmb_domimio.Location.Y + tamanhobtn.Height)
    }
    Dim btn_alterar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = tamanhobtn,
        .Location = New Point(lbl_nome.Location.X, cmb_domimio.Location.Y + tamanhobtn.Height)
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
        classesAbertas.setAtualCadAltTelefones(frm_email)

        'AddHandler txt_numero.KeyUp, AddressOf txt_KeyUp
        'AddHandler txt_numero.GotFocus, AddressOf txt_GotFocus
        'AddHandler txt_numero.LostFocus, AddressOf txt_LostFocus
        'AddHandler txt_pessoa.KeyUp, AddressOf txt_KeyUp
        'AddHandler txt_pessoa.GotFocus, AddressOf txt_GotFocus
        'AddHandler txt_pessoa.LostFocus, AddressOf txt_LostFocus
        'AddHandler txt_local.KeyUp, AddressOf txt_KeyUp
        'AddHandler txt_local.GotFocus, AddressOf txt_GotFocus
        'AddHandler txt_local.LostFocus, AddressOf txt_LostFocus

        cmb_domimio.Items.Add("ifsj.org.br")
        cmb_domimio.Items.Add("saojosevm.org.br")
        cmb_domimio.Items.Add("saojosepf.org.br")
        cmb_domimio.Items.Add("esfs.org.br")
        cmb_domimio.Items.Add("isc.org.br")

        frm_email.Controls.Add(lbl_nome)
        frm_email.Controls.Add(txt_nome)
        frm_email.Controls.Add(lbl_setor)
        frm_email.Controls.Add(txt_setor)
        frm_email.Controls.Add(lbl_email)
        frm_email.Controls.Add(txt_email)
        frm_email.Controls.Add(lbl_senha)
        frm_email.Controls.Add(txt_senha)
        frm_email.Controls.Add(lbl_domimio)
        frm_email.Controls.Add(cmb_domimio)
        frm_email.Controls.Add(lbl_estado)
        frm_email.Controls.Add(rbt_estadoAtivo)
        frm_email.Controls.Add(rbt_estadoInativo)
        frm_email.Controls.Add(btn_salvar)
        frm_email.Controls.Add(btn_alterar)
        frm_email.Controls.Add(btn_notas)
        frm_email.Controls.Add(btn_editar)
        frm_email.Controls.Add(btn_cancelar)
        frm_email.Show()
    End Sub
    Private Sub alternarReadOnly()

    End Sub
    Private Sub notas()

    End Sub
    Private Sub salvar()

    End Sub
    Private Sub alterar()

    End Sub
    Private Sub carregarDados()

    End Sub
    Private Sub editarCancelar()

    End Sub

End Class
