Imports System.Data.SqlClient
Public Class cadImpressora
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim panel As New Panel()
    Dim lbl_modelo As New Label()
    Dim txt_modelo As New TextBox()
    Dim lbl_nserie As New Label()
    Dim txt_nserie As New TextBox()
    Dim lbl_ip As New Label()
    Dim txt_ip As New TextBox()
    Dim lbl_suprimento As New Label()
    Dim cbx_suprimento As New ComboBox()
    Dim rdb_corpb As New RadioButton()
    Dim rdb_corcl As New RadioButton()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()
    Dim lbl_dtentrada As New Label()
    Dim dtp_dtentrada As New DateTimePicker()
    Dim lbl_dtsaida As New Label()
    Dim dtp_dtsaida As New DateTimePicker()
    Dim btn_cadastrar As New Button()
    Dim fonte As New Font("Microsoft Sans Serif", 10)

    Private Sub cadImpressora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim y As Integer = 25
        Dim Wpadrao As Integer = 200

        'adicionando controles ao panel
        panel.Controls.Add(lbl_modelo)
        panel.Controls.Add(txt_modelo)
        panel.Controls.Add(lbl_nserie)
        panel.Controls.Add(txt_nserie)
        panel.Controls.Add(lbl_ip)
        panel.Controls.Add(txt_ip)
        panel.Controls.Add(lbl_suprimento)
        panel.Controls.Add(cbx_suprimento)
        panel.Controls.Add(rdb_corpb)
        panel.Controls.Add(rdb_corcl)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(lbl_dtentrada)
        panel.Controls.Add(dtp_dtentrada)
        panel.Controls.Add(lbl_dtsaida)
        panel.Controls.Add(dtp_dtsaida)
        panel.Controls.Add(btn_cadastrar)

        'fonte dos controles
        lbl_modelo.Font = fonte
        txt_modelo.Font = fonte
        lbl_nserie.Font = fonte
        txt_nserie.Font = fonte
        lbl_ip.Font = fonte
        txt_ip.Font = fonte
        lbl_suprimento.Font = fonte
        cbx_suprimento.Font = fonte
        rdb_corpb.Font = fonte
        rdb_corcl.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte
        lbl_dtentrada.Font = fonte
        dtp_dtentrada.Font = fonte
        lbl_dtsaida.Font = fonte
        dtp_dtsaida.Font = fonte
        btn_cadastrar.Font = fonte

        'texto dos controles
        lbl_modelo.Text = "Marca && Modelo"
        lbl_nserie.Text = "Nº de série"
        lbl_ip.Text = "IP"
        lbl_suprimento.Text = "Suprimento"
        rdb_corpb.Text = "Preto && Branco"
        rdb_corcl.Text = "Colorido"
        lbl_estado.Text = "Estado"
        lbl_dtentrada.Text = "Data de entrada"
        lbl_dtsaida.Text = "Data de saída"
        btn_cadastrar.Text = "Cadastrar"

        'tamanho dos controles
        panel.Size = New Size(500, 560)
        lbl_modelo.Size = New Size(Wpadrao, 20)
        txt_modelo.Size = New Size(Wpadrao, 20)
        lbl_nserie.Size = New Size(Wpadrao, 20)
        txt_nserie.Size = New Size(Wpadrao, 20)
        lbl_ip.Size = New Size(Wpadrao, 20)
        txt_ip.Size = New Size(Wpadrao, 20)
        lbl_suprimento.Size = New Size(Wpadrao, 20)
        cbx_suprimento.Size = New Size(Wpadrao, 20)
        rdb_corpb.Size = New Size(130, 20)
        rdb_corcl.Size = New Size(100, 20)
        lbl_estado.Size = New Size(Wpadrao, 20)
        cbx_estado.Size = New Size(Wpadrao, 20)
        lbl_dtentrada.Size = New Size(Wpadrao, 20)
        dtp_dtentrada.Size = New Size(Wpadrao, 20)
        lbl_dtsaida.Size = New Size(Wpadrao, 20)
        dtp_dtsaida.Size = New Size(Wpadrao, 20)
        btn_cadastrar.Size = New Size(Wpadrao, 40)

        'posição dos controles
        lbl_modelo.Location = New Point(10, y * 1)
        txt_modelo.Location = New Point(10, y * 2)
        lbl_nserie.Location = New Point(10, y * 3)
        txt_nserie.Location = New Point(10, y * 4)
        lbl_ip.Location = New Point(10, y * 5)
        txt_ip.Location = New Point(10, y * 6)
        lbl_suprimento.Location = New Point(10, y * 7)
        cbx_suprimento.Location = New Point(10, y * 8)
        rdb_corpb.Location = New Point(10, y * 9)
        rdb_corcl.Location = New Point(140, y * 9)
        lbl_estado.Location = New Point(10, y * 10)
        cbx_estado.Location = New Point(10, y * 11)
        lbl_dtentrada.Location = New Point(10, y * 12)
        dtp_dtentrada.Location = New Point(10, y * 13)
        lbl_dtsaida.Location = New Point(10, y * 14)
        dtp_dtsaida.Location = New Point(10, y * 15)
        btn_cadastrar.Location = New Point(10, y * 16 + 10)

        'coinfigurações especificas
        AddHandler btn_cadastrar.Click, AddressOf btn_cadastrar_Click

        'adicionando panel ao form
        Me.Controls.Add(panel)

    End Sub
    Private Sub btn_cadastrar_Click()
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand

        Dim cor_selecionada As Integer
        If rdb_corpb.Checked Then
            cor_selecionada = 1
        ElseIf rdb_corcl.Checked Then
            cor_selecionada = 2
        End If

        consulta.CommandText = "insert into tb_item(item_tipo) values(2) insert into tb_impressora(impressora_fkitem, impressora_marcamodelo, impressora_serie, impressora_ip, impressora_suprimento, impressora_corimpressao, impressora_estado, impressora_dtentrada, impressora_dtsaida)  values(scope_identity(),'" & txt_modelo.Text & "','" & txt_nserie.Text & "','" & txt_ip.Text & "'," & cbx_suprimento.SelectedIndex + 1 & "," & cor_selecionada & "," & cbx_estado.SelectedIndex + 1 & "," & dtp_dtentrada.Value & "," & dtp_dtsaida.Value & ")"
        'consulta.CommandText = "select * from tb_impressora"

        conexao.Open()
        myReader = consulta.ExecuteReader()

        MsgBox(consulta.CommandText)

        myReader.Close()
        conexao.Close()
    End Sub
End Class