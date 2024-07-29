-- SM Excellent! See comment.
use HeartyHearthDB
go
--Note: some of these scripts are needed for specific items, when the instructions say "specific" pick one item in your data and specify it in the where clause using a unique value that identifies it, do not use the primary key.
--1) Sometimes when a staff member is fired. We need to eradicate everything from that user in our system. Write the SQL to delete a specific user and all the user's related records.
delete cr 
--select *
from CookbookRecipe cr
join Cookbook c 
on cr.CookbookId = c.CookbookId
join Recipe r 
on cr.RecipeId = r.RecipeId 
join Users u 
on c.UsersId = u.UsersId
or r.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete c
--select *
from Cookbook c 
join Users u 
on c.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete mr
--select *
from MealCourseRecipe mr
join MealCourse mc 
on mr.MealCourseId = mc.MealCourseId
join Meal m 
on mc.MealId = m.MealId 
join Recipe r 
on mr.RecipeId = r.RecipeId
join Users u 
on m.UsersId = u.UsersId 
or r.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete mc 
--select *
from MealCourse mc 
join Meal m 
on mc.MealId = m.MealId 
join Users u 
on m.UsersId = u.UsersId 
where u.UserName = 'A.Cook'

delete m
--select * 
from Meal m 
join Users u 
on m.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete d
--select *
from Direction d 
join Recipe r 
on d.RecipeId = r.RecipeId 
join Users u 
on r.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete ri
--select * 
from RecipeIngredient ri 
join Recipe r 
on ri.RecipeId = r.RecipeId 
join Users u 
on r.UsersId = u.UsersId 
where u.UserName = 'A.Cook'

delete r
--select * 
from Recipe r 
join Users u 
on r.UsersId = u.UsersId
where u.UserName = 'A.Cook'

delete u 
from Users u 
where u.UserName = 'A.Cook'

--2) Sometimes we want to clone a recipe as a starting point and then edit it. For example we have a complex recipe (steps and ingredients) and want to make a modified version. Write the SQL that clones a specific recipe, add " - clone" to its name.
insert Recipe(UsersId, CuisineId, RecipeName, Calories, DateDraft, DatePublished, DateArchived)
select r.UsersId, r.CuisineId, RecipeName = concat(r.RecipeName,' - clone'), r.Calories, r.DateDraft, r.DatePublished, r.DateArchived
from Recipe r 
where r.RecipeName = 'Chocolate Covered Popcorn'

;
with x as (
	select RecipeName = concat(r.RecipeName, ' - clone'), ri.RecipeIngredientId
	from Recipe r 
	join RecipeIngredient ri 
	on r.RecipeId = ri.RecipeId
	where r.RecipeName = 'Chocolate Covered Popcorn'
)
insert RecipeIngredient(RecipeId, IngredientId, Amount, MeasurementTypeId, IngredientSequence)
select r.RecipeId, ri.IngredientId, ri.Amount, ri.MeasurementTypeId, ri.IngredientSequence
from x 
join Recipe r 
on x.RecipeName = r.RecipeName
join RecipeIngredient ri 
on x.RecipeIngredientId = ri.RecipeIngredientId

;
with x as (
	select RecipeName = concat(r.RecipeName, ' - clone'), d.DirectionId
	from Recipe r 
	join Direction d 
	on r.RecipeId = d.RecipeId
	where r.RecipeName = 'Chocolate Covered Popcorn'
)
insert Direction(RecipeId, StepNumber, Directions)
select r.RecipeId, d.StepNumber, d.Directions
from x 
join Recipe r 
on x.RecipeName = r.RecipeName
join Direction d 
on x.DirectionId = d.DirectionId

/*
3) We offer users an option to auto-create a recipe book containing all of their recipes. 
Write a SQL script that creates the book for a specific user and fills it with their recipes.
The name of the book should be Recipes by Firstname Lastname. 
The price should be the number of recipes multiplied by $1.33
Sequence the book by recipe name.

Tip: To get a unique sequential number for each row in the result set use the ROW_NUMBER() function. See Microsoft Docs.
	 The following can be a column in your select statement: Sequence = ROW_NUMBER() over (order by colum name) , replace column name with the name of the column that the row number should be sorted
*/
insert Cookbook(UsersId, CookbookName, DateCreated, Price, CookbookActive)
select u.UsersId, concat('Recipes by ', u.FirstName, ' ', u.LastName), getdate(), count(r.UsersId) * 1.33, 1 
from Users u 
join Recipe r 
on u.UsersId = r.UsersId
where u.UserName = 'J.Foodie'
group by u.UsersId, u.FirstName, u.LastName

-- SM Why do you need distinct?
;
with x as (
	select CookbookName = concat('Recipes by ', u.FirstName, ' ', u.LastName), r.RecipeName
	from Users u 
	join Recipe r 
	on u.UsersId = r.UsersId
	where u.UserName = 'J.Foodie'
)
insert CookbookRecipe(CookbookId, RecipeId, RecipeSequence)
select c.CookbookId, r.RecipeId, row_number() over (order by r.RecipeName)
from x 
join Cookbook c 
on x.CookbookName = c.CookbookName 
join Recipe r 
on x.RecipeName = r.RecipeName

/*
4) Sometimes the calorie count of of an ingredient changes and we need to change the calorie total for all recipes that use that ingredient.
Our staff nutritionist will specify the amount to change per measurement type, and of course multiply the amount by the quantity of the ingredient.
For example, the calorie count for butter went down by 2 per ounce, and 10 per stick of butter. 
Write an update statement that changes the number of calories of a recipe for a specific ingredient. 
The statement should include at least two measurement types, like the example above. 
*/
update r 
set Calories = 
--select r.Calories, UpdatedCalories = 
    case m.MeasurementTypeName
        when 'stick' then r.Calories - ri.Amount * 10 
        when 'oz' then r.Calories - ri.Amount * 2 
    end
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Ingredient i 
on ri.IngredientId = i.IngredientId 
join MeasurementType m 
on ri.MeasurementTypeId = m.MeasurementTypeId
where i.IngredientName = 'butter'

/*
5) We need to send out alerts to users that have recipes sitting in draft longer the average amount of time that recipes have taken to be published.
Produce a result set that has 4 columns (Data values in brackets should be replaced with actual data)
	User First Name, 
	User Last Name, 
	email address (first initial + lastname@heartyhearth.com),
	Alert: 
		Your recipe [recipe name] is sitting in draft for [X] hours.
		That is [Z] hours more than the average [Y] hours all other recipes took to be published.
*/
;
with x as (
    select TotalAvgHoursInDraft = avg(datediff(hour,r.DateDraft,r.DatePublished))
    from Recipe r 
)
select u.FirstName, u.LastName, EmailAddress = concat(lower(substring(u.FirstName,1,1)), lower(u.LastName), '@heartyhearth.com'),
Alert = 
concat(
'Your recipe ', r.RecipeName, ' is sitting in draft for ', datediff(hour,r.DateDraft,getdate()), ' hours. 
That is ',datediff(hour,r.DateDraft,getdate()) - x.TotalAvgHoursInDraft,' hours more than the average ', x.TotalAvgHoursInDraft, ' hours all other recipes took to be published.'
)
from x
cross join Recipe r 
join Users u 
on r.UsersId = u.UsersId
where r.CurrentStatus = 'Draft' 
and datediff(hour,r.DateDraft,getdate()) > x.TotalAvgHoursInDraft
   
/*
6) We want to send out marketing emails for books. Produce a result set with one row and one column "Email Body" as specified below.
The email should have a unique guid link to follow, which should be shown in the format specified. 

Email Body:
Order cookbooks from HeartyHearth.com! We have [X] books for sale, average price is [Y]. You can order them all and receive a 25% discount, for a total of [Z].
Click <a href = "www.heartyhearth.com/order/[GUID]">here</a> to order.
*/
select EmailBody = concat(
'Order cookbooks from HeartyHearth.com! 
We have ', count(c.CookbookId), ' books for sale, average price is ', convert(decimal(7,2),avg(c.Price)), 
'. You can order them all and receive a 25% discount, for a total of ', convert(decimal(10,2),(sum(c.Price)*.75)), 
'. Click <a href = "www.heartyhearth.com/order/',newid(),'">here</a> to order.'
)
from Cookbook c 