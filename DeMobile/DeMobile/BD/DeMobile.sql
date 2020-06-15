create database web_demobile;
use web_demobile;

create table endereco
(
id_end int auto_increment primary key,
log_end varchar(100) not null,
num_end varchar(20) not null,
comp_end varchar(20) not null,
bair_end varchar(100) not null,
cid_end varchar(100) not null,
uf_end char(2) not null
);

create table cliente
(
id_cli int auto_increment primary key,
endereco int not null,
nom_cli varchar(100),
email_cli varchar(100),
des_numero_cli varchar(15),
stt_cli varchar(7),
FOREIGN KEY (endereco) REFERENCES endereco (id_end)
);

create table usuario(
id_usu		int			not null auto_increment,
nom_usu	varchar(50)		not null,
log_usu		varchar(10)		not null,
senha	text			not null,
nivel		char(1)			not null,
primary key(id_usu)
);

CREATE TABLE produto
(
id_prod int primary key auto_increment,
nom_prod varchar(100) not null,
des_nom_prod varchar(100) not null,
qtd_esto_prod int not null,
preco_unit_prod float not null,
stt_prod char(1)	not null
);


CREATE TABLE pedido
(
id_ped int primary key auto_increment,
produto int not null,
cliente int not null,
qtd_ped int not null,
valor_final_ped float not null,
stt_ped varchar(12),
FOREIGN KEY (produto) REFERENCES produto (id_prod),
FOREIGN KEY (cliente) REFERENCES cliente (id_cli)
);

