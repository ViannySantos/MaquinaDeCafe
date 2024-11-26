using System;

class Vaso
{
    private int cantidadVasos;

    public Vaso(int cantidadVasos)
    {
        this.cantidadVasos = cantidadVasos;
    }

    public bool HasVasos()
    {
        return cantidadVasos > 0;
    }

    public bool GiveVasos()
    {
        if (HasVasos())
        {
            cantidadVasos--;
            return true;
        }
        else
        {
            Console.WriteLine("No hay suficientes vasos.");
            return false;
        }
    }
}

class Cafetera
{
    private int cantidadCafe;

    public Cafetera(int cantidadCafe)
    {
        this.cantidadCafe = cantidadCafe;
    }

    public bool HasCafe(int cantidadCafe)
    {
        return this.cantidadCafe >= cantidadCafe;
    }

    public bool GiveCafe(int cantidadCafe)
    {
        if (HasCafe(cantidadCafe))
        {
            this.cantidadCafe -= cantidadCafe;
            return true;
        }
        else
        {
            Console.WriteLine("No hay suficiente café.");
            return false;
        }
    }
}

class Azucarero
{
    private int cantidadAzucar;

    public Azucarero(int cantidadAzucar)
    {
        this.cantidadAzucar = cantidadAzucar;
    }

    public bool HasAzucar(int cantidadAzucar)
    {
        return this.cantidadAzucar >= cantidadAzucar;
    }

    public bool GiveAzucar(int cantidadAzucar)
    {
        if (HasAzucar(cantidadAzucar))
        {
            this.cantidadAzucar -= cantidadAzucar;
            return true;
        }
        else
        {
            Console.WriteLine("No hay suficiente azúcar.");
            return false;
        }
    }
}

class MaquinaDeCafe
{
    private Vaso vasosPequenos = new Vaso(10);
    private Vaso vasosMedianos = new Vaso(10);
    private Vaso vasosGrandes = new Vaso(10);
    private Cafetera cafetera = new Cafetera(100);
    private Azucarero azucarero = new Azucarero(50);

    public void ServirCafe(string tamano, int cantidadAzucar)
    {
        int cantidadCafe;

        if (tamano == "pequeno" && vasosPequenos.GiveVasos())
        {
            cantidadCafe = 3;
        }
        else if (tamano == "mediano" && vasosMedianos.GiveVasos())
        {
            cantidadCafe = 5;
        }
        else if (tamano == "grande" && vasosGrandes.GiveVasos())
        {
            cantidadCafe = 7;
        }
        else
        {
            Console.WriteLine("Opción de tamaño no válida o no hay vasos disponibles.");
            return;
        }

        if (cafetera.GiveCafe(cantidadCafe) && azucarero.GiveAzucar(cantidadAzucar))
        {
            Console.WriteLine($"Disfruta tu café {tamano} con {cantidadAzucar} cucharada(s) de azúcar!");
        }
        else
        {
            Console.WriteLine("No se pudo servir el café.");
        }
    }
}

class Program
{
    static void Main()
    {
        MaquinaDeCafe maquina = new MaquinaDeCafe();

        while (true)
        {
            Console.WriteLine("\nBienvenido a la máquina de café.");
            Console.WriteLine("1. Vaso pequeño - 3 Oz de café");
            Console.WriteLine("2. Vaso mediano - 5 Oz de café");
            Console.WriteLine("3. Vaso grande - 7 Oz de café");
            Console.WriteLine("4. Salir");
            Console.Write("Elige el tamaño del café (1, 2, 3) o presiona '4' para salir: ");

            string opcion = Console.ReadLine();

            if (opcion == "4")
            {
                Console.WriteLine("Gracias por visitarnos, disfrute su café");
                break;
            }

            Console.Write("¿Cuántas cucharadas de azúcar deseas?: ");
            if (!int.TryParse(Console.ReadLine(), out int cantidadAzucar))
            {
                Console.WriteLine("Entrada no válida. Intente de nuevo.");
                continue;
            }

            string tamanoCafe = opcion switch
            {
                "1" => "pequeno",
                "2" => "mediano",
                "3" => "grande",
                _ => null
            };

            if (tamanoCafe != null)
            {
                maquina.ServirCafe(tamanoCafe, cantidadAzucar);
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}
