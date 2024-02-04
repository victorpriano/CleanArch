
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


