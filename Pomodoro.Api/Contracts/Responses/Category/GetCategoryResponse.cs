namespace Pomodoro.Api.Contracts.Responses.Task
{
    public class GetCategoryResponse
    {
        public GetCategoryResponse(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}