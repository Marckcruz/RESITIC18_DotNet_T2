using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===== Sistema de Gerenciamento de Tarefas =====");
            Console.WriteLine(" ");
            Console.WriteLine("1. Criar Tarefa");
            Console.WriteLine("2. Listar Todas as Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Listar Tarefas Pendentes");
            Console.WriteLine("5. Listar Tarefas Concluídas");
            Console.WriteLine("6. Excluir Tarefa");
            Console.WriteLine("7. Pesquisar Tarefas por Palavra-Chave");
            Console.WriteLine("8. Exibir Estatísticas");
            Console.WriteLine("0. Sair");
            Console.WriteLine(" ");
            Console.WriteLine("==============================================");
            Console.WriteLine(" ");

            Console.Write("Escolha uma opção: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    CreateTask();
                    break;
                case 2:
                    ListAllTasks();
                    break;
                case 3:
                    MarkTaskAsCompleted();
                    break;
                case 4:
                    ListPendingTasks();
                    break;
                case 5:
                    ListCompletedTasks();
                    break;
                case 6:
                    DeleteTask();
                    break;
                case 7:
                    SearchTasksByKeyword();
                    break;
                case 8:
                    DisplayStatistics();
                    break;
                case 0:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void CreateTask()
    {
        Console.Write("Digite o título da tarefa: ");
        string title = Console.ReadLine();
        Console.Write("Digite a descrição da tarefa: ");
        string description = Console.ReadLine();
        
        DateTime dueDate;
        while (true)
        {
            Console.Write("Digite a data de vencimento (dd-MM-yyyy): ");
            if (DateTime.TryParse(Console.ReadLine(), out dueDate))
            {
                if (dueDate >= DateTime.Now)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("A data de vencimento não pode ser no presente ou passado. Tente novamente.");
                }
            }
            else
            {
                Console.WriteLine("Formato de data inválido. Tente novamente.");
            }
        }

        Task newTask = new Task(title, description, dueDate);
        tasks.Add(newTask);

        Console.WriteLine("Tarefa criada com sucesso!");
        Console.WriteLine("\n\n");
        

    }

    static void ListAllTasks()
    {
        Console.WriteLine(" ");
        Console.WriteLine("===== Lista de Todas as Tarefas =====");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine();
    }

    static void MarkTaskAsCompleted()
    {
        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks[taskNumber].MarkAsCompleted();
                Console.WriteLine("Tarefa marcada como concluída!");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Digite um número válido.");
        }
    }

    static void ListPendingTasks()
    {
        Console.WriteLine(" ");
        Console.WriteLine("===== Lista de Tarefas Pendentes =====");
        var pendingTasks = tasks.Where(t => !t.IsCompleted);
        foreach (var task in pendingTasks)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine();
    }

    static void ListCompletedTasks()
    {
        Console.WriteLine("===== Lista de Tarefas Concluídas =====");
        var completedTasks = tasks.Where(t => t.IsCompleted);
        foreach (var task in completedTasks)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine();
    }

    static void DeleteTask()
    {
        Console.Write("Digite o número da tarefa a ser excluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber))
        {
            if (taskNumber >= 0 && taskNumber < tasks.Count)
            {
                tasks.RemoveAt(taskNumber);
                Console.WriteLine("Tarefa excluída com sucesso!");
            }
            else
            {
                Console.WriteLine("Número de tarefa inválido. Tente novamente.");
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Digite um número válido.");
        }
    }

    static void SearchTasksByKeyword()
    {
        Console.Write("Digite a palavra-chave para a pesquisa: ");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine("===== Resultados da Pesquisa =====");
        var searchResults = tasks.Where(t => t.Title.ToLower().Contains(keyword) || t.Description.ToLower().Contains(keyword));
        foreach (var task in searchResults)
        {
            Console.WriteLine(task);
        }
        Console.WriteLine();
    }

    static void DisplayStatistics()
    {
        int totalTasks = tasks.Count;
        int completedTasks = tasks.Count(t => t.IsCompleted);
        int pendingTasks = totalTasks - completedTasks;

        DateTime oldestTaskDate = tasks.Min(t => t.DueDate);
        DateTime newestTaskDate = tasks.Max(t => t.DueDate);

        Console.WriteLine(""); 
        Console.WriteLine("===== Estatísticas ====="); 
        Console.WriteLine("\n");       
        Console.WriteLine($"Total de tarefas: {totalTasks}");
        Console.WriteLine($"Tarefas concluídas: {completedTasks}");
        Console.WriteLine($"Tarefas pendentes: {pendingTasks}");
        Console.WriteLine($"Tarefa mais antiga: {oldestTaskDate:dd-MM-yyyy}");
        Console.WriteLine($"Tarefa mais recente: {newestTaskDate:dd-MM-yyyy}");
        Console.WriteLine();
        Console.WriteLine("========================");
    }
}

class Task
{
    public string Title { get; }
    public string Description { get; }
    public DateTime DueDate { get; }
    public bool IsCompleted { get; private set; }

    public Task(string title, string description, DateTime dueDate)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = false;
    }

    public void MarkAsCompleted()
    {
        IsCompleted = true;
    }

    public override string ToString()
    {
        return $"Título: {Title}\nDescrição: {Description}\nData de Vencimento: {DueDate:dd-MM-yyyy}\nConcluída: {(IsCompleted ? "Sim" : "Não")}\n";
    }
}
