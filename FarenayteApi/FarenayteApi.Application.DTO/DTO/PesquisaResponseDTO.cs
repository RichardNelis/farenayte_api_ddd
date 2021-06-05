using System;
using Newtonsoft.Json;

namespace FarenayteApi.Application.DTO.DTO
{
    public class PesquisaResponseDTO
    {
        [JsonProperty(PropertyName = "es_usuario")]
        public int EsUsuario { get; set; }

        public string Logo { get; set; }

        [JsonProperty(PropertyName = "razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty(PropertyName = "nome_fantasia")]
        public string NomeFantasia { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public decimal? Preco { get; set; }

        public int IBGE { get; set; }

        public double Rating { get; set; }

        public double CalcularRating(double RatingTotal, int QntComentarios)
        {
            double rating = RatingTotal / QntComentarios;            
            rating = double.IsNaN(rating) || rating < 0 ? 0 : rating > 5 ? 5 : rating;
                        
            rating = Math.Round(rating, 1);

            return rating;
        }
    }
}