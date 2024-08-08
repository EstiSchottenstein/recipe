set nocount on 

declare @recipeid int 

select top 1 @recipeid = r.RecipeId
from Recipe r 
join RecipeIngredient ri 
on ri.RecipeId = r.RecipeId
join Direction d
on d.RecipeId = r.RecipeId
order by r.RecipeId

/*
--script to find recipe not in meal or cookbook

select top 1 @recipeid = r.recipeid               
from recipe r
left join CookbookRecipe cr on cr.recipeid = r.recipeid 
left join MealCourseRecipe mcr on mcr.recipeid = r.recipeid 
left join Direction d on d.recipeid = r.recipeid 
left join RecipeIngredient ri on ri.recipeid = r.recipeid 
where cr.cookbookrecipeid is null and mcr.mealcourserecipeid is null
*/

select 'recipe', r.RecipeId, r.RecipeName from Recipe r where r.RecipeId = @recipeid
union select 'recipeingredient', ri.RecipeIngredientId, i.IngredientName from RecipeIngredient ri join Ingredient i on ri.IngredientId = i.IngredientId where ri.RecipeId = @recipeid
union select 'direction', d.DirectionId, d.Directions from Direction d where d.RecipeId = @recipeid

exec RecipeDelete @RecipeId = @recipeid
	
select 'recipe', r.RecipeId, r.RecipeName from Recipe r where r.RecipeId = @recipeid
union select 'recipeingredient', ri.RecipeIngredientId, i.IngredientName from RecipeIngredient ri join Ingredient i on ri.IngredientId = i.IngredientId where ri.RecipeId = @recipeid
union select 'direction', d.DirectionId, d.Directions from Direction d where d.RecipeId = @recipeid
