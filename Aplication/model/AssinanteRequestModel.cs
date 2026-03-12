using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.model
{
    public class AssinanteRequestModel
    {
        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O plano deve ser selecionado.")]
        public PlanoEnum Plano { get; set; }

        [Required(ErrorMessage = "O valor mensal é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor da assinatura deve ser maior que zero.")]
        public double Valor { get; set; }
    }
}
