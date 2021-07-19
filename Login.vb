Imports System.Data.SqlClient

Public Class Login
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader


    Private Sub btn_sair_Click(sender As Object, e As EventArgs) Handles btn_sair.Click
        Me.Close()
        Principal.Close()
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler btn_entrar.Click, AddressOf btn_entrar_Click
    End Sub

    Private Sub btn_entrar_Click()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select usuario_id, usuario_user, usuario_nome, usuario_senha from tb_usuario where usuario_user='" & txt_usuario.Text & "' ORDER BY usuario_id desc OFFSET 0 ROWS FETCH NEXT 1 ROWS ONLY"

            conexao.Open()

            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                myReader.Read()
                Dim id As Integer
                Dim user As String
                Dim nome As String
                Dim senha As String
                Dim senha2 As String

                user = myReader.GetString("usuario_user")
                nome = myReader.GetString("usuario_nome")
                senha = myReader.GetString("usuario_senha")
                id = myReader.GetInt32("usuario_id")
                senha2 = txt_senha.Text

                If senha = senha2 Then
                    Dim usuario = New usuario(id, user, nome, True)
                    Me.Close()
                    Principal.Opacity = 1
                    Principal.Show()
                Else
                    MessageBox.Show("Senha incorreta", "Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                End If

                myReader.Close()
            Else
                MessageBox.Show("usuário " & txt_usuario.Text & " não existe", "Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub txt_usuario_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_usuario.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return Then
            txt_senha.Focus()
        End If
        If KeyCode = System.Windows.Forms.Keys.Escape Then
            End
        End If
    End Sub
    Private Sub txt_senha_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txt_senha.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        If KeyCode = System.Windows.Forms.Keys.Return Then
            btn_entrar_Click()
        End If
        If KeyCode = System.Windows.Forms.Keys.Escape Then
            End
        End If
    End Sub

End Class