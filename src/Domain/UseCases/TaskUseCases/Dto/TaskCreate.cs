using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.TaskUseCases.Dto
{
    public class TaskCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string? UserId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        public static implicit operator Models.Task(TaskCreate model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return new Models.Task(model.Title, model.Description, Status.Pending, model.UserId, model.CategoryId, Guid.NewGuid());
        }
    }
}
