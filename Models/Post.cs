namespace portfolio_api.Models
{
    public class Post
    {
        public int ID {get;set;}
        public required string Title {get;set;}
        public required string Content {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public required int ProfileID {get;set;}
        public required Profile Profile {get;set;}
     }
}