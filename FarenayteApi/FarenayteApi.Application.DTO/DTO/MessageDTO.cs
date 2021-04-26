using System.Collections.Generic;
using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class MessageDTO
    {
        [JsonProperty(PropertyName = "messages")]
        public ICollection<string> Messages { get; set; }

        public MessageDTO()
        {
            Messages = new List<string>();
        }
    }
}
