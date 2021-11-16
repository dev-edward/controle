Imports System.Data.SqlClient
Public Class DispositivoCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim pk As Integer
    Dim tamanho As New Size(260, 30)
    Dim fonte As New Font("Microsoft Sans Serif", 12)

    Dim frm_evento As New Form With {
        .Text = "Cadastrar dispositivo",
        .ClientSize = New Size(320, 320),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }

    Friend Sub New()

    End Sub
    Friend Sub New(pk)

    End Sub
End Class
