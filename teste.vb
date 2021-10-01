Public Class teste
    Dim fontBT = New Font("Arial", 72, FontStyle.Bold)
    Dim recadoBT As String
    Dim brushBT As New SolidBrush(Color.FromArgb(140, 200, 200, 255))


    Dim Format As New StringFormat With {
        .LineAlignment = StringAlignment.Center,
        .Alignment = StringAlignment.Center
    }
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub teste_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim bmpBG = Bitmap.FromFile("..\..\..\img\background\orig.jpg")
        Dim newImage = New Bitmap(bmpBG.Width, bmpBG.Height)
        Dim gr = Graphics.FromImage(newImage)
        Dim rectBT1 As New RectangleF(0, 200, bmpBG.Width, 200)
        Dim rectBT2 As New RectangleF(200, 600, bmpBG.Width - 400, 900)
        recadoBT = ""
        'txt_mensagem.Text

        gr.DrawImageUnscaled(bmpBG, 0, 0)
        gr.DrawString("Aviso", fontBT, brushBT, rectBT1, Format)

        gr.DrawString(recadoBT, fontBT, brushBT, rectBT2, Format)

        newImage.Save("..\..\..\img\background\newImg.jpg")
    End Sub

    Private Sub BindingSource1_CurrentChanged(sender As Object, e As EventArgs) Handles BindingSource1.CurrentChanged

    End Sub
End Class