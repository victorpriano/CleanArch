
## Aprendizados

Através desse projeto, consegui aprofundar meus conhecimentos sobre Clean Architecture e aprender um pouco mais sobre alguns padrões e boas práticas, como a utilização da biblioteca Mediatr, a separação de uma camada para alocar os componentes de injeção de dependência, criação de uma classe de configuração para as entidades e a executar as migrations na camada de infrastructure. Sobre a biblioteca Mediatr, aprendi sobre a criação de pipelines através de Behaviors, onde após o request ser recebido pelo servidor, esse request é encaminhado para o pipeline de requests da aplicação aspnet core, e o pipeline do request  da aplicação vai ser responsável por receber, processar e gerar uma resposta. O pipeline é composto por middlewares, onde cada middleware vai ser responsável por processar o request de alguma forma, isso inclui operações como: autenticação, roteamento, tratamento de erros, etc. Os Middlewares são executados em ordem um após o outro e cada middleware pode modificar o request ou o response antes de passar para o próximo, esse processo ocorre antes do request chegar na aplicação, o que se torna eficiente. Na camada de apresentação desse projeto (API), aprendi como criar  filtros de exceções que é um recurso do Aspnet Core, para que sejam interceptadas mensagens de exceções lançadas durante a execução de um request HTTP, com a implementação desse filtro é possível centralizar o tratamento de exceções em um único lugar na aplicação.


## Documentação da API

#### Retorna todos os Members

```http
  GET /members
```

| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` |  A chave da sua API |

#### Retorna um Member

```http
  GET /members/${id}
```

| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `id`      | `string` |  O ID do item que você quer |

#### Insere um Member

```http
  POST /members
```
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` |  A chave da sua API |

#### Atualiza um Member

```http
  PUT /members/${id}
```
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` |  A chave da sua API |

#### Deleta um Member

```http
  DELETE /members/${id}
```
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `api_key` | `string` |  A chave da sua API |


## Referência
Este projeto foi desenvolvido através das video-aulas semanais do professor Macoratti:
 - [Canal Macoratti](https://www.youtube.com/watch?v=xnbLwL_OzNE&t=6s)

Código-fonte do projeto oficial: 
 - [GitHub](https://github.com/macoratti/CleanArch_CQRS_MediatR)


