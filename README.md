## Este é o desafio feito para o processo seletivo da Toro Investimentos
#### O projeto consiste basicamente em um dashboard de exibição de investimentos onde o usuário pode verificar e ocultar seus valores de saldo e patrimônio, além de conferir uma listagem dos ativos que compõem sua carteira. Além da listagem de investimentos, também tomei a liberdade de inserir três cards mostrando:
#### - Investimento Principal (Investimento de maior representatividade na carteira);
#### - Investimento de maior lucro;
#### - Investimento de maior prejuízo;

## Tecnologias:
#### Para o desenvolvimento deste projeto foi usado .net Core 5.0 e o pacote xUnit para os testes. Referente à arquitetura, foi usada uma estrutura em camadas contendo as seguintes camadas com suas respectivas responsabilidades:
####  - WebApi - Contém os controllers que são os pontos de entrada da aplicação;
####  - Domain - Contém a camada de services sendo estes os responsáveis pela regra de negócio da aplicação;
####  - Data - Contém a camada de repositories sendo estes os responsáveis pela busca de dados de fontes internas ou externas.

## Utilização:
#### Particularmente tenho costume de utilizar o Visual Studio para execução de projetos .net core, por isso, usarei dessa ferramenta para explicar como executar o projeto. Após clonar o repositório, basta abrir o arquivo "toro.WebApi.sln" e em Startup Project selecionar toro.WebApi.
#### Sobre testes: Ainda utilizando o Visual Studio, para executar os testes basta acessar a opção Test e em seguida clicar na opção Run All Tests.
#### Obs.: O idioma do Visual Studio alterará alguns dos passos dispostos acima, porém é possível acompanhar o fluxo e chegar ao mesmo resultado.

## Front-end:
#### Foi desenvolvido também um front-end para consumir os dados retornados desta API. O código fonte do projeto do front pode ser acessado através do link: <a href="https://github.com/gusnogueira/toro.front"><b>projeto front-end</b></a>
