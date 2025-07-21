namespace ContaBancaria
{
    public class ContaCorrente : Conta, ITributavel
    {


        public decimal LimiteChequeEspecial { get; set; }

        // O construtor apenas repassa os dados para o construtor da classe-mãe.
        public ContaCorrente(string numero, string titular, decimal saldo, decimal limite)
            : base(numero, titular, saldo)
        {
            LimiteChequeEspecial = limite;
        }


        public override void Sacar(decimal valor)
        {
            Console.WriteLine($"Tentativa de saque valor: {valor:c} na conta {this.GetType().Name} de {Titular}");
            if (valor <= 0)
            {
                Console.WriteLine("Valor de saque inválido!");
                return;
            }
            if (valor > Saldo + (decimal)LimiteChequeEspecial)
            {
                Console.WriteLine("Saldo insuficiente, incluindo o cheque especial.");
                return;
            }
            Saldo -= valor;
            if (Saldo < 0)
            {
                LimiteChequeEspecial -= (decimal)(-Saldo);
                Saldo = 0;

            }
            Console.WriteLine($"Saque de {valor:c} realizado com sucesso! Saldo atual: {this.Saldo} , limite cheque especial : {this.LimiteChequeEspecial}");
        }

        public double CalcularImposto()
        {
            return (double)Saldo * 0.02; // Exemplo de cálculo de imposto: 2% do saldo
        }
    }

}

