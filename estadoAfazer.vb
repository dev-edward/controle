Imports System.Data.SqlClient
Public Class estadoAfazer
    Private conexao As SqlConnection
    Private consulta As SqlCommand

    Dim pk As Integer
    Dim estado As Integer
    Dim btn As Button
    Dim selecionado = Color.FromArgb(255, 134, 185, 233)
    Dim deselecionado = SystemColors.Control

    Friend Sub New(ByRef _btn As Button, ByVal _pk As Integer)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        pk = _pk
        btn = _btn

    End Sub
    Private Sub estadoAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_alterar.Enabled = False
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
        If (estado <> 0) Then
            Try
                conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

                consulta = conexao.CreateCommand
                consulta.CommandText = "UPDATE tb_afazer SET 
                                afazer_dtalteracao = GETDATE(),
                                afazer_useralteracao = @useralteracao,
                                afazer_status = @status
                                WHERE afazer_id = @id"

                consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
                consulta.Parameters.AddWithValue("@status", estado)
                consulta.Parameters.AddWithValue("@id", pk)

                conexao.Open()

                consulta.ExecuteNonQuery()

                Select Case estado
                    Case 1
                        btn.BackgroundImage = img.aguardando
                    Case 2
                        btn.BackgroundImage = img.andamento
                    Case 3
                        btn.BackgroundImage = img.feito
                    Case 4
                        btn.BackgroundImage = img.descartado
                End Select

            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar: " & ex.Message, "Insert Records")
            Finally
                conexao.Close()
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub rdb_aguardando_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_aguardando.CheckedChanged
        selecionando(rdb_aguardando, 1)
    End Sub

    Private Sub rdb_andamento_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_andamento.CheckedChanged
        selecionando(rdb_andamento, 2)
    End Sub

    Private Sub rdb_feito_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_feito.CheckedChanged
        selecionando(rdb_feito, 3)
    End Sub

    Private Sub rdb_descartado_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_descartado.CheckedChanged
        selecionando(rdb_descartado, 4)
    End Sub
    Private Sub selecionando(ByRef _radio As RadioButton, ByVal _estado As Integer)
        estado = _estado
        rdb_aguardando.BackColor = deselecionado
        rdb_andamento.BackColor = deselecionado
        rdb_feito.BackColor = deselecionado
        rdb_descartado.BackColor = deselecionado
        _radio.BackColor = selecionado

        If Not btn_alterar.Enabled Then
            btn_alterar.Enabled = True
        End If
    End Sub
End Class