create database dbsorveteriazequinha;
use dbsorveteriazequinha;

CREATE TABLE tbUsuarios(
codUsu int not null auto_increment,
nome varchar(50) not null,
senha varchar(12) not null,
primary key(codUsu));

create table tbfuncionarios(
codFunc int not null auto_increment,
nome varchar(100),
email varchar(100),
cpf char(14) unique,
funcao varchar(100),
telCel char(10),
cep char(9),
logradouro varchar(100),
numero char(10),
cidade varchar(100),
estado varchar(100),
uf char(2),
complemento varchar(30),
bairro varchar(100),
primary key(codFunc));

insert into tbfuncionarios(nome,email,cpf,funcao,telCel,
cep,logradouro,numero,cidade,estado,uf,
complemento,bairro)values();

insert into tbusuarios(nome,senha)
	values('etecia','etecia');
insert into tbusuarios(nome,senha)
	values('admin','admin');
insert into tbusuarios(nome,senha)
	values('lula','lula');


select * from tbusuarios where nome = 'etecia' and senha = 'etecia';