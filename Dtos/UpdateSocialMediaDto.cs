using portfolio_api.Enums;
using portfolio_api.Models;

namespace portfolio_api.Dtos
{
    public class UpdateSocialMediaDto
    {
        public SocialMediaNames? Name { get; set; }
        public  string? URL { get; set; }
        public  int? ProfileID { get; set; }
        public  Profile? Profile { get; set; }
    }
}