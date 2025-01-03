namespace portfolio_api.Dtos.PostDtos
{
    public class CreatePostDto
    {
        public required string Title { get; set; }
        public required string Content { get; set; }
        public required int ProfileID { get; set; }
    }
}