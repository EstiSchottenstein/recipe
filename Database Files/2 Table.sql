-- SM WOW! Excellent! 100% See comment.
use HeartyHearthDB 
go
drop table if exists dbo.CookbookRecipe
drop table if exists dbo.Cookbook 
drop table if exists dbo.MealCourseRecipe
drop table if exists dbo.MealCourse
drop table if exists dbo.Meal
drop table if exists dbo.Course
drop table if exists dbo.Direction
drop table if exists dbo.RecipeIngredient
drop table if exists dbo.Recipe
drop table if exists dbo.Users 
drop table if exists dbo.Cuisine
drop table if exists dbo.Ingredient
drop table if exists dbo.MeasurementType
go
create table dbo.Users(
    UsersId int not null identity primary key, 
    FirstName varchar(50) not null constraint ck_Users_FirstName_cannot_be_blank check(FirstName <> ''),
    LastName varchar(50) not null constraint ck_Users_LastName_cannot_be_blank check(LastName <> ''),
    UserName varchar(100) not null 
        constraint ck_Users_UserNAme_cannot_be_blank check(UserName <> '')
        constraint u_Users_UserName unique
)
create table dbo.Cuisine(
    CuisineId int not null identity primary key, 
    CuisineType varchar(25) not null
        constraint u_Cuisine_CuisineType unique
        constraint ck_Cuisine_CuisineType_cannot_be_blank check(CuisineType <> '')
)
create table dbo.Ingredient(
    IngredientId int not null identity primary key, 
    IngredientName varchar(50) not null 
        constraint u_Ingredient_IngredientName unique 
        constraint ck_Ingredient_IngredientName_cannot_be_blank check(IngredientName <> ''),
    IngredientPicture as 
        concat('Ingredient','_',replace(IngredientName,' ','_'),'.jpg') persisted
)
create table dbo.MeasurementType(
    MeasurementTypeId int not null identity primary key, 
    MeasurementTypeName varchar(15) not null 
        constraint u_MeasurementType_MeasurementTypeName unique 
        constraint u_MeasurementType_MeasurementTypeName_cannot_be_blank check(MeasurementTypeName <> '')
)
create table dbo.Recipe(
    RecipeId int not null identity primary key, 
    UsersId int not null constraint f_Users_Recipe foreign key references Users(UsersId),
    CuisineId int not null constraint f_Cuisine_Recipe foreign key references Cuisine(CuisineId),
    RecipeName varchar(100) not null 
        constraint u_Recipe_RecipeName unique 
        constraint ck_Recipe_RecipeName_cannot_be_blank check(RecipeName <> ''),
    Calories int not null 
        constraint ck_Recipe_Calories_cannot_be_negative check(Calories >= 0),
    DateDraft datetime not null 
        constraint ck_Recipe_DateDraft_cannot_be_after_curent_date check(DateDraft <= getdate()),
    DatePublished datetime null 
        constraint ck_Recipe_DatePublished_cannot_be_after_curent_date check(DatePublished <= getdate()),
    DateArchived datetime null 
        constraint ck_Recipe_DateArchived_cannot_be_after_curent_date check(DateArchived <= getdate()),
    CurrentStatus as 
        case
            when DateArchived is null and DatePublished is null then 'Draft'
            when DateArchived is null then 'Published'
            else 'Archive'
        end persisted,
    RecipePicture as 
        concat('Recipe','_',replace(RecipeName,' ','_'),'.jpg') persisted,
    constraint ck_Recipe_DatePublished_must_be_after_DateDraft check(DatePublished >= DateDraft),
-- SM DateArchived must "also" be after DatePublished but "also" after DateDraft. This will not make sure that DateArchived is after DateDraft when DatePublished is null.
    constraint ck_Recipe_DateArchived_must_be_after_DateDraft check(DateArchived >= DateDraft),
    constraint ck_Recipe_DateArchived_must_be_after_DatePublished check(DateArchived >= DatePublished)
)
create table dbo.RecipeIngredient(
    RecipeIngredientId int not null identity primary key, 
    RecipeId int not null constraint f_Recipe_RecipeIngredient foreign key references Recipe(RecipeId), 
    IngredientId int not null constraint f_Ingredient_RecipeIngredient foreign key references Ingredient(IngredientId), 
    MeasurementTypeId int null constraint f_Recipe_MeasurementType foreign key references MeasurementType(MeasurementTypeId),
    Amount decimal(5,2) not null 
        constraint ck_RecipeIngredient_Amount_must_be_greater_than_0 check(Amount > 0),
    IngredientSequence int not null 
        constraint ck_Recipe_IngredientSequence_must_be_greater_than_0 check(IngredientSequence > 0),
    constraint u_Recipe_RecipeId_IngredientId unique(RecipeId, IngredientId),
    constraint u_Recipe_RecipeId_IngredientSequence unique(RecipeId, IngredientSequence)
)
create table dbo.Direction(
    DirectionId int not null identity primary key,
    RecipeId int not null constraint f_Recipe_Direction foreign key references Recipe(RecipeId),
    StepNumber int not null 
        constraint ck_Direction_StepNumber_must_be_greater_than_0 check(StepNumber > 0),
    Directions varchar(max) not null 
        constraint ck_Direction_Directions_cannot_be_blank check(Directions <> ''),
    constraint u_Direction_RecipeId_StepNumber unique(RecipeId, StepNumber)
)
create table dbo.Course(
    CourseId int not null identity primary key, 
    CourseName varchar(25) not null 
        constraint u_Course_CourseName unique
        constraint ck_Course_CourseName_cannot_be_blank check(CourseName <> ''),
    CourseSequence int not null 
        constraint u_Course_Course_Sequence unique 
        constraint ck_Course_CourseSequence_must_be_greater_than_0 check(CourseSequence > 0)
)
create table dbo.Meal(
    MealId int not null identity primary key,
    UsersId int not null constraint f_Users_Meal foreign key references Users(UsersId),
    MealName varchar(100) not null
        constraint u_Meal_MealName unique 
        constraint ck_Meal_MealName_cannot_be_blank check(MealName <> ''),
    DateCreated date not null 
        constraint ck_Meal_DateCreated_cannot_be_after_curent_date check(DateCreated <= getdate()),
    MealActive bit not null default 1, 
    MealPicture as 
        concat('Meal','_',replace(MealName,' ','_'),'.jpg') persisted    
)
create table dbo.MealCourse(
    MealCourseId int not null identity primary key,
    MealId int not null constraint f_Meal_MealCourse foreign key references Meal(MealId),
    CourseId int not null constraint f_Course_MealCourse foreign key references Course(CourseId),
    constraint u_MealCourse_MealId_CourseId unique(MealId, CourseId)
)
create table dbo.MealCourseRecipe(
    MealCourseRecipeId int not null identity primary key, 
    MealCourseId int not null constraint f_MealCourse_MealCourse_Recipe foreign key references MealCourse(MealCourseId),
    RecipeId int not null constraint f_Recipe_MealCourseRecipe foreign key references Recipe(RecipeId),
    Main bit not null,
    constraint u_MealCourseRecipe_MealCourseId_RecipeId unique(MealCourseId, RecipeId)
)
create table dbo.Cookbook(
    CookbookId int not null identity primary key, 
    UsersId int not null constraint f_Users_Cookbook foreign key references Users(UsersId),
    CookbookName varchar(100) not null 
        constraint u_Cookbook_CookbookName unique 
        constraint ck_Cookbook_CookbookName_cannot_be_blank check(CookbookName <> ''),
    DateCreated date not null 
        constraint ck_Cookbook_DateCreated_cannot_be_after_curent_date check(DateCreated <= getdate()),
    Price decimal(5,2) not null 
        constraint ck_Cookbook_Price_must_be_greater_than_0 check(Price > 0),
    CookbookActive bit not null default 1, 
    CookbookPicture as 
        concat('Cookbook','_',replace(CookbookName,' ','_'),'.jpg') persisted
)
create table dbo.CookbookRecipe(
    CookbookRecipeId int not null identity primary key, 
    CookbookId int not null constraint f_Cookbook_CookbookRecipe foreign key references Cookbook(CookbookId),
    RecipeId int not null constraint f_Recipe_CookbookRecipe foreign key references Recipe(RecipeId),
    RecipeSequence int not null 
        constraint ck_CookbookRecipe_RecipeSequence_must_be_greater_than_0 check(RecipeSequence > 0),
    constraint u_CookbookRecipe_CookbookId_RecipeId unique(CookbookId, RecipeId),
    constraint u_CookbookRecipe_CookbookId_RecipeSequence unique(CookbookId, RecipeSequence)
)
go