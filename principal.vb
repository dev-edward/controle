Imports System.Data.SqlClient

Public Class principal
    Inherits System.Windows.Forms.Form

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub

    Private Sub CadastrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CadastrarToolStripMenuItem.Click
        'Dim cadAfazer As New cadAfazer
        'cadAfazer.MdiParent = Me
        'cadAfazer.Show()

        If (Application.OpenForms.OfType(Of cadAfazer).Any()) Then
            Application.OpenForms.OfType(Of cadAfazer).First().BringToFront()
        Else
            Dim cadAfazer = New cadAfazer
            cadAfazer.MdiParent = Me
            'cadAfazer.WindowState = FormWindowState.Maximized
            cadAfazer.Show()
        End If

    End Sub

    Private Sub VerListaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerListaToolStripMenuItem.Click
        'Dim verAfazer As New verAfazer
        'verAfazer.MdiParent = Me
        'verAfazer.WindowState = FormWindowState.Maximized
        'verAfazer.Show()

        If (Application.OpenForms.OfType(Of verAfazer).Any()) Then
            Application.OpenForms.OfType(Of verAfazer).First().BringToFront()
        Else
            Dim verAfazer = New verAfazer
            verAfazer.MdiParent = Me
            'verAfazer.WindowState = FormWindowState.Maximized
            verAfazer.Show()
        End If

    End Sub

    Private Sub CadastrarToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles CadastrarToolStripMenuItem6.Click
        If (Application.OpenForms.OfType(Of cadImpressora).Any()) Then
            Application.OpenForms.OfType(Of cadImpressora).First().BringToFront()
        Else
            Dim verAfazer = New cadImpressora
            cadImpressora.MdiParent = Me
            'cadImpressora.WindowState = FormWindowState.Maximized
            cadImpressora.Show()
        End If
    End Sub
End Class
