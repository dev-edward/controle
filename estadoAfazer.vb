Imports System.Data.SqlClient
Public Class estadoAfazer
    Private conexao As SqlConnection
    Private consulta As SqlCommand

    Dim pk As Integer
    Dim estado As Integer
    Dim selecionado = Color.FromArgb(255, 134, 185, 233)
    Dim deselecionado = SystemColors.Control

    Friend Sub New(ByVal _pk As Integer)
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
        If (estado! = 0) Then
            Try
                conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

                consulta = conexao.CreateCommand
                consulta.CommandText = "UPDATE tb_afazer SET 
                                afazer_dtalteracao = GETDATE(),
                                afazer_useralteracao = @useralteracao,
                                afazer_status = @status,
                                WHERE afazer_id = @id"

                consulta.Parameters.AddWithValue("@useralteracao", usuario.usuario_id)
                consulta.Parameters.AddWithValue("@status", estado)
                consulta.Parameters.AddWithValue("@id", pk)

                conexao.Open()

                consulta.ExecuteNonQuery()

            Catch ex As Exception
                MessageBox.Show("Erro ao atualizar: " & ex.Message, "Insert Records")
            Finally
                conexao.Close()
            End Try
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_aguardando.CheckedChanged
        If rdb_aguardando.Checked Then
            estado = 1
            rdb_aguardando.BackColor = selecionado
        Else
            rdb_aguardando.BackColor = deselecionado
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_andamento.CheckedChanged
        If rdb_andamento.Checked Then
            estado = 2
            rdb_andamento.BackColor = selecionado
        Else
            rdb_andamento.BackColor = deselecionado
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_feito.CheckedChanged
        If rdb_feito.Checked Then
            estado = 3
            rdb_feito.BackColor = selecionado
        Else
            rdb_feito.BackColor = deselecionado
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_descartado.CheckedChanged
        If rdb_descartado.Checked Then
            estado = 4
            rdb_descartado.BackColor = selecionado
        Else
            rdb_descartado.BackColor = deselecionado
        End If
    End Sub
End Class