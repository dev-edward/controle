Imports System.Data.SqlClient
Public Class EventoCadastroAlteracao
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader

    Dim tamanho As New Size(260, 30)
    Dim fonte As New Font("Microsoft Sans Serif", 12)

    Dim pk As Integer
    Dim frm_evento As New Form With {
        .Name = "EventoCadAlt",
        .Text = "Cadastrar evento",
        .ClientSize = New Size(320, 320),
        .FormBorderStyle = FormBorderStyle.FixedSingle,
        .MaximizeBox = False,
        .Location = New Point(Screen.FromControl(Principal).WorkingArea.X + 310, Screen.FromControl(Principal).WorkingArea.Y + 120)
    }
    Dim lbl_descricao As New Label With {
        .Text = "Descrição do evento",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 10)
    }
    Dim txt_descricao As New TextBox With {
        .Size = tamanho,
        .Font = fonte,
        .Location = New Point(29, 40)
    }
    Dim lbl_data As New Label With {
        .Text = "Data e horario do evento",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 70)
    }
    Dim dtp_data As New DateTimePicker With {
        .Size = tamanho,
        .Font = fonte,
        .Format = DateTimePickerFormat.Custom,
        .CustomFormat = "dd/MM/yy HH:mm",
        .Location = New Point(29, 100)
    }
    Dim lbl_frequencia As New Label With {
        .Text = "Frequência",
        .Font = fonte,
        .Size = tamanho,
        .TextAlign = ContentAlignment.MiddleCenter,
        .Location = New Point(29, 130)
    }
    Dim cmb_frequencia As New ComboBox With {
        .Font = fonte,
        .Size = tamanho,
        .DropDownStyle = ComboBoxStyle.DropDownList,
        .Location = New Point(29, 160)
    }
    Dim WithEvents cbx_allday As New CheckBox With {
        .Text = "Qualquer horario",
        .Font = fonte,
        .Size = New Size(160, 30),
        .Location = New Point(29, 190),
        .CheckAlign = ContentAlignment.MiddleLeft,
        .TextAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat
    }
    Dim cbx_ativo As New CheckBox With {
        .Text = "Ativo",
        .Font = fonte,
        .Size = New Size(100, 30),
        .Location = New Point(190, 190),
        .CheckAlign = ContentAlignment.MiddleLeft,
        .TextAlign = ContentAlignment.MiddleCenter,
        .FlatStyle = FlatStyle.Flat,
        .Checked = True
    }
    Dim btn_salvar As New Button With {
        .Text = "Salvar",
        .Font = fonte,
        .Size = New Size(260, 40),
        .Location = New Point(30, 250)
    }
    Friend Sub New()

        cmb_frequencia.Items.AddRange({"Uma vez", "Diário", "Semanal", "Mensal", "Anual"})
        cmb_frequencia.SelectedIndex = 0

        frm_evento.Controls.Add(lbl_descricao)
        frm_evento.Controls.Add(txt_descricao)
        frm_evento.Controls.Add(lbl_data)
        frm_evento.Controls.Add(dtp_data)
        frm_evento.Controls.Add(lbl_frequencia)
        frm_evento.Controls.Add(cmb_frequencia)
        frm_evento.Controls.Add(cbx_allday)
        frm_evento.Controls.Add(cbx_ativo)
        frm_evento.Controls.Add(btn_salvar)
        frm_evento.Show()
    End Sub
    Friend Sub New(ByVal _pk As Boolean)
        pk = _pk
        carregarDados()
    End Sub
    Private Sub cbx_allday_CheckedChanged(sender As Object, e As EventArgs) Handles cbx_allday.CheckedChanged
        If cbx_allday.Checked Then
            dtp_data.CustomFormat = "dd/MM/yy"
        Else
            dtp_data.CustomFormat = "dd/MM/yy HH:mm"
        End If
    End Sub
    Private Sub alternarReadOnly()

    End Sub
    Private Sub carregarDados()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)
            consulta = conexao.CreateCommand
            consulta.CommandText = "select 
                                        evento_id,
                                        evento_descricao, 
                                        evento_datahora, 
                                        evento_frequencia, 
                                        evento_allday, 
                                        evento_ativo
                                from tb_evento 
								where evento_id= " & pk

            conexao.Open()
            myReader = consulta.ExecuteReader()
            myReader.Read()

            txt_descricao.Text = myReader.GetString("evento_descricao")
            dtp_data.Value = myReader.GetDateTime("evento_datahora")
            cmb_frequencia.SelectedIndex = myReader.GetValue("evento_frequencia") - 1

            If myReader.GetValue("evento_allday") > 0 Then
                cbx_allday.Checked = True
                dtp_data.CustomFormat = "dd/MM/yy"
            End If
            If myReader.GetValue("evento_ativo") > 0 Then
                cbx_ativo.Checked = True
            End If

            Debug.WriteLine(pk)

        Catch ex As Exception
            MessageBox.Show("Erro ao carregar evento: " & ex.Message, "Classe EventoCadastroAlteração")
        Finally
            conexao.Close()
        End Try
    End Sub
End Class
