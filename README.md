# SalesWebMVC

## Sobre
Aplicação web de gerenciamento de vendas desenvolvida com **ASP.NET Core** utilizando o padrão **MVC** e com conexão
com o banco **MySQL** através do ORM **Entity Framework**. Projeto desenvolvido durante o curso de C# Completo - Programação
Orientada a Objetos do Professor Nélio Alves, com o objetivo de praticar o desenvolvimento de aplicações web com 
ASP.NET Core MVC e conhecer os fundamentos da utilização do framework.

A aplicaçao possui as três camadas que são características do padrão arquitetural MVC:
- Models: responsável por gerenciar e controlar a forma como os dados se comportam por meio das funções, lógica e regras de negócios estabelecidas
- Views: responsável por apresentar as informações de forma visual ao usuário
- Controllers: responsável por intermediar as requisições enviadas pelo View com as respostas fornecidas pelo Model

### Entities

- Seller
- Department
- SalesRecord
- Enum: SaleStatus

![diagrama-uml](https://uploaddeimagens.com.br/images/003/900/919/original/diagram-uml.png?1654959268)

### Métodos 

Nas entidades de Departments e Sellers, é possível fazer o gerenciamento de dados através do CRUD básico: listar
todos os registros, criar um novo registro, atualizar a informação de um registro específico e deletar um registro.

![crud-gif](https://s8.gifyu.com/images/video-crud.gif)

Na entidade SalesRecord é possível realizar buscas dos registros de vendas de um determinado período tempo. É possível
fazer tanto a busca simples, quanto a busca agrupada, que retorna os registros de vendas de acordo com o seu departamento.

![busca-gif](https://s8.gifyu.com/images/video-busca.gif)

## Tecnologias utilizadas

- ASP.NET Core
- C#
- MySQL
- Entity Framework

## Autor

LinkedIn: https://www.linkedin.com/in/emanuele-rangel-7b50971b8/

e-mail: emanuele.rangel52@gmail.com
