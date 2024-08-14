create or alter proc dbo.RecipeUpdate(
	@RecipeId int output,
	@UsersId int,
	@CuisineId int,
	@RecipeName varchar (100),
	@Calories int,
	@DateDraft datetime,
	@DatePublished datetime,
	@DateArchived datetime,
	@Message varchar(500) = '' output
)
as
begin
	declare @return int = 0

	select @RecipeId = isnull(@RecipeId,0), @DatePublished = nullif(@DatePublished,0), @DateArchived = nullif(@DateArchived,0)

	if @RecipeId = 0
	begin
		insert Recipe(UsersId, CuisineId, RecipeName, Calories, DateDraft, DatePublished, DateArchived)
		values(@UsersId, @CuisineId, @RecipeName, @Calories, @DateDraft, @DatePublished, @DateArchived)
	
		select @RecipeId = SCOPE_IDENTITY()
	end
	else
	begin 
		update Recipe
		set 
			UsersId = @UsersId, 
			CuisineId = @CuisineId, 
			RecipeName = @RecipeName, 
			Calories = @Calories, 
			DateDraft = @DateDraft, 
			DatePublished = @DatePublished, 
			DateArchived = @DateArchived
		where RecipeId = @RecipeId
	end

	return @return
end
go
