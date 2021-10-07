Public Class classesAbertas
    Public Shared atualdetalhes As DemandaDetalhes
    Public Shared atualnotas As listarNotas
    Public Shared atualntpessoal As NotaPessoal
    Public Shared cadastrodemanda As Boolean

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
End Class
