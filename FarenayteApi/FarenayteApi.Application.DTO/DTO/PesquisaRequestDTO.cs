using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PesquisaRequestDTO
    {
        public int IBGE { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string RazaoSocial { get; set; }

        public string NomeFantasia { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }

        public double Distancia { get; set; }
    }
}