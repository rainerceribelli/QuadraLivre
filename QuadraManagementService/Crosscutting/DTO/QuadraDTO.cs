using System;
using System.ComponentModel.DataAnnotations;

namespace QuadraManagementService.Crosscutting.DTO
{
    public class QuadraDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A localização é obrigatória.")]
        public string Localizacao { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        public string Tipo { get; set; }

        [Required]
        public DateTime? DtCriacao { get; set; }

        public DateTime DtUltimaAlteracao { get; set; }

        [Required(ErrorMessage = "O campo BitAtivo é obrigatório.")]
        public bool? BitAtivo { get; set; }
    }
}
