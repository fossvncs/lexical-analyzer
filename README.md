
# Validador de Expressões Lógicas

Este é um programa desenvolvido em C# para validar expressões de lógica proposicional escritas em LaTeX, verificando se estão **lexical e gramaticalmente corretas**. O programa lê um arquivo de texto contendo expressões lógicas e valida se as expressões estão de acordo com as regras de produção fornecidas.

## Requisitos

Antes de rodar o programa, você precisa ter o seguinte instalado:

- **.NET SDK**: Certifique-se de que o SDK do .NET esteja instalado. Você pode baixar e instalar a versão mais recente do .NET [aqui](https://dotnet.microsoft.com/download).
- **Editor de Texto**: Qualquer editor de texto para visualizar ou editar arquivos. O Visual Studio Code ou o Visual Studio são recomendados.

## Como Configurar e Rodar

### Passo 1: Clonar o Repositório

Primeiro, clone o repositório do projeto ou baixe o código-fonte.

```bash
git clone https://github.com/fossvncs/lexical-analyzer.git
```

### Passo 2: Restaurar Dependências

Abra o terminal ou prompt de comando na pasta do projeto e execute o comando para restaurar as dependências do projeto:

```bash
dotnet restore
```

### Passo 3: Compilar o Projeto

Compile o projeto para garantir que está tudo correto:

```bash
dotnet build
```

### Passo 4: Executar o Programa

Para rodar o programa, você precisa fornecer o caminho para o arquivo de entrada contendo as expressões lógicas. A primeira linha do arquivo deve conter um número inteiro indicando quantas expressões estão no arquivo.

Use o comando abaixo para rodar o programa:

```bash
dotnet run -- caminho/do/arquivo.txt
```

### Estrutura do Arquivo de Entrada

O arquivo de entrada deve ter o seguinte formato:

1. A primeira linha contém um número inteiro, representando a quantidade de expressões lógicas.
2. As linhas seguintes contêm as expressões lógicas a serem validadas.

Exemplo de arquivo de entrada (`arquivo.txt`):

```
5
true
false
( \neg 1p )
( \wedge 1x false )
( \rightarrow ( \neg 2a ) ( \vee 3b 4c ) )
```

### Saída do Programa

O programa imprimirá no terminal se cada expressão é **válida** ou **inválida**. Exemplo de saída:

```
valida
valida
valida
valida
valida
```
