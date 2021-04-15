CREATE DATABASE controle
GO
USE controle

CREATE TABLE tb_afazer
(
	afazer_id INT PRIMARY KEY IDENTITY,
	afazer_datacadastro DATETIME DEFAULT GETDATE(),
	afazer_status TINYINT,
	afazer_prazo DATETIME,
	afazer_titulo NVARCHAR(30),
	afazer_detalhes NVARCHAR(90),
	afazer_ultalteracao DATETIME DEFAULT GETDATE(),
)

CREATE TABLE tb_evento
(
	evento_id INT PRIMARY KEY IDENTITY,
	evento_data DATETIME,
	evento_descricao NVARCHAR(256)
)

CREATE TABLE tb_item
(
	item_id INT PRIMARY KEY IDENTITY,
	item_tipo INT,
	item_tabela VARCHAR(16)
)

CREATE TABLE tb_estoque
(
	estoque_id INT PRIMARY KEY IDENTITY,
	estoque_fkobjeto INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	estoque_quantidade INT,
	estoque_localizacao NVARCHAR(30)
)

CREATE TABLE tb_sala
(
	sala_id INT PRIMARY KEY IDENTITY,
	sala_nome NVARCHAR(20),
	sala_bloco NVARCHAR(20),
	sala_descricao NVARCHAR(30)
)

CREATE TABLE tb_pessoa
(
	pessoa_id INT PRIMARY KEY IDENTITY,
	pessoa_nome NVARCHAR(30),
	pessoa_fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id)
)

CREATE TABLE tb_dispositivo
(
	dispositivo_id INT PRIMARY KEY IDENTITY,
	dispositivo_tipo TINYINT,
	dispositivo_posto TINYINT,
	dispositivo_fkobjeto INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	dispositivo_marcamodelo NVARCHAR(30),
	dispositivo_nome NVARCHAR(20),
	dispositivo_ip NVARCHAR(16),
	dispositivo_macadress NVARCHAR(20),
	dispositivo_os NVARCHAR(20),
	dispositivo_qtdmemoriaram TINYINT,
	dispositivo_processador NVARCHAR(20),
	dispositivo_armazenamento NVARCHAR(30),
	dispositivo_bateria NVARCHAR(30)
	dispositivo_fkpessoa 
)
CREATE TABLE tb_impressora
(
	impressora_id INT PRIMARY KEY IDENTITY,
	impressora_marcamodelo NVARCHAR(20),
	impressora_toner TINYINT

)
CREATE TABLE tb_nobreak
(
	nobreak_id INT PRIMARY KEY IDENTITY,
	nobreak_marca NVARCHAR(20),
	nobreak_modelo NVARCHAR(20),
	nobreak_bateria NVARCHAR(20)
)
CREATE TABLE tb_projetor
(
	projetor_id INT PRIMARY KEY IDENTITY,
	projetor_fksala INT FOREIGN KEY REFERENCES tb_sala(sala_id) NOT NULL,
	projetor_modelo NVARCHAR(20),
	projetor_conexao TINYINT,
	projetor_limpeza DATE, 
	projetor_tempolampada INT
)
CREATE TABLE tb_camera
(
	camera_id INT PRIMARY KEY IDENTITY,
	camera_marcamodelo NVARCHAR(30),
	camera_resolucao NVARCHAR(16),
	camera_local NVARCHAR(20)
)
CREATE TABLE tb_notaitem
(
	notaitem_id INT PRIMARY KEY IDENTITY,
	notaitem_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL UNIQUE,
	notaitem_nota NVARCHAR(256)
)
CREATE TABLE tb_historico
(
	historico_id INT PRIMARY KEY IDENTITY,
	historico_fkitem INT FOREIGN KEY REFERENCES tb_item(item_id) NOT NULL,
	historico_descricao NVARCHAR(256)
)

use controle
go
select * from tb_afazer
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 1','detalhes 1','11/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 2','detalhes 2','12/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 3','detalhes 3','13/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 4','detalhes 4','14/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 5','detalhes 5','15/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 6','detalhes 6','16/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 7','detalhes 7','17/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 8','detalhes 8','18/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 9','detalhes 9','19/04/2021',1)
insert into tb_afazer(afazer_titulo,afazer_detalhes,afazer_prazo,afazer_status) VALUES('titulo 10','detalhes 10','20/04/2021',1)


