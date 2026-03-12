using Dominio.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.model
{
    public class AsssinanteReponserModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Plano { get; set; } 
        public double Valor { get; set; }
        public bool Status { get; set; }
        public int TempoAssinaturaEmMeses { get; set; }
        public DateTime DataInicio { get; set; }

        public static AsssinanteReponserModel DeEntidade(Assinante assinante)
        {
            if (assinante == null) return null;

            return new AsssinanteReponserModel
            {
                Id = assinante.Id,
                Nome = assinante.Nome,
                Email = assinante.Email,
                Plano = assinante.Plano.ToString(),
                Valor = assinante.Valor,
                Status = assinante.Status,
                TempoAssinaturaEmMeses = assinante.TempoAssinaturaEmMeses,
                DataInicio = assinante.DataInicio
            };
        }
    }
}
