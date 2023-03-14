# FinancialApiTest 
- Webapi para salvar lançamentos financeiros e consolidar o resultado diário

- Projeto da solução: 

Desenvolvido em camadas, seguindo o padrão SOLID, Onion Architecture e TDD. 

<img src="/Documentation/architecture_layers.jpg"/>

Descrição:

1 Criação do repositório 'FinancialRepository' responsável pelo acesso e manutenção de dados;
	1.1 Base de dados (FinancialPosts) criada no SQLEXPRESS utilizando EF Migration:
		- Add-Migration InitialCreate
		- Update-Database

2 Criação do serviço: FinancialService - Responsável para salvar e listar os lançamentos;

3 Criação do app service: FinancialApp para consolidar o resultado da lista de lançamentos diários e chamar a inserção dos lançamentos;

4 Criação do controller 'Financial', utilizando cache para otimizar o desempenho na exibição de resultados;

5 Criação da documentação da API via swagger;

6 Adição de Log para monitoramento do funcionamento da aplicação;

7 Implementação de Testes Unitários por camadas;

8 Configuração de AutoMapper e Injeção de Dependências.
