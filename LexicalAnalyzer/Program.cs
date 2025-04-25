using System.Diagnostics.Metrics;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Uso: dotnet run <expressoes.txt>");
            return;
        }

        var caminho = args[0];
        if (!File.Exists(caminho))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return;
        }

        string[] linhas = File.ReadAllLines(caminho);
        if (linhas.Length == 0 || !int.TryParse(linhas[0].Trim(), out int quantidade))
        {
            Console.WriteLine("Arquivo inválido. A primeira linha deve conter um número.");
            return;
        }

        var lines = File.ReadAllLines(caminho);
        string primeiraLinha = linhas[0];

        if (int.Parse(primeiraLinha) != (linhas.Length - 1))
        {
            Console.WriteLine("Número de expressões no arquivo não corresponde ao valor indicado na primeira linha.");
            return;
        }

        for (int i = 1; i <= quantidade && i < linhas.Length; i++)
        {
            var linha = linhas[i];
            var tokens = Lexer.Analisar(linha);
            bool valido = Parser.Validar(tokens);
            Console.WriteLine(valido ? "valida" : "inválida");
        }
    }
}