create or alter procedure dbo.UsersGet(@UsersId int = 0, @All bit = 0, @LastName varchar(50) = '')
as 
begin
	select @LastName = nullif(@LastName, '')

	select u.UsersId, u.FirstName, u.LastName, u.UserName
	from Users u
	where u.UsersId = @UsersId
	or @All = 1
	or u.LastName like '%' + @LastName + '%'
	order by u.UserName
end
go


/*
exec UsersGet

exec UsersGet @All = 1

exec UsersGet @LastName = '' --return no results
exec UsersGet @LastName = 'a'

declare @id int
select top 1 @id = u.UsersId from Users u
exec UsersGet @UsersId = @id
*/