using System.ComponentModel.DataAnnotations.Schema;
using portfolio_api.Enums;

namespace portfolio_api.Models {
    public class SocialMedia{
        public int ID {get; set;}
        [Column(TypeName = "nvarchar(24)")]
        public required SocialMediaNames Name {get; set;}
        public required string URL {get; set;}
        public required int ProfileID {get; set;}
        public required Profile Profile {get;set;}
    }
}