# GameStoreMVC - Loja de Games (E-commerce)

**Checkpoint 6** | FIAP - Engenharia de Software | C# Development | Turma 3ESPS

## Sobre o Projeto

E-commerce de games desenvolvido com **ASP.NET Core MVC**, integrando persistência de dados com **MySQL** e práticas modernas de segurança (**BCrypt** + **Claims**).

## Tecnologias

- **Framework:** ASP.NET Core 8.0 MVC
- **Banco de Dados:** MySQL + Entity Framework Core
- **Frontend:** Bootstrap 5 + Bootstrap Icons
- **Segurança:** BCrypt.Net (hash de senhas) + Cookie Authentication com Claims
- **Arquitetura:** MVC + Repository Pattern + Interfaces (IoC/DI)

## Estrutura do Projeto

```
GameStoreMVC/
├── Controllers/
│   ├── HomeController.cs
│   ├── LoginController.cs
│   └── GameController.cs
├── Models/
│   ├── Usuario.cs
│   ├── Game.cs
│   ├── LoginViewModel.cs
│   └── RegisterViewModel.cs
├── Views/
│   ├── Home/Index.cshtml
│   ├── Login/Index.cshtml
│   ├── Login/CriarConta.cshtml
│   ├── Game/Index.cshtml
│   ├── Game/Criar.cshtml
│   ├── Game/Editar.cshtml
│   └── Shared/_Layout.cshtml
├── Interfaces/
│   ├── IUsuarioRepository.cs
│   └── IGameRepository.cs
├── Repositories/
│   ├── UsuarioRepository.cs
│   └── GameRepository.cs
├── Data/
│   └── AppDbContext.cs
├── wwwroot/css/site.css
└── Program.cs
```

## Como Executar

### Pré-requisitos
- .NET 8.0 SDK
- MySQL Server (8.0+)

### 1. Configurar o Banco de Dados
```sql
CREATE DATABASE gamestoredb;
```

### 2. Configurar Connection String
Edite `appsettings.json`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=gamestoredb;User=root;Password=sua_senha;"
}
```

### 3. Executar
```bash
dotnet restore
dotnet run
```

### 4. Acesso Admin
| Campo | Valor |
|-------|-------|
| Email | admin@gamestore.com |
| Senha | admin123 |

## Segurança
- **BCrypt** para hash de senhas
- **Claims-based Authentication** (Name, Email, Role, UserId)
- **Cookie Authentication** com expiração de 8h
- **Autorização por Role** (Admin)
- **AntiForgeryToken** em todos os forms

## Equipe
- Thiago Araujo Vieira - RM553477
- Diana Letícia de Souza Inocencio -  RM553562
- João Viktor Carvalho de Souza - RM552613
- Lucas Reis Diniz - RM552838
- Victor Augusto Pereira dos Santos -  RM553518
- Vitor de Moura Nascimento - RM553806
