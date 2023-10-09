


public interface Grafico
{
    public bool Mover(int x, int y);
    public void Dibujar();
}

public class GraficoCompuesto:Grafico
{

    public List<Grafico> ListaGraficos = new List<Grafico>();
    
    public bool Mover(int x, int y)
    {
        throw new NotImplementedException();
    }

    public void Dibujar()
    {
        throw new NotImplementedException();
    }
    
}

public abstract class Punto:Grafico
{

    public int X { get; private set; }

    public int Y { get; private set; }

    public Punto(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    
    public void Dibujar()
    {
        Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y);
    }

    public bool Mover(int x, int y)
    {
        return x >= 0 && x <= 800 && y >= 0 && y <= 600;
    }
    
}

public class Circulo : Punto
{
    
    public int Radio { get; private set; }
    
    public Circulo(int x, int y,int radio) : base(x, y)
    {
        this.Radio = radio;
        if (x+radio>800 || x - radio <0 || y+radio>600 || y-radio<0)
        {
            throw new Exception("tas pasau");
        }
    }

    public new void Dibujar()
    {
        Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y + ", radio = " + Radio);
    }

    public new bool Mover(int x, int y)
    {
        return true;
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
    }
    
    public new void Dibujar()
    {
        Console.WriteLine("posicion x = " + X + ", posicion Y = " + Y + ", alto = " + Alto + ", ancho = " + Ancho);
    }
    
    public new bool Mover(int x, int y)
    {
        return true;
    }
    
}

