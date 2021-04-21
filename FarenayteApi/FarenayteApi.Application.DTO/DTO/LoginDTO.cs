using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class LoginDTO
    {
        [JsonProperty(PropertyName = "email")]

        public string Email { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}