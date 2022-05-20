namespace Pomodoro.Api.Contracts.Responses.Task
{
    public class GetCategoryResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}