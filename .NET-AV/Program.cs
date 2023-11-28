using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Exemplo de utilização
        List<Treinador> treinadores = new List<Treinador>
        {
            new Treinador("Treinador-01", new DateTime(1990, 1, 1), "12345678901", "CREF123"),
            new Treinador("Treinador-02", new DateTime(1985, 5, 5), "98765432101", "CREF456"),
            new Treinador("Treinador-03", new DateTime(1988, 1, 1), "12345678901", "CREF321"),
            new Treinador("Treinador-04", new DateTime(1987, 5, 5), "98765432101", "CREF654"),
        };

        List<Cliente> clientes = new List<Cliente>
        {
            new Cliente("Cliente1", new DateTime(1995, 2, 15), "11122233344", 1.75, 70),
            new Cliente("Cliente2", new DateTime(1988, 8, 10), "22233344455", 1.65, 60),
        };

        
        var relatorioTreinadores = Relatorios.TreinadoresComIdadeEntre(treinadores, 30, 40);
        var relatorioClientes = Relatorios.ClientesComIdadeEntre(clientes, 25, 35);
        var relatorioIMC = Relatorios.ClientesComIMCMaiorQue(clientes, 22);
        var relatorioOrdemAlfabetica = Relatorios.ClientesEmOrdemAlfabetica(clientes);
        var relatorioMaisVelhoParaMaisNovo = Relatorios.ClientesDoMaisVelhoParaMaisNovo(clientes);
        var relatorioAniversariantes = Relatorios.AniversariantesDoMes(treinadores, clientes, 2);

        Console.WriteLine("\nRELATORIO GERAL - ACADEMIA");
        Console.WriteLine("\nTreinadores com idade entre 30 e 40 anos:");
        foreach (var treinador in relatorioTreinadores)
        {
            Console.WriteLine($"{treinador.Nome}, {treinador.Idade} anos");
        }

        Console.WriteLine("\nClientes com idade entre 25 e 35 anos:");
        foreach (var cliente in relatorioClientes)
        {
            Console.WriteLine($"{cliente.Nome}, {cliente.Idade} anos");
        }

        Console.WriteLine("\nClientes com IMC maior que 22:");
        foreach (var cliente in relatorioIMC)
        {
            Console.WriteLine($"{cliente.Nome}, IMC: {cliente.CalcularIMC()}");
        }

        Console.WriteLine("\nClientes em ordem alfabética:");
        foreach (var cliente in relatorioOrdemAlfabetica)
        {
            Console.WriteLine(cliente.Nome);
        }

        Console.WriteLine("\nClientes do mais velho para o mais novo:");
        foreach (var cliente in relatorioMaisVelhoParaMaisNovo)
        {
            Console.WriteLine($"{cliente.Nome}, {cliente.Idade} anos");
        }

        Console.WriteLine("\nAniversariantes do mês:");
        foreach (var pessoa in relatorioAniversariantes)
        {
            Console.WriteLine($"{pessoa.Nome}, {pessoa.DataNascimento.Day}/{pessoa.DataNascimento.Month}");
            Console.WriteLine("\n");
        }
    }
}

class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public int Idade => DateTime.Now.Year - DataNascimento.Year;

    public Pessoa(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }
}

class Treinador : Pessoa
{
    public string CPF { get; set; }
    public string CREF { get; set; }

    public Treinador(string nome, DateTime dataNascimento, string cpf, string cref)
        : base(nome, dataNascimento)
    {
        CPF = cpf;
        CREF = cref;
    }
}

class Cliente : Pessoa
{
    public string CPF { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }

    public Cliente(string nome, DateTime dataNascimento, string cpf, double altura, double peso)
        : base(nome, dataNascimento)
    {
        CPF = cpf;
        Altura = altura;
        Peso = peso;
    }

    public double CalcularIMC() => Peso / (Altura * Altura);
}

static class Relatorios
{
    public static IEnumerable<Treinador> TreinadoresComIdadeEntre(List<Treinador> treinadores, int idadeMin, int idadeMax)
    {
        return treinadores.Where(t => t.Idade >= idadeMin && t.Idade <= idadeMax);
    }

    public static IEnumerable<Cliente> ClientesComIdadeEntre(List<Cliente> clientes, int idadeMin, int idadeMax)
    {
        return clientes.Where(c => c.Idade >= idadeMin && c.Idade <= idadeMax);
    }

    public static IEnumerable<Cliente> ClientesComIMCMaiorQue(List<Cliente> clientes, double imcMin)
    {
        return clientes.Where(c => c.CalcularIMC() > imcMin).OrderBy(c => c.CalcularIMC());
    }

    public static IEnumerable<Cliente> ClientesEmOrdemAlfabetica(List<Cliente> clientes)
    {
        return clientes.OrderBy(c => c.Nome);
    }

    public static IEnumerable<Cliente> ClientesDoMaisVelhoParaMaisNovo(List<Cliente> clientes)
    {
        return clientes.OrderByDescending(c => c.Idade);
    }

    public static IEnumerable<Pessoa> AniversariantesDoMes(List<Treinador> treinadores, List<Cliente> clientes, int mes)
    {
        var aniversariantesTreinadores = treinadores.Where(t => t.DataNascimento.Month == mes);
        var aniversariantesClientes = clientes.Where(c => c.DataNascimento.Month == mes);
        return aniversariantesTreinadores.Cast<Pessoa>().Concat(aniversariantesClientes);
    }
}
