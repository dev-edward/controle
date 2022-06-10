Public Class CadastrarEditar
    Dim tabela As String

    Sub New(ByVal _tabela As String, ByVal _cadastro As Boolean, Optional ByVal _pk As Integer = 0)
        tabela = _tabela
        Select Case tabela
            Case "Demandas"
                If _cadastro Then
                    If Application.OpenForms.OfType(Of DemandaDetalhes).Any() Then
                        Application.OpenForms.OfType(Of DemandaDetalhes).First().Close()
                    End If
                    Dim verDetalhes = New DemandaDetalhes()
                    verDetalhes.Show()
                Else
                    If Application.OpenForms.OfType(Of DemandaDetalhes).Any() Then
                        Application.OpenForms.OfType(Of DemandaDetalhes).First().Close()
                    End If
                    Dim verDetalhes = New DemandaDetalhes(_pk)
                    verDetalhes.Show()
                End If

            Case "Eventos"
                If _cadastro Then
                    Dim cadastroEvento As New EventoCadastroAlteracao()
                Else
                    Dim cadastroEvento As New EventoCadastroAlteracao(_pk)
                End If
            Case "Dispositivos", "Computador", "Notebook", "Chromebook", "Tablet", "Celular"
                If _cadastro Then
                    Dim cadastroEvento As New DispositivoCadastroAlteracao(tabela)
                Else
                    Dim cadastroEvento As New DispositivoCadastroAlteracao(_pk)
                End If
            Case "Impressoras"
                If _cadastro Then
                    Dim cadastroImpressora As New ImpressoraCadastroAlteracao()
                Else
                    Dim cadastroImpressora As New ImpressoraCadastroAlteracao(_pk)
                End If
            Case "Nobreaks"

            Case "Projetores"

            Case "Cameras"

            Case "Telefones"
                If _cadastro Then
                    Dim cadastroTelefone As New TelefoneCadastroAlteracao()
                Else
                    Dim detalheTelefone As New TelefoneCadastroAlteracao(_pk)
                End If
            Case "Emails"
                If _cadastro Then
                    Dim cadastroEmail As New EmailCadastroAlteracao()
                Else
                    Dim detalheEmail As New EmailCadastroAlteracao(_pk)
                End If
            Case "Skypes"

            Case "TotvsRM"

            Case "Pessoas"

            Case "Estoque"
                If _cadastro Then
                    Dim cadastroEstoque As New EstoqueCadastroAlteracao()
                Else
                    Dim detalheEstoque As New EstoqueCadastroAlteracao(_pk)
                End If
            Case "Software"

            Case Else
                MessageBox.Show("Tabela: " & tabela & " não encontrada, por favor comunique este erro")
        End Select

        'If Sql <> "" Then
        '    iniciar()
        'End If
    End Sub
End Class
