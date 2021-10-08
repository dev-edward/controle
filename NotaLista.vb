Imports System.Data.SqlClient
Public Class listarNotas
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim pkitem As Integer
    Dim tabela As String
    Dim num As Integer
    Dim idnota As Integer
    Dim textoNota As String
    Dim posicaoY As Integer
    Dim conteiner As New Panel
    Dim txt_novaNota As New RichTextBox
    Dim btn_addNota As New Button
    Dim demandaAtual As Demanda

    Friend Sub New(ByRef _demandaAtual As Demanda)
        classesAbertas.setAtualNotas(Me)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        demandaAtual = _demandaAtual
        pkitem = demandaAtual.pk
        tabela = "demanda"
    End Sub

    Private Sub listarNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 420)

        'posição dos controles
        conteiner.Location = New Point(10, 10)
        txt_novaNota.Location = New Point(10, 370)
        btn_addNota.Location = New Point(260, 375)

        'tamanho dos controles
        conteiner.Size = New Size(300, 350)
        txt_novaNota.Size = New Size(240, 40)
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

        atualizarLista()

    End Sub
    Friend Sub atualizarNovaLista(ByRef _demandaAtual As Demanda)
        demandaAtual = _demandaAtual
        pkitem = demandaAtual.pk
        atualizarLista()
    End Sub
    Friend Sub atualizarLista()

        conteiner.Controls.Clear()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = "select nota_id, nota_nota from tb_anotacao where nota_pkitem = " & pkitem & " and nota_tabela = '" & tabela & "' and nota_excluido is null"
            conexao.Open()

            myReader = consulta.ExecuteReader()

            num = 0
            posicaoY = 10
            If myReader.HasRows Then
                Do While myReader.Read()
                    num += 1
                    idnota = myReader.GetInt32("nota_id")
                    textoNota = myReader.GetString("nota_nota")
                    Dim notas As New Nota(conteiner, idnota, textoNota, posicaoY, num)
                    posicaoY += 44
                Loop
                If demandaAtual IsNot Nothing Then
                    demandaAtual.setQtdNotas(num)
                End If
            Else
                Dim label As New Label
                label.Text = "Este item ainda não possui notas"
                label.Location = New Point(0, 40)
                label.Size = New Size(280, 40)
                label.TextAlign = ContentAlignment.MiddleCenter
                conteiner.Controls.Add(label)

            End If
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas 01: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub addNota()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "insert into tb_anotacao(nota_pkitem,nota_tabela,nota_nota) values(@fk,@tabela,@nota)"
            consulta.Parameters.AddWithValue("@fk", pkitem)
            consulta.Parameters.AddWithValue("@tabela", tabela)
            consulta.Parameters.AddWithValue("@nota", txt_novaNota.Text)

            conexao.Open()
            consulta.ExecuteNonQuery()
            txt_novaNota.Text = ""

        Catch ex As Exception
            MessageBox.Show("Erro adicionar nova nota: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

        atualizarLista()

    End Sub
End Class