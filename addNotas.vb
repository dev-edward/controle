Imports System.Data.SqlClient
Public Class addNotas
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Friend Sub New(ByVal _fkitem As Integer)

        ' Esta chamada é requerida pelo designer.
        InitializeComponent()

        ' Adicione qualquer inicialização após a chamada InitializeComponent().
        Dim lbl_fkitem As New Label
        lbl_fkitem.Text = _fkitem
        lbl_fkitem.Location = New Point(0, 0)
        Me.Controls.Add(lbl_fkitem)

        AddHandler btn_adicionar.Click, AddressOf btn_adicionar_Click
        AddHandler btn_cancelar.Click, AddressOf btn_cancelar_Click

    End Sub

    Private Sub btn_adicionar_Click()
        MsgBox(lbl_fkitem.Text)
    End Sub

    Private Sub btn_cancelar_Click()
        Me.Close()
    End Sub





End Class