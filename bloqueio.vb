Public Class bloqueio
    Dim skValor As String
    Dim skParent As Microsoft.Win32.RegistryKey
    Dim fontBT = New Font("Arial", 72, FontStyle.Bold)
    Dim recadoBT As String
    Dim brushBT As New SolidBrush(Color.FromArgb(140, 200, 200, 255))

    Dim Format As New StringFormat With {
        .LineAlignment = StringAlignment.Center,
        .Alignment = StringAlignment.Center
    }
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim bmpBG = Bitmap.FromFile("..\..\..\img\background\orig.jpg")
        'Dim newImage = New Bitmap(bmpBG.Width, bmpBG.Height)
        'Dim gr = Graphics.FromImage(newImage)
        'Dim rectBT1 As New RectangleF(0, 200, bmpBG.Width, 200)
        'Dim rectBT2 As New RectangleF(200, 600, bmpBG.Width - 400, 900)
        'recadoBT = txt_mensagem.Text

        'gr.DrawImageUnscaled(bmpBG, 0, 0)
        'gr.DrawString("Aviso", fontBT, brushBT, rectBT1, Format)

        'gr.DrawString(recadoBT, fontBT, brushBT, rectBT2, Format)

        'newImage.Save("..\..\..\img\background\newImg.jpg")

        'adicionando chave para alterar a imagem da tela de bloqueio
        'subkeyBT = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP")

        skValor = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImagePath", Nothing)

        If (skValor IsNot Nothing) Then
            skParent = My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\", True)
            skParent.CreateSubKey("PersonalizationCSP", True)
            My.Computer.Registry.SetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImagePath", "\backgroundBT\newImg.jpg")
            skValor = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\PersonalizationCSP", "LockScreenImagePath", Nothing)
            MsgBox(skValor)

        Else
            Try
            Catch ex As Exception
                MsgBox(ex)
            End Try

        End If

    End Sub

    Private Sub rbt_outro_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_outro.CheckedChanged
        txt_mensagem.Text = ""
    End Sub

    Private Sub rbt_banheiro_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_banheiro.CheckedChanged
        txt_mensagem.Text = "Fui ao banheiro, eu já volto"

    End Sub

    Private Sub rbt_almoco_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_almoco.CheckedChanged
        txt_mensagem.Text = "Estou no horário de almoço, previsão de volta: " & TimeOfDay.AddMinutes(62)

    End Sub

    Private Sub rbt_setor_CheckedChanged(sender As Object, e As EventArgs) Handles rbt_setor.CheckedChanged
        txt_mensagem.Text = "Estarei no setor "

    End Sub
End Class