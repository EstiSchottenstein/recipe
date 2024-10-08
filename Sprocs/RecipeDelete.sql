create or alter procedure dbo.RecipeDelete(
	@RecipeId int,
	@Message varchar(500) = '' output
)
as 
begin
	declare @return int = 0
	if exists(select * from Recipe r where r.RecipeId = @RecipeId and (r.CurrentStatus = 'Published' or (r.CurrentStatus = 'Archive' and datediff(day, r.DateArchived, CURRENT_TIMESTAMP) < 30)))
	begin 
		select @return = 1, @Message = 'Cannot delete if recipe is not currently in draft or is archived for less than 30 days.'
		goto finished
	end

	begin try 
		begin tran
		delete RecipeIngredient where RecipeId = @RecipeId
		delete Direction where RecipeId = @RecipeId
		delete Recipe where RecipeId = @RecipeId
		commit
	end try
	begin catch
		rollback;
		throw
	end catch

	finished:
	return @return
end
go 


