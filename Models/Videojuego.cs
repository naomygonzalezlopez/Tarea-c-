using System;
namespace SistemaVideojuegos.Models
{
public class Videojuego
{
public int Id { get; set; }
public string Titulo { get; set; } = string.Empty;
public string Genero { get; set; } = string.Empty;
public string Plataforma { get; set; } = string.Empty;
public double Precio { get; set; }
public Videojuego(int id, string titulo, string genero, string plataforma, double precio)
{
Id = id;
Titulo = titulo;
Genero = genero;
Plataforma = plataforma;
Precio = precio;
}
}
}

