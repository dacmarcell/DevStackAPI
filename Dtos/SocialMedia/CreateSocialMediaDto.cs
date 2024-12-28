namespace portfolio_api.Dtos
{
    public class CreateSocialMediaDto
    {
        public required string Name { get; set; }
        public required string URL { get; set; }
        public required int ProfileID { get; set; }
    }
}