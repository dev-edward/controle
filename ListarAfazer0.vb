Imports System.Data.SqlClient

Public Class ListarAfazer0
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Class Afazer
        'Create ADO.NET objects.
        Private conexao As SqlConnection
        Private consulta As SqlCommand
        Private myReader As SqlDataReader

        Dim id As Integer
        Dim fk As Integer
        Dim panel As New Panel()
        Dim txt_titulo As New TextBox()
        Dim btn_notas As New Button()
        Dim btn_estado As New Button()
        Dim btn_vermais As New Button()

        'fonte padrão
        Dim fonte As New Font("Microsoft Sans Serif", 12)

        Friend Sub New(ByVal _conteiner As Panel, ByVal _id As Integer, ByVal _fkitem As Integer, ByVal _titulo As String, ByVal _prazo As DateTime, ByVal _estado As Integer, ByVal _panelY As Integer)
            'adicionando controles no panel
            panel.Controls.Add(txt_titulo)

            'colocando fonte 12 para todos os itens
            txt_titulo.Font = fonte

            'conteudo dos controles extraido do BD
            txt_titulo.Text = _titulo

            'tamanho dos controles
            panel.Size = New Size(660, 170)
            txt_titulo.Size = New Size(260, 26)

            'lbl_titulo.BackColor = New Color().FromArgb(255, 215, 0, 0)

            'posição dos controles
            panel.Location = New Point(0, _panelY)



            'configurações especificas
            panel.BorderStyle = BorderStyle.FixedSingle
            txt_titulo.ReadOnly = True

            'vinculando funções aos botões
            AddHandler btn_notas.Click, AddressOf btn_notas_Click


            _conteiner.Controls.Add(panel)


        End Sub

        Private Sub atualizarDados()

        End Sub

        Private Sub btn_notas_Click()

            Dim frm_addNotas As New addNotas(Me.fk)
            'addNotas.MdiParent =
            frm_addNotas.ShowDialog()
        End Sub

    End Class

    Friend Sub New(ByVal _form As Form)
        Dim conteiner = New Panel

        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        consulta = conexao.CreateCommand
        consulta.CommandText = "select afazer_id, afazer_fkitem, afazer_titulo, afazer_prazo, afazer_status from tb_afazer ORDER BY afazer_id desc OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY"

        conexao.Open()

        myReader = consulta.ExecuteReader()

        Dim panelY As Integer
        panelY = 50

        Do While myReader.Read()
            Dim id As Integer
            Dim fkitem As Integer
            Dim titulo As String
            Dim prazo As DateTime
            Dim estado As String

            id = myReader.GetInt32(0)
            fkitem = myReader.GetInt32(1)
            titulo = myReader.GetString(2)
            prazo = myReader.GetDateTime(3)
            estado = myReader.GetByte(4)

            Dim afazer1 As New Afazer(conteiner, id, fkitem, titulo, prazo, estado, panelY)
            panelY += 180
        Loop
        conteiner.Location = New Point((_form.Width - conteiner.Width) / 2, 2)
        conteiner.AutoSize = True
        conteiner.BackColor = New Color().FromArgb(255, 0, 0, 150)
        _form.Controls.Add(conteiner)

        myReader.Close()
        conexao.Close()
    End Sub

    Private Sub btn_cadastrar_Click()
        'Dim CadastrarAfazer = New cadastrarAfazer
        'CadastrarAfazer.MdiParent = Principal
        'CadastrarAfazer.ShowIcon = False
        'CadastrarAfazer.MaximizeBox = False
        ''cadastrarAfazer.Dock = DockStyle.Left
        ''Me.Dock = DockStyle.Right
        'CadastrarAfazer.Show()
        'Me.Refresh()
        ''Principal.LayoutMdi(MdiLayout.TileVertical)

        ''If (Application.OpenForms.OfType(Of cadastrarAfazer).Any()) Then
        ''    Application.OpenForms.OfType(Of cadastrarAfazer).First().BringToFront()
        ''Else
        ''    'Dim CadastrarAfazer = New cadastrarAfazer
        ''    cadastrarAfazer.MdiParent = Principal
        ''    cadastrarAfazer.ShowIcon = False
        ''    cadastrarAfazer.MaximizeBox = False
        ''    cadastrarAfazer.Dock = DockStyle.Left
        ''    'Me.Dock = DockStyle.Right
        ''    cadastrarAfazer.Show()
        ''    Me.Refresh()
        ''    Principal.LayoutMdi(MdiLayout.TileVertical)
        ''End If

    End Sub
    Private Sub btn_atualizar_Click()
        'Principal.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

End Class