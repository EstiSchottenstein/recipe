create or alter procedure dbo.CookbookGet(@CookbookId int = 0, @All bit = 0, @CookbookName varchar(100) = '')
as 
begin
	select @CookbookName = nullif(@CookbookName, '')

	select c.CookbookId, c.UsersId, c.CookbookName, c.DateCreated, c.Price, c.CookbookActive, c.CookbookPicture
	from Cookbook c
	where c.CookbookId = @cookbookId
	or @All = 1
	or c.CookbookName like '%' + @CookbookName + '%'
	order by c.UsersId, c.CookbookActive, c.DateCreated, c.Price, c.CookbookName
end
go

/*
exec CookbookGet

exec CookbookGet @All = 1

exec CookbookGet @CookbookName = '' --return no results
exec CookbookGet @CookbookName = 'a'

declare @id int
select top 1 @id = c.CookbookId from Cookbook c
exec CookbookGet @CookbookId = @id
*/
create or alter procedure dbo.CourseGet(@CourseId int = 0, @All bit = 0, @CourseName varchar(25) = '')
as 
begin
	select @CourseName = nullif(@CourseName, '')

	select c.CourseId, c.CourseName, c.CourseSequence
	from Course c
	where c.CourseId = @CourseId
	or @All = 1
	or c.CourseName like '%' + @CourseName + '%'
	order by c.CourseSequence
end
go

/*
exec CourseGet

exec CourseGet @All = 1

exec CourseGet @CourseName = '' --return no results
exec CourseGet @CourseName = 'a'

declare @id int
select top 1 @id = c.CourseId from Course c
exec CourseGet @CourseId = @id
*/
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
create or alter procedure dbo.MealGet(@MealId int = 0, @All bit = 0, @MealName varchar(100) = '')
as 
begin
	select @MealName = nullif(@MealName, '')

	select  m.MealActive, m.UsersId, m.MealName, m.DateCreated, m.MealActive, m.MealPicture
	from Meal m
	where m.MealId = @MealId
	or @All = 1
	or m.MealName like '%' + @MealName + '%'
	order by m.UsersId, m.MealActive, m.DateCreated, m.MealName
end
go

/*
exec MealGet

exec MealGet @All = 1

exec MealGet @MealName = '' --return no results
exec MealGet @MealName = 'a'

declare @id int
select top 1 @id = m.MealId from Meal m
exec MealGet @MealId = @id
*/