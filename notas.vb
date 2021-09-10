Imports System.Data.SqlClient
Public Class notas
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim fk As Integer
    Dim num As Integer
    Dim posicaoY As Integer
    Dim idNota As Integer
    Dim conteiner As New Panel
    Dim txt_novaNota As New TextBox
    Dim btn_addNota As New Button

    Friend Sub New(ByVal _fk As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        fk = _fk

    End Sub
    Private Sub notas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        'especuficos
        conteiner.BorderStyle = BorderStyle.FixedSingle
        'conteiner.AutoScroll =True

        Me.Controls.Add(txt_novaNota)
        Me.Controls.Add(btn_addNota)
        Me.Controls.Add(conteiner)

        atualizar()

    End Sub
    Private Sub atualizar()
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
                    Dim panel As New Panel
                    Dim btn_notaNum As New Button
                    Dim txt_nota As New TextBox
                    Dim btn_excluir As New Button

                    'posição dos controles
                    panel.Location = New Point(posicaoY, 0)
                    btn_notaNum.Location = New Point(0, 0)
                    txt_nota.Location = New Point(55, 0)
                    btn_excluir.Location = New Point(270, 0)

                    'tamanho dos controles
                    btn_notaNum.Size = New Size(50, 30)
                    txt_nota.Size = New Size(190, 30)
                    btn_excluir.Size = New Size(50, 30)

                    'especuficos
                    btn_notaNum.ForeColor = Color.FromArgb(255, 255, 255, 255)
                    btn_notaNum.TextAlign = ContentAlignment.TopRight
                    btn_notaNum.Font = New Font("Impact", 10)
                    btn_notaNum.BackgroundImage = img.notas
                    btn_notaNum.BackgroundImageLayout = ImageLayout.Zoom
                    btn_notaNum.Text = num
                    txt_nota.Multiline = True
                    btn_excluir.BackgroundImage = img.xis
                    btn_excluir.BackgroundImageLayout = ImageLayout.Zoom
                    panel.Width = 300
                    panel.BorderStyle = BorderStyle.FixedSingle

                    AddHandler btn_excluir.Click, AddressOf excluir

                    'conteudo
                    idNota = myReader.GetInt32("nota_id")
                    txt_nota.Text = myReader.GetInt32("nota_nota")

                    panel.Controls.Add(btn_notaNum)
                    conteiner.Controls.Add(panel)

                    posicaoY += panel.Height
                    num += 1
                Loop
            Else
                Dim label As New Label
                label.Text = "Este item ainda não possui notas"
                label.Location = New Point(0, 40)
                label.Size = New Size(300, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub excluir()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "update tb_notaitem set nota_excluido = 1 where nota_id = " & idNota
            conexao.Open()
            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro ao excluir nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        atualizar()

    End Sub

End Class