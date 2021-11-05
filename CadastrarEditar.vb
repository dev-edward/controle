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

            Case "Dispositivos", "Computador", "Notebook", "Chromebook", "Tablet", "Celular"

                'If _opcao > 0 Then

                'End If

            Case "Impressoras"

            Case "Nobreaks"

            Case "Projetores"

            Case "Cameras"

            Case "Telefones"

            Case "Emails"

            Case "Skypes"

            Case "TotvsRM"

            Case "Pessoas"

            Case "Estoque"

            Case "Software"

            Case Else
                MessageBox.Show("Tabela: " & tabela & " não encontrada, por favor comunique este erro")
        End Select

        'If Sql <> "" Then
        '    iniciar()
        'End If
    End Sub
End Class
