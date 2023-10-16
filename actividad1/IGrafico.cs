


public interface IGrafico
{
    public bool Mover(int x, int y);
    public void Dibujar();

    public void Comprobar(int x, int y);
}

public class GraficoCompuesto:IGrafico
{

    public List<IGrafico> ListaGraficos = new List<IGrafico>();
    
    public bool Mover(int x, int y)
    {
        foreach (var grafico in ListaGraficos)
        {
            
        }
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        Console.WriteLine("grafico compuesto por:\n___________________");
        foreach (var grafico in ListaGraficos)
        {
            grafico.Dibujar();
        }    
        Console.WriteLine("___________________");
    }

    public void Comprobar(int x, int y)
    {
        throw new NotImplementedException();
    }
}

public abstract class Punto:IGrafico
{

    public int X { get; private set; }

    public int Y { get; private set; }

    public Punto(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    
    public virtual void Dibujar()
    {
        Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y);
    }

    public bool Mover(int x, int y)
    {
        try
        {
            Comprobar(x,y);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public virtual void Comprobar(int x, int y)
    {
        if (x >= 0 && x <= 800 && y >= 0 && y <= 600)
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
        Comprobar(x,y);
        
    }

    public override void Dibujar()
    {
        Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y + ", radio = " + Radio);
    }

    public sealed override void Comprobar(int x, int y)
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
        
        Comprobar(x,y);
    }

    public override void Dibujar()
    {
    Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y + ", alto = " + Alto + ", ancho = " + Ancho);
    }

    public sealed override void Comprobar(int x, int y)
    {
        if (Ancho/2+x>800||Ancho/2-x<0 || Alto/2+y>600||Alto/2-y <0)
        {
            throw new Exception("tas pasau");
        }
    }
}

