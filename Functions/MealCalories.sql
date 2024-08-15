create or alter function dbo.MealCalories(@MealId int)
returns int
as
begin 
	declare @value int = 0

	select @value = sum(r.Calories)
	from MealCourse mc 
	join MealCourseRecipe mr
	on mc.MealCourseId = mr.MealCourseId
	join Recipe r 
	on mr.RecipeId = r.RecipeId 
	where mc.MealId = @MealId

	return @value
end
go

select MealCalories = dbo.MealCalories(m.MealId), m.* 
from Meal m