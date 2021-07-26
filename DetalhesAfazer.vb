Imports System.Data.SqlClient
Public Class DetalhesAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim panel As New Panel()
    Dim lbl_id As New Label()
    Dim lbl_fkitem As New Label()
    Dim lbl_dataCadastro As New Label()
    Dim lbl_dataCadastroValor As New Label()
    Dim lbl_userCadastro As New Label()
    Dim lbl_userCadastroValor As New Label()
    Dim lbl_dataAlteracao As New Label()
    Dim lbl_dataAlteracaoValor As New Label()
    Dim lbl_useralteracao As New Label()
    Dim lbl_useralteracaoValor As New Label()
    Dim lbl_titulo As New Label()
    Dim txt_titulo As New TextBox()
    Dim lbl_detalhes As New Label()
    Dim txt_detalhes As New TextBox()
    Dim lbl_prazo As New Label()
    Dim dtp_prazo As New DateTimePicker()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()
    Dim btn_addnotas As New Button()
    Dim btn_modificar As New Button()
    Dim btn_salvar As New Button()

    'fontes
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim fontemenor As New Font("Microsoft Sans Serif", 8)

    Friend Sub New(ByVal _id As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        lbl_id.Text = _id
        lbl_id.Location = New Point(0, 0)
        lbl_id.Size = New Size(30, 10)
        Me.Controls.Add(lbl_id)

    End Sub
    Private Sub DetalhesAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
        consulta = conexao.CreateCommand
        consulta.CommandText = "select afazer_id, afazer_fkitem, afazer_dtcadastro, afazer_usercadastro, afazer_dtalteracao, afazer_useralteracao, afazer_titulo,afazer_detalhes, afazer_prazo,afazer_status from tb_afazer where id=" & lbl_id.Text
        conexao.Open()
        myReader = consulta.ExecuteReader()

        Dim id As Integer
        Dim fkitem As Integer
        Dim dataCadastro As DateTime
        Dim titulo As String
        Dim detalhes As String
        Dim prazo As DateTime
        Dim estado As String

        id = myReader.GetInt32(0)
        fkitem = myReader.GetInt32(0)
        dataCadastro = myReader.GetInt32(0)
        titulo = myReader.GetInt32(0)
        detalhes = myReader.GetInt32(0)
        prazo = myReader.GetInt32(0)
        estado = myReader.GetInt32(0)

        'texto dos labels
        lbl_dataCadastro.Text = "Data do Cadastro:"
        lbl_userCadastro.Text = "Usuário que cadastrou"
        lbl_dataAlteracao.Text = "Data da última altecação"
        lbl_useralteracao.Text = "Usuário que alterou"
        lbl_titulo.Text = "Título"
        lbl_prazo.Text = "Prazo"
        lbl_estado.Text = "Estado"
        lbl_detalhes.Text = "Detalhes"
        btn_addnotas.Text = "add. notas"
        btn_modificar.Text = "Editar"
        btn_salvar.Text = "Salvar"

        'conteudo dos controles extraido do BD
        lbl_id.Text = _id
        lbl_fkitem.Text = _fkitem
        lbl_dataCadastroValor.Text = _dataCadastro
        txt_titulo.Text = _titulo
        dtp_prazo.Value = _prazo
        cbx_estado.Items.AddRange({"Não feito", "Feito", "Em andamento"})
        cbx_estado.SelectedIndex = _estado - 1
        txt_detalhes.Text = _detalhes

        'fonte dos controles
        lbl_id.Font = fontemenor
        lbl_fkitem.Font = fontemenor
        lbl_dataCadastro.Font = fontemenor
        lbl_dataCadastroValor.Font = fontemenor
        lbl_userCadastro.Font = fontemenor
        lbl_userCadastroValor.Font = fontemenor
        lbl_dataAlteracao.Font = fontemenor
        lbl_dataAlteracaoValor.Font = fontemenor
        lbl_useralteracao.Font = fontemenor
        lbl_useralteracaoValor.Font = fontemenor
        lbl_titulo.Font = fonte
        txt_titulo.Font = fonte
        lbl_detalhes.Font = fonte
        txt_detalhes.Font = fontemenor
        lbl_prazo.Font = fonte
        dtp_prazo.Font = fonte
        lbl_estado.Font = fonte
        cbx_estado.Font = fonte
        btn_addnotas.Font = fonte
        btn_modificar.Font = fonte
        btn_salvar.Font = fonte

        'adicionando controles ao panel
        panel.Controls.Add(lbl_id)
        panel.Controls.Add(lbl_fkitem)
        panel.Controls.Add(lbl_dataCadastro)
        panel.Controls.Add(lbl_dataCadastroValor)
        panel.Controls.Add(lbl_userCadastro)
        panel.Controls.Add(lbl_userCadastroValor)
        panel.Controls.Add(lbl_dataAlteracao)
        panel.Controls.Add(lbl_dataAlteracaoValor)
        panel.Controls.Add(lbl_useralteracao)
        panel.Controls.Add(lbl_useralteracaoValor)
        panel.Controls.Add(lbl_titulo)
        panel.Controls.Add(txt_titulo)
        panel.Controls.Add(lbl_prazo)
        panel.Controls.Add(dtp_prazo)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)
        panel.Controls.Add(btn_addnotas)
        panel.Controls.Add(btn_modificar)
        panel.Controls.Add(btn_salvar)
        panel.Controls.Add(lbl_detalhes)
        panel.Controls.Add(txt_detalhes)





        myReader.Close()
        conexao.Close()
    End Sub
End Class