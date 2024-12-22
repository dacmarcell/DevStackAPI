namespace portfolio_api.Models
{
    public class Profile
    {
        public int ID { get; set; }
        public required string  Name { get; set; }
        public string AboutMe {get; set;} = string.Empty;
        public List<SocialMedia> SocialMedia { get; set; } = [];
        public List<Project> Projects {get;set;} = [];
    }
}