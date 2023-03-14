# FinancialApiTest 
- Webapi para salvar lançamentos financeiros e consolidar o resultado diário

- Projeto da solução: 

Desenvolvido em camadas, seguindo o padrão SOLID, utilizando a Onion Architecture e TDD. 
<img src="/Documentation/architecture_layers.jpg" style="width:200px"/>
<hr />
<img src="/Documentation/microservices_scheme.png" style="width:200px"/>

Descrição:

1 Criação do repositório 'FinancialRepository' responsável pelo acesso e manutenção de dados;
Base de dados (FinancialPosts) criada no SQLEXPRESS utilizando EF Migration, para criar a base de dados utilizar os comandos no 'Console do Gerenciador de Pacotes':
- Add-Migration InitialCreate
- Update-Database

2 Criação do serviço: FinancialService - Responsável para salvar e listar os lançamentos;

3 Criação do app service: FinancialApp para consolidar o resultado da lista de lançamentos diários e chamar a inserção dos lançamentos;

4 Criação do controller 'Financial', utilizando cache para otimizar o desempenho na exibição de resultados;

5 Criação da documentação da API via swagger;

6 Adição de Log para monitoramento do funcionamento da aplicação;

7 Implementação de Testes Unitários por camadas;

8 Configuração de AutoMapper e Injeção de Dependências.

# Como rodar o projeto local
- Ir para o diretório /Presentation do projeto e executar o comando "dotnet run"
- Acessar o endereço https://localhost:5001/swagger no browser, para acessar a documentação da API gerada no swagger.

