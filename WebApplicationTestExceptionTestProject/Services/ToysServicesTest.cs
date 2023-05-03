using Moq;
using WebApplicationTestExceptions.Entities;
using WebApplicationTestExceptions.Repositories;
using WebApplicationTestExceptions.Services;

namespace WebApplicationTestExceptionTestProject.Services;

public class ToysServicesTest
{
    [Fact]
    public void GetByName_Лего_ReturnExistToy()
    {
        //подготовка
        string name = "Лего";

        Mock<IToysRepository> toysRepository = new Mock<IToysRepository>();
        toysRepository.Setup(exp => exp.GetByName("Лего"))
            .Returns(new Toy() { Id = 1, Name = "Лего", Price = 900, AgeLimit = "3-5" });

        ToysService toysService = new ToysService(toysRepository.Object);

        //тестирование
        Toy toy = toysService.GetByName(name);

        int expectedPrice = 900;
        int actualPrice = toy.Price;

        //проверка
        Assert.Equal(expectedPrice, actualPrice);
    }
}