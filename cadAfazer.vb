Imports System.Data.SqlClient
Public Class cadAfazer
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Private resultado As String
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbx_estado.SelectedIndex = 0
    End Sub

    Private Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        conexao = New SqlConnection("Initial Catalog=auxiliar;" & "Data Source=localhost;Integrated Security=SSPI;")
        consulta = conexao.CreateCommand

        consulta.CommandText = "insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('" & txt_titulo.Text & "','" & txt_detalhes.Text & "','" & dtp_prazo.Value & "'," & cbx_estado.SelectedIndex + 1 & ")"
        'Dim var As String = "insert into tb_afazer(afazer_titulo,afazer_descricao,afazer_prazo,afazer_status) VALUES('" & txt_titulo.Text & "','" & txt_detalhes.Text & "','" & dtp_prazo.Value & "'," & cbx_estado.SelectedIndex + 1 & ")"

        conexao.Open()
        myReader = consulta.ExecuteReader()

        MsgBox(resultado)

        'MsgBox(var)

        myReader.Close()
        conexao.Close()
    End Sub
End Class