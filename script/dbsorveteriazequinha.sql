create database dbsorveteriazequinha;
use dbsorveteriazequinha;

CREATE TABLE tbUsuarios(
codUsu int not null auto_increment,
nome varchar(50) not null,
senha varchar(12) not null,
primary key(codUsu));

insert into tbusuarios(nome,senha)
	values('etecia','etecia');
insert into tbusuarios(nome,senha)
	values('admin','admin');
insert into tbusuarios(nome,senha)
	values('lula','lula');


select * from tbusuarios where nome = 'etecia' and senha = 'etecia';