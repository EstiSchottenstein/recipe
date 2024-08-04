create or alter procedure dbo.CourseGet(@CourseId int = 0, @All bit = 0, @CourseName varchar(25) = '')
as 
begin
	select @CourseName = nullif(@CourseName, '')

	select c.CourseId, c.CourseName, c.CourseSequence
	from Course c
	where c.CourseId = @CourseId
	or @All = 1
	or c.CourseName like '%' + @CourseName + '%'
	order by c.CourseSequence
end
go

/*
exec CourseGet

exec CourseGet @All = 1

exec CourseGet @CourseName = '' --return no results
exec CourseGet @CourseName = 'a'

declare @id int
select top 1 @id = c.CourseId from Course c
exec CourseGet @CourseId = @id
*/