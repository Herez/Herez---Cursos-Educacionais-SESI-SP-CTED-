using Microsoft.EntityFrameworkCore;
using CatalogoCursosApi.Data;
using CatalogoCursosApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Banco de Dados (SQLite como padrão para fácil execução local)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection") 
        ?? "Data Source=catalogocursos.db"));

// Configuração de CORS para permitir requisições do Front-End
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Seed de dados iniciais no banco
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
    SeedDatabase(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();

// Função local de Seeding para garantir os requisitos mínimos de dados
void SeedDatabase(AppDbContext context)
{
    if (context.Cursos.Any()) return;

    var cursos = new List<Curso>
    {
        new Curso
        {
            NomeCompleto = "Desenvolvimento Web Fullstack com C# e .NET Core",
            NomeBreve = "Web .NET Core",
            Descricao = "Aprenda a construir aplicações web completas e modernas utilizando C#, ASP.NET Core e banco de dados relacional.",
            Categoria = "Tecnologia",
            Modalidade = "EAD",
            CargaHoraria = 120,
            PublicoAlvo = "Estudantes e profissionais de tecnologia",
            Status = "Inscrições Abertas",
            ImagemUrl = "https://picsum.photos/seed/dotnet/400/220",
            DataDisponibilizacao = new DateTime(2026, 3, 1)
        },
        new Curso
        {
            NomeCompleto = "Gestão Ágil de Projetos de Software com Scrum e Kanban",
            NomeBreve = "Gestão Ágil",
            Descricao = "Domine as principais metodologias ágeis utilizadas no mercado corporativo para otimizar entregas e liderar equipes.",
            Categoria = "Gestão",
            Modalidade = "EAD",
            CargaHoraria = 60,
            PublicoAlvo = "Gerentes de projetos, líderes técnicos e coordenadores",
            Status = "Em Andamento",
            ImagemUrl = "https://picsum.photos/seed/agile/400/220",
            DataDisponibilizacao = new DateTime(2026, 2, 15)
        },
        new Curso
        {
            NomeCompleto = "UX/UI Design: Fundamentos da Experiência do Usuário",
            NomeBreve = "UX/UI Design",
            Descricao = "Conceitos de arquitetura de informação, prototipagem no Figma e testes de usabilidade para interfaces digitais.",
            Categoria = "Design",
            Modalidade = "Presencial",
            CargaHoraria = 80,
            PublicoAlvo = "Designers, desenvolvedores front-end e entusiastas",
            Status = "Inscrições Abertas",
            ImagemUrl = "https://picsum.photos/seed/design/400/220",
            DataDisponibilizacao = new DateTime(2026, 4, 10)
        },
        new Curso
        {
            NomeCompleto = "Banco de Dados Relacional e SQL Avançado",
            NomeBreve = "SQL Avançado",
            Descricao = "Modelagem de dados, otimização de consultas, procedures, views e gestão de performance em SGBDs open-source.",
            Categoria = "Tecnologia",
            Modalidade = "EAD",
            CargaHoraria = 40,
            PublicoAlvo = "Desenvolvedores e analistas de dados",
            Status = "Encerrado",
            ImagemUrl = "https://picsum.photos/seed/database/400/220",
            DataDisponibilizacao = new DateTime(2026, 1, 10)
        },
        new Curso
        {
            NomeCompleto = "Liderança Eficaz no Ambiente Industrial 4.0",
            NomeBreve = "Liderança 4.0",
            Descricao = "Desenvolvimento de competências comportamentais, comunicação assertiva e gestão de conflitos no setor produtivo.",
            Categoria = "Gestão",
            Modalidade = "Presencial",
            CargaHoraria = 30,
            PublicoAlvo = "Supervisores e encarregados da indústria",
            Status = "Inscrições Abertas",
            ImagemUrl = "https://picsum.photos/seed/leadership/400/220",
            DataDisponibilizacao = new DateTime(2026, 5, 1)
        },
        new Curso
        {
            NomeCompleto = "Design System e Componentização Front-end",
            NomeBreve = "Design Systems",
            Descricao = "Criação de bibliotecas de componentes escaláveis e alinhadas entre design e desenvolvimento web.",
            Categoria = "Design",
            Modalidade = "EAD",
            CargaHoraria = 50,
            PublicoAlvo = "Front-end Developers e Product Designers",
            Status = "Em Andamento",
            ImagemUrl = "https://picsum.photos/seed/components/400/220",
            DataDisponibilizacao = new DateTime(2026, 2, 1)
        }
    };

    context.Cursos.AddRange(cursos);
    context.SaveChanges();
}