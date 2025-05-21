# 📑 CHANGELOG

## [v1.0.0] - 2024-05-21

### Adicionado
- Estrutura de API em ASP.NET Core 8.0 com camadas bem definidas.
- Models: Cliente, Reserva, TipoQuartoEnum, StatusReserva.
- Validador real de CPF com algoritmo oficial.
- Cálculo automático de valor total da reserva.
- DTOs para entrada e saída de dados.
- Repository Pattern com EF Core.
- Service Layer para lógica de negócio.
- Documentação de código com comentários e resumo.

### Corrigido
- Redundância de dados (CPF duplicado em Reserva).
- Lógica de negócio duplicada em múltiplos lugares.

### Removido
- Armazenamento em arquivos `.txt`.
- Lógica misturada entre controle, dados e persistência.
