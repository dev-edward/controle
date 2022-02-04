Imports System.Data.SqlClient
Public Class EmailCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(260, 26)
    Dim tamanhobtn As New Size(130, 40)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "email"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_email As New Form With {
        .Text = "Cadastrar novo email",
        .ClientSize = New Size(300, 340),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_nome As New Label With {
        .Text = "Nome",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(20, 10),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_nome As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 40,
        .Location = New Point(lbl_nome.Location.X, lbl_nome.Location.Y + tamanholbl.Height)
    }
    Dim lbl_setor As New Label With {
        .Text = "Setor",
        .Font = fonte,
        .Size = tamanholbl,
        .Location = New Point(lbl_nome.Location.X, lbl_nome.Location.Y + tamanholbl.Height),
        .TextAlign = ContentAlignment.BottomCenter
    }
    Dim txt_setor As New TextBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .MaxLength = 30,
        .Location = New Point(lbl_nome.Location.X, lbl_nome.Location.Y + tamanholbl.Height)
    }

End Class
