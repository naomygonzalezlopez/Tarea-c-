using System.Collections.Generic;
using System.Linq;
using SistemaVideojuegos.Models;
namespace SistemaVideojuegos.Services
{
public class VideojuegoService
{
private readonly List<Videojuego> _videojuegos;
private int _siguienteId;
public VideojuegoService()
{
_videojuegos = new List<Videojuego>
{
new Videojuego(1, "The Legend of Zelda", "Aventura", "Nintendo Switch", 59.99),
new Videojuego(2, "Elden Ring", "Acción/RPG", "PC / PS5", 69.99)
};
_siguienteId = 3;
}
public List<Videojuego> ObtenerTodos()
{
return _videojuegos;
}
public void Registrar(string titulo, string genero, string plataforma, double precio)
{
var nuevoJuego = new Videojuego(_siguienteId, titulo, genero, plataforma, precio);
_videojuegos.Add(nuevoJuego);
_siguienteId++;
}
public bool Eliminar(int id)
{
var juego = _videojuegos.FirstOrDefault(j => j.Id == id);
if (juego != null)
{
_videojuegos.Remove(juego);
return true;
}
return false;
}
}
}
