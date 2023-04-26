using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Repositories;

public class ToysRepository
{
    private static ToysRepository _instance = null;

    public static ToysRepository Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ToysRepository();
            }

            return _instance;
        }
    }

    private List<Toy> _toys;

    private ToysRepository()
    {
        _toys = new List<Toy>()
        {
            new Toy() { Name = "Лего", Price = 900, AgeLimit = "3-5" },
            new Toy() { Name = "Мишка", Price = 200, AgeLimit = "0+" },
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