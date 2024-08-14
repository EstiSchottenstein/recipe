create or alter function dbo.MealCalories(@MealId int)
returns varchar(250)
as
begin 
	declare @value varchar(250) = ''

	select @value = concat(m.MealName, ': Total Calories = ', sum(r.Calories)) 
	from Meal m
	join MealCourse mc 
	on m.MealId = mc.MealId
	join MealCourseRecipe mr
	on mc.MealCourseId = mr.MealCourseId
	join Recipe r 
	on mr.RecipeId = r.RecipeId 
	where m.MealId = @MealId
	group by m.MealName

	return @value
end
go

select MealCalories = dbo.MealCalories(m.MealId), m.* 
from Meal m