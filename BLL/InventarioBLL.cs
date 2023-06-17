using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GeekEngineer.Data;

public class InventarioBLL
{
    private ApplicationDbContext contexto;
    public InventarioBLL(ApplicationDbContext _contexto)
    {
        contexto = _contexto;
    }

    public bool Existe(int inventarioId)
    {
        return contexto.Inventarios.Any(p => p.InventarioId == inventarioId);
    }  

    private bool Insertar(Inventarios inventario)
    {
        contexto.Inventarios.Add(inventario);
        return contexto.SaveChanges() > 0;
    }

    private bool Modificar(Inventarios inventario)
    {
        var existe = contexto.Inventarios.Find(inventario.InventarioId);

        if (existe != null)
        {
            contexto.Entry(existe).CurrentValues.SetValues(inventario);
            return contexto.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Inventarios inventario)
    {
        if (!Existe(inventario.InventarioId))
            return Insertar(inventario);
        else
            return Modificar(inventario);
    }

    public bool Eliminar(int inventarioId)
    {
        var eliminado = contexto.Inventarios
        .Where(p => p.InventarioId == inventarioId)
        .SingleOrDefault();

        if(eliminado != null)
        {
            eliminado.Status = false;
            return contexto.SaveChanges() > 0;
        }
        
        return false;
    }

    public Inventarios? Buscar(Inventarios inventario)
    {
         var valor =  contexto.Inventarios.Find(inventario.InventarioId);

        if(valor != null)
        {
            if(valor.Status == true)
            return contexto.Inventarios
            .Where(p => p.InventarioId == valor.InventarioId)
            .AsNoTracking()
            .SingleOrDefault();
        else
            return null;
        }
        
        return null;
    }

    public List<Inventarios> GetList(Expression<Func<Inventarios, bool>> criterio)
    {
        return contexto.Inventarios.AsNoTracking().Where(criterio).ToList();
    }
}