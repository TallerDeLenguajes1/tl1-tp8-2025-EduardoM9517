using miCalculadora;
using operaciones;

bool salir = false;
// Lista para almacenar el historial de operaciones
List<Operacion> historialOperaciones = new List<Operacion>();

Console.WriteLine("----------Mi Calculadora---------");
do
{
    int opcion;
    Console.WriteLine("1. Realizar Suma");
    Console.WriteLine("2. Realizar Resta");
    Console.WriteLine("3. Realizar Multiplicacion");
    Console.WriteLine("4. Realizar Division");
    Console.WriteLine("5. Limpiar");
    Console.WriteLine("6. Historial de operaciones");
    Console.WriteLine("7. Limpiar historial de operaciones");
    Console.Write("Seleccione una opcion: ");
    opcion = int.Parse(Console.ReadLine());
    var calculadora = new Calculadora(0);

    switch (opcion)
    {
        case 1:
            Console.Write("Ingrese el numero a sumar: ");
            double numeroSuma = double.Parse(Console.ReadLine());
            // Crear una nueva operacion de tipo Suma y agregarla al historial
            var operacionSuma = new Operacion(calculadora.Resultado(), numeroSuma, Operacion.TipoOperacion.Suma);
            historialOperaciones.Add(operacionSuma);
            // Realizar la suma
            calculadora.Sumar(numeroSuma);
            Console.WriteLine($"Resultado: {calculadora.Resultado()}");
            break;
        case 2:
            Console.Write("Ingrese el numero a restar: ");
            double numeroResta = double.Parse(Console.ReadLine());
            // Crear una nueva operacion de tipo Resta y agregarla al historial
            var operacionResta = new Operacion(calculadora.Resultado(), numeroResta, Operacion.TipoOperacion.Resta);
            historialOperaciones.Add(operacionResta);
            // Realizar la resta
            calculadora.Restar(numeroResta);
            Console.WriteLine($"Resultado: {calculadora.Resultado()}");
            break;
        case 3:
            Console.Write("Ingrese el numero a multiplicar: ");
            double numeromultipli = double.Parse(Console.ReadLine());
            // Crear una nueva operacion de tipo Multiplicacion y agregarla al historial
            var operacionMultiplicacion = new Operacion(calculadora.Resultado(), numeromultipli, Operacion.TipoOperacion.Multiplicacion);
            historialOperaciones.Add(operacionMultiplicacion);
            // Realizar la multiplicacion
            calculadora.Multiplicar(numeromultipli);
            Console.WriteLine($"Resultado: {calculadora.Resultado()}");
            break;
        case 4:
            Console.Write("Ingrese el numero a dividir: ");
            double numeroDividir = double.Parse(Console.ReadLine());
            // Crear una nueva operacion de tipo Division y agregarla al historial
            var operacionDividir = new Operacion(calculadora.Resultado(), numeroDividir, Operacion.TipoOperacion.Division);
            historialOperaciones.Add(operacionDividir);
            // Realizar la division, verificando que no sea por cero
            if (numeroDividir != 0)
            {
                calculadora.Dividir(numeroDividir);
                Console.WriteLine($"Resultado: {calculadora.Resultado()}");
            }
            else
            {
                Console.WriteLine("No se puede dividir por cero");
            }
            break;
        case 5:
            calculadora.Limpiar();
            Console.WriteLine("Calculadora limpiada");
            break;
        case 6:
            Console.WriteLine("Historial de operaciones:");
            foreach (var operacion in historialOperaciones)
            {
                Console.WriteLine(operacion);
            }
            if (historialOperaciones.Count == 0)
            {
                Console.WriteLine("No hay operaciones en el historial");
            }
            break;
        case 7:
            historialOperaciones.Clear();
            Console.WriteLine("Historial de operaciones limpiado");
            break;
    }
    if (opcion < 1 || opcion > 7)
    {
        Console.WriteLine("Opcion no valida, por favor intente de nuevo");
        salir = true;
    }
    else
    {
        Console.WriteLine("¿Desea realizar otra operacion? (s/n)");
        string respuesta = Console.ReadLine().ToLower();
        salir = respuesta == "s" || respuesta == "si";
        if (!salir)
        {
            Console.WriteLine("Saliedo de la calculadora...");
        }
        else
        {
            Console.WriteLine("Continuando con la calculadora...");
        }
    }
} while (salir);