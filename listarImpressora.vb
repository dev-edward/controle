Imports System.Data.SqlClient
Public Class listarImpressora
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Class Impressora
        Dim panel As New Panel()
        Dim lbl_id As New Label()
        Dim lbl_fkitem As New Label()
        Dim lbl_dtcadastro As New Label()
        Dim lbl_usercadastro As New Label()
        Dim lbl_dtultalteracao As New Label()
        Dim lbl_userultalteracao As New Label()
        Dim lbl_modelo As New Label()
        Dim lbl_serie As New Label()
        Dim lbl_ip As New Label()
        Dim lbl_suprimento As New Label()
        Dim lbl_cor As New Label()
        Dim lbl_estado As New Label()
        Dim lbl_dtentrada As New Label()
        Dim lbl_dtsaida As New Label()

        'fonte padrão 
        Dim fonte As New Font("Microsoft Sans Serif", 12)

        Friend Sub New()
            'adicionando controles ao panel
            panel.Controls.Add(lbl_id)
            panel.Controls.Add(lbl_fkitem)
            panel.Controls.Add(lbl_dtcadastro)
            panel.Controls.Add(lbl_usercadastro)
            panel.Controls.Add(lbl_dtultalteracao)
            panel.Controls.Add(lbl_userultalteracao)
            panel.Controls.Add(lbl_modelo)
            panel.Controls.Add(lbl_serie)
            panel.Controls.Add(lbl_ip)
            panel.Controls.Add(lbl_suprimento)
            panel.Controls.Add(lbl_cor)
            panel.Controls.Add(lbl_estado)
            panel.Controls.Add(lbl_dtentrada)
            panel.Controls.Add(lbl_dtsaida)


        End Sub

    End Class

    Private Sub listarImpressora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id As Integer
        Dim fkitem As Integer
        Dim dtcadastro As DateTime
        Dim usercadastro As Integer
        Dim dtultalteracao As DateTime
        Dim userultalteracao
        Dim modelo As String
        Dim serie As String
        Dim ip As String
        Dim suprimento As Integer
        Dim cor As Integer
        Dim estado As Integer
        Dim dtentrada As DateTime
        Dim dtsaida As DateTime

        conexao = New SqlConnection(globalConexao.initial & globalConexao.data)


        consulta = conexao.CreateCommand
        consulta.CommandText = "select impressora_marcamodelo from tb_impressora where impressora_id=1002"

        conexao.Open()
        myReader = consulta.ExecuteReader()
        myReader.Read()
        modelo = myReader.GetString(0)


        myReader.Close()
        conexao.Close()



    End Sub

End Class