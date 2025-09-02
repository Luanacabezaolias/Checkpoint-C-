using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Processador de Arquivos de Texto ===");

        Console.Write("Informe o diretório onde estão os arquivos .txt: ");
        string? dir = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(dir) || !Directory.Exists(dir))
        {
            Console.WriteLine("Diretório inválido!");
            return;
        }

        // Busca arquivos .txt
        string[] arquivos = Directory.GetFiles(dir, "*.txt");
        if (arquivos.Length == 0)
        {
            Console.WriteLine("Nenhum arquivo .txt encontrado.");
            return;
        }

        Console.WriteLine("\nArquivos encontrados:");
        foreach (var arq in arquivos)
        {
            Console.WriteLine($" - {Path.GetFileName(arq)}");
        }

        Console.WriteLine("\nIniciando processamento...\n");

        // Processa todos os arquivos em paralelo (async/await)
        var tarefas = arquivos.Select(ProcessarArquivo).ToList();
        var resultados = await Task.WhenAll(tarefas);

        // Gera relatório
        string pastaExport = Path.Combine(AppContext.BaseDirectory, "export");
        Directory.CreateDirectory(pastaExport);

        string relatorioPath = Path.Combine(pastaExport, "relatorio.txt");

        await File.WriteAllLinesAsync(relatorioPath, resultados);

        Console.WriteLine($"\nProcessamento concluído!");
        Console.WriteLine($"Relatório gerado em: {relatorioPath}");
    }

    static async Task<string> ProcessarArquivo(string caminho)
    {
        string nomeArquivo = Path.GetFileName(caminho);
        Console.WriteLine($"Processando arquivo {nomeArquivo}...");

        // Lê todas as linhas
        var linhas = await File.ReadAllLinesAsync(caminho);
        int qtdLinhas = linhas.Length;

        // Conta palavras (separadas por espaço em branco)
        int qtdPalavras = linhas.Sum(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length);

        string resultado = $"{nomeArquivo} - {qtdLinhas} linhas - {qtdPalavras} palavras";
        return resultado;
    }
}
