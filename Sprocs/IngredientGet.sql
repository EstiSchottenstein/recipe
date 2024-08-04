create or alter procedure dbo.IngredientGet(@IngredientId int = 0, @All bit = 0, @IngredientName varchar(100) = '')
as 
begin
	select @IngredientName = nullif(@IngredientName, '')

	select i.IngredientId, i.IngredientName, i.IngredientPicture
	from Ingredient i
	where i.IngredientId = @IngredientId
	or @All = 1
	or i.IngredientName like '%' + @IngredientName + '%'
	order by i.IngredientName
end
go

/*
exec IngredientGet

exec IngredientGet @All = 1

exec IngredientGet @IngredientName = '' --return no results
exec IngredientGet @IngredientName = 'l'

declare @id int
select top 1 @id = i.IngredientId from Ingredient i
exec IngredientGet @IngredientId = @id
*/