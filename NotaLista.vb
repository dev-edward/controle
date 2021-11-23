Imports System.Data.SqlClient
Public Class listarNotas
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim pkitem As Integer
    Dim tabela As String
    Dim btnnotas As Button
    Dim num As Integer
    Dim idnota As Integer
    Dim textoNota As String
    Dim posicaoY As Integer
    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim conteiner As New Panel With {
        .Location = New Point(10, 10),
        .Size = New Size(300, 350),
        .BorderStyle = BorderStyle.FixedSingle,
        .AutoScroll = True
    }
    Dim WithEvents txt_novaNota As New RichTextBox With {
        .Location = New Point(10, 370),
        .Size = New Size(240, 40),
        .MaxLength = 256
    }
    Dim btn_addNota As New Button With {
        .Location = New Point(260, 375),
        .Size = New Size(50, 30),
        .BackgroundImage = img.mais,
        .BackgroundImageLayout = ImageLayout.Zoom,
        .FlatStyle = FlatStyle.Popup
    }
    Dim label As New Label With {
        .Text = "Este item ainda não possui notas",
        .Location = New Point(0, 40),
        .Size = New Size(280, 40),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim posicaoInicial As New Point(Screen.FromControl(Principal).WorkingArea.X + 620, Screen.FromControl(Principal).WorkingArea.Y + 150)

    Friend Sub New(ByVal _pkitem As Integer, ByVal _tabela As String, ByRef _btnnotas As Button)
        ' Esta chamada é requerida pelo designer.
        InitializeComponent()
        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        classesAbertas.setAtualNotas(Me)
        Me.Location = posicaoInicial
        pkitem = _pkitem
        tabela = _tabela
        btnnotas = _btnnotas

    End Sub
    Private Sub listarNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.ClientSize = New Size(320, 420)

        AddHandler btn_addNota.Click, AddressOf addNota

        AddHandler txt_novaNota.KeyUp, AddressOf txt_KeyUp
        AddHandler txt_novaNota.GotFocus, AddressOf txt_GotFocus
        AddHandler txt_novaNota.LostFocus, AddressOf txt_LostFocus

        Me.Controls.Add(txt_novaNota)
        Me.Controls.Add(btn_addNota)
        Me.Controls.Add(conteiner)

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

            Else
                conteiner.Controls.Add(label)
            End If
            'If demandaAtual IsNot Nothing Then
            '    demandaAtual.setQtdNotas(num)
            'End If
            myReader.Close()
            btnnotas.Text = If(num > 0, num, "")
        Catch ex As Exception
            MessageBox.Show("Erro ao obter notas 01: " & ex.Message, "Insert Records")
        Finally
            conexao.Close()
        End Try

    End Sub
    Private Sub addNota()
        If txt_novaNota.Text <> "" Then
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
                MessageBox.Show("Erro ao adicionar nova nota: " & ex.Message, "Insert Records")
            Finally
                conexao.Close()
            End Try

            atualizarLista()
        End If
    End Sub
    Private Sub txt_KeyUp(sender As Object, e As EventArgs)
        lbl_maxchar.Text = "(" & sender.TextLength & "/" & sender.MaxLength & ")"
        If (sender.TextLength > 0 And Not lbl_maxchar.Visible) Then
            lbl_maxchar.Visible = True
        End If
    End Sub
    Private Sub txt_GotFocus(sender As Object, e As EventArgs)
        lbl_maxchar.Location = New Point(sender.location.x + 6, sender.location.y - 16)
        Me.Controls.Add(lbl_maxchar)
        lbl_maxchar.BringToFront()
        If (sender.TextLength = 0) Then
            lbl_maxchar.Visible = False
        End If
    End Sub
    Private Sub txt_LostFocus(sender As Object, e As EventArgs)
        Me.Controls.Remove(lbl_maxchar)
    End Sub
End Class