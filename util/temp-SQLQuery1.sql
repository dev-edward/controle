select * from tb_anotacao
select * from tb_afazer
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
WHERE TABLE_NAME = N'tb_demanda'

select demanda_id as 'ID',Convert(varchar(16),demanda_dtcadastro, 120) as 'Cadastro', demanda_usercadastro as 'Cadastrado por',
Convert(varchar(16),demanda_dtalteracao, 120) as 'Alteração',demanda_useralteracao as 'Alterado por', demanda_titulo as 'Título',
demanda_detalhes as 'Detalhes', case when demanda_temprevisao > 0 then Convert(varchar(16),demanda_previsao, 120) else 'Sem Previsão' END as 'Previsão',
demanda_status as 'Status'
from tb_demanda 

update tb_demanda set demanda_temprevisao = 0 where demanda_id =2