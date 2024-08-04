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