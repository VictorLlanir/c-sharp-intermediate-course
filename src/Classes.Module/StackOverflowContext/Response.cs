namespace Classes.Module.StackOverflowContext
{
    public class Response : BaseModel
    {
        public Response(string description, string author) : base(author)
        {
            Description = description;
        }

        public string Description { get; private set; }

        public void Update(string description, string title)
        {
            Description = description;
            Update();
        }

        public override string ToString()
        {
            return $"{Description[..30]}... by {Author} at {CreatedAt}";
        }
    }
}
