--> informa��es de tabelas <--
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'tb_evento'
--> informa��es de tabelas <--

--> alter table <--
alter table tb_evento add evento_ultimocheck DATETIME
alter table tb_evento drop column evento_dtinicio 
alter table tb_evento add evento_ativo TINYINT 
alter table tb_evento alter column evento_data tinyint
--> alter table <--

--> lista de demandas <--
SELECT demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status,
sum(case when nota_pkitem = demanda_id and nota_tabela = 'demanda' and nota_excluido is null then 1 else 0 end) as 'qtd_notas' 
FROM tb_demanda LEFT JOIN tb_anotacao ON  demanda_id = nota_pkitem and  nota_tabela = 'demanda'
where demanda_status in(0,1) -- and demanda_usercadastro = 1 and demanda_encarregado = 1
group by demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status
--> lista de demandas <--

--> lista de eventos <--
select
evento_id,
evento_descricao,
evento_datahora,
evento_frequencia,
evento_allday,
case when evento_ultimocheck > evento_datahora then 1 else 0 end as 'checado'
from tb_evento
where evento_ativo = 1 and evento_datahora > DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) and evento_datahora < DATEADD(dd, 1, DATEDIFF(dd, 0, GETDATE()))
order by 'checado'

select * from tb_evento
select dateadd(month,2,'31/10/2021 00:00')
update tb_evento set evento_ultimocheck = DATEADD(hh, 22, DATEDIFF(dd, 0, GETDATE())) where evento_id = 4

update tb_evento set evento_datahora = '18/10/2021 09:00', evento_ultimocheck = '18/10/2021 22:00' where evento_id = 1
update tb_evento set evento_datahora = '20/10/2021 14:15', evento_ultimocheck = '19/10/2021 22:00' where evento_id = 2
update tb_evento set evento_datahora = '20/10/2021 17:00', evento_ultimocheck = '19/10/2021 22:00' where evento_id = 3
update tb_evento set evento_datahora = '21/10/2021 09:00', evento_ultimocheck = null where evento_id = 4
update tb_evento set evento_datahora = '22/10/2021 15:00', evento_ultimocheck = null where evento_id = 5


insert into tb_evento(evento_datahora,evento_ultimocheck,evento_descricao,evento_frequencia,evento_allday,evento_ativo) values('25/04/2021 12:00','24/04/2021 12:00','Teste de Evento',1,0,1)
insert into tb_evento(evento_datahora,evento_ultimocheck,evento_descricao,evento_frequencia,evento_allday,evento_ativo) values('25/04/2021 12:00','25/04/2021 13:00','Teste de Evento',1,0,1)

--> lista de eventos <--

--> Demandas <--
select 
demanda_id as 'ID',
demanda_titulo as 'T�tulo',
demanda_detalhes as 'Detalhes',
case when demanda_temprevisao > 0 then Convert(varchar(16),
demanda_previsao, 120) else 'Sem Previs�o' END as 'Previs�o',
case 
	when demanda_status = 1 then 'Aguardando' 
	when demanda_status = 2 then 'Em andamento' 
	when demanda_status = 3 then 'Feito' 
	when demanda_status = 4 then 'Descartado' 
	end as 'Status',
u3.usuario_user as 'Encarregado',
prioridade.valor_valor as 'Prioridade',
Convert(varchar(16),demanda_dtcadastro, 120) as 'Cadastro',
u1.usuario_user as 'Cadastrado por',
Convert(varchar(16),demanda_dtalteracao, 120) as 'Altera��o',
u2.usuario_user as 'Alterado por'
from tb_demanda 
left join tb_usuario u1 on demanda_usercadastro = u1.usuario_id
left join tb_usuario u2 on demanda_useralteracao = u2.usuario_id
left join tb_usuario u3 on demanda_encarregado = u3.usuario_id
left join meta_valor prioridade on valor_tabela = 'tb_demanda' and valor_coluna = 'demanda_prioridade' and demanda_prioridade = prioridade.valor_numero
--> Demandas <--

--> Evento <--
select
evento_id as 'ID',
evento_descricao as 'Descri��o',
evento_datahora as 'Data do evento',
evento_ultimocheck as '�ltimo Checado',
evento_frequencia as 'Frequ�ncia',
evento_allday as 'O dia inteiro',
evento_ativo as 'Ativo'
from tb_evento
--> Evento <--

--> Dispositivos <--
select 
dispositivo_id as 'ID',
case 
	when dispositivo_tipo = 1 then 'Computador' 
	when dispositivo_tipo = 2 then 'Notebook' 
	when dispositivo_tipo = 3 then 'Chromebook' 
	when dispositivo_tipo = 4 then 'Tablet' 
	when dispositivo_tipo = 5 then 'Celular' 
end as 'Tipo',
case 
	when dispositivo_posto = 0 or dispositivo_posto is null then 'N�o' 
	else 'Sim' 
end as '� posto inform�tico',
dispositivo_marcamodelo as 'Marca e Modelo',
dispositivo_nome as 'Nome/hostname',
dispositivo_ip as 'IP',
dispositivo_macadress as 'Endere�o MAC',
dispositivo_os as 'Sistema Operacional',
dispositivo_qtdmemoriaram as 'Mem�ria RAM',
dispositivo_processador as 'Processador',
dispositivo_armazenamento as  'Armazenamento',
dispositivo_bateria as 'Bateria',
Convert(varchar(16),dispositivo_dtcadastro, 120) as 'Cadastro',
ucadastro.usuario_user as 'Cadastrado por',
Convert(varchar(16),dispositivo_dtalteracao, 120) as 'Altera��o',
ualteracao.usuario_user as 'Alterado por'
from tb_dispositivo
left join tb_usuario ucadastro on dispositivo_usercadastro = ucadastro.usuario_id
left join tb_usuario ualteracao on dispositivo_usercadastro = ualteracao.usuario_id

where dispositivo_tipo = 1
--> Dispositivos <--

--> Impressoras <--
select 
impressora_id as 'ID',
impressora_marcamodelo as 'Marca & Modelo',
impressora_nserie as 'N� Serie',
impressora_nnota as 'N� Nota',
impressora_nproduto as 'N� Produto',
suprimento.estoque_nome as 'Suprimento',
case 
	when impressora_corimpressao = 0 or impressora_corimpressao is null then 'Preto & Branco' 
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
Convert(varchar(16),impressora_dtsaida, 103) as 'Data de saida',
Convert(varchar(16),impressora_dtcadastro, 120) as 'Cadastro',
ucadastro.usuario_user as 'Cadastrado por',
Convert(varchar(16),impressora_dtalteracao, 120) as 'Altera��o',
ualteracao.usuario_user as 'Alterado por'
from tb_impressora
left join tb_usuario ucadastro on impressora_usercadastro = ucadastro.usuario_id
left join tb_usuario ualteracao on impressora_usercadastro = ualteracao.usuario_id
left join tb_estoque suprimento on impressora_suprimento = suprimento.estoque_id
--> Impressoras <--

--> Telefone <--
select
telefone_id as 'ID',
telefone_numero as 'N�mero',
telefone_pessoa as 'Pessoa',
telefone_local as 'Local',
tipo.valor_valor as 'Tipo'
from tb_telefone
left join meta_valor tipo on valor_tabela = 'tb_telefone' and valor_coluna = 'telefone_tipo' and telefone_tipo = tipo.valor_numero
--> Telefone <--

--> E-mails <--
select
email_id as 'ID',
email_nome as 'Nome',
email_setor as 'Setor',
email_email as 'E-mail',
case when email_senha is not null then
'********' end as 'Senha',
email_dominio as 'Dom�nio',
case 
	when email_estado = 0 or email_estado is null then 'Inativo' 
	else 'Ativo' 
end as 'Estado',
meta_valor.valor_valor as 'Grupo',
email_outlook_nome as 'Nome no Outlook',
email_outlook_ass_nome as 'Nome na Assinatura Outlook',
email_outlook_ass_servico as 'Servi�o na Assinatura Outlook'
from tb_email
left join meta_valor on valor_tabela = 'tb_email' and valor_coluna = 'email_grupo' and email_grupo = meta_valor.valor_numero  
--> E-mails <--

--> Skype <--
select
skype_id as 'ID',
skype_nome as 'Nome no Skype',
skype_unidade as 'Unidade',
skype_departamento as 'Departamento',
skype_skype as 'Skype ID',
skype_email as 'Email',
case when skype_senha is not null then
'********' end as 'Senha'
from tb_skype
--> Skype <--

--> Estoque <--
Select 
estoque_id as 'ID',
estoque_nome as 'Nome',
estoque_descricao as 'Descri��o',
estoque_tag as 'Tag',
estoque_quantidade as 'Quantidade',
estoque_localizacao as 'Local armazenado'
from tb_estoque
--> Estoque <--

--> Software <--
--> Software <--

insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('paulo','senha','Paulo Henrique dos Santos')
insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('andre','senha','Andr� luis Ruffo Veroneze')
