Public Class CadastrarEditar
    Dim tabela As String

    Sub New(ByVal _tabela As String)
        tabela = _tabela
        Select Case tabela
            Case "Demandas"
                Dim cadastrarDemanda = New DemandaDetalhes()

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
