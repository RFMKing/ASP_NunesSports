
# Projeto CRUD ASP.NET- Website Nunes Sports

Projeto requerido pelo Programa Best Minds 2024 - Pessoa Desenvolvedora Trainee e treino em desenvolvimento no Visual Code/ ASP.NET.




## Deployment

Este projeto foi desenvolvido no Visual Studio, Net 7.0.9, com os seguintes NuGet:
```
-Microsoft.EntityFrameworkCore.SqlServer v7.0.9
-Microsoft.EntityFrameworkCore.Tools V7.0.9
```
Para banco de dados:
```
-Microsoft® SQL Server® 2022 Express
-Uma cópia do SQL está disponível no diretório acima para ser carregada a fim de ter exemplos prontos de exibição
```
Sem essas dependencias instaladas pode haver problemas de execução do site ou acessar os dados do banco de dados.

Recomendado executar o projeto no modo IIS Express para evitar ter erro de permissões de acesso a pastas ou realizar funções de "Editar" e "Deletar" na área de Administrador.


## Feedback

Agradeço qualquer feedback sobre o código e estruturação, especialmente soluções para resolver alteração em inputs do tipo "decimal" para aderirem formato regional en-US (#,###.##) ao invés do pt-BR(#.###,##).

O projeto somente requisitava o CRUD, mas para aprendizado irei desenvolver features a serem adicionadas em updates:
-Sistema funcional de Cadastro/Login com níveis de acesso
-Homepage para usuários com Design finalizado
-Sistema de listagem de produtos, compra, carrinho e pagamento
-Implementar uma instância do SQL Server pelo Docker e linkar como referencia a um banco de dados em Nuvem ao invés de local.

