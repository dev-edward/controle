Imports System.Data.SqlClient
Public Class globalConexao
    Public Shared conexao As SqlConnection
    Public Shared consulta As SqlCommand
    Public Shared myReader As SqlDataReader
    Public Shared initial As String = "Initial Catalog=controle;"
    Public Shared data As String = "Data Source=localhost;Integrated Security=SSPI;"

    Friend Sub conectar()
        conexao = New SqlConnection(initial & data)

    End Sub
End Class
