# Registro de Uso de Inteligência Artificial

Este documento descreve a utilização de ferramentas de Inteligência Artificial no processo de desenvolvimento da aplicação do catálogo de cursos.

## 1. Ferramenta Utilizada
* **IA Utilizada:** Chatbot / Assistente Baseado em LLM (Gemini / ChatGPT).

## 2. Objetivo do Uso
* Auxiliar na estruturação inicial dos modelos de dados em C#/.NET.
* Acelerar a geração de dados fictícios em formato JSON para pré-popular a base de dados.
* Validação rápida da lógica dos filtros combinados via LINQ no Entity Framework Core.

## 3. Prompts Relevantes e Filtragem do Conteúdo

### Prompt: Estruturação dos dados fictícios
> *"Gere um arquivo JSON com 6 cursos fictícios contendo: nome completo, nome breve, descrição, categoria (mínimo 3 distintas), modalidade (mínimo 2 distintas), status (mínimo 3 distintos), carga horária e público-alvo."*

* **Aproveitado:** Os textos descritivos e a estrutura base do JSON para criação dos mocks.
* **Descartado:** Nomes de propriedades gerados em padrão camelCase genérico que divergiam das nomenclaturas em C#.

## 4. Validação do Conteúdo
Todo o código e modelo gerados pela IA foram revisados e testados manualmente:
* Compilação do código em C# e testes dos endpoints REST via Swagger/Postman.
* Garantia de que a API retornava o formato correto esperado pelo front-end.

## 5. Exemplo de Erro / Inadequação Identificado e Correção
* **Erro Identificado:** A consulta inicial gerada pela IA para os filtros combinados aplicava o operador de junção `OR` em vez de `AND`, fazendo com que a pesquisa retornasse registros que atendiam a apenas *um* dos critérios, em vez de refinar a busca.
* **Correção Realizada:** O código LINQ foi corrigido para encadear os filtros `Where` progressivamente, garantindo a junção lógica `AND`:

```csharp
// Código Corrigido
var query = _context.Cursos.AsQueryable();

if (!string.IsNullOrEmpty(pesquisa))
    query = query.Where(c => c.NomeCompleto.Contains(pesquisa));

if (!string.IsNullOrEmpty(categoria))
    query = query.Where(c => c.Categoria == categoria);

if (!string.IsNullOrEmpty(modalidade))
    query = query.Where(c => c.Modalidade == modalidade);

if (!string.IsNullOrEmpty(status))
    query = query.Where(c => c.Status == status);
```