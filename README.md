🏦 Skunk Works Bank

Projeto pessoal de portfólio com foco em arquitetura de software, DDD, Clean Architecture e boas práticas usadas no dia a dia.

O objetivo do projeto é modelar e implementar, de forma incremental, um core bancário simplificado, começando por cadastro de clientes (PF/PJ), contas bancárias e, futuramente, movimentações financeiras, como bolsa de valores.

🎯 Objetivos do Projeto

 - Demonstrar domínio de modelagem de dados e DDD (Domain-Driven Design)

 - Aplicar Bounded Contexts corretamente

 - Utilizar Clean Architecture

 - Criar um modelo escalável e realista de banco digital

 - Servir como projeto de estudo e portfólio profissional

🧠 Abordagem Arquitetural

O projeto segue os seguintes princípios:

 - DDD (Domain-Driven Design)

 - Bounded Contexts definidos

 - Explicit aggregate boundaries

 - Separação clara de responsabilidades

 - Modelo de domínio rico (entidades com comportamento)

📦 Bounded Contexts

🟦 Customer Management Context

Responsável pelo cadastro e gestão de clientes PF.

Principais entidades:

 - User

 - Contact

 - Address

 - UserStatus

Responsabilidades:

 - Dados pessoais

 - Contatos (email, telefone)

 - Endereços

 - Status do usuário

 - Regras de compliance (ex: PEP)

🟧 Company Context

Responsável pelo cadastro e gestão de empresas (PJ) e seus vínculos.

Principais entidades:

 - Company

 - UserCompany

 - Role

 - CompanyStatus

Responsabilidades:

 - Cadastro de empresas

 - Vínculo PF ↔ PJ

 - Papéis (representante legal, sócio, etc.)

🟩 Account Context

Responsável pelo gerenciamento de contas bancárias.

Principais entidades:

 - Account

 - AccountType

 - AccountStatus

 - Bank

Responsabilidades:

 - Criação de conta bancária

 - Número, agência e dígito

 - Saldo

 - Status da conta


🗄️ Modelagem de Dados

 - Banco de dados relacional

 - Tabelas normalizadas

 - Uso de snake_case no banco

 - Chaves estrangeiras explícitas

 - Tabelas de status separadas por domínio

Exemplo:

 - user_status

 - company_status

 - account_status


🛠️ Tecnologias Planejadas

 - .NET

 - Angular

 - Entity Framework Core

 - SQL Server

 - Docker (futuramente)

 - RabbitMQ (futuramente)

🧪 Testes

 - Testes unitários no domínio

 - Testes de regras de negócio

 - Uso de mocks para serviços externos


🚀 Status do Projeto

 - 🟡 API em desenvolvimento


📌 Observações

Este projeto não é um banco real e não deve ser usado em produção.

O foco é aprendizado, arquitetura e boas práticas, simulando cenários reais do mercado financeiro.

👤 Autor

Projeto desenvolvido por Diego Fernandes de Meneses como estudo avançado de arquitetura e domínio bancário.

Se você trabalha com backend, arquitetura ou sistemas financeiros e quiser trocar ideia, fique à vontade 😄
