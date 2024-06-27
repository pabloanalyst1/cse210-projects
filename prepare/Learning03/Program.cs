using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor sin parámetros que inicializa la fracción a 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor que inicializa el numerador y establece el denominador a 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor que inicializa el numerador y el denominador con valores proporcionados
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters y Setters para _top y _bottom
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // Método para obtener la representación de la fracción como cadena
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Método para obtener el valor decimal de la fracción
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning03 World!");

        // Crear instancias de Fraction usando los tres constructores
        Fraction fraction1 = new Fraction();          // 1/1
        Fraction fraction2 = new Fraction(6);         // 6/1
        Fraction fraction3 = new Fraction(6, 7);      // 6/7

        // Verificar los valores iniciales
        Console.WriteLine(fraction1.GetFractionString()); // Output: 1/1
        Console.WriteLine(fraction2.GetFractionString()); // Output: 6/1
        Console.WriteLine(fraction3.GetFractionString()); // Output: 6/7

        // Usar getters y setters para cambiar y obtener valores
        fraction1.SetTop(3);
        fraction1.SetBottom(4);
        Console.WriteLine(fraction1.GetFractionString()); // Output: 3/4

        // Obtener valores decimales
        Console.WriteLine(fraction1.GetDecimalValue()); // Output: 0.75
        Console.WriteLine(fraction3.GetDecimalValue()); // Output: 0.8571428571428571

        // Verificar getters
        Console.WriteLine("Numerador de fraction1: " + fraction1.GetTop()); // Output: 3
        Console.WriteLine("Denominador de fraction1: " + fraction1.GetBottom()); // Output: 4

        // Verificar setters
        fraction2.SetTop(5);
        fraction2.SetBottom(2);
        Console.WriteLine(fraction2.GetFractionString()); // Output: 5/2
    }
}
