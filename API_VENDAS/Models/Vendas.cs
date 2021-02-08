using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Vendas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenda { get; set; }

        [Required(ErrorMessage = "Preencha ao menos um Veículo.")]
        public ICollection<Veiculo> Veiculos { get; set; }

        [Required]
        public int Status { get; set; } = (int)StatusVendas.ConfirmacaodePagamento;

        [Required]
        public string CodigoVendedor { get; set; }
    }
    public enum StatusVendas
    {
        ConfirmacaodePagamento = 1,
        PagamentoAprovado,
        EmTransporte,
        Entregue,
        Cancelada
    }

}
