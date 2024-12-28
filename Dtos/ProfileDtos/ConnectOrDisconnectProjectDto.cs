using portfolio_api.Enums;

namespace portfolio_api.Dtos.ProfileDtos {
    public class ConnectOrDisconnectProjectDto {
        public required string ProjectID { get; set; }
        public required ConnectOrDisconnect Kind { get; set; }
    }
}