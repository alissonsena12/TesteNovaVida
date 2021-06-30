create procedure prProfessores_Insert(
	@Nome varchar(200)
)
as
begin
	if exists (select * from Professores where Nome like '%'+ @Nome+ '%')
	begin
		select cast(0 as bit) Cadastrado
		return
	end
	else
	begin
		insert into Professores values (@Nome)
		select cast(1 as bit) Cadastrado
		return
	end
end


