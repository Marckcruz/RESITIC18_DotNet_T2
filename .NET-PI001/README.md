# INSTRUÇÃO PRÁTICA .NET-P001
## Marcelo da Silva Cruz


### 1. Configuração do Ambiente:

#### Problema: Como você pode verificar se o .NET SDK está corretamente instalado em seu sistema? Em um arquivo de texto ou Markdown, liste os comandos que podem ser usados para verificar a(s) versão(ões) do .NET SDK instalada(s), como remover e atualizar.

#### Ver:
 - dotnet --version

#### Listar Versões Instalado:
 - dotnet --list-sdks

#### Atualizar o .NET SDK:

##### Verificar a versão instalada atualmente
 - dotnet --version  # 
 - dotnet --list-sdks  

#####  Listar as versões instaladas
 - dotnet --list-runtimes  
 
 
##### Listar runtimes instalados (opcional)
 - dotnet --
 

##### Atualizar para a versão mais recente (substitua x.y.z pela versão desejada)
 - dotnet --install-sdk x.y.z
 - dotnet --install-sdk

#### Rem -  Remover uma versão específica (substitua x.y.z pela versão a ser removida)
 - dotnet --uninstall-sdk x.y.z
 - dotnet --un

### 2. Tipos de Dados:
#### Problema: Quais são os tipos de dados numéricos inteiros disponíveis no .NET? Dê exemplos de uso para cada um deles através de exemplos.

- byte: Representa valores inteiros sem sinal de 0 a 255.

   Exemplo:

      byte meuByte = 200;
- sbyte: Representar. 

    Exemplo:
    
      sbyte meuSByte = -30;

- short: Representa valores inteiros
    
    Exemplo:
    
      short meuShort = 15000;

- ushort: Representa valores

    Exemplo:

      ushort meuUShort = 60000

- int: Representa valores
    
    Exemplo:

      int meuInt = 1000000;

- uint: Representa valores inteiros sem sinal de 0 a
    
    Exemplo

      uint meuUInt = 3000000000;

      
- long: Representar
    
    Exemplo

      long meuLong = 9000000000000000000;

- ulong:  Representar

    Exemplo

      ulong meuULong = 15000000000000000000;


### 3. Conversão de Tipos de Dados:

#### Problema: Suponha que você tenha uma variável do tipo double e deseja convertê-la em um tipo int. Como você faria essa conversão e o que aconteceria se a parte fracionária da variável double não pudesse ser convertida em um int? Resolva o problema através de um exemplo em C#.

    using System;

     class Program
    {
    static void Main()
    {
        // Variável do tipo double
        double numeroDouble = 10.75;

        // Conversão para int usando casting
        int numeroInteiro = (int)numeroDouble;

        // Exibição dos resultados
        Console.WriteLine($"Número Double: {numeroDouble}");
        Console.WriteLine($"Número Inteiro: {numeroInteiro}");
     }
    }

##### Neste exemplo:
##### 'numeroDouble' é converter 'int" usando o (int)numeroDouble. 
      Número Double: 10.75
      Número Inteiro: 10
##### A parte fracionária (0,75) é truncada durante a conversão, resultando no número inteiro 10.
##### Se a parte fracionária não puder ser convertida em um int, o compilador não gerará um erro, mas simplesmente truncará a parte decimal. Então, por exemplo, se numeroDoublefosse 10.99, a conversãoia em 10, sem qualquer aviso ou erro durante a compilação ou execução.

### 4. Operadores Aritméticos:
#### Problema: Dada a variável int x = 10 e a variável int y = 3, escreva código para calcular e exibir o resultado da adição, subtração, multiplicação e divisão de x por y.
      using System;

      class Program
    {
           static void Main()
    {
        // Variáveis
        int x = 10;
        int y = 3;

        // Operações
        int soma = x + y;
        int subtracao = x - y;
        int multiplicacao = x * y;
        
        // Verificar se a divisão é por zero antes de realizar a operação
        int divisao = (y != 0) ? (x / y) : 0;

        // Exibição dos resultados
        Console.WriteLine($"Adição: {soma}");
        Console.WriteLine($"Subtração: {subtracao}");
        Console.WriteLine($"Multiplicação: {multiplicacao}");
        Console.WriteLine($"Divisão: {divisao}");
      }
    }

##### Resultado
    Adição: 13
    Subtração: 7
    Multiplicação: 30
    Divisão: 3

### 5. Operadores de Comparação:
#### Problema: Considere as variáveis int a = 5 e int b = 8. Escreva código para determinar se a é maior que b e exiba o resultado.
    using System;

    class Program
    {
    static void Main()
        {
        // Variáveis
        int a = 5;
        int b = 8;

        // Verificar se a é maior que b
        bool aMaiorQueB = a > b;

        // Exibir o resultado
        Console.WriteLine($"a é maior que b? {aMaiorQueB}");
        }
    }

##### Resultado:
    a é maior que b? False

### 6. Operadores de Igualdade:
#### Problema: Você tem duas strings, string str1 = "Hello" e string str2 = "World". Escreva código para verificar se as duas strings são iguais e exibir o resultado.
using System;

    class Program
    {  
    static void Main()
      {
        // Strings
        string str1 = "Hello";
        string str2 = "World";

        // Verificar se as strings são iguais
        bool saoIguais = str1 == str2;

        // Exibir o resultado
        Console.WriteLine($"As strings são iguais? {saoIguais}");
      }
    }


##### Resultado
    As strings são iguais? False


### 7. Operadores Lógicos:
#### Problema: Suponha que você tenha duas variáveis booleanas, bool condicao1 = true e bool condicao2 = false. Escreva código para verificar se ambas as condições são verdadeiras e exiba o resultado.
    using System;

    class Program
    {
    static void Main()
      {
        // Variáveis booleanas
        bool condicao1 = true;
        bool condicao2 = false;

        // Verificar se ambas as condições são verdadeiras
        bool ambasCondicoesVerdadeiras = condicao1 && condicao2;

        // Exibir o resultado
        Console.WriteLine($"Ambas as condições são verdadeiras? {ambasCondicoesVerdadeiras}");
      }
    }

##### Resultado:
    Ambas as condições são verdadeiras? False


### 8. Desafio de Mistura de Operadores:
#### Problema: Dadas as variáveis int num1 = 7, int num2 = 3, e int num3 = 10, escreva código para verificar se num1 é maior do que num2 e se num3 é igual a num1 + num2.
    using System;

    class Program
    {
    static void Main()
      {
        // Variáveis
        int num1 = 7;
        int num2 = 3;
        int num3 = 10;

        // Verificações
        bool num1MaiorQueNum2 = num1 > num2;
        bool num3IgualA SomaNum1Num2 = num3 == num1 + num2;

        // Exibir o resultado
        Console.WriteLine($"num1 é maior que num2? {num1MaiorQueNum2}");
        Console.WriteLine($"num3 é igual a num1 + num2? {num3IgualA SomaNum1Num2}");
      }
    }

##### Resultado
    num1 é maior que num2? True
    num3 é igual a num1 + num2? True
