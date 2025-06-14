namespace EspacioTareas;

public class Tarea
{
    public int TareaID { get; set; }
    public string Descripcion { get; set; }
    public int Duracion { get; set; } //validar que esta entre 10 y 100
}