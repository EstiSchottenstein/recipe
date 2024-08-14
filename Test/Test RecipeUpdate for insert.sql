--insert

declare @Message varchar(500) = '', @return int, @cuisineid int, @usersid int, @recipeid int

select top 1 @cuisineid = cuisineid from Cuisine
select top 1 @usersid = usersid from Users

exec @return = RecipeUpdate
	@RecipeId = @recipeid output,
	@CuisineId = @cuisineid,
	@UsersId = @usersid, 
	@RecipeName = 'TestInsert', 
	@Calories = 100, 
	@DateDraft = '8/01/2024', 
	@DatePublished = '8/12/2024', 
	@DateArchived = null,
	@Message = @Message output

select @return, @Message, @recipeid


select top 1 * from Recipe r where r.RecipeId = @recipeid

delete Recipe where RecipeId = @recipeid