Imports System.Data.SqlClient
Public Class ImpressoraCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Private novoid As Integer
    Dim tamanholbl As New Size(170, 30)
    Dim fonte As New Font("Microsoft Sans Serif", 12)
    Dim pk As Integer
    Const tabela As String = "evento"

    Dim lbl_maxchar As New Label With {
        .Size = New Size(50, 16),
        .BackColor = Color.Azure,
        .TextAlign = ContentAlignment.MiddleCenter,
        .BorderStyle = BorderStyle.FixedSingle
    }
    Dim frm_impressora As New Form With {
        .Text = "Cadastrar nova impressora",
        .ClientSize = New Size(320, 300),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .StartPosition = FormStartPosition.Manual,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_nserie As New Label With {
        .Text = "Número de série",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(10, 10)
    }
    Dim txt_nserie As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nserie.Location.Y),
        .MaxLength = 12
    }
    Dim lbl_nnota As New Label With {
        .Text = "Número da nota",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(lbl_nserie.Location.X, lbl_nserie.Location.Y + tamanholbl.Height)
    }
    Dim txt_nnota As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nnota.Location.Y),
        .MaxLength = 16
    }
    Dim lbl_nproduto As New Label With {
        .Text = "Número do produto",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(lbl_nserie.Location.X, lbl_nnota.Location.Y + tamanholbl.Height)
    }
    Dim txt_nproduto As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_nproduto.Location.Y),
        .MaxLength = 16
    }
    Dim lbl_marcaModelo As New Label With {
        .Text = "Marca/Modelo",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(lbl_nserie.Location.X, lbl_nproduto.Location.Y + tamanholbl.Height)
    }
    Dim txt_marcaModelo As New TextBox With {
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_marcaModelo.Location.Y),
        .MaxLength = 24
    }
    Dim lbl_suprimento As New Label With {
        .Text = "Suprimento",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(lbl_nserie.Location.X, lbl_marcaModelo.Location.Y + tamanholbl.Height)
    }
    Dim cmb_suprimento As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_suprimento.Location.Y)
    }
    Dim lbl_ip As New Label With {
        .Text = "IP: ",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.TopRight,
        .Location = New Point(lbl_nserie.Location.X, lbl_suprimento.Location.Y + tamanholbl.Height)
    }
    Dim txt_ip As New MaskedTextBox With {
        .Size = New Size(160, 30),
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_ip.Location.Y),
        .Mask = "###.###.###.###"
    }
    Dim lbl_cor As New Label With {
        .Text = "Cor da impressão",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(lbl_nserie.Location.X, lbl_ip.Location.Y + tamanholbl.Height)
    }
    Dim rbt_cor As New RadioButton With {
        .Text = "Colorida",
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(lbl_nserie.Location.X + tamanholbl.Width, lbl_ip.Location.Y),
    }
    Dim rbt_peb As New RadioButton With {
        .Text = "Preto & Branco",
        .Size = tamanholbl,
        .Font = fonte,
        .Location = New Point(29, 40)
    }
    Dim lbl_local As New Label With {
        .Text = "Local",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim cbm_local As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(29, 160)
    }
    Dim lbl_estado As New Label With {
        .Text = "Estado",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim cbm_estado As New ComboBox With {
        .Font = fonte,
        .Size = tamanholbl,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(29, 160)
    }
    Dim lbl_dtentrada As New Label With {
        .Text = "Data de entrada",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim dtp_dtentrada As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short
    }
    Dim lbl_dtsaida As New Label With {
        .Text = "Data de saída",
        .Font = fonte,
        .Size = tamanholbl,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim dtp_dtsaida As New DateTimePicker With {
        .Font = fonte,
        .Size = tamanholbl,
        .Format = DateTimePickerFormat.Short
    }
    Friend Sub New()
        iniciar()
    End Sub
    Friend Sub New(ByVal _pk As Integer)
        iniciar()
    End Sub
    Private Sub iniciar()
        frm_impressora.Show()
    End Sub

End Class
