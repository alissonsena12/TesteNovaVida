create procedure prAlunos_Insert(
	@ListaAlunos    ListaAlunos readonly,
	@Tipo			varchar(10)				= 'UNICO',
	@Nome			varchar(200)			= null,
	@Valor			decimal(18,2)			= null,
	@DataVencimento datetime				= null,
	@IdProfessor	int						= null
)
as
begin
	if @Tipo = 'UNICO'
	begin
		insert into Alunos values(@Nome, @Valor, @DataVencimento, @IdProfessor)
	end
	if @Tipo = 'LOTE'
	begin
		insert into Alunos
		select * from @ListaAlunos	
	end
end
