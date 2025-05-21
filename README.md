# Refatoração do Projeto de Cadastro de Reservas

Este projeto é uma refatoração em C# com ASP.NET Core de um sistema de cadastro de reservas originalmente desenvolvido em Python, durante a primeira fase da disciplina de Engenharia de Software. O objetivo é aplicar boas práticas da plataforma .NET, utilizando Entity Framework Core com SQLite como banco de dados.

## Tecnologias Utilizadas

- ASP.NET Core
- C#
- Entity Framework Core
- SQLite
- AutoMapper
- Moq

## Banco de Dados

O banco de dados utilizado é o SQLite, por ser leve e prático para projetos locais. Abaixo estão os comandos necessários para criar o banco de dados usando migrations do Entity Framework Core:

```bash
# Criar a primeira migration
dotnet ef migrations add Inicial

# Aplicar a migration e criar o banco de dados
dotnet ef database update

# Restaurar os pacotes
dotnet restore

# Executar a aplicação
dotnet run

A aplicação estará disponível em https://localhost:5001 ou http://localhost:5000, conforme a configuração padrão.