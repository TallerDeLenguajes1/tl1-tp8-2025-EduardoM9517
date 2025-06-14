namespace miCalculadora;

public class Calculadora
{
    private double dato;
    public Calculadora(double valorInicial)
    {
        dato = valorInicial;
    }
    public void Sumar(double numeroSuma)
    {
        dato += numeroSuma;
    }

    public void Restar(double numeroResta)
    {
        dato -= numeroResta;
    }
    public void Dividir(double numeroDividir)
    {
        dato /= numeroDividir;
    }
    public void Multiplicar(double numeromultipli)
    {
        dato *= numeromultipli;
    }

    public void Limpiar()
    {
        dato = 0;
    }

    public double Resultado()
    {
        return dato;
    }
}