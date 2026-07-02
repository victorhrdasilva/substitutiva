using victor.api.Models;
using victor.api.Data;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>();

var app = builder.Build();


///api/pressao/listar
app.MapGet("/api/pressao/listar",
    ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Pressao.Any())
    {

        return Results.Ok(ctx.Pressao.ToList());
    }
    return Results.NotFound("Lista vazia!");
});

//api/pressao/cadastrar
app.MapPost("/api/pressao/cadastrar",
    ([FromBody] Pressao pressao,
    [FromServices] AppDataContext ctx) =>
{
    Pressao? resultado = ctx.Pressao.FirstOrDefault
        (x => x.nomePaciente == pressao.nomePaciente);

    if (resultado is not null)
    {
        return Results.Conflict("Essa pessoa já foi cadastrada!");
    }

    ctx.Pressao.Add(pressao);
    ctx.SaveChanges();
    return Results.Created("", pressao);
});



app.Run();
