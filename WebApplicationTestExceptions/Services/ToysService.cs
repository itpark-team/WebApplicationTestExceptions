using FluentValidation.Results;
using WebApplicationTestExceptions.Entities;
using WebApplicationTestExceptions.Exceptions;
using WebApplicationTestExceptions.Repositories;
using WebApplicationTestExceptions.Validators;

namespace WebApplicationTestExceptions.Services;

public class ToysService
{
    private ToysRepository _toysRepository;

    public ToysService()
    {
        _toysRepository = ToysRepository.Instance;
    }

    public List<Toy> GetAll()
    {
        return _toysRepository.GetAll();
    }

    public Toy GetByName(string name)
    {
        Toy result = _toysRepository.GetByName(name);

        if (result == null)
        {
            throw new UserException("GetByName Exception", $"toy with {name} not found", 400);
        }

        return result;
    }

    public int GetToysCount()
    {
        int result = _toysRepository.GetToysCount();

        if (result < 100)
        {
            throw new ServerException("GetToysCount Exception", $"toys smaller than 100", 500);
        }

        return result;
    }

    public void AddNewToy(Toy toy)
    {
        ToyValidator toyValidator = new ToyValidator();
        ValidationResult result = toyValidator.Validate(toy);

        if (result.IsValid)
        {
            _toysRepository.AddNewToy(toy);
        }
        else
        {
            
            throw new UserException("AddNewToy Exception", $"Invalid data {result.ToString(", ")}", 400);
        }
    }
}