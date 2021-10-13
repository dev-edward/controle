Imports System.Data.SqlClient
Public Class tabpages
    'Create ADO.NET objects.
    Private conexao As SqlConnection
    Private consulta As SqlCommand
    Private myReader As SqlDataReader
    Dim tabela As String
    Dim sql As String
    Dim label As New Label With {
        .Text = "Nenhum registro foi encontrado ",
        .Location = New Point(0, 60),
        .TextAlign = ContentAlignment.MiddleCenter
    }
    Dim dt As New DataTable
    Dim cs As New System.Windows.Forms.DataGridViewCellStyle With {
        .BackColor = Color.Azure
    }
    Dim WithEvents tabpg As New TabPage With {
        .BorderStyle = BorderStyle.Fixed3D,
        .Margin = New Padding(0, 0, 0, 0)
        }
    Dim dgv_tabpg As New DataGridView With {
        .Dock = DockStyle.Fill,
        .RowHeadersVisible = False,
        .AllowUserToAddRows = False,
        .AllowUserToDeleteRows = False,
        .AllowUserToOrderColumns = True,
        .AllowUserToResizeRows = False,
        .AlternatingRowsDefaultCellStyle = cs
    }
    Dim ts_tab As New ToolStrip With {
        .Dock = DockStyle.Top,
        .GripStyle = ToolStripGripStyle.Hidden
    }
    Dim mi_botao As New ToolStripButton("", img.xis)
    'dgv_tabpg.EditMode = DataGridViewEditMode.EditProgrammatically
    'dgv_tabpg.Columns(0).ReadOnly = False
    'dgv_tabpg.Columns(1).ReadOnly = True
    Dim valores As Dictionary(Of Integer, String)

    Sub New(ByVal _tabela As String, Optional ByVal _opcao As Integer = 0)
        tabela = _tabela
        tabpg.Name = tabela

        Select Case tabela
            Case "Demandas"
                sql = "select 
                    demanda_id as 'ID',
                    Convert(varchar(16),demanda_dtcadastro, 120) as 'Cadastro',
                    u1.usuario_user as 'Cadastrado por',
                    Convert(varchar(16),demanda_dtalteracao, 120) as 'Alteração',
                    u2.usuario_user as 'Alterado por',
                    demanda_titulo as 'Título',
                    demanda_detalhes as 'Detalhes',
                    case when demanda_temprevisao > 0 then Convert(varchar(16),
                    demanda_previsao, 120) else 'Sem Previsão' END as 'Previsão',
                    case 
	                    when demanda_status = 1 then 'Aguardando' 
	                    when demanda_status = 2 then 'Em andamento' 
	                    when demanda_status = 3 then 'Feito' 
	                    when demanda_status = 4 then 'Descartado' 
	                    end as 'Status',
                    u3.usuario_user as 'Encarregado',
                    demanda_prioridade as 'Prioridade'
                    from tb_demanda 
                    left join tb_usuario u1 on demanda_usercadastro = u1.usuario_id
                    left join tb_usuario u2 on demanda_useralteracao = u2.usuario_id
                    left join tb_usuario u3 on demanda_encarregado = u3.usuario_id"

            Case "Eventos"

            Case "Dispositivos", "Computador", "Notebook", "Chromebook", "Tablet", "Celular"
                sql = "select 
                        dispositivo_id as 'ID',
                        Convert(varchar(16),dispositivo_dtcadastro, 120) as 'Cadastro',
                        ucadastro.usuario_user as 'Cadastrado por',
                        Convert(varchar(16),dispositivo_dtalteracao, 120) as 'Alteração',
                        ualteracao.usuario_user as 'Alterado por',
                        case 
	                        when dispositivo_tipo = 1 then 'Computador' 
	                        when dispositivo_tipo = 2 then 'Notebook' 
	                        when dispositivo_tipo = 3 then 'Chromebook' 
	                        when dispositivo_tipo = 4 then 'Tablet' 
	                        when dispositivo_tipo = 5 then 'Celular' 
                        end as 'Tipo',
                        case 
	                        when dispositivo_posto = 0 then 'Não' 
	                        else 'Sim' 
                        end as 'É posto informático',
                        dispositivo_marcamodelo as 'Marca e Modelo',
                        dispositivo_nome as 'Nome/hostname',
                        dispositivo_ip as 'IP',
                        dispositivo_macadress as 'Endereço MAC',
                        dispositivo_os as 'Sistema Operacional',
                        dispositivo_qtdmemoriaram as 'Memória RAM',
                        dispositivo_processador as 'Processador',
                        dispositivo_armazenamento as  'Armazenamento',
                        dispositivo_bateria as 'Bateria'
                        from tb_dispositivo
                        left join tb_usuario ucadastro on dispositivo_usercadastro = ucadastro.usuario_id
                        left join tb_usuario ualteracao on dispositivo_usercadastro = ualteracao.usuario_id
                        left join tb_usuario u1 on dispositivo_usercadastro = u1.usuario_id"

                If _opcao > 0 Then
                    sql += " where dispositivo_tipo = " & _opcao
                End If

            Case "Impressoras"
                sql = "select 
                    impressora_id as 'ID',
                    Convert(varchar(16),impressora_dtcadastro, 120) as 'Cadastro',
                    ucadastro.usuario_user as 'Cadastrado por',
                    Convert(varchar(16),impressora_dtalteracao, 120) as 'Alteração',
                    ualteracao.usuario_user as 'Alterado por',
                    impressora_marcamodelo as 'Marca & Modelo',
                    impressora_nserie as 'Nº Serie',
                    impressora_nnota as 'Nº Nota',
                    impressora_nproduto as 'Nº Produto',
                    suprimento.estoque_nome as 'Suprimento',
                    case 
	                    when impressora_corimpressão = 0 or impressora_corimpressão is null then 'Preto & Branco' 
	                    else 'Colorido' 
                    end as 'P/B ou Colorido',
                    impressora_local as 'Local da impressora',
                    case 
	                    when impressora_estado = 1 then 'Ativo' 
	                    when impressora_estado = 2 then 'Inativo' 
	                    when impressora_estado = 3 then 'Devolvido' 
                    end as 'Status',
                    impressora_ip as 'IP da impressora',
                    Convert(varchar(16),impressora_dtentrada, 103) as 'Data de entrada',
                    Convert(varchar(16),impressora_dtsaida, 103) as 'Data de saida'
                    from tb_impressora
                    left join tb_usuario ucadastro on impressora_usercadastro = ucadastro.usuario_id
                    left join tb_usuario ualteracao on impressora_usercadastro = ualteracao.usuario_id
                    left join tb_estoque suprimento on impressora_suprimento = suprimento.estoque_id"

            Case "Nobreaks"

            Case "Projetores"

            Case "Cameras"

            Case "Telefones"
                sql = "select
                    telefone_id as 'ID',
                    telefone_numero as 'Número',
                    telefone_pessoa as 'Pessoa',
                    telefone_local as 'Local'
                    from tb_telefone"
            Case "Emails"
                sql = "select
                    email_id as 'ID',
                    email_nome as 'Nome',
                    email_setor as 'Setor',
                    email_email as 'E-mail',
                    case when email_senha is not null then
                    '********' end as 'Senha',
                    email_dominio as 'Domínio',
                    case 
	                    when email_estado = 0 or email_estado is null then 'Inativo' 
	                    else 'Ativo' 
                    end as 'Estado',
                    meta_valor.valor_valor as 'Grupo',
                    email_outlook_nome as 'Nome no Outlook',
                    email_outlook_ass_nome as 'Nome na Assinatura Outlook',
                    email_outlook_ass_servico as 'Serviço na Assinatura Outlook'
                    from tb_email
                    inner join meta_valor on valor_tabela = 'tb_email' and valor_coluna = 'email_grupo' and email_grupo = meta_valor.valor_numero "

            Case "Skypes"
                sql = "select
                    skype_id as 'ID',
                    skype_nome as 'Nome no Skype',
                    skype_unidade as 'Unidade',
                    skype_departamento as 'Departamento',
                    skype_skype as 'Skype ID',
                    skype_email as 'Email',
                    case when skype_senha is not null then
                    '********' end as 'Senha'
                    from tb_skype"

            Case "TotvsRM"

            Case "Pessoas"

            Case "Estoque"

            Case "Software"

            Case Else
                MessageBox.Show("Tabela: " & tabela & " não encontrada")
        End Select


        iniciar()
    End Sub
    Private Sub iniciar()
        Try
            conexao = New SqlConnection(globalConexao.initial & globalConexao.data)

            consulta = conexao.CreateCommand
            consulta.CommandText = sql

            conexao.Open()

            myReader = consulta.ExecuteReader()

            If myReader.HasRows Then
                dt.Load(myReader)

                tabpg.Controls.Add(dgv_tabpg)

                dgv_tabpg.AutoGenerateColumns = True
                dgv_tabpg.DataSource = dt
                dgv_tabpg.Refresh()
                dgv_tabpg.ReadOnly = True

                'For Each dc As DataGridViewColumn In dgv_tabpg.Columns
                '    If dc.Index > 0 Then
                '        dc.ReadOnly = True
                '    End If
                'Next
            Else
                tabpg.Controls.Add(label)
            End If
            myReader.Close()
            tabpg.Text = tabela
            ts_tab.Items.Add(mi_botao)
            tabpg.Controls.Add(ts_tab)
            Principal.tabCentro.TabPages.Add(tabpg)
            AddHandler mi_botao.Click, AddressOf fechar
        Catch ex As Exception
            MessageBox.Show("Error while connecting to SQL Server." & ex.Message)
        Finally
            conexao.Close()
        End Try
    End Sub
    Private Sub tabpg_alteralargura(sender As Object, e As EventArgs) Handles tabpg.SizeChanged
        label.Width = tabpg.Width
    End Sub
    Private Sub tabpg_keydown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles tabpg.KeyDown
        'Dim KeyCode As Short = eventArgs.KeyCode
        'If KeyCode = System.Windows.Forms.Keys.Escape Then
        '    Principal.tabCentro.TabPages.Remove(tabpg)
        'End If
    End Sub
    Private Sub fechar()
        Principal.tabCentro.TabPages.Remove(tabpg)
        'tabpg.Dispose()
        'dgv_tabpg.Dispose()
        'dt.Dispose()
    End Sub
End Class
