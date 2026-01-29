### Resolução ~ by Filipe Ribeiro ([github.com/kerusmighos/CRUD\_CSHARP](https://github.com/kerusmighos/CRUD_CSHARP))

Primeiramente, gostaria de parabenizar a equipe pelo desenvolvimento e aplicação desse teste prático. Essa atitude demonstra o empenho e dedicação da empresa com o processo seletivo e com os participantes.

Apesar de essa ser a minha primeira vez trabalhando com C#, me senti confortável com a estrutura do projeto pois já tenho experiência com outros frameworks MVC como o Spring Boot (Java) e Django (Python).

Uma vez que me familiarizei com a estrutura e nomenclaturas do ASP.NET e do desafio em si, pude implementar os requisitos especificados sem dificuldades, apenas fazendo algumas consultas eventuais as documentações e ao módulo de motoristas.

#### Pequenas melhorias:

Além dos requisitos listados no desafio, implementei algumas pequenas melhorias:

*   Adicionei um arquivo **Docker Compose**
*   Adicionei um botão de **Excluir** na tela de **Details** de **Veiculo**, que na de motoristas não existe
*   Tornei a exibição do nome da propriedade CapacidadeTanqueLitros **dinâmica** e fiz ela ser exibida como Capacidade do Tanque **kWh** para veículos elétricos

Gostaria de finalizar agradecendo pela oportunidade de participar do processo seletivo.

# Resolução Estendida

Após a entrega dos requisitos mínimos solicitados no desafio, nos próximos commits irei implementar uma funcionalidade de **Vinculação** que tem como objetivo registrar o **utilização** de um **Veículo** por um **Motorista**

## Explicação dos commits

### Lista de persistência injetáveis

Ao implementar algo semelhante a um relacionamento entre entidades usando listas como forma de persistência, em algum momento eu precisarei acessar as listas de veículos e motoristas fora de seus respectivos controllers, para isso irei remover a declaração dessas listas dos controllers e colocá-las em um repository, de forma que eu possa fazer uso do mecanismo de injeção de dependências para injetar e acessar essas listas em qualquer lugar que eu precisar.

## Pontos de melhoria

### Constraint para delete

Impedir que um motorista ou veiculo seja apagado caso possua vinculações 

## Constraint de tempo / quilometragem 

Impedir que diferentes vinculações sejam criadas de forma que se sobreponham no periodo de tempo ou na faixa de quilometragem