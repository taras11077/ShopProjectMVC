using Microsoft.EntityFrameworkCore;
using ShopProjectMVC.Core.Interfaces;

namespace ShopProjectMVC.Storage.Repositories;

public class GenericRepository : IRepository
{
    private readonly ShopProjectContext _context;

    public GenericRepository(ShopProjectContext context)
    {
        _context = context;
    }

    public async Task<T> Add<T>(T entity) where T : class
    {
        var obj = _context.Add(entity);
        await _context.SaveChangesAsync();

        return obj.Entity;
    }

    public async Task Delete<T>(int id) where T : class
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity != null)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException("Entity not found");
        }
    }


    public IQueryable<T> GetAll<T>() where T : class
    {
        return _context.Set<T>();
    }


    public async Task<T> GetById<T>(int id) where T : class
    {
        return await _context.Set<T>().FindAsync(id);
    }



    public async Task<T> Update<T>(T entity) where T : class
    {
        var obj = _context.Entry(entity);
        if (obj.State == EntityState.Detached)
        {
            _context.Set<T>().Attach(entity);
        }
        obj.State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return obj.Entity;
    }
}
