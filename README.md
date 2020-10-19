# HungryPizza
[![Linkedin Curriculo](https://cariadmarketing.com/wp-content/uploads/2013/11/default-share.png)](https://www.linkedin.com/in/cassioguilhermy/)

# Proposta do Projeto

Você acabou de ser contratado como desenvolvedor sênior da Hungry Pizza. Esta é uma pizzaria muito famosa no bairro, seus donos sempre foram muito reticentes quando o assunto é a venda online, mas diante das atuais circunstâncias eles tiveram de reconsiderar. 

Seu desafio é criar uma API para receber os pedidos feitos a partir do site da pizzaria que atenda aos requisitos abaixo:

- Todo pedido precisa ter um identificador único
- Um pedido pode ter no mínimo uma pizza e no máximo 10.
- Cada pizza pode ter até dois sabores, os sabores disponíveis são:
	 - 3 Queijos (R$ 50)
	 - Frango com requeijão (R$ 59.99)
	 - Mussarela (R$ 42.50)
	 - Calabresa (R$ 42.50)
	 - Pepperoni (R$ 55)
	 - Portuguesa (R$ 45)
	 - Veggie (R$ 59.99)
- O preço da pizza com dois sabores (meio a meio) deve ser composto pela metade do valor de cada uma das pizzas.
- O cliente não precisa ter cadastro para fazer um pedido, mas nesse caso precisará informar os dados de endereço de entrega, caso seja um cliente cadastrado ele não precisa informar o endereço de entrega, pois deve constar em seu cadastro.
- Não vamos cobrar frete nessa primeira versão do sistema
- O cliente deve ser capaz de ver seu histórico de pedidos, com os detalhes das pizzas, valor individual e valor total do pedido.

O front-end será desenvolvido por outro time, por isso a criação de testes de unidade e de integração são imprescindíveis. Fique a vontade para testar os cenários que achar mais relevantes.

Fique atento as regras:
- A aplicação deve ser construida com C#
- A api deve rodar em ambiente Linux, por isso é necessário que seja construida com .NET Core
- A definição do banco de dados utilizado fica a critérido do candidato
- Esperamos que você resolva o teste em até 2 dias a contar da data combinada para início. Caso você precise de mais tempo, por favor, avise-nos com até três dias de antecedência a contar do recebimento.
- Ao final do prazo limite ou quando você terminar, o que acontecer primeiro, você deve publicar o código desenvolvido em um repositório aberto no github e, depois, responder a este formulário com o link para o repositório.

## PROJETOS DA SOLUÇÃO

• **HungryPizza.WebAPI.Core**: Web API. usando Swagger permite assim mapear os metodos, e testar a aplicação.

• **HungryPizza.Servico**: Nesse repositorio contém as entidades, commands, queries, handlers e validações utilizados pelos demais projetos.

• **HungryPizza.Repositorio**: Nesse repositorio temos as classes referentes ao repositório e conexão com o banco de dados.

• **HungryPizza.Compartilhado**: Nesse repositorio possui classes comuns a todos os projetos.

• **HungryPizza.Tests**: Nesse repositorio testes automatizados. Permite testar os commands, queries e controllers utilizando dados mockados.

## DADOS DO PROJETO

- .NET Core 
- Swagger
- AutoMapper
- MediatR
- FluentValidation
- Entity Framework
- MySQL
- xUnit
- AutoMoq

## PATTERNS/DESIGNS

- S.O.L.I.D.
- CQRS
- Domain Driven Design
- Notification Pattern

## INSTRUÇÕES

A solução requer conexão com o banco de dados MySQL para ser testada pelo Swagger.  
A pasta "SCRIPTS_BANCO" contém o arquivo HungryPizza.sql e o diagrama de tabelas. É necessário executar o script no MySQL Workbench ou qualquer outro gerenciador de banco de dados MySQL para contruir o schema, cadastrar as pizzas e poder realizar os testes por completo.
A string de conexão deve ser fornecida no arquivo _appsettings.json_ do projeto **HungryPizza.WebAPI.Core**.

## CONEXÃO COM O BANCO

"ConnectionStrings": {
    "DefaultConnection": "server=###;uid=###;port=###;pwd=###;database=hungrypizza;"
}

- Todos os métodos possuem exemplo de entrada.  
- Para cadastrar um cliente, utilize o controller _Customer_.  
- O histórico de pedidos requer um cliente cadastrado e é acessado através da rota _/Request/{idCustomer}_ do controller _Request_.  
- O método de autenticação de usuário no controller _User_ é apenas um recurso a mais, não necessário para o funcionamento do sistema.
