# Space_Odyssey
Space Odyssey é um jogo feito em **#C** na **Unity** para a disciplina de TI4: Aplicações Móveis. 

### SINOPSE
Aventura espacial estilo arcade (space shooter) onde o jogador assume o
papel de um astronauta que precisa escapar de uma invasão alienígena em um
ambiente 2D cheio de obstáculos. A jogabilidade é baseada em habilidades de
navegação e reflexos para desviar de obstáculos e vencer alienígenas.

O jogador também tem a oportunidade de coletar consumíveis para aumentar
seu desempenho

### COMO JOGAR
Resumo: O jogador controla a nave espacial em um ambiente 2D, onde
precisa desviar de obstáculos, e atirar em naves de aliens invasores até
vencê-las. De tempos em tempos enfrenta um boss que atira mísseis capazes
de perseguir o player. A derrota ocorre se a vida do jogador chega a zero.

O jogador consegue se mover em todas as direções utilizando as setas e atirar
com a barra de espaço.

### DIFERENCIAIS
Desafio emocionante para jogadores que procuram testar suas habilidades de
navegação e reflexos, em um ambiente cheio de obstáculos.

Jogabilidade simples e viciante + capacidade de coletar consumíveis para
melhorias na nave, proporcionam uma experiência única e envolvente.

### GRAFOS
- Utilizado para spawn de consumíveis
- Opções de busca em largura e em profundidade
- Cada nó do grafo representa um Waypoint do cenário
- Consumíveis são gerados no nó mais distante do Player
- Busca em largura explora o grafo de forma nivelada
- Busca em profundidade explora o grafo de forma aprofundada

### IA
- Algoritmo de busca A*
- Heurística de distância euclidiana
- Utilizada nos Bosses do jogo
- Mísseis perseguem o jogador
- Mísseis desviam de obstáculos
- Aumenta dificuldade e imersão do jogo

