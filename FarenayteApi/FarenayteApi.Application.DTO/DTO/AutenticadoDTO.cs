using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class AutenticadoDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }
}