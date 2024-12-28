using portfolio_api.Enums;

namespace portfolio_api.Models {
    public class SocialMedia{
        public int ID {get; set;}
        public required SocialMediaNames Name {get; set;}
        public required string URL {get; set;}
        public required int ProfileID {get; set;}
        public required Profile Profile {get;set;}
    }
}