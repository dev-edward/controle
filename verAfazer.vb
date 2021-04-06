Imports System.Data.SqlClient

Public Class verAfazer
    Class Afazer
        Dim panel As New Panel()
        Dim lbl_dataCadastro As New Label()
        Dim lbl_dataCadastroValor As New Label()
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
            panel.Controls.Add(lbl_dataCadastroValor)
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
            lbl_dataCadastroValor.Font = fonte
            lbl_titulo.Font = fonte
            txt_titulo.Font = fonte
            lbl_prazo.Font = fonte
            dtp_prazo.Font = fonte
            lbl_estado.Font = fonte
            cbx_estado.Font = fonte
            btn_modificar.Font = fonte
            btn_addnotas.Font = fonte
            lbl_detalhes.Font = fonte
            txt_detalhes.Font = New Font("Microsoft Sans Serif", 8)

            'labels
            lbl_dataCadastro.Text = "Data do Cadastro:"
            lbl_titulo.Text = "Título"
            lbl_prazo.Text = "Prazo"
            lbl_estado.Text = "Estado"
            lbl_detalhes.Text = "Detalhes"
            btn_modificar.Text = "Editar"
            btn_addnotas.Text = "add. notas"

            'conteudo dos controles
            lbl_dataCadastroValor.Text = _dataCadastro
            txt_titulo.Text = _titulo
            dtp_prazo.Value = _prazo
            cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
            cbx_estado.SelectedIndex = _estado - 1
            txt_detalhes.Text = _detalhes

            'tamanho dos controles
            panel.Size = New Size(660, 170)
            lbl_dataCadastro.Size = New Size(140, 20)
            lbl_dataCadastroValor.Size = New Size(110, 20)
            lbl_titulo.Size = New Size(260, 20)
            txt_titulo.Size = New Size(260, 26)
            lbl_prazo.Size = New Size(110, 20)
            dtp_prazo.Size = New Size(110, 26)
            lbl_estado.Size = New Size(140, 20)
            cbx_estado.Size = New Size(140, 20)
            btn_modificar.Size = New Size(100, 30)
            btn_addnotas.Size = New Size(100, 30)
            lbl_detalhes.Size = New Size(640, 20)
            'lbl_detalhes.BackColor = New Color().FromArgb(255, 215, 0, 0)
            txt_detalhes.Size = New Size(640, 60)




            'posição dos controles
            panel.Location = New Point(40, 50)
            panelx = panel.Location.X
            panely = panel.Location.Y

            lbl_dataCadastro.Location = New Point(panel.Width / 2 - (lbl_dataCadastro.Width), 2)
            lbl_dataCadastroValor.Location = New Point(panel.Width / 2, 2)
            lbl_titulo.Location = New Point(10, 26)
            txt_titulo.Location = New Point(10, 48)
            lbl_prazo.Location = New Point(280, 26)
            dtp_prazo.Location = New Point(280, 48)
            lbl_estado.Location = New Point(400, 26)
            cbx_estado.Location = New Point(400, 48)
            btn_addnotas.Location = New Point(550, 16)
            btn_modificar.Location = New Point(550, 47)
            lbl_detalhes.Location = New Point(10, 80)
            txt_detalhes.Location = New Point(10, 100)

            'configurações especificas
            panel.BorderStyle = BorderStyle.FixedSingle
            dtp_prazo.Format = DateTimePickerFormat.Short
            lbl_titulo.TextAlign = ContentAlignment.MiddleCenter
            lbl_prazo.TextAlign = ContentAlignment.MiddleCenter
            lbl_detalhes.TextAlign = ContentAlignment.MiddleCenter
            txt_detalhes.Multiline = True
            txt_titulo.ReadOnly = True
            txt_detalhes.ReadOnly = True
            dtp_prazo.Enabled = False
            cbx_estado.Enabled = False


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
        'conexao = New SqlConnection("Initial Catalog=auxiliar;" & "Data Source=VM-CPD3\DBTESTE;Integrated Security=SSPI;")

        'Create a Command object.
        consulta = conexao.CreateCommand
        consulta.CommandText = "select afazer_dataatual,afazer_titulo,afazer_detalhes ,afazer_prazo,afazer_status from tb_afazer ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY"

        'Open the connection.
        conexao.Open()

        myReader = consulta.ExecuteReader()

        'Concatenate the query result into a string.
        Dim y As Integer
        y = 10

        Do While myReader.Read()

            Dim dataCadastro As DateTime
            Dim titulo As String
            Dim detalhes As String
            Dim prazo As DateTime
            Dim estado As String



            dataCadastro = myReader.GetDateTime(0)
            titulo = myReader.GetString(1)
            detalhes = myReader.GetString(2)
            prazo = myReader.GetDateTime(3)
            estado = myReader.GetByte(4)

            Dim a1 As New Afazer(Me, dataCadastro, titulo, prazo, estado, detalhes)

        Loop



        'MsgBox(estado)

        myReader.Close()
        conexao.Close()
    End Sub


End Class