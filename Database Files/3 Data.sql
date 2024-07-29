-- SM Excellent!
use HeartyHearthDB
go 

delete CookbookRecipe
delete Cookbook
delete MealCourseRecipe
delete MealCourse
delete Meal
delete Course
delete Direction
delete RecipeIngredient
delete Recipe
delete Users 
delete Cuisine
delete Ingredient
delete MeasurementType
go 

insert Users(FirstName, LastName, UserName)
select 'John', 'Foodie', 'J.Foodie'
union select 'Sally', 'Baker', 'S.Baker'
union select 'Lily', 'Cheffer', 'L.Cheffer'
union select 'Anne', 'Cook', 'A.Cook'
union select 'Sam', 'Taster', 'S.Taster'

insert Cuisine(CuisineType)
select 'American'
union select 'French'
union select 'English'
union select 'Japanese'
union select 'Russian'
union select 'Mexican'
union select 'Chinese'

insert Ingredient(IngredientName)
select 'sugar'
union select 'oil'
union select 'eggs' 
union select 'flour'
union select 'vanilla sugar'
union select 'baking powder'
union select 'baking soda' 
union select 'chocolate chips'
union select 'granny smith apples' 
union select 'vanilla yogurt' 
union select 'orange juice'
union select 'honey'
union select 'ice cubes'
union select 'club bread' 
union select 'butter'
union select 'shredded cheese' 
union select 'cloves garlic (crushed)'
union select 'black pepper' 
union select 'salt'
union select 'butter'
union select 'vanilla pudding'
union select 'whipped cream cheese'
union select 'sour cream cheese'
union select 'chiken cutlets' 
union select 'olive oil'
union select 'montreal steak seasoning' 
union select 'maple syrup' 
union select 'onion'
union select 'soy sauce'
union select 'cooked rice'
union select 'tomato'
union select 'white button mushrooms'
union select 'popcorn kernels'
union select 'white chocolate chips'

insert MeasurementType(MeasurementTypeName)
select 'cup'
union select 'tsp'
union select 'tbsp'
union select 'oz'
union select 'pinch'
union select 'stick'
union select 'lb'

;
with x as (
    select UserName = 'J.Foodie', CuisineType = 'American', RecipeName = 'Chocolate Chip Cookies', Calories = 100, DateDraft = '2020-1-28 12:00', DatePublished = '2020-2-15 1:00', DateArchived = null
    union select 'J.Foodie', 'American', 'Apple Yogurt Smoothie', 250, '2021-5-15 1:30', '2021-6-10 12:00', null
    union select 'A.Cook', 'French', 'Cheese Bread', 150, '2020-10-10 11:15', '2020-10-25 12:05', null
    union select 'A.Cook', 'English', 'Butter Muffins', 170, '2021-5-16 11:45', null, null
    union select 'L.Cheffer', 'American', 'Grilled Chicken', 170, '2022-6-10 11:10', '2022-7-1 10:30', null
    union select 'L.Cheffer', 'Chinese', 'Fried Rice', 150, '2023-1-13 9:30', '2023-1-25 10:40', null
    union select 'S.Baker', 'French', 'Sauteed Vegetable Omelette', 200, '2020-10-25 10:50', '2020-11-5 11:05', null
    union select 'S.Baker', 'American', 'Chocolate Covered Popcorn', 120, '2022-11-2 11:00', '2022-11-20 10:30', '2024-1-5 10:45'
    union select 'A.Cook', 'English', 'Cinnamon Muffins', 170, '2021-5-16 1:00', null, '2021-5-16 4:00'--test
    union select 'A.Cook', 'English', 'Mocha Muffins', 170, '2021-5-16 1:00', '2021-5-16 2:00', '2021-5-16 3:00'--test
    union select 'A.Cook', 'English', 'Oatmeal Muffins', 170, '2021-5-16 1:00', '2021-5-16 2:00', null --test
    union select 'S.Baker', 'American', 'Caramel Popcorn', 120, '2024-2-24 11:00', null, '2024-2-26 10:45' --test
)
insert Recipe(UsersId, CuisineId, RecipeName, Calories, DateDraft, DatePublished, DateArchived)
select u.UsersId, c.CuisineId, x.RecipeName, x.Calories, x.DateDraft, x.DatePublished, x.DateArchived
from x 
join Users u 
on x.UserName = u.UserName 
join Cuisine c 
on x.CuisineType = c.CuisineType 

;
with x as (
    select RecipeName = 'Chocolate Chip Cookies', IngredientName = 'sugar', Amount = 1, MeasurementTypeName = 'cup', IngredientSequence = 1 
    union select 'Chocolate Chip Cookies', 'oil', .5, 'cup', 2 
    union select 'Chocolate Chip Cookies', 'eggs', 3, null, 3
    union select 'Chocolate Chip Cookies', 'flour', 2, 'cup', 4
    union select 'Chocolate Chip Cookies', 'vanilla sugar', 1, 'tsp', 5
    union select 'Chocolate Chip Cookies', 'baking powder', 2, 'tsp', 6  
    union select 'Chocolate Chip Cookies', 'baking soda', .5, 'tsp', 7
    union select 'Chocolate Chip Cookies', 'chocolate chips', 1, 'cup', 8
    union select 'Apple Yogurt Smoothie', 'granny smith apples', 3, null, 1
    union select 'Apple Yogurt Smoothie', 'vanilla yogurt', 2, 'cup', 2
    union select 'Apple Yogurt Smoothie', 'sugar', 2, 'tsp', 3 
    union select 'Apple Yogurt Smoothie', 'orange juice', .5, 'cup', 4
    union select 'Apple Yogurt Smoothie', 'honey', 2, 'tbsp', 5
    union select 'Apple Yogurt Smoothie', 'ice cubes', 5.5, null, 6
    --union select 'Apple Yogurt Smoothie', 'ice cubes', '5-6', null, 6?
    union select 'Cheese Bread', 'club bread', 1, null, 1
    union select 'Cheese Bread', 'butter', 4, 'oz', 2 
    union select 'Cheese Bread', 'shredded cheese', 8, 'oz', 3
    union select 'Cheese Bread', 'cloves garlic (crushed)', 2, null, 4
    union select 'Cheese Bread', 'black pepper', .25, 'tsp', 5
    union select 'Cheese Bread', 'salt', 1, 'pinch', 6
    union select 'Butter Muffins', 'butter', 1, 'stick', 1
    union select 'Butter Muffins', 'sugar', 3, 'cup', 2
    union select 'Butter Muffins', 'vanilla pudding', 2, 'tbsp', 3
    union select 'Butter Muffins', 'eggs', 4, null, 4
    union select 'Butter Muffins', 'whipped cream cheese', 8, 'oz', 5
    union select 'Butter Muffins', 'sour cream cheese', 8, 'oz', 6
    union select 'Butter Muffins', 'flour', 1, 'cup', 7
    union select 'Butter Muffins', 'baking powder', 2, 'tsp', 8
    union select 'Grilled Chicken', 'chiken cutlets', 1, 'lb', 1 
    union select 'Grilled Chicken', 'olive oil', 2, 'tbsp', 2
    union select 'Grilled Chicken', 'montreal steak seasoning', 1, 'tbsp', 3
    union select 'Grilled Chicken', 'salt', 1, 'tsp', 4
    union select 'Grilled Chicken', 'maple syrup', 2, 'tbsp', 5
    union select 'Fried Rice', 'oil', 4, 'tbsp', 1
    union select 'Fried Rice', 'onion', 1, null, 2
    union select 'Fried Rice', 'eggs', 2, null, 3
    union select 'Fried Rice', 'soy sauce', 2, 'tbsp', 4
    union select 'Fried Rice', 'cooked rice', 2.5, 'cup', 5
    union select 'Fried Rice', 'black pepper', .25, 'tsp', 6
    union select 'Sauteed Vegetable Omelette', 'oil', 2, 'tbsp', 1
    union select 'Sauteed Vegetable Omelette', 'onion', 1, null, 2
    union select 'Sauteed Vegetable Omelette', 'tomato', 1, null, 3
    union select 'Sauteed Vegetable Omelette', 'white button mushrooms', 4, 'oz', 4
    union select 'Sauteed Vegetable Omelette', 'eggs', 3, null, 5
    union select 'Sauteed Vegetable Omelette', 'salt', 1, 'tsp', 6
    union select 'Sauteed Vegetable Omelette', 'shredded cheese', .25, 'cup', 7
    union select 'Chocolate Covered Popcorn', 'oil', 2, 'tbsp', 1
    union select 'Chocolate Covered Popcorn', 'popcorn kernels', .33, 'cup', 2
    union select 'Chocolate Covered Popcorn', 'chocolate chips', 6, 'oz', 3
    union select 'Chocolate Covered Popcorn', 'white chocolate chips', 6, 'oz', 4
)
insert RecipeIngredient(RecipeId, IngredientId, Amount, MeasurementTypeId, IngredientSequence)
select r.RecipeId, i.IngredientId, x.Amount, m.MeasurementTypeId, x.IngredientSequence
from x 
join Recipe r 
on x.RecipeName = r.RecipeName 
join Ingredient i 
on x.IngredientName = i.IngredientName
left join MeasurementType m 
on x.MeasurementTypeName = m.MeasurementTypeName

;
with x as (
    select RecipeName = 'Chocolate Chip Cookies', StepNumber = 1, Directions = 'First combine sugar, oil and eggs in a bowl'
    union select 'Chocolate Chip Cookies', 2, 'Mix well'
    union select 'Chocolate Chip Cookies', 3, 'Add flour, vanilla sugar, baking powder and baking soda'
    union select 'Chocolate Chip Cookies', 4, 'Beat for 5 minutes'
    union select 'Chocolate Chip Cookies', 5, 'Add chocolate chips'
    union select 'Chocolate Chip Cookies', 6, 'Freeze for 1-2 hours'
    union select 'Chocolate Chip Cookies', 7, 'Roll into balls and place spread out on a cookie sheet'
    union select 'Chocolate Chip Cookies', 8, 'Bake on 350 for 10 min'
    union select 'Apple Yogurt Smoothie', 1, 'Peel the apples and dice'
    union select 'Apple Yogurt Smoothie', 2, 'Combine all ingredients in bowl except for apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 3, 'Mix until smooth'
    union select 'Apple Yogurt Smoothie', 4, 'Add apples and ice cubes'
    union select 'Apple Yogurt Smoothie', 5, 'Pour into glasses'
    union select 'Cheese Bread', 1, 'Slit bread every 3/4 inch'
    union select 'Cheese Bread', 2, 'Combine all ingredients in bowl'
    union select 'Cheese Bread', 3, 'Fill slits with cheese mixture'
    union select 'Cheese Bread', 4, 'Wrap bread into a foil and bake for 30 minutes'
    union select 'Butter Muffins', 1, 'Cream butter with sugars'
    union select 'Butter Muffins', 2, 'Add eggs and mix well'
    union select 'Butter Muffins', 3, 'Slowly add rest of ingredients and mix well'
    union select 'Butter Muffins', 4, 'Fill muffin pans 3/4 full and bake for 30 minutes'
    union select 'Grilled Chicken', 1, 'Combine olive oil, montreal steak seasoning, salt, and maple syrup in a gallon sized ziploc bag'
    union select 'Grilled Chicken', 2, 'Add chicken and shake to coat completely'
    union select 'Grilled Chicken', 3, 'Marinate for at least 30 minutes'
    union select 'Grilled Chicken', 4, 'Heat grill pan over medium high flame'
    union select 'Grilled Chicken', 5, 'Grill chicken for 3-5 minutes per side, until cooked through'
    union select 'Fried Rice', 1, 'Dice onions and saute in oil on medium flame'
    union select 'Fried Rice', 2, 'Beat eggs and add to onions and fry, stirring constantly to break up eggs'
    union select 'Fried Rice', 3, 'Add soy sauce and stir'
    union select 'Fried Rice', 4, 'Add cooked rice'
    union select 'Fried Rice', 5, 'Sprinke with black peper and mix well over flame for about 2 minutes'
    union select 'Fried Rice', 6, 'Add more soy sauce if necessary'
    union select 'Sauteed Vegetable Omelette', 1, 'Dice onion and tomato and thinly slice mushrooms'
    union select 'Sauteed Vegetable Omelette', 2, 'Saute onions until translucent'
    union select 'Sauteed Vegetable Omelette', 3, 'Add tomato and mushrooms and saute until soft '
    union select 'Sauteed Vegetable Omelette', 4, 'Beat eggs and salt'
    union select 'Sauteed Vegetable Omelette', 5, 'Heat another greased frying pan and add egg'
    union select 'Sauteed Vegetable Omelette', 6, 'Sprinkle the cheese and sauteed vegetables over one side of the omelette'
    union select 'Sauteed Vegetable Omelette', 7, 'Carefully fold the other side over and cook until the eggs are fully cooked through'
    union select 'Chocolate Covered Popcorn', 1, 'Heat oil in a large pot over high flame'
    union select 'Chocolate Covered Popcorn', 2, 'Add popcorn kernels, cover, and let cook until it stops popping'
    union select 'Chocolate Covered Popcorn', 3, 'Pour popcorn onto cookie sheet'
    union select 'Chocolate Covered Popcorn', 4, 'Melt chocolate chips and white chocolate chips in microwave in 2 seperate bowls'
    union select 'Chocolate Covered Popcorn', 5, 'Drizzle melted chocolate over popcorn'
    union select 'Chocolate Covered Popcorn', 6, 'Refrigerate until set'
)
insert Direction(RecipeId, StepNumber, Directions)
select r.RecipeId, x.StepNumber, x.Directions
from x 
join Recipe r 
on x.RecipeName = r.RecipeName

insert Course(CourseName, CourseSequence)
select 'Appetizer', 1
union select 'Soup', 2
union select 'Main', 3
union select 'Dessert', 4 

;
with x as (
    select UserName = 'J.Foodie', MealName = 'Breakfast Bash', DateCreated = '2024-2-5', MealActive = 1
    union select 'L.Cheffer', 'Supper Supreme', '2024-2-10', 1
    union select 'A.Cook', 'Luscious Lunch', '2024-2-20', 1
    union select 'S.Baker', 'Simple Snack', '2024-2-15', 0
    union select 'A.Cook', 'Lunch', '2024-2-20', 1 --test
    union select 'L.Cheffer', 'Supper', '2024-2-10', 0 --test
)
insert Meal(UsersId, MealName, DateCreated, MealActive
)
select u.UsersId, x.MealName, x.DateCreated, x.MealActive
from x 
join Users u 
on x.UserName = u.UserName 

;
with x as (
    select MealName = 'Breakfast Bash', CourseName = 'Main'
    union select 'Breakfast Bash', 'Appetizer' 
    union select 'Supper Supreme', 'Main'
    union select 'Supper Supreme', 'Dessert'
    union select 'Simple Snack', 'Main'
    union select 'Luscious Lunch', 'Appetizer'
    union select 'Luscious Lunch', 'Main'
    union select 'Luscious Lunch', 'Dessert'
)
insert MealCourse(MealId, CourseId)
select m.MealId, c.CourseId
from x 
join Meal m 
on x.MealName = m.MealName
join Course c 
on x.CourseName = c.CourseName

;
with x as (
    select MealName = 'Breakfast Bash', CourseName = 'Main', RecipeName = 'Butter Muffins', Main = 0
    union select 'Breakfast Bash', 'Main', 'Cheese Bread', 1
    union select 'Breakfast Bash', 'Appetizer', 'Apple Yogurt Smoothie', 0
    union select 'Supper Supreme', 'Main', 'Grilled Chicken', 1
    union select 'Supper Supreme', 'Main', 'Fried Rice', 0
    union select 'Supper Supreme', 'Dessert', 'Chocolate Chip Cookies', 0
    union select 'Simple Snack', 'Main', 'Chocolate Covered Popcorn', 1
    union select 'Luscious Lunch', 'Appetizer', 'Cheese bread', 0
    union select 'Luscious Lunch', 'Main', 'Sauteed Vegetable Omelette', 1
    union select 'Luscious Lunch', 'Main', 'Apple Yogurt Smoothie', 0
    union select 'Luscious Lunch', 'Dessert', 'Chocolate Chip Cookies', 1
)
insert MealCourseRecipe(MealCourseId, RecipeId, Main)
select mc.MealCourseId, r.RecipeId, x.Main
from x 
join Recipe r 
on x.RecipeName = r.RecipeName
join Course c 
on x.CourseName = c.CourseName
join Meal m 
on m.MealName = x.MealName
join MealCourse mc 
on mc.CourseId = c.CourseId
and m.MealId = mc.MealId

;
with x as (
    select UserName = 'J.Foodie', CookbookName = 'Treats for Two', DateCreated = '2024-1-30', Price = 30, CookbookActive = 1  
    union select 'A.Cook', 'Set my Table', '2024-2-11', 32, 1
    union select 'S.Baker', 'Junior Chef', '2024-1-15', 30, 1
    union select 'L.Cheffer', 'For the Family', '2024-2-17', 35, 0
    union select 'L.Cheffer', 'For the Kids', '2024-2-17', 35, 1 --test
)
insert Cookbook(UsersId, CookbookName, DateCreated, Price, CookbookActive)
select u.UsersId, x.CookbookName, x.DateCreated, x.Price, x.CookbookActive
from x 
join Users u 
on x.UserName = u.UserName

;
with x as (
    select CookbookName = 'Treats for Two', RecipeName = 'Apple Yogurt Smoothie', RecipeSequence = 1
    union select 'Treats for Two', 'Cheese Bread', 2
    union select 'Treats for Two', 'Butter Muffins', 3
    union select 'Set My Table', 'Sauteed Vegetable Omelette', 1
    union select 'Set My Table', 'Fried Rice', 2
    union select 'Junior Chef', 'Chocolate Chip Cookies', 1
    union select 'Junior Chef', 'Chocolate Covered Popcorn', 2
    union select 'For the Family', 'Grilled Chicken', 1 
)
insert CookbookRecipe(CookbookId, RecipeId, RecipeSequence)
select c.CookbookId, r.RecipeId, x.RecipeSequence
from x 
join Cookbook c 
on x.CookbookName = c.CookbookName
join Recipe r 
on x.RecipeName = r.RecipeName

go 

select * from Users u
select * from Cuisine c
select * from Ingredient i 
select * from MeasurementType m
select * from Recipe r
select * from RecipeIngredient ri
select * from Direction d
select * from Course c
select * from Meal m
select * from MealCourse mc
select * from MealCourseRecipe mcr
select * from Cookbook cb
select * from CookbookRecipe cr

select u.UserName, r.RecipeName, c.CuisineType, r.Calories, ri.IngredientSequence, i.IngredientName, ri.Amount, m.MeasurementTypeName, r.CurrentStatus  
from Users u 
join Recipe r 
on u.UsersId = r.UsersId 
join Cuisine c 
on c.CuisineId = r.CuisineId
left join RecipeIngredient ri 
on r.RecipeId = ri.RecipeId 
left join Ingredient i 
on ri.IngredientId = i.IngredientId 
left join MeasurementType m 
on ri.MeasurementTypeId = m.MeasurementTypeId
order by r.CurrentStatus desc, r.RecipeName, ri.IngredientSequence 