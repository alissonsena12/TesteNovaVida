create database TesteTecnico

go

use TesteTecnico

go

create table Professores (
	Id int primary key identity,
	Nome varchar(200) unique
)

create table Alunos (
	Id int primary key identity,
	Nome varchar(200),
	Valor decimal(18,2),
	DataVencimento datetime,
	IdProfessor int,
	FOREIGN KEY (IdProfessor) REFERENCES Professores(Id)
)

