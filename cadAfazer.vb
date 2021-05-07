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


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_estado.SelectedIndex = 0
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
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