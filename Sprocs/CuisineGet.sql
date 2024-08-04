create or alter procedure dbo.CuisineGet(@CuisineId int = 0, @All bit = 0, @CuisineType varchar(25) = '')
as 
begin
	select @CuisineType = nullif(@CuisineType, '')

	select c.CuisineId, c.CuisineType
	from Cuisine c
	where c.CuisineId = @CuisineId
	or @All = 1
	or c.CuisineType like '%' + @CuisineType + '%'
	order by c.CuisineType
end
go

/*
exec CuisineGet

exec CuisineGet @All = 1

exec CuisineGet @CuisineType = '' --return no results
exec CuisineGet @CuisineType = 'a'

declare @id int
select top 1 @id = c.CuisineId from Cuisine c
exec CuisineGet @CuisineId = @id
*/