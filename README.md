# Descri��o da Solu��o
Esta solu��o implementa testes unit�rios para validar a l�gica do jogo "JoKenPo" (Pedra, Papel, Tesoura, Lagarto, Spock) utilizando o .NET 8 e C# 12.0. Os testes s�o escritos com xUnit e focam na compara��o dos movimentos dos jogadores, assegurando que o resultado esteja de acordo com as regras definidas para o jogo.

## Componentes Principais
1.	Entidades e Enumeradores
	- GameMoves: Enumera��o que define as poss�veis jogadas: Pedra, Papel, Tesoura, Lagarto e Spock.
	- PossiblePlays: Representa uma jogada poss�vel no jogo, associando um movimento a uma lista de movimentos que ele vence. Cada inst�ncia � criada por meio do m�todo est�tico Create.
2.	Casos de Uso
	- ComparePlaysUseCase: Caso de uso respons�vel por comparar as jogadas dos dois jogadores. Ele determina qual jogador � o vencedor ou se houve empate, baseado nas regras definidas atrav�s dos objetos do tipo PossiblePlays.
3.	Testes Unit�rios
	- ComparePlaysUseCaseTests: Conjunto de testes que validam o comportamento do ComparePlaysUseCase:
	- Testes Parametrizados ([Theory] com [InlineData]): S�o utilizados para testar diferentes cen�rios da compara��o de jogadas. Cada conjunto de dados oferece as jogadas dos dois jogadores, indicando se o resultado deve ser um empate ou qual jogada deve vencer.
	- Teste de Exce��o ([Fact]): Valida se o uso de entradas inv�lidas (quando as regras de vit�ria n�o est�o definidas) gera a exce��o esperada, garantindo assim a robustez da solu��o.

## Abordagem e Benef�cios
�	Parametriza��o dos Testes: Facilita a valida��o de m�ltiplos cen�rios de jogo em um �nico m�todo de teste, permitindo uma manuten��o e extens�o mais simples dos casos de uso.

�	Valida��o de Exce��es: Garante que situa��es an�malas e entradas inv�lidas sejam tratadas adequadamente, mantendo a integridade do componente.

�	Foco na L�gica de Dom�nio: A separa��o clara entre entidades, l�gica de compara��o e testes unit�rios permite um c�digo organizado, facilitando futuras altera��es e amplia��es da regra de neg�cio.

Esta arquitetura de testes assegura que as regras de compara��o de jogadas do jogo estejam corretas e que, caso um cen�rio inesperado ocorra, a aplica��o retorne erros informativos e gerenci�veis.

---
# Jogadas Poss�veis

No jogo "JoKenPo", as regras de vit�ria e empate est�o definidas com base nas rela��es entre as jogadas, conforme implementado na sua solu��o por meio das inst�ncias da classe PossiblePlays. Eis as regras espec�ficas:

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
	
Al�m disso, caso ambos os jogadores selecionem a mesma jogada, o resultado � declarado como empate.
A l�gica utiliza esses relacionamentos para determinar o vencedor ou se houve empate no caso de jogadas iguais. Em situa��es em que a lista de jogadas que um movimento pode vencer (WinsFrom) n�o esteja definida adequadamente (por exemplo, ser nula), a aplica��o lan�a uma exce��o, garantindo a integridade das regras implementadas.

---
# Sobre o Projeto de Apresenta��o

A aplica��o definida pelo arquivo Act.Teste.Fazio.JoKenPo.Presentation.Console.csproj � um projeto Console em .NET 8 que serve como camada de apresenta��o para o jogo "JoKenPo". Ela funciona da seguinte forma:
- Execu��o como Aplicativo Console:
O projeto � configurado para produzir um execut�vel (OutputType: Exe), permitindo a intera��o por meio do terminal. A aplica��o provavelmente inicia lendo as entradas do usu�rio e exibindo resultados da l�gica implementada no dom�nio.
- Framework e Recursos Modernos:
A aplica��o tem como target o .NET 8, utilizando C# 12 com implicit usings e o recurso de checagem de nulabilidade ativado, garantindo um c�digo mais conciso e com seguran�a na manipula��o de valores nulos.
- Inje��o de Depend�ncias:
O pacote Microsoft.Extensions.DependencyInjection est� referenciado, fazendo o uso de DI (Inje��o de Depend�ncias) para gerenciar inst�ncias dos componentes do dom�nio e dos casos de uso, facilitando a modulariza��o e a testabilidade da aplica��o.
- Integra��o com a L�gica de Dom�nio:
A aplica��o faz refer�ncia aos projetos Act.Teste.Fazio.JoKenPo.Domain e Act.Teste.Fazio.JoKenPo.Domain.UseCase, que cont�m as regras de neg�cio e a l�gica para compara��o das jogadas. Dessa forma, a aplica��o Console atua como uma interface para demonstrar e executar essa l�gica.
Em resumo, a aplica��o de Console possibilita que os usu�rios interajam com o sistema "JoKenPo", executando casos de uso que determinam o vencedor com base nas regras definidas para as jogadas (Pedra, Papel, Tesoura, Lagarto e Spock), utilizando pr�ticas modernas de desenvolvimento e inje��o de depend�ncias.
---
# Servi�o

O ConsoleJoKenPoService � um servi�o de camada de apresenta��o respons�vel por interagir com o usu�rio via console, coletando entradas, processando jogadas e exibindo os resultados do jogo "Pedra-Papel-Tesoura-Lagarto-Spock". A seguir, segue uma explica��o detalhada do seu funcionamento:

## Estrutura e Depend�ncias
- Interfaces Implementadas e Depend�ncias
- O servi�o implementa a interface IBaseService, o que exige a implementa��o do m�todo Invoke(), que cont�m a l�gica principal de execu��o.
- Recebe via construtor duas depend�ncias:
- Uma lista de PossiblePlays, que define as regras de vit�ria para cada movimento.
- Uma inst�ncia de IBaseUseCase<ComparePlaysInputDto, ComparePlaysOutputDto>, que � o caso de uso respons�vel por comparar as jogadas dos jogadores.

## L�gica do M�todo Invoke
1.	Inicializa��o e Mensagens Iniciais
	- Exibe a mensagem: "Iniciando o Jogo PEDRA-PAPEL-TESOURA-LAGARTO-SPOCK!".
	- Configura nomes fixos para os jogadores (player1Name = "rajesh" e player2Name = "sheldon").
2.	Entrada do N�mero de Jogadas
	- Entra em um loop que solicita ao usu�rio a quantidade de rodadas a serem jogadas.
	- Valida a entrada convertendo a string obtida via Console.ReadLine() para um inteiro (numberOfPlays).
	- Caso a entrada seja inv�lida ou menor ou igual a zero, exibe uma mensagem de erro ("Op��o Inv�lida!") e repete a solicita��o at� receber um n�mero v�lido.
3.	Processamento de Cada Rodada
	- Para cada rodada, inicia um loop interno para capturar e validar as jogadas dos dois jogadores.
	- O servi�o solicita ao usu�rio as escolhas dos dois jogadores, esperando que elas sejam informadas separadas por espa�o.
	- Utiliza um m�todo de extens�o (ToGameMoves()) para converter as strings em valores do enum GameMoves.
	- Cria uma inst�ncia de ComparePlaysInputDto utilizando o m�todo PlayerMove.Create(). Esse m�todo associa o nome do jogador e a jogada selecionada (obtida por meio da busca na lista _possiblePlayes).
	- Em caso de falha ao converter ou ao recuperar a jogada desejada, captura a exce��o e exibe "Jogada inv�lida! Tente novamente.", reiniciando a captura para a rodada atual.
4.	Execu��o do Caso de Uso
	- Uma vez que o input � corretamente criado, o m�todo chama _comparePlaysUseCase.TryToExecute(input) para obter o resultado da rodada.
	- O resultado, contendo informa��es sobre empate (IsADraw) e o vencedor (Winner), � armazenado na lista playsResult.
5.	Exibi��o dos Resultados
	- Ap�s processar todas as rodadas, o servi�o exibe uma mensagem "Resultado:".
	- Itera sobre os resultados armazenados:
	- Se a rodada for um empate (IsADraw true), exibe "Empate!".
	- Caso contr�rio, exibe o nome do vencedor seguido da mensagem "venceu!".
6.	Finaliza��o
�	Exibe as mensagens "Fim de Jogo!" e um marcador visual final (por exemplo, "����"), sinalizando o encerramento da execu��o.

## Considera��es T�cnicas

- Campos Est�ticos:
Os campos _possiblePlayes e _comparePlaysUseCase s�o definidos como est�ticos, o que faz com que sejam compartilhados entre as inst�ncias do servi�o. Essa abordagem pode ser �til para garantir que a mesma configura��o de regras e caso de uso seja utilizada durante toda a sess�o.
- Tratamento de Erros:
O servi�o utiliza estruturas de repeti��o (do/while) e blocos try/catch para garantir que apenas entradas v�lidas sejam processadas, aumentando a robustez e a experi�ncia do usu�rio ao lidar com erros de digita��o ou entradas inesperadas.
- Integra��o com a L�gica de Dom�nio:
Ao utilizar o caso de uso via interface (IBaseUseCase), o servi�o desacopla a l�gica de apresenta��o da l�gica de neg�cio, permitindo que as regras de compara��o de jogadas sejam modificadas independentemente da interface com o usu�rio.

- 
Essa implementa��o demonstra uma abordagem pr�tica para rodar a l�gica do jogo via console, com valida��o de entrada e tratamento adequado de cada jogada, al�m de uma organiza��o modular que permite f�cil manuten��o e testes.

