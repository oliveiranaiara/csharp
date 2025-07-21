using System;

namespace ContaBancaria;
public class Conta
{

    //acessível pela classe base e pelas classes (derivadas) filhas
    protected double _saldo;


    public string? Numero { get; set; }
    public string? Titular { get; set; }

    public decimal Saldo { get; set; }


    //Construtor

    public Conta(string numero, string titular, decimal saldo)
    {
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
    }


    //Métodos  - Action - Função

    public void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso. Novo saldo: {Saldo:C}");
        }
        else
        {
            Console.WriteLine("Valor de depósito inválido. O valor deve ser maior que zero.");
        }

    }

    public virtual void Sacar(decimal valor)
    {
        if (valor <= 0)
        {
            throw new ArgumentException("VAlopr deve ser positivo");
        }
        if (valor > Saldo)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.");
        }
        Saldo -= valor;

    }


    public void ExibirSaldo()
    {
        Console.WriteLine($"Saldo atual: {Saldo:C}");
    }



}