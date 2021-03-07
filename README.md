## Projeto PracteceService 

Este projeto é um exemplo simples de uma solução que criei para 
um recente problema que passei em um projeto, decidi compartilhar minha ideia. 

### `Teste unitário e fluxo de teste` 

Implementação de teste unitários em projetos é claramente indispensável, 
este projeto serve de exemplo para implantação de teste unitários que seguem um fluxo. 

### `xUnit Test`

A projeto PracteceService.Test foi feito em xUnit para testar a API principal da solução.

A pasta API: contém as classes de testes, nosso fuco é na classe GeneralTests que contém 
os métodos de execução (Fact) e de ordenação TestCaseOrderer e TestPriority() que permite 
dar prioridade de execução;

O TestPriority() é feito através das classes PriorityOrderer e TestPriorityAttribute 
contido na pasta Orderers. TestPriority(1) permite que os métodos de testes sejam 
executados em ordem segundo um fluxo de regras de negócios do projeto. 
