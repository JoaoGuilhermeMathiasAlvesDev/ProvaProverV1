using Dominio.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entity
{
    public class Assinante
    {
        [Key]
        public Guid Id { get;private set; }
        public string Nome { get;private set; }

        public string Email { get;private set; }

        public DateTime DataInicio { get; private set; }

        public PlanoEnum Plano { get; private set; }

        public double Valor { get; private set; }

        public bool Status { get; set; }

        public Assinante()
        {
            
        }

        public Assinante(string nome, string email, PlanoEnum plano, double valor, DateTime dataInicio)
        {
            Validacao.Validar(nome,email,valor,dataInicio);
            Adiconar(nome, email, plano, valor, dataInicio);
        }

        public void Adiconar(string nome, string email,PlanoEnum plano,double valor,DateTime dataInicio)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Email = email;
            DataInicio = dataInicio;
            Plano = plano;
            Valor = valor;
            Status = true;
        }

        public void Editar(string nome,PlanoEnum plano,double valor)
        {
            Validacao.ValidarNome(nome);
            Validacao.ValidarValor(valor);

            Nome= nome;
            Plano= plano;
            Valor= valor;
        }

        public bool Ativa() => Status = true;

        public bool Desativa() => Status = false;

        public int TempoAssinaturaEmMeses => CalcularMeses();

        private int CalcularMeses()
        {
            var meses = ((DateTime.Now.Year - DataInicio.Year) * 12) + DateTime.Now.Month - DataInicio.Month;
            return meses <= 0 ? 1 : meses; 
        }

    }
}
