using portfolio_api.Enums;

namespace portfolio_api.Dtos
{
    public class UpdateSocialMediaDto
    {
        public int ID { get; set; }
        public required SocialMediaNames Name { get; set; }
        public required string URL { get; set; }
        public required int ProfileID { get; set; }
    }
}