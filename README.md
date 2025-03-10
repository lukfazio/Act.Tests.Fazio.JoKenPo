# Descrição da Solução
Esta solução implementa testes unitários para validar a lógica do jogo "JoKenPo" (Pedra, Papel, Tesoura, Lagarto, Spock) utilizando o .NET 8 e C# 12.0. Os testes são escritos com xUnit e focam na comparação dos movimentos dos jogadores, assegurando que o resultado esteja de acordo com as regras definidas para o jogo.

## Componentes Principais
1.	Entidades e Enumeradores
	- GameMoves: Enumeração que define as possíveis jogadas: Pedra, Papel, Tesoura, Lagarto e Spock.
	- PossiblePlays: Representa uma jogada possível no jogo, associando um movimento a uma lista de movimentos que ele vence. Cada instância é criada por meio do método estático Create.
2.	Casos de Uso
	- ComparePlaysUseCase: Caso de uso responsável por comparar as jogadas dos dois jogadores. Ele determina qual jogador é o vencedor ou se houve empate, baseado nas regras definidas através dos objetos do tipo PossiblePlays.
3.	Testes Unitários
	- ComparePlaysUseCaseTests: Conjunto de testes que validam o comportamento do ComparePlaysUseCase:
	- Testes Parametrizados ([Theory] com [InlineData]): São utilizados para testar diferentes cenários da comparação de jogadas. Cada conjunto de dados oferece as jogadas dos dois jogadores, indicando se o resultado deve ser um empate ou qual jogada deve vencer.
	- Teste de Exceção ([Fact]): Valida se o uso de entradas inválidas (quando as regras de vitória não estão definidas) gera a exceção esperada, garantindo assim a robustez da solução.

## Abordagem e Benefícios
•	Parametrização dos Testes: Facilita a validação de múltiplos cenários de jogo em um único método de teste, permitindo uma manutenção e extensão mais simples dos casos de uso.

•	Validação de Exceções: Garante que situações anômalas e entradas inválidas sejam tratadas adequadamente, mantendo a integridade do componente.

•	Foco na Lógica de Domínio: A separação clara entre entidades, lógica de comparação e testes unitários permite um código organizado, facilitando futuras alterações e ampliações da regra de negócio.

Esta arquitetura de testes assegura que as regras de comparação de jogadas do jogo estejam corretas e que, caso um cenário inesperado ocorra, a aplicação retorne erros informativos e gerenciáveis.

---
# Jogadas Possíveis

No jogo "JoKenPo", as regras de vitória e empate estão definidas com base nas relações entre as jogadas, conforme implementado na sua solução por meio das instâncias da classe PossiblePlays. Eis as regras específicas:

- Pedra vence:	
	- Lagarto
	- Tesoura
- Papel vence:
	- Pedra
	- Spock
- Tesoura vence:
	- Papel
	- Lagarto	
- Lagarto vence:
	- Spock
	- Papel	
- Spock vence:
	- Tesoura
	- Pedra
	
Além disso, caso ambos os jogadores selecionem a mesma jogada, o resultado é declarado como empate.
A lógica utiliza esses relacionamentos para determinar o vencedor ou se houve empate no caso de jogadas iguais. Em situações em que a lista de jogadas que um movimento pode vencer (WinsFrom) não esteja definida adequadamente (por exemplo, ser nula), a aplicação lança uma exceção, garantindo a integridade das regras implementadas.

---
# Sobre o Projeto de Apresentação

A aplicação definida pelo arquivo Act.Teste.Fazio.JoKenPo.Presentation.Console.csproj é um projeto Console em .NET 8 que serve como camada de apresentação para o jogo "JoKenPo". Ela funciona da seguinte forma:
- Execução como Aplicativo Console:
O projeto é configurado para produzir um executável (OutputType: Exe), permitindo a interação por meio do terminal. A aplicação provavelmente inicia lendo as entradas do usuário e exibindo resultados da lógica implementada no domínio.
- Framework e Recursos Modernos:
A aplicação tem como target o .NET 8, utilizando C# 12 com implicit usings e o recurso de checagem de nulabilidade ativado, garantindo um código mais conciso e com segurança na manipulação de valores nulos.
- Injeção de Dependências:
O pacote Microsoft.Extensions.DependencyInjection está referenciado, fazendo o uso de DI (Injeção de Dependências) para gerenciar instâncias dos componentes do domínio e dos casos de uso, facilitando a modularização e a testabilidade da aplicação.
- Integração com a Lógica de Domínio:
A aplicação faz referência aos projetos Act.Teste.Fazio.JoKenPo.Domain e Act.Teste.Fazio.JoKenPo.Domain.UseCase, que contêm as regras de negócio e a lógica para comparação das jogadas. Dessa forma, a aplicação Console atua como uma interface para demonstrar e executar essa lógica.
Em resumo, a aplicação de Console possibilita que os usuários interajam com o sistema "JoKenPo", executando casos de uso que determinam o vencedor com base nas regras definidas para as jogadas (Pedra, Papel, Tesoura, Lagarto e Spock), utilizando práticas modernas de desenvolvimento e injeção de dependências.
---
# Serviço

O ConsoleJoKenPoService é um serviço de camada de apresentação responsável por interagir com o usuário via console, coletando entradas, processando jogadas e exibindo os resultados do jogo "Pedra-Papel-Tesoura-Lagarto-Spock". A seguir, segue uma explicação detalhada do seu funcionamento:

## Estrutura e Dependências
- Interfaces Implementadas e Dependências
- O serviço implementa a interface IBaseService, o que exige a implementação do método Invoke(), que contém a lógica principal de execução.
- Recebe via construtor duas dependências:
- Uma lista de PossiblePlays, que define as regras de vitória para cada movimento.
- Uma instância de IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto>, que é o caso de uso responsável por comparar as jogadas dos jogadores.

## Lógica do Método Invoke
1.	Inicialização e Mensagens Iniciais
	- Exibe a mensagem: "Iniciando o Jogo PEDRA-PAPEL-TESOURA-LAGARTO-SPOCK!".
	- Configura nomes fixos para os jogadores (player1Name = "rajesh" e player2Name = "sheldon").
2.	Entrada do Número de Jogadas
	- Entra em um loop que solicita ao usuário a quantidade de rodadas a serem jogadas.
	- Valida a entrada convertendo a string obtida via Console.ReadLine() para um inteiro (numberOfPlays).
	- Caso a entrada seja inválida ou menor ou igual a zero, exibe uma mensagem de erro ("Opção Inválida!") e repete a solicitação até receber um número válido.
3.	Processamento de Cada Rodada
	- Para cada rodada, inicia um loop interno para capturar e validar as jogadas dos dois jogadores.
	- O serviço solicita ao usuário as escolhas dos dois jogadores, esperando que elas sejam informadas separadas por espaço.
	- Utiliza um método de extensão (ToGameMoves()) para converter as strings em valores do enum GameMoves.
	- Cria uma instância de ComparePlaysInputDto utilizando o método PlayerMove.Create(). Esse método associa o nome do jogador e a jogada selecionada (obtida por meio da busca na lista _possiblePlayes).
	- Em caso de falha ao converter ou ao recuperar a jogada desejada, captura a exceção e exibe "Jogada inválida! Tente novamente.", reiniciando a captura para a rodada atual.
4.	Execução do Caso de Uso
	- Uma vez que o input é corretamente criado, o método chama _comparePlaysUseCase.TryToExecute(input) para obter o resultado da rodada.
	- O resultado, contendo informações sobre empate (IsADraw) e o vencedor (Winner), é armazenado na lista playsResult.
5.	Exibição dos Resultados
	- Após processar todas as rodadas, o serviço exibe uma mensagem "Resultado:".
	- Itera sobre os resultados armazenados:
	- Se a rodada for um empate (IsADraw true), exibe "Empate!".
	- Caso contrário, exibe o nome do vencedor seguido da mensagem "venceu!".
6.	Finalização
•	Exibe as mensagens "Fim de Jogo!" e um marcador visual final (por exemplo, "´´´´"), sinalizando o encerramento da execução.

## Considerações Técnicas

- Campos Estáticos:
Os campos _possiblePlayes e _comparePlaysUseCase são definidos como estáticos, o que faz com que sejam compartilhados entre as instâncias do serviço. Essa abordagem pode ser útil para garantir que a mesma configuração de regras e caso de uso seja utilizada durante toda a sessão.
- Tratamento de Erros:
O serviço utiliza estruturas de repetição (do/while) e blocos try/catch para garantir que apenas entradas válidas sejam processadas, aumentando a robustez e a experiência do usuário ao lidar com erros de digitação ou entradas inesperadas.
- Integração com a Lógica de Domínio:
Ao utilizar o caso de uso via interface (IBaseUseCase), o serviço desacopla a lógica de apresentação da lógica de negócio, permitindo que as regras de comparação de jogadas sejam modificadas independentemente da interface com o usuário.

- 
Essa implementação demonstra uma abordagem prática para rodar a lógica do jogo via console, com validação de entrada e tratamento adequado de cada jogada, além de uma organização modular que permite fácil manutenção e testes.

