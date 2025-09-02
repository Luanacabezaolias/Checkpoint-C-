# ProcessadorTxtAsync

Aplicação Console em **C# (.NET 8)** para processamento assíncrono de arquivos de texto.

## 📌 Funcionalidades
- Solicita ao usuário um diretório de entrada.
- Localiza todos os arquivos `.txt` no diretório.
- Processa cada arquivo de forma **assíncrona** com `async/await`.
- Conta **linhas** e **palavras** em cada arquivo.
- Gera um relatório consolidado em `./export/relatorio.txt`.

## 📂 Estrutura do Projeto
```
ProcessadorTxtAsync/
└── src/
    ├── Program.cs
    ├── ProcessadorTxtAsync.csproj
```

## ▶️ Como Executar

1. **Clonar ou extrair o projeto**
   ```bash
   unzip ProcessadorTxtAsync.zip
   cd ProcessadorTxtAsync/src
   ```

2. **Compilar e executar**
   ```bash
   dotnet run
   ```

3. **Interação**
   - O programa pedirá um caminho de diretório.
   - Listará os arquivos `.txt` encontrados.
   - Processará cada arquivo de forma assíncrona, mostrando progresso.
   - Criará o relatório em:
     ```
     ./export/relatorio.txt
     ```

## 📄 Exemplo de Saída
```
=== Processador de Arquivos de Texto ===
Informe o diretório onde estão os arquivos .txt: C:\arquivos

Arquivos encontrados:
 - teste1.txt
 - teste2.txt

Iniciando processamento...

Processando arquivo teste1.txt...
Processando arquivo teste2.txt...

Processamento concluído!
Relatório gerado em: .../export/relatorio.txt
```


