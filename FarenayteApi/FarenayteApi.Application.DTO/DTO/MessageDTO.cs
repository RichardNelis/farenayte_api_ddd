using System.Collections.Generic;

namespace FarenayteApi.Application.DTO.DTO
{
    public class MessageDTO
    {
        public ICollection<string> Messages { get; set; }

        public MessageDTO()
        {
            Messages = new List<string>();
        }
    }
}
