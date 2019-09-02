/*DDL*/

Create Database M_InLock;

Use M_InLock;

Create Table Usuarios
(
	UsuarioId	int primary key Identity
	, Email		varchar(255) not null unique
	, Senha		varchar(40) not null
	, Permissao	varchar(14) not null
);

Create Table Estudios
(
	EstudioId		int primary key Identity 
	, NomeEstudio	Varchar(255) not null unique
	, PaisOrigem	varchar(255)
	, DataCriacao	Date
	, UsuarioId		int foreign key references Usuarios
);

Create Table Jogos
(
	JogoId			int primary key Identity
	,NomeJogo		varchar(255) not null unique
	,Descricao		text
	,DataLancamento	Date
	,Valor			float
	,EstudioId		int foreign key references Estudios not null
);
