### Gym Membership Web Api Project Sample.

This project's main goal was learning Domain Driven Design (DDD) and Clean Architecture. It is a sample project that implements a Gym Membership Web Api. It is a simple project that has a few endpoints to manage gym memberships. It is a work in progress and will be updated as I learn more about DDD and Clean Architecture.

Visit <a href="/Docs/">docs</a> folder for more information about the project.

## Technologies

- .NET 6
- ASP.NET Core 6.0.320
- CQRS
- Dapper
- MediatR
- ErrorOr
- FluentValidation
- Mapper"
- Swagger
- Bcrypt
- JWT
- Redis (Ongoing)


## Features

- [x] DDD (Domain Driven Design)
- [x] Clean Architecture
- [x] CQRS (Command Query Responsibility Segregation)
- [x] Database Sql Express Server 2019
- [x] Repository Pattern (Dapper)
- [ ] Redis Cache <- Ongoing -> 


## Getting Started

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/IbrahimSabriOrene/GymMembershipWebApi.git

    ```

2. Run the project
    ```sh
    dotnet run --project .\MemberInfo.Api\
    ```

## Usage

### Swagger

```sh
    https://localhost:{{port}}/swagger/index.html
```

## Http Request
```text

    Go to the Request folder and import the requests to Postman
```
## Roadmap

Currently, the project is in the early stages of development. The following features are planned to be implemented in the future:

- [ ] Redis Cache
- [ ] Unit Tests
- [ ] Integration Tests
- [ ] Docker
- [ ] Kubernetes
- [ ] CI/CD
- [ ] Frontend (Angular, React, Vue)
- [ ] Mobile App (Xamarin, Flutter)
- [ ] Desktop App (WPF, WinForms)