using System;
namespace victor.api.Models;

public class Pressao
{
    public int Id { get; set; }
    public string? nomePaciente { get; set; }
    public int pressaoMaxima { get; set; }
    public int pressaoMinima { get; set; }
    public string? classificacao { get; set; }
    public DateTime dataRegistro { get; set; } = DateTime.Now;
}