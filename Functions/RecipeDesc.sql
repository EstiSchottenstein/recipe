create or alter function dbo.RecipeDesc(@RecipeId int)
returns varchar(250)
as
begin 
	declare @value varchar(250) = ''

	select @value = concat(r.RecipeName, ' (', c.CuisineType, ') has ', count(distinct ri.RecipeIngredientId), ' ingredients and ', count(distinct d.DirectionId), ' steps.')
	from Recipe r 
	join Cuisine c 
	on c.CuisineId = r.CuisineId
	left join RecipeIngredient ri
	on ri.RecipeId = r.RecipeId
	left join Direction d 
	on d.RecipeId = r.RecipeId
	where r.RecipeId = @RecipeId
	group by r.RecipeName, c.CuisineType

	return @value
end
go


select RecipeDesc = dbo.RecipeDesc(r.RecipeId), r.* 
from Recipe r