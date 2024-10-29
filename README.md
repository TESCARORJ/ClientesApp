# ClienteApp API
Projeto **ClienteApp API** desenvolvido com os conceitos de **DDD** (Domain-Driven Design), **TDD** (Test-Driven Development), e uma arquitetura orientada a eventos e mensageria. Este projeto segue os princípios do **SOLID** e utiliza **CQRS** para separação de comandos e consultas. A API é construída sobre o **ASP.NET 8** e utiliza uma série de tecnologias e ferramentas modernas para entregar um sistema altamente escalável e de fácil manutenção.

## Índice

- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Instalação](#instalação)
- [Execução](#execução)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Funcionalidades

- **Autenticação e Autorização:** Implementação de autenticação JWT para segurança das APIs.
- **CRUD de Clientes:** Endpoints para gerenciamento de clientes.
- **Mensageria com RabbitMQ:** Arquitetura de eventos para comunicação assíncrona entre serviços.
- **CQRS:** Separação de comandos e consultas com MediatR e MongoDB para consultas.
- **Persistência:** Utilização de EntityFramework e Dapper para gerenciamento de dados relacionais.

## Tecnologias Utilizadas

- **.NET 8** - Framework principal da API
- **ASP.NET Core 8** - Construção da API REST
- **JWT** - Autenticação baseada em tokens
- **AutoMapper** - Mapeamento de objetos
- **Entity Framework** - ORM para interações com o banco de dados relacional
- **Dapper** - Micro ORM para consultas de alta performance
- **MongoDB** - Banco de dados NoSQL para consultas CQRS
- **RabbitMQ** - Mensageria para arquitetura de eventos
- **Docker** - Containerização da aplicação
- **Azure** - Deploy e serviços em nuvem

## Estrutura do Projeto

A organização segue a metodologia de **Domain-Driven Design (DDD)**, estruturada em camadas:

- **Domain:** Contém as entidades, agregados, serviços de domínio e interfaces.
- **Application:** Implementa os casos de uso e é responsável por orquestrar as operações do domínio.
- **Infrastructure:** Contém a configuração de banco de dados, repositórios e integração com outras infraestruturas (mensageria e bancos de dados).
- **API:** Exposição dos endpoints para os clientes.

Além disso, o projeto é dividido para suportar **CQRS** e separação de comandos e consultas com o uso de **MediatR**.


