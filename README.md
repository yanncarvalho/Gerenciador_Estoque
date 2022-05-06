# Prova C#
API Rest para compras com Cartão de crédito e gerenciamento de estoque e venda de produtos 

## Tecnologias Usadas
- .Net 6.0
- C# 10.0
- SqlServer 6.0.4
- XUnit e Moq (para testes automatizadas)
- Swagger (para documentação dos endpoints)

## Como funciona
- Simula a realização de pagamentos com cartão de crédito (simulando uma requisitação via rota Gateway) 
- Faz o gerenciamento de estoque de uma loja (Busca, remove e cadastra produtos)

## Testes Automatizados
#### Teste de integração
- Moca as tabelas do Banco de Dados e faz uso de stubs da tabelas para simular o comportamento real 
#### Teste de unitário
- Realiza a validação de uma annotation criada para validar data de expiração de cartão de crédito, dentro outros pontos da aplicação

## Autor
- Feito por [Yann Gabriel](https://www.linkedin.com/in/yann-gabriel-764abab6/)