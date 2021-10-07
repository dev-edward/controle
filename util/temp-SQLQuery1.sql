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
