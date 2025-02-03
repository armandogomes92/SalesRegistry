# Projeto de Avaliação de Desenvolvedor

`LEIA COM ATENÇÃO`

## Instruções
**O teste abaixo terá até 7 dias corridos para ser entregue a partir da data de recebimento deste manual.**

- O código deve ser versionado em um repositório público no Github e um link deve ser enviado para avaliação após a conclusão
- Faça o upload deste template para o seu repositório e comece a trabalhar a partir dele
- Leia as instruções com atenção e certifique-se de que todos os requisitos estão sendo atendidos
- O repositório deve fornecer instruções sobre como configurar, executar e testar o projeto
- Documentação e organização geral também serão levadas em consideração

## Caso de Uso
**Você é um desenvolvedor na equipe DeveloperStore. Agora precisamos implementar os protótipos da API.**

Como trabalhamos com `DDD`, para referenciar entidades de outros domínios, usamos o padrão `Identidades Externas` com desnormalização das descrições das entidades.

Portanto, você escreverá uma API (CRUD completo) que lida com registros de vendas. A API precisa ser capaz de informar:

* Número da venda
* Data em que a venda foi realizada
* Cliente
* Valor total da venda
* Filial onde a venda foi realizada
* Produtos
* Quantidades
* Preços unitários
* Descontos
* Valor total de cada item
* Cancelado/Não Cancelado

Não é obrigatório, mas seria um diferencial construir código para publicar eventos de:
* VendaCriada
* VendaModificada
* VendaCancelada
* ItemCancelado

Se você escrever o código, **não é necessário** realmente publicar para qualquer Message Broker. Você pode registrar uma mensagem no log da aplicação ou da maneira que achar mais conveniente.

### Regras de Negócio

* Compras acima de 4 itens idênticos têm 10% de desconto
* Compras entre 10 e 20 itens idênticos têm 20% de desconto
* Não é possível vender acima de 20 itens idênticos
* Compras abaixo de 4 itens não podem ter desconto

Essas regras de negócios definem níveis de desconto baseados na quantidade e limitações:

1. Níveis de Desconto:
   - 4+ itens: 10% de desconto
   - 10-20 itens: 20% de desconto

2. Restrições:
   - Limite máximo: 20 itens por produto
   - Nenhum desconto permitido para quantidades abaixo de 4 itens

## Visão Geral
Esta seção fornece uma visão geral do projeto e das várias habilidades e competências que ele visa avaliar em candidatos a desenvolvedor.

Veja [Visão Geral](./overview.md)

## Pilha de Tecnologia
Esta seção lista as principais tecnologias usadas no projeto, incluindo os componentes de backend, testes, frontend e banco de dados.

Veja [Pilha de Tecnologia](./tech-stack.md)

## Frameworks
Esta seção descreve os frameworks e bibliotecas que são utilizados no projeto para aumentar a produtividade do desenvolvimento e a manutenibilidade.

Veja [Frameworks](./frameworks.md)

<!-- 
## Estrutura da API
Esta seção inclui links para a documentação detalhada dos diferentes recursos da API:
- [API Geral](./general-api.md)
- [Produtos API](./products-api.md)
- [Carrinhos API](./carts-api.md)
- [Usuários API](./users-api.md)
- [Autenticação API](./auth-api.md)
-->

## Estrutura do Projeto
Esta seção descreve a estrutura geral e a organização dos arquivos e diretórios do projeto.

Veja [Estrutura do Projeto](./project-structure.md)