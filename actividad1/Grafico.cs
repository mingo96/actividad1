


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

    public int x { get; private set; }

    public int y { get; private set; }

    public Punto(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    
    public void Dibujar()
    {
        throw new NotImplementedException();
    }

    public bool Mover(int x, int y)
    {
        throw new NotImplementedException();
    }
    
}

public class Circulo : Punto
{
    public Circulo(int x, int y) : base(x, y)
    {
    }
}