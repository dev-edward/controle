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
--CREATE TABLE tb_item
--(/*informações da tabela inseridas*/
--	item_id INT PRIMARY KEY IDENTITY,
--	item_tabela NVARCHAR(20)
--)
CREATE TABLE tb_usuario
(/*informações da tabela inseridas*/
	usuario_id INT PRIMARY KEY IDENTITY,
	--usuario_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	usuario_user VARCHAR(15),
	usuario_nome VARCHAR(35),
	usuario_senha VARCHAR(35)
)
CREATE TABLE tb_anotacao
(/*informações da tabela inseridas*/
	nota_id INT PRIMARY KEY IDENTITY,
	nota_pkitem INT NOT NULL,
	nota_tabela NVARCHAR(30) NOT NULL,
	nota_nota NVARCHAR(256),
	nota_excluido TINYINT
)
CREATE TABLE tb_estoque
(/*informações da tabela inseridas*/
	estoque_id INT PRIMARY KEY IDENTITY,
	estoque_nome NVARCHAR(20) UNIQUE,
	estoque_descricao NVARCHAR(60),
	estoque_tag NVARCHAR(20),
	estoque_quantidade INT,
	estoque_localizacao NVARCHAR(40)
)
CREATE TABLE tb_demanda
(/*informações da tabela inseridas*/
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
(/*informações da tabela inseridas*/
	telefone_id INT PRIMARY KEY IDENTITY,
	telefone_numero NVARCHAR(16),
	telefone_pessoa NVARCHAR(30),
	telefone_local NVARCHAR(30),
)
CREATE TABLE tb_email
(
	email_id INT PRIMARY KEY IDENTITY,
	email_nome NVARCHAR(40),
	email_setor NVARCHAR(30),
	email_email NVARCHAR(40),
	email_senha NVARCHAR(16),
	email_dominio NVARCHAR(20),
	email_estado TINYINT,
	email_grupo TINYINT,
	email_outlook_nome NVARCHAR(40),
	email_outlook_ass_nome NVARCHAR(40),
	email_outlook_ass_servico NVARCHAR(40)
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
(/*informações da tabela inseridas*/
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
(/*informações da tabela inseridas*/
	impressora_id INT PRIMARY KEY IDENTITY,
	impressora_nserie NVARCHAR(12),
	impressora_nnota NVARCHAR(16),
	impressora_nproduto NVARCHAR(16),
	impressora_marcamodelo NVARCHAR(24),
	impressora_suprimento INT FOREIGN KEY REFERENCES tb_estoque(estoque_id),
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
--(/*informações da tabela inseridas*/
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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_dtalteracao','Data da ultima alteração das informações','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_useralteracao','FK do usuario que alterou por ultimo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_titulo','O titulo que se deu para a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_detalhes','A descrição e os detalhes da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_temprevisao','Indica se tem prazo ou uma previsão para a realização da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_previsao','Data em que precisa ser concluída a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_status','FK do estado que se encontra a demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_encarregado','FK do usuario que ficou encarregado/responsável/à frente da demanda','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_demanda','demanda_prioridade','Quanto maior o numero maior a prioridade da demanda,','1')

/** Tabela do estoque **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','#','Armazena informações dos itens em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_id','Chave primária da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_nome','Nome do recurso/peça/material','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_descricao','Breve informação da sua utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_tag','Usada para agrupar por tipos ou utilidade','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_quantidade','Quantidade em estoque','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_estoque','estoque_localizacao','O local onde o item está guardado','1')

/** Tabela de notas **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','#','Armazena as notas de itens(anotações relevantes, especifica do item)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_pkitem','Chave primaria da tabela do item da nota','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_tabela','Tabela ao qual o item dono da nota pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_nota','A anotação','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notaitem','nota_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso não irá aparecer na lista de notas do item.','1')

/** Tabela de eventos **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','#','Armazena eventos, para ajudar lembrar eventos no dia','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_descricao','Descrição do evento','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_datahora','A data e a hora que o evento irá começar a acontecer','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_ultimocheck','Ultimo dia que foi visualisado/confirmado que já terminou o evento ','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_frequencia','O periodo de lembretes, se é uma vez, diário, semanal, etc...','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_allday','O evento pode acontecer a qualquer momento do dia','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_ativo','Se o evento está ativo, ainda mostra lembretes','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_evento','evento_notificadohj','Se já apareceu uma notificação do evento no dia','1')

/** Tabela de notas pessoais **/
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','#','Armazena as anotações de cada usuário','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_id','Chave primaria da tabela ','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_fkuser','Chave extrangeira correspondente ao usuário que a nota pertence','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_nota','A anotação','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_notapessoal','nt_excluido','Valor maior ou igual a 1 indica se foi excluido, nesse caso não irá aparecer na lista de notas do item.','1')

/** Tabela de tb_telefone **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','#','Armazena os ramais/telefone de usuarios/departamentos internos e externos','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_numero','Número de ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_pessoa','Pessoas que atendem este ramal/telefone','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_telefone','telefone_local','O departamento ao qual o ramal/telefone pertence','1')

/** Tabela de tb_email **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','#','Armazena os emails internos e externos','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_id','Chave primaria da tabela','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_nome','Nome da pessoa que usa este e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_setor','Setor em que se encontra a pessoa que usa este e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_email','Endereço de e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_senha','Senha do e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_dominio','Dominio do e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_estado','Estado do email','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_grupo','Grupo a que pertence o dono do e-mail','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_outlook_nome','O nome colocado na configuração do Outlook','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_outlook_ass_nome','O nome que aparece na assinatura do Outlook','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_email','email_outlook_ass_servico','Departamento/Serviço que aparece na assinatura do Outlook','1')

/** Tabela de tb_skype **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','#','Armazena as contas de skype de funcionários e outros','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_nome','O nome que aparece na conta do skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_unidade','A unidade do funcionário que usa o skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_departamento','O departamento que o funcionário pertence','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_skype','ID da conta de skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_email','E-mail que está cadastrado neste skype','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_skype','skype_senha','Senha do skype','1')

/** Tabela Dispositivo **/
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','#','Guarda informações de Computador/Notebook/Chromebook/Tablet/Celular','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_id','Chave primária da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_fkitem','Chave estrangeira da tabela item','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_dtcadastro','Data em que o dispositivo foi cadastrado','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_usercadastro','FK do usuario que cadastrou o dispositivo','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_dispositivo','dispositivo_dtalteracao','Data da ultima alteração das informações','1')
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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','#','Guarda informações das impressoras','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_id','Chave primaria da tabela','1')
--insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_fkitem','Chave estrangeira da tabela item','1')
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
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_local','FK do local em que a impressora está sendo usada','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_estado','Indica em qual estado a impressora está(ex:ativo,substituido,devolvido,..)','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_ip','IP da impressora','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtentrada','Data em que a impressora foi adquirida','1')
insert into meta_dicionario (dic_tabela,dic_coluna,dic_descricao,dic_inclusao)values('tb_impressora','impressora_dtsaida','Data em que a impressora saiu','1')

/** (desnecessário)Tabelas e seus números **/
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
/* inclusões na tabela meta_valor */
/*********************************/
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_anotacao','nota_excluido',0,'não excluído')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_anotacao','nota_excluido',1,'ecluído')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_temprevisao',0,'não')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_temprevisao',1,'sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',1,'Aguardando')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',2,'Em andamento')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',3,'Feito')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_status',4,'Descartado')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_demanda','demanda_prioridade',1,'Descartável')
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
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_posto',0,'não')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_dispositivo','dispositivo_posto',1,'sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_corimpressão',0,'Preto & Branco')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_impressora','impressora_corimpressão',1,'Colorido')
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
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',1,'Funcionário')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',2,'Irmãs')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_email','email_grupo',3,'Externo')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',1,'Ramal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',2,'Telefone')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_telefone','telefone_tipo',3,'Celular')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',1,'Uma vez')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',2,'Diário')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',3,'Semanal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',4,'Mensal')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_frequencia',5,'Anual')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_allday',0,'Não')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_allday',1,'Sim')
--
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_ativo',0,'Não')
insert into meta_valor(valor_tabela,valor_coluna,valor_numero,valor_valor) values('tb_evento','evento_ativo',1,'Sim')
--


/**************************************/
/* inclusões para proposito de teste */
/************************************/
-- Afazeres
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 10','detalhes 10',1,'25/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 11','detalhes 11',1,'26/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 12','detalhes 12',1,'27/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 13','detalhes 13',1,'28/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 14','detalhes 14',1,'29/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 15','detalhes 15',1,'30/04/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 16','detalhes 16',1,'01/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 17','detalhes 17',1,'02/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 18','detalhes 18',1,'03/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 19','detalhes 19',1,'04/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 20','detalhes 20',1,'05/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 21','detalhes 21',1,'06/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 22','detalhes 22',1,'07/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 23','detalhes 23',1,'08/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 24','detalhes 24',1,'09/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 25','detalhes 25',1,'10/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 26','detalhes 26',1,'11/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 27','detalhes 27',1,'12/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 28','detalhes 28',1,'13/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 29','detalhes 29',1,'14/09/2021',1,1,5)
insert into tb_demanda(demanda_usercadastro,demanda_titulo,demanda_detalhes,demanda_temprevisao,demanda_previsao,demanda_status,demanda_encarregado,demanda_prioridade) VALUES(1,'titulo 30','detalhes 30',1,'15/09/2021',1,1,5)

-- Telefones/Ramais
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

-- Usuários
insert into tb_usuario(usuario_user,usuario_nome,usuario_senha) values('edward','Edward Cahua Huayta','senha')
insert into tb_usuario(usuario_user,usuario_nome,usuario_senha) values('paulo','Paulo Henrique Gonçalves Santos','senha')
insert into tb_usuario(usuario_user,usuario_nome,usuario_senha) values('andre','André Luis Ruffo Veroneze','senha')

-- Estoque
insert into tb_estoque(estoque_nome,estoque_descricao,estoque_tag,estoque_quantidade,estoque_localizacao) values('Toner T06','Toner usado em impressoras da canon','SuprimentoImpressora',12,'Sala em frente à secretaria')
select * from tb_estoque

-- Impressoras
insert into tb_impressora(impressora_marcamodelo,impressora_nserie,impressora_nnota,impressora_nproduto,impressora_suprimento,impressora_corimpressao,impressora_local,impressora_estado,impressora_ip,impressora_dtentrada,impressora_dtsaida)values('Canon IR1643IF','2TQ05853','000021624','3630C003AA',1,1,1,1,'192.0.1.184','20/01/2021',null)

-- E-mails
insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ELOISA HELENA DE REZENDE','Gerente Geral','admin@ifsj.org.br','#A70B50c30@','ifsj.org.br',1,1,'Administrador - IFSJ',null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('LENA CLAUDIA DIAS BATISTA','Biblioteca','biblioteca@ifsj.org.br','Y67$y56.KLb%','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('GLAUCIA ANGELINA PERIN DE LIMA','Financeiro','financ.inst@ifs.org.br','F1N4NC3Ir0#','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('LILIAN TOREZAN PIMENTA DE SOUSA','Financeiro','financeiro@ifsj.org.br','I02F04S06J08*z','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ELOISA HELENA DE REZENDE','Gerência Geral','gerencia@ifsj.org.br','8@}KOMf2','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('GUILHERME BRIQUES JACYNTO','Comunicação e Marketing','marketing@ifsj.org.br','A10b20c40*','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('Nota Fiscal Eletrônica',null,'nfe@ifsj.org.br','N0T4F15C4L#$','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('JOSÉ RICARDO BAPTISTA','Pastoral','pastoral@ifsj.org.br','&Ze5F07S07J15','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ANDREA TAMASSAKI ARAUJO DA SILVA','Recursos Humanos','rh1@ifsj.org.br','&L6B!53r7T9','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ELISANGELA AMARO FEITOSA DE ANDRADE','Recursos Humanos','rh2@ifsj.org.br','A10B20C30d40E50#','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('LEOVERAL GOLZER SOARES','Serviço Social','serv.social@ifsj.org.br','%Z3[1Lrr','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ANDRE LUIZ RUFFO VERONEZE','TECNOLOGIA DA INFORMAÇÃO','ti1@ifsj.org.br','I05F09S08J08@a','ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('PAULO HENRIQUE GONCALVES DOS SANTOS','TECNOLOGIA DA INFORMAÇÃO','ti2@ifsj.org.br',null,'ifsj.org.br',1,1,null,null,null)

insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('EDWARD CAHUA HUAYTA','TECNOLOGIA DA INFORMAÇÃO','ti3@ifsj.org.br',null,'ifsj.org.br',1,1,null,null,null)




insert into tb_email(email_nome,email_setor,email_email,email_senha,email_dominio,email_estado,email_grupo,email_outlook_nome,email_outlook_ass_nome,email_outlook_ass_servico)
values('ANDREA TAMASSAKI ARAUJO DA SILVA','Compras','compras@saojosevm.org.br','&L6B!53r7T9','saoojosevm.org.br',1,1,null,null,null)
--

-- Locais
insert into tb_local(local_nome,local_bloco,local_andar,local_descricao)
values('STI','A',2,'Tecnologia da Informção')