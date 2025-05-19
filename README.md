# SevenFood
Projeto a pedidos dos alunos do 3º período de Engenharia de Computação do Unasp-EC. 2025.1.

# Release
## [SevenFood_1.3](https://github.com/ProfDudarts/SevenFood/raw/refs/heads/main/SevenFoodApp/bin/Releases/SevenFoodApp_1.3.exe)
  ### Release Note: 17/05/2025
  #### Novidades
  - Adição do fluxo de cadastro de comida;
  - Refatoração do banco de dados;
  - Adição de camada de segurança contra o bug do ponto e vírgula no "banco de dados";
  - Exibição de preço no formato `currenty`, padrão local (Brasil): `R$ 00,00`;
  - Centralização do Menu de opção de cada contexto;
  - Mais opções de tamanho de colunas para as views;

  #### Correções
  - Ajustes nas colunas que estavam truncadas;
  - Ajuste nos modificador de acesso;
  - Adiciona os arquivos de banco de dados em uma única pasta;
  - Correção de nomeclaturas de variáveis e mensagens de acordo com o contexto;

## [SevenFood_1.2](https://github.com/ProfDudarts/SevenFood/raw/refs/heads/main/SevenFoodApp/bin/Releases/SevenFoodApp_1.2.exe)
  ### Release Note: 17/05/2025
  #### Novidades
  - Adição da Classe `FileRepository` para abstrair o ações de banco de dados;
  - `Controllers` retornando dicionários para as `views`;
  - `Repositories` genéricos baseados em contextos;
  - Adição de classe abstrata genérica para o adicionar `Id` a todas as classes `Model`;
  - Adição de classe `Please` para inicialização e métodos auxiliares
  - Adição de ums `View` exclusiva para o login
  - Tradução dos `Enums`
  - Centralização de Mensagens

  #### Correções
  - Correções de erros de digitação;
  - Ajustes para atender o padrão MVC;
    - Ajustes de modificadores de acesso para atender o padrão MVC;

## [SevenFood_1.1](https://github.com/ProfDudarts/SevenFood/raw/refs/heads/main/SevenFoodApp/bin/Releases/SevenFoodApp_1.1.exe)
  ### Release Note: 14/05/2025
  - Ajustes no fluxo do CRUD dos usuários
  - Adicionou o tipo de usuário
  - Login para entrar no sistema
  - CRUD do Restaurante

## [SevenFood_1.0](https://github.com/ProfDudarts/SevenFood/raw/refs/heads/main/SevenFoodApp/bin/Releases/SevenFoodApp_1.0.exe)
  ### Release Note: 10/05/2025
  - Arquitetura MVC
  - Fluxo do CRUD dos usuários


# UML
![Diagrama de Classes - SevenFood](SevenFood-uml-Classes.drawio.svg)

# ARQUITETURA
![Diagrama de Classes - SevenFood](SevenFood-uml-Arquitetura.drawio.svg)
