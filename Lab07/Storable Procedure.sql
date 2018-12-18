use EngineChemicals

-- По имени владельца получает имя его самой богатой компании
go 

drop procedure [sp_GetRichestCompany]

go

create procedure [dbo].[sp_GetRichestCompany]
	@ownerName nvarchar(100) = '%',
	@companyName nvarchar(100) output
as
	begin
		select @companyName = Companies.CompanyName
		from Companies
		where Companies.AnnualTurnover = 
		(
			select MAX(Companies.AnnualTurnover) 
			from Companies
			where Companies.CompanyOwnerPassport = 
			(
				select Owners.Passport
				from Owners
				where Owners.Passport = Companies.CompanyOwnerPassport
			)
		)
	end;

go

declare @result nvarchar(100)

exec dbo.sp_GetRichestCompany N'Куклушева Надежда Антоновна', @companyName = @result OUTPUT

select @result
