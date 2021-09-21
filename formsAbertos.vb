Public Class formsAbertos
    Public Shared atualdetalhes As AfazerDetalhes
    Public Shared atualnotas As listarNotas
    Public Shared cadastroOUdetalhes As Integer

    Shared Sub setAtualDetalhes(ByRef _atualdetalhes As AfazerDetalhes, ByVal _cadastroOUdetalhes As Integer)
        atualdetalhes = _atualdetalhes
        cadastroOUdetalhes = _cadastroOUdetalhes
    End Sub
    Shared Sub setAtualNotas(ByRef _atualnotas As listarNotas)
        atualnotas = _atualnotas
    End Sub
End Class
