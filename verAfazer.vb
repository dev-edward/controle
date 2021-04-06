Imports System.Data.SqlClient

Public Class verAfazer
    Class Afazer
        Dim panel As New Panel()
        Dim lbl_dataCadastro As New Label()
        Dim dtp_dataCadastro As New DateTimePicker()
        Dim lbl_titulo As New Label()
        Dim txt_titulo As New TextBox()
        Dim lbl_prazo As New Label()
        Dim dtp_prazo As New DateTimePicker()
        Dim lbl_estado As New Label()
        Dim cbx_estado As New ComboBox()
        Dim btn_modificar As New Button()
        Dim btn_addnotas As New Button()
        Dim lbl_detalhes As New Label()
        Dim txt_detalhes As New TextBox()
        Dim panelx As New Integer
        Dim panely As New Integer
        'fonte padrão 
        Dim fonte As New Font("Microsoft Sans Serif", 12)

        Friend Sub New(ByVal frm As verAfazer, ByVal _dataCadastro As DateTime, ByVal _titulo As String, ByVal _prazo As DateTime, ByVal _estado As Integer, ByVal _detalhes As String)
            'adicionando controles no panel
            panel.Controls.Add(lbl_dataCadastro)
            panel.Controls.Add(dtp_dataCadastro)
            panel.Controls.Add(lbl_titulo)
            panel.Controls.Add(txt_titulo)
            panel.Controls.Add(lbl_prazo)
            panel.Controls.Add(dtp_prazo)
            panel.Controls.Add(lbl_estado)
            panel.Controls.Add(cbx_estado)
            panel.Controls.Add(btn_modificar)
            panel.Controls.Add(btn_addnotas)
            panel.Controls.Add(lbl_detalhes)
            panel.Controls.Add(txt_detalhes)

            'colocando fonte 12 para todos os itens
            lbl_dataCadastro.Font = fonte
            dtp_dataCadastro.Font = fonte
            lbl_titulo.Font = fonte
            txt_titulo.Font = fonte
            lbl_prazo.Font = fonte
            dtp_prazo.Font = fonte
            lbl_estado.Font = fonte
            cbx_estado.Font = fonte
            btn_modificar.Font = fonte
            btn_addnotas.Font = fonte
            lbl_detalhes.Font = fonte
            txt_detalhes.Font = fonte

            'labels
            lbl_dataCadastro.Text = "Data do Cadastro:"
            lbl_titulo.Text = "Título"
            lbl_prazo.Text = "Prazo"
            lbl_estado.Text = "Estado"
            lbl_detalhes.Text = "Detalhes"

            'conteudo dos controles
            dtp_dataCadastro.Value = _dataCadastro
            txt_titulo.Text = _titulo
            dtp_prazo.Value = _prazo
            cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
            cbx_estado.SelectedIndex = _estado - 1
            txt_detalhes.Text = _detalhes

            'tamanho dos controles
            panel.Size = New Size(700, 200)
            lbl_dataCadastro = New Si

            'posição dos controles
            panel.Location = New Point(10, 10)
            panelx = panel.Location.X
            panely = panel.Location.Y

            lbl_dataCadastro.Location = New Point(panel.Width / 2 - ((lbl_dataCadastro.Width + dtp_dataCadastro.Width) / 2), panely + 20)
            dtp_dataCadastro.Location = New Point(panel.Width / 2 + ((lbl_dataCadastro.Width + dtp_dataCadastro.Width) / 2), panely + 20)
            lbl_titulo.Location = New Point(panelx + 95, panely + 60)
            txt_titulo.Location = New Point(panelx + 20, panely + 90)
            lbl_prazo.Location = New Point(panelx + 295, panely + 60)
            dtp_prazo.Location = New Point(panelx + 260, panely + 90)
            lbl_estado.Location = New Point(panelx + 440, panely + 60)
            cbx_estado.Location = New Point(panelx + 410, panely + 90)
            btn_modificar.Location = New Point(panelx + 540, panely + 90)
            btn_addnotas.Location = New Point(panelx + 630, panely + 90)
            lbl_detalhes.Location = New Point(panel.Width / 2 - (lbl_detalhes.Width / 2), panely + 135)
            txt_detalhes.Location = New Point(panel.Width / 2 - (txt_detalhes.Width / 2), panely + 150)

            'configurações especificas
            dtp_dataCadastro.Format = DateTimePickerFormat.Short
            dtp_prazo.Format = DateTimePickerFormat.Short



            frm.Controls.Add(panel)


        End Sub

    End Class

    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Private resultado As String
    Private Sub verAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Create a Connection object.
        conexao = New SqlConnection("Initial Catalog=auxiliar;" & "Data Source=localhost;Integrated Security=SSPI;")

        'Create a Command object.
        consulta = conexao.CreateCommand
        consulta.CommandText = "select afazer_dataatual,afazer_titulo,afazer_detalhes ,afazer_prazo,afazer_status from tb_afazer ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 5 ROWS ONLY"

        'Open the connection.
        conexao.Open()

        myReader = consulta.ExecuteReader()

        'Concatenate the query result into a string.
        Dim y As Integer
        y = 10

        'Do While myReader.Read()

        '    Dim dataCadastro As DateTime
        '    Dim titulo As String
        '    Dim detalhes As String
        '    Dim prazo As DateTime
        '    Dim estado As String



        '    dataCadastro = myReader.GetDateTime(0)
        '    titulo = myReader.GetString(1)
        '    detalhes = myReader.GetString(2)
        '    prazo = myReader.GetDateTime(3)
        '    estado = myReader.GetByte(4)



        'Loop

        Dim a1 As New Afazer(Me, "10/03/2021", "titulo", "11/03/2021", 1, "detalhes")

        'MsgBox(estado)

        myReader.Close()
        conexao.Close()
    End Sub


End Class