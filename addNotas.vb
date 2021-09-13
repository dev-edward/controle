Imports System.Data.SqlClient
Public Class addNotas
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim lbl_fkitem As New Label

    Friend Sub New(ByVal _fkitem As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().

        lbl_fkitem.Text = _fkitem
        lbl_fkitem.Location = New Point(0, 0)
        lbl_fkitem.Size = New Size(30, 10)
        Me.Controls.Add(lbl_fkitem)

        AddHandler btn_adicionar.Click, AddressOf btn_adicionar_Click
        AddHandler btn_cancelar.Click, AddressOf btn_cancelar_Click

    End Sub

    Private Sub btn_adicionar_Click()
        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

        consulta = conexao.CreateCommand
        consulta.CommandText = "insert into tb_notaitem(notaitem_fkitem,notaitem_nota) values(" & lbl_fkitem.Text & ",'" & txt_nota.Text & "')"

        conexao.Open()
        myReader = consulta.ExecuteReader()

        myReader.Close()
        conexao.Close()

        MsgBox("Nota adicionanda")

        Me.Close()

    End Sub

    Private Sub btn_cancelar_Click()
        Me.Close()
    End Sub

    Private Sub addNotas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
    End Sub

End Class