use HeartyHearthDB
go 

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


select * from Recipe