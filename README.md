# 🧹 Clean Code Refactor - Sistema de Reservas

Projeto de refatoração de um sistema de reservas originalmente implementado em Python, agora convertido para uma **API ASP.NET Core** com foco em **Clean Code**, **boas práticas de arquitetura** e **testabilidade**.

---

## 📦 Descrição do Software

Este sistema permite:

- Cadastro de clientes com CPF validado.
- Criação de reservas com cálculo automático de valor total.
- Operações de check-in, check-out e cancelamento de reservas.
- Consulta de reservas por status e CPF.
---

## 🔍 Análise dos Problemas Detectados no Código Original (Python)

| Problema | Descrição |
|----------|-----------|
| Acoplamento excessivo | Toda a lógica agrupada em um único arquivo. |
| Persistência em arquivos | Uso de `.txt` para armazenar reservas, check-ins, etc. |
| Falta de abstração | Nenhuma separação de responsabilidades (dados, lógica e I/O misturados). |
| Validação de CPF fraca | Apenas verificava comprimento e números. |
| Repetição de código | Gravação e leitura repetidas para cada operação. |
| Dados duplicados | CPF repetido em reservas, sem entidade cliente. |
| Sem testes | Código não testável. |

---

## 🔧 Estratégia de Refatoração

- Separação clara entre **camadas**: Controllers, Services, Repositories, Models e ViewModels.
- Criação de **entidades reais** com relacionamentos (Cliente ↔ Reserva).
- Uso de **EF Core + SQLite** com migrations e DI.
- Criação de DTOs para entrada e saída de dados.
- Implementação de **validador real de CPF**.
- Registro dinâmico de serviços com **Dependency Injection baseada em interfaces genéricas**.

---

## 🔁 ChangeLog

Veja [CHANGELOG.md](CHANGELOG.md) para detalhes das alterações por versão.

---

## 🧪 Testes Implementados

- **Validação de CPF**: testes para validar corretamente CPFs reais e falsos.
- **Cálculo de valor da reserva**: testes com combinações de tipos de quarto, número de pessoas e diárias.
- **ReservaService**: testes para criação, verificação de disponibilidade e tratamento de fila.
- **Testes com `xUnit` e mocks (`Moq`)** para repositórios.

---

## 🗣️ Interface Fluente

A interface fluente poderia ser preparada com uma nova classe chamada ResultExtensions, dessa forma:

```csharp
public static class ResultExtensions
{
    public static Result OnSuccess(this Result  result, Action action)
    {
        if (result.Success) action();
        return result;
    }

    public static Result<T> OnSuccess<T>(this Result<T> result, Func<T, T> func)
    {
        if (result.Success)
        {
            var newValue = func(result.Value!);
            return Result.SetSuccess(newValue);
        }

        return result;
    }

    public static Result OnFailure(this Result result, Action<List<Error>> action)
    {
        if (!result.Success) action(result.Errors);
        return result;
    }
}
```

Utilizada dessa forma:

```csharp
var result = Result.Create("João", "nome")
    .OnSuccess(nome => nome.Trim())
    .OnFailure(errors => LogErros(errors));
```

---

## 🚀 Instalação e Execução

### 🔧 Requisitos

- .NET 8 SDK

### 🔤 Rodando localmente

1. Clone o repositório:
   ```bash
   git clone https://github.com/luigimilanez/Projeto-Final-CleanCode.git
   cd clean-code-refactor
   ```

2. Restaure os pacotes e crie a migration:
   ```bash
   dotnet restore
   dotnet ef migrations add Inicial
   dotnet ef database update
   dotnet run
   ```
