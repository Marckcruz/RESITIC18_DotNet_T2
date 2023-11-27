using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    
    public record Produto(int Codigo, string Nome, int QuantidadeEmEstoque, double PrecoUnitario);

    
    static List<Produto> estoque = new List<Produto>();

    static void Main()
    {
        while (true)
        {
           Console.WriteLine(" ");
           Console.WriteLine("Sistema de Gerenciamento de Estoque - SIGES");
            Console.WriteLine(" ");
            Console.WriteLine("1. Cadastro de Produtos");
            Console.WriteLine("2. Consulta de Produtos");
            Console.WriteLine("3. Atualização de Estoque");
            Console.WriteLine("4. Relatórios");
            Console.WriteLine("5. Sair");
            
            Console.WriteLine(" ");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarProduto();
                    break;
                case 2:
                    ConsultarProduto();
                    break;
                case 3:
                    AtualizarEstoque();
                    break;
                case 4:
                    GerarRelatorios();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CadastrarProduto()
    {
        try
        {
            Console.Write("Código do produto: ");
            int codigo = int.Parse(Console.ReadLine());

            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Quantidade em estoque: ");
            int quantidade = int.Parse(Console.ReadLine());

            Console.Write("Preço unitário: ");
            double preco = double.Parse(Console.ReadLine());

            
            estoque.Add(new Produto(codigo, nome, quantidade, preco));

            Console.WriteLine("Produto cadastrado com sucesso!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir os dados corretamente.");
        }
    }

    static void ConsultarProduto()
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());

        try
        {
            
            Produto produto = estoque.First(p => p.Codigo == codigo);

            Console.WriteLine($"Nome: {produto.Nome}");
            Console.WriteLine($"Quantidade em estoque: {produto.QuantidadeEmEstoque}");
            Console.WriteLine($"Preço unitário: {produto.PrecoUnitario}");
        }
        catch (InvalidOperationException)
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
        }
    }

    static void AtualizarEstoque()
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());

        try
        {
            Produto produto = estoque.First(p => p.Codigo == codigo);

            Console.Write("Digite a quantidade a ser adicionada (+) ou removida (-): ");
            int quantidadeAtualizacao = int.Parse(Console.ReadLine());

            
            if (produto.QuantidadeEmEstoque + quantidadeAtualizacao < 0)
            {
                Console.WriteLine("Erro: Estoque insuficiente para a saída desejada.");
            }
            else
            {
                produto = produto with { QuantidadeEmEstoque = produto.QuantidadeEmEstoque + quantidadeAtualizacao };
                Console.WriteLine("Estoque atualizado com sucesso!");
            }
        }
        catch (InvalidOperationException)
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir os dados corretamente.");
        }
    }

    static void GerarRelatorios()
    {
        
        Console.Write("Informe o limite de quantidade em estoque: ");
        int limiteQuantidade = int.Parse(Console.ReadLine());
        var relatorio1 = estoque.Where(p => p.QuantidadeEmEstoque < limiteQuantidade);
        ImprimirRelatorio("Produtos com estoque abaixo do limite:", relatorio1);

        
        Console.Write("Informe o valor mínimo: ");
        double minValor = double.Parse(Console.ReadLine());
        Console.Write("Informe o valor máximo: ");
        double maxValor = double.Parse(Console.ReadLine());
        var relatorio2 = estoque.Where(p => p.PrecoUnitario >= minValor && p.PrecoUnitario <= maxValor);
        ImprimirRelatorio("Produtos com valor entre mínimo e máximo:", relatorio2);

        
        double valorTotalEstoque = estoque.Sum(p => p.QuantidadeEmEstoque * p.PrecoUnitario);
        Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

        Console.WriteLine("Valor total de cada produto:");
        foreach (var produto in estoque)
        {
            Console.WriteLine($"{produto.Nome}: {produto.QuantidadeEmEstoque * produto.PrecoUnitario:C}");
        }
    }

    static void ImprimirRelatorio(string titulo, IEnumerable<Produto> produtos)
    {
        Console.WriteLine(titulo);
        foreach (var produto in produtos)
        {
            Console.WriteLine($"Código: {produto.Codigo}, Nome: {produto.Nome}, Quantidade em Estoque: {produto.QuantidadeEmEstoque}, Preço Unitário: {produto.PrecoUnitario:C}");
        }
        Console.WriteLine();
    }
}


class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string mensagem) : base(mensagem)
    {
    }
}
