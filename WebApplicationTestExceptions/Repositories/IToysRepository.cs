using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Repositories;

public interface IToysRepository
{
    List<Toy> GetAll();
    Toy GetByName(string name);
    int GetToysCount();
    void AddNewToy(Toy toy);
}