--use master
--rop database controle

CREATE DATABASE controle
GO

USE controle
GO

-- IDENTITY_CACHE = OFF, para não reservar 1000 valores de identidade durante uma transação
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
GO

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
(/*-- não lembro o objeti --*/
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
	item_tabela NVARCHAR(20)
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
	afazer_detalhes NVARCHAR(256),
	afazer_temprevisao TINYINT,
	afazer_previsao DATETIME,
	afazer_status TINYINT
)

CREATE TABLE tb_evento
(
	evento_id INT PRIMARY KEY IDENTITY,
	evento_data DATETIME,
	evento_descricao NVARCHAR(256)
)
CREATE TABLE tb_telefone
(/*informações da tabela inseridas*/
	telefone_id INT PRIMARY KEY IDENTITY,
	telefone_numero NVARCHAR(16),
	telefone_pessoa NVARCHAR(30),
	telefone_local NVARCHAR(30)
)
CREATE TABLE tb_estoque
(/*informações da tabela inseridas*/
	estoque_id INT PRIMARY KEY IDENTITY,
	estoque_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	estoque_nome NVARCHAR(18),
	estoque_descricao NVARCHAR(60),
	estoque_tag NVARCHAR(12),
	estoque_quantidade INT,
	estoque_localizacao NVARCHAR(40)
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
	impressora_nnota NVARCHAR(16),
	impressora_nproduto NVARCHAR(16),
	impressora_suprimento INT FOREIGN KEY REFERENCES tb_estoque(estoque_id),
	impressora_corimpressão TINYINT,
	impressora_local NVARCHAR(20),
	impressora_estado TINYINT,
	impressora_ip NVARCHAR(15),
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
(/*informações da tabela inseridas*/
	nota_id INT PRIMARY KEY IDENTITY,
	nota_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	nota_nota NVARCHAR(256),
	nota_excluido TINYINT
)
CREATE table tb_notapessoal
(/*informações da tabela inseridas*/
	nt_id INT PRIMARY KEY IDENTITY,
	nt_fkuser INT FOREIGN KEY REFERENCES tb_usuario(usuario_id) NOT NULL,
	nt_nota NVARCHAR(256),
	nt_excluido TINYINT
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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','#','Esta tabela serve para catrastrar todos os itens, para que possam se relacionar com outras tabelas, ex:tb_notas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','item_id','Chave primaria da tabela, que será usada como FK em outras tabelas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','item_tabela','Tabela em que está cadastrada, onde se encontram informações específicas do item','1')

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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_titulo','O titulo que se deu para a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_detalhes','A descrição e os detalhes da tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_temprevisao','Indica se tem prazo ou uma previsão para a realização da tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_previsao','Data em que precisa ser concluída a tarefa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_afazer','afazer_status','FK do estado que se encontra a tarefa','1')

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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nnota','Número da nota da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nproduto','Número de produto da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_suprimento','FK do suprimento(toner,cartucho,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_corimpressão','Indica se imprime apenas em preto e branco(1) ou colorido(2)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_local','O local que a impressora está sendo usada','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_estado','Indica em qual estado a impressora está(ex:ativo,substituido,devolvido,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_ip','IP da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtentrada','Data em que a impressora foi adquirida','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtsaida','Data em que a impressora saiu','1')

/** Tabela do estoque **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','#','Armazena informações dos itens em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_id','Chave primária da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_nome','Nome do recurso/peça/material','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_descricao','Breve informação da sua utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_tag','Usada para agrupar por tipos ou utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_quantidade','Quantidade em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_localizacao','O local onde o item está guardado','1')

/** Tabela de notas **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','#','Armazena as notas de itens(anotações relevantes, especifica do item)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_fkitem','Chave extrangeira correspondente ao item que a nota pertenca','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_nota','A anotação','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso não irá aparecer na lista de notas do item.','1')

/** Tabela de notas pessoais **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','#','Armazena as anotações de cada usuário','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_id','Chave primaria da tabela ','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_fkuser','Chave extrangeira correspondente ao usuário que a nota pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_nota','A anotação','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso não irá aparecer na lista de notas do item.','1')

/** Tabela de tb_telefone **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','#','Armazena os ramais/telefone de usuarios/departamentos internos e externos','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_numero','Número de ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_pessoa','Pessoas que atendem este ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_local','O departamento ao qual o ramal/telefone pertence','1')

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

insert into meta_tabela(tabela_nome,tabela_numero) values('tb_afazer',11)


/**************************************/
/* inclusões para proposito de teste */
/************************************/

insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 10','detalhes 10',1,'25/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 11','detalhes 11',1,'26/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 12','detalhes 12',1,'27/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 13','detalhes 13',1,'28/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 14','detalhes 14',1,'29/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 15','detalhes 15',1,'30/04/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 16','detalhes 16',1,'01/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 17','detalhes 17',1,'02/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 18','detalhes 18',1,'03/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 19','detalhes 19',1,'04/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 20','detalhes 20',1,'05/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 21','detalhes 21',1,'06/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 22','detalhes 22',1,'07/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 23','detalhes 23',1,'08/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 24','detalhes 24',1,'09/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 25','detalhes 25',1,'10/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 26','detalhes 26',1,'11/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 27','detalhes 27',1,'12/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 28','detalhes 28',1,'13/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 29','detalhes 29',1,'14/09/2021',1)
insert into tb_item(item_tabela) values('tb_afazer') insert into tb_afazer(afazer_fkitem,afazer_usercadastro,afazer_titulo,afazer_detalhes,afazer_temprevisao,afazer_previsao,afazer_status) VALUES(scope_identity(),1,'titulo 30','detalhes 30',1,'15/09/2021',1)
--select * from tb_afazer
--select * from tb_item

insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('200','Bruna/Marcela','Telefonia Recepção')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('201','Ir. Fátima','Diretora ADM e Financeira')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('205','Lilian','Financeiro')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('206','Leandro','Secretaria')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('207','Galiani','Direção')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('208','Eloisa','Gerência Geral')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('209','Amanda','Orienação Educacional')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('210','Karina','Secretaria')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('212','Régis','Portaria A')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('215','Andre/Paulo/Edward','Serviço de TI')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('216','Portaria F','Portaria F')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('217','Leoveral','Serviço Social')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('218','Lena','Biblioteca')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('222','Angela','Cozinha')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('224','Anderson','Reprografia')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('225','Bete/Vanessa','Cozinha')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('227','Debora','Dpto. de Pessoal')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('231','Carla','Contas a Receber')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('232','Sala de Reunião CA','Centro Administrativo')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('233','Bruna','Aux Coordenação')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('234','Yuri','Lab. Ciências')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('235/234','Thais Yumi','Lab. Informática')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('236','Ana Maria','Enfermaria')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('238','Andrea','Compras')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('240','Glaucia','Financeiro')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('241','Andre Condes','Coordenação')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('243','Fernanda','Financeiro')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('244','Guilherme','MArketing')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('246','Suzanete','Coordenação')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('247','Integral Refeitório','Refeitório')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('248','Elisangela','Serviço de RH')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('249/250','Integral','Integral + Coordenação')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('251','José Ricardo','Pastoral')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('252','Danilo/Graciele','Pastoral')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('253','Monica','Contas a Receber')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('254','Giovanna','Marketing')
insert into tb_telefone(telefone_numero,telefone_pessoa,telefone_local) values('258','Sala dos Professores','Sala dos Professores')


insert into tb_notaitem(nota_fkitem,nota_nota) values(1,'teste nota')
select * from tb_notaitem

insert into tb_impressora(impressora_marcamodelo,impressora_nserie,impressora_fkitem) values('canon teste','dfsas',11)

insert into tb_usuario(usuario_user,usuario_nome,usuario_senha) values('edward','Edward Cahua Huayta','senha')

