using System.ComponentModel.DataAnnotations;
using Pomodoro.Core.Models;

namespace Pomodoro.Api.Contracts.Requests.Task
{
    public class UpdateCategoryRequest
    {
        public UpdateCategoryRequest(string name)
        {
            Name = name;
        }

        [Required]
        [MaxLength(TaskCategory.MAX_NAME_LENGTH)]
        public string Name { get; set; }
    }
}