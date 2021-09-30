﻿Imports System.Windows.Forms

Public Class Principal
    Dim topmost_esq As Boolean
    Dim topmost_dir As Boolean

    Dim ts_Esq As New ToolStrip With {
        .LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
        .GripStyle = ToolStripGripStyle.Hidden,
        .Padding = New Padding(30, 0, 30, 0),
        .BackColor = Color.FromArgb(255, 250, 209, 183)
    }
    Dim ts_Dir As New ToolStrip With {
        .LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow,
        .GripStyle = ToolStripGripStyle.Hidden,
        .Padding = New Padding(30, 0, 30, 0),
        .BackColor = Color.FromArgb(255, 250, 209, 183)
    }

    Dim mi_tmEsq As New ToolStripButton("", img.topmost)

    Dim spliterModo As Integer
    Dim mi_spliter As New ToolStripButton("", img.spliter3)

    'Public WithEvents splitconteiner_Esq As New SplitContainer
    Public splitconteiner_Esq As New SplitContainer With {
            .Orientation = System.Windows.Forms.Orientation.Horizontal,
            .Dock = DockStyle.Fill
        }
    Public splitconteiner_Dir As New SplitContainer With {
            .Orientation = System.Windows.Forms.Orientation.Horizontal,
            .Dock = DockStyle.Fill
        }

    Dim LateralEsquerda As New Form With {
            .FormBorderStyle = FormBorderStyle.None,
            .ControlBox = False,
            .StartPosition = FormStartPosition.Manual,
            .AutoScroll = True,
            .Text = " "
        }
    'Dim WithEvents FormCentral As New Form With {
    Dim FormCentral As New Form With {
            .ControlBox = False,
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.Manual,
            .AutoScroll = True
        }
    Dim LateralDireita As New Form With {
            .ControlBox = False,
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.Manual,
            .AutoScroll = True
        }
    Dim redimensionando = New Panel

    Dim mi_afazer As New ToolStripMenuItem("Afazer")

    Dim mi_eventos As New ToolStripMenuItem("Eventos")

    Dim mi_dispositivos As New ToolStripMenuItem("Dispositivos")
    Dim si_computador As New ToolStripMenuItem("Computador")
    Dim si_notebook As New ToolStripMenuItem("Notebook")
    Dim si_chromebook As New ToolStripMenuItem("Chromebook")
    Dim si_tablet As New ToolStripMenuItem("Tablet")
    Dim si_celular As New ToolStripMenuItem("Celular")

    Dim mi_impressora As New ToolStripMenuItem("Impressora")
    Dim mi_nobreak As New ToolStripMenuItem("Nobreak")
    Dim mi_projetor As New ToolStripMenuItem("Projetor")
    Dim mi_camera As New ToolStripMenuItem("Camera")

    Dim mi_contas As New ToolStripMenuItem("Contas")
    Dim si_email As New ToolStripMenuItem("E-mail")
    Dim si_skype As New ToolStripMenuItem("Skype")

    Dim mi_pessoas As New ToolStripMenuItem("Pessoas")
    Dim mi_estoque As New ToolStripMenuItem("Estoque")
    Dim mi_software As New ToolStripMenuItem("Sofware")
    Dim mi_bloquear As New ToolStripMenuItem("", img.cadeado)

    Dim mi_desconectar As New ToolStripMenuItem("Desconectar")

    Private Sub Principal_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        If Not topmost_esq Then
            LateralEsquerda.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4
        End If
        If Not topmost_dir Then
            LateralDireita.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4
        End If
        FormCentral.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4

        'LateralEsquerda.Width = 200
        'LateralDireita.Width = 200
        FormCentral.Width = Me.ClientSize.Width - (LateralDireita.Width + LateralEsquerda.Width) - 4

        LateralEsquerda.Location = New Point(0, 0)
        FormCentral.Location = New Point(LateralEsquerda.Width, 0)
        LateralDireita.Location = New Point(LateralEsquerda.Width + FormCentral.Width, 0)
    End Sub
    Private Sub Principal_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        LateralEsquerda.Hide()
        FormCentral.Hide()
        LateralDireita.Hide()
        Me.Controls.Add(redimensionando)
    End Sub

    Private Sub Principal_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        LateralEsquerda.Show()
        FormCentral.Show()
        LateralDireita.Show()
        Me.Controls.Remove(redimensionando)
    End Sub

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'itens do menustrip 
        mi_dispositivos.DropDownItems.Add(si_computador)
        mi_dispositivos.DropDownItems.Add(si_notebook)
        mi_dispositivos.DropDownItems.Add(si_chromebook)
        mi_dispositivos.DropDownItems.Add(si_tablet)
        mi_dispositivos.DropDownItems.Add(si_celular)
        mi_contas.DropDownItems.Add(si_email)
        mi_contas.DropDownItems.Add(si_skype)
        AddHandler mi_afazer.Click, AddressOf mi_afazer_Click
        AddHandler mi_eventos.Click, AddressOf mi_eventos_Click
        AddHandler si_computador.Click, AddressOf si_computador_Click
        AddHandler si_notebook.Click, AddressOf si_notebook_Click
        AddHandler si_chromebook.Click, AddressOf si_chromebook_Click
        AddHandler si_tablet.Click, AddressOf si_tablet_Click
        AddHandler si_celular.Click, AddressOf si_celular_Click
        AddHandler mi_impressora.Click, AddressOf mi_impressora_Click
        AddHandler mi_nobreak.Click, AddressOf mi_nobreak_Click
        AddHandler mi_projetor.Click, AddressOf mi_projetor_Click
        AddHandler mi_camera.Click, AddressOf mi_camera_Click
        AddHandler si_email.Click, AddressOf si_email_Click
        AddHandler si_skype.Click, AddressOf si_skype_Click
        AddHandler mi_pessoas.Click, AddressOf mi_pessoas_Click
        AddHandler mi_estoque.Click, AddressOf mi_estoque_Click
        AddHandler mi_software.Click, AddressOf mi_software_Click
        AddHandler mi_bloquear.Click, AddressOf mi_bloquear_Click
        AddHandler mi_desconectar.Click, AddressOf mi_desconectar_Click

        redimensionando.BackgroundImage = Image.FromFile("..\..\..\util\rezise-icon2.png")
        redimensionando.BackgroundImageLayout = ImageLayout.Center
        redimensionando.Dock = DockStyle.Fill

        splitconteiner_Esq.Panel1.BackColor = Color.FromArgb(255, 137, 189, 158)
        splitconteiner_Esq.Panel2.BackColor = Color.FromArgb(255, 240, 201, 135)
        splitconteiner_Esq.Panel1.AutoScroll = True
        splitconteiner_Esq.Panel2.AutoScroll = True

        splitconteiner_Dir.Panel1.BackColor = Color.FromArgb(255, 137, 189, 158)
        splitconteiner_Dir.Panel2.BackColor = Color.FromArgb(255, 240, 201, 135)
        splitconteiner_Dir.Panel1.AutoScroll = True
        splitconteiner_Dir.Panel2.AutoScroll = True

        If usuario.usuario_logado = False Then
            Dim Login = New Login
            Login.ShowDialog()
            'teste.ShowDialog()
        End If

        LateralEsquerda.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4
        LateralDireita.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4
        FormCentral.Height = Me.ClientSize.Height - (MenuStripPrincipal.Height + StatusStrip.Height) - 4

        LateralEsquerda.Width = 300
        LateralDireita.Width = 300
        FormCentral.Width = Me.ClientSize.Width - (LateralDireita.Width + LateralEsquerda.Width) - 4

        LateralEsquerda.Location = New Point(0, 0)
        FormCentral.Location = New Point(LateralEsquerda.Width, 0)
        LateralDireita.Location = New Point(LateralEsquerda.Width + FormCentral.Width, 0)

        FormCentral.BackColor = Color.FromArgb(255, 255, 255, 255)
        LateralDireita.BackColor = Color.FromArgb(255, 255, 133, 82)

        LateralEsquerda.MdiParent = Me
        FormCentral.MdiParent = Me
        LateralDireita.MdiParent = Me
        LateralEsquerda.Show()
        FormCentral.Show()
        LateralDireita.Show()

        lbl_usuarioLogado.Text = "Logado como: " & usuario.usuario_user

        Me.MenuStripPrincipal.Items.Add(mi_afazer)
        Me.MenuStripPrincipal.Items.Add(mi_eventos)
        Me.MenuStripPrincipal.Items.Add(mi_dispositivos)
        Me.MenuStripPrincipal.Items.Add(mi_impressora)
        Me.MenuStripPrincipal.Items.Add(mi_nobreak)
        Me.MenuStripPrincipal.Items.Add(mi_projetor)
        Me.MenuStripPrincipal.Items.Add(mi_camera)
        Me.MenuStripPrincipal.Items.Add(mi_contas)
        Me.MenuStripPrincipal.Items.Add(mi_pessoas)
        Me.MenuStripPrincipal.Items.Add(mi_estoque)
        Me.MenuStripPrincipal.Items.Add(mi_software)
        Me.MenuStripPrincipal.Items.Add(mi_bloquear)
        Me.MenuStripPrincipal.Items.Add(mi_desconectar)

        AddHandler mi_tmEsq.Click, AddressOf separar_Esq
        mi_spliter.Alignment = ToolStripItemAlignment.Right
        AddHandler mi_spliter.Click, AddressOf estenderSP_Esq

        ts_Esq.Dock = DockStyle.Top
        ts_Esq.Items.Add(mi_tmEsq)
        ts_Esq.Items.Add(mi_spliter)

        ts_Dir.Dock = DockStyle.Top
        ts_Dir.Items.Add(mi_tmEsq)
        ts_Dir.Items.Add(mi_spliter)

        'mi_tmEsq.ImageScaling = ToolStripItemImageScaling.SizeToFit


        LateralEsquerda.Controls.Add(splitconteiner_Esq)
        LateralEsquerda.Controls.Add(ts_Esq)
        LateralDireita.Controls.Add(splitconteiner_Dir)
        LateralDireita.Controls.Add(ts_Dir)
        Dim listarAfazer = New AfazerLista()
        Dim listarNotasPessoais = New NotaPessoal()

    End Sub

    Private Sub mi_afazer_Click()

        'Dim verAfazer = New DetalhesAfazer(1011)
        'verAfazer.Show()

        'If (Application.OpenForms.OfType(Of listarAfazer).Any()) Then
        '    Application.OpenForms.OfType(Of listarAfazer).First().BringToFront()
        'Else
        '    'Dim verAfazer = New listarAfazer
        '    listarAfazer.MdiParent = Me
        '    'listarAfazer.Dock = DockStyle.Fill
        '    listarAfazer.ShowIcon = False
        '    'listarAfazer.MaximizeBox = False

        '    listarAfazer.Show()
        '    'listarAfazer.WindowState = FormWindowState.Maximized
        'End If
    End Sub
    Private Sub mi_eventos_Click()
        MsgBox("mi_eventos")
    End Sub
    Private Sub si_computador_Click()
        MsgBox("si_computador")
    End Sub
    Private Sub si_notebook_Click()
        MsgBox("si_notebook")
    End Sub
    Private Sub si_chromebook_Click()
        MsgBox("si_chromebook")
    End Sub
    Private Sub si_tablet_Click()
        MsgBox("si_tablet")
    End Sub
    Private Sub si_celular_Click()
        MsgBox("si_celular")
    End Sub
    Private Sub mi_impressora_Click()
        'If (Application.OpenForms.OfType(Of ListarImpressora).Any()) Then
        '    Application.OpenForms.OfType(Of ListarImpressora).First().BringToFront()
        'Else
        '    'Dim listarImpressora = New ListarImpressora
        '    ListarImpressora.MdiParent = Me
        '    ListarImpressora.Dock = DockStyle.Fill
        '    ListarImpressora.ShowIcon = False
        '    ListarImpressora.MaximizeBox = False
        '    ListarImpressora.Show()
        'End If
    End Sub
    Private Sub mi_nobreak_Click()
        MsgBox("mi_nobreak")
    End Sub
    Private Sub mi_projetor_Click()
        MsgBox("mi_projetor")
    End Sub
    Private Sub mi_camera_Click()
        MsgBox("mi_camera")
    End Sub
    Private Sub si_email_Click()
        MsgBox("mi_email")
    End Sub
    Private Sub si_skype_Click()
        MsgBox("mi_skype")
    End Sub
    Private Sub mi_pessoas_Click()
        MsgBox("mi_pessoas")
    End Sub
    Private Sub mi_estoque_Click()
        MsgBox("mi_estoque")
    End Sub
    Private Sub mi_software_Click()
        MsgBox("mi_software")
    End Sub
    Private Sub mi_bloquear_Click()
        Dim bloqueio = New bloqueio
        bloqueio.ShowDialog()
    End Sub
    Private Sub mi_desconectar_Click()
        usuario.usuario_logado = False
        Application.Restart()
    End Sub
    Private Sub separar_Esq()
        If topmost_esq Then
            LateralEsquerda.TopMost = False
            LateralEsquerda.FormBorderStyle = FormBorderStyle.None
            LateralEsquerda.MdiParent = Me
            LateralEsquerda.Location = New Point(0, 0)
        Else
            LateralEsquerda.MdiParent = Nothing
            LateralEsquerda.FormBorderStyle = FormBorderStyle.FixedSingle
            LateralEsquerda.TopMost = True
        End If
        topmost_esq = Not topmost_esq
    End Sub
    Private Sub estenderSP_Esq()
        spliterModo += 1
        Select Case spliterModo
            Case 1
                splitconteiner_Esq.Panel2Collapsed = True
                mi_spliter.Image = img.spliter2
            Case 2
                splitconteiner_Esq.Panel2Collapsed = False
                mi_spliter.Image = img.spliter1
            Case 3
                splitconteiner_Esq.Panel1Collapsed = True
                mi_spliter.Image = img.spliter2
            Case 4
                splitconteiner_Esq.Panel1Collapsed = False
                mi_spliter.Image = img.spliter3
                spliterModo = 0
        End Select

    End Sub

End Class
