--DQL--

Use M_InLock;

select * from Usuarios
select * from Estudios
select * from Jogos


select Jogos.JogoId, Jogos.NomeJogo, Jogos.Descricao, Jogos.DataLancamento, Jogos.Valor, Estudios.NomeEstudio
from Jogos
join Estudios
on Jogos.EstudioId = Estudios.EstudioId

select Estudios.NomeEstudio, Jogos.NomeJogo
from Estudios
full join Jogos
on Estudios.EstudioId = Jogos.EstudioId

select * from Jogos
where JogoId = 1

select  UsuarioId, Email, Permissao from Usuarios
where Email = 'cliente@cliente.com' and Senha = 'cliente'

