using EspacioTareas;

List<Tarea> tareasPendientes = new List<Tarea>();
Random random = new Random();
int N = 0;
for (int i = 0; i < N; i++)
{
    Tarea tarea = new Tarea
    {
        TareaID = i + 1,
        Descripcion = $"Tarea {i + 1}",
        Duracion = random.Next(10, 101)
    };
    tareasPendientes.Add(tarea);
}

List<Tarea> tareasRealizadas = new List<Tarea>();

void CrearTareaPendiente(List<Tarea> pendientes, string descripcion, int Duracion)
{
    if (Duracion < 10 || Duracion > 100)
    {
        Console.WriteLine("La duracion debe estar entre 10 y 100");
        return;
    }
    int nuevoID = pendientes.Count > 0 ? pendientes.Max(t => t.TareaID) + 1 : 1;
    Tarea nuevaTarea = new Tarea
    {
        TareaID = nuevoID,
        Descripcion = descripcion,
        Duracion = Duracion
    };
    pendientes.Add(nuevaTarea);
    Console.WriteLine($"Tarea creada: ID {nuevaTarea.TareaID}, Descripcion: {nuevaTarea.Descripcion}, Duracion: {nuevaTarea.Duracion}");
    Console.WriteLine("Tarea pendiente agregada a la lista de pendientes");
}



void MoverTarea(List<Tarea> pendientes, List<Tarea> realizadas, int TareaID)
{
    Tarea tarea = pendientes.FirstOrDefault(t => t.TareaID == TareaID);
    if (tarea != null)
    {
        pendientes.Remove(tarea);
        realizadas.Add(tarea);
        Console.WriteLine($"Tarea {tarea.TareaID} movida a realizada");
    }
    else
    {
        Console.WriteLine($"Tarea con ID {TareaID} no encontrada en pendientes");
    }
}


void BuscarTareaPorDescripcion(List<Tarea> pendientes, string descripción)
{
    var tareasEncontradas = pendientes.Where(t => t.Descripcion.Contains(descripción, StringComparison.OrdinalIgnoreCase)).ToList();
    if (tareasEncontradas.Any())
    {
        Console.WriteLine("Tareas encontradas:");
        foreach (var tarea in tareasEncontradas)
        {
            Console.WriteLine($"ID: {tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
        }
    }
    else
    {
        Console.WriteLine($"No se encontro la tarea con la descripcion: {descripción}");
    }
}


void MostrarTareas(List<Tarea> pendientes, List<Tarea> realizadas)
{
    Console.WriteLine("Tareas Pendientes: ");
    foreach (var tarea in pendientes)
    {
        Console.WriteLine($"ID: {tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
    }

    Console.WriteLine("Tareas Realizadas: ");
    foreach (var tarea in realizadas)
    {
        Console.WriteLine($"ID: {tarea.TareaID}, Descripcion: {tarea.Descripcion}, Duracion: {tarea.Duracion}");
    }
}


while (true)
{
    Console.WriteLine("Menu de tareas:");
    Console.WriteLine("1. Crear tarea pendiente");
    Console.WriteLine("2. Mostrar todas las tareas");
    Console.WriteLine("3. Mover tarea de pendientes a realizadas");
    Console.WriteLine("4. Buscar tarea por descripcion");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opcion: ");
    string opcion = Console.ReadLine();

    switch (opcion)
    {
        case "1":
            Console.Write("Ingrese la descripcion de la tarea: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese la duracion de la tarea (entre 10 y 100): ");
            if (int.TryParse(Console.ReadLine(), out int duracion))
            {
                CrearTareaPendiente(tareasPendientes, descripcion, duracion);
            }else
            {
                Console.WriteLine("Duracion invalida, debe ser un numero entre 10 y 100");
            }
            break;

        case "2":
            MostrarTareas(tareasPendientes, tareasRealizadas);
            break;

        case "3":
            Console.Write("Ingrese el ID de la tarea a mover: ");
            if (int.TryParse(Console.ReadLine(), out int TareaID))
            {
                MoverTarea(tareasPendientes, tareasRealizadas, TareaID);
            }
            else
            {
                Console.WriteLine("ID de la tarea invalido");
            }
            break;

        case "4":
            Console.Write("Ingrese la descripcion de la tarea a buscar: ");
            string descripcionNueva = Console.ReadLine();
            BuscarTareaPorDescripcion(tareasPendientes, descripcionNueva);
            break;

        case "5":
            Console.WriteLine("Saliendo del programa...");
            return;
    }
}