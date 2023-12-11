
Console.WriteLine("creando un punto\nintroduce x e y de el punto separados por ,:");

try
{

var datos = Console.ReadLine().Split(",");

Punto punto = new Punto(Int32.Parse(datos[0]), Int32.Parse(datos[1]));

Console.WriteLine("creando un circulo\nintroduce x ,y y radio de el circulo separados por ,:");

datos= Console.ReadLine().Split(",");

Circulo circulo = new Circulo(Int32.Parse(datos[0]), Int32.Parse(datos[1]),Int32.Parse(datos[2]) );

Console.WriteLine("creando un rectangulo\nintroduce x, y, ancho y alto de el rectangulo separados por ,:");

datos= Console.ReadLine().Split(",");

Rectangulo rectangulo =new Rectangulo(Int32.Parse(datos[0]), Int32.Parse(datos[1]),Int32.Parse(datos[2]),Int32.Parse(datos[3]));

GraficoCompuesto graficoCompuesto = new GraficoCompuesto();

graficoCompuesto.AñadirGrafico(punto);
graficoCompuesto.AñadirGrafico(circulo);
graficoCompuesto.AñadirGrafico(rectangulo);
Console.WriteLine(graficoCompuesto.Dibujar());

Console.WriteLine("siguiente :\n1. Mover el grafico\n2. Salir");

var dato = Console.ReadLine();

while (dato != "2")
{
    if (dato =="1")
    {
        Console.WriteLine("introduce posiciones a mover, formato x,y");
        datos = Console.ReadLine().Split(",");
        if(graficoCompuesto.Mover(Int32.Parse(datos[0]), Int32.Parse(datos[1])))
            Console.WriteLine(graficoCompuesto.Dibujar());
        else
        {
            Console.WriteLine("error, movimientos no validos");
        }
        
        Console.WriteLine("siguiente :\n1. Mover el grafico\n2. Salir");
        
        dato = Console.ReadLine();
    }

    else
    {
        Console.WriteLine("introduce un valor valido");
    }
    
}

Console.WriteLine("adios");

}
catch (Exception e)
{
    Console.WriteLine("error en la creación de objetos");
}
public class EditorGrafico
{
    public List<IGrafico> ListaGraficos = new List<IGrafico>();

    public void Añadir(IGrafico grafico)
    {
        ListaGraficos.Add(grafico);
    }
}

public interface IGrafico
{
    public bool Mover(int x, int y);
    public String Dibujar();

    public void MovimientoEsValido(int x, int y);
}

public class GraficoCompuesto:IGrafico
{

    public List<IGrafico> ListaGraficos = new List<IGrafico>();

    public void AñadirGrafico(IGrafico grafico)
    {
        ListaGraficos.Add(grafico);
    }
    
    public bool Mover(int x, int y)
    {
        try
        {
            
            MovimientoEsValido(x,y);
            
            return true;
            
        }
        catch (Exception)
        {
            return false;
        }

    }

    public String Dibujar()
    {
        var respuesta = "";
        respuesta += "grafico compuesto por:\n___________________\n";
        foreach (var grafico in ListaGraficos)
        {
            respuesta += grafico.Dibujar();
        }    
        respuesta +="___________________\n";
        return respuesta;
    }

    public void MovimientoEsValido(int x, int y)
    {
        foreach (var grafico in ListaGraficos)
        {
            if(!grafico.Mover(x, y)) throw new Exception("movimiento no valido");
        }
    }
}

public class Punto:IGrafico
{

    public int X { get; private set; }

    public int Y { get; private set; }

    public Punto(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    
    public virtual String Dibujar()
    {
        return "posicion x = " + X + ", posicion Y = " + Y +"\n";
    }

    public bool Mover(int x, int y)
    {
        try
        {
            MovimientoEsValido(x+X,y+Y);
            X += x;
            Y += y;
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual void MovimientoEsValido(int x, int y)
    {
        if (x < 0 || x > 800 || y < 0 || y > 600)
        {
            throw new Exception("tas pasau");
        }
    }
}

public class Circulo : Punto
{
    
    public int Radio { get; private set; }
    
    public Circulo(int x, int y,int radio) : base(x, y)
    {
        this.Radio = radio;
        MovimientoEsValido(x,y);
        
    }

    public override String Dibujar()
    {
        return "posicion x = " + X + ", posicion Y = " + Y + ", radio = " + Radio + "\n";
    }

    public sealed override void MovimientoEsValido(int x, int y)
    {
        if (x + Radio > 800 || x - Radio < 0 || y + Radio > 600 || y - Radio < 0)
        {
            throw new Exception("tas pasau");
        }
    }

}

public class Rectangulo : Punto
{
    
    public int Ancho { get; private set; }
    
    public int Alto { get; private set; }
    
    public Rectangulo(int x, int y,int ancho, int alto) : base(x, y)
    {
        this.Ancho = ancho;
        this.Alto = alto;
        
        MovimientoEsValido(x,y);
    }

    public override String Dibujar()
    {
     return "posicion x = " + X + ", posicion Y = " + Y + ", alto = " + Alto + ", ancho = " + Ancho + "\n";
    }

    public sealed override void MovimientoEsValido(int x, int y)
    {
        if ((Ancho / 2)+x>800|| x-(Ancho / 2)<0 || (Alto / 2)+y>600|| y-(Alto / 2) <0)
        {
            throw new Exception("tas pasau");
        }
    }
}

