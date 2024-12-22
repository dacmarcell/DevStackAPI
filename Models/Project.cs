namespace portfolio_api.Models
{
    public class Project
    {
        public int ID { get; set; }
        public required string Name {get; set;} = string.Empty;
        public string Description {get;set;} = string.Empty;
        public string GithubURL {get;set;} = string.Empty;
        public string DeployURL {get;set;} = string.Empty;
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public required int ProfileID {get;set;}
        public required Profile Profile {get;set;}

    }
}