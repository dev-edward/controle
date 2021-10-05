select * from tb_impressora
insert into tb_item(item_tabela) values('tb_impressora')
insert into tb_impressora(
impressora_fkitem,
impressora_marcamodelo,
impressora_nserie,
impressora_nnota,
impressora_nproduto,
impressora_suprimento,
impressora_corimpressão,
impressora_local,
impressora_estado,
impressora_ip,
impressora_dtentrada,
impressora_dtsaida)
values(
scope_identity(),
'Canon IR1643IF',
'2TQ05853',
'000021624',
'3630C003AA',
1,
'',
)

insert into tb_item(item_tabela) values('tb_estoque') go
insert into tb_estoque(estoque_fkitem,estoque_nome,estoque_descricao,estoque_tag,estoque_quantidade,estoque_localizacao)
values(scope_identity(),'Toner T06','Toner usado em impressoras da canon','SuprimentoImpressora',12,'Sala em frente à secretaria')
select * from tb_estoque

alter table tb_estoque alter column estoque_tag NVARCHAR(20)