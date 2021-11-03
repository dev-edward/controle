Public Class classesAbertas
    Public Shared atualListaDemandas As DemandaLista
    Public Shared atualdetalhes As DemandaDetalhes
    Public Shared cadastrodemanda As Boolean
    Public Shared atualnotas As listarNotas
    Public Shared atualntpessoal As NotaPessoal
    Public Shared atualEventos As EventoLista

    Shared Sub setAtualListaDemandas(ByRef _atualListaDemandas As DemandaLista)
        atualListaDemandas = _atualListaDemandas
    End Sub
    Shared Sub setAtualDetalhes(ByRef _atualdetalhes As DemandaDetalhes, ByVal _cadastrodemanda As Boolean)
        atualdetalhes = _atualdetalhes
        cadastrodemanda = _cadastrodemanda
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
End Class
