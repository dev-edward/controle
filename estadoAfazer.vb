Imports System.Data.SqlClient
Public Class estadoAfazer
    Private conexao As SqlConnection
    Private consulta As SqlCommand

    Dim pk As Integer
    Dim estado As Integer
    Dim estadoAtual As Integer
    Dim selecionado = Color.FromArgb(255, 134, 185, 233)
    Dim deselecionado = SystemColors.Control
    Dim lista As Afazer

    Friend Sub New(ByRef _lista As Afazer, ByVal _pk As Integer, ByRef _estado As Integer)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        pk = _pk
        estadoAtual = _estado
        lista = _lista

    End Sub
    Private Sub estadoAfazer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_alterar.Enabled = False
        Select Case estadoAtual
            Case 1
                rdb_aguardando.BackColor = selecionado
                rdb_aguardando.Checked = True
            Case 2
                rdb_andamento.BackColor = selecionado
                rdb_andamento.Checked = True
            Case 3
                rdb_feito.BackColor = selecionado
                rdb_feito.Checked = True
            Case 4
                rdb_descartado.Checked = True
        End Select

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btn_alterar_Click(sender As Object, e As EventArgs) Handles btn_alterar.Click
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


            lista.setEstado(estado)

            System.Diagnostics.Debug.WriteLine(estadoAtual)

        Catch ex As Exception
            MessageBox.Show("Erro ao atualizar: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try
        Me.Dispose()
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

        If estado <> estadoAtual Then
            btn_alterar.Enabled = True
        Else
            btn_alterar.Enabled = False
        End If
    End Sub
End Class