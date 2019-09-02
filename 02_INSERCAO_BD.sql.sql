Use M_InLock;

insert into Usuarios (Email, Senha, Permissao)
values	('admin@admin.com', 'admin',	'ADMINISTRADOR'),
		('cliente@cliente', 'cliente',	'CLIENTE')
;

select * from Usuarios;

insert into Estudios (NomeEstudio, PaisOrigem, DataCriacao, UsuarioId)
values	('Blizzard',			'Inglaterra',		'2009-10-12', 1)
		,('Rockstar Studio',	'Estados Unidos',	'2015-11-01', 1)
		,('Square Enix',		'India',			'2018-02-10', 1);
select * from Estudios;

insert into Jogos (NomeJogo, Descricao, DataLancamento, Valor, EstudioId)
values	('Diablo 3',				'É um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '2012-05-15', 99.00,  1)
		,('Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western',										 '2018-10-26', 120.00, 2)
;
select * from Jogos;