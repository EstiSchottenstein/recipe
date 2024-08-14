--update

declare @Message varchar(500) = '', @return int, @cuisineid int, @usersid int, @recipeid int,
	@RecipeName varchar (100),
	@Calories int,
	@DateDraft datetime,
	@DatePublished datetime,
	@DateArchived datetime

select top 1 
	@recipeid = r.RecipeId, 
	@UsersId = r.UsersId, 
	@CuisineId = r.CuisineId, 
	@RecipeName = RecipeName, 
	@Calories = Calories, 
	@DateDraft = DateDraft, 
	@DatePublished = DatePublished, 
	@DateArchived = DateArchived
from Recipe r 

select @RecipeName = REVERSE(@RecipeName)

exec @return = RecipeUpdate 
	@RecipeId = @recipeid output,
	@CuisineId = @cuisineid,
	@UsersId = @usersid, 
	@RecipeName = @RecipeName, 
	@Calories = @Calories, 
	@DateDraft = @DateDraft, 
	@DatePublished = @DatePublished, 
	@DateArchived = @DateArchived,
	@Message = @Message output

select @return, @Message, @recipeid

select top 1 * from Recipe r where r.RecipeId = @recipeid
