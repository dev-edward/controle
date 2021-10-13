select * from tb_anotacao
insert into tb_anotacao(nota_pkitem,nota_tabela,nota_nota) values(7,'afazer','Anotação 5 | afazer 7')
select * from tb_anotacao

update tb_anotacao set nota_excluido = null where nota_id = 6
select * from tb_anotacao

SELECT demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status,
sum(case when nota_pkitem = demanda_id and nota_tabela = 'demanda' and nota_excluido is null then 1 else 0 end) as 'qtd_notas' 
FROM tb_demanda LEFT JOIN tb_anotacao ON  demanda_id = nota_pkitem and  nota_tabela = 'demanda'
where demanda_status in(0,1) -- and demanda_usercadastro = 1 and demanda_encarregado = 1
group by demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status

select * from tb_impressora

insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('(11)937520377','Teste Edward','Celular e Whatsapp')


select * from tb_demanda

SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'tb_telefone'

-- Demandas --
select 
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
left join tb_usuario u3 on demanda_encarregado = u3.usuario_id
-- Demandas--

-- Dispositivos --
select 
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
	when dispositivo_posto = 0 or dispositivo_posto is null then 'Não' 
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

where dispositivo_tipo = 1
-- Dispositivos --

-- Impressoras --
select 
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
left join tb_estoque suprimento on impressora_suprimento = suprimento.estoque_id
-- Impressoras --

-- Telefone --
select
telefone_id as 'ID',
telefone_numero as 'Número',
telefone_pessoa as 'Pessoa',
telefone_local as 'Local'
from tb_telefone
-- Telefone --

-- E-mails --
select
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
inner join meta_valor on valor_tabela = 'tb_email' and valor_coluna = 'email_grupo' and email_grupo = meta_valor.valor_numero  
-- E-mails --

-- Skype --
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
-- Skype --




select * from tb_impressora
update tb_impressora set impressora_corimpressão = null

update tb_demanda set demanda_temprevisao = 0 where demanda_id = 2
insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('Paulo','senha','Paulo Henrique dos Santos')
insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('Andre','senha','André luis Ruffo Veroneze')
