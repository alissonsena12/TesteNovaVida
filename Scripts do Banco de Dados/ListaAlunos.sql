create type ListaAlunos as table(
	Nome			varchar(200),
	Valor			decimal(18,2),
	DataVencimento	datetime,
	IdProfessor		int

)
