using Domain.Enums;

namespace Domain.Models
{
    public class Task
    {
        public Task(string title, string description, Status status, string userId, Guid categoryId, Guid id)
        {
            Title = title;
            Description = description;
            UserId = userId;
            Id = id;
            CategoryId = categoryId;
            Status= status;
            CreationDate = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationDate { get; private set; }
        public DateTime? DateConclusion { get; private set; }
        public Status Status { get; private set; }
        public string UserId { get; private set; }

        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public void InProgress()
        {
            Status = Status.InProgress;
        } 
        
        public void Pending()
        {
            Status = Status.Pending;
        }

        public void Completed()
        {
            Status = Status.Completed;
            DateConclusion = DateTime.Now;
        }


    }
}
