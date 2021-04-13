Imports System.Data.SqlClient

Public Class principal
    Inherits System.Windows.Forms.Form

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub CadastrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastrarToolStripMenuItem.Click
        Dim cadAfazer As New cadAfazer
        cadAfazer.MdiParent = Me
        cadAfazer.Show()

    End Sub

    Private Sub VerListaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListaToolStripMenuItem.Click
        Dim verAfazer As New verAfazer
        verAfazer.MdiParent = Me
        verAfazer.WindowState = FormWindowState.Maximized
        verAfazer.Show()

    End Sub
End Class
