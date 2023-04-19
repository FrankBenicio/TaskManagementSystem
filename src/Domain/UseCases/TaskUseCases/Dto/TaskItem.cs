using Domain.Enums;
using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Domain.UseCases.TaskUseCases.Dto
{
    public class TaskItem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Date Conclusion")]
        public DateTime? DateConclusion { get; set; }
        public Status Status { get; set; }
        public string UserId { get; set; }
        public string Category { get; set; }

        public static implicit operator TaskItem(Models.Task model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return new TaskItem
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                Category = model.Category.Name,
                Status = model.Status,
                UserId = model.UserId,
                CreationDate = model.CreationDate,
                DateConclusion = model.DateConclusion,
            };
        }
    }
}
