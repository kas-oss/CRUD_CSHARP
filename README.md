# Desafio Técnico: CRUD C# (ASP.NET Core MVC)

Olá, bem-vindo(a) ao nosso desafio técnico.

Esta é uma aplicação web simples em **ASP.NET Core MVC** estruturada para o gerenciamento de **Motoristas** e **Veículos**. A parte de "Motoristas" já está pronta e funcional, e o objetivo deste teste é que você use essa base para implementar a parte de "Veículos".

## Antes de começar (Leia com atenção)

Sabemos que testes técnicos podem gerar ansiedade, então queremos deixar algumas coisas claras para você ficar tranquilo:

1.  **Não buscamos a perfeição:** O principal objetivo aqui é entender como você raciocina e organiza seu código.
2.  **Qualidade é melhor que quantidade:** Se o tempo estiver curto, não corra para entregar tudo de qualquer jeito. É melhor entregar uma funcionalidade bem feita e estável do que o projeto todo com erros.
3.  **Não conseguiu terminar? Envie mesmo assim:** Avaliamos o seu esforço e o que foi produzido. Se travar em alguma etapa, faça até onde conseguir. Isso já nos ajuda a conhecer suas habilidades atuais.
4.  **Use o código existente:** O CRUD de `Motoristas` está pronto justamente para servir de exemplo. Você pode (e deve) consultá-lo para entender como criar o de `Veiculos`.

## O Objetivo

Sua tarefa é usar o projeto atual para:

* Implementar o CRUD completo de **Veiculos** no arquivo `Controllers/VeiculosController.cs`.
* Criar as Views correspondentes na pasta `Views/Veiculos` (telas de `Index`, `Details`, `Create`, `Edit`, `Delete`).

Tente seguir o mesmo padrão de organização e nomenclatura que já foi utilizado no controlador de Motoristas.

## Requisitos

* **.NET SDK:** Versão `9.0.x`
* **Git** (para clonar o repositório)
* Sua IDE de preferência (Visual Studio [recomendado], VS Code.)

## Guia de instalação do projeto
* Instale o Visual Studio (Essa é a melhor IDE para te ajudar a programar em C#): [Clique aqui para baixar](https://visualstudio.microsoft.com/pt-br/downloads/)
* O projeto está em .NET 9.0.X, você precisará baixar e instalar o SDK, também: [Clique aqui para baixar](https://dotnet.microsoft.com/pt-br/download/dotnet/9.0)
* Preparei um vídeo te mostrando como configurar o projeto no windows: Em breve estará aqui! [Clique aqui para assistir](https://lucasoss.com.br/)

## Passo a passo

Este repositório é público. Para começar:

1.  Faça um **fork** deste repositório para o seu GitHub.
2.  Clone o seu fork para sua máquina.
3.  Rode o projeto antes de alterar qualquer coisa para garantir que tudo está funcionando.
4.  Implemente as funcionalidades solicitadas.
5.  Faça commits descritivos conforme for evoluindo o código.

## Como entregar

Você pode entregar de duas formas:

1.  **Pull Request:** Abra um PR para a branch `main` do repositório original explicando brevemente o que foi feito.
2.  **E-mail:** Envie o link do seu repositório para **ti@solutionmais.com.br**.

*Sinta-se à vontade para comentar no e-mail ou no PR sobre quaisquer dificuldades que teve ou decisões que tomou durante o desenvolvimento.*

## Rotas principais da aplicação

* Home: `/`
* Motoristas: `/Motoristas` (Exemplo para consulta)
* Veículos: `/Veiculos` (Onde você vai trabalhar)

## Observação

A persistência dos dados é feita **em memória** (listas estáticas). Isso significa que, se você reiniciar a aplicação, os dados cadastrados serão perdidos. Isso é o comportamento esperado para este teste, não se preocupe em configurar banco de dados.

Boa sorte e bom trabalho!
