namespace Classes.Module.StackOverflowContext
{
    public class Post
    {
        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            CreatedAt = DateTime.Now;
            Votes = 0;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public int Votes { get; private set; }

        public void UpVote() => Votes++;
        public void DownVote() => Votes--;

        public void Update(string description)
        {
            Description = description;
        }

        public override string ToString()
        {
            return $"{Title} at {CreatedAt:G}";
        }
    }
}
