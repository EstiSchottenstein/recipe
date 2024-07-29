-- SM Woo-hoo! Excellent! See comments, no need to resubmit the sketch.
-- How did you get it right the first time? Good luck on creating the DB.
/*
HeartyHearth 

-- SM You can't use User as table name, it's a reserved word. Either use Users or Staff.
Users
    UserId pk
    FirstName varchar(50) not null, not blank
    LastName varchar(50) not null, not blank
    UserName varchar(50) not null, not blank, unique

Cuisine
    CuisineId pk
    CuisineType varchar(25) not null, not blank, unique 

Ingredient
    IngredientId pk
    IngredientName varchar(50) not null, not blank, unique
    IngredientPicture computed-
        concat('Ingredient','_',replace(IngredientName,' ','_'),'.jpg')

MeasurementType
    MeasurementTypeId pk
    MeasurementTypeName varchar(15) not null, not blank, unique

Recipe
    RecipeId pk
    UserId fk not null 
    CuisineId fk not null
    RecipeName varchar(100) not null, not blank, unique 
    Calories int not null, not negative
    DateDraft datetime not null, must be <= getdate()
    DatePublished datetime null, must be >= DateDraft and <= getdate()
-- SM Must also be after DatePublished
    DateArchived datetime null, must be >= DateDraft and DatePublished and <= getdate()
    CurrentStatus computed-
        case
            when DateArchived is null and DatePublished is null then 'Draft'
            when DateArchived is null then 'Published'
            else 'Archive'
        end 
    RecipePicture computed-
        concat('Recipe','_',replace(RecipeName,' ','_'),'.jpg')

RecipeIngredient
    RecipeIngredientId pk
    RecipeId fk not null
    IngredientId fk not null
    Amount int not null, greater than 0 
-- SM You should allow null here. There are some ingredients that don't have a measurement.
    MeasurementTypeId fk null
    IngredientSequence int not null, greater than 0
        unique RecipeId, IngredientId
        unique RecipeId, IngredientSequence

Direction
    DirectionId pk
    RecipeId fk not null
    StepNumber int not null, greater than 0
    Directions varchar(max) not null, not blank
        unique RecipeId, StepNumber

Course 
    CourseId pk
    CourseName varchar(25) not null, not blank, unique
-- SM Should be unique.
    CourseSequence int not null, greater than 0, unique

Meal
    MealId pk
    UserId fk not null
    MealName varchar(100) not null, not blank, unique
    DateCreated date not null, must be <= getdate()
    MealActive bit not null 
    MealPicture computed-
        concat('Meal','_',replace(MealName,' ','_'),'.jpg')

MealCourse
    MealCourseId pk
    MealId fk not null
    CourseId fk not null
        unique MealId, CourseId

MealCourseRecipe
    MealCourseRecipeId pk
    MealCourseId fk not null
    RecipeId fk not null
    Main bit not null
        unique MealCourseId, RecipeId

Cookbook
    CookbookId pk
    UserId fk not null
    CookbookName varchar(100) not null, not blank, unique
    DateCreated date not null, must be <= getdate()
    Price decimal not null, greater than 0 
    CookbookActive bit not null
    CookbookPicture computed-
        concat('Cookbook','_',replace(CookbookName,' ','_'),'.jpg')

CookbookRecipe
    CookbookRecipeId pk
    CookbookId fk not null
    RecipeId fk not null
    RecipeSequence int not null, greater than 0 
-- SM The sequence should also be unique to book.
        unique CookbookId, RecipeId
        unique CookbookId, RecipeSequence
*/