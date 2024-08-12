set nocount on 

declare @recipeid int 

--script to find recipe with recipe status draft or archived for over 30 days
/*
select  @recipeid = r.RecipeId
from Recipe r 
left join CookbookRecipe cr on cr.recipeid = r.recipeid 
left join MealCourseRecipe mcr on mcr.recipeid = r.recipeid 
where r.CurrentStatus = 'draft' or (r.CurrentStatus = 'archive' and datediff(day, r.DateArchived, CURRENT_TIMESTAMP) > 30)
and cr.cookbookrecipeid is null and mcr.mealcourserecipeid is null 
order by r.RecipeId
*/

--script to find recipe with recipe status published or archived for under 30 days
/*
select  @recipeid = r.RecipeId
from Recipe r 
left join CookbookRecipe cr on cr.recipeid = r.recipeid 
left join MealCourseRecipe mcr on mcr.recipeid = r.recipeid 
where r.CurrentStatus = 'published' or (r.CurrentStatus = 'archive' and datediff(day, r.DateArchived, CURRENT_TIMESTAMP) < 30)
and cr.cookbookrecipeid is null and mcr.mealcourserecipeid is null 
order by r.RecipeId
*/

select 'recipe', r.RecipeId, r.RecipeName from Recipe r where r.RecipeId = @recipeid
union select 'recipeingredient', ri.RecipeIngredientId, i.IngredientName from RecipeIngredient ri join Ingredient i on ri.IngredientId = i.IngredientId where ri.RecipeId = @recipeid
union select 'direction', d.DirectionId, d.Directions from Direction d where d.RecipeId = @recipeid

declare @return int, @message varchar(500)
exec @return = RecipeDelete @RecipeId = @recipeid, @Message = @message output
select @return, @message
	
select 'recipe', r.RecipeId, r.RecipeName from Recipe r where r.RecipeId = @recipeid
union select 'recipeingredient', ri.RecipeIngredientId, i.IngredientName from RecipeIngredient ri join Ingredient i on ri.IngredientId = i.IngredientId where ri.RecipeId = @recipeid
union select 'direction', d.DirectionId, d.Directions from Direction d where d.RecipeId = @recipeid
