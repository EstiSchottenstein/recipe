-- SM Excellent! Really nice work! 100%
use HeartyHearthDB
go 
/*
Our website development is underway! 
Below is the layout of the pages on our website, please provide the SQL to produce the necessary result sets.

Note: 
a) When the word 'specific' is used, pick one record (of the appropriate type, recipe, meal, etc.) for the query. 
    The way the website works is that a list of items are displayed and then the user picks one and navigates to the "details" page.
b) Whenever you have a record for a specific item include the name of the picture for that item. That is because the website will always show a picture of the item.
*/

/*
Home Page
    One result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
*/
select ItemName = 'Recipes', TotalCount = count(r.RecipeId) from Recipe r
union select 'Meals', count(m.MealId) from Meal m 
union select 'Cookbooks', count(cb.CookbookId) from Cookbook cb
order by ItemName desc

/*
Recipe list page:
    List of all Recipes that are either published or archived, published recipes should appear at the top. 
	Archived recipes should appear gray. Surround the archived recipe with <span style="color:gray">recipe name</span>
    In the resultset show the Recipe with its status, dates it was published and archived in mm/dd/yyyy format (blank if not archived), user, number of calories and number of ingredients.
    Tip: You'll need to use the convert function for the dates
*/
select r.RecipeId, 
RecipeName = 
case r.CurrentStatus
    when 'Archive' then concat('<span style="color:gray">',r.RecipeName,'</span>') 
    else r.RecipeName 
end, 
r.CurrentStatus, 
DatePublished = isnull(convert(varchar,r.DatePublished,101),''), DateArchived = isnull(convert(varchar,r.DateArchived,101),''), 
r.UsersId, r.Calories, NumIngredients = count(ri.RecipeIngredientId)
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
where r.CurrentStatus in ('Published','Archive')
group by r.RecipeId, r.RecipeName, r.CurrentStatus, r.DatePublished, DateArchived, r.UsersId, r.Calories
order by r.CurrentStatus desc 

/*
Recipe details page:
    Show for a specific recipe (three result sets):
        a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
        b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
        c) List of prep steps sorted by sequence.
*/
--a) Recipe header: recipe name, number of calories, number of ingredients and number of steps.
select r.RecipeName, r.Calories, NumIngredients = count(distinct ri.RecipeIngredientId)
, NumSteps = count(distinct d.DirectionId), r.RecipePicture
from Recipe r 
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Direction d
on r.RecipeId = d.RecipeId
where r.RecipeName = 'Grilled Chicken'
group by r.RecipeName, r.Calories, r.RecipePicture

--b) List of ingredients: show the measurement quantity, measurement type and ingredient in one column, sorted by sequence. Ex. 1 Teaspoon Salt  
select IngredientList = concat(ri.Amount, ' ', mt.MeasurementTypeName, ' ', i.IngredientName), i.IngredientPicture
from RecipeIngredient ri 
join Ingredient i 
on ri.IngredientId = i.IngredientId
join Recipe r 
on ri.RecipeId = r.RecipeId
left join MeasurementType mt 
on ri.MeasurementTypeId = mt.MeasurementTypeId
where r.RecipeName = 'Grilled Chicken'
order by ri.IngredientSequence

--c) List of prep steps sorted by sequence.
select d.Directions
from Direction d 
join Recipe r 
on d.RecipeId = r.RecipeId
where r.RecipeName = 'Grilled Chicken'
order by d.StepNumber

/*
Meal list page:
    For all active meals, show the meal name, user that created the meal, number of calories for the meal, number of courses, and number of recipes per each meal, sorted by name of meal
*/
select m.MealName, u.UserName, TotalCalories = sum(r.Calories), NumCourses = count(distinct mc.MealCourseId), NumRecipes = count(distinct mr.MealCourseRecipeId)
from Meal m
join Users u 
on m.UsersId = u.UsersId
join MealCourse mc 
on m.MealId = mc.MealId
join MealCourseRecipe mr
on mc.MealCourseId = mr.MealCourseId 
join Recipe r 
on mr.RecipeId = r.RecipeId
where m.MealActive = 1 
group by m.MealName, u.UserName
order by m.MealName

/*
Meal details page:
    Show for a specific meal:
        a) Meal header: meal name, user, date created.
        b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
			Format for main course: CourseType: Main/Side dish - Recipe Name. 
            Format for non-main course: CourseType: Recipe Name
            Main dishes of the main course should be bold, using the bold tags as shown below
                ex: 
                    Appetizer: Mixed Greens
                    <b>Main: Main dish - Onion Pastrami Chicken</b>
					Main: Side dish - Roasted cucumbers with mustard
*/
--a) Meal header: meal name, user, date created.
select m.MealName, u.UserName, m.DateCreated, m.MealPicture
from Meal m
join Users u 
on m.UsersId = u.UsersId
where m.MealName = 'Supper Supreme'

--b) List of all recipes: Result set should have one column, including the course type, whether the dish is serverd as main/side (if it's the main course), and recipe name. 
select MealRecipes = 
case 
    when c.CourseName = 'Main' then 
        case 
            when mr.Main = 0 then concat(c.CourseName, ': ', 'Side Dish - ', r.RecipeName) 
            else concat('<b>',c.CourseName, ': ', 'Main Dish - ', r.RecipeName, '</b>') 
        end
    else concat(c.CourseName, ': ', r.RecipeName) 
end
from MealCourseRecipe mr 
join MealCourse mc 
on mr.MealCourseId = mc.MealCourseId
join Recipe r 
on mr.RecipeId = r.RecipeId 
join Course c 
on mc.CourseId = c.CourseId
join Meal m 
on mc.MealId = m.MealId
where m.MealName = 'Supper Supreme'
order by c.CourseSequence

/*
Cookbook list page:
    Show all active cookbooks with author and number of recipes per book. Sorted by book name.
*/
select c.CookbookName, u.FirstName, u.LastName, NumRecipes = count(cr.RecipeId)
from Cookbook c
join Users u 
on c.UsersId = u.UsersId 
join CookbookRecipe cr 
on c.CookbookId = cr.CookbookId
where c.CookbookActive = 1 
group by c.CookbookName, u.FirstName, u.LastName
order by c.CookbookName

/*
Cookbook details page:
    Show for specific cookbook:
    a) Cookbook header: cookbook name, user, date created, price, number of recipes.
    b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
        Note: User will click on recipe to see all ingredients and steps.
*/
--a) Cookbook header: cookbook name, user, date created, price, number of recipes.
select c.CookbookName, u.UserName, c.DateCreated, c.Price, NumRecipes = count(cr.RecipeId), c.CookbookPicture
from Cookbook c
join Users u 
on c.UsersId = u.UsersId 
join CookbookRecipe cr 
on c.CookbookId = cr.CookbookId
where c.CookbookName = 'Set My Table'
group by c.CookbookName, u.UserName, c.DateCreated, c.Price, c.CookbookPicture
order by c.CookbookName

--b) List of all recipes in the correct order. Include recipe name, cuisine and number of ingredients and steps.  
select cr.RecipeSequence, r.RecipeName, c.CuisineType, NumIngredients = count(distinct ri.RecipeIngredientId), NumSteps = count(distinct d.DirectionId)
from CookbookRecipe cr
join Recipe r
on cr.RecipeId = r.RecipeId
join Cookbook cb 
on cr.CookbookId = cb.CookbookId
join Cuisine c 
on c.CuisineId = r.CuisineId
join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId
join Direction d 
on d.RecipeId = ri.RecipeId
where cb.CookbookName = 'Set My Table'
group by cr.RecipeSequence, r.RecipeName, c.CuisineType
order by cr.RecipeSequence

/*
April Fools Page:
    On April 1st we have a page with a joke cookbook. For that page provide the following.
    a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
        There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
        Note: ".jpg" file extension must be at the end of the reversed picture name EX: Recipe_Seikooc_pihc_etalocohc.jpg
    b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
        Hint: Use CTE
*/
--a) A list of all the recipes that are in all cookbooks. The recipe name should be the reverse of the real name with the first letter capitalized and all others lower case.
--There are matching pictures for those names, include the reversed picture names so that we can show the joke pictures.
select 
c.CookbookName, 
RecipeName = concat(upper(substring(reverse(r.RecipeName),1,1)), substring(lower(reverse(r.RecipeName)),2,len(r.RecipeName))),
RecipePicture = replace(concat('Recipe_', upper(substring(reverse(r.RecipeName),1,1)), substring(lower(reverse(r.RecipeName)),2,len(r.RecipeName)), '.jpg'),' ','_')
from CookbookRecipe cr 
join Cookbook c 
on cr.CookbookId = c.CookbookId 
join Recipe r 
on cr.RecipeId = r.RecipeId 
order by c.CookbookName

--b) When the user clicks on any recipe they should see a spoof steps lists showing the step instructions for the LAST step of EACH recipe in the system. No sequence required.
;
with x as (
    select d.RecipeId, StepNumber = max(d.StepNumber)
    from Direction d
    group by d.RecipeId
)
select Directions = d.Directions
from x 
join Direction d 
on x.StepNumber = d.StepNumber
and x.RecipeId = d.RecipeId

/*
For site administration page:
5 seperate reports
    a) List of how many recipes each user created per status. Show 0 if user has no recipes at all. 
    b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
    c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
        Hint: For active/inactive columns, use SUM function with CASE to only include in sum if active/inactive 
    e) List of archived recipes that were never published, and how long it took for them to be archived.
*/
--a) List of how many recipes each user created per status. Show 0 if user has no recipes at all. 
select u.UserName, CurrentStatus = isnull(r.CurrentStatus,'N/A'), NumRecipes = count(r.UsersId)
from Users u 
left join Recipe r 
on u.UsersId = r.UsersId 
group by u.UserName, r.CurrentStatus
order by u.UserName

--b) List of how many recipes each user created and average amount of days that it took for the user's recipes to be published.
select u.UserName, NumRecipes = count(r.UsersId), AvgDaysToPublish = isnull(avg(datediff(day, r.DateDraft, r.DatePublished)),0)
from Users u 
left join Recipe r 
on u.UsersId = r.UsersId 
group by u.UserName

--c) For each user, show three columns: Total number of meals, Total Active meals, Total Inactive meals. Show 0 if none
select u.UserName, TotalMeals = count(m.UsersId)
, TotalActiveMeals = sum(
    case m.MealActive 
        when 1 then 1
        else 0
    end 
)
, TotalInactiveMeals = sum(
    case m.MealActive 
        when 0 then 1
        else 0
    end
)
from Users u 
left join Meal m 
on u.UsersId = m.UsersId 
group by u.UserName

--d) For each user, show three columns: Total number of cookbooks, Total Active cookbooks, Total Inactive cookbooks. Show 0 if none
select u.UserName, TotalCookbooks = count(c.UsersId)
, TotalActiveCookbooks = sum(
    case c.CookbookActive
        when 1 then 1
        else 0
    end 
)
, TotalInactiveCookbooks = sum(
    case c.CookbookActive 
        when 0 then 1
        else 0
    end
)
from Users u 
left join Cookbook c
on u.UsersId = c.UsersId 
group by u.UserName

--e) List of archived recipes that were never published, and how long it took for them to be archived.
select r.RecipeName, DaysFromDraftToArchive = datediff(day,r.DateDraft,r.DateArchived)
from Recipe r
where r.CurrentStatus = 'Archive' and r.DatePublished is null

/*
For user dashboard page:
    a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
        Tip: If you would like, you can use a CTE to get the User Id once instead of in each union select
    b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
    
    OPTIONAL CHALLENGE QUESTION
    c) Show a list of cuisines and the count of recipes the user has per cuisine, 0 if none
        Hint: Start by writing a CTE to give you cuisines for which the user does have recipes. 
*/
--a) For a specific user, show one result set with the number of recipes, meals, and cookbooks. Each row should have a column with the item name (Ex: Recipes) and a column with the count.
select ItemName = 'Recipes', TotalCount = count(r.RecipeId) 
from Recipe r 
join Users u 
on r.UsersId = u.UsersId 
where u.UserName = 'A.Cook'
union select 'Meals', count(m.MealId) 
from Meal m 
join Users u 
on m.UsersId = u.UsersId 
where u.UserName = 'A.Cook'
union select 'Cookbooks', count(cb.CookbookId) 
from Cookbook cb 
join Users u 
on cb.UsersId = u.UsersId 
where u.UserName = 'A.Cook'
order by ItemName desc

--b) List of the user's recipes, display the status and the number of hours between the status it's in and the one before that. Omit recipes in drafted status.
select r.RecipeName, r.CurrentStatus, 
HoursFromLastStatus = 
case r.CurrentStatus 
    when 'Published' then datediff(hour,r.DateDraft,r.DatePublished) 
    when 'Archive' then 
    case 
        when r.DatePublished is null then datediff(hour,r.DateDraft,r.DateArchived)
        else datediff(hour,r.DatePublished,r.DateArchived)
    end
end
from Users u 
join Recipe r 
on u.UsersId = r.UsersId
where u.UserName = 'A.Cook'
and r.CurrentStatus <> 'Draft'