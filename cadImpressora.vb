Public Class cadImpressora
    Dim panel As New Panel()
    Dim lbl_modelo As New Label()
    Dim txt_modelo As New TextBox()
    Dim lbl_nserie As New Label()
    Dim txt_nserie As New TextBox()
    Dim lbl_ip As New Label()
    Dim txt_ip As New TextBox()
    Dim lbl_dtentrada As New Label()
    Dim dtp_dtentrada As New DateTimePicker()
    Dim lbl_tipotoner As New Label()
    Dim cbx_tipotoner As New ComboBox()
    Dim rdb_corpb As New RadioButton()
    Dim rdb_corcl As New RadioButton()
    Dim lbl_estado As New Label()
    Dim cbx_estado As New ComboBox()

    Private Sub cadImpressora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'adicionando controles ao panel
        panel.Controls.Add(lbl_modelo)
        panel.Controls.Add(txt_modelo)
        panel.Controls.Add(lbl_nserie)
        panel.Controls.Add(txt_nserie)
        panel.Controls.Add(lbl_ip)
        panel.Controls.Add(txt_ip)
        panel.Controls.Add(lbl_dtentrada)
        panel.Controls.Add(dtp_dtentrada)
        panel.Controls.Add(lbl_tipotoner)
        panel.Controls.Add(cbx_tipotoner)
        panel.Controls.Add(rdb_corpb)
        panel.Controls.Add(rdb_corcl)
        panel.Controls.Add(lbl_estado)
        panel.Controls.Add(cbx_estado)


    End Sub
End Class