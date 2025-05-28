
# Gestão Livraria

Esse é um CRUD para uma livraria online onde é possível adicionar livros, retornar todos os livros, editar e deletar um livro específico.

## Documentação da API

#### Cadastra um novo livro

```http
  POST /api/book
```
Entrada:
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `title` | `string` | **Obrigatório**. O título do livro |
| `author` | `string` | **Obrigatório**. O autor do livro |
| `genre` | `string` | **Obrigatório**. O gênero do livro ("Ficção", "Ciência", "História", "Mistério", "Romance"2) |
| `price` | `decimal` | **Obrigatório**. O preço do livro |
| `stock` | `int` | **Obrigatório**. A quantidade de livros disponíveis no estoque |

#### Atualiza um livro

```http
  PUT /api/book/${id}
```
Entrada:
| Parâmetro   | Tipo       | Descrição                           |
| :---------- | :--------- | :---------------------------------- |
| `title` | `string` | **Obrigatório**. O título do livro |
| `author` | `string` | **Obrigatório**. O autor do livro |
| `genre` | `string` | **Obrigatório**. O gênero do livro ("Ficção", "Ciência", "História", "Mistério", "Romance"2) |
| `price` | `decimal` | **Obrigatório**. O preço do livro |
| `stock` | `int` | **Obrigatório**. A quantidade de livros disponíveis no estoque |

#### Retorna todas os livros

```http
  GET /api/book
```
Saída:
| Parâmetro   | Tipo       | Descrição                                   |
| :---------- | :--------- | :------------------------------------------ |
| `title` | `string` | O título do livro |
| `author` | `string` | O autor do livro |
| `genre` | `string` | O gênero do livro ("Ficção", "Ciência", "História", "Mistério", "Romance"2) |
| `price` | `decimal` | O preço do livro |
| `stock` | `int` | A quantidade de livros disponíveis no estoque |

#### Deleta um livro

```http
  DELETE /api/book/${id}
```


## Stack utilizada

**Back-end:** C# e .NET 8.0

