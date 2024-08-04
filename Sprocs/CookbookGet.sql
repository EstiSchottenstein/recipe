create or alter procedure dbo.CookbookGet(@CookbookId int = 0, @All bit = 0, @CookbookName varchar(100) = '')
as 
begin
	select @CookbookName = nullif(@CookbookName, '')

	select c.CookbookId, c.UsersId, c.CookbookName, c.DateCreated, c.Price, c.CookbookActive, c.CookbookPicture
	from Cookbook c
	where c.CookbookId = @cookbookId
	or @All = 1
	or c.CookbookName like '%' + @CookbookName + '%'
	order by c.UsersId, c.CookbookActive, c.DateCreated, c.Price, c.CookbookName
end
go

/*
exec CookbookGet

exec CookbookGet @All = 1

exec CookbookGet @CookbookName = '' --return no results
exec CookbookGet @CookbookName = 'a'

declare @id int
select top 1 @id = c.CookbookId from Cookbook c
exec CookbookGet @CookbookId = @id
*/