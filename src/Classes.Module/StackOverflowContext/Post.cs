namespace Classes.Module.StackOverflowContext
{
    public class Post : BaseModel
    {
        public Post(string description, string title, string author, params string[] tags) : base(author)
        {
            Description = description;
            Title = title;
            Tags = tags;
        }

        public string Description { get; private set; }
        public string Title { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public int Votes { get; private set; }

        public void Update(string description, string title)
        {
            Description = description;
            Title = title;
            Update();
        }

        public void UpVote() => Votes++;
        public void DownVote() => Votes--;

        public override string ToString()
        {
            return $"{Title} by {Author} at {CreatedAt}";
        }
    }
}
