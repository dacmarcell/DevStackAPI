using System.Text.Json.Serialization;

namespace portfolio_api.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SocialMediaNames {
        Github,
        LinkedIN,
        Email
    }
}