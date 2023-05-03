using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Repositories;

public class ToysRepository : IToysRepository
{
    private List<Toy> _toys;

    public ToysRepository()
    {
        _toys = new List<Toy>()
        {
            new Toy() { Id = 1, Name = "Лего", Price = 900, AgeLimit = "3-5" },
            new Toy() { Id = 2, Name = "Мишка", Price = 200, AgeLimit = "0+" },
        };
    }

    public List<Toy> GetAll()
    {
        return _toys;
    }

    public Toy GetByName(string name)
    {
        return _toys.FirstOrDefault(toy => toy.Name == name);
        //return _toys.First(toy => toy.Name == name);
    }

    public int GetToysCount()
    {
        return _toys.Count;
    }

    public void AddNewToy(Toy toy)
    {
        _toys.Add(toy);
    }
}