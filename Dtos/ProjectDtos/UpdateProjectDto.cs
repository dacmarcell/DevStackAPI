namespace portfolio_api.Dtos.ProjectDtos {
    public class UpdateProjectDto {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? GithubURL { get; set; }
        public string? DeployURL { get; set; }
        public int? ProfileID { get; set; }
    }
}