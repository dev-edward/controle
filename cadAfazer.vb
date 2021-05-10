Imports System.Data.SqlClient
Public Class cadAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Private resultado As String

    Dim panel As New Panel()
    Dim lbl_cadastro As New Label()
    Dim lbl_titulo As New Label()
    Dim txt_titulo As New TextBox()
    Dim lbl_detalhes As New Label()
    Dim txt_detalhes As New TextBox()
    Dim lbl_prazo As New Label()
    Dim dtp_prazo As New DateTimePicker()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()
    Dim btn_salvar As New Button()
    Dim fonte As New Font("Microsoft Sans Serif", 12)

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'adicionando controles ao panel
        panel.Controls.Add(lbl_cadastro)
        panel.Controls.Add(lbl_titulo)
        panel.Controls.Add(txt_titulo)
        panel.Controls.Add(lbl_detalhes)
        panel.Controls.Add(txt_detalhes)
        panel.Controls.Add(lbl_prazo)
        panel.Controls.Add(dtp_prazo)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(btn_salvar)

        'fonte dos controles
        lbl_cadastro.Font = New Font("Microsoft Sans Serif", 12, FontStyle.Bold)
        lbl_titulo.Font = fonte
        txt_titulo.Font = fonte
        lbl_detalhes.Font = fonte
        txt_detalhes.Font = fonte
        lbl_prazo.Font = fonte
        dtp_prazo.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte
        btn_salvar.Font = fonte

        'texto dos controles
        lbl_cadastro.Text = "Cadastre uma nova tarefa"
        lbl_titulo.Text = "Título da tarefa"
        lbl_detalhes.Text = "Detalhes"
        lbl_prazo.Text = "Prazo"
        lbl_estado.Text = "Estado"
        btn_salvar.Text = "Salvar"

        'tamanho dos controles
        panel.Size = New Size(350, 480)
        txt_titulo.Size = New Size(230, 28)
        txt_detalhes.Size = New Size(230, 84)
        dtp_prazo.Size = New Size(110, 30)
        cbx_estado.Size = New Size(230, 28)
        btn_salvar.Size = New Size(230, 40)
        lbl_cadastro.AutoSize = True
        lbl_titulo.AutoSize = True
        lbl_detalhes.AutoSize = True
        lbl_prazo.AutoSize = True
        lbl_estado.AutoSize = True

        'posição dos controles
        panel.Location = New Point(10, 10)
        lbl_cadastro.Location = New Point((panel.Width / 2) - (lbl_cadastro.Width / 2), 20)
        lbl_titulo.Location = New Point((panel.Width / 2) - (lbl_titulo.Width / 2), 50)
        txt_titulo.Location = New Point((panel.Width / 2) - (txt_titulo.Width / 2), 80)
        lbl_detalhes.Location = New Point((panel.Width / 2) - (lbl_detalhes.Width / 2), 110)
        txt_detalhes.Location = New Point((panel.Width / 2) - (txt_detalhes.Width / 2), 140)
        lbl_prazo.Location = New Point((panel.Width / 2) - (lbl_prazo.Width / 2), 225)
        dtp_prazo.Location = New Point((panel.Width / 2) - (dtp_prazo.Width / 2), 255)
        lbl_estado.Location = New Point((panel.Width / 2) - (lbl_estado.Width / 2), 285)
        cbx_estado.Location = New Point((panel.Width / 2) - (cbx_estado.Width / 2), 315)
        btn_salvar.Location = New Point((panel.Width / 2) - (btn_salvar.Width / 2), 360)


        'configurações especificas
        txt_detalhes.Multiline = True
        dtp_prazo.Format = DateTimePickerFormat.Short
        cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
        cbx_estado.SelectedIndex = 0
        cbx_estado.DropDownStyle = ComboBoxStyle.DropDownList
        AddHandler btn_salvar.Click, AddressOf btn_salvar_Click

        'lbl_titulo.BackColor = New Color().FromArgb(255, 215, 0, 0)
        'panel.BackColor = New Color().FromArgb(255, 215, 0, 0)
        Me.Controls.Add(panel)

    End Sub

    Private Sub btn_salvar_Click()
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand

        consulta.CommandText = "insert into tb_item(item_tipo) values(1) insert into tb_afazer(afazer_fkitem, afazer_titulo, afazer_detalhes, afazer_prazo, afazer_status) VALUES(scope_identity(),'" & txt_titulo.Text & "','" & txt_detalhes.Text & "','" & dtp_prazo.Value & "'," & cbx_estado.SelectedIndex + 1 & ")"

        conexao.Open()
        myReader = consulta.ExecuteReader()

        MsgBox(resultado)

        myReader.Close()
        conexao.Close()
    End Sub


End Class