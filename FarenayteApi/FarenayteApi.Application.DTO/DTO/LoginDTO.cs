using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioRequestDTO
    {
        public int Id { get; set; }        
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        /*[JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }*/
    }
}