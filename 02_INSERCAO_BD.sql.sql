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
values	('Diablo 3',				'� um jogo que cont�m bastante a��o e � viciante, seja voc� um novato ou um f�', '2012-05-15', 99.00,  1)
		,('Red Dead Redemption II', 'Jogo eletr�nico de a��o-aventura western',										 '2018-10-26', 120.00, 2)
;
select * from Jogos;