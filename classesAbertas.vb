Public Class classesAbertas
    Public Shared atualdetalhes As AfazerDetalhes
    Public Shared atualnotas As listarNotas
    Public Shared atualntpessoal As NotaPessoal
    Public Shared cadastroOUdetalhes As Integer

    Shared Sub setAtualDetalhes(ByRef _atualdetalhes As AfazerDetalhes, ByVal _cadastroOUdetalhes As Integer)
        atualdetalhes = _atualdetalhes
        cadastroOUdetalhes = _cadastroOUdetalhes
    End Sub
    Shared Sub setAtualNotas(ByRef _atualnotas As listarNotas)
        atualnotas = _atualnotas
    End Sub
    Shared Sub setAtualNtPessoal(ByRef _atualntpessoal As NotaPessoal)
        atualntpessoal = _atualntpessoal
    End Sub
End Class
