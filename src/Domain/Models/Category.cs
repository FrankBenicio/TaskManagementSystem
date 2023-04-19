namespace Domain.Models
{
    public class Category
    {
        public Category(string name, string userId, Guid id)
        {
            Name = name;
            UserId = userId;
            Id = id;
        }

        public Guid Id { get; private set; } 
        public string Name { get; private set; }
        public string UserId { get; private set; }
    }
}
