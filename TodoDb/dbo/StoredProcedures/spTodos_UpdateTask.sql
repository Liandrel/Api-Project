CREATE PROCEDURE [dbo].[spTodos_UpdateTask]
	@Task		nvarchar(100),
	@AssignedTo int,
	@TodoId		int

AS
BEGIN
	
	UPDATE dbo.Todos
	SET	Task = @Task
	WHERE Id = @TodoId AND AssignedTo = @AssignedTo;

END