CREATE PROCEDURE [dbo].[spTodos_Create]
	@Task		nvarchar(100),
	@AssignedTo int

AS
BEGIN
	
	INSERT INTO dbo.Todos (Task, AssignedTo)
	VALUES(@Task,@AssignedTo);

	SELECT [Id], [Task], [AssignedTo], [IsComplete]
	FROM dbo.Todos
	WHERE Id = SCOPE_IDENTITY();

END