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

    Class Nota
        Private conexao As SqlConnection
        Private consulta As SqlCommand
        Private myReader As SqlDataReader
        Dim parent
        Dim panel As New Panel
        Dim lbl_notaNum As New Label
        Dim txt_nota As New TextBox
        Dim btn_excluir As New Button

        Dim idNota As Integer
        Friend Sub New(ByVal _parent As listarNotas, ByRef _conteiner As Panel, ByVal _id As Integer, ByVal _textoNota As String, ByVal _posicaoY As Integer, ByVal _num As Integer)

            idNota = _id

            'posição dos controles
            panel.Location = New Point(0, _posicaoY)
            lbl_notaNum.Location = New Point(0, 0)
            txt_nota.Location = New Point(35, 0)
            btn_excluir.Location = New Point(225, 0)

            'tamanho dos controles
            lbl_notaNum.Size = New Size(30, 30)
            txt_nota.Size = New Size(190, 30)
            btn_excluir.Size = New Size(50, 30)

            'especuficos
            lbl_notaNum.ForeColor = Color.FromArgb(255, 15, 15, 15)
            lbl_notaNum.TextAlign = ContentAlignment.MiddleCenter
            lbl_notaNum.Font = New Font("Impact", 12)
            lbl_notaNum.Text = _num
            txt_nota.Multiline = True
            txt_nota.Text = _textoNota
            btn_excluir.BackgroundImage = img.xis
            btn_excluir.BackgroundImageLayout = ImageLayout.Zoom
            btn_excluir.FlatStyle = FlatStyle.Popup
            panel.Size = New Size(300, 34)

            AddHandler btn_excluir.Click, AddressOf excluir

            panel.Controls.Add(lbl_notaNum)
            panel.Controls.Add(txt_nota)
            panel.Controls.Add(btn_excluir)
            _conteiner.Controls.Add(panel)

            parent = _parent
        End Sub

        Friend Sub excluir()
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

            parent.atualizar()

        End Sub

    End Class

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
                    posicaoY += 30
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
    Private Sub addNota()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "insert into tb_notaitem(nota_fkitem,nota_nota) values(@fk,@nota)"
            consulta.Parameters.AddWithValue("@fk", fk)
            consulta.Parameters.AddWithValue("@nota", txt_novaNota.Text)

            conexao.Open()
            consulta.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show("Erro adicionar nova nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        atualizar()
    End Sub
End Class