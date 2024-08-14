create or alter procedure dbo.RecipeGet(@RecipeId int = 0, @All bit = 0, @RecipeName varchar(100) = '')
as 
begin
	select @RecipeName = nullif(@RecipeName, '')

	select r.RecipeId, r.UsersId, r.CuisineId, r.RecipeName, r.Calories, r.DateDraft, r.DatePublished, r.DateArchived, r.CurrentStatus, r.RecipePicture,
		RecipeDesc = dbo.RecipeDesc(r.RecipeId)
	from Recipe r
	where r.RecipeId = @RecipeId
	or @All = 1
	or r.RecipeName like '%' + @RecipeName + '%'
	order by r.UsersId, r.CuisineId, r.CurrentStatus, r.RecipeName
end
go


/*
exec RecipeGet
	 
exec RecipeGet @All = 1
	 
exec RecipeGet @RecipeName = '' --return no results
exec RecipeGet @RecipeName = 'm'

declare @id int
select top 1 @id = r.RecipeId from Recipe r
exec RecipeGet @RecipeId = @id
*/