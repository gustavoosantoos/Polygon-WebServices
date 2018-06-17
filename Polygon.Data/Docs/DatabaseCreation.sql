create database if not exists PolygonPontoOnline;
use PolygonPontoOnline;
create table if not exists Funcionarios(
	Matricula int primary key not null,
    Senha varchar(1024) not null,
    Administrador boolean default false not null,
    Ativo boolean default true not null
);

create table if not exists Registros(
	IdRegistro int auto_increment primary key,
    MatriculaFuncionario int not null,
    DataHora datetime not null default now(),
    Latitude float not null,
    Longitude float not null
);

alter table Registros add foreign key (MatriculaFuncionario) references Funcionarios(Matricula);