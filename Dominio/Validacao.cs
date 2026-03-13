using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public  class Validacao
    {
        public static void Validar(string nome, string email, double valor, DateTime dataInicio)
        {
           ValidarNome(nome);
           ValidarValor(valor);
           ValidaDataInicio(dataInicio);
           ValidarEmail(email);
        }

        public static void ValidarNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome é obrigatório.");
        }

        public static void ValidaDataInicio(DateTime dataInicio)
        {
            if (dataInicio > DateTime.Now)
                throw new ArgumentException("A data de início não pode ser maior que a data atual.");
        }

        public static void ValidarValor(double valor)
        {
            if (valor <= 0)
                throw new ArgumentException("O valor mensal da assinatura deve ser maior que 0.");
        }

        public static void ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("E-mail é obrigatorio.");

            try
            {
                var endereço = new System.Net.Mail.MailAddress(email);
                if (!email.Contains("."))
                    throw new Exception();
            }
            catch (Exception)
            {

                throw new ArgumentException("E-mail em formato Invalido.");
            }
        }
    }
}
