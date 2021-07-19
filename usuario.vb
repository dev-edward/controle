Public Class usuario
    Public Shared usuario_id As Integer
    Public Shared usuario_user As String
    Public Shared usuario_nome As String
    Public Shared usuario_logado As Boolean

    Public Sub New()
        usuario_id = 0
        usuario_user = ''
        usuario_nome = ''
        usuario_logado = False
    End Sub
    Public Sub New(ByVal _id As Integer, ByVal _user As String, ByVal _nome As String, ByVal _logado As Boolean)
        usuario_id = _id
        usuario_user = _user
        usuario_nome = _nome
        usuario_logado = _logado
    End Sub
End Class
