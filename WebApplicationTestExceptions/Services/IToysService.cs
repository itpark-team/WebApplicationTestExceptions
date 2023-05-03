using WebApplicationTestExceptions.Entities;

namespace WebApplicationTestExceptions.Services;

public interface IToysService
{
    List<Toy> GetAll();
    Toy GetByName(string name);
    int GetToysCount();
    void AddNewToy(Toy toy);
}