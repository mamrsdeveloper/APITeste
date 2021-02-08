using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Veiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVeiculo { get; set; }

        [Required(ErrorMessage = "O campo código é obrigatório.")]
        [StringLength(6, ErrorMessage = "O código deve conter 6 caracteres.", MinimumLength = 6)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O campo Ano é obrigatório.")]
        public int AnoFabricacao { get; set; }
    }
}
