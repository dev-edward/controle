Imports System.Data.SqlClient
Public Class estadoAfazer
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim pk As Integer
    Private Sub New(ByVal _pk As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        pk = _pk

    End Sub
    Private Sub estadoAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'AddHandler btn_addnotas.Click, AddressOf btn_addnotas_Click
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        pk = 1



        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "UPDATE tb_afazer SET 
                                afazer_dtalteracao = GETDATE(),
                                afazer_useralteracao = @useralteracao,
                                afazer_status = @status,
                                WHERE afazer_id = @id"

            consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
            consulta.Parameters.AddWithValue("@status", cbx_estado.SelectedIndex + 1)
            consulta.Parameters.AddWithValue("@id", pk)

            conexao.Open()

            consulta.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
    End Sub
End Class