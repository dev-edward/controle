--> Fazer depois
-- formatar todas as datas no seguinte formato:
-- format(evento_datahora,'dd/MM/yyyy HH:mm','pt-br')
-- e atualizar instruções no Visual Studio

--> informações de tabelas <--
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'tb_evento'
--> informações de tabelas <--

--> alter table <--
alter table tb_evento add evento_ultimocheck DATETIME
alter table tb_evento drop column evento_dtinicio 
alter table tb_evento add evento_ativo TINYINT 
alter table tb_evento alter column evento_data tinyint
alter table tb_usuario alter column usuario_nome NVARCHAR(35)
--> alter table <--

--> lista de demandas <--
SELECT demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status,
sum(case when nota_pkitem = demanda_id and nota_tabela = 'demanda' and nota_excluido is null then 1 else 0 end) as 'qtd_notas' 
FROM tb_demanda LEFT JOIN tb_anotacao ON  demanda_id = nota_pkitem and  nota_tabela = 'demanda'
where demanda_status in(0,1) -- and demanda_usercadastro = 1 and demanda_encarregado = 1
group by demanda_id, demanda_titulo, demanda_temprevisao, demanda_previsao, demanda_status
--> lista de demandas <--

--> update evento <--
UPDATE tb_evento
SET
evento_ultimocheck = CASE
   WHEN DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
   THEN evento_datahora
   ELSE evento_ultimocheck
END
,evento_datahora = case 
	when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) <> DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) or evento_ultimocheck is null
	then DATEADD(d,1,evento_datahora)
	else evento_datahora
end
where evento_id = 1
--> update evento <--

--> lista de eventos <--
select
evento_id
,evento_descricao
,SUBSTRING(DATENAME(dw, evento_datahora), 0,4) + ', ' + format(evento_datahora,'dd/MM/yyyy HH:mm','pt-br') as 'evento_datahora'
,evento_ultimocheck
,evento_frequencia
,evento_allday
,case when evento_datahora >= getdate() then 1 else 0 end as 'proximo'
,case when DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) = DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE())) then 1 else 0 end as 'checado'
from tb_evento
where
evento_ativo = 1
and 
(
DATEADD(dd, 0, DATEDIFF(dd,0,evento_datahora)) <= DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE()))
or
DATEADD(dd, 0, DATEDIFF(dd,0,evento_ultimocheck)) = DATEADD(dd, 0, DATEDIFF(dd,0,GETDATE()))
)
order by 'checado'
--> lista de eventos <--

--> Demandas <--
select 
demanda_id as 'ID',
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
prioridade.valor_valor as 'Prioridade',
Convert(varchar(16),demanda_dtcadastro, 120) as 'Cadastro',
u1.usuario_user as 'Cadastrado por',
Convert(varchar(16),demanda_dtalteracao, 120) as 'Alteração',
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
evento_descricao as 'Descrição',
evento_datahora as 'Data do evento',
evento_ultimocheck as 'Última data Checado',
case
	when evento_frequencia = 0 then 'Apenas uma vez'
	when evento_frequencia = 0 then 'Diário'
	when evento_frequencia = 0 then 'Semanal'
	when evento_frequencia = 0 then 'Mensal'
	when evento_frequencia = 0 then 'Anual'
end as 'Frequência',
case 
	when evento_allday = 0 or evento_allday is null then 'Não' 
	else 'Sim' 
end as 'O dia inteiro',
case 
	when evento_ativo = 0 or evento_ativo is null then 'Não' 
	else 'Sim' 
end as 'Ativo'
from tb_evento
--> Evento <--

--> Form Evento <--
select 
        evento_id,
        evento_descricao, 
        evento_datahora, 
        evento_frequencia, 
        evento_allday, 
        evento_ativo,
		(select sum(case when nota_pkitem = @id and nota_tabela = 'evento' and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_evento 
where evento_id = @id
--> Form Evento <--

--> Salvar evento <--
insert into tb_evento(evento_usercadastro,evento_descricao,evento_datahora,evento_frequencia,evento_allday,evento_ativo)
values(
@usercadastro,
@descricao,
@datahora,
@frequencia,
@allday,
@ativo
)
--> Salvar evento <--

--> Alterar evento <--
update tb_evento set 
evento_dtalteracao = GETDATE(),
evento_useralteracao = @useralteracao,
evento_descricao = @descricao,
evento_datahora = @datahora,
evento_frequencia = @frequencia,
evento_allday = @allday,
evento_ativo = @ativo
where evento_id = @id
--> Alterar evento <--
select * from tb_evento

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
dispositivo_bateria as 'Bateria',
Convert(varchar(16),dispositivo_dtcadastro, 120) as 'Cadastro',
ucadastro.usuario_user as 'Cadastrado por',
Convert(varchar(16),dispositivo_dtalteracao, 120) as 'Alteração',
ualteracao.usuario_user as 'Alterado por'
from tb_dispositivo
left join tb_usuario ucadastro on dispositivo_usercadastro = ucadastro.usuario_id
left join tb_usuario ualteracao on dispositivo_usercadastro = ualteracao.usuario_id

where dispositivo_tipo = 1
--> Dispositivos <--

--> Form dispositivo <--
select 
    dispositivo_tipo,
    dispositivo_posto, 
    dispositivo_marcamodelo, 
    dispositivo_hostname, 
    dispositivo_ip, 
    dispositivo_macadress,
    dispositivo_os,
    dispositivo_qtdmemoriaram,
    dispositivo_processador,
    dispositivo_armazenamento,
    dispositivo_bateria,
	(select sum(case when nota_pkitem = @id and nota_tabela = 'dispositivo' and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_dispositivo 
where dispositivo_id = @id
--> Form dispositivo <--

--> Salvar dispositivo <--
INSERT INTO tb_dispositivo(
dispositivo_usercadastro,dispositivo_tipo,dispositivo_posto,dispositivo_marcamodelo,dispositivo_hostname,dispositivo_ip,dispositivo_macadress,dispositivo_os,dispositivo_qtdmemoriaram,dispositivo_processador,dispositivo_armazenamento,dispositivo_bateria)
VALUES(
@usercadastro,
@tipo,
@posto,
@marcamodelo,
@hostname,
@ip,
@macadress,
@os,
@qtdmemoriaram,
@processador,
@armazenamento,
@bateria
)
--> Salvar dispositivo <--

--> Alterar dispositivo <--
UPDATE tb_dispositivo SET
dispositivo_dtalteracao = GETDATE(),
dispositivo_useralteracao = @useralteracao,
dispositivo_tipo = @tipo,
dispositivo_posto = @posto,
dispositivo_marcamodelo = @marcamodelo,
dispositivo_hostname = @hostname,
dispositivo_ip = @ip
dispositivo_macadress = @macadress,
dispositivo_os = @os,
dispositivo_qtdmemoriaram = @qtdmemoriaram,
dispositivo_processador = @processador,
dispositivo_armazenamento = @armazenamento,
dispositivo_bateria = @bateria
where dispositivo_id = @id


update tb_dispositivo set dispositivo_posto=1 where dispositivo_id = 1
select * from tb_dispositivo

--> Alterar dispositivo <--

--> Impressoras <--
select 
impressora_id as 'ID',
impressora_marcamodelo as 'Marca & Modelo',
impressora_nserie as 'Nº Serie',
impressora_nnota as 'Nº Nota',
impressora_nproduto as 'Nº Produto',
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
Convert(varchar(16),impressora_dtalteracao, 120) as 'Alteração',
ualteracao.usuario_user as 'Alterado por'
from tb_impressora
left join tb_usuario ucadastro on impressora_usercadastro = ucadastro.usuario_id
left join tb_usuario ualteracao on impressora_usercadastro = ualteracao.usuario_id
left join tb_estoque suprimento on impressora_suprimento = suprimento.estoque_id
--> Impressoras <--

--> Telefone <--
select
telefone_id as 'ID',
telefone_numero as 'Número',
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
estoque_descricao as 'Descrição',
estoque_tag as 'Tag',
estoque_quantidade as 'Quantidade',
estoque_localizacao as 'Local armazenado'
from tb_estoque
--> Estoque <--

--> Software <--
--> Software <--

insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('paulo','senha','Paulo Henrique dos Santos')
insert into tb_usuario(usuario_user,usuario_senha,usuario_nome) values('andre','senha','André luis Ruffo Veroneze')
