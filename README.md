# M3P-BackEnd-Squad1

# LABSchool-Manager REST API com SQL SERVER

REST API com integração ao SQL SERVER para sistema de gerenciamento de uma escola, com as seguintes tabelas relacionadas: 
1. Usuario
2. Endereço
3. Atendimento
4. Avaliação
5. Exercício
6. WhiteLabel
7. Log

## Tecnologias

Lista de tecnologias utilizadas no desenvolvimento do projeto:

- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/)
- [ASP.NET Core](https://learn.microsoft.com/pt-br/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-7.0)
- [EntityFrameworkCore](https://learn.microsoft.com/en-us/ef/)
- [Fluent API](https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties)
- [AutoMapper](https://automapper.org/)
- [Data Annotation](https://learn.microsoft.com/pt-br/aspnet/mvc/overview/older-versions-1/models-data/validation-with-the-data-annotation-validators-cs)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-2022)
- [MVC Pattern](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)


## Data Model

Modelo Entidade Relacionamento desenvolvido para a criação do banco de dados:

[DER-FINAL-SQUAD1.pdf](https://github.com/FullStack-Estreito/M3P-BackEnd-Squad1/files/13199388/DER-FINAL-SQUAD1.pdf)

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) instalado e configurado

## Instalação

1. Clone o repositório: `git clone https://github.com/FullStack-Estreito/M3P-BackEnd-Squad1.git`
2. Navegue até o diretório do projeto: `cd LabSchoolAPI`
3. Restaure as dependências: `dotnet restore`
4. Execute as migrações do banco de dados para configurar o SQL Server:
4.1.`dotnet ef add migrations inicial`
4.2. `dotnet ef database update`
5. Execute a aplicação: `dotnet run`

## Uso

- Acesse a API através de `http://localhost:5203/swagger`
