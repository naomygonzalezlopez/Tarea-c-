using System;
using Spectre.Console;
using SistemaVideojuegos.Services;
using SistemaVideojuegos.Models;
namespace SistemaVideojuegos
{
internal class Program
{
private static readonly VideojuegoService _servicio = new VideojuegoService();
static void Main(string[] args)
{
bool salir = false;
while (!salir)
{
AnsiConsole.Clear();
AnsiConsole.Write(
new FigletText("Game Zone")
.Centered()
.Color(Color.Purple));
AnsiConsole.MarkupLine("[bold white]Sistema de Gestión de Videojuegos[/]\n");
var opcion = AnsiConsole.Prompt(
new SelectionPrompt<string>()
.Title("[yellow]Seleccione una acción:[/]")
.AddChoices(new[] {
"1. Listar Videojuegos",
"2. Registrar Videojuego",
"3. Eliminar Videojuego",
"4. Salir"
}));
switch (opcion)
{
case "1. Listar Videojuegos":
MostrarInventario();
break;
case "2. Registrar Videojuego":
FormularioRegistrar();
break;
case "3. Eliminar Videojuego":
FormularioEliminar();
break;
case "4. Salir":
salir = true;
AnsiConsole.MarkupLine("[bold red]¡Programa finalizado correctamente![/]");
break;
}
if (!salir)
{
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[grey]Presione cualquier tecla para volver al menú...[/]");
Console.ReadKey(true);
}
}
}
private static void MostrarInventario()
{
AnsiConsole.Clear();
AnsiConsole.MarkupLine("[bold purple]=== CATÁLOGO DE VIDEOJUEGOS ===[/]\n");
var juegos = _servicio.ObtenerTodos();
if (juegos.Count == 0)
{
AnsiConsole.MarkupLine("[yellow]El catálogo está vacío.[/]");
return;
}
var tabla = new Table().Border(TableBorder.Square);
tabla.AddColumn("[bold magenta]ID[/]");
tabla.AddColumn("[bold magenta]Título[/]");
tabla.AddColumn("[bold magenta]Género[/]");
tabla.AddColumn("[bold magenta]Plataforma[/]");
tabla.AddColumn("[bold magenta]Precio[/]");
foreach (var juego in juegos)
{
tabla.AddRow(
juego.Id.ToString(),
juego.Titulo,
juego.Genero,
juego.Plataforma,
$"${juego.Precio:F2}"
);
}
AnsiConsole.Write(tabla);
}
private static void FormularioRegistrar()
{
AnsiConsole.Clear();
AnsiConsole.MarkupLine("[bold purple]=== REGISTRAR NUEVO JUEGO ===[/]\n");
var titulo = AnsiConsole.Ask<string>("Título del videojuego:");
var genero = AnsiConsole.Ask<string>("Género:");
var plataforma = AnsiConsole.Ask<string>("Plataforma:");
var precio = AnsiConsole.Ask<double>("Precio en tienda ($):");
_servicio.Registrar(titulo, genero, plataforma, precio);
AnsiConsole.MarkupLine("\n[bold green]✓ Juego añadido al catálogo con éxito.[/]");
}
private static void FormularioEliminar()
{
AnsiConsole.Clear();
AnsiConsole.MarkupLine("[bold red]=== ELIMINAR VIDEOJUEGO ===[/]\n");
MostrarInventario();
AnsiConsole.WriteLine();
var id = AnsiConsole.Ask<int>("[yellow]Ingrese el ID del juego a eliminar:[/]");
if (AnsiConsole.Confirm("[red]¿Seguro que quiere borrar este juego de forma permanente?[/]"))
{
bool eliminado = _servicio.Eliminar(id);
if (eliminado)
AnsiConsole.MarkupLine("\n[bold green]✓ Eliminado exitosamente.[/]");
else
AnsiConsole.MarkupLine("\n[bold red]✗ Código ID no encontrado.[/]");
}
else
{
AnsiConsole.MarkupLine("\n[yellow]Operación cancelada.[/]");
}
}
}
}
