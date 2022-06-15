--> Fazer depois
-- formatar todas as datas no seguinte formato:
-- format(evento_datahora,'dd/MM/yyyy HH:mm','pt-br')
-- e atualizar instruções no Visual Studio

--> informações de tabelas <--
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = N'tb_estoque'
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
		(select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
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
tb_local.local_nome as 'Local da impressora',
suprimento.valor_valor as 'Suprimento',
cor.valor_valor as 'P/B ou Colorido',
estado.valor_valor as 'Status',
impressora_ip as 'IP da impressora',
Convert(varchar(16),impressora_dtentrada, 103) as 'Data de entrada',
Convert(varchar(16),impressora_dtsaida, 103) as 'Data de saida',
Convert(varchar(16),impressora_dtcadastro, 120) as 'Cadastro',
ucadastro.usuario_user as 'Cadastrado por',
Convert(varchar(16),impressora_dtalteracao, 120) as 'Alteração',
ualteracao.usuario_user as 'Alterado por'
from tb_impressora
left join meta_valor cor 
	on cor.valor_tabela = 'tb_impressora'
	and cor.valor_coluna = 'impressora_corimpressao'
	and tb_impressora.impressora_corimpressao = cor.valor_numero
left join meta_valor estado 
	on estado.valor_tabela = 'tb_impressora'
	and estado.valor_coluna = 'impressora_estado'
	and tb_impressora.impressora_estado = estado.valor_numero
left join meta_valor suprimento
    on suprimento.valor_tabela = 'tb_impressora'
    and suprimento.valor_coluna = 'impressora_suprimento'
    and tb_impressora.impressora_suprimento = suprimento.valor_numero
left join tb_usuario ucadastro on impressora_usercadastro = ucadastro.usuario_id
left join tb_usuario ualteracao on impressora_usercadastro = ualteracao.usuario_id
left join tb_local on tb_impressora.impressora_local = tb_local.local_id

--> Impressoras <--

--> Form Impressoras <--
declare @id as int=1
declare @tabela as nvarchar = 'impressora'
select 
impressora_id,
impressora_nserie,
impressora_nnota,
impressora_nproduto,
impressora_marcamodelo,
tb_estoque.estoque_nome,
impressora_ip,
impressora_corimpressao,
tb_local.local_nome,
impressora_estado,
impressora_dtentrada,
impressora_dtsaida,
(select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_impressora
left join tb_estoque on tb_impressora.impressora_suprimento = tb_estoque.estoque_id
left join tb_local on tb_impressora.impressora_local = tb_local.local_id
where impressora_id = @id
--> Form Impressora <--

--> Salvar Impressora <--
INSERT INTO tb_impressora(
impressora_usercadastro,impressora_nserie,impressora_nnota,impressora_nproduto,impressora_marcamodelo,impressora_suprimento,impressora_ip,impressora_corimpressao,impressora_local,impressora_estado,impressora_dtentrada,impressora_dtsaida
)
VALUES(
@usercadastro,
@nserie,
@nnota,
@nproduto,
@marcamodelo,
(select estoque_id from tb_estoque where estoque_nome = @suprimento),
@ip,
@corimpressao,
(select local_id from tb_local where local_nome = @local),
@estado,
@dtentrada,
@dtsaida
)
--> Salvar Impressora <--

--> Alterar Impressora <--
UPDATE tb_impressora SET
impressora_dtalteracao = GETDATE(),
impressora_useralteracao = @useralteracao,
impressora_nserie = @nserie,
impressora_nnota = @nnota,
impressora_nproduto = @nproduto,
impressora_marcamodelo = @marcamodelo,
impressora_suprimento = @suprimento,
impressora_ip = @ip,
impressora_corimpressao = @corimpresao,
impressora_local = @local,
impressora_estado = @estado,
impressora_dtentrada = @entrada,
impressora_dtsaida = @saida
where impressora_id = @id
--> Alterar Impressora <--

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

--> Form Telefone <--
select
telefone_numero,
telefone_pessoa,
telefone_local,
meta_valor.valor_valor as 'tipo',
(select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_telefone
left join meta_valor on tb_telefone.telefone_tipo = meta_valor.valor_numero
and meta_valor.valor_tabela = 'tb_telefone' 
and meta_valor.valor_coluna = 'telefone_tipo'
where telefone_id = @id
--> Form Telefone <--

--> Salvar Telefone <--
insert into tb_telefone(telefone_id, telefone_numero, telefone_pessoa, telefone_local, telefone_tipo)
values(
@numero,
@pessoa,
@local,
@tipo
)
--> Salvar Telefone <--
--> Alterar Telefone <--
UPDATE tb_telefone SET
telefone_numero = @numero,
telefone_pessoa = @pessoa,
telefone_local = @local,
telefone_tipo = @tipo
where telefone_id = @id
--> Alterar Telefone <--
--> E-mails <--
select
email_id as 'ID',
email_nome as 'Nome',
email_setor as 'Setor',
email_email as 'E-mail',
case when email_senha is not null then
'********' end as 'Senha',
right (email_email,len(email_email)-charIndex('@',email_email)) as 'Domínio',
case 
	when email_estado = 0 or email_estado is null then 'Inativo' 
	else 'Ativo' 
end as 'Estado',
grupo.valor_valor as 'Grupo'
from tb_email
left join meta_valor grupo on grupo.valor_tabela = 'tb_email' and grupo.valor_coluna = 'email_grupo' and email_grupo = grupo.valor_numero
--> E-mails <--
--> Form E-mails <--
declare @id as int = 1
declare @tabela as varchar(10) = 'telefone'
select
email_nome,
email_setor,
email_email,
email_senha,
dominio.valor_valor as 'dominio',
email_estado,
grupo.valor_valor as 'grupo',
(select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_email
left join meta_valor dominio
on dominio.valor_tabela = 'tb_email'
and dominio.valor_coluna = 'email_dominio'
and tb_email.email_dominio = dominio.valor_numero
left join meta_valor grupo
on grupo.valor_tabela = 'tb_email'
and grupo.valor_coluna = 'email_grupo'
and tb_email.email_dominio = grupo.valor_numero
where email_id = @id

select valor_numero,valor_valor from meta_valor where valor_tabela='tb_email' and valor_coluna = 'email_dominio'
--> Form E-mails <--
--> Salvar E-mail <--
INSERT INTO tb_email(
	email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo
)
VALUES(
	@nome,
	@setor,
	@email,
	@senha,
	@dominio,
	@estado,
	@grupo
)
select SCOPE_IDENTITY()
--> Salvar E-mail <--
--> Alterar E-mail <--
UPDATE tb_email SET
email_nome = @nome,
email_setor = @setor,
email_email = @email,
email_senha = @senha,
email_dominio = @dominio,
email_estado = @estado,
email_grupo = @grupo
where email_id = @id
--> Alterar E-mail <--
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
estoque_quantidade as 'Quantidade',
estoque_localizacao as 'Local armazenado'
from tb_estoque
--> Estoque <--
--> Form Estoque <--
select
estoque_nome,
estoque_descricao,
estoque_quantidade,
estoque_localizacao,
(select sum(case when nota_pkitem = @id and nota_tabela = @tabela and nota_excluido is null then 1 else 0 end) from tb_anotacao) as 'qtd_notas'
from tb_estoque
where estoque_id = @id
--> Form Estoque <--
--> Salvar Estoque <--
insert into tb_estoque 
(estoque_nome, estoque_descricao, estoque_tag, estoque_quantidade, estoque_localizacao)
VALUES(
@nome,
@descricao,
@tag,
@quantidade,
localizacao
)
--> Salvar Estoque <--
--> Alterar Estoque <--
UPDATE tb_estoque SET
estoque_nome = @nome,
estoque_descricao = @descricao,
estoque_tag = @tag,
estoque_quantidade = @quantidade,
estoque_localizacao = @localizacao
where estoque_id = @id
--> Alterar Estoque <--
--> Software <--
--> Software <--
