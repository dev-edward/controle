Imports System.Data.SqlClient
Public Class listarNotas
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim fk As Integer
    Dim num As Integer
    Dim posicaoY As Integer
    Dim conteiner As New Panel
    Dim txt_novaNota As New TextBox
    Dim btn_addNota As New Button

    Friend Sub New(ByVal _fk As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        fk = _fk

    End Sub

    Private Sub listarNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 420)

        'posição dos controles
        conteiner.Location = New Point(10, 10)
        txt_novaNota.Location = New Point(10, 380)
        btn_addNota.Location = New Point(260, 380)

        'tamanho dos controles
        conteiner.Size = New Point(300, 360)
        txt_novaNota.Size = New Size(240, 30)
        btn_addNota.Size = New Size(50, 30)

        'específicos
        conteiner.BorderStyle = BorderStyle.FixedSingle
        btn_addNota.BackgroundImage = img.mais
        btn_addNota.BackgroundImageLayout = ImageLayout.Zoom
        btn_addNota.FlatStyle = FlatStyle.Popup
        conteiner.AutoScroll = True

        AddHandler btn_addNota.Click, AddressOf addNota

        Me.Controls.Add(txt_novaNota)
        Me.Controls.Add(btn_addNota)
        Me.Controls.Add(conteiner)

        atualizar()

    End Sub

    Public Sub atualizar()
        conteiner.Controls.Clear()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select nota_id, nota_nota from tb_notaitem where nota_fkitem = " & fk & " and (nota_excluido = 0 or nota_excluido is null)"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            num = 1
            posicaoY = 10
            If myReader.HasRows Then
                Do While myReader.Read()
                    Dim id As Integer = myReader.GetInt32("nota_id")
                    Dim textoNota As String = myReader.GetString("nota_nota")
                    Dim notas As New Nota(Me, conteiner, id, textoNota, posicaoY, num)
                    posicaoY += 44
                    num += 1
                Loop
            Else
                Dim label As New Label
                label.Text = "Este item ainda não possui notas"
                label.Location = New Point(0, 40)
                label.Size = New Size(280, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub addNota()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "insert into tb_notaitem(nota_fkitem,nota_nota) values(@fk,@nota)"
            consulta.Parameters.AddWithValue("@fk", fk)
            consulta.Parameters.AddWithValue("@nota", txt_novaNota.Text)

            conexao.Open()
            consulta.ExecuteNonQuery()
            txt_novaNota.Text = ""

        Catch ex As Exception
            MessageBox.Show("Erro adicionar nova nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        atualizar()

    End Sub
End Class