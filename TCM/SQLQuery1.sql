/*CRIANDO O BANCO DE DADOS*/
CREATE DATABASE DB_TRANSPORTADORA;
go
/*ESPECIFICA��O DO BANCO QUE SER� UTIIZADO*/
USE DB_TRANSPORTADORA
go
/*CRIA��O DE TABELAS*/

/*GERENTE*/
CREATE TABLE GERENTE(
ID_COD_GER INTEGER identity,
NOME_GERENTE VARCHAR(30) NOT NULL,
EMAIL VARCHAR(50) NOT NULL UNIQUE,
TELEFONE_GER VARCHAR(15) NOT NULL,
SENHA INT  NOT NULL,
PRIMARY KEY (ID_COD_GER)
);
go
/*CLIENTE*/
CREATE TABLE CLIENTE(
ID_COD_CLI INTEGER identity,
NOME_CLI VARCHAR(30) NOT NULL,
CNPJ VARCHAR(20) NOT NULL,
ENDERECO_CLI VARCHAR(40) NOT NULL,
EMAIL_CLI VARCHAR(50) NOT NULL,
TELEFONE_CLI VARCHAR(15) NOT NULL,
DESCRICAO VARCHAR (200) NOT NULL,
PRIMARY KEY (ID_COD_CLI)
);
go
/*MOTORISTA*/
CREATE TABLE MOTORISTA(
ID_COD_MOT INT identity,
NOME_MOT VARCHAR(30) NOT NULL,
CNH VARCHAR(20) NOT NULL,
DATA_NASCIMENTO DATETIME,
TELEFONE_MOT VARCHAR(15) NOT NULL,
EMAIL_MOT VARCHAR (50) NOT NULL,
SENHA INT  NOT NULL,
PRIMARY KEY (ID_COD_MOT)
);
go
/*PASSAGEIRO*/
CREATE TABLE PASSAGEIRO(
ID_COD_PAS INTEGER identity,
NOME_PAS VARCHAR(30) NOT NULL,
CPF VARCHAR(15) NOT NULL,
ENDERECO VARCHAR(30) NOT NULL,
TELEFONE_PAS VARCHAR(15) NOT NULL,
EMAIL_PAS VARCHAR (50) NOT NULL UNIQUE,
SENHA INT  NOT NULL,
PRIMARY KEY (ID_COD_PAS)
);
go
CREATE TABLE CARTAO(
ID_COD_CAR INTEGER identity,
ID_COD_PAS int not null,
NOME_PAS VARCHAR(30) NOT NULL,
VALIDADE_CARTAO DATETIME,
FOREIGN KEY (ID_COD_PAS) REFERENCES PASSAGEIRO (ID_COD_PAS),
PRIMARY KEY (ID_COD_CAR)
);
go


/*CATRACA*/
CREATE TABLE CATRACA(
ID_COD_CATRACA INTEGER identity,
PRIMARY KEY (ID_COD_CATRACA),
ID_COD_CAR INTEGER,
FOREIGN KEY (ID_COD_CAR) REFERENCES CARTAO (ID_COD_CAR)
);
go

/*�NIBUS*/
CREATE TABLE ONIBUS(
ID_COD_ONI INTEGER identity,
PLACA_ONIBUS VARCHAR(10) NOT NULL,
ROTA VARCHAR(40),
DATA_MANUTENCAO DATETIME,
ID_COD_CATRACA INTEGER not null,
ID_COD_CAR INTEGER not null,
ID_COD_MOT INT,
FOREIGN KEY (ID_COD_MOT) REFERENCES MOTORISTA (ID_COD_MOT),
FOREIGN KEY (ID_COD_CATRACA) REFERENCES CATRACA (ID_COD_CATRACA),
FOREIGN KEY (ID_COD_CAR) REFERENCES CARTAO (ID_COD_CAR),
PRIMARY KEY (ID_COD_ONI)
);
go

insert into GERENTE (NOME_GERENTE,EMAIL,TELEFONE_GER,SENHA) values ('Jhonathan', 'admin', '77960178950', 123)
go


select *from GERENTE
go

drop database DB_TRANSPORTADORA


use db_2ANO


