using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameStoreMVC.Models
{
    [Table("Games")]
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(200)]
        [Display(Name = "Título do Jogo")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(500)]
        [Display(Name = "Descrição Curta")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço (R$)")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Preco { get; set; }

        [StringLength(500)]
        [Display(Name = "URL da Capa")]
        public string? ImagemUrl { get; set; }

        [StringLength(50)]
        [Display(Name = "Categoria")]
        public string? Categoria { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
