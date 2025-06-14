namespace operaciones;

public class Operacion
{
    private double resultadoAnterior; //Almacena el resultado de la operacion anterior
    private double nuevoValor; //El valor con el que se opera sobre el resultado anterior
    private TipoOperacion operacion; //El tipo de operacion que se realiza
    public double Resultado
    {
        /* Logica para calcular o devolver el resultado */
        get
        {
            switch (operacion)
            {
                case TipoOperacion.Suma:
                    return resultadoAnterior + nuevoValor;
                case TipoOperacion.Resta:
                    return resultadoAnterior - nuevoValor;
                case TipoOperacion.Multiplicacion:
                    return resultadoAnterior * nuevoValor;
                case TipoOperacion.Division:
                    if (nuevoValor != 0)
                        return resultadoAnterior / nuevoValor;
                    else
                        throw new DivideByZeroException("No se puede dividir en cero");
                case TipoOperacion.Limpiar:
                    return 0;
                default:
                    throw new InvalidOperationException("Operacion no valida");
            }
        }
    }

    // Propiedad publica para acceder al nuevo valor utilizado en la operacion

    public double NuevoValor
    {
        get { return nuevoValor; }
        set { nuevoValor = value; }
    }

    // Constructor u otros metodos para inicializar y realizar operaciones
    public Operacion(double resultadoAnterior, double nuevoValor, TipoOperacion operacion)
    {
        this.resultadoAnterior = resultadoAnterior;
        this.nuevoValor = nuevoValor;
        this.operacion = operacion;
    }

    public enum TipoOperacion
    {
        Suma,
        Resta,
        Multiplicacion,
        Division,
        Limpiar //Representa la accion de borrar el resultado actual o el historial 
    }

    public override string ToString()
    {
        return $"Operacion: {operacion}, Resultado: {Resultado}, Nuevo Valor: {NuevoValor}";
    }
    public void ActualizarResultadoAnterior()
    {
        resultadoAnterior = Resultado;
    }
    public void Limpiar()
    {
        resultadoAnterior = 0;
        nuevoValor = 0;
        operacion = TipoOperacion.Limpiar;
    }
    public double ObtenerResultadoAnterior()
    {
        return resultadoAnterior;
    }
    public void EstablecerResultadoAnterior(double valor)
    {
        resultadoAnterior = valor;
    }
    public void EstablecerNuevoValor(double valor)
    {
        nuevoValor = valor;
    }
    public void EstablecerOperacion(TipoOperacion tipoOperacion)
    {
        operacion = tipoOperacion;
    }
    public TipoOperacion obtenerOperacion()
    {
        return operacion;
    }
    public double ObtenerNuevoValor()
    {
        return nuevoValor;
    }
    public double ObtenerResultado()
    {
        return Resultado;
    }
}
