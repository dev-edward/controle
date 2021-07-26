--use master
--rop database controle

CREATE DATABASE controle
GO
USE controle

CREATE TABLE meta_dicionario
(/*informações da tabela inseridas*/
	dic_tabela NVARCHAR(30),
	dic_coluna NVARCHAR(30),
	dic_descricao NVARCHAR(120),
	dic_inclusao NVARCHAR(10)
)
CREATE TABLE meta_valor
(/*informações da tabela inseridas*/
	valor_tabela NVARCHAR(30),
	valor_coluna NVARCHAR(30),
	valor_numero TINYINT,
	valor_valor NVARCHAR(30)
)
CREATE TABLE meta_tabela
(/*informações da tabela inseridas*/
	tabela_nome NVARCHAR(30),
	tabela_numero TINYINT
)
CREATE TABLE meta_permissao
(
	perm_usuario INT,
	perm_menu INT,
	perm_submenu INT
)
CREATE TABLE meta_sistema
(
	usuario_id INT PRIMARY KEY IDENTITY,
	sistema_menunome varchar(15),
	sistema_submenunome varchar(15)

)
CREATE TABLE tb_usuario
(/*informações da tabela inseridas*/
	usuario_id INT PRIMARY KEY IDENTITY,
	usuario_user VARCHAR(15),
	usuario_nome VARCHAR(30),
	usuario_senha VARCHAR(35)
)
CREATE TABLE tb_item
(/*informações da tabela inseridas*/
	item_id INT PRIMARY KEY IDENTITY,
	item_tipo INT
)
CREATE TABLE tb_afazer
(/*informações da tabela inseridas*/
	afazer_id INT PRIMARY KEY IDENTITY,
	afazer_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	afazer_dtcadastro DATETIME DEFAULT GETDATE(),
	afazer_usercadastro TINYINT,
	afazer_dtalteracao DATETIME,
	afazer_useralteracao TINYINT,
	afazer_titulo NVARCHAR(30),
	afazer_detalhes NVARCHAR(90),
	afazer_prazo DATETIME,
	afazer_status TINYINT
	
)

CREATE TABLE tb_evento
(
	evento_id INT PRIMARY KEY IDENTITY,
	evento_data DATETIME,
	evento_descricao NVARCHAR(256)
)

CREATE TABLE tb_estoque
(
	estoque_id INT PRIMARY KEY IDENTITY,
	estoque_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	estoque_quantidade INT,
	estoque_localizacao NVARCHAR(30)
)

CREATE TABLE tb_sala
(
	sala_id INT PRIMARY KEY IDENTITY,
	sala_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	sala_nome NVARCHAR(20),
	sala_bloco NVARCHAR(20),
	sala_descricao NVARCHAR(30)
)

CREATE TABLE tb_pessoa
(
	pessoa_id INT PRIMARY KEY IDENTITY,
	pessoa_nome NVARCHAR(30),
	--pessoa_fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id)
)

CREATE TABLE tb_dispositivo
(
	dispositivo_id INT PRIMARY KEY IDENTITY,
	--dispositivo_fkpessoa INT FOREIGN KEY REFERENCES tb_pessoa(pessoa_id),
	--dispositivo_fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id),
	dispositivo_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	dispositivo_tipo TINYINT,
	dispositivo_posto TINYINT,
	dispositivo_marcamodelo NVARCHAR(30),
	dispositivo_nome NVARCHAR(20),
	dispositivo_ip NVARCHAR(16),
	dispositivo_macadress NVARCHAR(20),
	dispositivo_os NVARCHAR(20),
	dispositivo_qtdmemoriaram TINYINT,
	dispositivo_processador NVARCHAR(20),
	dispositivo_armazenamento NVARCHAR(30),
	dispositivo_bateria NVARCHAR(30)
	
)

CREATE TABLE tb_impressora
(/*informações da tabela inseridas*/
	impressora_id INT PRIMARY KEY IDENTITY,
	impressora_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	impressora_dtcadastro DATETIME DEFAULT GETDATE(),
	impressora_usercadastro TINYINT,
	impressora_dtalteracao DATETIME,
	impressora_useralteracao TINYINT,
	impressora_marcamodelo NVARCHAR(20),
	impressora_nserie NVARCHAR(12),
	impressora_ip NVARCHAR(15),
	impressora_suprimento TINYINT,
	impressora_corimpressão TINYINT,
	impressora_estado TINYINT,
	impressora_dtentrada DATETIME,
	impressora_dtsaida DATETIME
)
CREATE TABLE tb_nobreak
(
	nobreak_id INT PRIMARY KEY IDENTITY,
	nobreak_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	nobreak_marca NVARCHAR(20),
	nobreak_modelo NVARCHAR(20),
	nobreak_bateria NVARCHAR(20)
)
CREATE TABLE tb_projetor
(
	projetor_id INT PRIMARY KEY IDENTITY,
	projetor_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	projetor_modelo NVARCHAR(20),
	projetor_conexao TINYINT,
	projetor_limpeza DATE, 
	projetor_tempolampada INT
)
CREATE TABLE tb_camera
(
	camera_id INT PRIMARY KEY IDENTITY,
	camera_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	camera_marcamodelo NVARCHAR(30),
	camera_resolucao NVARCHAR(16),
	camera_local NVARCHAR(20)
)
CREATE TABLE tb_software
(
	software_id INT PRIMARY KEY IDENTITY,
	software_nome NVARCHAR(60),
	software_descricao NVARCHAR(120),
	software_dtinstalacao DATETIME,
	software_ultatualizacao DATETIME
)

CREATE TABLE tb_notaitem
(
	nota_id INT PRIMARY KEY IDENTITY,
	nota_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	nota_nota NVARCHAR(256)
)
CREATE TABLE tb_pessoaitem
(
	pessoaitem_id INT PRIMARY KEY IDENTITY,
	fkpessoa INT FOREIGN KEY REFERENCES tb_pessoa(pessoa_id) NOT NULL,
	fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	data_atribuicao DATETIME
)
CREATE TABLE tb_salaitem
(
	salaitem_id INT PRIMARY KEY IDENTITY,
	fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id) NOT NULL,
	fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	data_atribuicao DATETIME
)

CREATE TABLE tb_historico
(
	historico_id INT PRIMARY KEY IDENTITY,
	historico_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	historico_descricao NVARCHAR(256)
)



/******************************************/
/* inclusões para a tabela de dicionario */
/****************************************/

/** Tabela dicionario **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','#','Armazena uma descrição das colunas de todas as tabelas do banco de dados para ser consultado','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_tabela','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_coluna','Nome da coluna da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_descricao','Descrição da coluna, seu uso ou proposito','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_inclusao','Indica em qual versão foi incluida a coluna, só para ter algum controle no futuro','1')

/** Tabela valor **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','#','Armazena os valores das colunas que são representadas com números','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_tabela','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_coluna','Nome da coluna','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_numero','Numero representativo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_valor','Valor do numero (ex 1:sim 2:não)','1')

/** Tabela tabela **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','#','Guarda o nome das tabelas e atribui um numero a ela, para ser usado na tabela item por exemplo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','tabela_nome','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','tabela_numero','Número atribuído à tabela','1')

/** Tabela item **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_item','#','Esta tabela serve para catrastrar todos os itens, para que possam se relacionar com outras tabelas, ex:tb_notas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_item','item_id','Chave primaria da tabela, que será usada como FK em outras tabelas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_item','item_tipo','FK do tipo do item ou seja em que tabela está cadastrada','1')

/** Tabela usuario **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','#','Armazena dados dos usuarios que usam o software','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_id','Chave primaria da tabela, usada como FK em outras tabelas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_user','Nome de usuario da pessoa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_nome','Nome real da pessoa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_senha','Senha que foi definida','1')

/** Tabela afazer **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','#','Armazena afazeres, tarefas, atividades, para lembrar e consultar','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_dtcadastro','Data em que a tarefa foi cadastrada pela primeira vez','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_usercadastro','FK do usuario que cadastrou a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_dtalteracao','Data da ultima alteração das informações','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_status','FK do estado que se encontra a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_prazo','Data em que precisa ser concluída a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_titulo','O titulo que se deu para a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_detalhes','A descrição e os detalhes da tarefa','1')

/** Tabela impressora **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','#','Guarda informações das impressoras','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtcadastro','Data em que a impressora foi cadastrada pela primeira vez','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_usercadastro','FK do usuario que cadastrou a impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtalteracao','Data da ultima alteração das informações','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_marcamodelo','Marca e modelo da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nserie','Número de serie da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_ip','IP da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_suprimento','FK do suprimento(toner,cartucho,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_corimpressão','Indica se imprime apenas em preto e branco ou colorido','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_estado','Indica em qual estado a impressora está(ex:ativo,substituido,devolvido,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtentrada','Data em que a impressora foi adquirida','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtsaida','Data em que a impressora saiu','1')

/** Tabelas e seus números **/
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_dicionario',1)
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_valor',2)
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_tabela',3)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_item',4)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_notaitem',5)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_item',6)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_pessoaitem',7)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_salaitem',8)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_historico',9)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_afazer',10)


/**************************************/
/* inclusões para proposito de teste */
/************************************/

insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 1','detalhes 1','11/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 2','detalhes 2','12/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 3','detalhes 3','13/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 4','detalhes 4','14/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 5','detalhes 5','15/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 6','detalhes 6','16/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 7','detalhes 7','17/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 8','detalhes 8','18/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 9','detalhes 9','19/04/2021',1)
insert into tb_item(item_tipo) values(10) insert into tb_afazer(afazer_fkitem,afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES(scope_identity(),'titulo 10','detalhes 10','20/04/2021',1)
--select * from tb_afazer
--select * from tb_item

insert into tb_item default values insert into tb_afazer(afazer_fkitem) values(scope_identity())

insert into tb_notaitem(nota_fkitem,nota_nota) values(1,'teste nota')
select * from tb_notaitem

insert into tb_impressora(impressora_marcamodelo,impressora_nserie,impressora_fkitem) values('canon teste','dfsas',11)
select * from tb_impressora
select * from meta_dicionario

insert into tb_usuario(usuario_user,usuario_nome,usuario_senha) values('edward','Edward Cahua Huayta','senha')
select * from tb_afazer