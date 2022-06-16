namespace Classes.Module.StackOverflowContext
{
    public class BaseModel
    {
        public BaseModel(string author)
        {
            Author = author;
            CreatedAt = DateTime.Now;
        }

        public string Author { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void Update()
        {
            UpdatedAt = DateTime.Now;
        }
    }
}
