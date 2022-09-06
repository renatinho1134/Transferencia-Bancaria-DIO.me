using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBancario
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private string Nome {get; set;}
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta TipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta = TipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double ValorSaque)
        {
            if(this.Saldo - ValorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            else
            {
                this.Saldo -= ValorSaque;
                Console.WriteLine("O saldo da conta {0} é de {1} reais", this.Nome, this.Saldo);
                return true;
            }
        }

        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine("O Valor atual da conta {0} é de: {1}", this.Nome, this.Saldo);
        }

        public void transferir(double ValorTransferencia, Conta ContaDestino)
        {
            if(this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Credito " + this.Credito; 
            return retorno;
        }
    }
}