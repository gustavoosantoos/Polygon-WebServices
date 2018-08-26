create database if not exists PolygonPontoOnline;

use PolygonPontoOnline;

create table if not exists funcionarios(
	Matricula int primary key not null,
    Senha varchar(1024) not null,
    Administrador boolean default false not null,
    Ativo boolean default true not null
);

create table if not exists registros(
	IdRegistro int auto_increment primary key,
    MatriculaFuncionario int not null,
    DataHora datetime not null default now(),
    Latitude float not null,
    Longitude float not null
);

alter table registros add foreign key (MatriculaFuncionario) references Funcionarios(Matricula);

insert into funcionarios values (1, '05121995!Gu', 1, 1);
insert into registros values (21, 1, '2018-06-19 20:02:30', -25.4449, -49.3588);
insert into registros values (22, 1, '2018-06-19 20:02:30', -25.4449, -49.3588);