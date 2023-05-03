using WebApplicationTestExceptions.Db;
using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Repositories;

public class DbToysRepository : IToysRepository
{
    private ToysSharpDbContext _db;

    public DbToysRepository(ToysSharpDbContext db)
    {
        _db = db;
    }

    public List<Toy> GetAll()
    {
        return _db.Toys.ToList();
    }

    public Toy GetByName(string name)
    {
        return _db.Toys.FirstOrDefault(toy => toy.Name == name);
    }

    public int GetToysCount()
    {
        return _db.Toys.Count();
    }

    public void AddNewToy(Toy toy)
    {
        _db.Toys.Add(toy);
        _db.SaveChanges();
    }
}