# LeadsService Backend

## Visão Geral

Este projeto representa o backend da aplicação LeadsService, estruturado segundo os princípios do DDD (Domain-Driven Design). Ele é desenvolvido em .NET e utiliza Entity Framework Core para interação com o banco de dados SQL Server.
Desenvolvido por: Alexandre Bento Pereira

## Estrutura do Projeto

```
LeadsService/
│── API/
│   ├── Controllers/        # Controladores da API
│
│── Application/
│   ├── DTOs/              # Data Transfer Objects
│   ├── Interfaces/        # Interfaces dos serviços
│   ├── Mappings/          # Configuração do AutoMapper
│   ├── Services/          # Implementação dos serviços
│
│── Domain/
│   ├── Entities/          # Entidades de domínio
│   ├── Enums/             # Definições de enums
│   ├── Interfaces/        # Interfaces de domínio
│
│── Infrastructure/
│   ├── Data/              # Configuração do contexto do banco de dados
│   ├── Migrations/        # Arquivos de migração do Entity Framework
│   ├── Repositories/      # Implementação dos repositórios
│
│── appsettings.json       # Configurações da aplicação
│── docker-compose.yml     # Arquivo Docker Compose para configuração do ambiente
│── Dockerfile             # Dockerfile para containerização do backend
│── Program.cs             # Ponto de entrada da aplicação
```

## Requisitos

- .NET 7 ou superior
- Docker e Docker Compose (opcional para execução via containers)
- Banco de dados SQL Server

## Configuração

### 1. Configuração Geral

1. Configure o banco de dados no arquivo `appsettings.json`, basta criar um arquivo com este nome na raiz do projeto e adicionar o código abaixo:
   ```json
   {
        "ConnectionStrings": {
            "DefaultConnection": "Server=localhost,1433;Database=LeadsDB;User Id=sa;Password=ServiceDB123;TrustServerCertificate=True;"
        }
   }
   ```

### 2. Executando local

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/LeadsService.git
   cd LeadsService
   ```
2. Rode a aplicação:
   ```sh
   dotnet run
   ```
3. Execute as migrações (caso necessário, pois o sistema já faz isso ao ser iniciado):
   ```sh
   dotnet ef database update
   ```

### 3. Executando com Docker

1. Construir a imagem do backend:
   ```sh
   docker build -t leadsservice-backend .
   ```
2. Subir os containers com Docker Compose:
   ```sh
   docker-compose up --build -d
   ```

## Endpoints Principais

A API estará disponível em `http://localhost:5000/swagger` para visualização e testes.

### LeadsController

- **GET /api/leads** → Retorna todos os leads
- **POST /api/leads** → Cria um novo lead
- **PUT /api/leads/{id}** → Atualiza um lead existente
- **GET /api/leads/accepted** → Retorna os leads aceitos

## Contribuição

Sinta-se à vontade para abrir issues e enviar pull requests para melhorias.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

