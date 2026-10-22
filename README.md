# Herez - Catálogo de Cursos Educacionais (SESI-SP / CTED)

## 1. Objetivo da Aplicação
Aplicação web desenvolvida para apresentar um catálogo de cursos em um ambiente educacional Moodle. A solução permite que usuários consultem, pesquisem por texto, apliquem filtros combinados (categoria, modalidade, status) e visualizem detalhes completos de cada oferta.

## 2. Tecnologias Utilizadas
- **Back-end:** C# / .NET 8 (ASP.NET Core Web API)
- **Banco de Dados:** Entity Framework Core com banco SQLite / PostgreSQL
- **Front-end:** HTML5, CSS3 (Tailwind CSS) e JavaScript (ES6+)
- **Hospedagem:** https://sites.google.com/view/sesi-herez-com-br

---

## 3. Arquitetura da Solução e Estrutura de Pastas

A aplicação é dividida em dois componentes principais: uma API RESTful em C#/.NET para o back-end e uma interface web responsiva para o front-end.

```text
/
├── backend/
│   ├── Controllers/
│   │   └── CursosController.cs
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Models/
│   │   └── Curso.cs
│   ├── Program.cs
│   └── appsettings.json
├── frontend/
│   ├── assets/
│   │   └── css/
│   ├── js/
│   │   └── app.js
│   └── index.html
├── README.md
└── USO_DE_IA.md
```

---

## 4. Instruções para Execução Local

### Pré-requisitos
- .NET SDK 8.0+ instalado
- Navegador moderno

### Passos:
1. Clone este repositório:
   ```bash
   git clone https://github.com/seu-usuario/catalogo-cursos-sesi.git
   cd catalogo-cursos-sesi
   ```
2. Inicie o Back-end (API):
   ```bash
   cd backend
   dotnet restore
   dotnet run
   ```
   A API estará rodando em `https://localhost:7123`.
3. Abra a interface web:
   Navegue até a pasta `frontend` e abra o arquivo `index.html` em qualquer navegador.

---

## 5. Endpoints da API

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/cursos` | Lista todos os cursos (suporta `pesquisa`, `categoria`, `modalidade`, `status`). |
| `GET` | `/api/cursos/{id}` | Retorna as informações detalhadas de um curso específico por ID. |

---

## 6. Modelo de Dados

### Entidade `Curso`
- `Id` (int, chave primária)
- `NomeCompleto` (string)
- `NomeBreve` (string)
- `Descricao` (string)
- `Categoria` (string)
- `Modalidade` (string)
- `CargaHoraria` (int, em horas)
- `PublicoAlvo` (string)
- `Status` (string)
- `ImagemUrl` (string)
- `DataDisponibilizacao` (DateTime?)

---

## 7. Responsividade e Acessibilidade

### Estratégia de Responsividade
- Interface construída com CSS Flexbox e Grid Layout com suporte mobile-first.
- Adaptação dinâmica de telas de smartphones, tablets e monitores desktop.

### Decisões de Acessibilidade
- Marcação semântica HTML5 (`<header>`, `<main>`, `<section>`, `<article>`, `<footer>`).
- Contraste de cores adequado em conformidade com as diretrizes WCAG.
- Suporte a navegação por teclado e rótulos para leitores de tela (`aria-label`).

---

## 8. Limitações Conhecidas
- Gerenciamento de cadastro, edição ou exclusão de cursos (CRUD administrativo) não implementado por não fazer parte do escopo definido pelas instruções.
