namespace portfolio_api.Dtos.ProjectDtos 
{
    public class CreateProjectDto 
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required int ProfileID { get; set; }
        public string? GithubURL { get; set; }
        public string? DeployURL { get; set; }
    }
}