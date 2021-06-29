Imports System.Data.SqlClient

Public Class principal
    Inherits System.Windows.Forms.Form

    Private Sub principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.ShowInTaskbar = False
        Dim frm_login As New Login()
        Login.ShowDialog()

    End Sub

    Private Sub AfazerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AfazerToolStripMenuItem.Click
        If (Application.OpenForms.OfType(Of listarAfazer).Any()) Then
            Application.OpenForms.OfType(Of listarAfazer).First().BringToFront()
        Else
            Dim verAfazer = New listarAfazer
            verAfazer.MdiParent = Me
            verAfazer.Dock = DockStyle.Left
            verAfazer.ShowIcon = False
            verAfazer.MaximizeBox = False
            verAfazer.Show()
        End If
    End Sub

    Private Sub ImpressoraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImpressoraToolStripMenuItem.Click

        Dim listarImpressora = New listarImpressora
        listarImpressora.MdiParent = Me
        listarImpressora.Dock = DockStyle.Left
        listarImpressora.ShowIcon = False
        listarImpressora.MaximizeBox = False
        listarImpressora.Show()

        'If (Application.OpenForms.OfType(Of cadImpressora).Any()) Then
        '    Application.OpenForms.OfType(Of cadImpressora).First().BringToFront()
        'Else
        '    Dim cadImpressora = New cadImpressora
        '    cadImpressora.MdiParent = Me
        '    cadImpressora.Dock = DockStyle.Left
        '    cadImpressora.ShowIcon = False
        '    cadImpressora.MaximizeBox = False
        '    cadImpressora.Show()
        'End If
    End Sub

    Private Sub ComputadorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComputadorToolStripMenuItem.Click

    End Sub
End Class
