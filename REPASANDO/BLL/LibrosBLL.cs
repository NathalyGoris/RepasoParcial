using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public class PrioridadesBLL{
    private Context _context;

    public PrioridadesBLL(Context context)
    {
        _context = context;
    }

    public bool Existe(int LibroId)
    {
        return _context.Libros.Any(o => o.LibroId == LibroId);
    }

    private bool Insertar(Libros 	Libros)
    {
        _context.Libros.Add(Libros);
        return _context.SaveChanges() > 0;
    }

    private bool Modificar(Libros Libros)
    {
        var existe = _context.Libros.Find(Libros.LibroId);
        if(existe != null)
        {
            _context.Entry(existe).CurrentValues.SetValues(Libros);
            return _context.SaveChanges() > 0;
        }

        return false;
    }

    public bool Guardar(Libros Libros){
        if(!Existe(Libros.LibroId))
            return this.Insertar(Libros);
        else
            return this.Modificar(Libros);
    }

    public bool Eliminar(int LibroId)
    {
        var eliminado  = _context.Libros.Where(o=> o.LibroId== LibroId).SingleOrDefault();

        if(eliminado!=null){
            _context.Entry(eliminado).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        return false;
    }

    public Libros? Buscar(int LibroId)
    {
        return _context.Libros.Where(o => o.LibroId == LibroId).AsNoTracking().SingleOrDefault();
    }

    public List<Libros> GetList(Expression<Func<Libros, bool>> criterio)
    {
        return _context.Libros
        .AsNoTracking()
        .Where(criterio)
        .ToList();
    }     
}