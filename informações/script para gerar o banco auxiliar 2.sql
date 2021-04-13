IF DB_ID ('auxiliar') IS NULL
	CREATE DATABASE auxiliar

USE auxiliar

IF OBJECT_ID ('tb_afazer', 'U') IS NOT NULL
DROP TABLE tb_afazer;

CREATE TABLE tb_afazer (
	afazer_id INT NOT NULL,
	afazer_dataatual DATETIME DEFAULT GETDATE(),
	afazer_status TINYINT,
	afazer_prazo DATETIME
)
GO

ALTER TABLE tb_afazer
ADD CONSTRAINT PK_afazer
PRIMARY KEY (afazer_id)