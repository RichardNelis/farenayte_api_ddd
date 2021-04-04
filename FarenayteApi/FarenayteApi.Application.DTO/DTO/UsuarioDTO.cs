using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class UsuarioDTO
    {        
        public int Id { get; set; }

        //[Required(ErrorMessage = "E-mail é obrigatório")]        
        //[MaxLength(100, ErrorMessage = "O E-mail deve conter até 100 caracteres")]
        //[DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Senha é obrigatória")]
        //[MinLength(8, ErrorMessage = "A senha deve conter 8 caracteres.")]
        //[MaxLength(8, ErrorMessage = "A senha deve conter 8 caracteres.")]
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "pessoa_fisica")]
        public virtual PessoaFisicaDTO PessoaFisica { get; set; }
    }
}