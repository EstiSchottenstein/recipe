use HeartyHearthDB
go 

delete d 
from Direction d
join Recipe r 
on d.RecipeId = r.RecipeId 
where r.RecipeName = 'Muddy Buddies'

delete ri 
from RecipeIngredient ri
join Recipe r 
on ri.RecipeId = r.RecipeId
where r.RecipeName = 'Muddy Buddies'

delete r 
from Recipe r 
where r.RecipeName = 'Muddy Buddies' or r.RecipeName = 'Cinnamon Buns' or r.RecipeName = 'Garlic Knots' or r.RecipeName = 'Granola'
go 

;
with x as (
    select UserName = 'S.Baker', CuisineType = 'American', RecipeName = 'Muddy Buddies', Calories = 200, DateDraft = '2022-6-15 1:30', DatePublished = '2022-7-10 12:00', DateArchived = null --no related records
    union select 'L.Cheffer', 'French', 'Cinnamon buns', 250, '2023-5-15 1:30', '2023-6-10 12:00', null --no related records
    union select 'A.Cook', 'American', 'Garlic Knots', 150, '2020-10-10 11:15', '2020-10-25 12:05', '2023-10-25 12:05' --no related records
    union select 'J.Foodie', 'English', 'Granola', 140, '2021-5-16 11:45', null, null --no related records
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
    select RecipeName = 'Muddy Buddies', IngredientName = 'chocolate chips', Amount = 1, MeasurementTypeName = 'cup', IngredientSequence = 1 
    union select 'Muddy Buddies', 'peanut butter', .5, 'cup', 2
    union select 'Muddy Buddies', 'margarine', .25, 'cup', 3
    union select 'Muddy Buddies', 'vanilla extract', 1, 'tsp', 4
    union select 'Muddy Buddies', 'rice chex', 9, 'cup', 5
    union select 'Muddy Buddies', 'powdered sugar', 1.5, 'cup', 6
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
    select RecipeName = 'Muddy Buddies', StepNumber = 1, Directions = 'Melt chocolate chips, margarine, and peanut butter together'
    union select 'Muddy Buddies', 2, 'Turn off flame and stir in vanilla extract'
    union select 'Muddy Buddies', 3, 'Add cereal and mix until fully coated'
    union select 'Muddy Buddies', 4, 'Pour powdered sugar into a big ziploc bag, add cereal'
    union select 'Muddy Buddies', 5, 'Shake until fully coated.'
)
insert Direction(RecipeId, StepNumber, Directions)
select r.RecipeId, x.StepNumber, x.Directions
from x 
join Recipe r 
on x.RecipeName = r.RecipeName

select * from Recipe