# Projeto de Avalia��o de Desenvolvedor

`LEIA COM ATEN��O`

## Instru��es
**O teste abaixo ter� at� 7 dias corridos para ser entregue a partir da data de recebimento deste manual.**

- O c�digo deve ser versionado em um reposit�rio p�blico no Github e um link deve ser enviado para avalia��o ap�s a conclus�o
- Fa�a o upload deste template para o seu reposit�rio e comece a trabalhar a partir dele
- Leia as instru��es com aten��o e certifique-se de que todos os requisitos est�o sendo atendidos
- O reposit�rio deve fornecer instru��es sobre como configurar, executar e testar o projeto
- Documenta��o e organiza��o geral tamb�m ser�o levadas em considera��o

## Caso de Uso
**Voc� � um desenvolvedor na equipe DeveloperStore. Agora precisamos implementar os prot�tipos da API.**

Como trabalhamos com `DDD`, para referenciar entidades de outros dom�nios, usamos o padr�o `Identidades Externas` com desnormaliza��o das descri��es das entidades.

Portanto, voc� escrever� uma API (CRUD completo) que lida com registros de vendas. A API precisa ser capaz de informar:

* N�mero da venda
* Data em que a venda foi realizada
* Cliente
* Valor total da venda
* Filial onde a venda foi realizada
* Produtos
* Quantidades
* Pre�os unit�rios
* Descontos
* Valor total de cada item
* Cancelado/N�o Cancelado

N�o � obrigat�rio, mas seria um diferencial construir c�digo para publicar eventos de:
* VendaCriada
* VendaModificada
* VendaCancelada
* ItemCancelado

Se voc� escrever o c�digo, **n�o � necess�rio** realmente publicar para qualquer Message Broker. Voc� pode registrar uma mensagem no log da aplica��o ou da maneira que achar mais conveniente.

### Regras de Neg�cio

* Compras acima de 4 itens id�nticos t�m 10% de desconto
* Compras entre 10 e 20 itens id�nticos t�m 20% de desconto
* N�o � poss�vel vender acima de 20 itens id�nticos
* Compras abaixo de 4 itens n�o podem ter desconto

Essas regras de neg�cios definem n�veis de desconto baseados na quantidade e limita��es:

1. N�veis de Desconto:
   - 4+ itens: 10% de desconto
   - 10-20 itens: 20% de desconto

2. Restri��es:
   - Limite m�ximo: 20 itens por produto
   - Nenhum desconto permitido para quantidades abaixo de 4 itens

## Vis�o Geral
Esta se��o fornece uma vis�o geral do projeto e das v�rias habilidades e compet�ncias que ele visa avaliar em candidatos a desenvolvedor.

Veja [Vis�o Geral](./overview.md)

## Pilha de Tecnologia
Esta se��o lista as principais tecnologias usadas no projeto, incluindo os componentes de backend, testes, frontend e banco de dados.

Veja [Pilha de Tecnologia](./tech-stack.md)

## Frameworks
Esta se��o descreve os frameworks e bibliotecas que s�o utilizados no projeto para aumentar a produtividade do desenvolvimento e a manutenibilidade.

Veja [Frameworks](./frameworks.md)

<!-- 
## Estrutura da API
Esta se��o inclui links para a documenta��o detalhada dos diferentes recursos da API:
- [API Geral](./general-api.md)
- [Produtos API](./products-api.md)
- [Carrinhos API](./carts-api.md)
- [Usu�rios API](./users-api.md)
- [Autentica��o API](./auth-api.md)
-->

## Estrutura do Projeto
Esta se��o descreve a estrutura geral e a organiza��o dos arquivos e diret�rios do projeto.

Veja [Estrutura do Projeto](./project-structure.md)