Public Class classesAbertas
    Public Shared atualListaDemandas As DemandaLista
    Public Shared atualdetalhes As DemandaDetalhes
    Public Shared atualnotas As listarNotas
    Public Shared atualntpessoal As NotaPessoal
    Public Shared atualEventos As EventoLista
    Public Shared atualCadAltEventos As Form
    Public Shared atualCadAltDispositivos As Form
    Public Shared atualCadAltImpressoras As Form
    Public Shared atualCadAltTelefones As Form


    Shared Sub setAtualListaDemandas(ByRef _atualListaDemandas As DemandaLista)
        atualListaDemandas = _atualListaDemandas
    End Sub
    Shared Sub setAtualDetalhes(ByRef _atualdetalhes As DemandaDetalhes)
        atualdetalhes = _atualdetalhes
    End Sub
    Shared Sub setAtualNotas(ByRef _atualnotas As listarNotas)
        atualnotas = _atualnotas
    End Sub
    Shared Sub setAtualNtPessoal(ByRef _atualntpessoal As NotaPessoal)
        atualntpessoal = _atualntpessoal
    End Sub
    Shared Sub setAtualNtEventos(ByRef _atualeventos As EventoLista)
        atualEventos = _atualeventos
    End Sub
    Shared Sub setAtualCadAltEventos(ByRef _atualCadAltEventos As Form)
        If atualCadAltEventos IsNot Nothing Then
            atualCadAltEventos.Close()
        End If
        atualCadAltEventos = _atualCadAltEventos
    End Sub
    Shared Sub setAtualCadAltDispositivos(ByRef _atualCadAltDispositivos As Form)
        If atualCadAltDispositivos IsNot Nothing Then
            atualCadAltDispositivos.Close()
        End If
        atualCadAltDispositivos = _atualCadAltDispositivos
    End Sub
    Shared Sub setAtualCadAltImpressoras(ByRef _atualCadAltImpressoras As Form)
        If atualCadAltImpressoras IsNot Nothing Then
            atualCadAltImpressoras.Close()
        End If
        atualCadAltImpressoras = _atualCadAltImpressoras
    End Sub
    Shared Sub setAtualCadAltTelefones(ByRef _atualCadAltTelefones As Form)
        If atualCadAltTelefones IsNot Nothing Then
            atualCadAltTelefones.Close()
        End If
        atualCadAltTelefones = _atualCadAltTelefones
    End Sub

End Class
