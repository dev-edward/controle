--use master
--rop database controle

CREATE DATABASE controle
GO

USE controle
GO

-- IDENTITY_CACHE = OFF, para n�o reservar 1000 valores de identidade durante uma transa��o
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
GO

CREATE TABLE meta_dicionario
(/*informa��es da tabela inseridas*/
	dic_tabela NVARCHAR(30),
	dic_coluna NVARCHAR(30),
	dic_descricao NVARCHAR(120),
	dic_inclusao NVARCHAR(10)
)
CREATE TABLE meta_valor
(/*informa��es da tabela inseridas*/
	valor_tabela NVARCHAR(30),
	valor_coluna NVARCHAR(30),
	valor_numero TINYINT,
	valor_valor NVARCHAR(30)
)
CREATE TABLE meta_tabela
(/*informa��es da tabela inseridas*/
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
(/*-- n�o lembro o objeti --*/
	usuario_id INT PRIMARY KEY IDENTITY,
	sistema_menunome varchar(15),
	sistema_submenunome varchar(15)
)
--CREATE TABLE tb_item
--(/*informa��es da tabela inseridas*/
--	item_id INT PRIMARY KEY IDENTITY,
--	item_tabela NVARCHAR(20)
--)
CREATE TABLE tb_usuario
(/*informa��es da tabela inseridas*/
	usuario_id INT PRIMARY KEY IDENTITY,
	--usuario_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	usuario_user VARCHAR(15),
	usuario_nome VARCHAR(35),
	usuario_senha VARCHAR(35)
)
CREATE TABLE tb_anotacao
(/*informa��es da tabela inseridas*/
	nota_id INT PRIMARY KEY IDENTITY,
	nota_pkitem INT NOT NULL,
	nota_tabela NVARCHAR(30) NOT NULL,
	nota_nota NVARCHAR(256),
	nota_excluido TINYINT
)
CREATE TABLE tb_estoque
(/*informa��es da tabela inseridas*/
	estoque_id INT PRIMARY KEY IDENTITY,
	estoque_nome NVARCHAR(20) UNIQUE,
	estoque_descricao NVARCHAR(60),
	--estoque_tag NVARCHAR(20),
	estoque_quantidade INT,
	estoque_localizacao NVARCHAR(40),
	estoque_dtcadastro DATETIME DEFAULT GETDATE(),
	estoque_usercadastro TINYINT,
	estoque_dtalteracao DATETIME,
	estoque_useralteracao TINYINT
)
CREATE TABLE tb_demanda
(/*informa��es da tabela inseridas*/
	demanda_id INT PRIMARY KEY IDENTITY,
	demanda_dtcadastro DATETIME DEFAULT GETDATE(),
	demanda_usercadastro TINYINT,
	demanda_dtalteracao DATETIME,
	demanda_useralteracao TINYINT,
	demanda_titulo NVARCHAR(30),
	demanda_detalhes NVARCHAR(256),
	demanda_temprevisao TINYINT,
	demanda_previsao DATETIME,
	demanda_status TINYINT,
	demanda_encarregado TINYINT,
	demanda_prioridade TINYINT
)
CREATE TABLE tb_evento
(
	evento_id INT PRIMARY KEY IDENTITY,
	evento_descricao NVARCHAR(128),
	evento_datahora DATETIME,
	evento_ultimocheck DATETIME,
	evento_frequencia TINYINT,
	evento_allday TINYINT,
	evento_ativo TINYINT,
	evento_dtcadastro DATETIME DEFAULT GETDATE(),
	evento_usercadastro TINYINT,
	evento_dtalteracao DATETIME,
	evento_useralteracao TINYINT
)
CREATE TABLE tb_telefone
(/*informa��es da tabela inseridas*/
	telefone_id INT PRIMARY KEY IDENTITY,
	telefone_numero NVARCHAR(16),
	telefone_pessoa NVARCHAR(30),
	telefone_local NVARCHAR(30),
	telefone_tipo TINYINT
)
CREATE TABLE tb_email
(
	email_id INT PRIMARY KEY IDENTITY,
	email_nome NVARCHAR(40),
	email_setor NVARCHAR(30),
	email_email NVARCHAR(40),
	email_senha NVARCHAR(20),
	email_estado TINYINT,
	email_grupo TINYINT
)
CREATE TABLE tb_skype
(
	skype_id INT PRIMARY KEY IDENTITY,
	skype_nome NVARCHAR(40),
	skype_unidade NVARCHAR(30),
	skype_departamento NVARCHAR(30),
	skype_skype NVARCHAR(30),
	skype_email NVARCHAR(40),
	skype_senha NVARCHAR(12)
)
CREATE TABLE tb_local
(
	local_id INT PRIMARY KEY IDENTITY,
	local_nome NVARCHAR(24),
	local_bloco NVARCHAR(1),
	local_andar TINYINT,
	local_descricao NVARCHAR(64)
)
CREATE TABLE tb_pessoa
(
	pessoa_id INT PRIMARY KEY IDENTITY,
	pessoa_nome NVARCHAR(30),
	--pessoa_fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id)
)

CREATE TABLE tb_dispositivo
(/*informa��es da tabela inseridas*/
	dispositivo_id INT PRIMARY KEY IDENTITY,
	dispositivo_tipo TINYINT,
	dispositivo_posto TINYINT,
	dispositivo_marcamodelo NVARCHAR(32),
	dispositivo_hostname NVARCHAR(24),
	dispositivo_ip NVARCHAR(16),
	dispositivo_macadress NVARCHAR(18),
	dispositivo_os NVARCHAR(32),
	dispositivo_qtdmemoriaram TINYINT,
	dispositivo_processador NVARCHAR(24),
	dispositivo_armazenamento NVARCHAR(32),
	dispositivo_bateria NVARCHAR(32),
	dispositivo_dtcadastro DATETIME DEFAULT GETDATE(),
	dispositivo_usercadastro TINYINT,
	dispositivo_dtalteracao DATETIME,
	dispositivo_useralteracao TINYINT
)
CREATE TABLE tb_impressora
(/*informa��es da tabela inseridas*/
	impressora_id INT PRIMARY KEY IDENTITY,
	impressora_nserie NVARCHAR(12),
	impressora_nnota NVARCHAR(16),
	impressora_nproduto NVARCHAR(16),
	impressora_marcamodelo NVARCHAR(24),
	impressora_suprimento TINYINT,
	impressora_ip NVARCHAR(15),
	impressora_corimpressao TINYINT,
	impressora_local INT,
	impressora_estado TINYINT,
	impressora_dtentrada DATETIME,
	impressora_dtsaida DATETIME,
	impressora_dtcadastro DATETIME DEFAULT GETDATE(),
	impressora_usercadastro TINYINT,
	impressora_dtalteracao DATETIME,
	impressora_useralteracao TINYINT
)
CREATE TABLE tb_nobreak
(
	nobreak_id INT PRIMARY KEY IDENTITY,
	--nobreak_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	nobreak_marca NVARCHAR(20),
	nobreak_modelo NVARCHAR(20),
	nobreak_bateria NVARCHAR(20)
)
CREATE TABLE tb_projetor
(
	projetor_id INT PRIMARY KEY IDENTITY,
	--projetor_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	projetor_modelo NVARCHAR(20),
	projetor_conexao TINYINT,
	projetor_limpeza DATE, 
	projetor_tempolampada INT
)
CREATE TABLE tb_camera
(
	camera_id INT PRIMARY KEY IDENTITY,
	--camera_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
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
--CREATE table tb_notapessoal
--(/*informa��es da tabela inseridas*/
--	nt_id INT PRIMARY KEY IDENTITY,
--	nt_fkuser INT FOREIGN KEY REFERENCES tb_usuario(usuario_id) NOT NULL,
--	nt_nota NVARCHAR(256),
--	nt_excluido TINYINT
--)
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
	historico_descricao NVARCHAR(256)
)

/******************************************/
/* inclus�es para a tabela de dicionario */
/****************************************/

/** Tabela dicionario **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','#','Armazena uma descri��o das colunas de todas as tabelas do banco de dados para ser consultado','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_tabela','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_coluna','Nome da coluna da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_descricao','Descri��o da coluna, seu uso ou proposito','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_dicionario','dic_inclusao','Indica em qual vers�o foi incluida a coluna, s� para ter algum controle no futuro','1')

/** Tabela valor **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','#','Armazena os valores das colunas que s�o representadas com n�meros','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_tabela','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_coluna','Nome da coluna','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_numero','Numero representativo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_valor','valor_valor','Valor do numero (ex 1:sim 2:n�o)','1')

/** Tabela tabela **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','#','Guarda o nome das tabelas e atribui um numero a ela, para ser usado na tabela item por exemplo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','tabela_nome','Nome da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('meta_tabela','tabela_numero','N�mero atribu�do � tabela','1')

/** Tabela item **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','#','Esta tabela serve para catrastrar todos os itens, para que possam se relacionar com outras tabelas, ex:tb_notas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','item_id','Chave primaria da tabela, que ser� usada como FK em outras tabelas','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_item','item_tabela','Tabela em que est� cadastrada, onde se encontram informa��es espec�ficas do item','1')

/** Tabela usuario **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','#','Armazena dados dos usuarios que usam o software','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_id','Chave primaria da tabela, usada como FK em outras tabelas','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_fkitem','Chave estrangeira da tabela items','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_user','Nome de usuario da pessoa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_nome','Nome real da pessoa','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_usuario','usuario_senha','Senha que foi definida','1')

/** Tabela demanda **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','#','Armazena demandas, tarefas, atividades, para lembrar e consultar','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_id','Chave primaria da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_dtcadastro','Data em que a demanda foi cadastrada','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_usercadastro','FK do usuario que cadastrou a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_dtalteracao','Data da ultima altera��o das informa��es','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_titulo','O titulo que se deu para a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_detalhes','A descri��o e os detalhes da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_temprevisao','Indica se tem prazo ou uma previs�o para a realiza��o da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_previsao','Data em que precisa ser conclu�da a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_status','FK do estado que se encontra a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_encarregado','FK do usuario que ficou encarregado/respons�vel/� frente da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_prioridade','Quanto maior o numero maior a prioridade da demanda,','1')

/** Tabela do estoque **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','#','Armazena informa��es dos itens em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_id','Chave prim�ria da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_nome','Nome do recurso/pe�a/material','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_descricao','Breve informa��o da sua utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_tag','Usada para agrupar por tipos ou utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_quantidade','Quantidade em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_localizacao','O local onde o item est� guardado','1')

/** Tabela de notas **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','#','Armazena as notas de itens(anota��es relevantes, especifica do item)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_pkitem','Chave primaria da tabela do item da nota','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_tabela','Tabela ao qual o item dono da nota pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_nota','A anota��o','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso n�o ir� aparecer na lista de notas do item.','1')

/** Tabela de eventos **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','#','Armazena eventos, para ajudar lembrar eventos no dia','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_descricao','Descri��o do evento','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_datahora','A data e a hora que o evento ir� come�ar a acontecer','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_ultimocheck','Ultimo dia que foi visualisado/confirmado que j� terminou o evento ','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_frequencia','O periodo de lembretes, se � uma vez, di�rio, semanal, etc...','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_allday','O evento pode acontecer a qualquer momento do dia','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_ativo','Se o evento est� ativo, ainda mostra lembretes','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_notificadohj','Se j� apareceu uma notifica��o do evento no dia','1')

/** Tabela de notas pessoais **/
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','#','Armazena as anota��es de cada usu�rio','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_id','Chave primaria da tabela ','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_fkuser','Chave extrangeira correspondente ao usu�rio que a nota pertence','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_nota','A anota��o','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso n�o ir� aparecer na lista de notas do item.','1')

/** Tabela de tb_telefone **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','#','Armazena os ramais/telefone de usuarios/departamentos internos e externos','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_numero','N�mero de ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_pessoa','Pessoas que atendem este ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_local','O departamento ao qual o ramal/telefone pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_tipo','O tipo, se � telefone, celular ou ramal','1')

/** Tabela de tb_email **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','#','Armazena os emails internos e externos','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_nome','Nome da pessoa que usa este e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_setor','Setor em que se encontra a pessoa que usa este e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_email','Endere�o de e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_senha','Senha do e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_dominio','Dominio do e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_estado','Estado do email','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_grupo','Grupo a que pertence o dono do e-mail','1')

/** Tabela de tb_skype **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','#','Armazena as contas de skype de funcion�rios e outros','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_nome','O nome que aparece na conta do skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_unidade','A unidade do funcion�rio que usa o skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_departamento','O departamento que o funcion�rio pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_skype','ID da conta de skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_email','E-mail que est� cadastrado neste skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_senha','Senha do skype','1')

/** Tabela Dispositivo **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','#','Guarda informa��es de Computador/Notebook/Chromebook/Tablet/Celular','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_id','Chave prim�ria da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_dtcadastro','Data em que o dispositivo foi cadastrado','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_usercadastro','FK do usuario que cadastrou o dispositivo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_dtalteracao','Data da ultima altera��o das informa��es','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_tipo','FK do tipo de dispositivo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_posto','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_marcamodelo','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_nome','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_ip','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_macadress','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_os','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_qtdmemoriaram','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_processador','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_armazenamento','','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_bateria','','1')

/** Tabela impressora **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','#','Guarda informa��es das impressoras','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_id','Chave primaria da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtcadastro','Data em que a impressora foi cadastrada pela primeira vez','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_usercadastro','FK do usuario que cadastrou a impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtalteracao','Data da ultima altera��o das informa��es','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_marcamodelo','Marca e modelo da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nserie','N�mero de serie da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nnota','N�mero da nota da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_nproduto','N�mero de produto da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_suprimento','suprimento da impressora(toner,cartucho,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_corimpress�o','Indica se imprime apenas em preto e branco(1) ou colorido(2)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_local','FK do local em que a impressora est� sendo usada','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_estado','Indica em qual estado a impressora est�(ex:ativo,substituido,devolvido,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_ip','IP da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtentrada','Data em que a impressora foi adquirida','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtsaida','Data em que a impressora saiu','1')

/** (desnecess�rio)Tabelas e seus n�meros **/
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_dicionario',1)
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_valor',2)
insert into meta_tabela(tabela_nome,tabela_numero) values('meta_tabela',3)
--insert into meta_tabela(tabela_nome,tabela_numero) values('tb_item',4)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_notaitem',5)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_item',6)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_pessoaitem',7)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_salaitem',8)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_historico',9)
insert into meta_tabela(tabela_nome,tabela_numero) values('tb_afazer',10)

/***********************************/
/* inclus�es na tabela meta_valor */
/*********************************/
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_anotacao','nota_excluido',0,'n�o exclu�do')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_anotacao','nota_excluido',1,'eclu�do')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_temprevisao',0,'n�o')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_temprevisao',1,'sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',1,'Aguardando')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',2,'Em andamento')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',3,'Feito')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',4,'Descartado')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',1,'Descart�vel')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',2,'Baixa')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',3,'Normal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',4,'Alta')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',5,'Urgente')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_tipo',1,'Computador')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_tipo',2,'Notebook')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_tipo',3,'Chromebook')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_tipo',4,'Tablet')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_tipo',5,'Celular')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_posto',0,'n�o')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_posto',1,'sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_suprimento',1,'Toner T06')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_suprimento',2,'Toner T07')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_suprimento',3,'Toner T10')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_corimpressao',0,'Preto & Branco')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_corimpressao',1,'Colorido')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_estado',1,'Ativo')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_estado',2,'Inativo')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_estado',3,'Devolvido')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_projetor','projetor_conexao',1,'VGA')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_projetor','projetor_conexao',2,'HDMI')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_estado',0,'Inativo')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_estado',1,'Ativo')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',1,'Funcion�rio')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',2,'Irm�s')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',3,'Externo')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',1,'Ramal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',2,'Telefone')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',3,'Celular')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',4,'Whatsapp')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',1,'Uma vez')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',2,'Di�rio')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',3,'Semanal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',4,'Mensal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',5,'Anual')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_allday',0,'N�o')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_allday',1,'Sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_ativo',0,'N�o')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_ativo',1,'Sim')
--

